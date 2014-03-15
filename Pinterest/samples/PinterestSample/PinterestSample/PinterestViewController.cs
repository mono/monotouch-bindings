using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using PinterestSDK;

namespace PinterestSample
{
	public class PinterestViewController : UIViewController
	{
		Pinterest pinterest;
		UIButton pinItButton;
		UIImageView sampleImageView;

		public PinterestViewController (IntPtr handle) : base (handle)
		{
		}

		public PinterestViewController () : base ()
		{
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
			View.BackgroundColor = UIColor.White;
			Title = "Pmterest Pint It Demo";

			// Initialize a Pinterest instance with our client_id
			pinterest = new Pinterest ("1234", "prod");

			// Setup a sample imageview for the image we want to pin
			var sampleImage = UIImage.LoadFromData (
				NSData.FromUrl (
					NSUrl.FromString ("http://placekitten.com/500/400")
				)
			);
			sampleImageView = new UIImageView (sampleImage) {
				Frame = new RectangleF (0, 61, 320, 200)
			};

			View.AddSubview (sampleImageView);

			// Setup PinIt Button
			pinItButton = Pinterest.GetPinItButton ();
			pinItButton.Frame = new RectangleF (124, 281, 72, 32);

			// Add button handler
			pinItButton.TouchUpInside += (sender, e) => {
				// Check if we can pin or if we are using simulator
				if (!pinterest.CanPin)
					new UIAlertView ("Error:", "Pinterest SDK can't pin if you are using simulator or you don't have Pinterest app :'(", null, "Ok", null).Show ();
				else 
				pinterest.CreatePin (NSUrl.FromString ("http://placekitten.com/500/400"),
					NSUrl.FromString ("http://placekitten.com"),
						"Pinning from Pin It Demo"
				);
			};

			View.AddSubview (pinItButton);
		}
	}
}

