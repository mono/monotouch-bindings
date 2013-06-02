using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Amazon.LogIn;

namespace AmazonLogInSample
{
	public class MainViewController : UIViewController
	{
		public MainViewController () : base ()
		{
			Title = "Amazon LogIn";
		}

		UIButton btnLogIn;
		UITextView message;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Just a few style details
			// Create Amazon Yellow color so we can use it in the Title text of the Navigation Controller
			var amznYellow = UIColor.FromRGBA (1.0f, 0.72299367049999996f, 0.1590426486f, 1.0f);
			View.BackgroundColor = UIColor.White;

			NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
			NavigationController.NavigationBar.Opaque = true;
			NavigationController.NavigationBar.SetTitleTextAttributes (new UITextAttributes () { TextColor = amznYellow });

			// Display a welcome message to the user
			message = new UITextView (new RectangleF (40, 76, 240, 107)) {
				Text = "Welcome to Login with Amazon!\nIf this is your first time logging in, " +
				"you will be asked to give permission for this application to access your profile data.",
				TextAlignment = UITextAlignment.Center,
				ContentMode = UIViewContentMode.ScaleToFill,
				BackgroundColor = UIColor.Clear,
				Font = UIFont.SystemFontOfSize (14.0f)
			};

			// Here we create the Amazon LogIn Button
			// You can get button graphics from http://login.amazon.com/button-guide#ios_images
			btnLogIn = UIButton.FromType (UIButtonType.RoundedRect);
			btnLogIn.Frame = new RectangleF (55, 206, 209, 48);
			btnLogIn.SetImage (UIImage.FromBundle ("btnLWA_gold_209x48.png"), UIControlState.Normal);
			btnLogIn.SetImage (UIImage.FromBundle ("btnLWA_gold_209x48_pressed.png"), UIControlState.Highlighted);
			btnLogIn.BackgroundColor = UIColor.Clear;

			// Here we handle the user's touch action 
			btnLogIn.TouchUpInside += (sender, e) => {
				// Make authorize call to SDK to get secure access token for the user.
				// While making the first call you can specify the minimum basic scopes needed.
				// Requesting both scopes for the current user.
				AIMobileLib.AuthorizeUser (new [] { "profile", "postal_code" }, new AMZNAuthorizationDelegate (this));
			};

			View.AddSubview (message);
			View.AddSubview (btnLogIn);
		}
	}
}

