using MonoTouch.UIKit;
using System.Drawing;
using System;
using MonoTouch.Foundation;
using MonoTouch.TestFlight;

namespace TestFlightSample
{
	public partial class TestFlightSampleViewController : UIViewController
	{
		public TestFlightSampleViewController (string nibName, NSBundle bundle) : base (nibName, bundle)
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
		
			TestFlight.PassCheckpoint("Checkpoint 1");
			
			//any additional setup after loading the view, typically from a nib.
		}
		
		partial void leaveFeedback (MonoTouch.Foundation.NSObject sender)
		{
			TestFlight.OpenFeedbackView();
		}
		
		partial void passCheckpoint (MonoTouch.Foundation.NSObject sender)
		{
			TestFlight.PassCheckpoint("Checkpoint 2");
		}
		
		partial void crashApp (MonoTouch.Foundation.NSObject sender)
		{
			var emptyString = String.Empty;
			var breaks = emptyString.Substring(0, 20);
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Release any retained subviews of the main view.
			// e.g. myOutlet = null;
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}
