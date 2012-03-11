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
		static void Main (string[] args)
		{
			UIApplication.Main (args, null, "AppDelegate");
		}
	}

		[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		
		DialogViewController dvc;
		RootElement root; 
		UINavigationController navigationController;
		
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
					
					new StringElement("Coverflow", () => {
						dvc.PresentModalViewController(new CoverflowViewController(), true);
//						dvc.ActivateController(new CoverflowViewController());
					}),
					new StringElement("Month Grid Calendar", () => {
						dvc.ActivateController(new DemoCalendarMonth());
					}),
				},
				new Section("UI Elements")
				{
					new StringElement("Empty Sign", () => {
						dvc.ActivateController(new EmptyViewController());
					}),
					new StringElement("Loading HUD",  () => {
						dvc.ActivateController( new HUDViewController());
					}),
					new StringElement("Alerts", () => {
						dvc.ActivateController(new AlertsViewController());
						
					}),
					new StringElement("Place Pins", () => {
						dvc.ActivateController(new MapViewController());
					}),
				},
				new Section("Network") {
					new StringElement("Image Cache", () => {
						dvc.ActivateController(new ImageCenterViewController());
					}),
				},
			};
		}
		
		public string DoExpensiveWork (string item)
		{	
			throw new NotImplementedException ();
		}
	}
}


