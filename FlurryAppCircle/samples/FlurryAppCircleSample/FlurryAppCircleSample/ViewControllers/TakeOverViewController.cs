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
using AppCircle = FlurryAppCircle.FlurryAppCircle;
using Analytics = FlurryAnalytics.FlurryAnalytics;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace FlurryAppCircleSample
{
	public class TakeOverViewController : DialogViewController
	{
		public TakeOverViewController()
			: base(new RootElement("Takeover API"), true)
		{
		}
		
		public override void LoadView()
		{
			base.LoadView();
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			AppCircle.OpenTakeover(AppCircleHooks.GLOBAL_APP_TAKEOVER, "portrait", new UIImage(), "[TakeOver Text Goes HERE]"
			                       , new NSDictionary());
			
		}
		
		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();
		}
	}
}

