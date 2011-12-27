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

namespace MonoTouch.TestFlight
{
	public partial class TestFlight : NSObject
	{
		[DllImport("__Internal", EntryPoint = "TFLog")]
		private extern static void WrapperTfLog(IntPtr handle);
		
		public static void Log (string msg, params object [] args)
		{
		     using (var nss = new NSString (string.Format (msg, args)))
		         WrapperTfLog (nss.Handle);
		}
	}
}
