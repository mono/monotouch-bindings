using System;

namespace Datatrans {

   public enum DtPaymentErrorCode {
		Technical,
		Validation,
		Authentication,
		Authorization
	}
	
	public enum DtPaymentCancellationType {
		BackButton,
		CancelButton
	}

	public enum DtPaymentReturnsCreditCard {
		Never,
		SelectableDefaultNo,
        SelectableDefaultYes
	}
	

	public class DtPaymentMethod {
	
		// values found with :
		// foreach(var p in NSArray.StringArrayFromHandle(payementMethod.Handle))
		//		Console.WriteLine(p);	
	
		// extern NSString* const DTPaymentMethodVisa;
		public const string Visa = "VIS";
		
		// extern NSString* const DTPaymentMethodMasterCard;
		public const string MasterCard = "ECA";
		
		// extern NSString* const DTPaymentMethodDinersClub;
		public const string DinersClub = "DIN";
		
		// extern NSString* const DTPaymentMethodAmericanExpress;
		public const string AmericanExpress = "AMX";
		
		// extern NSString* const DTPaymentMethodPostFinanceCard;
		public const string PostFinanceCard = "PFC";
		
		// extern NSString* const DTPaymentMethodPostFinanceEFinance;
		public const string PostFinanceEFinance = "PEF";
		
		// extern NSString* const DTPaymentMethodPayPal;
		public const string PayPal = "PAP";
	
	}
	
}
