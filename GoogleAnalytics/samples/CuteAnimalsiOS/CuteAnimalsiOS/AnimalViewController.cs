using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

using GoogleAnalytics.iOS;

namespace CuteAnimalsiOS
{
	public class AnimalViewController : UIViewController
	{
		public string Animal;
		public int SelectedIndex;
		UIImageView imageView;

		public AnimalViewController (string animal, int selectedIndex)
		{
			Animal = animal;
			SelectedIndex = selectedIndex;
			Title = Animal + SelectedIndex + " View";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.BackgroundColor = UIColor.White;
			imageView = new UIImageView (View.Bounds) {
				ContentMode = UIViewContentMode.ScaleAspectFit,
				Image = UIImage.FromBundle (Animal + "-" + SelectedIndex + ".jpg")
			};

			View.AddSubview (imageView);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			// This screen name value will remain set on the tracker and sent with
			// hits until it is set to a new value or to null.
			GAI.SharedInstance.DefaultTracker.Set (GAIConstants.ScreenName, Title);

			GAI.SharedInstance.DefaultTracker.Send (GAIDictionaryBuilder.CreateAppView ().Build ());
		}
	}
}