using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace TapkuSample
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
	}

	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		//TapkuSampleViewController viewController;
		
		DialogViewController dvc;
		RootElement root; 
		UINavigationController navigationController;
		
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			root = CreateRoot();
			dvc = new DialogViewController(UITableViewStyle.Grouped,root);
			navigationController = new UINavigationController(dvc);
			
			window.RootViewController = navigationController;
			
			window.MakeKeyAndVisible ();
			
			return true;
		}
		
		public RootElement CreateRoot()
		{
			return new RootElement("Tapku Library")
			{
				new Section("Views")
				{
					new StringElement("Coverflow",delegate{
						dvc.ActivateController(new CoverflowViewController());
					}),
					new StringElement("Graph",delegate {
						
					}),
					new StringElement("Month Grid Calendar",delegate {
						
					}),
				},
				new Section("UI Elements")
				{
					new StringElement("Empty Sign",delegate {
						
					}),
					new StringElement("Loading HUD", delegate {
						dvc.ActivateController( new HUDViewController());
					}),
					new StringElement("Alerts",delegate {
						
					}),
					new StringElement("Place Pins",delegate {
						
					}),
					
				},
				new Section("Table View Cells")
				{
					new StringElement("Label Cells",delegate {
						
					}),
					new StringElement("More Cells",delegate {
						
					}),
					new StringElement("Indicator Cells",delegate {
						
					}),
				},
				new Section("Network")
				{
					new StringElement("Image Center",delegate {
						
					})
				},
			};
		}
		
		public string DoExpensiveWork (string item)
		{	
			throw new NotImplementedException ();
		}
	}
}


