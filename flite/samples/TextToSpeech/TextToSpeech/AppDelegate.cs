// 
//  Copyright 2012  Xamarin Inc  (http://www.xamarin.com)
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
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace TextToSpeech
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		EntryElement entryElement;
		StringElement spearkBtn;
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			entryElement = new EntryElement("","Type the text to speak here.","");
			spearkBtn = new StringElement("Speak",delegate{
				entryElement.FetchValue();
				Flite.Flite.ConvertTextToWav(entryElement.Value,"test.wav",0);
			});
			window.RootViewController = new DialogViewController(new RootElement("") {
				new Section(){
					entryElement,
					spearkBtn
				}
			});
			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);
			
			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

