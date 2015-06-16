using System;

using UIKit;
using MonoTouch.Dialog;

using Facebook.CoreKit;
using Facebook.LoginKit;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;

namespace FBExam
{
	public partial class MainViewController : DialogViewController
	{

		// To see the full list of permissions, visit the following link:
		// https://developers.facebook.com/docs/facebook-login/permissions/v2.3

		// This permission is set by default, even if you don't add it, but FB recommends to add it anyway
		List<string> readPermissions = new List<string> { "public_profile" };

		LoginButton loginButton;
		ProfilePictureView pictureView;

		Section readSection;
		CustomCheckboxElement chkPublicProfile;
		CustomStringElement strPostHello;

		bool isHelloPosted = false;
		string helloId;

		public MainViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			// If was send true to Profile.EnableUpdatesOnAccessTokenChange method
			// this notification will be called after the user is logged in and
			// after the AccessToken is gotten
			Profile.Notifications.ObserveDidChange ((sender, e) => {

				if (e.NewProfile == null)
					return;
				
				LoggedIn (e.NewProfile.UserID);
			});

			loginButton = new LoginButton (new CGRect (48, 0, 218, 46)) {
				LoginBehavior = LoginBehavior.Native
			};

			// Handle actions once the user is logged in
			loginButton.Completed += (sender, e) => {
				if (e.Error != null) {
					ShowMessageBox ("Ups", e.Error.Description, "Ok", null, null);
					return;
				}
				if (e.Result.IsCancelled) {
					ShowMessageBox ("Ups", "The user cancelled the request", "Ok", null, null);
					return;
				}
			};

			// Handle actions once the user is logged out
			loginButton.LoggedOut += (sender, e) => {				
				LoggedOut ();
			};

			// This permission is set by default
			chkPublicProfile = new CustomCheckboxElement ("Public Profile", true);
			chkPublicProfile.Enabled = false;

			// Add or remove all the permissions that you want to ask
			readSection = new Section ("Ask Read Permissions") {
				chkPublicProfile,
				new CustomCheckboxElement ("Email", () => CheckReadPermission ("email")),
				new CustomCheckboxElement ("About Me", () => CheckReadPermission ("user_about_me")),
				new CustomCheckboxElement ("Birthday", () => CheckReadPermission ("user_birthday")),
				new CustomCheckboxElement ("Hometown", () => CheckReadPermission ("user_hometown")),
				new CustomCheckboxElement ("Friendlists", () => CheckReadPermission ("read_custom_friendlists")),
				new CustomCheckboxElement ("Groups", () => CheckReadPermission ("user_groups"))
			};

			// The user image profile is set automatically once is logged in
			pictureView = new ProfilePictureView (new CGRect (48, 0, 220, 220));

			// Add the initial sections
			Root = new RootElement ("Facebook iOS Sample") {
				readSection,
				new Section () {
					new UIViewElement ("", loginButton, true) {
						Flags = UIViewElement.CellFlags.DisableSelection | UIViewElement.CellFlags.Transparent,
					}
				}
			};

			// If the user is already logged in, remove the read section and add the actions sections
			if (AccessToken.CurrentAccessToken != null)
				LoggedIn (AccessToken.CurrentAccessToken.UserID);

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}


		#region Login Status Methods

		void LoggedIn (string userId)
		{
			// If the login was successful, remove the read permissions seccion and add revoke permissions, your info and actions sections
			Root.Remove (readSection);
			Root.Add (new Section () {
				new UIViewElement ("", pictureView, true) {
					Flags = UIViewElement.CellFlags.DisableSelection | UIViewElement.CellFlags.Transparent,
				},
			});
			AddRevokeAllPermissionsSection ();
			AddUserInfoSection (userId);
		}

		// Remove all the sections but the loggin button and add the read section again
		void LoggedOut ()
		{
			for (int i = 1; i < Root.Count;)
				Root.RemoveAt (1);

			Root.Insert (0, readSection);
		}

		#endregion


		#region Monotouch Dialog Sections

		void AddRevokeAllPermissionsSection ()
		{
			string title = "Revoke all permissions";
			string message = "Are you sure you want to revoke all the permissions?";
			Root.Add (new Section () {
				// Ask the user if he/she really wants to erase the permissions
				new StyledStringElement ("Revoke All permissions", () => ShowMessageBox (title, message, "Maybe Later", new [] { "Ok" }, () => RevokeAllPermissions (AccessToken.CurrentAccessToken.UserID))) {
					Alignment = UITextAlignment.Center,
					TextColor = UIColor.Red,
					BackgroundColor = UIColor.White
				}
			});
		}

		void AddUserInfoSection (string userId)
		{
			// Ask for the info that the user allowed to show
			var request = new GraphRequest ("/" + userId, null, AccessToken.CurrentAccessToken.TokenString, null, "GET");
			var requestConnection = new GraphRequestConnection ();
			requestConnection.AddRequest (request, (connection, result, error) => {
				// Handle if something went wrong with the request
				if (error != null) {
					new UIAlertView ("Error...", error.Description, null, "Ok", null).Show ();
					return;
				}

				NSDictionary userInfo = (result as NSDictionary);

				var userSection = new Section (userInfo ["name"].ToString ());

				// Show the info user that allowed to show
				// If the user haven't assigned anything to his/her information,
				// it will be null even if the user allowed to show it.
				if (userInfo ["email"] != null)
					userSection.Add (new StringElement ("Email: " + userInfo ["email"].ToString ()));
				if (userInfo ["birthday"] != null)
					userSection.Add (new StringElement ("Birthday: " + userInfo ["birthday"].ToString ()));
				if (userInfo ["about"] != null)
					userSection.Add (new StringElement ("About: " + userInfo ["about"].ToString ()));
				if (userInfo ["hometown"] != null)
					userSection.Add (new StringElement ("Hometown: " + userInfo ["hometown"].ToString ()));

				Root.Add (userSection);

				// Add the allowed actions that user have granted
				AddActionsSection ();
			});
			requestConnection.Start ();
		}

		// Actions to add: Post/Delete a Hello, see friend list, see Group and Publish a Photo
		void AddActionsSection ()
		{
			strPostHello = new CustomStringElement ("Post \"Hello\" on your wall", PostHello);

			var actionsSection = new Section ("Actions") {
				strPostHello
			};

			if (AccessToken.CurrentAccessToken.HasGranted ("read_custom_friendlists"))
				actionsSection.Add (new StringElement ("See Friendlist", () => {
					NavigationController.PushViewController (new ListViewController (FacebookListType.Friends), true);
				}));

			if (AccessToken.CurrentAccessToken.HasGranted ("user_groups"))
				actionsSection.Add (new StringElement ("See Groups", () => {
					NavigationController.PushViewController (new ListViewController (FacebookListType.Groups), true);
				}));

			actionsSection.Add (new StringElement ("Publish photo", PostPhoto));

			Root.Add (actionsSection);
		}

		#endregion


		#region Facebook actions

		// Post and delete the "Hello!" from user wall
		void PostHello ()
		{
			// Verify if you have permissions to post into user wall,
			// if not, ask to user if he/she wants to let your app post things for them
			if (!AccessToken.CurrentAccessToken.HasGranted ("publish_actions")) {
				AskPermissions ("Post Hello", "Would you like to let this app to post a \"Hello\" for you?", new [] { "publish_actions" }, PostHello);
				return;
			}

			// Once you have the permissions, you can publish or delete the post from your wall 
			GraphRequest request;

			if (!isHelloPosted)
				request = new GraphRequest ("me/feed", new NSDictionary ("message", "Hello!"), AccessToken.CurrentAccessToken.TokenString, null, "POST");
			else
				request = new GraphRequest (helloId, null, AccessToken.CurrentAccessToken.TokenString, null, "DELETE");

			var requestConnection = new GraphRequestConnection ();

			// Handle the result of the request
			requestConnection.AddRequest (request, (connection, result, error) => {
				// Handle if something went wrong
				if (error != null) {
					ShowMessageBox ("Error...", error.Description, "Ok", null, null);
					return;
				}

				// Post the Hello! to your wall
				if (!isHelloPosted) {
					helloId = (result as NSDictionary) ["id"].ToString ();
					isHelloPosted = true;
					InvokeOnMainThread (() => {
						strPostHello.Caption = "Delete \"Hello\" from your wall";
						Root.Reload (strPostHello, UITableViewRowAnimation.Left);
						ShowMessageBox ("Success!!", "Posted Hello in your wall, MsgId: " + helloId, "Ok", null, null);
					});
				} else { // Delete the Hello! from your wall
					helloId = "";

					isHelloPosted = false;
					InvokeOnMainThread (() => {
						strPostHello.Caption = "Post \"Hello\" on your wall";
						Root.Reload (strPostHello, UITableViewRowAnimation.Left);
						ShowMessageBox ("Success", "Deleted Hello from your wall", "Ok", null, null);
					});
				}
			});
			requestConnection.Start ();
		}

		// Post a photo with a text
		void PostPhoto ()
		{
			// Verify if you have permissions to post into user wall,
			// if not, ask to user if he/she wants to let your app post things for them
			if (!AccessToken.CurrentAccessToken.HasGranted ("publish_actions")) {
				AskPermissions ("Post photos, post and delete comments", "Would you like to let this app to post photos and comments for you?", new [] { "publish_actions" }, PostPhoto);
				return;
			}

			// Once you have the permission, go to the next controller to post the photo
			NavigationController.PushViewController (new PhotoViewController (), true);
		}

		// Verifies if you have granted the permissions, if not, ask for them
		void AskPermissions (string title, string message, string[] permissions, Action successHandler)
		{

			ShowMessageBox (title, message, "Maybe Later", new [] { "Ok" }, () => {
				// If they let you do things, ask for a new Access Token with the new permission
				var login = new LoginManager ();
				login.LogInWithPublishPermissions (permissions, (result, error) => {
					// Handle if something went wrong with the request
					if (error != null) {
						new UIAlertView ("Error...", error.Description, null, "Ok", null).Show ();
						return;
					}

					// Handle if the user cancelled the request
					if (result.IsCancelled) {
						new UIAlertView ("The request was cancelled", "If you are using a Test App Id, please, make sure that your account have an Administrator role at:\rhttps://developers.facebook.com/apps/appid/roles/", null, "OK", null).Show ();
						return;
					}

					// Do your magic if the request was successful
					successHandler ();
				});
			});
		}

		// Revoke all the permissions that you had granted, you will need to login again for ask the permissions again
		// You can also revoke a single permission, for more info, visit this link:
		// https://developers.facebook.com/docs/facebook-login/permissions/v2.3#revoking
		void RevokeAllPermissions (string userId)
		{
			// Create the request for delete all the permissions
			var request = new GraphRequest ("/" + userId + "/permissions", null, AccessToken.CurrentAccessToken.TokenString, null, "DELETE");
			var requestConnection = new GraphRequestConnection ();
			requestConnection.AddRequest (request, (connection, result, error) => {
				// Handle if something went wrong
				if (error != null) {
					ShowMessageBox ("Error...", error.Description, "Ok", null, null);
					return;
				}

				// If the revoking was successful, logout from FB
				if ((result as NSDictionary) ["success"].ToString () == "1")
					InvokeOnMainThread (() => {
						ShowMessageBox ("Successful", "All permissions have been revoked", "Ok", null, null);
						var login = new LoginManager ();
						login.LogOut ();
						LoggedOut ();
					});
				else
					InvokeOnMainThread (() => ShowMessageBox ("Ups...", "A problem has ocurred", "Ok", null, null));

			});
			requestConnection.Start ();
		}

		#endregion

		// Adds the permission if not exists in the list, otherwise, removes the permission
		void CheckReadPermission (string permission)
		{
			if (!readPermissions.Contains (permission))
				readPermissions.Add (permission);
			else
				readPermissions.Remove (permission);
			loginButton.ReadPermissions = readPermissions.ToArray ();
		}

		// Show the alert view
		void ShowMessageBox (string title, string message, string cancelButton, string[] otherButtons, Action successHandler)
		{
			var alertView = new UIAlertView (title, message, null, cancelButton, otherButtons);
			alertView.Clicked += (sender, e) => {
				if (e.ButtonIndex == 0)
					return;

				if (successHandler != null)
					successHandler ();
			};
			alertView.Show ();
		}
	}
}

