using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.CoreLocation;
using Google.Maps;

namespace GoogleMapsSample
{
	public class MapViewController : UIViewController
	{
		MapView mapView;
		public MapViewController ()
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

		}

		public override void LoadView ()
		{
			base.LoadView ();

			CameraPosition camera = CameraPosition.FromCamera (37.797865, -122.402526, 6);
			mapView = MapView.FromCamera(RectangleF.Empty, camera);
			mapView.MyLocationEnabled = true;
			View = mapView;
			
			var xamarinhq = new MarkerOptions {
				Title = "Xamarin HQ",
				Snippet = "Where the magic happens.",
				Position = new CLLocationCoordinate2D (37.797865, -122.402526)
			};
			mapView.AddMarker (xamarinhq);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			mapView.StartRendering ();
		}
		public override void ViewWillDisappear (bool animated)
		{	
			mapView.StopRendering ();
			base.ViewWillDisappear (animated);
		}
	}
}

