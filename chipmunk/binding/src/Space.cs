//
// Space.cs
//
// Authors:
//  Stephane Delcroix <stephane@delcroix.org>
//
// Copyright 2012, 2013 S. Delcroix
//

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Chipmunk
{
	public sealed partial class Space : ChipmunkObject
	{
		[DllImport ("__Internal")]
		extern static IntPtr cpSpaceNew ();

		public Space () : base (cpSpaceNew ())
		{
		}		

		public Space (IntPtr space) : base (space)
		{
		}

		[DllImport ("__Internal")]
		extern static void cpSpaceFree (IntPtr space);

		protected override void Free ()
		{
		    foreach (var shape in shapes.Values)
			shape.Dispose ();
		    foreach (var body in bodies.Values)
			body.Dispose ();
		    foreach (var constraint in constraints.Values)
			constraint.Dispose ();
		    shapes = null;
		    bodies = null;
		    constraints = null;

		    cpSpaceFree (Handle.Handle);
		}
		
		//properties
		[DllImport ("__Internal")]
		extern static int __cpSpaceGetIterations (IntPtr space);

		[DllImport ("__Internal")]
		extern static void __cpSpaceSetIterations (IntPtr space, int i);

		public int Iterations {
		    get { return __cpSpaceGetIterations (Handle.Handle); }
		    set { __cpSpaceSetIterations (Handle.Handle, value); }
		}

		[DllImport("__Internal")]
		extern static PointF __cpSpaceGetGravity(IntPtr space);

		[DllImport("__Internal")]
		extern static void __cpSpaceSetGravity(IntPtr space, PointF gravity); 

		public PointF Gravity {
			get { return __cpSpaceGetGravity(Handle.Handle);}
			set { __cpSpaceSetGravity(Handle.Handle, value); }
		}

		[DllImport ("__Internal")]
		extern static float __cpSpaceGetDamping (IntPtr space);

		[DllImport ("__Internal")]
		extern static void __cpSpaceSetDamping (IntPtr space, float d);

		public float Damping {
		    get { return __cpSpaceGetDamping (Handle.Handle); }
		    set { __cpSpaceSetDamping (Handle.Handle, value); }
		}

		[DllImport ("__Internal")]
		extern static float __cpSpaceGetIdleSpeedThreshold (IntPtr space);

		[DllImport ("__Internal")]
		extern static void __cpSpaceSetIdleSpeedThreshold (IntPtr space, float i);

		public float IdleSpeedThreshold {
		    get { return __cpSpaceGetIdleSpeedThreshold (Handle.Handle); }
		    set { __cpSpaceSetIdleSpeedThreshold (Handle.Handle, value); }
		}

		[DllImport ("__Internal")]
		extern static float __cpSpaceGetSleepTimeThreshold (IntPtr space);

		[DllImport ("__Internal")]
		extern static void __cpSpaceSetSleepTimeThreshold (IntPtr space, float i);

		public float SleepTimeThreshold {
		    get { return __cpSpaceGetSleepTimeThreshold (Handle.Handle); }
		    set { __cpSpaceSetSleepTimeThreshold (Handle.Handle, value); }
		}
		
		[DllImport ("__Internal")]
		extern static float __cpSpaceGetCollisionSlop (IntPtr space);

		[DllImport ("__Internal")]
		extern static void __cpSpaceSetCollisionSlop (IntPtr space, float i);

		public float CollisionSlop {
		    get { return __cpSpaceGetCollisionSlop (Handle.Handle); }
		    set { __cpSpaceSetCollisionSlop (Handle.Handle, value); }
		}

		[DllImport ("__Internal")]
		extern static float __cpSpaceGetCollisionBias (IntPtr space);

		[DllImport ("__Internal")]
		extern static void __cpSpaceSetCollisionBias (IntPtr space, float i);

		public float CollisionBias {
		    get { return __cpSpaceGetCollisionBias (Handle.Handle); }
		    set { __cpSpaceSetCollisionBias (Handle.Handle, value); }
		}

		[DllImport ("__Internal")]
		extern static uint __cpSpaceGetCollisionPersistence (IntPtr space);

		[DllImport ("__Internal")]
		extern static void __cpSpaceSetCollisionPersistence (IntPtr space, uint i);

		public uint CollisionPersistence {
		    get { return __cpSpaceGetCollisionPersistence (Handle.Handle); }
		    set { __cpSpaceSetCollisionPersistence (Handle.Handle, value); }
		}

		[DllImport ("__Internal")]
		extern static float __cpSpaceGetCurrentTimeStep (IntPtr space);

		public float CurrentTimeStep {
		    get { return __cpSpaceGetCurrentTimeStep (Handle.Handle); }
		}

		[DllImport ("__Internal")]
		extern static bool __cpSpaceIsLocked(IntPtr space);

		public bool IsLocked {
		    get { return __cpSpaceIsLocked (Handle.Handle); }
		}
		
		[DllImport("__Internal")]
		extern static IntPtr __cpSpaceGetStaticBody(IntPtr space);

		public Body StaticBody {
			get { return Body.FromIntPtr (__cpSpaceGetStaticBody(Handle.Handle)); }
		}

		//operations on the space
		[DllImport ("__Internal")]
		extern static IntPtr cpSpaceAddShape(IntPtr space, IntPtr shape);

		Dictionary<IntPtr,Shape> shapes = new Dictionary<IntPtr,Shape> ();
		public T Add<T> (T shape) where T : Shape
		{
			cpSpaceAddShape(Handle.Handle, shape.Handle.Handle);
			shapes.Add (shape.Handle.Handle, shape);
			return shape;
		}

		[DllImport ("__Internal")]
		extern static IntPtr cpSpaceRemoveShape(IntPtr space, IntPtr shape);

		public void Remove (Shape shape)
		{
		    cpSpaceRemoveShape (Handle.Handle, shape.Handle.Handle);
		    shapes.Remove (shape.Handle.Handle);
		}
		
		[DllImport ("__Internal")]
		extern static bool cpSpaceContainsShape (IntPtr space, IntPtr shape);

		public bool Contains (Shape shape)
		{
		    return cpSpaceContainsShape (Handle.Handle, shape.Handle.Handle);
		}

		[DllImport ("__Internal")]
		extern static IntPtr cpSpaceAddBody(IntPtr space, IntPtr body);

		Dictionary<IntPtr,Body> bodies = new Dictionary<IntPtr,Body> ();
		public Body Add (Body body)
		{
			cpSpaceAddBody(Handle.Handle, body.Handle.Handle);
			bodies.Add (body.Handle.Handle, body);
			return body;
		}

		[DllImport ("__Internal")]
		extern static void cpSpaceRemoveBody (IntPtr space, IntPtr body);

		public void Remove (Body body)
		{
		    cpSpaceRemoveBody (Handle.Handle, body.Handle.Handle);
		    bodies.Remove (body.Handle.Handle);
		}
		
		[DllImport ("__Internal")]
		extern static bool cpSpaceContainsBody (IntPtr space, IntPtr body);
		
		public bool Contains (Body body)
		{
		    return cpSpaceContainsBody (Handle.Handle, body.Handle.Handle);
		}

		[DllImport ("__Internal")]
		extern static IntPtr cpSpaceAddConstraint(IntPtr space, IntPtr constraint);

		Dictionary<IntPtr,Constraint> constraints = new Dictionary<IntPtr,Constraint> ();
		public Constraint Add (Constraint constraint)
		{
			cpSpaceAddConstraint(Handle.Handle, constraint.Handle.Handle);
			constraints.Add (constraint.Handle.Handle, constraint);
			return constraint;
		}

		[DllImport ("__Internal")]
		extern static void cpSpaceRemoveConstraint (IntPtr space, IntPtr constraint);
		
		public void Remove (Constraint constraint)
		{
		    cpSpaceRemoveConstraint (Handle.Handle, constraint.Handle.Handle);
		    constraints.Remove (constraint.Handle.Handle);
		}
		
		[DllImport ("__Internal")]
		extern static bool cpSpaceContainsConstraint (IntPtr space, IntPtr constraint);
		
		public bool Contains (Constraint constraint)
		{
		    return cpSpaceContainsConstraint (Handle.Handle, constraint.Handle.Handle);
		}
	
		[DllImport("__Internal")]
		extern static IntPtr cpSpaceAddStaticShape (IntPtr space, IntPtr shape);

		[Obsolete ("Attach the shape to the static body instead")]
		public T AddStaticShape<T> (T shape) where T : Shape
		{
			cpSpaceAddStaticShape (Handle.Handle, shape.Handle.Handle);
			return shape;
		}

		//spatial indexing
		[DllImport ("__Internal")]
		extern static void cpSpaceReindexShape (IntPtr space, IntPtr shape);

		public void ReindexShape (Shape shape)
		{
		    cpSpaceReindexShape (Handle.Handle, shape.Handle.Handle);
		}

		[DllImport ("__Internal")]
		extern static void cpSpaceReindexShapesForBody(IntPtr space, IntPtr body);

		public void ReindexShapesForBody (Body body)
		{
		    cpSpaceReindexShapesForBody (Handle.Handle, body.Handle.Handle);
		}

		[DllImport ("__Internal")]
		extern static void cpSpaceReindexStatic (IntPtr space);

		public void ReindexStaticShapes ()
		{
		    cpSpaceReindexStatic (Handle.Handle);
		}
		
		//iterators
		delegate void BodyIteratorFunc (IntPtr body, IntPtr data);

		[MonoTouch.MonoPInvokeCallback (typeof (BodyIteratorFunc))] 
		static void BodyIterator (IntPtr body, IntPtr data)
		{
		    var handle = GCHandle.FromIntPtr (data);
		    var action = (Action<Body>)handle.Target;
		    action (Body.FromIntPtr (body));
		}
		
		[DllImport ("__Internal")]
		extern static void cpSpaceEachBody (IntPtr space, BodyIteratorFunc iterator, IntPtr data);

		public void EachBody (Action<Body> action)
		{
		    var handle = GCHandle.Alloc (action);
		    var data = GCHandle.ToIntPtr(handle);
		    cpSpaceEachBody (Handle.Handle, BodyIterator, data);
		    handle.Free ();
		}
		
		delegate void ShapeIteratorFunc (IntPtr shape, IntPtr data);

		[MonoTouch.MonoPInvokeCallback (typeof (ShapeIteratorFunc))] 
		static void ShapeIterator (IntPtr shape, IntPtr data)
		{
		    var handle = GCHandle.FromIntPtr (data);
		    var action = (Action<Shape>)handle.Target;
		    action (Shape.FromIntPtr (shape));
		}
	
		[DllImport ("__Internal")]
		extern static void cpSpaceEachShape (IntPtr space, ShapeIteratorFunc iterator, IntPtr data);
		
		public void EachShape (Action<Shape> action)
		{
		    var handle = GCHandle.Alloc (action);
		    var data = GCHandle.ToIntPtr(handle);
		    cpSpaceEachShape (Handle.Handle, ShapeIterator, data);
		    handle.Free ();
		}

		delegate void ConstraintIteratorFunc (IntPtr constraint, IntPtr data);

		[MonoTouch.MonoPInvokeCallback (typeof (ConstraintIteratorFunc))] 
		static void ConstraintIterator (IntPtr constraint, IntPtr data)
		{
		    var handle = GCHandle.FromIntPtr (data);
		    var action = (Action<Constraint>)handle.Target;
		    action (Constraint.FromIntPtr (constraint));
		}
		
		[DllImport ("__Internal")]
		extern static void cpSpaceEachConstraint(IntPtr body, ConstraintIteratorFunc iterator, IntPtr data);

		public void EachConstraint (Action<Constraint> action)
		{
		    var handle = GCHandle.Alloc (action);
		    var data = GCHandle.ToIntPtr(handle);
		    cpSpaceEachConstraint (Handle.Handle, ConstraintIterator, data);
		    handle.Free ();
		}

		//simulating the space
		[DllImport("__Internal")]
		extern static void cpSpaceStep (IntPtr space, float dt);

		public void Step (float dt)
		{
		    cpSpaceStep(Handle.Handle, dt);
		}

		//Post step
		delegate void PostStepFunc (IntPtr space, IntPtr obj, IntPtr data);

		[MonoTouch.MonoPInvokeCallback (typeof (PostStepFunc))]
		static void PostStepForBody (IntPtr space, IntPtr obj, IntPtr data)
		{
		    var handle = GCHandle.FromIntPtr (data);
		    var action = (Action<Body>)handle.Target;
		    handle.Free ();
		    action (obj == IntPtr.Zero ? null :  Body.FromIntPtr (obj));
		}

		[MonoTouch.MonoPInvokeCallback (typeof (PostStepFunc))]
		static void PostStepForShape (IntPtr space, IntPtr obj, IntPtr data)
		{
		    var handle = GCHandle.FromIntPtr (data);
		    var action = (Action<Shape>)handle.Target;
		    handle.Free ();
		    action (obj == IntPtr.Zero ? null :  Shape.FromIntPtr (obj));
		}

		[MonoTouch.MonoPInvokeCallback (typeof (PostStepFunc))]
		static void PostStepForConstraint (IntPtr space, IntPtr obj, IntPtr data)
		{
		    var handle = GCHandle.FromIntPtr (data);
		    var action = (Action<Constraint>)handle.Target;
		    handle.Free ();
		    action (obj == IntPtr.Zero ? null :  Constraint.FromIntPtr (obj));
		}

		[DllImport ("__Internal")]
		extern static void cpSpaceAddPostStepCallback (IntPtr space, PostStepFunc func, IntPtr key, IntPtr data); 

		public void AddPostStepCallback (Action<Body> action, Body obj)
		{
		    var data = GCHandle.ToIntPtr(GCHandle.Alloc (action));
		    cpSpaceAddPostStepCallback (Handle.Handle, PostStepForBody, obj.Handle.Handle, data);
		}

		public void AddPostStepCallback (Action<Shape> action, Shape obj)
		{
		    var data = GCHandle.ToIntPtr(GCHandle.Alloc (action));
		    cpSpaceAddPostStepCallback (Handle.Handle, PostStepForShape, obj.Handle.Handle, data);
		}
		
		public void AddPostStepCallback (Action<Constraint> action, Constraint obj)
		{
		    var data = GCHandle.ToIntPtr(GCHandle.Alloc (action));
		    cpSpaceAddPostStepCallback (Handle.Handle, PostStepForConstraint, obj.Handle.Handle, data);
		}
		
		//spatial hash
		[DllImport ("__Internal")]
		extern static void cpSpaceUseSpatialHash(IntPtr space, float dim, int count);

		public void UseSpatialHash (float dim, int count)
		{
		    cpSpaceUseSpatialHash(Handle.Handle, dim, count);
		}

		//collision callbacks
		delegate bool BeginFunc (IntPtr arbiter, IntPtr space, IntPtr data);
		delegate bool PreSolveFunc (IntPtr arbiter, IntPtr space, IntPtr data);
		delegate void PostSolveFunc (IntPtr arbiter, IntPtr space, IntPtr data);
		delegate void SeparateFunc (IntPtr arbiter, IntPtr space, IntPtr data);

		[MonoTouch.MonoPInvokeCallback (typeof (BeginFunc))]
		static bool CollisionBegin (IntPtr arb, IntPtr space, IntPtr data)
		{
		    var handle = GCHandle.FromIntPtr (data);
		    var callbacks = (Tuple<Func<Arbiter,bool>, 
					   Func<Arbiter,bool>,
					   Action<Arbiter>,
					   Action<Arbiter>>)handle.Target;
		    //handle.Free ();
		    var arbiter = (arb == IntPtr.Zero ? null : new Arbiter (arb));
		    var func = callbacks.Item1;
		    if (func == null)
			return false;
		    return func (arbiter);
		}
		
		[MonoTouch.MonoPInvokeCallback (typeof (PreSolveFunc))]
		static bool CollisionPreSolve (IntPtr arb, IntPtr space, IntPtr data)
		{
		    var handle = GCHandle.FromIntPtr (data);
		    var callbacks = (Tuple<Func<Arbiter,bool>, 
					   Func<Arbiter,bool>,
					   Action<Arbiter>,
					   Action<Arbiter>>)handle.Target;
		    //handle.Free ();
		    var arbiter = (arb == IntPtr.Zero ? null : new Arbiter (arb));
		    var func = callbacks.Item2;
		    if (func == null)
			return false;
		    return func (arbiter);
		}

		[MonoTouch.MonoPInvokeCallback (typeof (PostSolveFunc))]
		static void CollisionPostSolve (IntPtr arb, IntPtr space, IntPtr data)
		{
		    var handle = GCHandle.FromIntPtr (data);
		    var callbacks = (Tuple<Func<Arbiter,bool>, 
					   Func<Arbiter,bool>,
					   Action<Arbiter>,
					   Action<Arbiter>>)handle.Target;
		    //handle.Free ();
		    var arbiter = (arb == IntPtr.Zero ? null : new Arbiter (arb));
		    var func = callbacks.Item3;
		    if (func == null)
			return;
		    func (arbiter);
		}

		[MonoTouch.MonoPInvokeCallback (typeof (SeparateFunc))]
		static void CollisionSeparate (IntPtr arb, IntPtr space, IntPtr data)
		{
		    var handle = GCHandle.FromIntPtr (data);
		    var callbacks = (Tuple<Func<Arbiter,bool>, 
					   Func<Arbiter,bool>,
					   Action<Arbiter>,
					   Action<Arbiter>>)handle.Target;
		    //handle.Free ();
		    var arbiter = (arb == IntPtr.Zero ? null : new Arbiter (arb));
		    var func = callbacks.Item4;
		    if (func == null)
			return;
		    func (arbiter);
		}

		[DllImport ("__Internal")]
		extern static void cpSpaceAddCollisionHandler (IntPtr space, uint collisionTypeA, uint collisionTypeB, BeginFunc begin, PreSolveFunc presolve, PostSolveFunc postsolve, SeparateFunc separate, IntPtr data);

		public void AddCollisionHandler (uint collisionTypeA, uint collisionTypeB, Func<Arbiter,bool> beginFunc, Func<Arbiter,bool> preSolveFunc, Action<Arbiter> postSolveFunc, Action<Arbiter> separateFunc)
		{
		    var callbacks = new Tuple<Func<Arbiter,bool>,Func<Arbiter,bool>,Action<Arbiter>,Action<Arbiter>> (beginFunc, preSolveFunc, postSolveFunc, separateFunc);
		    var data = GCHandle.ToIntPtr(GCHandle.Alloc (callbacks));

		    cpSpaceAddCollisionHandler (Handle.Handle, collisionTypeA, collisionTypeB, CollisionBegin, CollisionPreSolve, CollisionPostSolve, CollisionSeparate, data);
		    /*
		    BeginFunc begin = beginFunc == null ? (BeginFunc)null : (arbiter, space, data) => {
			Console.Write("b");
			return beginFunc(new Arbiter(arbiter), this);
		    };
		    PreSolveFunc presolve = preSolveFunc == null ? (PreSolveFunc)null : (arbiter, space, data) => {
			return preSolveFunc(new Arbiter(arbiter), this);
		    };
		    PostSolveFunc postsolve = postSolveFunc == null ? (PostSolveFunc)null : (arbiter, space, data) => {
			postSolveFunc (new Arbiter (arbiter), this);
		    };
		    SeparateFunc separate = separateFunc == null ? (SeparateFunc)null : (arbiter, psace, data) => {
			separateFunc (new Arbiter(arbiter), this);
		    };
		    cpSpaceAddCollisionHandler (Handle.Handle, collisionTypeA, collisionTypeB, begin, presolve, postsolve, separate, IntPtr.Zero);
		    */
		}

		[DllImport ("__Internal")]
		extern static void cpSpaceRemoveCollisionHandler (IntPtr space, uint collisionTypeA, uint collisionTypeB);

		public void RemoveCollisionHandler (uint collisionTypeA, uint collisionTypeB)
		{
		    cpSpaceRemoveCollisionHandler (Handle.Handle, collisionTypeA, collisionTypeB);
		}

		[DllImport ("__Internal")]
		extern static void cpSpaceSetDefaultCollisionHandler (IntPtr space, BeginFunc begin, PreSolveFunc presolve, PostSolveFunc postsolve, SeparateFunc separate, IntPtr data);

		void SetDefaultCollisionHandler (Func<Arbiter,Space,bool> beginFunc, Func<Arbiter,Space,bool> preSolveFunc, Action<Arbiter,Space> postSolveFunc, Action<Arbiter,Space> separateFunc)
		{
		    BeginFunc begin = beginFunc == null ? (BeginFunc)null : (arbiter, space, data) => {
			return beginFunc(new Arbiter(arbiter), this);
		    };
		    PreSolveFunc presolve = preSolveFunc == null ? (PreSolveFunc)null : (arbiter, space, data) => {
			return preSolveFunc(new Arbiter(arbiter), this);
		    };
		    PostSolveFunc postsolve = postSolveFunc == null ? (PostSolveFunc)null : (arbiter, space, data) => {
			postSolveFunc (new Arbiter (arbiter), this);
		    };
		    SeparateFunc separate = separateFunc == null ? (SeparateFunc)null : (arbiter, psace, data) => {
			separateFunc (new Arbiter(arbiter), this);
		    };
		    cpSpaceSetDefaultCollisionHandler (Handle.Handle, begin, presolve, postsolve, separate, IntPtr.Zero);
		}

		[DllImport("__Internal")]
		extern static IntPtr __cpSpaceGetUserData (IntPtr body);

		[DllImport("__Internal")]
		extern static void __cpSpaceSetUserData (IntPtr body, IntPtr userData);

		internal override IntPtr UserData {
		    get { return __cpSpaceGetUserData (Handle.Handle); }
		    set { __cpSpaceSetUserData (Handle.Handle, value); }
		}

	
	}
}
