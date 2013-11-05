/*
 * paypal.cs: API definitions
 *
 * Author:
 *   Miguel de Icaza (miguel@xamarin.com)
 *
 * Copyright 2011 Xamarin, Inc.
 */

using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace MonoTouch.PayPal {

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface PayPalPaymentDelegate {
		[Abstract]
		[Export ("paymentSuccessWithKey:andStatus:")]
		void PaymentSuccess (string payKey, PayPalPaymentStatus paymentStatus);

		[Abstract]
		[Export ("paymentFailedWithCorrelationID:")]
		void PaymentFailed (string correlationID);

		[Abstract]
		[Export ("paymentCanceled")]
		void PaymentCanceled ();

		[Abstract]
		[Export ("paymentLibraryExit")]
		void PaymentLibraryExit ();
		
		[Export ("adjustAmountsForAddress:andCurrency:andAmount:andTax:andShipping:andErrorCode:")]
		PayPalAmounts AdjustAmounts (PayPalAddress address, string currency, NSDecimalNumber amount, NSDecimalNumber tax, NSDecimalNumber shipping, out int payPalAmountErrorCode);

		[Export ("adjustAmountsAdvancedForAddress:andCurrency:andReceiverAmounts:andErrorCode:")]
		PayPalReceiverAmounts [] AdjustAmountsAdvanced (PayPalAddress Address, string currency, PayPalReceiverAmounts [] receiverAmounts, out int PayPalAmountErrorCode);
	}

	[BaseType (typeof (NSObject))]
	interface PayPal {
		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set;  }

		[Wrap ("WeakDelegate")]
		PayPalPaymentDelegate Delegate { get; set; }

		[Export ("paymentsEnabled")]
		bool PaymentsEnabled { get;  }

		[Export ("shippingEnabled")]
		bool ShippingEnabled { get; set;  }

		[Export ("dynamicAmountUpdateEnabled")]
		bool DynamicAmountUpdateEnabled { get; set;  }

		[Export ("appID")]
		string AppID { get;  }

		[Export ("lang")]
		string Language { get; set;  }

		[Export ("environment")]
		PayPalEnvironment Environment { get;  }

		[Export ("buttonText")]
		PayPalButtonText ButtonText { get;  }

		[Export ("feePayer")]
		PayPalFeePayer FeePayer { get; set;  }

		[Export ("payment")]
		PayPalAdvancedPayment Payment { get;  }

		[Export ("preapprovalDetails")]
		PayPalPreapprovalDetails PreapprovalDetails { get;  }

		[Export ("payButtons")]
		UIButton []PayButtons { get; set;  }
		

		[Export ("responseMessage")]
		NSMutableDictionary ResponseMessage { get; set;  }

		[Static]
		[Export ("getInstance")]
		PayPal SharedInstance { get; }

		[Static]
		[Export ("initializeWithAppID:")]
		PayPal Create (string appID);

		[Static]
		[Export ("initializeWithAppID:forEnvironment:")]
		PayPal Create (string inAppID, PayPalEnvironment env);

		[Static]
		[Export ("initializationStatus")]
		PayPalInitializationStatus InitializationStatus { get; }

		[Static]
		[Export ("buildVersion")]
		string BuildVersion { get; }

		[Export ("getPayButtonWithTarget:andAction:andButtonType:andButtonText:"), Internal]
		UIButton GetPayButton (PayPalPaymentDelegate target, Selector action, PayPalButtonType theButtonType, PayPalButtonText theButtonText);

		[Export ("getPayButtonWithTarget:andAction:andButtonType:"), Internal]
		UIButton GetPayButton (PayPalPaymentDelegate target, Selector action, PayPalButtonType theButtonType);

		[Export ("checkoutWithPayment:")]
		void Checkout (PayPalPayment payment);

		[Export ("advancedCheckoutWithPayment:")]
		void AdvancedCheckout (PayPalAdvancedPayment payment);

		[Export ("preapprovalWithKey:andMerchantName:")]
		void Preapproval (string preapprovalKey, string merchantName);
	}

	[BaseType (typeof (NSObject))]
	interface PayPalReceiverPaymentDetails {
		[Export ("recipient")]
		string Recipient { get; set;  }

		[Export ("subTotal")]
		double SubTotal { get; set;  }

		[Export ("isPrimary")]
		bool IsPrimary { get; set;  }

		[Export ("paymentType")]
		PayPalPaymentType PaymentType { get; set;  }

		[Export ("paymentSubType")]
		PayPalPaymentSubType PaymentSubType { get; set;  }

		[Export ("invoiceData")]
		PayPalInvoiceData InvoiceData { get; set;  }

		[Export ("description")]
		string Description { get; set;  }

		[Export ("customId")]
		string CustomId { get; set;  }

		[Export ("merchantName")]
		string MerchantName { get; set;  }

		[Export ("total")]
		double Total { get;  }
	}

	[BaseType (typeof (NSObject))]
	interface PayPalAddress {
		[Export ("name")]
		string Name { get;  }
		
		[Export ("street1")]
		string Street1 { get;  }

		[Export ("street2")]
		string Street2 { get;  }

		[Export ("city")]
		string City { get;  }

		[Export ("state")]
		string State { get;  }

		[Export ("postalcode")]
		string PostalCode { get;  }

		[Export ("countrycode")]
		string CountryCode { get;  }
	}

	[BaseType (typeof (NSObject))]
	interface PayPalPayment {
		[Export ("paymentCurrency")]
		string PaymentCurrency { get; set;  }

		[Export ("subTotal")]
		double SubTotal { get; set;  }

		[Export ("recipient")]
		string Recipient { get; set;  }

		[Export ("paymentType")]
		PayPalPaymentType PaymentType { get; set;  }

		[Export ("paymentSubType")]
		PayPalPaymentSubType PaymentSubType { get; set;  }

		[Export ("invoiceData")]
		PayPalInvoiceData InvoiceData { get; set;  }

		[Export ("description")]
		string Description { get; set;  }

		[Export ("customId")]
		string CustomId { get; set;  }

		[Export ("merchantName")]
		string MerchantName { get; set;  }

		[Export ("ipnUrl")]
		string IpnUrl { get; set;  }

		[Export ("memo")]
		string Memo { get; set;  }

	}
	[BaseType (typeof (NSObject))]
	interface PayPalAdvancedPayment {
		[Export ("paymentCurrency")]
		string PaymentCurrency { get; set;  }

		[Export ("receiverPaymentDetails")]
		PayPalReceiverPaymentDetails [] ReceiverPaymentDetails { get; set;  }

		[Export ("merchantName")]
		string MerchantName { get; set;  }

		[Export ("ipnUrl")]
		string IpnUrl { get; set;  }

		[Export ("memo")]
		string Memo { get; set;  }

		[Export ("subtotal")]
		double Subtotal { get;  }

		[Export ("tax")]
		double Tax { get;  }

		[Export ("shipping")]
		double Shipping { get;  }

		[Export ("total")]
		double Total { get;  }

		[Export ("singleReceiver")]
		PayPalReceiverPaymentDetails SingleReceiver { get;  }

		[Export ("isPersonal")]
		bool IsPersonal { get;  }
	}

	[BaseType (typeof (NSObject))]
	interface PayPalAmounts {
		[Export ("currency")]
		string Currency { get; set;  }

		[Export ("payment_amount")]
		double PaymentAmount { get; set;  }

		[Export ("tax")]
		double Tax { get; set;  }

		[Export ("shipping")]
		double Shipping { get; set;  }
	}

	[BaseType (typeof (NSObject))]
	interface PayPalContext {
		[Export ("sessionToken")]
		string SessionToken { get; set;  }

		[Export ("amount")]
		string Amount { get; set;  }

		[Export ("tax")]
		string Tax { get; set;  }

		[Export ("shipping")]
		string Shipping { get; set;  }

		[Export ("currencyCode")]
		string CurrencyCode { get; set;  }

		[Export ("itemDesc")]
		string ItemDesc { get; set;  }

		[Export ("shippable")]
		bool Shippable { get; set;  }

		[Export ("recipientEmail")]
		string RecipientEmail { get; set;  }

		[Export ("merchantName")]
		string MerchantName { get; set;  }

		[Export ("environment")]
		PayPalEnvironment Environment { get; set;  }

		[Export ("recipientPaysFee")]
		bool RecipientPaysFee { get; set;  }

		[Export ("enableDynamicAutoUpdate")]
		bool EnableDynamicAutoUpdate { get; set;  }

		[Export ("serialize")]
		NSDictionary Serialize ();

		[Export ("deserialize:")]
		bool Deserialize (NSDictionary contextData);
	}

	[BaseType (typeof (NSObject))]
	interface PayPalInvoiceData {
		[Export ("totalTax")]
		double TotalTax { get; set;  }

		[Export ("totalShipping")]
		double TotalShipping { get; set;  }

		[Export ("invoiceItems")]
		PayPalInvoiceItem [] InvoiceItems { get; set;  }
	}

	[BaseType (typeof (NSObject))]
	interface PayPalInvoiceItem {
		[Export ("name")]
		string Name { get; set;  }

		[Export ("itemId")]
		string ItemId { get; set;  }

		[Export ("totalPrice")]
		NSDecimalNumber TotalPrice { get; set;  }

		[Export ("itemPrice")]
		NSDecimalNumber ItemPrice { get; set;  }

		[Export ("itemCount")]
		NSNumber ItemCount { get; set;  }
	}

	[BaseType (typeof (NSObject))]
	interface PayPalPreapprovalDetails {
		[Export ("merchantName")]
		string MerchantName { get; set;  }

		[Export ("maxNumPayments")]
		int MaxNumPayments { get; set;  }

		[Export ("maxPerPayment")]
		double MaxPerPayment { get; set;  }

		[Export ("currency")]
		string Currency { get; set;  }

		[Export ("maxTotalAmountOfAllPayments")]
		double MaxTotalAmountOfAllPayments { get; set;  }

		[Export ("startDate")]
		DateTime StartDate { get; set;  }

		[Export ("endDate")]
		DateTime EndDate { get; set;  }

		[Export ("approved")]
		bool Approved { get; set;  }

		[Export ("pinRequired")]
		bool PinRequired { get; set;  }

		[Export ("paymentPeriod")]
		PayPalPaymentPeriod PaymentPeriod { get; set;  }

		[Export ("dateOfMonth")]
		int DateOfMonth { get; set;  }

		[Export ("dayOfWeek")]
		PayPalDayOfWeek DayOfWeek { get; set;  }

		[Export ("maxNumPaymentsPerPeriod")]
		int MaxNumPaymentsPerPeriod { get; set;  }

		[Export ("ipnUrl")]
		string IpnUrl { get; set;  }

		[Export ("memo")]
		string Memo { get; set;  }

		[Export ("senderEmail")]
		string SenderEmail { get; set;  }
	}

	[BaseType (typeof (NSObject))]
	interface PayPalReceiverAmounts {
		[Export("amounts")]
		PayPalAmounts Amounts {get;set;}
		
		[Export ("recipient")]
		string Recipient { get; set;  }
	}
}
