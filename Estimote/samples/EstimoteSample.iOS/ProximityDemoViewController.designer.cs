// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace EstimoteSample.iOS
{
	[Register ("ProximityDemoViewController")]
	partial class ProximityDemoViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel distanceLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (distanceLabel != null) {
				distanceLabel.Dispose ();
				distanceLabel = null;
			}
		}
	}
}
