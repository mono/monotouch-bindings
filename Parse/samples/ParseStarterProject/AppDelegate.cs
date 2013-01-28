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
using Parse;
using MonoTouch.Dialog;
using System.Text;

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
		//TODO: set your keys
		const string appid = "";
		const string clientid = "";
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
			if (string.IsNullOrEmpty (appid) || string.IsNullOrEmpty (clientid)) {
				StringBuilder sb = new StringBuilder ();
				sb.AppendLine ("A Parse API key is required");
				sb.AppendLine ("Please sign up for one at:");
				sb.AppendLine ("https://parse.com/apps/new");
				(new UIAlertView ("Error", sb.ToString (), null, "Ok")).Show ();
			} else
				ParseService.SetAppId (appid, clientid);
			dvc = new DialogViewController (CreateRoot ());
			window.RootViewController = new UINavigationController (dvc);
			window.MakeKeyAndVisible ();
			return true;
		}
		
		EntryElement nameElement;
		EntryElement scoreElement;
		RadioGroup difficultyGroup;
		
		RootElement CreateRoot ()
		{
			nameElement = new EntryElement ("Name", "", "");
			scoreElement = new EntryElement ("Score", "", "");
			difficultyGroup = new RadioGroup (0);
			return new RootElement ("Parse"){
				new Section("Add a score!"){
					nameElement,
					scoreElement,
					new RootElement ("Difficulty",difficultyGroup){
						new Section ("Difficulty"){
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

		void viewHighScores ()
		{
			dvc.ActivateController (new HighScoreViewController ());
		}

		void submitScore ()
		{
			try {
				nameElement.FetchValue ();
				scoreElement.FetchValue ();
				var gameScore = new GameScore ()
				{
					Player = nameElement.Value,
					Score = int.Parse(scoreElement.Value),
					Dificulty = (GameDificulty)difficultyGroup.Selected,
				};
				
				var pfobj = gameScore.ToPfObject ();
				Console.WriteLine (pfobj);

				pfobj.SaveAsync ((success,error) => {
					UIAlertView alert = new UIAlertView (pfobj.ClassName, string.Format ("Success: {0}", success), null, "Ok");
					alert.Show ();
				});
			} catch (Exception ex) {
				(new UIAlertView ("Error", "Please make sure all inputs are valid", null, "Ok")).Show ();
			}
		}
	}
}

