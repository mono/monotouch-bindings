using System;
using System.Drawing;
using MonoTouch.CoreGraphics;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace KGStatusBar
{
	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "KGStatusBar")]
	interface StatusBar
	{
		[Static, Export ("showWithStatus:")]
		void ShowStatus (string status);

		[Static, Export ("showErrorWithStatus:")]
		void ShowError (string status);

		[Static, Export ("showSuccessWithStatus:")]
		void ShowSuccess (string status);

		[Static, Export ("dismiss")]
		void Dismiss ();
	}
}
