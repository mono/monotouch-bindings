using System;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

namespace Parse
{
	delegate void PFBooleanResult (bool succeeded, NSError error);
	delegate void PFIntegerResult (int number, NSError error);
	delegate void PFArrayResult (NSArray objects, NSError error);
	delegate void PFObjectResult (PFObject theObject, NSError error);
	delegate void PFSetResult(NSSet channels, NSError error);
	delegate void PFUserResult (PFUser user, NSError error);
	delegate void PFDataResult (NSData data, NSError error);

}
