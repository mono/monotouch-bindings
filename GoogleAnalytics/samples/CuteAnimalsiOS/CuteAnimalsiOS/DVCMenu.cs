using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using MonoTouch.ObjCRuntime;

using GoogleAnalytics.iOS;

namespace CuteAnimalsiOS
{
	public class DVCMenu : DialogViewController
	{
		public DVCMenu () : base (null)
		{
			Root = new RootElement ("Cute Animals") {
				new Section () {
					new StringElement ("Cute Monkey Pictures!", ()=> {
						var categoryView = new DVCCategory ("Monkey", 8);
						NavigationController.PushViewController (categoryView, true);
					}),
					new StringElement ("Cute Cat Pictures!", ()=> {
						var categoryView = new DVCCategory ("Cat", 4);
						NavigationController.PushViewController (categoryView, true);
					}),
					new StringElement ("Cute Bunny Pictures!", ()=> {
						var categoryView = new DVCCategory ("Bunny", 3);
						NavigationController.PushViewController (categoryView, true);
					}),
					new StringElement ("Cute Lion Pictures!", ()=> {
						var categoryView = new DVCCategory ("Lion", 4);
						NavigationController.PushViewController (categoryView, true);
					}),
					new StringElement ("Cute Tiger Pictures!", ()=> {
						var categoryView = new DVCCategory ("Tiger", 2);
						NavigationController.PushViewController (categoryView, true);
					}),
				}
			};
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Create a GA event and dispatch it to GA.
			NavigationItem.LeftBarButtonItem = new UIBarButtonItem ("Dispatch", UIBarButtonItemStyle.Bordered, (s, e) => {
				var gaEvent = GAIDictionaryBuilder.CreateEvent ("UI", "buttonPress", "dispatch", null).Build ();
				GAI.SharedInstance.DefaultTracker.Send (gaEvent);
				GAI.SharedInstance.Dispatch ();
				Console.WriteLine ("Event Sent, Check Google's GA Event Console");
			});

			// Create a Crash
			NavigationItem.RightBarButtonItem = new UIBarButtonItem ("Crash", UIBarButtonItemStyle.Bordered, (s, e) => {
				var obj = new NSObject ();
				obj.PerformSelector (new Selector ("doesNotRecognizeSelector"), obj, 0);
			});
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			// This screen name value will remain set on the tracker and sent with
			// hits until it is set to a new value or to null.
			GAI.SharedInstance.DefaultTracker.Set (GAIConstants.ScreenName, "Main Menu");

			GAI.SharedInstance.DefaultTracker.Send (GAIDictionaryBuilder.CreateAppView ().Build ());
		}
	}
}

