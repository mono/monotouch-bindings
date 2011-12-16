//
// Auto-generated from generator.cs, do not edit
//
// We keep references to objects, so warning 414 is expected

#pragma warning disable 414

using System;

using System.Drawing;

using System.Runtime.InteropServices;

using MonoTouch;

using MonoTouch.CoreFoundation;

using MonoTouch.CoreMedia;

using MonoTouch.CoreMotion;

using MonoTouch.Foundation;

using MonoTouch.ObjCRuntime;

using MonoTouch.CoreAnimation;

using MonoTouch.CoreLocation;

using MonoTouch.MapKit;

using MonoTouch.UIKit;

using MonoTouch.CoreGraphics;

using MonoTouch.NewsstandKit;

using MonoTouch.GLKit;

using OpenTK;

namespace GoogleAnalytics {
	[Register("GANTrackerDelegate", true)]
	public partial class GANTrackerDelegate : NSObject {
		static IntPtr selTrackerDispatchDidCompleteEventsDispatchedEventsFailedDispatch = Selector.GetHandle ("trackerDispatchDidComplete:eventsDispatched:eventsFailedDispatch:");
		
		static IntPtr class_ptr = Class.GetHandle ("GANTrackerDelegate");
		
		[Export ("init")]
		public  GANTrackerDelegate () : base (NSObjectFlag.Empty)
		{
			Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.Init);
			
		}

		public GANTrackerDelegate (NSObjectFlag t) : base (t) {}

		public GANTrackerDelegate (IntPtr handle) : base (handle) {}

		[Export ("trackerDispatchDidComplete:eventsDispatched:eventsFailedDispatch:")]
		public virtual void DispatchCompleted (GANTracker tracker, int eventsDispatched, int eventsFailedDispatch)
		{
			if (tracker == null)
				throw new ArgumentNullException ("tracker");
			MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_IntPtr_int_int (this.Handle, selTrackerDispatchDidCompleteEventsDispatchedEventsFailedDispatch, tracker.Handle, eventsDispatched, eventsFailedDispatch);
		}
		
	} /* class GANTrackerDelegate */
}
