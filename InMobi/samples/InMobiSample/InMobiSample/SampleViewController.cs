using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using InMobiSdk;

namespace InMobiSample
{
	public class SampleViewController : UIViewController
	{
		public SampleViewController () : base ()
		{
		}

		UIButton btnShowAd;
		IMBanner banner;
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.BackgroundColor = UIColor.White;

			btnShowAd = UIButton.FromType (UIButtonType.RoundedRect);
			btnShowAd.Frame = new RectangleF (129, 99, 62, 30);
			btnShowAd.SetTitle ("Show Ad", UIControlState.Normal);

			btnShowAd.TouchUpInside += (sender, e) => {
				if (banner == null) 
					banner = new IMBanner (frame: new RectangleF (0, 20, 320, 50),  
					                       appId: "Insert InMobi App ID Here", 
					                       adSize: IMAdSize.Banner320x50);
				banner.LoadBanner ();
				View.Add (banner);
			};

			View.Add (btnShowAd);
		}
	}
}

