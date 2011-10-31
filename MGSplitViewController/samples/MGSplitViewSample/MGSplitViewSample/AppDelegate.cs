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
using MonoTouch.UIKit;

using MG;

namespace MGSplitViewSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		MGSplitViewController splitViewController;
		DetailViewController details;
		RootViewController root;
		UIWindow window;
		
		class SplitViewDelegate : MGSplitViewControllerDelegate {
			DetailViewController details;
			
			public SplitViewDelegate (DetailViewController details)
			{
				this.details = details;
			}
			
			public override void WillHideViewController (MGSplitViewController svc, UIViewController viewController, UIBarButtonItem barButtonItem, UIPopoverController popoverController)
			{
				Console.WriteLine ("Got called.");
				
				if (barButtonItem != null) {
					barButtonItem.Title = "Popover";
					
					details.AddButton (barButtonItem);
				}
			}
			
			public override void WillShowViewController (MGSplitViewController svc, UIViewController viewController, UIBarButtonItem barButtonItem)
			{
				if (barButtonItem != null)
					details.RemoveButton (barButtonItem);
			}
			
			public override void PopoverController (MGSplitViewController svc, UIPopoverController popovercontroller, UIViewController viewController)
			{
				base.PopoverController (svc, popovercontroller, viewController);
			}
		}
		
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			splitViewController = new MGSplitViewController ();
			details = new DetailViewController (splitViewController);
			root = new RootViewController ();
			
			splitViewController.Delegate = new SplitViewDelegate (details);
			UIViewController[] controllers = new UIViewController[2];
			controllers[0] = root;
			controllers[1] = details;
			splitViewController.ViewControllers = controllers;
			
			// make the window visible
			window.RootViewController = splitViewController;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

