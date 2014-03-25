//
// ApiDefinition.cs: Bindings to the Facebook iOS SDK.
//
//	Authors:
//		Miguel de Icaza (miguel@xamarin.com)
//		Alex Soto (alex.soto@xamarin.com)
//
//

using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using MonoTouch.Accounts;

namespace MonoTouch.FacebookConnect
{
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	interface FBAccessTokenData
	{
		[Static, Export ("createTokenFromFacebookURL:appID:urlSchemeSuffix:")]
		FBAccessTokenData CreateToken (NSUrl url, string appId, string urlSchemeSuffix);

		[Static, Export ("createTokenFromDictionary:")]
		FBAccessTokenData CreateToken (NSDictionary dictionary);

		[Static, Export ("createTokenFromString:permissions:expirationDate:loginType:refreshDate:")]
		FBAccessTokenData CreateToken (string accessToken, [NullAllowed] string [] permissions, [NullAllowed] NSDate expirationDate, FBSessionLoginType loginType, [NullAllowed] NSDate refreshDate);

		[Static, Export ("createTokenFromString:permissions:expirationDate:loginType:refreshDate:permissionsRefreshDate:")]
		FBAccessTokenData CreateToken (string accessToken, [NullAllowed] string [] permissions, [NullAllowed] NSDate expirationDate, FBSessionLoginType loginType, [NullAllowed] NSDate refreshDate, [NullAllowed] NSDate permissionsRefreshDate);

		[Export ("dictionary")]
		NSMutableDictionary Dictionary { get; }

		[Export ("isEqualToAccessTokenData:")]
		bool IsEqualToAccessTokenData (FBAccessTokenData accessTokenData);

		[Export ("accessToken", ArgumentSemantic.Copy)]
		string AccessToken { get; }

		[Export ("permissions", ArgumentSemantic.Copy)]
		string [] Permissions { get; }

		[Export ("expirationDate", ArgumentSemantic.Copy)]
		NSDate ExpirationDate { get; }

		[Export ("loginType")]
		FBSessionLoginType LoginType { get; }

		[Export ("refreshDate", ArgumentSemantic.Copy)]
		NSDate RefreshDate { get; }

		[Export ("permissionsRefreshDate", ArgumentSemantic.Copy)]
		NSDate PermissionsRefreshDate { get; }
	}

	delegate void FBAppCallHandler (FBAppCall call);
	delegate void FBAppLinkFallbackHandler (NSError error);

	[BaseType (typeof (NSObject))]
	interface FBAppCall 
	{
		[Export ("ID")]
		string Id { get; }

		[Export ("error")]
		NSError Error { get; }

		[Export ("dialogData")]
		FBDialogsData DialogData { get; }

		[Export ("appLinkData")]
		FBAppLinkData AppLinkData { get; }

		[Export ("accessTokenData")]
		FBAccessTokenData AccessTokenData { get; }

		[Static]
		[Export ("appCallFromURL:")]
		FBAppCall GetAppCallFromUrl (NSUrl url);

		[Export ("isEqualToAppCall:")]
		bool IsEqualToAppCall (FBAppCall appCall);

		[Static, Export ("handleOpenURL:sourceApplication:")]
		bool HandleOpenURL (NSUrl url, string sourceApplication);

		[Static, Export ("handleOpenURL:sourceApplication:fallbackHandler:")]
		bool HandleOpenURL (NSUrl url, string sourceApplication, [NullAllowed] FBAppCallHandler handler);

		[Static, Export ("handleOpenURL:sourceApplication:withSession:")]
		bool HandleOpenURL (NSUrl url, string sourceApplication, [NullAllowed] FBSession session);

		[Static, Export ("handleOpenURL:sourceApplication:withSession:fallbackHandler:")]
		bool HandleOpenURL (NSUrl url, string sourceApplication, [NullAllowed] FBSession session, [NullAllowed] FBAppCallHandler handler);

		[Static, Export ("handleDidBecomeActive")]
		void HandleDidBecomeActive ();

		[Static, Export ("handleDidBecomeActiveWithSession:")]
		void HandleDidBecomeActive ([NullAllowed] FBSession session);

		[Static, Export ("openDeferredAppLink:")]
		void OpenDeferredAppLink ([NullAllowed] FBAppLinkFallbackHandler fallbackHandler);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	interface FBAppEvents 
	{
		[Field ("FBAppEventsLoggingResultNotification", "__Internal")]
		[Notification]
		NSString LoggingResultNotification { get; }

		// Predefined event names for logging events common to many apps.
		// Logging occurs through the `LogEvent` family of methods on `FBAppEvents`.

		[Field ("FBAppEventNameActivatedApp", "__Internal")]
		NSString ActivatedAppEvent { get; }

		[Field ("FBAppEventNameCompletedRegistration", "__Internal")]
		NSString CompletedRegistrationEvent { get; }

		[Field ("FBAppEventNameViewedContent", "__Internal")]
		NSString ViewedContentEvent { get; }

		[Field ("FBAppEventNameSearched", "__Internal")]
		NSString SearchedEvent { get; }

		[Field ("FBAppEventNameRated", "__Internal")]
		NSString NameRatedEvent { get; }

		[Field ("FBAppEventNameCompletedTutorial", "__Internal")]
		NSString CompletedTutorialEvent { get; }

		[Field ("FBAppEventNameAddedToCart", "__Internal")]
		NSString AddedToCartEvent { get; }

		[Field ("FBAppEventNameAddedToWishlist", "__Internal")]
		NSString AddedToWishlistEvent { get; }

		[Field ("FBAppEventNameInitiatedCheckout", "__Internal")]
		NSString InitiatedCheckoutEvent { get; }

		[Field ("FBAppEventNameAddedPaymentInfo", "__Internal")]
		NSString AddedPaymentInfoEvent { get; }

		[Field ("FBAppEventNamePurchased", "__Internal")]
		NSString PurchasedEvent { get; }

		[Field ("FBAppEventNameAchievedLevel", "__Internal")]
		NSString AchievedLevelEvent { get; }

		[Field ("FBAppEventNameUnlockedAchievement", "__Internal")]
		NSString UnlockedAchievementEvent { get; }

		[Field ("FBAppEventNameSpentCredits", "__Internal")]
		NSString SpentCreditsEvent { get; }

		// Predefined parameters keys for common additional information
		// to accompany events logged through the `LogEvent` family of methods on `FBAppEvents`

		[Field ("FBAppEventParameterNameCurrency", "__Internal")]
		NSString CurrencyParamKey { get; }

		[Field ("FBAppEventParameterNameRegistrationMethod", "__Internal")]
		NSString RegistrationMethodParamKey { get; }

		[Field ("FBAppEventParameterNameContentType", "__Internal")]
		NSString ContentTypeParamKey { get; }

		[Field ("FBAppEventParameterNameContentID", "__Internal")]
		NSString ContentIDParamKey { get; }

		[Field ("FBAppEventParameterNameSearchString", "__Internal")]
		NSString SearchStringParamKey { get; }

		[Field ("FBAppEventParameterNameSuccess", "__Internal")]
		NSString SuccessParamKey { get; }

		[Field ("FBAppEventParameterNameMaxRatingValue", "__Internal")]
		NSString MaxRatingValueParamKey { get; }

		[Field ("FBAppEventParameterNamePaymentInfoAvailable", "__Internal")]
		NSString PaymentInfoAvailableParamKey { get; }

		[Field ("FBAppEventParameterNameNumItems", "__Internal")]
		NSString NumItemsParamKey { get; }

		[Field ("FBAppEventParameterNameLevel", "__Internal")]
		NSString LevelParamKey { get; }

		[Field ("FBAppEventParameterNameDescription", "__Internal")]
		NSString DescriptionParamKey { get; }

		[Field ("FBAppEventParameterValueYes", "__Internal")]
		NSString YesValueParamKey { get; }

		[Field ("FBAppEventParameterValueNo", "__Internal")]
		NSString NoValueParamKey { get; }

		// Class Implementation
		// TODO: Enhance the usage of this class by C#'ifiying it.

		[Static]
		[Export ("logEvent:")]
		void LogEvent (NSString eventName);

		[Static]
		[Export ("logEvent:valueToSum:")]
		void LogEvent (NSString eventName, double valueToSum);

		[Static]
		[Export ("logEvent:parameters:")]
		void LogEvent (NSString eventName, NSDictionary parameters);

		[Static]
		[Export ("logEvent:valueToSum:parameters:")]
		void LogEvent (NSString eventName, double valueToSum, NSDictionary parameters);

		[Static]
		[Export ("logEvent:valueToSum:parameters:session:")]
		void LogEvent (NSString eventName, double valueToSum, NSDictionary parameters, FBSession session);

		[Static]
		[Export ("logPurchase:currency:")]
		void LogPurchase (double purchaseAmount, string currency);

		[Static]
		[Export ("logPurchase:currency:parameters:")]
		void LogPurchase (double purchaseAmount, string currency, NSDictionary parameters);

		[Static]
		[Export ("logPurchase:currency:parameters:session:")]
		void LogPurchase (double purchaseAmount, string currency, NSDictionary parameters, FBSession session);

		[Obsolete ("use FBSettings.LimitEventAndDataUsage instead")]
		[Static]
		[Export ("limitEventUsage")]
		bool LimitEventUsage { get; set; }

		[Static]
		[Export ("activateApp")]
		void ActivateApp ();

		[Static]
		[Export ("flushBehavior")]
		FBAppEventsFlushBehavior FlushBehavior { get; set; }

		[Static]
		[Export ("flush")]
		void Flush ();
	}

	[BaseType (typeof (NSObject))]
	interface FBAppLinkData 
	{
		[Export ("targetURL")]
		NSUrl TargetUrl { get; }

		[Export ("actionTypes")]
		string [] ActionTypes { get; }

		[Export ("actionIDs")]
		string [] ActionIDs { get; }

		[Export ("ref")]
		string Ref { get; }

		[Export ("userAgent")]
		string UserAgent { get; }

		[Export ("refererData")]
		NSDictionary RefererData { get; }

		[Export ("originalQueryParameters")]
		NSDictionary OriginalQueryParameters { get; }

		[Export ("originalURL")]
		NSUrl OriginalURL { get; }

		[Export ("arguments")]
		NSDictionary Arguments { get; }
	}

	[BaseType (typeof (NSObject))]
	interface FBCacheDescriptor 
	{
		[Export ("prefetchAndCacheForSession:")]
		void PrefetchAndCacheForSession (FBSession session);
	}

	delegate void FBOSIntegratedShareDialogHandler (FBOSIntegratedShareDialogResult result, NSError error);
	delegate void FBDialogAppCallCompletionHandler (FBAppCall call, NSDictionary results, NSError error);

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	interface FBDialogs 
	{
		[Async, Static, Export("presentOSIntegratedShareDialogModallyFrom:initialText:image:url:handler:")]
		bool PresentOSIntegratedShareDialogModally (UIViewController viewController, [NullAllowed] string initialText, [NullAllowed] UIImage image, [NullAllowed] NSUrl url, [NullAllowed] FBOSIntegratedShareDialogHandler handler);

		[Async, Static, Export("presentOSIntegratedShareDialogModallyFrom:initialText:images:urls:handler:")]
		bool PresentOSIntegratedShareDialogModally (UIViewController viewController, [NullAllowed] string initialText, [NullAllowed] UIImage [] images, [NullAllowed] NSUrl [] urls, [NullAllowed] FBOSIntegratedShareDialogHandler handler);

		[Async, Static, Export("presentOSIntegratedShareDialogModallyFrom:session:initialText:images:urls:handler:")]
		bool PresentOSIntegratedShareDialogModally (UIViewController viewController, [NullAllowed] FBSession session, [NullAllowed] string initialText, [NullAllowed] UIImage [] images, [NullAllowed] NSUrl [] urls, [NullAllowed] FBOSIntegratedShareDialogHandler handler);

		[Static, Export ("canPresentOSIntegratedShareDialogWithSession:")]
		bool CanPresentOSIntegratedShareDialog ([NullAllowed] FBSession session);

		[Static, Export ("canPresentShareDialogWithParams:")]
		bool CanPresentShareDialog (FBShareDialogParams aParams);
		
		[Static, Export ("canPresentShareDialogWithPhotos")]
		bool CanPresentShareDialog ();

		[Async (ResultTypeName = "FBDialogAppCallResult")]
		[Static, Export ("presentShareDialogWithParams:clientState:handler:")]
		FBAppCall PresentShareDialog (FBShareDialogParams aParams, [NullAllowed] NSDictionary clientState, [NullAllowed] FBDialogAppCallCompletionHandler handler);

		[Async (ResultTypeName = "FBDialogAppCallResult")]
		[Static, Export ("presentShareDialogWithPhotoParams:clientState:handler:")]
		FBAppCall PresentShareDialog ([NullAllowed] FBShareDialogPhotoParams aParams, [NullAllowed] NSDictionary clientState, [NullAllowed] FBDialogAppCallCompletionHandler handler);

		[Async (ResultTypeName = "FBDialogAppCallResult")]
		[Static, Export ("presentShareDialogWithLink:handler:")]
		FBAppCall PresentShareDialog ([NullAllowed] NSUrl link, [NullAllowed] FBDialogAppCallCompletionHandler handler);

		[Async (ResultTypeName = "FBDialogAppCallResult")]
		[Static, Export ("presentShareDialogWithLink:name:handler:")]
		FBAppCall PresentShareDialog ([NullAllowed] NSUrl link, [NullAllowed] string name, [NullAllowed] FBDialogAppCallCompletionHandler handler);

		[Async (ResultTypeName = "FBDialogAppCallResult")]
		[Static, Export ("presentShareDialogWithLink:name:caption:description:picture:clientState:handler:")]
		FBAppCall PresentShareDialog ([NullAllowed] NSUrl link, [NullAllowed] string name, [NullAllowed] string caption, [NullAllowed] string description, [NullAllowed] NSUrl picture, [NullAllowed] NSDictionary clientState, [NullAllowed] FBDialogAppCallCompletionHandler handler);

		[Async (ResultTypeName = "FBDialogAppCallResult")]
		[Static, Export ("presentShareDialogWithPhotos:handler:")]
		FBAppCall PresentShareDialog ([NullAllowed] UIImage [] photos, [NullAllowed] FBDialogAppCallCompletionHandler handler);
		
		[Async (ResultTypeName = "FBDialogAppCallResult")]
		[Static, Export ("presentShareDialogWithPhotos:clientState:handler:")]
		FBAppCall PresentShareDialog ([NullAllowed] UIImage [] photos, [NullAllowed] NSDictionary clientState, [NullAllowed] FBDialogAppCallCompletionHandler handler);
		
		[Static, Export ("canPresentShareDialogWithOpenGraphActionParams:")]
		bool CanPresentShareDialog (FBOpenGraphActionShareDialogParams aParams);

		[Async (ResultTypeName = "FBDialogAppCallResult")]
		[Static, Export ("presentShareDialogWithOpenGraphActionParams:clientState:handler:")]
		FBAppCall PresentShareDialog (FBOpenGraphActionShareDialogParams aParams, [NullAllowed] NSDictionary clientState, [NullAllowed] FBDialogAppCallCompletionHandler handler);

		[Async (ResultTypeName = "FBDialogAppCallResult")]
		[Static, Export ("presentShareDialogWithOpenGraphAction:actionType:previewPropertyName:handler:")]
		FBAppCall PresentShareDialog (IFBOpenGraphAction action, [NullAllowed] string actionType, string previewPropertyName, [NullAllowed] FBDialogAppCallCompletionHandler handler);

		[Async (ResultTypeName = "FBDialogAppCallResult")]
		[Static, Export ("presentShareDialogWithOpenGraphAction:actionType:previewPropertyName:clientState:handler:")]
		FBAppCall PresentShareDialog (IFBOpenGraphAction action, [NullAllowed] string actionType, string previewPropertyName, [NullAllowed] NSDictionary clientState, [NullAllowed] FBDialogAppCallCompletionHandler handler);
	}

	[BaseType (typeof (NSObject))]
	interface FBDialogsData 
	{
		[Export ("method")]
		string Method { get; }

		[Export ("arguments")]
		NSDictionary Arguments { get; }

		[Export ("clientState")]
		NSDictionary ClientState { get; }

		[Export ("results")]
		NSDictionary Results { get; }
	}

	[BaseType (typeof (NSObject))]
	interface FBDialogsParams 
	{

	}
	
	[BaseType (typeof (FBDialogsParams))]
	interface FBShareDialogPhotoParams 
	{
		[Export ("friends", ArgumentSemantic.Copy)]
		IFBGraphUser [] Friends { get; set; }
		
		[Export ("place", ArgumentSemantic.Copy)]
		IFBGraphPlace Place { get; set; }
		
		[Export ("dataFailuresFatal", ArgumentSemantic.Assign)]
		bool DataFailuresFatal { get; set; }
		
		[Export ("photos", ArgumentSemantic.Copy)]
		UIImage [] Photos { get; set; }
	}

	[BaseType (typeof (NSError))]
	[Category]
	interface FBError 
	{
		[Field ("FacebookSDKDomain", "__Internal")]
		NSString FacebookSDKDomain { get; }

		[Field ("FacebookNativeApplicationDomain", "__Internal")]
		NSString FacebookNativeApplicationDomain { get; }

		[Field ("FBErrorInnerErrorKey", "__Internal")]
		NSString InnerErrorKey { get; }

		[Field ("FBErrorParsedJSONResponseKey", "__Internal")]
		NSString ParsedJSONResponseKey { get; }

		[Field ("FBErrorHTTPStatusCodeKey", "__Internal")]
		NSString HTTPStatusCodeKey { get; }

		[Field ("FBErrorSessionKey", "__Internal")]
		NSString SessionKey { get; }

		[Field ("FBErrorUnprocessedURLKey", "__Internal")]
		NSString UnprocessedURLKey { get; }

		[Field ("FBErrorLoginFailedReason", "__Internal")]
		NSString LoginFailedReason { get; }

		[Field ("FBErrorLoginFailedOriginalErrorCode", "__Internal")]
		NSString LoginFailedOriginalErrorCode { get; }

		[Field ("FBErrorLoginFailedReasonInlineCancelledValue", "__Internal")]
		NSString LoginFailedReasonInlineCancelledValue { get; }

		[Field ("FBErrorLoginFailedReasonInlineNotCancelledValue", "__Internal")]
		NSString LoginFailedReasonInlineNotCancelledValue { get; }

		[Field ("FBErrorLoginFailedReasonUserCancelledValue", "__Internal")]
		NSString LoginFailedReasonUserCancelledValue { get; }

		[Field ("FBErrorLoginFailedReasonUserCancelledSystemValue", "__Internal")]
		NSString LoginFailedReasonUserCancelledSystemValue { get; }

		[Field ("FBErrorLoginFailedReasonOtherError", "__Internal")]
		NSString LoginFailedReasonOtherError { get; }

		[Field ("FBErrorLoginFailedReasonSystemDisallowedWithoutErrorValue", "__Internal")]
		NSString LoginFailedReasonSystemDisallowedWithoutErrorValue { get; }

		[Field ("FBErrorLoginFailedReasonSystemError", "__Internal")]
		NSString LoginFailedReasonSystemError { get; }

		[Field ("FBErrorLoginFailedReasonUnitTestResponseUnrecognized", "__Internal")]
		NSString LoginFailedReasonUnitTestResponseUnrecognized { get; }

		[Field ("FBErrorReauthorizeFailedReasonSessionClosed", "__Internal")]
		NSString ReauthorizeFailedReasonSessionClosed { get; }

		[Field ("FBErrorReauthorizeFailedReasonUserCancelled", "__Internal")]
		NSString ReauthorizeFailedReasonUserCancelled { get; }

		[Field ("FBErrorReauthorizeFailedReasonUserCancelledSystem", "__Internal")]
		NSString ReauthorizeFailedReasonUserCancelledSystem { get; }

		[Field ("FBErrorReauthorizeFailedReasonWrongUser", "__Internal")]
		NSString ReauthorizeFailedReasonWrongUser { get; }

		[Field ("FBErrorDialogInvalidOpenGraphObject", "__Internal")]
		NSString DialogInvalidOpenGraphObject { get; }

		[Field ("FBErrorDialogInvalidOpenGraphActionParameters", "__Internal")]
		NSString DialogInvalidOpenGraphActionParameters { get; }
		
		[Field ("FBErrorDialogInvalidShareParameters", "__Internal")]
		NSString DialogInvalidShareParameters { get; }

		[Field ("FBErrorAppEventsReasonKey", "__Internal")]
		NSString AppEventsReasonKey { get; }

		[Field ("FBInvalidOperationException", "__Internal")]
		NSString InvalidOperationException { get; }

		[Static, Export ("fberrorCategory")]
		FBErrorCategory FberrorCategory { get; }

		[Static, Export ("fberrorShouldNotifyUser")]
		bool FberrorShouldNotifyUser { get; }

		[Static, Export ("fberrorUserMessage", ArgumentSemantic.Copy)]
		string FberrorUserMessage { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	interface FBErrorUtility 
	{
		[Static, Export ("errorCategoryForError:")]
		FBErrorCategory ErrorCategory (NSError error);

		[Static, Export ("shouldNotifyUserForError:")]
		bool ShouldNotifyUser (NSError error);

		[Static, Export ("userMessageForError:")]
		string UserMessage (NSError error);
	}

	[BaseType (typeof (FBCacheDescriptor))]
	interface FBFrictionlessRecipientCache 
	{
		[Export ("recipientIDs", ArgumentSemantic.Copy)]
		string RecipientIDs { get; set; }

		[Export("isFrictionlessRecipient:")]
		bool IsFrictionlessRecipient (NSObject user);

		[Export("areFrictionlessRecipients:")]
		bool AreFrictionlessRecipients (NSArray users);

		[Export("prefetchAndCacheForSession:")]
		void PrefetchAndCache ([NullAllowed] FBSession session);

		[Async (ResultTypeName = "FBRequestResult")]
		[Export("prefetchAndCacheForSession:completionHandler:")]
		void PrefetchAndCache ([NullAllowed] FBSession session, [NullAllowed] FBRequestHandler handler);
	}

	[BaseType (typeof (FBViewController),
	           Delegates=new string [] {"WeakDelegate"},
	Events=new Type [] { typeof (FBFriendPickerDelegate) })]
	interface FBFriendPickerViewController 
	{
		[Export("spinner")]
		UIActivityIndicatorView Spinner { get; set; }

		[Export("tableView")]
		UITableView TableView { get; set; }

		[Export("allowsMultipleSelection")]
		bool AllowsMultipleSelection { get; set; }

		[Export("itemPicturesEnabled")]
		bool ItemPicturesEnabled { get; set; }

		[Export("fieldsForRequest", ArgumentSemantic.Copy)]
		NSSet FieldsForRequest { get; set; }

		[Export("session")]
		FBSession Session { get; set; }

		[Export("userID", ArgumentSemantic.Copy)]
		string UserID { get; set; }

		[Export("selection")]
		IFBGraphUser [] Selection { get; }

		//		[Export("selection")] [Internal]
		//		IntPtr Selection_ { get; }

		[Export("sortOrdering")]
		FBFriendSortOrdering SortOrdering { get; set; }

		[Export("displayOrdering")]
		FBFriendDisplayOrdering DisplayOrdering { get; set; }

		[Export("initWithNibName:bundle:")]
		IntPtr Constructor ([NullAllowed] string nibName, [NullAllowed] NSBundle nibBundle);

		[Export("configureUsingCachedDescriptor:")]
		void ConfigureUsingCachedDescriptor (FBCacheDescriptor cacheDescriptor);

		[Export("loadData")]
		void LoadData ();

		[Export("updateView")]
		void UpdateView ();

		[Export("clearSelection")]
		void ClearSelection ();

		[Static]
		[Export("cacheDescriptor")]
		FBCacheDescriptor CacheDescriptor ();

		[Static]
		[Export("cacheDescriptorWithUserID:fieldsForRequest:")]
		FBCacheDescriptor CacheDescriptor (string userID, NSSet fieldsForRequest);

		[Wrap ("WeakDelegate")] [New]
		FBFriendPickerDelegate Delegate { get; set; }
	}

	interface IFBFriendPickerDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface FBFriendPickerDelegate : FBViewControllerDelegate
	{
		[Export("friendPickerViewControllerDataDidChange:"), EventArgs("FBFriendPickerChange")]
		void DataDidChange (FBFriendPickerViewController friendPicker);

		[Export("friendPickerViewControllerSelectionDidChange:"), EventArgs("FBFriendPickerChange")]
		void SelectionDidChange (FBFriendPickerViewController friendPicker);

		[Export("friendPickerViewController:shouldIncludeUser:"), DelegateName("FBFriendPickerCondition"), DefaultValue("true")]
		bool ShouldIncludeUser (FBFriendPickerViewController friendPicker, IFBGraphUser user);

		[Export("friendPickerViewController:handleError:"), EventArgs("FBFriendPickerError")]
		void HandleError (FBFriendPickerViewController friendPicker, NSError error);
	}

	interface IFBGraphLocation { }

	[BaseType (typeof (NSObject))]
	[Protocol]
	interface FBGraphLocation : FBGraphObjectProtocol
	{
		[Bind ("street")]
		string GetStreet ();

		[Bind ("setStreet:")]
		void SetStreet (string street);

		[Bind ("city")]
		string GetCity ();

		[Bind ("setCity:")]
		void SetCity (string city);

		[Bind ("state")]
		string GetState ();

		[Bind ("setState:")]
		void SetState (string state);

		[Bind ("country")]
		string GetCountry ();

		[Bind ("setCountry:")]
		void SetCountry (string country);

		[Bind ("zip")]
		string GetZip ();

		[Bind ("setZip:")]
		void SetZip (string zip);

		[Bind ("latitude")]
		NSNumber GetLatitude ();

		[Bind ("setLatitude:")]
		void SetLatitude (NSNumber latitude);

		[Bind ("longitude")]
		NSNumber GetLongitude ();

		[Bind ("setLongitude:")]
		void SetLongitude (NSNumber longitude);
	}

	interface IFBGraphObjectProtocol { }
	
	[Protocol]
	interface FBGraphObjectProtocol
	{
		[Bind ("count")]
		uint GetCount ();

		[Bind ("objectForKey:")]
		NSObject ObjectForKey (string aKey);

		[Bind ("keyEnumerator")]
		NSEnumerator GetKeyEnumerator ();

		[Bind ("removeObjectForKey:")]
		NSObject RemoveObjectForKey (string aKey);

		[Bind ("setObject:forKey:")]
		void SetObject (NSObject anObject, string aKey);
	}

	[BaseType (typeof (NSObject))]
	interface FBGraphObject : FBGraphObjectProtocol
	{
		[Static]
		[Export("graphObject")]
		IFBGraphObjectProtocol GraphObject ();

		[Static]
		[Export("graphObjectWrappingDictionary:")]
		IFBGraphObjectProtocol GraphObject (NSDictionary jsonDictionary);

		[Static]
		[Export("openGraphActionForPost")]
		IFBOpenGraphAction OpenGraphAction { get; }

		[Static]
		[Export("openGraphObjectForPost")]
		IFBOpenGraphObject OpenGraphObject { get; }

		[Static]
		[Export("openGraphObjectForPostWithType:title:image:url:description:")]
		IFBOpenGraphObject OpenGraphObjectForPost (string aType, string title, NSObject image, NSObject url, string description);

		[Static]
		[Export("isGraphObjectID:sameAs:")]
		bool IsGraphObjectIDEqual (IFBGraphObjectProtocol anObject, IFBGraphObjectProtocol anotherObject);
	}

	interface IFBGraphPlace { }

	[BaseType (typeof (NSObject))]
	[Protocol]
	interface FBGraphPlace : FBGraphObjectProtocol
	{
		[Bind ("id")]
		string GetId ();

		[Bind ("setId:")]
		void SetId (string id);

		[Bind ("name")]
		string GetName ();

		[Bind ("setName:")]
		void SetName (string name);

		[Bind ("category")]
		string GetCategory ();

		[Bind ("setCategory:")]
		void SetCategory (string category);

		[Bind ("location")]
		IFBGraphLocation GetLocation ();

		[Bind ("setLocation")]
		void SetLocation (IFBGraphLocation location);
	}

	interface IFBGraphUser { }

	[BaseType (typeof (NSObject))]
	[Protocol]
	interface FBGraphUser : FBGraphObjectProtocol
	{
		[Bind ("id")]
		string GetId ();

		[Bind ("setId:")]
		void SetId (string id);

		[Bind ("name")]
		string GetName ();

		[Bind ("setName:")]
		void SetName (string name);

		[Bind ("first_name")]
		string GetFirstName ();

		[Bind ("setFirst_name:")]
		void SetFirstName (string firstName);

		[Bind ("middle_name")]
		string GetMiddleName ();

		[Bind ("setMiddle_name:")]
		void SetMiddleName (string middleName);

		[Bind ("last_name")]
		string GetLastName ();

		[Bind ("setLast_name:")]
		void SetLastName (string middleName);

		[Bind ("link")]
		string GetLink ();

		[Bind ("setLink:")]
		void SetLink (string link);

		[Bind ("username")]
		string GetUsername ();

		[Bind ("setUsername:")]
		void SetUsername (string username);

		[Bind ("birthday")]
		string GetBirthday ();

		[Bind ("setBirthday:")]
		void SetBirthday (string birthday);

		[Bind ("location")]
		IFBGraphPlace GetLocation ();

		[Bind ("setLocation:")]
		void SetLocation (IFBGraphPlace location);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	[Obsolete ("Use the FBAppEvents class instead")]
	interface FBInsights
	{
		[Notification]
		[Field ("FBInsightsLoggingResultNotification", "__Internal")]
		NSString FBInsightsLoggingResultNotification { get; }

		[Obsolete ("use FBSettings.AppVersion instead")]
		[Static, Export ("appVersion")]
		string AppVersion { get; set; }

		[Obsolete ("use FBAppEvents.LogPurchase instead")]
		[Static, Export ("logPurchase:currency:")]
		void LogPurchase (double purchaseAmount, string currency);

		[Obsolete ("use FBAppEvents.LogPurchase instead")]
		[Static, Export ("logPurchase:currency:parameters:")]
		void LogPurchase (double purchaseAmount, string currency, NSDictionary parameters);

		[Obsolete ("use FBAppEvents.LogPurchase instead")]
		[Static, Export ("logPurchase:currency:parameters:session:")]
		void LogPurchase (double purchaseAmount, string currency, NSDictionary parameters, FBSession session);

		[Static, Export ("logConversionPixel:valueOfPixel:")]
		void LogConversionPixel (string pixelId, double aValue);

		[Static, Export ("logConversionPixel:valueOfPixel:session:")]
		void LogConversionPixel (string pixelId, double aValue, FBSession session);

		[Obsolete ("use FBAppEvents.FlushBehavior instead")]
		[Static, Export ("flushBehavior")]
		FBInsightsFlushBehavior FlushBehavior { get; set; }

		[Obsolete ("use FBAppEvents.Flush instead")]
		[Static, Export ("flush")]
		void Flush ();
	}

	[BaseType (typeof (UIView),
	           Delegates=new string [] {"WeakDelegate"},
	Events=new Type [] { typeof (FBLoginViewDelegate) })]
	interface FBLoginView 
	{
		[Export("readPermissions", ArgumentSemantic.Copy)]
		string [] ReadPermissions { get; set; }

		[Export("publishPermissions", ArgumentSemantic.Copy)]
		string [] PublishPermissions { get; set; }

		[Export("defaultAudience", ArgumentSemantic.Assign)]
		FBSessionDefaultAudience DefaultAudience { get; set; }

		[Export("loginBehavior", ArgumentSemantic.Assign)]
		FBSessionLoginBehavior LoginBehavior { get; set; }

		[Export("initWithReadPermissions:"),PostGet("ReadPermissions")]
		IntPtr Constructor (string [] readPermissions);

		[Export("initWithPublishPermissions:defaultAudience:"),PostGet("PublishPermissions")]
		IntPtr Constructor (string [] publishPermissions, FBSessionDefaultAudience defaultAudience);

		[Wrap ("WeakDelegate")]
		FBLoginViewDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
	}

	interface IFBLoginViewDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface FBLoginViewDelegate 
	{
		[Export("loginViewShowingLoggedInUser:"), EventArgs ("FBLoginViewLogged")]
		void ShowingLoggedInUser (FBLoginView loginView);

		[Export("loginViewFetchedUserInfo:user:"), EventArgs ("FBLoginViewUserInfo")]
		void FetchedUserInfo (FBLoginView loginView, IFBGraphUser user);

		[Export("loginViewShowingLoggedOutUser:"), EventArgs ("FBLoginViewLogged")]
		void ShowingLoggedOutUser (FBLoginView loginView);

		[Export("loginView:handleError:"), EventArgs ("FBLoginViewError")]
		void HandleError (FBLoginView loginView, NSError error);
	}

	delegate void FBShareDialogHandler (FBNativeDialogResult result, NSError error);

	[Obsolete ("Please note that `FBNativeDialogs` has been deprecated, please migrate your code to use `FBDialogs`.")]
	[BaseType (typeof (NSObject))]
	interface FBNativeDialogs 
	{
		[Static] [Obsolete ("Please migrate your code to use `FBDialogs` and the related method `PresentOSIntegratedShareDialogModally`")]
		[Export("presentShareDialogModallyFrom:initialText:image:url:handler:")]
		bool PresentShareDialogModallyFrom(UIViewController viewController, string initialText, UIImage image, NSUrl url, FBShareDialogHandler handler);

		[Static] [Obsolete ("Please migrate your code to use `FBDialogs` and the related method `PresentOSIntegratedShareDialogModally`")]
		[Export("presentShareDialogModallyFrom:initialText:images:urls:handler:")]
		bool PresentShareDialogModallyFrom(UIViewController viewController, string initialText, UIImage [] images, NSUrl [] urls, FBShareDialogHandler handler);

		[Static] [Obsolete ("Please migrate your code to use `FBDialogs` and the related method `PresentOSIntegratedShareDialogModally`")]
		[Export("presentShareDialogModallyFrom:session:initialText:images:urls:handler:")]
		bool PresentShareDialogModallyFrom(UIViewController viewController, FBSession session, string initialText, UIImage [] images, NSUrl [] urls, FBShareDialogHandler handler);

		[Static] [Obsolete ("please migrate your code to use `FBDialogs` and the related method `CanPresentOSIntegratedShareDialog`")]
		[Export("canPresentShareDialogWithSession:")]
		bool CanPresentShareDialogWithSession (FBSession session);
	}

	interface IFBOpenGraphAction { }

	[BaseType (typeof (NSObject))]
	[Protocol]
	interface FBOpenGraphAction : FBGraphObjectProtocol
	{
		[Bind ("id")]
		string GetId ();

		[Bind ("setId:")]
		void SetId (string id);

		[Bind ("start_time")]
		string GetStartTime ();

		[Bind ("setStart_time:")]
		void SetStartTime (string startTime);

		[Bind ("end_time")]
		string GetEndTime ();

		[Bind ("setEnd_time:")]
		void SetEndTime (string endTime);

		[Bind ("publish_time")]
		string GetPublishTime ();

		[Bind ("setPublish_time:")]
		void SetPublishTime (string publishTime);

		[Bind ("created_time")]
		string GetCreatedTime ();

		[Bind ("setCreated_time:")]
		void SetCreatedTime (string createdTime);

		[Bind ("expires_time")]
		string GetExpiresTime ();

		[Bind ("setExpires_time:")]
		void SetExpiresTime (string expiresTime);

		[Bind ("ref")]
		string GetRef ();

		[Bind ("setRef:")]
		void SetRef (string aRef);

		[Bind ("message")]
		string GetMessage ();

		[Bind ("setMessage:")]
		void SetMessage (string message);

		[Bind ("place")]
		IFBGraphPlace GetPlace ();

		[Bind ("setPlace:")]
		void SetPlace (IFBGraphPlace place);

		[Bind ("tags")]
		NSObject [] GetTags ();

		[Bind ("setTags:")]
		void SetTags (NSObject [] tags);

		[Bind ("image")]
		NSObject GetImage ();

		[Bind ("setImage:")]
		void SetImage (NSObject image);

		[Bind ("from")]
		IFBGraphUser GetFrom ();

		[Bind ("setFrom:")]
		void SetFrom (IFBGraphUser fromUser);

		[Bind ("likes")]
		NSObject [] GetLikes ();

		[Bind ("setLikes:")]
		void SetLikes (NSObject [] likes);

		[Bind ("application")]
		IFBGraphObjectProtocol GetApplication ();

		[Bind ("setApplication:")]
		void SetApplication (IFBGraphObjectProtocol application);

		[Bind ("comments")]
		NSObject [] GetComments ();

		[Bind ("setComments:")]
		void SetComments (NSObject [] comments);
	}

	[BaseType (typeof (FBDialogsParams))]
	interface FBOpenGraphActionShareDialogParams 
	{
		[Field ("FBPostObject", "__Internal")]
		NSString FBPostObject { get; }

		[Export("action")]
		IFBOpenGraphAction Action { get; set; }

		[Export("previewPropertyName", ArgumentSemantic.Copy)]
		string PreviewPropertyName { get; set; }

		[Export("actionType", ArgumentSemantic.Copy)]
		string ActionType { get; set; }
	}

	interface IFBOpenGraphObject { }

	[BaseType (typeof (NSObject))]
	[Protocol]
	interface FBOpenGraphObject : FBGraphObjectProtocol
	{	
		[Bind ("id")]
		string GetId ();

		[Bind ("setId:")]
		void SetId (string id);

		[Bind ("type")]
		string GetAType ();

		[Bind ("setType:")]
		void SetAType (string aType);

		[Bind ("title")]
		string GetTitle ();

		[Bind ("setTitle:")]
		void SetTitle (string title);

		[Bind ("image")]
		NSObject GetImage ();

		[Bind ("setImage:")]
		void SetImage (NSObject image);

		[Bind ("url")]
		NSObject GetUrl ();

		[Bind ("setUrl:")]
		void SetUrl (NSObject url);

		[Bind ("description")]
		NSObject GetDescription ();

		[Bind ("setDescription:")]
		void SetDescription (NSObject description);

		[Bind ("data")]
		FBGraphObject GetData ();

		[Bind ("setData:")]
		void SetData (FBGraphObject data);
	}

	[BaseType (typeof (FBViewController),
	           Delegates=new string [] {"WeakDelegate"},
	Events=new Type [] { typeof (FBPlacePickerDelegate) })]
	interface FBPlacePickerViewController 
	{
		[Export("spinner")]
		UIActivityIndicatorView Spinner { get; set; }

		[Export("tableView")]
		UITableView TableView { get; set; }

		[Export("fieldsForRequest", ArgumentSemantic.Copy)]
		NSSet FieldsForRequest { get; set; }

		[Export("itemPicturesEnabled")]
		bool ItemPicturesEnabled { get; set; }

		[Export("locationCoordinate")]
		CLLocationCoordinate2D LocationCoordinate { get; set; }

		[Export("radiusInMeters")]
		int RadiusInMeters { get; set; }

		[Export("resultsLimit")]
		int ResultsLimit { get; set; }

		[Export("searchText", ArgumentSemantic.Copy)]
		string SearchText { get; set; }

		[Export("session")]
		FBSession Session { get; set; }

		[Export("selection")]
		IFBGraphPlace Selection { get; }

		[Export("clearSelection")]
		void ClearSelection ();

		//		[Export("selection")] [Internal]
		//		IntPtr Selection_ { get; }

		[Export("initWithNibName:bundle:")]
		IntPtr Constructor ([NullAllowed] string nibName, [NullAllowed] NSBundle nibBundle);

		[Export("configureUsingCachedDescriptor:")]
		void ConfigureUsingCachedDescriptor (FBCacheDescriptor cacheDescriptor);

		[Export("loadData")]
		void LoadData ();

		[Export("updateView")]
		void UpdateView ();

		[Static]
		[Export("cacheDescriptorWithLocationCoordinate:radiusInMeters:searchText:resultsLimit:fieldsForRequest:")]
		FBCacheDescriptor CacheDescriptorWithLocationCoordinate (CLLocationCoordinate2D locationCoordinate, int radiusInMeters, string searchText, int resultsLimit, NSSet fieldsForRequest);

		[Wrap ("WeakDelegate")] [New]
		FBPlacePickerDelegate Delegate { get; set; }
	}

	interface IFBPlacePickerDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface FBPlacePickerDelegate : FBViewControllerDelegate
	{
		[Export("placePickerViewControllerDataDidChange:"), EventArgs("FBPlacePickerChange")]
		void DataDidChange (FBPlacePickerViewController placePicker);

		[Export("placePickerViewControllerSelectionDidChange:"), EventArgs("FBPlacePickerChange")]
		void SelectionDidChange (FBPlacePickerViewController placePicker);

		[Export("placePickerViewController:shouldIncludePlace:"), DelegateName("FBPlacePickerCondition"), DefaultValue("true")]
		bool ShouldIncludeUser (FBPlacePickerViewController placePicker, IFBGraphPlace place);

		[Export("placePickerViewController:handleError:"), EventArgs("FBPlacePickerError")]
		void HandleError (FBPlacePickerViewController placePicker, NSError error);
	}

	[BaseType (typeof (UIView))]
	interface FBProfilePictureView 
	{
		[Export ("profileID", ArgumentSemantic.Copy)]
		string ProfileID { get; [NullAllowed] set; }

		[Export ("pictureCropping")]
		FBProfilePictureCropping PictureCropping { get; set; }

		[Export("initWithProfileID:pictureCropping:")] [PostGet("ProfileID")] [PostGet("PictureCropping")]
		IntPtr Constructor (string profileID, FBProfilePictureCropping pictureCropping);
	}

	[BaseType (typeof (NSObject))]
	interface FBRequest 
	{
		[Field ("FBGraphBasePath", "__Internal")]
		NSString GraphBasePath { get; }

		[Export("initWithSession:graphPath:")]
		IntPtr Constructor ([NullAllowed] FBSession session, string graphPath);

		[Export("initWithSession:graphPath:parameters:HTTPMethod:")]
		IntPtr Constructor ([NullAllowed] FBSession session, string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string HTTPMethod);

		[Export("initForPostWithSession:graphPath:graphObject:")]
		IntPtr Constructor ([NullAllowed] FBSession session, string graphPath, IFBGraphObjectProtocol graphObject);

		[Export("initWithSession:restMethod:parameters:HTTPMethod:")]
		IntPtr Constructor ([NullAllowed] FBSession session, NSString restMethod, [NullAllowed] NSDictionary parameters, [NullAllowed] string HTTPMethod);

		[Export ("parameters")]
		NSMutableDictionary Parameters { get; }

		[Export ("session")]
		FBSession Session { get; set; }

		[Export ("graphPath", ArgumentSemantic.Copy)]
		string GraphPath { get; set; }

		[Export ("restMethod", ArgumentSemantic.Copy)]
		string RestMethod { get; set; }

		[Export ("HTTPMethod", ArgumentSemantic.Copy)]
		string HTTPMethod { get; set; }

		[Export ("graphObject")]
		IFBGraphObjectProtocol GraphObject { get; set; }

		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startWithCompletionHandler:")]
		FBRequestConnection Start (FBRequestHandler handler);

		[Static]
		[Export ("requestForMe")]
		FBRequest ForMe { get; }

		[Static]
		[Export ("requestForMyFriends")]
		FBRequest ForMyFriends { get; }

		[Static]
		[Export ("requestForUploadPhoto:")]
		FBRequest ForUploadPhoto (UIImage photo);

		[Static]
		[Export ("requestForPostStatusUpdate:")]
		FBRequest ForPostStatusUpdate (string message);

		[Static]
		[Export ("requestForPostStatusUpdate:place:tags:")]
		FBRequest ForPostStatusUpdate (string message, [NullAllowed] NSObject place, NSObject [] tags);

		[Static]
		[Export ("requestForPlacesSearchAtCoordinate:radiusInMeters:resultsLimit:searchText:")]
		FBRequest ForPlacesSearchAtCoordinate (CLLocationCoordinate2D coordinate, int radius, int limit, string searchText);

		[Static]
		[Export ("requestForCustomAudienceThirdPartyID:")]
		FBRequest ForCustomAudienceThirdPartyID (FBSession session);

		[Static]
		[Export ("requestForGraphPath:")]
		FBRequest ForGraphPath (string graphPath);

		[Static]
		[Export ("requestForDeleteObject:")]
		FBRequest ForDeleteObject (NSObject aObject);

		[Static]
		[Export ("requestForPostWithGraphPath:graphObject:")]
		FBRequest ForPostWithGraphPath (string graphPath, IFBGraphObjectProtocol graphObject);

		[Static]
		[Export ("requestWithGraphPath:parameters:HTTPMethod:")]
		FBRequest WithGraphPath (string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string HTTPMethod);

		[Static]
		[Export ("requestForPostOpenGraphObject:")]
		FBRequest ForPostOpenGraphObject (IFBOpenGraphObject aObject);

		[Static]
		[Export ("requestForPostOpenGraphObjectWithType:title:image:url:description:objectProperties:")]
		FBRequest ForPostOpenGraphObject (string aType, string title, NSObject image, NSObject url, string description, NSDictionary objectProperties);

		[Static]
		[Export ("requestForUpdateOpenGraphObject:")]
		FBRequest ForUpdateOpenGraphObject (IFBOpenGraphObject aObject);

		[Static]
		[Export ("requestForUpdateOpenGraphObjectWithId:title:image:url:description:objectProperties:")]
		FBRequest ForPostOpenGraphObject (NSObject objectId, string title, NSObject image, NSObject url, string description, NSDictionary objectProperties);

		[Static]
		[Export ("requestForUploadStagingResourceWithImage:")]
		FBRequest ForUploadStagingResource (UIImage image);

		#region Old Facebook Apis

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set;  }

		[Wrap ("WeakDelegate")]
		FBRequestDelegate Delegate { get; set; }

		[Export ("url")]
		string Url { get; set;  }

		[Export ("httpMethod")]
		string HttpMethod { get; set;  }

		[Export ("connection")]
		NSUrlConnection Connection { get; set;  }

		[Export ("responseText")]
		NSMutableData ResponseText { get; set;  }

		[Export ("state")]
		FBRequestState State { get;  }

		[Export ("error")]
		NSError Error { get; set;  }

		[Static]
		[Export ("serializeURL:params:")]
		string Serialize (string baseUrl, NSDictionary parameters);

		[Static]
		[Export ("serializeURL:params:httpMethod:")]
		string Serialize (string baseUrl, NSDictionary parameters, string httpMethod);

		[Static]
		[Export ("getRequestWithParams:httpMethod:delegate:requestURL:")]
		FBRequest GetRequest (NSMutableDictionary parameters, string method , FBRequestDelegate httpMethodDelegatedelegate, string url);

		[Export ("loading")]
		bool Loading ();

		[Export ("connect")]
		void Connect ();

		#endregion

	}

	delegate void FBRequestHandler (FBRequestConnection connection, NSObject result, NSError error);

	[BaseType (typeof (NSObject))]
	interface FBRequestConnection
	{
		[Field ("FBNonJSONResponseProperty", "__Internal")]
		NSString NonJSONResponseProperty { get; }

		[Export("initWithTimeout:")]
		IntPtr Constructor (double timeout);

		[Export ("urlRequest", ArgumentSemantic.Retain)]
		NSMutableUrlRequest UrlRequest { get; set; }

		[Export ("urlResponse", ArgumentSemantic.Retain)]
		NSHttpUrlResponse UrlResponse { get; }

		[Export ("errorBehavior", ArgumentSemantic.Assign)]
		FBRequestConnectionErrorBehavior ErrorBehavior { get; set; }

		[Export("addRequest:completionHandler:")]
		void AddRequest (FBRequest request, FBRequestHandler handler);

		[Export("addRequest:completionHandler:batchEntryName:")]
		void AddRequest (FBRequest request, FBRequestHandler handler, string batchEntryName);

		[Export("addRequest:completionHandler:batchParameters:")]
		void AddRequest (FBRequest request, FBRequestHandler handler, [NullAllowed] NSDictionary batchParameters);

		[Export("start")]
		void Start ();

		[Export("cancel")]
		void Cancel ();

		[Static]
		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startForMeWithCompletionHandler:")]
		FBRequestConnection GetMe (FBRequestHandler handler);

		[Static]
		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startForMyFriendsWithCompletionHandler:")]
		FBRequestConnection GetMyFriends (FBRequestHandler handler);

		[Static]
		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startForUploadPhoto:completionHandler:")]
		FBRequestConnection UploadPhoto (UIImage photo, FBRequestHandler handler);

		[Static]
		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startForPostStatusUpdate:completionHandler:")]
		FBRequestConnection PostStatusUpdate (string message, FBRequestHandler handler);

		[Static]
		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startForPostStatusUpdate:place:tags:completionHandler:")]
		FBRequestConnection PostStatusUpdate (string message, [NullAllowed] NSObject place, NSObject [] tags, FBRequestHandler handler);

		[Static]
		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startForPlacesSearchAtCoordinate:radiusInMeters:resultsLimit:searchText:completionHandler:")]
		FBRequestConnection StartPlacesSearchAtCoordinate (CLLocationCoordinate2D coordinate, int radius, int limit, string searchText, FBRequestHandler handler);

		[Static]
		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startForCustomAudienceThirdPartyID:completionHandler:")]
		FBRequestConnection StartCustomAudienceThirdPartyID (FBSession session, FBRequestHandler handler);

		[Static]
		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startWithGraphPath:completionHandler:")]
		FBRequestConnection GetFromGraphPath (string graphPath, FBRequestHandler handler);

		[Static]
		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startForDeleteObject:completionHandler:")]
		FBRequestConnection DeleteObject (NSObject aObject, FBRequestHandler handler);

		[Static]
		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startForPostWithGraphPath:graphObject:completionHandler:")]
		FBRequestConnection PostGraphPath (string graphPath, IFBGraphObjectProtocol graphObject, FBRequestHandler handler);

		[Static]
		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startWithGraphPath:parameters:HTTPMethod:completionHandler:")]
		FBRequestConnection StartWithGraphPath (string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string HTTPMethod, FBRequestHandler handler);

		[Static]
		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startForPostOpenGraphObject:completionHandler:")]
		FBRequestConnection PostOpenGraphObject (IFBOpenGraphObject aObject, FBRequestHandler handler);

		[Static]
		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startForPostOpenGraphObjectWithType:title:image:url:description:objectProperties:completionHandler:")]
		FBRequest PostOpenGraphObject (string aType, string title, NSObject image, NSObject url, string description, NSDictionary objectProperties, FBRequestHandler handler);

		[Static]
		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startForUpdateOpenGraphObject:completionHandler:")]
		FBRequest UpdateOpenGraphObject (IFBOpenGraphObject aObject, FBRequestHandler handler);

		[Static]
		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startForUpdateOpenGraphObjectWithId:title:image:url:description:objectProperties:completionHandler:")]
		FBRequest UpdateOpenGraphObject (NSObject objectId, string title, NSObject image, NSObject url, string description, NSDictionary objectProperties, FBRequestHandler handler);

		[Static]
		[Async (ResultTypeName = "FBRequestResult")]
		[Export ("startForUploadStagingResourceWithImage:completionHandler:")]
		FBRequest UploadStagingResource (UIImage image, FBRequestHandler handler);
	}

	delegate void FBSessionStateHandler (FBSession session, FBSessionState status, NSError error);

	delegate void FBSessionReauthorizeResultHandler (FBSession session, NSError error);

	delegate void FBSessionRequestPermissionResultHandler (FBSession session, NSError error);

	delegate void FBSessionRenewSystemCredentialsHandler (ACAccountCredentialRenewResult result, NSError error);

	[BaseType (typeof (NSObject))]
	interface FBSession 
	{
		[Notification]
		[Field ("FBSessionDidSetActiveSessionNotification", "__Internal")]
		NSString DidSetActiveSessionNotification { get; }

		[Notification]
		[Field ("FBSessionDidUnsetActiveSessionNotification", "__Internal")]
		NSString DidUnsetActiveSessionNotification { get; }

		[Notification]
		[Field ("FBSessionDidBecomeOpenActiveSessionNotification", "__Internal")]
		NSString DidBecomeOpenActiveSessionNotification { get; }

		[Notification]
		[Field ("FBSessionDidBecomeClosedActiveSessionNotification", "__Internal")]
		NSString DidBecomeClosedActiveSessionNotification { get; }

		[Export("initWithPermissions:")]
		IntPtr Constructor ([NullAllowed] string [] permissions);

		[Export("initWithAppID:permissions:urlSchemeSuffix:tokenCacheStrategy:")]
		IntPtr Constructor ([NullAllowed] string appId, [NullAllowed] string [] permissions, [NullAllowed] string urlSchemeSuffix, [NullAllowed] FBSessionTokenCachingStrategy tokenCachingStrategy);

		[Export("initWithAppID:permissions:defaultAudience:urlSchemeSuffix:tokenCacheStrategy:")]
		IntPtr Constructor ([NullAllowed] string appId, [NullAllowed] string [] permissions, FBSessionDefaultAudience defaultAudience, [NullAllowed] string urlSchemeSuffix, [NullAllowed] FBSessionTokenCachingStrategy tokenCachingStrategy);

		[Export ("isOpen")]
		bool IsOpen { get; }

		[Export ("state")]
		FBSessionState State { get; }

		[Export ("appID", ArgumentSemantic.Copy)]
		string AppID { get; }

		[Export ("urlSchemeSuffix", ArgumentSemantic.Copy)]
		string UrlSchemeSuffix { get; }

		[Export ("accessToken", ArgumentSemantic.Copy)] [Obsolete ("Use the `AccessTokenData` property.")]
		string AccessToken { get; }

		[Export ("expirationDate", ArgumentSemantic.Copy)] [Obsolete ("Use the `AccessTokenData` property.")]
		NSDate ExpirationDate { get; }

		[Export ("permissions", ArgumentSemantic.Copy)]
		string [] Permissions { get; }

		[Export ("loginType")] [Obsolete ("Use the `AccessTokenData` property.")]
		FBSessionLoginType LoginType { get; }

		[Export ("accessTokenData", ArgumentSemantic.Copy)]
		FBAccessTokenData AccessTokenData { get; }

		[Export ("openWithCompletionHandler:")]
		void Open (FBSessionStateHandler handler);

		[Export ("openWithBehavior:completionHandler:")]
		void Open (FBSessionLoginBehavior behavior, [NullAllowed] FBSessionStateHandler handler);

		[Export ("openFromAccessTokenData:completionHandler:")]
		void Open (FBAccessTokenData accessTokenData, [NullAllowed] FBSessionStateHandler handler);

		[Export ("close")]
		void Close ();

		[Export ("closeAndClearTokenInformation")]
		void CloseAndClearTokenInformation ();

		[Export ("reauthorizeWithReadPermissions:completionHandler:")] [Obsolete ("Use `RequestNewReadPermissions` instead")]
		void ReauthorizeWithReadPermissions (string [] readPermissions, [NullAllowed] FBSessionReauthorizeResultHandler handler);

		[Export ("reauthorizeWithPublishPermissions:defaultAudience:completionHandler:")] [Obsolete ("Use `RequestNewPublishPermissions` instead")]
		void ReauthorizeWithPublishPermissions (string [] writePermissions, FBSessionDefaultAudience defaultAudience, [NullAllowed] FBSessionReauthorizeResultHandler handler);

		[Async]
		[Export ("requestNewReadPermissions:completionHandler:")]
		void RequestNewReadPermissions (string [] readPermissions, [NullAllowed] FBSessionRequestPermissionResultHandler handler);

		[Async]
		[Export ("requestNewPublishPermissions:defaultAudience:completionHandler:")]
		void RequestNewPublishPermissions (string [] writePermissions, FBSessionDefaultAudience defaultAudience, [NullAllowed] FBSessionRequestPermissionResultHandler handler);

		[Export ("handleOpenURL:")]
		bool HandleOpenURL (NSUrl url);

		[Export ("handleDidBecomeActive")]
		void HandleDidBecomeActive ();

		[Export ("setStateChangeHandler:")]
		void SetStateChangeHandler (FBSessionStateHandler stateChangeHandler);

		[Static]
		[Export ("openActiveSessionWithAllowLoginUI:")]
		bool OpenActiveSession (bool allowLoginUI);

		[Static]
		[Export ("openActiveSessionWithReadPermissions:allowLoginUI:completionHandler:")]
		bool OpenActiveSession ([NullAllowed] string[] readPermissions, bool allowLoginUI, FBSessionStateHandler completion);

		[Static]
		[Export ("openActiveSessionWithPublishPermissions:defaultAudience:allowLoginUI:completionHandler:")]
		bool OpenActiveSession (string[] publishPermissions, FBSessionDefaultAudience defaultAudience, bool allowLoginUI, FBSessionStateHandler completion);

		[Static]
		[Export ("activeSession")]
		FBSession ActiveSession { get; set; }

		[Static] [Obsolete ("Deprecated in favor of FBSettings.DefaultAppID")]
		[Export ("defaultAppID")]
		string DefaultAppID { get; set; }

		[Static] [Obsolete ("Deprecated in favor of FBSettings.DefaultUrlSchemeSuffix")]
		[Export ("defaultUrlSchemeSuffix")]
		string DefaultUrlSchemeSuffix { get; set; }

		[Static]
		[Export ("renewSystemCredentials:")]
		void RenewSystemCredentials (FBSessionRenewSystemCredentialsHandler handler);

		#region Old facebook Apis

		[Export ("reauthorizeWithPermissions:behavior:completionHandler:")] [Obsolete]
		void ReauthorizeWithPermissions (string[] permissions, FBSessionLoginBehavior behavior, FBSessionReauthorizeResultHandler completion);

		#endregion
	}

	[BaseType (typeof (NSObject))]
	interface FBSessionTokenCachingStrategy 
	{
		[Export("initWithUserDefaultTokenInformationKeyName:")]
		IntPtr Constructor (string tokenInformationKeyName);

		[Export ("cacheTokenInformation:")]
		void CacheTokenInformation (NSDictionary tokenInformation);

		[Export ("cacheFBAccessTokenData:")]
		void CacheFBAccessTokenData (FBAccessTokenData accessToken);

		[Export ("fetchTokenInformation")]
		NSDictionary FetchTokenInformation ();

		[Export ("fetchFBAccessTokenData")]
		FBAccessTokenData FetchFBAccessTokenData ();

		[Export ("clearToken")]
		void ClearToken ();

		[Static]
		[Export ("defaultInstance")]
		FBSessionTokenCachingStrategy DefaultInstance { get; }

		[Static]
		[Export ("nullCacheInstance")]
		FBSessionTokenCachingStrategy NullCacheInstance { get; }

		[Static]
		[Export ("isValidTokenInformation:")]
		bool IsValidTokenInformation (NSDictionary tokenInformation);

		[Field ("FBTokenInformationTokenKey", "__Internal")]
		NSString TokenInformationTokenKey { get; }

		[Field ("FBTokenInformationExpirationDateKey", "__Internal")]
		NSString TokenInformationExpirationDateKey { get; }

		[Field ("FBTokenInformationRefreshDateKey", "__Internal")]
		NSString TokenInformationRefreshDateKey { get; }

		[Field ("FBTokenInformationUserFBIDKey", "__Internal")]
		NSString TokenInformationUserFBIDKey { get; }

		[Field ("FBTokenInformationIsFacebookLoginKey", "__Internal")]
		NSString TokenInformationIsFacebookLoginKey { get; }

		[Field ("FBTokenInformationLoginTypeLoginKey", "__Internal")]
		NSString TokenInformationLoginTypeLoginKey { get; }

		[Field ("FBTokenInformationPermissionsKey", "__Internal")]
		NSString TokenInformationPermissionsKey { get; }

		[Field ("FBTokenInformationPermissionsRefreshDateKey", "__Internal")]
		NSString TokenInformationPermissionsRefreshDateKey { get; }
	}

	delegate void FBInstallResponseDataHandler (IFBGraphObjectProtocol response, NSError error);

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	interface FBSettings 
	{
		[Field ("FBLoggingBehaviorFBRequests", "__Internal")]
		NSString LoggingBehaviorFBRequests { get; }

		[Field ("FBLoggingBehaviorFBURLConnections", "__Internal")]
		NSString LoggingBehaviorFBURLConnections { get; }

		[Field ("FBLoggingBehaviorAccessTokens", "__Internal")]
		NSString LoggingBehaviorAccessTokens { get; }

		[Field ("FBLoggingBehaviorSessionStateTransitions", "__Internal")]
		NSString LoggingBehaviorSessionStateTransitions { get; }

		[Field ("FBLoggingBehaviorPerformanceCharacteristics", "__Internal")]
		NSString LoggingBehaviorPerformanceCharacteristics { get; }

		[Field ("FBLoggingBehaviorAppEvents", "__Internal")]
		NSString LoggingBehaviorAppEvents { get; }

		[Field ("FBLoggingBehaviorInformational", "__Internal")]
		NSString LoggingBehaviorInformational { get; }

		[Field ("FBLoggingBehaviorDeveloperErrors", "__Internal")]
		NSString LoggingBehaviorDeveloperErrors { get; }

		[Static]
		[Export ("sdkVersion")]
		string SdkVersion { get; }

		[Static]
		[Export ("loggingBehavior")]
		NSSet LoggingBehavior { get; set; }

		[Obsolete]
		[Static]
		[Export ("shouldAutoPublishInstall")]
		bool ShouldAutoPublishInstall { get; set; }

		[Obsolete ("use FBAppEvents.ActivateApp instead")]
		[Static]
		[Export ("publishInstall:")]
		void PublishInstall ([NullAllowed] string appID);

		[Obsolete]
		[Static]
		[Export ("publishInstall:withHandler:")]
		void PublishInstall ([NullAllowed] string appID, [NullAllowed] FBInstallResponseDataHandler handler);

		[Static]
		[Export ("appVersion")]
		string AppVersion { get; set; }

		[Static]
		[Export ("clientToken")]
		string ClientToken { get; set; }

		[Static]
		[Export ("defaultDisplayName")]
		string DefaultDisplayName { get; set; }

		[Static]
		[Export ("defaultAppID")]
		string DefaultAppID { get; set; }

		[Static]
		[Export ("defaultUrlSchemeSuffix")]
		string DefaultUrlSchemeSuffix { get; set; }

		[Static]
		[Export ("resourceBundleName")]
		string ResourceBundleName { get; set; }

		[Static]
		[Export ("facebookDomainPart")]
		string FacebookDomainPart { get; set; }

		[Static]
		[Export ("enableBetaFeatures:")]
		void EnableBetaFeatures (uint betaFeatures);

		[Static]
		[Export ("enableBetaFeature:")]
		void EnableBetaFeature (FBBetaFeatures betaFeature);

		[Static]
		[Export ("disableBetaFeature:")]
		void DisableBetaFeature (FBBetaFeatures betaFeature);

		[Static]
		[Export ("isBetaFeatureEnabled:")]
		bool IsBetaFeatureEnabled (FBBetaFeatures betaFeature);

		[Static]
		[Export ("limitEventAndDataUsage")]
		bool LimitEventAndDataUsage { get; set; }
	}

	[BaseType (typeof (FBDialogsParams))]
	interface FBShareDialogParams 
	{
		[Export ("link", ArgumentSemantic.Copy)]
		NSUrl Link { get; set; }

		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; set; }

		[Export ("caption", ArgumentSemantic.Copy)]
		string Caption { get; set; }

		[Export ("description", ArgumentSemantic.Copy)] [New]
		string Description { get; set; }

		[Export ("picture", ArgumentSemantic.Copy)]
		NSUrl Picture { get; set; }

		[Export ("friends", ArgumentSemantic.Copy)]
		NSObject [] Friends { get; set; }

		[Export ("place", ArgumentSemantic.Copy)]
		NSObject Place { get; set; }

		[Export ("ref", ArgumentSemantic.Copy)]
		string Ref { get; set; }

		[Export ("dataFailuresFatal", ArgumentSemantic.Assign)]
		bool DataFailuresFatal { get; set; }
	}

	[BaseType (typeof (FBSession))]
	interface FBTestSession 
	{
		[Export ("appAccessToken", ArgumentSemantic.Copy)]
		string AppAccessToken { get; set; }

		[Export ("testUserID", ArgumentSemantic.Copy)]
		string TestUserID { get; set; }

		[Export ("testAppID", ArgumentSemantic.Copy)]
		string TestAppID { get; set; }

		[Export ("testAppSecret", ArgumentSemantic.Copy)]
		string TestAppSecret { get; set; }

		[Export ("disableReauthorize", ArgumentSemantic.Assign)]
		bool DisableReauthorize { get; set; }

		[Static]
		[Export ("sessionWithSharedUserWithPermissions:")]
		FBTestSession SessionWithSharedUserWithPermissions ([NullAllowed] string [] permissions);

		[Static]
		[Export ("sessionWithSharedUserWithPermissions:uniqueUserTag:")]
		FBTestSession SessionWithSharedUserWithPermissions ([NullAllowed] string [] permissions, string uniqueUserTag);

		[Static]
		[Export ("sessionWithPrivateUserWithPermissions:")]
		FBTestSession SessionWithPrivateUserWithPermissions ([NullAllowed] string [] permissions);
	}

	interface IFBUserSettingsDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface FBUserSettingsDelegate : FBViewControllerDelegate
	{
		[Export("loginViewControllerWillLogUserOut:")]
		void WillLogUserOut (NSObject sender);

		[Export("loginViewControllerDidLogUserOut:")]
		void DidLogUserOut (NSObject sender);

		[Export("loginViewControllerWillAttemptToLogUserIn:")]
		void WillAttemptToLogUserIn (NSObject sender);

		[Export("loginViewControllerDidLogUserIn:")]
		void DidLogUserIn (NSObject sender);

		[Export("loginViewController:receivedError:")]
		void ReceivedError (NSObject sender, NSError error);
	}

	[BaseType (typeof (FBViewController))]
	interface FBUserSettingsViewController
	{
		[Export ("readPermissions", ArgumentSemantic.Copy)]
		string [] ReadPermissions { get; set; }

		[Export ("publishPermissions", ArgumentSemantic.Copy)]
		string [] PublishPermissions { get; set; }

		[Export ("defaultAudience", ArgumentSemantic.Assign)]
		FBSessionDefaultAudience DefaultAudience { get; set; }
	}

	delegate void FBModalCompletionHandler (FBViewController sender, bool donePressed);

	interface IFBViewControllerDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface FBViewControllerDelegate 
	{
		[Export("facebookViewControllerCancelWasPressed:"), EventArgs("FBViewControllerButton")]
		void CancelWasPressed (NSObject sender);

		[Export("facebookViewControllerDoneWasPressed:"), EventArgs("FBViewControllerButton")]
		void DoneWasPressed (NSObject sender);
	}

	[BaseType (typeof (UIViewController))]
	interface FBViewController
	{
		[Export ("cancelButton")]
		UIBarButtonItem CancelButton { get; set; }

		[Export ("doneButton")]
		UIBarButtonItem DoneButton { get; set; }

		[Wrap ("WeakDelegate")]
		FBViewControllerDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("canvasView")]
		UIView CanvasView { get; }

		[Export ("presentModallyFromViewController:animated:handler:")]
		void PresentModallyFromViewController (UIViewController viewController, bool animated, FBModalCompletionHandler handler);
	}

	delegate void FBWebDialogHandler (FBWebDialogResult result, NSUrl resultUrl, NSError error);

	[BaseType (typeof (NSObject))]
	interface FBWebDialogs {

		[Static, Export ("presentDialogModallyWithSession:dialog:parameters:handler:")]
		void PresentDialogModally ([NullAllowed] FBSession session, string dialog, [NullAllowed] NSDictionary parameters, [NullAllowed] FBWebDialogHandler handler);

		[Static, Export ("presentDialogModallyWithSession:dialog:parameters:handler:delegate:")]
		void PresentDialogModally ([NullAllowed] FBSession session, string dialog, [NullAllowed] NSDictionary parameters, [NullAllowed] FBWebDialogHandler handler, [NullAllowed] FBWebDialogsDelegate aDelegate);

		[Static, Export ("presentRequestsDialogModallyWithSession:message:title:parameters:handler:")]
		void PresentRequestsDialogModally ([NullAllowed] FBSession session, string message, string title, [NullAllowed] NSDictionary parameters, [NullAllowed] FBWebDialogHandler handler);

		[Static, Export ("presentRequestsDialogModallyWithSession:message:title:parameters:handler:friendCache:")]
		void PresentRequestsDialogModally ([NullAllowed] FBSession session, string message, string title, [NullAllowed] NSDictionary parameters, [NullAllowed] FBWebDialogHandler handler, FBFrictionlessRecipientCache friendCache);

		[Static, Export ("presentFeedDialogModallyWithSession:parameters:handler:")]
		void PresentFeedDialogModally ([NullAllowed] FBSession session, [NullAllowed] NSDictionary parameters, [NullAllowed] FBWebDialogHandler handler);
	}

	interface IFBWebDialogsDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface FBWebDialogsDelegate {

		[Export ("webDialogsWillPresentDialog:parameters:session:")]
		void WillPresentDialog (string dialog, NSMutableDictionary parameters, FBSession session);

		[Export ("webDialogsDialog:parameters:session:shouldAutoHandleURL:")]
		void ShouldAutoHandleURL (string dialog, NSMutableDictionary parameters, FBSession session, NSUrl url);

		[Export ("webDialogsWillDismissDialog:parameters:session:result:url:error:")]
		void WillDismissDialog (string dialog, NSMutableDictionary parameters, FBSession session, FBWebDialogResult result, out NSUrl url, out NSError error);
	}

	#region Old Facebook Apis

	[BaseType (typeof (NSObject))]
	interface Facebook {

		[Export ("accessToken")]
		string AccessToken { get; set;  }

		[Export ("expirationDate")]
		NSDate ExpirationDate { get; set;  }

		[Export ("sessionDelegate"), NullAllowed]
		NSObject WeakSessionDelegate { get; set;  }

		[Wrap ("WeakSessionDelegate")]
		FBSessionDelegate Delegate { get; set; }

		[Export ("urlSchemeSuffix")]
		string UrlSchemeSuffix { get; set;  }

		[Export ("initWithAppId:andDelegate:"), PostGet ("WeakSessionDelegate")]
		IntPtr Constructor (string appId, FBSessionDelegate del);

		[Export ("initWithAppId:urlSchemeSuffix:andDelegate:"), PostGet ("WeakSessionDelegate")]
		IntPtr Constructor (string appId, string urlSchemeSuffix, FBSessionDelegate dele);

		[Export ("authorize:")]
		void Authorize (string [] permissions);

		[Export ("extendAccessToken")]
		void ExtendAccessToken();

		[Export ("extendAccessTokenIfNeeded")]
		void ExtendAccessTokenIfNeeded();

		[Export ("shouldExtendAccessToken")]
		bool ShouldExtendAccessToken();

		[Export ("handleOpenURL:")]
		bool HandleOpenURL (NSUrl url);

		[Export ("logout")]
		void Logout ();

		[Export ("requestWithParams:andDelegate:")]
		FBRequest Request (NSMutableDictionary parameters, FBRequestDelegate del);

		[Export ("requestWithMethodName:andParams:andHttpMethod:andDelegate:")]
		FBRequest Request (string methodName, NSMutableDictionary parameters, string httpMethod, FBRequestDelegate del);

		[Export ("requestWithGraphPath:andDelegate:")]
		FBRequest GraphRequest (string graphPath, FBRequestDelegate del);

		[Export ("requestWithGraphPath:andParams:andDelegate:")]
		FBRequest GraphRequest (string graphPath, NSMutableDictionary parameters, FBRequestDelegate del);

		[Export ("requestWithGraphPath:andParams:andHttpMethod:andDelegate:")]
		FBRequest GraphRequest (string graphPath, NSMutableDictionary parameters, string httpMethod, FBRequestDelegate del);

		[Export ("dialog:andDelegate:")]
		void Dialog (string action, FBDialogDelegate del);

		[Export ("dialog:andParams:andDelegate:")]
		void Dialog (string action, NSMutableDictionary parameters, FBDialogDelegate del);

		[Export ("isSessionValid")]
		bool IsSessionValid { get; }
	}

	interface IFBSessionDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface FBSessionDelegate {
		[Export ("fbDidLogin")]
		void DidLogin ();

		[Export ("fbDidNotLogin:")]
		void DidNotLogin (bool cancelled);

		[Export ("fbDidExtendToken:expiresAt")]
		void DidExtendToken(string accessToken, NSDate expiresAt);

		[Export ("fbDidLogout")]
		void DidLogout ();

		[Export ("fbSessionInvalidated")]
		void SessionInvalidated ();
	}

	interface IFBRequestDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface FBRequestDelegate {
		[Export ("requestLoading:")]
		void RequestLoading (FBRequest request);

		[Export ("request:didReceiveResponse:")]
		void ReceivedResponse (FBRequest request, NSUrlResponse response);

		[Export ("request:didFailWithError:")]
		void FailedWithError (FBRequest request, NSError error);

		[Export ("request:didLoad:")]
		void RequestLoaded (FBRequest request, NSObject result);

		[Export ("request:didLoadRawResponse:")]
		void LoadedRawResponse (FBRequest request, NSData data);
	}

	[BaseType (typeof (UIView))]
	interface FBDialog {
		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set;  }

		[Wrap ("WeakDelegate")]
		FBDialogDelegate Delegate { get; set; }

		[Export ("params")]
		NSMutableDictionary Parameters { get; set;  }

		[Export ("getStringFromUrl:needle:")]
		string GetString (string url, string needle );

		[Export ("initWithURL:params:delegate:")]
		IntPtr Constructor (string url, NSMutableDictionary parameters , FBDialogDelegate del);

		[Export ("show")]
		void Show ();

		[Export ("load")]
		void Load ();

		[Export ("loadURL:get:")]
		void LoadUrl (string url, NSDictionary getParams);

		[Export ("dismissWithSuccess:animated:")]
		void Dismiss (bool success, bool animated);

		[Export ("dismissWithError:animated:")]
		void Dismiss (NSError error, bool animated);

		[Export ("dialogWillAppear")]
		void DialogWillAppear ();

		[Export ("dialogWillDisappear")]
		void DialogWillDisappear ();

		[Export ("dialogDidSucceed:")]
		void DialogDidSucceed (NSUrl url);

		[Export ("dialogDidCancel:")]
		void DialogDidCancel (NSUrl url);
	}

	interface IFBDialogDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface FBDialogDelegate {
		[Export ("dialogDidComplete:")]
		void Completed (FBDialog dialog);

		[Export ("dialogCompleteWithUrl:")]
		void CompletedWithUrl (NSUrl url);

		[Export ("dialogDidNotCompleteWithUrl:")]
		void NotCompletedWithUrl (NSUrl url);

		[Export ("dialogDidNotComplete:")]
		void NotCompleted (FBDialog dialog);

		[Export ("dialog:didFailWithError:")]
		void Failed (FBDialog dialog, NSError error);

		[Export ("dialog:shouldOpenURLInExternalBrowser:")]
		bool ShouldOpenUrl (FBDialog dialog, NSUrl url);

	}
	#endregion
}