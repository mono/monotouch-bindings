using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SegmentedControl
{
	[BaseType (typeof (UISegmentedControl))]
	interface SDSegmentedControl {

		[Export ("backgroundColor")] [New]
		UIColor BackgroundColor { get; set; }

		[Export ("borderColor")]
		UIColor BorderColor { get; set; }

		[Export ("arrowSize", ArgumentSemantic.Assign)]
		float ArrowSize { get; set; }
	
		[Export ("arrowHeightFactor", ArgumentSemantic.Assign)]
		float ArrowHeightFactor { get; set; }

		[Export ("animationDuration", ArgumentSemantic.Assign)]
		double AnimationDuration { get; set; }

		[Export ("stainEdgeInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets StainEdgeInsets { get; set; }

		[Export ("scrollView")]
		UIScrollView ScrollView { get; set; }
	}

	[BaseType (typeof (UIButton))]
	interface SDSegmentView {

		[Export ("imageSize", ArgumentSemantic.Assign)]
		SizeF ImageSize { get; set; }

	}

	[BaseType (typeof (UIView))]
	interface SDStainView {

		[Export ("cornerRadius", ArgumentSemantic.Assign)]
		float CornerRadius { get; set; }

		[Export ("edgeInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets EdgeInsets { get; set; }

		[Export ("shadowOffset", ArgumentSemantic.Assign)]
		SizeF ShadowOffset { get; set; }

		[Export ("shadowBlur", ArgumentSemantic.Assign)]
		float ShadowBlur { get; set; }

		[Export ("shadowColor", ArgumentSemantic.Assign)]
		UIColor ShadowColor { get; set; }

		[Export ("innerStrokeLineWidth", ArgumentSemantic.Assign)]
		float InnerStrokeLineWidth { get; set; }

		[Export ("innerStrokeColor", ArgumentSemantic.Assign)]
		UIColor InnerStrokeColor { get; set; }
	}

}

