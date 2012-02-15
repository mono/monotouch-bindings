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
		TKMapView mapView;
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			mapView = new TKMapView(View.Bounds);
			mapView.Delegate = new MyMap();
			
//			mapView.Did (sender, e) => {
//				using (TKMapPlace place = new TKMapPlace())
//				{
//					place.Title = String.Format("{0}, {1}",	
//				}
////				TKMapPlace *place = [[TKMapPlace alloc] init];
////	place.title = [NSString stringWithFormat:@"%f,%f",location.latitude,location.longitude];
////	NSLog(@"(%f,%f)",location.latitude,location.longitude);
////	place.coordinate = location;
////	[mapView.mapView addAnnotation:place];
////	[place release];
//
//			};
			View.AddSubview(mapView);
			
			NavigationItem.RightBarButtonItem = new UIBarButtonItem("Add Pin", UIBarButtonItemStyle.Bordered, (sender2, e2) => {
				if(mapView.PinMode){
					mapView.MapView.MapType = MKMapType.Standard;
					NavigationItem.RightBarButtonItem.Style = UIBarButtonItemStyle.Bordered;
				}else{
					mapView.MapView.MapType = MKMapType.Hybrid;
					NavigationItem.RightBarButtonItem.Style = UIBarButtonItemStyle.Done;
				}
				
				mapView.PinMode = !mapView.PinMode;
			});
		}
		
		public class MyMap : TKMapViewDelegate
		{
			public override void DidPlacePin (TKMapView mapView, CLLocationCoordinate2D location)
			{
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}
		}
		
	}
}
