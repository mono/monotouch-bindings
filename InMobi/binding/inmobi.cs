using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace InMobi
{
	/// <summary>
	/// Specifies optional parameters for ad requests.
	/// </summary>
	[BaseType(typeof(NSObject))]
	public interface IMAdRequest
	{
		/// <summary>
		/// Postal code of the user may be used to deliver more relevant ads.
		/// </summary>
		/// <value>
		/// The postal code.
		/// </value>
		[Export("postalCode")]
		string PostalCode { get; set; }
		
		/// <summary>
		/// Area code of the user may be used to deliver more relevant ads.
		/// </summary>
		/// <value>
		/// The area code.
		/// </value>
		[Export("areaCode")]
		string AreaCode { get; set; }
		
		/// <summary>
		/// Date of birth of the user may be used to deliver more relevant ads.
		/// </summary>
		/// <value>
		/// The date of birth.
		/// </value>
		[Export("dateOfBirth")]
		string DateOfBirth { get; set; }
		
		/// <summary>
		/// Gender of the user may be used to deliver more relevant ads.
		/// </summary>
		/// <value>
		/// The gender.
		/// </value>
		[Export("gender")]
		Gender Gender { get; set; }
		
		/// <summary>
		/// Use contextually relevant strings to deliver more relevant ads.
		/// </summary>
		/// <value>
		/// The keywords.
		/// </value>
		[Export("keywords")]
		string Keywords { get; set; }
		
		/// <summary>
		/// search string provided by the user, e.g. @"Hotel Bangalore India"
		/// </summary>
		/// <value>
		/// The search string.
		/// </value>
		[Export("searchString")]
		string SearchString { get; set; }
		
		/// <summary>
		/// optional, if the user has specified his/her income. income should be in USD.
		/// </summary>
		/// <value>
		/// The income.
		/// </value>
		[Export("income")]
		uint Income { get; set; }
		
		/// <summary>
		/// Educational qualification of the user may be used to deliver more relevant ads.
		/// </summary>
		/// <value>
		/// The education.
		/// </value>
		[Export("education")]
		Education Education { get; set; }
		
		/// <summary>
		/// Ethnicity of the user may be used to deliver more relevant ads. Look for IMAdRequest.h class to set the relevant values  
		/// </summary>
		/// <value>
		/// The ethnicity.
		/// </value>
		[Export("ethnicity")]
		Ethnicity Ethnicity { get; set; }
		
		/// <summary>
		/// Age of the user may be used to deliver more relevant ads. Look for IMAdRequest.h class to set the relevant values  
		/// </summary>
		/// <value>
		/// The age.
		/// </value>
		[Export("age")]
		uint Age { get; set; }
		
		/// <summary>
		/// Use contextually relevant strings to deliver more relevant ads. Eg @"cars bikes racing"
		/// </summary>
		/// <value>
		/// The interests.
		/// </value>
		[Export("interests")]
		string Interests { get; set; }
		
		/// <summary>
		/// Provide additional values to be passed in the ad request as key-value pair.
		/// </summary>
		/// <value>
		/// The parameters dictionary.
		/// </value>
		[Export("paramsDictionary")]
		NSDictionary ParamsDictionary { get; set; }
		
		/// <summary>
		/// Allow InMobi to access location of the user for geo-targeted advertising. This value is set to YES by default.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is location enquiry allowed; otherwise, <c>false</c>.
		/// </value>
		[Export("isLocationEnquiryAllowed")]
		bool IsLocationEnquiryAllowed { get; set; }
		
		/// <summary>
		/// Set testMode to YES for receiving test-ads. default value is NO.
		/// </summary>
		/// <value>
		/// <c>true</c> if test mode; otherwise, <c>false</c>.
		/// </value>
		[Export("testMode")]
		bool TestMode { get; set; }
		
		/// <summary>
		/// Default value is YES. You may set this to NO if you want Inmobi to send UDID value of publisher as plain text.
		/// </summary>
		/// <value>
		/// <c>true</c> if UDID hashing allowed; otherwise, <c>false</c>.
		/// </value>
		[Export("UDIDHashingAllowed")]
		bool UDIDHashingAllowed { get; set; }
	}
	
	/// <summary>
	/// The view that displays banner ads.
	/// </summary>
	[BaseType (typeof(UIView))]
	public interface IMAdView
	{
		/// <summary>
		/// You can obtain your AppId under Publisher section by logging into inmobi.com. Must be not-null.
		/// </summary>
		/// <value>
		/// The app identifier.
		/// </value>
		[Export("imAppId")]
		string AppId { get; set; }
		
		/// <summary>
		/// Required reference to the current root view controller. For example the root view controller in navigation-based application would be the UINavigationController. must be not-null.
		/// </summary>
		/// <value>
		/// The root view controller.
		/// </value>
		[Export("rootViewController")]
		UIViewController RootViewController { get; set; }
		
		/// <summary>
		/// The ad-unit slot to request for the specific banner size. Defaults to IM_AD_SIZE_320x50. Please see above for supported banner sizes and their slots.
		/// </summary>
		/// <value>
		/// The ad unit.
		/// </value>
		[Export("imAdUnit")]
		int AdUnit { get; set; }
		
		/// <summary>
		/// Specify a time period (seconds) for this view to refresh ads. To disable auto refreshing, set this value to REFRESH_INTERVAL_OFF. The default value is 60 seconds. Minimum refresh interval should be 20 seconds. Throws InvalidArgumentException if interval is set to less than minimum refresh interval.
		/// </summary>
		/// <value>
		/// The refresh interval.
		/// </value>
		[Export("refreshInterval")]
		int RefreshInterval { get; set; }
		
		/// <summary>
		///  Optional delegate object that receives state change notifications from this view. Typically this is a UIViewController instance. Set the delegate property of this view to nil in the dealloc method of your UIViewController.
		/// </summary>
		/// <value>
		/// The delegate.
		/// </value>
		[Export("delegate", ArgumentSemantic.Assign), NullAllowed]
		IMAdDelegate Delegate { get; set; }
		
		/// <summary>
		/// Specify animationtype to be performed when this view will refresh. Default value is AnimationCurlUp
		/// </summary>
		/// <value>
		/// The type of the animation.
		/// </value>
		[Export("animationType")]
		Animation AnimationType { get; set; }
		
		/// <summary>
		/// Specify additional parameters for targeted advertising. You may call loadIMAdRequest method for this view to load the request. Optionally you can specify a request object by calling loadIMAdRequest: method for this view. see IMAdRequest class for more details
		/// </summary>
		/// <value>
		/// The ad request.
		/// </value>
		[Export("imAdRequest")]
		IMAdRequest AdRequest { get; set; }
		
		/// <summary>
		///  Use this constructor to obtain an instance of IMAdView. frame 
		/// </summary>
		/// <param name='frame'>
		/// The CGRect bounds for this view, typically according to the adunit slot requested.
		/// </param>
		/// <param name='appId'>
		/// The publisher's app-id as obtained from inmobi.
		/// </param>
		/// <param name='adUnit'>
		/// The adunit slot, to request the specific banner size.
		/// </param>
		/// <param name='rootViewController'>
		/// The rootviewcontroller for this view.
		/// </param>
		[Export ("initWithFrame:imAppId:imAdUnit:rootViewController:")]
		IntPtr Constructor (RectangleF frame, string appId, int adUnit, UIViewController rootViewController);
		
		/// <summary>
		/// Call this method to refresh this view.
		/// </summary>
		/// <param name='request'>
		/// The IMAdRequest object for requesting additional parameters.
		/// </param>
		[Export("loadIMAdRequest:")]
		void LoadAdRequest (IMAdRequest request);
		
		/// <summary>
		/// Call this method to refresh this view. This method will call loadIMAdRequest: with the imAdRequest object specified for this view.
		/// </summary>
		[Export("loadIMAdRequest:")]
		void LoadAdRequest ();
		
		/// <summary>
		/// Use this method to specify the text color for the ad. The color value must be of the format @"#RRGGBB". This method will be valid only for a "text ad". For other ads, the value will be ignored. 
		/// </summary>
		/// <param name='color'>
		/// the RGB value of the color.
		/// </param>
		[Export("setAdTextColor:")]
		void SetAdTextColor (string color);
		
		/// <summary>
		/// Use this method to specify background color for the ad. The color value must be of the format @"#RRGGBB". This method will be valid only for a "text ad". For other ads, the value will be ignored.
		/// </summary>
		/// <param name='color'>
		/// the RGB value of the color.
		/// </param>
		[Export("setAdBackgroundColor:")]
		void SetAdBackgroundColor (string color);
		
		/// <summary>
		/// Use this method to specify background color with a linear gradient. The color value must be of the format @"#RRGGBB". This method will be valid only for a "text ad". For other ads, the value will be ignored.
		/// </summary>
		/// <param name='topColor'>
		/// the top RGB value for the gradient.
		/// </param>
		/// <param name='bottomColor'>
		/// the bottom RGB value for the gradient.
		/// </param>
		[Export("setAdBackgroundGradientWithTopColor:bottomColor:")]
		void SetAdBackgroundGradient (string topColor, string bottomColor);
		
		/// <summary>
		/// Use this method to assign a custom reference tag at the time of making an Ad Request to the InMobi Ad Server. Maximum character limit for ref-tag is 50.
		/// </summary>
		/// <param name='value'>
		/// value the value for this ref-tag
		/// </param>
		/// <param name='key'>
		/// key the key for this ref-tag
		/// </param>
		[Export("setRefTag:forKey:")]
		void SetRefTag (string value, string key);
	}
	
	/// <summary>
	/// Defines the error codes passed when an InMobi ad request fails to load.
	/// </summary>
	[BaseType(typeof(NSError))]
	public interface IMADError
	{
		
	}
	
	/// <summary>
	/// Defines the InMobiAdDelegate protocol.
	/// </summary>
	[BaseType(typeof(NSObject)), Model]
	public interface IMAdDelegate
	{
		/// <summary>
		/// Sent when an ad request loaded an ad.  This is a good opportunity to add this view to the hierarchy if it has not yet been added.
		/// </summary>
		/// <param name='adView'>
		/// The IMAdView which finished loading the ad request.
		/// </param>
		[Export("adViewDidFinishRequest:")]
		void DidFinishRequest (IMAdView adView);
				
		/// <summary>
		/// Sent when an ad request failed.  Normally this is because no network connection was available or no ads were available (i.e. no fill).  If the error was received as a part of the server-side auto refreshing, you can examine the hasAutoRefreshed property of the view.
		/// </summary>
		/// <param name='view'>
		/// The IMAdView which failed to load the ad request.
		/// </param>
		/// <param name='error'>
		/// The error that occurred during loading.
		/// </param>
		[Export("adView:didFailRequestWithError:")]
		void DidFailRequestWithError(IMAdView view, IMADError error);
		
		/// <summary>
		/// Sent just before the adview will present a full screen view to the user. Use this opportunity to stop animations and save the state of your application.
		/// </summary>
		/// <param name='adView'>
		/// The adview responsible for presenting the screen.
		/// </param>
		[Export("adViewWillPresentScreen:")]
		void WillPresentScreen(IMAdView adView);
		
		/// <summary>
		/// Sent just before dismissing a full screen view.
		/// </summary>
		/// <param name='adView'>
		/// The adview responsible for dismissing the screen.
		/// </param>
		[Export("adViewWillDismissScreen:")]
		void WillDismissScreen(IMAdView adView);
		
		/// <summary>
		/// Sent just after dismissing a full screen view.  Use this opportunity to restart anything you may have stopped as part of WillPresentScreen.
		/// </summary>
		/// <param name='adView'>
		/// The adview responsible for dismissing the screen.
		/// </param>
		[Export("adViewDidDismissScreen:")]
		void DidDismissScreen(IMAdView adView);
		
		/// <summary>
		/// Sent just before the application will background or terminate because the user clicked on an ad that will launch another application (such as the App Store). The normal UIApplicationDelegate methods, like applicationDidEnterBackground:, will be called immediately after this.
		/// </summary>
		/// <param name='adView'>
		/// The adview responsible for launching another application.
		/// </param>
		[Export("adViewWillLeaveApplication:")]
		void WillLeaveApplication(IMAdView adView);
	}
	
	/// <summary>
	/// InMobi SDK Utility class
	/// </summary>
	[BaseType(typeof(NSObject))]
	public interface IMSDKUtil 
	{
		/// <summary>
		/// The LogLevel, for printing console messages
		/// </summary>
		/// <value>
		/// The log level.
		/// </value>
		[Export("logLevel")]
		LogLevel LogLevel { get; set; }
		
		/// <summary>
		/// This method returns the InMobi iOS SDK version. Typically of the format @"2.0.0",@"2.1.3" etc.
		/// </summary>
		/// <value>
		/// The sdk version.
		/// </value>
		[Export("sdkVersion")]
		string SdkVersion { get; }
		
		/// <summary>
		/// Returns the singleton instance of this class.
		/// </summary>
		/// <value>
		/// The util.
		/// </value>
		[Static, Export("util")]
		IMSDKUtil Util { get; }
		
		/// <summary>
		/// Send the application installed tracker conversion ping to the server. The information will be sent only once and calling multiple times does not have any effect.
		/// </summary>
		/// <param name='advertiserId'>
		/// advertiserId Advertiser Id.
		/// </param>
		/// <param name='itunesId'>
		/// itunesId Itunes Id of your app, as obtained from Apple.
		/// </param>
		[Export("startAppTrackerConversion:iTunesId:")]
		void StartAppTrackerConversion(string advertiserId, string itunesId);
	}

	[BaseType(typeof(NSObject))]
	public interface IMAdInterstitial
	{
		/// <summary>
		/// You can obtain your AppId under publisher section by logging into inmobi.com. 
		/// </summary>
		[Export("imAppId")]
		string AppId { get; set; }

		/// <summary>
		/// Optional delegate object that receives state change notifications from this interstitial object. 
		/// </summary>
		[Export("delegate", ArgumentSemantic.Assign), NullAllowed]
		IMAdInterstitialDelegate Delegate { get; set; }

		/// <summary>
		/// Makes an interstitial ad request.
		/// This is best to do several seconds before the interstitial is needed to
		/// preload its content.  
		/// </summary>
		/// <param name='request'>
		/// The ad request which will be loaded. Additional targeting options can be supplied with a request object.
		/// </param>
		[Export("loadRequest:")]
		void LoadRequest(IMAdRequest request);

		/// <summary>
		/// Returns the state of the interstitial ad.  The delegate's interstitialDidFinishRequest: will be called when this switches from kIMInterstitialAdStateInit state to kIMInterstitialAdStateReady state.
		/// </summary>
		[Export("state")]
		InterstitialState State { get; set; }

		/// <summary>
		/// Presents the interstitial ad which takes over the entire screen until the user dismisses it. This has no effect unless interstitialState returns kIMInterstitialAdStateReady and/or the delegate's interstitialDidReceiveAd: has been received.
		/// </summary>
		/// <param name='rootViewController'>
		/// The current view controller at the time this method is called.
		/// </param>
		[Export("presentFromRootViewController:")]
		void PresentFromRootViewController(UIViewController rootViewController);
	}

	/// <summary>
	/// Defines the IMAdInterstitialDelegate protocol
	/// </summary>
	[BaseType(typeof(NSObject))]
	public interface IMAdInterstitialDelegate
	{
		/// <summary>
		/// Sent when an interstitial ad request succeeded. 
		/// </summary>
		/// <param name='ad'>
		/// The interstitial ad which got loaded.
		/// </param>
		[Export("interstitialDidFinishRequest:")]
		void DidFinishRequest(IMAdInterstitial ad);

		/// <summary>
		/// Sent when an interstitial ad request completed without an interstitial to show.  This is common since interstitials are shown sparingly to users.
		/// </summary>
		/// <param name='ad'>
		/// The interstitial which failed to load.
		/// </param>
		/// <param name='error'>
		/// The error that occurred during loading.
		/// </param>
		[Export("interstitial:didFailToReceiveAdWithError:")]
		void DidFailToReceiveAd(IMAdInterstitial ad, IMADError error);

		/// <summary>
		/// Sent just before presenting an interstitial.  After this method finishes the
		/// interstitial will animate onto the screen.  Use this opportunity to stop
		/// animations and save the state of your application.
		/// </summary>
		/// <param name='ad'>
		/// The interstitial which will be presented to the user.
		/// </param>
		[Export("interstitialWillPresentScreen:")]
		void WillPresentScreen(IMAdInterstitial ad);

		/// <summary>
		/// Sent when an interstitial fails to present a full screen to the user. 
		/// This will generally occur if interstitial is not in a kIMInterstitialAdStateReady state.
		/// See IMAdInterstitial.h for a list of states.
		/// NOTE: An interstitial ad can be shown only once.
		/// After dismissal, you must again call loadRequest: and wait for this ad request to succeed.
		/// </summary>
		/// <param name='ad'>
		/// The interstitial which failed to present screen.
		/// </param>
		/// <param name='error'>
		/// The error that occurred during loading.
		/// </param>
		[Export("interstitial:didFailToPresentScreenWithError:")]
		void WillPresentScreen(IMAdInterstitial ad, IMADError error);

		/// <summary>
		/// Sent before the interstitial is to be animated off the screen.
		/// </summary>
		/// <param name='ad'>
		/// The interstitial which will be dismissed off the screen.
		/// </param>
		[Export("interstitialWillDismissScreen:")]
		void WillDismissScreen(IMAdInterstitial ad);

		/// <summary>
		/// Sent just after dismissing an interstitial and it has animated off the screen.
		/// </summary>
		/// <param name='ad'>
		/// The interstitial which was dismissed off the screen.
		/// </param>
		[Export("interstitialDidDismissScreen:")]
		void DidDismissScreen(IMAdInterstitial ad);

		/// <summary>
		/// Sent just before the application will background or terminate because the
		/// user clicked on an ad that will launch another application (such as the App
		/// Store).  The normal UIApplicationDelegate methods, like
		/// applicationDidEnterBackground:, will be called immediately before this.
		/// </summary>
		/// <param name='ad'>
		/// The interstitial which caused user to leave the application.
		/// </param>
		[Export("interstitialWillLeaveApplication:")]
		void WillLeaveApplication(IMAdInterstitial ad);
	}
}

