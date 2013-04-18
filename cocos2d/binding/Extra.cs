//
// Extra.cs: API extensions for Cocos2D binding to Mono.
//
// Author:
//   Stephane Delcroix
//
// Copyright 2012, 2013 S. Delcroix
//

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
#if MONOMAC
using UITextAlignment = MonoMac.AppKit.NSTextAlignment;
using UILineBreakMode = MonoMac.AppKit.NSLineBreakMode;
#endif


namespace MonoTouch.Cocos2D {
	// Use this for synchronous operations
	[Register ("__My_NSActionDispatcher")]
	internal class NSActionDispatcher : NSObject {

		public static Selector Selector = new Selector ("apply");

		NSAction action;

		public NSActionDispatcher (NSAction action)
		{
			this.action = action;
		}

		[Export ("apply")]
		[Preserve (Conditional = true)]
		public void Apply ()
		{
			action ();
		}
	}
	
	[Register ("__My_NSActionDispatcherWithNode")]
	internal class NSActionDispatcherWithNode : NSObject {

		public static Selector Selector = new Selector ("apply:");

		Action<CCNode> action;

		public NSActionDispatcherWithNode (Action<CCNode> action)
		{
			this.action = action;
		}

		[Export ("apply:")]
		[Preserve (Conditional = true)]
		public void Apply (CCNode node)
		{
			action (node);
		}
	}

	[Register ("__My_NSActionDispatcherWithFloat")]
	internal class NSActionDispatcherWithFloat : NSObject {

		public static Selector Selector = new Selector ("apply:");

		Action<float> action;

		public NSActionDispatcherWithFloat (Action<float> action)
		{
			this.action = action;
		}

		[Export ("apply:")]
		[Preserve (Conditional = true)]
		public void Apply (float timer)
		{
			action (timer);
		}
	}
	
	public partial class CCNode {
		public const uint RepeatForever = uint.MaxValue - 1;

		public void Schedule (Action<float> callback, float interval=0, uint repeat=RepeatForever, float delay=0)
		{
			CCDirector.SharedDirector.Scheduler.ScheduleSelector(NSActionDispatcherWithFloat.Selector, new NSActionDispatcherWithFloat(callback), interval, !IsRunning, repeat, delay);
		}

		public void ScheduleOnce (Action<float> callback, float delay)
		{
			Schedule (callback, repeat:0, delay:delay);
		}
	}

	public partial class CCScheduler {
		public const uint RepeatForever = uint.MaxValue - 1;
		public NSObject Schedule (Action<float> callback, float interval=0, bool paused=false, uint repeat=RepeatForever, float delay=0)
		{
			var token = new NSActionDispatcherWithFloat (callback);
			ScheduleSelector (NSActionDispatcherWithFloat.Selector, token, interval, paused, repeat, delay);
			return token;
		}
		
	}

	public partial class CCMenuItemLabel {
		public CCMenuItemLabel (NSCallbackWithSender callback) : base (callback)
		{
		}

	}
	public partial class CCMenuItemImage {
		public CCMenuItemImage (string normalImageFile, string selectedImageFile, NSCallbackWithSender callback) : this (normalImageFile, selectedImageFile, null, callback)
		{
		} 
	}

	public partial class CCMenu {
		void AlignItemsInColumns (params NSNumber[] columns)
		{
			if (columns == null)
				throw new ArgumentNullException ("columns");

			var pNativeArr = Marshal.AllocHGlobal(columns.Length * IntPtr.Size);
			for (var i =1; i<columns.Length;++i)
				Marshal.WriteIntPtr (pNativeArr, (i-1)*IntPtr.Size, columns[i].Handle);

			//Null termination
			Marshal.WriteIntPtr (pNativeArr, (columns.Length-1)*IntPtr.Size, IntPtr.Zero);

			AlignItemsInColumns (columns[0], pNativeArr);
			Marshal.FreeHGlobal(pNativeArr);
		}
		
		void AlignItemsInRows (params NSNumber[] rows)
		{
			if (rows == null)
				throw new ArgumentNullException ("rows");

			var pNativeArr = Marshal.AllocHGlobal(rows.Length * IntPtr.Size);
			for (var i =1; i<rows.Length;++i)
				Marshal.WriteIntPtr (pNativeArr, (i-1)*IntPtr.Size, rows[i].Handle);

			//Null termination
			Marshal.WriteIntPtr (pNativeArr, (rows.Length-1)*IntPtr.Size, IntPtr.Zero);

			AlignItemsInColumns (rows[0], pNativeArr);
			Marshal.FreeHGlobal(pNativeArr);
		}
		
	}

	public partial class CCCallFunc {
		public CCCallFunc (NSAction callback) : this (new NSActionDispatcher(callback), NSActionDispatcher.Selector)
		{
		}
	}

	public partial class CCCallFuncN {
		public CCCallFuncN (Action<CCNode> callback) : this (new NSActionDispatcherWithNode(callback), NSActionDispatcherWithNode.Selector)
		{
		}
	}

	public partial class CCSpriteBatchNode {
		const int DEFAULTCAPACITY = 29; 
		public CCSpriteBatchNode (CCTexture2D texture) : this (texture, DEFAULTCAPACITY)
		{
		}

		public CCSpriteBatchNode (string filename) : this (filename, DEFAULTCAPACITY)
		{
		}
	}

	public partial class CCPointArray {
		public PointF this [int index] {
			get {
				return GetControlPoint (index);
			}
			set {
				Replace (value, index);
			}
		}
	}

	public partial class CCCardianSpline {
		[DllImport ("__Internal", EntryPoint="ccCardinalSplineAt")]
		public extern static PointF GetPosition (PointF p0, PointF p1, PointF p2, PointF p3, float tension, float time);
	}

	public partial class CCLabelBMFont {
		public float Width {
			set {
				SetWidth (value);
			}
		}
	}

	public partial class CCTimer {
		public CCTimer (NSAction target) : this (new NSActionDispatcher (target), NSActionDispatcher.Selector)
		{
		}
	}


#if ENABLE_CHIPMUNK_INTEGRATION
	public partial class CCPhysicsSprite {
		public Chipmunk.Body Body {
			get { return Chipmunk.Body.FromIntPtr (BodyPtr); }
			set { BodyPtr = value.Handle.Handle; }
		} 

		public PointF Position {
			get {
				if (BodyPtr == IntPtr.Zero)
					throw new InvalidOperationException ("You can't get the Position if the Body isn't set");
				return PositionInt;
			}
			set {
				if (BodyPtr == IntPtr.Zero)
					throw new InvalidOperationException ("You can't set the Position if the Body isn't set");
				PositionInt = value;
			}
		}
	}

	public partial class CCPhysicsDebugNode {
		public static CCPhysicsDebugNode DebugNode (Chipmunk.Space space) 
		{
			return DebugNode (space.Handle.Handle);
		}
	}
#endif
}	
