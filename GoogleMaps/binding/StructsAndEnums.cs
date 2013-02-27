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

	[StructLayout (LayoutKind.Sequential)]
	public struct GMSVisibleRegion {

		public CLLocationCoordinate2D NearLeft;
		public CLLocationCoordinate2D NearRight;
		public CLLocationCoordinate2D FarLeft;
		public CLLocationCoordinate2D FarRight;

		public GMSVisibleRegion (double nearLeftLatitude, double nearLeftLongitude, 
		                         double nearRightLatitude, double nearRightLongitude, 
		                         double farLeftLatitude, double farLeftLongitude, 
		                         double farRightLatitude, double farRightLongitude)
		{
			NearLeft = new CLLocationCoordinate2D (nearLeftLatitude, nearLeftLongitude);
			NearRight = new CLLocationCoordinate2D (nearRightLatitude, nearRightLongitude);
			FarLeft = new CLLocationCoordinate2D (farLeftLatitude, farLeftLongitude);
			FarRight = new CLLocationCoordinate2D (farRightLatitude, farRightLongitude);
		}	
	}
}

