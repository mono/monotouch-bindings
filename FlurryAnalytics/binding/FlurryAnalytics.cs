using System;
using MonoTouch.Foundation;
namespace FlurryAnalytics
{
	[BaseType (typeof (NSObject))]
	interface FlurryAnalytics {
		[Static]
		[Export ("setAppVersion:")]
		void SetAppVersion (string version);

		[Static]
		[Export ("getFlurryAgentVersion")]
		string GetFlurryAgentVersion ();

		[Static]
		[Export ("setShowErrorInLogEnabled:")]
		void SetShowErrorInLog (bool value);

		[Static]
		[Export ("setDebugLogEnabled:")]
		void SetDebugLog (bool value);

		[Static]
		[Export ("setSessionContinueSeconds:")]
		void SetSessionContinue (int seconds);

		[Static]
		[Export ("setSecureTransportEnabled:")]
		void SetSecureTransportEnabled (bool value);

		[Static]
		[Export ("startSession:")]
		void StartSession (string apiKey);

		[Static]
		[Export ("logEvent:")]
		void LogEvent (string eventName);

		[Static]
		[Export ("logEvent:withParameters:")]
		void LogEvent (string eventName, NSDictionary parameters);

		[Static]
		[Export ("logError:message:exception:")]
		void LogError (string errorID, string message, NSException exception);

		[Static]
		[Export ("logError:message:error:")]
		void LogError (string errorID, string message, NSError error);

		[Static]
		[Export ("logEvent:timed:")]
		void LogEvent (string eventName, bool timed);

		[Static]
		[Export ("logEvent:withParameters:timed:")]
		void LogEvent (string eventName, NSDictionary parameters, bool timed);

		[Static]
		[Export ("endTimedEvent:withParameters:")]
		void EndTimedEvent (string eventName, NSDictionary parameters);
	
		// automatically track page view on UINavigationController or UITabBarController
		[Static]
		[Export ("logAllPageViews:")]
		void LogAllPageViews (NSObject target);

		[Static]
		[Export ("logPageView")]
		void LogPageView ();

		[Static]
		[Export ("setUserID:")]
		void SetUserID (string userID);

		[Static]
		[Export ("setAge:")]
		void SetAge (int age);

		[Static]
		[Export ("setGender:")]
		void SetGender (string gender);

		[Static]
		[Export ("setLatitude:longitude:horizontalAccuracy:verticalAccuracy:")]
		void SetLocation (double latitude, double longitude, float horizontalAccuracy, float verticalAccuracy);

		[Static]
		[Export ("setSessionReportsOnCloseEnabled:")]
		void SetSessionReportsOnClose (bool sendSessionReportsOnClose);

		[Static]
		[Export ("setSessionReportsOnPauseEnabled:")]
		void SetSessionReportsOnPause (bool setSessionReportsOnPauseEnabled);

		[Static]
		[Export ("setEventLoggingEnabled:")]
		void SetEventLogging (bool value);

	}
}
