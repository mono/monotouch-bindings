using Foundation;
using UIKit;

using Facebook.CoreKit;

namespace HelloFacebook
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		string appId = "Your_Id_Here";
		string appName = "Your_App_Display_Name";

		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method

			// This is false by default,
			// If you set true, you can handle the user profile info once is logged into FB with the Profile.Notifications.ObserveDidChange notification,
			// If you set false, you need to get the user Profile info by hand with a GraphRequest
			Profile.EnableUpdatesOnAccessTokenChange (true);
			Settings.AppID = appId;
			Settings.DisplayName = appName;

			// This method verifies if you have been logged into the app before, and keep you logged in after you reopen or kill your app.
			return ApplicationDelegate.SharedInstance.FinishedLaunching (application, launchOptions);
		}

		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			// We need to handle URLs by passing them to their own OpenUrl in order to make the SSO authentication works.
			return ApplicationDelegate.SharedInstance.OpenUrl (application, url, sourceApplication, annotation);
		}
	}
}


