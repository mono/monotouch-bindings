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
	[Register("WEPopoverControllerDelegate")]
	[Model]
	public partial class WEPopoverControllerDelegate : NSObject {

		static IntPtr class_ptr = Class.GetHandle ("NSObject");

		[Export ("init")]
		public  WEPopoverControllerDelegate () : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::WEPopover.Messaging.this_assembly;
			if (IsDirectBinding) {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.Init);
			} else {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, Selector.Init);
			}
		}

		[Export ("initWithCoder:")]
		public WEPopoverControllerDelegate (NSCoder coder) : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::WEPopover.Messaging.this_assembly;
			if (IsDirectBinding) {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend_IntPtr (this.Handle, Selector.InitWithCoder, coder.Handle);
			} else {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.InitWithCoder, coder.Handle);
			}
		}

		public WEPopoverControllerDelegate (NSObjectFlag t) : base (t) {}

		public WEPopoverControllerDelegate (IntPtr handle) : base (handle) {}

		[Export ("popoverControllerDidDismissPopover:")]
		public virtual void DidDismissPopover (WEPopoverController popover)
		{
			throw new You_Should_Not_Call_base_In_This_Method ();
		}

		[Export ("popoverControllerShouldDismissPopover:")]
		public virtual bool ShouldDismissPopover (WEPopoverController popover)
		{
			throw new You_Should_Not_Call_base_In_This_Method ();
		}

	
	} /* class WEPopoverControllerDelegate */
}
