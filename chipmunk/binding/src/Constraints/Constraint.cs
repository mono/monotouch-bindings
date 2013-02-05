//
// Constraint.cs
//
// Author:
//   Stephane Delcroix <stephane@delcroix.org>
//
// Copyright © 2013 Stephane Delcroix. All Rights Reserved.

using System;
using System.Runtime.InteropServices;

namespace Chipmunk
{
    public abstract partial class Constraint : ChipmunkObject
    {
	protected Constraint (IntPtr ptr) : base (ptr)
	{
	}

	[DllImport("__Internal")]
	extern static IntPtr __cpConstraintGetA (IntPtr constraint);

	public Body A {
	    get { return new Body (__cpConstraintGetA (Handle.Handle)); }
	}

	[DllImport("__Internal")]
	extern static IntPtr __cpConstraintGetB (IntPtr constraint);

	public Body B {
	    get { return new Body (__cpConstraintGetA (Handle.Handle)); }
	}

	[DllImport("__Internal")]
	extern static float __cpConstraintGetMaxForce (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpConstraintSetMaxForce (IntPtr constraint, float value);

	public float MaxForce {
	    get { return __cpConstraintGetMaxForce (Handle.Handle); }
	    set { __cpConstraintSetMaxForce (Handle.Handle, value); }
	}

	[DllImport("__Internal")]
	extern static float __cpConstraintGetErrorBias (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpConstraintSetErrorBias (IntPtr constraint, float value);

	public float ErrorBias {
	    get { return __cpConstraintGetErrorBias (Handle.Handle); }
	    set { __cpConstraintSetErrorBias (Handle.Handle, value); }
	}

	[DllImport("__Internal")]
	extern static float __cpConstraintGetMaxBias (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpConstraintSetMaxBias (IntPtr constraint, float value);

	public float MaxBias {
	    get { return __cpConstraintGetMaxBias (Handle.Handle); }
	    set { __cpConstraintSetMaxBias (Handle.Handle, value); }
	}
	
	[DllImport ("__Internal")]
	extern static IntPtr __cpConstraintGetSpace (IntPtr constraint);

	public Space Space {
	    get { return new Space (__cpConstraintGetSpace (Handle.Handle)); }
	}

	[DllImport("__Internal")]
	extern static float __cpConstraintGetImpulse (IntPtr constraint);

	public float Impulse {
	    get { return __cpConstraintGetImpulse (Handle.Handle); }
	}

    }
}

