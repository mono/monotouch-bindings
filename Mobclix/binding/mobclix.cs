using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

namespace Mobclix
{
	[BaseType (typeof (UIViewController))]
    interface MCBrowserViewController
	{
		[Export ("initWithURLRequest:")]
	    IntPtr Constructor (NSUrlRequest urlRequest);
		
		[Export ("initWithURLRequest:browserStyle:")]
	    IntPtr Constructor (NSUrlRequest urlRequest, BrowserStyle browserStyle);
		
		[Export ("initWithEmbeddedHTML:baseURL:")]
	    IntPtr Constructor (string embeddedHTML, NSUrl baseURL);
		
		[Export ("initWithEmbeddedHTML:baseURL:browserStyle:")]
	    IntPtr Constructor (string embeddedHTML, NSUrl baseURL, BrowserStyle browserStyle);
		
		[Export ("stopLoading")]
	    void StopLoading ();
		
		[Export ("preloadRequest")]
	    void PreloadRequest ();

		[Export ("webView")]
		UIWebView WebView { get; }
		
		[Wrap ("WeakDelegate")][NullAllowed]
		MCBrowserViewControllerDelegate Delegate { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		[Export ("autoDismissOnResignActive", ArgumentSemantic.Assign)]
		bool AutoDismissOnResignActive { get; set; }
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface MCBrowserViewControllerDelegate 
	{
		[Export ("browserViewControllerFinishedPreloading:")]
		void BrowserViewControllerFinishedPreloading (MCBrowserViewController browserViewController);
		
		[Export ("browserViewController:failedToPreloadWithError:")]
		void BrowserViewControllerFailedToPreloadWithError (MCBrowserViewController browserViewController, NSError error);
	}
	
	[Static]
	interface MCNotifications 
	{
    	[Field ("MCBrowserWillShowNotification", "__Internal")]
    	NSString MCBrowserWillShowNotification { get; }
		
		[Field ("MCBrowserDidHideNotification", "__Internal")]
    	NSString MCBrowserDidHideNotification { get; }
		
		[Field ("MCAdsErrorDomain", "__Internal")]
    	NSString MCAdsErrorDomain { get; }
	}
	
	[BaseType (typeof (NSObject))]
    interface Mobclix
	{	
		[Static, Export ("start")]
	    void Start ();
		
		[Static, Export ("startWithApplicationId:")]
	    void StartWithApplicationId (string applicationId);
		
		[Static, Export ("updateLocation:")]
	    void UpdateLocation (CLLocation locaion);
		
		[Static, Export ("isApplicationCracked")]
	    bool IsApplicationCracked ();
	}
	
	[BaseType (typeof (UIView))]
    interface MobclixAdView
	{	
		[Export ("getAd")]
	    void GetAd ();
		
		[Export ("continueRequest")]
	    void ContinueRequest ();
		
		[Export ("pauseAdAutoRefresh")]
	    void PauseAdAutoRefresh ();
		
		[Export ("resumeAdAutoRefresh")]
	    void ResumeAdAutoRefresh ();
		
		[Export ("cancelAd")]
	    void CancelAd ();
		
		[Wrap ("WeakDelegate")][NullAllowed]
		MobclixAdViewDelegate Delegate { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		[Export ("refreshTime", ArgumentSemantic.Assign)]
		double RefreshTime { get; set; }
		
		[Export ("viewController", ArgumentSemantic.Assign)]
		UIViewController ViewController { get; set; }
	}
	
	[BaseType (typeof (MobclixAdView))]
	interface MobclixAdViewiPhone_320x50
	{	
		[Export("initWithFrame:")]
		IntPtr Constructor(RectangleF frame);
	}
	
	[BaseType (typeof (MobclixAdView))]
    interface MobclixAdViewiPhone_300x250
	{	
		[Export("initWithFrame:")]
		IntPtr Constructor(RectangleF frame);
	}
	
	[BaseType (typeof (MobclixAdView))]
    interface MobclixAdViewiPad_300x250
	{	
		[Export("initWithFrame:")]
		IntPtr Constructor(RectangleF frame);
	}
	
	[BaseType (typeof (MobclixAdView))]
    interface MobclixAdViewiPad_728x90
	{	
		[Export("initWithFrame:")]
		IntPtr Constructor(RectangleF frame);
	}
	
	[BaseType (typeof (MobclixAdView))]
    interface MobclixAdViewiPad_120x600
	{	
		[Export("initWithFrame:")]
		IntPtr Constructor(RectangleF frame);
	}
	
	[BaseType (typeof (MobclixAdView))]
    interface MobclixAdViewiPad_468x60
	{	
		[Export("initWithFrame:")]
		IntPtr Constructor(RectangleF frame);
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface MobclixAdViewDelegate 
	{
		[Export ("adViewDidFinishLoad:")]
		void DidFinishLoad (MobclixAdView adView);
		
		[Export ("adView:didFailLoadWithError:")]
		void DidFailLoadWithError (MobclixAdView adView, NSError error);
		
		[Export ("adViewCanAutoplay:")]
		bool CanAutoplay (MobclixAdView adView);
		
		[Export ("richMediaRequiresUserInteraction:")]
		bool RichMediaRequiresUserInteraction (MobclixAdView adView);
		
		[Export ("adView:shouldHandleSuballocationRequest:")]
		bool ShouldHandleSuballocationRequest (MobclixAdView adView, SuballocationType suballocationType);
		
		[Export ("adView:didReceiveSuballocationRequest:")]
		void DidReceiveSuballocationRequest (MobclixAdView adView, SuballocationType suballocationType);
		
		[Export ("adView:publisherKeyForSuballocationRequest:")]
		string PublisherKeyForSuballocationRequest (MobclixAdView adView, SuballocationType suballocationType);
		
		[Export ("adViewWillTouchThrough:")]
		void WillTouchThrough (MobclixAdView adView);
		
		[Export ("adViewDidFinishTouchThrough:")]
		void DidFinishTouchThrough (MobclixAdView adView);
		
		[Export ("adView:didTouchCustomAdWithString:")]
		void DidTouchCustomAdWithString (MobclixAdView adView , string text);
		
		[Export ("mcKeywords")]
		string Keywords ();
		
		[Export ("query")]
		string Query ();
	}
	
	[BaseType (typeof (UIViewController))]
    interface MobclixFullScreenAdViewController
	{	
		[Export ("requestAd")]
	    void RequestAd ();
		
		[Export ("displayRequestedAdFromViewController:")]
	    bool DisplayRequestedAdFromViewController (UIViewController viewController);
		
		[Export ("requestAndDisplayAdFromViewController:")]
	    void RequestAndDisplayAdFromViewController (UIViewController viewController);
		
		[Export ("hasAd")]
		bool HasAd { get; }
		
		[Wrap ("WeakDelegate")][NullAllowed]
		MobclixFullScreenAdDelegate Delegate { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface MobclixFullScreenAdDelegate 
	{
		[Export ("fullScreenAdViewControllerDidFinishLoad:")]
		void DidFinishLoad (MobclixFullScreenAdViewController fullScreenAdViewController);
		
		[Export ("fullScreenAdViewController:didFailToLoadWithError:")]
		void DidFailToLoadWithError (MobclixFullScreenAdViewController fullScreenAdViewController, NSError error);
		
		[Export ("fullScreenAdViewControllerWillPresentAd:")]
		void WillPresentAd (MobclixFullScreenAdViewController fullScreenAdViewController);
		
		[Export ("fullScreenAdViewControllerDidDismissAd:")]
		void DidDismissAd (MobclixFullScreenAdViewController fullScreenAdViewController);
	}
}
