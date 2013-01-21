
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using MonoTouch.FacebookConnect;
using MonoTouch.ObjCRuntime;
using System.Linq;


namespace Scrumptious
{
	public partial class SCViewController : UIViewController
	{
		public CLLocationManager locationManager;
		AppDelegate appDelegate;

		public FBFriendPickerViewController friendPickerController;
		public FBPlacePickerViewController placePickerController;
		public SCMealViewController mealViewController;
		public FBGraphUser [] selectedFriends;
		public FBGraphPlace selectedPlace;
		public string selectedMeal;
		public UIImagePickerController imagePicker;
		public UIImage selectedPhoto;

		public SCViewController () : base ("SCViewController", null)
		{
			appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.Title = "Scrumptious";

			// Get the CLLocationManager going.
			locationManager = new CLLocationManager();
			locationManager.DesiredAccuracy = CLLocation.AccuracyNearestTenMeters;

			// We don't want to be notified of small changes in location, preferring to use our
			// last cached results, if any.
			locationManager.DistanceFilter = 50;

			// We Hook Location Events

			//Check if we are on iOS6
			if (UIDevice.CurrentDevice.CheckSystemVersion (6, 0)) 
			{
				locationManager.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) => 
				{
					Console.WriteLine("Got Location: Lat:" + e.Locations[0].Coordinate.Latitude + " Long:" + e.Locations[0].Coordinate.Longitude);
				};
			} 
			else 
			{
				locationManager.UpdatedLocation += (object sender, CLLocationUpdatedEventArgs e) => 
				{
					if (e.OldLocation.Coordinate.Latitude != e.NewLocation.Coordinate.Latitude && e.OldLocation.Coordinate.Longitude != e.NewLocation.Coordinate.Longitude ) 
					{
						Console.WriteLine("Got Location: Lat:" + e.NewLocation.Coordinate.Latitude + " Long:" + e.NewLocation.Coordinate.Longitude );
					}
				};
			}

			locationManager.Failed += (object sender, NSErrorEventArgs e) => 
			{
				Console.WriteLine("Location Error: " + e.Error.LocalizedDescription);
			};

			locationManager.StartUpdatingLocation();

			// Add a logout button to the right bar of the navigation
			this.NavigationItem.RightBarButtonItem = new UIBarButtonItem ("Log Out", UIBarButtonItemStyle.Bordered, (s,a)=> { FBSession.ActiveSession.CloseAndClearTokenInformation(); });

			NSNotificationCenter.DefaultCenter.AddObserver(this, new Selector("sessionStateChanged:"), AppDelegate.SCSessionStateChangedNotification, null);
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;

			NSNotificationCenter.DefaultCenter.RemoveObserver(this);
			friendPickerController = null;
			placePickerController = null;
			imagePicker = null;

			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			if (FBSession.ActiveSession.IsOpen)
				PopulateUserDetails();

			MenuTableView.Source = new MyDataSource(this);
		}

		public void StartLocationManager ()
		{
			this.locationManager.StartMonitoringSignificantLocationChanges();
		}

		void PopulateUserDetails ()
		{
			if (FBSession.ActiveSession.IsOpen) 
			{
				FBRequest.GetRequestForMe.Start( (connection, result, error) => 
				{
					if (error == null) 
					{
						FBGraphUser user = new FBGraphUser(result);
						userNameLabel.Text = user.Name;
						userProfileImage.ProfileID = user.Id;
					}
				});    
			}
		}

		[Export("sessionStateChanged:")]
		void SessionStateChanged (NSObject sender)
		{
			PopulateUserDetails();
		}

		public void UpdateCellIndex (int index, string subtitle)
		{
			UITableViewCell cell = MenuTableView.CellAt(NSIndexPath.FromRowSection(index, 0));
			cell.DetailTextLabel.Text = subtitle;
		}

		public void UpdateSelections ()
		{
			// Update Cell's Details text

			if (selectedFriends != null) 
			{
				string friendsSubtitle = "Select friends";
				int friendCount = selectedFriends.Count();
				if (friendCount > 2) 
				{
					// Just to mix things up, don't always show the first friend.
					Random r = new Random(DateTime.Now.Millisecond);
					int usr = r.Next(0, friendCount - 1);
					FBGraphUser randomFriend = selectedFriends[usr];
					friendsSubtitle = randomFriend.Name + " and " + friendCount.ToString() + " others" ;
				}
				else if (friendCount == 2) 
				{
					FBGraphUser friend1 = selectedFriends[0];
					FBGraphUser friend2 = selectedFriends[1];
					friendsSubtitle = friend1.Name + " and " + friend2.Name;
				}
				else if (friendCount == 1) 
				{
					FBGraphUser friend = selectedFriends[0];
					friendsSubtitle = friend.Name;
				}
				UpdateCellIndex(2, friendsSubtitle);
			}

			UpdateCellIndex(1, selectedPlace != null ? selectedPlace.Name : "Select One");

			UpdateCellIndex(0, selectedMeal != null ? selectedMeal : "Select One");

			UpdateCellIndex(3, selectedPhoto != null ? "Ready" : "Take One");

			announceButton.UserInteractionEnabled = selectedMeal != null;
		}

		// FBSample logic
		// This is a helper function that returns an FBGraphObject representing a meal
		SCOGMeal MealObjectForMeal (String meal) 
		{
			
			// We create an FBGraphObject object, but we can treat it as an SCOGMeal with typed
			// properties, etc.
//			SCOGMeal result = (SCOGMeal) FBGraphObject.GraphObject();

			FBGraphObject obj = FBGraphObject.GraphObject();
			SCOGMeal result = new SCOGMeal(obj.Handle);
			

			// Give it a URL of sample data that contains the object's name, title, description, and body.
			// These OG object URLs were created using the edit open graph feature of the graph tool
			// at https://www.developers.facebook.com/apps/
			if (meal == "Cheeseburger") 
				result.Url = "http://samples.ogp.me/314483151980285";
			else if (meal == "Pizza") 
				result.Url = "http://samples.ogp.me/314483221980278";
			else if (meal == "Hotdog") 
				result.Url = "http://samples.ogp.me/314483265313607";
			else if (meal == "Italian")
				result.Url = "http://samples.ogp.me/314483348646932";
			else if (meal == "French")
				result.Url = "http://samples.ogp.me/314483375313596";
			else if (meal == "Chinese")
				result.Url = "http://samples.ogp.me/314483421980258";
			else if (meal == "Thai")
				result.Url = "http://samples.ogp.me/314483451980255";
			else if (meal == "Indian")
				result.Url = "http://samples.ogp.me/314483491980251";
	
			return result;
		}

		// FBSample logic
		// Creates the Open Graph Action.
		void PostOpenGraphAction ()
		{
			// First create the Open Graph meal object for the meal we ate.
			SCOGMeal mealObject = MealObjectForMeal (selectedMeal);
			
			// Now create an Open Graph eat action with the meal, our location, and the people we were with.
			//SCOGEatMealAction action = (SCOGEatMealAction)FBGraphObject.GraphObject ();

			FBGraphObject obj = FBGraphObject.GraphObject();
			SCOGEatMealAction action = new SCOGEatMealAction(obj.Handle);

			action.Meal = mealObject;
			if (selectedPlace != null) 
			{
				action.Place = selectedPlace;
			}
			if (selectedFriends != null) 
			{
				action.Tags = selectedFriends;
			}
			
			// Create the request and post the action to the "me/fb_sample_scrumps:eat" path.
			FBRequestConnection.StartForPostWithGraphPath ("me/fb_sample_mtscrumps:eat", action, (FBRequestConnection connection, NSObject result, NSError error) => {
				activityIndicator.StopAnimating ();
				this.View.UserInteractionEnabled = true;

				if (error == null) {
					new UIAlertView ("Result", "Posted Open Graph action, id: " + (string)new NSString (result.ValueForKey (new NSString ("id")).Handle), null, "Thanks!", null).Show ();
					selectedMeal = null;
					selectedPlace = null;
					selectedFriends = null;
					selectedPhoto = null;
					UpdateSelections ();
				} else {
					// do we lack permissions here? If so, the application's policy is to reask for the permissions, and if
					// granted, we will recall this method in order to post the action
					// TODO: Resolve Status Code 200
					if (false) {
						Console.WriteLine (error.LocalizedDescription);

						FBSession.ActiveSession.ReauthorizeWithPublishPermissions (new string[] { "publish_actions" }, FBSessionDefaultAudience.Friends, (FBSession fsession, NSError innerError) => 
						{
							if (innerError == null) {
								// re-call assuming we now have the permission
								PostOpenGraphAction ();
							} else {
								// If we are here, this means the user has disallowed posting after a retry
								// which means iOS 6.0 will have turned the app's slider to "off" in the
								// device settings->Facebook.
								// You may want to customize the message for your application, since this
								// string is specifically for iOS 6.0.
								new UIAlertView ("Permission To Post Disallowed", "Use device settings->Facebook to re-enable permission to post.", null, "Ok!", null).Show ();
							}
						});
					} else {
						new UIAlertView ("Result", "error: domain = " + error.Domain + ", code = " + (FBErrorCode)error.Code, null, "Ok", null).Show ();

					}
				}

			});		
		}

		// FBSample logic
		// Handles the user clicking the Announce button by creating an Open Graph Action
		partial void announce (MonoTouch.UIKit.UIButton sender)
		{
			// if we don't have permission to announce, let's first address that
			if (!FBSession.ActiveSession.Permissions.Contains("publish_actions")) 
			{
				FBSession.ActiveSession.ReauthorizeWithPublishPermissions(new string[] { "publish_actions" }, FBSessionDefaultAudience.Friends, (FBSession session, NSError error) =>
				{
					if (error == null) 
					{
						this.announce(sender);
					}
				});
			}
			else 
			{
				announceButton.Enabled = false;
				activityIndicator.StartAnimating();
				this.View.UserInteractionEnabled = false;

				PostOpenGraphAction();
			}

		}
	}

	public class MyDataSource : MonoTouch.UIKit.UITableViewSource
	{
		SCViewController ctrl;
		public MyDataSource (SCViewController ctrl)
		{
			this.ctrl = ctrl;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			string CellIdentifier = "CellID";
			
			var cell = tableView.DequeueReusableCell(CellIdentifier) as UITableViewCell;
			
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				cell.SelectionStyle = UITableViewCellSelectionStyle.None;
				
				cell.TextLabel.Font = UIFont.SystemFontOfSize(16f);
				cell.TextLabel.BackgroundColor = UIColor.White;
				cell.TextLabel.LineBreakMode = UILineBreakMode.TailTruncation;
				cell.ClipsToBounds = true;
				
				cell.DetailTextLabel.Font = UIFont.SystemFontOfSize(12f);
				cell.DetailTextLabel.BackgroundColor = UIColor.FromRGBA(0.4f, 0.6f, 0.8f, 1f);
				cell.DetailTextLabel.LineBreakMode = UILineBreakMode.TailTruncation;
				cell.DetailTextLabel.ClipsToBounds = true;
			}
			
			switch (indexPath.Row) 
			{
			case 0:
				cell.TextLabel.Text = "What are you eating?";

				if(ctrl.selectedMeal == null)
					cell.DetailTextLabel.Text = "Select One";

				cell.ImageView.Image = new UIImage(Environment.CurrentDirectory + "/images/action-eating.png");
				break;
				
			case 1:
				cell.TextLabel.Text = "Where are you?";

				if(ctrl.selectedPlace == null)
				cell.DetailTextLabel.Text = "Select One";

				cell.ImageView.Image = new UIImage(Environment.CurrentDirectory + "/images/action-location.png");
				break;

			case 2:
				cell.TextLabel.Text = "With whom?";

				if(ctrl.selectedFriends == null)
					cell.DetailTextLabel.Text = "Select friends";

				cell.ImageView.Image = new UIImage(Environment.CurrentDirectory + "/images/action-people.png");
				break;

			case 3:
				cell.TextLabel.Text = "Got a picture?";

				if(ctrl.selectedPhoto == null)
					cell.DetailTextLabel.Text = "Take one";

				cell.ImageView.Image = new UIImage(Environment.CurrentDirectory + "/images/action-photo.png");
				break;
				
			default:
				break;
			}

			return cell;
		}	
		
		public override int RowsInSection (UITableView tableview, int section)
		{
			return 4;
		}		

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			switch (indexPath.Row) 
			{
			case 0:
				if(ctrl.mealViewController == null)
				{
					ctrl.mealViewController = new SCMealViewController(ctrl);
				}
				ctrl.NavigationController.PushViewController(ctrl.mealViewController, true);
				break;

			case 1:
				if(ctrl.placePickerController == null)
				{
					ctrl.placePickerController = new FBPlacePickerViewController(null, null);
					ctrl.placePickerController.Title = "Select a Restaurant";
				}

				//Setup PlacePicker properties
				ctrl.placePickerController.LocationCoordinate = ctrl.locationManager.Location.Coordinate;
				ctrl.placePickerController.RadiusInMeters = 1000;
				ctrl.placePickerController.ResultsLimit = 50;
				ctrl.placePickerController.SearchText = "restaurant";

				//Hook up events
				ctrl.placePickerController.SelectionDidChange += (s, e) => 
				{
					var picker = s as FBPlacePickerViewController;
					ctrl.selectedPlace = picker.Selection;

					ctrl.UpdateSelections();
					
					if (ctrl.selectedPlace.Count > 0)
						ctrl.NavigationController.PopViewControllerAnimated(true);
				};

				ctrl.placePickerController.LoadData();
				ctrl.NavigationController.PushViewController(ctrl.placePickerController, true);

				break;
			case 2:
				if (ctrl.friendPickerController == null) 
				{
					ctrl.friendPickerController = new FBFriendPickerViewController(null, null);
					ctrl.friendPickerController.Title = "Select friends";
				}

				//Hook up events
				ctrl.friendPickerController.SelectionDidChange += (s,e) =>
				{
					var picker = s as FBFriendPickerViewController;
					ctrl.selectedFriends = picker.Selection;
					ctrl.UpdateSelections();
				};

				ctrl.friendPickerController.LoadData();
				ctrl.NavigationController.PushViewController(ctrl.friendPickerController, true);
				break;
			case 3:
				if (ctrl.imagePicker == null) 
				{
					ctrl.imagePicker = new UIImagePickerController();

					// In a real app, we would probably let the user
					// either pick an image or take one using the camera.
					// For sample purposes in the simulator, the camera is not available.
					ctrl.imagePicker.SourceType = UIImagePickerControllerSourceType.SavedPhotosAlbum;
				}

				ctrl.imagePicker.FinishedPickingMedia += (object sender, UIImagePickerMediaPickedEventArgs e) => 
				{
					var s = sender as UIImagePickerController;
					ctrl.selectedPhoto = e.OriginalImage;
					s.DismissViewController(true, null);
					ctrl.UpdateSelections();
				};

				ctrl.imagePicker.Canceled += (object sender, EventArgs e) => 
				{
					var s = sender as UIImagePickerController;
					s.DismissViewController(true, null);
				};

				ctrl.NavigationController.PresentViewController(ctrl.imagePicker, true, null);
				break;

			default:
				break;
			}
		}


	}
}

