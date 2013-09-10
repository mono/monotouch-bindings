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

		CBLReplication pull;
		CBLReplication push;

		UIProgressView Progress { get; set; }
 		
		public CBLDatabase Database { get; set; }

		#region Initialization/Configuration

		public RootViewController () : base ("RootViewController", null)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Grocery Sync", "Grocery Sync");
		}

		public ConfigViewController DetailViewController { get;	set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var deleteButton = new UIBarButtonItem ("Clean", UIBarButtonItemStyle.Plain, DeleteCheckedItems);
			NavigationItem.RightBarButtonItem = deleteButton;

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

			NavigationController.NavigationBar.TintColor = new UIColor (0.564f, 0.0f, 0.015f, 0f);
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
			var db = CBLManager.SharedInstance.CreateDatabaseNamed ("grocery-sync", out error);
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
			var mapBlock = new CBLMapBlock ((doc, aview) => {
				NSObject date  = doc.ObjectForKey (key);
				if (date  != null) {
					aview.Emit (date, doc);
				}
			});

			view.SetMapBlock (mapBlock, null, "1.1");

			var validationBlock = new CBLValidationBlock ((revision, context)=>{
				if (revision.IsDeleted) return true;

				NSObject date = revision.Properties.ObjectForKey(key);
				return (date != null);
			});

			Database.DefineValidation ((NSString)key, validationBlock);

		}

		void InitializeDatasource ()
		{
			var view = Database.ViewNamed (DefaultViewName);
			CBLLiveQuery query = view.Query.AsLiveQuery;
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
				foreach (CBLQueryRow row in Datasource.Rows)
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
				throw new ApplicationException ("failed to save a new document");

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
				Datasource.DeleteDocuments(CheckedDocuments.ToArray(), out error);
			};
			alert.Show ();
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
				pull = repls [0] as CBLReplication;
				push = repls [1] as CBLReplication;
				pull.Continuous = push.Continuous = true;
				pull.Persistent = push.Persistent = true;
				var nctr = NSNotificationCenter.DefaultCenter;
				nctr.AddObserver ((NSString)ReplicationChangeNotification, ReplicationProgress, pull);
				nctr.AddObserver ((NSString)ReplicationChangeNotification, ReplicationProgress, push);
			}
		}

		void ReplicationProgress(NSNotification notification)
		{
			if (pull.Mode == CBLReplicationMode.Active || push.Mode == CBLReplicationMode.Active) {
				var completed = pull.Completed + push.Completed;
				var total = pull.Total + push.Total;
				Debug.WriteLine ("Sync Progress: {0}/{1}", completed, total);
				ShowSyncStatus ();
				Progress.Progress = total == 0 
					? 1f
					: (float)completed / (float)Math.Max(total, 1u);
			} else {
				ShowSyncButton ();
			}
		}

		void ShowSyncStatus ()
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

		#region Error Handling

		public void ShowErrorAlert (string errorMessage, NSError error, Boolean fatal = false)
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
			var controller = new ConfigViewController ();
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

		#endregion
	}
}
