// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace RedLaserSample
{
	[Register ("OverlayController")]
	partial class OverlayController
	{
		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem cancelButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem flashButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel latestResultLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView redlaserLogo { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel textCue { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIToolbar toolBar { get; set; }

		[Action ("cancelPressed:")]
		partial void cancelPressed (MonoTouch.UIKit.UIBarButtonItem sender);

		[Action ("flashPressed:")]
		partial void flashPressed (MonoTouch.UIKit.UIBarButtonItem sender);

		[Action ("rotatePressed:")]
		partial void rotatePressed (MonoTouch.UIKit.UIBarButtonItem sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (flashButton != null) {
				flashButton.Dispose ();
				flashButton = null;
			}

			if (latestResultLabel != null) {
				latestResultLabel.Dispose ();
				latestResultLabel = null;
			}

			if (toolBar != null) {
				toolBar.Dispose ();
				toolBar = null;
			}

			if (cancelButton != null) {
				cancelButton.Dispose ();
				cancelButton = null;
			}

			if (redlaserLogo != null) {
				redlaserLogo.Dispose ();
				redlaserLogo = null;
			}

			if (textCue != null) {
				textCue.Dispose ();
				textCue = null;
			}
		}
	}
}
