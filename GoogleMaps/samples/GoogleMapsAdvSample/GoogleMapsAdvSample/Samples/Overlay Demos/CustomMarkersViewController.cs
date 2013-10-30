using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreLocation;
using System.Drawing;
using Google.Maps;
using System.Threading;
using System.Security.Cryptography;

namespace GoogleMapsAdvSample
{
	public class CustomMarkersViewController : UIViewController
	{
		MapView mapView;
		int markerCount = 0;

		public CustomMarkersViewController () : base ()
		{
			Title = "Custom Markers";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			var camera = CameraPosition.FromCamera (-37.81969, 144.966085, 4);
			mapView = MapView.FromCamera (RectangleF.Empty, camera);
			AddDefaultMarkers ();

			// Add a button which adds random markers to the map.
			var addButton = new UIBarButtonItem (UIBarButtonSystemItem.Add, DidTapAdd);
			var clearButton = new UIBarButtonItem ("Clear Markers", UIBarButtonItemStyle.Plain, (o,s) => { 
				mapView.Clear ();
				AddDefaultMarkers ();
			});

			NavigationItem.RightBarButtonItems = new [] {addButton, clearButton} ;

			View = mapView;
		}

		void AddDefaultMarkers () 
		{
			var sydneyMarker = new Marker () {
				Title = "Sydney!",
				Icon = UIImage.FromBundle ("glow-marker"),
				Position = new CLLocationCoordinate2D (-33.8683, 151.2086),
				Map = mapView
			};
			
			var melbourneMarker = new Marker () {
				Title = "Melbourne!",
				Icon = UIImage.FromBundle ("arrow"),
				Position = new CLLocationCoordinate2D (-37.81969, 144.966085),
				Map = mapView
			};
		}

		void DidTapAdd (object sender, EventArgs e)
		{
			for (int i = 0; i < 10; ++i) {
				// Add a marker every 0.25 seconds for the next ten markers, randomly
				// within the bounds of the camera as it is at that point.
				var region = mapView.Projection.VisibleRegion;
				var bounds = new CoordinateBounds (region);
				AddMarkerInBounds (bounds);
				Thread.Sleep (250);
			}
		}

		void AddMarkerInBounds (CoordinateBounds bounds)
		{
			double latitude = bounds.SouthWest.Latitude + GetRandomNumber() * (bounds.NorthEast.Latitude - bounds.SouthWest.Latitude);
						
			// If the visible region crosses the antimeridian (the right-most point is
			// "smaller" than the left-most point), adjust the longitude accordingly.
			bool offset = (bounds.NorthEast.Longitude < bounds.SouthWest.Longitude);
			double longitude = bounds.SouthWest.Longitude + GetRandomNumber() * 
				(bounds.NorthEast.Longitude - bounds.SouthWest.Longitude + (offset ? 360 : 0));

			if (longitude > 180)
				longitude -= 360;
			
			var color =	UIColor.FromHSBA ((float)GetRandomNumber(), 1, 1, 1.0f);
						
			var position = new CLLocationCoordinate2D (latitude, longitude);
			var marker = Marker.FromPosition (position);
			marker.Title = string.Format ("Marker {0}", ++markerCount);
			marker.AppearAnimation = MarkerAnimation.Pop;
			marker.Icon = Marker.MarkerImage (color);
			marker.Map = mapView;
		}

		double GetRandomNumber ()
		{ 
			var rng = new RNGCryptoServiceProvider();
			var bytes = new Byte[8];
			rng.GetBytes (bytes);
			var ul = BitConverter.ToUInt64 (bytes, 0) / (1 << 11);
			return ul / (Double)(1UL << 53);
		}
	}
}

