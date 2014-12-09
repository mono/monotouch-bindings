using System;
using System.Collections.Generic;
using System.Linq;
#if __UNIFIED__
using Foundation;
using UIKit;
using RectangleF=CoreGraphics.CGRect;
using PointF=CoreGraphics.CGPoint;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using CGRect = global::System.Drawing.RectangleF;
using CGPoint = global::System.Drawing.PointF;
using CGSize = global::System.Drawing.SizeF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif
using PHFComposeBarView;

namespace PHFComposeBarViewSample
{
	public class SampleViewController : UIViewController
	{
		UIView container;
		ComposeBarView composeBarView;
		UITextView textView;

		// Notifications
		NSObject keyboarWillShowNot;
		NSObject keyboarWillHideNot;

		public SampleViewController () : base ()
		{
			// Here we subscribe to keyboard notifications so we can modify out UI accordingly 
			keyboarWillShowNot = UIKeyboard.Notifications.ObserveWillShow (KeyboardWillToggle);
			keyboarWillHideNot = UIKeyboard.Notifications.ObserveWillHide (KeyboardWillToggle);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			keyboarWillShowNot.Dispose ();
			keyboarWillHideNot.Dispose ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.BackgroundColor = UIColor.FromHSBA (220f/360.0f, 0.08f, 0.93f, 1.0f);

			container = new UIView (View.Bounds) {
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight
			};

			// Creating ComposeBarView and initializing its properties
			#if __UNIFIED__
			composeBarView = new ComposeBarView (new RectangleF (0, View.Bounds.Height - ComposeBarView.InitialHeight, View.Bounds.Width, (nfloat)ComposeBarView.InitialHeight)) {
			#else
			composeBarView = new ComposeBarView (new RectangleF (0, View.Bounds.Height - ComposeBarView.InitialHeight, View.Bounds.Width, ComposeBarView.InitialHeight)) {
			#endif
				MaxCharCount = 160,
				MaxLinesCount = 5,
				Placeholder = "Type something...",
				UtilityButtonImage = UIImage.FromBundle ("Camera")
			};

			// This will handle when the user taps the main button
			composeBarView.DidPressButton += (sender, e) => {
				var composeBar = sender as ComposeBarView;
				Console.WriteLine ("Main button pressed. Text:\n{0}", composeBar.Text);
				AppendTextToTextView (string.Format ("Main button pressed. Text:\n{0}", composeBar.Text));
				composeBar.Text = string.Empty;
				composeBar.ResignFirstResponder ();
			};

			// This will handle when the user taps the Utility button in this case a CameraButton
			composeBarView.DidPressUtilityButton += (sender, e) => {
				Console.WriteLine ("Utility button pressed");
				AppendTextToTextView ("Utility button pressed");
			};

			// Here we setup the view that will hold everything we write
			textView = new UITextView (new RectangleF (0, 0, View.Bounds.Width, View.Bounds.Height - composeBarView.Bounds.Height)) {
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight,
				Editable = false,
				BackgroundColor = UIColor.Clear,
				AlwaysBounceVertical = true,
				Font = UIFont.SystemFontOfSize (UIFont.LabelFontSize),
				Text = "Welcome to the Demo!\n\nThis is just some placeholder text to give you a better feeling of how the compose bar can be used along other Views."
			};	

			container.AddSubview (textView);
			container.AddSubview (composeBarView);
			View.AddSubview (container);

		}

		void AppendTextToTextView (string text)
		{
			textView.Text += "\n\n" + text;

			// Let's scroll text to bottom
			var offsetY = Math.Max (0, textView.ContentSize.Height - textView.Bounds.Height);
			#if __UNIFIED__
			var newTextViewContentOffset = new PointF (0, (nfloat) offsetY);
			#else
			var newTextViewContentOffset = new PointF (0, offsetY);
			#endif
			textView.SetContentOffset (newTextViewContentOffset, true);
		}

		// Here we will resize and move our UI when Keyboard Shows/Hides
		void KeyboardWillToggle (object sender, UIKeyboardEventArgs e)
		{
			var duration = e.AnimationDuration;
			var startFrame = e.FrameBegin;
			var endFrame = e.FrameEnd;
			int signCorrection = 1;

			if (startFrame.Y < 0 || startFrame.X < 0 || endFrame.Y < 0 || endFrame.X < 0)
				signCorrection = -1;

			var widthChange = (endFrame.X - startFrame.X) * signCorrection;
			var heightChange = (endFrame.Y - startFrame.Y) * signCorrection;
			//var sizeChange = heightChange; //UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.Portrait ? heightChange : widthChange;
			var sizeChange = InterfaceOrientation == UIInterfaceOrientation.Portrait ? heightChange : widthChange;
			var newContainerFrame = container.Frame;
			newContainerFrame = new RectangleF (container.Frame.X, container.Frame.Y, container.Frame.Width, container.Frame.Height + sizeChange);
			var offsetY = Math.Max (0.0f, textView.ContentSize.Height - textView.Frame.Size.Height - sizeChange);
			#if __UNIFIED__
			var newTextViewContentOffset = new PointF (0, (nfloat) offsetY);
			#else
			var newTextViewContentOffset = new PointF (0, offsetY);
			#endif
			UIView.Animate (duration, 0, UIViewAnimationOptions.BeginFromCurrentState, () => container.Frame = newContainerFrame, null);
			textView.SetContentOffset (newTextViewContentOffset, true);
		}
	}
}

