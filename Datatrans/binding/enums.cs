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

}
