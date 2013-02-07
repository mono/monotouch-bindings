//
// Shape.cs
//
// Authors:
//  Stephane Delcroix <stephane@delcroix.org>
//
// Copyright 2012 S. Delcroix
//

//TODO: bind CollisionType and Group
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
    
        [DllImport ("__Internal")]
        extern static void cpShapeFree (IntPtr shape);
    	
        protected override void Free ()
        {
    	cpShapeFree (Handle.Handle);
        }
    
        //properties
        [DllImport ("__Internal")]
        extern static IntPtr cpShapeGetBody (IntPtr shape);
    
        [DllImport ("__Internal")]
        extern static void cpShapeSetBody (IntPtr shape, IntPtr body);
    
        public Body Body {
	   get { return new Body (cpShapeGetBody (Handle.Handle)); }
	   set { cpShapeSetBody (Handle.Handle, value.Handle.Handle); }
        }
    
        [DllImport ("__Internal")]
        extern static BoundingBox __cpShapeGetBB (IntPtr shape);
    
        public RectangleF BoundingBox {
	   get { return __cpShapeGetBB (Handle.Handle); }
        }
    	
        [DllImport ("__Internal")]
        extern static bool __cpShapeGetSensor (IntPtr shape);
    
        [DllImport ("__Internal")]
        extern static void __cpShapeSetSensor (IntPtr shape, bool value);
    	
        public bool Sensor {
	   get { return __cpShapeGetSensor (Handle.Handle); }
	   set { __cpShapeSetSensor (Handle.Handle, value); }
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
    
        [DllImport ("__Internal")]
        extern static PointF __cpShapeGetSurfaceVelocity (IntPtr shape);
    
        [DllImport ("__Internal")]
        extern static void __cpShapeSetSurfaceVelocity (IntPtr shape, PointF vel);
    
        public PointF SurfaceVelocity {
	   get { return __cpShapeGetSurfaceVelocity (Handle.Handle); }
	   set { __cpShapeSetSurfaceVelocity (Handle.Handle, value); }
        }
    
        [DllImport ("__Internal")]
        extern static uint __cpShapeGetLayers (IntPtr shape);
    
        [DllImport ("__Internal")]
        extern static void __cpShapeSetLayers (IntPtr shape, uint layers);
    
        public uint Layers {
	   get { return __cpShapeGetLayers (Handle.Handle); }
	   set { __cpShapeSetLayers (Handle.Handle, value); }
        }
    	
	//Don't provide GetSpace. You have to keep a ref to it to avoid GC
	//
        //[DllImport ("__Internal")]
        //extern static IntPtr __cpShapeGetSpace (IntPtr shape);
    
        //public Space Space {
	//   get { return new Space (__cpShapeGetSpace (Handle.Handle)); }
        //}

	//misc
	[DllImport ("__Internal")]
	extern static BoundingBox cpShapeCacheBB (IntPtr shape);

	public RectangleF CacheBoundingBox ()
	{
	    return cpShapeCacheBB (Handle.Handle);
	}

	[DllImport ("__Internal")]
	extern static BoundingBox cpShapeUpdate (IntPtr shape, PointF pos, PointF rot);

	public RectangleF Update (PointF position, PointF rotation)
	{
	    return cpShapeUpdate (Handle.Handle, position, rotation);
	}

	[DllImport ("__Internal", EntryPoint="cpResetShapeIdCounter")]
	public extern static void ResetShapeIdCounter ();
    }

    public partial class CircleShape : Shape
    {
	[DllImport ("__Internal")]
	extern static IntPtr cpCircleShapeNew (IntPtr body, float radius, PointF offset);

	public CircleShape (Body body, float radius, PointF offset) : base (cpCircleShapeNew (body.Handle.Handle, radius, offset))
	{
	}
	
	[DllImport ("__Internal")]
	extern static PointF cpCircleShapeGetOffset (IntPtr shape);

	public PointF Offset {
	    get { return cpCircleShapeGetOffset (Handle.Handle); }
	}

	[DllImport ("__Internal")]
	extern static float cpCircleShapeGetRadius (IntPtr shape);

	public float Radius {
	    get { return cpCircleShapeGetRadius (Handle.Handle); }
	}
    }
    
    public partial class SegmentShape:Shape
    {
    	[DllImport("__Internal")]
    	extern static IntPtr cpSegmentShapeNew (IntPtr body, PointF a, PointF b, float radius);
    
    	public SegmentShape (Body body, PointF a, PointF b, float radius) : base (cpSegmentShapeNew (body.Handle.Handle, a, b, radius))
    	{
    	}

	[DllImport ("__Internal")]
	extern static PointF cpSegmentShapeGetA (IntPtr chape);

	public PointF GetA {
	    get { return  cpSegmentShapeGetA (Handle.Handle); }
	}

	[DllImport ("__Internal")]
	extern static PointF cpSegmentShapeGetB (IntPtr chape);

	public PointF GetB {
	    get { return cpSegmentShapeGetA (Handle.Handle); }
	}

	[DllImport ("__Internal")]
	extern static PointF cpSegmentShapeGetNormal (IntPtr chape);

	public PointF GetNormal {
	    get { return cpSegmentShapeGetA (Handle.Handle); }
	}

	[DllImport ("__Internal")]
	extern static float cpSegmentShapeGetRadius (IntPtr shape);

	public float Radius {
	    get { return cpSegmentShapeGetRadius (Handle.Handle); }
	}	
    }
    
    public partial class PolygonShape : Shape
    {
    	[DllImport("__Internal")]
    	extern static IntPtr cpPolyShapeNew (IntPtr body, int numVerts, PointF[] verts, PointF offset);
    
    	public PolygonShape (Body body, PointF[] vertices, PointF offset) : base (cpPolyShapeNew (body.Handle.Handle, vertices.Length, vertices, offset))
    	{
    	}

	[DllImport ("__Internal")]
	extern static IntPtr cpBoxShapeNew (IntPtr body, float width, float height);
	public PolygonShape (Body body, float width, float height) : base (cpBoxShapeNew (body.Handle.Handle, width, height))
	{
	}
	
	[DllImport ("__Internal")]
	extern static int cpPolyShapeGetNumVerts (IntPtr shape);

	[DllImport ("__Internal")]
	extern static PointF cpPolyShapeGetVert (IntPtr shape, int index);
	
	public PointF[] Vertices {
	    get {
		var n = cpPolyShapeGetNumVerts (Handle.Handle);
		var vertices = new PointF[n];
		for (var i=0; i<n; i++)
		    vertices[i] = cpPolyShapeGetVert (Handle.Handle, i);
		return vertices;
	    }
	}

	[DllImport ("__Internal")]
	extern static bool cpPolyValidate(PointF[] verts, int numVerts);

	public static bool Validate (PointF[] vertices)
	{
	    return cpPolyValidate (vertices, vertices.Length);
	}

	[DllImport ("__Internal")]
	extern static PointF cpCentroidForPoly (int numVerts, PointF[] verts);

	public static PointF Centroid (PointF[] vertices)
	{
	    return cpCentroidForPoly (vertices.Length, vertices);
	}

	[DllImport ("__Internal")]
	extern static void cpRecenterPoly (int numVerts, ref PointF[] vertices);
	
	public static void Recenter (ref PointF[] vertices)
	{
	    cpRecenterPoly (vertices.Length, ref vertices);
	}
	
	[DllImport ("__Internal")]
	extern static int cpConvexHull (int count, PointF[] verts, ref PointF[] result, IntPtr first, float tol);

	public static PointF[] ConvexHull (PointF[] vertices, float tolerance)
	{
	    var numVerts = vertices.Length;
	    var result = new PointF[numVerts];
	    var count = cpConvexHull (numVerts, vertices, ref result, IntPtr.Zero, tolerance);
	    Array.Resize (ref result, count);
	    return result;
	}
    }
}
