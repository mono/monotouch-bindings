//
// facebook.cs: Bindings to the Facebook IOS SDK.
//
// Authors:
//   Miguel de Icaza (miguel@xamarin.com)
//
//
using System;
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

		[Export ("reauthorizeWithPermissions:behavior:completionHandler:")]
		void Reauthorize ([NullAllowed]string [] permissions, FBSessionLoginBehavior behavior, FBSessionReauthorizeResultHandler handler);

		[Export ("handleOpenURL:")]
		bool HandleOpenUrl (NSUrl url);

		[Static]
		[Export ("sessionOpen")]
		FBSession SessionOpen ();

		[Static]
		[Export ("sessionOpenWithPermissions:completionHandler:")]
		FBSession SessionOpen ([NullAllowed]string [] permissions, FBSessionStateHandler handler);


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
	interface FBRequest {
		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set;  }

		[Wrap ("WeakDelegate")]
		FBRequestDelegate Delegate { get; set; }

		[Export ("url")]
		string Url { get; set;  }

		[Export ("httpMethod")]
		string HttpMethod { get; set;  }

		[Export ("params")]
		NSMutableDictionary Parameters { get; set;  }

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
}