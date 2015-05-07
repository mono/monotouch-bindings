using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Dialog;
using System.Web;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreLocation;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using System.Drawing;

using CGRect = global::System.Drawing.RectangleF;
using CGSize = global::System.Drawing.SizeF;
using CGPoint = global::System.Drawing.PointF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

using Facebook.CoreKit;
using Facebook.LoginKit;
using Facebook.ShareKit;

namespace FacebookiOSSample
{
	public partial class DVCActions : DialogViewController, ISharingDelegate, IAppInviteDialogDelegate
	{
		ProfilePictureView pictureView;
		bool isHelloPosted = false;
		string helloId = null;
		bool isXamarinShared = false;
		string sharedId = null;
		AccessToken currentAccessToken = AccessToken.CurrentAccessToken;

		// So you can share your Facebook app, you need to create an AppLink:
		// https://developers.facebook.com/docs/app-invites/ios#app_links
		NSUrl appLinkUrl = new NSUrl ("https://fb.me/1057737077589334");
		NSUrl previewImageUrl = new NSUrl ("http://colegiokolbe.com/wp-content/uploads/2014/09/facebook.png");

		public DVCActions () : base (UITableViewStyle.Grouped, null, true)
		{
			
			pictureView = new ProfilePictureView (new CGRect (120, 0, 80, 80));

			// Create menu options with Monotouch.Dialog
			Root = new RootElement ("Menu") {
				new Section () {
					new UIViewElement ("", pictureView, true) {
						Flags = UIViewElement.CellFlags.DisableSelection | UIViewElement.CellFlags.Transparent,
					}
				},
				new Section () {
					new StringElement (Profile.CurrentProfile.Name) {
						Alignment = UITextAlignment.Center
					}
				},
				new Section ("Actions") {
					new CustomStringElement ("Share Xamarin.com", ShareUrl) {
						Alignment = UITextAlignment.Center,
						Value = "ShareDialog Sample"
					},
					new CustomStringElement ("Delete Shared Xamarin.com", DeleteSharedPost, 13) {
						Alignment = UITextAlignment.Center,
						Value = "GraphRequest Sample"
					},
					new CustomStringElement ("Post \"Hello\"", PostHello) {
						Alignment = UITextAlignment.Center,
						Value = "GraphRequest Sample"
					},
					new CustomStringElement ("Delete \"Hello\"", DeleteHelloPost) {
						Alignment = UITextAlignment.Center,
						Value = "GraphRequest Sample"
					},
					new CustomStringElement ("Invite some friends", InviteFriends) {
						Alignment = UITextAlignment.Center,
						Value = "AppInviteDialog Sample"
					},
				}
			};
		}

		// Share a Xamarin.com link into user wall
		void ShareUrl ()
		{
			// Create the content of what will be shared
			var content = new ShareLinkContent {
				ContentTitle = "Xamarin - cross platform that works",
				ContentDescription = "Create iOS, Android, Mac and Windows apps in C#"
			};
			content.SetContentUrl (new NSUrl ("https://xamarin.com"));

			// Show your share post, automatically chooses the best way to share
			ShareDialog.Show (this, content, this);
		}

		// Delete the last Xamarin.com shared
		void DeleteSharedPost ()
		{
			if (!isXamarinShared) {
				new UIAlertView ("Error", "Please Share \"Xamarin.com\" to your wall first", null, "Ok", null).Show ();
				return;
			}

			// Verify if you have permissions to delete things from user wall,
			// if not, ask to user if he/she wants to let your app to delete things for them
			if (!currentAccessToken.HasGranted ("publish_actions")) {
				AskPermissions ("Delete Shared Post", "Would you like to let this app to delete your last shared post for you?", new [] { "publish_actions" }, PostHello);
				return;
			}

			// Use GraphRequest to delete the last shared post
			var request = new GraphRequest (sharedId, null, currentAccessToken.TokenString, null, "DELETE");
			var requestConnection = new GraphRequestConnection ();

			// Handle the result of the request
			requestConnection.AddRequest (request, (connection, result, error) => {
				if (error != null) {
					new UIAlertView ("Error...", error.Description, null, "Ok", null).Show ();
					return;
				}

				sharedId = "";
				new UIAlertView ("Success!!", "Deleted your last share from your wall", null, "Ok", null).Show ();
				isXamarinShared = false;
			});

			// Start all your request that you have added
			requestConnection.Start ();
		}

		// Post a "Hello!" into user wall
		void PostHello ()
		{
			if (isHelloPosted) {
				InvokeOnMainThread (() => new UIAlertView ("Error", "Hello already posted on your wall", null, "Ok", null).Show ());
				return;
			}

			// Verify if you have permissions to post into user wall,
			// if not, ask to user if he/she wants to let your app post things for them
			if (!currentAccessToken.HasGranted ("publish_actions")) {
				AskPermissions ("Post Hello", "Would you like to let this app to post a \"Hello\" for you?", new [] { "publish_actions" }, PostHello);
				return;
			}

			// Once you have the permissions, you can publish into user wall 
			var request = new GraphRequest ("me/feed", new NSDictionary ("message", "Hello!"), AccessToken.CurrentAccessToken.TokenString, null, "POST");
			var requestConnection = new GraphRequestConnection ();

			// Handle the result of the request
			requestConnection.AddRequest (request, (connection, result, error) => {
				if (error != null) {
					new UIAlertView ("Error...", error.Description, null, "Ok", null).Show ();
					return;
				}

				helloId = (result as NSDictionary) ["id"].ToString ();
				new UIAlertView ("Success!!", "Posted Hello in your wall, MsgId: " + helloId, null, "Ok", null).Show ();
				isHelloPosted = true;
			});
			requestConnection.Start ();
		}

		// Delete the "Hello!" post from user wall
		void DeleteHelloPost ()
		{
			if (!isHelloPosted) {
				new UIAlertView ("Error", "Please Post \"Hello\" to your wall first", null, "Ok", null).Show ();
				return;
			}

			// Verify if you have permissions to delete things from user wall,
			// if not, ask to user if he/she wants to let your app to delete things for them
			if (!currentAccessToken.HasGranted ("publish_actions")) {
				AskPermissions ("Delete Hello Post", "Would you like to let this app to delete your \"Hello\" post for you?", new [] { "publish_actions" }, PostHello);
				return;
			}

			// Use GraphRequest to delete the Hello! post
			var request = new GraphRequest (helloId, null, currentAccessToken.TokenString, null, "DELETE");
			var requestConnection = new GraphRequestConnection ();

			// Handle the result of the request
			requestConnection.AddRequest (request, (connection, result, error) => {
				if (error != null) {
					new UIAlertView ("Error...", error.Description, null, "Ok", null).Show ();
					return;
				}

				helloId = "";
				new UIAlertView ("Success", "Deleted Hello from your wall", null, "Ok", null).Show ();
				isHelloPosted = false;
			});
			requestConnection.Start ();
		}

		// Invite user's friends to use your Facebook app
		void InviteFriends ()
		{
			var content = new AppInviteContent {
				AppLinkURL = appLinkUrl
			};
			content.PreviewImageURL = previewImageUrl;
			AppInviteDialog.Show (content, this);
		}

		void AskPermissions (string title, string message, string[] permissions, Action successHandler)
		{
			var alertView = new UIAlertView (title, message, null, "Maybe later", new [] { "Ok" });
			alertView.Clicked += (sender, e) => {
				if (e.ButtonIndex == 0)
					return;

				// If they let you post thing, ask a new loggin with publish permissions
				var login = new LoginManager ();

				login.LogInWithPublishPermissions (permissions, (result, error) => {
					if (error != null) {
						new UIAlertView ("Error...", error.Description, null, "Ok", null).Show ();
						return;
					}

					if (result.IsCancelled) {
						new UIAlertView ("The request was cancelled", "If you are using a Test App Id, please, make sure that your account have an Administrator role at:\rhttps://developers.facebook.com/apps/appid/roles/", null, "OK", null).Show ();
						return;
					}

					currentAccessToken = result.Token;
					successHandler ();
				});
			};
			alertView.Show ();
		}

		#region ISharingDelegate Implement

		public void DidComplete (ISharing sharer, NSDictionary results)
		{
			Console.WriteLine (results);
			if (results.ContainsKey (new NSString ("postId"))) {
				sharedId = results ["postId"].ToString ();
				new UIAlertView ("Success!!", "Successfully posted to Facebook!", null, "Ok", null).Show ();
				isXamarinShared = true;
			}
		}

		public void DidFail (ISharing sharer, NSError error)
		{
			new UIAlertView ("Error...", error.Description, null, "Ok", null).Show ();
		}

		public void DidCancel (ISharing sharer)
		{
			new UIAlertView ("Cancelled", "The share post was cancelled", null, "Ok", null).Show ();
		}

		#endregion

		#region IAppInviteDialogDelegate implement

		public void DidComplete (AppInviteDialog appInviteDialog, NSDictionary results)
		{
			if (results ["completionGesture"] != null && results ["completionGesture"].ToString () != "cancel")
				new UIAlertView ("Success!!", "Successfully invited to some friends to use your app!", null, "Ok", null).Show ();
		}

		public void DidFail (AppInviteDialog appInviteDialog, NSError error)
		{
			new UIAlertView ("Error...", error.Description, null, "Ok", null).Show ();
		}

		#endregion
	}
}
