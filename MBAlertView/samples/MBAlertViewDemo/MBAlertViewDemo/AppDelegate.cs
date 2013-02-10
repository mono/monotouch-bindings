using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using AlertView;

namespace MBAlertViewDemo
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UIViewController controller;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			window.BackgroundColor = UIColor.White;
			window.MakeKeyAndVisible ();

			controller = new UIViewController ();
			window.RootViewController = controller;

			MBHUDView.HudWithBody ("Hello", MBAlertViewHUDType.Checkmark, 1.0f, true);
			var alert = MBAlertView.AlertWithBody ("Do you want to see more? (Note: you don't have a choice)", null, null);

			alert.AddButtonWithText ("Yes", MBAlertViewItemType.Positive, () => {

				MBHUDView.HudWithBody ("Say please", MBAlertViewHUDType.ExclamationMark, 1.5f, true);
				var please = MBAlertView.AlertWithBody ("Did you say please?", null, null);
				please.Size = new System.Drawing.SizeF (280f, 180f);

				please.AddButtonWithText ("Yes", MBAlertViewItemType.Positive, () => {

					MBHUDView.HudWithBody ("Good boy.", MBAlertViewHUDType.Checkmark, 1.0f, true);
					MBHUDView.HudWithBody ("Wait", MBAlertViewHUDType.ActivityIndicator, 4.0f, true);
					MBHUDView.HudWithBody ("Ready?", MBAlertViewHUDType.Default, 2.0f, true);

					var destruct = MBAlertView.AlertWithBody ("Do you want your device to self-destruct?", null, null);
					destruct.ImageView.Image = UIImage.FromBundle ("image.png");

					destruct.AddButtonWithText ("Yes please", MBAlertViewItemType.Destructive, () => {

						MBHUDView.HudWithBody ("Ok", MBAlertViewHUDType.Checkmark, 1.0f, true);
						MBHUDView.HudWithBody ("5", MBAlertViewHUDType.Default, 1.0f, true);
						MBHUDView.HudWithBody ("4", MBAlertViewHUDType.Default, 1.0f, true);
						MBHUDView.HudWithBody ("3", MBAlertViewHUDType.Default, 1.0f, true);
						MBHUDView.HudWithBody ("2", MBAlertViewHUDType.Default, 1.0f, true);
						MBHUDView.HudWithBody ("1", MBAlertViewHUDType.Default, 1.0f, true);
						InvokeOnMainThread (()=> {

							var hud = MBHUDView.HudWithBody ("Goodbye", MBAlertViewHUDType.ExclamationMark, 2.0f, true);
							hud.SetDismissalHandler (()=> {
								UIView.Animate (2, ()=> {
									controller.View.BackgroundColor = UIColor.Black;
								});
							});
						});
					});

					destruct.AddToDisplayQueue ();
				});

				please.AddToDisplayQueue();
			});

			alert.AddToDisplayQueue();			
			return true;
		}
	}
}

