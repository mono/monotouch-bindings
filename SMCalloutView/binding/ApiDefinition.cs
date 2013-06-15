using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;


namespace SMCalloutView
{
	[BaseType (typeof (UIView), Name = "SMCalloutView",
	Delegates= new string [] {"WeakDelegate"},
	Events=new Type [] { typeof (CalloutViewDelegate) })]
	interface CalloutView {

		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);

		[Wrap ("WeakDelegate")][NullAllowed]
		CalloutViewDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("title", ArgumentSemantic.Copy)][NullAllowed]
		string Title { get; set; }

		[Export ("subtitle", ArgumentSemantic.Copy)][NullAllowed]
		string Subtitle { get; set; }

		[Export ("leftAccessoryView", ArgumentSemantic.Retain)][NullAllowed]
		UIView LeftAccessoryView { get; set; }

		[Export ("rightAccessoryView", ArgumentSemantic.Retain)][NullAllowed]
		UIView RightAccessoryView { get; set; }

		[Export ("currentArrowDirection")]
		CalloutArrowDirection CurrentArrowDirection { get; }

		[Export ("backgroundView", ArgumentSemantic.Retain)]
		CalloutBackgroundView BackgroundView { get; set; }

		[Export ("titleView", ArgumentSemantic.Retain)][NullAllowed]
		UIView TitleView { get; set; }

		[Export ("subtitleView", ArgumentSemantic.Retain)][NullAllowed]
		UIView SubtitleView { get; set; }

		[Export ("contentView", ArgumentSemantic.Retain)][NullAllowed]
		UIView ContentView { get; set; }

		[Export ("calloutOffset", ArgumentSemantic.Retain)]
		PointF CalloutOffset { get; set; }

		[Export ("presentAnimation", ArgumentSemantic.Assign)]
		CalloutAnimation PresentAnimation { get; set; }

		[Export ("dismissAnimation", ArgumentSemantic.Assign)]
		CalloutAnimation DismissAnimation { get; set; }

		[Export ("presentCalloutFromRect:inView:constrainedToView:permittedArrowDirections:animated:")]
		void PresentCallout (RectangleF frame, UIView view, UIView constrainedView, CalloutArrowDirection arrowDirections, bool animated);

		[Export ("presentCalloutFromRect:inLayer:constrainedToLayer:permittedArrowDirections:animated:")]
		void PresentCallout (RectangleF frame, CALayer layer, CALayer constrainedLayer, CalloutArrowDirection arrowDirections, bool animated);

		[Export ("dismissCalloutAnimated:")]
		void DismissCallout (bool animated); 
	}

	[BaseType (typeof (UIView), Name = "SMCalloutBackgroundView")]
	interface CalloutBackgroundView {

		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);

		[Export ("arrowPoint", ArgumentSemantic.Assign)]
		PointF ArrowPoint { get; set; }

		[Static]
		[Export ("systemBackgroundView", ArgumentSemantic.Assign)]
		CalloutBackgroundView SystemBackgroundView { get; }
	}

	[BaseType (typeof (CalloutBackgroundView), Name = "SMCalloutImageBackgroundView")]
	interface CalloutImageBackgroundView {

		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);

		[Export ("leftCapImage", ArgumentSemantic.Retain)]
		UIImage LeftCapImage { get; set; }

		[Export ("rightCapImage", ArgumentSemantic.Retain)]
		UIImage RightCapImage { get; set; }

		[Export ("topAnchorImage", ArgumentSemantic.Retain)]
		UIImage TopAnchorImage { get; set; }

		[Export ("bottomAnchorImage", ArgumentSemantic.Retain)]
		UIImage BottomAnchorImage { get; set; }

		[Export ("backgroundImage", ArgumentSemantic.Retain)]
		UIImage BackgroundImage { get; set; }
	}

	[BaseType (typeof (CalloutBackgroundView), Name = "SMCalloutDrawnBackgroundView")]
	interface CalloutDrawnBackgroundView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);
	}

	[BaseType (typeof (NSObject), Name = "SMCalloutViewDelegate")]
	[Protocol]
	[Model]
	interface CalloutViewDelegate {
		[Export ("calloutView:delayForRepositionWithSize:"), DelegateName ("CVDelayForReposition"), DefaultValue ("1.0/3.0")]
		double DelayForReposition (CalloutView calloutView, SizeF offset);

		[Export ("calloutViewWillAppear:"), EventArgs ("CalloutView")]
		void WillAppear (CalloutView calloutView);

		[Export ("calloutViewDidAppear:"), EventArgs ("CalloutView")]
		void DidAppear (CalloutView calloutView);

		[Export ("calloutViewWillDisappear:"), EventArgs ("CalloutView")]
		void WillDisappear (CalloutView calloutView);

		[Export ("calloutViewDidDisappear:"), EventArgs ("CalloutView")]
		void DidDisappear (CalloutView calloutView);
	}
}
