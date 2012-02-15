using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Tapku;

namespace TapkuSample
{
	public partial class AlertsViewController : UIViewController
	{
		//loads the AlertsViewController.xib file and connects it to this object
		public AlertsViewController ()
		{
			Title = "Alerts";
			NavigationItem.RightBarButtonItem = new UIBarButtonItem("Tap Me", UIBarButtonItemStyle.Bordered, (sender, e) => {
				
				//TKAlertCenter.DefaultCenter.PostAlert("Beer!", UIImage.FromFile("Images/beer.png"));
			});
		}
		
		public override void LoadView ()
		{
			base.LoadView ();
			
			View.BackgroundColor = UIColor.White;

		}
		
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			
			TKAlertCenter.DefaultCenter.PostAlert("Hi");
			TKAlertCenter.DefaultCenter.PostAlert("This is the alert system");
			//TKAlertCenter.DefaultCenter.PostAlert("Use images too!", UIImage.FromFile("Images/beer.png"));
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
		
	}
}
