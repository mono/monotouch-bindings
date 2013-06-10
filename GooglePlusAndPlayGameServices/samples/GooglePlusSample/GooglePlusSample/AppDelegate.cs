using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Google.Plus;

namespace GooglePlusSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		MainViewController viewController;
		UINavigationController navController;

		// TODO:
		// Before you can use Google Plus SDK and run this sample, 
		// you must create an APIs Console project at 
		// https://developers.google.com/console
		// make sure you use com.xamarin.googleplussample as your Bundle ID on Google's portal.
		// More info on how to setup https://developers.google.com/+/mobile/ios/getting-started

		const string ClientId = "YOUR_CLIENT_ID";

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

			// Configure the SignIn shared singleton instance by declaring 
			// its client ID, delegate, and scopes.
			var signIn = SignIn.SharedInstance;
			signIn.ClientId = ClientId;
			signIn.Scopes = new [] { PlusConstants.AuthScopePlusLogin, PlusConstants.AuthScopePlusMe };

			// If you want to know user Email or Google User Id you should
			// Set ShouldFetchGoogleUserEmail or ShouldFetchGoogleUserId
			// value to true, default value is false
			signIn.ShouldFetchGoogleUserEmail = true;
			signIn.ShouldFetchGoogleUserId = true;

			// Setup event listener when user logins
			signIn.Finished += HandleFinished;

			viewController = new MainViewController ();
			navController = new UINavigationController (viewController);

			window.RootViewController = navController;
			window.MakeKeyAndVisible ();

			return true;
		}

		void HandleFinished (object sender, SignInDelegateFinishedEventArgs e)
		{
			if (e.Error != null) {
				InvokeOnMainThread (()=> new UIAlertView ("Error", "Could not sign in.\nError: " + e.Error.Description, null, "Ok", null).Show ());
			} else {
				Console.WriteLine ("Success\nToken: " + SignIn.SharedInstance.Authentication.AccessToken);
				Console.WriteLine ("Email: " + SignIn.SharedInstance.UserEmail);
				navController.PushViewController (new DVCMenu(), true);
			}
		}

		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			// This handler will properly handle the URL that your application 
			// receives at the end of the authentication process.
			return UrlHandler.HandleUrl (url, sourceApplication, annotation);
		}							
	}
}

