using System;
using MonoTouch.UIKit;
using Datatrans;

namespace DatatransSample
{
	public class UserPaymentContoller : DTPaymentControllerDelegate
	{
		private readonly UINavigationController _rootNavigation;
		internal UINavigationController RootNavigation {
			get { return _rootNavigation; }
		}
		
		public UserPaymentContoller(UINavigationController nav ) {
			_rootNavigation = nav;
		}
		
		#region implemented abstract members of Datatrans.DtPaymentControllerDelegate

		public override void PaymentRequestDidSucceed (DTPaymentController controller, DTPaymentRequest request)
		{
			Console.WriteLine("DidSucceed:");
			RootNavigation.PopToRootViewController(true);
			
		}

		public override void DidFailWithError (DTPaymentController controller, MonoTouch.Foundation.NSError error)
		{
			Console.WriteLine("DidFail:");
			RootNavigation.PopToRootViewController(true);
		}

		#endregion

		public override void DidCancelWithType (DTPaymentController controller, DTPaymentCancellationType cancellationType)
		{
			RootNavigation.PopToRootViewController(true);
		}
		
		
		// public override bool ShouldAutorotate (DtPaymentController controller, MonoTouch.UIKit.UIInterfaceOrientation toInterfaceOrientation)
		// {
		// 	return toInterfaceOrientation == MonoTouch.UIKit.UIInterfaceOrientation.Portrait;
		// }
	}
}

