using System;


#if __UNIFIED__
using ObjCRuntime;
using Foundation;
using UIKit;
using CoreGraphics;
using RectangleF=CoreGraphics.CGRect;
#else
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
#endif

namespace PHFComposeBarView
{
	interface ComposeBarViewDidChangeFrameEventArgs {

		[Export ("PHFComposeBarViewFrameBeginUserInfoKey", ArgumentSemantic.Assign)]
		RectangleF FrameBegin { get; }

		[Export ("PHFComposeBarViewFrameEndUserInfoKey", ArgumentSemantic.Assign)]
		RectangleF FrameEnd { get; }
	}

	interface ComposeBarViewViewWillChangeFrameEventArgs {

		[Export ("PHFComposeBarViewFrameBeginUserInfoKey", ArgumentSemantic.Assign)]
		RectangleF FrameBegin { get; }

		[Export ("PHFComposeBarViewFrameEndUserInfoKey", ArgumentSemantic.Assign)]
		RectangleF FrameEnd { get; }

		[Export ("PHFComposeBarViewAnimationDurationUserInfoKey", ArgumentSemantic.Assign)]
		double AnimationDuration { get; }

		[Export ("PHFComposeBarViewAnimationCurveUserInfoKey", ArgumentSemantic.Assign)]
		int AnimationCurve { get; }
	}

	[BaseType (typeof (UIView), Name = "PHFComposeBarView", 
	Delegates=new string [] { "WeakDelegate" }, 
	Events=new Type [] {typeof(ComposeBarViewDelegate) })]

	interface ComposeBarView {

		[Field ("PHFComposeBarViewInitialHeight", "__Internal")]
		float InitialHeight { get; }

		[Notification (typeof (ComposeBarViewDidChangeFrameEventArgs))]
		[Field ("PHFComposeBarViewDidChangeFrameNotification", "__Internal")]
		NSString DidChangeFrameNotification { get; }

		[Notification (typeof (ComposeBarViewViewWillChangeFrameEventArgs))]
		[Field ("PHFComposeBarViewWillChangeFrameNotification", "__Internal")]
		NSString WillChangeFrameNotification { get; }

		[Export ("initWithFrame:")]
		#if __UNIFIED__
		IntPtr Constructor (CGRect frame);
		#else
		IntPtr Constructor (RectangleF frame);
		#endif
		[Export ("autoAdjustTopOffset", ArgumentSemantic.Assign)]
		bool AutoAdjustTopOffset { get; set; }

		[Export ("buttonTintColor")]
		UIColor ButtonTintColor { get; set; }

		[Export ("buttonTitle")]
		string ButtonTitle { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
		    
		[Wrap ("WeakDelegate")]
		ComposeBarViewDelegate Delegate { get; set; }

		[Export ("enabled", ArgumentSemantic.Assign)]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		[Export ("maxCharCount", ArgumentSemantic.Assign)]
		uint MaxCharCount { get; set; }

		[Export ("maxHeight", ArgumentSemantic.Assign)]
		float MaxHeight { get; set; }

		[Export ("maxLinesCount", ArgumentSemantic.Assign)]
		float MaxLinesCount { get; set; }

		[Export ("placeholder")] [NullAllowed]
		string Placeholder { get; set; }

		[Export ("placeholderLabel")]
		UILabel PlaceholderLabel { get; }

		[Export ("text")] [NullAllowed]
		string Text { get; set; }

		[Export ("textView")]
		UITextView TextView { get; }

		[Export ("utilityButtonImage")] [NullAllowed]
		UIImage UtilityButtonImage { get; set; }
	}

	[BaseType (typeof (NSObject), Name = "PHFComposeBarViewDelegate")]
	[Model]
	[Protocol]
	interface ComposeBarViewDelegate {

		[Export ("composeBarViewDidPressButton:"), EventArgs ("ComposeBarViewArgs")]
		void DidPressButton (ComposeBarView composeBarView);

		[Export ("composeBarViewDidPressUtilityButton:"), EventArgs ("ComposeBarViewArgs")]
		void DidPressUtilityButton (ComposeBarView composeBarView);

		[Export ("composeBarView:willChangeFromFrame:toFrame:duration:animationCurve:"), EventArgs ("ComposeBarViewFrameAnimationArgs")]
		void WillChangeFrameSize (ComposeBarView composeBarView, RectangleF startFrame, RectangleF endFrame, double duration, UIViewAnimationCurve animationCurve);

		[Export ("composeBarView:didChangeFromFrame:toFrame:"), EventArgs ("ComposeBarViewFrameArgs")]
		void DidChangeFrameSize (ComposeBarView composeBarView, RectangleF startFrame, RectangleF endFrame);

		// UITextViewDelegate

		[Export ("textViewShouldBeginEditing:"), DelegateName ("ComposeBarViewTextViewCondition"), DefaultValue ("true")]
		bool ShouldBeginEditing (UITextView textView);

		[Export ("textViewShouldEndEditing:"), DelegateName ("ComposeBarViewTextViewCondition"), DefaultValue ("true")]
		bool ShouldEndEditing (UITextView textView);

		[Export ("textViewDidBeginEditing:"), EventArgs ("ComposeBarViewTextView"), EventName ("Started")]
		void EditingStarted (UITextView textView);

		[Export ("textViewDidEndEditing:"), EventArgs ("ComposeBarViewTextView"), EventName ("Ended")]
		void EditingEnded (UITextView textView);

		[Export ("textView:shouldChangeTextInRange:replacementText:"), DelegateName ("ComposeBarViewTextViewChange"), DefaultValue ("true")]
		bool ShouldChangeText (UITextView textView, NSRange range, string text);

		[Export ("textViewDidChange:"), EventArgs ("ComposeBarViewTextView")]
		void Changed (UITextView textView);

		[Export ("textViewDidChangeSelection:"), EventArgs ("ComposeBarViewTextView")]
		void SelectionChanged (UITextView textView);
	}
}

