using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SegmentedControl;
using System.Drawing;

namespace SDSegmentedControlSample
{
	public class ViewController : UIViewController
	{
		public ViewController () : base ()
		{
		}

		SDSegmentedControl niceSegmentedCtrl;
		UIWebView browser;

		public override void LoadView ()
		{
			base.LoadView ();

			bool isV7 = UIDevice.CurrentDevice.CheckSystemVersion (7, 0);

			View.BackgroundColor = UIColor.White;

			niceSegmentedCtrl = new SDSegmentedControl (new string [] { "Google", "Bing", "Yahoo" });

			if (isV7)
				niceSegmentedCtrl.Frame = new RectangleF (0, 10, 320, 44);
			else
				niceSegmentedCtrl.Frame = new RectangleF (0, 0, 320, 44);

			niceSegmentedCtrl.SetImage (UIImage.FromBundle ("google"), 0);
			niceSegmentedCtrl.SetImage (UIImage.FromBundle ("bicon"), 1);
			niceSegmentedCtrl.SetImage (UIImage.FromBundle ("yahoo"), 2);
			niceSegmentedCtrl.ValueChanged += HandleValueChanged;

			if (isV7) 
				browser = new UIWebView (new RectangleF (0, 55, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height - 64));
			else
				browser = new UIWebView (new RectangleF (0, 45, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height - 64));

			browser.LoadRequest (new NSUrlRequest ( new NSUrl ("http://google.com")));
			browser.AutosizesSubviews = true;

			View.AddSubviews ( new UIView[] { niceSegmentedCtrl, browser });
		}

		void HandleValueChanged (object sender, EventArgs e)
		{
			switch (niceSegmentedCtrl.SelectedSegment) {
			case 0:
				browser.LoadRequest (new NSUrlRequest (new NSUrl ("http://google.com")));
				break;
			case 1:
				browser.LoadRequest (new NSUrlRequest (new NSUrl ("http://bing.com")));
				break;
			case 2:
				browser.LoadRequest (new NSUrlRequest (new NSUrl ("http://yahoo.com")));
				break;
			default:
			break;
			}
		}
	}
}

