using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Dialog;

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

using Facebook.LoginKit;
using Facebook.CoreKit;

namespace FacebookiOSSample
{
	public partial class DVCLogIn : DialogViewController
	{
		LoginButton loginView;
		ProfilePictureView pictureView;

		// By default you only get the "public_profile" read permissions
		// For extensive list of available publish and read permissions refer to
		// https://developers.facebook.com/docs/reference/api/permissions/
		string[] readPermissions = new [] {
			"public_profile",
			"email",
			"user_friends"
		};
		string[] publishPermissions = new [] { "publish_actions" };

		public DVCLogIn () : base (UITableViewStyle.Grouped, null, true)
		{
			 
			// If was sent true to Profile.EnableUpdatesOnAccessTokenChange method
			// this notification will be called once the user is logged in
			Profile.Notifications.ObserveDidChange ((sender, e) => {
				if (e.NewProfile != null) {
					Root.Add (new Section ("Hello " + e.NewProfile.Name) {
						new StringElement ("Actions Menu", () => {
							var dvc = new DVCActions ();
							NavigationController.PushViewController (dvc, true);
						}) {
							Alignment = UITextAlignment.Center
						}
					});
				}
			});

			loginView = new LoginButton (new CGRect (51, 0, 218, 46)) {
				LoginBehavior = LoginBehavior.Native,
				ReadPermissions = readPermissions,
				// You can ask permissions to publish right now
				// or later, to see a proper way of how to ask permissions
//				PublishPermissions = publishPermissions
			};

			// Handle actions once the user is logged in
			loginView.Completed += (sender, e) => {
				if (e.Error != null) {
					new UIAlertView ("Ups", e.Error.Description, null, "Ok", null).Show ();
					return;
				}
			};

			// Handle actions once the user is logged out
			loginView.LoggedOut += (sender, e) => {
				if (Root.Count >= 3) {
					InvokeOnMainThread (() => {
						var section = Root [2];
						section.Remove (0);
						Root.Remove (section);
						ReloadData ();
					});
				}
			};

			// The user image profile is set automatically once is logged in
			pictureView = new ProfilePictureView (new CGRect (50, 0, 220, 220));

			Root = new RootElement ("Facebook Sample") {
				new Section () {
					new UIViewElement ("", loginView, true) {
						Flags = UIViewElement.CellFlags.DisableSelection | UIViewElement.CellFlags.Transparent,
					}
				},
				new Section () {
					new UIViewElement ("", pictureView, true) {
						Flags = UIViewElement.CellFlags.DisableSelection | UIViewElement.CellFlags.Transparent,
					}, 
				}
			};
		}
	}
}
