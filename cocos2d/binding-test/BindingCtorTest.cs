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
using System.Drawing;
using System.Reflection;
using System.Collections.Generic;

using NUnit.Framework;
using TouchUnit.Bindings;

#if MONOMAC
using MonoMac.AppKit;
using MonoMac.Cocos2D;
using MonoMac.Foundation;
#else
using MonoTouch.UIKit;
using MonoTouch.Cocos2D;
using MonoTouch.Foundation;
#endif
namespace Cocos2D.Bindings {

	[TestFixture]
	public class BindingCtorTest : ApiCtorInitTest	{

		public BindingCtorTest ()
		{
			// Useful to know what was being tested if the application crash
			// LogProgress = true;

			// Useful for fixing several errors before rebuilding the bindings
			// ContinueOnFailure = true;

			// Useful to know which types are being skipped for lack of a default ctor
			// LogUntestedTypes = true;
		}

		static List<object> do_not_dispose = new List<object> ();
		protected override void Dispose (NSObject obj, Type type)
		{
			if (type == typeof(CCDrawNode)) {
				do_not_dispose.Add (obj);
				return;
			}
			base.Dispose (obj, type);
		}

		[SetUp]
		public void Setup ()
		{
			//Some types require a working Director, like CCTextureCache
			var director =  CCDirector.SharedDirector;
#if MONOMAC
			//var glView = new CCGLView ();
#else
			var glView = new CCGLView (MonoTouch.UIKit.UIScreen.MainScreen.Bounds);
			director.View = glView;
			//UIApplication.SharedApplication.Windows[0].RootViewController.PresentViewController (new UINavigationController (director), false, null);
#endif

		}

		//[TearDown]
		//public void TearDown ()
		//{
		//	UIApplication.SharedApplication.Windows[0].RootViewController.DismissViewController (false, null);
		//}

		protected override Assembly Assembly {
			get { return typeof (CCAccelAmplitude).Assembly; }
		}
	}
}