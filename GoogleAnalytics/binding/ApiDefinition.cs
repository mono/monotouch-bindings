using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GoogleAnalytics.iOS
{
	// Custom Class to export all the constants inside Google Analytics SDK
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GoogleAnalyticsExporter")]
	interface GAIConstants
	{
		[Static]
		[Export ("kGAIHitTypeGlobal")]
		NSString HitType { get; }

		[Static]
		[Export ("kGAITrackingIdGlobal")]
		NSString TrackingId { get; }

		[Static]
		[Export ("kGAIClientIdGlobal")]
		NSString ClientId { get; }

		[Static]
		[Export ("kGAIAnonymizeIpGlobal")]
		NSString AnonymizeIp { get; }

		[Static]
		[Export ("kGAISessionControlGlobal")]
		NSString SessionControl { get; }

		[Static]
		[Export ("kGAIScreenResolutionGlobal")]
		NSString ScreenResolution { get; }

		[Static]
		[Export ("kGAIViewportSizeGlobal")]
		NSString ViewportSize { get; }

		[Static]
		[Export ("kGAIEncodingGlobal")]
		NSString Encoding { get; }

		[Static]
		[Export ("kGAIScreenColorsGlobal")]
		NSString ScreenColors { get; }

		[Static]
		[Export ("kGAILanguageGlobal")]
		NSString Language { get; }

		[Static]
		[Export ("kGAIJavaEnabledGlobal")]
		NSString JavaEnabled { get; }

		[Static]
		[Export ("kGAIFlashVersionGlobal")]
		NSString FlashVersion { get; }

		[Static]
		[Export ("kGAINonInteractionGlobal")]
		NSString NonInteraction { get; }

		[Static]
		[Export ("kGAIReferrerGlobal")]
		NSString Referrer { get; }

		[Static]
		[Export ("kGAILocationGlobal")]
		NSString Location { get; }

		[Static]
		[Export ("kGAIHostnameGlobal")]
		NSString Hostname { get; }

		[Static]
		[Export ("kGAIPageGlobal")]
		NSString Page { get; }

		[Static]
		[Export ("kGAIDescriptionGlobal")] [New]
		NSString Description { get; }

		[Static]
		[Export ("kGAIScreenNameGlobal")]
		NSString ScreenName { get; }

		[Static]
		[Export ("kGAITitleGlobal")]
		NSString Title { get; }

		[Static]
		[Export ("kGAIAppNameGlobal")]
		NSString AppName { get; }

		[Static]
		[Export ("kGAIAppVersionGlobal")]
		NSString AppVersion { get; }

		[Static]
		[Export ("kGAIAppIdGlobal")]
		NSString AppId { get; }

		[Static]
		[Export ("kGAIAppInstallerIdGlobal")]
		NSString AppInstallerId { get; }

		[Static]
		[Export ("kGAIEventCategoryGlobal")]
		NSString EventCategory { get; }

		[Static]
		[Export ("kGAIEventActionGlobal")]
		NSString EventAction { get; }

		[Static]
		[Export ("kGAIEventLabelGlobal")]
		NSString EventLabel { get; }

		[Static]
		[Export ("kGAIEventValueGlobal")]
		NSString EventValue { get; }

		[Static]
		[Export ("kGAISocialNetworkGlobal")]
		NSString SocialNetwork { get; }

		[Static]
		[Export ("kGAISocialActionGlobal")]
		NSString SocialAction { get; }

		[Static]
		[Export ("kGAISocialTargetGlobal")]
		NSString SocialTarget { get; }

		[Static]
		[Export ("kGAITransactionIdGlobal")]
		NSString TransactionId { get; }

		[Static]
		[Export ("kGAITransactionAffiliationGlobal")]
		NSString TransactionAffiliation { get; }

		[Static]
		[Export ("kGAITransactionRevenueGlobal")]
		NSString TransactionRevenue { get; }

		[Static]
		[Export ("kGAITransactionShippingGlobal")]
		NSString TransactionShipping { get; }

		[Static]
		[Export ("kGAITransactionTaxGlobal")]
		NSString TransactionTax { get; }

		[Static]
		[Export ("kGAICurrencyCodeGlobal")]
		NSString CurrencyCode { get; }

		[Static]
		[Export ("kGAIItemPriceGlobal")]
		NSString ItemPrice { get; }

		[Static]
		[Export ("kGAIItemQuantityGlobal")]
		NSString ItemQuantity { get; }

		[Static]
		[Export ("kGAIItemSkuGlobal")]
		NSString ItemSku { get; }

		[Static]
		[Export ("kGAIItemNameGlobal")]
		NSString ItemName { get; }

		[Static]
		[Export ("kGAIItemCategoryGlobal")]
		NSString ItemCategory { get; }

		[Static]
		[Export ("kGAICampaignSourceGlobal")]
		NSString CampaignSource { get; }

		[Static]
		[Export ("kGAICampaignMediumGlobal")]
		NSString CampaignMedium { get; }

		[Static]
		[Export ("kGAICampaignNameGlobal")]
		NSString CampaignName { get; }

		[Static]
		[Export ("kGAICampaignKeywordGlobal")]
		NSString CampaignKeyword { get; }

		[Static]
		[Export ("kGAICampaignContentGlobal")]
		NSString CampaignContent { get; }

		[Static]
		[Export ("kGAICampaignIdGlobal")]
		NSString CampaignId { get; }

		[Static]
		[Export ("kGAITimingCategoryGlobal")]
		NSString TimingCategory { get; }

		[Static]
		[Export ("kGAITimingVarGlobal")]
		NSString TimingVar { get; }

		[Static]
		[Export ("kGAITimingValueGlobal")]
		NSString TimingValue { get; }

		[Static]
		[Export ("kGAITimingLabelGlobal")]
		NSString TimingLabel { get; }

		[Static]
		[Export ("kGAIExDescriptionGlobal")]
		NSString ExDescription { get; }

		[Static]
		[Export ("kGAIExFatalGlobal")]
		NSString ExFatal { get; }

		[Static]
		[Export ("kGAISampleRateGlobal")]
		NSString SampleRate { get; }

		[Static]
		[Export ("kGAIIdfaGlobal")]
		NSString Idfa { get; }

		[Static]
		[Export ("kGAIAdTargetingEnabledGlobal")]
		NSString AdTargetingEnabled { get; }

		[Static]
		[Export ("kGAIAppViewGlobal")]
		NSString AppView { get; }

		[Static]
		[Export ("kGAIEventGlobal")]
		NSString Event { get; }

		[Static]
		[Export ("kGAISocialGlobal")]
		NSString Social { get; }

		[Static]
		[Export ("kGAITransactionGlobal")]
		NSString Transaction { get; }

		[Static]
		[Export ("kGAIItemGlobal")]
		NSString Item { get; }

		[Static]
		[Export ("kGAIExceptionGlobal")]
		NSString Exception { get; }

		[Static]
		[Export ("kGAITimingGlobal")]
		NSString Timing { get; }
	}

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
		IGAITracker GetTracker (string name, string trackingId);

		[Export ("trackerWithTrackingId:")]
		IGAITracker GetTracker (string trackingId);

		[Export ("removeTrackerByName:")]
		void RemoveTracker (string name);

		[Export ("dispatch")]
		void Dispatch ();
	}

	[BaseType (typeof (NSObject))]
	interface GAIDictionaryBuilder
	{
		[Export ("set:forKey:")]
		GAIDictionaryBuilder Set ([NullAllowed] string value, [NullAllowed] string key);

		[Export ("setAll:")]
		GAIDictionaryBuilder SetAll ([NullAllowed] NSDictionary parameters);

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

	interface ITAGFunctionCallTagHandler { }

	[Protocol]
	[BaseType (typeof (NSObject))]
	interface TAGFunctionCallTagHandler
	{
		[Export ("execute:parameters:")]
		void Execute (string tagName, [NullAllowed] NSDictionary parameters);
	}

	interface ITAGFunctionCallMacroHandler { }

	[Protocol]
	[BaseType (typeof (NSObject))]
	interface TAGFunctionCallMacroHandler
	{
		[Export ("valueForMacro:parameters:")]
		NSObject ValueForMacro (string macroName, [NullAllowed] NSDictionary parameters);
	}

	interface ITAGContainerCallback { }

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject))]
	interface TAGContainerCallback
	{
		[Export ("containerRefreshBegin:refreshType:")]
		void RefreshBegin (TAGContainer container, TAGContainerCallbackRefreshType refreshType);

		[Export ("containerRefreshSuccess:refreshType:")]
		void RefreshSuccess (TAGContainer container, TAGContainerCallbackRefreshType refreshType);

		[Export ("containerRefreshFailure:failure:refreshType:")]
		void RefreshFailure (TAGContainer container, TAGContainerCallbackRefreshFailure failure, TAGContainerCallbackRefreshType refreshType);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	interface TAGContainer
	{
		[Export ("containerId", ArgumentSemantic.Copy)]
		string ContainerId { get; }

		[Export ("lastRefreshTime", ArgumentSemantic.Assign)]
		double LastRefreshTime { get; }

		[Export ("booleanForKey:")]
		bool BooleanForKey (string key);

		[Export ("doubleForKey:")]
		double DoubleForKey (string key);

		[Export ("int64ForKey:")]
		long Int64ForKey (string key);

		[Export ("stringForKey:")]
		string StringForKey (string key);

		[Export ("refresh")]
		void Refresh ();

		[Export ("close")]
		void Close ();

		[Export ("isDefault")]
		bool IsDefault { get; }

		[Export ("registerFunctionCallMacroHandler:forMacro:")]
		void RegisterFunctionCallMacroHandler ([NullAllowed] ITAGFunctionCallMacroHandler handler, string macroName);

		[Export ("functionCallMacroHandlerForMacro:")]
		ITAGFunctionCallMacroHandler FunctionCallMacroHandlerForMacro (string functionCallMacroName);

		[Export ("registerFunctionCallTagHandler:forTag:")]
		void RegisterFunctionCallTagHandler ([NullAllowed] ITAGFunctionCallTagHandler handler, string tagName);

		[Export ("functionCallTagHandlerForTag:")]
		ITAGFunctionCallTagHandler FunctionCallTagHandlerForTag (string functionCallTagName);
	}

	interface ITAGContainerFuture { }

	[Protocol]
	[BaseType (typeof (NSObject))]
	interface TAGContainerFuture
	{
		[Export ("get")]
		TAGContainer Get ();

		[Export ("isDone")]
		bool IsDone ();
	}

	interface ITAGContainerOpenerNotifier { }

	[Protocol]
	[BaseType (typeof (NSObject))]
	interface TAGContainerOpenerNotifier
	{
		[Export ("containerAvailable:")]
		void ContainerAvailable (TAGContainer container);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	interface TAGContainerOpener
	{
		[Static]
		[Export ("openContainerWithId:tagManager:openType:timeout:")]
		ITAGContainerFuture OpenContainer (string containerId, TAGManager tagManager, TAGOpenType openType, double timeout);

		[Static]
		[Export ("openContainerWithId:tagManager:openType:timeout:notifier:")]
		ITAGContainerFuture OpenContainer (string containerId, TAGManager tagManager, TAGOpenType openType, double timeout, [NullAllowed] ITAGContainerOpenerNotifier notifier);

		[Static]
		[Export ("defaultTimeout")]
		double DefaultTimeout { get; }
	}

	[BaseType (typeof (NSObject))]
	interface TAGDataLayer
	{
		[Export ("dataLayer", ArgumentSemantic.Copy)]
		NSDictionary DataLayer { get; }

		[Export ("pushValue:forKey:")]
		void PushValue (NSObject val, string key);

		[Export ("push:")]
		void Push (NSDictionary update);

		[Export ("get:")]
		NSObject Get (string key);
	}

	interface ITAGLogger { }

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject))]
	interface TAGLogger
	{
		[Abstract]
		[Export ("error:")]
		void Error (string message);

		[Abstract]
		[Export ("warning:")]
		void Warning (string message);

		[Abstract]
		[Export ("info:")]
		void Info (string message);

		[Abstract]
		[Export ("debug:")]
		void Debug (string message);

		[Abstract]
		[Export ("verbose:")]
		void Verbose (string message);

		[Abstract]
		[Export ("logLevel")]
		TAGLoggerLogLevelType LogLevel { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface TAGManager
	{
		[Export ("logger", ArgumentSemantic.Retain)] [NullAllowed]
		ITAGLogger Logger { get; set; }

		[Export ("refreshMode", ArgumentSemantic.Assign)]
		TAGRefreshMode RefreshMode { get; set; }

		[Export ("dataLayer", ArgumentSemantic.Retain)]
		TAGDataLayer DataLayer { get; }

		[Export ("openContainerById:callback:")]
		TAGContainer OpenContainer (string containerId, ITAGContainerCallback callback);

		[Export ("getContainerById:")]
		TAGContainer GetContainer (string containerId);

		[Export ("previewWithUrl:")]
		bool Preview (NSUrl url);

		[Static]
		[Export ("instance")]
		TAGManager GetInstance { get; }
	}
}

