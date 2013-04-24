using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreLocation;
using System.Drawing;
using Google.Maps;
using MonoTouch.CoreAnimation;

namespace GoogleMapsAdvSample
{
	public class MapLayerViewController : UIViewController
	{
		MapView mapView;
		public MapLayerViewController () : base ()
		{
			Title = "Map Layer";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var camera = CameraPosition.FromCamera (-37.81969, 144.966085, 4);
			mapView = MapView.FromCamera (RectangleF.Empty, camera);
			View = mapView;

			BeginInvokeOnMainThread (()=> mapView.MyLocationEnabled = true);
			var myLocationButton = new UIBarButtonItem ("Fly to My Location", UIBarButtonItemStyle.Plain, DidTapMyLocation);
			NavigationItem.RightBarButtonItem = myLocationButton;
		}

		void DidTapMyLocation (object sender, EventArgs e)
		{
			var location = mapView.MyLocation;
			if (location == null || !location.Coordinate.IsValid()) {
				return;
			}

			// Access the GMSMapLayer directly to modify the following properties with a
			// specified timing function and duration.
			
			var curve = CAMediaTimingFunction.FromName (CAMediaTimingFunction.EaseInEaseOut);
			CABasicAnimation animation;
			
			animation = CABasicAnimation.FromKeyPath (Constants.LayerCameraLatitudeKey);
			animation.Duration = 2.0;
			animation.TimingFunction = curve;
			animation.To = NSNumber.FromDouble (location.Coordinate.Latitude);
			mapView.Layer.AddAnimation (animation, Constants.LayerCameraLatitudeKey);
			
            animation = CABasicAnimation.FromKeyPath (Constants.LayerCameraLongitudeKey);
			animation.Duration = 2.0;
			animation.TimingFunction = curve;
			animation.To = NSNumber.FromDouble (location.Coordinate.Longitude);
			mapView.Layer.AddAnimation (animation, Constants.LayerCameraLongitudeKey);
			
			animation = CABasicAnimation.FromKeyPath (Constants.LayerCameraBearingKey);
			animation.Duration = 2.0;
			animation.TimingFunction = curve;
			animation.To = NSNumber.FromDouble (0.0);
			mapView.Layer.AddAnimation (animation, Constants.LayerCameraBearingKey);
			
			// Fly out to the minimum zoom and then zoom back to the current zoom!
			var zoom = mapView.Camera.Zoom;
			var keyValues = new [] { NSNumber.FromFloat (zoom), NSNumber.FromFloat (-100), NSNumber.FromFloat (zoom) };
			var keyFrameAnimation = (CAKeyFrameAnimation) CAKeyFrameAnimation.FromKeyPath (Constants.LayerCameraZoomLevelKey);
			keyFrameAnimation.Duration = 2.0;
			keyFrameAnimation.Values = keyValues;
			mapView.Layer.AddAnimation (keyFrameAnimation, Constants.LayerCameraZoomLevelKey);
		}
	}
}

