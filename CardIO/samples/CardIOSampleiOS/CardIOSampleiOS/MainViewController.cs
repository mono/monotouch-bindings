using System;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using Card.IO;

namespace CardIOSampleiOS
{
	public class MainViewController : DialogViewController
	{
		public MainViewController () : base(UITableViewStyle.Plain, new RootElement("card.io"), false)
		{
		}

		PaymentViewController paymentViewController;
		PaymentViewControllerDelegate paymentDelegate;

		StyledStringElement elemCardNumber;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			paymentDelegate = new PaymentViewControllerDelegate ();
			paymentDelegate.OnScanCompleted += (viewController, cardInfo) => {

				if (cardInfo == null) {
					elemCardNumber.Caption = "xxxx xxxx xxxx xxxx";
					Console.WriteLine("Cancelled");
				} else {
					elemCardNumber.Caption = cardInfo.CardNumber;
				}

				ReloadData();

				paymentViewController.DismissViewController(true, null);			
			};

			elemCardNumber = new StyledStringElement ("xxxx xxxx xxxx xxxx");

			Root = new RootElement ("card.io") {
				new Section {
					elemCardNumber,
					new StyledStringElement("Enter your Credit Card", () => {
						paymentViewController = new PaymentViewController(paymentDelegate);
						paymentViewController.AppToken = "YOUR-APP-TOKEN";

						NavigationController.PresentViewController(paymentViewController, true, null);
					}) { Accessory = UITableViewCellAccessory.DisclosureIndicator }
				}
			};
		}
	}
}