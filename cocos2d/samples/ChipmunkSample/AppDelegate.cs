using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Cocos2D;

namespace CC2DSharp
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		public UINavigationController NavController { get ; private set; }
		CCDirectorIOS director;

		/// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			var glView = CCGLView.View(window.Bounds);

			director = (CCDirectorIOS)CCDirector.SharedDirector;
			director.WantsFullScreenLayout = true;

			director.DisplayStats = true;

			director.AnimationInterval = 1.0/60;

			director.View = glView;

			director.Projection = CCDirectorProjection.TwoD;

			//if (!director.EnableRetinaDisplay(true))
			//	Console.WriteLine ("Retina Display not supported");

			CCTexture2D.DefaultAlphaPixelFormat = CCTexture2DPixelFormat.Rgba8888;

			var fileUtils = CCFileUtils.SharedFileUtils;
			fileUtils.EnableFallbackSuffixes=false;
			fileUtils.IPhoneRetinaDisplaySuffix="-hd";
			fileUtils.IPadSuffix="-ipad";
			fileUtils.IPhoneRetinaDisplaySuffix="-ipadhd";

			CCTexture2D.PVRImageHavePremultipliedAlpha = true;

			director.Push (IntroLayer.Scene);

			// Create a Navigation Controller with the Director
			NavController = new UINavigationController(director) {NavigationBarHidden=true};

			// set the Navigation Controller as the root view controller
			window.RootViewController = NavController;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	
		public override void DidEnterBackground (UIApplication application)
		{
			if (NavController.VisibleViewController == director)
				director.StopAnimation ();
		}

		public override void WillEnterForeground (UIApplication application)
		{
			if (NavController.VisibleViewController == director)
				director.StartAnimation ();
		}

		public override void WillTerminate (UIApplication application)
		{
			CCDirector.SharedDirector.End();
		}

		public override void ReceiveMemoryWarning (UIApplication application)
		{
			CCDirector.SharedDirector.PurgeCachedData ();
		}

		public override void ApplicationSignificantTimeChange (UIApplication application)
		{
			CCDirector.SharedDirector.NextDeltaTimeZero=true;
		}
	}
}

