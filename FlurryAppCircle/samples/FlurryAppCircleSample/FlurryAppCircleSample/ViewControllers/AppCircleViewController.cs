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
using MonoTouch.Dialog;
using MonoTouch.UIKit;

using AppCircle = FlurryAppCircle.FlurryAppCircle;
using Analytics = FlurryAnalytics.FlurryAnalytics;

namespace FlurryAppCircleSample
{
	public class AppCircleViewController : DialogViewController
	{
		public AppCircleViewController()
			: base(new RootElement("AppCircle"), true)
		{
		}
		
		public override void LoadView()
		{
			base.LoadView();
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			var bannerSection = new Section("") {
				new StringElement("Show Banner API", () => {
					BeginInvokeOnMainThread(()=>{
						this.NavigationController.PushViewController(new BannerViewController(), true);
					});
				})
			};
			
			var catalogSection = new Section("") {
				new StringElement("Show Catlaog API", () => {
					BeginInvokeOnMainThread(()=>{
						this.NavigationController.PushViewController(new FlurryCatalogViewController(), true);
					});
				})
			};
			
			var takeOverSection = new Section("") {
				new StringElement("Show TakeOver API", () => {
					BeginInvokeOnMainThread(()=>{
						this.NavigationController.PushViewController(new TakeOverViewController(), true);
					});
				})
			};
			this.Root.Add(new Section[] { bannerSection, catalogSection, takeOverSection });
			
			
			
			
		}
		
		
		
	}
}

