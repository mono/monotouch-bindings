//
// cocos2d.cs: API definition for Cocos2D binding to Mono.
//
// Author:
//   Miguel de Icaza
//   Stephane Delcroix
//
// Copyright 2011 Xamarin, Inc.
// Copyright 2012 S. Delcroix
//

using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace MonoTouch.Cocos2D {
	
	[BaseType (typeof (NSObject))]
	interface CCActionManager {
		[Export ("sharedManager")]
		CCActionManager SharedManager { get; }

		[Static]
		[Export ("purgeSharedManager")]
		void PurgeSharedManager ();

		[Export ("addAction:actiontarget:paused:")]
		void AddAction (CCAction action, NSObject target, bool paused);

		[Export ("removeAllActions")]
		void RemoveAllActions ();

		[Export ("removeAllActionsFromTarget:")]
		void RemoveActions (NSObject target);

		[Export ("removeAction")]
		void RemoveAction (CCAction action);

		[Export ("removeActionByTag:target:")]
		void RemoveAction (int tag, NSObject target);

		[Export ("getActionByTag:tagtarget:")]
		CCAction GetAction (int tag, NSObject target);

		[Export ("numberOfRunningActionsInTarget:")]
		uint ActionsInTarget (NSObject target);

		[Export ("pauseTarget:")]
		void PauseTarget (NSObject target);

		[Export ("resumeTarget:")]
		void ResumeTarget (NSObject target);
	}

	[BaseType (typeof (NSObject))]
	interface CCAction {
		[Export ("originalTarget")]
		NSObject OriginalTarget { get;  }

		[Export ("tag")]
		int Tag { get; set;  }

		[Export ("idtarget")]
		NSObject Target { get; }

		[Static]
		[Export ("action")]
		CCAction CreateAction ();

		//[Export ("init")]
		//IntPtr Constructor ();

		//[Export ("copyWithZone:")]
		//NSObject CopyFromZone (NSZone zone );

		[Export ("isDone")]
		bool IsDone { get; }

		[Export ("startWithTarget:")]
		void StartWithTarget (NSObject target);

		[Export ("stop")]
		void Stop ();

		[Export ("step:")]
		void Step (float ccTime);

		[Export ("update:")]
		void Update (float time);

	}

	[BaseType (typeof (CCAction))]
	interface CCFiniteTimeAction {
		[Export ("duration")]
		float Duration { get; set; }

		[Export ("reverse")]
		CCFiniteTimeAction Reverse ();

	}

	[BaseType (typeof (NSObject))]
	interface CCNode {
		[Export ("zOrder")]
		int ZOrder { get; set; }

		[Export ("vertexZ")]
		float VertexZ { get; set; }	

		[Static]
		[Export ("node")]
		CCNode Node { get; }

		[Export ("addChild:")]
		void Add (CCNode child);

		[Export ("position")]
		PointF Position { get; set; }
	}

	[BaseType (typeof (CCAction))]
	interface CCRepeatForever {
		[Export ("innerAction")]
		CCActionInterval InnerAction { get; set; }

		[Static]
		[Export ("actionWithAction:")]
		CCRepeatForever FromAction (CCActionInterval action);

		[Export ("initWithAction:")]
		IntPtr Constructor (CCActionInterval action);

	}

	[BaseType (typeof (CCAction))]
	interface CCSpeed {
		[Export ("innerAction")]
		CCActionInterval InnerAction { get; set;  }

		[Export ("speed")]
		float Speed  { get; set; }

		[Static]
		[Export ("actionWithAction:speed:")]
		NSObject FromAction (CCActionInterval action, float rate);

		[Export ("initWithAction:actionspeed:")]
		IntPtr Constructor (CCActionInterval action, float rate);
	}

	[BaseType (typeof (CCAction))]
	interface CCFollow {
		[Export ("boundarySet")]
		bool BoundarySet { get; set; }

		[Static]
		[Export ("actionWithTarget:")]
		CCFollow FromAction (CCNode followedNode);

		[Static]
		[Export ("actionWithTarget:worldBoundary:")]
		CCFollow FromAction (CCNode followedNode, RectangleF worldBoundary);

		[Export ("initWithTarget:")]
		IntPtr Constructor (CCNode followedNode);

		[Export ("initWithTarget:worldBoundary:")]
		IntPtr Constructor (CCNode followedNode, RectangleF worldBoundary);
	}

	
	[BaseType (typeof (CCFiniteTimeAction))]
	interface CCActionInterval {
		[Export ("elapsed")]
		float Elapsed { get; }

		[Static]
		[Export ("actionWithDuration:")]
		CCActionInterval Create (float duration);

		[Export ("initWithDuration:")]
		IntPtr Constructor (float duration);

		[Export ("isDone")]
		bool IsDone { get; }

		[Export ("reverse")]
		CCActionInterval Reverse ();

	}

	[BaseType (typeof (CCActionInterval))]
	interface CCSequence {
		[Static]
		[Export ("actionsWithArray:actions")]
		CCSequence FromActions (CCFiniteTimeAction [] actions);

		[Static]
		[Export ("actionOne:two:")]
		CCSequence FromActions (CCFiniteTimeAction first, CCFiniteTimeAction second);

		[Export ("initOne:two:")]
		IntPtr Constructor (CCFiniteTimeAction first, CCFiniteTimeAction second);

	}

	[BaseType (typeof (CCActionInterval))]
	interface CCRepeat {
		[Export ("innerAction")]
		CCFiniteTimeAction InnerAction { get; set; }

		[Static]
		[Export ("actionWithAction:times:")]
		NSObject FromAction (CCFiniteTimeAction [] actions, int count);

		[Export ("initWithAction:times:")]
		IntPtr Constructor (CCFiniteTimeAction action, int count);

	}

	[BaseType (typeof (CCActionInterval))]
	interface CCSpawn {
		[Static]
		[Export ("actionsWithArray:")]
		CCSpawn FromActions (CCFiniteTimeAction [] actions );

		[Static]
		[Export ("actionOne:onetwo:two")]
		CCSpawn FromActions (CCFiniteTimeAction first , CCFiniteTimeAction second);

		[Export ("initOne:onetwo:two")]
		IntPtr Constructor (CCFiniteTimeAction first , CCFiniteTimeAction second);

	}

	[BaseType (typeof (CCActionInterval))]
	interface CCRotateTo {
		[Export ("actionWithDuration:angle:")]
		CCRotateTo Create (float duration, float angle);

		[Export ("initWithDuration:angle:")]
		IntPtr Constructor (float duration, float angle);

	}

	[BaseType (typeof (CCActionInterval))]
	interface CCRotateBy {
		[Export ("actionWithDuration:angle:")]
		CCRotateBy Create (float duration, float deltaAngle);

		[Export ("initWithDuration:angle:")]
		IntPtr Constructor (float duration, float deltaAngle);

	}

	[BaseType (typeof (CCActionInterval))]
	interface CCMoveTo {
		[Export ("actionWithDuration:position:")]
		CCMoveTo Create (float duration, PointF position);

		[Export ("initWithDuration:position:")]
		IntPtr Constructor (float duration, PointF position);
	}

	[BaseType (typeof (CCMoveTo))]
	interface CCMoveBy {
		[Static]
		[Export ("actionWithDuration:position:")]
		CCMoveBy Create (float duration, PointF deltaPosition);

		[Export ("initWithDuration:position:")]
		IntPtr Constructor (float duration, PointF deltaPosition);
	}

	[BaseType (typeof (CCActionInterval))]
	interface CCSkewTo {
		[Static]
		[Export ("actionWithDuration:skewX:skewY:")]
		CCSkewTo Create (float duration, float sx, float sy);

		[Export ("initWithDuration:skewX:skewY:")]
		CCSkewTo Constructor (float duration, float sx, float sy);

	}

	[BaseType (typeof (CCSkewTo))]
	interface CCSkewBy {
		[Static]
		[Export ("actionWithDuration:skewX:skewY:")]
		CCSkewBy Create (float duration, float sx, float sy);

		[Export ("initWithDuration:skewX:skewY:")]
		CCSkewBy Constructor (float duration, float sx, float sy);
	}

	[BaseType (typeof (CCActionInterval))]
	interface CCJumpBy {
		[Export ("actionWithDuration:position:height:jumps:")]
		NSObject ActionWithDurationtbezierc (float duration, PointF position, float height, int jumps);

		[Export ("initWithDuration:position:height:jumps:")]
		IntPtr Constructor (float duration, PointF position, float height, int jumps);
	}

	[BaseType (typeof (CCActionInterval))]
	interface CCBezierBy {
		[Export ("actionWithDuration:bezier:")]
		CCBezierBy Create (float duration, CCBezierConfig config);

		[Export ("initWithDuration:bezier:")]
		IntPtr Constructor (float duration, CCBezierConfig config);
	}

	[BaseType (typeof (CCBezierBy))]
	interface CCBezierTo {
		[Export ("actionWithDuration:bezier:")]
		CCBezierTo Create (float duration, CCBezierConfig config);

		[Export ("initWithDuration:bezier:")]
		IntPtr Constructor (float duration, CCBezierConfig config);
	}

	[BaseType (typeof (CCActionInterval))]
	interface CCScaleTo {
		[Static]
		[Export ("actionWithDuration:scale:")]
		CCScaleTo Create (float duration, float scale);

		[Export ("initWithDuration:scale:s")]
		IntPtr Constructor (float duration, float scale);

		[Static]
		[Export ("actionWithDuration:scaleX:scaleY:")]
		CCScaleTo Create (float duration, float sx, float sy);

		[Export ("initWithDuration:scaleX:scaleY:")]
		IntPtr Constructor (float duration, float sx, float sy);

	}

	[BaseType (typeof (CCScaleTo))]
	interface CCScaleBy {
		[Static]
		[Export ("actionWithDuration:scale:")]
		CCScaleBy Create (float duration, float scale);

		[Export ("initWithDuration:scale:s")]
		IntPtr Constructor (float duration, float scale);

		[Static]
		[Export ("actionWithDuration:scaleX:scaleY:")]
		CCScaleBy Create (float duration, float sx, float sy);

		[Export ("initWithDuration:scaleX:scaleY:")]
		IntPtr Constructor (float duration, float sx, float sy);

	}

	[BaseType (typeof (CCActionInterval))]
	interface CCBlink {
		[Static]
		[Export ("actionWithDuration:blinks:")]
		NSObject Create (float duration, int blinks);

		[Export ("initWithDuration:blinks:")]
		IntPtr Constructor (float duration, int blinks);

	}

	[BaseType (typeof (CCActionInterval))]
	interface CCFadeIn {
	}

	[BaseType (typeof (CCActionInterval))]
	interface CCFadeOut {
	}

	[BaseType (typeof (CCActionInterval))]
	interface CCFadeTo {
		[Static, Export ("actionWithDuration:opacity:")]
		CCFadeTo Create (float duration, byte opactiy);

		[Export ("initWithDuration:opacity:")]
		IntPtr Constructor (float duration, byte opacity);

	}

	[BaseType (typeof (CCActionInterval))]
	interface CCTintTo {
		[Static, Export ("actionWithDuration:red:green:blue:")]
		CCTintTo Create (float duration, byte red, byte green, byte blue);

		[Export ("initWithDuration:red:green:blue:")]
		IntPtr Constructor (float duration, byte red, byte green, byte blue);
	}

	[BaseType (typeof (CCActionInterval))]
	interface CCTintBy {
		[Export ("actionWithDuration:red:green:blue:")]
		CCTintBy Create (float duration, byte red, byte green, byte blue);

		[Export ("initWithDuration:red:green:blue:")]
		IntPtr Constructor (float duration, byte red, byte green, byte blue);
	}

	[BaseType (typeof (CCActionInterval))]
	interface CCDelayTime {
	}

	[BaseType (typeof (CCActionInterval))]
	interface CCReverseTime {
		[Static, Export ("actionWithAction:")]
		NSObject Create (CCFiniteTimeAction action);

		[Export ("initWithAction:")]
		IntPtr Constructor (CCFiniteTimeAction action);

	}

	[BaseType (typeof (CCActionInterval))]
	interface CCAnimate {
		[Export ("animation")]
		CCAnimation Animation { get; set; }

		[Static]
		[Export ("actionWithAnimation:")]
		CCAnimate FromAnimation (CCAnimation animation);

		[Export ("initWithAnimation:a")]
		IntPtr Constructor (CCAnimation animation);

		[Static]
		[Export ("actionWithAnimation:restoreOriginalFrame:")]
		CCAnimate Create (CCAnimation animation , bool restoreOriginalFrame);

		[Export ("initWithAnimation:restoreOriginalFrame:")]
		IntPtr Constructor (CCAnimation animation, bool restoreOriginalFrame);

		[Static]
		[Export ("actionWithDuration:animation:restoreOriginalFrame:")]
		CCAnimate Create (float duration, CCAnimation animation, bool restoreOriginalFrame);

		[Export ("initWithDuration:animation:restoreOriginalFrame:")]
		IntPtr Constructor (float duration, CCAnimation animation, bool restoreOriginalFrame);
	}

	[BaseType (typeof (NSObject))]
	interface CCAnimation {
		[Export ("delay")]
		float Delay { get; set;  }

		[Export ("frames")]
		CCSpriteFrame [] Frames { get; set;  }

		[Export ("name")]
		string Name { get; set; }

		[Static]
		[Export ("animation")]
		NSObject Create ();

		[Static]
		[Export ("animationWithFrames:")]
		CCAnimation FromFrames (CCSpriteFrame [] frames);

		[Static]
		[Export ("animationWithFrames:delay:")]
		CCAnimation FromFrames (CCSpriteFrame [] frames, float delay);

		[Export ("initWithFrames:")]
		IntPtr Constructor (CCSpriteFrame [] frames);

		[Export ("initWithFrames:delay:")]
		IntPtr Constructor (CCSpriteFrame [] frames, float delay);

		[Export ("addFrame:")]
		void AddFrame (CCSpriteFrame frame);

		[Export ("addFrameWithFilename:")]
		void AddFrame (string filename);

		[Export ("addFrameWithTexture:rect:")]
		void AddFrame (CCTexture2D texture, RectangleF rect);

	}

	[BaseType (typeof (NSObject))]
	interface CCSpriteFrame {
		[Export ("rect")]
		RectangleF Rect { get; set; }

		[Export ("rectInPixels")]
		RectangleF RectInPixels { get; set; }

		[Export ("rotated")]
		bool Rotated { get; set; }	
	}

	[BaseType (typeof (NSObject))]
	interface CCTexture2D {
		[Static]
		[Export("defaultAlphaPixelFormat")]
		CCTexture2DPixelFormat DefaultAlphaPixelFormat { get; set; }

		[Static]
		[Export ("PVRImageHavePremultipliedAlpha")]
		bool PVRImageHavePremultipliedAlpha { set; }
	}

	[BaseType (typeof (UIView))]
	interface CCGLView {
		[Static]
		[Export ("viewWithFrame:")]
		CCGLView View (RectangleF frame);
	}

	[BaseType (typeof(UIViewController))]
	interface CCDirector {
		[Static]
		[Export ("sharedDirector")]
		CCDirector SharedDirector { get; set; }

		[Export ("displayStats")]
		bool DisplayStats { get; set; }

		[Export ("animationInterval")]
		double AnimationInterval { get; set; }

		[Export ("projection")]
		CCDirectorProjection Projection { set; }

		[Export ("pushScene:")]
		void Push (CCScene scene);

		[Export ("winSize")]
		SizeF WinSize { get; }

		[Export ("winSizeInPixels")]
		SizeF WinSizeInPixels { get; }
	} 

	[BaseType (typeof (CCNode))]
	interface CCScene {
		
	}

	[BaseType (typeof (CCDirector))]
	interface CCDirectorIOS {
		[Export ("projection:")]
		CCDirectorProjection Projection { set; }

		[Export ("enableRetinaDisplay:")]
		bool EnableRetinaDisplay (bool enableRetina);
	}

	[BaseType (typeof (CCNode))]
	interface CCLayer {
		[Export ("registerWithTouchDispatcher")]
		void RegisterWithTouchDispatcher ();

		[Export ("isTouchEnabled")]
		bool IsTouchEnabled { get; set; }

		[Export ("isAccelerometerEnabled")]
		bool IsAccelerometerEnabled { get; set; }
	}

	[BaseType (typeof (CCSprite))]
	interface CCLabelTTF {
		[Static]
		[Export ("labelWithString:fontName:fontSize:")]
		CCLabelTTF Label (string label, string fontName, float fontSize);

	}

	[BaseType (typeof (CCNode))]
	interface CCSprite {
	}
}
