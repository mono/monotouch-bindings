using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

namespace Google.Maps
{

	[BaseType (typeof (NSObject), Name="GMSCameraPosition")]
	interface CameraPosition {

		[Export ("initWithTarget:zoom:bearing:viewingAngle:")]
		IntPtr Constructor (CLLocationCoordinate2D target, float zoom, double bearing, double viewingAngle);

		[Static, Export ("cameraWithTarget:zoom:")]
		CameraPosition FromCamera (CLLocationCoordinate2D target, float zoom);

		[Static, Export ("cameraWithLatitude:longitude:zoom:")]
		CameraPosition FromCamera (double latitude, double longitude, float zoom);

		[Static, Export ("cameraWithTarget:zoom:bearing:viewingAngle:")]
		CameraPosition FromCamera (CLLocationCoordinate2D target, float zoom, double bearing, double viewingAngle);

		[Static, Export ("cameraWithLatitude:longitude:zoom:bearing:viewingAngle:")]
		CameraPosition FromCamera (double latitude, double longitude, float zoom, double bearing, double viewingAngle);

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

	[BaseType (typeof (NSObject), Name="GMSCoordinateBounds")]
	interface CoordinateBounds {

		[Export ("northEast")]
		CLLocationCoordinate2D NorthEast { get; }

		[Export ("southWest")]
		CLLocationCoordinate2D SouthWest { get; }

		[Export ("initWithCoordinate:andCoordinate:")]
		IntPtr Constructor (CLLocationCoordinate2D coord1, CLLocationCoordinate2D coord2);
		
		[Export ("initWithRegion:")]
		IntPtr Constructor (VisibleRegion region);

		[Export ("including:")]
		CoordinateBounds Including (CLLocationCoordinate2D coordinate);

		[Export ("containsCoordinate:")]
		bool ContainsCoordinate (CLLocationCoordinate2D coordinate);
	}

	delegate void ReverseGeocodeCallback (ReverseGeocodeResponse response, NSError error);

	[BaseType (typeof (NSObject), Name="GMSGeocoder")]
	interface Geocoder {

		[Static, Export ("geocoder")]
		Geocoder SharedGeocoder { get; }

		[Export ("reverseGeocodeCoordinate:completionHandler:")]
		void ReverseGeocodeCord(CLLocationCoordinate2D coordinate, ReverseGeocodeCallback handler);
	}

	[BaseType (typeof (NSObject), Name="GMSGroundOverlay")]
	[Model]
	interface GroundOverlay {
		
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

	[BaseType (typeof (NSObject), Name="GMSGroundOverlayOptions")]
	interface GroundOverlayOptions {

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
		GroundOverlayOptions Pptions { get; }

		[Field ("kGMSGroundOverlayDefaultZoom", "__Internal")]
		float DefaultZoom { get; }
	}

	[BaseType (typeof (NSObject), Name="GMSMapViewDelegate")]
	[Model]
	interface MapViewDelegate {

		[Export ("mapView:didChangeCameraPosition:"), EventArgs ("GMSCamera"), EventName ("ChangedCameraPosition")]
		void DidChangeCameraPosition (MapView mapView, CameraPosition position);
		
		[Export ("mapView:didTapAtCoordinate:"), EventArgs ("GMSCoord"), EventName ("Tapped")]
		void DidTapAtCoordinate (MapView mapView, CLLocationCoordinate2D coordinate);
		
		[Export ("mapView:didLongPressAtCoordinate:"), EventArgs ("GMSCoord"), EventName ("LongPress")]
		void DidLongPressAtCoordinate (MapView mapView, CLLocationCoordinate2D coordinate);
		
		[Export ("mapView:didTapMarker:"), DelegateName ("GMSTappedMarker"), DefaultValue(false)]
		bool TappedMarker (MapView mapView, Marker marker);
		
		[Export ("mapView:didTapInfoWindowOfMarker:"), EventArgs ("GMSMarkerEvent"), EventName ("TapedInfo")]
		void DidTapInfoWindowOfMarker (MapView mapView, Marker marker);
		
		[Export ("mapView:markerInfoWindow:"), DelegateName ("GMSInfoFor"), DefaultValue(null)]
		UIView InfoFor (MapView mapView, Marker marker);
	}

	[BaseType (typeof (UIView), Name="GMSMapView",
	Delegates=new string [] {"WeakDelegate"},
	Events=new Type [] { typeof (MapViewDelegate) })]
	interface MapView {

		[Wrap ("WeakDelegate")]
		MapViewDelegate Delegate { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("camera")]
		CameraPosition Camera { get; set; }

		[Export ("projection")]
		Projection Projection { get; }
		
		[Export ("myLocationEnabled", ArgumentSemantic.Assign)]
		bool MyLocationEnabled { [Bind ("isMyLocationEnabled")] get; set; }
		
		[Export ("myLocation")]
		CLLocation MyLocation { get; }
		
		[Export ("selectedMarker")]
		Marker SelectedMarker { get; [NullAllowed] set; }
		
		[Export ("trafficEnabled", ArgumentSemantic.Assign)]
		bool TrafficEnabled { [Bind ("isTrafficEnabled")] get; set; }
		
		[Export ("mapType", ArgumentSemantic.Assign)]
		MapViewType MapType { get; set; }

		[Export ("settings")]
		UISettings Settings { get; }
		
		[Static]
		[Export ("mapWithFrame:camera:")]
		MapView FromCamera (RectangleF frame, CameraPosition camera);
		
		[Export ("startRendering")]
		void StartRendering ();
		
		[Export ("stopRendering")]
		void StopRendering ();

		[Export ("animateToCameraPosition:")]
		void AnimateToCameraPosition (CameraPosition cameraPosition);

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
		IntPtr InternalAddMarker (MarkerOptions options);

		[Export ("markers")]
		Marker [] Markers { get; }

		[Internal]
		[Export ("addPolylineWithOptions:")]
		IntPtr InternalAddPolyline (PolylineOptions options);

		[Export ("polylines")]
		Polyline [] Polylines { get; }

		[Internal]
		[Export ("addGroundOverlayWithOptions:")] 
		IntPtr InternalAddGroundOverlay (GroundOverlayOptions options);
		
		[Export ("groundOverlays")]
		GroundOverlay [] GroundOverlays { get; }
		
		[Export ("clear")]
		void Clear ();	
	}

	[BaseType (typeof (NSObject), Name="GMSMarker")]
	[Model]
	interface Marker {

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

	[BaseType (typeof (NSObject), Name="GMSMarkerOptions")]
	interface MarkerOptions {

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
		MarkerOptions Options { get; }	
	}

	[BaseType (typeof (Path), Name="GMSMutablePath")]
	interface MutablePath {

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

	[BaseType (typeof (NSObject), Name="GMSPath")]
	interface Path {

		[Static, Export ("path")]
		Path GetPath { get; }

		[Export ("initWithPath:")]
		IntPtr Constructor (Path path);

		[Export ("count")]
		uint Count { get; }

		[Export ("coordinateAtIndex:")]
		CLLocationCoordinate2D CoordinateAtIndex (uint index);
	}

	[BaseType (typeof (NSObject), Name="GMSPolyline")]
	[Model]
	interface Polyline {

		[Export ("path", ArgumentSemantic.Copy)]
		Path Path { get; set; }

		[Export ("color")]
		UIColor Color { get; set; }
		
		[Export ("width", ArgumentSemantic.Assign)]
		float Width { get; set; }

		[Export ("geodesic", ArgumentSemantic.Assign)]
		bool Geodesic { get; set; }
		
		[Export ("accessibilityLabel", ArgumentSemantic.Copy)]
		string AccessibilityLabel { get; set; }

		[Export ("remove")]
		void Remove ();
	}

	[BaseType (typeof (NSObject), Name="PolylineOptions")]
	interface PolylineOptions {

		[Export ("path", ArgumentSemantic.Copy)]
		Path Path { get; set; }

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
		PolylineOptions Options { get; }
	}

	[BaseType (typeof (NSObject), Name="GMSProjection")]
	interface Projection {
	
		[Export ("pointForCoordinate:")]
		PointF PointForCoordinate (CLLocationCoordinate2D coordinate);
		
		[Export ("coordinateForPoint:")]
		CLLocationCoordinate2D CoordinateForPoint (PointF point);
		
		[Export ("pointsForMeters:atCoordinate:")]
		float PointsForMeters (float meters, CLLocationCoordinate2D coordinate);

		[Export ("containsCoordinate:")]
		bool ContainsCoordinate (CLLocationCoordinate2D coordinate);

		[Export ("visibleRegion")]
		VisibleRegion VisibleRegion { get; }	
	}

	[BaseType (typeof (NSObject), Name="GMSReverseGeocodeResult")]
	interface ReverseGeocodeResult {

		[Export ("addressLine1")]
		string AddressLine1 { get; }
		
		[Export ("addressLine2")]
		string AddressLine2 { get; }	
	}

	[BaseType (typeof (NSObject), Name="GMSReverseGeocodeResponse")]
	interface ReverseGeocodeResponse {

		[Export ("firstResult")]
		ReverseGeocodeResult FirstResult ();
		
		[Export ("results")]
		ReverseGeocodeResult [] Results { get; }
	}
	
	[BaseType (typeof (NSObject), Name="GMSScreenshot")]
	interface Screenshot {

		[Static, Export ("screenshotOfMainScreen")]
		UIImage ScreenshotOfMainScreen { get; }

		[Static, Export ("screenshotOfScreen:")]
		UIImage ScreenshotOfScreen (UIScreen screen);
	}

	[BaseType(typeof (NSObject), Name="GMSServices")]
	interface MapServices {

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

	[BaseType(typeof(NSObject), Name="GMSUISettings")]
	interface UISettings {

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

