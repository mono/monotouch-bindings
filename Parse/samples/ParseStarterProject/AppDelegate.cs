// 
//  Copyright 2011  Clancey
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
using MonoTouch.ObjCRuntime;
using ParseLib;
using MonoTouch.Dialog;

namespace ParseStarterProject
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.

	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		DialogViewController dvc;
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
			ParseLib.Parse.SetApplicationIdclientKey("appid","clientid");
			dvc = new DialogViewController(CreateRoot());
			window.RootViewController = new UINavigationController(dvc);
			window.MakeKeyAndVisible ();
			return true;
		}
		
		EntryElement nameElement;
		EntryElement scoreElement;
		RadioGroup dificultyGroup;
		RootElement CreateRoot()
		{
			nameElement = new EntryElement("Name","","");
			scoreElement = new EntryElement("Score","","");
			dificultyGroup = new RadioGroup(0);
			return new RootElement("Parse"){
				new Section("Add a score!"){
					nameElement,
					scoreElement,
					new RootElement ("Dificulty",dificultyGroup){
						new Section ("Dificulty"){
							new RadioElement ("Easy"),
							new RadioElement ("Medium"),
							new RadioElement ("Hard"),
						},
					},
				},
				new Section()
				{
					new StringElement("Submit Score",submitScore),
				},
				new Section()
				{
					new StringElement("View High Scores", viewHighScores),
				}
			};
		}
		void viewHighScores()
		{
			dvc.ActivateController(new HighScoreViewController());
		}
		void submitScore()
		{
			nameElement.FetchValue();
			scoreElement.FetchValue();
			var gameScore = new GameScore()
			{
				Player = nameElement.Value,
				Score = int.Parse(scoreElement.Value),
				Dificulty = (GameDificulty)dificultyGroup.Selected,
			};
			var pfobj = gameScore.ToPfObject();
			Console.WriteLine(pfobj);

			pfobj.SaveAsync((success,error)=>{
				UIAlertView alert = new UIAlertView(pfobj.ClassName,string.Format("Success: {0}",success),null,"Ok");
				alert.Show();
			});
		}
	}
}

