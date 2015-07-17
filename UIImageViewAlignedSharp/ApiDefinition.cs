using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace UIImageViewAlignedSharp
{
	// @interface UIImageViewAligned : UIImageView
	[BaseType (typeof (UIImageView))]
	interface UIImageViewAligned {

		// @property (nonatomic) UIImageViewAlignmentMask alignment;
		[Export ("alignment")]
		UIImageViewAlignmentMask Alignment { get; set; }

		// @property (nonatomic) BOOL alignLeft;
		[Export ("alignLeft")]
		bool AlignLeft { get; set; }

		// @property (nonatomic) BOOL alignRight;
		[Export ("alignRight")]
		bool AlignRight { get; set; }

		// @property (nonatomic) BOOL alignTop;
		[Export ("alignTop")]
		bool AlignTop { get; set; }

		// @property (nonatomic) BOOL alignBottom;
		[Export ("alignBottom")]
		bool AlignBottom { get; set; }

		// @property (nonatomic) BOOL enableScaleUp;
		[Export ("enableScaleUp")]
		bool EnableScaleUp { get; set; }

		// @property (nonatomic) BOOL enableScaleDown;
		[Export ("enableScaleDown")]
		bool EnableScaleDown { get; set; }

		// @property (readonly, nonatomic) UIImageView * realImageView;
		[Export ("realImageView")]
		UIImageView RealImageView { get; }
	}

	// @interface UIImageViewAlignedSharp : NSObject
	[BaseType (typeof (NSObject))]
	interface UIImageViewAlignedSharp {

	}
}

