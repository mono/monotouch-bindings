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

	delegate void NSCallbackWithSender (NSObject sender);

	[BaseType (typeof (NSObject))]
	interface CCAction {
		[Export ("originalTarget")]
		NSObject OriginalTarget { get;  }

		[Export ("tag")]
		int Tag { get; set;  }

		[Export ("target")]
		NSObject Target { get; }

		//[Export ("copyWithZone:")]
		//CCAction CopyFromZone (NSZone zone );

		[Export ("isDone")]
		bool IsDone { get; }

		[Export ("startWithTarget:")]
		void Start (NSObject target);

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
	interface CCNode {

		//Note to self, don't bind schedule*, we can do a better job than this

		[Export ("zOrder")]
		int ZOrder { get; set; }

		[Export ("vertexZ")]
		float VertexZ { get; set; }	

		[Export ("skewX")]
		float SkewX { get; set; }

		[Export ("rotation")]
		float Rotation { get; set; }

		[Export ("scale")]
		float Scale { get; set; }

		[Export ("scaleX")]
		float ScaleX { get; set; }

		[Export ("scaleY")]
		float ScaleY { get; set; }

		[Export ("position")]
		PointF Position { get; set; }

		[Export ("camera")]
		CCCamera Camera { get; }

		[Export ("addChild:")]
		void Add (CCNode child);
		
		[Export ("addChild:z:")]
		void Add (CCNode child, int zIndex);
		
		[Export ("addChild:z:tag:")]
		void Add (CCNode child, int zIndex, int tag);
		
		[Export ("removeChild:cleanup:")]
		void Remove (CCNode child, bool cleanup);

		[Export ("removeChildByTag:cleanup:")]
		void Remove (int tag, bool cleanup);

		[Export ("isRunning")]
		bool IsRunning { get; }

		[Export ("contentSize")]
		SizeF ContentSize { get; set; }

		[Export ("tag")]
		int Tag { get; set; }

		[Export ("runAction:")]
		void RunAction (CCAction action);

		[Export ("stopAction:")]
		void StopAction (CCAction action);

		[Export ("stopAllActions")]
		void StopAllActions ();

		[Export ("stopActionByTag:")]
		void StopAction (int tag);

		[Export ("getActionByTag:")]
		void GetActionByTag(int tag);

		[Export ("numberOfRunningActions")]
		int NumberOfRunningActions ();

		[Export ("onEnter")]
		void OnEnter ();

		[Export ("getChildByTag:")]
		CCNode GetChild (int tag);

		[Export ("visible")]
		bool Visible { get; set; }
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
		[Export ("actionsWithArray:")]
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
		[Export ("PVRImagesHavePremultipliedAlpha")]
		bool PVRImageHavePremultipliedAlpha { [Bind ("PVRImagesHavePremultipliedAlpha:")]set; }
	}

	[BaseType (typeof (UIView))]
	interface CCGLView {
		[Static]
		[Export ("viewWithFrame:")]
		CCGLView View (RectangleF frame);
	}

	public delegate bool AutorotateCondition (UIInterfaceOrientation orientation);

	[BaseType (typeof (NSObject))]
	[Model]
	interface CCDirectorDelegate {
		//[Export ("updateProjection")]
		//void UpdateProjection ();

		[Export("shouldAutorotateToInterfaceOrientation:"), DefaultValue ("true"), DelegateName ("AutorotateCondition")]
		bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation orientation);
	}

	[BaseType (typeof(UIViewController), Delegates=new string[]{"Delegate"}, Events=new Type[]{typeof(CCDirectorDelegate)})]
	interface CCDirector {
		[Export ("sharedDirector")]
		[Static]
		CCDirector SharedDirector { get; }

		[Export ("displayStats")]
		bool DisplayStats { get; set; }

		[Export ("animationInterval")]
		double AnimationInterval { get; set; }

		[Export ("projection")]
		CCDirectorProjection Projection { set; }

		[Export ("replaceScene:")]
		void ReplaceScene (CCScene scene);

		[Export ("pushScene:")]
		void Push (CCScene scene);

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
	} 

	[BaseType (typeof (CCNode))]
	interface CCScene {
		
	}

	[BaseType (typeof (NSObject))]
	interface CCTouchDispatcher {
		[Export("addStandardDelegate:priority:")]
		void AddStandardDelegate(NSObject delegate_, int priority);

		[Export("addTargetedDelegate:priority:")]
		void AddTargetedDelegate(NSObject delegate_, int priority);
	}	

	[BaseType (typeof (CCDirector))]
	interface CCDirectorIOS {
	
		[Export ("touchDispatcher")]
		CCTouchDispatcher TouchDispatcher { get; set; }

		[Export ("projection")]
		CCDirectorProjection Projection { set; }

		[Export ("enableRetinaDisplay:")]
		bool EnableRetinaDisplay (bool enableRetina);

		[Export ("startAnimation")]
		void StartAnimation ();

		[Export ("stopAnimation")]
		void StopAnimation ();

		[Export ("animationInterval")]
		double AnimationInterval { set; }

		[Export ("calculateDeltaTime")]
		void CalculateDeltaTime ();

		[Export("convertToGL:")]
		PointF ConvertToGL (PointF point);

		[Export("convertToUI:")]
		PointF ConvertToUI (PointF point);
	}

	[BaseType (typeof (CCDirectorIOS))]
	interface CCDirectorDisplayLink {

	}

	interface CCTargetedTouchDelegate {
		[Export ("ccTouchBegan:withEvent:")]
		[PrologueSnippet ("return false;")]
		bool OnTouchBegan(UITouch touch, UIEvent ev);

		[Export ("ccTouchMoved:withEvent:")]
		[PrologueSnippet ("return;")]
		void OnTouchMoved(UITouch touch, UIEvent ev);

		[Export ("ccTouchEnded:withEvent:")]
		[PrologueSnippet ("return;")]
		void OnTouchEnded(UITouch touch, UIEvent ev);

		[Export ("ccTouchCancelled:withEvent:")]
		[PrologueSnippet ("return;")]
		void OnTouchCancelled(UITouch touch, UIEvent ev);
	}

	interface CCStandardTouchDelegate {
		[Export ("ccTouchesBegan:withEvent:")]
		[PrologueSnippet ("return;")]
		void OnTouchesBegan(NSSet touches, UIEvent ev);

		[Export ("ccTouchesMoved:withEvent:")]
		[PrologueSnippet ("return;")]
		void OnTouchesMoved(NSSet touches, UIEvent ev);

		[Export ("ccTouchesEnded:withEvent:")]
		[PrologueSnippet ("return;")]
		void OnTouchesEnded(NSSet touches, UIEvent ev);

		[Export ("ccTouchesCancelled:withEvent:")]
		[PrologueSnippet ("return;")]
		void OnTouchesCancelled(NSSet touches, UIEvent ev);	
	}

	[BaseType (typeof (CCNode))]
	interface CCLayer : CCStandardTouchDelegate, CCTargetedTouchDelegate {
		[Export ("registerWithTouchDispatcher")]
		void RegisterWithTouchDispatcher ();

		[Export ("isTouchEnabled")]
		bool IsTouchEnabled { get; set; }

		[Export ("isAccelerometerEnabled")]
		bool IsAccelerometerEnabled { get; set; }


	}

	[BaseType (typeof (CCLayer))]
	interface CCLayerColor {
		[Export ("initWithColor:width:height:")]
		CCLayerColor Constructor (Color4B color, float width, float height);

		[Export ("initWithColor:")]
		CCLayerColor Constructor (Color4B color);

		[Export ("changeWidth:")]
		void ChangeWidth (float width);

		[Export ("changeHeight:")]
		void ChangeHeight (float height);

		[Export ("changeWidth:height:")]
		void ChangeSize (float width, float height);

		[Export ("opacity")]
		byte Opacity { get; }

		[Export ("color")]
		Color3B Color { get; }
	}

	interface CCLabelProtocol {
		[Export ("string")]
		string Label { get; set; }
	}

	interface CCRGBAProtocol {
		[Export ("color")]
		Color3B Color { get; set; }

		[Export ("opacity")]
		byte Opacity { get; set; }

		[Export ("doesOpacityModifyRGB")]
		bool OpacityModifyRGB { get;[Bind("opacityModifyRGB:")] set;}
	}

	[BaseType (typeof (CCSprite))]
	interface CCLabelTTF : CCLabelProtocol {
		[Export ("initWithString:fontName:fontSize:")]
		CCLabelTTF Constructor (string label, string fontName, float fontSize);

	}
	
	[BaseType (typeof(CCSpriteBatchNode))]
	interface CCLabelBMFont : CCLabelProtocol, CCRGBAProtocol {
		[Export("purgeCachedData")]
		[Static]
		void PurgeCachedData  ();

		[Export("alignment")]
		TextAlignment Alignment { get; set; }

		[Export("fntFile")]
		string FontFile { get; set; }

		[Export("initWithString:fntFile:")]
		CCLabelBMFont Constructor (string label, string fontFile);

		[Export ("initWithString:fntFile:width:alignment:")]
		CCLabelBMFont Constructor (string label, string fontFile, float width, TextAlignment alignment);

		[Export ("initWithString:fntFile:width:alignment:imageOffset:")]
		CCLabelBMFont Constructor (string label, string fontFile, float width, TextAlignment alignment, PointF offset);

		[Export ("createFontChars")]
		void CreateFontChars ();

		[Export ("width")]
		float Width { set; }
	}

	interface CCBlendProtocol {
		[Export ("blendFunc")]
		BlendFunc BlendFunc { get; set; }		
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
		V3F_C4B_T2F_Quad Quads { get; set; }

		[Export("initWithFile:capacity:")]
		CCTextureAtlas Constructor (string fileName, uint capacity);

		[Export("initWithTexture:capacity:")]
		CCTextureAtlas Constructor (CCTexture2D texture, uint capacity);

		[Export ("updateQuad:atIndex:")]
		void UpdateQuad(V3F_C4B_T2F_Quad quad, uint atIndex);

		[Export ("insertQuad:atIndex:")]
		void InsertQuad(V3F_C4B_T2F_Quad quad, uint atIndex);

		//[Export ("insertQuads:atIndex:amount:")]
		//void InsertQuads(V3F_C4B_T2F_Quad quad, uint atIndex, uint amount);

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
		CCSpriteBatchNode Constructor (CCTexture2D texture, uint capacity);

		[Export ("initWithFile:capacity:")]
		CCSpriteBatchNode Constructor (string filename, uint capacity);

		[Export ("increaseAtlasCapacity")]
		void IncreaseAtlasCapacity ();

		[Export ("removeChildrenAtIndex:cleanup:")]
		void RemoveChildAtIndex (uint index, bool cleanup);

		[Export ("removeChild:cleanup:")]
		void RemoveChild(CCSprite sprite, bool cleanup);

		[Export ("insertChild:inAtlasIndex:")]
		void InsertChild(CCSprite child, uint index);
	
		[Export ("appendChild:")]
		void Append(CCSprite sprite);

		[Export ("removeSpriteFromAtlas:")]
		void RemoveSpriteFromAtlas(CCSprite sprite);

		[Export ("rebuildIndexInOrder:atlasIndex:")]
		uint RebuildIndexInOrder (CCSprite parent, uint altalIndex);

		[Export ("atlasIndexForChild:atZ:")]
		uint AtlasIndexForChild(CCSprite sprite, int atZ);
	}

	[BaseType (typeof (CCNode))]
	interface CCSprite {
		[Export ("initWithTexture:rect:rotated:")]
		CCSprite Constructor (CCTexture2D texture, RectangleF rect, bool rotated);

		[Export ("initWithTexture:rect:")]
		CCSprite Constructor (CCTexture2D texture, RectangleF rect);

		[Export ("initWithTexture:rect:")]
		CCSprite Constructor (CCTexture2D texture);

		[Export ("initWithFile:")]
		CCSprite Constructor (string filename);

		[Export ("initWithFile:rect:")]
		CCSprite Constructor (string filename, RectangleF rect);

//		[Export ("initWithCGImage:key:")]
//		CCSprite Constructor (CGImage image, string key);

		[Export ("description")]
//		[Override]
		string ToString ();
	
		[Export("opacity")]
		byte Opacity { get; set; }
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
		[Static]
		[Export ("getZeye")]
		float ZEye { get; }
	}

	[BaseType (typeof (CCScene))]
	interface CCTransitionScene {
		[Export ("initWithDuration:scene:")]
		CCTransitionScene Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionSceneOriented {
		[Export ("initWithDuration:scene:")]
		CCTransitionSceneOriented Constructor (float duration, CCScene scene);

		[Export ("initWithDuration:scene:orientation:")]
		CCTransitionSceneOriented Constructor (float duration, CCScene scene, Orientation orientation);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionRotoZoom {
		[Export ("initWithDuration:scene:")]
		CCTransitionRotoZoom Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionJumpZoom {
		[Export ("initWithDuration:scene:")]
		CCTransitionJumpZoom Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionMoveInL {
		[Export ("initWithDuration:scene:")]
		CCTransitionMoveInL Constructor (float duration, CCScene scene);

		[Export ("initScenes")]
		void InitScenes ();

		[Export ("action")]
		CCActionInterval Action { get; }
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionMoveInR {
		[Export ("initWithDuration:scene:")]
		CCTransitionMoveInR Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionMoveInT {
		[Export ("initWithDuration:scene:")]
		CCTransitionMoveInT Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionMoveInB {
		[Export ("initWithDuration:scene:")]
		CCTransitionMoveInB Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionSlideInL {
		[Export ("initWithDuration:scene:")]
		CCTransitionSlideInL Constructor (float duration, CCScene scene);

		[Export ("initScenes")]
		void InitScenes ();

		[Export ("action")]
		CCActionInterval Action { get; }
	}

	[BaseType (typeof (CCTransitionSlideInL))]
	interface CCTransitionSlideInR {
		[Export ("initWithDuration:scene:")]
		CCTransitionSlideInR Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionSlideInL))]
	interface CCTransitionSlideInB {
		[Export ("initWithDuration:scene:")]
		CCTransitionSlideInB Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionSlideInL))]
	interface CCTransitionSlideInT {
		[Export ("initWithDuration:scene:")]
		CCTransitionSlideInT Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionShrinkGrow {
		[Export ("initWithDuration:scene:")]
		CCTransitionShrinkGrow Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionSceneOriented))]
	interface CCTransitionFlipX {
		[Export ("initWithDuration:scene:")]
		CCTransitionFlipX Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionSceneOriented))]
	interface CCTransitionFlipY {
		[Export ("initWithDuration:scene:")]
		CCTransitionFlipY Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionSceneOriented))]
	interface CCTransitionFlipAnguled {
		[Export ("initWithDuration:scene:")]
		CCTransitionFlipAnguled Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionSceneOriented))]
	interface CCTransitionZoomFlipX {
		[Export ("initWithDuration:scene:")]
		CCTransitionZoomFlipX Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionSceneOriented))]
	interface CCTransitionZoomFlipY {
		[Export ("initWithDuration:scene:")]
		CCTransitionZoomFlipY Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionSceneOriented))]
	interface CCTransitionZoomFlipAngular {
		[Export ("initWithDuration:scene:")]
		CCTransitionZoomFlipAngular Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionFade {
		[Export ("initWithDuration:scene:")]
		CCTransitionFade Constructor (float duration, CCScene scene);

		[Export ("initWithDuration:scene:withColor:")]
		CCTransitionFade Constructor (float duration, CCScene scene, Color3B color);
	}
	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionCrossFade {
		[Export ("initWithDuration:scene:")]
		CCTransitionCrossFade Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionTurnOffTiles {
		[Export ("initWithDuration:scene:")]
		CCTransitionTurnOffTiles Constructor (float duration, CCScene scene);
	}

	[BaseType (typeof (CCTransitionScene))]
	interface CCTransitionSplitCols {
		[Export ("initWithDuration:scene:")]
		CCTransitionSplitCols Constructor (float duration, CCScene scene);

		[Export ("action")]
		CCActionInterval Action { get; }
	}

	[BaseType (typeof (CCTransitionSplitCols))]
	interface CCTransitionSplitRows {
		[Export ("initWithDuration:scene:")]
		CCTransitionSplitRows Constructor (float duration, CCScene scene);
	}
	
	[BaseType (typeof (CCNode))]
	interface CCMenuItem {
		[Export ("initWithBlock:")]
		CCMenuItem Constructor (NSCallbackWithSender callback);
		
		[Export ("setBlock:")]
		void SetCallback (NSCallbackWithSender callback);		

		[Export ("rect")]
		RectangleF Rect { get; }

		[Export ("isEnabled")]
		bool IsEnabled { get; }
	}

	[BaseType (typeof (CCMenuItem))]
	interface CCMenuItemLabel {
		[Export ("initWithLabel:block:")]
		CCMenuItemLabel Constructor (CCNode label, NSCallbackWithSender callback);

		[Export ("string")]
		string Label { set; }

		[Export ("isEnabled")]
		bool IsEnabled { set; }
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

		[Export ("initWithString:block:")]
		CCMenuItemFont Constructor (string value, NSCallbackWithSender callback);
	}

	[BaseType (typeof(CCMenuItem))]
	interface CCMenuItemSprite : CCRGBAProtocol
	{
		//TODO
	}

	[BaseType (typeof(CCMenuItemSprite))]
	interface CCMenuItemImage {
		[Export("initWithNormalImage:selectedImage:disabledImage:block:")]
		CCMenuItemImage Constructor (string normalImageFile, string selectedImageFile, [NullAllowed]string disabledImageFile, NSCallbackWithSender callback);

		[Export("normalSpriteFrame")]
		CCSpriteFrame NormalSpriteFrame { set; }

		[Export("selectedSpriteFrame")]
		CCSpriteFrame SelectedSpriteFrame { set; }

		[Export("disabledSpriteFrame")]
		CCSpriteFrame DisabledSpriteFrame { set; }
	}

	[BaseType (typeof (CCLayer))]
	interface CCMenu {
		[Export ("opacity")]
		byte Opacity { get; }

		[Export ("color")]
		Color3B Color { get; }

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
		[Internal]
		void Schedule (Selector selector, NSObject target, float interval, bool paused, uint repeat, float delay);

		[Export ("scheduleSelector:forTarget:interval:paused:")]
		[Internal]
		void Schedule (Selector selector, NSObject target, float interval, bool paused);

		[Export ("scheduleUpdateForTarget:priority:paused:")]
		[Internal]
		void ScheduleUpdate (NSObject target, int priority, bool paused);

		[Export ("unscheduleSelector:forTarget:")]
		[Internal]
		void Unschedule (Selector sel, NSObject target);

		[Export ("unscheduleUpdateForTarget:")]
		[Internal]
		void UnscheduleUpdate (NSObject target);

		[Export ("unscheduleAllSelectorsForTarget:")]
		[Internal]
		void UnscheduleAllSelectors (NSObject target);

		[Export ("unscheduleAllSelectors")]
		[Internal]
		void UnscheduleAllSelectors ();
	}
}
