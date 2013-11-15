using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CrittercismSdk
{
	[BaseType (typeof (NSObject))]
	public partial interface CRFilter {

		[Export ("onlyScrubQuery")]
		bool OnlyScrubQuery { get; }

		[Static, Export ("filterWithString:")]
		CRFilter FromFilter (string matchToken);

		[Static, Export ("queryOnlyFilterWithString:")]
		CRFilter FromQueryOnlyFilter (string matchToken);

		[Export ("initWithString:")]
		IntPtr Constructor (string matchToken);

		[Export ("initWithString:queryOnly:")]
		IntPtr Constructor (string matchToken, bool onlyScrubQuery);

		[Export ("doesMatch:")]
		bool DoesMatch (string url);

		[Export ("applyToURL:")]
		string ApplyToUrl (string url);
	}

	[BaseType (typeof (NSObject))]
	public partial interface Crittercism {

		[Static, Export ("enableWithAppID:")]
		void EnableWithAppId (string appId);

		[Static, Export ("enableWithAppID:andDelegate:")]
		void EnableWithAppId (string appId, ICrittercismDelegate critterDelegate);

		[Static, Export ("enableWithAppID:andDelegate:andURLFilters:")]
		void EnableWithAppId (string appId, ICrittercismDelegate critterDelegate, CRFilter[] filters);

		[Static, Export ("enableWithAppID:andURLFilters:")]
		void EnableWithAppId (string appId, CRFilter[] filters);

		[Static, Export ("enableWithAppID:andDelegate:andURLFilters:disableInstrumentation:")]
		void EnableWithAppId (string appId, ICrittercismDelegate critterDelegate, CRFilter[] filters, bool disableInstrumentation);

		[Static, Export ("addFilter:")]
		void AddFilter (CRFilter filter);

		[Static, Export ("leaveBreadcrumb:")]
		void LeaveBreadcrumb (string breadcrumb);

		[Static, Export ("asyncBreadcrumbMode")]
		bool AsyncBreadcrumbMode { set; }

		[Static, Export ("logHandledException:")]
		bool LogHandledException (NSException exception);

		[Static, Export ("optOutStatus")]
		bool OptOutStatus { [Bind ("getOptOutStatus")] get; set; }

		[Static, Export ("maxOfflineCrashReports")]
		uint MaxOfflineCrashReports { get; set; }

		[Static, Export ("userUUID")]
		string UserUuid { [Bind ("getUserUUID")] get; }

		[Static, Export ("username")]
		string Username { set; }

		[Static, Export ("setValue:forKey:")]
		void SetValue (string value, string key);

		[Export ("delegate")][NullAllowed]
		ICrittercismDelegate Delegate { get; set; }

		[Export ("didCrashOnLastLoad")]
		bool DidCrashOnLastLoad { get; }
	}

	public interface ICrittercismDelegate { }

	[Protocol, Model, BaseType (typeof (NSObject))]
	public partial interface CrittercismDelegate {

		[Export ("crittercismDidCrashOnLastLoad")]
		void CrittercismDidCrashOnLastLoad ();
	}
}

