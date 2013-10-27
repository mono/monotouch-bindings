using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using DropboxChooser;

namespace DBChooserApp
{
	public partial class DBChooserAppViewController : UIViewController
	{
		public DBChooserAppViewController () : base ("DBChooserAppViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		partial void ChooseFile (NSObject sender)
		{
			//var chooser = DBChooser.DefaultChooser;
			DBChooser.DefaultChooser.OpenChooserForLinkType (DBChooserLinkType.Direct, this, DBChooserComplete);
		}

		void DBChooserComplete (DBChooserResult[] results)
		{
			if (results != null && results.Length > 0) {
				var result = results [0];
				Console.WriteLine ("\n Link: {0} \n Name: {1} \n Icon: {2}", result.Link, result.Name, result.IconURL);
			} else {
				UIAlertView error = new UIAlertView ("Error", "No values", null, "OK", null);
				error.Show ();
			}
		}
	}
}

