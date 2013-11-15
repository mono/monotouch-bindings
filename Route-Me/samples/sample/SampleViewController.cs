using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RouteMe;

namespace Sample
{
	public partial class SampleViewController : UIViewController
	{
		RMMapView MapView { get; set; }

		public SampleViewController () : base ("SampleViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			MapView = new RMMapView(View.Frame, new RMOpenStreetMapSource().Handle);
			MapView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;

			// Uncomment these and provide 'myCoordinate' to pan the map to your location
			//MapView.ShowsUserLocation = true;
			//MapView.Zoom = 13;
			//MapView.SetCenterCoordinate (myCoordinate, false /* without animation */);

			// running on retina? since the OSM tiles were not designed specifically for retina, need to adjust map display...
			if (UIScreen.MainScreen.Scale > 1.0)
				MapView.AdjustTilesForRetinaDisplay = true;

			Add (MapView);
		}
	}
}

