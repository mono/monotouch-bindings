using System;
using MonoTouch.UIKit;
using System.Drawing;
using Google.Maps;

namespace GoogleMapsAdvSample
{
	public class MapTypesViewController : UIViewController
	{
		public MapTypesViewController () : base ()
		{
			Title = "Map Types";
		}

		UISegmentedControl switcher;
		MapView mapView;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var camera = CameraPosition.FromCamera (-33.868, 151.2086, 12);
			mapView = MapView.FromCamera (RectangleF.Empty, camera);
			View = mapView;

			// The possible different types to show.
			// Create a UISegmentedControl that is the navigationItem's titleView.
			switcher = new UISegmentedControl (new [] {"Normal", "Satellite", "Hybrid", "Terrain"}) {
				AutoresizingMask = UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleBottomMargin,
				SelectedSegment = 0,
				ControlStyle = UISegmentedControlStyle.Bar
			};
			NavigationItem.TitleView = switcher;

			// Listen to touch events on the UISegmentedControl.
			switcher.ValueChanged += HandleValueChanged;
		}

		void HandleValueChanged (object sender, EventArgs e)
		{
			// Switch to the type clicked on.
			var sw = sender as UISegmentedControl;

			switch (sw.SelectedSegment) {
			case 0:
				mapView.MapType = MapViewType.Normal;
				break;
			case 1:
				mapView.MapType = MapViewType.Satellite;
				break;
			case 2:
				mapView.MapType = MapViewType.Hybrid;
				break;
			case 3:
				mapView.MapType = MapViewType.Terrain;
				break;
			default:
			break;
			}
		}
	}
}

