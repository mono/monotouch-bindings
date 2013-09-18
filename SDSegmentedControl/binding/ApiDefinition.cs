using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SegmentedControl
{
	[BaseType (typeof (UISegmentedControl))]
	interface SDSegmentedControl {

		[Export ("backgroundColor", ArgumentSemantic.Retain)] [New]
		UIColor BackgroundColor { get; set; }

		[Export ("borderColor", ArgumentSemantic.Retain)]
		UIColor BorderColor { get; set; }

		[Export ("borderWidth", ArgumentSemantic.Assign)]
		float BorderWidth { get; set; }

		[Export ("arrowSize", ArgumentSemantic.Assign)]
		float ArrowSize { get; set; }
	
		[Export ("arrowHeightFactor", ArgumentSemantic.Assign)]
		float ArrowHeightFactor { get; set; }

		[Export ("animationDuration", ArgumentSemantic.Assign)]
		double AnimationDuration { get; set; }

		[Export ("interItemSpace", ArgumentSemantic.Assign)]
		float InterItemSpace { get; set; }

		[Export ("stainEdgeInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets StainEdgeInsets { get; set; }

		[Export ("shadowColor", ArgumentSemantic.Retain)]
		UIColor ShadowColor { get; set; }

		[Export ("shadowRadius", ArgumentSemantic.Assign)]
		float ShadowRadius { get; set; }

		[Export ("shadowOpacity", ArgumentSemantic.Assign)]
		float ShadowOpacity { get; set; }

		[Export ("shadowOffset", ArgumentSemantic.Assign)]
		SizeF ShadowOffset { get; set; }

		[Export ("scrollView")]
		UIScrollView ScrollView { get; set; }
	}

	[BaseType (typeof (UIButton))]
	interface SDSegmentView {

		[Export ("imageSize", ArgumentSemantic.Assign)]
		SizeF ImageSize { get; set; }

		[Export ("titleFont", ArgumentSemantic.Retain)]
		UIFont TitleFont { get; set; }

		[Export ("selectedTitleFont", ArgumentSemantic.Retain)]
		UIFont SelectedTitleFont { get; set; }

		[Export ("titleShadowOffset", ArgumentSemantic.Assign)] [New]
		SizeF TitleShadowOffset { get; set; }
	}

	[BaseType (typeof (UIView))]
	interface SDStainView {

		[Export ("backgroundColor", ArgumentSemantic.Retain)] [New]
		UIColor BackgroundColor { get; set; }

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

