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
	[Register("WETouchableView")]
	public partial class WETouchableView : MonoTouch.UIKit.UIView {
		static IntPtr selTouchForwardingDisabled = Selector.GetHandle ("touchForwardingDisabled");
		static IntPtr selSetTouchForwardingDisabled = Selector.GetHandle ("setTouchForwardingDisabled:");
		static IntPtr selDelegate = Selector.GetHandle ("delegate");
		static IntPtr selSetDelegate = Selector.GetHandle ("setDelegate:");
		static IntPtr selPassthroughViews = Selector.GetHandle ("passthroughViews");
		static IntPtr selSetPassthroughViews = Selector.GetHandle ("setPassthroughViews:");

		static IntPtr class_ptr = Class.GetHandle ("WETouchableView");

		public override IntPtr ClassHandle { get { return class_ptr; } }

		[Export ("init")]
		public  WETouchableView () : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::WEPopover.Messaging.this_assembly;
			if (IsDirectBinding) {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.Init);
			} else {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, Selector.Init);
			}
		}

		[Export ("initWithCoder:")]
		public WETouchableView (NSCoder coder) : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::WEPopover.Messaging.this_assembly;
			if (IsDirectBinding) {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend_IntPtr (this.Handle, Selector.InitWithCoder, coder.Handle);
			} else {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.InitWithCoder, coder.Handle);
			}
		}

		public WETouchableView (NSObjectFlag t) : base (t) {}

		public WETouchableView (IntPtr handle) : base (handle) {}

		public virtual bool TouchForwardingDisabled {
			[Export ("touchForwardingDisabled", ArgumentSemantic.Assign)]
			get {
				if (IsDirectBinding) {
					return MonoTouch.ObjCRuntime.Messaging.bool_objc_msgSend (this.Handle, selTouchForwardingDisabled);
				} else {
					return MonoTouch.ObjCRuntime.Messaging.bool_objc_msgSendSuper (this.SuperHandle, selTouchForwardingDisabled);
				}
			}

			[Export ("setTouchForwardingDisabled:", ArgumentSemantic.Assign)]
			set {
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_bool (this.Handle, selSetTouchForwardingDisabled, value);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_bool (this.SuperHandle, selSetTouchForwardingDisabled, value);
				}
			}
		}

		WEPopover.WETouchableViewDelegate __mt_Delegate_var;
		public virtual WETouchableViewDelegate Delegate {
			[Export ("delegate", ArgumentSemantic.Assign)]
			get {
				WETouchableViewDelegate ret;
				if (IsDirectBinding) {
					ret = (WETouchableViewDelegate) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, selDelegate));
				} else {
					ret = (WETouchableViewDelegate) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selDelegate));
				}
				__mt_Delegate_var = ret;
				return ret;
			}

			[Export ("setDelegate:", ArgumentSemantic.Assign)]
			set {
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_IntPtr (this.Handle, selSetDelegate, value == null ? IntPtr.Zero : value.Handle);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, selSetDelegate, value == null ? IntPtr.Zero : value.Handle);
				}
				__mt_Delegate_var = value;
			}
		}

		MonoTouch.Foundation.NSArray __mt_PassThroughViews_var;
		public virtual NSArray PassThroughViews {
			[Export ("passthroughViews", ArgumentSemantic.Copy)]
			get {
				NSArray ret;
				if (IsDirectBinding) {
					ret = (NSArray) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, selPassthroughViews));
				} else {
					ret = (NSArray) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selPassthroughViews));
				}
				__mt_PassThroughViews_var = ret;
				return ret;
			}

			[Export ("setPassthroughViews:", ArgumentSemantic.Copy)]
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_IntPtr (this.Handle, selSetPassthroughViews, value.Handle);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, selSetPassthroughViews, value.Handle);
				}
				__mt_PassThroughViews_var = value;
			}
		}

	
	} /* class WETouchableView */
}
