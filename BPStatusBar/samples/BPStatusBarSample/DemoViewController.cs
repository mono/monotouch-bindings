using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

using BPStatusBar;

namespace BPStatusBarSample
{
	public class DemoViewController : UIViewController
	{
		public DemoViewController () : base ()
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.BackgroundColor = UIColor.White;

			var btnShowMessage = UIButton.FromType (UIButtonType.RoundedRect);
			btnShowMessage.Frame = new RectangleF (20, 20, 280, 44);
			btnShowMessage.SetTitle ("Show Message", UIControlState.Normal);
			btnShowMessage.TouchUpInside += (sender, e) => {
				// Show a status Update
				StatusBar.ShowStatus ("Status Update");
			};
			View.AddSubview (btnShowMessage);

			var btnIndeterminate = UIButton.FromType (UIButtonType.RoundedRect);
			btnIndeterminate.Frame = new RectangleF (20, 71, 280, 44);
			btnIndeterminate.SetTitle ("Show Indeterminate Status", UIControlState.Normal);
			btnIndeterminate.TouchUpInside += (sender, e) => {
				// Show an indeterminate Activity status
				StatusBar.ShowActivity ("Processing...");
			};
			View.AddSubview (btnIndeterminate);

			var btnDismiss = UIButton.FromType (UIButtonType.RoundedRect);
			btnDismiss.Frame = new RectangleF (20, 122, 280, 44);
			btnDismiss.SetTitle ("Dismiss", UIControlState.Normal);
			btnDismiss.TouchUpInside += (sender, e) => {
				// Dismiss status bar
				StatusBar.Dismiss ();
			};
			View.AddSubview (btnDismiss);

			var btnShowSuccess = UIButton.FromType (UIButtonType.RoundedRect);
			btnShowSuccess.Frame = new RectangleF (20, 173, 280, 44);
			btnShowSuccess.SetTitle ("Show Success", UIControlState.Normal);
			btnShowSuccess.TouchUpInside += (sender, e) => {
				// Show Success Activity status
				StatusBar.ShowSuccess ("Task Success");
			};
			View.AddSubview (btnShowSuccess);

			var btnShowError = UIButton.FromType (UIButtonType.RoundedRect);
			btnShowError.Frame = new RectangleF (20, 224, 280, 44);
			btnShowError.SetTitle ("Show Error", UIControlState.Normal);
			btnShowError.TouchUpInside += (sender, e) => {
				// Show a failed Activity status
				StatusBar.ShowError ("Task Failed");
			};
			View.AddSubview (btnShowError);
		}
	}
}

