using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using MonoTouch.FacebookConnect;

namespace Scrumptious
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// This sample is based on Facebook SDK for iOS Tutorial
		// https://developers.facebook.com/docs/tutorials/ios-sdk-tutorial/
		// Please review the tutorial for more information

		// Replace here you own Facebook App Id, if you don't have one go to
		// https://developers.facebook.com/apps
		public static string FbAppId = "454287177934330";

		public static string SCSessionStateChangedNotification = new NSString("com.facebook.Scrumptious:SCSessionStateChangedNotification");

		// class-level declarations
		UIWindow window;
		SCViewController mainViewController;
		UINavigationController navController;
		SCLoginViewController loginViewController;


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

			//
			FBSession.DefaultAppID = FbAppId;

			mainViewController = new SCViewController ();
			navController = new UINavigationController(mainViewController);

			window.RootViewController = navController;
			window.MakeKeyAndVisible ();

			// FBSample logic
			// See if we have a valid token for the current state.
			if (!OpenSession(false)) 
			{
				// No? Display the login page.
				ShowLoginView();
			}
			return true;
		}

		private void CreateAndPresentLoginView ()
		{
			if (loginViewController == null) 
			{
				loginViewController = new SCLoginViewController();
				navController.TopViewController.PresentModalViewController(loginViewController, false);
			}

		}

		private void ShowLoginView()
		{
			// If the login screen is not already displayed, display it. If the login screen is 
			// displayed, then getting back here means the login in progress did not successfully 
			// complete. In that case, notify the login view so it can update its UI appropriately.
			if (loginViewController == null) 
			{
				CreateAndPresentLoginView();
			} else 
			{
				loginViewController.LoginFailed();
			}
		}

		public void OnSessionStateChanged(FBSession session, FBSessionState state, NSError error)
		{
			// FBSample logic
			// Any time the session is closed, we want to display the login controller (the user
			// cannot use the application unless they are logged in to Facebook). When the session
			// is opened successfully, hide the login controller and show the main UI.
			switch (state) 
			{
			
			case FBSessionState.Open:
				this.mainViewController.StartLocationManager();
				if (loginViewController != null) 
				{
					navController.TopViewController.DismissViewController(true, null);
					loginViewController = null;
				}

				// FBSample logic
				// Pre-fetch and cache the friends for the friend picker as soon as possible to improve
				// responsiveness when the user tags their friends.
				FBCacheDescriptor cacheDescriptor = FBFriendPickerViewController.CacheDescriptor();
				cacheDescriptor.PrefetchAndCacheForSession(session);
				break;

			case FBSessionState.Closed:
				// FBSample logic
				// Once the user has logged out, we want them to be looking at the root view.
				// and to clear the user Token
				if (navController.TopViewController.ModalViewController != null) 
					navController.TopViewController.DismissViewController(false, null);

				navController.PopToRootViewController(false);
				FBSession.ActiveSession.CloseAndClearTokenInformation();
				ShowLoginView();
				break;

			case FBSessionState.ClosedLoginFailed:
				// if the token goes invalid we want to switch right back to
				// the login view, however we do it with a slight delay in order to
				// account for a race between this and the login view dissappearing
				// a moment before
				this.ShowLoginView();
				break;

			default:
				break;
			}

			NSNotificationCenter.DefaultCenter.PostNotificationName(SCSessionStateChangedNotification, session);

			if (error != null) 
			{
				UIAlertView alertView = new UIAlertView("Error: " + ((FBErrorCode)error.Code).ToString(), error.LocalizedDescription, null, "Ok", null);
				alertView.Show();
			}
		}

		public bool OpenSession (bool allowLoginUI)
		{
			string [] permissions = new string[] { "user_photos" };

			return 	FBSession.OpenActiveSession(permissions, allowLoginUI, (session, status, error) => 
			        {
						this.OnSessionStateChanged(session, status, error);
					});
		}

		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			// FBSample logic
			// We need to handle URLs by passing them to FBSession in order for SSO authentication
			// to work.
			return FBSession.ActiveSession.HandleOpenURL(url);
		}

		public override void OnActivated (UIApplication application)
		{
			// FBSample logic
			// We need to properly handle activation of the application with regards to SSO
			//  (e.g., returning from iOS 6.0 authorization dialog or from fast app switching).
			FBSession.ActiveSession.HandleDidBecomeActive();
		}

	}
}

