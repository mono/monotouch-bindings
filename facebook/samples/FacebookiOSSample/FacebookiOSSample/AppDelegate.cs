using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using MonoTouch.FacebookConnect;

namespace FacebookiOSSample
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
		DVCLogIn viewController;

		// Replace here you own Facebook App Id, if you don't have one go to
		// https://developers.facebook.com/apps
		private const string AppId = "454287177934330";
		private const string DisplayName = "IFaceTouch";

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

			FBSettings.DefaultAppID = AppId;
			FBSettings.DefaultDisplayName = DisplayName;

			viewController = new DVCLogIn ();
			navController = new UINavigationController (viewController);

			window.RootViewController = navController;
			window.MakeKeyAndVisible ();
			
			return true;
		}

		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			// We need to handle URLs by passing them to FBSession in order for SSO authentication
			// to work.
			return FBSession.ActiveSession.HandleOpenURL(url);
		}

		public override void OnActivated (UIApplication application)
		{
			// We need to properly handle activation of the application with regards to SSO
			//  (e.g., returning from iOS 6.0 authorization dialog or from fast app switching).
			FBSession.ActiveSession.HandleDidBecomeActive();
		}
	}
}

