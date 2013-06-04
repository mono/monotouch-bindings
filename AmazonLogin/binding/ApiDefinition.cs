using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Amazon.Login
{
	[BaseType (typeof (NSObject), Name = "APIResult")]
	interface ApiResult {

		[Export ("result", ArgumentSemantic.Retain)]
		NSObject Result { get; set; }

		[Export ("api")]
		ApiChooser Api { get; set; }

		[Export ("initResultForAPI:andResult:")]
		IntPtr Constructor (ApiChooser api, NSObject result);
	}
	
	[BaseType (typeof (NSObject), Name = "APIError")]
	interface ApiError {

		[Export ("error", ArgumentSemantic.Retain)]
		AIError Error { get; set; }

		[Export ("api")]
		ApiChooser Api { get; set; }

		[Export ("initErrorForAPI:andError:")]
		IntPtr Constructor (ApiChooser api, NSObject errorObject);
	}


	[BaseType (typeof (NSObject))]
	[Protocol] 
	[Model]
	interface AIAuthenticationDelegate {
		[Abstract]
		[Export ("requestDidSucceed:")]
		void RequestDidSucceed (ApiResult apiResult);

		[Abstract]
		[Export ("requestDidFail:")]
		void RequestDidFail (ApiError errorResponse);
	}

	[Static]
	interface AIErrorCons {

		[Field ("kAINoError", "__Internal")] [Internal]
		IntPtr NoError { get; }

		[Field ("kAIApplicationNotAuthorized", "__Internal")] [Internal]
		IntPtr ApplicationNotAuthorized { get; }

		[Field ("kAIServerError", "__Internal")] [Internal]
		IntPtr ServerError { get; }

		[Field ("kAIErrorUserInterrupted", "__Internal")] [Internal]
		IntPtr ErrorUserInterrupted { get; }

		[Field ("kAIAccessDenied", "__Internal")] [Internal]
		IntPtr AccessDenied { get; }

		[Field ("kAIDeviceError", "__Internal")] [Internal]
		IntPtr DeviceError { get; }

		[Field ("kAIInvalidInput", "__Internal")] [Internal]
		IntPtr InvalidInput { get; }

		[Field ("kAINetworkError", "__Internal")] [Internal]
		IntPtr NetworkError { get; }

		[Field ("kAIUnauthorizedClient", "__Internal")] [Internal]
		IntPtr UnauthorizedClient { get; }

		[Field ("kAIInternalError", "__Internal")] [Internal]
		IntPtr InternalError { get; }
	}
	
	[BaseType (typeof (NSObject))]
	interface AIError {

		[Export ("message", ArgumentSemantic.Retain)]
		string Message { get; set; }

		[Export ("code")] [Internal]
		uint Code_ { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface AIMobileLib {

		[Field ("kForceRefresh", "__Internal")] [Internal]
		NSString ForceRefresh { get; }

		[Static]
		[Export ("authorizeUserForScopes:delegate:")]
		void AuthorizeUser (string [] scopes, AIAuthenticationDelegate authenticationDelegate);

		[Static]
		[Export ("getAccessTokenForScopes:withOverrideParams:delegate:")]
		void GetAccessToken (string [] scopes, NSDictionary overrideParams, AIAuthenticationDelegate authenticationDelegate);

		[Static]
		[Export ("clearAuthorizationState:")]
		void ClearAuthorizationState (AIAuthenticationDelegate authenticationDelegate);

		[Static]
		[Export ("getProfile:")]
		void GetProfile (AIAuthenticationDelegate authenticationDelegate);

		[Static]
		[Export ("handleOpenURL:sourceApplication:")]
		bool HandleOpenUrl (NSUrl url, string sourceApplication);
	}
}

