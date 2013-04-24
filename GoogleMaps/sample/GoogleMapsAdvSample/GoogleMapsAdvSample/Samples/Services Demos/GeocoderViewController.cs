using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreLocation;
using System.Drawing;
using Google.Maps;

namespace GoogleMapsAdvSample
{
	public class GeocoderViewController : UIViewController
	{
		MapView mapView;
		Geocoder geocoder;

		public GeocoderViewController () : base ()
		{
			Title = "Geocoder";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var camera = CameraPosition.FromCamera (-33.868, 151.2086, 12);
			mapView = MapView.FromCamera (RectangleF.Empty, camera);
			geocoder = new Geocoder ();

			mapView.LongPress += (sender, e) => {
				// On a long press, reverse geocode this location.
				geocoder.ReverseGeocodeCord (e.Coordinate, (response, error) => {
					if (response != null && response.FirstResult != null) {
						var marker = new Marker () {
							Position = e.Coordinate,
							Title = response.FirstResult.AddressLine1,
							Snippet = response.FirstResult.AddressLine2,
							Animated = true,
							Map = mapView
						};
					} else {
						Console.WriteLine (string.Format ("Could not reverse geocode point ({0},{1}): {2}", 
						                                  e.Coordinate.Latitude, e.Coordinate.Longitude, error));
					}
				});
			};

			View = mapView;
		}
	}
}

