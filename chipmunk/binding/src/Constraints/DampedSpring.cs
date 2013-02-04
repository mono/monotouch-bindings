//
// DampedSpring.cs
//
// Author:
//   Stephane Delcroix <stephane@delcroix.org>
//
// Copyright © 2013 Stephane Delcroix. All Rights Reserved.

using System;
using System.Drawing;
using System.Runtime.InteropServices;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Chipmunk 
{
    public partial class DampedSpring : Constraint
    {

	[DllImport("__Internal")]
	extern static IntPtr cpDampedSpringNew (IntPtr bodyA, IntPtr bodyB, PointF anchr1, PointF anchr2, float restLength, float stiffness, float damping);

	public DampedSpring (Body bodyA, Body bodyB, PointF anchr1, PointF anchr2, float restLength, float stiffness, float damping) : base (cpDampedSpringNew (bodyA.Handle.Handle, bodyB.Handle.Handle, anchr1, anchr2, restLength, stiffness, damping))
	{
	}

	[DllImport("__Internal")]
	extern static PointF cpDampedSpringGetAnchr1 (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void cpDampedSpringSetAnchr1 (IntPtr constraint, PointF value);

	public PointF Anchr1 {
	    get { return cpDampedSpringGetAnchr1 (Handle.Handle); }
	    set { cpDampedSpringSetAnchr1 (Handle.Handle, value); }
	}

	[DllImport("__Internal")]
	extern static PointF cpDampedSpringGetAnchr2 (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void cpDampedSpringSetAnchr2 (IntPtr constraint, PointF value);

	public PointF Anchr2 {
	    get { return cpDampedSpringGetAnchr2 (Handle.Handle); }
	    set { cpDampedSpringSetAnchr2 (Handle.Handle, value); }
	}

	[DllImport("__Internal")]
	extern static PointF cpDampedSpringGetRestLength (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void cpDampedSpringSetRestLength (IntPtr constraint, PointF value);

	public PointF RestLength {
	    get { return cpDampedSpringGetRestLength (Handle.Handle); }
	    set { cpDampedSpringSetRestLength (Handle.Handle, value); }
	}

	[DllImport("__Internal")]
	extern static PointF cpDampedSpringGetStiffness (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void cpDampedSpringSetStiffness (IntPtr constraint, PointF value);

	public PointF Stiffness {
	    get { return cpDampedSpringGetStiffness (Handle.Handle); }
	    set { cpDampedSpringSetStiffness (Handle.Handle, value); }
	}

	[DllImport("__Internal")]
	extern static PointF cpDampedSpringGetDamping (IntPtr constraint);

	[DllImport("__Internal")]
	extern static void cpDampedSpringSetDamping (IntPtr constraint, PointF value);

	public PointF Damping {
	    get { return cpDampedSpringGetDamping (Handle.Handle); }
	    set { cpDampedSpringSetDamping (Handle.Handle, value); }
	}
    }
}

