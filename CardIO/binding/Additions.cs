using System;

namespace Card.IO
{
	public partial class PaymentViewControllerDelegate : BasePaymentViewControllerDelegate
	{
		public delegate void ScanCompleted(PaymentViewController viewController, CreditCardInfo cardInfo);
		public event ScanCompleted OnScanCompleted;

		public override void UserDidCancel (PaymentViewController paymentViewController)
		{
			var evt = OnScanCompleted;
			if (evt != null)
				evt(paymentViewController, null);
		}

		public override void UserDidProvideCreditCardInfo (CreditCardInfo cardInfo, PaymentViewController paymentViewController)
		{
			var evt = OnScanCompleted;
			if (evt != null)
				evt(paymentViewController, cardInfo);
		}
	}
}

