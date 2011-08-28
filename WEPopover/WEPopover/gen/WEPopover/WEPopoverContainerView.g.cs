//
// Auto-generated from generator.cs, do not edit
//
// We keep references to objects, so warning 414 is expected

#pragma warning disable 414

using System;

using System.Drawing;

using System.Runtime.InteropServices;

using MonoTouch;

using MonoTouch.CoreFoundation;

using MonoTouch.CoreMedia;

using MonoTouch.CoreMotion;

using MonoTouch.Foundation;

using MonoTouch.ObjCRuntime;

using MonoTouch.CoreAnimation;

using MonoTouch.CoreLocation;

using MonoTouch.MapKit;

using MonoTouch.UIKit;

using MonoTouch.CoreGraphics;

namespace WEPopover {
	[Register("WEPopoverContainerView")]
	public partial class WEPopoverContainerView : MonoTouch.UIKit.UIView {
		static IntPtr selArrowDirection = Selector.GetHandle ("arrowDirection");
		static IntPtr selSetArrowDirection = Selector.GetHandle ("setArrowDirection:");
		static IntPtr selContentView = Selector.GetHandle ("contentView");
		static IntPtr selSetContentView = Selector.GetHandle ("setContentView:");
		static IntPtr selInitWithSize = Selector.GetHandle ("initWithSize:");
		static IntPtr selUpdatePositionWithAnchorRect = Selector.GetHandle ("updatePositionWithAnchorRect:");

		static IntPtr class_ptr = Class.GetHandle ("WEPopoverContainerView");

		public override IntPtr ClassHandle { get { return class_ptr; } }

		[Export ("init")]
		public  WEPopoverContainerView () : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::WEPopover.Messaging.this_assembly;
			if (IsDirectBinding) {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.Init);
			} else {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, Selector.Init);
			}
		}

		[Export ("initWithCoder:")]
		public WEPopoverContainerView (NSCoder coder) : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::WEPopover.Messaging.this_assembly;
			if (IsDirectBinding) {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend_IntPtr (this.Handle, Selector.InitWithCoder, coder.Handle);
			} else {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.InitWithCoder, coder.Handle);
			}
		}

		public WEPopoverContainerView (NSObjectFlag t) : base (t) {}

		public WEPopoverContainerView (IntPtr handle) : base (handle) {}

		[Export ("initWithSize:")]
		public WEPopoverContainerView (System.Drawing.SizeF size, System.Drawing.RectangleF achorRect, System.Drawing.RectangleF displayArea, MonoTouch.UIKit.UIPopoverArrowDirection direction) : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::WEPopover.Messaging.this_assembly;
			if (IsDirectBinding) {
				Handle = WEPopover.Messaging.IntPtr_objc_msgSend_SizeF_RectangleF_RectangleF_UInt32 (this.Handle, selInitWithSize, size, achorRect, displayArea, (UInt32)direction);
			} else {
				Handle = WEPopover.Messaging.IntPtr_objc_msgSendSuper_SizeF_RectangleF_RectangleF_UInt32 (this.SuperHandle, selInitWithSize, size, achorRect, displayArea, (UInt32)direction);
			}
		}

		[Export ("updatePositionWithAnchorRect:")]
		public virtual void UpdatePosition (System.Drawing.RectangleF anchorRect, System.Drawing.Rectangle area, MonoTouch.UIKit.UIPopoverArrowDirection direction)
		{
			if (IsDirectBinding) {
				WEPopover.Messaging.void_objc_msgSend_RectangleF_Rectangle_UInt32 (this.Handle, selUpdatePositionWithAnchorRect, anchorRect, area, (UInt32)direction);
			} else {
				WEPopover.Messaging.void_objc_msgSendSuper_RectangleF_Rectangle_UInt32 (this.SuperHandle, selUpdatePositionWithAnchorRect, anchorRect, area, (UInt32)direction);
			}
		}

		public virtual MonoTouch.UIKit.UIPopoverArrowDirection ArrowDirection {
			[Export ("arrowDirection")]
			get {
				if (IsDirectBinding) {
					return (MonoTouch.UIKit.UIPopoverArrowDirection) MonoTouch.ObjCRuntime.Messaging.UInt32_objc_msgSend (this.Handle, selArrowDirection);
				} else {
					return (MonoTouch.UIKit.UIPopoverArrowDirection) MonoTouch.ObjCRuntime.Messaging.UInt32_objc_msgSendSuper (this.SuperHandle, selArrowDirection);
				}
			}

			[Export ("setArrowDirection:")]
			set {
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_UInt32 (this.Handle, selSetArrowDirection, (UInt32)value);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_UInt32 (this.SuperHandle, selSetArrowDirection, (UInt32)value);
				}
			}
		}

		MonoTouch.UIKit.UIView __mt_ContentView_var;
		public virtual MonoTouch.UIKit.UIView ContentView {
			[Export ("contentView")]
			get {
				MonoTouch.UIKit.UIView ret;
				if (IsDirectBinding) {
					ret = (MonoTouch.UIKit.UIView) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, selContentView));
				} else {
					ret = (MonoTouch.UIKit.UIView) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selContentView));
				}
				__mt_ContentView_var = ret;
				return ret;
			}

			[Export ("setContentView:")]
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_IntPtr (this.Handle, selSetContentView, value.Handle);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, selSetContentView, value.Handle);
				}
				__mt_ContentView_var = value;
			}
		}

	
	} /* class WEPopoverContainerView */
}
