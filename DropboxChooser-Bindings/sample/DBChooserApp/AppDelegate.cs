using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using DropboxChooser;
using MonoTouch.Dialog;

namespace DBChooserApp
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UINavigationController navigation;
		RootElement root;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			root = new RootElement ("Dropbox Chooser Demo") { 
				new Section{
					new StringElement("Preview", delegate {
						ChooseFile(DBChooserLinkType.Preview);
				}),
					new StringElement("Direct Dowload", delegate {
						ChooseFile(DBChooserLinkType.Direct);
				})
				},

				//This section is used to show results metadata
				new Section("Metadata"),

				//This section used to show link and thumbnails
				new Section("Links and Thumbnails")

			};

			var dv = new DialogViewController (root);
			navigation = new UINavigationController ();
			navigation.PushViewController (dv, true);

			if (UIDevice.CurrentDevice.CheckSystemVersion (5, 0))
				window.RootViewController = navigation;
			else
				window.AddSubview (navigation.View);

			window.MakeKeyAndVisible ();
			
			return true;
		}

		void ChooseFile (DBChooserLinkType type)
		{
			DBChooser.DefaultChooser.OpenChooserForLinkType (type, navigation, DBChooserComplete);
		}

		void DBChooserComplete (DBChooserResult[] results)
		{
			if (results != null && results.Length > 0) {
				var result = results [0];

				var metadata = root [1];
				metadata.Clear ();

				var values = new Element[] { 
					new StringElement("Name",result.Name),
					new StringElement("Size in bytes: ",result.Size.ToString()),
					new ImageStringElement("Icon", UIImage.LoadFromData(NSData.FromUrl(result.IconURL)))
				};


				foreach (var item in values) {
					metadata.Add (item);
				}

				var linkSection = root [2];
				linkSection.Clear ();

				linkSection.Add (
					new StringElement (result.Link.ToString (), delegate {
					OpenLink (result.Link);
				}));

				foreach (var thumb in result.Thumbnails) {
					string key = thumb.Key.ToString ();
					string value = thumb.Value.ToString ();
					linkSection.Add (new StringElement (key, delegate {
						OpenLink (NSUrl.FromString (value));
					}));
				}

			} else {
				UIAlertView error = new UIAlertView ("Error", "No values", null, "OK", null);
				error.Show ();
			}
		}

		void OpenLink (NSUrl url)
		{
			UIApplication.SharedApplication.OpenUrl (url);
		}

		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			return DBChooser.DefaultChooser.HandleOpenURL (url);
		}
	}
}

