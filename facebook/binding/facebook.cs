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

	delegate void FBSessionStateHandler (FBSession session, FBSessionState status, NSError error);

	delegate void FBSessionReauthorizeResultHandler (FBSession session, NSError error);

	[BaseType (typeof (NSObject))]
	interface FBSession {
		[Static]
		[Export ("openActiveSessionWithReadPermissions:allowLoginUI:completionHandler:")]
		bool OpenActiveSession ([NullAllowed] string[] readPermissions, bool allowLoginUI, FBSessionStateHandler completion);

		[Static]
		[Export ("openActiveSessionWithPublishPermissions:defaultAudience:allowLoginUI:completionHandler:")]
		bool OpenActiveSession (string[] publishPermissions, FBSessionDefaultAudience defaultAudience, bool allowLoginUI, FBSessionStateHandler completion);

		[Static]
		[Export ("openActiveSessionWithAllowLoginUI:")]
		bool OpenActiveSession (bool allowLoginUI);

		[Static]
		[Export ("activeSession")]
		FBSession ActiveSession { get; set; }

		[Static]
		[Export ("defaultAppID")]
		string DefaultAppID { get; set; }

		[Export ("isOpen")]
		bool IsOpen { get; }

		[Export ("accessToken", ArgumentSemantic.Copy)]
		string AccessToken { get; }

		[Export ("handleOpenURL:")]
		bool HandleOpenURL (NSUrl url);

		[Export ("handleDidBecomeActive")]
		void HandleDidBecomeActive ();

		[Export ("close")]
		void Close ();

		[Export ("closeAndClearTokenInformation")]
		void CloseAndClearTokenInformation ();

		[Export ("reauthorizeWithPermissions:behavior:completionHandler:")]
		void ReauthorizeWithPermissions (string[] permissions, FBSessionLoginBehavior behavior, FBSessionReauthorizeResultHandler completion);

		[Export ("reauthorizeWithReadPermissions:completionHandler:")]
		void ReauthorizeWithReadPermissions (string[] permissions, FBSessionReauthorizeResultHandler completion);

		[Export ("reauthorizeWithPublishPermissions:defaultAudience:completionHandler:")]
		void ReauthorizeWithPublishPermissions (string[] permissions, FBSessionDefaultAudience defaultAudience, FBSessionReauthorizeResultHandler completion);
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