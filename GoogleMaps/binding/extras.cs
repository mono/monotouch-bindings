using System;
using System.Runtime.InteropServices;
using MonoTouch.CoreLocation;
using System.Drawing;
using MonoTouch.ObjCRuntime;

namespace Google.Maps
{
	public partial class MapView {

		public Marker AddMarker (MarkerOptions options)
		{
			return new Marker (InternalAddMarker (options));
		}

		public Polyline AddPolyline (PolylineOptions options)
		{
			return new Polyline (InternalAddPolyline (options));
		}

		public GroundOverlay AddGroundOverlay (GroundOverlayOptions options)
		{
			return new GroundOverlay (InternalAddGroundOverlay (options));
		}
	}

	public partial class MarkerOptions
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

	public partial class GroundOverlayOptions
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

