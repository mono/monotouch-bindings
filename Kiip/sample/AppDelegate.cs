// 
//  Copyright 2012  James Clancey, Xamarin Inc  (http://www.xamarin.com)
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
using Kiip;

namespace sample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		MainViewController viewController;
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
			var Manager = new KPManager("APIKEY","SECRET");
			KPManager.SharedManager = Manager;
			KPManager.SharedManager.DidStartSession += DidStartSession;
			//Manager.Delegate = new myDelegate();
			KPManager.SharedManager.StartSession();
			viewController = new MainViewController ();
			window.RootViewController = viewController;
			window.MakeKeyAndVisible ();
			
			return true;
		}
		class myDelegate : KPManagerDelegate
		{
			#region KPManagerDelegate implementation
			public void WillPresentNotification (string rid)
			{
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public void DidPresentNotification (string rid)
			{
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public void WillCloseNotification (string rid)
			{
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public void DidCloseNotification (string rid)
			{
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public void WillShowWebView (string rid)
			{
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public void DidShowWebView (string rid)
			{
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public void WillCloseWebView (string rid)
			{
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public void DidCloseWebView (string rid)
			{
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public void DidStartSession (KPManager manager, NSDictionary resource)
			{
				
				Console.WriteLine("Session started");
				if(resource == null)
				{
					var alert = new UIAlertView("Kiip","Session created: No Promo",null,"OK");
					alert.Show();
					return;
				}
	
				NSMutableDictionary reward = new NSMutableDictionary(resource);
				reward.SetValueForKey(NSNumber.FromInt32((int)KPViewPosition.FullScreen),new NSString("position"));
				KPManager.SharedManager.PresentReward(reward);
				(new UIAlertView("Kiip","Session created: Promo",null,"Ok")).Show();;
			}

			public void DidEndSession (KPManager manager)
			{
				Console.WriteLine("DidEndSession");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public void DidUnlockAchievement (KPManager manager, NSDictionary resource)
			{
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public void DidGetActivePromos (KPManager manager, NSArray promos)
			{
				Console.WriteLine("DidEndSession");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public void DidUpdateLocation (KPManager manager)
			{
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public void DidUpdateLeaderboard (KPManager manager, NSDictionary resource)
			{
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public void DidReceiveError (KPManager manager, NSError error)
			{
				Console.WriteLine("DidEndSession");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public void DidStartSwarm (string leaderboard_id)
			{
				Console.WriteLine("DidEndSession");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public void DidReceiveContent (string content, int quantity, NSDictionary receipt)
			{
				Console.WriteLine("DidEndSession");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}
			#endregion
		}

		void DidStartSession(object sender, KiipManagerDictEventArgs evt)
		{
			Console.WriteLine("Session started");
			if(evt.Resource == null)
			{
				var alert = new UIAlertView("Kiip","Session created: No Promo",null,"OK");
				alert.Show();
				return;
			}

			NSMutableDictionary reward = new NSMutableDictionary(evt.Resource);
			reward.SetValueForKey(NSNumber.FromInt32((int)KPViewPosition.FullScreen),new NSString("position"));
			KPManager.SharedManager.PresentReward(reward);
			(new UIAlertView("Kiip","Session created: Promo",null,"Ok")).Show();;
		}


	}
}

