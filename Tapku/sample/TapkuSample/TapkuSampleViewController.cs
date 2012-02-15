using MonoTouch.UIKit;
using System.Drawing;
using System;
using MonoTouch.Foundation;
using Tapku;

namespace TapkuSample
{
	public partial class TapkuSampleViewController : UIViewController
	{
		public TapkuSampleViewController (string nibName, NSBundle bundle) : base (nibName, bundle)
		{
		}
		
		private TKLoadingView loading;
		private TKProgressBarView progressBar;
		private TKProgressAlertView alertView;
		private TKProgressCircleView progressCircle;
		
		public TKLoadingView Loading { 
			get {
				if(loading == null)
				{
					loading = new TKLoadingView("Loading...");
					loading.StartAnimating();
					loading.Center = new PointF(View.Bounds.Width / 2f, 160);
				}
				return loading;
			}
		}
		
		public TKProgressBarView ProgressBar { 
			get {
				if(progressBar == null)
				{
					progressBar = new TKProgressBarView(TKProgressBarViewStyle.Short);
					progressBar.Center = new PointF(View.Bounds.Width / 2f, 320);
					progressBar.Progress = 0.01f;
				}
				return progressBar;
			}
		}
		
		public TKProgressAlertView AlertView {
			get {
				if(alertView == null)
				{
					alertView = new TKProgressAlertView("Loading important stuff!");	
				}
				return alertView;
			}
		}
		
		public TKProgressCircleView ProgressCircle {
			get {
				if(progressCircle == null)
				{
					progressCircle = new TKProgressCircleView();	
				}
				return progressCircle;
			}
		}
		
		int time;
		NSTimer timer;
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void LoadView ()
		{
			base.LoadView ();
			
			View.BackgroundColor = UIColor.Gray;
			
			View.AddSubview(Loading);
			View.AddSubview(ProgressBar);
			View.AddSubview(ProgressCircle);
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			var button = UIButton.FromType(UIButtonType.RoundedRect);
			button.Frame = new RectangleF(20f, 40f, 280f, 40f);
			button.TouchUpInside += (sender, e) => {
				
				time = 0;
				
				ProgressCircle.TwirlMode = !ProgressCircle.TwirlMode;
				if(!ProgressCircle.TwirlMode)
				{	
					ProgressCircle.SetProgress(0f, false);	
					ProgressCircle.SetProgress(1f, true);
				}
			};
			View.AddSubview(button);
			
			time = 0;
			timer = NSTimer.CreateRepeatingScheduledTimer(0.02, () => {
				
				if(ProgressBar.Superview != null)
				{
					//Console.WriteLine ("Something something");
					ProgressBar.Progress = time / 100f;
					time++;
					if(time > 130) time = -30;
					return;
				}
				time++;
				AlertView.ProgressBar.Progress = time / 200f;
				if(time > 240)
				{
					View.AddSubview(ProgressBar);
					View.AddSubview(Loading);
					AlertView.Hide();
					time = 0;
				}
			});
			
			NSRunLoop.Current.AddTimer(timer, NSRunLoopMode.Default);
			
		}
		
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			
			ProgressCircle.SetProgress(1f, true);
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
