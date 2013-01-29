//
// Authors:
//	Sebastien Pouliot  <sebastien@xamarin.com>
//
// Copyright 2013 Xamarin Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Reflection;

using NUnit.Framework;
using TouchUnit.Bindings;

using MonoTouch.Cocos2D;

namespace Cocos2D.Bindings {
	
	[TestFixture]
	public class BindingSelectorTest : ApiSelectorTest {
		
		public BindingSelectorTest ()
		{
			// Useful to know what was being tried if things crash
			// LogProgress = true;

			// Useful for fixing several errors before rebuilding the bindings
			// ContinueOnFailure = true;
		}
		
		protected override Assembly Assembly {
			get { return typeof (CCAccelAmplitude).Assembly; }
		}
		
		protected override bool Skip (Type type, string selectorName)
		{
			switch (selectorName) {
			// CCRGBAProtocol
			case "doesOpacityModifyRGB":
			case "opacityModifyRGB:":
				switch (type.Name) {
				case "CCAtlasNode":
				case "CCLabelBMFont":
				case "CCLayerColor":
				case "CCMenu":
				case "CCMenuItemLabel":
				case "CCMenuItemSprite":
				case "CCMenuItemToggle":
				case "CCSprite":
					return true;
				}
				break;
			// CCTargetedTouchDelegate
			case "ccTouchMoved:withEvent:":
			case "ccTouchEnded:withEvent:":
			case "ccTouchCancelled:withEvent:":
			case "ccTouchesBegan:withEvent:":
			case "ccTouchesMoved:withEvent:":
			case "ccTouchesEnded:withEvent:":
			case "ccTouchesCancelled:withEvent:":
				return type.Name == "CCLayer";
			}
			return base.Skip (type, selectorName);
		}
	}
}