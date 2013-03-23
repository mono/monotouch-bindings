//
// testflight.cs: API definition for the TestFlight SDK
//
// Authors:
//  Miguel de Icaza (miguel@xamarin.com)
//
// Copyright 2011 Xamarin Inc.
//

using System;
using MonoTouch.Foundation;

namespace MonoTouch.TestFlight {

	[BaseType (typeof (NSObject))]
	public interface TestFlight {
		[Static, Export ("addCustomEnvironmentInformation:forKey:")]
		void AddCustomEnvironmentInformation (string information, string key);

		[Static, Export ("takeOff:")]
		void TakeOff (string applicationToken);

		// The values that the dictionary accepts:
		// TFOptionAttachBacktraceToFeedback => NSNumber.Boolean, Defaults to @NO. Setting to @YES attaches the current backtrace, with symbols, to the feedback.
		// TFOptionDisableInAppUpdates => NSNumber.Boolean, Defaults to @NO. Setting to @YES, disables the in app update screen shown in BETA apps when there is a new version available on TestFlight.
		// TFOptionLogToConsole => NSNumber.Boolean, Defaults to @YES. Prints remote logs to Apple System Log.
		// TFOptionLogToSTDERR => NSNumber.Boolean, Defaults to @YES. Sends remote logs to STDERR when debugger is attached.
		// TFOptionReinstallCrashHandlers => NSNumber.Boolean, If set to @YES: Reinstalls crash handlers, to be used if a third party library installs crash handlers overtop of the TestFlight Crash Handlers.
		// TFOptionSendLogOnlyOnCrash => NSNumber.Boolean, Defaults to @NO. Setting to @YES stops remote logs from being sent when sessions end. They would only be sent in the event of a crash.
		[Static, Export ("setOptions:")]
		void SetOptions (NSDictionary options);

		[Static, Export ("passCheckpoint:")]
		void PassCheckpoint (string checkpointName);

		[Static, Export ("openFeedbackView")]
		void OpenFeedbackView ();

		[Static, Export ("submitFeedback:")]
		void SubmitFeedback (string feedback);

		[Static, Export ("setDeviceIdentifier:")]
		void SetDeviceIdentifier (string deviceIdentifer);


	}

	//The NSStrings used for the options could be exposed to C#, but this doesn't seem to work. (someone please fix)
	//They are kept for refrence.
	//For now these constants are not used and the bindings define them themself
//	[Static]
//	public interface TestFlightOptions {
//		[Static, Field("TFOptionAttachBacktraceToFeedback","__Internal")]
//		NSString AttachBacktraceToFeedback {get;}
//		
//		[Static, Field("TFOptionDisableInAppUpdates","__Internal")]
//		NSString DisableInAppUpdates {get;}
//		
//		[Static, Field("TFOptionLogToConsole","__Internal")]
//		NSString LogToConsole {get;}
//		
//		[Static, Field("TFOptionLogToSTDERR","__Internal")]
//		NSString LogToSTDERR {get;}
//		
//		[Static, Field("TFOptionReinstallCrashHandlers","__Internal")]
//		NSString ReinstallCrashHandlers {get;}
//		
//		[Static, Field("TFOptionSendLogOnlyOnCrash","__Internal")]
//		NSString SendLogOnlyOnCrash {get;}
//	}
}