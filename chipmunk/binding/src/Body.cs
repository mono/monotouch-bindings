//
// Body.cs
//
// Authors:
//  Stephane Delcroix <stephane@delcroix.org>
//
// Copyright 2012, 2013 S. Delcroix
//

using System;
using System.Drawing;
using System.Runtime.InteropServices;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Chipmunk
{
	public partial class Body : ChipmunkObject
	{
		public Body (IntPtr ptr) : base (ptr)
		{
		} 

		[DllImport("__Internal")]
		extern static IntPtr cpBodyNew (float m, float i);

		public Body (float m, float i) : base (cpBodyNew (m, i))
		{
		}

		[DllImport("__Internal")]
		extern static IntPtr cpBodyNewStatic ();

		public static Body CreateStatic ()
		{
		    return new Body (cpBodyNewStatic ());
		}

		[DllImport("__Internal")]
		extern static void cpBodyFree (IntPtr body);

		protected override void Free ()
		{
		    cpBodyFree (Handle.Handle);
		}

		//Properties
		[DllImport("__Internal")]
		extern static float __cpBodyGetMass(IntPtr body);

		[DllImport("__Internal")]
		extern static void cpBodySetMass(IntPtr body, float mass);

		public float Mass {
			get { return __cpBodyGetMass (Handle.Handle); }
			set { cpBodySetMass (Handle.Handle, value); }
		}

		[DllImport("__Internal")]
		extern static float __cpBodyGetMoment(IntPtr body);

		[DllImport("__Internal")]
		extern static void cpBodySetMoment(IntPtr body, float mass);

		public float Moment {
			get { return __cpBodyGetMoment (Handle.Handle); }
			set { cpBodySetMoment (Handle.Handle, value); }
		}	

		[DllImport("__Internal")]
		extern static PointF __cpBodyGetPos(IntPtr body);

		[DllImport("__Internal")]
		extern static void cpBodySetPos(IntPtr body, PointF pos);

		public PointF Position {
			get { return __cpBodyGetPos(Handle.Handle); }
			set { cpBodySetPos(Handle.Handle, value); }
		}

		[DllImport("__Internal")]
		extern static PointF __cpBodyGetVel(IntPtr body);

		[DllImport("__Internal")]
		extern static void __cpBodySetVel(IntPtr body, PointF value);

		public PointF Velocity {
			get { return __cpBodyGetVel(Handle.Handle); }
			set { __cpBodySetVel(Handle.Handle, value); }
		}

		[DllImport("__Internal")]
		extern static PointF __cpBodyGetForce(IntPtr body);

		[DllImport("__Internal")]
		extern static void __cpBodySetForce(IntPtr body, PointF value);

		public PointF Force {
			get { return __cpBodyGetForce(Handle.Handle); }
			set { __cpBodySetForce(Handle.Handle, value); }
		}	

		[DllImport("__Internal")]
		extern static float __cpBodyGetAngle(IntPtr body);

		[DllImport("__Internal")]
		extern static void cpBodySetAngle(IntPtr body, float angle);

		public float Angle {
			get { return __cpBodyGetAngle (Handle.Handle); }
			set { cpBodySetAngle (Handle.Handle, value); }
		}	

		[DllImport("__Internal")]
		extern static float __cpBodyGetAngVel(IntPtr body);

		[DllImport("__Internal")]
		extern static void __cpBodySetAngVel(IntPtr body, float value);

		public float AngularVelocity {
			get { return __cpBodyGetAngVel(Handle.Handle); }
			set { __cpBodySetAngVel(Handle.Handle, value); }
		}

		[DllImport("__Internal")]
		extern static float __cpBodyGetTorque(IntPtr body);

		[DllImport("__Internal")]
		extern static void __cpBodySetTorque(IntPtr body, float value);

		public float Torque {
			get { return __cpBodyGetTorque(Handle.Handle); }
			set { __cpBodySetTorque(Handle.Handle, value); }
		}

		[DllImport("__Internal")]
		extern static PointF __cpBodyGetRot(IntPtr body);

		public PointF Rotation {
			get { return __cpBodyGetRot(Handle.Handle); }
		}

		[DllImport("__Internal")]
		extern static float __cpBodyGetVelLimit(IntPtr body);

		[DllImport("__Internal")]
		extern static void __cpBodySetVelLimit(IntPtr body, float value);

		public float VelocityLimit {
			get { return __cpBodyGetVelLimit(Handle.Handle); }
			set { __cpBodySetVelLimit(Handle.Handle, value); }
		}

		[DllImport("__Internal")]
		extern static float __cpBodyGetAngleVelLimit(IntPtr body);

		[DllImport("__Internal")]
		extern static void __cpBodySetAngleVelLimit(IntPtr body, float value);

		public float AngularVelocityLimit {
			get { return __cpBodyGetAngleVelLimit(Handle.Handle); }
			set { __cpBodySetAngleVelLimit(Handle.Handle, value); }
		}	

		[DllImport("__Internal")]
		extern static IntPtr __cpBodyGetSpace (IntPtr body);

		public Space Space {
		    get { return new Space (__cpBodyGetSpace (Handle.Handle)); }
		}

		[DllImport("__Internal")]
		extern static IntPtr __cpBodyGetUserData (IntPtr body);

		[DllImport("__Internal")]
		extern static void __cpBodySetUserData (IntPtr body, IntPtr userData);

		public IntPtr UserData {
		    get { return __cpBodyGetUserData (Handle.Handle); }
		    set { __cpBodySetUserData (Handle.Handle, value); }
		}

		//coordinate conversion
		[DllImport ("__Internal")]
		extern static PointF cpBodyLocal2World (IntPtr body, PointF v);

		public PointF Local2World (PointF v)
		{
		    return cpBodyLocal2World (Handle.Handle, v);
		}

		[DllImport ("__Internal")]
		extern static PointF cpBodyWorld2Local (IntPtr body, PointF v);

		public PointF World2Local (PointF v)
		{
		    return cpBodyWorld2Local (Handle.Handle, v);
		}

		//applying forces and torque
		[DllImport ("__Internal")]
		extern static void cpBodyResetForces (IntPtr body);

		public void ResetForces ()
		{
		    cpBodyResetForces (Handle.Handle);
		}

		[DllImport ("__Internal")]
		extern static void cpBodyApplyForce (IntPtr body, PointF force, PointF offset);

		public void ApplyForce (PointF force, PointF offset)
		{
		    cpBodyApplyForce (Handle.Handle, force, offset);
		}

		[DllImport ("__Internal")]
		extern static void cpBodyApplyImpulse (IntPtr body, PointF impulse, PointF offset);

		public void ApplyImpulse (PointF impulse, PointF offset) 
		{
		    cpBodyApplyImpulse (Handle.Handle, impulse, offset);
		}
			
		//sleeping
		[DllImport ("__Internal")]
		extern static bool __cpBodyIsSleeping (IntPtr body);

		public bool IsSleeping {
		    get { return __cpBodyIsSleeping (Handle.Handle); }
		}

		[DllImport ("__Internal")]
		extern static void cpBodyActivate (IntPtr body);

		public void Activate ()
		{
		    cpBodyActivate (Handle.Handle);
		}

		[DllImport ("__Internal")]
		extern static void cpBodySleep (IntPtr body);

		public void Sleep ()
		{
		    cpBodySleep (Handle.Handle);
		}

		[DllImport ("__Internal")]
		extern static void cpBodyActivateStatic (IntPtr body, IntPtr filter);

		public void ActivateStatic (Shape filter)
		{
		    cpBodyActivateStatic (Handle.Handle, filter.Handle.Handle);
		}
		
		[DllImport ("__Internal")]
		extern static void cpBodySleepWithGroup (IntPtr body, IntPtr group);

		public void SleepWithGroup (Body group)
		{
		    cpBodySleepWithGroup (Handle.Handle, group.Handle.Handle);
		}
	
		//iterators
		delegate void ShapeIterator (IntPtr body, IntPtr shape, IntPtr data);

		[DllImport ("__Internal")]
		extern static void cpBodyEachShape (IntPtr body, ShapeIterator iterator, IntPtr data);
		
		public void EachShape (Action<Body, Shape> action)
		{
		    ShapeIterator iterator = (body, shape, data) => {
			action (new Body(body), new Shape(shape));
		    };
		    cpBodyEachShape (Handle.Handle, iterator, IntPtr.Zero);
		}

		delegate void ConstraintIterator (IntPtr body, IntPtr constraint, IntPtr data);

		[DllImport ("__Internal")]
		extern static void cpBodyEachConstraint(IntPtr body, ConstraintIterator iterator, IntPtr data);

		public void EachConstraint (Action<Body, Constraint> action)
		{
		    ConstraintIterator iterator = (body, constraint, data) => {
			action (new Body(body), new Constraint(constraint));
		    };
		    cpBodyEachConstraint (Handle.Handle, iterator, IntPtr.Zero);
		}

		delegate void ArbiterIterator (IntPtr body, IntPtr arbiter, IntPtr data);

		[DllImport ("__Internal")]
		extern static void cpBodyEachArbiter (IntPtr body, ArbiterIterator iterator, IntPtr data);

		public void EachArbiter (Action<Body, Arbiter> action)
		{
		    ArbiterIterator iterator = (body, arbiter, data) => {
			action (new Body(body), new Arbiter(arbiter));
		    };
		    cpBodyEachArbiter (Handle.Handle, iterator, IntPtr.Zero);
		}
		
		//Misc
		[DllImport ("__Internal")]
		extern static bool __cpBodyIsStatic (IntPtr body);

		public bool IsStatic {
		    get { return __cpBodyIsStatic (Handle.Handle); }
		}

		[DllImport ("__Internal")]
		extern static bool __cpBodyIsRogue (IntPtr body);
		
		public bool IsRogue {
		    get { return __cpBodyIsRogue (Handle.Handle); }
		}
	}	
}
