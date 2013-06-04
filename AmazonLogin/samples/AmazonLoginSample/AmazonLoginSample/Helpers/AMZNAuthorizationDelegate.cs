using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Amazon.Login;

namespace AmazonLoginSample
{
	// Class that hanldes Authentication Success/Failure
	public class AMZNAuthorizationDelegate : AIAuthenticationDelegate
	{
		MainViewController vc;
		public AMZNAuthorizationDelegate (MainViewController vc)
		{
			this.vc = vc;
		}

		public override void RequestDidSucceed (ApiResult apiResult)
		{
			// Your code after the user authorizes application for
			// requested scopes.

			// Load new view controller with user identifying information
			// as the user is now successfully logged in.
			AIMobileLib.GetProfile (new AMZNGetProfileDelegate (vc));
		}

		public override void RequestDidFail (ApiError errorResponse)
		{
			// Your code when the authorization fails.
			InvokeOnMainThread (()=> new UIAlertView ("User Authorization Failed", errorResponse.Error.Message, null, "Ok", null).Show ());
		}
	}
}

