using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

namespace GoogleMaps
{
	delegate void GMSReverseGeocodeCallback (GMSReverseGeocodeResponse response,NSError error);
	[BaseType (typeof (NSObject))]
	[Model]
	interface GMSMapViewDelegate {
		[Abstract]
		[Export ("mapView:didChangeCameraPosition:"), EventArgs ("GMSCamera")]
		void ChangedCameraPosition (GMSMapView mapView, GMSCamera position);
		
		[Abstract]
		[Export ("mapView:didTapAtCoordinate:"), EventArgs ("GMSCoord")]
		void Tapped (GMSMapView mapView, CLLocationCoordinate2D coordinate);
		
		[Abstract]
		[Export ("mapView:didLongPressAtCoordinate:"), EventArgs ("GMSCoord")]
		void LongPress (GMSMapView mapView, CLLocationCoordinate2D coordinate);
		
		[Abstract]
		[Export ("mapView:didTapMarker:"), EventArgs ("GMSMarkerEvent"), DefaultValue(false)]
		bool TapedMarker (GMSMapView mapView, GMSMarker marker);
		
		[Abstract]
		[Export ("mapView:didTapInfoWindowOfMarker:"), EventArgs ("GMSMarkerEvent")]
		void TapedInfo (GMSMapView mapView, GMSMarker marker);
		
		[Abstract]
		[Export ("mapView:markerInfoWindow:"), EventArgs ("GMSMapEvent"),DefaultValue(null)]
		UIView InfoFor (GMSMapView mapView, GMSMarker marker);
		
	}

	[BaseType (typeof (UIView), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof (GMSMapViewDelegate)})]
	interface GMSMapView {
		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		[Wrap ("WeakDelegate")]
		GMSMapViewDelegate Delegate { get; set; }
		
		[Export ("camera")]
		GMSCamera Camera { get; set;  }
		
		[Export ("projection")]
		GMSProjection Projection { get;  }
		
		[Export ("myLocationEnabled")]
		bool MyLocationEnabled { [Bind ("isMyLocationEnabled")] get; set;  }
		
		[Export ("myLocation")]
		CLLocation MyLocation { get;  }
		
		[Export ("selectedMarker")]
		GMSMarker SelectedMarker { get; set;  }
		
		[Export ("trafficEnabled")]
		bool TrafficEnabled { [Bind ("isTrafficEnabled")] get; set;  }
		
		[Export ("mapType")]
		GMSMapViewType MapType { get; set;  }
		
		[Static]
		[Export ("mapWithFrame:camera:")]
		GMSMapView FromCamera (RectangleF frame, GMSCamera camera);
		
		[Export ("startRendering")]
		void StartRendering ();
		
		[Export ("stopRendering")]
		void StopRendering ();
		
		[Export ("animateToLocation:")]
		void AnimateToLocation (CLLocationCoordinate2D location);
		
		[Export ("animateToZoom:")]
		void AnimateToZoom (float zoom);
		
		[Export ("animateToBearing:")]
		void AnimateToBearing (double bearing);
		
		[Export ("animateToViewingAngle:")]
		void AnimateToViewingAngle (double viewingAngle);
		
		[Internal]
		[Export ("addMarkerWithOptions:")]
		IntPtr InternalAddMarker (GMSMarkerOptions options);
		
		[Export ("addPolylineWithOptions:")]
		GMSPolyline AddPolyline (GMSPolylineOptions options);
		
		[Export ("clear")]
		void Clear ();
		
	}
	[BaseType (typeof (NSObject))]
	interface GMSGeocoder {
		[Export ("reverseGeocodeCoordinate:completionHandler:")]
		void ReverseGeocodeCord(CLLocationCoordinate2D coordinate, GMSReverseGeocodeCallback handler);
		
	}
	
	[BaseType (typeof (NSObject))]
	interface GMSMarker {
		[Export ("position")]
		CLLocationCoordinate2D Position { get; set;  }
		
		[Export ("title")]
		string Title { get; set;  }
		
		[Export ("snippet")]
		string Snippet { get; set;  }
		
		[Export ("icon")]
		UIImage Icon { get; set;  }
		
		[Export ("groundAnchor")]
		PointF GroundAnchor { get; set;  }
		
		[Export ("infoWindowAnchor")]
		PointF InfoWindowAnchor { get; set;  }
		
		[Export ("accessibilityLabel")]
		string AccessibilityLabel { get; set;  }
		
		[Export ("userData")]
		NSObject UserData { get; set;  }
		
		[Export ("remove")]
		void Remove ();
		
	}
	
	[BaseType (typeof (NSObject))]
	interface GMSMarkerOptions {
		[Export ("position")]
		CLLocationCoordinate2D Position { get; set;  }
		
		[Export ("title")]
		string Title { get; set;  }
		
		[Export ("snippet")]
		string Snippet { get; set;  }
		
		[Export ("icon")]
		UIImage Icon { get; set;  }
		
		[Export ("groundAnchor")]
		PointF GroundAnchor { get; set;  }
		
		[Export ("infoWindowAnchor")]
		PointF InfoWindowAnchor { get; set;  }
		
		[Export ("accessibilityLabel")]
		string AccessibilityLabel { get; set;  }
		
		[Export ("userData")]
		NSObject UserData { get; set;  }
		
		[Static]
		[Export ("options")]
		GMSMarkerOptions Options ();
		
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface GMSPolyline {
		[Abstract]
		[Export ("color")]
		UIColor Color { get; set;  }
		
		[Abstract]
		[Export ("width")]
		float Width { get; set;  }
		
		[Abstract]
		[Export ("accessibilityLabel")]
		string AccessibilityLabel { get; set;  }
		
		[Abstract]
		[Export ("remove")]
		void Remove ();
		
	}
	
	[BaseType (typeof (NSObject))]
	interface GMSPolylineOptions {
		[Export ("color")]
		UIColor Color { get; set;  }
		
		[Export ("width")]
		float Width { get; set;  }
		
		[Export ("accessibilityLabel")]
		string AccessibilityLabel { get; set;  }
		
		[Static]
		[Export ("options")]
		GMSPolylineOptions Options ();
		
		[Export ("addVertex:")]
		void AddVertex (CLLocationCoordinate2D vertex);
		
	}
	
	[BaseType (typeof (NSObject))]
	interface GMSProjection {
		[Export ("pointForCoordinate:")]
		PointF PointForCoordinate (CLLocationCoordinate2D coordinate);
		
		[Export ("coordinateForPoint:")]
		CLLocationCoordinate2D CoordinateForPoint (PointF point);
		
		[Export ("pointsForMeters:atCoordinate:")]
		float PointsForMeters (float meters, CLLocationCoordinate2D coordinate);
		
	}

	[BaseType (typeof (NSObject))]
	interface GMSReverseGeocodeResult {
		[Export ("addressLine1")]
		string AddressLine1 {get;}
		
		[Export ("addressLine2")]
		string AddressLine2 { get; }
		
	}
	
	[BaseType (typeof (NSObject))]
	interface GMSReverseGeocodeResponse {
		[Export ("firstResult")]
		GMSReverseGeocodeResult FirstResult ();
		
		[Export ("results")]
		GMSReverseGeocodeResult[] Results ();
		
	}
	[BaseType(typeof(NSObject))]
	interface GMSServices {
		[Static]
		[Export ("provideAPIKey:")]
		bool ProvideAPIKey (string APIKey);
		
		[Static]
		[Export ("openSourceLicenseInfo")]
		string OpenSourceLicenseInfo { get; }
		
		[Static]
		[Export ("SDKVersion")]
		string SDKVersion { get; }
		
	}


}

