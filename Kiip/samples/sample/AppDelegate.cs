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
		public static List<NSDictionary> Rewards = new List<NSDictionary>();
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

						
			KPManager.SharedManager =  new KPManager("799cd5dabaae331d900801f0ac86a672","85c521a809899003bbec3e7b418ce391",100);
			KPManager.SharedManager.DidStartSession += DidStartSession;
			KPManager.SharedManager.DidUpdateLocation += DidUpdateLocation;
			KPManager.SharedManager.DidEndSession += DidEndSession;
			KPManager.SharedManager.DidGetActivePromos += DidGetActivePromos;
			KPManager.SharedManager.DidUnlockAchievement += DidUnlockAchievement;
			KPManager.SharedManager.DidUpdateLeaderboard += DidUpdateLeaderboard;
			KPManager.SharedManager.DidReceiveError += DidReceiveError;
			KPManager.SharedManager.WillPresentNotification += WillPresentNotification;
			KPManager.SharedManager.DidReceiveContent += DidReceiveContent;
			KPManager.SharedManager.DidCloseNotification += DidCloseNotification;
			KPManager.SharedManager.DidCloseWebView += DidCloseWebView;
			KPManager.SharedManager.DidPresentNotification += DidPresentNotification;

			//Manager.Delegate = new MyDelegate();

			viewController = new MainViewController ();
			window.RootViewController = viewController;
			window.MakeKeyAndVisible ();
			
			return true;
		}


		void DidPresentNotification (object sender, EventArgs e)
		{
			Console.WriteLine("Did present Notification");
		}

		void DidCloseWebView (object sender, EventArgs e)
		{
			Console.WriteLine("Did close webview");
		}

		void DidCloseNotification (object sender, EventArgs e)
		{
			Console.WriteLine("Did Close");
		}

		void DidReceiveContent (object sender, KiipStringIntDictEventArgs e)
		{
			Console.WriteLine("Did revceive content");
		}

		void WillPresentNotification (object sender, EventArgs e)
		{
			Console.WriteLine("Will present notification");
		}

		void DidReceiveError (object sender, KiipManagerErrEventArgs e)
		{
			Console.WriteLine(e.Error);
		}

		void DidUpdateLeaderboard (object sender, KiipManagerDictEventArgs e)
		{
			Console.WriteLine("Did Update Leader Board");
		}

		void DidUnlockAchievement (object sender, KiipManagerDictEventArgs e)
		{
			Console.WriteLine("Did Unlock Achievment");
			if(e.Resource != null)
			{
				if(viewController.ToggleAction)
					KPManager.SharedManager.PresentReward(e.Resource);
				else
					Rewards.Add (e.Resource);
			}
		}

		void DidGetActivePromos (object sender, KiipManagerArrayEventArgs e)
		{
			Console.WriteLine("Current Active Promos:\r\n" +e.Promos.ToString() );
		}

		void DidEndSession (object sender, EventArgs e)
		{
			Console.WriteLine("Did End Session");
		}

		void DidUpdateLocation (object sender, EventArgs e)
		{
			Console.WriteLine("Did update location");
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
		/*
		class MyDelegate : KPManagerDelegate
		{
			public override void DidStartSession (KPManager manager, NSDictionary resource)
			{
				Console.WriteLine("Did Start");
			}
			public override void DidGetActivePromos (KPManager manager, NSArray promos)
			{
				Console.WriteLine("Did get active promos");
			}
			public override void WillShowWebView (string rid)
			{
				Console.WriteLine("WillShowWebView");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}
			public override void DidShowWebView (string rid)
			{
				Console.WriteLine("WillShowWebView");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}
			public override void WillCloseWebView (string rid)
			{
				Console.WriteLine("WillShowWebView");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}
			public override void DidCloseWebView (string rid)
			{
				Console.WriteLine("WillShowWebView");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public override void DidUnlockAchievement (KPManager manager, NSDictionary resource)
			{
				Console.WriteLine("WillShowWebView");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}
			public override void DidUpdateLeaderboard (KPManager manager, NSDictionary resource)
			{
				Console.WriteLine("WillShowWebView");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}
			public override void DidUpdateLocation (KPManager manager)
			{
				Console.WriteLine("WillShowWebView");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}
			public override void DidStartSwarm (string leaderboard_id)
			{
				Console.WriteLine("WillShowWebView");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}

			public override void DidEndSession (KPManager manager)
			{
				Console.WriteLine("DidEndSession");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}
			public override void DidReceiveContent (string content, int quantity, NSDictionary receipt)
			{
				Console.WriteLine("Did Recieve Content");
			}
			public override void DidReceiveError (KPManager manager, NSError error)
			{
				Console.WriteLine("error:" + error);
			}
			public override void WillPresentNotification (string rid)
			{
				Console.WriteLine("WillPresentNotification");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}
			public override void DidPresentNotification (string rid)
			{
				Console.WriteLine("DidPresentNotification");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}
			public override void WillCloseNotification (string rid)
			{
				Console.WriteLine("WillCloseNotification");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}
			public override void DidCloseNotification (string rid)
			{
				Console.WriteLine("DidCloseNotification");
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}
		}
		*/
	}
}

