using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

namespace WEPopover
{
	[BaseType(typeof(NSObject))]
	public interface WEPopoverController
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
		[Export("delegate", ArgumentSemantic.Assign)]
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
		
		[Export("presentPopoverFromBarButtonItem:")]
		void PresentFromBarButtonItem(UIBarButtonItem item, UIPopoverArrowDirection direction, bool animated);
		
		[Export("presentPopoverFromRect:")]
		void PresentFromRect(RectangleF rect, UIView view, UIPopoverArrowDirection direction, bool animated);
		
		[Export("repositionPopoverFromRect:")]
		void RepositionFromRect(RectangleF rect, UIView view, UIPopoverArrowDirection direction);
		
	}
	
	[Model]
	[BaseType(typeof(NSObject))]
	public interface WEPopoverControllerDelegate
	{
		[Export("popoverControllerDidDismissPopover:")]
		void DidDismissPopover(WEPopoverController popover);
		[Export("popoverControllerShouldDismissPopover:")]
		bool ShouldDismissPopover(WEPopoverController popover);
	}
}



