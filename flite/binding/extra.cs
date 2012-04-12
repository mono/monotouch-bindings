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

namespace Flite
{
	public partial class Flite
	{
		[DllImport ("__Internal")] extern static int czx_flite_main_with_voice(string message, string output, int voiceIndex);		
		public static void ConvertTextToWav(string message, string output, int voiceIndex) {
			czx_flite_main_with_voice(message, output, voiceIndex);
		}
	}
}
