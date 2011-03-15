
using System;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CorePlot;
using MonoTouch.Dialog;
using System.Drawing;

namespace iOSsample
{
	public class Application
	{
		static void Main (string[] args)
		{
			var j = NSNumber.FromDouble (1);
			var dec = j.NSDecimalValue;
			Console.WriteLine (dec);
			
			try {
				UIApplication.Main (args);
			} catch (Exception e){
				Console.WriteLine (e);
			}
		}
	}

	// The name AppDelegate is referenced in the MainWindow.xib file.
	public partial class AppDelegate : UIApplicationDelegate
	{
		UINavigationController navigation;
		
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window.MakeKeyAndVisible ();
			
			var root = new RootElement ("CorePlot Samples"){
				new Section () {
					new RootElement ("XYGraph", r => new ScatterPlot ())
				}
			};
					                 
			var dvc = new DialogViewController (root);
			navigation = new UINavigationController (dvc);
			window.Add (navigation.View);
			return true;
		}
	

		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}
	}
	

}
