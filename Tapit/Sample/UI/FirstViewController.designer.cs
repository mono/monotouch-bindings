// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace TapitExample
{
	[Register ("FirstViewController")]
	partial class FirstViewController
	{
		[Outlet]
		Tapit.TapItBannerAdView tapitAd { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton button { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tapitAd != null) {
				tapitAd.Dispose ();
				tapitAd = null;
			}

			if (button != null) {
				button.Dispose ();
				button = null;
			}
		}
	}
}
