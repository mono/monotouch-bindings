using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace CouchbaseBinding
{
	[BaseType (typeof(NSObject))]
	[Model]
	interface CouchbaseDelegate
	{
		[Abstract]
		[Export ("couchbaseMobile:didStart:"), EventArgs ("CouchBaseStarted")]
		void Started (CouchbaseMobile couchbase, NSUrl serverURL);
		
		[Abstract]
		[Export ("couchbaseMobile:failedToStart:"), EventArgs ("CouchBaseError")]
		void FailedToStart (CouchbaseMobile couchbase, NSError error);

	}

	[BaseType (typeof(NSObject), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof(CouchbaseDelegate)})]
	interface CouchbaseMobile
	{

		[Export ("serverURL")]
		NSUrl ServerUrl { get; }

		[Export ("error")]
		NSError Error { get; }

		[Export ("autoRestart")]
		bool AutoRestart { get; set; }

		[Export ("rootDirectory")]
		string RootDirectory { get; set; }

		[Export ("logDirectory")]
		string LogDirectory { get; }

		[Export ("databaseDirectory")]
		string DatabaseDirectory { get; }

		[Export ("iniFilePath")]
		string IniFilePath { get; set; }

		[Export ("localIniFilePath")]
		string LocalIniFilePath { get; }

		[Export ("startCouchbase:")]
		CouchbaseMobile Start (CouchbaseDelegate theDelegate);

		[Export ("init")]
		NSObject Init ();

		[Export ("start")]
		bool Start ();

		[Export ("restart")]
		void Restart ();
		
		[Export ("initWithBundlePath:")]
		IntPtr Constructor (string bundlePath);

		[Export ("installDefaultDatabase:")]
		bool InstallDefaultDatabase (string databasePath);
		
		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		CouchbaseDelegate Delegate { get; set; }

	}

}

