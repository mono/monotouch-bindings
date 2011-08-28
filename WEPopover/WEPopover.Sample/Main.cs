using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace WEPopover.Sample
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}

	// The name AppDelegate is referenced in the MainWindow.xib file.
	public partial class AppDelegate : UIApplicationDelegate
	{
		WEPopoverController controller;
		UIViewController viewController;
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			viewController = new UIViewController();
			viewController.View.Frame = new System.Drawing.RectangleF(0, 0, 100, 100);
			
			
			controller = new WEPopoverController(viewController);
			controller.ContentSize = new System.Drawing.SizeF(100 ,100);
			
			controller.PresentFromRect(new RectangleF(0, 0, 100, 100), UIPopoverArrowDirection.Left, true);
			
			
//			window.AddSubview (navigationController.View);
			window.MakeKeyAndVisible ();
			
			return true;
		}

		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}
		
		/*
		public override void WillTerminate (UIApplication application)
		{
			//Save data here
		}
		*/
	}
}

