using System;
using MonoTouch.Foundation;
using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.ObjCRuntime;

namespace WEPopover
{
	[BaseType(typeof(UIView))]
	public interface WEPopoverContainerView
	{
		[Export("initWithSize:")]
		IntPtr Constructor(SizeF size, RectangleF achorRect, RectangleF displayArea, UIPopoverArrowDirection direction);
		
		[Export("arrowDirection")]
		UIPopoverArrowDirection ArrowDirection { get; set; }
		
		[Export("contentView")]
		UIView ContentView { get; set; }
		
		[Export("updatePositionWithAnchorRect:")]
		void UpdatePosition(RectangleF anchorRect, Rectangle area, UIPopoverArrowDirection direction);	
	}
	
	[BaseType(typeof(NSObject))]
	public interface WEPopoverContainerViewProperties
	{
		[Export("bgImageName")]
		string BackgroundImageName { get; set; }
		
		[Export("upArrowImageName")]
		string UpArrowImageName { get; set; }
		
		[Export("downArrowImageName")]
		string DownArrowImageName { get; set; }
		
		[Export("leftArrowImageName")]
		string LeftArrowImageName { get; set; }
		
		[Export("rightArrowImageName")]
		string RightArrowImageName { get; set; }
		
		[Export("leftBgMargin", ArgumentSemantic.Assign)]
		float LeftBackgroundMargin { get; set; }
		
		[Export("rightBgMargin", ArgumentSemantic.Assign)]
		float RightBackgroundMargin { get; set; }
		
		[Export("topBgMargin", ArgumentSemantic.Assign)]
		float TopBackgroundMargin { get; set; }
		
		[Export("bottomBgMargin", ArgumentSemantic.Assign)]
		float BottomBackgroundMargin { get; set; }
		
		[Export("leftContentMargin", ArgumentSemantic.Assign)]
		float LeftContentMargin { get; set; }
		
		[Export("rightContentMargin", ArgumentSemantic.Assign)]
		float RightContentMargin { get; set; }
		
		[Export("topContentMargin", ArgumentSemantic.Assign)]
		float TopContentMargin { get; set; }
		
		[Export("bottomContentMargin", ArgumentSemantic.Assign)]
		float BottomContentMargin { get; set; }
		
		[Export("topBgCapSize", ArgumentSemantic.Assign)]
		int TopBackgroundCapSize { get; set; }
		
		[Export("leftBgCapSize", ArgumentSemantic.Assign)]
		int LeftBackgroundCapSize { get; set; }
		
		[Export("arrowMargin", ArgumentSemantic.Assign)]
		float ArrowMargin { get; set; }
	}
}

