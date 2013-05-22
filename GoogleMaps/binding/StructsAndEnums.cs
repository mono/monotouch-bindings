using System;
using System.Runtime.InteropServices;
using MonoTouch.CoreLocation;

namespace Google.Maps
{
	public enum MapViewType {
		/** Basic maps.  The default. */
		Normal = 1,

		/** Satellite maps with no labels. */
		Satellite,

		/** Terrain maps. */
		Terrain,

		/** Satellite maps with a transparent label overview. */
		Hybrid,

		/** No maps, no labels.  Display of traffic data is not supported. */
		None	
	} 

	[StructLayout (LayoutKind.Sequential)]
	public struct VisibleRegion {

		public CLLocationCoordinate2D NearLeft;
		public CLLocationCoordinate2D NearRight;
		public CLLocationCoordinate2D FarLeft;
		public CLLocationCoordinate2D FarRight;

		public VisibleRegion (double nearLeftLatitude, double nearLeftLongitude, 
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

