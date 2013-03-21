using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using DropBoxSync.iOS;

namespace DropBoxSyncSampleMTD
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		public UINavigationController navController;
		DVCLogin loginController;

		// TODO: Get your own App Key and Secret from https://www.dropbox.com/developers/apps
		// TODO: Also don't forget to set CFBundleURLSchemes to db-YOUR_APP_KEY in your Info.plist
		const string appKey = "YOUR_APP_KEY";
		const string appSecret = "YOUR_APP_SECRET";

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// The account manager stores all the account info. Create this when your app launches
			var accountMgr = new DBAccountManager (key: appKey, secret: appSecret);
			DBAccountManager.SetSharedManager (accountMgr);
			var account = accountMgr.LinkedAccount;

			if (account != null) {
				var filesystem = new DBFilesystem (account);
				DBFilesystem.SetSharedFilesystem (filesystem);
			}

			window = new UIWindow (UIScreen.MainScreen.Bounds);

			loginController = new DVCLogin ();
			navController = new UINavigationController (loginController);
			window.RootViewController = navController;
			window.MakeKeyAndVisible ();
			
			return true;
		}

		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			var account = DBAccountManager.SharedManager.HandleOpenURL (url);
			if (account != null) {
				var filesystem = new DBFilesystem (account);
				DBFilesystem.SetSharedFilesystem (filesystem);
				Console.WriteLine ("App linked successfully!");
				return true;
			}
			Console.WriteLine ("App is not linked");
			return false;
		}

	}
}

