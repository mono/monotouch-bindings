using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;

namespace SegmentedControl
{
	public partial class SDSegmentedControl : MonoTouch.UIKit.UISegmentedControl
	{
		public SDSegmentedControl (object [] args) : base (args)
		{
		}

		public SDSegmentedControl (RectangleF frame) : base (frame)
		{
		}
	}
}

