using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.CoreAnimation;
using MonoTouch.UIKit;

namespace ATMHud {
	//@interface ATMHud : UIViewController {
	[BaseType (typeof (UIViewController), Name="ATMHud", Delegates=new string [] { "WeakDelegate" }, Events=new Type [] { typeof (AtmHudDelegate)})]
	interface AtmHud {
		#region Delegates
		
		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		[Wrap ("WeakDelegate")]
		AtmHudDelegate Delegate { get; set; }
		
		#endregion
		
		#region Properties
		
		//@property (nonatomic, assign) CGFloat margin;
		[Export ("margin", ArgumentSemantic.Assign)]
		float Margin { get; set; }
		
		//@property (nonatomic, assign) CGFloat padding;
		[Export ("padding", ArgumentSemantic.Assign)]
		float Padding { get; set; }
		
		//@property (nonatomic, assign) CGFloat alpha;
		[Export ("alpha", ArgumentSemantic.Assign)]
		float Alpha { get; set; }
		
		//@property (nonatomic, assign) CGFloat appearScaleFactor;
		[Export ("appearScaleFactor", ArgumentSemantic.Assign)]
		float AppearScaleFactor { get; set; }
		
		//@property (nonatomic, assign) CGFloat disappearScaleFactor;
		[Export ("disappearScaleFactor", ArgumentSemantic.Assign)]
		float DisappearScaleFactor { get; set; }
		
		//@property (nonatomic, assign) CGFloat progressBorderRadius;
		[Export ("progressBorderRadius", ArgumentSemantic.Assign)]
		float ProgressBorderRadius { get; set; }
		
		//@property (nonatomic, assign) CGFloat progressBorderWidth;
		[Export ("progressBorderWidth", ArgumentSemantic.Assign)]
		float ProgressBorderWidth { get; set; }
		
		//@property (nonatomic, assign) CGFloat progressBarRadius;
		[Export ("progressBarRadius", ArgumentSemantic.Assign)]
		float ProgressBarRadius { get; set; }
		
		//@property (nonatomic, assign) CGFloat progressBarInset;
		[Export ("progressBarInset", ArgumentSemantic.Assign)]
		float ProgressBarInset { get; set; }
		
		//@property (nonatomic, assign) CGPoint center;
		[Export ("center", ArgumentSemantic.Assign)]
		PointF Center { get; set; }
		
		//@property (nonatomic, assign) BOOL shadowEnabled;
		[Export ("shadowEnabled", ArgumentSemantic.Assign)]
		bool ShadowEnabled { get; set; }
		
		//@property (nonatomic, assign) BOOL blockTouches;
		[Export ("blockTouches", ArgumentSemantic.Assign)]
		bool BlockTouches { get; set; }
		
		//@property (nonatomic, assign) BOOL allowSuperviewInteraction;
		[Export ("allowSuperviewInteraction")]
		bool AllowSuperviewInteraction { get; set; }
		
		//@property (nonatomic, retain) NSString *showSound;
		[Export ("showSound", ArgumentSemantic.Retain)]
		string ShowSound { get; set; }
		
		//@property (nonatomic, retain) NSString *updateSound;
		[Export ("updateSound", ArgumentSemantic.Retain)]
		string UpdateSound { get; set; }
		
		//@property (nonatomic, retain) NSString *hideSound;
		[Export ("hideSound", ArgumentSemantic.Retain)]
		string HideSound { get; set; }
		
		//@property (nonatomic, assign) AtmHudAccessoryPosition accessoryPosition;
		[Export ("accessoryPosition", ArgumentSemantic.Assign)]
		AtmHudAccessoryPosition AccessoryPosition { get; set; }
		
		//@property (nonatomic, retain) AtmHudView *__view;
		[Export ("__view", ArgumentSemantic.Retain)]
		AtmHudView HudView { get; set; }
		
		//@property (nonatomic, retain) ATMSoundFX *sound;
		[Export ("sound", ArgumentSemantic.Retain)]
		AtmSoundFX Sound { get; set; }
		
		//@property (nonatomic, retain) NSMutableArray *displayQueue;
		[Export ("displayQueue", ArgumentSemantic.Retain)]
		NSArray DisplayQueue { get; set; }
		
		//@property (nonatomic, assign) NSMutableArray queuePosition;
		[Export ("queuePosition", ArgumentSemantic.Assign)]
		int QueuePosition { get; set; }
		
		#endregion
		
		//- (id)initWithDelegate:(id)hudDelegate;
		[Export ("initWithDelegate:")]
		IntPtr Constructor (AtmHudDelegate hudDelegate);
		
		#region Methods
		
		//+ (NSString *)buildInfo;
		[Static, Export ("buildInfo")]
		string BuildInfo { get; }
		
		//- (void)setCaption:(NSString *)caption;
		[Export ("setCaption:")]
		void SetCaption (string caption);
		
		//- (void)setImage:(UIImage *)image;
		[Export ("setImage:")]
		void SetImage (UIImage image);
		
		//- (void)setActivity:(BOOL)flag;
		[Export ("setActivity:")]
		void SetActivity (bool activity);
		
		//- (void)setActivityStyle:(UIActivityIndicatorViewStyle)style;
		[Export ("setActivityStyle:")]
		void SetActivityStyle (UIActivityIndicatorViewStyle style);
		
		//- (void)setFixedSize:(CGSize)fixedSize;
		[Export ("setFixedSize:")]
		void SetFixedSize (SizeF fixedSize);
		
		//- (void)setProgress:(CGFloat)progress;
		[Export ("setProgress:")]
		void SetProgress (float progress);
		
		//- (void)addQueueItem:(AtmHudQueueItem *)item;
		[Export ("addQueueItem:")]
		void AddToQueue (AtmHudQueueItem item);
		
		//- (void)addQueueItems:(NSArray *)items;
		[Export ("addQueueItems:")]
		void AddToQueue (NSArray items);
		
		//- (void)clearQueue;
		[Export ("clearQueue")]
		void ClearQueue ();
		
		//- (void)startQueue;
		[Export ("startQueue")]
		void StartQueue ();
		
		//- (void)showNextInQueue;
		[Export ("showNextInQueue")]
		void ShowNextInQueue ();
		
		//- (void)showQueueAtIndex:(NSInteger)index;
		[Export ("showQueueAtIndex:")]
		void ShowQueueAtIndex (int index);
		
		//- (void)show;
		[Export ("show")]
		void Show ();
		
		//- (void)update;
		[Export ("update")]
		void Update ();
		
		//- (void)hide;
		[Export ("hide")]
		void Hide ();
		
		//- (void)hideAfter:(NSTimeInterval)delay;
		[Export ("hideAfter:")]
		void HideAfter (double delay);
		
		//- (void)playSound:(NSString *)soundPath;
		[Export ("playSound:")]
		void PlaySound (string soundPath);
		
		#endregion
	}
	
	
	[Model]
	[BaseType (typeof (NSObject), Name="ATMHudDelegate")]
	interface AtmHudDelegate {
		//- (void)userDidTapHud:(AtmHud *)_hud;
		[Abstract]//, DelegateName ("UserTappedHud")]
		[Export ("userDidTapHud:")]
		void UserDidTapHud (AtmHud hud);
		
		//- (void)hudWillAppear:(AtmHud *)_hud;
		[Abstract]//, DelegateName ("HudWillAppear")]
		[Export ("hudWillAppear:")]
		void HudWillAppear (AtmHud hud);
		
		//- (void)hudDidAppear:(AtmHud *)_hud;
		[Abstract]//, DelegateName ("HudDidAppear")]
		[Export ("hudDidAppear:")]
		void HudDidAppear (AtmHud hud);
		
		//- (void)hudWillUpdate:(AtmHud *)_hud;
		[Abstract]//, DelegateName ("HudWillUpdate")]
		[Export ("hudWillUpdate:")]
		void HudWillUpdate (AtmHud hud);
		
		//- (void)hudDidUpdate:(AtmHud *)_hud;
		[Abstract]//, DelegateName ("HudDidUpdate")]
		[Export ("hudDidUpdate:")]
		void HudDidUpdate (AtmHud hud);
		
		//- (void)hudWillDisappear:(AtmHud *)_hud;
		[Abstract]//, DelegateName ("HudWillDisappear")]
		[Export ("hudWillDisappear:")]
		void HudWillDisappear (AtmHud hud);
		
		//- (void)hudDidDisappear:(AtmHud *)_hud;
		[Abstract]//, DelegateName ("HudDidDisappear")]
		[Export ("hudDidDisappear:")]
		void HudDidDisappear (AtmHud hud);
	}
	
	[BaseType (typeof (NSObject), Name="ATMHudQueueItem")]
	interface AtmHudQueueItem {
		#region Properties
		
		//@property (nonatomic, retain) NSString *caption;
		[Export ("caption")]
		string Caption { get; set; }
		
		//@property (nonatomic, retain) UIImage *image;
		[Export ("image")]
		UIImage Image { get; set; }
		
		//@property (nonatomic, assign) BOOL showActivity;
		[Export ("showActivity")]
		bool ShowActivity { get; set; }
		
		//@property (nonatomic, assign) AtmHudAccessoryPosition accessoryPosition;
		[Export ("accessoryPosition")]
		AtmHudAccessoryPosition AccessoryPosition { get; set; }
		
		//@property (nonatomic, assign) UIActivityIndicatorViewStyle activityStyle;
		[Export ("activityStyle")]
		UIActivityIndicatorViewStyle ActivityStyle { get; set; }
		
		#endregion
	}
	
	[BaseType (typeof (NSObject), Name="ATMHudView")]
	interface AtmHudView {
		#region Properties
		
		//@property (nonatomic, retain) NSString *caption;
		[Export ("caption")]
		string Caption { get; set; }
		
		//@property (nonatomic, retain) UIImage *image;
		[Export ("image")]
		UIImage Image { get; set; }
		
		//@property (nonatomic, retain) UIActivityIndicatorView *activity;
		[Export ("activity")]
		UIActivityIndicatorView Activity { get; set; }
		
		//@property (nonatomic, assign) UIActivityIndicatorViewStyle activityStyle;
		[Export ("activityStyle")]
		UIActivityIndicatorViewStyle ActivityStyle { get; set; }
		
		//@property (nonatomic, retain) AtmHud *p;
		[Export ("p")]
		AtmHud ParentHudController { get; set; }
		
		//@property (nonatomic, assign) BOOL showActivity;
		[Export ("showActivity")]
		bool ShowActivity { get; set; }
		
		//@property (nonatomic, assign) CGFloat progress;
		[Export ("progress")]
		float Progress { get; set; }
		
		//@property (nonatomic, assign) CGRect targetBounds;
		[Export ("targetBounds")]
		RectangleF TargetBounds { get; set; }
		
		//@property (nonatomic, assign) CGRect captionRect;
		[Export ("captionRect")]
		RectangleF CaptionRect { get; set; }
		
		//@property (nonatomic, assign) CGRect progressRect;
		[Export ("progressRect")]
		RectangleF ProgressRect { get; set; }
		
		//@property (nonatomic, assign) CGRect activityRect;
		[Export ("activityRect")]
		RectangleF ActivityRect { get; set; }
		
		//@property (nonatomic, assign) CGRect imageRect;
		[Export ("imageRect")]
		RectangleF ImageRect { get; set; }
		
		//@property (nonatomic, assign) CGSize fixedSize;
		[Export ("fixedSize")]
		SizeF FixedSize { get; set; }
		
		//@property (nonatomic, assign) CGSize activitySize;
		[Export ("activitySize")]
		SizeF ActivitySize { get; set; }
		
		//@property (nonatomic, retain) CALayer *backgroundLayer;
		[Export ("backgroundLayer")]
		CALayer BackgroundLayer { get; set; }
		
		//@property (nonatomic, retain) CALayer *imageLayer;
		[Export ("imageLayer")]
		CALayer ImageLayer { get; set; }
		
		//@property (nonatomic, retain) ATMTextLayer *captionLayer;
		[Export ("captionLayer")]
		AtmTextLayer CaptionLayer { get; set; }
		
		//@property (nonatomic, retain) ATMProgressLayer *progressLayer;
		[Export ("progressLayer")]
		AtmProgressLayer ProgressLayer { get; set; }
		
		#endregion
		
		#region Constructors
		
		//- (id)initWithFrame:(CGRect)frame andController:(AtmHud *)c;
		[Export ("initWithFrame:andController:")]
		IntPtr Constructor (RectangleF frame, AtmHud controller);
		
		#endregion
		
		#region Methods
		
		//- (CGRect)sharpRect:(CGRect)rect;
		[Export ("sharpRect:")]
		RectangleF SharpRect (RectangleF rect);
		
		//- (CGPoint)sharpPoint:(CGPoint)point;
		[Export ("sharpPoint:")]
		PointF SharpPoint (PointF point);
		
		//- (void)calculate;
		[Export ("calculate")]
		void Calculate ();
		
		//- (CGSize)calculateSizeForQueueItem:(AtmHudQueueItem *)item;
		[Export ("calculateSizeForQueueItem:")]
		SizeF CalculateSize (AtmHudQueueItem item);
		
		//- (CGSize)sizeForActivityStyle:(UIActivityIndicatorViewStyle)style;
		[Export ("sizeForActivityStyle:")]
		SizeF SizeForActivityStyle (UIActivityIndicatorViewStyle style);
		
		//- (void)applyWithMode:(AtmHudApplyMode)mode;
		[Export ("applyWithMode:")]
		void Apply (AtmHudApplyMode mode);
		
		//- (void)show;
		[Export ("show")]
		void Show ();
		
		//- (void)reset;
		[Export ("reset")]
		void Reset ();
		
		//- (void)update;
		[Export ("update")]
		void Update ();
		
		//- (void)hide;
		[Export ("hide")]
		void Hide ();
		
		#endregion
	}
	
	[BaseType (typeof (CALayer), Name="ATMProgressLayer")]
	interface AtmProgressLayer {
		#region Properties
		
		//@property (nonatomic, assign) CGFloat theProgress;
		[Export ("theProgress")]
		float Progress { get; set; }
		
		//@property (nonatomic, assign) CGFloat progressBorderWidth;
		[Export ("progressBorderWidth")]
		float ProgressBorderWidth { get; set; }
		
		//@property (nonatomic, assign) CGFloat progressBorderRadius;
		[Export ("progressBorderRadius")]
		float ProgressBorderRadius { get; set; }
		
		//@property (nonatomic, assign) CGFloat progressBarRadius;
		[Export ("progressBarRadius")]
		float ProgressBarRadius { get; set; }
		
		//@property (nonatomic, assign) CGFloat progressBarInset;
		[Export ("progressBarInset")]
		float ProgressBarInset { get; set; }
		
		#endregion
	}
	
	[BaseType (typeof (CALayer), Name="ATMTextLayer")]
	interface AtmTextLayer {
		#region Properties
		
		//@property (nonatomic, assign) NSString *caption;
		[Export ("caption")]
		string Caption { get; set; }
		
		#endregion
	}
	
	[BaseType (typeof (NSObject), Name="ATMSoundFX")]
	interface AtmSoundFX {
		//+ (id)soundEffectWithContentsOfFile:(NSString *)aPath;
		[Static, Export ("soundEffectWithContentsOfFile:")]
		AtmSoundFX FromFile (string path);
		
		//- (id)initWithContentsOfFile:(NSString *)path;
		[Export ("initWithContentsOfFile:")]
		IntPtr Constructor (string path);
		
		//- (void)play;
		[Export ("play")]
		void Play ();
	}
}

