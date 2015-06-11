
using System;
using System.Linq;
using System.Collections.Generic;

using MonoTouch.Dialog;

using Foundation;
using UIKit;

using Facebook.CoreKit;
using Facebook.LoginKit;
using CoreGraphics;

namespace FBExam
{
	public partial class ListDetailViewController : DialogViewController
	{

		public ListDetailViewController (string listId, string listName, FacebookListType type) : base (UITableViewStyle.Grouped, null, true)
		{
			Root = new RootElement (listName);

			// Ask for the members within the group
			var request = new GraphRequest ("/" + listId + "/members", null, AccessToken.CurrentAccessToken.TokenString, null, "GET");
			var requestConnection = new GraphRequestConnection ();
			requestConnection.AddRequest (request, (connection, result, error) => {
				// Handle if something went wrong
				if (error != null) {
					new UIAlertView ("Error...", error.Description, null, "Ok", null).Show ();
					return;
				}

				// Get the name and the userId of all the memebers
				NSArray membersData = (result as NSDictionary) ["data"] as NSArray;

				var listSection = new List<Section> ();

				// Add the name and the picture profile to the view
				for (nuint i = 0; i < membersData.Count; i++) {
					// Get the info of one of the members
					var memberData = membersData.GetItem <NSDictionary> (i);
					var pictureView = new ProfilePictureView (new CGRect (48, 0, 220, 220)) {
						ProfileId = memberData ["id"].ToString ()
					};
					listSection.Add (new Section (memberData ["name"].ToString ()) {
						new UIViewElement ("", pictureView, true) {
							Flags = UIViewElement.CellFlags.DisableSelection | UIViewElement.CellFlags.Transparent,
						}, 
					});
				}

				Root = new RootElement (listName) {
					listSection
				};
			});

			requestConnection.Start ();
		}
	}
}
