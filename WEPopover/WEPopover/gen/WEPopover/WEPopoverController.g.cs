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
	[Register("WEPopoverController")]
	public partial class WEPopoverController : NSObject {
		static IntPtr selContentViewController = Selector.GetHandle ("contentViewController");
		static IntPtr selSetContentViewController = Selector.GetHandle ("setContentViewController:");
		static IntPtr selView = Selector.GetHandle ("view");
		static IntPtr selIsPopoverVisible = Selector.GetHandle ("isPopoverVisible");
		static IntPtr selPopoverArrowDirection = Selector.GetHandle ("popoverArrowDirection");
		static IntPtr selDelegate = Selector.GetHandle ("delegate");
		static IntPtr selSetDelegate = Selector.GetHandle ("setDelegate:");
		static IntPtr selPopoverContentSize = Selector.GetHandle ("popoverContentSize");
		static IntPtr selSetPopoverContentSize = Selector.GetHandle ("setPopoverContentSize:");
		static IntPtr selContainerViewProperties = Selector.GetHandle ("containerViewProperties");
		static IntPtr selSetContainerViewProperties = Selector.GetHandle ("setContainerViewProperties:");
		static IntPtr selContext = Selector.GetHandle ("context");
		static IntPtr selSetContext = Selector.GetHandle ("setContext:");
		static IntPtr selPassthroughViews = Selector.GetHandle ("passthroughViews");
		static IntPtr selSetPassthroughViews = Selector.GetHandle ("setPassthroughViews:");
		static IntPtr selInitWithContentViewController = Selector.GetHandle ("initWithContentViewController:");
		static IntPtr selDismissPopoverAnimated = Selector.GetHandle ("dismissPopoverAnimated:");
		static IntPtr selPresentPopoverFromBarButtonItem = Selector.GetHandle ("presentPopoverFromBarButtonItem:");
		static IntPtr selPresentPopoverFromRect = Selector.GetHandle ("presentPopoverFromRect:");
		static IntPtr selRepositionPopoverFromRect = Selector.GetHandle ("repositionPopoverFromRect:");

		static IntPtr class_ptr = Class.GetHandle ("WEPopoverController");

		public override IntPtr ClassHandle { get { return class_ptr; } }

		[Export ("init")]
		public  WEPopoverController () : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::WEPopover.Messaging.this_assembly;
			if (IsDirectBinding) {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.Init);
			} else {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, Selector.Init);
			}
		}

		[Export ("initWithCoder:")]
		public WEPopoverController (NSCoder coder) : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::WEPopover.Messaging.this_assembly;
			if (IsDirectBinding) {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend_IntPtr (this.Handle, Selector.InitWithCoder, coder.Handle);
			} else {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.InitWithCoder, coder.Handle);
			}
		}

		public WEPopoverController (NSObjectFlag t) : base (t) {}

		public WEPopoverController (IntPtr handle) : base (handle) {}

		[Export ("initWithContentViewController:")]
		public WEPopoverController (MonoTouch.UIKit.UIViewController contentController) : base (NSObjectFlag.Empty)
		{
			if (contentController == null)
				throw new ArgumentNullException ("contentController");
			IsDirectBinding = GetType ().Assembly == global::WEPopover.Messaging.this_assembly;
			if (IsDirectBinding) {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend_IntPtr (this.Handle, selInitWithContentViewController, contentController.Handle);
			} else {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper_IntPtr (this.SuperHandle, selInitWithContentViewController, contentController.Handle);
			}
		}

		[Export ("dismissPopoverAnimated:")]
		public virtual void DismissAnimated (bool animated)
		{
			if (IsDirectBinding) {
				MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_bool (this.Handle, selDismissPopoverAnimated, animated);
			} else {
				MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_bool (this.SuperHandle, selDismissPopoverAnimated, animated);
			}
		}

		[Export ("presentPopoverFromBarButtonItem:")]
		public virtual void PresentFromBarButtonItem (MonoTouch.UIKit.UIBarButtonItem item, MonoTouch.UIKit.UIPopoverArrowDirection direction, bool animated)
		{
			if (item == null)
				throw new ArgumentNullException ("item");
			if (IsDirectBinding) {
				MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_IntPtr_UInt32_bool (this.Handle, selPresentPopoverFromBarButtonItem, item.Handle, (UInt32)direction, animated);
			} else {
				MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_IntPtr_UInt32_bool (this.SuperHandle, selPresentPopoverFromBarButtonItem, item.Handle, (UInt32)direction, animated);
			}
		}

		[Export ("presentPopoverFromRect:")]
		public virtual void PresentFromRect (System.Drawing.RectangleF rect, MonoTouch.UIKit.UIView view, MonoTouch.UIKit.UIPopoverArrowDirection direction, bool animated)
		{
			if (view == null)
				throw new ArgumentNullException ("view");
			if (IsDirectBinding) {
				MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_RectangleF_IntPtr_UInt32_bool (this.Handle, selPresentPopoverFromRect, rect, view.Handle, (UInt32)direction, animated);
			} else {
				MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_RectangleF_IntPtr_UInt32_bool (this.SuperHandle, selPresentPopoverFromRect, rect, view.Handle, (UInt32)direction, animated);
			}
		}

		[Export ("repositionPopoverFromRect:")]
		public virtual void RepositionFromRect (System.Drawing.RectangleF rect, MonoTouch.UIKit.UIView view, MonoTouch.UIKit.UIPopoverArrowDirection direction)
		{
			if (view == null)
				throw new ArgumentNullException ("view");
			if (IsDirectBinding) {
				WEPopover.Messaging.void_objc_msgSend_RectangleF_IntPtr_UInt32 (this.Handle, selRepositionPopoverFromRect, rect, view.Handle, (UInt32)direction);
			} else {
				WEPopover.Messaging.void_objc_msgSendSuper_RectangleF_IntPtr_UInt32 (this.SuperHandle, selRepositionPopoverFromRect, rect, view.Handle, (UInt32)direction);
			}
		}

		MonoTouch.UIKit.UIViewController __mt_ContentViewController_var;
		public virtual MonoTouch.UIKit.UIViewController ContentViewController {
			[Export ("contentViewController")]
			get {
				MonoTouch.UIKit.UIViewController ret;
				if (IsDirectBinding) {
					ret = (MonoTouch.UIKit.UIViewController) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, selContentViewController));
				} else {
					ret = (MonoTouch.UIKit.UIViewController) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selContentViewController));
				}
				__mt_ContentViewController_var = ret;
				return ret;
			}

			[Export ("setContentViewController:")]
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_IntPtr (this.Handle, selSetContentViewController, value.Handle);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, selSetContentViewController, value.Handle);
				}
				__mt_ContentViewController_var = value;
			}
		}

		MonoTouch.UIKit.UIView __mt_View_var;
		public virtual MonoTouch.UIKit.UIView View {
			[Export ("view")]
			get {
				MonoTouch.UIKit.UIView ret;
				if (IsDirectBinding) {
					ret = (MonoTouch.UIKit.UIView) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, selView));
				} else {
					ret = (MonoTouch.UIKit.UIView) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selView));
				}
				__mt_View_var = ret;
				return ret;
			}

		}

		public virtual bool IsPopoverVisible {
			[Export ("isPopoverVisible")]
			get {
				if (IsDirectBinding) {
					return MonoTouch.ObjCRuntime.Messaging.bool_objc_msgSend (this.Handle, selIsPopoverVisible);
				} else {
					return MonoTouch.ObjCRuntime.Messaging.bool_objc_msgSendSuper (this.SuperHandle, selIsPopoverVisible);
				}
			}

		}

		public virtual MonoTouch.UIKit.UIPopoverArrowDirection ArrowDirection {
			[Export ("popoverArrowDirection")]
			get {
				if (IsDirectBinding) {
					return (MonoTouch.UIKit.UIPopoverArrowDirection) MonoTouch.ObjCRuntime.Messaging.UInt32_objc_msgSend (this.Handle, selPopoverArrowDirection);
				} else {
					return (MonoTouch.UIKit.UIPopoverArrowDirection) MonoTouch.ObjCRuntime.Messaging.UInt32_objc_msgSendSuper (this.SuperHandle, selPopoverArrowDirection);
				}
			}

		}

		WEPopover.WEPopoverControllerDelegate __mt_Delegate_var;
		public virtual WEPopoverControllerDelegate Delegate {
			[Export ("delegate", ArgumentSemantic.Assign)]
			get {
				WEPopoverControllerDelegate ret;
				if (IsDirectBinding) {
					ret = (WEPopoverControllerDelegate) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, selDelegate));
				} else {
					ret = (WEPopoverControllerDelegate) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selDelegate));
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

		public virtual System.Drawing.SizeF ContentSize {
			[Export ("popoverContentSize", ArgumentSemantic.Assign)]
			get {
				System.Drawing.SizeF ret;
				if (IsDirectBinding) {
					if (Runtime.Arch == Arch.DEVICE){
						MonoTouch.ObjCRuntime.Messaging.SizeF_objc_msgSend_stret (out ret, this.Handle, selPopoverContentSize);
					} else {
						ret = MonoTouch.ObjCRuntime.Messaging.SizeF_objc_msgSend (this.Handle, selPopoverContentSize);
					}
				} else {
					if (Runtime.Arch == Arch.DEVICE){
						MonoTouch.ObjCRuntime.Messaging.SizeF_objc_msgSendSuper_stret (out ret, this.SuperHandle, selPopoverContentSize);
					} else {
						ret = MonoTouch.ObjCRuntime.Messaging.SizeF_objc_msgSendSuper (this.SuperHandle, selPopoverContentSize);
					}
				}
				return ret;
			}

			[Export ("setPopoverContentSize:", ArgumentSemantic.Assign)]
			set {
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_SizeF (this.Handle, selSetPopoverContentSize, value);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_SizeF (this.SuperHandle, selSetPopoverContentSize, value);
				}
			}
		}

		WEPopover.WEPopoverContainerViewProperties __mt_Properties_var;
		public virtual WEPopoverContainerViewProperties Properties {
			[Export ("containerViewProperties")]
			get {
				WEPopoverContainerViewProperties ret;
				if (IsDirectBinding) {
					ret = (WEPopoverContainerViewProperties) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, selContainerViewProperties));
				} else {
					ret = (WEPopoverContainerViewProperties) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selContainerViewProperties));
				}
				__mt_Properties_var = ret;
				return ret;
			}

			[Export ("setContainerViewProperties:")]
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_IntPtr (this.Handle, selSetContainerViewProperties, value.Handle);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, selSetContainerViewProperties, value.Handle);
				}
				__mt_Properties_var = value;
			}
		}

		MonoTouch.Foundation.NSObject __mt_Context_var;
		public virtual NSObject Context {
			[Export ("context")]
			get {
				NSObject ret;
				if (IsDirectBinding) {
					ret = (NSObject) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, selContext));
				} else {
					ret = (NSObject) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selContext));
				}
				__mt_Context_var = ret;
				return ret;
			}

			[Export ("setContext:")]
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_IntPtr (this.Handle, selSetContext, value.Handle);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, selSetContext, value.Handle);
				}
				__mt_Context_var = value;
			}
		}

		MonoTouch.Foundation.NSArray __mt_PassthroughViews_var;
		public virtual NSArray PassthroughViews {
			[Export ("passthroughViews", ArgumentSemantic.Copy)]
			get {
				NSArray ret;
				if (IsDirectBinding) {
					ret = (NSArray) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, selPassthroughViews));
				} else {
					ret = (NSArray) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selPassthroughViews));
				}
				__mt_PassthroughViews_var = ret;
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
				__mt_PassthroughViews_var = value;
			}
		}

	
	} /* class WEPopoverController */
}
