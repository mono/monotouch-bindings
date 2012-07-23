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
using MonoTouch.CoreLocation;

namespace Tapit
{

	[BaseType (typeof (NSObject))]
	[Model]
	interface TapItBannerAdViewDelegate {
		[Export ("tapitBannerAdViewWillLoadAd:")]
		void WillLoadAd (TapItBannerAdView bannerView);

		[Export ("tapitBannerAdViewDidLoadAd:")]
		void DidLoadAd (TapItBannerAdView bannerView);

		[Export ("tapitBannerAdView:didFailToReceiveAdWithError:"),EventArgs ("TapitError")]
		void FailedToReceiveAd (TapItBannerAdView bannerView, NSError error);

		[Export ("tapitBannerAdViewActionShouldBegin:willLeaveApplication:"),DefaultValue (true),DelegateName ("TapitBool")]
		bool ShouldBegin (TapItBannerAdView bannerView, bool willLeave);

		[Export ("tapitBannerAdViewActionDidFinish:")]
		void DidFinish (TapItBannerAdView bannerView);

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TapItInterstitialAdDelegate {
		[Abstract]
		[Export ("tapitInterstitialAd:didFailWithError:"),EventArgs ("TapitError")]
		void FailedWithError (TapItInterstitialAd interstitialAd, NSError error);

		[Abstract]
		[Export ("tapitInterstitialAdDidUnload:")]
		void DidUnload (TapItInterstitialAd interstitialAd);

		[Abstract]
		[Export ("tapitInterstitialAdWillLoad:")]
		void WillLoad (TapItInterstitialAd interstitialAd);

		[Abstract]
		[Export ("tapitInterstitialAdDidLoad:")]
		void DidLoad (TapItInterstitialAd interstitialAd);

		[Abstract]
		[Export ("tapitInterstitialAdActionShouldBegin:willLeaveApplication:"),DefaultValue (true),DelegateName ("TapitInterstitialBool")]
		bool ShouldBegin (TapItInterstitialAd interstitialAd, bool willLeave);

		[Abstract]
		[Export ("tapitInterstitialAdActionDidFinish:")]
		void DidFinish (TapItInterstitialAd interstitialAd);

	}

	
	[BaseType (typeof (NSObject))]
	interface TapItAppTracker {
		[Export ("deviceUDID")]
		string DeviceUDID ();

		[Export ("userAgent")]
		string UserAgent ();

		[Export ("location")]
		CLLocation Location ();

		[Export ("networkConnectionType")]
		int NetworkConnectionType ();

		[Export ("reportApplicationOpen")]
		void ReportApplicationOpen ();

	}

	
	[BaseType (typeof (UIView), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof (TapItBannerAdViewDelegate)})]
	interface TapItBannerAdView {

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		TapItBannerAdViewDelegate Delegate { get; set; }

		[Export ("animated")]
		bool Animated { get; set;  }

		[Export ("isServingAds")]
		bool IsServingAds { get;  }

		[Export ("hideDirection")]
		TapItBannerHideDirection HideDirection { get; set;  }

		[Export ("locationPrecision")]
		int locationPrecision { get; set;  }

		[Export ("startServingAdsForRequest:")]
		bool StartServingAds(TapItRequest request);

		[Export ("updateLocation:")]
		void UpdateLocation (CLLocation location);

		[Export ("cancelAds")]
		void CancelAds ();

		[Export ("repositionToInterfaceOrientation:")]
		void RepositionToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation);

	}

	
	[BaseType (typeof (NSObject), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof (TapItInterstitialAdDelegate)})]
	interface TapItInterstitialAd {

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		TapItInterstitialAdDelegate Delegate { get; set; }

		[Export ("animated")]
		bool Animated { get; set;  }

		[Export ("controlType")]
		TapItInterstitialControlType ControlType { get; set;  }

		[Export ("allowedAdTypes")]
		TapItAdType AllowedAdTypes { get; set;  }

		[Export ("loaded")]
		bool Loaded { get;  }

		[Export ("loadInterstitialForRequest:")]
		bool Load (TapItRequest request);

		[Export ("presentFromViewController:")]
		void PresentFromViewController (UIViewController contoller);

	}
	
	[BaseType (typeof (NSObject))]
	interface TapItRequest {
		[Static]
		[Export ("requestWithAdZone:")]
		TapItRequest FromZone (string zone);

		[Static]
		[Export ("requestWithAdZone:andCustomParameters:")]
		TapItRequest FromZone (string zone, NSDictionary theParams);

		[Export ("updateLocation:")]
		void UpdateLocation (CLLocation location);

		[Export ("customParameterForKey:")]
		NSObject Parameter (string key);

		[Export ("setCustomParameter:forKey:")]
		NSObject SetParameter (NSObject value, string key);

		[Export ("removeCustomParameterForKey:")]
		NSObject RemoveParameter (string key);

	}

}