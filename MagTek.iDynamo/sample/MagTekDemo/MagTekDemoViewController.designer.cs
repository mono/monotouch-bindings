// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace MagTekDemo
{
	[Register ("MagTekDemoViewController")]
	partial class MagTekDemoViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIScrollView scrollView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel deviceStatus { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel revVersion { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField command { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel transStatus { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton displayResponse { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView responseData { get; set; }
		
		[Outlet]
		MonoTouch.UIKit.UITextView rawResponseData { get; set; }

		[Action ("OnSendMessageToDevice:")]
		partial void OnSendMessageToDevice (MonoTouch.Foundation.NSObject sender);

		[Action ("OnDisplayResponse:")]
		partial void OnDisplayResponse (MonoTouch.Foundation.NSObject sender);

		[Action ("OnClearScreen:")]
		partial void OnClearScreen (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (scrollView != null) {
				scrollView.Dispose ();
				scrollView = null;
			}

			if (deviceStatus != null) {
				deviceStatus.Dispose ();
				deviceStatus = null;
			}

			if (revVersion != null) {
				revVersion.Dispose ();
				revVersion = null;
			}

			if (command != null) {
				command.Dispose ();
				command = null;
			}

			if (transStatus != null) {
				transStatus.Dispose ();
				transStatus = null;
			}

			if (displayResponse != null) {
				displayResponse.Dispose ();
				displayResponse = null;
			}

			if (responseData != null) {
				responseData.Dispose ();
				responseData = null;
			}
			
			if (rawResponseData != null) {
				rawResponseData.Dispose ();
				rawResponseData = null;
			}
		}
	}
}
