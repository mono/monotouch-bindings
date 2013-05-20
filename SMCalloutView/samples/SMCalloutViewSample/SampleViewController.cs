using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using System.Drawing;
using MonoTouch.MapKit;
using SMCalloutView;
using MonoTouch.CoreLocation;

namespace SMCalloutViewSample
{
	public class SampleViewController : UIViewController
	{
		UIScrollView scrollView;
		UIImageView marsView;
		MKPinAnnotationView topPin;
		CalloutView calloutView;


		public SampleViewController () : base ()
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.BackgroundColor = UIColor.White;

			scrollView = new UIScrollView (View.Bounds) {
				BackgroundColor = UIColor.Gray
			};

			// Setup mats view
			marsView = new UIImageView (UIImage.FromBundle ("mars.jpg")){
				UserInteractionEnabled = true,
			};
			marsView.AddGestureRecognizer (new UITapGestureRecognizer (()=> {
				// We'll introduce an artifical delay to feel more like MKMapView for this demonstration.
				NSTimer.CreateScheduledTimer (new TimeSpan (0, 0, 0, 0, 333), ()=> InvokeOnMainThread (()=> calloutView.DismissCallout (true)));
			}));
			scrollView.AddSubview (marsView);
			scrollView.ContentSize = marsView.Frame.Size;
			scrollView.ContentOffset = new PointF (150, 50);

			//Setup top Pin
			topPin = new MKPinAnnotationView (null, "") {
				Center = new PointF (View.Frame.Width/2 + 230, View.Frame.Height/2)
			};
			topPin.AddGestureRecognizer (new UITapGestureRecognizer (()=> {
				// now in this example we're going to introduce an artificial delay in order to make our popup feel identical to MKMapView.
				// MKMapView has a delay after tapping so that it can intercept a double-tap for zooming. We don't need that delay but we'll
				// add it just so things feel the same.
				NSTimer.CreateScheduledTimer (new TimeSpan (0, 0, 0, 0, 333), () => {
					InvokeOnMainThread (()=> {
						calloutView.ContentView = null; // clear any custom view that was set by another pin
						calloutView.BackgroundView = CalloutBackgroundView.SystemBackgroundView; // use the system graphics

						// This does all the magic. It present the CalloutView
						calloutView.PresentCallout (topPin.Frame, marsView, scrollView, CalloutArrowDirection.Any, true);

						// Here's an alternate method that adds the callout *inside* the pin view. This may seem strange, but it's how MKMapView
						// does it. It brings the selected pin to the front, then pops up the callout inside the pin's view. This way, the callout
						// is "anchored" to the pin itself. Visually, there's no difference; the callout still looks like it's floating outside the pin.

						// calloutView.PresentCallout (topPin.Bounds, topPin, scrollView, CalloutArrowDirection.Down, true);

					});
				});
			}));
			marsView.AddSubview (topPin);

			// Setup disclosure button
			var topDisclosure = UIButton.FromType (UIButtonType.DetailDisclosure);
			topDisclosure.AddGestureRecognizer (new UITapGestureRecognizer (()=> {
				InvokeOnMainThread (()=> new UIAlertView ("Tap!", "You tapped the disclosure button.", null, "Ok", null).Show ());
			}));

			// Now lets stup our calloutView
			calloutView = new CalloutView () {
				Title = "Curiosity",
				Subtitle = "Mars Rover",
				RightAccessoryView = topDisclosure,
				CalloutOffset = topPin.CalloutOffset
			};

			View.AddSubview (scrollView);
		}
	}
}

