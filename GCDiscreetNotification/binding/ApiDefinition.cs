using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GCDiscreetNotification
{
	
	[BaseType (typeof (UIView))]
	interface GCDiscreetNotificationView {

		[Export ("label", ArgumentSemantic.Retain)]
		UILabel Label { get; }

		[Export ("activityIndicator", ArgumentSemantic.Retain)]
		UIActivityIndicatorView ActivityIndicator { get; }

		[Export ("view", ArgumentSemantic.Assign)]
		UIView View { get; set; }

		[Export ("presentationMode", ArgumentSemantic.Assign)]
		GCDNPresentationMode PresentationMode { get; set; }

		[Export ("textLabel", ArgumentSemantic.Copy)]
		string TextLabel { get; set; }

		[Export ("showActivity", ArgumentSemantic.Assign)]
		bool ShowActivity { get; set; }

		[Export ("showing")]
		bool Showing { [Bind ("isShowing")] get; }

		[Export ("initWithText:inView:")]
		IntPtr Constructor (string text, UIView view);

		[Export ("initWithText:showActivity:inView:")]
		IntPtr Constructor (string text, bool activity, UIView view);

		[Export ("initWithText:showActivity:inPresentationMode:inView:")]
		IntPtr Constructor (string text, bool activity, GCDNPresentationMode presentationMode, UIView view);

		[Export ("showAnimated")]
		void ShowAnimated ();

		[Export ("hideAnimated")]
		void HideAnimated ();

		[Export ("hideAnimatedAfter:")]
		void hideAnimated (double timeInterval);

		[Export ("show:")]
		void Show (bool animated);

		[Export ("hide:")]
		void Hide (bool animated);

		[Export ("showAndDismissAutomaticallyAnimated")]
		void ShowAndDismissAutomaticallyAnimated ();

		[Export ("showAndDismissAfter:")]
		void ShowAndDismissAfter (double timeInterval);

		[Export ("setTextLabel:animated:")]
		void SetTextLabel (string text, bool animated);

		[Export ("setShowActivity:animated:")]
		void SetShowActivity (bool activity, bool animated);

		[Export ("setTextLabel:andSetShowActivity:animated:")]
		void SetTextLabel (string text, bool activity, bool animated);
	}

}

