using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.StoreKit;
using BeeblexSDK;

namespace BeeblexDemo
{
	public partial class BeeblexDemoViewController : UIViewController
	{
		public BeeblexDemoViewController () : base ("BeeblexDemoViewController", null)
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

		partial void ShowApiKey (MonoTouch.UIKit.UIButton sender)
		{
			// You can make sure BBXBeeblex has your API Key
			// by checking it's ApiKey Property

			UIAlertView alert;
			BBXBeeblex beeblex = BBXBeeblex.SharedInstance;

			if (beeblex.ApiKey != null) 
			{
				alert = new UIAlertView("Here is it:", beeblex.ApiKey, null, "Ok, Thanks!", null);
				alert.Show();
			}
			else 
			{
				alert = new UIAlertView("Failure", "Did you provide your API Key to BBXBeeblex?", null, "Ok", null);
				alert.Show();
			}
		}

		partial void ShowIfReachable (MonoTouch.UIKit.UIButton sender)
		{
			// You can validate if Beeblex Service is Available 
			// Using the Booblean Property BBXIAPTransaction.CanValidateTransactions
			// ie. This will return false is no Network is Availabe 

			UIAlertView alert;
			if (BBXIAPTransaction.CanValidateTransactions) 
			{
				alert = new UIAlertView("Success", "Beeblex Service is Available", null, "Ok, Thanks!", null);
				alert.Show();
			}
			else
			{
				alert = new UIAlertView("Failure", "Beeblex Service is Unavailable", null, "Aww, Okay!", null);
				alert.Show();
			}
		}

		partial void VerifyTransaction (NSObject sender)
		{
			// You MUST obtain the SKPaymentTransaction here
			// That you want to validate against Beeblex Service
			SKPaymentTransaction skTrans = new SKPaymentTransaction();
				
			// Initialize your BBXIAPTransaction with the SKPaymentTransaction you got
			// If you do not provide a Valid SKPaymentTransaction you will get a
			// MonoTouch.Foundation.MonoTouchException
			// Because you need a transaction that is either purchased or restored.
			BBXIAPTransaction bbxTransaction = new BBXIAPTransaction(skTrans);

			// Here the you validate the SKPaymentTransaction.
			bbxTransaction.Validate((error)=> 
			{
				if (bbxTransaction.TransactionVerified) {
					if (bbxTransaction.TransactionIsDuplicate) {
						
						// The transaction is valid, but duplicate - it has already been
						// sent to Beeblex in the past.
						// Do Something Here
						
					} else {
						
						// The transaction has been successfully validated
						// and is unique.
						// Do Something Here
					}
					
				} else {
					
					// Check whether this is a validation error, or if something
					// went wrong with Beeblex.
					// Do Something Here
					
					if (bbxTransaction.HasServerError) {
						
						// The error was not caused by a problem with the data, but is
						// most likely due to some transient networking issues.
						// Do Something Here
						
					} else {
						
						// The transaction supplied to the validation service was not valid according to Apple.		
						// Do Something Here
					}
					
				}
				
			});
		}
	}
}

