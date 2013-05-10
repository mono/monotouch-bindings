using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

using iCarouselSDK;

namespace iCarouselSample
{
	public class ControlsViewController : UIViewController
	{
		public iCarousel Carousel;
		public UILabel Label;
		public HashSet<UIView> ObjCache = new HashSet<UIView> ();

		public ControlsViewController () : base ()
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Setup Background image
			var imgView = new UIImageView (UIImage.FromBundle ("background")) {
				ContentMode = UIViewContentMode.ScaleToFill,
				AutoresizingMask = UIViewAutoresizing.All,
				Frame = View.Bounds
			};
			View.AddSubview (imgView);
			
			// Setup iCarousel view
			Carousel = new iCarousel (View.Bounds) {
				CarouselType = iCarouselType.CoverFlow2,
				DataSource = new ControlsDataSource (this)
			};
			
			View.AddSubview (Carousel);

			// Setup info label
			Label = new UILabel (new RectangleF (20, 362, 280, 21)) {
				BackgroundColor = UIColor.Clear,
				Text = string.Empty,
				TextAlignment = UITextAlignment.Center
			};

			View.AddSubview (Label);
		}

		public class ControlsDataSource : iCarouselDataSource
		{
			ControlsViewController vc;

			public ControlsDataSource (ControlsViewController vc)
			{
				this.vc = vc;
			}

			public override uint NumberOfItems (iCarousel carousel)
			{
				// generate 100 item views
				// normally we'd use a backing array/List
				// as shown in the basic iOS example
				// but for this example we haven't bothered
				return 100;
			}

			public override UIView ViewForItem (iCarousel carousel, uint index, UIView reusingView)
			{
				if (reusingView == null) {

					var itemView = new UIView (new RectangleF (0, 0, 200, 200)) {
						AutoresizingMask = UIViewAutoresizing.All
					};

					// Creating the background
					var imgView = new UIImageView (new RectangleF (-20, -90, 240, 380)) {
						Image = UIImage.FromBundle ("page"),
						ContentMode = UIViewContentMode.Center
					};
					itemView.AddSubview (imgView);

					// We create and add some controls
					// UIButton
					var button = UIButton.FromType (UIButtonType.RoundedRect);
					button.Frame = new RectangleF (20, 20, 160, 37);
					button.SetTitle ("Press me!", UIControlState.Normal);
					button.TouchUpInside += (sender, e) => {
						vc.Label.Text = string.Format ("Button {0} tapped", vc.Carousel.IndexOfItemViewOrSubview (sender as UIView));
					};

					if (!vc.ObjCache.Contains (button))
						vc.ObjCache.Add (button);

					itemView.AddSubview (button);

					// UISwitch
					var switchbtn = new UISwitch (new RectangleF (62, 86, 79, 27));
					switchbtn.ValueChanged += (sender, e) => {
						vc.Label.Text = string.Format ("Switch {0} toggled", vc.Carousel.IndexOfItemViewOrSubview (sender as UIView));
					};

					if (!vc.ObjCache.Contains (switchbtn))
						vc.ObjCache.Add (switchbtn);

					itemView.AddSubview (switchbtn);

					// UISlider
					var slider = new UISlider (new RectangleF (41, 146, 118, 23)) {
						MinValue = 0,
						MaxValue = 100,
						Value = 50
					};
					slider.ValueChanged += (sender, e) => {
						vc.Label.Text = string.Format ("Slider {0} changed", vc.Carousel.IndexOfItemViewOrSubview (sender as UIView));
					};

					if (!vc.ObjCache.Contains (slider))
						vc.ObjCache.Add (slider);

					itemView.AddSubview (slider);

					reusingView = itemView;
				}
				return reusingView;
			}
		}
	}
}

