
using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using MonoTouch.CoreFoundation;

using DropBoxSync.iOS;

namespace DropBoxSyncSampleMTD
{
	public partial class DVCFiles : DialogViewController
	{
		DVCFiles filesController;
		DBPath path;
		bool creatingFolder;

		public DVCFiles (DBPath path) : base (UITableViewStyle.Plain, null, true)
		{
			this.path = path;
			DispatchQueue.DefaultGlobalQueue.DispatchAsync (() => {
				LoadFiles ();
			});

			Root = new RootElement (string.IsNullOrWhiteSpace (path.Name) ? "/" : path.Name) {
				new Section (){
					new StringElement ("Loading...") {
						Alignment = UITextAlignment.Center
					}
				}
			};
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			var createButton = new UIBarButtonItem (UIBarButtonSystemItem.Add);
			createButton.Clicked += (sender, e) => {
				var sheet = new UIActionSheet ("What do you want to create?");
				sheet.AddButton ("New File");
				sheet.AddButton ("New Folder");
				sheet.AddButton ("Cancel");
				sheet.CancelButtonIndex = 2;
				sheet.ShowInView (View);
				sheet.Clicked += HandleCreateSheetClicked;
			};
			NavigationItem.RightBarButtonItem = createButton;
		}

		void HandleCreateSheetClicked (object sender, UIButtonEventArgs e)
		{
			var actionSheet = (UIActionSheet)sender;
			if (e.ButtonIndex != actionSheet.CancelButtonIndex) {
				creatingFolder = e.ButtonIndex > 0;
				string title = creatingFolder ? "Create folder" : "Create a file";
				var alert = new UIAlertView (title, "", null, "Cancel", new string[] {"Create"});
				alert.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
				alert.Clicked += (s, a) => {
					if (a.ButtonIndex != alert.CancelButtonIndex) {
						string input = alert.GetTextField (0).Text;
							CreateAt (input);
					}
					DispatchQueue.DefaultGlobalQueue.DispatchAsync (() => LoadFiles ());
				};
				alert.Show ();
			}
		}

		public void CreateAt (string input)
		{
			DBError error;
			if (!creatingFolder) {
				string noteFilename = string.Format ("{0}.txt", input);
				var newPath = path.ChildPath (noteFilename);
				var file = DBFilesystem.SharedFilesystem.CreateFile (newPath, out error);
				
				if (file == null)
					new UIAlertView ("Unable to create note", "An error has occurred: " + error.Description, null, "Ok", null).Show ();
				else {
					var controller = new NoteController (file);
					NavigationController.PushViewController (controller, true);
				}
			} else {
				var newPath = path.ChildPath (input);
				bool success = DBFilesystem.SharedFilesystem.CreateFolder (newPath, out error);
				if (!success)
					new UIAlertView ("Unable to create folder", "An error has occurred: " + error.Description, null, "Ok", null).Show ();
				else {
					var controller = new DVCFiles (newPath);
					NavigationController.PushViewController (controller, true);
				}
			}
		}

		void LoadFiles ()
		{
			DBError error;
			var contents = DBFilesystem.SharedFilesystem.ListFolder (path, out error);

			InvokeOnMainThread (()=> {	
				Root.Clear ();
				Root.Add (new Section ());
			});
			foreach (DBFileInfo info in contents) {
				var localinfo = info;

				var filerow = new StyledStringElement (localinfo.Path.Name, () => {
					if (localinfo.IsFolder) {
						filesController = new DVCFiles (localinfo.Path);
						NavigationController.PushViewController (filesController, true);
					} else {
						DBError err;
						var file = DBFilesystem.SharedFilesystem.OpenFile (localinfo.Path, out err);
						var noteController = new NoteController (file);
						NavigationController.PushViewController (noteController, true);
					}
				}) {
					Accessory = localinfo.IsFolder ? UITableViewCellAccessory.DisclosureIndicator : UITableViewCellAccessory.None
				};
				InvokeOnMainThread (()=> Root[0].Add (filerow));
			}
		}
	}
}
