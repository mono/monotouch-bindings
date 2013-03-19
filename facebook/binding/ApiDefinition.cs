//
// ApiDefinition.cs: Bindings to the Facebook iOS SDK.
//
//	Authors:
//		Miguel de Icaza (miguel@xamarin.com)
//		Alex Soto 		(alex.soto@xamarin.com)
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
		FBAccessTokenData CreateToken (string accessToken, [NullAllowed] string [] permissions, NSDate expirationDate, FBSessionLoginType loginType, NSDate refreshDate);
		
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
	}

	[BaseType (typeof (NSObject))]
	interface FBCacheDescriptor 
	{
		[Export("prefetchAndCacheForSession:")]
		void PrefetchAndCacheForSession (FBSession session);
	}

	[BaseType (typeof (NSError))]
	[Category]
	interface FBError 
	{
		[Field ("FacebookSDKDomain", "__Internal")]
		NSString FacebookSDKDomain { get; }
		
		[Field ("FBErrorInnerErrorKey", "__Internal")]
		NSString InnerErrorKey { get; }
		
		[Field ("FBErrorParsedJSONResponseKey", "__Internal")]
		NSString ParsedJSONResponseKey { get; }
		
		[Field ("FBErrorHTTPStatusCodeKey", "__Internal")]
		NSString HTTPStatusCodeKey { get; }
		
		[Field ("FBErrorSessionKey", "__Internal")]
		NSString SessionKey { get; }
		
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
		
		[Field ("FBErrorNativeDialogReasonKey", "__Internal")]
		NSString NativeDialogReasonKey { get; }
		
		[Field ("FBErrorNativeDialogNotSupported", "__Internal")]
		NSString NativeDialogNotSupported { get; }
		
		[Field ("FBErrorNativeDialogInvalidForSession", "__Internal")]
		NSString NativeDialogInvalidForSession { get; }
		
		[Field ("FBErrorNativeDialogCantBeDisplayed", "__Internal")]
		NSString NativeDialogCantBeDisplayed { get; }
		
		[Field ("FBErrorInsightsReasonKey", "__Internal")]
		NSString InsightsReasonKey { get; }
		
		[Field ("FBInvalidOperationException", "__Internal")]
		NSString InvalidOperationException { get; }

		[Static, Export ("fberrorCategory")]
		FBErrorCategory FberrorCategory { get; }

		[Static, Export ("fberrorShouldNotifyUser")]
		bool FberrorShouldNotifyUser { get; }

		[Static, Export ("fberrorUserMessage", ArgumentSemantic.Copy)]
		string FberrorUserMessage { get; }
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
		
		[Export("selection")] [Internal]
		IntPtr Selection_ { get; }
		
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
	
	[BaseType (typeof (FBViewControllerDelegate))]
	[Model]
	interface FBFriendPickerDelegate 
	{
		[Export("friendPickerViewControllerDataDidChange:"), EventArgs("FBFriendPickerChange")]
		void DataDidChange (FBFriendPickerViewController friendPicker);
		
		[Export("friendPickerViewControllerSelectionDidChange:"), EventArgs("FBFriendPickerChange")]
		void SelectionDidChange (FBFriendPickerViewController friendPicker);
		
		[Export("friendPickerViewController:shouldIncludeUser:"), DelegateName("FBFriendPickerCondition"), DefaultValue("true")]
		bool ShouldIncludeUser (FBFriendPickerViewController friendPicker, FBGraphUser user);
		
		[Export("friendPickerViewController:handleError:"), EventArgs("FBFriendPickerError")]
		void HandleError (FBFriendPickerViewController friendPicker, NSError error);
	}
	
	[BaseType (typeof (FBGraphObject))]
	interface FBGraphLocation
	{
		[Export("street")]
		string Street { get; set; }
		
		[Export("city")]
		string City { get; set; }
		
		[Export("state")]
		string State { get; set; }
		
		[Export("country")]
		string Country { get; set; }
		
		[Export("zip")]
		string Zip { get; set; }
		
		[Export("latitude")]
		NSNumber Latitude { get; set; }
		
		[Export("longitude")]
		NSNumber Longitude { get; set; }
		
		// FBGraphObject Model Properties and Methods
		
		[Export("count")] [New]
		uint Count { get; }
		
		[Export("objectForKey:")] [New]
		NSObject ObjectForKey (NSObject aKey);
		
		[Export("keyEnumerator")]
		NSEnumerator KeyEnumerator { get; }
		
		[Export("removeObjectForKey:")]
		NSObject RemoveObjectForKey (NSObject aKey);
		
		[Export("setObject:forKey:")]
		void SetObject (NSObject anObject, NSObject aKey);
	}
	
	[BaseType (typeof (NSMutableDictionary))]
	interface FBGraphObject
	{
		[Static]
		[Export("graphObject")]
		FBGraphObject GraphObject ();
		
		[Static]
		[Export("graphObjectWrappingDictionary:")]
		FBGraphObject GraphObject (NSDictionary jsonDictionary);
		
		[Static]
		[Export("isGraphObjectID:")]
		bool IsGraphObjectIDEqual (FBGraphObject anObject, FBGraphObject anotherObject);
	}
	
	[BaseType (typeof (FBGraphObject))]
	interface FBGraphPlace
	{
		[Export("id")]
		string Id { get; set; }
		
		[Export("name")]
		string Name { get; set; }
		
		[Export("category")]
		string Category { get; set; }
		
		[Export("location")] [Internal]
		NSObject Location_ { get; set; }
		
		// FBGraphObject Model Properties and Methods
		
		[Export("count")] [New]
		uint Count { get; }
		
		[Export("objectForKey:")] [New]
		NSObject ObjectForKey (NSObject aKey);
		
		[Export("keyEnumerator")]
		NSEnumerator KeyEnumerator { get; }
		
		[Export("removeObjectForKey:")]
		NSObject RemoveObjectForKey (NSObject aKey);
		
		[Export("setObject:forKey:")]
		void SetObject (NSObject anObject, NSObject aKey);
	}
	
	[BaseType (typeof (FBGraphObject))]
	interface FBGraphUser
	{
		[Export("id")]
		string Id { get; set; }
		
		[Export("name")]
		string Name { get; set; }
		
		[Export("first_name")]
		string FirstName { get; set; }
		
		[Export("middle_name")]
		string MiddleName { get; set; }
		
		[Export("last_name")]
		string LastName { get; set; }
		
		[Export("link")]
		string Link { get; set; }
		
		[Export("username")]
		string Username { get; set; }
		
		[Export("birthday")]
		string Birthday { get; set; }
		
		[Export("location")] [Internal]
		NSObject Location_ { get; set; }
		
		// FBGraphObject Model Properties and Methods
		
		[Export("count")] [New]
		uint Count { get; }
		
		[Export("objectForKey:")] [New]
		NSObject ObjectForKey (NSObject aKey);
		
		[Export("keyEnumerator")]
		NSEnumerator KeyEnumerator { get; }
		
		[Export("removeObjectForKey:")]
		NSObject RemoveObjectForKey (NSObject aKey);
		
		[Export("setObject:forKey:")]
		void SetObject (NSObject anObject, NSObject aKey);
	}

	[BaseType (typeof (NSObject))]
	interface FBInsights
	{
		[Notification]
		[Field ("FBInsightsLoggingResultNotification", "__Internal")]
		NSString FBInsightsLoggingResultNotification { get; }
		
		[Static, Export ("appVersion")]
		string AppVersion { get; set; }
		
//		[Static, Export ("setAppVersion:")]
//		void SetAppVersion (string appVersion);
		
		[Static, Export ("logPurchase:currency:")]
		void LogPurchase (double purchaseAmount, string currency);
		
		[Static, Export ("logPurchase:currency:parameters:")]
		void LogPurchase (double purchaseAmount, string currency, NSDictionary parameters);
		
		[Static, Export ("logPurchase:currency:parameters:session:")]
		void LogPurchase (double purchaseAmount, string currency, NSDictionary parameters, FBSession session);
		
		[Static, Export ("logConversionPixel:valueOfPixel:")]
		void LogConversionPixel (string pixelId, double value);
		
		[Static, Export ("logConversionPixel:valueOfPixel:session:")]
		void LogConversionPixel (string pixelId, double value, FBSession session);
		
		[Static, Export ("flushBehavior")]
		FBInsightsFlushBehavior FlushBehavior { get; set; }
		
//		[Static, Export ("setFlushBehavior:")]
//		void SetFlushBehavior (FBInsightsFlushBehavior flushBehavior);
		
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
		
		[Export("initWithReadPermissions:"),PostGet("ReadPermissions")]
		IntPtr Constructor (string [] readPermissions);
		
		[Export("initWithPublishPermissions:defaultAudience:"),PostGet("PublishPermissions")]
		IntPtr Constructor (string [] publishPermissions, FBSessionDefaultAudience defaultAudience);
		
		[Wrap ("WeakDelegate")]
		FBLoginViewDelegate Delegate { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface FBLoginViewDelegate 
	{
		[Export("loginViewShowingLoggedInUser:"), EventArgs ("FBLoginViewLogged")]
		void ShowingLoggedInUser (FBLoginView loginView);
		
		[Export("loginViewFetchedUserInfo:user:"), EventArgs ("FBLoginViewUserInfo")]
		void FetchedUserInfo (FBLoginView loginView, FBGraphUser user);
		
		[Export("loginViewShowingLoggedOutUser:"), EventArgs ("FBLoginViewLogged")]
		void ShowingLoggedOutUser (FBLoginView loginView);

		[Export("loginView:handleError:"), EventArgs ("FBLoginViewError")]
		void HandleError (FBLoginView loginView, NSError error);
	}
	
	delegate void FBShareDialogHandler (FBNativeDialogResult result, NSError error);
	
	[BaseType (typeof (NSObject))]
	interface FBNativeDialogs 
	{
		[Static]
		[Export("presentShareDialogModallyFrom:initialText:image:url:handler:")]
		bool PresentShareDialogModallyFrom(UIViewController viewController, string initialText, UIImage image, NSUrl url, FBShareDialogHandler handler);
		
		[Static]
		[Export("presentShareDialogModallyFrom:initialText:images:urls:handler:")]
		bool PresentShareDialogModallyFrom(UIViewController viewController, string initialText, UIImage [] images, NSUrl [] urls, FBShareDialogHandler handler);
		
		[Static]
		[Export("presentShareDialogModallyFrom:session:initialText:images:urls:handler:")]
		bool PresentShareDialogModallyFrom(UIViewController viewController, FBSession session, string initialText, UIImage [] images, NSUrl [] urls, FBShareDialogHandler handler);
		
		[Static]
		[Export("canPresentShareDialogWithSession:")]
		bool CanPresentShareDialogWithSession (FBSession session);
	}
	
	[BaseType (typeof (FBGraphObject))]
	interface FBOpenGraphAction
	{
		[Export("id")]
		string Id { get; set; }
		
		[Export("start_time")]
		string StartTime { get; set; }
		
		[Export("end_time")]
		string EndTime { get; set; }
		
		[Export("publish_time")]
		string PublishTime { get; set; }
		
		[Export("created_time")]
		string CreatedTime { get; set; }
		
		[Export("expires_time")]
		string ExpiresTime { get; set; }
		
		[Export("ref")]
		string Ref { get; set; }
		
		[Export("message")]
		string Message { get; set; }
		
		[Export("place")] [Internal]
		NSObject Place_ { get; set; }
		
		[Export("tags")]
		NSObject [] Tags { get; set; }
		
		[Export("image")]
		NSObject [] Image { get; set; }
		
		[Export("from")] [Internal]
		NSObject From_ { get; set; }
		
		[Export("likes")]
		NSObject [] Likes { get; set; }
		
		[Export("application")] [Internal]
		NSObject Application_ { get; set; }
		
		[Export("comments")]
		NSArray Comments { get; set; }
		
		// FBGraphObject Model Properties and Methods
		
		[Export("count")] [New]
		uint Count { get; }
		
		[Export("objectForKey:")] [New]
		NSObject ObjectForKey (NSObject aKey);
		
		[Export("keyEnumerator")]
		NSEnumerator KeyEnumerator { get; }
		
		[Export("removeObjectForKey:")]
		NSObject RemoveObjectForKey (NSObject aKey);
		
		[Export("setObject:forKey:")]
		void SetObject (NSObject anObject, NSObject aKey);
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
		
		[Export("selection")] [Internal]
		IntPtr Selection_ { get; }
		
		[Export("clearSelection")]
		void ClearSelection ();
		
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
	
	[BaseType (typeof (FBViewControllerDelegate))]
	[Model]
	interface FBPlacePickerDelegate 
	{
		[Export("placePickerViewControllerDataDidChange:"), EventArgs("FBPlacePickerChange")]
		void DataDidChange (FBPlacePickerViewController placePicker);
		
		[Export("placePickerViewControllerSelectionDidChange:"), EventArgs("FBPlacePickerChange")]
		void SelectionDidChange (FBPlacePickerViewController placePicker);
		
		[Export("placePickerViewController:shouldIncludePlace:"), DelegateName("FBPlacePickerCondition"), DefaultValue("true")]
		bool ShouldIncludeUser (FBPlacePickerViewController placePicker, FBGraphPlace place);
		
		[Export("placePickerViewController:handleError:"), EventArgs("FBPlacePickerError")]
		void HandleError (FBPlacePickerViewController placePicker, NSError error);
	}
	
	[BaseType (typeof (UIView))]
	interface FBProfilePictureView 
	{
		[Export ("profileID", ArgumentSemantic.Copy)]
		string ProfileID { get; set; }
		
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
		IntPtr Constructor ([NullAllowed] FBSession session, string graphPath, FBGraphObject graphObject);
		
		[Export("initWithSession:restMethod:parameters:HTTPMethod:")]
		IntPtr Constructor ([NullAllowed] FBSession session, string restMethod, [NullAllowed] NSDictionary parameters, [NullAllowed] string HTTPMethod, bool fakearg);
		
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
		FBGraphObject GraphObject { get; set; }
		
		[Export ("startWithCompletionHandler:")]
		FBRequestConnection Start (FBRequestHandler handler);
		
		[Static]
		[Export ("requestForMe")]
		FBRequest GetRequestForMe { get; }
		
		[Static]
		[Export ("requestForMyFriends")]
		FBRequest GetRequestForMyFriends { get; }
		
		[Static]
		[Export ("requestForUploadPhoto:")]
		FBRequest RequestForUploadPhoto (UIImage photo);
		
		[Static]
		[Export ("requestForPostStatusUpdate:")]
		FBRequest RequestForPostStatusUpdate (string message);
		
		[Static]
		[Export ("requestForPostStatusUpdate:place:tags:")]
		FBRequest RequestForPostStatusUpdate (string message, [NullAllowed] NSObject place, NSObject [] tags);
		
		[Static]
		[Export ("requestForPlacesSearchAtCoordinate:radiusInMeters:resultsLimit:searchText:")]
		FBRequest RequestForPlacesSearchAtCoordinate (CLLocationCoordinate2D coordinate, int radius, int limit, string searchText);
		
		[Static]
		[Export ("requestForGraphPath:")]
		FBRequest RequestForGraphPath (string graphPath);
		
		[Static]
		[Export ("requestForPostWithGraphPath:graphObject:")]
		FBRequest RequestForPostWithGraphPath (string graphPath, FBGraphObject graphObject);
		
		[Static]
		[Export ("requestWithGraphPath:parameters:HTTPMethod:")]
		FBRequest RequestWithGraphPath (string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string HTTPMethod);

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
		
		[Export ("urlRequest")]
		NSMutableUrlRequest UrlRequest { get; set; }
		
		[Export ("urlResponse")]
		NSHttpUrlResponse UrlResponse { get; }
		
		[Export("addRequest:completionHandler:")]
		void AddRequest (FBRequest request, FBRequestHandler handler);
		
		[Export("addRequest:completionHandler:batchEntryName:")]
		void AddRequest (FBRequest request, FBRequestHandler handler, string name);
		
		[Export("start")]
		void Start ();
		
		[Export("cancel")]
		void Cancel ();
		
		[Static]
		[Export ("startForMeWithCompletionHandler:")]
		FBRequestConnection StartForMeWithCompletionHandler (FBRequestHandler handler);
		
		[Static]
		[Export ("startForMyFriendsWithCompletionHandler:")]
		FBRequestConnection StartForMyFriendsWithCompletionHandler (FBRequestHandler handler);
		
		[Static]
		[Export ("startForUploadPhoto:completionHandler:")]
		FBRequestConnection StartForUploadPhoto (UIImage photo, FBRequestHandler handler);
		
		[Static]
		[Export ("startForPostStatusUpdate:completionHandler:")]
		FBRequestConnection StartForPostStatusUpdate (string message, FBRequestHandler handler);
		
		[Static]
		[Export ("startForPostStatusUpdate:place:tags:completionHandler:")]
		FBRequestConnection StartForPostStatusUpdate (string message, [NullAllowed] NSObject place, NSObject [] tags, FBRequestHandler handler);
		
		[Static]
		[Export ("startForPlacesSearchAtCoordinate:radiusInMeters:resultsLimit:searchText:completionHandler:")]
		FBRequestConnection StartForPlacesSearchAtCoordinate (CLLocationCoordinate2D coordinate, int radius, int limit, string searchText, FBRequestHandler handler);
		
		[Static]
		[Export ("startWithGraphPath:completionHandler:")]
		FBRequestConnection StartWithGraphPath (string graphPath, FBRequestHandler handler);
		
		[Static]
		[Export ("startForPostWithGraphPath:graphObject:completionHandler:")]
		FBRequestConnection StartForPostWithGraphPath (string graphPath, FBGraphObject graphObject, FBRequestHandler handler);
		
		[Static]
		[Export ("startWithGraphPath:parameters:HTTPMethod:completionHandler:")]
		FBRequestConnection StartWithGraphPath (string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string HTTPMethod, FBRequestHandler handler);
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
		NSString FBSessionDidSetActiveSessionNotification { get; }
		
		[Notification]
		[Field ("FBSessionDidUnsetActiveSessionNotification", "__Internal")]
		NSString FBSessionDidUnsetActiveSessionNotification { get; }
		
		[Notification]
		[Field ("FBSessionDidBecomeOpenActiveSessionNotification", "__Internal")]
		NSString FBSessionDidBecomeOpenActiveSessionNotification { get; }
		
		[Notification]
		[Field ("FBSessionDidBecomeClosedActiveSessionNotification", "__Internal")]
		NSString FBSessionDidBecomeClosedActiveSessionNotification { get; }

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

		[Export ("requestNewReadPermissions:completionHandler:")]
		void RequestNewReadPermissions (string [] readPermissions, [NullAllowed] FBSessionRequestPermissionResultHandler handler);

		[Export ("requestNewPublishPermissions:defaultAudience:completionHandler:")]
		void RequestNewPublishPermissions (string [] writePermissions, FBSessionDefaultAudience defaultAudience, [NullAllowed] FBSessionRequestPermissionResultHandler handler);

		[Export ("handleOpenURL:")]
		bool HandleOpenURL (NSUrl url);
		
		[Export ("handleDidBecomeActive")]
		void HandleDidBecomeActive ();
		
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
		
		[Static]
		[Export ("defaultAppID")]
		string DefaultAppID { get; set; }

		[Static]
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
	}

	delegate void FBInstallResponseDataHandler (FBGraphObject response, NSError error);
	
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

		[Field ("FBLoggingBehaviorInsights", "__Internal")]
		NSString LoggingBehaviorInsights { get; }

		[Field ("FBLoggingBehaviorDeveloperErrors", "__Internal")]
		NSString LoggingBehaviorDeveloperErrors { get; }

		[Static]
		[Export ("loggingBehavior")]
		NSSet LoggingBehavior { get; set; }
		
		[Static]
		[Export ("shouldAutoPublishInstall")]
		bool ShouldAutoPublishInstall { get; set; }
		
		[Static]
		[Export ("publishInstall:")]
		bool PublishInstall ([NullAllowed] string appID);

		[Static]
		[Export ("publishInstall:withHandler:")]
		bool PublishInstall ([NullAllowed] string appID, [NullAllowed] FBInstallResponseDataHandler handler);
	
		[Static]
		[Export ("clientToken")]
		string ClientToken { get; set; }
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
	
	[BaseType (typeof (FBViewControllerDelegate))]
	[Model]
	interface FBUserSettingsDelegate 
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
	
	[BaseType (typeof (NSObject))]
	[Model]
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

		[Static, Export ("presentRequestsDialogModallyWithSession:message:title:parameters:handler:")]
		void PresentRequestsDialogModally ([NullAllowed] FBSession session, string message, string title, [NullAllowed] NSDictionary parameters, [NullAllowed] FBWebDialogHandler handler);

		[Static, Export ("presentFeedDialogModallyWithSession:parameters:handler:")]
		void PresentFeedDialogModally ([NullAllowed] FBSession session, [NullAllowed] NSDictionary parameters, [NullAllowed] FBWebDialogHandler handler);
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
	
	[BaseType (typeof (NSObject))]
	[Model]
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

	[BaseType (typeof (NSObject))]
	[Model]
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

	[BaseType (typeof (NSObject))]
	[Model]
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

