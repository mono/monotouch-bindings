//
// Shape.cs
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
	public partial class Shape : ChipmunkObject
	{
		public Shape (IntPtr handle) : base (handle)
		{
		}		

		[DllImport("__Internal")]
		extern static void cpBodyActivate (IntPtr body);

		void ActivateBody (IntPtr body)
		{
			cpBodyActivate (body);		
		}

		public void Activate (Body body)
		{
			ActivateBody(body.Handle.Handle);
		}

		[DllImport("__Internal")]
		extern static float __cpShapeGetElasticity (IntPtr shape);

		[DllImport("__Internal")]
		extern static void __cpShapeSetElasticity (IntPtr shape, float e);

		public float Elasticity {
			get { return __cpShapeGetElasticity(Handle.Handle); }
			set { __cpShapeSetElasticity(Handle.Handle, value); }
		}

		[DllImport("__Internal")]
		extern static float __cpShapeGetFriction(IntPtr shape);

		[DllImport("__Internal")]
		extern static void __cpShapeSetFriction(IntPtr shape, float value);

		public float Friction {
			get { return __cpShapeGetFriction(Handle.Handle); }
			set { __cpShapeSetFriction(Handle.Handle, value); }
		}

	}

	public partial class SegmentShape:Shape
	{
		[DllImport("__Internal")]
		extern static IntPtr cpSegmentShapeNew (IntPtr body, PointF a, PointF b, float radius);

		public SegmentShape (Body body, PointF a, PointF b, float radius) : base (cpSegmentShapeNew (body.Handle.Handle, a, b, radius))
		{
		}
	}

	public partial class PolygonShape : Shape
	{
		[DllImport("__Internal")]
		extern static IntPtr cpPolyShapeNew (IntPtr body, int numVerts, PointF[] verts, PointF offset);

		public PolygonShape (Body body, PointF[] vertices, PointF offset) : base (cpPolyShapeNew (body.Handle.Handle, vertices.Length, vertices, offset))
		{
		}
	}
}
