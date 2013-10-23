//
// extensions.cs: Convenience methods.
//
//	Authors:
//		Alex Soto (alex.soto@xamarin.com)
//
//

using System;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using System.Collections.Generic;

namespace MonoTouch.FacebookConnect
{
	public partial class FBGraphObject
	{
		public NSObject this [string key]
		{
			get{ return this.ObjectForKey (key); }
			set{ this.SetObject (value, key); }
		}

		public static FBGraphObject [] FromResultObject (NSObject resultObject)
		{
			var results = new List<FBGraphObject> ();
			var dataObject = resultObject.ValueForKey (new NSString ("data")) as NSMutableArray;
			for (uint i = 0; i < dataObject.Count; i++) {
				var o = Runtime.GetNSObject (dataObject.ValueAt (i));
				results.Add (o as FBGraphObject);
			}
			return results.ToArray ();
		}
	}
}