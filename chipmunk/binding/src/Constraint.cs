//
// Constraint.cs
//
// Author:
//   Stephane Delcroix <stephane@delcroix.org>
//
// Copyright © 2013 Stephane Delcroix. All Rights Reserved.

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Chipmunk
{
    public partial class Constraint : ChipmunkObject
    {
	internal Constraint (IntPtr ptr) : base (ptr)
	{
	}

	[DllImport ("__Internal")]
	extern static void cpConstraintFree (IntPtr constraint);
	
	protected override void Free ()
	{
	    cpConstraintFree (Handle.Handle);
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

    public partial class PinJoint : Constraint
    {
	[DllImport ("__Internal")]
	extern static IntPtr cpPinJointNew (IntPtr bodyA, IntPtr bodyB, PointF anchr1, PointF anchr2);

	public PinJoint (Body bodyA, Body bodyB, PointF anchr1, PointF anchr2) : base (cpPinJointNew (bodyA.Handle.Handle, bodyB.Handle.Handle, anchr1, anchr2))
	{
	}

	[DllImport ("__Internal")]
	extern static PointF __cpPinJointGetAnchr1 (IntPtr constraint);

	[DllImport ("__Internal")]
	extern static void __cpPinJointSetAnchr1 (IntPtr constraint, PointF value);

	public PointF Anchr1 {
	    get { return __cpPinJointGetAnchr1 (Handle.Handle); }
	    set { __cpPinJointSetAnchr1 (Handle.Handle, value); }
	}
		
	[DllImport ("__Internal")]
	extern static PointF __cpPinJointGetAnchr2 (IntPtr constraint);

	[DllImport ("__Internal")]
	extern static void __cpPinJointSetAnchr2 (IntPtr constraint, PointF value);

	public PointF Anchr2 {
	    get { return __cpPinJointGetAnchr2 (Handle.Handle); }
	    set { __cpPinJointSetAnchr2 (Handle.Handle, value); }
	}
	
	[DllImport ("__Internal")]
	extern static float __cpPinJointGetDist (IntPtr constraint);

	[DllImport ("__Internal")]
	extern static void __cpPinJointSetDist (IntPtr constraint, float value);

	public float Dist {
	    get { return __cpPinJointGetDist (Handle.Handle); }
	    set { __cpPinJointSetDist (Handle.Handle, value); }
	}
    }

    public partial class SlideJoint : Constraint
    {
	[DllImport ("__Internal")]
	extern static IntPtr cpSlideJointNew (IntPtr bodyA, IntPtr bodyB, PointF anchr1, PointF anchr2, float min, float max);

	public SlideJoint (Body bodyA, Body bodyB, PointF anchr1, PointF anchr2, float min, float max) : base (cpSlideJointNew (bodyA.Handle.Handle, bodyB.Handle.Handle, anchr1, anchr2, min, max))
	{
	}

	[DllImport ("__Internal")]
	extern static PointF __cpSlideJointGetAnchr1 (IntPtr constraint);

	[DllImport ("__Internal")]
	extern static void __cpSlideJointSetAnchr1 (IntPtr constraint, PointF value);

	public PointF Anchr1 {
	    get { return __cpSlideJointGetAnchr1 (Handle.Handle); }
	    set { __cpSlideJointSetAnchr1 (Handle.Handle, value); }
	}
		
	[DllImport ("__Internal")]
	extern static PointF __cpSlideJointGetAnchr2 (IntPtr constraint);

	[DllImport ("__Internal")]
	extern static void __cpSlideJointSetAnchr2 (IntPtr constraint, PointF value);

	public PointF Anchr2 {
	    get { return __cpSlideJointGetAnchr2 (Handle.Handle); }
	    set { __cpSlideJointSetAnchr2 (Handle.Handle, value); }
	}
	
	[DllImport ("__Internal")]
	extern static float __cpSlideJointGetMin (IntPtr constraint);

	[DllImport ("__Internal")]
	extern static void __cpSlideJointSetMin (IntPtr constraint, float value);

	public float Min {
	    get { return __cpSlideJointGetMin (Handle.Handle); }
	    set { __cpSlideJointSetMin (Handle.Handle, value); }
	}

	[DllImport ("__Internal")]
	extern static float __cpSlideJointGetMax (IntPtr constraint);

	[DllImport ("__Internal")]
	extern static void __cpSlideJointSetMax (IntPtr constraint, float value);

	public float Max {
	    get { return __cpSlideJointGetMax (Handle.Handle); }
	    set { __cpSlideJointSetMax (Handle.Handle, value); }
	}	
    }

    public partial class PivotJoint : Constraint
    {
	[DllImport ("__Internal")]
	extern static IntPtr cpPivotJointNew (IntPtr bodyA, IntPtr bodyB, PointF pivot);

	public PivotJoint (Body bodyA, Body bodyB, PointF pivot) : base (cpPivotJointNew (bodyA.Handle.Handle, bodyB.Handle.Handle, pivot))
	{
	}

	[DllImport ("__Internal")]
	extern static IntPtr cpPivotJointNew2 (IntPtr bodyA, IntPtr bodyB, PointF anchr1, PointF anchr2);
	
	public PivotJoint (Body bodyA, Body bodyB, PointF anchr1, PointF anchr2) : base (cpPivotJointNew2 (bodyA.Handle.Handle, bodyB.Handle.Handle, anchr1, anchr2))
	{
	}
										   
	[DllImport ("__Internal")]
	extern static PointF __cpPivotJointGetAnchr1 (IntPtr constraint);

	[DllImport ("__Internal")]
	extern static void __cpPivotJointSetAnchr1 (IntPtr constraint, PointF value);

	public PointF Anchr1 {
	    get { return __cpPivotJointGetAnchr1 (Handle.Handle); }
	    set { __cpPivotJointSetAnchr1 (Handle.Handle, value); }
	}
		
	[DllImport ("__Internal")]
	extern static PointF __cpPivotJointGetAnchr2 (IntPtr constraint);

	[DllImport ("__Internal")]
	extern static void __cpPivotJointSetAnchr2 (IntPtr constraint, PointF value);

	public PointF Anchr2 {
	    get { return __cpPivotJointGetAnchr2 (Handle.Handle); }
	    set { __cpPivotJointSetAnchr2 (Handle.Handle, value); }
	}
    }

    public partial class GrooveJoint : Constraint
    {
	[DllImport ("__Internal")]
	extern static IntPtr cpGrooveJointNew (IntPtr bodyA, IntPtr bodyB, PointF grooveA, PointF grooveB, PointF anchr2);

	public GrooveJoint (Body bodyA, Body bodyB, PointF grooveA, PointF grooveB, PointF anchr2) : base (cpGrooveJointNew (bodyA.Handle.Handle, bodyB.Handle.Handle, grooveA, grooveB, anchr2))
	{
	}

	[DllImport ("__Internal")]
	extern static PointF __cpGrooveJointGetGrooveA (IntPtr constraint);

	[DllImport ("__Internal")]
	extern static void __cpGrooveJointSetGrooveA (IntPtr constraint, PointF value);

	public PointF GrooveA {
	    get { return __cpGrooveJointGetGrooveA (Handle.Handle); }
	    set { __cpGrooveJointSetGrooveA (Handle.Handle, value); }
	}
		
	[DllImport ("__Internal")]
	extern static PointF __cpGrooveJointGetGrooveB (IntPtr constraint);

	[DllImport ("__Internal")]
	extern static void __cpGrooveJointSetGrooveB (IntPtr constraint, PointF value);

	public PointF GrooveB {
	    get { return __cpGrooveJointGetGrooveB (Handle.Handle); }
	    set { __cpGrooveJointSetGrooveB (Handle.Handle, value); }
	}
	
    	[DllImport ("__Internal")]
	extern static PointF __cpGrooveJointGetAnchr2 (IntPtr constraint);

	[DllImport ("__Internal")]
	extern static void __cpGrooveJointSetAnchr2 (IntPtr constraint, PointF value);

	public PointF Anchr2 {
	    get { return __cpGrooveJointGetAnchr2 (Handle.Handle); }
	    set { __cpGrooveJointSetAnchr2 (Handle.Handle, value); }
	}
    }

    public partial class DampedSpring : Constraint
    {
	[DllImport("__Internal")]
	extern static IntPtr cpDampedSpringNew (IntPtr bodyA, IntPtr bodyB, PointF anchr1, PointF anchr2, float restLength, float stiffness, float damping);

	public DampedSpring (Body bodyA, Body bodyB, PointF anchr1, PointF anchr2, float restLength, float stiffness, float damping) : base (cpDampedSpringNew (bodyA.Handle.Handle, bodyB.Handle.Handle, anchr1, anchr2, restLength, stiffness, damping))
	{
	}

	[DllImport("__Internal")]
	extern static PointF __cpDampedSpringGetAnchr1 (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpDampedSpringSetAnchr1 (IntPtr constraint, PointF value);

	public PointF Anchr1 {
	    get { return __cpDampedSpringGetAnchr1 (Handle.Handle); }
	    set { __cpDampedSpringSetAnchr1 (Handle.Handle, value); }
	}

	[DllImport("__Internal")]
	extern static PointF __cpDampedSpringGetAnchr2 (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpDampedSpringSetAnchr2 (IntPtr constraint, PointF value);

	public PointF Anchr2 {
	    get { return __cpDampedSpringGetAnchr2 (Handle.Handle); }
	    set { __cpDampedSpringSetAnchr2 (Handle.Handle, value); }
	}

	[DllImport("__Internal")]
	extern static PointF __cpDampedSpringGetRestLength (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpDampedSpringSetRestLength (IntPtr constraint, PointF value);

	public PointF RestLength {
	    get { return __cpDampedSpringGetRestLength (Handle.Handle); }
	    set { __cpDampedSpringSetRestLength (Handle.Handle, value); }
	}

	[DllImport("__Internal")]
	extern static PointF __cpDampedSpringGetStiffness (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpDampedSpringSetStiffness (IntPtr constraint, PointF value);

	public PointF Stiffness {
	    get { return __cpDampedSpringGetStiffness (Handle.Handle); }
	    set { __cpDampedSpringSetStiffness (Handle.Handle, value); }
	}

	[DllImport("__Internal")]
	extern static PointF __cpDampedSpringGetDamping (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpDampedSpringSetDamping (IntPtr constraint, PointF value);

	public PointF Damping {
	    get { return __cpDampedSpringGetDamping (Handle.Handle); }
	    set { __cpDampedSpringSetDamping (Handle.Handle, value); }
	}
    }
}

