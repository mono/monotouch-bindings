// 
//  Copyright 2012  abhatia
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using UIKit;
using WEPopover;
using Foundation;
using CoreGraphics;

namespace WEPopoverSample
{
	public class TableViewController : UITableViewController
	{	
		UIBarButtonItem _ButtonItem;
		
		public TableViewController()
			: base()
		{
		}
		
		public override void LoadView()
		{
			base.LoadView();
			this.View.BackgroundColor = UIColor.White;
			this.NavigationItem.Title = "Popover Sample";
			
			this.TableView.Source = new TableViewSource(this);
			this.NavigationController.NavigationBar.Hidden = false;
			
			_ButtonItem = new UIBarButtonItem("Info", UIBarButtonItemStyle.Plain, (o, e) => {
				Popover.PresentFromRect(this.NavigationController.NavigationBar.Frame, 
				                        this.NavigationController.NavigationBar, UIPopoverArrowDirection.Any, true);
			});
			
			this.NavigationItem.SetRightBarButtonItem(_ButtonItem, true);
			
			
			// Popover is a singleton we start by "initializing" it
			Popover.Initialize();
			Popover.ShouldDismiss = true;
			
			// This is how we get notified that the popover was closed
			Popover.PopoverClosed += DidDismissPopover;
			
			var puppyView = new UIImageView(UIImage.FromFile("Images/smile.png"))  {
				Frame = new CGRect(0, 0, 367, 367),
			};
			
			Popover.ContentViewController = new UIViewController() {
				View = puppyView,
				ContentSizeForViewInPopover = new CGSize(367, 367),
			};

			if (UIDevice.CurrentDevice.CheckSystemVersion (7, 0)) {
				Popover.ContentViewController.PreferredContentSize = Popover.ContentViewController.ContentSizeForViewInPopover;
			}
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}
		
		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();
		}
		
		public void DidDismissPopover(PopoverController popover)
		{
			Console.WriteLine("Popover Did Dismiss...");
		}
		
		public class TableViewSource : UITableViewSource
		{
			const string id = "cell";
			UITableViewController _Controller;
			
			public TableViewSource(UITableViewController controller)
				: base()
			{
				_Controller = controller;
			}
			
			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return 10;
			}
			
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell(id);
				
				if (cell == null) {
					cell = new UITableViewCell(UITableViewCellStyle.Default, id);
					cell.TextLabel.Text = string.Format("Click Cell for Popover -- {0}", indexPath.Row);
				}
				
				return cell;
			}
			
			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				Popover.PresentFromRect(tableView.RectForRowAtIndexPath(indexPath), tableView, UIPopoverArrowDirection.Any, true);
				
			}
			
		}
		
	}
}

