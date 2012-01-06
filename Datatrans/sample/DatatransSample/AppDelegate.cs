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
		RootElement rootNode;
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
			

			rootNode = new RootElement ("Datatrans Samples"){
				new Section () {
					
					
					new RootElement ("DtPaymentMethod", new RadioGroup (0)){
						new Section (){
							from n in DtPaymentController.AllAvailablePaymentMethods()
							select (Element) new CheckboxElement (n, true)
						}
					},
					
					new RootElement ("DtPaymentRequest"){
						new Section (){
							new EntryElement ("Amount", null, "6400"),
							new EntryElement ("CurrencyCode", null, "CHF"),
							new EntryElement ("PriceDescription", null, "CHF 64.-"),
							new EntryElement ("MerchantId", "Provided by Datatrans", "1000011011"),
							new EntryElement ("Refno", null, "refno12345"),
							new EntryElement ("MerchantName", null, "Test Datatrans"),
						}
					},
					
					new RootElement ("DtPaymentOptions"){
						new Section (){
							new BooleanElement ("HideToolbarSecurityInfo", true),
							new RootElement ("ReturnsCreditCard", new RadioGroup (0)){
								new Section (){
									new RadioElement ("Never"),
									new RadioElement ("DefaultYes"),
									new RadioElement ("DefaultNo")
								}
							},
							new BooleanElement ("ShowBackButton", false),
							new BooleanElement ("Testing", false)
						}
					},
					
					new StringElement ("DtPaymentController", DtPayementController),
					new StringElement ("DtPaymentControllerStatic", DtPayementControllerStatic)
					
				}
			};
			
			
			dvc = new DialogViewController (rootNode);
			nav = new UINavigationController (dvc);
			
			// make the window visible
			window.RootViewController = nav;
			window.MakeKeyAndVisible ();
			
			return true;
		}
		
		
		string StringAt(RootElement re, int section, int row) {
			return ((EntryElement)re[section][row]).Value;
		}
		RootElement RootAt(RootElement re, int section, int row) {
			return ((RootElement)re[section][row]);
		}
		bool BoolAt(RootElement re, int section, int row) {
			return ((BooleanElement)re[section][row]).Value;
		}
		
		RadioElement RadioAt(RootElement re, int section, int row) {
			return ((RadioElement)re[section][row]);
		}
		RadioElement SelAt(RootElement re, int section, int row) {
			int i = RootAt(re, section, row).RadioSelected;
			var selected = RadioAt(RootAt(re, section, row), 0, i);
			return selected;
		}
		
		void DtPayementController() {
			

			var method = RootAt(rootNode, 0, 0);
			var request = RootAt(rootNode, 0, 1);
			var options = RootAt(rootNode, 0, 2);
			
			
			int amount = 0;
			int.TryParse(StringAt(request, 0, 0), out amount);
			var currency = StringAt(request, 0, 1);
			var price = StringAt(request, 0, 2);
			var merchantid = StringAt(request, 0, 3);
			var refno = StringAt(request, 0, 4);
			var merchantname = StringAt(request, 0, 5);
			
			
			var hideToolbar = BoolAt(options, 0,0);
			var rcc = SelAt(options, 0,1);
			var showBack = BoolAt(options, 0,2);
			var testing = BoolAt(options, 0,3);
			
			DtPaymentReturnsCreditCard dprcc= DtPaymentReturnsCreditCard.Never;
			Enum.TryParse<DtPaymentReturnsCreditCard>(rcc.Caption, out dprcc);
			
			var paymentRequest = new DtPaymentRequest() {
				AmountInSmallestCurrencyUnit = amount,
				CurrencyCode = currency,
				LocalizedPriceDescription = price,
				MerchantId = merchantid, // provided by datatrans
				Refno = refno,
				LocalizedMerchantName = merchantname
				
			};
			
			var po = new DtPaymentOptions() {
				HideToolbarSecurityInfo = hideToolbar,
				ReturnsCreditCard = DtPaymentReturnsCreditCard.Never,
				ShowBackButtonOnFirstScreen = showBack,
				Testing = testing
			};
			
			var payementMethod = new List<string>();
			foreach(CheckboxElement e in method[0].Elements) {
				if (e.Value) {
					payementMethod.Add(e.Caption);
				}
			}
			
			
			cpc = new CinetoilePaymentContoller(nav);
			dtpc = DtPaymentController.FromDelegate(cpc, paymentRequest, payementMethod.ToArray());
			dtpc.PaymentOptions = po;
			dtpc.PresentIn(nav, true);	
		}
		
		
		void DtPayementControllerStatic() {
			
			
			var paymentRequest = new DtPaymentRequest() {
				AmountInSmallestCurrencyUnit = 100,
				CurrencyCode = @"CHF",
				LocalizedPriceDescription = @"CHF 1.-",
				MerchantId = @"1000011643", // provided by datatrans
				Refno = @"testld",
				LocalizedMerchantName = "11643"
				
			};
			
			var po = new DtPaymentOptions() {
				HideToolbarSecurityInfo = true,
				ReturnsCreditCard = DtPaymentReturnsCreditCard.Never,
				ShowBackButtonOnFirstScreen = false,
				Testing = true  // to be removed
			};
			
			var payementMethod = new [] { 
				DtPaymentMethod.Visa,
				DtPaymentMethod.MasterCard, 
				DtPaymentMethod.PostFinanceCard, 
				DtPaymentMethod.PostFinanceEFinance };
			
			
			cpc = new CinetoilePaymentContoller(nav);
			dtpc = DtPaymentController.FromDelegate(cpc, paymentRequest, payementMethod);
			dtpc.PaymentOptions = po;
			dtpc.PresentIn(nav, true);	
		}
	}
}

