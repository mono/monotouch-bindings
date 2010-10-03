using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace MG {

	[BaseType (typeof (UIViewController))]
	interface MGSplitViewController  {

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		MGSplitViewControllerDelegate Delegate { get; set; }

		[Export ("showsMasterInPortrait")]
		bool ShowsMasterInPortrait { get; set; }

		[Export ("showsMasterInLandscape")]
		bool ShowsMasterInLandscape { get; set; }

		[Export ("vertical")]
		bool Vertical { [Bind ("isVertical")] get; set; }

		[Export ("masterBeforeDetail")]
		bool MasterBeforeDetail { [Bind ("isMasterBeforeDetail")] get; set; }

		[Export ("splitPosition")]
		float SplitPosition { get; set; }

		[Export ("splitWidth")]
		float SplitWidth { get; set; }

		[Export ("allowsDraggingDivider")]
		bool AllowsDraggingDivider { get; set; }

		[Export ("viewControllers")]
		UIViewController [] ViewControllers { get; set; }

		[Export ("masterViewController")]
		UIViewController MasterViewController { get; set; }

		[Export ("detailViewController")]
		UIViewController DetailViewController { get; set; }

		[Export ("dividerView")]
		MGSplitDividerView DividerView { get; set; }

		[Export ("dividerStyle")]
		MGSplitViewDividerStyle DividerStyle { get; set; }

		[Export ("landscape")]
		bool Landscape { [Bind ("isLandscape")] get; set; }

		[Export ("toggleSplitOrientation")]
		void ToggleSplitOrientation (NSObject sender);

		[Export ("toggleMasterBeforeDetail")]
		void ToggleMasterBeforeDetail (NSObject sender);

		[Export ("toggleMasterView")]
		void ToggleMasterView (NSObject sender);

		[Export ("showMasterPopover")]
		void ShowMasterPopover (NSObject sender);

		[Export ("isShowingMaster")]
		bool IsShowingMaster { get; }

		[Export ("setSplitPosition:animated:")]
		void SetSplitPosition (float position, bool animated);

		[Export ("setDividerStyle:animated:")]
		void SetDividerStyle (MGSplitViewDividerStyle style, bool animated);

		[Export ("cornerViews")]
		MGSplitCornersView [] CornerViews { get; }
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface MGSplitViewControllerDelegate {
		[Export ("splitViewController:willHideViewController:withBarButtonItem:forPopoverController:")]
		void WillHideViewController (MGSplitViewController svc, UIViewController viewController, UIBarButtonItem barButtonItem, UIPopoverController popoverController);

		[Export ("splitViewController:willShowViewController:invalidatingBarButtonItem:")]
		void WillShowViewController (MGSplitViewController svc, UIViewController viewController, UIBarButtonItem barButtonItem);

		[Export ("splitViewController:popoverController:willPresentViewController:")]
		void PopoverController (MGSplitViewController svc, UIPopoverController popovercontroller, UIViewController viewController);

		[Export ("splitViewController:willChangeSplitOrientationToVertical:")]
		void WillChangeSplitOrientation (MGSplitViewController svc, bool isVertical);

		[Export ("splitViewController:willMoveSplitToPosition:")]
		void WillMoveSplit (MGSplitViewController svc, float position);

		[Export ("splitViewController:constraintSplitPosition:splitViewSize:")]
		void ConstraintSplitPosition (MGSplitViewController svc, float proposedPosition, SizeF viewSize);
	}

	[BaseType (typeof (UIView))]
	interface MGSplitCornersView {
		[Export ("cornerRadius")]
		float CornerRadius { get; set; }

		[Export ("splitViewController")]
		MGSplitViewController SplitViewController { get; set; }

		[Export ("cornersPosition")]
		MGCornersPosition CornersPosition { get; set; }

		[Export ("cornerBackgroundColor")]
		UIColor CornerBackgroundColor { get; set; }
	}

	[BaseType (typeof (UIView))]
	interface MGSplitDividerView {
		[Export ("splitViewController")]
		MGSplitViewController SplitViewController { get; set; }

		[Export ("allowsDragging:")]
		bool AllowsDragging { get; set; }

		[Export ("rect")]
		void DrawGripThumbInRect (RectangleF rect);
	}
}
