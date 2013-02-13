using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using DropBoxSync.iOS;
using System.Linq;

namespace DropBoxSyncSampleiOS
{
	public enum RowType
	{
		LinkRow,
		UnlinkRow,
		AccountRow
	}

	public class SettingsController : UITableViewController
	{
		public UITableViewCell AccountCell { get; set; }
		public UITableViewCell LinkCell { get; set; }
		public DBAccountManager Manager { get; set; }
		FolderListController folderController;

		public SettingsController (DBAccountManager manager) : base (UITableViewStyle.Grouped)
		{
			Manager = manager;
			Title = "Settings";
			Manager.AddObserver (this, (account) => {
				AccountUpdated (account);
			});
			TableView.Source = new SettingsControllerSource (this);
		}

		public SettingsController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			AccountCell = new UITableViewCell (UITableViewCellStyle.Default, null) {
				Accessory = UITableViewCellAccessory.DisclosureIndicator
			};

			LinkCell = new UITableViewCell (UITableViewCellStyle.Default, null);
			LinkCell.TextLabel.TextAlignment = UITextAlignment.Center;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			TableView.ReloadData ();
		}

		protected override void Dispose (bool disposing)
		{
			Manager.RemoveObserver (this);
			base.Dispose (disposing);
		}

		[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return toInterfaceOrientation == UIInterfaceOrientation.Portrait ? true : false;
		}

		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations ()
		{
			return UIInterfaceOrientationMask.Portrait;
		}

		public override UIInterfaceOrientation PreferredInterfaceOrientationForPresentation ()
		{
			return UIInterfaceOrientation.Portrait;
		}

		void AccountUpdated (DBAccount account)
		{
			if (!account.Linked && CurrentAccount () == account) {
				NavigationController.PopToViewController (this, true);
				new UIAlertView ("Info", "Your account was unlinked!", null, "Ok", null).Show ();
			} else
				TableView.ReloadData ();
		}

		DBAccount CurrentAccount ()
		{
			var viewControllers = NavigationController.ViewControllers;
			if (viewControllers.Count() < 2)
				return null;

			var folderController = (FolderListController)viewControllers.ElementAt (1);
			return folderController.Account;
		}
	}

	public class SettingsControllerSource : UITableViewSource
	{
		SettingsController ctlr;

		public SettingsControllerSource (SettingsController controller)
		{
			ctlr = controller;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			switch (RowTypeForIndexPath (indexPath)) {
			case RowType.AccountRow:
				var account = ctlr.Manager.LinkedAccount;
				var fileSystem = new DBFilesystem (account);
				Console.WriteLine ("Created filesystem " + fileSystem.Description);
				var controller = new FolderListController (fileSystem, DBPath.Root);
				ctlr.NavigationController.PushViewController (controller, true);
				break;
			case RowType.LinkRow:
				ctlr.Manager.LinkFromController (ctlr.NavigationController);
				break;
			case RowType.UnlinkRow:
				ctlr.Manager.LinkedAccount.Unlink ();
				break;
			default:
				break;
			}
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return ctlr.Manager.LinkedAccount != null ? 2 : 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return 1;
		}
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			switch (RowTypeForIndexPath (indexPath)) {
			case RowType.AccountRow:
				string text = "DropBox";
				if (ctlr.Manager.LinkedAccount.Info != null) {
					text += " " + ctlr.Manager.LinkedAccount.Info.DisplayName;
				}

				ctlr.AccountCell.TextLabel.Text = text;
				return ctlr.AccountCell;
			case RowType.LinkRow:
				ctlr.LinkCell.TextLabel.Text = "Link";
				return ctlr.LinkCell;
			case RowType.UnlinkRow:
				ctlr.LinkCell.TextLabel.Text = "Unlink";
				return ctlr.LinkCell;
			default:
				return null;
			}
		}

		RowType RowTypeForIndexPath (NSIndexPath indexPath)
		{
			if (indexPath.Section == 0) {
				if (ctlr.Manager.LinkedAccount != null)
					return RowType.AccountRow;
				else
					return RowType.LinkRow;
			} else 
				return RowType.UnlinkRow;
		}
	}
}

