using System;
using MonoTouch.Cocos2D;
using UIKit;
using ObjCRuntime;
using Foundation;

namespace CC2DSharp
{
	public class IntroLayer : CCLayer
	{
		public static CCScene Scene {
			get {
				var scene = new CCScene ();
				var layer = new IntroLayer ();
				scene.Add (layer);
				return scene;
			}
		}

		public IntroLayer ()
		{
		}

		public override void OnEnter ()
		{
			base.OnEnter ();

			CCSprite background;
			var size = CCDirector.SharedDirector.WinSize;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {
				background = new CCSprite ("Default.png");
				background.Rotation = 90;
			} else
				background = new CCSprite ("Default-Landscape~ipad.png");
			background.Position = new CoreGraphics.CGPoint (size.Width / 2, size.Height / 2);
			Add (background);

			ScheduleOnce ((timer) => {
				CCDirector.SharedDirector.ReplaceScene (new CCTransitionTurnOffTiles (1f, HelloWorldLayer.Scene));
			}, 1f);
		}
	}
}

