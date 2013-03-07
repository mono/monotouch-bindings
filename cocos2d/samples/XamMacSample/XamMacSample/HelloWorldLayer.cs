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
	public class HelloWorldLayer : CCLayer
	{
		public HelloWorldLayer ()
		{
			var size = CCDirector.SharedDirector.WinSize;

			var label = new CCLabelTTF ("Hello Xamarin.Mac", "Marker Felt", 64) {
				Position = new PointF (size.Width/2,size.Height/2),
			};
			Add (label);

		}
	}
}

