using System;

namespace Datatrans
{
	public enum DTPaymentErrorCode {
		Technical,
		Validation,
		Authentication,
		Authorization
	}

	public enum DTPaymentCancellationType {
		BackButton,
		CancelButton
	}

	public enum DTPaymentReturnsCreditCard {
		Never = 0,
		SelectableDefaultNo,
		SelectableDefaultYes
	}

	public enum DTPaymentCardHolder {
		Hidden = 0,
		Optional,
		Required
	}
}

