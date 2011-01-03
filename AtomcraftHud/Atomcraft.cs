using System;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace Atomcraft
{	
	//@interface ATMHud : UIViewController {
	[BaseType (typeof (UIViewController), Delegates=new string [] {"WeakDelegate"}, Events=new Type [] { typeof (ATMHudDelegate)})]
	interface ATMHud {
		
		#region Delegates
		
		[Export ("delegate"), NullAllowed, New]
		NSObject WeakDelegate { get; set;  }

		[Wrap ("WeakDelegate"), New]
		ATMHudDelegate Delegate { get; set; }
		
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
		
		//@property (nonatomic, assign) BOOL shadowEnabled;
		[Export ("shadowEnabled", ArgumentSemantic.Assign)]
		bool ShadowEnabled { get; set; }

		//@property (nonatomic, assign) BOOL blockTouches;
		[Export ("blockTouches", ArgumentSemantic.Assign)]
		bool BlockTouches { get; set; }

		//@property (nonatomic, assign) BOOL maximizeTouchArea;
		[Export ("maximizeTouchArea", ArgumentSemantic.Assign)]
		bool MaximizeTouchArea { get; set; }

		//@property (nonatomic, assign) BOOL useSameSizeInQueue;
		[Export ("useSameSizeInQueue", ArgumentSemantic.Assign)]
		bool UseSameSizeInQueue { get; set; }
		
		//@property (nonatomic, assign) BOOL blockUserInteraction;
		[Export ("blockUserInteraction", ArgumentSemantic.Assign)]
		bool BlockUserInteraction { get; set; }
		
		//@property (nonatomic, retain) NSString *showSound;
		[Export ("showSound", ArgumentSemantic.Retain)]
		string ShowSound { get; set; }
		
		//@property (nonatomic, retain) NSString *updateSound;
		[Export ("updateSound", ArgumentSemantic.Retain)]
		string UpdateSound { get; set; }
		
		//@property (nonatomic, retain) NSString *hideSound;
		[Export ("hideSound", ArgumentSemantic.Retain)]
		string HideSound { get; set; }
		
		//@property (nonatomic, assign) ATMHudAccessoryPosition accessoryPosition;
		[Export ("accessoryPosition", ArgumentSemantic.Assign)]
		ATMHudAccessoryPosition AccessoryPosition { get; set; }
		
		//@property (nonatomic, retain) ATMHudView *hudView;
		[Export ("hudView", ArgumentSemantic.Retain)]
		ATMHudView HudView { get; set; }
		
		//@property (nonatomic, retain) NSMutableArray *displayQueue;
		[Export ("displayQueue", ArgumentSemantic.Retain)]
		NSArray DisplayQueue { get; set; }
		
		//@property (nonatomic, assign) NSMutableArray queuePosition;
		[Export ("queuePosition", ArgumentSemantic.Assign)]
		int QueuePosition { get; set; }
		
		//@property (nonatomic, assign) NSMutableArray useStandby;
		[Export ("useStandby", ArgumentSemantic.Assign)]
		bool UseStandby { get; set; }
		
		/* // Skip for now... I don't quite get it...
		//@property (nonatomic, retain) ATMSoundFX *sound;
		[Export ("sound", ArgumentSemantic.Retain)]
		ATMSoundFX Sound { get; set; }*/
		
		#endregion
		
		//- (id)initWithDelegate:(id)hudDelegate;
		[Export ("initWithDelegate:")]
		IntPtr Constructor (ATMHudDelegate hudDelegate);
		
		#region Methods
		
		//+ (NSString *)buildInfo;
		[Static, Export ("buildInfo")]
		string BuildInfo();
		
		//- (void)setCaption:(NSString *)caption;
		[Export ("setCaption:")]
		void SetCaption (string caption);
		
		//- (void)setImage:(UIImage *)image;
		[Export ("setImage:")]
		void SetImage (UIImage image);
		
		//- (void)setActivity:(BOOL)flag;
		[Export ("setActivity:")]
		void SetActivity (bool flag);
		
		//- (void)setActivityStyle:(UIActivityIndicatorViewStyle)style;
		[Export ("setActivityStyle:")]
		void SetActivityStyle (UIActivityIndicatorViewStyle style);
		
		//- (void)setBlockUserInteraction:(BOOL)flag;
		[Export ("setBlockUserInteraction:")]
		void SetBlockUserInteraction (bool flag);
		
		//- (void)setFixedSize:(CGSize)size;
		[Export ("setFixedSize:")]
		void SetFixedSize (System.Drawing.SizeF size);
		
		//- (void)setProgress:(CGFloat)progress;
		[Export ("setProgress:")]
		void SetFixedSize (double size);
		
		//- (void)addToQueueWithCaption:(NSString *)caption 
		//image:(UIImage *)image 
		//accessoryPosition:(ATMHudAccessoryPosition)position 
		//showActivity:(BOOL)flag;
		[Export ("addToQueueWithCaption:image:accessoryPosition:showActivity:")]
		void AddToQueue(string caption, UIImage image, ATMHudAccessoryPosition position, bool flag);
		
		//- (void)addToQueueWithCaptions:(NSArray *)captions 
		//images:(NSArray *)images 
		//accessoryPositions:(NSArray *)positions 
		//showActivities:(NSArray *)flags;
		[Export ("addToQueueWithCaptions:images:accessoryPositions:showActivities:")]
		void AddToQueue(string[] captions, UIImage[] images, NSNumber[] positions, NSNumber[] flags);
	
		//- (void)clearQueue;
		[Export ("clearQueue")]
		void ClearQueue();
		
		//- (void)show;
		[Export ("show")]
		void Show();
		
		//- (void)showInParentView:(UIView *)pView;
		[Export ("showInParentView:")]
		void ShowInParentView(UIView pView);
		
		//- (void)update;
		[Export ("update")]
		void Update();
		
		//- (void)hide;
		[Export ("hide")]
		void Hide();
	
		//- (void)hideAfter:(NSTimeInterval)delay;
		[Export ("hideAfter:")]
		void HideAfter(double delay);
		
		//- (void)startQueue;
		[Export ("startQueue")]
		void StartQueue();
		
		//- (void)showNextInQueue;
		[Export ("showNextInQueue")]
		void ShowNextInQueue();
		
		//- (void)showQueueAtIndex:(NSInteger)index;
		[Export ("showQueueAtIndex:")]
		void ShowQueueAtIndex(int index);
		
		//- (void)playSound:(NSString *)soundPath;
		[Export ("playSound:")]
		void PlaySound(string soundPath);
		
		#endregion
	}
	
	
	[Model]
	[BaseType (typeof (NSObject))]
	interface ATMHudDelegate {
		
		//- (void)userDidTapHud:(ATMHud *)_hud;
		[Abstract]//, DelegateName ("UserTappedHud")]
		[Export ("userDidTapHud:")]
		void UserDidTapHud (ATMHud _hud);
		
		//- (void)hudWillAppear:(ATMHud *)_hud;
		[Abstract]//, DelegateName ("HudWillAppear")]
		[Export ("hudWillAppear:")]
		void HudWillAppear (ATMHud _hud);
		
		//- (void)hudDidAppear:(ATMHud *)_hud;
		[Abstract]//, DelegateName ("HudDidAppear")]
		[Export ("hudDidAppear:")]
		void HudDidAppear (ATMHud _hud);
		
		//- (void)hudWillUpdate:(ATMHud *)_hud;
		[Abstract]//, DelegateName ("HudWillUpdate")]
		[Export ("hudWillUpdate:")]
		void HudWillUpdate (ATMHud _hud);
		
		//- (void)hudDidUpdate:(ATMHud *)_hud;
		[Abstract]//, DelegateName ("HudDidUpdate")]
		[Export ("hudDidUpdate:")]
		void HudDidUpdate (ATMHud _hud);
		
		//- (void)hudWillDisappear:(ATMHud *)_hud;
		[Abstract]//, DelegateName ("HudWillDisappear")]
		[Export ("hudWillDisappear:")]
		void HudWillDisappear (ATMHud _hud);
		
		//- (void)hudDidDisappear:(ATMHud *)_hud;
		[Abstract]//, DelegateName ("HudDidDisappear")]
		[Export ("hudDidDisappear:")]
		void HudDidDisappear (ATMHud _hud);
	}
	
	[Model]
	[BaseType (typeof (NSObject))]
	interface ATMHudView {

	

	}
}

