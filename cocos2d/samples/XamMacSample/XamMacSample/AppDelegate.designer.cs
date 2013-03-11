// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;

namespace XamMacSample
{
	[Register ("AppDelegate")]
	partial class AppDelegate
	{
		[Outlet]
		MonoMac.Cocos2D.CCGLView glView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (glView != null) {
				glView.Dispose ();
				glView = null;
			}
		}
	}
}
