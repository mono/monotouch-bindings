//
// extensions.cs: Convenience methods.
//
//	Authors:
//		Alex Soto (alex.soto@xamarin.com)
//
//

using System;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace MonoTouch.FacebookConnect
{
	public partial class FBGraphUser : FBGraphObject
	{
		public FBGraphUser (NSObject requestResult) : this(requestResult.Handle)
		{
		}

		public FBGraphPlace Location 
		{
			get { return Location_ != null ? new FBGraphPlace (Location_.Handle) : null; }
			set { Location_ = new NSObject (value.Handle); }
		}
	}

	public partial class FBGraphPlace : FBGraphObject
	{
		public FBGraphPlace (NSObject requestResult) : this(requestResult.Handle)
		{
		}

		public FBGraphLocation Location
		{
			get { return Location_!= null ? new FBGraphLocation(Location_.Handle) : null; }
			set	{ Location_ = new NSObject(value.Handle); }
		}
	}

	public partial class FBGraphLocation : FBGraphObject
	{
		public FBGraphLocation (NSObject requestResult) : this(requestResult.Handle)
		{
		}
	}

	public partial class FBOpenGraphAction : FBGraphObject
	{
		public FBOpenGraphAction (NSObject requestResult) : this(requestResult.Handle)
		{
		}

		public FBGraphPlace Place
		{
			get { return Place_ != null ? new FBGraphPlace(Place_.Handle) : null; }
			set	{ Place_ = new NSObject(value.Handle); }
		}

		public FBGraphUser From
		{
			get	{ return From_ != null ? new FBGraphUser(From_.Handle) : null; }
			set	{ From_ = new NSObject(value.Handle); }
		}

		public FBGraphObject Application
		{
			get { return Application_ != null ? new FBGraphObject(Application_.Handle) : null; }
			set	{ From_ = new NSObject(value.Handle); }
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

