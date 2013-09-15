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

			var southWest = new CLLocationCoordinate2D (40.712216, -74.22655);
			var northEast = new CLLocationCoordinate2D (40.773941, -74.12544);
			var overlayBounds = new CoordinateBounds (southWest, northEast);

			// Choose the midpoint of the coordinate to focus the camera on.
			var newark = GeometryUtils.Interpolate (southWest, northEast, 0.5);
			var camera = CameraPosition.FromCamera (newark, 12, 0, 45);
			var mapView = MapView.FromCamera (RectangleF.Empty, camera);

			// Add the ground overlay, centered in Newark, NJ
			// Image from http://www.lib.utexas.edu/maps/historical/newark_nj_1922.jpg
			var groundOverlay = new GroundOverlay () {
				Icon = UIImage.FromBundle ("newark_nj_1922.jpg"),
				Position = newark,
				Bounds = overlayBounds,
				Map = mapView
			};

			View = mapView;
		}
	}
}

