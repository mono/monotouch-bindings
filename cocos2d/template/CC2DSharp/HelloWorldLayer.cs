using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Cocos2D;
using MonoTouch.GameKit;

namespace CC2DSharp
{
	public class HelloWorldLayer : CCLayer
	{
		public static CCScene Scene {
			get {
				var scene = new CCScene();
				var layer = new HelloWorldLayer();
				scene.Add(layer);
				return scene;
			}
		}

		public HelloWorldLayer ()
		{
			// create and initialize a Label
			var label = new CCLabelTTF ("Hello mtouch", "Marker Felt", 64);
			// ask director for the window size
			var size = CCDirector.SharedDirector.WinSize;

			// position the label on the center of the screen
			label.Position = new PointF(size.Width/2, size.Height/2);
			// add the label as a child to this Layer
			Add(label);

			//
			// Leaderboards and Achievements
			//
			
			// Default font size will be 28 points.
			CCMenuItemFont.DefaultFontSize = 28;
			
			// Achievement Menu Item
			var itemAchievement = new CCMenuItemFont("Achievements", (sender)=>{
				var achievementController = new GKAchievementViewController() {Delegate = new AchievementDelegate()};
				var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
				var navController = appDelegate.NavController;
				navController.PresentModalViewController(achievementController, true);
			});


			// Leaderboard Menu Item
			var itemLeaderBoard = new CCMenuItemFont ("Leaderboard", (sender) => {
				var leaderboardController = new GKLeaderboardViewController() {Delegate = new LeaderboardDelegate()};
				var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
				var navController = appDelegate.NavController;
				navController.PresentModalViewController(leaderboardController, true);
			});

			var menu = new CCMenu (new CCMenuItem [] {itemAchievement, itemLeaderBoard});
			menu.AlignItemsHorizontally(20);
			menu.Position = new PointF (size.Width/2, size.Height/2 - 50);
			// Add the menu to the layer
			Add (menu);
		}
	}

	public class AchievementDelegate : GKAchievementViewControllerDelegate
	{
		public override void DidFinish (GKAchievementViewController viewController)
		{
			var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
			var navController = appDelegate.NavController;
			navController.DismissModalViewControllerAnimated(true);
		}
	}

	public class LeaderboardDelegate : GKLeaderboardViewControllerDelegate
	{
		public override void DidFinish (GKLeaderboardViewController viewController)
		{
			var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
			var navController = appDelegate.NavController;
			navController.DismissModalViewControllerAnimated(true);
		}
	}
}

