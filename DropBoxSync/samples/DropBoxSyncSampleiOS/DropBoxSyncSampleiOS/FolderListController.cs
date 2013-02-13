using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using DropBoxSync.iOS;
using MonoTouch.CoreFoundation;
using System.Linq;

namespace DropBoxSyncSampleiOS
{
	public class FolderListController : UITableViewController
	{
		public DBAccount Account { get; set; }
		public DBFilesystem Filesystem { get; set; }
		public DBPath Root { get; set; }
		public DBFileInfo [] Contents { get; set; }
		public bool CreatingFolder { get; set; }
		public DBPath FromPath { get; set; }
		public UITableViewCell LoadingCell { get; set; }
		public bool LoadingFiles { get; set; }
		public bool Moving { get; set; }

		public FolderListController (DBFilesystem filesystem, DBPath root) : base ()
		{
			Filesystem = filesystem;
			Root = root;
			NavigationItem.Title = Root.Equals (DBPath.Root) ? "Dropbox" : root.Name;
			TableView.Source = new MyFolderTableViewSource (this);
		}

		public FolderListController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			Filesystem.AddObserverForPathAndChildren (this, Root, () => LoadFiles() );
			NavigationController.ToolbarHidden = false;
			LoadFiles ();
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			Filesystem.RemoveObserver (this);

			if (NavigationController.ViewControllers.Count () == 1)
				Filesystem.Dispose ();
		}

		public void LoadFiles ()
		{
			if (LoadingFiles) return;

			LoadingFiles = true;
			DispatchQueue.DefaultGlobalQueue.DispatchAsync ( ()=> {
				DBError error;
				var immContents = Filesystem.ListFolder (Root, out error);
				DispatchQueue.MainQueue.DispatchAsync ( ()=> {
					Contents = immContents;
					LoadingFiles = false;
					Reload ();
				});
			});
		}

		public void Reload ()
		{
			TableView.ReloadData ();
			var moveItem = new UIBarButtonItem ("Move", UIBarButtonItemStyle.Bordered, this, new MonoTouch.ObjCRuntime.Selector ("didPressMove"));

			if (Contents != null) moveItem.Enabled = true;
			else moveItem.Enabled = false;

			if (Moving) {
				moveItem.Enabled = false;
				var messageItem = new UIBarButtonItem ("Select a file to move", UIBarButtonItemStyle.Plain, null, null);
				ToolbarItems = new UIBarButtonItem [] { moveItem, messageItem };
				NavigationItem.RightBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.Cancel, this, new MonoTouch.ObjCRuntime.Selector ("didPressCancel"));
			} else {
				ToolbarItems = new UIBarButtonItem [] { moveItem };
				NavigationItem.RightBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.Add, this, new MonoTouch.ObjCRuntime.Selector ("didPressAdd"));
			}
		}

		[Export ("didPressAdd")]
		void DidPressAdd ()
		{
			var actionSheet = new UIActionSheet (null, null, "Cancel", null, new string [] { "Create File", "Create Folder" });
			actionSheet.Clicked += (sender, e) => 
			{
				if (e.ButtonIndex != actionSheet.CancelButtonIndex) {
					CreatingFolder = e.ButtonIndex > 0;
					string title = CreatingFolder ? "Create folder" : "Create a file";

					var alert = new UIAlertView (title, "", null, "Cancel", new string[] {"Create"});
					alert.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
					alert.Clicked += (s, a) => {
						if (a.ButtonIndex != alert.CancelButtonIndex) {
							string input = alert.GetTextField (0).Text;
							if (Moving) 
								MoveTo (input);
							else
								CreateAt (input);
						}
						Moving = false;
						FromPath = null;
						LoadFiles ();
					};
					alert.Show ();
				}
			};
			actionSheet.ShowInView (NavigationController.View);
		}

		[Export ("didPressCancel")]
		void DidPressCancel ()
		{
			Moving = false;
			Reload ();
		}

		[Export ("didPressMove")]
		void DidPressMove ()
		{
			Moving = true;
			Reload ();
		}

		public void CreateAt (string input)
		{
			DBError error;
			if (!CreatingFolder) {
				string noteFilename = string.Format ("{0}.txt", input);
				var path = Root.ChildPath (noteFilename);
				var file = Filesystem.CreateFile (path, out error);

				if (file == null)
					new UIAlertView ("Unable to create note", "An error has occurred: " + error.Description, null, "Ok", null).Show ();
				else {
					var controller = new NoteController (file);
					NavigationController.PushViewController (controller, true);
				}
			} else {
				var path = Root.ChildPath (input);
				bool success = Filesystem.CreateFolder (path, out error);

				if (!success)
					new UIAlertView ("Unable to create folder", "An error has occurred: " + error.Description, null, "Ok", null).Show ();
				else {
					var controller = new FolderListController (Filesystem, path);
					NavigationController.PushViewController (controller, true);
				}
			}
		}

		public void MoveTo (string input)
		{
			DBError error;
			var components = input.Split ('/');
			int startIndex = 0;
			DBPath path = Root;
			if (components[0].Length == 0) {
				path = DBPath.Root;
				startIndex = 1;
			}

			foreach (var component in components) {
				if (component == "..")
					path = path.Parent;
				else
					path = path.ChildPath (component);
			}
			Filesystem.MovePath (FromPath, path, out error);
			Moving = false;
			FromPath = null;
		}

		public UITableViewCell loadingCell ()
		{
			if (LoadingCell == null) {
				LoadingCell = new UITableViewCell (UITableViewCellStyle.Default, null);
				LoadingCell.TextLabel.Text = "Loading...";
				LoadingCell.TextLabel.TextAlignment = UITextAlignment.Center;
			}
			return LoadingCell;
		}

		DBAccount account ()
		{
			return Filesystem.Account;
		}
	}

	public class MyFolderTableViewSource : UITableViewSource
	{
		FolderListController ctrl;

		public MyFolderTableViewSource (FolderListController controller)
		{
			ctrl = controller;
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			if (ctrl.Contents == null) return 1;
			return ctrl.Contents.Count();
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			if (ctrl.Contents == null) return ctrl.loadingCell();
			

			string cellid = "Cell";
			var cell = tableView.DequeueReusableCell (cellid);
			if (cell == null) 
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellid);
			var info = ctrl.Contents.ElementAt (indexPath.Row);
			cell.TextLabel.Text = info.Path.Name;

			if (info.IsFolder) 
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			else
				cell.Accessory = UITableViewCellAccessory.None;
			return cell;
		}

		public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			DBError error;
			var info = ctrl.Contents.ElementAt (indexPath.Row);
			if (ctrl.Filesystem.DeletePath (info.Path, out error)) {
				var listcontents = ctrl.Contents.ToList();
				listcontents.RemoveAt (indexPath.Row);
				ctrl.Contents = listcontents.ToArray();
				tableView.DeleteRows (new NSIndexPath[] { indexPath }, UITableViewRowAnimation.None);
			} else {
				new UIAlertView ("Error", "There was an error deleting that file: " + error.Description, null, "Ok", null).Show ();
				ctrl.Reload ();
			}
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			if (ctrl.Contents.Count() <= indexPath.Row) return;

			DBError error;

			var info = ctrl.Contents.ElementAt (indexPath.Row);
			if (!ctrl.Moving) {
				UIViewController controller;
				if (info.IsFolder)
					controller = new FolderListController (ctrl.Filesystem, info.Path);
				else {
					var file = ctrl.Filesystem.OpenFile (info.Path, out error);
					if (file == null) {
						new UIAlertView ("Error", "There was an error opening your note: " + error.Description, null, "Ok", null).Show ();
						return;
					}
					controller = new NoteController (file);
				}
				ctrl.NavigationController.PushViewController (controller, true);
			} else {
				ctrl.FromPath = info.Path;
				var alert = new UIAlertView ("Choose a destination", "", null, "Cancel", new string[] {"Move"});
				alert.AlertViewStyle = UIAlertViewStyle.PlainTextInput;

				alert.Clicked += (sender, e) => {
					if (e.ButtonIndex != alert.CancelButtonIndex) {
						string input = alert.GetTextField (0).Text;
						if (ctrl.Moving)
							ctrl.MoveTo (input);
						else
							ctrl.CreateAt (input);
					}
					ctrl.Moving = false;
					ctrl.FromPath = null;
					ctrl.LoadFiles();
				};

				alert.Show ();
			}
		}
	}
}

