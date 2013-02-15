using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using GCDiscreetNotification;

namespace GCDiscreetNotificationDemo
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UINavigationController navController;
		DialogViewController dvc;

		EntryElement text2Show;
		BooleanElement topBottom;
		BooleanElement showActivity;

		GCDiscreetNotificationView notificationView;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			var root = new RootElement ("Discreet Sample") {
				new Section ("Settings") {
					(text2Show = new EntryElement ("Text2Show:", "Some text here", "I'm so Discreet")),
					new StringElement ("Show", Show) {
						Alignment = UITextAlignment.Center
					},
					new StringElement ("Hide", Hide) {
						Alignment = UITextAlignment.Center
					},
					new StringElement ("Hide after 1 second", HideAfter1sec) {
						Alignment = UITextAlignment.Center
					},
					(topBottom = new BooleanElement ("Top / Bottom", true)),
					(showActivity = new BooleanElement ("Show Activity?", true))
				}
			};

			dvc = new DialogViewController (root);
			navController = new UINavigationController (dvc);

			window.RootViewController = navController;
			window.MakeKeyAndVisible ();

			notificationView = new GCDiscreetNotificationView (text:text2Show.Value,
			                                                   activity: showActivity.Value,
			                                                   presentationMode: topBottom.Value ? GCDNPresentationMode.Top : GCDNPresentationMode.Bottom,
			                                                   view: dvc.View);
			showActivity.ValueChanged += ChangeActivity;
			topBottom.ValueChanged += ChangeTopBottom;
			text2Show.Changed += HandleChanged;

			return true;
		}

		void Show ()
		{
			notificationView.Show (animated: true);
		}

		void Hide ()
		{
			notificationView.Hide (animated: true);
		}

		void HideAfter1sec ()
		{
			notificationView.hideAnimated (timeInterval: 1);
		}

		void ChangeActivity (object sender, EventArgs e)
		{
			notificationView.SetShowActivity (activity: showActivity.Value, animated: true);
		}

		void ChangeTopBottom (object sender, EventArgs e)
		{
			notificationView.PresentationMode = topBottom.Value ? GCDNPresentationMode.Top : GCDNPresentationMode.Bottom;
		}

		void HandleChanged (object sender, EventArgs e)
		{
			notificationView.SetTextLabel (text: text2Show.Value, animated: true);
		}
	}
}

