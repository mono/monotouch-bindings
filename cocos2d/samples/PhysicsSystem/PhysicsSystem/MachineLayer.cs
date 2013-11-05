using System;
using System.Drawing;

using MonoTouch.Cocos2D;
using MonoTouch.UIKit;
using Chipmunk;

namespace PhysicsSystem
{
	public class MachineLayer : CCLayer
	{

		public static CCScene Scene {
			get {
				var scene = new CCScene ();
				var layer = new MachineLayer ();
				scene.Add (layer);
				return scene;
			}
		}

		Space space;
		public MachineLayer ()
		{
			space = new Space () {
				Gravity = new PointF (0, -10),
			};

			Add ( new CCSprite ("bg.jpg") {
				Position = UIDevice.CurrentDevice.IsIPad() ? new PointF(512, 384) : new PointF(240, 160),
			});

			//motorblock, no body, no shape
			var motorblock = new CCSprite ("motor_block.png") {
				Position = UIDevice.CurrentDevice.IsIPad() ? new PointF (160, 460) : new PointF (80, 230),
			};
			Add (motorblock);

			//motorwheel
			var motorwheel = new CCPhysicsSprite ("motor_wheel.png") {
				Body = new Body (1, Helper.MomentForCircle (1, 20, 20, PointF.Empty)),
				Position = UIDevice.CurrentDevice.IsIPad() ? new PointF (160, 460) : new PointF (80, 230),
			};
			Add (motorwheel);

			space.Add (motorwheel.Body);
			space.Add (new CircleShape (motorwheel.Body, UIDevice.CurrentDevice.IsIPad() ? 20 : 10, PointF.Empty) {Group = 1});
			space.Add ((Constraint)new PivotJoint (space.StaticBody, motorwheel.Body, UIDevice.CurrentDevice.IsIPad() ? new PointF (160,460) : new PointF (80, 230)));
			space.Add ((Constraint)new SimpleMotor (space.StaticBody, motorwheel.Body, 10f));
			
			//wheel
			var wheel = new CCPhysicsSprite ("wheel.png") {
				Body = new Body (25, Helper.MomentForCircle (25, 140, 140, PointF.Empty)),
				Position = UIDevice.CurrentDevice.IsIPad() ? new PointF (160, 300) : new PointF (80, 150),
			};
			space.Add (wheel.Body);
			space.Add (new CircleShape (wheel.Body, UIDevice.CurrentDevice.IsIPad() ? 140 : 70, PointF.Empty){Group = 1});
			Add (wheel);
			space.Add ((Constraint)new PivotJoint (space.StaticBody, wheel.Body, UIDevice.CurrentDevice.IsIPad() ? new PointF (160, 300) : new PointF (80, 150)));
			space.Add ((Constraint)new GearJoint (motorwheel.Body, wheel.Body, 0f, -7f));

			//cylinder. no physics body. only a shape
			Add (new CCSprite ("cylinder.png") {
				Position = UIDevice.CurrentDevice.IsIPad() ? new PointF (570, 300) : new PointF (285, 150),
			});

			//space.Add (new PolygonShape (space.StaticBody, new [] {
			//	new PointF (350, 160),
			//	new PointF (350, 200),
			//	new PointF (750, 200),
			//	new PointF (750, 160),
			//}, PointF.Empty));
			//
			//space.Add (new PolygonShape (space.StaticBody, new [] {
			//	new PointF (350, 400),
			//	new PointF (350, 440),
			//	new PointF (750, 440),
			//	new PointF (750, 400),
			//}, PointF.Empty));

			//piston
			var piston = new CCPhysicsSprite ("piston.png") {
				Body = new Body (8, float.PositiveInfinity), //never rotates
				Position = UIDevice.CurrentDevice.IsIPad() ? new PointF (370, 300) : new PointF (185, 150),
			};
			space.Add (piston.Body);
			space.Add (new PolygonShape (piston.Body, UIDevice.CurrentDevice.IsIPad() ? 100 : 50, UIDevice.CurrentDevice.IsIPad() ? 200 : 50) {Group = 1});
			Add (piston);

			//conrod
			var conrod = new CCPhysicsSprite ("conrod.png") {
				Body = new Body (4, Helper.MomentForPolygon (4, new[] {
					new PointF (-160,-20),
					new PointF (-160, 20),
					new PointF (160, 20),
					new PointF (160, -20),
				}, PointF.Empty)),
				Position = UIDevice.CurrentDevice.IsIPad() ? new PointF (190, 300) : new PointF (95, 150)
			};
			space.Add (conrod.Body);
			space.Add (new PolygonShape (conrod.Body, UIDevice.CurrentDevice.IsIPad() ? 320 : 160, UIDevice.CurrentDevice.IsIPad() ? 40 : 20) {Group = 1});
			Add (conrod);
			space.Add ((Constraint)new PivotJoint (wheel.Body, conrod.Body, UIDevice.CurrentDevice.IsIPad() ? new PointF (40, 300) : new PointF (20, 150)));

			space.Add ((Constraint)new PivotJoint (conrod.Body, piston.Body, UIDevice.CurrentDevice.IsIPad() ? new PointF (340, 300) : new PointF (170, 150)));
			space.Add ((Constraint)new GrooveJoint (space.StaticBody, 
			                            piston.Body, 
			                            UIDevice.CurrentDevice.IsIPad() ? new PointF (0, 300) : new PointF (0, 150), 
			                            UIDevice.CurrentDevice.IsIPad() ? new PointF (1024, 300) : new PointF (480, 150),
			                            UIDevice.CurrentDevice.IsIPad() ? new PointF (0, 0): new PointF (0, 0)));

		}

		public override void OnEnter ()
		{
			base.OnEnter ();

			Schedule (Update);
		}

		new void Update (float dt)
		{
			space.Step (dt);
		}
	}
}

