using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Drawing;

using GoogleAdMobAds;

namespace GoogleAdmobSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UINavigationController navController;
		DialogViewController dvcDialog;

		GADBannerView adViewTableView;
		GADBannerView adViewWindow;

		bool adOnTable = false;
		bool adOnWindow = false;

		// Get you own AdmobId from: http://www.google.com/ads/admob/
		const string admobId = "YOUR-ADMOB-ID-HERE";

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			var root = new RootElement("GoogleAdmbSample") {
				new Section ("Insert Ad") {
					new StringElement ("on TableView", AddToTableView),
					new StringElement ("on Window", AddToWindow)
				},
				new Section ("Remove Ad") {
					new StringElement ("from TableView", RemoveAdFromTableView),
					new StringElement ("from Window", RemoveAdFromWindow),
				}
			};

			dvcDialog = new DialogViewController(UITableViewStyle.Grouped, root, false);
			navController = new UINavigationController(dvcDialog);

			window.RootViewController = navController;
			window.MakeKeyAndVisible ();

			return true;
		}

		void AddToTableView ()
		{
			if (adViewTableView == null) {

				// Setup your GADBannerView, review GADAdSizeCons class for more Ad sizes. 
				adViewTableView = new GADBannerView (size: GADAdSizeCons.Banner, origin: new PointF (-10, 0)) {
					AdUnitID = admobId,
					RootViewController = navController
				};

				// Wire DidReceiveAd event to know when the Ad is ready to be displayed
				adViewTableView.DidReceiveAd += (object sender, EventArgs e) => {
					if (!adOnTable) {
						dvcDialog.Root.Add( new Section (caption: "Ad Section") {
							new UIViewElement(caption: "Ad", view: adViewTableView, transparent: true)
						});
						adOnTable = true;
					}
				};
			}
			adViewTableView.LoadRequest (GADRequest.Request);
		}

		void RemoveAdFromTableView ()
		{
			if (adViewTableView != null) {
				if (adOnTable) {
					dvcDialog.Root.RemoveAt (idx: 2, anim: UITableViewRowAnimation.Fade);
				}
				adOnTable = false;

				// You need to explicitly Dispose GADBannerView when you dont need it anymore
				// to avoid crashes if pending request are in progress
				adViewTableView.Dispose();
				adViewTableView = null;
			}
		}

		void AddToWindow ()
		{
			if (adViewWindow == null) {

				// Setup your GADBannerView, review GADAdSizeCons class for more Ad sizes. 
				adViewWindow = new GADBannerView (size: GADAdSizeCons.Banner, 
				                                  origin: new PointF (0, window.Bounds.Size.Height - GADAdSizeCons.Banner.size.Height)) {
					AdUnitID = admobId,
					RootViewController = navController
				};

				// Wire DidReceiveAd event to know when the Ad is ready to be displayed
				adViewWindow.DidReceiveAd += (object sender, EventArgs e) => {
					if (!adOnWindow) {
						navController.View.Subviews.First().Frame = new RectangleF(0, 0, 320, UIScreen.MainScreen.Bounds.Height - 50);
						navController.View.AddSubview(adViewWindow);
						adOnWindow = true;
					}
				};
			}
			adViewWindow.LoadRequest (GADRequest.Request);
		}

		void RemoveAdFromWindow ()
		{
			if (adViewWindow != null) {
				if (adOnWindow) {
					navController.View.Subviews.First().Frame = new RectangleF(0, 0, 320, UIScreen.MainScreen.Bounds.Height);
					adViewWindow.RemoveFromSuperview();
				}
				adOnWindow = false;

				// You need to explicitly Dispose GADBannerView when you dont need it anymore
				// to avoid crashes if pending request are in progress
				adViewWindow.Dispose();
				adViewWindow = null;
			}
		}

	}
}

