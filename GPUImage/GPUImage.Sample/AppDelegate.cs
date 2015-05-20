using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GPUImage.Sample
{
	/// <summary>
	/// Sample MonoTouch application using GPUImage
	/// </summary>
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
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
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.BackgroundColor = UIColor.White;

			window.RootViewController = new MainViewController();
			
			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

