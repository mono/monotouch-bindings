//
// Helper.cs
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
	public static class Helper
	{
		[DllImport("__Internal", EntryPoint="cpMomentForCircle")]
		public extern static float MomentForCircle (float m, float r1, float r2, PointF offset);

		[DllImport("__Internal", EntryPoint="cpAreaForCircle")]
		public extern static float AreaForCircle(float r1, float r2);


		[DllImport("__Internal", EntryPoint="cpMomentForSegment")]
		public extern static float MomentForSegment(float m, PointF a, PointF b);
		
		[DllImport("__Internal", EntryPoint="cpAreaForSegment")]
		public extern static float AreaForSegment (PointF a, PointF b);

		[DllImport("__Internal")]
		extern static float cpMomentForPoly(float m, int numVerts, PointF[] Verts, PointF offset);

		public static float MomentForPolygon (float m, PointF[] vertices, PointF offset)
		{
			return cpMomentForPoly (m, vertices.Length, vertices, offset);
		}

		[DllImport("__Internal")]
		extern static float cpAreaForPoly(int numVerts, PointF[] verts);

		public static float AreaForPolygon(PointF[] vertices)
		{
			return cpAreaForPoly(vertices.Length, vertices);
		}

		[DllImport("__Internal")]
		extern static PointF cpCentroidForPoly(int numVerts, PointF[] verts);

		public static PointF CentroidForPolygon(PointF[] vertices)
		{
			return cpCentroidForPoly(vertices.Length, vertices);
		}
		
		[DllImport("__Internal")]
		extern static void cpRecenterPoly(int numVerts, PointF[] verts);

		public static void RecenterPolygon(PointF[] vertices)
		{
			cpRecenterPoly(vertices.Length, vertices);
		}

		[DllImport("__Internal", EntryPoint="cpMomentForBox")]
		extern static float MomentForBox (float m, float width, float height);

		[DllImport("__Internal", EntryPoint="cpMomentForBox2" )]
		extern static float cpMomentForBox2 (float m, BoundingBox box);
	}
}
