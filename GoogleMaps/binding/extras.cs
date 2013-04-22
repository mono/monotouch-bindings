using System;
using System.Runtime.InteropServices;
using MonoTouch.CoreLocation;
using System.Drawing;
using MonoTouch.ObjCRuntime;

namespace Google.Maps
{
	public partial class GroundOverlay
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

		private static PointF kGMSGroundOverlayDefaultZoom;
		public static PointF DefaultZoom
		{
			get 
			{
				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGMSGroundOverlayDefaultZoom");
				kGMSGroundOverlayDefaultZoom = (PointF)Marshal.PtrToStructure(ptr, typeof(PointF));
				
				return kGMSGroundOverlayDefaultZoom;
			}
		}
	}

	public partial class Marker
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
	
}

