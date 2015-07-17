
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using MonoTouch.Dialog;

using GPUImage.Filters;
using GPUImage;

namespace GPUImage.Sample
{
	/// <summary>
	/// Display an image and apply any selected filter
	/// </summary>
	public partial class MainViewController : UIViewController
	{
		private UIImage image;
		private GPUImageView imageView;

		public MainViewController () : base (null, null)
		{
		}

		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations ()
		{
			return UIInterfaceOrientationMask.Landscape;
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		// Create view
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			image = UIImage.FromFile("image.jpg");

			imageView = new GPUImageView(new RectangleF(0,0,480,320));
			imageView.ContentMode = UIViewContentMode.ScaleToFill;
			View = imageView;

			// Trick to display the image initially
			// TODO: Have the right size
			applySepiaFilter(0f);

			UIButton button = new GlassButton(new RectangleF(0,0,96,32));
			button.SetTitle("Sepia!", UIControlState.Normal);
			button.TouchUpInside += (object sender, EventArgs e) => {
				applySepiaFilter(0.9f);
			};
			View.AddSubview (button);
		}

		private void applySepiaFilter(float sepiaIntensity) {
			// Apply a filter
			GPUImageSepiaFilter filter = new GPUImageSepiaFilter();
			filter.Intensity = sepiaIntensity;
			
			// Create image object to process
			GPUImagePicture stillImageSource = new GPUImagePicture(image, true);
			stillImageSource.AddTarget(filter);
			
			filter.AddTarget(imageView);

			// Launch the process
			stillImageSource.ProcessImage();
		}
	}
}

