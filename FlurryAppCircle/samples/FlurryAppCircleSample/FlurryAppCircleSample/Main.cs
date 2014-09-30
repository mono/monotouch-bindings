// 
//  Copyright 2012  abhatia
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using AppCircle = FlurryAppCircle.FlurryAppCircle;
using Analytics = FlurryAnalytics.Flurry;

namespace FlurryAppCircleSample
{
	public class Application
	{
		static void Main(string[] args)
		{
			UIApplication.Main(args, null, "AppDelegate");
		}
	}
	
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow _window;
		AppCircleDelegate _appCircleDelegate;
		
		const string API_KEY = "YOUR_API_KEY";
		
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			//ALWAYS enable AppCircle, and THEN start Session, THEN set Delegate
			
			AppCircle.SetEnabled(true);
			Analytics.StartSession(API_KEY);
			
			_appCircleDelegate = new AppCircleDelegate();
			AppCircle.SetAppCircleDelegate(_appCircleDelegate);
			
			//THENNN start regular code
			
			_window = new UIWindow(UIScreen.MainScreen.Bounds);
			var root = new RootViewController();
			_window.RootViewController = root;
		
			_window.MakeKeyAndVisible();
			return true;
		}
	}
}
