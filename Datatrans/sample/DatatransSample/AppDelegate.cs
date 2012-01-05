using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using Datatrans;

namespace DatatransSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UINavigationController nav;
		DialogViewController dvc;
		UIWindow window;
		DtPaymentController dtpc;
		CinetoilePaymentContoller cpc;
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
			

			var root = new RootElement ("Datatrans Samples"){
				new Section () {
					new RootElement ("Test")
				}
			};
			
			
			dvc = new DialogViewController (root);
			nav = new UINavigationController (dvc);
			
			var paymentRequest = new DtPaymentRequest() {
				AmountInSmallestCurrencyUnit = 1000,
				CurrencyCode = @"CHF",
				LocalizedPriceDescription = @"CHF 10.-",
				MerchantId = @"12345",
				Refno = @"refno12345"
			};
			
			cpc = new CinetoilePaymentContoller();
			dtpc = DtPaymentController.FromDelegate(cpc, paymentRequest, DtPaymentController.AllAvailablePaymentMethods());
			dtpc.PresentIn(nav, true);
			// make the window visible
			window.RootViewController = nav;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

