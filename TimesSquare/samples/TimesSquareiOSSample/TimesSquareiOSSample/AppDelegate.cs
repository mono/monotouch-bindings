using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimesSquareiOSSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UITabBarController tabBarController;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			var gregorian = new TSQTAViewController () {
				Calendar = new NSCalendar (NSCalendarType.Gregorian)
			};

			var hebrew = new TSQTAViewController () {
				Calendar = new NSCalendar (NSCalendarType.Hebrew)
			};

			var islamic = new TSQTAViewController () {
				Calendar = new NSCalendar (NSCalendarType.Islamic)
			};

			var indian = new TSQTAViewController () {
				Calendar = new NSCalendar (NSCalendarType.Indian)
			};

			var persian = new TSQTAViewController () {
				Calendar = new NSCalendar (NSCalendarType.Persian)
			};

			tabBarController = new UITabBarController ();
			tabBarController.ViewControllers = new UIViewController [] {
				gregorian,
				hebrew,
				islamic,
				indian,
				persian
			};
			
			window.RootViewController = tabBarController;
			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

