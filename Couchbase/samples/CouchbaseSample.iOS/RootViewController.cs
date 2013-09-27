using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Linq;

using Couchbase;
using System.Diagnostics;

namespace CouchbaseSample
{
	public partial class RootViewController : UIViewController
	{
		private  const string ReplicationChangeNotification = "CBLReplicationChange";
		private  const string DefaultViewName = "byDate";
		private  const string DocumentDisplayPropertyName = "text";
		internal const string CheckboxPropertyName = "check";

		Boolean showingSyncButton;

		Replication pull;
		Replication push;

		uint _lastPushCompleted;
		uint _lastPullCompleted;

		Replication _leader;

		UIProgressView Progress { get; set; }
 		
		public Database Database { get; set; }

		#region Initialization/Configuration

		public RootViewController () : base ("RootViewController", null)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Grocery Sync", "Grocery Sync");
		}

		public ConfigViewController DetailViewController { get;	set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var addButton = new UIBarButtonItem ("Clean", UIBarButtonItemStyle.Plain, DeleteCheckedItems);
			NavigationItem.RightBarButtonItem = addButton;

			ShowSyncButton ();

			EntryField.ShouldEndEditing += (sender) => { 
				EntryField.ResignFirstResponder (); 
				return true; 
			};

			EntryField.EditingDidEndOnExit += AddNewItem;

			// Custom initialization
			InitializeDatabase ();
			InitializeCouchbaseView ();
			InitializeDatasource ();

			Datasource.TableView = TableView;
			Datasource.TableView.Delegate = new CouchtableDelegate(this, Datasource);

			UIImage backgroundImage = null;
			switch(Convert.ToInt32(UIScreen.MainScreen.PreferredMode.Size.Height))
			{
			case 480:
				backgroundImage = UIImage.FromBundle ("Default");
				break;
			case 960:
				backgroundImage = UIImage.FromBundle ("Default@2x");
				break;
			case 1136:
				backgroundImage = UIImage.FromBundle ("Default-568h@2x");
				break;
			}

			var background = new UIImageView (UIImage.FromImage(backgroundImage.CGImage, UIScreen.MainScreen.Scale, UIImageOrientation.Up)) { ContentMode = UIViewContentMode.ScaleAspectFill, ContentScaleFactor = UIScreen.MainScreen.Scale };
			background.AutosizesSubviews = true;
			background.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
			var newLocation = background.Frame.Location;
			newLocation.Y = -65f;
			background.Frame = new System.Drawing.RectangleF (newLocation, background.Frame.Size);

			// Handle iOS 7 specific code.
			if (AppDelegate.CurrentSystemVersion < AppDelegate.iOS7) {
				TableView.BackgroundColor = UIColor.Clear;
				TableView.BackgroundView = null;
				NavigationController.NavigationBar.TintColor = UIColor.FromRGB (0.564f, 0.0f, 0.015f);
			}

			View.InsertSubviewBelow (background, View.Subviews[0]);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear (animated);

			// Check for changes after returning from the sync config view:
			UpdateSyncUrl();
		}

		void InitializeDatabase ()
		{
			NSError error;
			var db = Manager.SharedInstance.CreateDatabaseNamed ("grocery-sync", out error);
			if (error != null)
				throw new ApplicationException (error.Description);
			else if (db == null)
				throw new ApplicationException("Could not create database");

			Database = db;
		}

		void InitializeCouchbaseView ()
		{
			var view = Database.ViewNamed (DefaultViewName);

			NSObject key = new NSString("created_at");
			var mapBlock = new MapBlock ((doc, emit) => {
				NSObject date  = doc.ObjectForKey (key);
				if (date  != null) {
					emit (date, doc);
				}
			});

			view.SetMapBlock (mapBlock, null, "1.1");

			var validationBlock = new ValidationBlock ((revision, context)=>{
				if (revision.IsDeleted) return true;

				NSObject date = revision.Properties.ObjectForKey(key);
				return (date != null);
			});

			Database.DefineValidation ((NSString)key, validationBlock);

		}

		void InitializeDatasource ()
		{
			var view = Database.ViewNamed (DefaultViewName);
			LiveQuery query = view.Query.AsLiveQuery;
			query.Descending = true;

			Datasource.Query = query;
			Datasource.LabelProperty = DocumentDisplayPropertyName; // Document property to display in the cell label
		}

		#endregion

		#region CRUD Operations

		IEnumerable<NSObject> CheckedDocuments
		{
			get
			{
				var docs = new List<NSObject> ();
				foreach (QueryRow row in Datasource.Rows)
				{
					var doc = row.Document;
					NSObject val;

					if (doc.Properties.TryGetValue ((NSString)CheckboxPropertyName, out val) && ((NSNumber)val).BoolValue)
					{
						docs.Add (doc);
					}
				}
				return docs;
			}
		}

		void AddNewItem (object sender, EventArgs args)
		{
			var value = EntryField.Text;
			if (String.IsNullOrWhiteSpace (value))
				return;

			var jsonDate = DateTime.UtcNow.ToString("o"); // ISO 8601 date/time format.
			var vals = NSDictionary.FromObjectsAndKeys (
				new NSObject[] { new NSString(value), NSNumber.FromBoolean(false), new NSString(jsonDate) }, 
				new NSObject[] { new NSString(DocumentDisplayPropertyName), new NSString(CheckboxPropertyName), new NSString("created_at") }
			);

			var doc = Database.UntitledDocument;
			NSError error;
			var result = doc.PutProperties (vals, out error);
			if (result == null)
				throw new ApplicationException ("failed to save a new document" + error.Description);

			var docContent = (NSDictionary)doc.Properties.MutableCopy ();
			var wasChecked = true;
			docContent.SetValueForKey (NSNumber.FromBoolean(!wasChecked), (NSString)"check");

			EntryField.Text = null;
		}

		void DeleteCheckedItems (object sender, EventArgs args)
		{
			var numChecked = CheckedDocuments.Count();
			if (numChecked == 0)
				return;

			var prompt = String.Format("Are you sure you want to remove the {0} checked-off item{1}?",
			                           numChecked,
			                           numChecked == 1 ? String.Empty : "s");

			var alert = new UIAlertView ("Remove Completed Items?",
			                            prompt,
			                            null,
			                            "Cancel",
			                            "Remove");

			alert.Dismissed += (alertView, e) => {
				if (e.ButtonIndex == 0) return;

				NSError error;
				var success = Datasource.DeleteDocuments(CheckedDocuments.ToArray(), out error);
				if (!success)
					ShowErrorAlert(error.Description);
			};
			alert.Show ();
		}

		#endregion

		#region Error Handling

		public void ShowErrorAlert (string errorMessage, NSError error = null, Boolean fatal = false)
		{
			if (error != null)
				errorMessage = String.Format ("{0}\r\n{1}", errorMessage, error.LocalizedDescription);

			var alert = new UIAlertView (fatal ? @"Fatal Error" : @"Error",
			                             errorMessage,
			                             null,
			                             fatal ? null : "Dismiss"
			                             );
			alert.Show ();
		}

		#endregion

		#region Sync

		void ConfigureSync(object sender, EventArgs args)
		{
			var navController = ParentViewController as UINavigationController;
			var controller = new ConfigViewController();
			if(AppDelegate.CurrentSystemVersion >= AppDelegate.iOS7)
			{
				controller.EdgesForExtendedLayout = UIRectEdge.None;
			}
			navController.PushViewController (controller, true);
		}

		void ShowSyncButton()
		{
			if (!showingSyncButton)
			{
				showingSyncButton = true;
				var button = new UIBarButtonItem ("Configure", UIBarButtonItemStyle.Plain, ConfigureSync);
				NavigationItem.LeftBarButtonItem = button;
			}
		}

		
		void UpdateSyncUrl()
		{
			if (Database == null) return;

			NSUrl newRemoteUrl = null;
			var syncPoint = NSUserDefaults.StandardUserDefaults.StringForKey(ConfigViewController.SyncUrlKey);
			if (!String.IsNullOrWhiteSpace (syncPoint))
				newRemoteUrl = new NSUrl (syncPoint);

			ForgetSync ();

			var repls = Database.ReplicateWithURL (newRemoteUrl, true);
			if (repls != null) {
				pull = repls [0] as Replication;
				push = repls [1] as Replication;
				pull.Continuous = push.Continuous = true;
				pull.Persistent = push.Persistent = true;
				var nctr = NSNotificationCenter.DefaultCenter;
				nctr.AddObserver ((NSString)ReplicationChangeNotification, ReplicationProgress, pull);
				nctr.AddObserver ((NSString)ReplicationChangeNotification, ReplicationProgress, push);
			}
		}

		void ReplicationProgress(NSNotification notification)
		{
			var active = notification.Object as Replication;
			Debug.WriteLine (String.Format("Push: {0}, Pull: {1}", push.Mode, pull.Mode));

			uint lastTotal = 0;

			if (_leader == null) {
				if (active.Pull && (pull.Mode == ReplicationMode.Active && push.Mode != ReplicationMode.Active))
				{
					_leader = pull;
				} else if (!active.Pull && (push.Mode == ReplicationMode.Active && pull.Mode != ReplicationMode.Active))	{
					_leader = push;
				} else {
					_leader = null;
				}
			} 
			if (active == pull)
				lastTotal = _lastPullCompleted;
			else
				lastTotal = _lastPushCompleted;


			Debug.WriteLine (String.Format("Sync: {2} Progress: {0}/{1};", active.Completed - lastTotal, active.Total - lastTotal, active == push ? "Push" : "Pull"));

			var progress = (float)(active.Completed - lastTotal) / (float)(Math.Max(active.Total - lastTotal, 1));

			if (AppDelegate.CurrentSystemVersion < AppDelegate.iOS7)
			{
				ShowSyncStatusLegacy ();
			}
			else
			{
				ShowSyncStatus ();
			}

			Debug.WriteLine (String.Format("({0})", progress));

			Progress.Hidden = false;

			if (progress < Progress.Progress)
				Progress.SetProgress (progress, false);
			else
				Progress.Progress = progress;

			if (!(pull.Mode != ReplicationMode.Active && push.Mode != ReplicationMode.Active))
				return;
			if (active == null)
				return;
			var initiatorName = _leader.Pull ? "Pull" : "Push";

			_lastPushCompleted = push.Completed;
			_lastPullCompleted = pull.Completed;

			if (Progress == null)
				return;
			Progress.Hidden = false;
			Progress.SetProgress (1f, true);

			var t = new System.Timers.Timer (300);
			t.Elapsed += (sender, e) => { 
				InvokeOnMainThread(()=>{
					t.Dispose();
					Progress.Hidden = true;
					Progress.SetProgress(0f, false);
					Debug.WriteLine(String.Format("{0} Sync Session Finished.", initiatorName));
					ShowSyncButton();
				});
			};
			t.Start ();

				}

		void ShowSyncStatus ()
		{
			if (showingSyncButton) {
				showingSyncButton = false;
				if (Progress == null) {
					Progress = new UIProgressView (UIProgressViewStyle.Bar);
					Progress.TintColor = UIColor.White;
					var frame = Progress.Frame;
					var size = new System.Drawing.SizeF (View.Frame.Size.Width, frame.Height);
					frame.Size = size;
					Progress.Frame = frame;
					Progress.SetProgress(0f, false);
				}
				var progressItem = new UIBarButtonItem (Progress);
				progressItem.Enabled = false;

				View.InsertSubviewAbove (Progress, View.Subviews [0]);
			}
		}

		void ShowSyncStatusLegacy ()
		{
			if (showingSyncButton) {
				showingSyncButton = false;
				if (Progress == null) {
					Progress = new UIProgressView (UIProgressViewStyle.Bar);
					var frame = Progress.Frame;
					var size = new System.Drawing.SizeF (View.Frame.Size.Width / 4f, frame.Height);
					frame.Size = size;
					Progress.Frame = frame;
				}
				var progressItem = new UIBarButtonItem (Progress);
				progressItem.Enabled = false;
				NavigationItem.LeftBarButtonItem = progressItem;
			}
		}

		void ForgetSync()
		{
			var nctr = NSNotificationCenter.DefaultCenter;

			if (pull != null)
			{
				nctr.RemoveObserver (this, null, pull);
				pull = null;
			}

			if (push != null)
			{
				nctr.RemoveObserver (this, null, push);
				push = null;
			}
		}
		#endregion
	}
}
