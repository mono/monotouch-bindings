using System;
using System.Runtime.InteropServices;
using MonoTouch.Foundation;

namespace MonoTouch.TestFlight
{
	public partial class TestFlight : NSObject
	{
		public static void TakeOffThreadSafe(String applicationToken)
		{

				IntPtr sigbus = Marshal.AllocHGlobal (512);
				IntPtr sigsegv = Marshal.AllocHGlobal (512);
				
				// Store Mono SIGSEGV and SIGBUS handlers
				sigaction (Signal.SIGBUS, IntPtr.Zero, sigbus);
				sigaction (Signal.SIGSEGV, IntPtr.Zero, sigsegv);
				
				// Enable crash reporting libraries
				//MonoTouch.TestFlight.TestFlight.SetDeviceIdentifier(UIDevice.CurrentDevice.UniqueIdentifier);
				//MonoTouch.TestFlight.TestFlight.SetDeviceIdentifier(MonoTouch.AdSupport.ASIdentifierManager.SharedManager.AdvertisingIdentifier.ToString());
				TestFlight.TakeOff(applicationToken);
				
				// Restore Mono SIGSEGV and SIGBUS handlers            
				sigaction (Signal.SIGBUS, sigbus, IntPtr.Zero);
				sigaction (Signal.SIGSEGV, sigsegv, IntPtr.Zero);
				
				Marshal.FreeHGlobal (sigbus);
				Marshal.FreeHGlobal (sigsegv);

		}

		private static void setOption(NSString option, Boolean newValue)
		{
			TestFlight.SetOptions(new NSDictionary(option,NSNumber.FromBoolean(newValue)));
		}

		public static void setAttachBacktraceToFeedback(Boolean newValue)
		{
			setOption(new NSString("attachBacktraceToFeedback"),newValue);
		}

		public static void setDisableInAppUpdates(Boolean newValue)
		{
			setOption(new NSString("disableInAppUpdates"),newValue);
		}

		public static void setLogToConsole(Boolean newValue)
		{
			setOption(new NSString("logToConsole"),newValue);
		}

		public static void setLogToSTDERR(Boolean newValue)
		{
			setOption(new NSString("logToSTDERR"),newValue);
		}

		public static void setReinstallCrashHandlers(Boolean newValue)
		{
			setOption(new NSString("reinstallCrashHandlers"),newValue);
		}

		public static void setSendLogOnlyOnCrash(Boolean newValue)
		{
			setOption(new NSString("sendLogOnlyOnCrash"),newValue);
		}



		[DllImport ("libc")]
		private static extern int sigaction (Signal sig, IntPtr act, IntPtr oact);
		enum Signal {
			SIGBUS = 10,
			SIGSEGV = 11
		}
	}
}

