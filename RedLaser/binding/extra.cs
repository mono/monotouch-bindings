//
// testflight-cplusplus.cs: API definition for the TestFlight SDK C++ Methods
//
// Authors:
//  Chris Hardy (chrisntr@xamarin.com)
//
// Copyright 2011 Xamarin Inc.
//

using System;
using System.Runtime.InteropServices;
using MonoTouch.Foundation;

namespace RedLaser
{
	public partial class RedLaser : NSObject
	{
		[DllImport ("__Internal")] extern static RedLaserStatus RL_CheckReadyStatus ();
		
		public static RedLaserStatus CheckReadyStatus()
		{
			return RL_CheckReadyStatus();
		}
	}
}
