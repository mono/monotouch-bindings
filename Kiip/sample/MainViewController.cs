// 
//  Copyright 2012  James Clancey, Xamarin Inc  (http://www.xamarin.com)
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Kiip;

namespace sample
{
	public partial class MainViewController : UIViewController
	{
		public MainViewController () : base ("MainViewController", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			toggleStatusBar.ValueChanged += toggleSwitchValueChanged;
		}

		void toggleSwitchValueChanged (object sender, EventArgs e)
		{
			Console.WriteLine("ChangeD");
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		partial void saveLeaderboard ()
		{
			throw new System.NotImplementedException ();
		}
		partial void setLocation ()
		{
			throw new System.NotImplementedException ();
		}
		partial void showFullscreen ()
		{
			throw new System.NotImplementedException ();
		}
		partial void showNotification ()
		{
			throw new System.NotImplementedException ();
		}

		partial void unlockAchievement ()
		{
			throw new System.NotImplementedException ();
		}
		partial void getActivePromos ()
		{
			KPManager.SharedManager.GetActivePromos();
		}

	}
}

