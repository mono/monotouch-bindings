// AppDelegate.cs
//
// Author(s)
//	Stephane Delcroix <stephane@delcroix.org>
//
// Copyright (C) 2012 s. Delcroix
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
// and associated documentation files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
//		
// 		The above copyright notice and this permission notice shall be included in all copies or 
//		substantial portions of the Software.
//		
//		THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING 
//		BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
//		NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
//		DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
//		OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Cocos2D;

namespace Jumpy
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
	CCDirectorDisplayLink director;
		
		/// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			var glView = new CCGLView(window.Bounds);

			director = (CCDirectorDisplayLink)CCDirector.SharedDirector;

			director.WantsFullScreenLayout = true;
			
			//director.DisplayStats = true;
			
			director.AnimationInterval = 1.0/60;
			
			director.View = glView;
			
			director.Projection = CCDirectorProjection.TwoD;
			
			//if (!director.EnableRetinaDisplay(true))
			//	Console.WriteLine ("Retina Display not supported");
			
			CCTexture2D.DefaultAlphaPixelFormat = CCTexture2DPixelFormat.Rgba8888;
			
//			CCDirector.SharedDirector.ShouldAutorotateToInterfaceOrientation = (orientation) => {
//				return orientation == UIInterfaceOrientation.LandscapeLeft || orientation == UIInterfaceOrientation.LandscapeRight;
//			};

			
			CCTexture2D.PVRImageHavePremultipliedAlpha = true;
			
			director.Run (GameLayer.Scene);
			
			// Create a Navigation Controller with the Director
			NavController = new UINavigationController(director) {NavigationBarHidden=true, WantsFullScreenLayout=true};
			
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

