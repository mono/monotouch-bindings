// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace TapitExample
{
	[Register ("SecondViewController")]
	partial class SecondViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView activityIndicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton loadButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton showButton { get; set; }

		[Action ("loadInterstitial:")]
		partial void loadInterstitial (MonoTouch.Foundation.NSObject sender);

		[Action ("showInterstitial:")]
		partial void showInterstitial (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (activityIndicator != null) {
				activityIndicator.Dispose ();
				activityIndicator = null;
			}

			if (loadButton != null) {
				loadButton.Dispose ();
				loadButton = null;
			}

			if (showButton != null) {
				showButton.Dispose ();
				showButton = null;
			}
		}
	}
}
