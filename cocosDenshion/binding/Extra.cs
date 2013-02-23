//
// Extra.cs: extras for CocosDenshion binding to Mono
//
// Author:
//   Stephane Delcroix <stephane@delcroix.org>
//
// Copyright © 2013 Stephane Delcroix. All Rights Reserved.

using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

namespace MonoTouch.CocosDenshion {
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

    public partial class CDAudioManager {
	public void SetBackgroundMusicCompletionListener (NSAction callback)
	{
	    SetBackgroundMusicCompletionListener (new NSActionDispatcher (callback), NSActionDispatcher.Selector);
	}
    }
}
