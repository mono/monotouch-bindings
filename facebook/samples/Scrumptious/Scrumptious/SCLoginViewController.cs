
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Scrumptious
{
	public partial class SCLoginViewController : UIViewController
	{
		AppDelegate appDelegate;

		public SCLoginViewController () : base ("SCLoginViewController", null)
		{
			appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
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
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;


			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		partial void PerformLogin (NSObject sender)
		{
			// FBSample logic
			// The user has initiated a login, so call the openSession method.
			this.Spinner.StartAnimating();
			appDelegate.OpenSession(true);
		}

		public void LoginFailed()
		{
			// FBSample logic
			// Our UI is quite simple, so all we need to do in the case of the user getting
			// back to this screen without having been successfully authorized is to
			// stop showing our activity indicator. The user can initiate another login
			// attempt by clicking the Login button again.
			this.Spinner.StopAnimating();
		}
	}
}

