using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

using iCarouselSDK;

namespace iCarouselSample
{
	public class SimpleSampleViewController : UIViewController
	{

		public List<int> items;
		iCarousel carousel;

		public SimpleSampleViewController () : base ()
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Setup the item list we will display
			// your carousel should always be driven by an array/list of
			// data of some kind - don't store data in your item views
			// or the recycling mechanism will destroy your data once
			// your item views move off-screen
			items = Enumerable.Range (1, 100).ToList(); // Prettier than for (int i = 0; i < 100; i++)

			// Setup Background image
			var imgView = new UIImageView (UIImage.FromBundle ("background")) {
				ContentMode = UIViewContentMode.ScaleToFill,
				AutoresizingMask = UIViewAutoresizing.All,
				Frame = View.Bounds
			};
			View.AddSubview (imgView);

			// Setup iCarousel view
			carousel = new iCarousel (View.Bounds) {
				CarouselType = iCarouselType.CoverFlow2,
				DataSource = new SimpleDataSource (this),
				Delegate = new SimpleDelegate (this)
			};

			View.AddSubview (carousel);
		}

		public class SimpleDataSource : iCarouselDataSource
		{
			SimpleSampleViewController vc;

			public SimpleDataSource (SimpleSampleViewController vc)
			{
				this.vc = vc;
			}

			public override uint NumberOfItems (iCarousel carousel)
			{
				return (uint) vc.items.Count;
			}
			public override UIView ViewForItem (iCarousel carousel, uint index, UIView reusingView)
			{

				UILabel label;

				// create new view if no view is available for recycling
				if (reusingView == null)
				{
					// don't do anything specific to the index within
					// this `if (view == null) {...}` statement because the view will be
					// recycled and used with other index values later
					var imgView = new UIImageView (new RectangleF (0, 0, 200, 200)) {
						Image = UIImage.FromBundle ("page"),
						ContentMode = UIViewContentMode.Center
					};

					label = new UILabel (imgView.Bounds) {
						BackgroundColor = UIColor.Clear,
						TextAlignment = UITextAlignment.Center,
						Tag = 1
					};
					label.Font = label.Font.WithSize (50);
					imgView.AddSubview (label);
					reusingView = imgView;
				}
				else
				{
					// get a reference to the label in the recycled view
					label = (UILabel) reusingView.ViewWithTag (1);
				}
				
				// set item label
				// remember to always set any properties of your carousel item
				// views outside of the `if (view == null) {...}` check otherwise
				// you'll get weird issues with carousel item content appearing
				// in the wrong place in the carousel
				label.Text = vc.items[(int)index].ToString();

				return reusingView;
			}
		}

		public class SimpleDelegate : iCarouselDelegate
		{
			SimpleSampleViewController vc;

			public SimpleDelegate (SimpleSampleViewController vc)
			{
				this.vc = vc;
			}

			public override float ValueForOption (iCarousel carousel, iCarouselOption option, float aValue)
			{
				if (option == iCarouselOption.Spacing) {
					return aValue * 1.1f;
				}
				return aValue;
			}

			public override void DidSelectItem (iCarousel carousel, int index)
			{
				Console.WriteLine ("Selected: " + ++index);
			}
		}
	}
}

