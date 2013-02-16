using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace LAAnimatedGrid
{
	[BaseType (typeof (UIView), Name = "LAAnimatedGrid")]
	interface MTLAAnimatedGrid {

		[Export ("laagOrientation", ArgumentSemantic.Assign)]
		LAAGOrientation LaagOrientation { get; set; }

		[Export ("arrImages", ArgumentSemantic.Retain)]
		NSObject [] ArrImages { get; set; }

		[Export ("placeholderImage", ArgumentSemantic.Retain)]
		UIImage PlaceholderImage { get; set; }

		[Export ("margin", ArgumentSemantic.Assign)]
		int Margin { get; set; }

		[Export ("laagBorderColor", ArgumentSemantic.Retain)]
		UIColor LaagBorderColor { get; set; }

		[Export ("laagBackGroundColor", ArgumentSemantic.Retain)]
		UIColor LaagBackGroundColor { get; set; }
	}

	[BaseType (typeof (UIView))]
	interface LAAnimatedView {

		[Export ("locked", ArgumentSemantic.Assign)]
		bool Locked { [Bind ("isLocked")] get; set; }

		[Export ("initWithFrame:andImage:")]
		IntPtr Constructor (RectangleF frame, UIImage image);

		[Export ("setScrollBackGroundColor:")]
		void SetScrollBackGroundColor (UIColor color);

		[Export ("setImage:")]
		void SetImage (UIImage image);

		[Export ("setImageURL:placeholderImage:")]
		void SetImageURL (NSUrl url, UIImage image);
	}

}

