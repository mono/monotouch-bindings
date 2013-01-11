using System;
using System.Runtime.InteropServices;
using MonoTouch.CoreLocation;

namespace GoogleMaps
{
	public partial class GMSMapView {
		public GMSMarker AddMarker (GMSMarkerOptions options)
		{
			return new GMSMarker (InternalAddMarker (options));
		}
	}
}

