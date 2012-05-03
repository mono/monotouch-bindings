
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.CoreLocation;
namespace MTIKS{
	[BaseType (typeof (NSObject))]
	interface mtiks {
		[Static]
		[Export ("sharedSession")]
		mtiks SharedSession{get;}
	
		[Export ("getVersion")]
		string GetVersion ();
	
		[Export ("start:")]
		void Start (string strAppKey);
	
		[Export ("stop")]
		void Stop ();
	
		[Export ("postEvent:")]
		void PostEvent (string eventName);
	
		[Export ("postEvent:withAttributes:")]
		void PostEventwithAttributes (string eventName, NSDictionary attribs);
	}
}
