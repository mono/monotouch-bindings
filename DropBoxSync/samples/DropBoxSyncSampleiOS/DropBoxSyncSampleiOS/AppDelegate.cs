using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using DropBoxSync.iOS;

namespace DropBoxSyncSampleiOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UINavigationController navController;
		SettingsController settingsController;

		public static AppDelegate SharedDelegate {
			get {
				return (AppDelegate) UIApplication.SharedApplication.Delegate;
			}
		}

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			var accountManager = new DBAccountManager (key: "t3ow4tvu36zlh5s", secret: "w4nmqlk5ul1uiw8");

			DBAccountManager.SetSharedManager (accountManager);
			settingsController = new SettingsController (accountManager);



			var initialControllers = new List<UIViewController>();
			initialControllers.Add (settingsController);
		
			var account = accountManager.LinkedAccount;
			if (account != null) {
				var fileSystem = new DBFilesystem (account);
				var folderController = new FolderListController (fileSystem, DBPath.Root);
				initialControllers.Add (folderController);
			}

			navController = new UINavigationController ();
			navController.ViewControllers = initialControllers.ToArray ();
			window.RootViewController = navController;
			window.BackgroundColor = UIColor.White;

			window.MakeKeyAndVisible ();
			return true;
		}

		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			var account = DBAccountManager.SharedManager.HandleOpenURL (url);

			if (account != null) {
				var fileSystem = new DBFilesystem (account);
				var folderController = new FolderListController (fileSystem, DBPath.Root);
				navController.PushViewController(folderController, true);
			}
			return true;
		}

	}
}

