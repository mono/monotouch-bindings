using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreLocation;
using System.Drawing;
using Google.Maps;

namespace GoogleMapsAdvSample
{
	public class TileLayerViewController : UIViewController
	{
		UISegmentedControl switcher;
		MapView mapView;
		TileLayer tilelayer;
		int floor;

		public TileLayerViewController () : base ()
		{
			Title = "Tile Layer";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var camera = CameraPosition.FromCamera (37.78318, -122.403874, 18);
			mapView = MapView.FromCamera (RectangleF.Empty, camera);
			mapView.BuildingsEnabled = false;
			View = mapView;

			// The possible floors that might be shown.
			var types = new [] { "1", "2", "3" };

			// Create a UISegmentedControl that is the navigationItem's titleView.
			switcher = new UISegmentedControl (types) {
				SelectedSegment = 0,
				ControlStyle = UISegmentedControlStyle.Bar,
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
			};

			NavigationItem.TitleView = switcher;

			// Listen to touch events on the UISegmentedControl, force initial update.
			switcher.ValueChanged += DidChangeSwitcher;

			DidChangeSwitcher ();
		}

		void DidChangeSwitcher (object sender = null, EventArgs e = null)
		{
			var title = switcher.TitleAt (switcher.SelectedSegment);
			var selectedFloor = Convert.ToInt32 (title);
			if (floor != selectedFloor) {
				// Clear existing tileLayer, if any.
				if (tilelayer != null)
					tilelayer.Map = null;

				// Create a new TileLayer with the new floor choice.
				tilelayer = UrlTileLayer.FromUrlConstructor ((x, y, zoom) => {
					var url = string.Format ("http://www.gstatic.com/io2010maps/tiles/9/L{0}_{1}_{2}_{3}.png", floor, zoom, x, y);
					return new NSUrl (url);
				});
				tilelayer.Map = mapView;
				floor = selectedFloor;
			}
		}
	}
}

