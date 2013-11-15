//
// This shows the various capabilities of the
// AtmHud library
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Dialog;
using GoogleAnalytics;
namespace sample
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		const string account = "youraccoutid";
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{			

			var result = GoogleAnalytics.GAI.SharedInstance;
			result.GetTracker(account);
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
						var success = GAI.SharedInstance.DefaultTracker.TrackEvent("Sample Data","Button Clicked","Xamarin!",1);
						//Console.WriteLine(error);
						ShowMessage(success ? "Success" : "Error","");
					}),
					new StringElement("Track Page",delegate{
						NSError error;
						var success = GoogleAnalytics.GAI.SharedInstance.DefaultTracker.TrackView("HomePage");
						ShowMessage(success ? "Success" : "Error","");
					}),
					new StringElement("Set Custom Variable",delegate{
						NSError error;
						var success = GoogleAnalytics.GAI.SharedInstance.DefaultTracker.Setvalue("Version",UIDevice.CurrentDevice.SystemVersion);
						ShowMessage(success ? "Success" : "Error","");
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