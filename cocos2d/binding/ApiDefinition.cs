//
// cocos2d.cs: API definition for Cocos2D binding to Mono.
//
// Authors:
//   Miguel de Icaza
//   Stephane Delcroix
//
// Copyright 2011, 2012, 2013 Xamarin, Inc.
// Copyright 2012, 2013 S. Delcroix
//
// Missing:
//    PostGets on types that contain children
//       CCSpriteBatchNode
//    P/Invokes for CCDrawingPrimitives (somehow deprecated in 2.1 in favor of CCDrawNode)
//    Manual bindings for CCLayerMultiplex, since it takes a va_list
//    Manual bindings for CCMenuItemToggle's constructor
//
// For va_list, we could either:
//   Add NSArray code in native land manually or
//   Figure out a way of marshalling the data.
//   Likely: contribute patches upstream to handle these
//

using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using OpenTK;

using ARCH_OPTIMAL_PARTICLE_SYSTEM = MonoTouch.Cocos2D.CCParticleSystemQuad;

namespace MonoTouch.Cocos2D {
	delegate void NSCallbackWithSender (NSObject sender);

	[BaseType (typeof (NSObject))]
	interface CCAction {
		[Export ("originalTarget")]
		CCNode OriginalTarget { get;  }

		[Export ("tag")]
		int Tag { get; set;  }

		[Export ("target")]
		CCNode Target { get; }

		//[Export ("copyWithZone:")]
		//CCAction CopyFromZone (NSZone zone );

		// [Static, Export ("action")]
		// Do not expose, as our constructor is just as good and
		// this implementation does an autorelease as well, which
		// requires more work on our part.

		[Export ("isDone")]
		bool IsDone { get; }

		[Export ("startWithTarget:")]
		void Start (CCNode target);

		[Export ("stop")]
		void Stop ();

		[Export ("step:")]
		void Step (float deltaTime);

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
	interface CCActionManager {

		[Export ("addAction:target:paused:")]
		void AddAction (CCAction action, CCNode target, bool paused);

		[Export ("removeAllActions")]
		void RemoveAllActions ();

		[Export ("removeAllActionsFromTarget:")]
		void RemoveActions (CCNode target);

		[Export ("removeAction:")]
		void RemoveAction (CCAction action);

		[Export ("removeActionByTag:target:")]
		void RemoveAction (int tag, CCNode target);

		[Export ("getActionByTag:target:")]
		CCAction GetAction (int tag, CCNode target);

		[Export ("numberOfRunningActionsInTarget:")]
		uint ActionsInTarget (CCNode target);

		[Export ("pauseTarget:")]
		void PauseTarget (CCNode target);

		[Export ("resumeTarget:")]
		void ResumeTarget (CCNode target);

		[Export ("pauseAllRunningActions")]
		NSSet PauseAllRunningActions ();

		[Export ("resumeTargets:")]
		void ResumeTargets (NSSet targetsToResume);
	}

	[BaseType (typeof (NSObject))]
	interface CCNode {

		//Note to self, don't bind schedule*, we can do a better job than this

		[Export ("zOrder")]
		int ZOrder { get; set; }

		[Export ("vertexZ")]
		float VertexZ { get; set; }	

		[Export ("skewX")]
		float SkewX { get; set; }

		[Export ("skewY")]
		float SkewY { get; set;  }

		[Export ("rotation")]
		float Rotation { get; set; }

		[Export ("rotationX")]
		float RotationX { get; set; }

		[Export ("rotationY")]
		float RotationY { get; set; }

		[Export ("scale")]
		float Scale { get; set; }

		[Export ("scaleX")]
		float ScaleX { get; set; }

		[Export ("scaleY")]
		float ScaleY { get; set; }

		[Export ("position")]
		PointF Position { get; set; }

		[Export ("children")]
		CCNode [] Children { get;  }

		[Export ("camera")]
		CCCamera Camera { get; }

		[Export ("addChild:")]
		void Add (CCNode child);
		
		[Export ("addChild:z:")]
		void Add (CCNode child, int zIndex);
		
		[Export ("addChild:z:tag:")]
		void Add (CCNode child, int zIndex, int tag);

		[Export ("removeFromPArent")]
		void RemoveFromPArent ();

		[Export ("removeFromParentAndCleanup:")]
		void RemoveFromParent (bool cleanup);

		[Export ("removeChild:")]
		void RemoveChild (CCNode child);
		
		[Export ("removeChild:cleanup:")]
		void Remove (CCNode child, bool cleanup);

		[Export ("removeChildByTag:")]
		void Remove (int tag);
		
		[Export ("removeChildByTag:cleanup:")]
		void Remove (int tag, bool cleanup);

		[Export ("removeAllChildren")]
		void RemoveAllChildren ();
		
		[Export ("anchorPoint")]
		PointF AnchorPoint { get; set; }

		[Export ("anchorPointInPoints")]
		PointF AnchorPointInPoints { get;  }

		[Export ("isRunning")]
		bool IsRunning { get; }

		[Export ("contentSize")]
		SizeF ContentSize { get; set; }

		[Export ("tag")]
		int Tag { get; set; }

		[Export ("runAction:")]
		CCAction RunAction (CCAction action);

		[Export ("stopAction:")]
		void StopAction (CCAction action);

		[Export ("stopAllActions")]
		void StopAllActions ();

		[Export ("stopActionByTag:")]
		void StopAction (int tag);

		[Export ("getActionByTag:")]
		CCAction GetActionByTag (int tag);

		[Export ("numberOfRunningActions")]
		int NumberOfRunningActions ();

		[Export ("onEnter")]
		void OnEnter ();

		[Export ("getChildByTag:")]
		CCNode GetChild (int tag);

		[Export ("visible")]
		bool Visible { get; set; }

		// master
		//[Export ("grid")]
		//CCGridBase Grid { get; set;  }
		//
		//[Export ("contentSizeInPixels")]
		//SizeF ContentSizeInPixels { get; set;  }
		//
		//[Export ("parent")]
		//CCNode Parent { get; set;  }
		//
		//[Export ("isRelativeAnchorPoint")]
		//bool IsRelativeAnchorPoint { get; set;  }

		[Export ("userData")]
		IntPtr UserData { get; set; }

		[Export ("onEnterTransitionDidFinish")]
		void OnEnterTransitionDidFinish ();

		[Export ("onExit")]
		void OnExit ();

		[Export ("removeAllChildrenWithCleanup:")]
		void RemoveAllChildrenWithCleanup (bool cleanup);

		[Export ("reorderChild:z:")]
		void ReorderChild (CCNode child, int zOrder);
		
		[Export ("cleanup")]
		void Cleanup ();

		[Export ("draw")]
		void Draw ();

		[Export ("visit")]
		void Visit ();

		[Export ("transform")]
		void Transform ();

		[Export ("transformAncestors")]
		void TransformAncestors ();

		[Export ("boundingBox")]
		RectangleF BoundingBox { get; }

		[Export ("scheduleUpdate")]
		void ScheduleUpdate ();

		[Export ("scheduleUpdateWithPriority:")]
		void ScheduleUpdate (int priority);

		[Export ("unscheduleUpdate")]
		void UnscheduleUpdate ();

		[Export ("schedule:")]
		void Schedule (Selector selector);

		[Export ("schedule:interval:")]
		void Scheduleinterval (Selector selector, float seconds);

		[Export ("unschedule:")]
		void Unschedule (Selector selector);

		[Export ("unscheduleAllSelectors")]
		void UnscheduleAllSelectors ();

		[Export ("resumeSchedulerAndActions")]
		void ResumeSchedulerAndActions ();

		[Export ("pauseSchedulerAndActions")]
		void PauseSchedulerAndActions ();

		[Export ("update:")]
		void Update (float delta);

		[Export ("nodeToParentTransform")]
		CGAffineTransform NodeToParentTransform { get; }
		
		[Export ("parentToNodeTransform")]
		CGAffineTransform ParentToNodeTransform { get; } 

		[Export ("nodeToWorldTransform")]
		CGAffineTransform NodeToWorldTransform { get; }

		[Export ("worldToNodeTransform")]
		CGAffineTransform WorldToNodeTransform { get; }

		[Export ("convertToNodeSpace:")]
		PointF ConvertToNodeSpace (PointF worldPoint);

		[Export ("convertToWorldSpace:")]
		PointF ConvertToWorldSpace (PointF nodePoint);

		[Export ("convertToNodeSpaceAR:")]
		PointF ConvertToNodeSpaceAnchorRelative (PointF worldPoint);

		[Export ("convertToWorldSpaceAR:")]
		PointF ConvertToWorldSpaceAnchorRelative (PointF nodePoint);

		[Export ("convertTouchToNodeSpace:")]
		PointF ConvertTouchToNodeSpace (UITouch touch);

		[Export ("convertTouchToNodeSpaceAR:")]
		PointF ConvertTouchToNodeSpaceAnchorRelative (UITouch touch);
	}

	[BaseType (typeof (CCAction))]
	interface CCRepeatForever {
		[Export ("innerAction")]
		CCActionInterval InnerAction { get; set; }

		[Export ("initWithAction:")]
		IntPtr Constructor (CCActionInterval action);

		[Static]
		[Obsolete ("Use the constructor")]
		[Export ("actionWithAction:")]
		CCRepeatForever FromAction (CCActionInterval action);
	}

	[BaseType (typeof (CCAction))]
	interface CCSpeed {
		[Export ("innerAction")]
		CCActionInterval InnerAction { get; set;  }

		[Export ("speed")]
		float Speed  { get; set; }

		[Export ("initWithAction:speed:")]
		IntPtr Constructor (CCActionInterval action, float rate);

		[Obsolete ("Use the constructor")]
		[Static]
		[Export ("actionWithAction:speed:")]
		NSObject FromAction (CCActionInterval action, float rate);
	}

	[BaseType (typeof (CCAction))]
	interface CCFollow {
		[Export ("boundarySet")]
		bool BoundarySet { get; set; }

		[Static]
		[Export ("actionWithTarget:")]
		[Obsolete ("Use the constructor")]
		CCFollow FromAction (CCNode followedNode);
		
		[Static]
		[Obsolete ("Use the constructor")]
		[Export ("actionWithTarget:worldBoundary:")]
		CCFollow FromAction (CCNode followedNode, RectangleF worldBoundary);

		[Export ("initWithTarget:")]
		IntPtr Constructor (CCNode followedNode);

		[Export ("initWithTarget:worldBoundary:")]
		IntPtr Constructor (CCNode followedNode, RectangleF worldBoundary);
	}

	[BaseType (typeof (CCFiniteTimeAction))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCActionInterval {
		[Export ("elapsed")]
		float Elapsed { get; }

		[Obsolete ("Use the constructor")]
		[Static]
		[Export ("actionWithDuration:")]
		CCActionInterval Create (float duration);

		[Export ("initWithDuration:")]
		IntPtr Constructor (float duration);
	}
	
	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCSequence {
		[Static]
		[Export ("actionsWithArray:")]
		CCSequence FromActions (CCFiniteTimeAction [] actions);

		[Obsolete ("Use the constructor")]
		[Static]
		[Export ("actionOne:two:")]
		CCSequence FromActions (CCFiniteTimeAction first, CCFiniteTimeAction second);

		[Export ("initOne:two:")]
		IntPtr Constructor (CCFiniteTimeAction first, CCFiniteTimeAction second);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCRepeat {
		[Export ("innerAction")]
		CCFiniteTimeAction InnerAction { get; set; }

		[Obsolete ("Use the constructor")]
		[Static]
		[Export ("actionWithAction:times:")]
		NSObject FromAction (CCFiniteTimeAction [] actions, int count);

		[Export ("initWithAction:times:")]
		IntPtr Constructor (CCFiniteTimeAction action, int count);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCSpawn {
		[Static]
		[Export ("actionsWithArray:")]
		CCSpawn FromActions (CCFiniteTimeAction [] actions );

		[Obsolete ("Use the constructor")]
		[Static]
		[Export ("actionOne:two:")]
		CCSpawn FromActions (CCFiniteTimeAction first , CCFiniteTimeAction second);

		[Export ("initOne:two:")]
		IntPtr Constructor (CCFiniteTimeAction first , CCFiniteTimeAction second);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCRotateTo {
		[Static]
		[Export ("actionWithDuration:angle:")]
		CCRotateTo Create (float duration, float angle);

		[Export ("initWithDuration:angle:")]
		IntPtr Constructor (float duration, float angle);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCRotateBy {
		[Static]
		[Export ("actionWithDuration:angle:")]
		CCRotateBy Create (float duration, float deltaAngle);

		[Export ("initWithDuration:angle:")]
		IntPtr Constructor (float duration, float deltaAngle);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCMoveTo {
		[Static]
		[Export ("actionWithDuration:position:")]
		CCMoveTo Create (float duration, PointF position);

		[Export ("initWithDuration:position:")]
		IntPtr Constructor (float duration, PointF position);
	}

	[BaseType (typeof (CCMoveTo))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCMoveBy {
		[Obsolete ("Use the constructor")]
		[Static]
		[Export ("actionWithDuration:position:")]
		CCMoveBy Create (float duration, PointF deltaPosition);

		[Export ("initWithDuration:position:")]
		IntPtr Constructor (float duration, PointF deltaPosition);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCSkewTo {
		[Obsolete ("Use the constructor")]
		[Static]
		[Export ("actionWithDuration:skewX:skewY:")]
		CCSkewTo Create (float duration, float sx, float sy);

		[Export ("initWithDuration:skewX:skewY:")]
		IntPtr Constructor (float duration, float sx, float sy);
	}

	[BaseType (typeof (CCSkewTo))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCSkewBy {
		[Obsolete ("Use the constructor")]
		[Static]
		[Export ("actionWithDuration:skewX:skewY:")]
		CCSkewBy Create (float duration, float sx, float sy);

		[Export ("initWithDuration:skewX:skewY:")]
		IntPtr Constructor (float duration, float sx, float sy);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCJumpBy {
		[Static]
		[Export ("actionWithDuration:position:height:jumps:")]
		NSObject ActionWithDurationtbezierc (float duration, PointF position, float height, int jumps);

		[Export ("initWithDuration:position:height:jumps:")]
		IntPtr Constructor (float duration, PointF position, float height, int jumps);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCBezierBy {
		[Static]
		[Export ("actionWithDuration:bezier:")]
		CCBezierBy Create (float duration, CCBezierConfig config);

		[Export ("initWithDuration:bezier:")]
		IntPtr Constructor (float duration, CCBezierConfig config);
	}

	[BaseType (typeof (CCBezierBy))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCBezierTo {
		[Static]
		[Export ("actionWithDuration:bezier:")]
		CCBezierTo Create (float duration, CCBezierConfig config);

		[Export ("initWithDuration:bezier:")]
		IntPtr Constructor (float duration, CCBezierConfig config);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCScaleTo {
		[Obsolete ("Use the constructor")]
		[Static]
		[Export ("actionWithDuration:scale:")]
		CCScaleTo Create (float duration, float scale);

		[Export ("initWithDuration:scale:")]
		IntPtr Constructor (float duration, float scale);

		[Obsolete ("Use the constructor")]
		[Static]
		[Export ("actionWithDuration:scaleX:scaleY:")]
		CCScaleTo Create (float duration, float sx, float sy);

		[Export ("initWithDuration:scaleX:scaleY:")]
		IntPtr Constructor (float duration, float sx, float sy);

	}

	[BaseType (typeof(CCFiniteTimeAction))]
	interface CCActionInstant {
	}

	[BaseType(typeof(CCActionInstant))]
	interface CCCallFunc {
		[Export ("initWithTarget:selector:")]
		[Internal]
		CCCallFunc Constructor (NSObject target, Selector selector);

		[Export ("execute")]
		void Execute ();
	}
	
	[BaseType (typeof(CCCallFunc))]
	interface CCCallFuncN {
		[Export ("initWithTarget:selector:")]
		[Internal]
		CCCallFuncN Constructor (NSObject target, Selector selector);
	}
	
	[BaseType (typeof (CCScaleTo))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCScaleBy {
		[Obsolete ("Use the constructor")]
		[Static]
		[Export ("actionWithDuration:scale:")]
		CCScaleBy Create (float duration, float scale);

		[Export ("initWithDuration:scale:")]
		IntPtr Constructor (float duration, float scale);

		[Obsolete ("Use the constructor")]
		[Static]
		[Export ("actionWithDuration:scaleX:scaleY:")]
		CCScaleBy Create (float duration, float sx, float sy);

		[Export ("initWithDuration:scaleX:scaleY:")]
		IntPtr Constructor (float duration, float sx, float sy);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCBlink {
		[Obsolete ("Use the constructor")]
		[Static]
		[Export ("actionWithDuration:blinks:")]
		NSObject Create (float duration, int blinks);

		[Export ("initWithDuration:blinks:")]
		IntPtr Constructor (float duration, int blinks);

	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCFadeIn {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithDuration:")]
		IntPtr Constructor (float duration);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCFadeOut {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithDuration:")]
		IntPtr Constructor (float duration);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCFadeTo {
		[Static, Export ("actionWithDuration:opacity:")]
		CCFadeTo Create (float duration, byte opactiy);

		[Export ("initWithDuration:opacity:")]
		IntPtr Constructor (float duration, byte opacity);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCTintTo {
		[Static, Export ("actionWithDuration:red:green:blue:")]
		CCTintTo Create (float duration, byte red, byte green, byte blue);

		[Export ("initWithDuration:red:green:blue:")]
		IntPtr Constructor (float duration, byte red, byte green, byte blue);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCTintBy {
		[Static, Export ("actionWithDuration:red:green:blue:")]
		CCTintBy Create (float duration, short red, short green, short blue);

		[Export ("initWithDuration:red:green:blue:")]
		IntPtr Constructor (float duration, short red, short green, short blue);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCDelayTime {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithDuration:")]
		IntPtr Constructor (float duration);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCReverseTime {
		[Static, Export ("actionWithAction:")]
		NSObject Create (CCFiniteTimeAction action);

		[Export ("initWithAction:")]
		IntPtr Constructor (CCFiniteTimeAction action);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCAnimate {
		[Export ("animation")]
		CCAnimation Animation { get; set; }

		[Obsolete ("Use the constructor")]
		[Static]
		[Export ("actionWithAnimation:")]
		CCAnimate FromAnimation (CCAnimation animation);

		[Export ("initWithAnimation:")]
		IntPtr Constructor (CCAnimation animation);

		[Obsolete ("Use the constructor")]
		[Static]
		[Export ("actionWithAnimation:restoreOriginalFrame:")]
		CCAnimate Create (CCAnimation animation , bool restoreOriginalFrame);

		[Export ("initWithAnimation:restoreOriginalFrame:")]
		IntPtr Constructor (CCAnimation animation, bool restoreOriginalFrame);

		[Obsolete ("Use the constructor")]
		[Static]
		[Export ("actionWithDuration:animation:restoreOriginalFrame:")]
		CCAnimate Create (float duration, CCAnimation animation, bool restoreOriginalFrame);

		[Export ("initWithDuration:animation:restoreOriginalFrame:")]
		IntPtr Constructor (float duration, CCAnimation animation, bool restoreOriginalFrame);
	}


	[BaseType (typeof (NSObject))]
	interface CCAnimationFrame {
		[Export ("spriteFrame")]
		CCSpriteFrame SpriteFrame { get; set;  }

		[Export ("delayUnits")]
		float DelayUnits { get; set;  }

		[Export ("userInfo")]
		NSDictionary UserInfo { get; set;  }

		[Export ("initWithSpriteFrame:delayUnits:userInfo:")]
		IntPtr Constructor (CCSpriteFrame spriteFrame, float delayUnits, NSDictionary userInfo);
	}

	[BaseType (typeof (NSObject))]
	interface CCAnimation {
		[Export ("totalDelayUnits")]
		float TotalDelayUnits { get;  }

		[Export ("delayPerUnit")]
		float DelayPerUnit { get; set;  }

		[Export ("duration")]
		float Duration { get;  }

		[Export ("frames")]
		CCSpriteFrame [] Frames { get; set;  }

		[Static]
		[Obsolete ("Use the constructor")]
		[Export ("animation")]
		NSObject Create ();

		[Export ("restoreOriginalFrame")]
		bool RestoreOriginalFrame { get; set;  }

		[Export ("loops")]
		int Loops { get; set;  }

		[Export ("initWithSpriteFrames:")]
		IntPtr Constructor (CCSpriteFrame [] frames);

		[Export ("initWithSpriteFrames:delay:")]
		IntPtr Constructor (CCSpriteFrame [] spriteFrames, float delay);

		[Export ("initWithAnimationFrames:delayPerUnit:loops:")]
		IntPtr Constructor (CCSpriteFrame [] spriteFrames, float delayPerUnit, int loops);

		[Export ("addSpriteFrame:")]
		void AddSpriteFrame (CCSpriteFrame frame);

		[Export ("addSpriteFrameWithFilename:")]
		void AddSpriteFrame (string spriteFilename);

		[Export ("addSpriteFrameWithTexture:rect:")]
		void AddSpriteFrame (CCTexture2D texture, RectangleF rect);

	}

	[BaseType (typeof (NSObject))]
	interface CCSpriteFrame {
		[Export ("rect")]
		RectangleF Rect { get; set; }

		[Export ("rectInPixels")]
		RectangleF RectInPixels { get; set; }

		[Export ("rotated")]
		bool Rotated { get; set; }	

		[Export ("offsetInPixels")]
		PointF OffsetInPixels { get; set;  }

		[Export ("originalSize")]
		SizeF OriginalSize { get; set;  }

		[Export ("originalSizeInPixels")]
		SizeF OriginalSizeInPixels { get; set;  }

		[Export ("texture")]
		CCTexture2D Texture { get; set;  }

		[Export ("textureFilename")]
		string TextureFilename { get;  }

		[Export ("initWithTexture:rect:")]
		IntPtr Constructor (CCTexture2D texture, RectangleF rect);

		[Export ("initWithTextureFilename:rect:")]
		IntPtr Constructor (string filename, RectangleF rect);

		[Export ("initWithTexture:rectInPixels:rotated:offset:originalSize:")]
		IntPtr Constructor (CCTexture2D texture, RectangleF rect, bool rotated, PointF offset, SizeF originalSize);

		[Export ("initWithTextureFilename:rectInPixels:rotated:offset:originalSize:")]
		IntPtr Constructor (string filename, RectangleF rect, bool rotated, PointF offset, SizeF originalSize);
	}

	[BaseType (typeof (NSObject))]
	interface CCTexture2D {
		[Static]
		[Export("defaultAlphaPixelFormat")]
		CCTexture2DPixelFormat DefaultAlphaPixelFormat { get; set; }

		[Static]
		[Export ("PVRImagesHavePremultipliedAlpha")]
		bool PVRImageHavePremultipliedAlpha { [Bind ("PVRImagesHavePremultipliedAlpha:")]set; }

		[Export ("pixelFormat")]
		CCTexture2DPixelFormat PixelFormat { get;  }

		[Export ("pixelsWide")]
		int PixelsWide { get;  }

		[Export ("pixelsHigh")]
		int PixelsHigh { get;  }

		[Export ("name")]
		uint Name { get;  }

		[Export ("contentSizeInPixels")]
		SizeF ContentSizeInPixels { get;  }

		[Export ("maxS")]
		float MaxS { get; set;  }

		[Export ("maxT")]
		float MaxT { get; set;  }

		[Export ("hasPremultipliedAlpha")]
		bool HasPremultipliedAlpha { get;  }

		[Export ("shaderProgram")]
		CCGLProgram ShaderProgram { get; set;  }

		[Export ("initWithData:pixelFormat:pixelsWide:pixelsHigh:contentSize:")]
		IntPtr Constructor (IntPtr data, CCTexture2DPixelFormat pixelFormat, int width, int height, SizeF size);

		[Export ("releaseData:")]
		void ReleaseData (IntPtr data);

		[Export ("keepData:length:")]
		IntPtr KeepData (IntPtr data, uint length);

#if !MONOMAC
		[Export ("resolutionType")]
		CCResolutionType ResolutionType { get; set; }
#endif

		[Export ("contentSize")]
		SizeF ContentSize ();

		[Export ("drawAtPoint:")]
		void DrawAtRect (PointF rect);
		
		[Export ("drawInRect:")]
		void DrawInRect (RectangleF rect);

#if MONOMAC
		[Export ("initWithCGImage:")]
		IntPtr Constructor (CGImage image);
#else
		[Export ("initWithCGImage:resolutionType:")]
		IntPtr Constructor (CGImage image, CCResolutionType resolutionType);
#endif

		[Export ("initWithString:fontName:fontSize:dimensions:hAlignment:vAlignment:lineBreakMode:")]
		IntPtr Constructor (string text, string fontName, float fontSize, SizeF dimensions, UITextAlignment alignment, CCVerticalTextAlignment vertAlignment, UILineBreakMode lineBreakMode);

		[Export ("initWithString:fontName:fontSize:dimensions:hAlignment:vAlignment:")]
		IntPtr Constructor (string text, string fontName, float fontSize, SizeF dimensions, UITextAlignment alignment, CCVerticalTextAlignment vertAlignment);

		[Export ("initWithString:fontName:fontSize:")]
		IntPtr Constructor (string text, string fontName, float fontSize);

		[Export ("initWithPVRFile:")]
		IntPtr Constructor (string pvrFile);
	}

	[BaseType (typeof (UIView))]
	interface CCGLView {
		[Static]
		[Export ("viewWithFrame:")]
		CCGLView View (RectangleF frame);

		[Export ("initWithFrame:")]
		CCGLView Constructor (RectangleF frame);

		[Export ("initWithFrame:pixelFormat:")]
		CCGLView Constuctor (RectangleF frame, string format);

		[Export ("initWithFrame:pixelFormat:depthFormat:preserveBackBuffer:sharegroup:multiSampling:numberOfSamples:")]
		CCGLView Constructor (RectangleF frame, string format, uint depth, bool retained, MonoTouch.OpenGLES.EAGLSharegroup sharegroup, bool sampling, uint nSamples);

		[Export ("pixelFormat")]
		string PixelFormat { get; set; }

		[Export ("depthFormat")]
		uint DepthFormat { get; set; }

		[Export ("surfaceSize")]
		SizeF SurfaceSize { get; }
		
		[Export ("context")]
		MonoTouch.OpenGLES.EAGLContext Context { get; }

		[Export ("multiSampling")]
		bool MultiSampling { get; set; }
		
		[Export ("swapBuffers")]
		void SwapBuffers ();

		[Export ("lockOpenGLContext")]
		void LockOpenGLContext ();

		[Export ("unlockOpenGLContext")]
		void UnlockOpenGLContext ();

		[Export ("convertPointFromViewToSurface:")]
		PointF ConvertPointFromViewToSurface(PointF point);
			
		[Export ("convertRectFromViewToSurface:")]
		RectangleF ConvertRectFromViewToSurface (RectangleF rect);
	}

	public delegate bool AutorotateCondition (UIInterfaceOrientation orientation);

	[BaseType (typeof (NSObject))]
	[Model]
	interface CCDirectorDelegate {
		//[Export ("updateProjection")]
		//void UpdateProjection ();

#if !MONOMAC
		[Export("shouldAutorotateToInterfaceOrientation:"), DefaultValue ("true"), DelegateName ("AutorotateCondition")]
		bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation orientation);
#endif
	}

	[BaseType (typeof(UIViewController), Delegates=new string[]{"Delegate"}, Events=new Type[]{typeof(CCDirectorDelegate)})]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: Attempted to allocate a second instance of a singleton.
	interface CCDirector {
		[Export ("sharedDirector")]
		[Static]
		CCDirector SharedDirector { get; }

		[Export ("runningThread")]
		NSThread RunningThread { get;  }

		[Export ("totalFrames")]
		uint TotalFrames { get;  }

		[Export ("runningScene")]
		CCScene RunningScene { get;  }

		[Export ("animationInterval")]
		double AnimationInterval { get; set;  }

		[Export ("displayStats")]
		bool DisplayStats { get; set;  }

		[Export ("projection")]
		CCDirectorProjection Projection { set; }

		[Export ("replaceScene:")]
		void ReplaceScene (CCScene scene);

		[Export ("pushScene:")]
		void PushScene (CCScene scene);

		[Export ("popScene")]
		void PopScene ();
		
		[Export ("popToRootScene")]
		void PopToRootScene ();

		[Export ("winSize")]
		SizeF WinSize { get; }

		[Export ("winSizeInPixels")]
		SizeF WinSizeInPixels { get; }

		[Export ("nextDeltaTimeZero")]
		bool NextDeltaTimeZero { get; set; }

		[Export ("purgeCachedData")]
		void PurgeCachedData ();

		[Export ("end")]
		void End ();

		[Export ("startAnimation")]
		void StartAnimation ();

		[Export ("stopAnimation")]
		void StopAnimation ();

		[Export ("scheduler")]
		CCScheduler Scheduler { get; set; }
	
		[Export("convertToGL:")]
		PointF ConvertToGL (PointF point);

		[Export("convertToUI:")]
		PointF ConvertToUI (PointF point);

		[Export("delegate")]
		[Internal]
		CCDirectorDelegate Delegate { get; set; }

		[Export ("runWithScene:")]
		void Run (CCScene scene);

		[Export ("isPaused")]
		bool IsPaused { get;  }

		[Export ("isAnimating")]
		bool IsAnimating { get;  }

		[Export ("secondsPerFrame")]
		float SecondsPerFrame { get;  }

		[Export ("sendCleanupToScene")]
		bool SendCleanupToScene { get;  }

		[Export ("notificationNode")]
		NSObject NotificationNode { get; set;  }

		[Export ("actionManager")]
		CCActionManager ActionManager { get; set;  }

		[Export ("reshapeProjection:")]
		void ReshapeProjection (SizeF newWindowSize);

		[Export ("getZEye")]
		float ZEye { get; }


		[Export ("pause")]
		void Pause ();

		[Export ("resume")]
		void Resume ();

		[Export ("drawScene")]
		void DrawScene ();

		[Export ("setGLDefaultValues")]
		void SetGLDefaultValues ();

		[Export ("setAlphaBlending:")]
		void SetAlphaBlending (bool on);

		[Export ("setDepthTest:")]
		void SetDepthTest (bool on);

		[Export ("createStatsLabel")]
		void CreateStatsLabel ();

#if MONOMAC
		[Export ("view")]
		CCGLView View { get; set; }
#endif
	} 

	[BaseType (typeof (CCNode))]
	interface CCScene {
		
	}

	[BaseType (typeof (NSObject))]
	interface CCTouchDispatcher {
		[Export ("dispatchEvents")]
		bool DispatchEvents { get; set; }

		[Export("addStandardDelegate:priority:")]
		void AddStandardDelegate(NSObject delegate_, int priority);

		[Export("addTargetedDelegate:priority:swallowsTouches:")]
		void AddTargetedDelegate(NSObject delegate_, int priority, bool swallowsTouches);

		[Export ("removeDelegate:")]
		void RemoveDelegate (NSObject delegate_);

		[Export ("removeAllDelegates")]
		void RemoveAllDelegates ();

		[Export ("setPriority:forDelegate:")]
		void SetPriority (int priority, NSObject delegate_);
	}	

	[BaseType (typeof (CCDirector))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: Attempted to allocate a second instance of a singleton.
	interface CCDirectorIOS {
	
		[Export ("touchDispatcher")]
		CCTouchDispatcher TouchDispatcher { get; set; }

		[Export ("enableRetinaDisplay:")]
		bool EnableRetinaDisplay (bool enableRetina);

		[Export ("calculateDeltaTime")]
		void CalculateDeltaTime ();

	}

	[BaseType (typeof (CCDirectorIOS))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: Attempted to allocate a second instance of a singleton.
	interface CCDirectorDisplayLink {

	}

	[Model]
	interface CCTargetedTouchDelegate {
		[Export ("ccTouchBegan:withEvent:")]
		bool OnTouchBegan(UITouch touch, UIEvent ev);

		[Export ("ccTouchMoved:withEvent:")]
		void OnTouchMoved(UITouch touch, UIEvent ev);

		[Export ("ccTouchEnded:withEvent:")]
		void OnTouchEnded(UITouch touch, UIEvent ev);

		[Export ("ccTouchCancelled:withEvent:")]
		void OnTouchCancelled(UITouch touch, UIEvent ev);
	}

	[Model]
	interface CCStandardTouchDelegate {
		[Export ("ccTouchesBegan:withEvent:")]
		void OnTouchesBegan(NSSet touches, UIEvent ev);

		[Export ("ccTouchesMoved:withEvent:")]
		void OnTouchesMoved(NSSet touches, UIEvent ev);

		[Export ("ccTouchesEnded:withEvent:")]
		void OnTouchesEnded(NSSet touches, UIEvent ev);

		[Export ("ccTouchesCancelled:withEvent:")]
		void OnTouchesCancelled(NSSet touches, UIEvent ev);	
	}

#if MONOMAC
	[BaseType (typeof (CCNode))]
	interface CCLayer : CCStandardTouchDelegate, CCKeyboardEventDelegate, CCMouseEventDelegate {
#else
	[BaseType (typeof (CCNode))]
	interface CCLayer : CCStandardTouchDelegate, CCTargetedTouchDelegate {
#endif
		[Export ("registerWithTouchDispatcher")]
		void RegisterWithTouchDispatcher ();

		[Export ("isTouchEnabled")]
		bool IsTouchEnabled { get; set; }
		
#if !MONOMAC
		[Export ("touchMode")]
		CCTouchesMode TouchMode { get; set; }
#endif
		[Export ("touchPriority")]
		int TouchPriority { get; set; }
		
		[Export ("isAccelerometerEnabled")]
		bool IsAccelerometerEnabled { get; set; }


#if MONOMAC
		[Export ("isKeyboardEnabled")]
		bool IsKeyboardEnabled { get; set;  }

		[Export ("isMouseEnabled")]
		bool IsMouseEnabled { get; set; }


		[Export ("mouseDelegatePriority")]
		int MouseDelegatePriority ();

		[Export ("keyboardDelegatePriority")]
		int KeyboardDelegatePriority ();

		[Export ("touchDelegatePriority")]
		int TouchDelegatePriority ();
#endif
	}

	[BaseType (typeof (CCLayer))]
	interface CCLayerColor : CCRGBAProtocol, CCBlendProtocol {
		[Export ("initWithColor:width:height:")]
		IntPtr Constructor (CCColor4B color, float width, float height);

		[Export ("initWithColor:")]
		CCLayerColor Constructor (CCColor4B color);

		[Export ("changeWidth:")]
		void ChangeWidth (float width);

		[Export ("changeHeight:")]
		void ChangeHeight (float height);

		[Export ("changeWidth:height:")]
		void ChangeSize (float width, float height);
	}

	interface CCLabelProtocol {
		[Export ("string")]
		string Label { get; set; }
	}

	interface CCRGBAProtocol {
		[Export ("color")]
		CCColor3B Color { get; set; }

		[Export ("opacity")]
		byte Opacity { get; set; }

		[Export ("doesOpacityModifyRGB")]
		bool OpacityModifyRGB { get;[Bind("opacityModifyRGB:")] set;}
	}

	[BaseType (typeof (CCSprite))]
	interface CCLabelTTF : CCLabelProtocol {
		[Export ("initWithString:fontName:fontSize:")]
		IntPtr Constructor (string label, string fontName, float fontSize);

		[Export ("initWithString:fontName:fontSize:dimensions:halignment:")]
		IntPtr Constructor (string label, string fontName, float fontSize, SizeF dimensions, UITextAlignment halignment);

		[Export ("initWithString:fontName:fontSize:dimensions:halignment:lineBreakMode:")]
		IntPtr Constructor (string label, string fontName, float fontSize, SizeF dimensions, UITextAlignment halignment, UILineBreakMode lineBreakMode);

		[Export ("initWithString:fontName:fontSize:dimensions:halignment:vAlignment:")]
		IntPtr Constructor (string label, string fontName, float fontSize, SizeF dimensions, UITextAlignment halignment, CCVerticalTextAlignment vertAlignment);

		[Export ("initWithString:fontName:fontSize:dimensions:halignment:vAlignment:lineBreakMode:")]
		IntPtr Constructor (string label, string fontName, float fontSize, SizeF dimensions, UITextAlignment halignment, CCVerticalTextAlignment vertAlignment, UILineBreakMode lineBreakMode);
	}
	
	[BaseType (typeof(CCSpriteBatchNode))]
	interface CCLabelBMFont : CCLabelProtocol, CCRGBAProtocol {
		[Export("purgeCachedData")]
		[Static]
		void PurgeCachedData  ();

		[Export("alignment")]
		UITextAlignment Alignment { get; set; }

		[Export("fntFile")]
		string FontFile { get; set; }

		[Export("initWithString:fntFile:")]
		CCLabelBMFont Constructor (string label, string fontFile);

		[Export ("initWithString:fntFile:width:alignment:")]
		IntPtr Constructor (string label, string fontFile, float width, UITextAlignment alignment);

		[Export ("initWithString:fntFile:width:alignment:imageOffset:")]
		IntPtr Constructor (string label, string fontFile, float width, UITextAlignment alignment, PointF offset);

		[Export ("createFontChars")]
		void CreateFontChars ();

		[Export ("setWidth:")]
		void SetWidth (float value);
	}

	[BaseType (typeof (CCGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCLiquid {
		[Export ("amplitude")]
		float Amplitude { get; set;  }

		[Export ("amplitudeRate")]
		float AmplitudeRate { get; set;  }

		[Export ("initWithWaves:amplitude:grid:duration:")]
		IntPtr Constructor (int waves, float amplitude, Size gridSize, float duration);
	}

	interface CCBlendProtocol {
		[Export ("blendFunc")]
		CCBlendFunc BlendFunc { get; set; }		
	}

	interface CCTextureProtocol : CCBlendProtocol {
		[Export ("texture")]
		CCTexture2D Texture { get; set; }
	}

	[BaseType (typeof(NSObject))]
	interface CCTextureAtlas {
		[Export ("totalQuads")]
		uint TotalQuads { get; }

		[Export("capacity")]
		uint Capacity { get; }

		[Export ("texture")]
		CCTexture2D Texture { get; set; }

		[Export ("quads")]
		CCV3F_C4B_T2F_Quad Quads { get; set; }

		[Export("initWithFile:capacity:")]
		IntPtr Constructor (string fileName, uint capacity);

		[Export("initWithTexture:capacity:")]
		IntPtr Constructor (CCTexture2D texture, uint capacity);

		[Export ("updateQuad:atIndex:")]
		void UpdateQuad (ref CCV3F_C4B_T2F_Quad quad, uint atIndex);

		[Export ("insertQuad:atIndex:")]
		void InsertQuad (ref CCV3F_C4B_T2F_Quad quad, uint atIndex);

		//[Export ("insertQuads:atIndex:amount:")]
		//void InsertQuads(CCV3F_C4B_T2F_Quad quad, uint atIndex, uint amount);

		[Export ("insertQuadFromIndex:atIndex:")]
		void MoveQuad (uint fromIndex, uint toIndex);

		[Export ("removeQuadAtIndex:")]
		void RemoveQuadAtIndex (uint index);

		[Export ("removeQuadsAtIndex:amount:")]
		void RemoveQuadsAtIndex (uint index, uint amount);

		[Export ("removeAllQuads")]
		void RemoveAllQuads ();

		[Export ("resizeCapacity:")]
		bool Resize (uint n);

		[Export ("increaseTotalQuadsWith:")]
		void IncreaseTotalQuadsWith (uint amount);

		[Export("moveQuadsFromIndex:amount:atIndex:")]
		void MoveQuads(uint fromIndex, uint amount, uint toIndex);

		[Export("moveQuadsFromIndex:to:")]
		void MoveQuads(uint fromIndex, uint toIndex);

		[Export("fillWithEmptyQuadsFromIndex:amount:")]
		void FillWithEmptyQuads (uint fromIndex, uint amount);

		[Export ("drawNumberOfQuads:")]
		void DrawNumberOfQuads(uint n);

		[Export ("drawNumberOfQuads:fromIndex:")]
		void DrawNumberOfQuads(uint n, uint fromIndex);
	}

	[BaseType (typeof(NSObject))]
	interface CCArray {
	}

	[BaseType (typeof (CCNode))] 
	interface CCSpriteBatchNode : CCTextureProtocol {
		[Export ("textureAtlas")]
		CCTextureAtlas TextureAtlas { get; set; }

		[Export ("descendants")]
		CCArray Descendants { get; }

		[Export ("initWithTexture:capacity:")]
		IntPtr Constructor (CCTexture2D texture, int capacity);

		[Export ("initWithFile:capacity:")]
		IntPtr Constructor (string filename, int capacity);

		[Export ("increaseAtlasCapacity")]
		void IncreaseAtlasCapacity ();

		[Export ("removeChildAtIndex:cleanup:")]
		void RemoveChildAtIndex (uint index, bool cleanup);

		[Export ("removeChild:cleanup:")]
		void RemoveChild (CCSprite sprite, bool cleanup);

		[Export ("insertChild:inAtlasAtIndex:")]
		void InsertChild (CCSprite child, uint index);
	
		[Export ("appendChild:")]
		void Append (CCSprite sprite);

		[Export ("removeSpriteFromAtlas:")]
		void RemoveSpriteFromAtlas(CCSprite sprite);

		[Export ("rebuildIndexInOrder:atlasIndex:")]
		uint RebuildIndexInOrder (CCSprite parent, int altalIndex);

		[Export ("atlasIndexForChild:atZ:")]
		int AtlasIndexForChild(CCSprite sprite, int atZ);

		[Export ("reorderBatch:")]
		void ReorderBatch (bool reorder);

		[Export ("addQuadFromSprite:quadIndex:")]
		void AddQuadFromSprite (CCSprite sprite, uint quadIndex);
	}

	[BaseType (typeof (CCNode))]
	interface CCSprite : CCRGBAProtocol, CCTextureProtocol {
		[Export ("initWithTexture:")]
		IntPtr Constructor (CCTexture2D texture);

		[Export ("initWithTexture:rect:rotated:")]
		IntPtr Constructor (CCTexture2D texture, RectangleF rect, bool rotated);

		[Export ("initWithTexture:rect:")]
		IntPtr Constructor (CCTexture2D texture, RectangleF rect);

		[Export ("initWithSpriteFrame:")]
		IntPtr Constructor (CCSpriteFrame spriteFrame);

		[Static]
		[Export ("spriteWithFile:")]
		[Autorelease]
		CCSprite FromSpriteFile (string filename);

		[Static]
		[Export ("spriteWithFile:rect:")]
		[Autorelease]
		CCSprite FromSpriteFile (string filename, RectangleF rect);

		[Export ("initWithFile:")]
		IntPtr Constructor (string filename);

		[Export ("initWithFile:rect:")]
		IntPtr Constructor (string filename, RectangleF rect);

		[Export ("initWithCGImage:key:")]
		NSObject InitWithCGImagekey (CGImage image, string key);

		[Export ("dirty")]
		bool Dirty { get; set; }
	
		//Detected properties
		[Export ("displayFrame")]
		CCSpriteFrame DisplayFrame { get; set; }

		// mehods

		[Export ("quad")]
		CCV3F_C4B_T2F_Quad Quad { get;  }

		[Export ("atlasIndex")]
		uint AtlasIndex { get; set;  }

		[Export ("textureRect")]
		// technically a read-only property - but a method with the right signature exists so we can NET-ify this
		RectangleF TextureRect { get; set; }

		[Export ("textureRectRotated")]
		bool TextureRectRotated { get;  }

		[Export ("flipX")]
		bool FlipX { get; set;  }

		[Export ("flipY")]
		bool FlipY { get; set;  }

		[Export ("textureAtlas")]
		CCTextureAtlas TextureAtlas { get; set;  }

		[Export ("batchNode")]
		[NullAllowed]
		CCSpriteBatchNode BatchNode { get; set;  }

		[Export ("offsetPosition")]
		PointF OffsetPosition { get;  }

		[Export ("updateTransform")]
		void UpdateTransform ();

		[Export ("setTextureRect:rotated:untrimmedSize:")]
		void SetTextureRect (RectangleF rect, bool rotated, SizeF untrimmedSize);

		[Export ("setVertexRect:")]
		void SetVertexRect (RectangleF rect);

		[Export ("isFrameDisplayed:")]
		bool IsFrameDisplayed (CCSpriteFrame frame);

		[Export ("setDisplayFrameWithAnimationName:index:")]
		void SetDisplayFrame (string animationName, int frameIndex);

	}

	[BaseType (typeof (NSObject))]
	interface CCFileUtils {
		[Export ("iPhoneRetinaDisplaySuffix")]
		string IPhoneRetinaDisplaySuffix { get; [Bind ("setiPhoneRetinaDisplaySuffix:")] set; }

		[Export ("iPadSuffix")]
		string IPadSuffix { get; [Bind ("setiPadSuffix:")] set; }

		[Export ("iPadRetinaDisplaySuffix")]
		string IPadRetinaDisplaySuffix { get; [Bind ("setiPadRetinaDisplaySuffix:")] set; }

		[Export ("enableFallbackSuffixes")]
		bool EnableFallbackSuffixes { get; set; }

		[Static]
		[Export ("sharedFileUtils")]
		CCFileUtils SharedFileUtils { get; }
	}

	[BaseType (typeof (NSObject))]
	interface CCCamera {
		[Export ("dirty")]
		bool Dirty { get; set;  }

		[Static]
		[Export ("getZEye")]
		float ZEye { get; }

		[Export ("restore")]
		void Restore ();

		[Export ("locate")]
		void Locate ();

		[Export ("setEyeX:eyeY:eyeZ:")]
		void SetEye (float x, float y, float z);

		[Export ("setCenterX:centerY:centerZ:")]
		void SetCenter (float x, float y, float z);

		[Export ("setUpX:upY:upZ:")]
		void SetUp (float x, float y, float z);

		[Export ("eyeX:eyeY:eyeZ:")]
		void GetEye (out float x, out float y, out float z);

		[Export ("centerX:centerY:centerZ:")]
		void GetCenter (out float x, out float y, out float z);

		[Export ("upX:upY:upZ:")]
		void GetUp (out float x, out float y, out float z);
	}

	[BaseType (typeof (CCScene))]
	interface CCTransitionScene {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionSceneOriented {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);

		[Export ("initWithDuration:scene:orientation:")]
		IntPtr Constructor (float duration, CCScene scene, CCOrientation orientation);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionRotoZoom {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionJumpZoom {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionMoveInL {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);

		[Export ("initScenes")]
		void InitScenes ();

		[Export ("action")]
		CCActionInterval Action { get; }
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionMoveInR {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionMoveInT {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionMoveInB {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionSlideInL {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);

		[Export ("initScenes")]
		void InitScenes ();

		[Export ("action")]
		CCActionInterval Action { get; }
	}

	[BaseType (typeof (CCTransitionSlideInL))]
	interface CCTransitionSlideInR {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionSlideInL))]
	interface CCTransitionSlideInB {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionSlideInL))]
	interface CCTransitionSlideInT {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionShrinkGrow {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionSceneOriented))]
	interface CCTransitionFlipX {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionSceneOriented))]
	interface CCTransitionFlipY {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionSceneOriented))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCTransitionFlipAnguled {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionSceneOriented))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCTransitionZoomFlipX {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionSceneOriented))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCTransitionZoomFlipY {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionSceneOriented))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCTransitionZoomFlipAngular {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionFade {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);

		[Export ("initWithDuration:scene:withColor:")]
		IntPtr Constructor (float duration, CCScene scene, CCColor3B color);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionCrossFade {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionTurnOffTiles {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionSplitCols {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);

		[Export ("action")]
		CCActionInterval Action { get; }
	}

	[BaseType (typeof (CCTransitionSplitCols))]
	interface CCTransitionSplitRows {
		[Export ("initWithDuration:scene:")]
		IntPtr Constructor (float duration, CCScene scene);
	}
	
	[BaseType (typeof (CCNode))]
	interface CCMenuItem {
		[Export ("initWithBlock:")]
		IntPtr Constructor (NSCallbackWithSender callback);
		
		[Export ("setBlock:")]
		void SetCallback (NSCallbackWithSender callback);		

		[Export ("rect")]
		RectangleF Rect { get; }

		[Export ("isEnabled")]
		bool Enabled { get; set; }

		[Export ("activate")]
		void Activate ();

		[Export ("selected")]
		void Selected ();

		[Export ("unselected")]
		void Unselected ();

	}

	[BaseType (typeof (CCMenuItem))]
	interface CCMenuItemLabel : CCRGBAProtocol {
		[Export ("initWithLabel:block:")]
		IntPtr Constructor (CCNode label, NSCallbackWithSender callback);

		//[Export ("label")]
		//CCNode Label { get; set; }
			
		[Export ("isEnabled")]
		bool IsEnabled { set; }

		[Export ("disabledColor")]
		CCColor3B DisabledColor { get; set;  }

	}


	[BaseType (typeof (CCMenuItemLabel))]
	interface CCMenuItemAtlasFont {
		[Export ("initWithString:charMapFile:itemWidth:itemHeight:startCharMap:target:selector:")]
		IntPtr Constructor (string value, string charMapFile, int itemWidth, int itemHeight, char startCharMap, NSObject target, Selector selector);

		[Export ("initWithString:charMapFile:itemWidth:itemHeight:startCharMap:block:")]
		IntPtr Constructor (string value, string charMapFile, int itemWidth, int itemHeight, char startCharMap, NSCallbackWithSender callback);
	}

	
	[BaseType (typeof (CCMenuItemLabel))]
	interface CCMenuItemFont {
		[Static]
		[Export ("fontSize")]
		uint DefaultFontSize { get; set; }

		[Static]
		[Export ("fontName")]
		string DefaultFontName { get; set; }

		[Export ("fontSize")]
		uint FontSize { get; set; }

		[Export ("fontName")]
		string FontName { get; set; }

		[Export ("initWithString:target:selector:")]
		IntPtr Constructor (string value, NSObject r, Selector s);

		[Export ("initWithString:block:")]
		IntPtr Constructor (string value, NSCallbackWithSender callback);
	}

	[BaseType (typeof(CCMenuItem))]
	interface CCMenuItemSprite : CCRGBAProtocol {
#if POST_2_0
		[Export ("normalImage")]
		CCNode NormalImage { get; set;  }

		[Export ("selectedImage")]
		CCNode SelectedImage { get; set;  }

		[Export ("disabledImage")]
		CCNode DisabledImage { get; set;  }
#endif
		[Export ("initFromNormalSprite:selectedSprite:disabledSprite:target:selector:")]
		IntPtr Constructor (CCNode normalSprite, CCNode selectedSprite, CCNode disabledSprite, NSObject target, Selector selector);

		[Export ("initFromNormalSprite:selectedSprite:disabledSprite:block:")]
		IntPtr Constructor (CCNode normalSprite, CCNode selectedSprite, CCNode disabledSprite, NSCallbackWithSender callback);

	}

	[BaseType (typeof(CCMenuItemSprite))]
	interface CCMenuItemImage {
		[Export ("initFromNormalImage:selectedImage:disabledImage:target:selector:")]
		IntPtr Constructor (string normalImage, [NullAllowed] string selectedImage, [NullAllowed] string disabledImage, NSObject target, Selector selector);

		[Export ("initFromNormalImage:selectedImage:disabledImage:block:")]
		IntPtr Constructor (string normalImage, [NullAllowed] string selectedImage, [NullAllowed] string disabledImage, NSCallbackWithSender callback);
	}

	[BaseType (typeof (CCMenuItem))]
	interface CCMenuItemToggle : CCRGBAProtocol {

		[Export ("selectedIndex")]
		int SelectedIndex { get; set;  }

		[Export ("subItems")]
		CCMenuItem [] SubItems { get; set;  }

		[Export ("selectedItem")]
		CCMenuItem SelectedItem  { get; }
	}

	[BaseType (typeof (CCLayer))]
	interface CCMenu : CCRGBAProtocol {
		[Export ("enabled")]
		bool Enabled { get; set; }

		[Export ("initWithArray:")]
		CCMenu Constructor (CCMenuItem[] items);

		[Export ("alignItemsVertically")]
		void AlignItemsVertically ();

		[Export ("alignItemsVerticallyWithPadding:")]
		void AlignItemsVertically (float padding);

		[Export ("alignItemsHorizontally")]
		void AlignItemsHorizontally ();
			
		[Export ("alignItemsHorizontallyWithPadding:")]
		void AlignItemsHorizontally (float padding);

		[Internal]
		[Export ("alignItemsInColumns:")]
		void AlignItemsInColumns (NSNumber firstItem, IntPtr itemPtr);

		[Internal]
		[Export ("alignItemsInRows:")]
		void AlignItemsInRows (NSNumber firstItem, IntPtr itemPtr);

		[Export ("handlerPriority")]
		int HandlerPriority { set; }
	}

	[BaseType (typeof (NSObject))]
	interface CCScheduler {
		[Export ("timeScale")]
		float TimeScale { get; set; }

		[Export ("scheduleSelector:forTarget:interval:paused:repeat:delay:")]
		void ScheduleSelector (Selector selector, NSObject target, float interval, bool paused, uint repeat, float delay);

		[Export ("scheduleSelector:forTarget:interval:paused:")]
		void ScheduleSelector (Selector selector, NSObject target, float interval, bool paused);

		[Export ("scheduleUpdateForTarget:priority:paused:")]
		void ScheduleUpdate (NSObject target, int priority, bool paused);

		[Export ("unscheduleSelector:forTarget:")]
		void UnscheduleSelector (Selector sel, NSObject target);

		[Export ("unscheduleUpdateForTarget:")]
		void UnscheduleUpdate (NSObject target);

		[Export ("unscheduleAllSelectorsForTarget:")]
		void UnscheduleAllSelectors (NSObject target);

		[Export ("unscheduleAllSelectors")]
		void UnscheduleAllSelectors ();

		[Export ("update:")]
		void Update (float deltaTime);

		[Export ("pauseTarget:")]
		void PauseTarget (NSObject target);

		[Export ("resumeTarget:")]
		void ResumeTarget (NSObject target);

		[Export ("isTargetPaused:")]
		bool IsTargetPaused (NSObject target);

		[Export ("pauseAllTargets")]
		NSSet PauseAllTargets ();

		[Export ("pauseAllTargetsWithMinPriority:")]
		NSSet PauseAllTargetsWithMinPriority (int minPriority);

		[Export ("resumeTargets:")]
		void ResumeTargets (NSSet targetsToResume);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCAccelAmplitude {
		[Export ("rate")]
		float Rate { get; set; }

		[Export ("initWithAction:duration:")]
		IntPtr Constructor (CCAction action, float d);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCAccelDeccelAmplitude {
		[Export ("rate")]
		float Rate { get; set; }

		[Export ("initWithAction:duration:")]
		IntPtr Constructor (CCAction action, float d);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCActionCamera {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithDuration:")]
		IntPtr Constructor (float duration);
	}
	
	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCActionEase {
		[Export ("initWithAction:")]
		IntPtr Constructor (CCActionInterval action);
	}

	[BaseType (typeof (CCGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCFlipX3D {
		[Export ("initWithDuration:")]
		IntPtr Constructor (float duration);
	}

	[BaseType (typeof (CCFlipX3D))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCFlipY3D {
		[Export ("initWithDuration:")]
		IntPtr Constructor (float duration);
	}

	[BaseType (typeof (CCActionInstant))]
	interface CCStopGrid {
	}

	[BaseType (typeof (CCGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCTwirl {
		[Export ("position")]
		PointF Position { get; set;  }

		[Export ("amplitude")]
		float Amplitude { get; set;  }

		[Export ("amplitudeRate")]
		float AmplitudeRate { get; set;  }

		[Export ("initWithPosition:twirls:amplitude:grid:duration:")]
		IntPtr Constructor (PointF position, int twirls, float amplitude, Size gridSize, float duration);
	}

	[BaseType (typeof (CCGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCWaves {
		[Export ("amplitude")]
		float Amplitude { get; set;  }

		[Export ("amplitudeRate")]
		float AmplitudeRate { get; set;  }

		[Export ("initWithWaves:amplitude:horizontal:vertical:grid:duration:")]
		IntPtr Constructor (int waves, float amplitude, bool horizontal, bool vertical, Size gridSize, float duration);

	}

	[BaseType (typeof (CCGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCWaves3D {
		[Export ("amplitude")]
		float Amplitude { get; set;  }

		[Export ("amplitudeRate")]
		float AmplitudeRate { get; set;  }

		[Export ("initWithWaves:amplitude:grid:duration:")]
		IntPtr Constructor (int waves, float amplitude, Size gridSize, float duration);
	}

	[BaseType (typeof (CCActionInstant))]
	interface CCShow {
	}

	[BaseType (typeof (CCActionInstant))]
	interface CCHide {
	}

	[BaseType (typeof (CCActionInstant))]
	interface CCToggleVisibility {
	}

	[BaseType (typeof (CCGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCLens3D {
		[Export ("lensEffect")]
		float LensEffect { get; set;  }

		[Export ("position")]
		PointF Position { get; set;  }

		[Export ("initWithPosition:radius:grid:duration:")]
		IntPtr Constructor (PointF position, float radius, Point gridSize, float duration);
	}

	[BaseType (typeof (CCActionCamera))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCOrbitCamera {
		[Export ("initWithDuration:radius:deltaRadius:angleZ:deltaAngleZ:angleX:deltaAngleX:")]
		IntPtr Constructor (float duration, float radius, float deltaRadius, float angleZ, float deltaAngleZ, float angleX, float deltaAngleX);

		[Export ("sphericalRadius:zenith:azimuth:")]
		void GetSphere (ref float radius, ref float zenith, ref float azimuth);
	}

	[BaseType (typeof (NSObject))]
	interface CCPointArray {
		[Export ("controlPoints")]
		NSMutableArray ControlPoints { get; set; }

		[Export ("initWithCapacity:")]
		IntPtr Constructor (uint capacity);

		[Export ("addControlPoint:")]
		void Add (PointF controlPoint);

		[Export ("insertControlPoint:atIndex:")]
		void Insert (PointF controlPoint, int index);

		[Export ("replaceControlPoint:atIndex:")]
		void Replace (PointF controlPoint, int ndex);

		[Export ("getControlPointAtIndex:"), Internal]
		PointF GetControlPoint (int index);

		[Export ("removeControlPointAtIndex:")]
		void Remove (int index);

		[Export ("count")]
		int Count { get; }

		[Export ("reverse")]
		CCPointArray Reverse ();

		[Export ("reverseInline")]
		void ReverseInline ();
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCCardinalSplineTo {
		[Export ("points")]
		CCPointArray Points { get; set; }

		[Export ("initWithDuration:points:tension:")]
		IntPtr Constructor (float duration, CCPointArray points, float tension);
	}

	[BaseType (typeof (CCCardinalSplineTo))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCCardinalSplineBy {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithDuration:points:tension:")]
		IntPtr Constructor (float duration, CCPointArray points, float tension);
	}

	[BaseType (typeof (CCCardinalSplineTo))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCCatmullRomTo {
		[Export ("initWithDuration:points:")]
		IntPtr Constructor (float duration, CCPointArray points);
	}

	[BaseType (typeof (CCCardinalSplineBy))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCCatmullRomBy {
		[Export ("initWithDuration:points:")]
		IntPtr Constructor (float duration, CCPointArray points);
	}


	[BaseType (typeof (CCGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCRipple3D {
		[Export ("position")]
		PointF Position { get; set;  }

		[Export ("amplitude")]
		float Amplitude { get; set;  }

		[Export ("amplitudeRate")]
		float AmplitudeRate { get; set;  }

		[Export ("initWithPosition:radius:waves:amplitude:grid:duration:")]
		IntPtr Constructor (PointF position, float radius, int waves, float amplitude, Point gridSize, float duration);
	}

	[BaseType (typeof (CCGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCShaky3D {
		[Export ("initWithRange:shakeZ:grid:duration:")]
		IntPtr Constructor (int range, bool shakeZ, Size gridSize, float duration);
	}

	[BaseType (typeof (CCGridAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCTiledGrid3DAction {
		[Export ("initWithSize:duration:")]
		IntPtr Constructor (Size gridSize, float duration);

		[Export ("tile:")]
		CCQuad3 GetTile (Point position);

		[Export ("originalTile:")]
		CCQuad3 GetOriginalTile (Point pos);

		[Export ("setTile:coords:")]
		void SetTile (Point pos, CCQuad3 coords);
	}

	[BaseType (typeof (CCActionEase))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCEaseBackIn {
		[Export ("initWithAction:")]
		IntPtr Constructor (CCActionInterval action);
	}

	[BaseType (typeof (CCActionEase))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCEaseBackOut {
		[Export ("initWithAction:")]
		IntPtr Constructor (CCActionInterval action);
	}

	[BaseType (typeof (CCActionEase))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCEaseBackInOut {
		[Export ("initWithAction:")]
		IntPtr Constructor (CCActionInterval action);
	}

	[BaseType (typeof (CCActionEase))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCEaseBounce {
		[Export ("initWithAction:")]
		IntPtr Constructor (CCActionInterval action);
	}

	[BaseType (typeof (CCEaseBounce))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCEaseBounceIn {
		[Export ("initWithAction:")]
		IntPtr Constructor (CCActionInterval action);
	}

	[BaseType (typeof (CCEaseBounce))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCEaseBounceOut {
		[Export ("initWithAction:")]
		IntPtr Constructor (CCActionInterval action);
	}

	[BaseType (typeof (CCEaseBounce))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCEaseBounceInOut {
		[Export ("initWithAction:")]
		IntPtr Constructor (CCActionInterval action);
	}

	[BaseType (typeof (CCActionEase))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCEaseElastic {
		[Export ("period")]
		float Period { get; set; }
		
		[Export ("initWithAction:period:")]
		IntPtr Constructor (CCActionInterval action , float period);
	}

	[BaseType (typeof (CCEaseElastic))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCEaseElasticIn {
		[Export ("initWithAction:period:")]
		IntPtr Constructor (CCActionInterval action , float period);
	}

	[BaseType (typeof (CCEaseElastic))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCEaseElasticInOut {
		[Export ("initWithAction:period:")]
		IntPtr Constructor (CCActionInterval action , float period);
	}

	[BaseType (typeof (CCEaseElastic))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCEaseElasticOut {
		[Export ("initWithAction:period:")]
		IntPtr Constructor (CCActionInterval action , float period);
	}

	[BaseType (typeof (CCActionEase))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCEaseExponentialIn {
		[Export ("initWithAction:")]
		IntPtr Constructor (CCActionInterval action);
	}

	[BaseType (typeof (CCActionEase))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCEaseExponentialInOut {
		[Export ("initWithAction:")]
		IntPtr Constructor (CCActionInterval action);
	}

	[BaseType (typeof (CCActionEase))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCEaseExponentialOut {
		[Export ("initWithAction:")]
		IntPtr Constructor (CCActionInterval action);
	}

	[BaseType (typeof (CCEaseRateAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCEaseIn {
		[Export ("initWithAction:rate:")]
		IntPtr Constructor (CCActionInterval action , float rate);
	}

	[BaseType (typeof (CCEaseRateAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCEaseInOut {
		[Export ("initWithAction:rate:")]
		IntPtr Constructor (CCActionInterval action , float rate);
	}

	[BaseType (typeof (CCEaseRateAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCEaseOut {
		[Export ("initWithAction:rate:")]
		IntPtr Constructor (CCActionInterval action , float rate);
	}

	[BaseType (typeof (CCActionEase))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCEaseRateAction {
		[Export ("rate")]
		float Rate { get; set; }

		[Export ("initWithAction:rate:")]
		IntPtr Constructor (CCActionInterval action , float rate);
	}
	
	[BaseType (typeof (CCActionEase))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCEaseSineIn {
		[Export ("initWithAction:")]
		IntPtr Constructor (CCActionInterval action);
	}

	[BaseType (typeof (CCActionEase))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCEaseSineInOut {
		[Export ("initWithAction:")]
		IntPtr Constructor (CCActionInterval action);
	}

	[BaseType (typeof (CCActionEase))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCEaseSineOut {
		[Export ("initWithAction:")]
		IntPtr Constructor (CCActionInterval action);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCDeccelAmplitude {
		[Export ("rate")]
		float Rate { get; set; }

		[Export ("initWithAction:duration:")]
		IntPtr Constructor (CCAction action, float d);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCGridAction {
		[Export ("gridSize")]
		Point GridSize { get; set; }

		[Export ("initWithSize:duration:")]
		IntPtr Constructor (Size gridSize, float duration);

		[Export ("grid")]
		CCGridBase Grid ();
	}

	[BaseType (typeof (CCGridAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCGrid3DAction {
		[Export ("vertex:")]
		Vector3 GetVertex (Point pos);

		[Export ("originalVertex:")]
		Vector3 GetOriginalVertex (Point pos);

		[Export ("setVertex:vertex:")]
		void SetVertex (Point position, Vector3 vertex);

		[Export ("initWithSize:duration:")]
		IntPtr Constructor (Size gridSize, float duration);

	}

	[BaseType (typeof (CCActionInstant))]
	interface CCReuseGrid {
		[Export ("initWithTimes:")]
		IntPtr Constructor (int times);
	}

	[BaseType (typeof (CCActionInstant))]
	interface CCFlipX {
		[Export ("initWithFlipX:")]
		IntPtr Constructor (bool flipped);

	}

	[BaseType (typeof (CCActionInstant))]
	interface CCFlipY {
		[Export ("initWithFlipY:")]
		IntPtr Constructor  (bool flipped);
	}

	[BaseType (typeof (CCActionInstant))]
	interface CCPlace {
		[Export ("initWithPosition:")]
		IntPtr Constructor (PointF position);
	}

	[BaseType (typeof (CCActionInstant))]
	interface CCCallBlock {
		[Export ("initWithBlock:")]
		IntPtr Constructor (NSAction action);

		[Export ("execute")]
		void Execute ();
	}

	[BaseType (typeof (CCGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCPageTurn3D {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithSize:duration:")]
		IntPtr Constructor (Size gridSize, float duration);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCProgressTo {
		[Export ("initWithDuration:percent:")]
		IntPtr Constructor (float duration, float percent);
	}

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCProgressFromTo {
		[Export ("initWithDuration:from:to:")]
		IntPtr Constructor (float duration, float fromPercentage, float toPercentage);
	}

	[BaseType (typeof (NSObject))]
	interface CCGridBase {
		[Export ("active")]
		bool Active { get; set;  }

		[Export ("reuseGrid")]
		int ReuseGrid { get; set;  }

		[Export ("gridSize")]
		Point GridSize { get;  }

		[Export ("step")]
		PointF Step { get; set;  }

		[Export ("texture")]
		CCTexture2D Texture { get; set;  }

		[Export ("grabber")]
		CCGrabber Grabber { get; set;  }

		[Export ("isTextureFlipped")]
		bool IsTextureFlipped { get; set;  }

		[Export ("initWithSize:texture:flippedTexture:")]
		IntPtr Constructor (Size gridSize, CCTexture2D texture, bool flippedTexture);

		[Export ("initWithSize:")]
		IntPtr Constructor (Size gridSize);

		[Export ("beforeDraw")]
		void BeforeDraw ();

		[Export ("afterDraw:")]
		void AfterDraw (CCNode target);

		[Export ("blit")]
		void Blit ();

		[Export ("reuse")]
		void Reuse ();

		[Export ("calculateVertexPoints")]
		void CalculateVertexPoints ();

	}

	[BaseType (typeof (CCGridBase))]
	interface CCGrid3D {
		[Export ("vertex:")]
		Vector3 GetVertex (Point pos);

		[Export ("originalVertex:")]
		Vector3 GetOriginalVertex (Point pos);

		[Export ("setVertex:vertex:")]
		void SetVertex (Point pos, Vector3 vertex);

	}

	[BaseType (typeof (CCGridBase))]
	interface CCTiledGrid3D {
		[Export ("tile:")]
		CCQuad3 GetTile (Point pos);

		[Export ("originalTile:")]
		CCQuad3 GetOriginalTile (Point pos);

		[Export ("setTile:coords:")]
		void SetTile (Point pos, CCQuad3 coords);

	}	

	[BaseType (typeof (NSObject))]
	interface CCGrabber {
		[Export ("grab:")]
		void Grab (CCTexture2D texture);

		[Export ("beforeRender:")]
		void BeforeRender (CCTexture2D texture);

		[Export ("afterRender:")]
		void AfterRender (CCTexture2D texture);
	}

	[BaseType (typeof (CCTiledGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCShakyTiles3D {
		[Export ("initWithRange:shakeZ:grid:duration:")]
		IntPtr Constructor (int range, bool shakeZ, Size gridSize, float duration);
	}

	[BaseType (typeof (CCTiledGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCShatteredTiles3D {
		[Export ("initWithRange:shatterZ:grid:duration:")]
		IntPtr Constructor (int range, bool shatterZ, Size gridSize, float duration);
	}

	[BaseType (typeof (CCTiledGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCShuffleTiles {
		[Export ("initWithSeed:grid:duration:")]
		IntPtr Constructor (int seed, Size gridSize, float duration);
	}

	[BaseType (typeof (CCTiledGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCFadeOutTRTiles {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithSize:duration:")]
		IntPtr Constructor (Size gridSize, float duration);
	}

	[BaseType (typeof (CCFadeOutTRTiles))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCFadeOutBLTiles {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithSize:duration:")]
		IntPtr Constructor (Size gridSize, float duration);
	}

	[BaseType (typeof (CCFadeOutTRTiles))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCFadeOutUpTiles {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithSize:duration:")]
		IntPtr Constructor (Size gridSize, float duration);
	}

	[BaseType (typeof (CCFadeOutUpTiles))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCFadeOutDownTiles {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithSize:duration:")]
		IntPtr Constructor (Size gridSize, float duration);
	}

	[BaseType (typeof (CCTiledGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCTurnOffTiles {
		[Export ("initWithSeed:grid:duration:")]
		IntPtr Constructor (int seed, Size gridSize, float duration);
	}

	[BaseType (typeof (CCTiledGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCWavesTiles3D {
		[Export ("amplitude")]
		float Amplitude { get; set;  }

		[Export ("amplitudeRate")]
		float AmplitudeRate { get; set;  }

		[Export ("initWithWaves:amplitude:grid:duration:")]
		IntPtr Constructor (int waves, float amplitude, Size gridSize, float duration);
	}

	[BaseType (typeof (CCTiledGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCJumpTiles3D {
		[Export ("amplitude")]
		float Amplitude { get; set;  }

		[Export ("amplitudeRate")]
		float AmplitudeRate { get; set;  }

		[Export ("initWithJumps:amplitude:grid:duration:")]
		IntPtr Constructor (int jumps, float amplitude, Size gridSize, float duration);
	}

	[BaseType (typeof (CCTiledGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCSplitRows {
		[Export ("initWithRows:duration:")]
		IntPtr Constructor (int rows, float duration);

	}

	[BaseType (typeof (CCTiledGrid3DAction))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCSplitCols {
		[Export ("initWithCols:duration:")]
		IntPtr Constructor  (int cols, float durationuration);
	}
	

	[BaseType (typeof (CCActionInterval))]
	[DisableDefaultCtor] // instance has no valid handle
	interface CCActionTween {
		[Export ("initWithDuration:key:from:to:")]
		IntPtr Constructor (float duration, NSString key, float from, float to);

	}

	[BaseType (typeof (NSObject))]
	interface CCAnimationCache {
		[Static]
		[Export ("sharedAnimationCache")]
		CCAnimationCache SharedAnimationCache { get; }

		[Static]
		[Export ("purgeSharedAnimationCache")]
		void PurgeSharedAnimationCache ();

		[Export ("addAnimation:name:")]
		void AddAnimation (CCAnimation animation, string name);

		[Export ("removeAnimationByName:")]
		void RemoveAnimation (string name);

		[Export ("animationByName:")]
		CCAnimation GetAnimation (string name);

		[Export ("addAnimationsWithDictionary:")]
		void AddAnimations (NSDictionary dictionary);

		[Export ("addAnimationsWithFile:")]
		void AddAnimationsFromFile (string plist);

	}

	[BaseType (typeof (CCNode))]
	[DisableDefaultCtor] // (in debug) Not supported - Use initWtihTileFile instead
	interface CCAtlasNode : CCRGBAProtocol, CCTextureProtocol {
		[Export ("textureAtlas")]
		CCTextureAtlas TextureAtlas { get; set;  }

		[Export ("quadsToDraw")]
		uint QuadsToDraw { get; set;  }

		[Export ("initWithTileFile:tileWidth:tileHeight:itemsToRender:")]
		IntPtr Constructor (string tileFile, int tileWidth, int tileHeight, uint itemsToRenderCount);

		[Export ("updateAtlasValues")]
		void UpdateAtlasValues ();

	}

	[BaseType (typeof (CCNode))]
	interface CCDrawNode {
		[Export ("drawDot:radius:dolor:")]
		void DrawDot (PointF position, float radius, CCColor4F color);

		[Export ("drawSegmentFrom:to:radius:color:")]
		void DrawSegment (PointF from, PointF to, float radius, CCColor4F color);

		//[Export ("drawPolyWithVerts:count:fillColor:borderWidth:borderColor:")]
		//void DrawPoly (Pointf [] vertices, CCColor4F fillColor, float borderWidth, CCColor4F borderColor);
		
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // use SharedConfiguration otherwise it crash with: 
	// Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: *** +[NSString stringWithCString:encoding:]: NULL cString
	interface CCConfiguration {
		[Export ("maxTextureSize")]
		int MaxTextureSize { get;  }

		[Export ("maxModelviewStackDepth")]
		int MaxModelviewStackDepth { get;  }

		[Export ("maxTextureUnits")]
		int MaxTextureUnits { get;  }

		[Export ("supportsNPOT")]
		bool SupportsNPOT { get;  }

		[Export ("supportsPVRTC")]
		bool SupportsPVRTC { get;  }

		[Export ("supportsBGRA8888")]
		bool SupportsBGRA8888 { get;  }

		[Export ("supportsDiscardFramebuffer")]
		bool SupportsDiscardFramebuffer { get;  }

		[Export ("supportsShareableVAO")]
		bool SupportsShareableVAO { get;  }

		[Export ("OSVersion")]
		CCOSVersion OSVersion { get;  }

		[Static]
		[Export ("sharedConfiguration")]
		CCConfiguration SharedConfiguration { get; }

		[Export ("checkForGLExtension:")]
		bool CheckForGLExtension (string searchName);
	}
	
	[BaseType (typeof (CCAtlasNode))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: IntervalActionInit: Init not supported. Use InitWithDuration
	interface CCLabelAtlas : CCLabelProtocol {
		[Export ("initWithString:charMapFile:itemWidth:itemHeight:startCharMap:")]
		IntPtr Constructor (string text, string atlasCharmapFile, uint elementWidth, uint elementHeight, char startingCharInAtlas);

		[Export ("initWithString:fntFile:")]
		IntPtr Constructor (string text, string fontConfigFile);
	}
	
	[BaseType (typeof (NSObject))]
	interface CCBMFontConfiguration {
		[Export ("atlasName")]
		string AtlasName { get; set;  }

		[Export ("initWithFNTfile:")]
		IntPtr Constructor (string fontConfigFile);

	}

	[BaseType (typeof (CCLayerColor))]
	interface CCLayerGradient {
		[Export ("startColor")]
		CCColor3B StartColor { get; set;  }

		[Export ("endColor")]
		CCColor3B EndColor { get; set;  }

		[Export ("startOpacity")]
		byte StartOpacity { get; set;  }

		[Export ("endOpacity")]
		byte EndOpacity { get; set;  }

		[Export ("vector")]
		PointF Vector { get; set;  }

		[Export ("compressedInterpolation")]
		bool CompressedInterpolation { get; set;  }

		[Export ("initWithColor:fadingTo:")]
		IntPtr Constructor (CCColor4B start, CCColor4B end);

		[Export ("initWithColor:fadingTo:alongVector:")]
		IntPtr Constructor (CCColor4B start, CCColor4B end, PointF alongVector);

	}

	[BaseType (typeof (CCLayer))]
	interface CCLayerMultiplex {
		[Export ("initWithLayers:vaList:")]
		IntPtr Constructor (CCLayer layer, IntPtr pars);

		[Export ("switchTo:")]
		void SwitchTo (uint n);

		[Export ("switchToAndReleaseMe:")]
		void SwitchToAndReleaseMe (uint n);
	}

#if ENABLE_CHIPMUNK_INTEGRATION
	[BaseType(typeof(CCDrawNode))]
	[DisableDefaultCtor]
	interface CCPhysicsDebugNode {
		[Export("debugNodeForCPSpace:")]
		[Static]
		[Internal]
		CCPhysicsDebugNode DebugNode (IntPtr space);
	}

	[BaseType(typeof(CCSprite))]
	interface CCPhysicsSprite {
		[Export ("initWithTexture:rect:rotated:")]
		IntPtr Constructor (CCTexture2D texture, RectangleF rect, bool rotated);

		[Export ("initWithTexture:rect:")]
		IntPtr Constructor (CCTexture2D texture, RectangleF rect);

		[Export ("initWithFile:")]
		IntPtr Constructor (string filename);

		[Export ("initWithFile:rect:")]
		IntPtr Constructor (string filename, RectangleF rect);

		[Export("ignoreBodyRotation")]
		bool IgnoreBodyRotation { get; set; }

		[Internal]
		[Export("CPBody")]
		IntPtr BodyPtr { get; set; }

		[Internal]
		[Export ("position")]
		PointF PositionInt { get; set; }
	}
#endif

	[BaseType (typeof (CCNode))]
	interface CCClippingNode {
		[Export ("stencil")]
		CCNode Stencil { get; set; }
		
		[Export ("alphaThreshold")]
		float AlphaThreshold { get; set; }

		[Export ("inverted")]
		bool Inverted { get; set; }

		[Export ("initWithStencil:")]
		IntPtr Constructor (CCNode stencil);
	}

	[BaseType (typeof (CCNode))]
	interface CCMotionStreak {
		[Export ("blendFunc")]
		CCBlendFunc BlendFunc { get; set;  }

		[Export ("fastMode")]
		bool FastMode { [Bind ("isFastMode")] get; set; }

		[Export ("texture")]
		CCTexture2D Texture { get; set;  }

		[Export ("initWithFade:minSeg:width:color:textureFilename:")]
		IntPtr Constructor (float fade, float minSeg, float stroke, CCColor3B color, string textureFilename);

		[Export ("initWithFade:minSeg:width:color:texture:")]
		IntPtr Constructor (float fade, float minSeg, float stroke, CCColor3B color, CCTexture2D texture);

		[Export ("tintWithColor:")]
		void TintWithColor (CCColor3B color);

		[Export ("reset")]
		void Reset ();
	}

	[BaseType (typeof (CCNode))]
	interface CCParallaxNode {
		[Export ("parallaxArray")]
		CCArray ParallaxArray { get; set;  }

		[Export ("addChild:z:parallaxRatio:positionOffset:")]
		void AddChild (CCNode node, int zOrder, PointF parallaxRatio, PointF positionOffset);

	}


	[BaseType (typeof (ARCH_OPTIMAL_PARTICLE_SYSTEM))]
	interface CCParticleFire {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithTotalParticles:")]
		IntPtr Constructor (int particles);
	}

	[BaseType (typeof (ARCH_OPTIMAL_PARTICLE_SYSTEM))]
	interface CCParticleFireworks {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithTotalParticles:")]
		IntPtr Constructor (int particles);
	}

	[BaseType (typeof (ARCH_OPTIMAL_PARTICLE_SYSTEM))]
	interface CCParticleSun {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithTotalParticles:")]
		IntPtr Constructor (int particles);
	}

	[BaseType (typeof (ARCH_OPTIMAL_PARTICLE_SYSTEM))]
	interface CCParticleGalaxy {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithTotalParticles:")]
		IntPtr Constructor (int particles);
	}

	[BaseType (typeof (ARCH_OPTIMAL_PARTICLE_SYSTEM))]
	interface CCParticleFlower {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithTotalParticles:")]
		IntPtr Constructor (int particles);
	}

	[BaseType (typeof (ARCH_OPTIMAL_PARTICLE_SYSTEM))]
	interface CCParticleMeteor {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithTotalParticles:")]
		IntPtr Constructor (int particles);
	}

	[BaseType (typeof (ARCH_OPTIMAL_PARTICLE_SYSTEM))]
	interface CCParticleSpiral {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithTotalParticles:")]
		IntPtr Constructor (int particles);
	}

	[BaseType (typeof (ARCH_OPTIMAL_PARTICLE_SYSTEM))]
	interface CCParticleExplosion {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithTotalParticles:")]
		IntPtr Constructor (int particles);
	}

	[BaseType (typeof (ARCH_OPTIMAL_PARTICLE_SYSTEM))]
	interface CCParticleSmoke {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithTotalParticles:")]
		IntPtr Constructor (int particles);
	}

	[BaseType (typeof (ARCH_OPTIMAL_PARTICLE_SYSTEM))]
	interface CCParticleSnow {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithTotalParticles:")]
		IntPtr Constructor (int particles);
	}

	[BaseType (typeof (ARCH_OPTIMAL_PARTICLE_SYSTEM))]
	interface CCParticleRain {
		// note: .ctor are not inherited so we need to duplicate the entry
		[Export ("initWithTotalParticles:")]
		IntPtr Constructor (int particles);
	}

	[BaseType (typeof (CCParticleSystem))]
	interface CCParticleSystemQuad {
		[Export ("initWithTotalParticles:")]
		IntPtr Constructor (int particles);
		
		[Export ("initIndices")]
		void InitIndices ();

		[Export ("initTexCoordsWithRect:")]
		void InitTexCoordsWithRect (RectangleF rect);

		[Export ("setDisplayFrame:")]
		void SetDisplayFrame (CCSpriteFrame spriteFrame);

		[Export ("setTexture:withRect:")]
		void SetTexture (CCTexture2D texture, RectangleF rect);
	}

	[BaseType (typeof (CCNode))]
	interface CCParticleSystem {
		[Export ("active")]
		bool Active { get;  }

		[Export ("particleCount")]
		int ParticleCount { get;  }

		[Export ("duration")]
		float Duration { get; set;  }

		[Export ("sourcePosition")]
		PointF SourcePosition { get; set;  }

		[Export ("posVar")]
		PointF PositionVariance { get; set;  }

		[Export ("life")]
		float Life { get; set;  }

		[Export ("lifeVar")]
		float LifeVariance { get; set;  }

		[Export ("angle")]
		float Angle { get; set;  }

		[Export ("angleVar")]
		float AngleVariance { get; set;  }

		[Export ("gravity")]
		PointF Gravity { get; set;  }

		[Export ("speed")]
		float Speed { get; set;  }

		[Export ("speedVar")]
		float SpeedVariance { get; set;  }

		[Export ("tangentialAccel")]
		float TangentialAcceleration { get; set;  }

		[Export ("tangentialAccelVar")]
		float TangentialAccelerationVariance { get; set;  }

		[Export ("radialAccel")]
		float RadialAcceleration { get; set;  }

		[Export ("radialAccelVar")]
		float RadialAccelerationVariance { get; set;  }

		[Export ("startRadius")]
		float StartRadius { get; set;  }

		[Export ("startRadiusVar")]
		float StartRadiusVariance { get; set;  }

		[Export ("endRadius")]
		float EndRadius { get; set;  }

		[Export ("endRadiusVar")]
		float EndRadiusVariance { get; set;  }

		[Export ("rotatePerSecond")]
		float RotatePerSecond { get; set;  }

		[Export ("rotatePerSecondVar")]
		float RotatePerSecondVariance { get; set;  }

		[Export ("startSize")]
		float StartSize { get; set;  }

		[Export ("startSizeVar")]
		float StartSizeVariance { get; set;  }

		[Export ("endSize")]
		float EndSize { get; set;  }

		[Export ("endSizeVar")]
		float EndSizeVariance { get; set;  }

		[Export ("startColor")]
		CCColor4F StartColor { get; set;  }

		[Export ("startColorVar")]
		CCColor4F StartColorVariance { get; set;  }

		[Export ("endColor")]
		CCColor4F EndColor { get; set;  }

		[Export ("endColorVar")]
		CCColor4F EndColorVariance { get; set;  }

		[Export ("startSpin")]
		float StartSpin { get; set;  }

		[Export ("startSpinVar")]
		float StartSpinVariance { get; set;  }

		[Export ("endSpin")]
		float EndSpin { get; set;  }

		[Export ("endSpinVar")]
		float EndSpinVariance { get; set;  }

		[Export ("emissionRate")]
		float EmissionRate { get; set;  }

		[Export ("totalParticles")]
		int TotalParticles { get; set;  }

		[Export ("texture")]
		CCTexture2D Texture { get; set;  }

		[Export ("blendFunc")]
		CCBlendFunc BlendFunc { get; set;  }

		[Export ("opacityModifyRGB")]
		bool OpacityModifiesRGB { [Bind ("doesOpacityModifyRGB")] get; set;  }

		[Export ("blendAdditive")]
		bool BlendAdditive { get; set;  }

		[Export ("positionType")]
		CCPositionType PositionType { get; set;  }

		[Export ("autoRemoveOnFinish")]
		bool AutoRemoveOnFinish { get; set;  }

		[Export ("emitterMode")]
		CCParticleEmitterMode EmitterMode { get; set;  }

		[Export ("batchNode")]
		CCParticleBatchNode BatchNode { get; set;  }

		[Export ("atlasIndex")]
		uint AtlasIndex { get; set;  }

		[Export ("initWithFile:")]
		IntPtr Constructor (string plistFile);

		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		[Export ("initWithTotalParticles:")]
		IntPtr Constructor (int numberOfParticles);

		[Export ("stopSystem")]
		void StopSystem ();

		[Export ("resetSystem")]
		void ResetSystem ();

		[Export ("isFull")]
		bool IsFull { get; }

		[Export ("updateQuadWithParticle:newPosition:")]
		void UpdateQuad (ref CCParticle particle, PointF pos);

		[Export ("postStep")]
		void PostStep ();

		[Export ("update:")]
		void Update (float deltaTime);

		[Export ("updateWithNoTime")]
		void UpdateWithNoTime ();

	}

	[BaseType (typeof (CCNode))]
	interface CCParticleBatchNode {
		[Export ("textureAtlas")]
		CCTextureAtlas TextureAtlas { get; set;  }

		[Export ("blendFunc")]
		CCBlendFunc BlendFunc { get; set;  }

		[Export ("initWithTexture:capacity:")]
		IntPtr Constructor (CCTexture2D texture, int capacity);

		[Export ("initWithFile:capacity:")]
		IntPtr Constructor (string fileImage, int capacity);

		[Export ("addChild:z:tag:")]
		void AddChild (CCParticleSystem child, int zOrder, int aTag);

		[Export ("insertChild:inAtlasAtIndex:")]
		void InsertChild (CCParticleSystem pSystem, uint inAtlasAtIndex);

		[Export ("removeChild:cleanup:")]
		void RemoveChildcleanup (CCParticleSystem pSystem, bool cleanUp);

		[Export ("disableParticle:")]
		void DisableParticle (uint particleIndex);

	}

	[BaseType (typeof (CCNode))]
	interface CCProgressTimer {
		[Export ("opacity")]
		byte Opacity { get; set;  }

		[Export ("type")]
		CCProgressTimerType Type { get; set;  }

		[Export ("reverseDirection")]
		bool ReverseDirection { get; set;  }

		[Export ("vertexData")]
		CCV2F_C4B_T2F VertexData { get;  }

		[Export ("vertexDataCount")]
		int VertexDataCount { get;  }

		[Export ("midpoint")]
		PointF Midpoint { get; set;  }

		[Export ("barChangeRate")]
		PointF BarChangeRate { get; set;  }

		[Export ("percentage")]
		float Percentage { get; set;  }

		[Export ("sprite")]
		CCSprite Sprite { get; set;  }

		[Export ("initWithSprite:")]
		IntPtr Constructor (CCSprite sprite);
	}

	[BaseType (typeof (CCNode))]
	interface CCRenderTexture {
		[Export ("sprite")]
		CCSprite Sprite { get; set;  }

		[Export ("initWithWidth:height:pixelFormat:")]
		IntPtr Constructor (int width, int height, CCTexture2DPixelFormat pixelFormat);

		[Export ("initWithWidth:height:pixelFormat:depthStencilFormat:")]
		IntPtr Constructor (int width, int height, CCTexture2DPixelFormat pixelFormat, uint openGLdepthStencilFormat);

		[Export ("begin")]
		void Begin ();

		[Export ("beginWithClear:g:b:a:")]
		void BeginWithClear (float red, float green, float blue, float alpha);

		[Export ("beginWithClear:g:b:a:depth:")]
		void BeginWithClear (float red, float green, float blue, float alpha, float depthValue);

		[Export ("beginWithClear:g:b:a:depth:stencil:")]
		void BeginWithClear (float red, float green, float blue, float alpha, float depthValue, int stencilValue);

		[Export ("end")]
		void End ();

		[Export ("clear:g:b:a:")]
		void Clear (float red, float green, float blue, float alpha);

		[Export ("clearDepth:")]
		void ClearDepth (float depthValue);

		[Export ("clearStencil:")]
		void ClearStencil (int stencilValue);

		[Export ("newCGImage")]
		CGImage NewCGImage ();

		[Export ("saveToFile:")]
		bool SaveToFile (string name);

		[Export ("saveToFile:format:")]
		bool SaveToFile (string name, CCImageFormat format);

		[Export ("getUIImage")]
		UIImage GetUIImage ();
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: CCTimer: Init not supported.
	interface CCTimer {
		[Export ("interval")]
		float Interval { get; set;  }

		[Export ("initWithTarget:selector:")]
		IntPtr Constructor (NSObject target, Selector selector);

		[Export ("initWithTarget:selector:interval:repeat:delay:")]
		IntPtr Constructor (NSObject target, Selector selector, float seconds, int repeat, float delay);

		[Export ("update:")]
		void Update (float deltaTime);
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // Objective-C exception thrown.  Name: NSInternalInconsistencyException Reason: Attempted to allocate a second instance of a singleton.
	interface CCShaderCache {
		[Static]
		[Export ("sharedShaderCache")]
		CCShaderCache SharedShaderCache { get; }

		[Static]
		[Export ("purgeSharedShaderCache")]
		void PurgeSharedShaderCache ();

		[Export ("loadDefaultShaders")]
		void LoadDefaultShaders ();

		[Export ("programForKey:")]
		CCGLProgram GetProgram (string key);

		[Export ("addProgram:forKey:")]
		void AddProgram (CCGLProgram program, string key);
	}
	

	[BaseType (typeof (NSObject))]
	interface CCGLProgram {
		[Export ("initWithVertexShaderByteArray:fragmentShaderByteArray:")]
		IntPtr Constructor (IntPtr vShaderByteArray, IntPtr fShaderByteArray);

		[Export ("initWithVertexShaderFilename:fragmentShaderFilename:")]
		IntPtr Constructor (string vertexShaderFilename, string fragmentShaderFilename);

		[Export ("addAttribute:index:")]
		void AddAttribute (string attributeName, uint index);

		[Export ("link")]
		bool Link ();

		[Export ("use")]
		void Use ();

		[Export ("updateUniforms")]
		void UpdateUniforms ();

		[Export ("setUniformLocation:withI1:")]
		void SetUniformLocation (uint location, int i1);

		[Export ("setUniformLocation:withF1:")]
		void SetUniformLocation (uint location, float f1);

		[Export ("setUniformLocation:withF1:f2:")]
		void SetUniformLocation (uint location, float f1, float f2);

		[Export ("setUniformLocation:withF1:f2:f3:")]
		void SetUniformLocation (uint location, float f1, float f2, float f3);

		[Export ("setUniformLocation:withF1:f2:f3:f4:")]
		void SetUniformLocation (uint location, float f1, float f2, float f3, float f4);

		//[Export ("setUniformLocation:with2fv:count:")]
		//unsafe void SetUniformLocation2f (uint location, float *floats, uint numberOfArrays);
		//
		//[Export ("setUniformLocation:with3fv:count:")]
		//unsafe void SetUniformLocation3f (uint location, float* floats, uint numberOfArrays);
		//
		//[Export ("setUniformLocation:with4fv:count:")]
		//unsafe void SetUniformLocation4f (uint location, float *floats, uint numberOfArrays);
		//
		//[Export ("setUniformLocation:withMatrix4fv:arraycount:")]
		//unsafe void SetUniformLocationMatrix4 (uint location, float *matrix_array, uint numberOfMatrix);

		[Export ("setUniformForModelViewProjectionMatrix")]
		void SetUniformForModelViewProjectionMatrix ();

		[Export ("vertexShaderLog")]
		string GetVertexShaderLog ();

		[Export ("fragmentShaderLog")]
		string GetFragmentShaderLog ();

		[Export ("programLog")]
		string GetProgramLog ();
	}

	[BaseType (typeof (NSObject))]
	interface CCSpriteFrameCache {
		[Export ("addSpriteFramesWithFile:")]
		void AddSpriteFrames (string plist);

		[Export ("addSpriteFramesWithFile:textureFilename:")]
		void AddSpriteFrames (string plist, string textureFilename);

		[Export ("addSpriteFramesWithFile:texture:")]
		void AddSpriteFrames (string plist, CCTexture2D texture);

		[Export ("addSpriteFrame:name:")]
		void AddSpriteFrame (CCSpriteFrame frame, string frameName);

		[Export ("removeSpriteFrames")]
		void RemoveSpriteFrames ();

		[Export ("removeUnusedSpriteFrames")]
		void RemoveUnusedSpriteFrames ();

		[Export ("removeSpriteFrameByName:")]
		void RemoveSpriteFrameByName (string name);

		[Export ("removeSpriteFramesFromFile:")]
		void RemoveSpriteFramesFromFile (string plist);

		[Export ("removeSpriteFramesFromTexture:")]
		void RemoveSpriteFramesFromTexture (CCTexture2D texture);

		[Export ("spriteFrameByName:")]
		CCSpriteFrame SpriteFrameByName (string name);
	}

	[BaseType (typeof (NSObject))]
	interface CCTextureCache {
		[Static]
		[Export ("sharedTextureCache")]
		CCTextureCache SharedTextureCache { get; }

		[Static]
		[Export ("purgeSharedTextureCache")]
		void PurgeSharedTextureCache ();

		[Export ("addImage:")]
		CCTexture2D AddImage (string fileImage);

		[Export ("addImageAsync:target:selector:")]
		void AddImageAsync (string filename, NSObject target, Selector selector);

		[Export ("addImageAsync:withBlock:")]
		void AddImageAsync (string filename, Action<CCTexture2D> callback);

		[Export ("addCGImage:forKey:")]
		CCTexture2D AddCGImage (CGImage image, string key);

		[Export ("textureForKey:")]
		CCTexture2D GetTexture (string textureKeyName);

		[Export ("removeAllTextures")]
		void RemoveAllTextures ();

		[Export ("removeUnusedTextures")]
		void RemoveUnusedTextures ();

		[Export ("removeTexture:")]
		void RemoveTexture (CCTexture2D tex);

		[Export ("removeTextureForKey:")]
		void RemoveTexture (string textureKeyName);

		[Export ("addPVRImage:")]
		CCTexture2D AddPVRImage (string filename);
	}

	[BaseType (typeof (NSObject))]
	interface CCTexturePVR {
		[Export ("name")]
		uint Name { get;  }

		[Export ("width")]
		int Width { get;  }

		[Export ("height")]
		int Height { get;  }

		[Export ("hasAlpha")]
		bool HasAlpha { get;  }

		[Export ("numberOfMipmaps")]
		int NumberOfMipmaps { get;  }

		[Export ("retainName")]
		bool RetainName { get; set;  }

		[Export ("format")]
		CCTexture2DPixelFormat Format { get;  }

		[Export ("initWithContentsOfFile:")]
		IntPtr Constructor (string path);

		[Export ("initWithContentsOfURL:")]
		IntPtr Constructor (NSUrl url);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionPageTurn {
		[Export ("initWithDuration:scene:backwards:")]
		IntPtr Constructor (float duration, CCScene scene, bool backwards);

		[Export ("actionWithSize:")]
		CCActionInterval ActionWithSize (Size vector);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionProgress {
	}

	[BaseType (typeof (CCTransitionProgress))]
	interface CCTransitionProgressRadialCCW {
	}

	[BaseType (typeof (CCTransitionProgress))]
	interface CCTransitionProgressHorizontal {
	}

	[BaseType (typeof (CCTransitionProgress))]
	interface CCTransitionProgressInOut {
	}

	[BaseType (typeof (CCSpriteBatchNode))]
	interface CCTMXLayer {
		[Export ("layerName")]
		string LayerName { get; set;  }

		[Export ("layerSize")]
		SizeF LayerSize { get; set;  }

		[Export ("mapTileSize")]
		SizeF MapTileSize { get; set;  }

		[Export ("tiles")]
		IntPtr TilesPtr { get; set;  }

		[Export ("tileset")]
		CCTMXTilesetInfo Tileset { get; set;  }

		[Export ("layerOrientation")]
		uint LayerOrientation { get; set;  }

		[Export ("properties")]
		NSMutableArray Properties { get; set;  }

		[Export ("initWithTilesetInfo:layerInfo:mapInfo:")]
		IntPtr Constructor (CCTMXTilesetInfo tilesetInfo, CCTMXLayerInfo layerInfo, CCTMXMapInfo mapInfo);

		[Export ("releaseMap")]
		void ReleaseMap ();

		[Export ("tileAt:")]
		CCSprite GetTileAt (PointF tileCoordinate);

		[Export ("tileGIDAt:")]
		uint GetTileGid (PointF tileCoordinate);

		[Export ("tileGIDAt:withFlags:")]
		uint GetTileGid (PointF position, ref CCTMXTileFlags flags);

		[Export ("setTileGID:at:")]
		void SetTileGid (uint gid, PointF tileCoordinate);

		[Export ("setTileGID:at:withFlags:")]
		void SetTileGid (uint gid, PointF at, CCTMXTileFlags flags);

		[Export ("removeTileAt:")]
		void RemoveTile (PointF tileCoordinate);

		[Export ("positionAt:")]
		PointF GetPositionAt (PointF tileCoordinate);

		[Export ("propertyNamed:")]
		NSObject GetProperty (string propertyName);

		[Export ("setupTiles")]
		void SetupTiles ();

		[Export ("addChild:z:tag:")]
		void AddChild (CCNode node, int z, int tag);

	}

	[BaseType (typeof (NSObject))]
	interface CCTMXObjectGroup {
		[Export ("groupName")]
		string GroupName { get; set;  }

		[Export ("positionOffset")]
		PointF PositionOffset { get; set;  }

		[Export ("objects")]
		NSMutableArray Objects { get; set;  }

		[Export ("properties")]
		NSMutableDictionary Properties { get; set;  }

		[Export ("propertyNamed:")]
		NSObject GetProperty (string propertyName);

		[Export ("objectNamed:")]
		NSMutableDictionary GetObject (string objectName);

	}

	[BaseType (typeof (CCNode))]
	interface CCTMXTiledMap {
		[Export ("mapSize")]
		SizeF MapSize { get;  }

		[Export ("tileSize")]
		SizeF TileSize { get;  }

		[Export ("mapOrientation")]
		int MapOrientation { get;  }

		[Export ("objectGroups")]
		NSMutableArray ObjectGroups { get; set;  }

		[Export ("properties")]
		NSMutableDictionary Properties { get; set;  }

		[Export ("initWithTMXFile:")]
		IntPtr Constructor (string tmxFile);

		[Export ("initWithXML:resourcePath:")]
		IntPtr Constructor (string tmxString, string resourcePath);

		[Export ("layerNamed:")]
		CCTMXLayer GetLayer (string layerName);

		[Export ("objectGroupNamed:")]
		CCTMXObjectGroup GetObjectGroup (string groupName);

		[Export ("propertyNamed:")]
		NSObject GetProperty (string propertyName);

		[Export ("propertiesForGID:")]
		NSDictionary GetProperties (uint gid);
	}

	[BaseType (typeof (NSObject))]
	interface CCTMXLayerInfo {
		[Export ("name")]
		string Name { get; set;  }

		[Export ("layerSize")]
		SizeF LayerSize { get; set;  }

		[Export ("tiles")]
		IntPtr TilesPtr { get; set;  }

		[Export ("visible")]
		bool Visible { get; set;  }

		[Export ("opacity")]
		byte Opacity { get; set;  }

		[Export ("ownTiles")]
		bool OwnTiles { get; set;  }

		[Export ("minGID")]
		uint MinGid { get; set;  }

		[Export ("maxGID")]
		uint MaxGid { get; set;  }

		[Export ("properties")]
		NSMutableDictionary Properties { get; set;  }

		[Export ("offset")]
		PointF Offset { get; set;  }

	}

	[BaseType (typeof (NSObject))]
	interface CCTMXTilesetInfo {
		[Export ("name")]
		string Name { get; set; }
		
		[Export ("firstGid")]
		uint FirstGid { get; set;  }

		[Export ("tileSize")]
		SizeF TileSize { get; set;  }

		[Export ("spacing")]
		uint Spacing { get; set;  }

		[Export ("margin")]
		uint Margin { get; set;  }

		[Export ("sourceImage")]
		string SourceImage { get; set;  }

		[Export ("imageSize")]
		SizeF ImageSize { get; set;  }

		[Export ("rectForGID:")]
		RectangleF GetRectForGid (uint gid);

	}

	[BaseType (typeof (NSObject))]
	interface CCTMXMapInfo {
		[Export ("orientation")]
		int Orientation { get; set;  }

		[Export ("mapSize")]
		SizeF MapSize { get; set;  }

		[Export ("tileSize")]
		SizeF TileSize { get; set;  }

		[Export ("layers")]
		NSMutableArray Layers { get; set;  }

		[Export ("tilesets")]
		NSMutableArray Tilesets { get; set;  }

		[Export ("filename")]
		string Filename { get; set;  }

		[Export ("resources")]
		string Resources { get; set;  }

		[Export ("objectGroups")]
		NSMutableArray ObjectGroups { get; set;  }

		[Export ("properties")]
		NSMutableDictionary Properties { get; set;  }

		[Export ("tileProperties")]
		NSMutableDictionary TileProperties { get; set;  }

		[Export ("initWithTMXFile:")]
		IntPtr Constructor (string tmxFile);

		[Export ("initWithXML:resourcePath:")]
		IntPtr Constructor (string tmxString, string resourcePath);
	}

}
