//
// ChipmunkObject.cs
//
// Authors:
//  Stephane Delcroix <stephane@delcroix.org>
//
// Copyright 2012 S. Delcroix
//

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Chipmunk
{
    public abstract class ChipmunkObject : IDisposable
    {
	static Dictionary<IntPtr, List<ChipmunkObject>> references = new Dictionary<IntPtr, List<ChipmunkObject>> ();

	public HandleRef Handle { get; private set;}

	public void Dispose ()
	{
	    Cleanup ();

	    System.GC.SuppressFinalize (this);
	}

	bool refcount;
	internal protected ChipmunkObject (IntPtr ptr, bool refcount = true)
	{
	    Handle = new HandleRef (this, ptr);
	    this.refcount = refcount;
	    if (refcount) 
		AddRef (this, ptr);

	    if (refcount) //Don't set it for Arbiters, as we have no way to free it
		UserData = GCHandle.ToIntPtr (GCHandle.Alloc (this));
	}

	public static bool operator ==(ChipmunkObject a, ChipmunkObject b)
	{
	    if (System.Object.ReferenceEquals (a, b))
		return true;

	    if (((object)a == null) || ((object)b == null))
		return false;

	    return a.Handle.Handle == b.Handle.Handle;
	}

	public static bool operator != (ChipmunkObject a, ChipmunkObject b)
	{
	    return !(a == b);
	}

	public override bool Equals (System.Object obj)
	{
	    var other = obj as ChipmunkObject;
	    if ((object)other == null)
		return false;

	    return this == other;
	}

	public override int GetHashCode ()
	{
	    return Handle.Handle.GetHashCode ();
	}

	~ChipmunkObject ()
	{
	    Cleanup ();
	}

	void Cleanup ()
	{
	    if (refcount && UserData!= IntPtr.Zero) {
		var gchandle = GCHandle.FromIntPtr (UserData);
		gchandle.Free ();
	    }
	    
	    if (refcount && RemoveRef (this, Handle.Handle))
		Free ();
	    Handle = new HandleRef (this, IntPtr.Zero);
	}

	protected virtual void Free ()
	{
	}

	static void AddRef (ChipmunkObject obj, IntPtr ptr)
	{
	    List<ChipmunkObject> list;
	    if (!references.TryGetValue (ptr, out list)){
		list = new List<ChipmunkObject> ();
		references.Add (ptr, list);
	    }
	    list.Add (obj);
	}

	static bool RemoveRef (ChipmunkObject obj, IntPtr ptr)
	{
	    List<ChipmunkObject> list;
	    if (references.TryGetValue (ptr, out list)) {
		list.Remove (obj);
		if (list.Count == 0) {
		    references.Remove (ptr);
		    return true;
		}
		return false;
	    }
#if DEBUG
	    throw new InvalidOperationException ();
#endif
	    return false;
	}

	internal abstract IntPtr UserData { get; set; }
    }    
}
