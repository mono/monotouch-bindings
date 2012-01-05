using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.TestFlight;
using MonoTouch.Dialog;

namespace TestFlightSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		TestFlightSampleViewController viewController;
		private static NSUserDefaults prefs = NSUserDefaults.StandardUserDefaults;
		

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			TestFlight.TakeOff("8a2f26739dc3810018973494f39c9019_ODY2MjAxMS0xMC0wNCAxODozMDozOC4wMTk4Mzk");
			
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			viewController = new TestFlightSampleViewController ("TestFlightSampleViewController", null);
			//window.RootViewController = viewController;
			
			var menu = new RootElement("Demos") { 
				new Section ("Enter some stuff")
				{
					new EntryElement ("Name:", "", prefs.StringForKey("UserName")),
					new EntryElement ("Email:", "", prefs.StringForKey("Email"))
				} 
			};

			var dv = new DialogViewController (menu) { Autorotate = true };
			
			window.AddSubview(dv.View);
			
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

