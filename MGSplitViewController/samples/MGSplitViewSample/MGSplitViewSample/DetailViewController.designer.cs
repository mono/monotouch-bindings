// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace MGSplitViewSample
{
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem master { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem vertical { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem divider { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem order { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIToolbar toolbar { get; set; }

		[Action ("ShowMasterToggled:")]
		partial void ShowMasterToggled (MonoTouch.Foundation.NSObject sender);

		[Action ("VerticalToggled:")]
		partial void VerticalToggled (MonoTouch.Foundation.NSObject sender);

		[Action ("DividerToggled:")]
		partial void DividerToggled (MonoTouch.Foundation.NSObject sender);

		[Action ("OrderToggled:")]
		partial void OrderToggled (MonoTouch.Foundation.NSObject sender);
	}
}
