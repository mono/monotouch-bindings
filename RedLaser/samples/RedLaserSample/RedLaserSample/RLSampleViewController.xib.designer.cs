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
	[Register ("RLSampleViewController")]
	partial class RLSampleViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel barcodeTextLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch enableCode128Switch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch enableCode39Switch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch enableDataMatrixSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch enableEAN13Switch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch enableEAN8Switch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch enableITFSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch enableQRCodeSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch enableSTICKYSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch enableUPCESwitch { get; set; }

		[Outlet]
		RedLaserSample.OverlayController overlayController { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel typeLabel { get; set; }

		[Action ("scanPressed:")]
		partial void scanPressed (MonoTouch.UIKit.UIBarButtonItem sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (overlayController != null) {
				overlayController.Dispose ();
				overlayController = null;
			}

			if (enableUPCESwitch != null) {
				enableUPCESwitch.Dispose ();
				enableUPCESwitch = null;
			}

			if (enableEAN8Switch != null) {
				enableEAN8Switch.Dispose ();
				enableEAN8Switch = null;
			}

			if (typeLabel != null) {
				typeLabel.Dispose ();
				typeLabel = null;
			}

			if (enableSTICKYSwitch != null) {
				enableSTICKYSwitch.Dispose ();
				enableSTICKYSwitch = null;
			}

			if (enableEAN13Switch != null) {
				enableEAN13Switch.Dispose ();
				enableEAN13Switch = null;
			}

			if (enableCode39Switch != null) {
				enableCode39Switch.Dispose ();
				enableCode39Switch = null;
			}

			if (enableCode128Switch != null) {
				enableCode128Switch.Dispose ();
				enableCode128Switch = null;
			}

			if (enableDataMatrixSwitch != null) {
				enableDataMatrixSwitch.Dispose ();
				enableDataMatrixSwitch = null;
			}

			if (enableQRCodeSwitch != null) {
				enableQRCodeSwitch.Dispose ();
				enableQRCodeSwitch = null;
			}

			if (enableITFSwitch != null) {
				enableITFSwitch.Dispose ();
				enableITFSwitch = null;
			}

			if (barcodeTextLabel != null) {
				barcodeTextLabel.Dispose ();
				barcodeTextLabel = null;
			}
		}
	}
}
