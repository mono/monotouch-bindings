using System;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using System.Drawing;

namespace WEPopover
{
	[BaseType(typeof(NSObject))]
	interface WEPopoverController
	{
		[Export("contentViewController")]
		UIViewController ContentViewController { get; set; }

		[Export("view")]
		UIView View { get; }

		[Export("popoverVisible")]
		bool IsPopoverVisible { [Bind("isPopoverVisible")] get; }

		[Export("popoverArrowDirection")]
		UIPopoverArrowDirection ArrowDirection { get; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Assign)]  
		NSObject WeakDelegate { get; set; }

		[NullAllowed]
		[Wrap ("WeakDelegate")]
		WEPopoverControllerDelegate Delegate { get; set; }  

		[Export("popoverContentSize", ArgumentSemantic.Assign)]
		SizeF ContentSize { get; set; }

		[Export("containerViewProperties")]
		WEPopoverContainerViewProperties Properties { get; set; }

		[Export("context")]
		NSObject Context { get; set; }

		[Export("passthroughViews", ArgumentSemantic.Copy)]
		NSArray PassthroughViews { get; set; }

		[Export("initWithContentViewController:")]
		IntPtr Constructor(UIViewController contentController);

		[Export("dismissPopoverAnimated:")]
		void DismissAnimated(bool animated);

		[Export("presentPopoverFromBarButtonItem:permittedArrowDirections:animated:")]
		void PresentFromBarButtonItem(UIBarButtonItem item, UIPopoverArrowDirection direction, bool animated);

		[Export("presentPopoverFromRect:inView:permittedArrowDirections:animated:")]
		void PresentFromRect(RectangleF rect, UIView view, UIPopoverArrowDirection direction, bool animated);

		[Export("repositionPopoverFromRect:inView:permittedArrowDirections:")]
		void RepositionFromRect(RectangleF rect, UIView view, UIPopoverArrowDirection direction);

	}

	[BaseType(typeof(NSObject))]
	[Model]
	[Protocol]
	interface WEPopoverControllerDelegate
	{
		[Export("popoverControllerDidDismissPopover:")]
		void DidDismissPopover(WEPopoverController popover);

		[Export("popoverControllerShouldDismissPopover:")]
		bool ShouldDismissPopover(WEPopoverController popover);
	}

	[BaseType(typeof(UIView))]
	interface WETouchableView
	{
		[Export("touchForwardingDisabled", ArgumentSemantic.Assign)]
		bool TouchForwardingDisabled { get; set; }


		[NullAllowed]
		[Export("delegate", ArgumentSemantic.Assign)]
		WETouchableViewDelegate Delegate { get; set; }

		[Export("passthroughViews", ArgumentSemantic.Copy)]
		NSArray PassThroughViews { get; set; }
	}

	[Model]
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface WETouchableViewDelegate
	{
		[Export("viewWasTouched:")]
		void ViewWasTouched(WETouchableView view);


	}

	[Model]
	[Protocol]
	[BaseType(typeof(NSObject))]
	interface WEPopoverParentView
	{
		[Export("displayAreaForPopover")]
		RectangleF GetDisplayArea();
	}

	[BaseType(typeof(UIView))]
	interface WEPopoverContainerView
	{
		[Export("initWithSize:anchorRect:displayArea:permittedArrowDirections:properties:")]
		IntPtr Constructor(SizeF size, RectangleF anchorRect, RectangleF displayArea, UIPopoverArrowDirection direction, WEPopoverContainerViewProperties properties);

		[Export("arrowDirection")]
		UIPopoverArrowDirection ArrowDirection { get; set; }

		[Export("contentView")]
		UIView ContentView { get; set; }

		[Export("updatePositionWithAnchorRect:displayArea:permittedArrowDirections:")]
		void UpdatePosition(RectangleF anchorRect, Rectangle area, UIPopoverArrowDirection direction);	
	}

	[BaseType(typeof(NSObject))]
	interface WEPopoverContainerViewProperties 
	{
		[Export("bgImageName")]
		string BackgroundImageName { get; set; }

		[Export("upArrowImageName")]
		string UpArrowImageName { get; set; }

		[Export("downArrowImageName")]
		string DownArrowImageName { get; set; }

		[Export("leftArrowImageName")]
		string LeftArrowImageName { get; set; }

		[Export("rightArrowImageName")]
		string RightArrowImageName { get; set; }

		[Export("leftBgMargin", ArgumentSemantic.Assign)]
		float LeftBackgroundMargin { get; set; }

		[Export("rightBgMargin", ArgumentSemantic.Assign)]
		float RightBackgroundMargin { get; set; }

		[Export("topBgMargin", ArgumentSemantic.Assign)]
		float TopBackgroundMargin { get; set; }

		[Export("bottomBgMargin", ArgumentSemantic.Assign)]
		float BottomBackgroundMargin { get; set; }

		[Export("leftContentMargin", ArgumentSemantic.Assign)]
		float LeftContentMargin { get; set; }

		[Export("rightContentMargin", ArgumentSemantic.Assign)]
		float RightContentMargin { get; set; }

		[Export("topContentMargin", ArgumentSemantic.Assign)]
		float TopContentMargin { get; set; }

		[Export("bottomContentMargin", ArgumentSemantic.Assign)]
		float BottomContentMargin { get; set; }

		[Export("topBgCapSize", ArgumentSemantic.Assign)]
		int TopBackgroundCapSize { get; set; }

		[Export("leftBgCapSize", ArgumentSemantic.Assign)]
		int LeftBackgroundCapSize { get; set; }

		[Export("arrowMargin", ArgumentSemantic.Assign)]
		float ArrowMargin { get; set; }
	}
}