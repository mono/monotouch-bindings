using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreLocation;
using System.Drawing;
using Google.Maps;
using MonoTouch.CoreAnimation;

namespace GoogleMapsAdvSample
{
	public class MarkerEventsViewController : UIViewController
	{
		MapView mapView;
		Marker melbourneMarker;

		public MarkerEventsViewController () : base ()
		{
			Title = "Marker Events";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var camera = CameraPosition.FromCamera (-37.81969, 144.966085, 4);
			mapView = MapView.FromCamera (RectangleF.Empty, camera);

			var sydneyMarker = new Marker () {
				Position = new CLLocationCoordinate2D (-33.8683, 151.2086),
				Map = mapView
			};

			melbourneMarker = new Marker () {
				Position = new CLLocationCoordinate2D (-37.81969, 144.966085),
				Map = mapView
			};

			mapView.InfoFor = (aMapView, aMarker) => {
				if (aMarker == melbourneMarker)
					return new UIImageView (UIImage.FromBundle ("Icon"));
				return null;
			};

			mapView.TappedMarker = (aMapView, aMarker) => {
				// Animate to the marker
				CATransaction.Begin ();
				CATransaction.AnimationDuration = 3;  // 3 second animation
				
				var cam = new CameraPosition (aMarker.Position, 8, 50, 60);
				mapView.Animate (cam);
				CATransaction.Commit ();
				
				// Melbourne marker has a InfoWindow so return NO to allow markerInfoWindow to
				// fire. Also check that the marker isn't already selected so that the
				// InfoWindow doesn't close.
				if (aMarker == melbourneMarker && mapView.SelectedMarker != melbourneMarker) {
					return false;
				}
				
				// The Tap has been handled so return YES
				return true;
			};

			View = mapView;
		}


	}
}

