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

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Kiip
{

	[BaseType (typeof (NSObject), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof (KPManagerDelegate)})]
	interface KPManager {
		[Export ("shouldAutoRotate")]
		bool ShouldAutoRotate { get; set;  }

		[Export ("authenticated")]
		bool Authenticated { [Bind ("isAuthenticated")] get;  }

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		KPManagerDelegate Delegate { get; set; }

		[Export ("initWithKey:secret:")]
		KPManager Constructor (string key, string secret);

		[Export ("initWithKey:secret:testFrequency:")]
		KPManager Constructor (string key, string secret, int frequency);

		[Export ("deviceIdentifier")]
		string DeviceIdentifier ();

		[Export ("startSession")]
		void StartSession ();

		[Export ("endSession")]
		void EndSession ();

		[Export ("updateLatitude:longitude:")]
		void UpdateLocation (double latitude, double longitude);

		[Export ("updateUserInfo:")]
		void UpdateUserInfo (NSDictionary alias);

		[Export ("unlockAchievement:")]
		void UnlockAchievement (string achievementId);

		[Export ("unlockAchievement:withTags:")]
		void UnlockAchievement (string achievementId, string[] tags);

		[Export ("updateScore:onLeaderboard:")]
		void UpdateScore (double score, string leaderboardId);

		[Export ("updateScore:onLeaderboard:withTags:")]
		void UpdateScore (double score, string leaderboardId, string[] tags);

		[Export ("presentReward:")]
		void PresentReward (NSDictionary resource);

		[Export ("presentReward:onView:")]
		void PresentReward (NSDictionary resource, UIView view);

		[Export ("getActivePromos")]
		void GetActivePromos ();

		[Export ("setGlobalOrientation:")]
		void SetGlobalOrientation (UIDeviceOrientation orientation);

		//Detected properties
		[Static]
		[Export ("sharedManager")]
		KPManager SharedManager { get; set; }

	}

	
	[BaseType (typeof (NSObject))]
	[Model]
	interface KPManagerDelegate {
		[Export ("willPresentNotification:"),EventArgs ("KiipString")]
		void WillPresentNotification (string rid);

		[Export ("didPresentNotification:"),EventArgs ("KiipString")]
		void DidPresentNotification (string rid);

		[Export ("willCloseNotification:"),EventArgs ("KiipString")]
		void WillCloseNotification (string rid);

		[Export ("didCloseNotification:"),EventArgs ("KiipString")]
		void DidCloseNotification (string rid);

		[Export ("willShowWebView:"),EventArgs ("KiipString")]
		void WillShowWebView (string rid);

		[Export ("didShowWebView:"),EventArgs ("KiipString")]
		void DidShowWebView (string rid);

		[Export ("willCloseWebView:"),EventArgs ("KiipString")]
		void WillCloseWebView (string rid);

		[Export ("didCloseWebView:"),EventArgs ("KiipString")]
		void DidCloseWebView (string rid);

		[Export ("manager:didStartSession:"),EventArgs ("KiipManagerDict")]
		void DidStartSession (KPManager manager, NSDictionary resource);

		[Export ("managerDidEndSession:"),EventArgs ("KiipManager")]
		void DidEndSession (KPManager manager);

		[Export ("manager:didUnlockAchievement:"),EventArgs ("KiipManagerDict")]
		void DidUnlockAchievement (KPManager manager, NSDictionary resource);

		[Export ("manager:didGetActivePromos:"),EventArgs ("KiipManagerArray")]
		void DidGetActivePromos (KPManager manager, NSArray promos);

		[Export ("managerDidUpdateLocation:"),EventArgs ("KiipManager")]
		void DidUpdateLocation (KPManager manager);

		[Export ("manager:didUpdateLeaderboard:"),EventArgs ("KiipManagerDict")]
		void DidUpdateLeaderboard (KPManager manager, NSDictionary resource);

		[Export ("manager:didReceiveError:"),EventArgs ("KiipManagerErr")]
		void DidReceiveError (KPManager manager, NSError error);

		[Export ("didStartSwarm:id"),EventArgs ("KiipString")]
		void DidStartSwarm (string leaderboard_id);

		[Export ("didReceiveContent:quantity:withReceipt:"),EventArgs ("KiipStringIntDict")]
		void DidReceiveContent (string content, int quantity, NSDictionary receipt);

	}


}

