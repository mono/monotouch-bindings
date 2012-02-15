using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Tapku;
using System.Collections.Specialized;

namespace TapkuSample
{
	public partial class RootViewController1 : UITableViewController
	{
		
		public RootViewController1(UITableViewStyle style) : base (style)
		{
			Title = "Tapku Library";	
		}		
		
		protected List<object> Data;
		
		public override void ViewDidLoad ()
		{
			
			base.ViewDidLoad ();
			
			SetupCellData();
			
			TableView.Source = new MyTableViewSource(this);
		}
		
		void SetupCellData()
		{
			NSArray rows;
			NSDictionary d;
			

			List<object> tmp = new List<object>();
			
			rows = NSArray.FromObjects("Coverflow", "Graph", "Month Grid Calendar");
			d = NSDictionary.FromObjectsAndKeys(new object[]{ rows, "Views"}, new string[]{"rows", "title"}); 
			tmp.Add(d);
			
			
			/*rows = NSArray.FromObjects("Month");
			d = NSDictionary.FromObjectsAndKeys(new object[]{ rows, "Calendar"}, new string[]{"rows", "title"}); 
			tmp.Add(d);
			*/
			
			rows = NSArray.FromObjects("Empty Sign", "Loading HUD", "Alerts", "Place Pins");
			d = NSDictionary.FromObjectsAndKeys(new object[]{ rows, "UI Elements"}, new string[]{"rows", "title"}); 
			tmp.Add(d);
			
			
			rows = NSArray.FromObjects("Label Cells", "More Cells", "Indicator Cells");
			d = NSDictionary.FromObjectsAndKeys(new object[]{ rows, "Table View Cells", ""}, new string[]{"rows", "title", "footer"}); 
			tmp.Add(d);
			
			
			rows = NSArray.FromObjects("Image Center");
			d = NSDictionary.FromObjectsAndKeys(new object[]{ rows, "Network", ""}, new string[]{"rows", "title", "footer"}); 
			tmp.Add(d);
			
			Data = tmp;
			
			//data = [[NSArray alloc] initWithArray:tmp];*/
		}
		
		public class MyTableViewSource : UITableViewSource
		{
			
			RootViewController1 _vc;
			
			public MyTableViewSource (RootViewController1 vc)
			{
				_vc = vc;	
			}
			
			#region implemented abstract members of MonoTouch.UIKit.UITableViewSource
			
			public override int NumberOfSections (UITableView tableView)
			{
				return _vc.Data.Count;
			}
			
			public override int RowsInSection (UITableView tableview, int section)
			{
				var item = _vc.Data[section] as NSMutableDictionary;
				var listOfKeys = item.ObjectForKey(new NSString("rows")) as NSArray;
				return (int) listOfKeys.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = _vc.TableView.DequeueReusableCell("myCell");
				if(cell == null)
				{
					cell = new UITableViewCell(UITableViewCellStyle.Default, "myCell");	
				}
				
				// This is C# code from 
				// [[[data objectAtIndex:indexPath.section] objectForKey:@"rows"] objectAtIndex:indexPath.row];
				// Obj-C code...
				var item = _vc.Data[indexPath.Section] as NSMutableDictionary;
				var listOfKeys = item.ObjectForKey(new NSString("rows")) as NSArray;
				
				cell.TextLabel.Text = NSString.FromHandle (listOfKeys.ValueAt ((uint)indexPath.Row)).ToString();
				return cell;
			}
			
			public override string TitleForHeader (UITableView tableView, int section)
			{
				var item = _vc.Data[section] as NSMutableDictionary;
				var title = item.ObjectForKey(new NSString("title")) as NSString;
				return title;
				//return data[section] as N objectForKey:@"title"];
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}
			
			public override string TitleForFooter (UITableView tableView, int section)
			{
				var item = _vc.Data[section] as NSMutableDictionary;
				var title = item.ObjectForKey(new NSString("footer")) as NSString;
				return title ?? "";
				
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}
			
			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				
				tableView.DeselectRow(indexPath, true);
				//[tv deselectRowAtIndexPath:indexPath animated:YES];
				UIViewController vc;
				
				int s = indexPath.Section;
				int r = indexPath.Row;
				
				if(s == 0 && r < 2) 
				{
					if (r == 0)
						vc = new HUDViewController();
						//vc = new CoverflowViewController();
					else
						vc = new HUDViewController();
						//vc = new GraphController();
					//vc = new UIViewController();
					vc.ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve;
					_vc.PresentModalViewController(vc, true);
					return;
				}
				if(s == 0 && r == 2)
				{
					//vc = new DemoCalendarMonth();	
				}
	
				if(s==0&&r==2)
					vc = new DemoCalendarMonth();
					//vc = [[DemoCalendarMonth alloc] initWithSunday:NO];
				else if(s==1 && r==0)
					vc = new EmptyViewController();
				else if(s==1 && r==1)
					vc = new HUDViewController();
				else if(s==1 && r==2)
					vc = new AlertsViewController();
				else if(s==1 && r==3)
					vc = new MapViewController();
				
				
				else if(s==2 && r==0)
					vc = new HUDViewController();
					//vc = [[LabelViewController alloc] initWithStyle:UITableViewStyleGrouped];
				else if(s==2 && r==1)
					vc = new HUDViewController();
					//vc = [[MoreCellsViewController alloc] initWithStyle:UITableViewStyleGrouped];
				else if(s==2 && r==2)
					vc = new HUDViewController();
					//vc = [[FastTableViewController alloc] init];
				else
					vc = new TweetViewController();
				
				_vc.NavigationController.PushViewController(vc, true);
				
			}
			
			#endregion
			
		}
	}
}
