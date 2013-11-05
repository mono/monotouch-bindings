using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Drawing;
using System.Web;
using MonoTouch.CoreLocation;

using MonoTouch.FacebookConnect;

namespace FacebookiOSSample
{
	public partial class DVCActions : DialogViewController
	{
		IFBGraphUser user;
		FBProfilePictureView pictureView;
		bool IsHiPosted = false;
		string HelloId = null;

		public DVCActions (IFBGraphUser facebookUser) : base (UITableViewStyle.Grouped, null, true)
		{
			this.user = facebookUser;

			pictureView = new FBProfilePictureView () {
				ProfileID = user.GetId()
			};

			if (UIDevice.CurrentDevice.CheckSystemVersion (7,0)) {
				pictureView.Frame = new RectangleF (120, 0, 80, 80);
			}
			else {
				pictureView.Frame = new RectangleF (110, 0, 80, 80);
			}

			Root = new RootElement ("Menu") {
				new Section (){
					new UIViewElement ("", pictureView, true) {
						Flags = UIViewElement.CellFlags.DisableSelection | UIViewElement.CellFlags.Transparent,
					}
				},
				new Section () {
					new StringElement (user.GetName()) {
						Alignment = UITextAlignment.Center
					}
				},
				new Section ("Actions") {
					new StringElement ("Share Xamarin.com", ShareUrl) {
						Alignment = UITextAlignment.Center
					},
					new StringElement ("FQL Sample - Show 25 friends", FQLSample) {
						Alignment = UITextAlignment.Center
					},
					new StringElement ("Graph API Sample - Post \"Hello\"", GraphApiPost) {
						Alignment = UITextAlignment.Center
					},
					new StringElement ("Graph API Sample - Delete \"Hello\"", GraphApiDeletePost) {
						Alignment = UITextAlignment.Center
					},
					new StringElement ("Select Some Friends", FriendPicker) {
						Alignment = UITextAlignment.Center
					},
					new StringElement ("Select a Place", PlacePicker) {
						Alignment = UITextAlignment.Center
					}
				}
			};
		}

		void ShareUrl ()
		{
			// Here we must take into account several things like is Native Share Dialog
			// available, if not then is iOS6 integrated share dialog available.
			// So if we can't use native dialogs we can support either our own dialog or
			// Feed Dialog see (https://developers.facebook.com/docs/howtos/feed-dialog-using-ios-sdk/)
			var url = new NSUrl ("http://xamarin.com");
			bool nativeShareDialog = FBDialogs.CanPresentShareDialog (new FBShareDialogParams () { Link = url }); 
			bool ios6ShareDialog = FBDialogs.CanPresentOSIntegratedShareDialog (FBSession.ActiveSession);
			if (nativeShareDialog) {
				FBDialogs.PresentShareDialog (url, "Create iOS, Android, Mac\nand Windows apps in C#", (call, results, error) => {
					if (error != null) 
						InvokeOnMainThread (() => new UIAlertView ("Error", error.Description, null, "Ok", null).Show ());
					else if (results["completionGesture"] as NSString == "post")
						InvokeOnMainThread (() => new UIAlertView ("Success", "Posted on Facebook.\nPostId = " + (NSString)results["postId"], null, "Ok", null).Show ());
					else if (results["completionGesture"] as NSString == "cancel")
						InvokeOnMainThread (() => new UIAlertView ("Cancelled", "User Cancelled Sharing", null, "Ok", null).Show ());

				});
			} else if (ios6ShareDialog) {
				FBDialogs.PresentOSIntegratedShareDialogModally (this, "Create iOS, Android, Mac and Windows apps in C#", null, new [] { url }, (result, error) => {
					if (error != null) 
						InvokeOnMainThread (() => new UIAlertView ("Error", error.Description, null, "Ok", null).Show ());
					else if (result == FBOSIntegratedShareDialogResult.Cancelled) 
						InvokeOnMainThread (() => new UIAlertView ("Cancelled", "User cancelled", null, "Ok", null).Show ());
					else if (result == FBOSIntegratedShareDialogResult.Succeeded) 
						InvokeOnMainThread (() => new UIAlertView ("Success", "Successfully posted to Facebook", null, "Ok", null).Show ());
				});
			} else { 
				// If we can't use native dialogs we use Feed Dialog see (https://developers.facebook.com/docs/howtos/feed-dialog-using-ios-sdk/)
				var data = new NSMutableDictionary ();
				data.Add (new NSString ("name"), new NSString ("Xamarin"));
				data.Add (new NSString ("caption"), new NSString ("Xamarin - cross platform that works"));
				data.Add (new NSString ("description"), new NSString ("Create iOS, Android, Mac and Windows apps in C#"));
				data.Add (new NSString ("link"), new NSString (url.AbsoluteString));
				data.Add (new NSString ("picture"), new NSString ("http://xamarin.com/images/index/feature-cross-platform.png"));

				FBWebDialogs.PresentFeedDialogModally (null, data, (result, resultUrl, error) => {
					if (error != null)
						InvokeOnMainThread (() => new UIAlertView ("Error", error.Description, null, "Ok", null).Show ());
					else if (result == FBWebDialogResult.NotCompleted) 
						InvokeOnMainThread (() => new UIAlertView ("Error", "User canceled story publishing.", null, "Ok", null).Show ()); //User clicked the "x" icon
					else {
						// Handle the publish feed callback
						if (resultUrl.Query == null)
							InvokeOnMainThread (() => new UIAlertView ("Error", "User canceled story publishing.", null, "Ok", null).Show ());
						else {
							var qstrings = HttpUtility.ParseQueryString (resultUrl.Query);
							var postId = qstrings["post_id"];
							InvokeOnMainThread (() => new UIAlertView ("Success", "Posted story, Id:" + postId, null, "Ok", null).Show ());					
						}				
					}
				});
			}
		}

		void FQLSample ()
		{
			// Query to fetch the active user's friends, limit to 25.
			string query = "SELECT uid, name, pic_big FROM user WHERE uid IN " +
					"(SELECT uid2 FROM friend WHERE uid1 = me() LIMIT 25)";
			// Set up the query parameter
			var queryParam = NSDictionary.FromObjectAndKey (new NSString (query), new NSString ("q"));
			// Make the API request that uses FQL
			FBRequestConnection.StartWithGraphPath ("/fql", queryParam, "GET", (connection, result, error) => {
				if (error != null)
					InvokeOnMainThread (() => new UIAlertView ("Error", error.Description, null, "Ok", null).Show ());
				else
				{
					// Here we use an utility method to extract all FBGraphObjects that came from the result
					var users = FBGraphObject.FromResultObject (result);

					// We create a RootElement that will hold the list
					// of people that returned in the result
					var root = new RootElement ("25 Friends") { new Section ()};
			
					foreach (var usr in users) 
						root[0].Add (new HtmlElement (usr["name"] as NSString, new NSUrl (usr["pic_big"] as NSString)));

					// We create the Dialog View Controller that will display the results and push it.
					var friendsDialog = new DialogViewController (root, true);
					NavigationController.PushViewController (friendsDialog, true);
				}
			});
		}

		void GraphApiPost ()
		{
			if (IsHiPosted) {
				InvokeOnMainThread (() => new UIAlertView ("Error", "Hello already posted on your wall", null, "Ok", null).Show ());
				return;
			}

			var data = new NSMutableDictionary ();
			data.Add (new NSString ("message"), new NSString ("Hello!"));

			// Ask for publish_actions permissions in context
			if (!FBSession.ActiveSession.Permissions.Contains ("publish_actions")) {
				// No permissions found in session, ask for it
				FBSession.ActiveSession.RequestNewPublishPermissions (new [] { "publish_actions" }, FBSessionDefaultAudience.Friends, (session, error) => {
					if (error != null) 
						InvokeOnMainThread (() => new UIAlertView ("Error", error.Description, null, "Ok", null).Show ());
					else {
						// If permissions granted, publish the story
						FBRequestConnection.StartWithGraphPath ("me/feed", data, "POST", (connection, result, err) => {
							if (err != null)
								InvokeOnMainThread (() => new UIAlertView ("Error", string.Format ("Error:\nDomain: {0}\nCode: {1}\nDescription: {3}", err.Domain, (FBErrorCode)err.Code, err.Description), null, "Ok", null).Show ());
							else {
								HelloId = (result as FBGraphObject)["id"] as NSString;
								InvokeOnMainThread (() => new UIAlertView ("Success", "Posted Hello, MsgId: " + HelloId, null, "Ok", null).Show ());
								IsHiPosted = true;
							}
						});
					}
				});
			} else {
				// If permissions is found, publish the story
				FBRequestConnection.StartWithGraphPath ("me/feed", data, "POST", (connection, result, err) => {
					if (err != null)
						InvokeOnMainThread (() => new UIAlertView ("Error", string.Format ("Error:\nDomain: {0}\nCode: {1}\nDescription: {3}", err.Domain, (FBErrorCode)err.Code, err.Description), null, "Ok", null).Show ());
					else {
						HelloId = (result as FBGraphObject)["id"] as NSString;
						InvokeOnMainThread (() => new UIAlertView ("Success", "Posted Hello in your wall, MsgId: " + HelloId, null, "Ok", null).Show ());
						IsHiPosted = true;
					}
				});
			}
		}

		void GraphApiDeletePost ()
		{
			if (!IsHiPosted) {
				new UIAlertView ("Error", "Please Post \"Hello\" to your wall first", null, "Ok", null).Show();
				return;
			}

			FBRequestConnection.StartWithGraphPath (HelloId, null, "DELETE", (connection, result, err) => {
				if (err != null)
					InvokeOnMainThread (() => new UIAlertView ("Error", string.Format ("Error:\nDomain: {0}\nCode: {1}\nDescription: {2}", err.Domain, (FBErrorCode)err.Code, err.Description), null, "Ok", null).Show ());
				else {
					HelloId = null;
					InvokeOnMainThread (() => new UIAlertView ("Success", "Deleted Hello from your wall", null, "Ok", null).Show ());
					IsHiPosted = false;
				}
			});
		}

		// Using Native Friend Picker Controller
		void FriendPicker ()
		{
			var friendController = new FBFriendPickerViewController () {
				Title = "Pick some friends"
			};

			friendController.LoadData ();
			friendController.PresentModallyFromViewController (this, true, (sender, donePressed) => {
				if (!donePressed) 
					InvokeOnMainThread (() => new UIAlertView ("Error", "User canceled.", null, "Ok", null).Show ());
				else {
					var ctrl = sender as FBFriendPickerViewController;
					foreach (var friend in ctrl.Selection)
						Console.WriteLine (friend.GetName ());
					InvokeOnMainThread (() => new UIAlertView ("Success", "You Picked " + ctrl.Selection.Count () + " friend(s)", null, "Ok", null).Show ());
				}
			});
		}

		// Using native PlacePicker Controller
		void PlacePicker ()
		{
			var placeController = new FBPlacePickerViewController () {
				Title = "Pick a place",
				LocationCoordinate = new CLLocationCoordinate2D (37.453827, -122.182187), // Hard code current location to Menlo Park, CA
				RadiusInMeters = 1000, // Configure the additional search parameters
				ResultsLimit = 50,
				SearchText = "Coffee"
			};

			placeController.LoadData ();
			placeController.PresentModallyFromViewController (this, true, (sender, donePressed) => {
				if (!donePressed) 
					InvokeOnMainThread (() => new UIAlertView ("Error", "User canceled.", null, "Ok", null).Show ());
				else {
					var ctrl = sender as FBPlacePickerViewController;
					InvokeOnMainThread (() => new UIAlertView ("Success", "You Picked " + ctrl.Selection.GetName(), null, "Ok", null).Show ());
				}
			});
		}
	}
}
