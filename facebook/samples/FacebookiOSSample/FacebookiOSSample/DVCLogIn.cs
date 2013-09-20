using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Drawing;

using MonoTouch.FacebookConnect;

namespace FacebookiOSSample
{
	public partial class DVCLogIn : DialogViewController
	{
		FBLoginView loginView;
		FBProfilePictureView pictureView;
		FBGraphUser user;

		// For extensive list of available extended permissions refer to 
		// https://developers.facebook.com/docs/reference/api/permissions/
		private string [] ExtendedPermissions = new [] { "user_about_me", "read_stream"};

		public DVCLogIn () : base (UITableViewStyle.Grouped, null, true)
		{
			loginView = new FBLoginView (ExtendedPermissions);

			if (UIDevice.CurrentDevice.CheckSystemVersion (7, 0)) {
				loginView.Frame = new RectangleF (51, 0, 218, 46);
			} else {
				loginView.Frame = new RectangleF (40, 0, 218, 46);
			}

			loginView.FetchedUserInfo += (sender, e) => {
				if (Root.Count < 3) {
					user = e.User;
					pictureView.ProfileID = user.Id;

					Root.Add (new Section ("Hello " + user.Name) {
						new StringElement ("Actions Menu", () => {
							var dvc = new DVCActions (user);
							NavigationController.PushViewController (dvc, true);
						}) {
							Alignment = UITextAlignment.Center
						}
					});
				}
			};
			loginView.ShowingLoggedOutUser += (sender, e) => {
				pictureView.ProfileID = null;
				if (Root.Count >= 3) {
					InvokeOnMainThread (() => {
						var section = Root [2];
						section.Remove (0);
						Root.Remove (section);
						ReloadData ();
					});
				}
			};

			pictureView = new FBProfilePictureView () ;

			if (UIDevice.CurrentDevice.CheckSystemVersion (7,0)) {
				pictureView.Frame = new RectangleF (50, 0, 220, 220);
			}
			else {
				pictureView.Frame = new RectangleF (40, 0, 220, 220);
			}

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
