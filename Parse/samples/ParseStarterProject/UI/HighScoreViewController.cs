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
using MonoTouch.Dialog;
using ParseLib;
using MonoTouch.Foundation;
using System.Linq;

namespace ParseStarterProject
{
	public class HighScoreViewController : DialogViewController
	{
		public HighScoreViewController () : base(null,true)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			GetHighScores();
		}

		public void GetHighScores()
		{
			ParseQuery query = new ParseQuery("GameScore");
			query.Limit = 100;
			query.OrderByDescending("Score");
			query.FindObjectsAsync(FoundResults);
		}

		private void FoundResults(ParseObject[] array, NSError error)
		{
			var easySection = new Section("Easy");
			var mediumSection = new Section("Medium");
			var hardSection = new Section("Hard");

			var objects = array.Select(x=> x.ToObject<GameScore>()).OrderByDescending(x=> x.Score).ToList();

			foreach(var score in objects)
			{
				var element = new StringElement(score.Player,score.Score.ToString("#,###"));
				switch(score.Dificulty)
				{
				case GameDificulty.Easy:
					easySection.Add(element);
					break;
				case GameDificulty.Medium:
					mediumSection.Add(element);
					break;
				case GameDificulty.Hard:
					hardSection.Add (element);
					break;
				}
			}
			Root = new RootElement("High Scores")
			{
				easySection,
				mediumSection,
				hardSection,
			};
			
		}
	}
}

