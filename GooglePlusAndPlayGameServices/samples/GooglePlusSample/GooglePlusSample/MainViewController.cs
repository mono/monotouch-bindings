using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Google.Plus;

namespace GooglePlusSample
{
	public class MainViewController : UIViewController
	{
		SignInButton btnSignIn;

		public MainViewController () : base ()
		{
			Title = "Google+ Sample";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.BackgroundColor = UIColor.White;

			btnSignIn = new SignInButton () {
				Frame = new RectangleF (85, 176, 151, 48)
			};

			View.AddSubview (btnSignIn);
		}
	}
}

