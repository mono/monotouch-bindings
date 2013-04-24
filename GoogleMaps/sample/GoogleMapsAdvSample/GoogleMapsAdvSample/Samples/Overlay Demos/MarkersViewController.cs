using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreLocation;
using System.Drawing;
using Google.Maps;

namespace GoogleMapsAdvSample
{
	public class MarkersViewController : UIViewController
	{
		public MarkersViewController () : base ()
		{
			Title = "Markers";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var camera = CameraPosition.FromCamera (-37.81969, 144.966085, 4);
			var mapView = MapView.FromCamera (RectangleF.Empty, camera);

			var sydneyMarker = new Marker () {
				Title = "Sydney",
				Snippet = "Population: 4,605,992",
				Position = new CLLocationCoordinate2D (-33.8683, 151.2086),
				Map = mapView
			};

			var melbourneMarker = new Marker () {
				Title = "Melbourne",
				Snippet = "Population: 4,169,103",
				Position = new CLLocationCoordinate2D (-37.81969, 144.966085),
				Map = mapView
			};

			// Set the marker in Sydney to be selected
			mapView.SelectedMarker = sydneyMarker;

			View = mapView;
		}
	}
}

