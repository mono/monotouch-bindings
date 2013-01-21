
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Linq;

namespace Scrumptious
{
	public partial class SCMealViewController : UIViewController
	{

		public string [] meals = new string [] {	"Cheeseburger", 
			                                        "Pizza",
			                                        "Hotdog",
			                                        "Italian",
			                                        "French",
			                                        "Chinese",
			                                        "Thai",
			                                        "Indian" } ;
		public SCViewController pController;

		public SCMealViewController () : base ("SCMealViewController", null)
		{
		}

		public SCMealViewController (SCViewController pController) : base ("SCMealViewController", null)
		{
			this.pController = pController;
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear(animated);

			tableView.Source = new MyMealSource(this);
		}
	}

	public class MyMealSource : MonoTouch.UIKit.UITableViewSource
	{
		SCMealViewController ctrl;

		public MyMealSource (SCMealViewController ctrl)
		{
			this.ctrl = ctrl;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return ctrl.meals.Count();
		}		

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			string CellIdentifier = "Cell";
			
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			if (cell == null) 
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
			}    
			
			cell.TextLabel.Text = ctrl.meals[indexPath.Row];
			cell.ImageView.Image = new UIImage(Environment.CurrentDirectory + "/images/action-eating.png");

			return cell;
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			ctrl.pController.selectedMeal = ctrl.meals[indexPath.Row];
			ctrl.pController.UpdateSelections();
			ctrl.NavigationController.PopViewControllerAnimated(true);
		}
	}

}

