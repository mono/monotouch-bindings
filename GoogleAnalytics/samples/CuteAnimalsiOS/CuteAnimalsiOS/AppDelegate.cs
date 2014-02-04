using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

using GoogleAnalytics.iOS;

namespace CuteAnimalsiOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		DVCMenu viewController;
		UINavigationController navController;
		const string AllowTrackingKey = "AllowTracking";

		// Shared GA tracker
		public IGAITracker Tracker;

		// Learn how to get your own Tracking Id from:
		// https://support.google.com/analytics/answer/2614741?hl=en
		public static readonly string TrackingId = "UA-TRACKING-ID";


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

			// We use NSUserDefaults to store a bool value if we are tracking the user or not 
			var optionsDict = NSDictionary.FromObjectAndKey (new NSString ("YES"), new NSString (AllowTrackingKey));
			NSUserDefaults.StandardUserDefaults.RegisterDefaults (optionsDict);

			// User must be able to opt out of tracking
			GAI.SharedInstance.OptOut = !NSUserDefaults.StandardUserDefaults.BoolForKey (AllowTrackingKey);

			// Initialize Google Analytics with a 5-second dispatch interval (Use a higher value when in production). There is a
			// tradeoff between battery usage and timely dispatch.
			GAI.SharedInstance.DispatchInterval = 5;
			GAI.SharedInstance.TrackUncaughtExceptions = true;

			Tracker = GAI.SharedInstance.GetTracker ("CuteAnimals", TrackingId);

			viewController = new DVCMenu ();
			navController = new UINavigationController (viewController);
			window.RootViewController = navController;
			window.MakeKeyAndVisible ();
			
			return true;
		}

		public override void OnActivated (UIApplication application)
		{
			GAI.SharedInstance.OptOut = !NSUserDefaults.StandardUserDefaults.BoolForKey (AllowTrackingKey);
		}
	}
}

