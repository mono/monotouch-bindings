
using System;
using System.Linq;
using System.Collections.Generic;

using MonoTouch.Dialog;

using Foundation;
using UIKit;

using Facebook.CoreKit;

namespace FBExam
{
	public partial class ListViewController : DialogViewController
	{
		public ListViewController (FacebookListType type) : base (UITableViewStyle.Grouped, null, true)
		{
			var kindListName = type == FacebookListType.Friends ? "Friendlists" : "Groups";

			Root = new RootElement (kindListName);

			// Depends of what you want to see, list all your groups or all your friendslist that you have
			var request = new GraphRequest ("/" + Profile.CurrentProfile.UserID + "/" + kindListName, null, AccessToken.CurrentAccessToken.TokenString, null, "GET");
			var requestConnection = new GraphRequestConnection ();
			requestConnection.AddRequest (request, (connection, result, error) => {
				// Handle if something went wrong
				if (error != null) {
					new UIAlertView ("Error...", error.Description, null, "Ok", null).Show ();
					return;
				}

				// Get all the info of all the friends or group list that you belong
				NSArray listsData = (result as NSDictionary) ["data"] as NSArray;

				var listSection = new Section ();

				for (nuint i = 0; i < listsData.Count; i++) {
					var data = listsData.GetItem <NSDictionary> (i);
					listSection.Add (new StringElement (data ["name"].ToString (), () => {
						// Ask for all the FB user members that belong to the groups
						// For security reasons, FB doesn't let you see who is in your friendlist anymore
						if (type == FacebookListType.Groups)
							NavigationController.PushViewController (new ListDetailViewController (data ["id"].ToString (), data ["name"].ToString (), type), true);
					}));
				}

				Root.Add (listSection);
			});

			requestConnection.Start ();
		}
	}

	public enum FacebookListType
	{
		Friends,
		Groups
	}
}
