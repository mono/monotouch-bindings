using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace AlexTouch.GoogleAdMobAds
{
	[BaseType (typeof (UIView),
	Delegates= new string [] {"WeakDelegate"},
	Events=new Type [] { typeof (GADBannerViewDelegate) })]
	interface GADBannerView
	{
		//@property (nonatomic, copy) NSString *adUnitID;
		[Export ("adUnitID", ArgumentSemantic.Copy)]
		string AdUnitID { get; set; }
		
		//@property (nonatomic, assign) UIViewController *rootViewController;
		[Export ("rootViewController", ArgumentSemantic.Assign)]
		UIViewController RootViewController {get; set; }
		
		//@property (nonatomic, assign) NSObject<GADBannerViewDelegate> *delegate;
		[Wrap ("WeakDelegate")][NullAllowed]
		GADBannerViewDelegate Delegate { get; set; }
		
		//@property (nonatomic, assign) NSObject<GADBannerViewDelegate> *delegate;
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		//- (void)loadRequest:(GADRequest *)request;
		[Export ("loadRequest:")]
		void LoadRequest( [NullAllowed] GADRequest request);
		
		//@property (nonatomic, readonly) BOOL hasAutoRefreshed;
		[Export ("hasAutoRefreshed")]
		bool HasAutoRefreshed { get; }
		
		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);
	}
	
	[BaseType (typeof (NSObject))]
	interface GADBannerViewDelegate 
	{
		//- (void)adViewDidReceiveAd:(GADBannerView *)view;
		[Export ("adViewDidReceiveAd:"), EventArgs("GADBannerViewAdViewDidReceiveAd")]
		void DidReceiveAd(GADBannerView sender);
		
		//- (void)adView:(GADBannerView *)view didFailToReceiveAdWithError:(GADRequestError *)error;
		[Export ("adView:didFailToReceiveAdWithError:"), EventArgs("GADBannerViewDidFailWithError")]
		void DidFailToReceiveAdWithError(GADBannerView sender, GADRequestError error);
		
		//- (void)adViewWillPresentScreen:(GADBannerView *)adView;
		[Export ("adViewWillPresentScreen:"), EventArgs("GADBannerWillPresentScreen")]
		void WillPresentScreen(GADBannerView sender);
		
		//- (void)adViewWillDismissScreen:(GADBannerView *)adView;
		[Export ("adViewWillDismissScreen:"), EventArgs("GADBannerWillDismissScreen")]
		void WillDismissScreen(GADBannerView sender);
		
		//- (void)adViewDidDismissScreen:(GADBannerView *)adView;
		[Export ("adViewDidDismissScreen:"), EventArgs("GADBannerDidDismissScreen")]
		void DidDismissScreen(GADBannerView sender);
		
		//- (void)adViewWillLeaveApplication:(GADBannerView *)adView;
		[Export ("adViewWillLeaveApplication:"), EventArgs("GADBannerWillLeaveApplication")]
		void WillLeaveApplication(GADBannerView sender);
	}
	
	[BaseType (typeof (NSObject),
	Delegates= new string [] {"WeakDelegate"},
	Events=new Type [] { typeof (GADInterstitialDelegate) })]
	interface GADInterstitial
	{
		//@property (nonatomic, copy) NSString *adUnitID;
		[Export ("adUnitID", ArgumentSemantic.Copy)]
		string AdUnitID { get; set; }
		
		//@property (nonatomic, assign) NSObject<GADInterstitialDelegate> *delegate;
		[Wrap ("WeakDelegate")][NullAllowed]
		GADInterstitialDelegate Delegate { get; set; }
		
		//@property (nonatomic, assign) NSObject<GADInterstitialDelegate> *delegate;
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		//- (void)loadRequest:(GADRequest *)request;
		[Export ("loadRequest:")]
		void LoadRequest(GADRequest request);
		
		//- (void)loadAndDisplayRequest:(GADRequest *)request usingWindow:(UIWindow *)window initialImage:(UIImage *)image;
		[Export ("loadAndDisplayRequest:usingWindow:initialImage:")]
		void LoadAndDisplayRequest(GADRequest request, UIWindow window, UIImage image);
		
		//@property (nonatomic, readonly) BOOL isReady;
		[Export ("isReady")]
		bool IsReady { get; }
		
		//@property (nonatomic, readonly) BOOL hasBeenUsed;
		[Export ("hasBeenUsed")]
		bool HasBeenUsed { get; }
		
		//- (void)presentFromRootViewController:(UIViewController *)rootViewController;
		[Export ("presentFromRootViewController:")]
		void PresentFromRootViewController(UIViewController rootViewController);
	}
	
	[BaseType (typeof (NSObject))]
	interface GADInterstitialDelegate 
	{
		//- (void)interstitialDidReceiveAd:(GADInterstitial *)ad;
		[Export ("interstitialDidReceiveAd:"), EventArgs("GADInterstitialDidReceiveAd")]
		void DidReceiveAd(GADInterstitial sender);
		
		//- (void)interstitial:(GADInterstitial *)ad didFailToReceiveAdWithError:(GADRequestError *)error;
		[Export ("interstitial:didFailToReceiveAdWithError:"), EventArgs("GADInterstitialDidFailToReceiveAdWithError")]
		void DidFailToReceiveAdWithError(GADInterstitial sender, GADRequestError error);
		
		//- (void)interstitialWillPresentScreen:(GADInterstitial *)ad;
		[Export ("interstitialWillPresentScreen:"), EventArgs("GADInterstitialWillPresentScreen")]
		void WillPresentScreen(GADInterstitial sender);
		
		//- (void)interstitialWillDismissScreen:(GADInterstitial *)ad;
		[Export ("interstitialWillDismissScreen:"), EventArgs("GADInterstitialWillDismissScreen")]
		void WillDismissScreen(GADInterstitial sender);
		
		//- (void)interstitialDidDismissScreen:(GADInterstitial *)ad;
		[Export ("interstitialDidDismissScreen:"), EventArgs("GADInterstitialDidDismissScreen")]
		void DidDismissScreen(GADInterstitial sender);
		
		//- (void)interstitialWillLeaveApplication:(GADInterstitial *)ad;
		[Export ("interstitialWillLeaveApplication:"), EventArgs("GADInterstitialWillLeaveApplication")]
		void WillLeaveApplication(GADInterstitial sender);
		
	}
	
	[BaseType (typeof (NSObject))]
	interface GADRequest
	{
		//+ (GADRequest *)request;
		[Static, Export ("request")]
		GADRequest Request();
		
		//@property (nonatomic, retain) NSDictionary *additionalParameters;
		[Export ("additionalParameters", ArgumentSemantic.Retain)]
		NSDictionary AdditionalParameters { get; set; }
		
		//+ (NSString *)sdkVersion;
		[Static, Export ("sdkVersion")]
		string SdkVersion();
		
		//@property (nonatomic, retain) NSArray *testDevices;
		[Export ("testDevices", ArgumentSemantic.Retain)]
		string [] TestDevices { get; set; }
		
		//@property (nonatomic, assign) GADGender gender;
		[Export ("gender", ArgumentSemantic.Assign)]
		GADGender Gender { get; set; }
		
		//@property (nonatomic, retain) NSDate *birthday;
		[Export ("birthday", ArgumentSemantic.Retain)]
		NSDate Birthday { get; set; } 
		
		//- (void)setBirthdayWithMonth:(NSInteger)m day:(NSInteger)d year:(NSInteger)y;
		[Export ("setBirthdayWithMonth:day:year:")]
		void SetBirthday(int m, int d, int y);
		
		//- (void)setLocationWithLatitude:(CGFloat)latitude longitude:(CGFloat)longitude accuracy:(CGFloat)accuracyInMeters;
		[Export ("setLocationWithLatitude:longitude:accuracy:")]
		void SetLocationWithLatitude(float latitude, float longitude, float accuracyInMeters);
		
		//- (void)setLocationWithDescription:(NSString *)locationDescription;
		[Export ("setLocationWithDescription:")]
		void SetLocationWithDescription(string locationDescription);
		
		//@property (nonatomic, retain) NSMutableArray *keywords;
		[Export ("keywords", ArgumentSemantic.Retain), NullAllowed]
		string [] keywords { get; set; }
		
		//- (void)addKeyword:(NSString *)keyword;
		[Export ("addKeyword:")]
		void AddKeyword (string keyword);
		
		//@property (nonatomic, getter=isTesting) BOOL testing;
		[Export ("testing")]
		bool Testing {  [Bind ("isTesting")] get; set; }
	}
	
	[BaseType (typeof (NSError))]
	interface GADRequestError 
	{
		
	}
}

