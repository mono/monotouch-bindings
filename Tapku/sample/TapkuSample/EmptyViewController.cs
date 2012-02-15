using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Tapku;

namespace TapkuSample
{
	public partial class EmptyViewController : UIViewController
	{
		
		TKEmptyView emptyView;
		
		public override void LoadView ()
		{
			base.LoadView ();
			
			emptyView = new TKEmptyView(View.Bounds, TKEmptyViewImage.Male, "Empty Pages", "All you need is a transparent image");
			
			emptyView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
			View.AddSubview(emptyView);
		}
	}
}
