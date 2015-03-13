using System;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

using CGRect = global::System.Drawing.RectangleF;
using CGSize = global::System.Drawing.SizeF;
using CGPoint = global::System.Drawing.PointF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

using AudioKit;

namespace AudioKitSample
{
	public partial class AudioKitSampleViewController : UIViewController
	{
		UIImageView imgBackground;
		UIButton btnSound;
		bool isPlaying = false;
		AKInstrument instrument;

		public AudioKitSampleViewController ()
		{
			View = new UIView (UIScreen.MainScreen.Bounds);
			View.BackgroundColor = UIColor.White;
			InitializeComponents ();
		}

		public AudioKitSampleViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public void InitializeComponents ()
		{
			
			imgBackground = new UIImageView (View.Frame) {
				Image = UIImage.FromFile ("AudioKitMan.png")
			};
			imgBackground.TranslatesAutoresizingMaskIntoConstraints = false;

			btnSound = new UIButton (UIButtonType.System) {
				BackgroundColor = UIColor.Blue
			};
			btnSound.SetTitle ("Play Sine Wave at 440Hz", UIControlState.Normal);
			btnSound.SetTitleColor (UIColor.White, UIControlState.Normal);
			btnSound.TranslatesAutoresizingMaskIntoConstraints = false;

			View.Add (imgBackground);
			View.Add (btnSound);

			SetConstraints ();

			btnSound.TouchUpInside += (sender, e) => {
				if (isPlaying) {
					instrument.Stop ();
					(sender as UIButton).SetTitle ("Play Sine Wave at 440Hz", UIControlState.Normal);
					isPlaying = false;
				} else {
					instrument.Play ();
					(sender as UIButton).SetTitle ("Stop", UIControlState.Normal);
					isPlaying = true;
				}
			};

			instrument = new AKInstrument ();
			var oscillator = new AKOscillator ();
			instrument.Connect (oscillator);
			instrument.Connect (AKAudioOutput.FromAudioSource (oscillator));
			AKOrchestra.AddInstrumentToOrchestra (instrument);
			AKOrchestra.Start ();
		}

		void SetConstraints ()
		{
			// Set btnSound height to 90
			btnSound.AddConstraints (NSLayoutConstraint.FromVisualFormat (
				"V:[btnSound(90)]",
				0,
				null,
				new NSDictionary ("btnSound", btnSound)
			));

			// Set btnSound's bottom to 20 px above from superview's bottom
			View.AddConstraints (NSLayoutConstraint.FromVisualFormat (
				"V:[btnSound]-20-|",
				0,
				null,
				new NSDictionary ("btnSound", btnSound)
			));

			// Set btnSound's left and right borders to 30 px from superview's borders
			View.AddConstraints (NSLayoutConstraint.FromVisualFormat (
				"H:|-30-[btnSound]-30-|",
				0,
				null,
				new NSDictionary ("btnSound", btnSound)
			));

			// Set 
			imgBackground.AddConstraints (NSLayoutConstraint.FromVisualFormat (
				"H:[imgBackground(width)]",
				0,
				new NSDictionary ("width", View.Frame.Size.Width),
				new NSDictionary ("imgBackground", imgBackground)
			));
			imgBackground.AddConstraints (NSLayoutConstraint.FromVisualFormat (
				"V:[imgBackground(width)]",
				0,
				new NSDictionary ("width", View.Frame.Size.Width),
				new NSDictionary ("imgBackground", imgBackground)
			));
			View.AddConstraints (NSLayoutConstraint.FromVisualFormat (
				"V:[imgBackground]-40-|",
				0,
				null,
				new NSDictionary ("imgBackground", imgBackground)
			));
			View.AddConstraint (NSLayoutConstraint.Create (
				imgBackground,
				NSLayoutAttribute.CenterX,
				NSLayoutRelation.Equal,
				View,
				NSLayoutAttribute.CenterX,
				1,
				0
			));
		}

		#endregion
	}
}

