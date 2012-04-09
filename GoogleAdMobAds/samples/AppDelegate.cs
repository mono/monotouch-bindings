//
// This shows the various capabilities of the
// AtmHud library
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using AlexTouch.GoogleAdMobAds;

namespace sample
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		GADBannerView ad;
		UIViewController vc;
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			vc = new UIViewController();
			
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.RootViewController = vc;
			window.MakeKeyAndVisible ();
			
			ad = new GADBannerView(new RectangleF(new PointF(0,0), GADBannerView.GAD_SIZE_320x50))
	        {
	            AdUnitID = "Use Your AdMob Id here",
	            RootViewController = vc //or your RootViewController  
	        };
	
	        ad.DidReceiveAd += delegate 
	        {
	            vc.View.AddSubview(ad);
	            Console.WriteLine("AD Received");
	        };
	
	        ad.DidFailToReceiveAdWithError += delegate(object sender, GADBannerViewDidFailWithErrorEventArgs e) {
	            Console.WriteLine(e.Error);
	        };
	
	        ad.WillPresentScreen += delegate {
	            Console.WriteLine("showing new screen");
	        };
	
	        ad.WillLeaveApplication += delegate {
	            Console.WriteLine("I will leave application");
	        };
	
	        ad.WillDismissScreen += delegate {
	            Console.WriteLine("Dismissing opened screen");
	        };
	
	        Console.Write("Requesting Ad");
	        ad.LoadRequest(new GADRequest());
			
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