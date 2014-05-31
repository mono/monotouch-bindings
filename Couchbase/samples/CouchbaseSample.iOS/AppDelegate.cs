using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Couchbase;

namespace CouchbaseSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		static AppDelegate()
		{
			CurrentSystemVersion = new Version (UIDevice.CurrentDevice.SystemVersion);
			iOS7 = new Version (7, 0);
		}

		public static readonly Version CurrentSystemVersion;
		public static readonly Version iOS7;

		// class-level declarations
		UINavigationController navigationController;
		UIWindow window;

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

			var controller = new RootViewController();

			if (CurrentSystemVersion >= iOS7)
			{
				window.TintColor = UIColor.FromRGB(0.564f, 0.0f, 0.015f);
				controller.EdgesForExtendedLayout = UIRectEdge.None;
			}

			navigationController = new UINavigationController (controller);

			window.RootViewController = navigationController;
			window.MakeKeyAndVisible ();

			return true;
		}
	}
}

