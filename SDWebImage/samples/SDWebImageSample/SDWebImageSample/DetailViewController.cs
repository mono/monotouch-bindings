
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using SDWebImage;

namespace SDWebImageSample
{
	public partial class DetailViewController : UIViewController
	{
		public NSUrl ImageUrl { get; set; }

		UIActivityIndicatorView activityIndicator;

		public DetailViewController () : base ("DetailViewController", null)
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
			
			configureView ();
		}

		void configureView ()
		{
			if (ImageUrl != null) {
				ImageView.SetImage (ImageUrl, null, SDWebImageOptions.ProgressiveDownload, ProgressHandler, CompletedHandler);
			}
		}

		void ProgressHandler (uint receivedSize, long expectedSize)
		{
			if (activityIndicator == null) {
				activityIndicator = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.Gray);
				ImageView.AddSubview (activityIndicator);
				activityIndicator.Center = ImageView.Center;
				activityIndicator.StartAnimating ();
			}
		}

		void CompletedHandler (UIImage image, NSError error, SDImageCacheType cacheType)
		{
			if (activityIndicator != null) {
				activityIndicator.RemoveFromSuperview ();
				activityIndicator = null;
			}
		}

	}
}

