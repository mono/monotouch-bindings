
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
namespace FlurryAnalytics
{
	public partial class FlurryAnalytics : NSObject {
		
		static IntPtr selSetLatitudeLongitudeHorizontalAccuracyVerticalAccuracy = Selector.GetHandle ("setLatitude:longitude:horizontalAccuracy:verticalAccuracy:");
		
		[Export ("setLatitude:longitude:horizontalAccuracy:verticalAccuracy:")]
		public static void SetLocation (System.Double latitude, System.Double longitude, float horizontalAccuracy, float verticalAccuracy)
		{
			Messaging.void_objc_msgSend_Double_Double_float_float (class_ptr, selSetLatitudeLongitudeHorizontalAccuracyVerticalAccuracy, latitude, longitude, horizontalAccuracy, verticalAccuracy);
		}
	}
	public partial class Messaging {
		[DllImport (LIBOBJC_DYLIB, EntryPoint="objc_msgSend")]
		public extern static void void_objc_msgSend_Double_Double_float_float (IntPtr receiver, IntPtr selector, Double arg1, Double arg2, float arg3, float arg4);
		//[DllImport (LIBOBJC_DYLIB, EntryPoint="objc_msgSendSuper")]
		//public extern static void void_objc_msgSendSuper_Double_Double_float_float (IntPtr receiver, IntPtr selector, Double arg1, Double arg2, float arg3, float arg4);
	}
}