using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace AdJitsu
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}
	
	public partial class AppDelegate : UIApplicationDelegate
	{
		SampleAdjitsu sample;
		
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			sample = new SampleAdjitsu ();
			
			window.Add (sample.View);
			window.MakeKeyAndVisible ();
	
			return true;
		}
	
		public override void OnActivated (UIApplication application)
		{
		}
	}
}

