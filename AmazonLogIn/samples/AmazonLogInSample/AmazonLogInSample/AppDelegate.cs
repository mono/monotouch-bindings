using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Amazon.LogIn;

namespace AmazonLogInSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// TODO:
		// Before you can use Login with Amazon SDK and run this sample, 
		// you must register an application on Amazon's portal at
		// http://login.amazon.com/manageApps
		// make sure you use amazonloginsample as your Bundle ID on Amazon's portal.

		// FIXME:
		// Open Info.plist and go to Source tab
		// You will find APIKey string key, you must set there
		// your own API Key Value, this is obtained at
		// http://login.amazon.com/manageApps

		// class-level declarations
		UIWindow window;
		MainViewController viewController;
		UINavigationController navController;

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

			viewController = new MainViewController ();
			navController = new UINavigationController (viewController);
			window.RootViewController = navController;
			window.MakeKeyAndVisible ();
			
			return true;
		}

		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			// Pass on the url to the SDK to parse authorization code from the url.
			bool isValidRedirectSignInURL = AIMobileLib.HandleOpenUrl (url, sourceApplication);
			if(!isValidRedirectSignInURL)
				return false;

			// App may also want to handle url 
			return true;
		}
	}
}

