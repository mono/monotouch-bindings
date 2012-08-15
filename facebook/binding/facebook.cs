//
// facebook.cs: Bindings to the Facebook IOS SDK.
//
// Authors:
//   Miguel de Icaza (miguel@xamarin.com)
//
//
using System;
using MonoTouch.CoreLocation;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace MonoTouch.FacebookConnect  {

	delegate void FBSessionStateHandler (FBSession session, FBSessionState state, NSError error);
	delegate void FBSessionReauthorizeResultHandler (FBSession session, NSError error);

	[BaseType (typeof (NSObject))]
	interface FBSession {
		[Export ("isOpen")]
		bool IsOpen { get; }

		[Export ("state")]
		FBSessionState State { get; }

		[Export ("appID")]
		string AppID { get; }

		[Export ("urlSchemeSuffix")]
		string UrlSchemeSuffix { get; }

		[Export ("accessToken")]
		string AccessToken { get; }

		[Export ("expirationDate")]
		DateTime ExpirationDate { get; }

		[Export ("permission")]
		string [] Permissions { get; }

//		[Export ("init")]
//		IntPtr Constructor ();

		[Export ("initWithPermissions:")]
		IntPtr Constructor (string [] permissions);

		[Export ("initWithAppID:permissions:urlSchemeSuffix:tokenCacheStrategy:")]
		IntPtr Constructor (string appId, string urlSchemeSuffix, [NullAllowed]FBSessionTokenCachingStrategy strategy);

		[Export ("openWithCompletionHandler:")]
		void Open ([NullAllowed]FBSessionStateHandler handler);

		[Export ("openWithBehavior:completionHandler:")]
		void Open (FBSessionLoginBehavior behavior, [NullAllowed]FBSessionStateHandler handler);

		[Export ("close")]
		void Close ();

		[Export ("closeAndClearTokenInformation")]
		void CloseAndClearTokenInformation ();

		[Export ("reauthorizeWithPermissions:behavior:completionHandler:")]
		void Reauthorize ([NullAllowed]string [] permissions, FBSessionLoginBehavior behavior, FBSessionReauthorizeResultHandler handler);

		[Export ("handleOpenURL:")]
		bool HandleOpenUrl (NSUrl url);

		[Static]
		[Export ("openActiveSessionWithAllowLoginUI:")]
		bool OpenActiveSession(bool allowLoginUI);

		[Static]
		[Export ("openActiveSessionWithPermissions:allowLoginUI:completionHandler:")]
		bool OpenActiveSession([NullAllowed]string [] permissions, bool allowLoginUI, FBSessionStateHandler handler);

		// TODO: Can activeSession, setActiveSession: be merged into a get/set property?
		[Static]
		[Export ("activeSession")]
		FBSession GetActiveSession ();

		[Static]
		[Export ("setActiveSession:")]
		FBSession SetActiveSession (FBSession session);

		// TODO: these, too
		[Static]
		[Export ("setDefaultAppID:")]
		void SetDefaultAppID (string appID);

		[Static]
		[Export ("defaultAppID")]
		string GetDefaultAppID ();
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface FBSessionTokenCachingStrategy {
//		[Export ("init")]
//		IntPtr Constructor ();

		[Export ("initWithUserDefaultTokenInformationKeyName:")]
		IntPtr Constructor ([NullAllowed]string tokenInformationKeyName);

		[Export ("cacheTokenInformation:")]
		void CacheTokenInformation (NSDictionary tokenInformation);

		[Export ("fetchTOkenInformation)]")]
		NSDictionary FetchTokenInformation ();

		[Export ("clearToken")]
		void ClearToken ();

		[Static]
		[Export ("defaultInstance")]
		FBSessionTokenCachingStrategy GetDefaultInstance ();

		[Static]
		[Export ("isValidTokenInformation:")]
		bool IsValidTokenInformation (NSDictionary tokenInformation);

		[Static]
		[Field ("FBTokenInformationTokenKey", "__Internal")]
		NSString FBTokenInformationTokenKey { get; }

		[Static]
		[Field ("FBTokenInformationExpirationDateKey", "__Internal")]
		NSString FBTokenInformationExpirationDateKey { get; }

		[Static]
		[Field ("FBTokenInformationRefreshDateKey", "__Internal")]
		NSString FBTokenInformationRefreshDateKey { get; }

		[Static]
		[Field ("FBTokenInformationUserFBIDKey", "__Internal")]
		NSString FBTokenInformationUserFBIDKey { get; }

		[Static]
		[Field ("FBTokenInformationIsFacebookLoginKey", "__Internal")]
		NSString FBTokenInformationIsFacebookLoginKey { get; }

		[Static]
		[Field ("FBTokenInformationPermissionsKey", "__Internal")]
		NSString FBTokenInformationPermissionsKey { get; }
	}

	delegate void FBRequestHandler(FBRequestConnection connection, NSObject result, NSError error);

	[BaseType (typeof (NSObject))]
	interface FBRequest {
		[Export ("HTTPMethod")]
		string HttpMethod { get; set;  }

		[Export ("graphObject")]
		FBGraphObject GraphObject { get; set; }

		[Export ("graphPath")]
		string GraphPath { get; set; }

                [Export ("parameters")]
                NSMutableDictionary Parameters { get; set; }

		[Export ("restMethod")]
		string RestMethod { get; set; }

		[Export ("session")]
		FBSession Session { get; set; }

		[Export ("initWithSession:graphPath:")]
		IntPtr Constructor([NullAllowed]FBSession session, string graphPath);

		[Export ("initWithSession:graphPath:parameters:HTTPMethod:")]
		IntPtr Constructor([NullAllowed]FBSession session, string graphPath, NSDictionary parameters, string HTTPMethod);

		[Export ("initForPostWithSession:graphPath:graphObject:")]
		IntPtr Constructor([NullAllowed]FBSession session, string graphPath, FBGraphObject graphObject);

		// This constructor overload collides with initWithSession:graphPath:parameters:HTTPMethod:.
                // How on earth can I fix this?
		//
		//[Export ("initWithSession:restMethod:parameters:HTTPMethod:")]
		//IntPtr Constructor([NullAllowed]FBSession session, string restMethod, NSDictionary parameters, string HTTPMethod);

		[Export ("startWithCompletionHandler:")]
		FBRequestConnection Start(FBRequestHandler handler);

		[Static]
		[Export ("requestForMe")]
		FBRequest RequestForMe();

		[Static]
		[Export ("requestForMyFriends")]
		FBRequest RequestForMyFriends();

		[Static]
		[Export ("requestForPlacesSearchAtCoordinate:radiusInMeters:resultsLimit:searchText:")]
		FBRequest RequestForPlacesSearch(CLLocationCoordinate2D coordinate, int radius, int limit, string searchText);

		[Static]
		[Export ("requestForPostStatusUpdate:")]
		FBRequest RequestForPostStatusUpdate(string message);

		[Static]
		[Export ("requestForPostStatusUpdate:place:tags:")]
		// TODO: Replace NSArray with NSFastEnumeration if possible.
		FBRequest RequestForPostStatusUpdate(string message, [NullAllowed]NSObject place, NSArray tags);

		[Static]
		[Export ("requestForPostWithGraphPath:graphObject:")]
		FBRequest RequestForPost(string graphPath, FBGraphObject graphObject);

		[Static]
		[Export ("requestForUploadPhoto:")]
		FBRequest RequestForUploadPhoto(UIImage photo);

		[Static]
		[Export ("requestWithGraphPath:parameters:HTTPMethod:")]
		FBRequest RequestWithGraphPath(string graphPath, NSDictionary parameters, string HTTPMethod);
	}


	// TODO: finish this binding
	[BaseType (typeof(NSObject))]
	interface FBRequestConnection {
		[Export ("initWithTimeout:")]
		IntPtr Constructor(double timeout);

		[Export ("urlRequest")]
		NSMutableUrlRequest UrlRequest { get; set; }

		[Export ("urlResponse")]
		NSHttpUrlResponse UrlResponse { get; set; }

		[Export ("addRequest:completionHandler:")]
		void AddRequest(FBRequest request, FBRequestHandler handler);

		[Export ("addRequest:completionHandler:batchEntryName:")]
		void AddRequest(FBRequest request, FBRequestHandler handler, string name);

		[Export ("cancel")]
		void Cancel();

		[Export ("start")]
		void Start();

		[Static]
		[Export ("startForMeWithCompletionHandler:")]
		FBRequestConnection StartForMe(FBRequestHandler handler);

		[Static]
		[Export ("startForMyFriendsWithCompletionHandler:")]
		FBRequestConnection StartForMyFriends(FBRequestHandler handler);

		[Static]
		[Export ("startForPlacesSearchAtCoordinate:radiusInMeters:resultsLimit:searchText:completionHandler:")]
		FBRequestConnection StartForPlacesSearch(CLLocationCoordinate2D coordinate, int radius, int limit, string searchText, FBRequestHandler handler);

		[Static]
		[Export ("startForPostStatusUpdate:completionHandler:")]
		FBRequestConnection StartForPostStatusUpdate(string message, FBRequestHandler handler);

		[Static]
		[Export ("startForPostStatusUpdate:place:tags:completionHandler:")]
		FBRequestConnection StartForPostStatusUpdate(string message, [NullAllowed]NSObject place, NSArray tags, FBRequestHandler handler);

		[Static]
		[Export ("startForPostWithGraphPath:graphObject:completionHandler:")]
		FBRequestConnection StartForPostWithGraphPath(string graphPath, FBGraphObject graphObject, FBRequestHandler handler);

		[Static]
		[Export ("startForUploadPhoto:completionHandler:")]
		FBRequestConnection StartForUploadPhoto(UIImage photo, FBRequestHandler handler);

		[Static]
		[Export ("startWithGraphPath:completionHandler:")]
		FBRequestConnection StartWithGraphPath(string graphPath, FBRequestHandler handler);

		[Static]
		[Export ("startWithGraphPath:parameters:HTTPMethod:completionHandler:")]
		FBRequestConnection StartWithGraphPath(string graphPath, NSDictionary parameters, string HTTPMethod, FBRequestHandler handler);
	}

	[BaseType (typeof(NSObject))]
	interface FBCacheDescriptor {
		[Static]
		[Export ("prefetchAndCacheForSession:")]
		void PrefetchCache(FBSession session);
	}

	[Model]
	[BaseType (typeof(NSObject))]
	interface FBViewControllerDelegate {
		[Export ("facebookViewControllerCancelWasPressed:")]
		void Cancel (UIViewController sender);

		[Export ("facebookViewControllerDoneWasPressed:")]
		void Done (UIViewController sender);
	}

	delegate void FBModalCompletionHandler(FBViewController sender, bool donePressed);

	[BaseType (typeof(UIViewController))]
	interface FBViewController {
		[Export ("cancelButton")]
		UIBarButtonItem CancelButton { get; set; }

		[Export ("canvasView")]
		UIView CanvasView { get; }

		[Export ("delegate")]
		FBViewControllerDelegate Delegate { get; set; }

		[Export ("doneButton")]
		UIBarButtonItem DoneButton { get; set; }

		[Export ("presentModallyFromViewController:animated:handler:")]
		void PresentModally(UIViewController viewController, bool animated, FBModalCompletionHandler handler);
	}

	[BaseType (typeof(FBViewController))]
	interface FBFriendPickerViewController {
		[Export ("spinner")]
		UIActivityIndicatorView Spinner { get; set; }

		[Export ("tableView")]
		UITableView TableView { get; set; }

		[Export ("allowsMultipleSelections")]
		bool AllowsMultipleSelections { get; set; }

		[Export ("itemPicturesEnabled")]
		bool ItemPicturesEnabled { get; set; }

		[Export ("fieldsForRequest")]
		NSSet FieldsForRequest { get; set; }

		[Export ("session")]
		FBSession Session { get; set; }

		[Export ("userID")]
		string UserID { get; set; }

		[Export ("selection")]
		NSArray Selection { get; }

		[Export ("sortOrdering")]
		FBFriendSortOrdering SortOrdering { get; set; }

		[Export ("displayOrdering")]
		FBFriendDisplayOrdering DisplayOrdering { get; set; }

		[Export ("initWithCoder:")]
		IntPtr Constructor (NSCoder aDecoder);

		[Export ("initWithNibName:bundle:")]
		IntPtr Constructor ([NullAllowed]NSString nibName, [NullAllowed]NSBundle nibBundle);

		[Export ("configureUsingCachedDescriptor:")]
		void ConfigureUsingCachedDescriptor(FBCacheDescriptor cacheDescriptor);

		[Export ("loadData")]
		void LoadData();

		[Export ("updateView")]
		void UpdateView();

		[Export ("clearSelection")]
		void ClearSelection();

		[Static]
		[Export ("cacheDescriptor")]
		FBCacheDescriptor CacheDescriptor();

		[Static]
		[Export ("cacheDescriptorWithUserID:fieldsForRequest:")]
		FBCacheDescriptor CacheDescriptor (string userID, NSSet fieldsForRequest);
	}

	[BaseType (typeof(FBViewController))]
	interface FBPlacePickerViewController {
		[Export ("spinner")]
		UIActivityIndicatorView Spinner { get; set; }

		[Export ("tableView")]
		UITableView TableView { get; set; }

		[Export ("fieldsForRequest")]
		NSSet FieldsForRequest { get; set; }

		[Export ("itemPicturesEnabled")]
		bool ItemPicturesEnabled { get; set; }

		[Export ("locationCoordinate")]
		CLLocationCoordinate2D LocationCoordinate { get; set; }

		[Export ("radiusInMeters")]
		int RadiusInMeters { get; set; }

		[Export ("resultsLimit")]
		int ResultsLimit { get; set; }

		[Export ("searchText")]
		string SearchText { get; set; }

		[Export ("session")]
		FBSession Session { get; set; }

		[Export ("selection")]
		NSArray Selection { get; }

		[Export ("initWithCoder:")]
		IntPtr Constructor (NSCoder aDecoder);

		[Export ("initWithNibName:bundle:")]
		IntPtr Constructor ([NullAllowed]NSString nibName, [NullAllowed]NSBundle nibBundle);

		[Export ("configureUsingCachedDescriptor:")]
		void ConfigureUsingCachedDescriptor(FBCacheDescriptor cacheDescriptor);

		[Export ("loadData")]
		void LoadData();

		[Export ("clearSelection")]
		void ClearSelection();

		[Static]
		[Export ("cacheDescriptorWithLocationCoordinate:radiusInMeters:searchText:resultsLimit:fieldsForRequest:")]
		FBCacheDescriptor CacheDescriptor (CLLocationCoordinate2D locationCoordinate,
						   int radiusInMeters, string searchText, int resultsLimit,
						   NSSet fieldsForRequest);
	}

	[Model]
	[BaseType (typeof(NSObject))]
	interface FBLoginViewDelegate {
		[Export ("loginViewShowingLoggedInUser:")]
		void LoginViewShowingLoggedInUser (FBLoginView loginView);

		[Export ("loginViewFetchedUserInfo:user:")]
		void LoginViewFetchedUserInfo (FBLoginView loginView, FBGraphUser user);

		[Export ("loginViewShowingLoggedOutUser:")]
		void LoginViewShowingLoggedOutUser (FBLoginView loginView);
	}

	[BaseType (typeof(UIView))]
	interface FBLoginView {
		[Export ("permissions")]
		NSArray Permissions { get; set; }

		[Export ("delegate")]
		FBLoginViewDelegate Delegate { get; set; }

		[Export ("initWithPermissions:")]
		IntPtr Constructor (NSArray permissions);
	}
	
	[BaseType (typeof(UIView))]
	interface FBProfilePictureView {
		[Export ("profileID")]
		string ProfileID { get; set; }

		[Export ("pictureCropping")]
		FBProfilePictureCropping PictureCropping { get; set; }

		[Export ("initWithProfileID:pictureCropping:")]
		IntPtr Constructor (string profileID, FBProfilePictureCropping pictureCropping);
	}

	[BaseType (typeof(FBViewController))]
	interface FBUserSettingsViewController {
		[Export ("permissions")]
		NSArray Permissions { get; set; }
	}

	[BaseType (typeof(NSObject))]
	interface FBSettings {
		[Static]
		[Export ("loggingBehavior")]
		NSSet LoggingBehavior ();

		[Static]
		[Export ("publishInstall:")]
		void PublishInstall (string appID);

		[Static]
		[Export ("setLoggingBehavior:")]
		void SetLoggingBehavior (NSSet loggingBehavior);

		[Static]
		[Export ("setShouldAutoPublishInstall:")]
		void SetShouldAutoPublishInstall (bool autoPublishInstall);

		[Static]
		[Export ("shouldAutoPublishInstall")]
		bool ShouldAutoPublishInstall ();
	}

	[BaseType (typeof(NSObject))]
	interface FBGraphObject {
		[Export ("count")]
		uint Count();
		
		[Export ("objectForKey:")]
		NSObject ObjectForKey (NSObject aKey);

		[Export ("keyEnumerator")]
		NSEnumerator KeyEnumerator();

		[Export ("removeObjectForKey:")]
		void Remove (NSObject aKey);

		[Export ("setObject:forKey:")]
		void Set (NSObject anObject, NSObject aKey);
	}

	[BaseType (typeof(FBGraphObject))]
	interface FBGraphUser {
		[Export ("id")]
		string Id { get; set; }

		[Export ("name")]
		string Name { get; set; }

		[Export ("first_name")]
		string FirstName { get; set; }

		[Export ("last_name")]
		string LastName { get; set; }

		[Export ("middle_name")]
		string MiddleName { get; set; }

		[Export ("link")]
		string Link { get; set; }

		[Export ("username")]
		string Username { get; set; }

		[Export ("birthday")]
		string Birthday { get; set; }

		[Export ("location")]
		FBGraphLocation Location { get; set; }
	}

	[BaseType (typeof(FBGraphObject))]
	interface FBGraphLocation {
		[Export ("street")]
		string Street { get; set; }

		[Export ("city")]
		string City { get; set; }

		[Export ("state")]
		string State { get; set; }

		[Export ("country")]
		string Country { get; set; }

		[Export ("zip")]
		string Zip { get; set; }

		[Export ("latitude")]
		NSNumber Latitude { get; set; }

		[Export ("longitude")]
		NSNumber Longitude { get; set; }
	}

	[BaseType (typeof(FBGraphObject))]
	interface FBGraphPlace {
		[Export ("id")]
		string Id { get; set; }

		[Export ("name")]
		string Name { get; set; }

		[Export ("category")]
		string Category { get; set; }

		[Export ("location")]
		FBGraphLocation Location { get; set; }
	}
}
