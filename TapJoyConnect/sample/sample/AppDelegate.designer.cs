// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace sample
{
	partial class AppDelegate
	{
		[Outlet]
		MonoTouch.UIKit.UILabel msgLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel statusLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (msgLabel != null) {
				msgLabel.Dispose ();
				msgLabel = null;
			}

			if (statusLabel != null) {
				statusLabel.Dispose ();
				statusLabel = null;
			}
		}
	}
}
