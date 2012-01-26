/*
 * enums.cs: Core definitions
 *
 * Author:
 *   Miguel de Icaza (miguel@xamarin.com)
 *
 * Copyright 2011 Xamarin, Inc.
 */

namespace MonoTouch.PayPal {

	public enum PayPalPaymentStatus {
		Completed,
		Created,
		Other,
	}
	
	public enum PayPalEnvironment {
		Live,
		Sandbox,
		None,
	}
	
	public enum PayPalButtonType {
		Size152x33,
		Size194x37,
		Size278x43,
		Size294x43,
	}
	
	public enum PayPalButtonText {
		Pay, Donate
	}
	
	public enum PayPalFeePayer {
		Sender,
		PrimaryReceiver,
		EachReceiver,
		SecondaryOnly,
	}
	
	public enum PayPalFailureType {
		SystemError,
		RecipientError,
		ApplicationError,
		ConsumerError,
	}
	
	public enum PayPalPaymentType {
		NotSet = -1,
		Goods,
		Service,
		Personal,
	}
	
	public enum PayPalPaymentSubType {
		NotSet = -1,
		AffiliatePayments,
		B2b,
		Payroll,
		Rebates,
		Refunds,
		Reimbursements,
		Donations,
		Utilities,
		Tuition,
		Government,
		Insurance,
		Remittances,
		Rent,
		Mortgage,
		Medical,
		ChildCare,
		EventPlanning,
		GeneralContractors,
		Entertainment,
		Tourism,
		Invoice,
		Transfer,
	}
	
	public enum PayPalAmountErrorCode {
		None,
		Server,
		Other,
	}
	
	public enum PayPalInitializationStatus {
		Not_Started,
		CompletedSuccess,
		CompletedError,
		Inprogress,
	}

	public enum PayPalDayOfWeek {
		NoneSpecified = -1,
		Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
	}

	public enum PayPalPaymentPeriod {
		NoneSpecified = -1,
			Daily, Weekly, BiWeekly, SemiMonthly, Monthly, Annually
	}
}
