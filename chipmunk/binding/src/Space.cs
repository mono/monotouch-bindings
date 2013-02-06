//
// Space.cs
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
	public partial class Space : ChipmunkObject
	{
		[DllImport ("__Internal")]
		extern static IntPtr cpSpaceNew ();

		public Space () : base (cpSpaceNew ())
		{
		}		

		public Space (IntPtr space) : base (space)
		{
		}

		[DllImport("__Internal")]
		extern static IntPtr cpSpaceAddStaticShape (IntPtr space, IntPtr shape);

		[Obsolete ("Attach the shape to the static body instead")]
		public T AddStaticShape<T> (T shape) where T : Shape
		{
			cpSpaceAddStaticShape (Handle.Handle, shape.Handle.Handle);
			return shape;
		}

		[DllImport("__Internal")]
		extern static PointF __cpSpaceGetGravity(IntPtr space);

		[DllImport("__Internal")]
		extern static void __cpSpaceSetGravity(IntPtr space, PointF gravity); 

		public PointF Gravity {
			get { return __cpSpaceGetGravity(Handle.Handle);}
			set { __cpSpaceSetGravity(Handle.Handle, value); }
		}

		[DllImport("__Internal")]
		extern static IntPtr __cpSpaceGetStaticBody(IntPtr space);

		public Body StaticBody {
			get { return new Body (__cpSpaceGetStaticBody(Handle.Handle)); }
		}

		[DllImport ("__Internal")]
		extern static IntPtr cpSpaceAddBody(IntPtr space, IntPtr body);

		public Body Add (Body body)
		{
			cpSpaceAddBody(Handle.Handle, body.Handle.Handle);
			return body;
		}

		[DllImport ("__Internal")]
		extern static IntPtr cpSpaceAddShape(IntPtr space, IntPtr shape);

		public Shape Add (Shape shape)
		{
			cpSpaceAddShape(Handle.Handle, shape.Handle.Handle);
			return shape;
		}

		[DllImport ("__Internal")]
		extern static IntPtr cpSpaceAddConstraint(IntPtr space, IntPtr constraint);

		public Constraint Add (Constraint constraint)
		{
			cpSpaceAddConstraint(Handle.Handle, constraint.Handle.Handle);
			return constraint;
		}

		[DllImport("__Internal")]
		extern static void cpSpaceStep (IntPtr space, float dt);

		public void Step (float dt)
		{
			cpSpaceStep(Handle.Handle, dt);
		}

		[DllImport ("__Internal")]
		extern static void cpSpaceFree (IntPtr space);

		protected override void Cleanup ()
		{
		    cpSpaceFree (Handle.Handle);
		    base.Cleanup ();
		}
	}
}
