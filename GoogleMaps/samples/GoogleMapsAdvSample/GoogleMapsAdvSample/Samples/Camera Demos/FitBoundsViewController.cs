using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreLocation;
using System.Drawing;
using System.Collections.Generic;
using Google.Maps;

namespace GoogleMapsAdvSample
{
	public class FitBoundsViewController : UIViewController
	{
		MapView mapView;
		List<Marker> markers;

		public FitBoundsViewController () : base ()
		{
			Title = "Fit Bounds";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var camera = CameraPosition.FromCamera (-37.81969, 144.966085, 4);
			mapView = MapView.FromCamera (RectangleF.Empty, camera);
			View = mapView;

			mapView.LongPress += HandleLongPress;

			// Add a default marker around Sydney.
			var sydneyMarker = new Marker () {
				Title = "Sydney!",
				Icon = UIImage.FromBundle ("glow-marker"),
				Position = new CLLocationCoordinate2D (-33.8683, 151.2086),
				Map = mapView
			};

			// Create a list of markers, adding the Sydney marker.
			markers = new List<Marker> () { sydneyMarker };

			// Create a button that, when pressed, updates the camera to fit the bounds
			// of the specified markers.
			var fitBoundsButton = new UIBarButtonItem ("Fit Bounds", UIBarButtonItemStyle.Plain, DidTapFitBounds);
			NavigationItem.RightBarButtonItem = fitBoundsButton;
		}

		void HandleLongPress (object sender, GMSCoordEventArgs e)
		{
			var marker = new Marker () {
				Title = string.Format ("Marker at: {0}, {1}", e.Coordinate.Latitude, e.Coordinate.Longitude),
				Position = e.Coordinate,
				AppearAnimation = MarkerAnimation.Pop,
				Map = mapView
			};
			
			// Add the new marker to the list of markers.
			markers.Add (marker);
		}

		void DidTapFitBounds (object sender, EventArgs e)
		{
			CoordinateBounds bounds = null;
			foreach (var marker in markers) {
				if (bounds == null)
					bounds = new CoordinateBounds (marker.Position, marker.Position);

				bounds = bounds.Including (marker.Position);
			}
			var update = CameraUpdate.FitBounds (bounds, 50.0f);
			mapView.MoveCamera (update);
		}
	}
}

