//
// Facebook sample
//
using System;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using MonoTouch.FacebookConnect;
using System.Drawing;
using System.Json;

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
		UINavigationController nav;
		
		void SetupUI ()
		{
			var sessionDelegate = new SessionDelegate (this); 
			facebook = new Facebook (AppId, sessionDelegate);

			var defaults = NSUserDefaults.StandardUserDefaults;
			if (defaults ["FBAccessTokenKey"] != null && defaults ["FBExpirationDateKey"] != null){
				facebook.AccessToken = defaults ["FBAccessTokenKey"] as NSString;
				facebook.ExpirationDate = defaults ["FBExpirationDateKey"] as NSDate;
			}
			
			dvc = new DialogViewController (null);
			nav = new UINavigationController (dvc);
			
			if (facebook.IsSessionValid)
				ShowLoggedIn ();
			else
				ShowLoggedOut ();
			
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.MakeKeyAndVisible ();
			window.RootViewController = nav;
		}

		void Login ()
		{
			if (!facebook.IsSessionValid)
				facebook.Authorize (new string [] { "offline_access" });
			else
				ShowLoggedIn ();
		}
		
		void UninstallFromFacebook ()
		{
			facebook.GraphRequest ("me/permissions", new NSMutableDictionary (), "DELETE", Handler (delegate {
				ShowMessage ("Success", "The application has been uninstall form Facebook");

				// Clear out authentication values
				facebook.AccessToken = null;
				facebook.ExpirationDate = null;
				ShowLoggedOut ();
			}));
		}
		
		void GrantUserLikes ()
		{
			facebook.Authorize (new string [] { "user_likes" });
		}
		
		// Method called back by all of the various Requests* methods
		void RequestsCallback (NSUrl url)
		{
			var collection = System.Web.HttpUtility.ParseQueryString (url.Query);
			int count = 0;
			foreach (var k in collection.AllKeys){
				if (k.StartsWith ("request_ids"))
					count++;
			}
			ShowMessage ("Request Result", "Successfully sent " + count + " requests");
		}
		
		void RequestsToMany ()
		{
			var gift = new JsonObject ();
			gift.Add ("social_karma", new JsonPrimitive (5));
			gift.Add ("badge_of_awesomeness", new JsonPrimitive (1));
			
			var parameters = NSMutableDictionary.FromObjectsAndKeys (
				new object [] { "Learn how to make your iOS apps social", "Check this out", gift.ToString () },
				new object [] { "message", "notification_text", "data" });
				
			facebook.Dialog ("apprequests", parameters, DialogCallback (RequestsCallback));
		}
		
		void PostUserWall ()
		{
			var json = new JsonObject ();
			json.Add ("name", new JsonPrimitive ("Getting started"));
			json.Add ("link", new JsonPrimitive ("http://github.com/mono/monotouch-bindings"));
			
			var parameters = NSMutableDictionary.FromObjectsAndKeys (
				new object [] { "Test using MonoTouch/Facebook", "Hackbook for MonoTouch/iOS", "Some long boring text goes here", 
				"http://xamarin.com", "http://www.facebookmobileweb.com/hackbook/img/facebook_icon_large.png", json.ToString ()},
				new object [] { "name", "caption", "description", "link", "picture", "actions"});
			
			_wallDialogHandler = DialogCallback (url => {
				
				if (url.Query == null)
					return;
				
				var pars = System.Web.HttpUtility.ParseQueryString (url.Query);
				if (pars ["post_id"] != null)
					ShowMessage ("Success", "Got the message posted, id=" + pars ["post_id"]);
			});
			
			facebook.Dialog ("feed", parameters, _wallDialogHandler);
		}
		
		private FBDialogDelegate _wallDialogHandler;		
		internal void ShowLoggedIn ()
		{
			dvc.Root = new RootElement ("Logged In") { 
				new Section ("Options"){
					new RootElement ("Login and Permissions") {
						new Section ("Logging the user out", "You should include a button in your app to log the user out"){
							new StringElement ("Logout", delegate { facebook.Logout (); })
						}, 
						new Section ("Uninstalling the App", "You can create a button so the user can uninstall the app from Facebook"){
							new StringElement ("Uninstall app", UninstallFromFacebook)
						}, 
						new Section ("Asking for extended permissions", "If your app needs more than this basic information to function, you must request specific permissions from the user. For example, you might prompt the user to access their Likes in order to recommend related content for them automatically"){
							new StringElement ("Grant the 'user_likes' permission", GrantUserLikes)
						}
					},
					new RootElement ("Requests") {
						new Section ("Request", "If you show the request dialog with no friend suggestions, it will automatically show friends that are using your app, as well as friends that have already used your app."){
							new StringElement ("Send Request", RequestsToMany),
						},
#if false
						new Section ("Invite friend not using app"){
						}, 
						new Section ("Request to App Friends"){
						}, 
						new Section ("Request to targeted friend"){
						}
#endif
					},
					new RootElement ("News feed") {
						new Section ("Publish to the User's Wall"){
							new StringElement ("Publish to your wall", PostUserWall)
						}, 
#if false
						new Section ("Publish to friend's Wall"){
						}
#endif
					},
					new RootElement ("Graph API")
				}
			};
		}
							
		internal void ShowLoggedOut ()
		{
			dvc.Root = new RootElement ("Facebook Sample"){
				new Section ("Facebook Connect Sample App") {
					new StringElement ("Login to Facebook", Login)
				}
			};
			nav.PopToRootViewController (true);
		}
		
		// Save authorization information
		internal void SaveAuthorization ()
		{
			var defaults = NSUserDefaults.StandardUserDefaults;
			defaults ["FBAccessTokenKey"] = new NSString (facebook.AccessToken);
			defaults ["FBExpirationDateKey"] = facebook.ExpirationDate;
			defaults.Synchronize ();
		}
		
		internal void ClearAuthorization ()
		{
			var defaults = NSUserDefaults.StandardUserDefaults;
			defaults.RemoveObject ("FBAccessTokenKey");
			defaults.RemoveObject ("FBExpirationDateKey");
			defaults.Synchronize ();
		}	

		void ShowMessage (string caption, string message, NSAction callback = null)
		{
			var alert = new UIAlertView (caption, message, null, "Ok");
			if (callback != null)
				alert.Dismissed += delegate { callback (); };
			alert.Show ();
		}
		
		void SetupError (string msg)
		{
			ShowMessage ("Setup Error", msg, ()=>{Environment.Exit (1); });
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
		public override bool HandleOpenURL (UIApplication application, NSUrl url)
		{
			return facebook.HandleOpenURL (url);
		}
		
		// Post 4.2 callback
		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			Console.WriteLine ("Got: {0} and {1}", url, facebook.Handle);
			try 
			{
				facebook.HandleOpenURL (url);
				return true;
			}
			catch (Exception ex) 
			{   
				Console.WriteLine ("A very bad thing happened : " + ex.Message );
				return false;
			}

		}
		
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
			
		FBRequestDelegate Handler (Action<FBRequest,NSObject> handler)
		{
				return new RequestHandler (handler);
		}
		
		FBDialogDelegate DialogCallback (Action<NSUrl> callback)
		{
			return new DialogHandler (callback);
		}
	}
		
	// 
	// The session FBSessionDelegate instance will let us get events informing us
	// when the user has logged in/logged out or when his session becomes invalid
	//
	class SessionDelegate : FBSessionDelegate 
	{
		AppDelegate container;
		
		public SessionDelegate (AppDelegate container)
		{
			this.container = container;
		}

		public override void DidLogin ()
		{
			container.ShowLoggedIn ();
			container.SaveAuthorization ();
		}
		public override void DidLogout ()
		{
			container.ClearAuthorization ();
			container.ShowLoggedOut ();
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
	
	//
	// Proxy class that turns method invocations into delegate calls
	//
	class RequestHandler : FBRequestDelegate {
		static List<RequestHandler> handlers = new List<RequestHandler> ();
		Action<FBRequest, NSObject> loadedHandler;
		
		public RequestHandler (Action<FBRequest, NSObject> loadedHandler)
		{
			handlers.Add (this);
			this.loadedHandler = loadedHandler;
		}
		
		public override void FailedWithError (FBRequest request, NSError error)
		{
			var u = new UIAlertView ("Request Error", "Failed with " + error.ToString (), null, "ok");
			u.Dismissed += delegate {
				handlers.Remove (this);
			};
			u.Show ();
		}
		
		public override void RequestLoaded (FBRequest request, NSObject result)
		{
			loadedHandler (request, result);
			handlers.Remove (this);
		}
	}
	
	// 
	// Proxy call that turns method invocation into delegate calls
	//
	class DialogHandler : FBDialogDelegate {
		Action<NSUrl> callback;
		
		public DialogHandler (Action<NSUrl> callback)
		{
			this.callback = callback;
		}
		public override void CompletedWithUrl (NSUrl url)
		{
			callback (url);
		}
	}
}