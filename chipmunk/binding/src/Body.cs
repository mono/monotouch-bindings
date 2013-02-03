//
// Body.cs
//
// Authors:
//  Stephane Delcroix <stephane@delcroix.org>
//
// Copyright 2012 S. Delcroix
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
		[DllImport("__Internal")]
		extern static IntPtr cpBodyNew (float m, float i);

		public Body (IntPtr ptr) : base (ptr)
		{
		} 

		public Body (float m, float i) : base (cpBodyNew(m, i))
		{
		}

		[DllImport("__Internal")]
		extern static float __cpBodyGetMass(IntPtr body);

		public float Mass {
			get { return __cpBodyGetMass (Handle.Handle); }
		}

		[DllImport("__Internal")]
		extern static float __cpBodyGetMoment(IntPtr body);

		public float Moment {
			get { return __cpBodyGetMoment (Handle.Handle); }
		}	

		[DllImport("__Internal")]
		extern static void cpBodySetPos(IntPtr body, PointF pos);

		[DllImport("__Internal")]
		extern static PointF __cpBodyGetPos(IntPtr body);

		public PointF Position {
			get { return __cpBodyGetPos(Handle.Handle); }
			set { cpBodySetPos(Handle.Handle, value); }
		}

		[DllImport("__Internal")]
		extern static float __cpBodyGetAngle(IntPtr body);

		public float Angle {
			get { return __cpBodyGetAngle (Handle.Handle); }
		}	

		[DllImport("__Internal")]
		extern static PointF __cpBodyGetRot(IntPtr body);

		public PointF Rotation {
			get { return __cpBodyGetRot(Handle.Handle); }
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
	}	
}


