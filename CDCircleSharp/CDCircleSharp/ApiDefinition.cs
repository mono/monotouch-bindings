using System;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using MonoTouch.AVFoundation;
using MonoTouch.CoreFoundation;
using MonoTouch.QuickLook;
using MonoTouch.MessageUI;
using MonoTouch.CoreAnimation;
using MonoTouch.CoreMedia;
using MonoTouch.MediaPlayer;
using System.Drawing;

using CGRect = global::System.Drawing.RectangleF;
using CGSize = global::System.Drawing.SizeF;
using CGPoint = global::System.Drawing.PointF;

using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;

namespace CDCircle {

	// @protocol CDCircleDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface CDCircleDelegate {

		// @required -(void)circle:(CDCircle *)circle didMoveToSegment:(NSInteger)segment thumb:(CDCircleThumb *)thumb;
		[Export ("circle:didMoveToSegment:thumb:")]
		[Abstract]
		void DidMoveToSegment (CDCircle circle, nint segment, CDCircleThumb thumb);
	}

	// @protocol CDCircleDataSource <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface CDCircleDataSource {

		// @required -(UIImage *)circle:(CDCircle *)circle iconForThumbAtRow:(NSInteger)row;
		[Export ("circle:iconForThumbAtRow:")]
		[Abstract]
		UIImage IconForThumbAtRow (CDCircle circle, nint row);
	}

	// @interface CDCircle : UIView
	[BaseType (typeof (UIView))]
	interface CDCircle {

		// -(id)initWithFrame:(CGRect)frame numberOfSegments:(NSInteger)nSegments ringWidth:(CGFloat)width;
		[Export ("initWithFrame:numberOfSegments:ringWidth:")]
		IntPtr Constructor (CGRect frame, nint nSegments, nfloat width);

		// @property (nonatomic, strong) NSMutableArray * thumbs;
		[Export ("thumbs", ArgumentSemantic.Retain)]
		NSMutableArray Thumbs { get; set; }

		// @property (nonatomic, strong) UIBezierPath * circle;
		[Export ("circle", ArgumentSemantic.Retain)]
		UIBezierPath Circle { get; set; }

		// @property (nonatomic, strong) UIBezierPath * path;
		[Export ("path", ArgumentSemantic.Retain)]
		UIBezierPath Path { get; set; }

		// @property (assign, nonatomic) BOOL inertiaeffect;
		[Export ("inertiaeffect", ArgumentSemantic.UnsafeUnretained)]
		bool Inertiaeffect { get; set; }

		// @property (nonatomic, strong) CDCircleGestureRecognizer * recognizer;
		[Export ("recognizer", ArgumentSemantic.Retain)]
		CDCircleGestureRecognizer Recognizer { get; set; }

		// @property (assign) int numberOfSegments;
		[Export ("numberOfSegments", ArgumentSemantic.UnsafeUnretained)]
		int NumberOfSegments { get; set; }

		// @property (nonatomic, strong) UIColor * separatorColor;
		[Export ("separatorColor", ArgumentSemantic.Retain)]
		UIColor SeparatorColor { get; set; }

		// @property (assign, nonatomic) CDCircleThumbsSeparator separatorStyle;
		[Export ("separatorStyle", ArgumentSemantic.UnsafeUnretained)]
		CDCircleThumbsSeparator SeparatorStyle { get; set; }

		// @property (nonatomic, strong) CDCircleOverlayView * overlayView;
		[Export ("overlayView", ArgumentSemantic.Retain)]
		CDCircleOverlayView OverlayView { get; set; }

		// @property (assign, nonatomic) CGFloat ringWidth;
		[Export ("ringWidth", ArgumentSemantic.UnsafeUnretained)]
		nfloat RingWidth { get; set; }

		// @property (assign, nonatomic) BOOL overlay;
		[Export ("overlay", ArgumentSemantic.UnsafeUnretained)]
		bool Overlay { get; set; }

		// @property (nonatomic, strong) id<CDCircleDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.Retain)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) id<CDCircleDelegate> delegate;
		[Wrap ("WeakDelegate")]
		CDCircleDelegate Delegate { get; set; }

		// @property (nonatomic, strong) id<CDCircleDataSource> dataSource;
		[Export ("dataSource", ArgumentSemantic.Retain)]
		CDCircleDataSource DataSource { get; set; }

		// @property (nonatomic, strong) UIColor * circleColor;
		[Export ("circleColor", ArgumentSemantic.Retain)]
		UIColor CircleColor { get; set; }
	}

	// @interface CDCircleGestureRecognizer : UIGestureRecognizer
	[BaseType (typeof (UIGestureRecognizer))]
	interface CDCircleGestureRecognizer {

		// @property (assign, nonatomic) BOOL ended;
		[Export ("ended", ArgumentSemantic.UnsafeUnretained)]
		bool Ended { get; set; }

		// @property (assign, nonatomic) CGFloat rotation;
		[Export ("rotation", ArgumentSemantic.UnsafeUnretained)]
		nfloat Rotation { get; set; }

		// @property (assign, nonatomic) CGPoint controlPoint;
		[Export ("controlPoint", ArgumentSemantic.UnsafeUnretained)]
		CGPoint ControlPoint { get; set; }

		// @property (nonatomic, strong) CDCircleThumb * currentThumb;
		[Export ("currentThumb", ArgumentSemantic.Retain)]
		CDCircleThumb CurrentThumb { get; set; }
	}

	// @interface CDIconView : UIView
	[BaseType (typeof (UIView))]
	interface CDIconView {

		// @property (nonatomic, strong) UIImage * image;
		[Export ("image", ArgumentSemantic.Retain)]
		UIImage Image { get; set; }

		// @property (assign, nonatomic, setter = setIsSelected:) BOOL selected;
		[Export ("selected", ArgumentSemantic.UnsafeUnretained)]
		bool Selected { get; [Bind ("setIsSelected:")] set; }

		// @property (nonatomic, strong) UIColor * highlitedIconColor;
		[Export ("highlitedIconColor", ArgumentSemantic.Retain)]
		UIColor HighlitedIconColor { get; set; }
	}

	// @interface CDCircleThumb : UIView
	[BaseType (typeof (UIView))]
	interface CDCircleThumb {

		// -(id)initWithShortCircleRadius:(CGFloat)shortRadius longRadius:(CGFloat)longRadius numberOfSegments:(CGFloat)sNumber;
		[Export ("initWithShortCircleRadius:longRadius:numberOfSegments:")]
		IntPtr Constructor (nfloat shortRadius, nfloat longRadius, nfloat sNumber);

		// @property (readonly, assign) CGFloat sRadius;
		[Export ("sRadius", ArgumentSemantic.UnsafeUnretained)]
		nfloat SRadius { get; }

		// @property (readonly, assign) CGFloat lRadius;
		[Export ("lRadius", ArgumentSemantic.UnsafeUnretained)]
		nfloat LRadius { get; }

		// @property (readonly, assign) CGFloat yydifference;
		[Export ("yydifference", ArgumentSemantic.UnsafeUnretained)]
		nfloat Yydifference { get; }

		// @property (nonatomic, strong) UIBezierPath * arc;
		[Export ("arc", ArgumentSemantic.Retain)]
		UIBezierPath Arc { get; set; }

		// @property (nonatomic, strong) UIColor * separatorColor;
		[Export ("separatorColor", ArgumentSemantic.Retain)]
		UIColor SeparatorColor { get; set; }

		// @property (assign, nonatomic) CDCircleThumbsSeparator separatorStyle;
		[Export ("separatorStyle", ArgumentSemantic.UnsafeUnretained)]
		CDCircleThumbsSeparator SeparatorStyle { get; set; }

		// @property (assign, nonatomic) CGPoint centerPoint;
		[Export ("centerPoint", ArgumentSemantic.UnsafeUnretained)]
		CGPoint CenterPoint { get; set; }

		// @property (nonatomic, strong) NSMutableArray * colorsLocations;
		[Export ("colorsLocations", ArgumentSemantic.Retain)]
		NSMutableArray ColorsLocations { get; set; }

		// @property (nonatomic, strong) CDIconView * iconView;
		[Export ("iconView", ArgumentSemantic.Retain)]
		CDIconView IconView { get; set; }

		// @property (assign) BOOL gradientFill;
		[Export ("gradientFill", ArgumentSemantic.UnsafeUnretained)]
		bool GradientFill { get; set; }

		// @property (nonatomic, strong) NSArray * gradientColors;
		[Export ("gradientColors", ArgumentSemantic.Retain)]
		NSObject [] GradientColors { get; set; }

		// @property (nonatomic, strong) UIColor * arcColor;
		[Export ("arcColor", ArgumentSemantic.Retain)]
		UIColor ArcColor { get; set; }
	}

	// @interface CDCircleOverlayView : UIView
	[BaseType (typeof (UIView))]
	interface CDCircleOverlayView {

		// -(id)initWithCircle:(CDCircle *)cicle;
		[Export ("initWithCircle:")]
		IntPtr Constructor (CDCircle cicle);

		// @property (nonatomic, strong) CDCircle * circle;
		[Export ("circle", ArgumentSemantic.Retain)]
		CDCircle Circle { get; set; }

		// @property (assign, nonatomic) CGPoint controlPoint;
		[Export ("controlPoint", ArgumentSemantic.UnsafeUnretained)]
		CGPoint ControlPoint { get; set; }

		// @property (assign, nonatomic) CGPoint buttonCenter;
		[Export ("buttonCenter", ArgumentSemantic.UnsafeUnretained)]
		CGPoint ButtonCenter { get; set; }

		// @property (nonatomic, strong) CDCircleThumb * overlayThumb;
		[Export ("overlayThumb", ArgumentSemantic.Retain)]
		CDCircleThumb OverlayThumb { get; set; }
	}

	// @interface Common : NSObject
	[BaseType (typeof (NSObject))]
	interface Common {

	}
}
