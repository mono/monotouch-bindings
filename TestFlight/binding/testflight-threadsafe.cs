using System;
using System.Runtime.InteropServices;
using MonoTouch.Foundation;

namespace MonoTouch.TestFlight
{
	public partial class TestFlight : NSObject
	{
		/// <summary>
		/// This is a better TakeOff methode for using with MonoTouch
		/// The default one tends to crash your app unexpectedly
		/// </summary>
		/// <param name="applicationToken">You can find your Application Token on the TestFlight site</param>
		public static void TakeOffThreadSafe(String applicationToken)
		{

				IntPtr sigbus = Marshal.AllocHGlobal (512);
				IntPtr sigsegv = Marshal.AllocHGlobal (512);
				IntPtr sigpipe = Marshal.AllocHGlobal (512);
				
				// Store Mono SIGSEGV and SIGBUS handlers
				sigaction (Signal.SIGBUS, IntPtr.Zero, sigbus);
				sigaction (Signal.SIGSEGV, IntPtr.Zero, sigsegv);
			  	sigaction (Signal.SIGPIPE, IntPtr.Zero, sigpipe);
				
				// Enable crash reporting libraries
				//MonoTouch.TestFlight.TestFlight.SetDeviceIdentifier(UIDevice.CurrentDevice.UniqueIdentifier);
				//MonoTouch.TestFlight.TestFlight.SetDeviceIdentifier(MonoTouch.AdSupport.ASIdentifierManager.SharedManager.AdvertisingIdentifier.ToString());
				TestFlight.TakeOff(applicationToken);
				
				// Restore Mono SIGSEGV and SIGBUS handlers            
				sigaction (Signal.SIGBUS, sigbus, IntPtr.Zero);
				sigaction (Signal.SIGSEGV, sigsegv, IntPtr.Zero);
				sigaction (Signal.SIGPIPE, sigpipe, IntPtr.Zero);
		 		
				Marshal.FreeHGlobal (sigbus);
				Marshal.FreeHGlobal (sigsegv);
				Marshal.FreeHGlobal (sigpipe);
		}

		private static void SetOption(NSString option, Boolean newValue)
		{
			TestFlight.SetOptions(new NSDictionary(option,NSNumber.FromBoolean(newValue)));
		}

		/// <summary>
		/// Setting to true attaches the current backtrace, with symbols, to the feedback
		/// </summary>
		/// <param name="newValue">Defaults to false</param>
		public static void SetAttachBacktraceToFeedback(Boolean newValue)
		{
			SetOption(new NSString("attachBacktraceToFeedback"),newValue);
		}

		/// <summary>
		/// Setting to true, disables the in app update screen shown in BETA apps when there is a new version available on TestFlight
		/// </summary>
		/// <param name="newValue">Defaults to false</param>
		public static void SetDisableInAppUpdates(Boolean newValue)
		{
			SetOption(new NSString("disableInAppUpdates"),newValue);
		}

		/// <summary>
		/// Prints remote logs to Apple System Log
		/// </summary>
		/// <param name="newValue">Defaults to true</param>
		public static void SetLogToConsole(Boolean newValue)
		{
			SetOption(new NSString("logToConsole"),newValue);
		}

		/// <summary>
		/// Sends remote logs to STDERR when debugger is attached
		/// </summary>
		/// <param name="newValue">Defaults to true</param>
		public static void SetLogToSTDERR(Boolean newValue)
		{
			SetOption(new NSString("logToSTDERR"),newValue);
		}

		/// <summary>
		/// If set to true: Reinstalls crash handlers, to be used if a third party library installs crash handlers overtop of the TestFlight Crash Handlers
		/// </summary>
		/// <param name="newValue">Only works when set to true</param>
		public static void SetReinstallCrashHandlers(Boolean newValue)
		{
			SetOption(new NSString("reinstallCrashHandlers"),newValue);
		}

		/// <summary>
		/// Setting to true stops remote logs from being sent when sessions end. They would only be sent in the event of a crash
		/// </summary>
		/// <param name="newValue">Defaults to false</param>
		public static void SetSendLogOnlyOnCrash(Boolean newValue)
		{
			SetOption(new NSString("sendLogOnlyOnCrash"),newValue);
		}



		[DllImport ("libc")]
		private static extern int sigaction (Signal sig, IntPtr act, IntPtr oact);
		enum Signal {
			SIGBUS = 10,
			SIGSEGV = 11,
			SIGPIPE = 13
		}
	}
}

