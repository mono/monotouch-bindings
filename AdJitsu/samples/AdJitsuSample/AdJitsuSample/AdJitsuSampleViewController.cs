// 
// AdJitsuSampleViewController.cs
//  
// Author: Jeffrey Stedfast <jeff@xamarin.com>
// 
// Copyright (c) 2011 Xamarin Inc.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 

using System;
using System.Drawing;
using System.Collections;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using AdJitsu;

namespace AdJitsuSample
{
	public partial class AdJitsuSampleViewController : UIViewController
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
		
		public AdJitsuSampleViewController ()
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			View.BackgroundColor = UIColor.White;
			
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
			
			status = new UILabel (new RectangleF (10, 180, 310, 22)) {
				Text = "Adjitsu Demo Status"
			};
			View.AddSubview (status);
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Release any retained subviews of the main view.
			// e.g. myOutlet = null;
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return true;
		}
	}
}
