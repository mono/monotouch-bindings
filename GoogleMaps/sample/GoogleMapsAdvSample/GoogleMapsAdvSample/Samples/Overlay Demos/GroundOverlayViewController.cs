using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreLocation;
using System.Drawing;
using Google.Maps;

namespace GoogleMapsAdvSample
{
	public class GroundOverlayViewController : UIViewController
	{
		public GroundOverlayViewController () : base ()
		{
			Title = "Ground Overlay";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var newark = new CLLocationCoordinate2D (40.742, -74.174);
			var camera = CameraPosition.FromCamera (newark, 12, 0, 50);
			var mapView = MapView.FromCamera (RectangleF.Empty, camera);

			// Image from http://www.lib.utexas.edu/maps/historical/newark_nj_1922.jpg
			var groundOverlay = new GroundOverlay () {
				Icon = UIImage.FromBundle ("newark_nj_1922.jpg"),
				Position = newark,
				Bearing = 0,
				ZoomLevel = 13.6f,
				Map = mapView
			};

			View = mapView;
		}
	}
}

