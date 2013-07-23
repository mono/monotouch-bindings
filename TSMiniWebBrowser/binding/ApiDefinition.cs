using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TSMiniWebBrowser
{
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "TSMiniWebBrowserDelegate")]
	interface MiniWebBrowserDelegate {
		[Export ("tsMiniWebBrowserDidDismiss")]
		void DidDismiss ();
	}

	[BaseType (typeof (UIViewController), Name = "TSMiniWebBrowser")]
	interface MiniWebBrowser {

		[Wrap ("WeakDelegate")][NullAllowed]
		MiniWebBrowserDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("mode", ArgumentSemantic.Assign)]
		MiniWebBrowserMode Mode { get; set; }

		[Export ("showURLStringOnActionSheetTitle", ArgumentSemantic.Assign)]
		bool ShowUrlstringOnActionSheetTitle { get; set; }

		[Export ("showPageTitleOnTitleBar", ArgumentSemantic.Assign)]
		bool ShowPageTitleOnTitleBar { get; set; }

		[Export ("showReloadButton", ArgumentSemantic.Assign)]
		bool ShowReloadButton { get; set; }

		[Export ("showActionButton", ArgumentSemantic.Assign)]
		bool ShowActionButton { get; set; }

		[Export ("barStyle", ArgumentSemantic.Assign)]
		UIBarStyle BarStyle { get; set; }

		[Export ("barTintColor", ArgumentSemantic.Retain)]
		UIColor BarTintColor { get; set; }

		[Export ("modalDismissButtonTitle", ArgumentSemantic.Retain)]
		string ModalDismissButtonTitle { get; set; }

		[Export ("domainLockList", ArgumentSemantic.Retain)]
		string DomainLockList { get; set; }

		[Export ("currentURL", ArgumentSemantic.Retain)]
		string CurrentURL { get; set; }

		[Export ("initWithUrl:")]
		IntPtr Constructor (NSUrl url);

		[Export ("setFixedTitleBarText:")]
		void SetFixedTitleBarText (string newTitleBarText);

		[Export ("loadURL:")]
		void LoadUrl (NSUrl url);
	}
}

