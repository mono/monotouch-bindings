using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;

public class MissingApiView : UIView
{
	UITextView tv;
	UIButton btn;

	public MissingApiView (RectangleF rect, string text, string url = "") : base(rect)
	{
		tv = new UITextView (){
			TextAlignment = UITextAlignment.Center,
			Text = text,
			BackgroundColor = UIColor.Black,
			TextColor = UIColor.White,
			Font = UIFont.SystemFontOfSize(18),
		};
		this.AddSubview (tv);
		btn = new UIButton ();
		btn.TouchUpInside += delegate {
			if (string.IsNullOrEmpty (url))
				return;
			var nsurl = new NSUrl (url);
			if (UIApplication.SharedApplication.CanOpenUrl (nsurl))
				UIApplication.SharedApplication.OpenUrl (nsurl);
		};
		this.AddSubview (btn);
	}

	public override void LayoutSubviews ()
	{
		base.LayoutSubviews ();
		var offset = 100f;
		tv.Frame = new RectangleF (0, offset, this.Bounds.Width, this.Bounds.Height - offset);
		btn.Frame = Bounds;
	}
}


