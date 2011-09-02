//
// Bindings to the AdJitsu library
//
// Author:
//   Miguel de Icaza
//
// Copyright 2011 Xamarin, Inc.
//
using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace AdJitsu {

	[BaseType (typeof (UIView), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof (AdJitsuViewDelegate)})]
	interface AdJitsuView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);
		
		[Export ("loadSceneAtURL:")]
		void LoadScene (NSUrl url);

		[Static, Export ("majorVersionString")]
		string MajorVersion { get; }
		
		[Static, Export ("buildVersionString")]
		string BuildVersion { get; }
		
		[Static, Export ("fullVersionString")]
		string FullVersion { get; }

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		AdJitsuViewDelegate Delegate { get; set; }
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface AdJitsuViewDelegate {
		[Export ("adJitsuView:didFinishLoadingSceneAtURL:"), EventArgs ("AdJitsuUrl")]
		void FinishedLoadingScene (AdJitsuView view, NSUrl atUrl);

		[Export ("adJitsuView:didFailLoadingSceneAtURL:"), EventArgs ("AdJitsuUrl")]
		void FailedLoadingScene (AdJitsuView view, NSUrl atUrl);
		
		[Export ("adJitsuView:willTransitionToFullScreen:"), DefaultValue (true), DelegateName ("AdJitsuTransitionScreen")]
		bool WillTransitionPresentation (AdJitsuView view, bool goingFullscreen);

		[Export ("adJitsuView:didTransitionToFullScreen:"), EventArgs ("AdJitsuScreen")]
		void TransitionedPresentation (AdJitsuView view, bool toFullScreen);

		[Export ("adJitsuView:didOpenPageAtIndex:"), EventArgs ("AdJitsuPage")]
		void OpenedPage (AdJitsuView view, int pageIndex);
		
		[Export ("adJitsuView:willClosePageAtIndex:"), EventArgs ("AdJitsuPage")]
		void WillClosePage (AdJitsuView view, int pageIndex);
		
		[Export ("adJitsuView:willOpenURL:"), EventArgs ("AdJitsuUrl")]
		void WillOpen (AdJitsuView view, NSUrl url);
		
		[Export ("adJitsuView:willCloseURL:"), EventArgs ("AdJitsuUrl")]
		void WillClose (AdJitsuView view, NSUrl url);
	}
}