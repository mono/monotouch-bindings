// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace CouchbaseSample
{
	[Register ("ConfigViewController")]
	partial class ConfigViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField UrlField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel VersionField { get; set; }

		[Action ("learnMore:")]
		partial void LearnMore (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (UrlField != null) {
				UrlField.Dispose ();
				UrlField = null;
			}

			if (VersionField != null) {
				VersionField.Dispose ();
				VersionField = null;
			}
		}
	}
}
