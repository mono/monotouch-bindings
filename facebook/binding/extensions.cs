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
	public partial class FBGraphObject : NSObject
	{
		public NSObject this [string key]
		{
			get{ return this.ObjectForKey (key); }
			set{ this.SetObject (value,key); }
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

	public partial class FBGraphUser : FBGraphObject
	{
		public string Id { 
			get { return GetId (); } 
			set { SetId (value); } 
		}

		public string Name { 
			get { return GetName (); } 
			set { SetName (value); } 
		}

		public string FirstName { 
			get { return GetFirstName (); } 
			set { SetFirstName (value); } 
		}

		public string MiddleName { 
			get { return GetMiddleName (); } 
			set { SetMiddleName (value); } 
		}

		public string LastName { 
			get { return GetLastName (); } 
			set { SetLastName (value); } 
		}

		public string Link { 
			get { return GetLink (); } 
			set { SetLink (value); } 
		}

		public string Username { 
			get { return GetUsername (); } 
			set { SetUsername (value); } 
		}

		public string Birthday { 
			get { return GetBirthday (); } 
			set { SetBirthday (value); } 
		}

		public FBGraphPlace Location { 
			get { return GetLocation () != IntPtr.Zero ? new FBGraphPlace (GetLocation ()) : null; } 
			set { SetLocation (value.Handle); } 
		}
	}

	public partial class FBGraphPlace : FBGraphObject
	{
		public string Id { 
			get { return GetId (); } 
			set { SetId (value); } 
		}

		public string Name { 
			get { return GetName (); } 
			set { SetName (value); } 
		}

		public string Category { 
			get { return GetCategory (); } 
			set { SetCategory (value); } 
		}

		public FBGraphLocation Location { 
			get { return GetLocation () != IntPtr.Zero ? new FBGraphLocation (GetLocation ()) : null; } 
			set { SetLocation (value.Handle); } 
		}
	}

	public partial class FBGraphLocation : FBGraphObject
	{
		public string Street { 
			get { return GetStreet (); }
			set { SetStreet (value); } 
		}

		public string City { 
			get { return GetCity (); }
			set { SetCity (value); }
		}

		public string State { 
			get { return GetState (); } 
			set { SetState (value); }
		}

		public string Country { 
			get { return GetCountry (); }
			set { SetCountry (value); }
		}

		public string Zip { 
			get { return GetZip (); } 
			set { SetZip (value); }
		}

		public NSNumber Latitude { 
			get { return GetLatitude (); } 
			set { SetLatitude (value); } 
		}

		public NSNumber Longitude { 
			get { return GetLongitude (); }
			set { SetLongitude (value);}
		}
	}

	public partial class FBOpenGraphAction : FBGraphObject
	{
		public string Id { 
			get { return GetId (); }
			set { SetId (value); } 
		}

		public string StartTime { 
			get { return GetStartTime (); } 
			set { SetStartTime (value); }
		}

		public string EndTime { 
			get { return GetEndTime (); } 
			set { SetEndTime (value); }
		}

		public string PublishTime { 
			get { return GetPublishTime (); }
			set { SetPublishTime (value); }
		}

		public string CreatedTime { 
			get { return GetCreatedTime (); }
			set { SetCreatedTime (value); }
		}

		public string ExpiresTime { 
			get { return GetExpiresTime (); } 
			set { SetExpiresTime (value); } 
		}

		public string Ref { 
			get { return GetRef (); }
			set { SetRef (value); } 
		}

		public string Message { 
			get { return GetMessage (); } 
			set { SetMessage (value); } 
		}

		public FBGraphPlace Place { 
			get { return GetPlace () != IntPtr.Zero ? new FBGraphPlace (GetPlace ()) : null; } 
			set { SetPlace (value.Handle); }
		}

		public NSObject [] Tags { 
			get { return GetTags (); }
			set { SetTags (value); }
		}
		public NSObject Image { 
			get { return GetImage (); } 
			set { SetImage (value); }
		}

		public FBGraphUser From { 
			get { return GetFrom () != IntPtr.Zero ? new FBGraphUser (GetFrom ()) : null; } 
			set { SetFrom (value.Handle); } 
		}

		public NSObject [] Likes { 
			get { return GetLikes (); } 
			set { SetLikes (value); } 
		}

		public FBGraphObject Application { 
			get { return GetApplication (); } 
			set { SetApplication (value); } 
		}

		public NSObject [] Comments { 
			get { return GetComments (); } 
			set { SetComments (value); }
		}
	}

	public partial class FBOpenGraphObject : FBGraphObject
	{
		public string Id { 
			get { return GetId (); }
			set { SetId (value); } 
		}

		public string aType { 
			get { return GetAType (); } 
			set { SetAType (value); }
		}
		public string Title { 
			get { return GetTitle (); }
			set { SetTitle (value); }
		}

		public NSObject Image { 
			get { return GetImage (); } 
			set { SetImage (value); }
		}

		public NSObject Url { 
			get { return GetUrl (); } 
			set { SetUrl (value); }
		}

		public NSObject ObjectDescription { 
			get { return GetDescription (); } 
			set { SetDescription (value); }
		}

		public FBGraphObject Data { 
			get { return GetData (); } 
			set { SetData (value); }
		}
	}

	public partial class FBFriendPickerViewController : FBViewController
	{
		public FBGraphUser [] Selection
		{
			get 
			{ 
				IntPtr ptr = Selection_;
				NSArray arr = new NSArray(ptr);

				List<FBGraphUser> list = new List<FBGraphUser>();

				for (uint i = 0; i < arr.Count; i++) 
				{
					list.Add(new FBGraphUser(arr.ValueAt(i)));
				}

				return list.ToArray();
			}
		}
	}

	public partial class FBPlacePickerViewController : FBViewController
	{
		public FBGraphPlace Selection
		{
			get { return new FBGraphPlace (Selection_); }
		}
	}
}

