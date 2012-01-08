
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

using MonoTouch.NewsstandKit;

using MonoTouch.GLKit;

using OpenTK;
namespace Flurry
{
	public partial class FlurryAppCircle : NSObject {
		
		static IntPtr selGetHookXLocYLocViewAttachToViewOrientationCanvasOrientationAutoRefreshCanvasAnimatedRewardMessageUserCookies = Selector.GetHandle ("getHook:xLoc:yLoc:view:attachToView:orientation:canvasOrientation:autoRefresh:canvasAnimated:rewardMessage:userCookies:");
		static IntPtr selOpenTakeoverOrientationRewardImageRewardMessageUserCookies = Selector.GetHandle ("openTakeover:orientation:rewardImage:rewardMessage:userCookies:");
		
		[Export ("getHook:xLoc:yLoc:view:attachToView:orientation:canvasOrientation:autoRefresh:canvasAnimated:rewardMessage:userCookies:")]
		public static MonoTouch.UIKit.UIView GetHook (string hook, int x, int y, MonoTouch.UIKit.UIView view, bool attachToView, string orientation, string canvasOrientation, bool refresh, bool canvasAnimated, string rewardMessage, NSDictionary userCookies)
		{
			if (hook == null)
				throw new ArgumentNullException ("hook");
			if (view == null)
				throw new ArgumentNullException ("view");
			if (orientation == null)
				throw new ArgumentNullException ("orientation");
			if (canvasOrientation == null)
				throw new ArgumentNullException ("canvasOrientation");
			if (rewardMessage == null)
				throw new ArgumentNullException ("rewardMessage");
			if (userCookies == null)
				throw new ArgumentNullException ("userCookies");
			var nshook = new NSString (hook);
			var nsorientation = new NSString (orientation);
			var nscanvasOrientation = new NSString (canvasOrientation);
			var nsrewardMessage = new NSString (rewardMessage);
			
			MonoTouch.UIKit.UIView ret;
			ret = (MonoTouch.UIKit.UIView) Runtime.GetNSObject (Flurry.Messaging.IntPtr_objc_msgSend_IntPtr_int_int_IntPtr_bool_IntPtr_IntPtr_bool_bool_IntPtr_IntPtr (class_ptr, selGetHookXLocYLocViewAttachToViewOrientationCanvasOrientationAutoRefreshCanvasAnimatedRewardMessageUserCookies, nshook.Handle, x, y, view.Handle, attachToView, nsorientation.Handle, nscanvasOrientation.Handle, refresh, canvasAnimated, nsrewardMessage.Handle, userCookies.Handle));
			nshook.Dispose ();
			nsorientation.Dispose ();
			nscanvasOrientation.Dispose ();
			nsrewardMessage.Dispose ();
			
			return ret;
		}
				
		[Export ("openTakeover:orientation:rewardImage:rewardMessage:userCookies:")]
		public static void OpenTakeover (string hook, string orientation, MonoTouch.UIKit.UIImage image, string message, NSDictionary userCookies)
		{
			if (hook == null)
				throw new ArgumentNullException ("hook");
			if (orientation == null)
				throw new ArgumentNullException ("orientation");
			if (image == null)
				throw new ArgumentNullException ("image");
			if (message == null)
				throw new ArgumentNullException ("message");
			if (userCookies == null)
				throw new ArgumentNullException ("userCookies");
			var nshook = new NSString (hook);
			var nsorientation = new NSString (orientation);
			var nsmessage = new NSString (message);
			
			Flurry.Messaging.void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr (class_ptr, selOpenTakeoverOrientationRewardImageRewardMessageUserCookies, nshook.Handle, nsorientation.Handle, image.Handle, nsmessage.Handle, userCookies.Handle);
			nshook.Dispose ();
			nsorientation.Dispose ();
			nsmessage.Dispose ();
			
		}
	}
	
	public partial class Messaging {
		static internal System.Reflection.Assembly this_assembly = typeof (Messaging).Assembly;

		const string LIBOBJC_DYLIB = "/usr/lib/libobjc.dylib";

		[DllImport (LIBOBJC_DYLIB, EntryPoint="objc_msgSend")]
		public extern static IntPtr IntPtr_objc_msgSend_IntPtr_int_int_IntPtr_bool_IntPtr_IntPtr_bool_bool_IntPtr_IntPtr (IntPtr receiver, IntPtr selector, IntPtr arg1, int arg2, int arg3, IntPtr arg4, bool arg5, IntPtr arg6, IntPtr arg7, bool arg8, bool arg9, IntPtr arg10, IntPtr arg11);
		[DllImport (LIBOBJC_DYLIB, EntryPoint="objc_msgSendSuper")]
		public extern static IntPtr IntPtr_objc_msgSendSuper_IntPtr_int_int_IntPtr_bool_IntPtr_IntPtr_bool_bool_IntPtr_IntPtr (IntPtr receiver, IntPtr selector, IntPtr arg1, int arg2, int arg3, IntPtr arg4, bool arg5, IntPtr arg6, IntPtr arg7, bool arg8, bool arg9, IntPtr arg10, IntPtr arg11);
		[DllImport (LIBOBJC_DYLIB, EntryPoint="objc_msgSend")]
		public extern static void void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr (IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5);
		[DllImport (LIBOBJC_DYLIB, EntryPoint="objc_msgSendSuper")]
		public extern static void void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr (IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5);
	}
}