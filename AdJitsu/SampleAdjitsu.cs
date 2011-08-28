using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;
using System.Drawing;
using AdJitsu;

namespace AdJitsu
{
	public class SampleAdjitsu : UIViewController
	{

		#region Ad Configuration parameters
		
		static RectangleF bannerSizePad = new RectangleF (0, 0, 728, 90);
		static RectangleF bannerSizePhone = new RectangleF (0, 0, 320, 48);
		const float borderSizePad = 20;
		const float borderSizePhone = 0;
		
		#endregion
		
		UIView adContainer;
		AdJitsuView ad;
		UILabel status;
		
		public SampleAdjitsu () : base (NSObjectFlag.Empty)
		{
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			AddButtons ();

			bool phone = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone;
			var bannerRect = phone ? bannerSizePhone : bannerSizePad;
			var border = phone ? borderSizePhone : borderSizePad;
			var bounds = View.Bounds;
			
			adContainer = new UIView (new RectangleF (new PointF ((bounds.Width-bannerRect.Width) / 2f, bounds.Height-bannerRect.Height - border), bannerSizePad.Size)){
				AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleTopMargin
			};
			View.AddSubview (adContainer);
			ResetView ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
		
		void ResetView ()
		{
			if (ad != null)
				ad.RemoveFromSuperview ();
			
			ad = new AdJitsuView (adContainer.Bounds);
			ad.WillOpen += delegate {
				status.Text = "Status: Opening";
			};
			ad.WillClose += delegate {
				status.Text = "Status: will close";
			};
			ad.FinishedLoadingScene += delegate {
				status.Text = "Finished Loading scene";
			};
			ad.FailedLoadingScene += delegate {
				status.Text = "Failed to load scene";
			};
			
			adContainer.AddSubview (ad);
			
			Reload ();
		}
		
		const string deviceAd = "http://cooliris-eng-3d.s3-website-us-east-1.amazonaws.com/production/3B38B58804D24BFBBC06ABA680E8F7B2/camera.zip";
		const string simulatorAd = "http://cooliris-eng-3d.s3-website-us-east-1.amazonaws.com/production/3B38B58804D24BFBBC06ABA680E8F7B2/camera-iphonesimulator.zip";
		
		void Reload ()
		{
			ad.LoadScene (new NSUrl (Runtime.Arch == Arch.DEVICE ? deviceAd : simulatorAd));
		}
		
		void AddButtons ()
		{
			var reload = UIButton.FromType (UIButtonType.RoundedRect);
			reload.Frame = new RectangleF (40, 40, 120, 48);
			reload.SetTitle ("Reload ad", UIControlState.Normal);
			View.AddSubview (reload);
			reload.TouchDown += delegate { Reload (); };

			var recreate = UIButton.FromType (UIButtonType.RoundedRect);
			recreate.Frame = new RectangleF (40, 100, 120, 48);
			recreate.SetTitle ("Recreate View", UIControlState.Normal);
			View.AddSubview (recreate);
			recreate.TouchDown += delegate { ResetView (); };
			
			status = new UILabel (new RectangleF (10, 180, 310, 240)) {
				Text = "Adjitsu Demo Status"
			};
			View.AddSubview (status);
		}
	}
}

