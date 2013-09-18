using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;
 
namespace GoogleAnalytics {

	public enum GAILogLevel : uint {
		None = 0,
		Error = 1,
		Warning = 2,
		Info = 3,
		Verbose = 4
	}

	[BaseType (typeof (NSObject))]
	public partial interface GAILogger {

		[Export ("logLevel")]
		GAILogLevel LogLevel { get; set; }

		[Export ("verbose:")]
		void Verbose (string message);

		[Export ("info:")]
		void Info (string message);

		[Export ("warning:")]
		void Warning (string message);

		[Export ("error:")]
		void Error (string message);
	}

	[BaseType (typeof (NSObject))]
	public partial interface GAITracker {

		[Export ("name")]
		string Name { get; }

		[Export ("set:value:")]
		void Set (string parameterName, string value);

		[Export ("get:")]
		string Get (string parameterName);

		[Export ("send:")]
		void Send (NSDictionary parameters);
	}

	[BaseType (typeof (UIViewController))]
	public partial interface GAITrackedViewController {


		[Export ("tracker", ArgumentSemantic.Assign)]
		GAITracker Tracker { get; set; }

		[Export ("screenName", ArgumentSemantic.Copy)]
		string ScreenName { get; set; }

		[Field ("kGAIProduct", "__Internal")]
		NSString GAIProduct { get; }

		[Field ("kGAIVersion", "__Internal")]
		NSString GAIVersion { get; }

		[Field ("kGAIErrorDomain", "__Internal")]
		NSString GAIErrorDomain { get; }
	}


	[BaseType (typeof (NSObject))]
	public partial interface GAI {

		[Export ("defaultTracker", ArgumentSemantic.Assign)]
		GAITracker DefaultTracker { get; set; }

		[Export ("logger", ArgumentSemantic.Retain)]
		GAILogger Logger { get; set; }

		[Export ("optOut")]
		bool OptOut { get; set; }

		[Export ("dispatchInterval")]
		double DispatchInterval { get; set; }

		[Export ("trackUncaughtExceptions")]
		bool TrackUncaughtExceptions { get; set; }

		[Export ("dryRun")]
		bool DryRun { get; set; }

		[Static, Export ("sharedInstance")]
		GAI SharedInstance { get; }

		[Export ("trackerWithName:trackingId:")]
		GAITracker TrackerWithName (string name, string trackingId);

		[Export ("trackerWithTrackingId:")]
		IntPtr TrackerWithTrackingId (string trackingId);

		[Export ("removeTrackerByName:")]
		void RemoveTrackerByName (string name);

		[Export ("dispatch")]
		void Dispatch ();
	}

	[BaseType (typeof (NSObject))]
	public partial interface GAIDictionaryBuilder {

		[Export ("set:forKey:")]
		GAIDictionaryBuilder Set (string value, string key);

		[Export ("setAll:")]
		GAIDictionaryBuilder SetAll (NSDictionary param);

		[Export ("get:")]
		string Get (string paramName);

		[Export ("build")]
		NSMutableDictionary Build { get; }

		[Export ("setCampaignParametersFromUrl:")]
		GAIDictionaryBuilder SetCampaignParametersFromUrl (string urlString);

		[Static, Export ("createAppView")]
		GAIDictionaryBuilder CreateAppView { get; }

		[Static, Export ("createEventWithCategory:action:label:value:")]
		GAIDictionaryBuilder CreateEventWithCategory (string category, string action, string label, NSNumber value);

		[Static, Export ("createExceptionWithDescription:withFatal:")]
		GAIDictionaryBuilder CreateExceptionWithDescription (string description, NSNumber fatal);

		[Static, Export ("createItemWithTransactionId:name:sku:category:price:quantity:currencyCode:")]
		GAIDictionaryBuilder CreateItemWithTransactionId (string transactionId, string name, string sku, string category, NSNumber price, NSNumber quantity, string currencyCode);

		[Static, Export ("createSocialWithNetwork:action:target:")]
		GAIDictionaryBuilder CreateSocialWithNetwork (string network, string action, string target);

		[Static, Export ("createTimingWithCategory:interval:name:label:")]
		GAIDictionaryBuilder CreateTimingWithCategory (string category, NSNumber intervalMillis, string name, string label);

		[Static, Export ("createTransactionWithId:affiliation:revenue:tax:shipping:currencyCode:")]
		GAIDictionaryBuilder CreateTransactionWithId (string transactionId, string affiliation, NSNumber revenue, NSNumber tax, NSNumber shipping, string currencyCode);

		[Field ("kGAIUseSecure", "__Internal")]
		NSString GAIUseSecure { get; }

		[Field ("kGAIHitType", "__Internal")]
		NSString GAIHitType { get; }

		[Field ("kGAITrackingId", "__Internal")]
		NSString GAITrackingId { get; }

		[Field ("kGAIClientId", "__Internal")]
		NSString GAIClientId { get; }

		[Field ("kGAIAnonymizeIp", "__Internal")]
		NSString GAIAnonymizeIp { get; }

		[Field ("kGAISessionControl", "__Internal")]
		NSString GAISessionControl { get; }

		[Field ("kGAIScreenResolution", "__Internal")]
		NSString GAIScreenResolution { get; }

		[Field ("kGAIViewportSize", "__Internal")]
		NSString GAIViewportSize { get; }

		[Field ("kGAIEncoding", "__Internal")]
		NSString GAIEncoding { get; }

		[Field ("kGAIScreenColors", "__Internal")]
		NSString GAIScreenColors { get; }

		[Field ("kGAILanguage", "__Internal")]
		NSString GAILanguage { get; }

		[Field ("kGAIJavaEnabled", "__Internal")]
		NSString GAIJavaEnabled { get; }

		[Field ("kGAIFlashVersion", "__Internal")]
		NSString GAIFlashVersion { get; }

		[Field ("kGAINonInteraction", "__Internal")]
		NSString GAINonInteraction { get; }

		[Field ("kGAIReferrer", "__Internal")]
		NSString GAIReferrer { get; }

		[Field ("kGAILocation", "__Internal")]
		NSString GAILocation { get; }

		[Field ("kGAIHostname", "__Internal")]
		NSString GAIHostname { get; }

		[Field ("kGAIPage", "__Internal")]
		NSString GAIPage { get; }

		[Field ("kGAIDescription", "__Internal")]
		NSString GAIDescription { get; }

		[Field ("kGAIScreenName", "__Internal")]
		NSString GAIScreenName { get; }

		[Field ("kGAITitle", "__Internal")]
		NSString GAITitle { get; }

		[Field ("kGAIAppName", "__Internal")]
		NSString GAIAppName { get; }

		[Field ("kGAIAppVersion", "__Internal")]
		NSString GAIAppVersion { get; }

		[Field ("kGAIAppId", "__Internal")]
		NSString GAIAppId { get; }

		[Field ("kGAIAppInstallerId", "__Internal")]
		NSString GAIAppInstallerId { get; }

		[Field ("kGAIEventCategory", "__Internal")]
		NSString GAIEventCategory { get; }

		[Field ("kGAIEventAction", "__Internal")]
		NSString GAIEventAction { get; }

		[Field ("kGAIEventLabel", "__Internal")]
		NSString GAIEventLabel { get; }

		[Field ("kGAIEventValue", "__Internal")]
		NSString GAIEventValue { get; }

		[Field ("kGAISocialNetwork", "__Internal")]
		NSString GAISocialNetwork { get; }

		[Field ("kGAISocialAction", "__Internal")]
		NSString GAISocialAction { get; }

		[Field ("kGAISocialTarget", "__Internal")]
		NSString GAISocialTarget { get; }

		[Field ("kGAITransactionId", "__Internal")]
		NSString GAITransactionId { get; }

		[Field ("kGAITransactionAffiliation", "__Internal")]
		NSString GAITransactionAffiliation { get; }

		[Field ("kGAITransactionRevenue", "__Internal")]
		NSString GAITransactionRevenue { get; }

		[Field ("kGAITransactionShipping", "__Internal")]
		NSString GAITransactionShipping { get; }

		[Field ("kGAITransactionTax", "__Internal")]
		NSString GAITransactionTax { get; }

		[Field ("kGAICurrencyCode", "__Internal")]
		NSString GAICurrencyCode { get; }

		[Field ("kGAIItemPrice", "__Internal")]
		NSString GAIItemPrice { get; }

		[Field ("kGAIItemQuantity", "__Internal")]
		NSString GAIItemQuantity { get; }

		[Field ("kGAIItemSku", "__Internal")]
		NSString GAIItemSku { get; }

		[Field ("kGAIItemName", "__Internal")]
		NSString GAIItemName { get; }

		[Field ("kGAIItemCategory", "__Internal")]
		NSString GAIItemCategory { get; }

		[Field ("kGAICampaignSource", "__Internal")]
		NSString GAICampaignSource { get; }

		[Field ("kGAICampaignMedium", "__Internal")]
		NSString GAICampaignMedium { get; }

		[Field ("kGAICampaignName", "__Internal")]
		NSString GAICampaignName { get; }

		[Field ("kGAICampaignKeyword", "__Internal")]
		NSString GAICampaignKeyword { get; }

		[Field ("kGAICampaignContent", "__Internal")]
		NSString GAICampaignContent { get; }

		[Field ("kGAICampaignId", "__Internal")]
		NSString GAICampaignId { get; }

		[Field ("kGAITimingCategory", "__Internal")]
		NSString GAITimingCategory { get; }

		[Field ("kGAITimingVar", "__Internal")]
		NSString GAITimingVar { get; }

		[Field ("kGAITimingValue", "__Internal")]
		NSString GAITimingValue { get; }

		[Field ("kGAITimingLabel", "__Internal")]
		NSString GAITimingLabel { get; }

		[Field ("kGAIExDescription", "__Internal")]
		NSString GAIExDescription { get; }

		[Field ("kGAIExFatal", "__Internal")]
		NSString GAIExFatal { get; }

		[Field ("kGAISampleRate", "__Internal")]
		NSString GAISampleRate { get; }

		[Field ("kGAIAppView", "__Internal")]
		NSString GAIAppView { get; }

		[Field ("kGAIEvent", "__Internal")]
		NSString GAIEvent { get; }

		[Field ("kGAISocial", "__Internal")]
		NSString GAISocial { get; }

		[Field ("kGAITransaction", "__Internal")]
		NSString GAITransaction { get; }

		[Field ("kGAIItem", "__Internal")]
		NSString GAIItem { get; }

		[Field ("kGAIException", "__Internal")]
		NSString GAIException { get; }

		[Field ("kGAITiming", "__Internal")]
		NSString GAITiming { get; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface GAIFields {

		[Static, Export ("contentGroupForIndex:")]
		string ContentGroupForIndex (uint index);

		[Static, Export ("customDimensionForIndex:")]
		string CustomDimensionForIndex (uint index);

		[Static, Export ("customMetricForIndex:")]
		string CustomMetricForIndex (uint index);
	}

}
