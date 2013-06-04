using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Amazon.Login;

namespace AmazonLoginSample
{
	// Class that hanldes Logout Success/Failure
	public class AMZNLogoutDelegate : AIAuthenticationDelegate
	{
		DVCDetails dvc;
		public AMZNLogoutDelegate (DVCDetails dvc)
		{
			this.dvc = dvc;
		}

		public override void RequestDidSucceed (ApiResult apiResult)
		{
			// Your additional logic after the user authorization state is cleared.
			dvc.NavigationController.PopViewControllerAnimated (true);
		}

		public override void RequestDidFail (ApiError errorResponse)
		{
			// Your additional logic after the SDK failed to clear
			// the authorization state.
			InvokeOnMainThread (()=> new UIAlertView ("User Logout Failed", errorResponse.Error.Message, null, "Ok", null).Show ());
		}
	}
}

