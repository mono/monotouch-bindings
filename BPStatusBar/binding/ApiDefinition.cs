using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace BPStatusBar
{
	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "BPStatusBar")]
	interface StatusBar
	{
		[Static]
		[Export ("transitionStyle")]
		UIStatusBarAnimation TransitionStyle { get; set; }

		[Static]
		[Export ("showStatus:")]
		void ShowStatus (string status);

		[Static]
		[Export ("showActivityWithStatus:")]
		void ShowActivity (string status);

		[Static]
		[Export ("showSuccessWithStatus:")]
		void ShowSuccess (string status);

		[Static]
		[Export ("showErrorWithStatus:")]
		void ShowError (string status);

		[Static]
		[Export ("showImage:status:")]
		void ShowImage (UIImage image, string status);

		[Static]
		[Export ("dismiss")]
		void Dismiss ();

		[Static]
		[Export ("isVisible")]
		bool IsVisible { get; }
	}
}

