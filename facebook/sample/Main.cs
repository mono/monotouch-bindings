//
// Facebook sample
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using MonoTouch.FacebookConnect;
using System.Drawing;

namespace sample {
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate {
		// Your Facebook APP Id must be set before running this example
		// See http://www.facebook.com/developers/createapp.php
		// Also, your application must bind to the fb[app_id]:// URL
		// scheme (substitue [app_id] for your real Facebook app id).
		const string AppId = "210849718975311";
		
		Facebook facebook;
		DialogViewController dvc;
		UIWindow window;
		
		void SetupUI ()
		{
			var sessionDelegate = new SessionDelegate (this); 
			facebook = new Facebook (AppId, sessionDelegate);
			
			var root = new RootElement ("Facebook Sample"){
				new Section ("Facebook Connect Sample App") {
					new StringElement ("Login to Facebook", Login)
				}
			};
			dvc = new DialogViewController (root);
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.MakeKeyAndVisible ();
			window.RootViewController = dvc;
			
		}

		void Login ()
		{
			if (!facebook.IsSessionValid)
				facebook.Authorize (new string [] { "offline_access" });
			else
				ShowLoggedIn ();
		}
		
		void ShowLoggedIn ()
		{
			dvc.Root = new RootElement ("You are logged in to Facebook");
		}
		
		void SetupError (string msg)
		{
				var alert = new UIAlertView ("Setup Error", msg, null, "Ok");
				alert.Dismissed += delegate { Environment.Exit (1); };
				alert.Show ();
		}
		
		//
		// This method merely validates that the basic components of a Facebook
		// app are complete, it should not be needed in a complete application,
		// but will help in the first stages of debugging your Facebook
		// interop
		//
		void ValidateSetup ()
		{
			if (AppId == null)
				SetupError ("Missing AppId,  You can not run the app until this is setup");
			
			// Validate the callback "fb[APPID]://authorize is in the Info.plist
			// which is what facebook uses to call us back
			bool urlFound = false;
			try {
				var arr = NSArray.FromArray<NSObject> (NSBundle.MainBundle.ObjectForInfoDictionary ("CFBundleURLTypes") as NSArray);
				if (arr != null && arr.Length > 0){
					var dict = arr [0] as NSDictionary;
					arr = NSArray.FromArray<NSString> (dict [(NSString) "CFBundleURLSchemes"] as NSArray);
					if (arr != null && arr.Length > 0){
						var fbvalue = arr [0].ToString ();
						if (fbvalue.StartsWith ("fb" + AppId))
							urlFound = true; 
					}
				} else 
					SetupError ("Missing fbXXXX URL handler in Info.plist's CFBundleURLTypes section");
			} catch {
				SetupError ("Invalid contents of Info.plist file");
			}
			
			if (!urlFound)
				SetupError ("Missing correct fbXXXX i the Info.plist's setup");

			// Check if the authorization callback will work
			if (!UIApplication.SharedApplication.CanOpenUrl (new NSUrl ("fb" + AppId + "://authorize")))
				SetupError ("Invalid or missing URL scheme. You cannot run the app until you set up a valid URL scheme in your .plist.");
		}
		
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			ValidateSetup ();
			SetupUI ();
			return true;
		}
		
		// Pre-4.2 callback
		// This method is called back when Facebook has authenticated us in the Web UI
		public override void HandleOpenURL (UIApplication application, NSUrl url)
		{
			facebook.HandleOpenURL (url);
		}
		
		// Post 4.2 callback
		public override void OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			Console.WriteLine ("Got: {0} and {1}", url, facebook.Handle);
			 facebook.HandleOpenURL (url);
		}
		
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
		
	class SessionDelegate : FBSessionDelegate 
	{
		AppDelegate container;
		
		public SessionDelegate (AppDelegate container)
		{
			this.container = container;
		}

		public override void DidLogin ()
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
		}
		public override void DidLogout ()
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
		}
		
		public override void DidNotLogin (bool cancelled)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
		}
		
		public override void SessionInvalidated ()
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
		}
	}
}