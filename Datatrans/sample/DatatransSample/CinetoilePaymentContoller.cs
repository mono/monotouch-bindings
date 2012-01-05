using System;
using Datatrans;

namespace DatatransSample
{
	public class CinetoilePaymentContoller : DtPaymentControllerDelegate
	{

		#region implemented abstract members of Datatrans.DtPaymentControllerDelegate
		public override void DidSucceed (DtPaymentController controller, DtPaymentRequest request)
		{
			Console.WriteLine("DidSucceed:");
		}

		public override void DidFail (DtPaymentController controller, MonoTouch.Foundation.NSError error)
		{
			Console.WriteLine("DidFail:");
		}

		public override void DidCancel (DtPaymentController controller, DtPaymentCancellationType cancellationType)
		{
			Console.WriteLine("cancelled:");
		}

		public override bool ShouldAutorotate (DtPaymentController controller, MonoTouch.UIKit.UIInterfaceOrientation toInterfaceOrientation)
		{
			return toInterfaceOrientation == MonoTouch.UIKit.UIInterfaceOrientation.Portrait;
		}
		#endregion
	}
}

