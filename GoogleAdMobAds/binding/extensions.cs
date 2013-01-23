using System;
using System.Runtime.InteropServices;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using System.Drawing;

namespace GoogleAdMobAds
{
	public partial class GADRequest
	{
		public static readonly string GAD_SIMULATOR_ID = "Simulator";
		
		public static readonly string GADGoogleAdMobNetworkName = "GoogleAdMobAds";
	}
	
	public partial class GADRequestError
	{
		private static string kGADErrorDomain;
		
		public static string ErrorDomain
		{
			get 
			{
				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				kGADErrorDomain = (string) Dlfcn.GetStringConstant (RTLD_MAIN_ONLY, "kGADErrorDomain");
				
				return kGADErrorDomain;
			}
			set 
			{
				kGADErrorDomain = value;
				
				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kGADErrorDomain");
				
				Marshal.WriteIntPtr(ptr, new NSString(kGADErrorDomain).Handle);
				
			}
		}
	}
	
	public partial class GADAdSizeCons : NSObject
	{	
		// Deprecated Macros
		[Obsolete("Use GADAdSizeCons.Banner Instead")]
		public static readonly SizeF GAD_SIZE_320x50 = GADAdSizeCons.Banner.size;
		
		[Obsolete("Use GADAdSizeCons.MediumRectangle Instead")]
		public static readonly SizeF GAD_SIZE_300x250 = GADAdSizeCons.MediumRectangle.size;
		
		[Obsolete("Use ADAdSizeCons.FullBanner Instead")]
		public static readonly SizeF GAD_SIZE_468x60 = GADAdSizeCons.FullBanner.size;
		
		[Obsolete("Use GADAdSizeCons.Leaderboard Instead")]
		public static readonly SizeF GAD_SIZE_728x90 = GADAdSizeCons.Leaderboard.size;
		
		[Obsolete("Use ADAdSizeCons.Skyscraper Instead")]
		public static readonly SizeF GAD_SIZE_120x600 = GADAdSizeCons.Skyscraper.size;
	}
}

