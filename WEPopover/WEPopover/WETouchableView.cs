using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

namespace WEPopover
{
	[BaseType(typeof(UIView))]
	public interface WETouchableView
	{
		[Export("touchForwardingDisabled", ArgumentSemantic.Assign)]
		bool TouchForwardingDisabled { get; set; }
		
		
		[NullAllowed]
		[Export("delegate", ArgumentSemantic.Assign)]
		WETouchableViewDelegate Delegate { get; set; }
		
		[Export("passthroughViews", ArgumentSemantic.Copy)]
		NSArray PassThroughViews { get; set; }
	}
	
	[Model]
	[BaseType(typeof(NSObject))]
	public interface WETouchableViewDelegate
	{
		[Export("viewWasTouched:")]
		void ViewWasTouched(WETouchableView view);
		
		
	}
}

