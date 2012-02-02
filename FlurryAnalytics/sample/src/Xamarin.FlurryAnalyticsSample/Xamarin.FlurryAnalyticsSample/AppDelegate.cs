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
using FA=FlurryAnalytics;
using System.Runtime.InteropServices;

namespace Xamarin.FlurryAnalyticsSample
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow _Window;
//		Action<IntPtr> UncaughtExceptionHandlerAction;
		RootViewController _RootViewController;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
//			UncaughtExceptionHandlerAction = UncaughtExceptionHandler;
//		    NSSetUncaughtExceptionHandler (Marshal.GetFunctionPointerForDelegate (UncaughtExceptionHandlerAction));
			
//			FA.FlurryAnalytics.StartSession("YOUR_API_KEY");
//			FA.FlurryAnalytics.SetSessionReportsOnPause(true);
			
			_Window = new UIWindow(UIScreen.MainScreen.Bounds);
				 
			_RootViewController = new RootViewController();
			_Window.RootViewController = _RootViewController;
			
			_Window.MakeKeyAndVisible();
			return true;
		}
		
		public override void WillTerminate(UIApplication application)
		{
			
		}
		
		public override void WillEnterForeground(UIApplication application)
		{
//			FA.FlurryAnalytics.LogEvent(string.Format("Application Sent to Background..."));
		}
		
				
		static void UncaughtExceptionHandler(IntPtr handle)
		{
		    
			var exception = new NSException(handle);
			FA.FlurryAnalytics.LogError("3584", exception.Reason, exception);
			
			Console.WriteLine(@"Got an exception...{0} -- {1}", exception.Name, exception.Reason);
		}
		
//		public delegate void NSUncaughtExceptionHandler (IntPtr exception);
//
//		[DllImport ("/System/Library/Frameworks/Foundation.framework/Foundation")]
//		extern static void NSSetUncaughtExceptionHandler (IntPtr handler);
	}
	
}

