using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreFoundation;

namespace MBProgressHUD
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

	// typedef void (^MBProgressHUDCompletionBlock)();
	delegate void MBProgressHUDCompletionHandler();
	delegate void NSDispatchHandlerT();

	// @interface MBProgressHUD : UIView
	[BaseType (typeof (UIView), Name="MBProgressHUD",
	Delegates=new string [] {"WeakDelegate"},
	Events=new Type [] { typeof (MBProgressHUDDelegate) })]
	interface MTMBProgressHUD {
	
		// + (MBProgressHUD *)showHUDAddedTo:(UIView *)view animated:(BOOL)animated;
		[Static]
		[Export ("showHUDAddedTo:animated:")]
		MTMBProgressHUD ShowHUD (UIView view, bool animated);

		// + (BOOL)hideHUDForView:(UIView *)view animated:(BOOL)animated;
		[Static]
		[Export ("hideHUDForView:animated:")]
		bool HideHUD (UIView view, bool animated);

		// + (NSUInteger)hideAllHUDsForView:(UIView *)view animated:(BOOL)animated;
		[Static]
		[Export ("hideAllHUDsForView:animated:")]
		uint HideAllHUDs (UIView view, bool animated);

		// + (MBProgressHUD *)HUDForView:(UIView *)view;
		[Static]
		[Export ("HUDForView:")]
		MTMBProgressHUD HUDForView (UIView view);

		// + (NSArray *)allHUDsForView:(UIView *)view;
		[Static]
		[Export ("allHUDsForView:")]
		MTMBProgressHUD [] AllHUDsForView (UIView view);

		// - (id)initWithWindow:(UIWindow *)window;
		[Export ("initWithWindow:")]
		IntPtr Constructor (UIWindow window);

		// - (id)initWithView:(UIView *)view;
		[Export ("initWithView:")]
		IntPtr Constructor (UIView view);

		// - (void)show:(BOOL)animated;
		[Export ("show:")]
		void Show (bool animated);

		// - (void)hide:(BOOL)animated;
		[Export ("hide:")]
		void Hide (bool animated);

		// - (void)hide:(BOOL)animated afterDelay:(NSTimeInterval)delay;
		[Export ("hide:afterDelay:")]
		void Hide (bool animated, double delay);

		// - (void)showWhileExecuting:(SEL)method onTarget:(id)target withObject:(id)object animated:(BOOL)animated;
		[Export ("showWhileExecuting:onTarget:withObject:animated:")]
		void Show (Selector method, NSObject target, [NullAllowed] NSObject aObject, bool animated);

		// - (void)showAnimated:(BOOL)animated whileExecutingBlock:(dispatch_block_t)block;
		[Export ("showAnimated:whileExecutingBlock:")]
		void Show (bool animated, NSDispatchHandlerT whileExecutingHandler);

		// - (void)showAnimated:(BOOL)animated whileExecutingBlock:(dispatch_block_t)block completionBlock:(MBProgressHUDCompletionBlock)completion;
		[Export ("showAnimated:whileExecutingBlock:completionBlock:")]
		void Show (bool animated, NSDispatchHandlerT whileExecutingHandler, MBProgressHUDCompletionHandler completionHandler);

		// - (void)showAnimated:(BOOL)animated whileExecutingBlock:(dispatch_block_t)block onQueue:(dispatch_queue_t)queue;
		[Export ("showAnimated:whileExecutingBlock:onQueue:")]
		void Show (bool animated, NSDispatchHandlerT whileExecutingHandler, DispatchQueue queue);

		// - (void)showAnimated:(BOOL)animated whileExecutingBlock:(dispatch_block_t)block onQueue:(dispatch_queue_t)queue completionBlock:(MBProgressHUDCompletionBlock)completion;
		[Export ("showAnimated:whileExecutingBlock:onQueue:completionBlock:")]
		void Show (bool animated, NSDispatchHandlerT whileExecutingHandler, DispatchQueue queue, MBProgressHUDCompletionHandler completionHandler);

		// @property (copy) MBProgressHUDCompletionBlock completionBlock;
		[Export ("completionBlock", ArgumentSemantic.Copy)]
		MBProgressHUDCompletionHandler CompletionHandler { get; set; }

		// @property (assign) MBProgressHUDMode mode;
		[Export ("mode", ArgumentSemantic.Assign)]
		MBProgressHUDMode Mode { get; set; }

		// @property (assign) MBProgressHUDAnimation animationType;
		[Export ("animationType", ArgumentSemantic.Assign)]
		MBProgressHUDAnimation AnimationType { get; set; }

		// @property (MB_STRONG) UIView *customView;
		[Export ("customView")]
		UIView CustomView { get; set; }

		// @property (MB_WEAK) id<MBProgressHUDDelegate> delegate;
		[Wrap ("WeakDelegate")]
		MBProgressHUDDelegate Delegate { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		// @property (copy) NSString *labelText;
		[Export ("labelText", ArgumentSemantic.Copy)]
		string LabelText { get; set; }

		// @property (copy) NSString *detailsLabelText;
		[Export ("detailsLabelText", ArgumentSemantic.Copy)]
		string DetailsLabelText { get; set; }

		// @property (assign) float opacity;
		[Export ("opacity", ArgumentSemantic.Assign)]
		float Opacity { get; set; }

		// @property (MB_STRONG) UIColor *color;
		[Export ("color")]
		UIColor Color { get; set; }

		// @property (assign) float xOffset;
		[Export ("xOffset", ArgumentSemantic.Assign)]
		float XOffset { get; set; }

		// @property (assign) float yOffset;
		[Export ("yOffset", ArgumentSemantic.Assign)]
		float YOffset { get; set; }

		// @property (assign) float margin;
		[Export ("margin", ArgumentSemantic.Assign)]
		float Margin { get; set; }

		// @property (assign) BOOL dimBackground;
		[Export ("dimBackground", ArgumentSemantic.Assign)]
		bool DimBackground { get; set; }

		// @property (assign) float graceTime;
		[Export ("graceTime", ArgumentSemantic.Assign)]
		float GraceTime { get; set; }

		// @property (assign) float minShowTime;
		[Export ("minShowTime", ArgumentSemantic.Assign)]
		float MinShowTime { get; set; }

		// @property (assign) BOOL taskInProgress;
		[Export ("taskInProgress", ArgumentSemantic.Assign)]
		bool TaskInProgress { get; set; }

		// @property (assign) BOOL removeFromSuperViewOnHide;
		[Export ("removeFromSuperViewOnHide", ArgumentSemantic.Assign)]
		bool RemoveFromSuperViewOnHide { get; set; }

		// @property (MB_STRONG) UIFont* labelFont;
		[Export ("labelFont")]
		UIFont LabelFont { get; set; }

		// @property (MB_STRONG) UIFont* detailsLabelFont;
		[Export ("detailsLabelFont")]
		UIFont DetailsLabelFont { get; set; }

		// @property (assign) float progress;
		[Export ("progress", ArgumentSemantic.Assign)]
		float Progress { get; set; }

		// @property (assign) CGSize minSize;
		[Export ("minSize", ArgumentSemantic.Assign)]
		SizeF MinSize { get; set; }

		// @property (assign, getter = isSquare) BOOL square;
		[Export ("square", ArgumentSemantic.Assign)]
		bool Square { [Bind ("isSquare")] get; set; }
	}

	// @protocol MBProgressHUDDelegate <NSObject>
	[BaseType (typeof (NSObject))]
	[Model]
	interface MBProgressHUDDelegate {

		//- (void)hudWasHidden:(MBProgressHUD *)hud;
		[Export ("hudWasHidden:"), EventArgs("MBProgressHUDS"), EventName("DidHide")]
		void HudWasHidden (MTMBProgressHUD hud);
	
	}

	// @interface MBRoundProgressView : UIView
	[BaseType (typeof (UIView))]
	interface MBRoundProgressView {

		// @property (nonatomic, assign) float progress;
		[Export ("progress", ArgumentSemantic.Assign)]
		float Progress { get; set; }

		// @property (nonatomic, MB_STRONG) UIColor *progressTintColor;
		[Export ("progressTintColor")]
		UIColor ProgressTintColor { get; set; }

		// @property (nonatomic, MB_STRONG) UIColor *backgroundTintColor;
		[Export ("backgroundTintColor")]
		UIColor BackgroundTintColor { get; set; }

		// @property (nonatomic, assign, getter = isAnnular) BOOL annular;
		[Export ("annular", ArgumentSemantic.Assign)]
		bool Annular { get; set; }
	}
}

