//
// StructsAndEnums.cs: Bindings to the Facebook iOS SDK.
//
//	Authors:
//		Miguel de Icaza (miguel@xamarin.com)
//		Alex Soto 		(alex.soto@xamarin.com)
//
//

using System;

namespace MonoTouch.FacebookConnect
{
	public enum FBErrorCode
	{
		Invalid = 0,
		OperationCancelled,
		LoginFailedOrCancelled,
		RequestConnectionApi,
		ProtocolMismatch,
		HTTPError,
		NonTextMimeTypeReturned,
		NativeDialog,
		Insights,
		SystemAPI,
		PublishInstallResponse,
	}
	
	public enum FBErrorCategory
	{
		Invalid                      = 0,
		Retry          				 = 1,
		AuthenticationReopenSession  = 2,
		Permissions                  = 3,
		Server                       = 4,
		Throttling                   = 5,
		UserCancelled                = 6,
		FacebookOther                = -1,
		BadRequest                   = -2,
	}

	public enum FBInsightsFlushBehavior
	{
		Auto,
		ExplicitOnly
	}
	
	public enum FBFriendSortOrdering
	{
		ByFirstName,
		ByLastName
	}
	
	public enum FBFriendDisplayOrdering
	{
		ByFirstName,
		ByLastName
	}
	
	public enum FBNativeDialogResult
	{
		Succeeded,
		Cancelled,
		Error
	}
	
	public enum FBProfilePictureCropping
	{
		Square = 0,
		Original = 1
	}
	
	public enum FBSessionState 
	{
		Created = 0,
		CreatedTokenLoaded = 1,
		CreatedOpening = 2,
		Open = 1 | (1 << 9),
		OpenTokenExtended = 2 | (1 << 9),
		ClosedLoginFailed = 1 | (1 << 8),
		Closed = 2 | (1 << 8)
	}
	
	public enum FBSessionLoginBehavior 
	{
		WithFallbackToWebView = 0, 
		WithNoFallbackToWebView = 1, 
		ForcingWebView = 2, 
		UseSystemAccountIfPresent = 3
	}
	
	public enum FBSessionDefaultAudience 
	{
		None = 0,
		OnlyMe = 10,
		Friends = 20,
		Everyone = 30
	}
	
	public enum FBSessionLoginType 
	{
		None = 0,
		SystemAccount  = 1,
		FacebookApplication = 2,
		FacebookViaSafari  = 3,
		WebView = 4,
		TestUser = 5
	}

	public enum FBWebDialogResult
	{
		Completed,
		NotCompleted
	}

	#region Old Facebook Api
	public enum FBRequestState {
		Ready, 
		Loading, 
		Complete, 
		Error
	}
	#endregion

}

