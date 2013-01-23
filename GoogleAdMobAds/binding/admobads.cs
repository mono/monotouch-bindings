using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GoogleAdMobAds
{	
	#region CustomLib
	// This is a custom class created by me and is not part of Google Admob lib
	// But it is necesary for this binding to work
	[BaseType (typeof (NSObject), Name="libAdmobExporter")]
	interface GADAdSizeCons
	{
		[Static, Export ("kGADAdSizeBannerGlobal")]
		GADAdSize Banner { get; }
		
		[Static, Export ("kGADAdSizeFullBannerGlobal")]
		GADAdSize FullBanner { get; }
		
		[Static, Export ("kGADAdSizeInvalidGlobal")]
		GADAdSize Invalid { get; }
		
		[Static, Export ("kGADAdSizeLeaderboardGlobal")]
		GADAdSize Leaderboard { get; }
		
		[Static, Export ("kGADAdSizeMediumRectangleGlobal")]
		GADAdSize MediumRectangle { get; }
		
		[Static, Export ("kGADAdSizeSkyscraperGlobal")]
		GADAdSize Skyscraper { get; }
		
		[Static, Export ("kGADAdSizeSmartBannerLandscapeGlobal")]
		GADAdSize SmartBannerLandscape { get; }
		
		[Static, Export ("kGADAdSizeSmartBannerPortraitGlobal")]
		GADAdSize SmartBannerPortrait { get; }
		
		[Static, Export ("GADAdSizeFromCGSizeGlobal:")]
		GADAdSize GADAdSizeFromSizeF (SizeF size);
		
		[Static, Export ("GADAdSizeFullWidthPortraitWithHeightGlobal:")]
		GADAdSize GADAdSizeFullWidthPortraitWithHeight (float height);
		
		[Static, Export ("GADAdSizeFullWidthLandscapeWithHeightGlobal:")]
		GADAdSize GADAdSizeFullWidthLandscapeWithHeight (float height);
	}
#endregion
	
	[BaseType (typeof (NSObject))]
	interface GADAdMobExtras : GADAdNetworkExtras
	{
		[Export ("additionalParameters", ArgumentSemantic.Retain)]
		NSDictionary AdditionalParameters { get; set; }
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface GADAdNetworkExtras
	{
		
	}
	
	[BaseType (typeof (UIView),
	           Delegates= new string [] {"WeakDelegate"},
	Events=new Type [] { typeof (GADBannerViewDelegate) })]
	interface GADBannerView
	{
		[Export ("initWithAdSize:origin:")]
		IntPtr Constructor (GADAdSize size, PointF origin);
		
		[Export ("initWithAdSize:")]
		IntPtr Constructor (GADAdSize size);
		
		[Export ("adUnitID", ArgumentSemantic.Copy)]
		string AdUnitID { get; set; }
		
		[Export ("rootViewController", ArgumentSemantic.Assign)]
		UIViewController RootViewController {get; set; }
		
		[Export ("adSize")]
		GADAdSize AdSize { get; set; }
		
		[Wrap ("WeakDelegate")][NullAllowed]
		GADBannerViewDelegate Delegate { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		[Export ("loadRequest:")]
		void LoadRequest( [NullAllowed] GADRequest request);
		
		[Export ("hasAutoRefreshed")]
		bool HasAutoRefreshed { get; }
		
		[Export ("mediatedAdView")]
		UIView MediatedAdView { get; }
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface GADBannerViewDelegate
	{
		[Export ("adViewDidReceiveAd:"), EventArgs("GADBannerViewE")]
		void DidReceiveAd(GADBannerView view);
		
		[Export ("adView:didFailToReceiveAdWithError:"), EventArgs("GADBannerViewError")]
		void DidFailToReceiveAd(GADBannerView view, GADRequestError error);
		
		[Export ("adViewWillPresentScreen:"), EventArgs("GADBannerViewE")]
		void WillPresentScreen(GADBannerView adView);
		
		[Export ("adViewWillDismissScreen:"), EventArgs("GADBannerViewE")]
		void WillDismissScreen(GADBannerView adView);
		
		[Export ("adViewDidDismissScreen:"), EventArgs("GADBannerViewE")]
		void DidDismissScreen(GADBannerView adView);
		
		[Export ("adViewWillLeaveApplication:"), EventArgs("GADBannerViewE")]
		void WillLeaveApplication(GADBannerView adView);
	}
	
	[BaseType (typeof (NSObject),
	           Delegates= new string [] {"WeakDelegate"},
	Events=new Type [] { typeof (GADInterstitialDelegate) })]
	interface GADInterstitial
	{
		[Export ("adUnitID", ArgumentSemantic.Copy)]
		string AdUnitID { get; set; }
		
		[Wrap ("WeakDelegate")][NullAllowed]
		GADInterstitialDelegate Delegate { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		[Export ("loadRequest:")]
		void LoadRequest(GADRequest request);
		
		[Export ("loadAndDisplayRequest:usingWindow:initialImage:")]
		void LoadAndDisplayRequest(GADRequest request, UIWindow window, UIImage image);
		
		[Export ("isReady")]
		bool IsReady { get; }
		
		[Export ("hasBeenUsed")]
		bool HasBeenUsed { get; }
		
		[Export ("presentFromRootViewController:")]
		void PresentFromRootViewController(UIViewController rootViewController);
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface GADInterstitialDelegate 
	{
		[Export ("interstitialDidReceiveAd:"), EventArgs("GADInterstitialE")]
		void DidReceiveAd(GADInterstitial ad);
		
		[Export ("interstitial:didFailToReceiveAdWithError:"), EventArgs("GADInterstitialDidFailToReceiveAdWithError")]
		void DidFailToReceiveAd(GADInterstitial sender, GADRequestError error);
		
		[Export ("interstitialWillPresentScreen:"), EventArgs("GADInterstitialE")]
		void WillPresentScreen(GADInterstitial ad);
		
		[Export ("interstitialWillDismissScreen:"), EventArgs("GADInterstitialE")]
		void WillDismissScreen(GADInterstitial ad);
		
		[Export ("interstitialDidDismissScreen:"), EventArgs("GADInterstitialE")]
		void DidDismissScreen(GADInterstitial ad);
		
		[Export ("interstitialWillLeaveApplication:"), EventArgs("GADInterstitialE")]
		void WillLeaveApplication(GADInterstitial ad);
		
	}
	
	[BaseType (typeof (NSObject))]
	interface GADRequest
	{
		[Static, Export ("request")]
		GADRequest Request { get; }
		
		[Export ("registerAdNetworkExtras:")]
		void RegisterAdNetworkExtras(GADAdNetworkExtras extras);
		
		[Export ("adNetworkExtrasFor:")]
		GADAdNetworkExtras AdNetworkExtrasFor(Class clazz);
		
		[Export ("removeAdNetworkExtrasFor:")]
		void RemoveAdNetworkExtrasFor(Class clazz);
		
		[Export ("mediationExtras", ArgumentSemantic.Retain)]
		NSDictionary MediationExtras { get; set; }
		
		[Static, Export ("sdkVersion")]
		string SdkVersion { get; }
		
		[Export ("testing")]
		bool Testing { [Bind("isTesting")] get; set; }
		
		[Export ("gender", ArgumentSemantic.Assign)]
		GADGender Gender { get; set; }
		
		[Export ("birthday", ArgumentSemantic.Retain)]
		NSDate Birthday { get; set; } 
		
		[Export ("setBirthdayWithMonth:day:year:")]
		void SetBirthday(int m, int d, int y);
		
		[Export ("setLocationWithLatitude:longitude:accuracy:")]
		void SetLocationWithLatitude(float latitude, float longitude, float accuracyInMeters);
		
		[Export ("setLocationWithDescription:")]
		void SetLocationWithDescription(string locationDescription);
		
		[Export ("keywords", ArgumentSemantic.Retain), NullAllowed]
		string [] keywords { get; set; }
		
		[Export ("addKeyword:")]
		void AddKeyword (string keyword);
		
		[Export ("testDevices", ArgumentSemantic.Retain)]
		string [] TestDevices { get; set; }
		
		#region "Deprecated GAdRequest Methods"		
		[Export ("additionalParameters", ArgumentSemantic.Retain), Obsolete ("Please use void RegisterAdNetworkExtras(GADAdNetworkExtras extras) instead")]
		NSDictionary AdditionalParameters { get; set; }
#endregion
		
	}
	
	[BaseType (typeof (NSError))]
	interface GADRequestError 
	{
		
	}
	
	#region Search
	
	[BaseType (typeof (NSObject))]
	interface GADSearchRequest 
	{
		[Export ("query", ArgumentSemantic.Copy)]
		string Query { get; set; }
		
		[Export ("backgroundColor")]
		UIColor BackgroundColor { get; }
		
		[Export ("gradientFrom")]
		UIColor GradientFrom { get; }
		
		[Export ("gradientTo")]
		UIColor GradientTo { get; }
		
		[Export ("headerColor", ArgumentSemantic.Retain)]
		UIColor HeaderColor { get; set; }
		
		[Export ("descriptionTextColor", ArgumentSemantic.Retain)]
		UIColor DescriptionTextColor { get; set; }
		
		[Export ("anchorTextColor", ArgumentSemantic.Retain)]
		UIColor AnchorTextColor { get; set; }
		
		[Export ("fontFamily", ArgumentSemantic.Copy)]
		string FontFamily { get; set; }
		
		[Export ("headerTextSize")]
		int HeaderTextSize { get; set; }
		
		[Export ("borderColor", ArgumentSemantic.Retain)]
		UIColor BorderColor { get; set; }
		
		[Export ("borderType")]
		GADSearchBorderType BorderType { get; set; }
		
		[Export ("borderThickness")]
		int BorderThickness { get; set; }
		
		[Export ("customChannels", ArgumentSemantic.Copy)]
		string CustomChannels { get; set; }
		
		[Export ("request")]
		GADRequest Request { get; }
		
		[Export ("setBackgroundSolid:")]
		void SetBackgroundSolid (UIColor color);
		
		[Export ("setBackgroundGradientFrom:toColor:")]
		void SetBackgroundGradient (UIColor fromColor, UIColor toColor);
	}
	
	[BaseType (typeof (GADBannerView))]
	interface GADSearchBannerView 
	{
		
	}
	
#endregion
	
	#region DoubleClick
	
	[BaseType (typeof (GADAdMobExtras))]
	interface DFPExtras 
	{
		[Export ("publisherProvidedID", ArgumentSemantic.Copy)]
		string PublisherProvidedID { get; set; }
	}
	
	[BaseType (typeof (GADInterstitial),
	           Delegates= new string [] {"WeakAppEventDelegate" },
	Events=new Type [] { typeof (GADAppEventDelegate) } )]
	interface DFPInterstitial 
	{
		[Wrap ("WeakAppEventDelegate")][NullAllowed]
		GADAppEventDelegate AppEventDelegate { get; set; }
		
		[Export ("appEventDelegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakAppEventDelegate { get; set; }
	}
	
	[BaseType (typeof (GADBannerView),
	           Delegates= new string [] {"WeakAppEventDelegate", "WeakAdSizeDelegate" },
	Events=new Type [] { typeof (GADAppEventDelegate), typeof(GADAdSizeDelegate) })]
	interface DFPBannerView 
	{
		[Wrap ("WeakAppEventDelegate")][NullAllowed]
		GADAppEventDelegate AppEventDelegate { get; set; }
		
		[Export ("appEventDelegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakAppEventDelegate { get; set; }
		
		[Wrap ("WeakAdSizeDelegate")][NullAllowed]
		GADAdSizeDelegate AdSizeDelegate { get; set; }
		
		[Export ("adSizeDelegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakAdSizeDelegate { get; set; }
		
		[Export ("validAdSizes", ArgumentSemantic.Retain)]
		NSObject [] ValidAdSizes { get; set; }
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface GADAdSizeDelegate 
	{
		[Export ("adView:willChangeAdSizeTo:"), EventArgs("GADAdSizeDelegateSize")]
		void WillChangeAdSizeTo(GADBannerView view, GADAdSize size);
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface GADAppEventDelegate 
	{
		[Export ("adView:didReceiveAppEvent:withInfo:"), EventArgs("GADAppEventDelegateNameInfo")]
		void AdViewDidReceiveAppEvent(GADBannerView banner, string name, string info);
		
		[Export ("interstitial:didReceiveAppEvent:withInfo:"), EventArgs("GADAppEventDelegateInterstitial")]
		void InterstitialDidReceiveAppEvent(GADInterstitial interstitial, string name, string info);
	}
	
#endregion
	
	#region Mediation
	
	[BaseType (typeof (NSObject),
	           Delegates= new string [] {"WeakDelegate" },
	Events=new Type [] { typeof (GADCustomEventBannerDelegate) } )]
	interface GADCustomEventBanner 
	{
		[Export ("requestBannerAd:parameter:label:request:")]
		void RequestBannerAd(GADAdSize adSize, string serverParameter, string serverLabel, GADCustomEventRequest request);
		
		[Wrap ("WeakDelegate")][NullAllowed]
		GADCustomEventBannerDelegate Delegate { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface GADCustomEventBannerDelegate 
	{
		[Export ("customEventBanner:didReceiveAd:"), EventArgs("GADCustomEventBannerView")]
		void DidReceiveAd(GADCustomEventBanner customEvent, UIView view);
		
		[Export ("customEventBanner:didFailAd:"), EventArgs("GADCustomEventBannerDidReceiveAd")]
		void DidFailAd(GADCustomEventBanner customEvent, NSError error);
		
		[Export ("customEventBanner:clickDidOccurInAd:"), EventArgs("GADCustomEventBannerView")]
		void DidClickInAd(GADCustomEventBanner customEvent, UIView view);
		
		[Export ("viewControllerForPresentingModalView")]
		UIViewController ViewControllerForPresentingModalView { get; }
		
		[Export ("customEventBannerWillPresentModal:"), EventArgs("GADCustomEventModal")]
		void WillPresentModal(GADCustomEventBanner customEvent);
		
		[Export ("customEventBannerWillDismissModal:"), EventArgs("GADCustomEventModal")]
		void WillDismissModal(GADCustomEventBanner customEvent);
		
		[Export ("customEventBannerDidDismissModal:"), EventArgs("GADCustomEventModal")]
		void DidDismissModal(GADCustomEventBanner customEvent);
		
		[Export ("customEventBannerWillLeaveApplication:"), EventArgs("GADCustomEventModal")]
		void WillLeaveApplication(GADCustomEventBanner customEvent);
	}
	
	[BaseType (typeof (GADAdNetworkExtras))]
	interface GADCustomEventExtras
	{
		[Export ("setExtras:forLabel:")] [PostGet ("AllExtras")]
		void SetExtras(NSDictionary extras, string label);
		
		[Export ("extrasForLabel:")]
		NSDictionary ExtrasForLabel(string label);
		
		[Export ("removeAllExtras")] [PostGet ("AllExtras")]
		void RemoveAllExtras();
		
		[Export ("allExtras")]
		NSDictionary AllExtras { get; }
	}
	
	[BaseType (typeof (NSObject),
	           Delegates= new string [] {"WeakDelegate" },
	Events=new Type [] { typeof (GADCustomEventInterstitialDelegate) } )]
	interface GADCustomEventInterstitial 
	{
		[Export ("requestInterstitialAdWithParameter:label:request:")]
		void RequestInterstitialAd(string serverParameter, string serverLabel, GADCustomEventRequest request);
		
		[Export ("presentFromRootViewController:")]
		void PresentFromRootViewController(UIViewController rootViewController);
		
		[Wrap ("WeakDelegate")][NullAllowed]
		GADCustomEventInterstitialDelegate Delegate { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface GADCustomEventInterstitialDelegate 
	{
		[Export ("customEventInterstitial:didReceiveAd:"), EventArgs("GADCustomEventInterstitialAd")]
		void DidReceiveAd(GADCustomEventInterstitial customEvent, NSObject ad);
		
		[Export ("customEventInterstitial:didFailAd:"), EventArgs("GADCustomEventInterstitialError")]
		void DidFailAd(GADCustomEventInterstitial customEvent, NSError error);
		
		[Export ("customEventInterstitialWillPresent:"), EventArgs("GADCustomEventInterstitialCustom")]
		void WillPresent(GADCustomEventInterstitial customEvent);
		
		[Export ("customEventInterstitialWillDismiss:"), EventArgs("GADCustomEventInterstitialCustom")]
		void WillDismiss(GADCustomEventInterstitial customEvent);
		
		[Export ("customEventInterstitialDidDismiss:"), EventArgs("GADCustomEventInterstitialCustom")]
		void DidDismiss(GADCustomEventInterstitial customEvent);
		
		[Export ("customEventInterstitialWillLeaveApplication:"), EventArgs("GADCustomEventInterstitialCustom")]
		void WillLeaveApplication(GADCustomEventInterstitial customEvent);
	}
	
	[BaseType (typeof (NSObject))]
	interface GADCustomEventRequest
	{
		[Export ("userGender")]
		GADGender UserGender { get; }
		
		[Export ("userBirthday")]
		NSDate UserBirthday { get; }
		
		[Export ("userHasLocation")]
		bool UserHasLocation { get; }
		
		[Export ("userLatitude")]
		float UserLatitude { get; }
		
		[Export ("userLongitude")]
		float UserLongitude { get; }
		
		[Export ("userLocationAccuracyInMeters")]
		float UserLocationAccuracyInMeters { get; }
		
		[Export ("userLocationDescription")]
		string UserLocationDescription { get; }
		
		[Export ("userKeywords")] [NullAllowed]
		NSObject [] UserKeywords { get; }
		
		[Export ("additionalParameters")]
		NSDictionary AdditionalParameters { get; }
		
		[Export ("isTesting")]
		bool IsTesting { get; }
	}
	
#endregion
}
