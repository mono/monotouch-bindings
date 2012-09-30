//
// Extra.cs: API extensions for Cocos2D binding to Mono.
//
// Author:
//   Stephane Delcroix
//
// Copyright 2012 S. Delcroix
//

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

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

		public static Selector Selector = new Selector ("apply");

		Action<CCNode> action;

		public NSActionDispatcherWithNode (Action<CCNode> action)
		{
			this.action = action;
		}

		[Export ("apply")]
		[Preserve (Conditional = true)]
		public void Apply (CCNode node)
		{
			action (node);
		}
	}

	[Register ("__My_NSActionDispatcherWithFloat")]
	internal class NSActionDispatcherWithFloat : NSObject {

		public static Selector Selector = new Selector ("apply");

		Action<float> action;

		public NSActionDispatcherWithFloat (Action<float> action)
		{
			this.action = action;
		}

		[Export ("apply")]
		[Preserve (Conditional = true)]
		public void Apply (float timer)
		{
			action (timer);
		}
	}
	
	public partial class CCNode {
		static CCScheduler scheduler = CCDirector.SharedDirector.Scheduler;
		public const uint RepeatForever = uint.MaxValue - 1;

		public void Schedule (Action<float> callback, float interval=0, uint repeat=RepeatForever, float delay=0)
		{
			scheduler.Schedule(NSActionDispatcherWithFloat.Selector, new NSActionDispatcherWithFloat(callback), interval, !IsRunning, repeat, delay);
		}

		public void ScheduleOnce (Action<float> callback, float delay)
		{
			Schedule (callback, repeat:0, delay:delay);
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
			for (var i =0; i<columns.Length;++i)
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
			for (var i =0; i<rows.Length;++i)
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
		const uint DEFAULTCAPACITY = 29; 
		public CCSpriteBatchNode (CCTexture2D texture) : this (texture, DEFAULTCAPACITY)
		{
		}

		public CCSpriteBatchNode (string filename) : this (filename, DEFAULTCAPACITY)
		{
		}
	}
}	
