
using System;
using System.Linq;
using System.Collections.Generic;

using MonoTouch.Dialog;

using Foundation;
using UIKit;
using CoreGraphics;

using Facebook.ShareKit;
using Facebook.CoreKit;

namespace FBExam
{
	public partial class PhotoViewController : DialogViewController
	{
		
		EntryElement txtMessage;
		string photoId;

		public PhotoViewController () : base (UITableViewStyle.Grouped, null, true)
		{
			// Add the image that will be publish
			var imageView = new UIImageView (new CGRect (0, 0, View.Frame.Width, 220)) {
				Image = UIImage.FromFile ("wolf.jpg")
			};

			// Add a textbox that where you will be able to add a comment to the photo
			txtMessage = new EntryElement ("", "Say something nice!", "");

			Root = new RootElement ("Post photo!") {
				new Section () {
					new UIViewElement ("", imageView, true) {
						Flags = UIViewElement.CellFlags.DisableSelection | UIViewElement.CellFlags.Transparent,
					},
					txtMessage
				}
			};

			// Create the request to post a photo into your wall
			NavigationItem.RightBarButtonItem = new UIBarButtonItem ("Post", UIBarButtonItemStyle.Plain, ((sender, e) => {

				// Disable the post button for prevent another untill the actual one finishes
				(sender as UIBarButtonItem).Enabled = false;

				// Add the photo and text that will be publish
				var parameters = new NSDictionary ("picture", UIImage.FromFile ("wolf.jpg").AsPNG (), "caption", txtMessage.Value);

				// Create the request
				var request = new GraphRequest ("/" + Profile.CurrentProfile.UserID + "/photos", parameters, AccessToken.CurrentAccessToken.TokenString, null, "POST");
				var requestConnection = new GraphRequestConnection ();
				requestConnection.AddRequest (request, (connection, result, error) => {

					// Enable the post button
					(sender as UIBarButtonItem).Enabled = true;

					// Handle if something went wrong
					if (error != null) {
						new UIAlertView ("Error...", error.Description, null, "Ok", null).Show ();
						return;
					}

					// Do your magic if the request was successful
					new UIAlertView ("Yay!!", "Your photo was published!", null, "Ok", null).Show ();

					photoId = (result as NSDictionary) ["post_id"].ToString ();

					// Add a button to allow to delete the photo posted
					Root.Add (new Section () {
						new StyledStringElement ("Delete Post", DeletePost) {
							Alignment = UITextAlignment.Center,
							TextColor = UIColor.Red
						}
					});
				});
				requestConnection.Start ();
			}));
		}

		// Delete the photo posted from your wall
		void DeletePost ()
		{
			// Create the request to delete the post
			var request = new GraphRequest ("/" + photoId, null, AccessToken.CurrentAccessToken.TokenString, null, "DELETE");
			var requestConnection = new GraphRequestConnection ();
			requestConnection.AddRequest (request, (connection, result, error) => {
				// Handle if something went wrong
				if (error != null) {
					new UIAlertView ("Error...", error.Description, null, "Ok", null).Show ();
					return;
				}

				// Do your magin is the request was successful
				new UIAlertView ("Post Deleted", "Success", null, "OK", null).Show ();
				NavigationController.PopViewController (true);
			});
			requestConnection.Start ();
		}
	}
}
