using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

using GoogleAnalytics.iOS;

namespace CuteAnimalsiOS
{
	public class DVCCategory : DialogViewController
	{
		public string Category;

		public DVCCategory (string category, int numberOfPics) : base (null, true)
		{
			Category = category;
			var section = new Section ();

			for (int picNumber = 1; picNumber <= numberOfPics; picNumber++) {
				var picNo = picNumber;
				var picName = string.Format ("{0} {1}", category, picNumber);
				section.Add (new StringElement (picName, ()=> {
					var animalView = new AnimalViewController (Category, picNo);
					NavigationController.PushViewController (animalView, true);
				}));
			}

			Root = new RootElement (Category) {
				section
			};
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			// This screen name value will remain set on the tracker and sent with
			// hits until it is set to a new value or to null.
			GAI.SharedInstance.DefaultTracker.Set (GAIConstants.ScreenName, Category + " Category View");

			GAI.SharedInstance.DefaultTracker.Send (GAIDictionaryBuilder.CreateAppView ().Build ());
		}
	}
}

