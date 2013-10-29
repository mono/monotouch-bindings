//
// This shows the various capabilities of the
// AtmHud library
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using MonoTouch.AtmHud;
using System.Drawing;

namespace sample
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		DialogViewController dvc;
		AtmHud hud;
		BooleanElement fixedSize;
		
		void ConfigureHud ()
		{
			// Configure the hud
			hud = new AtmHud ((AtmHudDelegate) null);
			hud.UserDidTapHud += delegate {
				hud.Hide ();
			};
			window.AddSubview (hud.View);
		}
		
		void HudShow ()
		{
			if (fixedSize.Value)
				hud.SetFixedSize (new SizeF (200, 100));
			else
				hud.SetFixedSize (new SizeF (0, 0));
			hud.Show ();
		}
		
		void UpdateHud ()
		{
			hud.SetCaption ("And now it will hide");
			hud.SetActivity (false);
			hud.SetImage (UIImage.FromFile ("19-check.png"));
			hud.Update ();
			hud.HideAfter (2);
		}
		
		void ShowPosition (AtmHudAccessoryPosition position)
		{
			hud.SetCaption (position.ToString ());
			hud.AccessoryPosition = position;
			switch (position){
			case AtmHudAccessoryPosition.Bottom:
				hud.SetProgress (0.45f);
				break;
			case AtmHudAccessoryPosition.Top:
				hud.SetActivity (true);
				break;
			case AtmHudAccessoryPosition.Left:
				hud.SetImage (UIImage.FromFile ("19-check.png"));
				break;
			case AtmHudAccessoryPosition.Right:
				hud.SetActivity (true);
				break;
			}
			HudShow ();
		}
		
		void SetupUI ()
		{
			var root = new RootElement ("AtmHud Demo"){
				new Section ("Basic Functions", "Tap to hide") {
					new StringElement ("Show with Caption only", delegate {
						hud.SetCaption ("Very simple caption");
						HudShow ();
					}),
					new StringElement ("Show with caption and activity", delegate {
						hud.SetCaption ("Caption and activity indicator");
						hud.SetActivity (true);
						HudShow ();
					}),
					new StringElement ("Show with caption and image", delegate {
						hud.SetCaption ("Caption and Image");
						hud.SetImage (UIImage.FromFile ("19-check.png"));
						HudShow ();
					}),
					new StringElement ("Show activity Only", delegate {
						hud.SetActivity (true);
						hud.SetActivityStyle (UIActivityIndicatorViewStyle.WhiteLarge);
						HudShow ();
					}),
					new StringElement ("Play sound on show", delegate {
						hud.SetCaption ("Showing the HUD triggers a sound");
						hud.ShowSound = "pop.wav";
						HudShow ();
					}),
				},
				new Section ("Advanced Functions", "Tap to hide is disabled") {
					new StringElement ("Show and auto-hide", delegate {
						hud.SetCaption ("This hud will auto-hide in 2 seconds");
						HudShow ();
						hud.HideAfter (2);
					}),
					new StringElement ("Show, update and auto-hide", delegate {
						hud.SetCaption ("This hud will update in 2 seconds");
						hud.SetActivity (true);
						HudShow ();
						NSTimer.CreateScheduledTimer (TimeSpan.FromSeconds (2), delegate {
							UpdateHud ();
						});
					}),
					new StringElement ("Show progressbar", delegate {
						hud.SetCaption ("Performing Operation");
						float progress = 0.08f;
						hud.SetProgress (progress);
						HudShow ();
						NSTimer timer = null;
						timer = NSTimer.CreateRepeatingScheduledTimer (TimeSpan.FromMilliseconds (200), delegate {
							Console.WriteLine ("Here {0}", progress);
							progress += 0.1f;
							hud.SetProgress (progress);
							if (progress >= 1){
								timer.Invalidate ();
								timer = null;
								hud.Hide ();
								hud.SetProgress (0);
							}
						});
					}),
					new StringElement ("Show queued HUD", delegate {
						hud.AddToQueue (new AtmHudQueueItem () {
							Caption = "Display 1",
							Image = null,
							AccessoryPosition = AtmHudAccessoryPosition.Bottom,
							ShowActivity = false,
						});
						hud.AddToQueue (new AtmHudQueueItem () {
							Caption = "Display 2",
							Image = null,
							AccessoryPosition = AtmHudAccessoryPosition.Right,
							ShowActivity = true,
						});
						hud.AddToQueue (new AtmHudQueueItem () {
							Caption = "Display 3",
							Image = UIImage.FromFile ("19-check.png"),
							AccessoryPosition = AtmHudAccessoryPosition.Bottom,
							ShowActivity = false,
						});
						hud.StartQueue ();
						NSTimer timer = null;
						int current = 0;
						timer = NSTimer.CreateRepeatingScheduledTimer (TimeSpan.FromSeconds (2), delegate {
							hud.ShowNextInQueue ();
							if (++current == 3){
								timer.Invalidate ();
								timer = null;
								hud.ClearQueue ();
							}
						});
					})
				},
				new Section ("Accessory Positioning"){
					new StringElement ("Top", delegate { ShowPosition (AtmHudAccessoryPosition.Top); }),
					new StringElement ("Bottom", delegate { ShowPosition (AtmHudAccessoryPosition.Bottom); }),
					new StringElement ("Left", delegate { ShowPosition (AtmHudAccessoryPosition.Left); }),
					new StringElement ("Right", delegate { ShowPosition (AtmHudAccessoryPosition.Right); }),
				},
				new Section () {
					(fixedSize = new BooleanElement ("Use fixed size", false)),
				}
			};
			dvc = new DialogViewController (root);
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.MakeKeyAndVisible ();
			window.RootViewController = dvc;
		}
		
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			SetupUI ();
			ConfigureHud ();
			return true;
		}
		
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}