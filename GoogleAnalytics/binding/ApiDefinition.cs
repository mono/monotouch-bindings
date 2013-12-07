using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GoogleAnalytics.iOS
{
	[BaseType (typeof (NSObject))]
	interface GAI
	{
		[Field ("GAIProduct", "__Internal")]
		NSString Product { get; }

		[Field ("GAIVersion", "__Internal")]
		NSString Version { get; }

		[Field ("GAIErrorDomain", "__Internal")]
		NSString GAIErrorDomain { get; }

		[Export ("defaultTracker", ArgumentSemantic.Assign)] [NullAllowed]
		IGAITracker DefaultTracker { get; set; }

		[Export ("logger", ArgumentSemantic.Retain)] [NullAllowed]
		IGAILogger Logger { get; set; }

		[Export ("optOut", ArgumentSemantic.Assign)]
		bool OptOut { get; set; }

		[Export ("dispatchInterval", ArgumentSemantic.Assign)]
		double DispatchInterval { get; set; }

		[Export ("trackUncaughtExceptions", ArgumentSemantic.Assign)]
		bool TrackUncaughtExceptions { get; set; }

		[Export ("dryRun", ArgumentSemantic.Assign)]
		bool DryRun { get; set; }

		[Static]
		[Export ("sharedInstance")]
		GAI SharedInstance { get; }

		[Export ("trackerWithName:trackingId:")]
		IGAITracker Tracker (string name, string trackingId);

		[Export ("trackerWithTrackingId:")]
		IGAITracker Tracker (string trackingId);

		[Export ("removeTrackerByName:")]
		void RemoveTracker (string name);

		[Export ("dispatch")]
		void Dispatch ();
	}

	[BaseType (typeof (NSObject))]
	interface GAIDictionaryBuilder
	{
		[Export ("set:forKey:")]
		GAIDictionaryBuilder Set (string value, string key);

		[Export ("setAll:")]
		GAIDictionaryBuilder SetAll (NSDictionary parameters);

		[Export ("get:")]
		string Get ([NullAllowed] string paramName);

		[Export ("build")]
		NSMutableDictionary Build ();

		[Export ("setCampaignParametersFromUrl:")]
		GAIDictionaryBuilder SetCampaignParameters (string urlString);

		[Static]
		[Export ("createAppView")]
		GAIDictionaryBuilder CreateAppView ();

		[Static]
		[Export ("createEventWithCategory:action:label:value:")]
		GAIDictionaryBuilder CreateEvent ([NullAllowed] string category, [NullAllowed] string action, [NullAllowed] string label, [NullAllowed] NSNumber number);

		[Static]
		[Export ("createExceptionWithDescription:withFatal:")]
		GAIDictionaryBuilder CreateException ([NullAllowed] string description, [NullAllowed] NSNumber fatal);

		[Static]
		[Export ("createItemWithTransactionId:name:sku:category:price:quantity:currencyCode:")]
		GAIDictionaryBuilder CreateItem ([NullAllowed] string transactionId, [NullAllowed] string name, [NullAllowed] string sku, [NullAllowed] string category, [NullAllowed] NSNumber price, [NullAllowed] NSNumber quantity, [NullAllowed] string currencyCode);

		[Static]
		[Export ("createSocialWithNetwork:action:target:")]
		GAIDictionaryBuilder CreateSocial ([NullAllowed] string network, [NullAllowed] string action, [NullAllowed] string target);

		[Static]
		[Export ("createTimingWithCategory:interval:name:label:")]
		GAIDictionaryBuilder CreateTiming ([NullAllowed] string category, [NullAllowed] NSNumber intervalMillis, [NullAllowed] string name, [NullAllowed] string label);

		[Static]
		[Export ("createTransactionWithId:affiliation:revenue:tax:shipping:currencyCode:")]
		GAIDictionaryBuilder CreateTransaction ([NullAllowed] string transactionId, [NullAllowed] string affiliation, [NullAllowed] NSNumber revenue, [NullAllowed] NSNumber tax, [NullAllowed] NSNumber shipping, [NullAllowed] string currencyCode);
	}

	[BaseType (typeof (NSObject))]
	interface GAIFields
	{
		[Static]
		[Export ("contentGroupForIndex:")]
		string ContentGroup (uint index);

		[Static]
		[Export ("customDimensionForIndex:")]
		string CustomDimension (uint index);

		[Static]
		[Export ("customMetricForIndex:")]
		string CustomMetric (uint index);

		[Field ("GAITitle", "__Internal")]
		NSString Title { get; }

		[Field ("GAIAppName", "__Internal")]
		NSString AppName { get; }

		[Field ("GAIAppVersion", "__Internal")]
		NSString AppVersion { get; }

		[Field ("GAIAppId", "__Internal")]
		NSString AppId { get; }

		[Field ("GAIAppInstallerId", "__Internal")]
		NSString AppInstallerId { get; }

		[Field ("GAIEventCategory", "__Internal")]
		NSString EventCategory { get; }

		[Field ("GAIEventAction", "__Internal")]
		NSString EventAction { get; }

		[Field ("GAIEventLabel", "__Internal")]
		NSString EventLabel { get; }

		[Field ("GAIEventValue", "__Internal")]
		NSString EventValue { get; }

		[Field ("GAISocialNetwork", "__Internal")]
		NSString SocialNetwork { get; }

		[Field ("GAISocialAction", "__Internal")]
		NSString SocialAction { get; }

		[Field ("GAISocialTarget", "__Internal")]
		NSString SocialTarget { get; }

		[Field ("GAITransactionId", "__Internal")]
		NSString TransactionId { get; }

		[Field ("GAITransactionAffiliation", "__Internal")]
		NSString TransactionAffiliation { get; }

		[Field ("GAITransactionRevenue", "__Internal")]
		NSString TransactionRevenue { get; }

		[Field ("GAITransactionShipping", "__Internal")]
		NSString TransactionShipping { get; }

		[Field ("GAITransactionTax", "__Internal")]
		NSString TransactionTax { get; }

		[Field ("GAICurrencyCode", "__Internal")]
		NSString CurrencyCode { get; }

		[Field ("GAIItemPrice", "__Internal")]
		NSString ItemPrice { get; }

		[Field ("GAIItemQuantity", "__Internal")]
		NSString ItemQuantity { get; }

		[Field ("GAIItemSku", "__Internal")]
		NSString ItemSku { get; }

		[Field ("GAIItemName", "__Internal")]
		NSString ItemName { get; }

		[Field ("GAIItemCategory", "__Internal")]
		NSString ItemCategory { get; }

		[Field ("GAICampaignSource", "__Internal")]
		NSString CampaignSource { get; }

		[Field ("GAICampaignMedium", "__Internal")]
		NSString CampaignMedium { get; }

		[Field ("GAICampaignName", "__Internal")]
		NSString CampaignName { get; }

		[Field ("GAICampaignKeyword", "__Internal")]
		NSString CampaignKeyword { get; }

		[Field ("GAICampaignContent", "__Internal")]
		NSString CampaignContent { get; }

		[Field ("GAICampaignId", "__Internal")]
		NSString CampaignId { get; }

		[Field ("GAITimingCategory", "__Internal")]
		NSString TimingCategory { get; }

		[Field ("GAITimingVar", "__Internal")]
		NSString TimingVar { get; }

		[Field ("GAITimingValue", "__Internal")]
		NSString TimingValue { get; }

		[Field ("GAITimingLabel", "__Internal")]
		NSString TimingLabel { get; }

		[Field ("GAIExDescription", "__Internal")]
		NSString ExDescription { get; }

		[Field ("GAIExFatal", "__Internal")]
		NSString ExFatal { get; }

		[Field ("GAISampleRate", "__Internal")]
		NSString SampleRate { get; }

		[Field ("GAIAppView", "__Internal")]
		NSString AppView { get; }

		[Field ("GAIEvent", "__Internal")]
		NSString Event { get; }

		[Field ("GAISocial", "__Internal")]
		NSString Social { get; }

		[Field ("GAITransaction", "__Internal")]
		NSString Transaction { get; }

		[Field ("GAIItem", "__Internal")]
		NSString Item { get; }

		[Field ("GAIException", "__Internal")]
		NSString Exception { get; }

		[Field ("GAITiming", "__Internal")]
		NSString Timing { get; }
	}

	interface IGAILogger { }

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject))]
	interface GAILogger
	{
		[Abstract]
		[Export ("logLevel", ArgumentSemantic.Assign)]
		GAILogLevel LogLevel { get; set; }

		[Abstract]
		[Export ("verbose:")]
		void Verbose (string message);

		[Abstract]
		[Export ("info:")]
		void Info (string message);

		[Abstract]
		[Export ("warning:")]
		void Warning (string message);

		[Abstract]
		[Export ("error:")]
		void Error (string message);
	}

	[BaseType (typeof (UIViewController))]
	interface GAITrackedViewController
	{
		[Export ("tracker", ArgumentSemantic.Assign)] [NullAllowed]
		IGAITracker Tracker { get; set; }

		[Export ("screenName", ArgumentSemantic.Copy)] [NullAllowed]
		string ScreenName { get; set; }
	}

	interface IGAITracker { }

	[Protocol]
	[BaseType (typeof (NSObject))]
	interface GAITracker
	{
		[Export ("name")]
		string GetName ();

		[Export ("set:value:")]
		void Set (string parameterName, [NullAllowed] string value);

		[Export ("get:")]
		string Get ([NullAllowed] string parameterName);

		[Export ("send:")]
		void Send ([NullAllowed] NSDictionary parameters);
	}
}

