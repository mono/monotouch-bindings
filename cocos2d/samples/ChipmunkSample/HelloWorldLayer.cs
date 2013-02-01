using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Cocos2D;
using MonoTouch.GameKit;

using Chipmunk;

namespace CC2DSharp
{
	public class HelloWorldLayer : CCLayer
	{

		int parentnode = 1;

		public static CCScene Scene {
			get {
				var scene = new CCScene();
				var layer = new HelloWorldLayer();
				scene.Add(layer);
				return scene;
			}
		}

		Random rnd = new Random();
		public HelloWorldLayer ()
		{
			IsTouchEnabled = true;
			UIAccelerometer.SharedAccelerometer.Delegate = new AccelerometerDelegate(DidAccelerate);

			var s = CCDirector.SharedDirector.WinSize;
			
			var label = new CCLabelTTF("Multi touch the screen", "Marker Felt", 36) {Position = new PointF (s.Width/2, s.Height - 40)};
			Add (label,-1);

			CreateMenu ();
		}

		void CreateMenu ()
		{
			CCMenuItemFont.DefaultFontSize = 22;

			var reset = new CCMenuItemFont("Reset",(sender)=>{
				CCDirector.SharedDirector.ReplaceScene(HelloWorldLayer.Scene);
			});

			var menu = new CCMenu(new CCMenuItem[]{reset});
			menu.AlignItemsVertically();
			var size = CCDirector.SharedDirector.WinSize;
			menu.Position=new PointF(size.Width/2, size.Height/2);
			Add (menu,-1);
		}

		float prevX=0f;
		float prevY=0f;
		void DidAccelerate (UIAccelerometer accelerometer, UIAcceleration acceleration)
		{
			var filterFactor =.5f;
			var accelX = (float)acceleration.X * filterFactor+(1-filterFactor)*prevX;
			var accelY = (float)acceleration.Y * filterFactor+(1-filterFactor)*prevY;
			prevX=accelX;
			prevY=accelY;
			PointF v;
			space.Gravity=new PointF(300*accelY, -300*accelX);
		}

		public override void OnTouchesEnded (NSSet touches, UIEvent ev)
		{
			foreach(UITouch touch in touches) {
				var location = touch.LocationInView(touch.View);
				location=CCDirector.SharedDirector.ConvertToGL(location);
				AddNewSpriteAt(location);
			}
		}

		Shape[] walls = new Shape[4];
		Space space;

		void InitPhysics ()
		{
			var s = CCDirector.SharedDirector.WinSize;
			space = new Space() {Gravity = new PointF(0,-300)};

			// bottom
			walls[0] = new SegmentShape(space.StaticBody, new PointF(0,0), new PointF(s.Width, 0), 0f);
			// top
			walls[1] = new SegmentShape(space.StaticBody, new PointF(0,s.Height), new PointF(s.Width, s.Height), 0f);
			// left
			walls[2] = new SegmentShape(space.StaticBody, new PointF(0,0), new PointF(0, s.Height), 0f);
			// right
			walls[3] = new SegmentShape(space.StaticBody, new PointF(s.Width,0), new PointF(s.Width, s.Height), 0f);

			foreach(var shape in walls) {
				shape.Elasticity=2f;
				shape.Friction=1f;
				space.AddStaticShape(shape);
			}
		}

		public override void OnEnter ()
		{
			base.OnEnter();

			InitPhysics ();
			
			
			var parent = new CCSpriteBatchNode("grossini_dance_atlas.png", 100);
			Add (parent, 0, parentnode);
			
			AddNewSpriteAt(new PointF(200,200));
			Schedule(Update);
		}

		public void Update (float delta)
		{
			// Should use a fixed size step based on the animation interval.
			int steps = 2;
			var dt = (float)CCDirector.SharedDirector.AnimationInterval/steps;
			
			for(int i=0; i<steps; i++){
				space.Step(dt);
			}
		}

		void AddNewSpriteAt (PointF pos)
		{
			int posx, posy;
			
			var parent = GetChild(parentnode) as CCSpriteBatchNode;
			
			posx = (int)(rnd.NextDouble() * 200.0f);
			posy = (int)(rnd.NextDouble() * 200.0f);
			
			posx = (posx % 4) * 85;
			posy = (posy % 3) * 121;

			var sprite = new CCPhysicsSprite (parent.Texture, new RectangleF (posx, posy, 85, 121));
			//this used to work, but crashes now, as it sets the Body's position and the Body isn't set yet :/
			//sprite.Position = pos;

			parent.Add(sprite);
			                           
			PointF[] verts = {
				new PointF(-24,-54),
				new PointF(-24, 54),
				new PointF( 24, 54),
				new PointF( 24,-54),
			};
			
			var body = new Body(1, Helper.MomentForPolygon(1f, verts, PointF.Empty)) {Position=pos};
			space.Add(body);

			var shape = new PolygonShape(body, verts, PointF.Empty) {
				Elasticity = .5f,
				Friction =.5f
			};

			space.Add(shape);
			sprite.Body = body;
		}
	}

	public class AccelerometerDelegate : UIAccelerometerDelegate
	{
		Action<UIAccelerometer, UIAcceleration> callback;
		public AccelerometerDelegate (Action<UIAccelerometer, UIAcceleration> callback)
		{
			this.callback = callback;
		}

		public override void DidAccelerate (UIAccelerometer accelerometer, UIAcceleration acceleration)
		{
			callback(accelerometer,acceleration);
		}
	}
}

