using MonoTouch.UIKit;
using System;
using MonoTouch.Foundation;

namespace WEPopover.Sample
{
	partial class RootViewController : UITableViewController
	{
		public RootViewController (IntPtr handle) : base (handle)
		{
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			//Show an edit button
			//NavigationItem.RightBarButtonItem = EditButtonItem;
			
			this.TableView.Source = new DataSource (this);
		}
		
		/*
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}
		*/
		/*
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}
		*/
		/*
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}
		*/
		/*
		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}
		*/
		
		/*
		// Override to allow orientations other than the default portrait orientation
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			//return true for supported orientations
			return (InterfaceOrientation == UIInterfaceOrientation.Portrait);
		}
		*/
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidUnload ()
		{
			// Release anything that can be recreated in viewDidLoad or on demand.
			// e.g. this.myOutlet = null;
			
			base.ViewDidUnload ();
		}
		
		class DataSource : UITableViewSource
		{
			RootViewController controller;
			
			public DataSource (RootViewController controller)
			{
				this.controller = controller;
			}
			
			public override int NumberOfSections (UITableView tableView)
			{
				return 1;
			}
			
			// Customize the number of rows in the table view
			public override int RowsInSection (UITableView tableview, int section)
			{
				return 0;
			}
			
			// Customize the appearance of table view cells.
			public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				string cellIdentifier = "Cell";
				var cell = tableView.DequeueReusableCell (cellIdentifier);
				if (cell == null) {
					cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
				}
				
				// Configure the cell.
				
				return cell;
			}
			
			/*
			// Override to support conditional editing of the table view.
			public override bool CanEditRow (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				// Return false if you do not want the specified item to be editable.
				return true;
			}
			*/
			/*
			// Override to support editing the table view.
			public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				if (editingStyle == UITableViewCellEditingStyle.Delete) {
					controller.TableView.DeleteRows (new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
				} else if (editingStyle == UITableViewCellEditingStyle.Insert) {
					// Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
				}
			}
			*/
			/*
			// Override to support rearranging the table view.
			public override void MoveRow (UITableView tableView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
			{
			}
			*/
			/*
			// Override to support conditional rearranging of the table view.
			public override bool CanMoveRow (UITableView tableView, NSIndexPath indexPath)
			{
				// Return false if you do not want the item to be re-orderable.
				return true;
			}
			*/
			
			// Override to support row selection in the table view.
			public override void RowSelected (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				// Navigation logic may go here -- for example, create and push another view controller.
				// var anotherViewController = new AnotherViewController ("AnotherView", null);
				//controller.NavigationController.PushViewController (anotherViewController, true);
			}
		}
	}
	
}

