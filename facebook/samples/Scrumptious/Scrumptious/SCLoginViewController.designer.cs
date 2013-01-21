// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Scrumptious
{
	[Register ("SCLoginViewController")]
	partial class SCLoginViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView Spinner { get; set; }

		[Action ("PerformLogin:")]
		partial void PerformLogin (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Spinner != null) {
				Spinner.Dispose ();
				Spinner = null;
			}
		}
	}
}
