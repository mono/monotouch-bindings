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
	[Register("WEPopoverContainerViewProperties")]
	public partial class WEPopoverContainerViewProperties : NSObject {
		static IntPtr selBgImageName = Selector.GetHandle ("bgImageName");
		static IntPtr selSetBgImageName = Selector.GetHandle ("setBgImageName:");
		static IntPtr selUpArrowImageName = Selector.GetHandle ("upArrowImageName");
		static IntPtr selSetUpArrowImageName = Selector.GetHandle ("setUpArrowImageName:");
		static IntPtr selDownArrowImageName = Selector.GetHandle ("downArrowImageName");
		static IntPtr selSetDownArrowImageName = Selector.GetHandle ("setDownArrowImageName:");
		static IntPtr selLeftArrowImageName = Selector.GetHandle ("leftArrowImageName");
		static IntPtr selSetLeftArrowImageName = Selector.GetHandle ("setLeftArrowImageName:");
		static IntPtr selRightArrowImageName = Selector.GetHandle ("rightArrowImageName");
		static IntPtr selSetRightArrowImageName = Selector.GetHandle ("setRightArrowImageName:");
		static IntPtr selLeftBgMargin = Selector.GetHandle ("leftBgMargin");
		static IntPtr selSetLeftBgMargin = Selector.GetHandle ("setLeftBgMargin:");
		static IntPtr selRightBgMargin = Selector.GetHandle ("rightBgMargin");
		static IntPtr selSetRightBgMargin = Selector.GetHandle ("setRightBgMargin:");
		static IntPtr selTopBgMargin = Selector.GetHandle ("topBgMargin");
		static IntPtr selSetTopBgMargin = Selector.GetHandle ("setTopBgMargin:");
		static IntPtr selBottomBgMargin = Selector.GetHandle ("bottomBgMargin");
		static IntPtr selSetBottomBgMargin = Selector.GetHandle ("setBottomBgMargin:");
		static IntPtr selLeftContentMargin = Selector.GetHandle ("leftContentMargin");
		static IntPtr selSetLeftContentMargin = Selector.GetHandle ("setLeftContentMargin:");
		static IntPtr selRightContentMargin = Selector.GetHandle ("rightContentMargin");
		static IntPtr selSetRightContentMargin = Selector.GetHandle ("setRightContentMargin:");
		static IntPtr selTopContentMargin = Selector.GetHandle ("topContentMargin");
		static IntPtr selSetTopContentMargin = Selector.GetHandle ("setTopContentMargin:");
		static IntPtr selBottomContentMargin = Selector.GetHandle ("bottomContentMargin");
		static IntPtr selSetBottomContentMargin = Selector.GetHandle ("setBottomContentMargin:");
		static IntPtr selTopBgCapSize = Selector.GetHandle ("topBgCapSize");
		static IntPtr selSetTopBgCapSize = Selector.GetHandle ("setTopBgCapSize:");
		static IntPtr selLeftBgCapSize = Selector.GetHandle ("leftBgCapSize");
		static IntPtr selSetLeftBgCapSize = Selector.GetHandle ("setLeftBgCapSize:");
		static IntPtr selArrowMargin = Selector.GetHandle ("arrowMargin");
		static IntPtr selSetArrowMargin = Selector.GetHandle ("setArrowMargin:");

		static IntPtr class_ptr = Class.GetHandle ("WEPopoverContainerViewProperties");

		public override IntPtr ClassHandle { get { return class_ptr; } }

		[Export ("init")]
		public  WEPopoverContainerViewProperties () : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::WEPopover.Messaging.this_assembly;
			if (IsDirectBinding) {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.Init);
			} else {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, Selector.Init);
			}
		}

		[Export ("initWithCoder:")]
		public WEPopoverContainerViewProperties (NSCoder coder) : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::WEPopover.Messaging.this_assembly;
			if (IsDirectBinding) {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend_IntPtr (this.Handle, Selector.InitWithCoder, coder.Handle);
			} else {
				Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.InitWithCoder, coder.Handle);
			}
		}

		public WEPopoverContainerViewProperties (NSObjectFlag t) : base (t) {}

		public WEPopoverContainerViewProperties (IntPtr handle) : base (handle) {}

		public virtual string BackgroundImageName {
			[Export ("bgImageName")]
			get {
				if (IsDirectBinding) {
					return NSString.FromHandle (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, selBgImageName));
				} else {
					return NSString.FromHandle (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selBgImageName));
				}
			}

			[Export ("setBgImageName:")]
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
			var nsvalue = new NSString (value);

				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_IntPtr (this.Handle, selSetBgImageName, nsvalue.Handle);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, selSetBgImageName, nsvalue.Handle);
				}
							nsvalue.Dispose ();

			}
		}

		public virtual string UpArrowImageName {
			[Export ("upArrowImageName")]
			get {
				if (IsDirectBinding) {
					return NSString.FromHandle (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, selUpArrowImageName));
				} else {
					return NSString.FromHandle (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selUpArrowImageName));
				}
			}

			[Export ("setUpArrowImageName:")]
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
			var nsvalue = new NSString (value);

				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_IntPtr (this.Handle, selSetUpArrowImageName, nsvalue.Handle);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, selSetUpArrowImageName, nsvalue.Handle);
				}
							nsvalue.Dispose ();

			}
		}

		public virtual string DownArrowImageName {
			[Export ("downArrowImageName")]
			get {
				if (IsDirectBinding) {
					return NSString.FromHandle (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, selDownArrowImageName));
				} else {
					return NSString.FromHandle (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selDownArrowImageName));
				}
			}

			[Export ("setDownArrowImageName:")]
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
			var nsvalue = new NSString (value);

				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_IntPtr (this.Handle, selSetDownArrowImageName, nsvalue.Handle);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, selSetDownArrowImageName, nsvalue.Handle);
				}
							nsvalue.Dispose ();

			}
		}

		public virtual string LeftArrowImageName {
			[Export ("leftArrowImageName")]
			get {
				if (IsDirectBinding) {
					return NSString.FromHandle (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, selLeftArrowImageName));
				} else {
					return NSString.FromHandle (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selLeftArrowImageName));
				}
			}

			[Export ("setLeftArrowImageName:")]
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
			var nsvalue = new NSString (value);

				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_IntPtr (this.Handle, selSetLeftArrowImageName, nsvalue.Handle);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, selSetLeftArrowImageName, nsvalue.Handle);
				}
							nsvalue.Dispose ();

			}
		}

		public virtual string RightArrowImageName {
			[Export ("rightArrowImageName")]
			get {
				if (IsDirectBinding) {
					return NSString.FromHandle (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, selRightArrowImageName));
				} else {
					return NSString.FromHandle (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, selRightArrowImageName));
				}
			}

			[Export ("setRightArrowImageName:")]
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
			var nsvalue = new NSString (value);

				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_IntPtr (this.Handle, selSetRightArrowImageName, nsvalue.Handle);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, selSetRightArrowImageName, nsvalue.Handle);
				}
							nsvalue.Dispose ();

			}
		}

		public virtual float LeftBackgroundMargin {
			[Export ("leftBgMargin", ArgumentSemantic.Assign)]
			get {
				if (IsDirectBinding) {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSend (this.Handle, selLeftBgMargin);
				} else {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSendSuper (this.SuperHandle, selLeftBgMargin);
				}
			}

			[Export ("setLeftBgMargin:", ArgumentSemantic.Assign)]
			set {
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_float (this.Handle, selSetLeftBgMargin, value);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_float (this.SuperHandle, selSetLeftBgMargin, value);
				}
			}
		}

		public virtual float RightBackgroundMargin {
			[Export ("rightBgMargin", ArgumentSemantic.Assign)]
			get {
				if (IsDirectBinding) {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSend (this.Handle, selRightBgMargin);
				} else {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSendSuper (this.SuperHandle, selRightBgMargin);
				}
			}

			[Export ("setRightBgMargin:", ArgumentSemantic.Assign)]
			set {
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_float (this.Handle, selSetRightBgMargin, value);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_float (this.SuperHandle, selSetRightBgMargin, value);
				}
			}
		}

		public virtual float TopBackgroundMargin {
			[Export ("topBgMargin", ArgumentSemantic.Assign)]
			get {
				if (IsDirectBinding) {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSend (this.Handle, selTopBgMargin);
				} else {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSendSuper (this.SuperHandle, selTopBgMargin);
				}
			}

			[Export ("setTopBgMargin:", ArgumentSemantic.Assign)]
			set {
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_float (this.Handle, selSetTopBgMargin, value);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_float (this.SuperHandle, selSetTopBgMargin, value);
				}
			}
		}

		public virtual float BottomBackgroundMargin {
			[Export ("bottomBgMargin", ArgumentSemantic.Assign)]
			get {
				if (IsDirectBinding) {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSend (this.Handle, selBottomBgMargin);
				} else {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSendSuper (this.SuperHandle, selBottomBgMargin);
				}
			}

			[Export ("setBottomBgMargin:", ArgumentSemantic.Assign)]
			set {
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_float (this.Handle, selSetBottomBgMargin, value);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_float (this.SuperHandle, selSetBottomBgMargin, value);
				}
			}
		}

		public virtual float LeftContentMargin {
			[Export ("leftContentMargin", ArgumentSemantic.Assign)]
			get {
				if (IsDirectBinding) {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSend (this.Handle, selLeftContentMargin);
				} else {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSendSuper (this.SuperHandle, selLeftContentMargin);
				}
			}

			[Export ("setLeftContentMargin:", ArgumentSemantic.Assign)]
			set {
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_float (this.Handle, selSetLeftContentMargin, value);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_float (this.SuperHandle, selSetLeftContentMargin, value);
				}
			}
		}

		public virtual float RightContentMargin {
			[Export ("rightContentMargin", ArgumentSemantic.Assign)]
			get {
				if (IsDirectBinding) {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSend (this.Handle, selRightContentMargin);
				} else {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSendSuper (this.SuperHandle, selRightContentMargin);
				}
			}

			[Export ("setRightContentMargin:", ArgumentSemantic.Assign)]
			set {
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_float (this.Handle, selSetRightContentMargin, value);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_float (this.SuperHandle, selSetRightContentMargin, value);
				}
			}
		}

		public virtual float TopContentMargin {
			[Export ("topContentMargin", ArgumentSemantic.Assign)]
			get {
				if (IsDirectBinding) {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSend (this.Handle, selTopContentMargin);
				} else {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSendSuper (this.SuperHandle, selTopContentMargin);
				}
			}

			[Export ("setTopContentMargin:", ArgumentSemantic.Assign)]
			set {
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_float (this.Handle, selSetTopContentMargin, value);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_float (this.SuperHandle, selSetTopContentMargin, value);
				}
			}
		}

		public virtual float BottomContentMargin {
			[Export ("bottomContentMargin", ArgumentSemantic.Assign)]
			get {
				if (IsDirectBinding) {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSend (this.Handle, selBottomContentMargin);
				} else {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSendSuper (this.SuperHandle, selBottomContentMargin);
				}
			}

			[Export ("setBottomContentMargin:", ArgumentSemantic.Assign)]
			set {
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_float (this.Handle, selSetBottomContentMargin, value);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_float (this.SuperHandle, selSetBottomContentMargin, value);
				}
			}
		}

		public virtual int TopBackgroundCapSize {
			[Export ("topBgCapSize", ArgumentSemantic.Assign)]
			get {
				if (IsDirectBinding) {
					return MonoTouch.ObjCRuntime.Messaging.int_objc_msgSend (this.Handle, selTopBgCapSize);
				} else {
					return MonoTouch.ObjCRuntime.Messaging.int_objc_msgSendSuper (this.SuperHandle, selTopBgCapSize);
				}
			}

			[Export ("setTopBgCapSize:", ArgumentSemantic.Assign)]
			set {
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_int (this.Handle, selSetTopBgCapSize, value);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_int (this.SuperHandle, selSetTopBgCapSize, value);
				}
			}
		}

		public virtual int LeftBackgroundCapSize {
			[Export ("leftBgCapSize", ArgumentSemantic.Assign)]
			get {
				if (IsDirectBinding) {
					return MonoTouch.ObjCRuntime.Messaging.int_objc_msgSend (this.Handle, selLeftBgCapSize);
				} else {
					return MonoTouch.ObjCRuntime.Messaging.int_objc_msgSendSuper (this.SuperHandle, selLeftBgCapSize);
				}
			}

			[Export ("setLeftBgCapSize:", ArgumentSemantic.Assign)]
			set {
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_int (this.Handle, selSetLeftBgCapSize, value);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_int (this.SuperHandle, selSetLeftBgCapSize, value);
				}
			}
		}

		public virtual float ArrowMargin {
			[Export ("arrowMargin", ArgumentSemantic.Assign)]
			get {
				if (IsDirectBinding) {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSend (this.Handle, selArrowMargin);
				} else {
					return MonoTouch.ObjCRuntime.Messaging.float_objc_msgSendSuper (this.SuperHandle, selArrowMargin);
				}
			}

			[Export ("setArrowMargin:", ArgumentSemantic.Assign)]
			set {
				if (IsDirectBinding) {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_float (this.Handle, selSetArrowMargin, value);
				} else {
					MonoTouch.ObjCRuntime.Messaging.void_objc_msgSendSuper_float (this.SuperHandle, selSetArrowMargin, value);
				}
			}
		}

	
	} /* class WEPopoverContainerViewProperties */
}
