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
	extern static float __cpDampedSpringGetRestLength (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpDampedSpringSetRestLength (IntPtr constraint, float value);

	public float RestLength {
	    get { return __cpDampedSpringGetRestLength (Handle.Handle); }
	    set { __cpDampedSpringSetRestLength (Handle.Handle, value); }
	}

	[DllImport("__Internal")]
	extern static float __cpDampedSpringGetStiffness (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpDampedSpringSetStiffness (IntPtr constraint, float value);

	public float Stiffness {
	    get { return __cpDampedSpringGetStiffness (Handle.Handle); }
	    set { __cpDampedSpringSetStiffness (Handle.Handle, value); }
	}

	[DllImport("__Internal")]
	extern static float __cpDampedSpringGetDamping (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpDampedSpringSetDamping (IntPtr constraint, float value);

	public float Damping {
	    get { return __cpDampedSpringGetDamping (Handle.Handle); }
	    set { __cpDampedSpringSetDamping (Handle.Handle, value); }
	}
    }

    public partial class DampedRotarySpring : Constraint
    {
	[DllImport ("__Internal")]
	extern static IntPtr cpDampedRotarySpringNew (IntPtr bodyA, IntPtr bodyB, float restAngle, float stiffness, float damping);

	public DampedRotarySpring (Body bodyA, Body bodyB, float restAngle, float stiffness, float damping) : base (cpDampedRotarySpringNew (bodyA.Handle.Handle, bodyB.Handle.Handle, restAngle, stiffness, damping))
	{
	}

	[DllImport("__Internal")]
	extern static float __cpDampedRotarySpringGetRestAngle (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpDampedRotarySpringSetRestAngle (IntPtr constraint, float value);

	public float RestAngle {
	    get { return __cpDampedRotarySpringGetRestAngle (Handle.Handle); }
	    set { __cpDampedRotarySpringSetRestAngle (Handle.Handle, value); }
	}

	[DllImport("__Internal")]
	extern static float __cpDampedRotarySpringGetStiffness (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpDampedRotarySpringSetStiffness (IntPtr constraint, float value);

	public float Stiffness {
	    get { return __cpDampedRotarySpringGetStiffness (Handle.Handle); }
	    set { __cpDampedRotarySpringSetStiffness (Handle.Handle, value); }
	}

	[DllImport("__Internal")]
	extern static float __cpDampedRotarySpringGetDamping (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpDampedRotarySpringSetDamping (IntPtr constraint, float value);

	public float Damping {
	    get { return __cpDampedRotarySpringGetDamping (Handle.Handle); }
	    set { __cpDampedRotarySpringSetDamping (Handle.Handle, value); }
	}
    }

    public partial class RotaryLimitJoint : Constraint
    {
	[DllImport ("__Internal")]
	extern static IntPtr cpRotaryLimitJointNew (IntPtr bodyA, IntPtr bodyB, float min, float max);

	public RotaryLimitJoint (Body bodyA, Body bodyB, float min, float max) : base (cpRotaryLimitJointNew (bodyA.Handle.Handle, bodyB.Handle.Handle, min, max))
	{
	}

	[DllImport ("__Internal")]
	extern static float __cpRotaryLimitJointGetMin (IntPtr constraint);

	[DllImport ("__Internal")]
	extern static void __cpRotaryLimitJointSetMin (IntPtr constraint, float value);

	public float Min {
	    get { return __cpRotaryLimitJointGetMin (Handle.Handle); }
	    set { __cpRotaryLimitJointSetMin (Handle.Handle, value); }
	}

	[DllImport ("__Internal")]
	extern static float __cpRotaryLimitJointGetMax (IntPtr constraint);

	[DllImport ("__Internal")]
	extern static void __cpRotaryLimitJointSetMax (IntPtr constraint, float value);

	public float Max {
	    get { return __cpRotaryLimitJointGetMax (Handle.Handle); }
	    set { __cpRotaryLimitJointSetMax (Handle.Handle, value); }
	}
    }

    public partial class RatchetJoint : Constraint
    {
	[DllImport ("__Internal")]
	extern static IntPtr cpRatchetJointNew (IntPtr bodyA, IntPtr bodyB, float phase, float ratchet);

	public RatchetJoint (Body bodyA, Body bodyB, float phase, float ratchet) : base (cpRatchetJointNew (bodyA.Handle.Handle, bodyB.Handle.Handle, phase, ratchet))
	{
	}

	[DllImport("__Internal")]
	extern static float __cpRatchetJointGetAngle (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpRatchetJointSetAngle (IntPtr constraint, float value);

	public float Angle {
	    get { return __cpRatchetJointGetAngle (Handle.Handle); }
	    set { __cpRatchetJointSetAngle (Handle.Handle, value); }
	}	
	
	[DllImport("__Internal")]
	extern static float __cpRatchetJointGetPhase (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpRatchetJointSetPhase (IntPtr constraint, float value);

	public float Phase {
	    get { return __cpRatchetJointGetPhase (Handle.Handle); }
	    set { __cpRatchetJointSetPhase (Handle.Handle, value); }
	}	

	[DllImport("__Internal")]
	extern static float __cpRatchetJointGetRatchet (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpRatchetJointSetRatchet (IntPtr constraint, float value);

	public float Ratchet {
	    get { return __cpRatchetJointGetRatchet (Handle.Handle); }
	    set { __cpRatchetJointSetRatchet (Handle.Handle, value); }
	}	
    }

    public partial class GearJoint : Constraint
    {
	[DllImport ("__Internal")]
	extern static IntPtr cpGearJointNew (IntPtr bodyA, IntPtr bodyB, float pahse, float ratio);

	public GearJoint (Body bodyA, Body bodyB, float phase, float ratio) : base (cpGearJointNew (bodyA.Handle.Handle, bodyB.Handle.Handle, phase, ratio))
	{
	}

	[DllImport("__Internal")]
	extern static float __cpGearJointGetPhase (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpGearJointSetPhase (IntPtr constraint, float value);

	public float Phase {
	    get { return __cpGearJointGetPhase (Handle.Handle); }
	    set { __cpGearJointSetPhase (Handle.Handle, value); }
	}	

	[DllImport("__Internal")]
	extern static float __cpGearJointGetRatio (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void __cpGearJointSetRatio (IntPtr constraint, float value);

	public float Ratio {
	    get { return __cpGearJointGetRatio (Handle.Handle); }
	    set { __cpGearJointSetRatio (Handle.Handle, value); }
	}
    }

    public partial class SimpleMotor : Constraint
    {
	[DllImport ("__Internal")]
	extern static IntPtr cpSimpleMotorNew (IntPtr bodyA, IntPtr bodyB, float rate);

	public SimpleMotor (Body bodyA, Body bodyB, float rate) : base (cpSimpleMotorNew (bodyA.Handle.Handle, bodyB.Handle.Handle, rate))
	{
	}

	[DllImport ("__Internal")]
	extern static float __cpSimpleMotorGetRate (IntPtr constraint);

	[DllImport ("__Internal")]
	extern static void __cpSimpleMotorSetRate (IntPtr constraint, float value);

	public float Rate {
	    get { return __cpSimpleMotorGetRate (Handle.Handle); }
	    set { __cpSimpleMotorSetRate (Handle.Handle, value); }
	}
    }
}

