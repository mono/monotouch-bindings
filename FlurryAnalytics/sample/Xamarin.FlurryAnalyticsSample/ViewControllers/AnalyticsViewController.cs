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
using FA=FlurryAnalytics;
using MonoTouch.Foundation;

namespace Xamarin.FlurryAnalyticsSample
{
	public class AnalyticsViewController : DialogViewController
	{
		public AnalyticsViewController()
			: base(new RootElement(""))
		{
			this.Title = "FlurryAnalytics";
		}
		
		public override void LoadView()
		{
			base.LoadView();
			
			var errorElement = new StringElement("Throw & Log Exception", () => {
				
				try {
					
					throw new Exception("Thar be dragons!");
					
				} catch (Exception ex) {
					
					Console.WriteLine("Logging Error...Name: {0} -- Message: {1}", ex.GetType().Name, ex.Message);
					FA.Flurry.LogError(ex.GetType().Name, ex.Message,  
			                            new NSError(NSError.CocoaErrorDomain, 3584));
					
				}
			});
			
			var errorSection = new Section("Track Errors") {
				errorElement
			};
			
			var idElement = new EntryElement("Enter UserID: ", "", "");
			idElement.Changed += (sender, e) => {
				FA.Flurry.SetUserID(((EntryElement)sender).Value);
				};
			
			var ageElement = new EntryElement("Enter Age: ", "", "");
			ageElement.Changed += (sender, e) => {
				int age;
				var element = (EntryElement)sender;
				
				if(int.TryParse(element.Value, out age)) {
					FA.Flurry.SetAge(age);
				}
			};
			
			var genderElement = new EntryElement("Enter Gender: ", "", "");
			genderElement.Changed += (sender, e) => {
				var element = (EntryElement)sender;
				
				if(string.IsNullOrWhiteSpace(element.Value)) {
					return;
				}
				
				if(element.Value.ToLowerInvariant() == "m") {
					FA.Flurry.SetGender("m");
				}
				else if(element.Value.ToLowerInvariant() == "f") {
					FA.Flurry.SetGender("f");
				}
			};
			
			var demoSection = new Section("Track Demographics") {
				idElement,
				ageElement,	
				genderElement,
			};
			
			this.Root.Add(new Section[] { errorSection, demoSection });
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}
		
		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();
		}
		
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
		}
		
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
	}
}

