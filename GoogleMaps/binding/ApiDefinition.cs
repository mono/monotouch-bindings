using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

namespace GoogleMaps
{

	[BaseType (typeof (NSObject))]
	interface GMSCameraPosition {

		[Export ("initWithTarget:zoom:bearing:viewingAngle:")]
		IntPtr Constructor (CLLocationCoordinate2D target, float zoom, double bearing, double viewingAngle);

		[Static, Export ("cameraWithTarget:zoom:")]
		GMSCameraPosition FromCamera (CLLocationCoordinate2D target, float zoom);

		[Static, Export ("cameraWithLatitude:longitude:zoom:")]
		GMSCameraPosition FromCamera (double latitude, double longitude, float zoom);

		[Static, Export ("cameraWithTarget:zoom:bearing:viewingAngle:")]
		GMSCameraPosition FromCamera (CLLocationCoordinate2D target, float zoom, double bearing, double viewingAngle);

		[Static, Export ("cameraWithLatitude:longitude:zoom:bearing:viewingAngle:")]
		GMSCameraPosition FromCamera (double latitude, double longitude, float zoom, double bearing, double viewingAngle);

		[Export ("target")]
		CLLocationCoordinate2D Target { [Bind ("targetAsCoordinate")] get; }

		[Export ("zoom")]
		float Zoom { get; }

		[Export ("bearing")]
		double Bearing { get; }

		[Export ("viewingAngle")]
		double ViewingAngle { get; }

		[Field ("kGMSMaxZoomLevel", "__Internal")]
		float MaxZoomLevel { get; }

		[Field ("kGMSMinZoomLevel", "__Internal")]
		float MinZoomLevel { get; }
	}

	[BaseType (typeof (NSObject))]
	interface GMSCoordinateBounds {

		[Export ("northEast")]
		CLLocationCoordinate2D NorthEast { get; }

		[Export ("southWest")]
		CLLocationCoordinate2D SouthWest { get; }

		[Export ("initWithCoordinate:andCoordinate:")]
		IntPtr Constructor (CLLocationCoordinate2D coord1, CLLocationCoordinate2D coord2);
		
		[Export ("initWithRegion:")]
		IntPtr Constructor (GMSVisibleRegion region);

		[Export ("including:")]
		GMSCoordinateBounds Including (CLLocationCoordinate2D coordinate);

		[Export ("containsCoordinate:")]
		bool ContainsCoordinate (CLLocationCoordinate2D coordinate);
	}

	delegate void GMSReverseGeocodeCallback (GMSReverseGeocodeResponse response, NSError error);

	[BaseType (typeof (NSObject))]
	interface GMSGeocoder {

		[Static, Export ("geocoder")]
		GMSGeocoder Geocoder { get; }

		[Export ("reverseGeocodeCoordinate:completionHandler:")]
		void ReverseGeocodeCord(CLLocationCoordinate2D coordinate, GMSReverseGeocodeCallback handler);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface GMSGroundOverlay {
		
		[Export ("position", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Position { get; set; }

		[Export ("anchor", ArgumentSemantic.Assign)]
		PointF Anchor { get; set; }

		[Export ("icon")]
		UIImage Icon { get; set; }

		[Export ("zoomLevel", ArgumentSemantic.Assign)]
		float ZoomLevel { get; set; }

		[Export ("bearing", ArgumentSemantic.Assign)]
		double Bearing { get; set; }

		[Export ("remove")]
		void Remove ();
	}

	[BaseType (typeof (NSObject))]
	interface GMSGroundOverlayOptions {

		[Export ("position", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Position { get; set; }

		[Export ("anchor", ArgumentSemantic.Assign)]
		PointF Anchor { get; set; }

		[Export ("icon")]
		UIImage Icon { get; set; }

		[Export ("zoomLevel", ArgumentSemantic.Assign)]
		float ZoomLevel { get; set; }

		[Export ("bearing", ArgumentSemantic.Assign)]
		double Bearing { get; set; }

		[Static, Export ("options")]
		GMSGroundOverlayOptions Pptions { get; }

		[Field ("kGMSGroundOverlayDefaultZoom", "__Internal")]
		float DefaultZoom { get; }
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface GMSMapViewDelegate {

		[Export ("mapView:didChangeCameraPosition:"), EventArgs ("GMSCamera"), EventName ("ChangedCameraPosition")]
		void DidChangeCameraPosition (GMSMapView mapView, GMSCameraPosition position);
		
		[Export ("mapView:didTapAtCoordinate:"), EventArgs ("GMSCoord"), EventName ("Tapped")]
		void DidTapAtCoordinate (GMSMapView mapView, CLLocationCoordinate2D coordinate);
		
		[Export ("mapView:didLongPressAtCoordinate:"), EventArgs ("GMSCoord"), EventName ("LongPress")]
		void DidLongPressAtCoordinate (GMSMapView mapView, CLLocationCoordinate2D coordinate);
		
		[Export ("mapView:didTapMarker:"), DelegateName ("GMSTappedMarker"), DefaultValue(false)]
		bool TappedMarker (GMSMapView mapView, GMSMarker marker);
		
		[Export ("mapView:didTapInfoWindowOfMarker:"), EventArgs ("GMSMarkerEvent"), EventName ("TapedInfo")]
		void DidTapInfoWindowOfMarker (GMSMapView mapView, GMSMarker marker);
		
		[Export ("mapView:markerInfoWindow:"), DelegateName ("GMSInfoFor"), DefaultValue(null)]
		UIView InfoFor (GMSMapView mapView, GMSMarker marker);
	}

	[BaseType (typeof (UIView),
	Delegates=new string [] {"WeakDelegate"},
	Events=new Type [] { typeof (GMSMapViewDelegate) })]
	interface GMSMapView {

		[Wrap ("WeakDelegate")]
		GMSMapViewDelegate Delegate { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("camera")]
		GMSCameraPosition Camera { get; set; }

		[Export ("projection")]
		GMSProjection Projection { get; }
		
		[Export ("myLocationEnabled", ArgumentSemantic.Assign)]
		bool MyLocationEnabled { [Bind ("isMyLocationEnabled")] get; set; }
		
		[Export ("myLocation")]
		CLLocation MyLocation { get; }
		
		[Export ("selectedMarker")]
		GMSMarker SelectedMarker { get; [NullAllowed] set; }
		
		[Export ("trafficEnabled", ArgumentSemantic.Assign)]
		bool TrafficEnabled { [Bind ("isTrafficEnabled")] get; set; }
		
		[Export ("mapType", ArgumentSemantic.Assign)]
		GMSMapViewType MapType { get; set; }

		[Export ("settings")]
		GMSUISettings Settings { get; }
		
		[Static]
		[Export ("mapWithFrame:camera:")]
		GMSMapView FromCamera (RectangleF frame, GMSCameraPosition camera);
		
		[Export ("startRendering")]
		void StartRendering ();
		
		[Export ("stopRendering")]
		void StopRendering ();

		[Export ("animateToCameraPosition:")]
		void AnimateToCameraPosition (GMSCameraPosition cameraPosition);

		[Export ("animateToLocation:")]
		void AnimateToLocation (CLLocationCoordinate2D location);
		
		[Export ("animateToZoom:")]
		void AnimateToZoom (float zoom);
		
		[Export ("animateToBearing:")]
		void AnimateToBearing (double bearing);
		
		[Export ("animateToViewingAngle:")]
		void AnimateToViewingAngle (double viewingAngle);
		
		[Internal]
		[Export ("addMarkerWithOptions:")] [PostGet ("Markers")]
		IntPtr InternalAddMarker (GMSMarkerOptions options);

		[Export ("markers")]
		GMSMarker [] Markers { get; }

		[Export ("addPolylineWithOptions:")] [PostGet ("Polylines")]
		GMSPolyline AddPolyline (GMSPolylineOptions options);

		[Export ("polylines")]
		GMSPolyline [] Polylines { get; }

		[Export ("addGroundOverlayWithOptions:")] [PostGet ("GroundOverlays")]
		GMSGroundOverlay AddGroundOverlay (GMSGroundOverlayOptions options);
		
		[Export ("groundOverlays")]
		GMSGroundOverlay [] GroundOverlays { get; }
		
		[Export ("clear")]
		void Clear ();	
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface GMSMarker {

		[Export ("position", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Position { get; set; }
		
		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }
		
		[Export ("snippet", ArgumentSemantic.Copy)]
		string Snippet { get; set; }
		
		[Export ("icon")]
		UIImage Icon { get; set; }
		
		[Export ("groundAnchor", ArgumentSemantic.Assign)]
		PointF GroundAnchor { get; set; }
		
		[Export ("infoWindowAnchor", ArgumentSemantic.Assign)]
		PointF InfoWindowAnchor { get; set; }
		
		[Export ("accessibilityLabel", ArgumentSemantic.Copy)]
		string AccessibilityLabel { get; set; }
		
		[Export ("userData")]
		NSObject UserData { get; set; }
		
		[Export ("remove")]
		void Remove ();
	}

	[BaseType (typeof (NSObject))]
	interface GMSMarkerOptions {

		[Export ("position", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Position { get; set; }
		
		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }
		
		[Export ("snippet", ArgumentSemantic.Copy)]
		string Snippet { get; set; }
		
		[Export ("icon")]
		UIImage Icon { get; set; }
		
		[Export ("groundAnchor", ArgumentSemantic.Assign)]
		PointF GroundAnchor { get; set; }
		
		[Export ("infoWindowAnchor", ArgumentSemantic.Assign)]
		PointF InfoWindowAnchor { get; set; }
		
		[Export ("accessibilityLabel", ArgumentSemantic.Copy)]
		string AccessibilityLabel { get; set; }
		
		[Export ("userData")]
		NSObject UserData { get; set;  }
		
		[Static]
		[Export ("options")]
		GMSMarkerOptions Options { get; }	
	}

	[BaseType (typeof (GMSPath))]
	interface GMSMutablePath {

		[Export ("addCoordinate:")]
		void AddCoordinate (CLLocationCoordinate2D coord);

		[Export ("addLatitude:longitude:")]
		void AddLatLong (double latitude, double longitude);

		[Export ("insertCoordinate:atIndex:")]
		void InsertCoordinate (CLLocationCoordinate2D coord, uint index);

		[Export ("replaceCoordinateAtIndex:withCoordinate:")]
		void ReplaceCoordinate (uint index, CLLocationCoordinate2D coord);

		[Export ("removeCoordinateAtIndex:")]
		void RemoveCoordinate (uint index);

		[Export ("removeLastCoordinate")]
		void RemoveLastCoordinate ();

		[Export ("removeAllCoordinates")]
		void RemoveAllCoordinates ();
	}

	[BaseType (typeof (NSObject))]
	interface GMSPath {

		[Static, Export ("path")]
		GMSPath Path { get; }

		[Export ("initWithPath:")]
		IntPtr Constructor (GMSPath path);

		[Export ("count")]
		uint Count { get; }

		[Export ("coordinateAtIndex:")]
		CLLocationCoordinate2D CoordinateAtIndex (uint index);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface GMSPolyline {

		[Abstract]
		[Export ("path", ArgumentSemantic.Copy)]
		GMSPath Path { get; set; }

		[Abstract]
		[Export ("color")]
		UIColor Color { get; set; }
		
		[Abstract]
		[Export ("width", ArgumentSemantic.Assign)]
		float Width { get; set; }

		[Abstract]
		[Export ("geodesic", ArgumentSemantic.Assign)]
		bool Geodesic { get; set; }
		
		[Abstract]
		[Export ("accessibilityLabel", ArgumentSemantic.Copy)]
		string AccessibilityLabel { get; set; }
		
		[Abstract]
		[Export ("remove")]
		void Remove ();
	}

	[BaseType (typeof (NSObject))]
	interface GMSPolylineOptions {

		[Export ("path", ArgumentSemantic.Copy)]
		GMSPath Path { get; set; }

		[Export ("color")]
		UIColor Color { get; set;  }

		[Export ("width", ArgumentSemantic.Assign)]
		float Width { get; set; }
		
		[Export ("geodesic", ArgumentSemantic.Assign)]
		bool Geodesic { get; set; }
		
		[Export ("accessibilityLabel", ArgumentSemantic.Copy)]
		string AccessibilityLabel { get; set; }
		
		[Static]
		[Export ("options")]
		GMSPolylineOptions Options { get; }
	}

	[BaseType (typeof (NSObject))]
	interface GMSProjection {
	
		[Export ("pointForCoordinate:")]
		PointF PointForCoordinate (CLLocationCoordinate2D coordinate);
		
		[Export ("coordinateForPoint:")]
		CLLocationCoordinate2D CoordinateForPoint (PointF point);
		
		[Export ("pointsForMeters:atCoordinate:")]
		float PointsForMeters (float meters, CLLocationCoordinate2D coordinate);

		[Export ("containsCoordinate:")]
		bool ContainsCoordinate (CLLocationCoordinate2D coordinate);

		[Export ("visibleRegion")]
		GMSVisibleRegion VisibleRegion { get; }	
	}

	[BaseType (typeof (NSObject))]
	interface GMSReverseGeocodeResult {

		[Export ("addressLine1")]
		string AddressLine1 { get; }
		
		[Export ("addressLine2")]
		string AddressLine2 { get; }	
	}

	[BaseType (typeof (NSObject))]
	interface GMSReverseGeocodeResponse {

		[Export ("firstResult")]
		GMSReverseGeocodeResult FirstResult ();
		
		[Export ("results")]
		GMSReverseGeocodeResult [] Results { get; }
	}
	
	[BaseType (typeof (NSObject))]
	interface GMSScreenshot {

		[Static, Export ("screenshotOfMainScreen")]
		UIImage ScreenshotOfMainScreen { get; }

		[Static, Export ("screenshotOfScreen:")]
		UIImage ScreenshotOfScreen (UIScreen screen);
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

	[BaseType(typeof(NSObject))]
	interface GMSUISettings {

		[Export ("scrollGestures", ArgumentSemantic.Assign)]
		bool ScrollGestures { get; set; }

		[Export ("zoomGestures", ArgumentSemantic.Assign)]
		bool ZoomGestures { get; set; }

		[Export ("tiltGestures", ArgumentSemantic.Assign)]
		bool TiltGestures { get; set; }

		[Export ("rotateGestures", ArgumentSemantic.Assign)]
		bool RotateGestures { get; set; }
	}
}

