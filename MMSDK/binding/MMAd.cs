
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
		[Export ("adWithFrame:type:apid:delegate:loadAd:startTimer:")]
		MMAdView FromRect (RectangleF aFrame, MMAdType adType, string apid , MMAdDelegate theDelegate , bool loadAdStartTimer, bool startTimer );

		[Export ("interstitialWithType:apid:delegate:loadAd:")]
		MMAdView FromType (MMAdType adType, string typeId, MMAdDelegate aDelegate, bool loadAd );

		[Static]
		[Export ("startSynchronousConversionTrackerWithGoalId:")]
		void StartTracker (string goalId );

		[Static]
		[Export ("version")]
		string Version ();

		[Static]
		[Export ("updateLocation:")]
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
	[Protocol]
	interface MMAdDelegate {
		[Export ("requestData")]
		NSDictionary RequestData ();

		[Export ("adRefreshDuration")]
		int AdRefreshDuration ();

		[Export ("accelerometerEnabled")]
		bool AccelerometerEnabled ();

		[Export ("adRequestSucceeded:")]
		void AdRequestSucceededadView (MMAdView adView);

		[Export ("adRequestFailed:")]
		void AdRequestFailedadView (MMAdView adView);

		[Export ("adDidRefresh:")]
		void AdDidRefreshadView (MMAdView adView );

		[Export ("adWasTapped:")]
		void AdWasTappedadView (MMAdView adView );

		[Export ("adRequestIsCaching:")]
		void AdRequestIsCachingadView (MMAdView adView );

		[Export ("adRequestFinishedCaching:successful:")]
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