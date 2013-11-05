// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace sample
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField leaderboard_id { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField achievement_id { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch toggleAction { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch toggleStatusBar { get; set; }

		[Action ("setLocation")]
		partial void setLocation ();

		[Action ("unlockAchievement")]
		partial void unlockAchievement ();

		[Action ("saveLeaderboard")]
		partial void saveLeaderboard ();

		[Action ("showNotification")]
		partial void showNotification ();

		[Action ("showFullscreen")]
		partial void showFullscreen ();

		[Action ("getActivePromos")]
		partial void getActivePromos ();
		
		void ReleaseDesignerOutlets ()
		{
			if (leaderboard_id != null) {
				leaderboard_id.Dispose ();
				leaderboard_id = null;
			}

			if (achievement_id != null) {
				achievement_id.Dispose ();
				achievement_id = null;
			}

			if (toggleAction != null) {
				toggleAction.Dispose ();
				toggleAction = null;
			}

			if (toggleStatusBar != null) {
				toggleStatusBar.Dispose ();
				toggleStatusBar = null;
			}
		}
	}
}
