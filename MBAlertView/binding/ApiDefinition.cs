using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace AlertView
{
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_types
	//

	delegate void MBAlertViewDismissalHandler ();
	delegate void MBAlertViewButtonHandler ();

	[BaseType (typeof (UIViewController))]
	interface MBAlertView {

		[Notification]
		[Field ("MBAlertViewDidAppearNotification", "__Internal")]
		NSString DidAppearNotification { get; }

		[Notification]
		[Field ("MBAlertViewDidDismissNotification", "__Internal")]
		NSString DidDismissNotification { get; }

		[Field ("MBAlertViewMaxHUDDisplayTime", "__Internal")]
		float MaxHUDDisplayTime { get; set; }

		[Field ("MBAlertViewDefaultHUDHideDelay", "__Internal")]
		float DefaultHUDHideDelay { get; set; }

		[Export ("shouldPerformBlockAfterDismissal", ArgumentSemantic.Assign)]
		bool ShouldPerformHandlerAfterDismissal { get; set; }

		[Export ("setUponDismissalBlock:")]
		void SetDismissalHandler (MBAlertViewDismissalHandler handler);

		[Export ("addsToWindow", ArgumentSemantic.Assign)]
		bool AddsToWindow { get; set; }

		[Export ("iconOffset", ArgumentSemantic.Assign)]
		SizeF IconOffset { get; set; }

		[Export ("bodyText", ArgumentSemantic.Copy)]
		string BodyText { get; set; }

		[Export ("bodyFont")]
		UIFont BodyFont { get; set; }

		[Export ("imageView")]
		UIImageView ImageView { get; set; }

		[Export ("size", ArgumentSemantic.Assign)]
		SizeF Size { get; set; }

		[Export ("backgroundAlpha", ArgumentSemantic.Assign)]
		float BackgroundAlpha { get; set; }

		[Export ("dismiss")]
		void Dismiss ();

		[Export ("addToDisplayQueue")]
		void AddToDisplayQueue ();

		[Export ("addButtonWithText:type:block:")]
		void AddButtonWithText (string text, MBAlertViewItemType bType, [NullAllowed] MBAlertViewButtonHandler handler);

		[Static, Export ("alertWithBody:cancelTitle:cancelBlock:")]
		MBAlertView AlertWithBody (string body, [NullAllowed] string buttonTitle, [NullAllowed] MBAlertViewButtonHandler handler);

		[Static, Export ("alertIsVisible")]
		bool AlertIsVisible { get; }

		[Static, Export ("dismissCurrentHUD")]
		void DismissCurrentHUD ();

		[Static, Export ("dismissCurrentHUDAfterDelay:")]
		void DismissCurrentHUD (float delay);

		[Static, Export ("halfScreenSize")]
		SizeF HalfScreenSize { get; }
	}

	[BaseType (typeof (MBAlertView))]
	interface MBHUDView {

		[Export ("hudType", ArgumentSemantic.Assign)]
		MBAlertViewHUDType HudType { get; set; }

		[Export ("hudHideDelay", ArgumentSemantic.Assign)]
		float HudHideDelay { get; set; }

		[Export ("bodyOffset", ArgumentSemantic.Assign)]
		SizeF BodyOffset { get; set; }

		[Export ("iconLabel")]
		UILabel IconLabel { get; set; }

		[Export ("backgroundColor")]
		UIColor BackgroundColor { get; set; }

		[Static, Export ("hudWithBody:type:hidesAfter:show:")]
		MBHUDView HudWithBody (string body, MBAlertViewHUDType aType, float delay, bool showNow);
	}
}

