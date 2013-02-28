using System;
using System.Runtime.InteropServices;
using MonoTouch.CoreLocation;
using System.Drawing;
using MonoTouch.ObjCRuntime;

namespace GoogleMaps
{
	public partial class GMSMapView {

		public GMSMarker AddMarker (GMSMarkerOptions options)
		{
			return new GMSMarker (InternalAddMarker (options));
		}

		public GMSPolyline AddPolyline (GMSPolylineOptions options)
		{
			return new GMSPolyline (InternalAddPolyline (options));
		}

		public GMSGroundOverlay AddGroundOverlay (GMSGroundOverlayOptions options)
		{
			return new GMSGroundOverlay (InternalAddGroundOverlay (options));
		}
	}

	public partial class GMSMarkerOptions
	{
		private static PointF kGMSMarkerDefaultGroundAnchor;
		public static PointF DefaultAnchor
		{
			get 
			{
				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGMSMarkerDefaultGroundAnchor");
				kGMSMarkerDefaultGroundAnchor = (PointF)Marshal.PtrToStructure(ptr, typeof(PointF));
				
				return kGMSMarkerDefaultGroundAnchor;
			}
		}

		private static PointF kGMSMarkerDefaultInfoWindowAnchor;
		public static PointF DefaultInfoWindowAnchor
		{
			get 
			{
				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGMSMarkerDefaultInfoWindowAnchor");
				kGMSMarkerDefaultInfoWindowAnchor = (PointF)Marshal.PtrToStructure(ptr, typeof(PointF));
				
				return kGMSMarkerDefaultInfoWindowAnchor;
			}
		}
	}

	public partial class GMSGroundOverlayOptions
	{
		private static PointF kGMSGroundOverlayDefaultAnchor;
		public static PointF DefaultAnchor
		{
			get 
			{
				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGMSGroundOverlayDefaultAnchor");
				kGMSGroundOverlayDefaultAnchor = (PointF)Marshal.PtrToStructure(ptr, typeof(PointF));
				
				return kGMSGroundOverlayDefaultAnchor;
			}
		}
	}
}

