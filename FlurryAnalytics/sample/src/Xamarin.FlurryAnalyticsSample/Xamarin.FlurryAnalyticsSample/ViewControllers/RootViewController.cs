// 
//  Copyright 2012  abhatia
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
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonoTouch.Foundation;
using FA=FlurryAnalytics;


namespace Xamarin.FlurryAnalyticsSample
{
	public class RootViewController : UINavigationController
	{
		AnalyticsViewController _AnalyticsController;
		
		public RootViewController()
			: base()
		{
		}
		
		public override void LoadView()
		{
			base.LoadView();
			FA.FlurryAnalytics.LogAllPageViews(this);
			_AnalyticsController = new AnalyticsViewController();	
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.PushViewController(_AnalyticsController, true);
		}
		
		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();
		}
		
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			
			
			if(LocationManager.IsInitialized == false) {
				LocationManager.Initialize();
			}
			
			LocationManager.LocationUpdated = (location) => {
				
				FA.FlurryAnalytics.SetLocation(location.NewLocation.Coordinate.Latitude, location.NewLocation.Coordinate.Longitude,
				                              (float)location.NewLocation.HorizontalAccuracy, (float)location.NewLocation.VerticalAccuracy);
				
			};
		}
		
		public override void PushViewController(UIViewController viewController, bool animated)
		{
			FA.FlurryAnalytics.LogEvent(string.Format("Pushed ViewController with Name: {0}", viewController.GetType().Name));
			base.PushViewController(viewController, animated);
		}
		
	}
}

