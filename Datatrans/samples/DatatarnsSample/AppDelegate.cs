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
		UserPaymentContoller cpc;
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
						new Section ("Payement request", "Contact Datatrans to get a valid iPhone MerchantId. 1000011011 from the doc will not work."){
							new EntryElement ("Amount", null, "6400"),
							new EntryElement ("CurrencyCode", null, "CHF"),
							new EntryElement ("PriceDescription", null, "CHF 64.-"),
							new EntryElement ("MerchantId", "Provided by Datatrans", "12345"),
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
									new RadioElement ("SelectableDefaultYes"),
									new RadioElement ("SelectableDefaultNo")
								}
							},
							new BooleanElement ("ShowBackButton", false),
							new BooleanElement ("Testing", true)
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
				MerchantId = merchantid, // The MerchantId is provided by datatrans 
				                         // 10000011011 from doc will not work
				                         // 1000011643 from doc will not work neither
				                         // contact Datatrans to have a working iPhone test account
				Refno = refno,
				LocalizedMerchantName = merchantname
				
			};
			
			var po = new DtPaymentOptions() {
				HideToolbarSecurityInfo = hideToolbar,
				ReturnsCreditCard = dprcc,
				ShowBackButtonOnFirstScreen = showBack,
				Testing = testing
			};
			
			var payementMethod = new List<string>();
			foreach(CheckboxElement e in method[0].Elements) {
				if (e.Value) {
					payementMethod.Add(e.Caption);
				}
			}
			var pma = payementMethod.ToArray();
			
			Debug(paymentRequest);
			Debug(po);
			Debug(pma);
			
			cpc = new UserPaymentContoller(nav);
			dtpc = DtPaymentController.FromDelegate(cpc, paymentRequest, pma);
			dtpc.PaymentOptions = po;
			dtpc.PresentIn(nav, true);	
		}
		
		void Debug(DtPaymentRequest pr) {
		
			
			Console.WriteLine();
			Console.WriteLine("DtPaymentRequest");
			Console.WriteLine("   AmountInSmallestCurrencyUnit: {0}", pr.AmountInSmallestCurrencyUnit);
			Console.WriteLine("   CurrencyCode: {0}", pr.CurrencyCode);
			Console.WriteLine("   LocalizedPriceDescription: {0}", pr.LocalizedPriceDescription);
			Console.WriteLine("   Refno: {0}", pr.Refno);
			Console.WriteLine("   LocalizedMerchantName: {0}", pr.LocalizedMerchantName);
			Console.WriteLine("   MerchantId: {0}", pr.MerchantId);
			Console.WriteLine();
			
		}
		
		
		void Debug(DtPaymentOptions po) {
		
			
			Console.WriteLine();
			Console.WriteLine("DtPaymentOptions");
			Console.WriteLine("   HideToolbarSecurityInfo: {0}", po.HideToolbarSecurityInfo);
			Console.WriteLine("   ReturnsCreditCard: {0}", po.ReturnsCreditCard);
			Console.WriteLine("   ShowAuthorizationConfirmationScreen: {0}", po.ShowAuthorizationConfirmationScreen);
			Console.WriteLine("   ShowBackButtonOnFirstScreen: {0}", po.ShowBackButtonOnFirstScreen);
			Console.WriteLine("   Testing: {0}", po.Testing);
			Console.WriteLine();
			
		}
		
		void Debug(string[] pm) {
		
			
			Console.WriteLine();
			Console.WriteLine("payementMethod");
			foreach(var p in pm) {
				Console.WriteLine("   {0}", p);
				
			}
			Console.WriteLine();
			
		}
		
		void DtPayementControllerStatic() {
			
			
			var paymentRequest = new DtPaymentRequest() {
				AmountInSmallestCurrencyUnit = 100,
				CurrencyCode = @"CHF",
				LocalizedPriceDescription = @"CHF 1.-",
				MerchantId = @"12345",   // The MerchantId is provided by datatrans 
				                         // 10000011011 from doc will not work
				                         // 1000011643 from doc will not work neither
				                         // contact Datatrans to have a working iPhone test account
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
			
			
			cpc = new UserPaymentContoller(nav);
			dtpc = DtPaymentController.FromDelegate(cpc, paymentRequest, payementMethod);
			dtpc.PaymentOptions = po;
			dtpc.PresentIn(nav, true);	
		}
	}
}

