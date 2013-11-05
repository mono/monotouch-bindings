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
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Kiip;

namespace sample
{
	public partial class MainViewController : UIViewController
	{
		KPViewPosition kPViewPosition = KPViewPosition.Top;
		public MainViewController () : base ("MainViewController", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			toggleStatusBar.ValueChanged += toggleSwitchValueChanged;
		}

		void toggleSwitchValueChanged (object sender, EventArgs e)
		{
			Console.WriteLine("ChangeD");
			UIApplication.SharedApplication.SetStatusBarHidden(!toggleStatusBar.On,UIStatusBarAnimation.Slide);
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		partial void saveLeaderboard ()
		{
			leaderboard_id.ResignFirstResponder();
			KPManager.SharedManager.UpdateScore(100,leaderboard_id.Text);
		}
		partial void setLocation ()
		{
			KPManager.SharedManager.UpdateLocation(37.7753,-122.4189);
		}
		partial void showFullscreen ()
		{
			while(AppDelegate.Rewards.Count > 0)
			{
				var reward = AppDelegate.Rewards[0];
				reward.SetValueForKey (new NSNumber((int)KPViewPosition.FullScreen),new NSString("position"));
				KPManager.SharedManager.PresentReward(reward);
				AppDelegate.Rewards.Remove(reward);
			}
		}
		partial void showNotification ()
		{
			kPViewPosition = kPViewPosition == KPViewPosition.Top ? KPViewPosition.Bottom : KPViewPosition.Top;
			while(AppDelegate.Rewards.Count > 0)
			{
				var reward = AppDelegate.Rewards[0];
				reward.SetValueForKey (new NSNumber((int)kPViewPosition),new NSString("position"));
				KPManager.SharedManager.PresentReward(reward);
				AppDelegate.Rewards.Remove(reward);
			}
		}

		partial void unlockAchievement ()
		{
			achievement_id.ResignFirstResponder();
			KPManager.SharedManager.UnlockAchievement(achievement_id.Text,new string[]{"movies","music"});
		}
		partial void getActivePromos ()
		{
			KPManager.SharedManager.GetActivePromos();
		}

		public bool ToggleAction
		{
			get{return toggleAction.On;}
		}

	}
}

