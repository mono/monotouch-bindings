
using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using SDWebImage;

namespace SDWebImageMTDialogSample
{
	public partial class DetailViewController : UIViewController
	{
		UIImageView ImageView;
		UIActivityIndicatorView activityIndicator;
		public NSUrl ImageUrl { get; private set; }


		public DetailViewController (NSUrl imageUrl) : base ()
		{
			ImageUrl = imageUrl;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.BackgroundColor = UIColor.White;
			ImageView = new UIImageView (View.Bounds) {
				ContentMode = UIViewContentMode.ScaleAspectFit
			};

			View.AddSubview (ImageView);

			if (ImageUrl != null) {
				ImageView.SetImageWithURL (ImageUrl, null, SDWebImageOptions.ProgressiveDownload, ProgressHandler, CompletedHandler);
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
