using System;
using MonoTouch.UIKit;
using Datatrans;

namespace DatatransSample
{
	public class CinetoilePaymentContoller : DtPaymentControllerDelegate
	{
		private readonly UINavigationController _rootNavigation;
		internal UINavigationController RootNavigation {
			get { return _rootNavigation; }
		}
		
		public CinetoilePaymentContoller(UINavigationController nav ) {
			_rootNavigation = nav;
		}
		
		#region implemented abstract members of Datatrans.DtPaymentControllerDelegate
		public override void DidSucceed (DtPaymentController controller, DtPaymentRequest request)
		{
			Console.WriteLine("DidSucceed:");
		}

		public override void DidFail (DtPaymentController controller, MonoTouch.Foundation.NSError error)
		{
			Console.WriteLine("DidFail:");
		}

		#endregion
				
		public override void DidCancel (DtPaymentController controller, DtPaymentCancellationType cancellationType)
		{
			RootNavigation.PopViewControllerAnimated(true);
		}
		
		
		// public override bool ShouldAutorotate (DtPaymentController controller, MonoTouch.UIKit.UIInterfaceOrientation toInterfaceOrientation)
		// {
		// 	return toInterfaceOrientation == MonoTouch.UIKit.UIInterfaceOrientation.Portrait;
		// }
	}
}

