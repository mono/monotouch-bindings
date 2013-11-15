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
using MonoTouch.Foundation;

namespace FlurryAppCircleSample
{
	public class AppCircleDelegate : FlurryAppCircle.FlurryAdDelegate
	{
		public static bool IsDataAvailable { get; private set; }
		
		public AppCircleDelegate()
			: base()
		{
		}
		
		public override void AppLaunched(string hook, NSDictionary cookies)
		{
			Console.WriteLine("AppCircle App Launched");
		}
		
		public static void CheckDataAvailability() 
		{	
			if(AppCircleDelegate.IsDataAvailable == false) {
				var alert = new UIAlertView("Data Unavailable", "Can't show Banner Ad", null, "OK", null);
				alert.Show();
			}
		}
		
		public override void DataAvailable()
		{
			IsDataAvailable = true;
			Console.WriteLine("Data is available..");
		}
		
		public override void DataUnavailable()
		{
			IsDataAvailable = false;
			Console.WriteLine("Data is NOT available");
		}
		
		public override void CanvasWillDisplay(string hook)
		{
			Console.WriteLine("Displaying Canvas: {0}", hook);
		}
		
		public override void CanvasWillClose()
		{
			Console.WriteLine("Closing Current Canvas");
		}
		
		public override void TakeoverWillDisplay(string hook)
		{
			Console.WriteLine("Displaying Takover: {0}", hook);
		}
		
		public override void TakeoverWillClose()
		{
			Console.WriteLine("Closing Current Takeover");
		}
		
		public override void VideoAvailable()
		{
			Console.WriteLine("Video is Available");
		}
		
		public override void VideoUnavailable()
		{
			Console.WriteLine("Video is NOT Available");
		}
		
		public override void VideoDidFinish(string hook, MonoTouch.Foundation.NSDictionary userCookies)
		{
			Console.WriteLine("Finished Video -- Hook: {0}", hook);
		}
		
		public override void VideoDidNotFinish(string hook)
		{
			Console.WriteLine("Unable to Complete Video -- Hook: {0}", hook);
		}
		
		public override void BannerExpanded(string hook)
		{
			Console.WriteLine("Banner Expanded: {0}", hook);
		}
		
		public override void BannerCollapsed(string hook)
		{
			Console.WriteLine("Banner Collapsed: {0}", hook);
		}
	}
}

