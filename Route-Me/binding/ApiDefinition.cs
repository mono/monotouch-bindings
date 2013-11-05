using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using MonoTouch.CoreAnimation;
using MonoTouch.CoreGraphics;

namespace RouteMe
{
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_types
	//

	#region MapView

	[BaseType (typeof (UIView))]
	interface RMMapView {
		
		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }		
		
		[Wrap ("WeakDelegate")]
		RMMapViewDelegate Delegate { get; set; }
		
		// -------- PROPERTIES
		
		//@property (nonatomic, assign) IBOutlet id <RMMapViewDelegate>delegate;
		//[Export ("id")]
		//IBOutlet Id { get; set;  }
		
		//@property (nonatomic, assign) BOOL enableDragging;
		[Export ("enableDragging")]
		bool EnableDragging { get; set;  }
		
		//@property (nonatomic, assign) BOOL enableBouncing;
		[Export ("enableBouncing")]
		bool EnableBouncing { get; set;  }
		
		//@property (nonatomic, assign) BOOL zoomingInPivotsAroundCenter;
		[Export ("zoomingInPivotsAroundCenter")]
		bool ZoomingInPivotsAroundCenter { get; set;  }
		
		//@property (nonatomic, assign) RMMapDecelerationMode decelerationMode;
		[Export ("decelerationMode")]
		RMMapDecelerationMode DecelerationMode { get; set;  }
		
		//@property (nonatomic, assign)   double metersPerPixel;
		[Export ("metersPerPixel")]
		double MetersPerPixel { get; set;  }
		
		//@property (nonatomic, readonly) double scaledMetersPerPixel;
		[Export ("scaledMetersPerPixel")]
		double ScaledMetersPerPixel { get;  }
		
		//@property (nonatomic, readonly) double scaleDenominator; 
		[Export ("scaleDenominator")]
		double ScaleDenominator { get;  }
		
		//@property (nonatomic, readonly) float screenScale;
		[Export ("screenScale")]
		float ScreenScale { get;  }
		
		//@property (nonatomic, assign)   BOOL adjustTilesForRetinaDisplay;
		[Export ("adjustTilesForRetinaDisplay")]
		bool AdjustTilesForRetinaDisplay { get; set;  }
		
		//@property (nonatomic, readonly) float adjustedZoomForRetinaDisplay; 
		[Export ("adjustedZoomForRetinaDisplay")]
		float AdjustedZoomForRetinaDisplay { get;  }
		
		//@property (nonatomic, assign) UIViewController *viewControllerPresentingAttribution;
		[Export ("viewControllerPresentingAttribution")]
		UIViewController ViewControllerPresentingAttribution { get; set;  }
		
		//@property (nonatomic, assign) NSUInteger missingTilesDepth;
		[Export ("missingTilesDepth")]
		uint MissingTilesDepth { get; set;  }
		
		//@property (nonatomic, assign) NSUInteger boundingMask;
		[Export ("boundingMask")]
		uint BoundingMask { get; set;  }
		
		//@property (nonatomic, retain) UIView *backgroundView;
		[Export ("backgroundView", ArgumentSemantic.Retain)]
		UIView BackgroundView { get; set;  }
		
		//@property (nonatomic, assign) BOOL debugTiles;
		[Export ("debugTiles")]
		bool DebugTiles { get; set;  }
		
		//@property (nonatomic, assign) CLLocationCoordinate2D centerCoordinate;
		[Export ("centerCoordinate")]
		CLLocationCoordinate2D CenterCoordinate { get; set;  }
		
		//@property (nonatomic, assign) RMProjectedPoint centerProjectedPoint;
		[Export ("centerProjectedPoint")]
		RMProjectedPoint CenterProjectedPoint { get; set;  }
		
		//@property (nonatomic, assign) float zoom;
		[Export ("zoom")]
		float Zoom { get; set;  }
		
		//@property (nonatomic, assign) float minZoom;
		[Export ("minZoom")]
		float MinZoom { get; set;  }
		
		//@property (nonatomic, assign) float maxZoom;
		[Export ("maxZoom")]
		float MaxZoom { get; set;  }
		
		//@property (nonatomic, assign) RMProjectedRect projectedBounds;
		[Export ("projectedBounds")]
		RMProjectedRect ProjectedBounds { get; set;  }
		
		//@property (nonatomic, readonly) RMProjectedPoint projectedOrigin;
		[Export ("projectedOrigin")]
		RMProjectedPoint ProjectedOrigin { get;  }
		
		//@property (nonatomic, readonly) RMProjectedSize projectedViewSize;
		[Export ("projectedViewSize")]
		RMProjectedSize ProjectedViewSize { get;  }
		
		//@property (nonatomic, readonly) NSArray *annotations;
		[Export ("annotations")]
		NSArray Annotations { get;  }
		
		//@property (nonatomic, readonly) NSArray *visibleAnnotations;
		[Export ("visibleAnnotations")]
		NSArray VisibleAnnotations { get;  }
		
		//@property (nonatomic, retain) RMQuadTree *quadTree;
		//[Export ("quadTree", ArgumentSemantic.Retain)]
		//RMQuadTree QuadTree { get; set;  }
		
		//@property (nonatomic, assign) BOOL enableClustering;
		[Export ("enableClustering")]
		bool EnableClustering { get; set;  }
		
		//@property (nonatomic, assign) BOOL positionClusterMarkersAtTheGravityCenter;
		[Export ("positionClusterMarkersAtTheGravityCenter")]
		bool PositionClusterMarkersAtTheGravityCenter { get; set;  }
		
		//@property (nonatomic, assign) BOOL orderClusterMarkersAboveOthers;
		[Export ("orderClusterMarkersAboveOthers")]
		bool OrderClusterMarkersAboveOthers { get; set;  }
		
		//@property (nonatomic, assign) CGSize clusterMarkerSize;
		[Export ("clusterMarkerSize")]
		System.Drawing.SizeF ClusterMarkerSize { get; set;  }
		
		//@property (nonatomic, assign) CGSize clusterAreaSize;
		[Export ("clusterAreaSize")]
		System.Drawing.SizeF ClusterAreaSize { get; set;  }
		
		//@property (nonatomic, readonly) RMTileSourcesContainer *tileSourcesContainer;
		[Export ("tileSourcesContainer")]
		RMTileSourcesContainer TileSourcesContainer { get;  }
		
		//@property (nonatomic, retain) NSArray *tileSources;
		[Export ("tileSources", ArgumentSemantic.Retain)]
		NSArray TileSources { get; set;  }
		
		//@property (nonatomic, retain)   RMTileCache *tileCache;
		[Export ("tileCache", ArgumentSemantic.Retain)]
		RMTileCache TileCache { get; set;  }
		
		//@property (nonatomic, readonly) RMProjection *projection;
		[Export ("projection")]
		RMProjection Projection { get;  }
		
		//@property (nonatomic, readonly) id <RMMercatorToTileProjection> mercatorToTileProjection;
//		[Export ("<RMMercatorToTileProjection>")]
//		IntPtr <RMMercatorToTileProjection> { get;  }
		
		//@property (nonatomic, assign)   BOOL showsUserLocation;
		[Export ("showsUserLocation")]
		bool ShowsUserLocation { get; set;  }
		
		//@property (nonatomic, readonly) RMUserLocation *userLocation;
		[Export ("userLocation")]
		RMUserLocation UserLocation { get;  }
		
		//@property (nonatomic, readonly, getter=isUserLocationVisible) BOOL userLocationVisible;
		[Export ("userLocationVisible")]
		bool UserLocationVisible { [Bind ("isUserLocationVisible")] get;  }
		
		//@property (nonatomic, assign)   RMUserTrackingMode userTrackingMode;
		[Export ("userTrackingMode")]
		RMUserTrackingMode UserTrackingMode { get; set;  }
		
		//@property (nonatomic, assign)   BOOL displayHeadingCalibration;
		[Export ("displayHeadingCalibration")]
		bool DisplayHeadingCalibration { get; set;  }
		
		// -------- CONSTRUCTORS
		
		//- (id)initWithFrame:(CGRect)frame andTilesource:(id <RMTileSource>)newTilesource;
		[Export ("initWithFrame:andTilesource:")]
		IntPtr Constructor (System.Drawing.RectangleF frame, IntPtr newTilesource);
		
		//NOTE: There is another multi-param ctor not bound yet
		
		// -------- METHODS
		
		//- (void)setFrame:(CGRect)frame;
		[Export ("setFrame:")]
		void SetFrame (System.Drawing.RectangleF frame);
		
		//- (void)setCenterCoordinate:(CLLocationCoordinate2D)coordinate animated:(BOOL)animated;
		[Export ("setCenterCoordinate:animated:")]
		void SetCenterCoordinate (CLLocationCoordinate2D coordinate, bool animated);
		
		//- (void)setCenterProjectedPoint:(RMProjectedPoint)aPoint animated:(BOOL)animated;
		[Export ("setCenterProjectedPoint:animated:")]
		void SetCenterProjectedPoint (RMProjectedPoint aPoint, bool animated);
		
		//- (void)moveBy:(CGSize)delta;
		[Export ("moveBy:")]
		void MoveBy (System.Drawing.SizeF delta);
		
		//- (void)setProjectedBounds:(RMProjectedRect)boundsRect animated:(BOOL)animated;
		[Export ("setProjectedBounds:animated:")]
		void SetProjectedBounds (RMProjectedRect boundsRect, bool animated);
		
		//- (void)zoomByFactor:(float)zoomFactor near:(CGPoint)center animated:(BOOL)animated;
		[Export ("zoomByFactor:near:animated:")]
		void ZoomByFactor (float zoomFactor, System.Drawing.PointF center, bool animated);
		
		//- (void)zoomInToNextNativeZoomAt:(CGPoint)pivot animated:(BOOL)animated;
		[Export ("zoomInToNextNativeZoomAt:animated:")]
		void ZoomInToNextNativeZoomAt (System.Drawing.PointF pivot, bool animated);
		
		//- (void)zoomOutToNextNativeZoomAt:(CGPoint)pivot animated:(BOOL)animated;
		[Export ("zoomOutToNextNativeZoomAt:animated:")]
		void ZoomOutToNextNativeZoomAt (System.Drawing.PointF pivot, bool animated);
		
		//- (void)zoomWithLatitudeLongitudeBoundsSouthWest:(CLLocationCoordinate2D)southWest northEast:(CLLocationCoordinate2D)northEast animated:(BOOL)animated;
		[Export ("zoomWithLatitudeLongitudeBoundsSouthWest:northEast:animated:")]
		void ZoomWithLatitudeLongitudeBoundsSouthWest (CLLocationCoordinate2D southWest, CLLocationCoordinate2D northEast, bool animated);
		
		//- (float)nextNativeZoomFactor;
//		[Field ("nextNativeZoomFactor")]
//		float NextNativeZoomFactor { get; }
		
		//- (float)previousNativeZoomFactor;
//		[Field ("previousNativeZoomFactor")]
//		float PreviousNativeZoomFactor { get; }
		
		//- (void)setMetersPerPixel:(double)newMetersPerPixel animated:(BOOL)animated;
		[Export ("setMetersPerPixel:animated:")]
		void SetMetersPerPixel (double newMetersPerPixel, bool animated);
		
		//- (RMSphericalTrapezium)latitudeLongitudeBoundingBox;
		[Export ("latitudeLongitudeBoundingBox")]
		RMSphericalTrapezium LatitudeLongitudeBoundingBox { get; }
		
		//- (RMSphericalTrapezium)latitudeLongitudeBoundingBoxFor:(CGRect) rect;
		[Export ("latitudeLongitudeBoundingBoxFor:")]
		RMSphericalTrapezium LatitudeLongitudeBoundingBoxFor (System.Drawing.RectangleF rect);
		
		//- (BOOL)tileSourceBoundsContainProjectedPoint:(RMProjectedPoint)point;
		[Export ("tileSourceBoundsContainProjectedPoint:")]
		bool TileSourceBoundsContainProjectedPoint (RMProjectedPoint point);
		
		//- (void)setConstraintsSouthWest:(CLLocationCoordinate2D)southWest northEast:(CLLocationCoordinate2D)northEast;
		[Export ("setConstraintsSouthWest:northEast:")]
		void SetConstraintsSouthWest (CLLocationCoordinate2D southWest, CLLocationCoordinate2D northEast);
		
		//- (void)setProjectedConstraintsSouthWest:(RMProjectedPoint)southWest northEast:(RMProjectedPoint)northEast;
		[Export ("setProjectedConstraintsSouthWest:northEast:")]
		void SetProjectedConstraintsSouthWest (RMProjectedPoint southWest, RMProjectedPoint northEast);
		
		//- (UIImage *)takeSnapshot;
		[Export ("takeSnapshot")]
		UIImage TakeSnapshot { get; }
		
		//- (UIImage *)takeSnapshotAndIncludeOverlay:(BOOL)includeOverlay;
		[Export ("takeSnapshotAndIncludeOverlay:")]
		UIImage TakeSnapshotAndIncludeOverlay (bool includeOverlay);
		
		//- (void)addAnnotation:(RMAnnotation *)annotation;
		[Export ("addAnnotation:")]
		void AddAnnotation (RMAnnotation annotation);
		
		//- (void)addAnnotations:(NSArray *)annotations;
		[Export ("addAnnotations:")]
		void AddAnnotations (NSArray annotations);
		
		//- (void)removeAnnotation:(RMAnnotation *)annotation;
		[Export ("removeAnnotation:")]
		void RemoveAnnotation (RMAnnotation annotation);
		
		//- (void)removeAnnotations:(NSArray *)annotations;
		[Export ("removeAnnotations:")]
		void RemoveAnnotations (NSArray annotations);
		
		//- (void)removeAllAnnotations;
		[Export ("removeAllAnnotations")]
		void RemoveAllAnnotations ();
		
		//- (CGPoint)mapPositionForAnnotation:(RMAnnotation *)annotation;
		[Export ("mapPositionForAnnotation:")]
		System.Drawing.PointF MapPositionForAnnotation (RMAnnotation annotation);
		
		//- (void)addTileSource:(id <RMTileSource>)tileSource;
		[Export ("addTileSource:")]
		void AddTileSource (IntPtr tileSource);
		
		//- (void)addTileSource:(id<RMTileSource>)tileSource atIndex:(NSUInteger)index;
		[Export ("addTileSource:atIndex:")]
		void AddTileSource (IntPtr tileSource, uint index);
		
		//- (void)removeTileSource:(id <RMTileSource>)tileSource;
		[Export ("removeTileSource:")]
		void RemoveTileSource (IntPtr tileSource);
		
		//- (void)removeTileSourceAtIndex:(NSUInteger)index;
		[Export ("removeTileSourceAtIndex:")]
		void RemoveTileSourceAtIndex (uint index);
		
		//- (void)moveTileSourceAtIndex:(NSUInteger)fromIndex toIndex:(NSUInteger)toIndex;
		[Export ("moveTileSourceAtIndex:toIndex:")]
		void MoveTileSourceAtIndex (uint fromIndex, uint toIndex);
		
		//- (void)setHidden:(BOOL)isHidden forTileSource:(id <RMTileSource>)tileSource;
		[Export ("setHidden:forTileSource:")]
		void SetHidden (bool isHidden, IntPtr tileSource);
		
		//- (void)setHidden:(BOOL)isHidden forTileSourceAtIndex:(NSUInteger)index;
		[Export ("setHidden:forTileSourceAtIndex:")]
		void SetHidden (bool isHidden, uint index);
		
		//- (void)reloadTileSource:(id <RMTileSource>)tileSource;
		[Export ("reloadTileSource:")]
		void ReloadTileSource (IntPtr tileSource);
		
		//- (void)reloadTileSourceAtIndex:(NSUInteger)index;
		[Export ("reloadTileSourceAtIndex:")]
		void ReloadTileSourceAtIndex (uint index);
		
		//-(void)removeAllCachedImages;
		[Export ("removeAllCachedImages")]
		void RemoveAllCachedImages ();
		
		//- (CGPoint)projectedPointToPixel:(RMProjectedPoint)projectedPoint;
		[Export ("projectedPointToPixel:")]
		System.Drawing.PointF ProjectedPointToPixel (RMProjectedPoint projectedPoint);
		
		//- (CGPoint)coordinateToPixel:(CLLocationCoordinate2D)coordinate;
		[Export ("coordinateToPixel:")]
		System.Drawing.PointF CoordinateToPixel (CLLocationCoordinate2D coordinate);
		
		//- (RMProjectedPoint)pixelToProjectedPoint:(CGPoint)pixelCoordinate;
		[Export ("pixelToProjectedPoint:")]
		RMProjectedPoint PixelToProjectedPoint (System.Drawing.PointF pixelCoordinate);
		
		//- (CLLocationCoordinate2D)pixelToCoordinate:(CGPoint)pixelCoordinate;
		[Export ("pixelToCoordinate:")]
		CLLocationCoordinate2D PixelToCoordinate (System.Drawing.PointF pixelCoordinate);
		
		//- (RMProjectedPoint)coordinateToProjectedPoint:(CLLocationCoordinate2D)coordinate;
		[Export ("coordinateToProjectedPoint:")]
		RMProjectedPoint CoordinateToProjectedPoint (CLLocationCoordinate2D coordinate);
		
		//- (CLLocationCoordinate2D)projectedPointToCoordinate:(RMProjectedPoint)projectedPoint;
		[Export ("projectedPointToCoordinate:")]
		CLLocationCoordinate2D ProjectedPointToCoordinate (RMProjectedPoint projectedPoint);
		
		//- (RMProjectedSize)viewSizeToProjectedSize:(CGSize)screenSize;
		[Export ("viewSizeToProjectedSize:")]
		RMProjectedSize ViewSizeToProjectedSize (System.Drawing.SizeF screenSize);
		
		//- (CGSize)projectedSizeToViewSize:(RMProjectedSize)projectedSize;
		[Export ("projectedSizeToViewSize:")]
		System.Drawing.SizeF ProjectedSizeToViewSize (RMProjectedSize projectedSize);
		
		//- (CLLocationCoordinate2D)normalizeCoordinate:(CLLocationCoordinate2D)coordinate;
		[Export ("normalizeCoordinate:")]
		CLLocationCoordinate2D NormalizeCoordinate (CLLocationCoordinate2D coordinate);
		
		//- (RMTile)tileWithCoordinate:(CLLocationCoordinate2D)coordinate andZoom:(int)zoom;
		[Export ("tileWithCoordinate:andZoom:")]
		RMTile TileWithCoordinate (CLLocationCoordinate2D coordinate, int zoom);
		
		//- (RMSphericalTrapezium)latitudeLongitudeBoundingBoxForTile:(RMTile)aTile;
		//[Export ("latitudeLongitudeBoundingBoxForTile:")]
		//RMSphericalTrapezium LatitudeLongitudeBoundingBoxForTile (RMTile aTile);
		
		//- (void)setUserTrackingMode:(RMUserTrackingMode)mode animated:(BOOL)animated;
		[Export ("setUserTrackingMode:animated:")]
		void SetUserTrackingMode (RMUserTrackingMode mode, bool animated);		
	}
	
	[Model, BaseType (typeof (NSObject))]
	interface RMMapViewDelegate {
		
		//- (RMMapLayer *)mapView:(RMMapView *)mapView layerForAnnotation:(RMAnnotation *)annotation;
		[Export ("mapView:layerForAnnotation:")]
		RMMapLayer LayerForAnnotation (RMMapView mapView, RMAnnotation annotation);
		
		//- (void)mapView:(RMMapView *)mapView willHideLayerForAnnotation:(RMAnnotation *)annotation;
		[Export ("mapView:willHideLayerForAnnotation:")]
		void WillHideLayerForAnnotation (RMMapView mapView, RMAnnotation annotation);
		
		//- (void)mapView:(RMMapView *)mapView didHideLayerForAnnotation:(RMAnnotation *)annotation;
		[Export ("mapView:didHideLayerForAnnotation:")]
		void DidHideLayerForAnnotation (RMMapView mapView, RMAnnotation annotation);
		
		//- (void)beforeMapMove:(RMMapView *)map byUser:(BOOL)wasUserAction;
		[Export ("beforeMapMove:byUser:")]
		void BeforeMapMove (RMMapView map, bool wasUserAction);
		
		//- (void)afterMapMove:(RMMapView *)map byUser:(BOOL)wasUserAction;
		[Export ("afterMapMove:byUser:")]
		void AfterMapMove (RMMapView map, bool wasUserAction);
		
		//- (void)beforeMapZoom:(RMMapView *)map byUser:(BOOL)wasUserAction;
		[Export ("beforeMapZoom:byUser:")]
		void BeforeMapZoom (RMMapView map, bool wasUserAction);
		
		//- (void)afterMapZoom:(RMMapView *)map byUser:(BOOL)wasUserAction;
		[Export ("afterMapZoom:byUser:")]
		void AfterMapZoom (RMMapView map, bool wasUserAction);
		
		//- (void)mapViewRegionDidChange:(RMMapView *)mapView;
		[Export ("mapViewRegionDidChange:")]
		void MapViewRegionDidChange (RMMapView mapView);
		
		//- (void)doubleTapOnMap:(RMMapView *)map at:(CGPoint)point;
		[Export ("doubleTapOnMap:at:")]
		void DoubleTapOnMap (RMMapView map, System.Drawing.PointF point);
		
		//- (void)singleTapOnMap:(RMMapView *)map at:(CGPoint)point;
		[Export ("singleTapOnMap:at:")]
		void SingleTapOnMap (RMMapView map, System.Drawing.PointF point);
		
		//- (void)singleTapTwoFingersOnMap:(RMMapView *)map at:(CGPoint)point;
		[Export ("singleTapTwoFingersOnMap:at:")]
		void SingleTapTwoFingersOnMap (RMMapView map, System.Drawing.PointF point);
		
		//- (void)longSingleTapOnMap:(RMMapView *)map at:(CGPoint)point;
		[Export ("longSingleTapOnMap:at:")]
		void LongSingleTapOnMap (RMMapView map, System.Drawing.PointF point);
		
		//- (void)tapOnAnnotation:(RMAnnotation *)annotation onMap:(RMMapView *)map;
		[Export ("tapOnAnnotation:onMap:")]
		void TapOnAnnotation (RMAnnotation annotation, RMMapView map);
		
		//- (void)doubleTapOnAnnotation:(RMAnnotation *)annotation onMap:(RMMapView *)map;
		[Export ("doubleTapOnAnnotation:onMap:")]
		void DoubleTapOnAnnotation (RMAnnotation annotation, RMMapView map);
		
		//- (void)tapOnLabelForAnnotation:(RMAnnotation *)annotation onMap:(RMMapView *)map;
		[Export ("tapOnLabelForAnnotation:onMap:")]
		void TapOnLabelForAnnotation (RMAnnotation annotation, RMMapView map);
		
		//- (void)doubleTapOnLabelForAnnotation:(RMAnnotation *)annotation onMap:(RMMapView *)map;
		[Export ("doubleTapOnLabelForAnnotation:onMap:")]
		void DoubleTapOnLabelForAnnotation (RMAnnotation annotation, RMMapView map);
		
		//- (BOOL)mapView:(RMMapView *)map shouldDragAnnotation:(RMAnnotation *)annotation;
		[Export ("mapView:shouldDragAnnotation:")]
		bool MapViewShouldDragAnnotation (RMMapView map, RMAnnotation annotation);
		
		//- (void)mapView:(RMMapView *)map didDragAnnotation:(RMAnnotation *)annotation withDelta:(CGPoint)delta;
		[Export ("mapView:didDragAnnotation:withDelta:")]
		void MapView (RMMapView map, RMAnnotation annotation, System.Drawing.PointF delta);
		
		//- (void)mapView:(RMMapView *)map didEndDragAnnotation:(RMAnnotation *)annotation;
		[Export ("mapView:didEndDragAnnotation:")]
		void MapViewDidEndDragAnnotation (RMMapView map, RMAnnotation annotation);
		
		//- (void)mapViewWillStartLocatingUser:(RMMapView *)mapView;
		[Export ("mapViewWillStartLocatingUser:")]
		void MapViewWillStartLocatingUser (RMMapView mapView);
		
		//- (void)mapViewDidStopLocatingUser:(RMMapView *)mapView;
		[Export ("mapViewDidStopLocatingUser:")]
		void MapViewDidStopLocatingUser (RMMapView mapView);
		
		//- (void)mapView:(RMMapView *)mapView didUpdateUserLocation:(RMUserLocation *)userLocation;
		[Export ("mapView:didUpdateUserLocation:")]
		void MapView (RMMapView mapView, RMUserLocation userLocation);
		
		//- (void)mapView:(RMMapView *)mapView didFailToLocateUserWithError:(NSError *)error;
		[Export ("mapView:didFailToLocateUserWithError:")]
		void MapView (RMMapView mapView, NSError error);
		
		//- (void)mapView:(RMMapView *)mapView didChangeUserTrackingMode:(RMUserTrackingMode)mode animated:(BOOL)animated;
		[Export ("mapView:didChangeUserTrackingMode:animated:")]
		void MapView (RMMapView mapView, RMUserTrackingMode mode, bool animated);
	}

	#endregion

	#region Projections
	
	[BaseType (typeof (NSObject))]
	interface RMProjection {
		
		// -------- PROPERTIES
		
		//+ (RMProjection *)googleProjection;
		//		[Static, Field ("googleProjection")]
		//		RMProjection GoogleProjection { get; }
		
		//+ (RMProjection *)EPSGLatLong;
		//		[Static, Field ("EPSGLatLong")]
		//		RMProjection EPSGLatLong { get; }
		
		//@property (nonatomic, readonly) RMProjectedRect planetBounds;
		[Export ("planetBounds")]
		RMProjectedRect PlanetBounds { get;  }
		
		//@property (nonatomic, assign)   BOOL projectionWrapsHorizontally;
		[Export ("projectionWrapsHorizontally")]
		bool ProjectionWrapsHorizontally { get; set;  }
		
		// -------- CONSTRUCTORS
		
		//- (id)initWithString:(NSString *)proj4String inBounds:(RMProjectedRect)projectedBounds;
		[Export ("initWithString:inBounds:")]
		IntPtr Constructor (string proj4String, RMProjectedRect projectedBounds);
		
		// -------- METHODS
		
		//NOTE: THere are two other static methods not bound yet:
		// - convertCoordinate
		// - convertUTMZoneNumber
		
		//- (RMProjectedPoint)wrapPointHorizontally:(RMProjectedPoint)aPoint;
		[Export ("wrapPointHorizontally:")]
		RMProjectedPoint WrapPointHorizontally (RMProjectedPoint aPoint);
		
		//- (RMProjectedPoint)constrainPointToBounds:(RMProjectedPoint)aPoint;
		[Export ("constrainPointToBounds:")]
		RMProjectedPoint ConstrainPointToBounds (RMProjectedPoint aPoint);
		
		//- (CLLocationCoordinate2D)projectedPointToCoordinate:(RMProjectedPoint)aPoint;
		[Export ("projectedPointToCoordinate:")]
		CLLocationCoordinate2D ProjectedPointToCoordinate (RMProjectedPoint aPoint);
		
		//- (RMProjectedPoint)coordinateToProjectedPoint:(CLLocationCoordinate2D)aLatLong;
		[Export ("coordinateToProjectedPoint:")]
		RMProjectedPoint CoordinateToProjectedPoint (CLLocationCoordinate2D aLatLong);
	}
	
	[BaseType (typeof (NSObject))]
	interface RMFractalTileProjection {
		
		// -------- PROPERTIES
		
		//@property (nonatomic, readonly) RMProjectedRect planetBounds;
		[Export ("planetBounds")]
		RMProjectedRect PlanetBounds { get;  }
		
		//@property (nonatomic, readonly) NSUInteger maxZoom;
		[Export ("maxZoom")]
		uint MaxZoom { get;  }
		
		//@property (nonatomic, readonly) NSUInteger minZoom;
		[Export ("minZoom")]
		uint MinZoom { get;  }
		
		//@property (nonatomic, readonly) NSUInteger tileSideLength;
		[Export ("tileSideLength")]
		uint TileSideLength { get;  }
		
		// -------- CONSTRUCTORS
		
		//- (id)initFromProjection:(RMProjection *)projection tileSideLength:(NSUInteger)tileSideLength maxZoom:(NSUInteger)aMaxZoom minZoom:(NSUInteger)aMinZoom;
		[Export ("initFromProjection:tileSideLength:maxZoom:minZoom:")]
		IntPtr Constructor (RMProjection projection, uint tileSideLength, uint aMaxZoom, uint aMinZoom);
		
		// -------- METHODS
		
		//- (void)setTileSideLength:(NSUInteger)aTileSideLength;
		[Export ("setTileSideLength:")]
		void SetTileSideLength (uint aTileSideLength);
		
		//- (void)setMinZoom:(NSUInteger)aMinZoom;
		[Export ("setMinZoom:")]
		void SetMinZoom (uint aMinZoom);
		
		//- (void)setMaxZoom:(NSUInteger)aMaxZoom;
		[Export ("setMaxZoom:")]
		void SetMaxZoom (uint aMaxZoom);
		
		//- (RMTilePoint)project:(RMProjectedPoint)aPoint atZoom:(float)zoom;
		[Export ("project:atZoom:")]
		RMTilePoint Project (RMProjectedPoint aPoint, float zoom);
		
		//- (RMTileRect)projectRect:(RMProjectedRect)aRect atZoom:(float)zoom;
		[Export ("projectRect:atZoom:")]
		RMTileRect ProjectRect (RMProjectedRect aRect, float zoom);
		
		//- (RMTilePoint)project:(RMProjectedPoint)aPoint atScale:(float)scale;
		[Export ("project:atScale:")]
		RMTilePoint ProjectAtScale (RMProjectedPoint aPoint, float scale);
		
		//- (RMTileRect)projectRect:(RMProjectedRect)aRect atScale:(float)scale;
		[Export ("projectRect:atScale:")]
		RMTileRect ProjectRectAtScale (RMProjectedRect aRect, float scale);
		
		//- (RMTile)normaliseTile:(RMTile)tile;
		[Export ("normaliseTile:")]
		RMTile NormaliseTile (RMTile tile);
		
		//- (float)normaliseZoom:(float)zoom;
		[Export ("normaliseZoom:")]
		float NormaliseZoom (float zoom);
		
		//- (float)calculateZoomFromScale:(float)scale;
		[Export ("calculateZoomFromScale:")]
		float CalculateZoomFromScale (float scale);
		
		//- (float)calculateNormalisedZoomFromScale:(float)scale;
		[Export ("calculateNormalisedZoomFromScale:")]
		float CalculateNormalisedZoomFromScale (float scale);
		
		//- (float)calculateScaleFromZoom:(float)zoom;
		[Export ("calculateScaleFromZoom:")]
		float CalculateScaleFromZoom (float zoom);	
	}
	
	#endregion

	#region Tile Cache
	
	[Model]
	[Protocol]
	// RMTileCache has multiple base types defined, 'NSObject' and 'NSObject'
	[BaseType (typeof (NSObject))]
	interface RMTileCache {
		
		//- (UIImage *)cachedImage:(RMTile)tile withCacheKey:(NSString *)cacheKey;
		[Abstract, Export ("cachedImage:withCacheKey:")]
		UIImage CachedImage (RMTile tile, string cacheKey);
		
		//- (void)didReceiveMemoryWarning;
		[Abstract, Export ("didReceiveMemoryWarning")]
		void DidReceiveMemoryWarning ();
		
		//@optional- (void)addImage:(UIImage *)image forTile:(RMTile)tile withCacheKey:(NSString *)cacheKey;
		[Abstract, Export ("addImage:forTile:withCacheKey:")]
		void AddImage (UIImage image, RMTile tile, string cacheKey);
		
		//- (void)removeAllCachedImages;
		[Abstract, Export ("removeAllCachedImages")]
		void RemoveAllCachedImages ();
		
		//- (void)removeAllCachedImagesForCacheKey:(NSString *)cacheKey;
		[Abstract, Export ("removeAllCachedImagesForCacheKey:")]
		void RemoveAllCachedImagesForCacheKey (string cacheKey);
		
		//- (id)initWithExpiryPeriod:(NSTimeInterval)period;
		[Export ("initWithExpiryPeriod:")]
		IntPtr Constructor (double period);
		
		//+ (NSNumber *)tileHash:(RMTile)tile;
		[Static, Export ("tileHash:")]
		NSNumber TileHash (RMTile tile);
		
		//- (void)addCache:(id <RMTileCache>)cache;
		[Export ("addCache:")]
		void AddCache (IntPtr cache);
		
		//- (void)insertCache:(id <RMTileCache>)cache atIndex:(NSUInteger)index;
		[Export ("insertCache:atIndex:")]
		void InsertCache (IntPtr cache, uint index);
	}
	
	#endregion

	#region Tile Source
	
	[Model, BaseType (typeof (NSObject))]
	interface RMTileSource {
		
		// -------- PROPERTIES
		
		//@property (nonatomic, assign) float minZoom;
		[Export ("minZoom")]
		float MinZoom { get; set;  }
		
		//@property (nonatomic, assign) float maxZoom;
		[Export ("maxZoom")]
		float MaxZoom { get; set;  }
		
		//@property (nonatomic, readonly) RMFractalTileProjection *mercatorToTileProjection;
		[Export ("mercatorToTileProjection")]
		RMFractalTileProjection MercatorToTileProjection { get;  }
		
		//@property (nonatomic, readonly) RMProjection *projection;
		[Export ("projection")]
		RMProjection Projection { get;  }
		
		//@property (nonatomic, readonly) RMSphericalTrapezium latitudeLongitudeBoundingBox;
		[Export ("latitudeLongitudeBoundingBox")]
		RMSphericalTrapezium LatitudeLongitudeBoundingBox { get;  }
		
		//@property (nonatomic, readonly) NSString *uniqueTilecacheKey;
		[Export ("uniqueTilecacheKey")]
		string UniqueTilecacheKey { get;  }
		
		//@property (nonatomic, readonly) NSUInteger tileSideLength;
		[Export ("tileSideLength")]
		uint TileSideLength { get;  }
		
		//@property (nonatomic, readonly) NSString *shortName;
		[Export ("shortName")]
		string ShortName { get;  }
		
		//@property (nonatomic, readonly) NSString *longDescription;
		[Export ("longDescription")]
		string LongDescription { get;  }
		
		//@property (nonatomic, readonly) NSString *shortAttribution;
		[Export ("shortAttribution")]
		string ShortAttribution { get;  }
		
		//@property (nonatomic, readonly) NSString *longAttribution;
		[Export ("longAttribution")]
		string LongAttribution { get;  }
		
		// -------- METHODS
		
		//#pragma mark -- (UIImage *)imageForTile:(RMTile)tile inCache:(RMTileCache *)tileCache;
		//[Abstract, DelegateName("RMTileSourceImage"), DefaultValue(null), Export ("imageForTile:inCache:")]
		//UIImage ImageForTile (RMTile tile, RMTileCache tileCache);
		[Export ("imageForTile:inCache:"), DelegateName("RMTileSourceImage"), DefaultValue(null)]
		UIImage ImageForTile (RMTile tile, IntPtr tileCache);
		
		//- (void)cancelAllDownloads;
		//		[Abstract, Export ("cancelAllDownloads")]
		//		void CancelAllDownloads ();
		
		//- (void)didReceiveMemoryWarning;
		//		[Abstract, Export ("didReceiveMemoryWarning")]
		//		void DidReceiveMemoryWarning ();
	}

	[BaseType (typeof (NSObject))]
	interface RMTileSourcesContainer {
		
		// -------- PROPERTIES
		
		//@property (nonatomic, assign) float minZoom;
		[Export ("minZoom")]
		float MinZoom { get; set;  }
		
		//@property (nonatomic, assign) float maxZoom;
		[Export ("maxZoom")]
		float MaxZoom { get; set;  }
		
		//@property (nonatomic, readonly) NSUInteger tileSideLength;
		[Export ("tileSideLength")]
		uint TileSideLength { get;  }
		
		//@property (nonatomic, readonly) RMFractalTileProjection *mercatorToTileProjection;
		[Export ("mercatorToTileProjection")]
		RMFractalTileProjection MercatorToTileProjection { get;  }
		
		//@property (nonatomic, readonly) RMProjection *projection;
		[Export ("projection")]
		RMProjection Projection { get;  }
		
		//@property (nonatomic, readonly) RMSphericalTrapezium latitudeLongitudeBoundingBox;
		[Export ("latitudeLongitudeBoundingBox")]
		RMSphericalTrapezium LatitudeLongitudeBoundingBox { get;  }
		
		//@property (nonatomic, readonly) NSArray *tileSources;
		[Export ("tileSources")]
		NSArray TileSources { get;  }
		
		// -------- METHODS
		
		//- (id <RMTileSource>)tileSourceForUniqueTilecacheKey:(NSString *)uniqueTilecacheKey;
		[Export ("tileSourceForUniqueTilecacheKey:")]
		RMTileSourcesContainer TileSourceForUniqueTilecacheKey (string uniqueTilecacheKey);
		
		//- (BOOL)setTileSource:(id <RMTileSource>)tileSource;
		[Export ("setTileSource:")]
		bool SetTileSource (IntPtr tileSource);
		
		//- (BOOL)setTileSources:(NSArray *)tileSources;
		[Export ("setTileSources:")]
		bool SetTileSources (NSArray tileSources);
		
		//- (BOOL)addTileSource:(id <RMTileSource>)tileSource;
		[Export ("addTileSource:")]
		bool AddTileSource (IntPtr tileSource);
		
		//- (BOOL)addTileSource:(id<RMTileSource>)tileSource atIndex:(NSUInteger)index;
		[Export ("addTileSource:atIndex:")]
		bool AddTileSource (IntPtr tileSource, uint index);
		
		//- (void)removeTileSource:(id <RMTileSource>)tileSource;
		[Export ("removeTileSource:")]
		void RemoveTileSource (IntPtr tileSource);
		
		//- (void)removeTileSourceAtIndex:(NSUInteger)index;
		[Export ("removeTileSourceAtIndex:")]
		void RemoveTileSourceAtIndex (uint index);
		
		//- (void)moveTileSourceAtIndex:(NSUInteger)fromIndex toIndex:(NSUInteger)toIndex;
		[Export ("moveTileSourceAtIndex:toIndex:")]
		void MoveTileSourceAtIndex (uint fromIndex, uint toIndex);
		
		//- (void)removeAllTileSources;
		[Export ("removeAllTileSources")]
		void RemoveAllTileSources ();
		
		//- (void)cancelAllDownloads;
		[Export ("cancelAllDownloads")]
		void CancelAllDownloads ();
		
		//- (void)didReceiveMemoryWarning;
		[Export ("didReceiveMemoryWarning")]
		void DidReceiveMemoryWarning ();
	}

	//	[BaseType (typeof (NSObject),
	//	        Delegates=new string [] { "WeakDelegate" },
	//			Events=new Type [] {typeof(RMTileSource)})]
	[BaseType (typeof (NSObject))]
	interface RMAbstractMercatorTileSource {
		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }		
		
		[Wrap ("WeakDelegate")]
		RMTileSource Delegate { get; set; }
		
		#region RMTileSource protocol
		//NOTE: couldn't get delegate stuff automatically generating these in here, so copied this from RMTileSource above
		// -------- PROPERTIES
		
		//@property (nonatomic, assign) float minZoom;
		[Export ("minZoom")]
		float MinZoom { get; set;  }
		
		//@property (nonatomic, assign) float maxZoom;
		[Export ("maxZoom")]
		float MaxZoom { get; set;  }
		
		//@property (nonatomic, readonly) RMFractalTileProjection *mercatorToTileProjection;
		[Export ("mercatorToTileProjection")]
		RMFractalTileProjection MercatorToTileProjection { get;  }
		
		//@property (nonatomic, readonly) RMProjection *projection;
		[Export ("projection")]
		RMProjection Projection { get;  }
		
		//@property (nonatomic, readonly) RMSphericalTrapezium latitudeLongitudeBoundingBox;
		[Export ("latitudeLongitudeBoundingBox")]
		RMSphericalTrapezium LatitudeLongitudeBoundingBox { get;  }
		
		//@property (nonatomic, readonly) NSString *uniqueTilecacheKey;
		[Export ("uniqueTilecacheKey")]
		string UniqueTilecacheKey { get;  }
		
		//@property (nonatomic, readonly) NSUInteger tileSideLength;
		[Export ("tileSideLength")]
		uint TileSideLength { get;  }
		
		//@property (nonatomic, readonly) NSString *shortName;
		[Export ("shortName")]
		string ShortName { get;  }
		
		//@property (nonatomic, readonly) NSString *longDescription;
		[Export ("longDescription")]
		string LongDescription { get;  }
		
		//@property (nonatomic, readonly) NSString *shortAttribution;
		[Export ("shortAttribution")]
		string ShortAttribution { get;  }
		
		//@property (nonatomic, readonly) NSString *longAttribution;
		[Export ("longAttribution")]
		string LongAttribution { get;  }
		
		// -------- METHODS
		
		//#pragma mark -- (UIImage *)imageForTile:(RMTile)tile inCache:(RMTileCache *)tileCache;
		//[Abstract, DelegateName("RMTileSourceImage"), DefaultValue(null), Export ("imageForTile:inCache:")]
		//UIImage ImageForTile (RMTile tile, RMTileCache tileCache);
		[Export ("imageForTile:inCache:"), DelegateName("RMTileSourceImage"), DefaultValue(null)]
		UIImage ImageForTile (RMTile tile, IntPtr tileCache);
		
		//- (void)cancelAllDownloads;
		//		[Abstract, Export ("cancelAllDownloads")]
		//		void CancelAllDownloads ();
		
		//- (void)didReceiveMemoryWarning;
		//		[Abstract, Export ("didReceiveMemoryWarning")]
		//		void DidReceiveMemoryWarning ();
		#endregion
	}

	[BaseType (typeof (RMAbstractMercatorTileSource))]
	interface RMAbstractWebMapSource {
		
		// -------- PROPERTIES
		
		//@property (nonatomic, assign) NSUInteger retryCount;
		[Export ("retryCount")]
		uint RetryCount { get; set;  }
		
		//@property (nonatomic, assign) NSTimeInterval requestTimeoutSeconds;
		[Export ("requestTimeoutSeconds")]
		double RequestTimeoutSeconds { get; set;  }
		
		// -------- METHODS
		
		//- (NSURL *)URLForTile:(RMTile)tile;
		[Export ("URLForTile:")]
		NSUrl UrlForTile (RMTile tile);

		//- (NSArray *)URLsForTile:(RMTile)tile;
		[Export ("URLsForTile:")]
		NSArray UrlsForTile (RMTile tile);
	}

	#region Map sources

	[BaseType (typeof (RMAbstractWebMapSource))]
	interface RMMapQuestOpenAerialSource {
	}
	
	[BaseType (typeof (RMAbstractWebMapSource))]
	interface RMMapQuestOSMSource {
	}
	
	[BaseType (typeof (RMAbstractWebMapSource))]
	interface RMOpenStreetMapSource {
	}

	#endregion

	#endregion

	#region Markers and other layers

	[BaseType (typeof (NSObject))]
	interface RMAnnotation {

		// -------- PROPERTIES

		//@property (nonatomic, assign) CLLocationCoordinate2D coordinate;
		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate { get; set;  }
		
		//@property (nonatomic, retain) NSString *title;
		[Export ("title", ArgumentSemantic.Retain)]
		string Title { get; set;  }
		
		//@property (nonatomic, retain) id userInfo;
		[Export ("userInfo", ArgumentSemantic.Retain)]
		IntPtr UserInfo { get; set;  }
		
		//@property (nonatomic, retain) NSString *annotationType;
		[Export ("annotationType", ArgumentSemantic.Retain)]
		string AnnotationType { get; set;  }
		
		//@property (nonatomic, retain) UIImage *annotationIcon;
		[Export ("annotationIcon", ArgumentSemantic.Retain)]
		UIImage AnnotationIcon { get; set;  }
		
		//@property (nonatomic, retain) UIImage *badgeIcon;
		[Export ("badgeIcon", ArgumentSemantic.Retain)]
		UIImage BadgeIcon { get; set;  }
		
		//@property (nonatomic, assign) CGPoint anchorPoint;
		[Export ("anchorPoint")]
		System.Drawing.PointF AnchorPoint { get; set;  }
		
		//@property (nonatomic, assign) CGPoint position;
		[Export ("position")]
		System.Drawing.PointF Position { get; set;  }
		
		//@property (nonatomic, assign) RMProjectedPoint projectedLocation; 
		[Export ("projectedLocation")]
		RMProjectedPoint ProjectedLocation { get; set;  }
		
		//@property (nonatomic, assign) RMProjectedRect  projectedBoundingBox;
		[Export ("projectedBoundingBox")]
		RMProjectedRect ProjectedBoundingBox { get; set;  }
		
		//@property (nonatomic, assign) BOOL hasBoundingBox;
		[Export ("hasBoundingBox")]
		bool HasBoundingBox { get; set;  }
		
		//@property (nonatomic, assign) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { get; set;  }
		
		//@property (nonatomic, assign) BOOL clusteringEnabled;
		[Export ("clusteringEnabled")]
		bool ClusteringEnabled { get; set;  }
		
		//@property (nonatomic, retain) RMMapLayer *layer;
		[Export ("layer", ArgumentSemantic.Retain)]
		RMMapLayer Layer { get; set;  }
		
		//@property (nonatomic, assign) RMQuadTreeNode *quadTreeNode;
//		[Export ("quadTreeNode")]
//		RMQuadTreeNode QuadTreeNode { get; set;  }
		
		//@property (nonatomic, readonly) BOOL isUserLocationAnnotation;
		[Export ("isUserLocationAnnotation")]
		bool IsUserLocationAnnotation { get;  }
		
		//@property (nonatomic, readonly) BOOL isAnnotationOnScreen;
		[Export ("isAnnotationOnScreen")]
		bool IsAnnotationOnScreen { get;  }
		
		//@property (nonatomic, readonly) BOOL isAnnotationVisibleOnScreen;
		[Export ("isAnnotationVisibleOnScreen")]
		bool IsAnnotationVisibleOnScreen { get;  }
		
		//@property (nonatomic, retain) RMMapView *mapView;
		[Export ("mapView", ArgumentSemantic.Retain)]
		RMMapView MapView { get; set;  }

		// -------- METHODS
		
		//+ (id)annotationWithMapView:(RMMapView *)aMapView coordinate:(CLLocationCoordinate2D)aCoordinate andTitle:(NSString *)aTitle;
		[Static, Export ("annotationWithMapView:coordinate:andTitle:")]
		RMAnnotation AnnotationWithMapView (RMMapView aMapView, CLLocationCoordinate2D aCoordinate, string aTitle);
		
		//- (id)initWithMapView:(RMMapView *)aMapView coordinate:(CLLocationCoordinate2D)aCoordinate andTitle:(NSString *)aTitle;
		[Export ("initWithMapView:coordinate:andTitle:")]
		IntPtr Constructor (RMMapView aMapView, CLLocationCoordinate2D aCoordinate, string aTitle);
		
		//- (void)setBoundingBoxCoordinatesSouthWest:(CLLocationCoordinate2D)southWest northEast:(CLLocationCoordinate2D)northEast;
		[Export ("setBoundingBoxCoordinatesSouthWest:northEast:")]
		void SetBoundingBoxCoordinatesSouthWest (CLLocationCoordinate2D southWest, CLLocationCoordinate2D northEast);
		
		//- (void)setBoundingBoxFromLocations:(NSArray *)locations;
		[Export ("setBoundingBoxFromLocations:")]
		void SetBoundingBoxFromLocations (NSArray locations);
		
		//- (BOOL)isAnnotationWithinBounds:(CGRect)bounds;
		[Export ("isAnnotationWithinBounds:")]
		bool IsAnnotationWithinBounds (System.Drawing.RectangleF bounds);

		//- (void)setPosition:(CGPoint)position animated:(BOOL)animated;
		[Export ("setPosition:animated:")]
		void SetPosition (System.Drawing.PointF position, bool animated);
	}

	[BaseType (typeof (CAScrollLayer))]
	interface RMMapLayer {
		// -------- PROPERTIES
		
		//@property (nonatomic, assign) RMAnnotation *annotation;
		[Export ("annotation")]
		RMAnnotation Annotation { get; set;  }
		
		//@property (nonatomic, assign) RMProjectedPoint projectedLocation;
		[Export ("projectedLocation")]
		RMProjectedPoint ProjectedLocation { get; set;  }
		
		//@property (nonatomic, assign) BOOL enableDragging;
		[Export ("enableDragging")]
		bool EnableDragging { get; set;  }
		
		//@property (nonatomic, retain) id userInfo;
		[Export ("userInfo", ArgumentSemantic.Retain)]
		IntPtr UserInfo { get; set;  }
		
		// -------- METHODS
		
		//- (void)setPosition:(CGPoint)position animated:(BOOL)animated;
		[Export ("setPosition:animated:")]
		void SetPosition (System.Drawing.PointF position, bool animated);
	}

	[BaseType (typeof (RMMapLayer))]
	interface RMMarker {

		// -------- PROPERTIES

		//@property (nonatomic, retain) UIView  *label;
		[Export ("label", ArgumentSemantic.Retain)]
		UIView Label { get; set;  }
		
		//@property (nonatomic, retain) UIColor *textForegroundColor;
		[Export ("textForegroundColor", ArgumentSemantic.Retain)]
		UIColor TextForegroundColor { get; set;  }
		
		//@property (nonatomic, retain) UIColor *textBackgroundColor;
		[Export ("textBackgroundColor", ArgumentSemantic.Retain)]
		UIColor TextBackgroundColor { get; set;  }

		// -------- METHODS

		//+ (UIFont *)defaultFont;
		[Static, Export ("defaultFont")]
		UIFont DefaultFont { get; }
		
		//- (id)initWithUIImage:(UIImage *)image;
		[Export ("initWithUIImage:")]
		IntPtr Constructor (UIImage image);
		
		//- (id)initWithUIImage:(UIImage *)image anchorPoint:(CGPoint)anchorPoint;
		[Export ("initWithUIImage:anchorPoint:")]
		IntPtr Constructor (UIImage image, System.Drawing.PointF anchorPoint);
		
		//- (void)changeLabelUsingText:(NSString *)text;
		[Export ("changeLabelUsingText:")]
		void ChangeLabelUsingText (string text);
		
		//- (void)changeLabelUsingText:(NSString *)text position:(CGPoint)position;
		[Export ("changeLabelUsingText:position:")]
		void ChangeLabelUsingText (string text, System.Drawing.PointF position);
		
		//- (void)changeLabelUsingText:(NSString *)text font:(UIFont *)font foregroundColor:(UIColor *)textColor backgroundColor:(UIColor *)backgroundColor;
		[Export ("changeLabelUsingText:font:foregroundColor:backgroundColor:")]
		void ChangeLabelUsingText (string text, UIFont font, UIColor textColor, UIColor backgroundColor);
		
		//- (void)changeLabelUsingText:(NSString *)text position:(CGPoint)position font:(UIFont *)font foregroundColor:(UIColor *)textColor backgroundColor:(UIColor *)backgroundColor;
		[Export ("changeLabelUsingText:position:font:foregroundColor:backgroundColor:")]
		void ChangeLabelUsingText (string text, System.Drawing.PointF position, UIFont font, UIColor textColor, UIColor backgroundColor);
		
		//- (void)toggleLabel;
		[Export ("toggleLabel")]
		void ToggleLabel ();
		
		//- (void)showLabel;
		[Export ("showLabel")]
		void ShowLabel ();
		
		//- (void)hideLabel;
		[Export ("hideLabel")]
		void HideLabel ();
		
		//- (void)replaceUIImage:(UIImage *)image;
		[Export ("replaceUIImage:")]
		void ReplaceUIImage (UIImage image);
		
		//- (void)replaceUIImage:(UIImage *)image anchorPoint:(CGPoint)anchorPoint;
		[Export ("replaceUIImage:anchorPoint:")]
		void ReplaceUIImage (UIImage image, System.Drawing.PointF anchorPoint);
	}

	[BaseType (typeof (RMMapLayer))]
	interface RMPath {

		// -------- PROPERTIES
		//@property (nonatomic, assign) CGPathDrawingMode drawingMode;
		[Export ("drawingMode")]
		CGPathDrawingMode DrawingMode { get; set;  }
		
		//@property (nonatomic, assign) CGLineCap lineCap;
		[Export ("lineCap")]
		CGLineCap LineCap { get; set;  }
		
		//@property (nonatomic, assign) CGLineJoin lineJoin;
		[Export ("lineJoin")]
		CGLineJoin LineJoin { get; set;  }
		
		//@property (nonatomic, assign) NSArray *lineDashLengths;
		[Export ("lineDashLengths")]
		NSArray LineDashLengths { get; set;  }
		
		//@property (nonatomic, assign) CGFloat lineDashPhase;
		[Export ("lineDashPhase")]
		float LineDashPhase { get; set;  }
		
		//@property (nonatomic, assign) BOOL scaleLineDash;
		[Export ("scaleLineDash")]
		bool ScaleLineDash { get; set;  }
		
		//@property (nonatomic, assign) float lineWidth;
		[Export ("lineWidth")]
		float LineWidth { get; set;  }
		
		//@property (nonatomic, assign) BOOL	scaleLineWidth;
		[Export ("scaleLineWidth")]
		bool ScaleLineWidth { get; set;  }
		
		//@property (nonatomic, assign) CGFloat shadowBlur;
		[Export ("shadowBlur")]
		float ShadowBlur { get; set;  }
		
		//@property (nonatomic, assign) CGSize shadowOffset;
//		[Export ("shadowOffset")]
//		System.Drawing.SizeF ShadowOffset { get; set;  }
		
		//@property (nonatomic, assign) BOOL enableShadow;
		[Export ("enableShadow")]
		bool EnableShadow { get; set;  }
		
		//@property (nonatomic, retain) UIColor *lineColor;
		[Export ("lineColor", ArgumentSemantic.Retain)]
		UIColor LineColor { get; set;  }
		
		//@property (nonatomic, retain) UIColor *fillColor;
		[Export ("fillColor", ArgumentSemantic.Retain)]
		UIColor FillColor { get; set;  }
		
		//@property (nonatomic, readonly) CGRect pathBoundingBox;
		[Export ("pathBoundingBox")]
		System.Drawing.RectangleF PathBoundingBox { get;  }
		
		// -------- METHODS

		//- (void)moveToProjectedPoint:(RMProjectedPoint)projectedPoint;
		[Export ("moveToProjectedPoint:")]
		void MoveToProjectedPoint (RMProjectedPoint projectedPoint);
		
		//- (void)moveToScreenPoint:(CGPoint)point;
		[Export ("moveToScreenPoint:")]
		void MoveToScreenPoint (System.Drawing.PointF point);
		
		//- (void)moveToCoordinate:(CLLocationCoordinate2D)coordinate;
		[Export ("moveToCoordinate:")]
		void MoveToCoordinate (CLLocationCoordinate2D coordinate);
		
		//- (void)addLineToProjectedPoint:(RMProjectedPoint)projectedPoint;
		[Export ("addLineToProjectedPoint:")]
		void AddLineToProjectedPoint (RMProjectedPoint projectedPoint);
		
		//- (void)addLineToScreenPoint:(CGPoint)point;
		[Export ("addLineToScreenPoint:")]
		void AddLineToScreenPoint (System.Drawing.PointF point);
		
		//- (void)addLineToCoordinate:(CLLocationCoordinate2D)coordinate;
		[Export ("addLineToCoordinate:")]
		void AddLineToCoordinate (CLLocationCoordinate2D coordinate);
		
		//- (void)closePath;
		[Export ("closePath")]
		void ClosePath ();
	}

	[BaseType (typeof (RMMapLayer))]
	interface RMShape {

		// -------- PROPERTIES

		//@property (nonatomic, retain) NSString *fillRule;
		[Export ("fillRule", ArgumentSemantic.Retain)]
		string FillRule { get; set;  }
		
		//@property (nonatomic, retain) NSString *lineCap;
		[Export ("lineCap", ArgumentSemantic.Retain)]
		string LineCap { get; set;  }
		
		//@property (nonatomic, retain) NSString *lineJoin;
		[Export ("lineJoin", ArgumentSemantic.Retain)]
		string LineJoin { get; set;  }
		
		//@property (nonatomic, retain) UIColor *lineColor;
		[Export ("lineColor", ArgumentSemantic.Retain)]
		UIColor LineColor { get; set;  }
		
		//@property (nonatomic, retain) UIColor *fillColor;
		[Export ("fillColor", ArgumentSemantic.Retain)]
		UIColor FillColor { get; set;  }
		
		//@property (nonatomic, assign) NSArray *lineDashLengths;
		[Export ("lineDashLengths")]
		NSArray LineDashLengths { get; set;  }
		
		//@property (nonatomic, assign) CGFloat lineDashPhase;
		[Export ("lineDashPhase")]
		float LineDashPhase { get; set;  }
		
		//@property (nonatomic, assign) BOOL scaleLineDash;
		[Export ("scaleLineDash")]
		bool ScaleLineDash { get; set;  }
		
		//@property (nonatomic, assign) float lineWidth;
		[Export ("lineWidth")]
		float LineWidth { get; set;  }
		
		//@property (nonatomic, assign) BOOL scaleLineWidth;
		[Export ("scaleLineWidth")]
		bool ScaleLineWidth { get; set;  }
		
		//@property (nonatomic, assign) CGFloat shadowBlur;
		[Export ("shadowBlur")]
		float ShadowBlur { get; set;  }
		
		//@property (nonatomic, assign) CGSize shadowOffset;
//		[Export ("shadowOffset")]
//		System.Drawing.SizeF ShadowOffset { get; set;  }
		
		//@property (nonatomic, assign) BOOL enableShadow;
		[Export ("enableShadow")]
		bool EnableShadow { get; set;  }
		
		//@property (nonatomic, readonly) CGRect pathBoundingBox;
		[Export ("pathBoundingBox")]
		System.Drawing.RectangleF PathBoundingBox { get; }
		
		// -------- METHODS

		//- (id)initWithView:(RMMapView *)aMapView;
		[Export ("initWithView:")]
		IntPtr Constructor (RMMapView aMapView);
		
		//- (void)moveToProjectedPoint:(RMProjectedPoint)projectedPoint;
		[Export ("moveToProjectedPoint:")]
		void MoveToProjectedPoint (RMProjectedPoint projectedPoint);
		
		//- (void)moveToScreenPoint:(CGPoint)point;
		[Export ("moveToScreenPoint:")]
		void MoveToScreenPoint (System.Drawing.PointF point);
		
		//- (void)moveToCoordinate:(CLLocationCoordinate2D)coordinate;
		[Export ("moveToCoordinate:")]
		void MoveToCoordinate (CLLocationCoordinate2D coordinate);
		
		//- (void)addLineToProjectedPoint:(RMProjectedPoint)projectedPoint;
		[Export ("addLineToProjectedPoint:")]
		void AddLineToProjectedPoint (RMProjectedPoint projectedPoint);
		
		//- (void)addLineToScreenPoint:(CGPoint)point;
		[Export ("addLineToScreenPoint:")]
		void AddLineToScreenPoint (System.Drawing.PointF point);
		
		//- (void)addLineToCoordinate:(CLLocationCoordinate2D)coordinate;
		[Export ("addLineToCoordinate:")]
		void AddLineToCoordinate (CLLocationCoordinate2D coordinate);

		//- (void)closePath;
		[Export ("closePath")]
		void ClosePath ();
	}

	[BaseType (typeof (RMMapLayer))]
	interface RMCircle {

		// -------- PROPERTIES
		//@property (nonatomic, retain) CAShapeLayer *shapeLayer;
		[Export ("shapeLayer", ArgumentSemantic.Retain)]
		CAShapeLayer ShapeLayer { get; set;  }
		
		//@property (nonatomic, retain) UIColor *lineColor;
		[Export ("lineColor", ArgumentSemantic.Retain)]
		UIColor LineColor { get; set;  }
		
		//@property (nonatomic, retain) UIColor *fillColor;
		[Export ("fillColor", ArgumentSemantic.Retain)]
		UIColor FillColor { get; set;  }
		
		//@property (nonatomic, assign) CGFloat radiusInMeters;
		[Export ("radiusInMeters")]
		float RadiusInMeters { get; set;  }
		
		//@property (nonatomic, assign) CGFloat lineWidthInPixels;
		[Export ("lineWidthInPixels")]
		float LineWidthInPixels { get; set;  }

		// -------- METHODS

		//- (id)initWithView:(RMMapView *)aMapView radiusInMeters:(CGFloat)newRadiusInMeters;
		[Export ("initWithView:radiusInMeters:")]
		IntPtr Constructor (RMMapView aMapView, float newRadiusInMeters);
	}

	#endregion

	#region User Location

	[BaseType (typeof (RMAnnotation))]
	interface RMUserLocation {
		//@property (nonatomic, readonly, getter=isUpdating) BOOL updating;
		[Export ("updating")]
		bool Updating { [Bind ("isUpdating")] get;  }
		
		//@property (nonatomic, readonly) CLLocation *location;
		[Export ("location")]
		CLLocation Location { get;  }
		
		//@property (nonatomic, readonly) CLHeading *heading;
		[Export ("heading")]
		CLHeading Heading { get;  }		
	}

	#endregion
	
	#region DBMap

	[BaseType (typeof(RMAbstractMercatorTileSource))]
	interface RMDBMapSource{
		//- (id)initWithPath:(NSString *)path;
		[Export ("initWithPath:")]
		IntPtr Constructor (string path);

		//- (CLLocationCoordinate2D)topLeftOfCoverage;
		[Export("topLeftOfCoverage")]
		CLLocationCoordinate2D TopLeftOfCoverage { get; }

		//- (CLLocationCoordinate2D)bottomRightOfCoverage;
		[Export("bottomRightOfCoverage")]
		CLLocationCoordinate2D BottomRightOfCoverage { get; }

		//- (CLLocationCoordinate2D)centerOfCoverage;
		[Export("centerOfCoverage")]
		CLLocationCoordinate2D CenterOfCoverage { get; }

	}

	#endregion
}
