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
		UINavigationController navController;
		UIButton button;
		WEPopoverController popController;
		UIViewController viewController;
		RectangleF rect = new RectangleF(0, 0, 100, 100);
		
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{	
			navController = new UINavigationController();
			navController.View.BackgroundColor = UIColor.Red;
			
			button = UIButton.FromType(UIButtonType.RoundedRect);
			button.Frame = new RectangleF(100, 100, 100,100);
			button.SetTitle("FOO", UIControlState.Normal);
			button.TouchDown += HandleButtonTouchDown;
			
			navController.View.AddSubview(button);
			
			viewController = new UIViewController();
			viewController.View.BackgroundColor = UIColor.Blue;
			viewController.View.Frame = new RectangleF(0, 0, 50, 50);
			
			popController = new WEPopoverController(viewController);
			popController.Delegate = new PopoverDelegate();
			popController.ContentSize = new SizeF(50, 50);
			
			
			window.RootViewController = navController;
			window.MakeKeyAndVisible ();
			
			return true;
		}

		void HandleButtonTouchDown (object sender, EventArgs e)
		{
			using(var pool = new NSAutoreleasePool())
			{
				pool.BeginInvokeOnMainThread(()=>
             	{
					try {
						
						popController.ContentSize = new SizeF(50 ,50);
						popController.PresentFromRect(rect, navController.View, UIPopoverArrowDirection.Left, true);
						
			
					} catch (Exception ex) {
						throw ex;
					}
				});
				
			}
		}
		
		public class PopoverDelegate : WEPopoverControllerDelegate
		{
			public override void DidDismissPopover (WEPopoverController popover)
			{
				Console.WriteLine(popover.ContentSize);
			}
			public override bool ShouldDismissPopover (WEPopoverController popover)
			{
				return true;
			}
			
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

