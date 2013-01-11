// 
// AppDelegate.cs
//  
// Author: Jeffrey Stedfast <jeff@xamarin.com>
// 
// Copyright (c) 2011 Xamarin Inc.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 

using System;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace CorePlotiOSSample
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UINavigationController nav;
		DialogViewController dvc;
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			var root = new RootElement ("CorePlot Samples"){
				new Section () {
					new RootElement ("XYGraph", r => new ScatterPlot ()),
					new RootElement ("BarChart", r => new BarPlot ()),
					new RootElement ("PieChart", r => new PiePlot ()),
					new RootElement ("RangePlot", r => new RangePlot ())
				}
			};
			
			dvc = new DialogViewController (root);
			nav = new UINavigationController (dvc);
			
			window.RootViewController = nav;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

