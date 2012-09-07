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
			Console.WriteLine ("hey, dispatcher calling");
			action ();
		}
	}
	
	public partial class CCNode {
		static CCScheduler scheduler = CCDirector.SharedDirector.Scheduler;
		public const uint RepeatForever = uint.MaxValue - 1;

		public void Schedule (NSAction callback, float interval=0, uint repeat=RepeatForever, float delay=0)
		{
			scheduler.Schedule(NSActionDispatcher.Selector, new NSActionDispatcher(callback), interval, !IsRunning, repeat, delay);
		}

		public void ScheduleOnce (NSAction callback, float delay)
		{
			Schedule (callback, repeat:0, delay:delay);
		}
	}

	public partial class CCMenuItemLabel {
		public CCMenuItemLabel (NSCallbackWithSender callback) : base (callback)
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
}	
