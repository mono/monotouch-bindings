
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.CoreLocation;

namespace MillennialMedia
{
	[BaseType (typeof (UIView))]
	interface MMAdView {
		[Export ("refreshTimerEnabled")]
		bool RefreshTimerEnabled { get; set;  }

		[Export ("adRequestTimeoutInterval")]
		double AdRequestTimeoutInterval { get; set;  }

		[Export ("overlayOrientation")]
		UIInterfaceOrientation OverlayOrientation { get; set;  }

		[Export ("overlayFrame")]
		RectangleF OverlayFrame { get; set;  }

		[Export ("rootViewController")]
		UIViewController RootViewController { get; set;  }

		[Static]
		[Export ("adWithFrame:type:typeapid:apiddelegate:aDelegateloadAd:loadAdstartTimer:startTimer")]
		MMAdView FromRect (RectangleF aFrame, MMAdType adType, string typeId , MMAdDelegate theDelegate , bool loadAdStartTimer, bool startTimer );

		[Export ("interstitialWithType:typeapid:apiddelegate:loadAd:loadAd")]
		MMAdView FromType (MMAdType adType, string typeId, MMAdDelegate aDelegate, bool loadAd );

		[Static]
		[Export ("startSynchronousConversionTrackerWithGoalId:goalid")]
		void StartTracker (string goalId );

		[Static]
		[Export ("version")]
		string Version ();

		[Static]
		[Export ("updateLocation:currentLocation")]
		void UpdateLocation (CLLocation currentLocation );

		[Export ("refreshAd")]
		void RefreshAd ();

		[Export ("fetchAdToCache")]
		bool FetchAdToCache ();

		[Export ("checkForCachedAd")]
		bool CheckForCachedAd ();

		[Export ("displayCachedAd")]
		bool DisplayCachedAd ();

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface MMAdDelegate {
		[Export ("requestData")]
		NSDictionary RequestData ();

		[Export ("adRefreshDuration")]
		int AdRefreshDuration ();

		[Export ("accelerometerEnabled")]
		bool AccelerometerEnabled ();

		[Export ("adRequestSucceeded:adView")]
		void AdRequestSucceededadView (MMAdView adView);

		[Export ("adRequestFailed:adView")]
		void AdRequestFailedadView (MMAdView adView);

		[Export ("adDidRefresh:adView")]
		void AdDidRefreshadView (MMAdView adView );

		[Export ("adWasTapped:adView")]
		void AdWasTappedadView (MMAdView adView );

		[Export ("adRequestIsCaching:adView")]
		void AdRequestIsCachingadView (MMAdView adView );

		[Export ("adRequestFinishedCaching:adViewsuccessful:didSucceed")]
		void AdRequestFinishedCachingadViewsuccessfuldidSucceed (MMAdView adView, bool sucess );

		[Export ("applicationWillTerminateFromAd")]
		void ApplicationWillTerminateFromAd ();

		[Export ("adModalWillAppear")]
		void AdModalWillAppear ();

		[Export ("adModalDidAppear")]
		void AdModalDidAppear ();

		[Export ("adModalWasDismissed")]
		void AdModalWasDismissed ();

	}
	
}