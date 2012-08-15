//
// facebook.cs: Bindings to the Facebook IOS SDK.
//
// Authors:
//   Miguel de Icaza (miguel@xamarin.com)
//
//
using System;
using MonoTouch.CoreLocation;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace MonoTouch.FacebookConnect  {

	delegate void FBSessionStateHandler (FBSession session, FBSessionState state, NSError error);
	delegate void FBSessionReauthorizeResultHandler (FBSession session, NSError error);

	[BaseType (typeof (NSObject))]
	interface FBSession {
		[Export ("isOpen")]
		bool IsOpen { get; }

		[Export ("state")]
		FBSessionState State { get; }

		[Export ("appID")]
		string AppID { get; }

		[Export ("urlSchemeSuffix")]
		string UrlSchemeSuffix { get; }

		[Export ("accessToken")]
		string AccessToken { get; }

		[Export ("expirationDate")]
		DateTime ExpirationDate { get; }

		[Export ("permission")]
		string [] Permissions { get; }

//		[Export ("init")]
//		IntPtr Constructor ();

		[Export ("initWithPermissions:")]
		IntPtr Constructor (string [] permissions);

		[Export ("initWithAppID:permissions:urlSchemeSuffix:tokenCacheStrategy:")]
		IntPtr Constructor (string appId, string urlSchemeSuffix, [NullAllowed]FBSessionTokenCachingStrategy strategy);

		[Export ("openWithCompletionHandler:")]
		void Open ([NullAllowed]FBSessionStateHandler handler);

		[Export ("openWithBehavior:completionHandler:")]
		void Open (FBSessionLoginBehavior behavior, [NullAllowed]FBSessionStateHandler handler);

		[Export ("close")]
		void Close ();

		[Export ("closeAndClearTokenInformation")]
		void CloseAndClearTokenInformation ();

		[Export ("reauthorizeWithPermissions:behavior:completionHandler:")]
		void Reauthorize ([NullAllowed]string [] permissions, FBSessionLoginBehavior behavior, FBSessionReauthorizeResultHandler handler);

		[Export ("handleOpenURL:")]
		bool HandleOpenUrl (NSUrl url);

		[Static]
		[Export ("openActiveSessionWithAllowLoginUI:")]
		bool OpenActiveSession(bool allowLoginUI);

		[Static]
		[Export ("openActiveSessionWithPermissions:allowLoginUI:completionHandler:")]
		bool OpenActiveSession([NullAllowed]string [] permissions, bool allowLoginUI, FBSessionStateHandler handler);

		// TODO: Can activeSession, setActiveSession: be merged into a get/set property?
		[Static]
		[Export ("activeSession")]
		FBSession GetActiveSession ();

		[Static]
		[Export ("setActiveSession:")]
		FBSession SetActiveSession (FBSession session);

		// TODO: these, too
		[Static]
		[Export ("setDefaultAppID:")]
		void SetDefaultAppID (string appID);

		[Static]
		[Export ("defaultAppID")]
		string GetDefaultAppID ();
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface FBSessionTokenCachingStrategy {
//		[Export ("init")]
//		IntPtr Constructor ();

		[Export ("initWithUserDefaultTokenInformationKeyName:")]
		IntPtr Constructor ([NullAllowed]string tokenInformationKeyName);

		[Export ("cacheTokenInformation:")]
		void CacheTokenInformation (NSDictionary tokenInformation);

		[Export ("fetchTOkenInformation)]")]
		NSDictionary FetchTokenInformation ();

		[Export ("clearToken")]
		void ClearToken ();

		[Static]
		[Export ("defaultInstance")]
		FBSessionTokenCachingStrategy GetDefaultInstance ();

		[Static]
		[Export ("isValidTokenInformation:")]
		bool IsValidTokenInformation (NSDictionary tokenInformation);

		[Static]
		[Field ("FBTokenInformationTokenKey", "__Internal")]
		NSString FBTokenInformationTokenKey { get; }

		[Static]
		[Field ("FBTokenInformationExpirationDateKey", "__Internal")]
		NSString FBTokenInformationExpirationDateKey { get; }

		[Static]
		[Field ("FBTokenInformationRefreshDateKey", "__Internal")]
		NSString FBTokenInformationRefreshDateKey { get; }

		[Static]
		[Field ("FBTokenInformationUserFBIDKey", "__Internal")]
		NSString FBTokenInformationUserFBIDKey { get; }

		[Static]
		[Field ("FBTokenInformationIsFacebookLoginKey", "__Internal")]
		NSString FBTokenInformationIsFacebookLoginKey { get; }

		[Static]
		[Field ("FBTokenInformationPermissionsKey", "__Internal")]
		NSString FBTokenInformationPermissionsKey { get; }
	}

	delegate void FBRequestHandler(FBRequestConnection connection, NSObject result, NSError error);

	[BaseType (typeof (NSObject))]
	interface FBRequest {
		[Export ("HTTPMethod")]
		string HttpMethod { get; set;  }

		[Export ("graphObject")]
		FBGraphObject GraphObject { get; set; }

		[Export ("graphPath")]
		string GraphPath { get; set; }

                [Export ("parameters")]
                NSMutableDictionary Parameters { get; set; }

		[Export ("restMethod")]
		string RestMethod { get; set; }

		[Export ("session")]
		FBSession Session { get; set; }

		[Export ("initWithSession:graphPath:")]
		IntPtr Constructor([NullAllowed]FBSession session, string graphPath);

		[Export ("initWithSession:graphPath:parameters:HTTPMethod:")]
		IntPtr Constructor([NullAllowed]FBSession session, string graphPath, NSDictionary parameters, string HTTPMethod);

		[Export ("initForPostWithSession:graphPath:graphObject:")]
		IntPtr Constructor([NullAllowed]FBSession session, string graphPath, FBGraphObject graphObject);

		// This constructor overload collides with initWithSession:graphPath:parameters:HTTPMethod:.
                // How on earth can I fix this?
		//
		//[Export ("initWithSession:restMethod:parameters:HTTPMethod:")]
		//IntPtr Constructor([NullAllowed]FBSession session, string restMethod, NSDictionary parameters, string HTTPMethod);

		[Export ("startWithCompletionHandler:")]
		FBRequestConnection Start(FBRequestHandler handler);

		[Static]
		[Export ("requestForMe")]
		FBRequest RequestForMe();

		[Static]
		[Export ("requestForMyFriends")]
		FBRequest RequestForMyFriends();

		[Static]
		[Export ("requestForPlacesSearchAtCoordinate:radiusInMeters:resultsLimit:searchText:")]
		FBRequest RequestForPlacesSearch(CLLocationCoordinate2D coordinate, int radius, int limit, string searchText);

		[Static]
		[Export ("requestForPostStatusUpdate:")]
		FBRequest RequestForPostStatusUpdate(string message);

		[Static]
		[Export ("requestForPostStatusUpdate:place:tags:")]
		// TODO: Replace NSArray with NSFastEnumeration if possible.
		FBRequest RequestForPostStatusUpdate(string message, [NullAllowed]NSObject place, NSArray tags);

		[Static]
		[Export ("requestForPostWithGraphPath:graphObject:")]
		FBRequest RequestForPost(string graphPath, FBGraphObject graphObject);

		[Static]
		[Export ("requestForUploadPhoto:")]
		FBRequest RequestForUploadPhoto(UIImage photo);

		[Static]
		[Export ("requestWithGraphPath:parameters:HTTPMethod:")]
		FBRequest RequestWithGraphPath(string graphPath, NSDictionary parameters, string HTTPMethod);
	}


	// TODO: finish this binding
	[BaseType (typeof(NSObject))]
	interface FBRequestConnection {
		[Export ("initWithTimeout:")]
		IntPtr Constructor(double timeout);

		[Export ("urlRequest")]
		NSMutableUrlRequest UrlRequest { get; set; }

		[Export ("urlResponse")]
		NSHttpUrlResponse UrlResponse { get; set; }

		[Export ("addRequest:completionHandler:")]
		void AddRequest(FBRequest request, FBRequestHandler handler);

		[Export ("addRequest:completionHandler:batchEntryName:")]
		void AddRequest(FBRequest request, FBRequestHandler handler, string name);

		[Export ("cancel")]
		void Cancel();

		[Export ("start")]
		void Start();

		[Static]
		[Export ("startForMeWithCompletionHandler:")]
		FBRequestConnection StartForMe(FBRequestHandler handler);

		[Static]
		[Export ("startForMyFriendsWithCompletionHandler:")]
		FBRequestConnection StartForMyFriends(FBRequestHandler handler);

		[Static]
		[Export ("startForPlacesSearchAtCoordinate:radiusInMeters:resultsLimit:searchText:completionHandler:")]
		FBRequestConnection StartForPlacesSearch(CLLocationCoordinate2D coordinate, int radius, int limit, string searchText, FBRequestHandler handler);

		[Static]
		[Export ("startForPostStatusUpdate:completionHandler:")]
		FBRequestConnection StartForPostStatusUpdate(string message, FBRequestHandler handler);

		[Static]
		[Export ("startForPostStatusUpdate:place:tags:completionHandler:")]
		FBRequestConnection StartForPostStatusUpdate(string message, [NullAllowed]NSObject place, NSArray tags, FBRequestHandler handler);

		[Static]
		[Export ("startForPostWithGraphPath:graphObject:completionHandler:")]
		FBRequestConnection StartForPostWithGraphPath(string graphPath, FBGraphObject graphObject, FBRequestHandler handler);

		[Static]
		[Export ("startForUploadPhoto:completionHandler:")]
		FBRequestConnection StartForUploadPhoto(UIImage photo, FBRequestHandler handler);

		[Static]
		[Export ("startWithGraphPath:completionHandler:")]
		FBRequestConnection StartWithGraphPath(string graphPath, FBRequestHandler handler);

		[Static]
		[Export ("startWithGraphPath:parameters:HTTPMethod:completionHandler:")]
		FBRequestConnection StartWithGraphPath(string graphPath, NSDictionary parameters, string HTTPMethod, FBRequestHandler handler);
	}

	[BaseType (typeof(NSObject))]
	interface FBGraphObject {
	}
}
