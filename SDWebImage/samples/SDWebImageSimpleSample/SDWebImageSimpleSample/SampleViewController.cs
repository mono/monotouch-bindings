using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using SDWebImage;

namespace SDWebImageSimpleSample
{
	public partial class SampleViewController : UIViewController
	{
		public SampleViewController () : base ("SampleViewController", null)
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

			btnDownload.TouchUpInside += (sender, e) => imageView.SetImage (
				new NSUrl ("http://goo.gl/1g7jP"), null, SDWebImageOptions.ProgressiveDownload, 
				ProgressHandler, CompletedHandler
			);	
		}

		void ProgressHandler (int receivedSize, int expectedSize)
		{
			if (expectedSize > 0) {
				InvokeOnMainThread (()=> {
					float progress = (float)receivedSize / (float)expectedSize;
					progressBar.SetProgress (progress, true);
					lblPercent.Text = "Downloading...";
				});
			}
		}
		
		void CompletedHandler (UIImage image, NSError error, SDImageCacheType cacheType)
		{
		 	InvokeOnMainThread (()=> lblPercent.Text = "Download Completed");
		}
	}
}

