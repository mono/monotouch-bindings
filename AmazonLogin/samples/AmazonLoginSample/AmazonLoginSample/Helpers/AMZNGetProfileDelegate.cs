using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Amazon.Login;

namespace AmazonLoginSample
{
	// Class that handles AIMobileLib.GetProfile success/failure
	public class AMZNGetProfileDelegate : AIAuthenticationDelegate
	{
		MainViewController vc;

		public AMZNGetProfileDelegate (MainViewController vc)
		{
			this.vc = vc;
		}

		public override void RequestDidSucceed (ApiResult apiResult)
		{
			// If request succeded we retrieve the results from our request
			var name = (NSString) apiResult["name"];
			var email = (NSString) apiResult["email"];
			var userId = (NSString) apiResult["user_id"];
			var postalCode = (NSString) apiResult["postal_code"];

			var dvc = new DVCDetails (name, email, userId, postalCode);
			vc.NavigationController.PushViewController (dvc, true);
		}

		public override void RequestDidFail (ApiError errorResponse)
		{
			// Get Profile request failed for profile scope.

			// If error code = kAIApplicationNotAuthorized,
			// allow user to log in again.

			if (errorResponse.Error.Code == AIErrorCode.ApplicationNotAuthorized)
				InvokeOnMainThread (()=> new UIAlertView ("Error", "App Not Authorized: " + errorResponse.Error.Message, null, "Ok", null).Show ());

			else {
				// Handle other errors
				InvokeOnMainThread (()=> new UIAlertView ("Error", errorResponse.Error.Message, null, "Ok", null).Show ());
			} 
		}
	}
}

