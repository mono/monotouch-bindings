//
// Arbiter.cs
//
// Author:
//   Stephane Delcroix <stephane@delcroix.org>
//
// Copyright © 2013 Stephane Delcroix. All Rights Reserved.

using System;
using System.Runtime.InteropServices;

using Foundation;
using UIKit;
using CoreGraphics;

namespace Chipmunk
{
    public sealed partial class Arbiter : ChipmunkObject
    {
	public Arbiter (IntPtr ptr) : base (ptr, false)
	{
	} 

	[DllImport ("__Internal")]
	extern static float __cpArbiterGetElasticity (IntPtr arbiter);

	[DllImport ("__Internal")]
	extern static void __cpArbiterSetElasticity (IntPtr arbiter, float value);

	public float Elasticity {
	    get { return __cpArbiterGetElasticity (Handle.Handle); }
	    set { __cpArbiterSetElasticity (Handle.Handle, value); }
	}	

	[DllImport ("__Internal")]
	extern static float __cpArbiterGetFriction (IntPtr arbiter);

	[DllImport ("__Internal")]
	extern static void __cpArbiterSetFriction (IntPtr arbiter, float value);

	public float Friction {
	    get { return __cpArbiterGetFriction (Handle.Handle); }
	    set { __cpArbiterSetFriction (Handle.Handle, value); }
	}	

/*
	[DllImport ("__Internal")]
	extern static CGPoint __cpArbiterGetSurfaceVelocity (IntPtr arbiter);

	[DllImport ("__Internal")]
	extern static void __cpArbiterSetSurfaceVelocity (IntPtr arbiter, CGPoint value);

	public CGPoint SurfaceVelocity {
	    get { return __cpArbiterGetSurfaceVelocity (Handle.Handle); }
	    set { __cpArbiterSetSurfaceVelocity (Handle.Handle, value); }
	}
*/

	[DllImport ("__Internal")]
	extern static int cpArbiterGetCount (IntPtr arbiter);

	public int Count {
	    get { return cpArbiterGetCount (Handle.Handle); }
	}
	
	[DllImport ("__Internal")]
	extern static CGPoint cpArbiterGetNormal (IntPtr arbiter, int i);

	public CGPoint GetNormal (int i)
	{
	    return cpArbiterGetNormal (Handle.Handle, i);
	}

	[DllImport ("__Internal")]
	extern static CGPoint cpArbiterGetPoint (IntPtr arbiter, int i);

	public CGPoint GetPoint (int i)
	{
	    return cpArbiterGetPoint (Handle.Handle, i);
	}

	[DllImport ("__Internal")]
	extern static float cpArbiterGetDepth (IntPtr arbiter, int i);

	public float GetDepth (int i)
	{
	    return cpArbiterGetDepth (Handle.Handle, i);
	}
	
	[DllImport ("__Internal")]
	extern static bool cpArbiterIsFirstContact (IntPtr arbiter);

	public bool IsFirstContact {
	    get { return cpArbiterIsFirstContact (Handle.Handle); }
	}

	[DllImport ("__Internal")]
	extern static void __cpArbiterGetShapes(IntPtr arbiter, out IntPtr shapeA, out IntPtr shapeB);

	public void GetShapes (out Shape shapeA, out Shape shapeB)
	{
	    IntPtr a, b;
	    __cpArbiterGetShapes (Handle.Handle, out a, out b);
	    shapeA = Shape.FromIntPtr (a);
	    shapeB = Shape.FromIntPtr (b);
	}

	[DllImport ("__Internal")]
	extern static void __cpArbiterGetBodies(IntPtr arbiter, out IntPtr bodyA, out IntPtr bodyB);

	public void GetBodies (out Body bodyA, out Body bodyB)
	{
	    IntPtr a, b;
	    __cpArbiterGetBodies (Handle.Handle, out a, out b);
	    bodyA = Body.FromIntPtr (a);
	    bodyB = Body.FromIntPtr (b);
	}
	
	//TODO contact point set
	
	[DllImport ("__Internal")]
	extern static CGPoint cpArbiterTotalImpulseWithFriction (IntPtr arbiter);

	public CGPoint TotalImpulseWithFriction {
	    get { return cpArbiterTotalImpulseWithFriction (Handle.Handle); }
	}

	[DllImport ("__Internal")]
	extern static CGPoint cpArbiterTotalImpulse (IntPtr arbiter);

	public CGPoint TotalImpulse {
	    get { return cpArbiterTotalImpulse (Handle.Handle); }
	}

	[DllImport ("__Internal")]
	extern static float cpArbiterTotalKE (IntPtr arbiter);

	public float TotalKE {
	    get { return cpArbiterTotalKE (Handle.Handle); }
	}
	
	[DllImport("__Internal")]
	extern static IntPtr __cpArbiterGetUserData (IntPtr body);

	[DllImport("__Internal")]
	extern static void __cpArbiterSetUserData (IntPtr body, IntPtr userData);

	internal override IntPtr UserData {
	    get { return __cpArbiterGetUserData (Handle.Handle); }
	    set { __cpArbiterSetUserData (Handle.Handle, value); }
	}
    }
}
