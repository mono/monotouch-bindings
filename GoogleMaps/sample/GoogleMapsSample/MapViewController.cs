using System;
using MonoTouch.UIKit;
using GoogleMaps;
using System.Drawing;
using MonoTouch.CoreLocation;

namespace GoogleMapsSample
{
	public class MapViewController : UIViewController
	{
		GMSMapView mapView;
		public MapViewController ()
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			GMSCamera camera = new GMSCamera(-33.8683, 151.2086, 6);
			mapView = new GMSMapView{Camera =  camera};
			mapView.MyLocationEnabled = true ;
			this.View = mapView;

			GMSMarkerOptions options = new GMSMarkerOptions ();
			options.Position = new CLLocationCoordinate2D(-33.8683, 151.2086);
			options.Title = @"Sydney";
			options.Snippet = @"Australia";
			mapView.AddMarker (options);
		}
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			mapView.StartRendering ();
		}
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			mapView.StopRendering ();
		}
	}
}

