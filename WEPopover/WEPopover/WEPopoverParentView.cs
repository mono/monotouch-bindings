using System;
using System.Drawing;
using MonoTouch.Foundation;

namespace WEPopover
{
	[Model]
	[BaseType(typeof(NSObject))]
	public interface WEPopoverParentView
	{
		[Export("displayAreaForPopover")]
		RectangleF DisplayArea();
		
	}
}

