using System;
using System.Runtime.InteropServices;
using MonoTouch.CoreLocation;

namespace GoogleMaps
{
	public enum GMSMapViewType {
		/** Basic maps.  The default. */
		Normal = 1,
		
		/** Satellite maps with no labels. */
		Satellite,
		
		/** Terrain maps. */
		Terrain,
		
		/** Satellite maps with a transparent label overview. */
		Hybrid,
		
	} 

	[StructLayout (LayoutKind.Sequential)]
	public struct GMSCamera {
		public CLLocationCoordinate2D Coordinate;
		public float Zoom;

		public GMSCamera(double latitude, double longitude, float zoom)
		{
			Coordinate = new CLLocationCoordinate2D (latitude, longitude);
			Zoom = zoom;
		}

	}
}

