//
// HelloWorldLayer.cs
//
// Author:
//       Stephane Delcroix <stephane@delcroix.org>
//
// Copyright (c) 2013 S. Delcroix
//
using System;
using System.Drawing;
using MonoMac.Cocos2D;

namespace XamMacSample
{
	public class HelloWorldLayer : CCLayerColor
	{
		public HelloWorldLayer () : base (new CCColor4B (0xaa, 0xaa, 0xaa, 0xff))
		{
			var size = CCDirector.SharedDirector.WinSize;

			var label = new CCLabelTTF ("Hello Xamarin.Mac", "Marker Felt", 32) {
				Position = new PointF (size.Width/2,size.Height/2),
			};
			Add (label);

		}

		public override void OnEnter ()
		{
			//var sprite = new CCSprite ("Character0") {Position = new PointF (10,10)};
			//Add (sprite);
			base.OnEnter ();
		}
	}
}

