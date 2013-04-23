using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using MonoTouch.CoreAnimation;

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

		[Static, Export ("zoomAtCoordinate:forMeters:perPoints:")]
		float ZoomAtCoordinate (CLLocationCoordinate2D coord, float meters, float points);

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

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name="GMSCameraUpdate")]
	interface CameraUpdate {

		[Static, Export ("zoomIn")]
		CameraUpdate ZoomIn { get; }

		[Static, Export ("zoomOut")]
		CameraUpdate ZoomOut { get; }

		[Static, Export ("zoomBy:")]
		CameraUpdate ZoomByDelta (float delta);

		[Static, Export ("zoomTo:")]
		CameraUpdate ZoomToZoom (float zoom);

		[Static, Export ("setTarget:")]
		CameraUpdate SetTarget (CLLocationCoordinate2D target);

		[Static, Export ("setTarget:zoom:")]
		CameraUpdate SetTarget (CLLocationCoordinate2D target, float zoom);

		[Static, Export ("setCamera:")]
		CameraUpdate SetCamera (CameraPosition camera);

		[Static, Export ("fitBounds:")]
		CameraUpdate FitBounds (CoordinateBounds bounds);

		[Static, Export ("fitBounds:withPadding:")]
		CameraUpdate FitBounds (CoordinateBounds bounds, float padding);

		[Static, Export ("scrollByX:Y:")]
		CameraUpdate Scroll (float x, float y);

		[Static, Export ("zoomBy:atPoint:")]
		CameraUpdate ZoomByZoom (float zoom, PointF point);
	}

	[BaseType (typeof (Overlay), Name="GMSCircle")]
	interface Circle {

		[Export ("position", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Position { get; set; }

		[Export ("radius", ArgumentSemantic.Assign)]
		float Radius { get; set; }

		[Export ("strokeWidth", ArgumentSemantic.Assign)]
		float StrokeWidth { get; set; }

		[Export ("strokeColor")]
		UIColor StrokeColor { get; set; }

		[Export ("fillColor")]
		UIColor FillColor { get; set; }

		[Static, Export ("circleWithPosition:radius:")]
		Circle FromPosition (CLLocationCoordinate2D position, float radius);
	}

	[BaseType (typeof (NSObject), Name="GMSCoordinateBounds")]
	interface CoordinateBounds {

		[Export ("northEast")]
		CLLocationCoordinate2D NorthEast { get; }

		[Export ("southWest")]
		CLLocationCoordinate2D SouthWest { get; }

		[Export ("initWithCoordinate:coordinate:")]
		IntPtr Constructor (CLLocationCoordinate2D coord1, CLLocationCoordinate2D coord2);
		
		[Export ("initWithRegion:")]
		IntPtr Constructor (VisibleRegion region);

		[Export ("initWithPath:")]
		IntPtr Constructor (Google.Maps.Path path);

		[Export ("includingCoordinate:")]
		CoordinateBounds Including (CLLocationCoordinate2D coordinate);

		[Export ("includingBounds:")]
		CoordinateBounds Including (CoordinateBounds bounds);

		[Export ("containsCoordinate:")]
		bool ContainsCoordinate (CLLocationCoordinate2D coordinate);

		[Export ("intersectsBounds:")]
		bool IntersectsBounds (CoordinateBounds bounds);

		[Export ("valid")]
		bool Valid { [Bind ("isValid")] get; }
	}

	delegate void ReverseGeocodeCallback (ReverseGeocodeResponse response, NSError error);

	[BaseType (typeof (NSObject), Name="GMSGeocoder")]
	interface Geocoder {

		[Static, Export ("geocoder")]
		Geocoder SharedGeocoder { get; }

		[Export ("reverseGeocodeCoordinate:completionHandler:")]
		void ReverseGeocodeCord(CLLocationCoordinate2D coordinate, ReverseGeocodeCallback handler);
	}

	[BaseType (typeof (Overlay), Name="GMSGroundOverlay")]
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

		[Static, Export ("groundOverlayWithPosition:icon:")]
		GroundOverlay GetGroundOverlay (CLLocationCoordinate2D position, UIImage icon);

		// HACK: This is to not break Release builds -> Avoid Symbol not found
		// This is to avoid user to setup --nosymbolstrip:kGMSGroundOverlayDefaultAnchor etc.
		[Field ("kGMSGroundOverlayDefaultAnchor", "__Internal")][Internal]
		NSString DefaultAnchor_Do_Not_Use { get; }

		[Field ("kGMSGroundOverlayDefaultZoom", "__Internal")][Internal]
		NSString DefaultZoom_Do_Not_Use { get; }
	}

	[BaseType (typeof (CALayer), Name="GMSMapLayer")]
	interface MapLayer {

		[Field ("kGMSLayerCameraLatitudeKey", "__Internal")]
		NSString CameraLatitudeKey { get; }

		[Field ("kGMSLayerCameraLongitudeKey", "__Internal")]
		NSString CameraLongitudeKey { get; }

		[Field ("kGMSLayerCameraBearingKey", "__Internal")]
		NSString CameraBearingKey { get; }

		[Field ("kGMSLayerCameraZoomLevelKey", "__Internal")]
		NSString CameraZoomLevelKey { get; }

		[Field ("kGMSLayerCameraViewingAngleKey", "__Internal")]
		NSString CameraViewingAngleKey { get; }

		[Export ("cameraLatitude", ArgumentSemantic.Assign)]
		double CameraLatitude { get; set; }

		[Export ("cameraLongitude", ArgumentSemantic.Assign)]
		double CameraLongitude { get; set; }

		[Export ("cameraBearing", ArgumentSemantic.Assign)]
		double CameraBearing { get; set; }

		[Export ("cameraZoomLevel", ArgumentSemantic.Assign)]
		float CameraZoomLevel { get; set; }

		[Export ("cameraViewingAngle", ArgumentSemantic.Assign)]
		double CameraViewingAngle { get; set; }
	}

	[BaseType (typeof (NSObject), Name="GMSMapViewDelegate")]
	[Model]
	interface MapViewDelegate {

		[Export ("mapView:didChangeCameraPosition:"), EventArgs ("GMSCamera"), EventName ("CameraPositionChanged")]
		void DidChangeCameraPosition (MapView mapView, CameraPosition position);
		
		[Export ("mapView:didTapAtCoordinate:"), EventArgs ("GMSCoord"), EventName ("Tapped")]
		void DidTapAtCoordinate (MapView mapView, CLLocationCoordinate2D coordinate);
		
		[Export ("mapView:didLongPressAtCoordinate:"), EventArgs ("GMSCoord"), EventName ("LongPress")]
		void DidLongPressAtCoordinate (MapView mapView, CLLocationCoordinate2D coordinate);
		
		[Export ("mapView:didTapMarker:"), DelegateName ("GMSTappedMarker"), DefaultValue(false)]
		bool TappedMarker (MapView mapView, Marker marker);
		
		[Export ("mapView:didTapInfoWindowOfMarker:"), EventArgs ("GMSMarkerEvent"), EventName ("TappedInfo")]
		void DidTapInfoWindowOfMarker (MapView mapView, Marker marker);

		[Export ("mapView:didTapOverlay:"), EventArgs ("GMSOverlayEvent"), EventName ("TappedOverlay")]
		void DidTapOverlay (MapView mapView, Overlay overlay);

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

		[Export ("layer")] [New]
		MapLayer Layer { get; }
		
		[Static]
		[Export ("mapWithFrame:camera:")]
		MapView FromCamera (RectangleF frame, CameraPosition camera);
		
		[Export ("startRendering")]
		void StartRendering ();
		
		[Export ("stopRendering")]
		void StopRendering ();

		[Export ("clear")]
		void Clear ();

		[Export ("moveCamera")]
		void MoveCamera (CameraUpdate update);

		// MapView + Overlays 

		[Export ("markers"), Obsolete ("Maintain your own references to overlays that you have added to a MapView")]
		Marker [] Markers { get; }
		
		[Export ("groundOverlays"), Obsolete ("Maintain your own references to overlays that you have added to a MapView")]
		GroundOverlay [] GroundOverlays { get; }
		
		[Export ("polylines"), Obsolete ("Maintain your own references to overlays that you have added to a MapView")]
		Polyline [] Polylines { get; }
	}

	[BaseType (typeof (MapView))]
	[Category]
	interface MapViewAnimation {

		[Export ("animateToCameraPosition:")]
		void Animate (CameraPosition cameraPosition);

		[Export ("animateToLocation:")]
		void Animate (CLLocationCoordinate2D location);

		[Export ("animateToZoom:")]
		void Animate (float zoom);

		[Export ("animateToBearing:")]
		void AnimateToBearing (double bearing);

		[Export ("animateToViewingAngle:")]
		void Animate (double viewingAngle);

		[Export ("animateWithCameraUpdate:")]
		void Animate (CameraUpdate cameraUpdate);
	}

	[BaseType (typeof (Overlay), Name="GMSMarker")]
	interface Marker {

		[Export ("position", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Position { get; set; }
		
		[Export ("snippet", ArgumentSemantic.Copy)]
		string Snippet { get; set; }
		
		[Export ("icon")]
		UIImage Icon { get; set; }
		
		[Export ("groundAnchor", ArgumentSemantic.Assign)]
		PointF GroundAnchor { get; set; }
		
		[Export ("infoWindowAnchor", ArgumentSemantic.Assign)]
		PointF InfoWindowAnchor { get; set; }

		[Export ("animated", ArgumentSemantic.Assign)]
		bool Animated { [Bind ("isAnimated")] get; set; }
		
		[Export ("userData")]
		NSObject UserData { get; set; }

		[Static, Export ("markerWithPosition:")]
		Marker FromPosition (CLLocationCoordinate2D position);

		[Static, Export ("markerImageWithColor:")]
		UIImage MarkerImage (UIColor color);

		// HACK: This is to not break Release builds -> Avoid Symbol not found
		// This is to avoid user to setup --nosymbolstrip:kGMSGroundOverlayDefaultAnchor etc.
		[Field ("kGMSMarkerDefaultGroundAnchor", "__Internal")][Internal]
		NSString DefaultGroundAnchor_Do_Not_Use { get; }
		
		[Field ("kGMSMarkerDefaultInfoWindowAnchor", "__Internal")][Internal]
		NSString DefaultInfoWindowAnchor_Do_Not_Use { get; }
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

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name="GMSOverlay")]
	interface Overlay {

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		[Export ("map")]
		MapView Map { get; set; }

		[Export ("tappable", ArgumentSemantic.Assign)]
		bool Tappable { [Bind ("isTappable")] get; set; }
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

		[Static, Export ("pathFromEncodedPath:")]
		Path FromEncodedPath (string encodedPath);

		[Export ("encodedPath")]
		string EncodedPath { get; }
	}

	[BaseType (typeof (Overlay), Name="GMSPolygon")]
	interface Polygon {

		[Export ("path", ArgumentSemantic.Copy)]
		Path Path { get; set; }

		[Export ("strokeWidth", ArgumentSemantic.Assign)]
		float StrokeWidth { get; set; }

		[Export ("strokeColor")]
		UIColor StrokeColor { get; set; }

		[Export ("fillColor")]
		UIColor FillColor { get; set; }

		[Export ("geodesic", ArgumentSemantic.Assign)]
		bool Geodesic { get; set; }

		[Static, Export ("polygonWithPath:")]
		Polygon FromPath (Google.Maps.Path path);
	}

	[BaseType (typeof (Overlay), Name="GMSPolyline")]
	interface Polyline {

		[Export ("path", ArgumentSemantic.Copy)]
		Path Path { get; set; }

		[Export ("strokeWidth", ArgumentSemantic.Assign)]
		float StrokeWidth { get; set; }
		
		[Export ("strokeColor")]
		UIColor StrokeColor { get; set; }

		[Export ("geodesic", ArgumentSemantic.Assign)]
		bool Geodesic { get; set; }

		[Static, Export ("polylineWithPath:")]
		Polyline FromPath (Google.Maps.Path path);
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
		ReverseGeocodeResult FirstResult { get; }
		
		[Export ("results")]
		ReverseGeocodeResult [] Results { get; }
	}

	[DisableDefaultCtor]
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

		[Export ("setAllGesturesEnabled:")]
		void SetAllGesturesEnabled (bool enabled);

		[Export ("scrollGestures", ArgumentSemantic.Assign)]
		bool ScrollGestures { get; set; }

		[Export ("zoomGestures", ArgumentSemantic.Assign)]
		bool ZoomGestures { get; set; }

		[Export ("tiltGestures", ArgumentSemantic.Assign)]
		bool TiltGestures { get; set; }

		[Export ("rotateGestures", ArgumentSemantic.Assign)]
		bool RotateGestures { get; set; }

		[Export ("compassButton", ArgumentSemantic.Assign)]
		bool CompassButton { get; set; }

		[Export ("myLocationButton", ArgumentSemantic.Assign)]
		bool MyLocationButton { get; set; }
	}
}

