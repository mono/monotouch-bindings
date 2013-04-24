
using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

using Google.Maps;

namespace GoogleMapsAdvSample
{
	public partial class DVCMenu : DialogViewController
	{
		public DVCMenu () : base (UITableViewStyle.Plain, null)
		{
			Root = new RootElement ("Maps Demo") {
				new Section ("Map") {
					new StringElement ("Basic Map", () => {
						var ctrl = new BasicMapViewController ();
						NavigationController.PushViewController (ctrl, true);
					}),
					new StringElement ("Map Types", () => {
						var ctrl = new MapTypesViewController ();
						NavigationController.PushViewController (ctrl, true);
					}),
					new StringElement ("Traffic Layer", () => {
						var ctrl = new TrafficMapViewController ();
						NavigationController.PushViewController (ctrl, true);
					}),
					new StringElement ("My Location", () => {
						var ctrl = new MyLocationViewController ();
						NavigationController.PushViewController (ctrl, true);
					}),
					new StringElement ("Gesture Control", () => {
						var ctrl = new GestureControlViewController ();
						NavigationController.PushViewController (ctrl, true);
					})
				},
				new Section ("Overlays") {
					new StringElement ("Markers", () => {
						var ctrl = new MarkersViewController ();
						NavigationController.PushViewController (ctrl, true);
					}),
					new StringElement ("Custom Markers", () => {
						var ctrl = new CustomMarkersViewController ();
						NavigationController.PushViewController (ctrl, true);
					}),
					new StringElement ("Marker Events", () => {
						var ctrl = new MarkerEventsViewController ();
						NavigationController.PushViewController (ctrl, true);
					}),
					new StringElement ("Polygons", () => {
						var ctrl = new PolygonsViewController ();
						NavigationController.PushViewController (ctrl, true);
					}),
					new StringElement ("Polylines", () => {
						var ctrl = new PolylinesViewController ();
						NavigationController.PushViewController (ctrl, true);
					}),
					new StringElement ("Ground Overlays", () => {
						var ctrl = new GroundOverlayViewController ();
						NavigationController.PushViewController (ctrl, true);
					})
				},
				new Section ("Camera") {
					new StringElement ("Fit Bounds", () => {
						var ctrl = new FitBoundsViewController ();
						NavigationController.PushViewController (ctrl, true);
					}),
					new StringElement ("Camera Animation", () => {
						var ctrl = new CameraViewController ();
						NavigationController.PushViewController (ctrl, true);
					}),
					new StringElement ("Map Layer", () => {
						var ctrl = new MapLayerViewController ();
						NavigationController.PushViewController (ctrl, true);
					})
				},
				new Section ("Services") {
					new StringElement ("Geocoder", () => {
						var ctrl = new GeocoderViewController ();
						NavigationController.PushViewController (ctrl, true);
					})
				}
			};
		}
	}
}
