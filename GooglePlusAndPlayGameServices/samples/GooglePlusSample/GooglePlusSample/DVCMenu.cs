using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

using Google.Plus;
using Google.OpenSource;

namespace GooglePlusSample
{
	public partial class DVCMenu : DialogViewController
	{
		ServicePlus plusService;
		//QueryPlus query;

		public DVCMenu () : base (UITableViewStyle.Grouped, null)
		{
			Root = new RootElement ("Google+ Sample") {
				new Section () {
					new StyledStringElement ("Email", SignIn.SharedInstance.UserEmail, UITableViewCellStyle.Subtitle)
				},
				new Section () {
					new StringElement ("Get User Information", GetUserInfo) {
						Alignment = UITextAlignment.Center
					},
					new StringElement ("Share Xamarin.com", HandleShareUrl) {
						Alignment = UITextAlignment.Center
					},
					new StringElement ("Share your love for XamarinStudio", HandleShareXS) {
						Alignment = UITextAlignment.Center
					},
					new StringElement ("List people in your circles", GetUserPeople) {
						Alignment = UITextAlignment.Center
					}
				},
				new Section () {
					new StringElement ("Logout", ()=> {
						SignIn.SharedInstance.SignOut ();
						NavigationController.PopViewControllerAnimated (true);
					}) {
						Alignment = UITextAlignment.Center
					},
					new StringElement ("Logout and Revoke Access Token", ()=> {
						SignIn.SharedInstance.Disconnect ();
						NavigationController.PopViewControllerAnimated (true);
					}) {
						Alignment = UITextAlignment.Center
					},
				}
			};
		}

		void HandleShareUrl ()
		{
			// When you share a URL, the title, description, thumbnail image and link 
			// for the share dialog are based on the URL you provide.
			var shareBuilder = Share.SharedInstance.ShareDialog;
			shareBuilder.SetURLToShare (new NSUrl ("http://xamarin.com"));
			shareBuilder.Open ();
		}

		void HandleShareXS ()
		{
			// This line will manually fill out the title, description, and 
			// thumbnail of the item you're sharing.
			var shareBuilder = Share.SharedInstance.ShareDialog;
			shareBuilder.SetTitle (title: "I love coding on Xamarin Studio!!",
			                       description: "Xamarin Studio is the best development environment for cross-platform mobile apps. Available on Windows and Mac.",
			                       thumbnailUrl: new NSUrl ("http://xamarin.com/images/studio/screenshot1.jpg"));

			// For more information about SetContentDeepLinkId visit 
			// https://developers.google.com/+/mobile/ios/share#deep_linking
			shareBuilder.SetContentDeepLinkId ("XamarinStudio");
			shareBuilder.Open ();
		}

		void GetUserPeople ()
		{
			plusService = new ServicePlus () {
				RetryEnabled = true,
				Authorizer = SignIn.SharedInstance.Authentication
			};

			// The following example uses the visible (PlusConstants.PlusCollectionVisible) collection to obtain a list of people 
			// who the signed-in user has added to one or more circles, which is limited to the circles the 
			// user made visible to the requesting app. This list does not include names of circles.
			var query = QueryPlus.QueryForPeopleListWithUserId ("me", PlusConstants.PlusCollectionVisible);
			plusService.ExecuteQuery (query, (ticket, obj, error) => {
				// obj contains the query results, we must cast it to PlusPeopleFeed in order to get its information
				var peopleFeed = obj as PlusPeopleFeed;
				if (error != null)
					InvokeOnMainThread (() => new UIAlertView ("Error", error.Description, null, "Ok", null).Show ());
				else {
					var root = new RootElement ("People List") { new Section () };
					foreach (var person in peopleFeed.Items) {
						root[0].Add (new StringElement (person.DisplayName));
					}
					var dvc = new DialogViewController (root, true);
					InvokeOnMainThread (() => NavigationController.PushViewController (dvc, true));
				}
			});
		}

		void GetUserInfo ()
		{
			plusService = new ServicePlus () {
				RetryEnabled = true,
				Authorizer = SignIn.SharedInstance.Authentication
			};

			// Create a QueryPlus object to get the details of the user with the given user ID. 
			// The special value "me" indicates the currently signed in user, but you could use 
			// any other valid user ID. Returns a PlusPerson.
			var query = QueryPlus.QueryForPeopleGetWithUserId ("me");
			plusService.ExecuteQuery (query, (ticket, obj, error) => {
				// obj contains the query results, we must cast it to PlusPerson in order to get its information
				var person = obj as PlusPerson;
				if (error != null)
					InvokeOnMainThread (() => new UIAlertView ("Error", error.Description, null, "Ok", null).Show ());
				else {
					InvokeOnMainThread (() => { 
						var section = Root[0];
						section.Add (new StyledStringElement ("Display Name", person.DisplayName, UITableViewCellStyle.Subtitle));
						section.Add (new StyledMultilineElement ("About Me", person.AboutMe, UITableViewCellStyle.Subtitle));
						section.Add (new StyledStringElement ("Birthday", person.Birthday, UITableViewCellStyle.Subtitle));
						ReloadData ();
					});	
				}
			});
		}
	}
}
