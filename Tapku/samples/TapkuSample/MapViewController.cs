using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;
using Tapku;

namespace TapkuSample
{
	public partial class MapViewController : UIViewController
	{
		public TKMapView MapView { get; private set; }
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			MapView = new TKMapView(View.Bounds);
			MapView.Delegate = new MyMapViewDelegate(this);
			
			View.AddSubview(MapView);
			
			NavigationItem.RightBarButtonItem = new UIBarButtonItem("Add Pin", UIBarButtonItemStyle.Bordered, Handle_AddPin);
		}
		
		private void Handle_AddPin(object sender, EventArgs e) 
		{
			if(MapView.PinMode){
				MapView.MapView.MapType = MKMapType.Standard;
				NavigationItem.RightBarButtonItem.Style = UIBarButtonItemStyle.Bordered;
			}else{
				MapView.MapView.MapType = MKMapType.Hybrid;
				NavigationItem.RightBarButtonItem.Style = UIBarButtonItemStyle.Done;
			}
			
			MapView.PinMode = !MapView.PinMode;
		}
		
		public class MyMapViewDelegate : TKMapViewDelegate
		{
			MapViewController _mapViewController;
			public MyMapViewDelegate(MapViewController viewController)
				: base()
			{
				_mapViewController = viewController;
			}
			
			public override void DidPlacePin(CLLocationCoordinate2D location)
			{
				var place = new TKMapPlace();
				var title = string.Format("Lat: {0}, Lng: {1}", location.Latitude, location.Longitude);
				Console.WriteLine("Added Pin at " + title);
				
				place.Title = title;
				place.Coordinate = location;
				_mapViewController.MapView.MapView.AddAnnotationObject(place);
			}
		}
		
	}
}
