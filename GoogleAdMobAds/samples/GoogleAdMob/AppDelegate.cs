//
// This shows the various capabilities of the
// GoogleAdMobAds
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using GoogleAdMobAds;

namespace sample
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		GADBannerView bannerView;
		UIViewController vc;
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			vc = new UIViewController();
			
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.RootViewController = vc;
			window.MakeKeyAndVisible ();

			bannerView = new GADBannerView(GADAdSizeCons.Banner, new PointF(0, vc.View.Frame.Height - GADAdSizeCons.Banner.size.Height));
			bannerView.AdUnitID = "MY_BANNER_UNIT_ID";
			bannerView.RootViewController = vc;
			
			vc.View.AddSubview(bannerView);
			bannerView.LoadRequest(new GADRequest());
			
			return true;
		}
		
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}