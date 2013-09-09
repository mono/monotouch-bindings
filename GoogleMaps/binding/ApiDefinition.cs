using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using MonoTouch.CoreAnimation;

namespace Google.Maps
{
	#region CustomLib
	// This is a custom class created by me (dalexsoto) and is not part of Google Maps lib
	// But it is necesary for this binding to work
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name="libGoogleMapsExporter")]
	interface Constants
	{
		[Static, Export ("kGMSLayerCameraLatitudeKeyGlobal")]
		NSString LayerCameraLatitudeKey { get; }
		
		[Static, Export ("kGMSLayerCameraLongitudeKeyGlobal")]
		NSString LayerCameraLongitudeKey { get; }

		[Static, Export ("kGMSLayerCameraBearingKeyGlobal")]
		NSString LayerCameraBearingKey { get; }

		[Static, Export ("kGMSLayerCameraZoomLevelKeyGlobal")]
		NSString LayerCameraZoomLevelKey { get; }

		[Static, Export ("kGMSLayerCameraViewingAngleKeyGlobal")]
		NSString LayerCameraViewingAngleKey { get; }

		[Static, Export ("kGMSMaxZoomLevelGlobal")]
		float MaxZoomLevel { get; }

		[Static, Export ("kGMSMinZoomLevelGlobal")]
		float MinZoomLevel { get; }

		[Static, Export ("kGMSGroundOverlayDefaultAnchorGlobal")]
		PointF GroundOverlayDefaultAnchor { get; }

		[Static, Export ("kGMSGroundOverlayDefaultZoomGlobal")]
		float GroundOverlayDefaultZoom { get; }

		[Static, Export ("kGMSMarkerDefaultGroundAnchorGlobal")]
		PointF MarkerDefaultGroundAnchor { get; }

		[Static, Export ("kGMSMarkerDefaultInfoWindowAnchorGlobal")]
		PointF MarkerDefaultInfoWindowAnchor { get; }

		[Static, Export ("kGMSTileLayerNoTileGlobal")]
		UIImage TileLayerNoTile { get; }
	}
	#endregion

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

		[Static, Export ("fitBounds:withEdgeInsets:")]
		CameraUpdate FitBounds (CoordinateBounds bounds, UIEdgeInsets edgeInsets);

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

		[Export ("valid")]
		bool Valid { [Bind ("isValid")] get; }

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

		[Export ("includingPath:")]
		CoordinateBounds Including (Google.Maps.Path path);

		[Export ("containsCoordinate:")]
		bool ContainsCoordinate (CLLocationCoordinate2D coordinate);

		[Export ("intersectsBounds:")]
		bool IntersectsBounds (CoordinateBounds bounds);
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

		[Export ("bearing", ArgumentSemantic.Assign)]
		double Bearing { get; set; }

		[Export ("bounds")]
		CoordinateBounds Bounds { get; set; }

		[Static, Export ("groundOverlayWithPosition:icon:")]
		GroundOverlay GetGroundOverlay (CLLocationCoordinate2D position, UIImage icon);

		[Static, Export ("groundOverlayWithPosition:icon:zoomLevel:")]
		GroundOverlay GetGroundOverlay (CoordinateBounds bounds, UIImage icon, float zoomLevel);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name="GMSIndoorBuilding")]
	interface IndoorBuilding {
		[Export ("levels", ArgumentSemantic.Retain)] [PostGet ("Underground")]
		IndoorLevel [] Levels { get; }

		[Export ("defaultLevelIndex", ArgumentSemantic.Assign)]
		uint DefaultLevelIndex { get; }

		[Export ("underground", ArgumentSemantic.Assign)]
		bool Underground { [Bind ("isUnderground")] get; }
	}

	//TODO: Check IndoorDisplay Events

	[BaseType (typeof (NSObject), Name="GMSIndoorDisplayDelegate")]
	[Model]
	[Protocol]
	interface IndoorDisplayDelegate {

		[Export ("didChangeActiveBuilding:"), EventArgs ("GMSIndoorDisplayDidChangeActiveBuilding"), EventName ("ActiveBuildingChanged")]
		void DidChangeActiveBuilding (IndoorBuilding building);

		[Export ("didChangeActiveLevel:"), EventArgs ("GMSIndoorDisplayDidChangeActiveLevel"), EventName ("ActiveLevelChanged")]
		void DidChangeActiveLevel (IndoorBuilding building);
	}

	[BaseType (typeof (NSObject), Name="GMSIndoorDisplay",
	Delegates=new string [] {"WeakDelegate"},
	Events=new Type [] { typeof (IndoorDisplayDelegate) })]
	interface IndoorDisplay {

		[Wrap ("WeakDelegate")]
		IndoorDisplayDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("activeBuilding", ArgumentSemantic.Retain)]
		IndoorBuilding ActiveBuilding { get; }

		[Export ("activeLevel", ArgumentSemantic.Retain)]
		IndoorLevel ActiveLevel { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name="GMSIndoorLevel")]
	interface IndoorLevel {
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		[Export ("shortName", ArgumentSemantic.Copy)]
		string ShortName { get; }
	}


	[BaseType (typeof (CALayer), Name="GMSMapLayer")]
	interface MapLayer {
		
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
	[Protocol]
	interface MapViewDelegate {

		[Export ("mapView:willMove:"), EventArgs ("GMSWillMove"), EventName ("WillMove")]
		void WillMove (MapView mapView, bool gesture);

		[Export ("mapView:didChangeCameraPosition:"), EventArgs ("GMSCamera"), EventName ("CameraPositionChanged")]
		void DidChangeCameraPosition (MapView mapView, CameraPosition position);

		[Export ("mapView:idleAtCameraPosition:"), EventArgs ("GMSCamera"), EventName ("CameraPositionIdle")]
		void IdleAtCameraPosition (MapView mapView, CameraPosition position);
		
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

		[Export ("buildingsEnabled", ArgumentSemantic.Assign)]
		bool BuildingsEnabled {[Bind ("isBuildingsEnabled")] get; set; }

		[Export ("indoorEnabled", ArgumentSemantic.Assign)]
		bool IndoorEnabled {[Bind ("isIndoorEnabled")] get; set; }

		[Export ("indoorDisplay", ArgumentSemantic.Retain)]
		IndoorDisplay IndoorDisplay { get; }

		[Export ("settings")]
		UISettings Settings { get; }

		[Export ("accessibilityElementsHidden", ArgumentSemantic.Assign)] [New]
		bool AccessibilityElementsHidden { get; set; }

		[Export ("layer", ArgumentSemantic.Retain)] [New]
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

		[Export ("moveCamera:")]
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

		[Export ("panoramaView")]
		PanoramaView PanoramaView { get; set; }

		[Static, Export ("markerWithPosition:")]
		Marker FromPosition (CLLocationCoordinate2D position);

		[Static, Export ("markerImageWithColor:")]
		UIImage MarkerImage (UIColor color);
	}

	[BaseType (typeof (Path), Name="GMSMutablePath")]
	interface MutablePath {

		[Export ("addCoordinate:")]
		void AddCoordinate (CLLocationCoordinate2D coord);

		[Export ("addLatitude:longitude:")]
		void AddLatLon (double latitude, double longitude);

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
		MapView Map { get; [NullAllowed] set; }

		[Export ("tappable", ArgumentSemantic.Assign)]
		bool Tappable { [Bind ("isTappable")] get; set; }

		[Export ("zIndex", ArgumentSemantic.Assign)]
		int ZIndex { get; set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name="GMSPanorama")]
	interface Panorama {

		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate { get; }

		[Export ("panoramaID")]
		string PanoramaID { get; }

		[Export ("links")]
		PanoramaLink Links { get; }
	}

	[BaseType (typeof (NSObject), Name="GMSPanoramaCamera")]
	interface PanoramaCamera {

		[Export ("initWithOrientation:zoom:FOV:")]
		IntPtr Constructor (Orientation orientation, float zoom, float fov);

		[Static]
		[Export ("cameraWithOrientation:zoom:")]
		PanoramaCamera FromOrientation (Orientation orientation, float zoom);

		[Static]
		[Export ("cameraWithHeading:pitch:zoom:")]
		PanoramaCamera FromHeading (Orientation orientation, float pitch, float zoom);

		[Static]
		[Export ("cameraWithOrientation:zoom:FOV:")]
		PanoramaCamera FromOrientation (Orientation orientation, float zoom, float fov);

		[Static]
		[Export ("cameraWithHeading:pitch:zoom:FOV:")]
		PanoramaCamera FromHeading (Orientation orientation, float pitch, float zoom, float fov);

		[Export ("FOV", ArgumentSemantic.Assign)]
		float Fov { get; }

		[Export ("zoom", ArgumentSemantic.Assign)]
		float Zoom { get; }

		[Export ("orientation", ArgumentSemantic.Assign)]
		Orientation TheOrientation { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name="GMSPanoramaCameraUpdate")]
	interface PanoramaCameraUpdate {

		[Static]
		[Export ("rotateBy:")]
		PanoramaCameraUpdate Rotate (float deltaHeading);

		[Static]
		[Export ("setHeading:")]
		PanoramaCameraUpdate SetHeading (float heading);

		[Static]
		[Export ("setPitch:")]
		PanoramaCameraUpdate SetPitch (float pitch);

		[Static]
		[Export ("setZoom:")]
		PanoramaCameraUpdate SetZoom (float zoom);
	}

	//TODO: Make PanoramaKeys Available
	[DisableDefaultCtor]
	[BaseType (typeof (CALayer), Name="GMSPanoramaLayer")]
	interface PanoramaLayer {

		[Export ("cameraHeading", ArgumentSemantic.Assign)]
		float CameraHeading { get; set; }

		[Export ("cameraPitch", ArgumentSemantic.Assign)]
		float CameraPitch { get; set; }

		[Export ("cameraZoom", ArgumentSemantic.Assign)]
		float CameraZoom { get; set; }

		[Export ("cameraFOV", ArgumentSemantic.Assign)]
		float CameraFOV { get; set; }
	}

	[BaseType (typeof (NSObject), Name="GMSPanoramaLink")]
	interface PanoramaLink {

		[Export ("heading", ArgumentSemantic.Assign)]
		float Heading { get; set; }

		[Export ("panoramaID", ArgumentSemantic.Copy)]
		string PanoramaID { get; set; }
	}

	delegate void PanoramaCallback (Panorama panorama, NSError error);

	[BaseType (typeof (NSObject), Name="GMSPanoramaService")]
	interface PanoramaService {
		[Export ("requestPanoramaNearCoordinate:callback:")]
		void RequestPanorama (CLLocationCoordinate2D coordinate, PanoramaCallback callback);

		[Export ("requestPanoramaWithID:callback:")]
		void RequestPanorama (string panoramaID, PanoramaCallback callback);
	}

	[BaseType (typeof (NSObject), Name="GMSPanoramaViewDelegate")]
	[Model]
	[Protocol]
	interface PanoramaViewDelegate {

		[Export ("panoramaView:willMoveToPanoramaID:"), EventArgs ("GMSPanoramaWillMove")]
		void WillMoveToPanoramaId (PanoramaView view, string panoramaID);

		[Export ("panoramaView:didMoveToPanorama:"), EventArgs ("GMSPanoramaDidMoveToPanorama")]
		void DidMoveToPanorama (PanoramaView view, Panorama panorama);

		[Export ("panoramaView:didMoveToPanorama:nearCoordinate:"), EventArgs ("GMSPanoramaDidMoveToPanoramaNearCoordinate")]
		void DidMoveToPanoramaNearCoordinate (PanoramaView view, Panorama panorama, CLLocationCoordinate2D coordinate);

		[Export ("panoramaView:error:onMoveNearCoordinate:"), EventArgs ("GMSPanoramaonMoveNearCoordinate")]
		void OnMoveNearCoordinate (PanoramaView view, NSError error, string panoramaId);

		[Export ("panoramaView:didMoveCamera:"), EventArgs ("GMSPanoramaDidMoveCamera")]
		void DidMoveCamera (PanoramaView view, PanoramaCamera camera);

		[Export ("panoramaView:didTap:"), EventArgs ("GMSPanoramaDidTap")]
		void DidTap (PanoramaView view, PointF point);

		[Export ("panoramaView:didTapMarker:"), DelegateName ("GMSTappedPanoramaMarker"), DefaultValue(false)]
		bool TappedMarker (PanoramaView view, Marker marker);
	}

	[BaseType (typeof (UIView), Name="GMSPanoramaView",
	Delegates=new string [] {"WeakDelegate"},
	Events=new Type [] { typeof (PanoramaViewDelegate) })]
	interface PanoramaView {

		[Export ("panorama", ArgumentSemantic.Retain)][NullAllowed]
		Panorama ThePanorama { get; set; }

		[Wrap ("WeakDelegate")]
		PanoramaViewDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("setAllGesturesEnabled:")]
		void SetAllGesturesEnabled (bool enabled);

		[Export ("orientationGestures", ArgumentSemantic.Assign)]
		bool OrientationGestures { get; set; }

		[Export ("zoomGestures", ArgumentSemantic.Assign)]
		bool ZoomGestures { get; set; }

		[Export ("navigationGestures", ArgumentSemantic.Assign)]
		bool NavigationGestures { get; set; }

		[Export ("navigationLinksHidden", ArgumentSemantic.Assign)]
		bool NavigationLinksHidden { get; set; }

		[Export ("streetNamesHidden", ArgumentSemantic.Assign)]
		bool StreetNamesHidden { get; set; }

		[Export ("camera", ArgumentSemantic.Retain)][NullAllowed]
		PanoramaCamera Camera { get; set; }

		[Export ("layer", ArgumentSemantic.Retain)][New]
		PanoramaLayer Layer { get; set; }

		[Export ("animateToCamera:animationDuration:")]
		void AnimateToCamera (PanoramaCamera camera, double duration);

		[Export ("updateCamera:animationDuration:")]
		void UpdateCamera (PanoramaCameraUpdate cameraUpdate, double duration);

		[Export ("moveNearCoordinate:")]
		void MoveNearCoordinate (CLLocationCoordinate2D coordinate);

		[Export ("moveToPanoramaID:")]
		void MoveToPanoramaId (string panoramaId);

		[Export ("pointForOrientation:")]
		PointF PointForOrientation (Orientation orientation);

		[Export ("orientationForPoint:")]
		Orientation OrientationForPoint (PointF point);

		[Static]
		[Export ("panoramaWithFrame:nearCoordinate:coordinate:")]
		PanoramaView FromFrame (RectangleF frame, CLLocationCoordinate2D coordinate);
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
	[BaseType (typeof (NSObject), Name="GMSServices")]
	interface MapServices {

		[Static]
		[Export ("sharedServices")]
		MapServices SharedServices { get; }

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

	[BaseType (typeof (TileLayer), Name="GMSSyncTileLayer")]
	interface SyncTileLayer {

		[Export ("tileForX:y:zoom:")]
		UIImage Tile (uint x, uint y, uint zoom);
	}

	[BaseType (typeof (NSObject), Name="GMSTileReceiver")]
	[Model]
	[Protocol]
	interface TileReceiver {

		[Export ("receiveTileWithX:y:zoom:image:")]
		void RecieveTile (uint x, uint y, uint zoom, UIImage image);
	}

	[BaseType (typeof (NSObject), Name="GMSTileLayer")]
	interface TileLayer {

		[Export ("requestTileForX:y:zoom:image:receiver:")]
		void RequestTile (uint x, uint y, uint zoom, TileReceiver receiver);

		[Export ("clearTileCache")]
		void ClearTileCache ();

		[Export ("map")]
		MapView Map { get; [NullAllowed] set; }

		[Export ("zIndex", ArgumentSemantic.Assign)]
		int ZIndex { get; set; }

		[Export ("tileSize", ArgumentSemantic.Assign)]
		int TileSize { get; set; }
	}

	[BaseType (typeof (NSObject), Name="GMSUISettings")]
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

		[Export ("consumesGesturesInView", ArgumentSemantic.Assign)]
		bool ConsumesGesturesInView { get; set; }

		[Export ("compassButton", ArgumentSemantic.Assign)]
		bool CompassButton { get; set; }

		[Export ("myLocationButton", ArgumentSemantic.Assign)]
		bool MyLocationButton { get; set; }

		[Export ("indoorPicker", ArgumentSemantic.Assign)]
		bool IndoorPicker { get; set; }
	}

	delegate NSUrl TileURLConstructor (uint x, uint y, uint zoom);

	[DisableDefaultCtor]
	[BaseType (typeof (TileLayer), Name="GMSURLTileLayer")]
	interface UrlTileLayer {
	
		[Static, Export ("tileLayerWithURLConstructor:")]
		UrlTileLayer FromUrlConstructor (TileURLConstructor constructor);

		[Export ("userAgent", ArgumentSemantic.Copy)] [NullAllowed]
		string UserAgent { get; set; }
	}
}

