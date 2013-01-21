// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Scrumptious
{
	[Register ("SCViewController")]
	partial class SCViewController
	{
		[Outlet]
		MonoTouch.FacebookConnect.FBProfilePictureView userProfileImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel userNameLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView MenuTableView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton announceButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView activityIndicator { get; set; }

		[Action ("announce:")]
		partial void announce (MonoTouch.UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (userProfileImage != null) {
				userProfileImage.Dispose ();
				userProfileImage = null;
			}

			if (userNameLabel != null) {
				userNameLabel.Dispose ();
				userNameLabel = null;
			}

			if (MenuTableView != null) {
				MenuTableView.Dispose ();
				MenuTableView = null;
			}

			if (announceButton != null) {
				announceButton.Dispose ();
				announceButton = null;
			}

			if (activityIndicator != null) {
				activityIndicator.Dispose ();
				activityIndicator = null;
			}
		}
	}
}
