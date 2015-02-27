using System;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Drawing;
using CoreGraphics;


namespace WEPopover
{
	// @interface WEPopover (UIBarButtonItem)
	[Category]
	[BaseType (typeof(UIBarButtonItem))]
	interface UIBarButtonItem_WEPopover
	{
		// -(CGRect)frameInView:(UIView *)v;
		[Export ("frameInView:")]
		CGRect FrameInView (UIView v);

		// -(UIView *)superview;
		[Export ("superview")]
		UIView Superview ();
	}

	// @interface WEBlockingGestureRecognizer : UIGestureRecognizer
	[BaseType (typeof(UIGestureRecognizer), Name = "WEBlockingGestureRecognizer")]
	interface BlockingGestureRecognizer
	{
	}

	// @interface WEPopoverContainerViewProperties : NSObject
	[BaseType (typeof(NSObject), Name = "WEPopoverContainerViewProperties")]
	interface PopoverContainerViewProperties
	{
		// @property (assign, nonatomic) CGFloat leftBgMargin;
		[Export ("leftBgMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat LeftBackgroundMargin { get; set; }

		// @property (assign, nonatomic) CGFloat rightBgMargin;
		[Export ("rightBgMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat RightBackgroundMargin { get; set; }

		// @property (assign, nonatomic) CGFloat topBgMargin;
		[Export ("topBgMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat TopBackgroundMargin { get; set; }

		// @property (assign, nonatomic) CGFloat bottomBgMargin;
		[Export ("bottomBgMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat BottomBackgroundMargin { get; set; }

		// @property (assign, nonatomic) CGFloat leftContentMargin;
		[Export ("leftContentMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat LeftContentMargin { get; set; }

		// @property (assign, nonatomic) CGFloat rightContentMargin;
		[Export ("rightContentMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat RightContentMargin { get; set; }

		// @property (assign, nonatomic) CGFloat topContentMargin;
		[Export ("topContentMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat TopContentMargin { get; set; }

		// @property (assign, nonatomic) CGFloat bottomContentMargin;
		[Export ("bottomContentMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat BottomContentMargin { get; set; }

		// @property (assign, nonatomic) NSInteger topBgCapSize;
		[Export ("topBgCapSize", ArgumentSemantic.UnsafeUnretained)]
		nint TopBackgroundCapSize { get; set; }

		// @property (assign, nonatomic) NSInteger leftBgCapSize;
		[Export ("leftBgCapSize", ArgumentSemantic.UnsafeUnretained)]
		nint LeftBackgroundCapSize { get; set; }

		// @property (assign, nonatomic) CGFloat arrowMargin;
		[Export ("arrowMargin", ArgumentSemantic.UnsafeUnretained)]
		nfloat ArrowMargin { get; set; }

		// @property (nonatomic, strong) UIColor * maskBorderColor;
		[Export ("maskBorderColor", ArgumentSemantic.Retain)]
		UIColor MaskBorderColor { get; set; }

		// @property (assign, nonatomic) CGFloat maskBorderWidth;
		[Export ("maskBorderWidth", ArgumentSemantic.UnsafeUnretained)]
		nfloat MaskBorderWidth { get; set; }

		// @property (assign, nonatomic) CGFloat maskCornerRadius;
		[Export ("maskCornerRadius", ArgumentSemantic.UnsafeUnretained)]
		nfloat MaskCornerRadius { get; set; }

		// @property (assign, nonatomic) CGSize maskInsets;
		[Export ("maskInsets", ArgumentSemantic.UnsafeUnretained)]
		CGSize MaskInsets { get; set; }

		// @property (nonatomic, strong) UIImage * upArrowImage;
		[Export ("upArrowImage", ArgumentSemantic.Retain)]
		UIImage UpArrowImage { get; set; }

		// @property (nonatomic, strong) UIImage * downArrowImage;
		[Export ("downArrowImage", ArgumentSemantic.Retain)]
		UIImage DownArrowImage { get; set; }

		// @property (nonatomic, strong) UIImage * leftArrowImage;
		[Export ("leftArrowImage", ArgumentSemantic.Retain)]
		UIImage LeftArrowImage { get; set; }

		// @property (nonatomic, strong) UIImage * rightArrowImage;
		[Export ("rightArrowImage", ArgumentSemantic.Retain)]
		UIImage RightArrowImage { get; set; }

		// @property (nonatomic, strong) UIImage * bgImage;
		[Export ("bgImage", ArgumentSemantic.Retain)]
		UIImage BackgroundImage { get; set; }

		// @property (nonatomic, strong) NSString * upArrowImageName;
		[Export ("upArrowImageName", ArgumentSemantic.Retain)]
		string UpArrowImageName { get; set; }

		// @property (nonatomic, strong) NSString * downArrowImageName;
		[Export ("downArrowImageName", ArgumentSemantic.Retain)]
		string DownArrowImageName { get; set; }

		// @property (nonatomic, strong) NSString * leftArrowImageName;
		[Export ("leftArrowImageName", ArgumentSemantic.Retain)]
		string LeftArrowImageName { get; set; }

		// @property (nonatomic, strong) NSString * rightArrowImageName;
		[Export ("rightArrowImageName", ArgumentSemantic.Retain)]
		string RightArrowImageName { get; set; }

		// @property (nonatomic, strong) NSString * bgImageName;
		[Export ("bgImageName", ArgumentSemantic.Retain)]
		string BackgroundImageName { get; set; }
	}

	interface IPopoverContainerViewDelegate {}

	// @protocol WEPopoverContainerViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "WEPopoverContainerViewDelegate")]
	interface PopoverContainerViewDelegate
	{
		// @required -(CGRect)popoverContainerView:(WEPopoverContainerView *)view willChangeFrame:(CGRect)newFrame;
		[Abstract]
		[Export ("popoverContainerView:willChangeFrame:")]
		CGRect WillChangeFrame (PopoverContainerView view, CGRect newFrame);
	}

	// @interface WEPopoverContainerView : UIView
	[BaseType (typeof(UIView), Name = "WEPopoverContainerView")]

	interface PopoverContainerView
	{
		// @property (nonatomic, weak) id<WEPopoverContainerViewDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPopoverContainerViewDelegate Delegate { get; set; }

		// @property (readonly, nonatomic) UIPopoverArrowDirection arrowDirection;
		[Export ("arrowDirection")]
		UIPopoverArrowDirection ArrowDirection { get; }

		// @property (nonatomic, strong) UIView * contentView;
		[Export ("contentView", ArgumentSemantic.Retain)]
		UIView ContentView { get; set; }

		// -(id)initWithSize:(CGSize)theSize anchorRect:(CGRect)anchorRect displayArea:(CGRect)displayArea permittedArrowDirections:(UIPopoverArrowDirection)permittedArrowDirections properties:(WEPopoverContainerViewProperties *)properties;
		[Export ("initWithSize:anchorRect:displayArea:permittedArrowDirections:properties:")]
		IntPtr Constructor (CGSize theSize, CGRect anchorRect, CGRect displayArea, UIPopoverArrowDirection permittedArrowDirections, PopoverContainerViewProperties properties);

		// -(void)updatePositionWithSize:(CGSize)theSize anchorRect:(CGRect)anchorRect displayArea:(CGRect)displayArea permittedArrowDirections:(UIPopoverArrowDirection)permittedArrowDirections;
		[Export ("updatePositionWithSize:anchorRect:displayArea:permittedArrowDirections:")]
		void UpdatePosition (CGSize theSize, CGRect anchorRect, CGRect displayArea, UIPopoverArrowDirection permittedArrowDirections);

		// -(CGRect)calculatedFrame;
		[Export ("calculatedFrame")]
		CGRect CalculatedFrame { get; }
	}

	interface ITouchableViewDelegate {}

	// @protocol WETouchableViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "WETouchableViewDelegate")]
	interface TouchableViewDelegate
	{
		// @required -(void)viewWasTouched:(WETouchableView *)view;
		[Abstract]
		[Export ("viewWasTouched:")]
		void ViewWasTouched (TouchableView view);
	}

	// @interface WETouchableView : UIView
	[BaseType (typeof(UIView), Name = "WETouchableView",
		Delegates=new string [] { "Delegate" }, 
		Events=new Type [] {typeof(TouchableViewDelegate)})]
	interface TouchableView
	{
		// @property (assign, nonatomic) BOOL touchForwardingDisabled;
		[Export ("touchForwardingDisabled")]
		bool TouchForwardingDisabled { get; set; }

		// @property (nonatomic, weak) id<WETouchableViewDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		ITouchableViewDelegate Delegate { get; set; }

		// @property (copy, nonatomic) NSArray * passthroughViews;
		[Export ("passthroughViews", ArgumentSemantic.Copy)]
		NSObject[] PassthroughViews { get; set; }
	}

	interface IPopoverControllerDelegate {}

	// @protocol WEPopoverControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "WEPopoverControllerDelegate")]
	interface PopoverControllerDelegate
	{
		// @optional -(void)popoverControllerDidDismissPopover:(WEPopoverController *)popoverController;
		[Export ("popoverControllerDidDismissPopover:")]
		void DidDismissPopover (PopoverController popoverController);

		// @optional -(BOOL)popoverControllerShouldDismissPopover:(WEPopoverController *)popoverController;
		[Export ("popoverControllerShouldDismissPopover:")]
		bool ShouldDismissPopover (PopoverController popoverController);

		// @optional -(void)popoverController:(WEPopoverController *)popoverController willRepositionPopoverToRect:(CGRect *)rect inView:(UIView **)view;
		[Export ("popoverController:willRepositionPopoverToRect:inView:")]
		void WillRepositionPopover (PopoverController popoverController, ref CGRect rect, ref UIView view);
	}

	// @interface WEPopoverController : NSObject
	[BaseType (typeof(NSObject), Name = "WEPopoverController")]
	interface PopoverController
	{
		// @property (nonatomic, strong) UIViewController * contentViewController;
		[Export ("contentViewController", ArgumentSemantic.Retain)]
		UIViewController ContentViewController { get; set; }

		// @property (readonly, nonatomic, weak) UIView * presentedFromView;
		[Export ("presentedFromView", ArgumentSemantic.Weak)]
		UIView PresentedFromView { get; }

		// @property (readonly, assign, nonatomic) CGRect presentedFromRect;
		[Export ("presentedFromRect", ArgumentSemantic.UnsafeUnretained)]
		CGRect PresentedFromRect { get; }

		// @property (readonly, nonatomic, weak) UIView * view;
		[Export ("view", ArgumentSemantic.Weak)]
		UIView View { get; }

		// @property (nonatomic, strong) UIColor * backgroundColor;
		[Export ("backgroundColor", ArgumentSemantic.Retain)]
		UIColor BackgroundColor { get; set; }

		// @property (readonly, nonatomic) UIView * backgroundView;
		[Export ("backgroundView")]
		UIView BackgroundView { get; }

		// @property (readonly, getter = isPopoverVisible, nonatomic) BOOL popoverVisible;
		[Export ("popoverVisible")]
		bool PopoverVisible { [Bind ("isPopoverVisible")] get; }

		// @property (readonly, nonatomic) UIPopoverArrowDirection popoverArrowDirection;
		[Export ("popoverArrowDirection")]
		UIPopoverArrowDirection PopoverArrowDirection { get; }

		// @property (nonatomic, weak) id<WEPopoverControllerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IPopoverControllerDelegate Delegate { get; set; }

		// @property (assign, nonatomic) CGSize popoverContentSize;
		[Export ("popoverContentSize", ArgumentSemantic.UnsafeUnretained)]
		CGSize ContentSize { get; set; }

		// @property (nonatomic, strong) WEPopoverContainerViewProperties * containerViewProperties;
		[Export ("containerViewProperties", ArgumentSemantic.Retain)]
		PopoverContainerViewProperties Properties { get; set; }

		// @property (nonatomic, strong) id<NSObject> context;
		[Export ("context", ArgumentSemantic.Retain)]
		NSObject Context { get; set; }

		// @property (nonatomic, weak) UIView * parentView;
		[Export ("parentView", ArgumentSemantic.Weak)]
		UIView ParentView { get; set; }

		// @property (copy, nonatomic) NSArray * passthroughViews;
		[Export ("passthroughViews", ArgumentSemantic.Copy)]
		NSObject[] PassthroughViews { get; set; }

		// @property (assign, nonatomic) UIEdgeInsets popoverLayoutMargins;
		[Export ("popoverLayoutMargins", ArgumentSemantic.UnsafeUnretained)]
		UIEdgeInsets PopoverLayoutMargins { get; set; }

		// +(WEPopoverContainerViewProperties *)defaultContainerViewProperties;
		[Static]
		[Export ("defaultContainerViewProperties")]
		PopoverContainerViewProperties DefaultContainerViewProperties { get; }

		// +(void)setDefaultContainerViewProperties:(WEPopoverContainerViewProperties *)properties;
		[Static]
		[Export ("setDefaultContainerViewProperties:")]
		void SetDefaultContainerViewProperties (PopoverContainerViewProperties properties);

		// -(id)initWithContentViewController:(UIViewController *)theContentViewController;
		[Export ("initWithContentViewController:")]
		IntPtr Constructor (UIViewController theContentViewController);

		// -(void)dismissPopoverAnimated:(BOOL)animated;
		[Export ("dismissPopoverAnimated:")]
		void DismissPopover (bool animated);

		// -(void)presentPopoverFromBarButtonItem:(UIBarButtonItem *)item permittedArrowDirections:(UIPopoverArrowDirection)arrowDirections animated:(BOOL)animated;
		[Export ("presentPopoverFromBarButtonItem:permittedArrowDirections:animated:")]
		void PresentPopover (UIBarButtonItem item, UIPopoverArrowDirection arrowDirections, bool animated);

		// -(void)presentPopoverFromRect:(CGRect)rect inView:(UIView *)view permittedArrowDirections:(UIPopoverArrowDirection)arrowDirections animated:(BOOL)animated;
		[Export ("presentPopoverFromRect:inView:permittedArrowDirections:animated:")]
		void PresentPopover (CGRect rect, UIView view, UIPopoverArrowDirection arrowDirections, bool animated);

		// -(void)repositionPopoverFromRect:(CGRect)rect inView:(UIView *)view permittedArrowDirections:(UIPopoverArrowDirection)arrowDirections;
		[Export ("repositionPopoverFromRect:inView:permittedArrowDirections:")]
		void RepositionPopover (CGRect rect, UIView view, UIPopoverArrowDirection arrowDirections);

		// -(void)repositionPopoverFromRect:(CGRect)rect inView:(UIView *)view permittedArrowDirections:(UIPopoverArrowDirection)arrowDirections animated:(BOOL)animated;
		[Export ("repositionPopoverFromRect:inView:permittedArrowDirections:animated:")]
		void RepositionPopover (CGRect rect, UIView view, UIPopoverArrowDirection arrowDirections, bool animated);
	}

	interface IPopoverParentView {}

	// @protocol WEPopoverParentView
	[Protocol, Model]
	[BaseType(typeof (NSObject), Name = "WEPopoverParentView")]
	interface PopoverParentView
	{
		// @optional -(CGRect)displayAreaForPopover;
		[Export ("displayAreaForPopover")]
		CGRect DisplayAreaForPopover ();
	}


}