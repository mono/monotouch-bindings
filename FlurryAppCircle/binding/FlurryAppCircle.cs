using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
namespace Flurry
{
	[BaseType (typeof (NSObject))]
	[Model]
	interface FlurryAdDelegate {
		[Abstract]
		[Export ("dataAvailable")]
		void DataAvailable ();

		[Abstract]
		[Export ("dataUnavailable")]
		void DataUnavailable ();

		[Abstract]
		[Export ("videoAvailable")]
		void VideoAvailable ();

		[Abstract]
		[Export ("videoUnavailable")]
		void VideoUnavailable ();

		[Abstract]
		[Export ("canvasWillDisplay:")]
		void CanvasWillDisplay (string hook);

		[Abstract]
		[Export ("canvasWillClose")]
		void CanvasWillClose ();

		[Abstract]
		[Export ("takeoverWillDisplay:")]
		void TakeoverWillDisplay (string hook);

		[Abstract]
		[Export ("takeoverWillClose")]
		void TakeoverWillClose ();

		[Abstract]
		[Export ("videoDidNotFinish:")]
		void VideoDidNotFinish (string hook);

		[Abstract]
		[Export ("videoDidFinish:withUserCookies:")]
		void VideoDidFinish (string hook, NSDictionary userCookies);

		[Abstract]
		[Export ("appLaunched:userCookies:userCookies")]
		void AppLaunched (string hook, NSDictionary cookies );

		[Abstract]
		[Export ("bannerExpanded:")]
		void BannerExpanded (string hook);

		[Abstract]
		[Export ("bannerCollapsed:")]
		void BannerCollapsed (string hook);

	}
	
	
	[BaseType (typeof (NSObject))]
	interface FlurryOffer {
		[Export ("appDisplayName")]
		string AppDisplayName { get; set;  }

		[Export ("appIcon")]
		UIImage AppIcon { get; set;  }

		[Export ("referralUrl")]
		string ReferralUrl { get; set;  }

		[Export ("appPrice")]
		NSNumber AppPrice { get; set;  }

		[Export ("appDescription")]
		string AppDescription { get; set;  }

	}
	
	
	[BaseType (typeof (NSObject))]
	interface FlurryAppCircle {
		[Static]
		[Export ("setAppCircleEnabled:")]
		void SetEnabled (bool value);

		[Static]
		[Export ("appAdIsAvailable:")]
		bool AppAdIsAvailable (string hook);

		[Static]
		[Export ("getAppAdCount:")]
		int GetAppAdCount (string hook);

		[Static]
		[Export ("getHook:xLoc:yLoc:view:")]
		UIView GetHook (string hook, int x, int y, UIView view);

		//[Static]
		//[Export ("getHook:xLoc:yLoc:view:attachToView:orientation:canvasOrientation:autoRefresh:canvasAnimated:rewardMessage:userCookies:")]
		//UIView GetHook (string hook, int x, int y, UIView view, bool attachToView, string orientation, string canvasOrientation, bool refresh, bool canvasAnimated, string rewardMessage, NSDictionary userCookies);

		[Static]
		[Export ("updateHook:")]
		void UpdateHook (UIView banner);

		[Static]
		[Export ("removeHook:")]
		void RemoveHook (UIView banner);

		[Static]
		[Export ("openCatalog:canvasOrientation:canvasAnimated:")]
		void OpenCatalog (string hook, string canvasOrientation, bool canvasAnimated);

		//[Static]
		//[Export ("openTakeover:orientation:rewardImage:rewardMessage:userCookies:")]
		//void OpenTakeover (string hook, string orientation, UIImage image, string message, NSDictionary userCookies);

		[Static]
		[Export ("getOffer:withFlurryOfferContainer:")]
		bool GetOffer (string hookName, FlurryOffer flurryOffer);

		[Static]
		[Export ("getOffer:withFlurryOfferContainer:userCookies:")]
		bool GetOffer (string hookName, FlurryOffer flurryOffer, NSDictionary userCookies);

		[Static]
		[Export ("peekOffer:withFlurryOfferContainer:")]
		bool PeekOffer (string hookName, FlurryOffer flurryOffer);

		[Static]
		[Export ("getOfferCount:")]
		int GetOfferCount (string hookName);

		[Static]
		[Export ("setAppCircleDelegate:")]
		void SetAppCircleDelegate (NSObject thedelegate);

	}

	
}
