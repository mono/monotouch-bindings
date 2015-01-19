// HighScoreLayer.cs
//
// Author(s)
//	Stephane Delcroix <stephane@delcroix.org>
//
// Copyright (C) 2012 s. Delcroix
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
// and associated documentation files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
//		
// 		The above copyright notice and this permission notice shall be included in all copies or 
//		substantial portions of the Software.
//		
//		THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING 
//		BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
//		NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
//		DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
//		OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using CoreGraphics;
using MonoTouch.Cocos2D;

namespace Jumpy
{
	public class HighScoreLayer:MainLayer
	{
		public static CCScene Scene (int score)
		{
			var scene = new CCScene (); 
			var layer = new HighScoreLayer (score);
			scene.Add (layer);
			return scene;
		}

		public override void OnEnter ()
		{
			base.OnEnter ();
			Schedule (Step);
		}

		public HighScoreLayer (int score) : base ()
		{
			var batchnode = GetChild ((int)Tags.SpriteManager) as CCSpriteBatchNode;
			var title = new CCSprite (batchnode.Texture, new CGRect (608, 192, 225, 57)) { Position = new CGPoint (160, 240) };
			batchnode.Add (title);

			var button1 = new CCMenuItemImage ("Images/playAgainButton.png", "Images/playAgainButton.png", (sender) => {
				CCDirector.SharedDirector.ReplaceScene (new CCTransitionFade (.5f, GameLayer.Scene, CCColor3B.White));
			});
			var button2 = new CCMenuItemImage ("Images/changePlayerButton.png", "Images/changePlayerButton.png", (sender) => {

			});
			var menu = new CCMenu (new CCMenuItem[] { button1, button2 }) { Position = new CGPoint (160, 58) };
			menu.AlignItemsVertically (9);

			Add (menu);
			

		}
	}
}

