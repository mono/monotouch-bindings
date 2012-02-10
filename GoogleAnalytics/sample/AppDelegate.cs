//
// This shows the various capabilities of the
// AtmHud library
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Dialog;

namespace sample
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		const string account = "youraccoutid";
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{			
			GoogleAnalytics.GANTracker.SharedTracker.StartTracker(account,60,null);
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.RootViewController = new DialogViewController(CreateRoot());
			window.MakeKeyAndVisible ();
						
			return true;
		}
		
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
		public RootElement CreateRoot()
		{
			return new RootElement("Google Analytics")
			{
				new Section()
				{
					new StringElement("Track Event",delegate{
						NSError error;
						var success = GoogleAnalytics.GANTracker.SharedTracker.TrackEvent("Sample Data","Button Clicked","Xamarin!",1,out error);
						Console.WriteLine(error);
						ShowMessage(success ? "Success" : "Error",error == null ? "" : error.ToString());
					}),
					new StringElement("Track Page",delegate{
						NSError error;
						var success = GoogleAnalytics.GANTracker.SharedTracker.TrackPageView("HomePage",out error);
						Console.WriteLine(error);
						ShowMessage(success ? "Success" : "Error",error == null ? "" : error.ToString());
					}),
					new StringElement("Set Custom Variable",delegate{
						NSError error;
						var success = GoogleAnalytics.GANTracker.SharedTracker.SetCustomVariable(0,"Version",UIDevice.CurrentDevice.SystemVersion,out error);
						Console.WriteLine(error);
						ShowMessage(success ? "Success" : "Error",error == null ? "" : error.ToString());
					}),
				}
			};
		}
		public void ShowMessage(string title,string message)
		{
			var alert = new UIAlertView(title,message,null,"OK");
			alert.Show();
		}
	}
}