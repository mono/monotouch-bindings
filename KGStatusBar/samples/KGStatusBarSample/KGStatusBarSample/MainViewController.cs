using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using KGStatusBar;

namespace KGStatusBarSample
{
	public class MainViewController : UIViewController
	{
		public MainViewController () : base ()
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.BackgroundColor = UIColor.White;

			var btnSuccess = UIButton.FromType (UIButtonType.RoundedRect);
			btnSuccess.Frame = new RectangleF (20, 20, 118, 44);
			btnSuccess.SetTitle ("Show Success", UIControlState.Normal);

			// Set Success button to show StatusBar Success when tapped.
			btnSuccess.TouchUpInside += (o, e) => StatusBar.ShowSuccess ("Loading succeeded!");

			var btnError = UIButton.FromType (UIButtonType.RoundedRect);
			btnError.Frame = new RectangleF (182, 20, 118, 44);
			btnError.SetTitle ("Show Error", UIControlState.Normal);

			// Set Error button to show StatusBar Error when tapped.
			btnError.TouchUpInside += (o, e) => StatusBar.ShowError ("Loading Failed!");

			var btnShowSatus = UIButton.FromType (UIButtonType.RoundedRect);
			btnShowSatus.Frame = new RectangleF (124, 71, 73, 44);
			btnShowSatus.SetTitle ("Show", UIControlState.Normal);

			// Set Show button to show StatusBar status when tapped.
			btnShowSatus.TouchUpInside += (o, e) => StatusBar.ShowStatus ("Loading...");

			var btnDismiss = UIButton.FromType (UIButtonType.RoundedRect);
			btnDismiss.Frame = new RectangleF (124, 122, 73, 44);
			btnDismiss.SetTitle ("Dismiss", UIControlState.Normal);

			// Set Dismiss button to dismiss StatusBar when tapped.
			btnDismiss.TouchUpInside += (o, e) => StatusBar.Dismiss ();

			View.AddSubviews (new [] { btnSuccess, btnError, btnShowSatus, btnDismiss});
		}
	}
}

