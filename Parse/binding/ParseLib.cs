using System;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace ParseTouch
{
	public delegate void ParseBooleanResult (bool succeeded,NSError error);

	public delegate void ParseIntegerResult (int number,NSError error);

	public delegate void ParseArrayResult (ParseObject[] objects,NSError error);

	public delegate void ParseObjectResult (ParseObject theObject,NSError error);

	public delegate void ParseSetResult (NSSet channels,NSError error);

	public delegate void ParseUserResult (ParseUser user,NSError error);

	public delegate void ParseDataResult (NSData data,NSError error);

	public delegate void ParseDataStreamResult (NSInputStream data,NSError error);

	public delegate void ParseErrorResult (NSError error);

	public delegate void ParseProgress (int percentDone);

	public delegate void ParseImageResult (UIImage image,NSError error);

	[BaseType (typeof(NSObject), Name="Parse")]
	public interface Parse
	{

		[Static]
		[Export ("setApplicationId:clientKey:")]
		void SetAppId (string applicationId, string clientKey);

		[Static]
		[Export ("offlineMessagesEnabled:")]
		void OfflineMessagesEnabled (bool enabled);

		[Static]
		[Export ("errorMessagesEnabled:")]
		void ErrorMessagesEnabled (bool enabled);

		[Static]
		[Export ("getApplicationId")]
		string ApplicationId{ get; }

		[Static]
		[Export ("getClientKey")]
		string ClientKey{ get; }


	}
	[BaseType (typeof (UIView))]
	interface PF_EGORefreshTableHeaderView {
		[Export ("lastUpdatedLabel")]
		UILabel LastUpdatedLabel { get;  }
		
		[Export ("statusLabel")]
		UILabel StatusLabel { get;  }
		
		[Export ("activityView")]
		UIActivityIndicatorView ActivityView { get;  }
		
		[Export ("refreshLastUpdatedDate")]
		void RefreshLastUpdatedDate ();
		
		[Export ("egoRefreshScrollViewDidScroll:")]
		void ScrollViewDidScroll (UIScrollView scrollView);
		
		[Export ("egoRefreshScrollViewDidEndDragging:")]
		void ScrollViewDidEndDragging (UIScrollView scrollView);
		
		[Export ("egoRefreshScrollViewDataSourceDidFinishedLoading:")]
		void FinishedLoading (UIScrollView scrollView);
		
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface PF_EGORefreshTableHeaderDelegate {
		[Abstract]
		[Export ("egoRefreshTableHeaderDataSourceIsLoading:")]
		bool DataSourceIsLoading (PF_EGORefreshTableHeaderView view);
		
		[Abstract]
		[Export ("egoRefreshTableHeaderDataSourceLastUpdated:")]
		NSDate DataSourceLastUpdated (PF_EGORefreshTableHeaderView view);
		
	}
	
	[BaseType (typeof(NSObject), Name="PFACL")]
	public interface ParseACL
	{
		[Static]
		[Export ("ACL")]
		ParseACL ACL ();

		[Static]
		[Export ("ACLWithUser:")]
		ParseACL ACL (ParseUser user);

		[Export ("setPublicReadAccess:")]
		void SetPublicReadAccess (bool allowed);

		[Export ("getPublicReadAccess")]
		bool GetPublicReadAccess ();

		[Export ("setPublicWriteAccess:")]
		void SetPublicWriteAccess (bool allowed);

		[Export ("getPublicWriteAccess")]
		bool GetPublicWriteAccess ();

		[Export ("setReadAccess:forUserId:")]
		void SetReadAccess (bool allowed, string userId);

		[Export ("getReadAccessForUserId:")]
		bool GetReadAccess (string userId);

		[Export ("setWriteAccess:forUserId:")]
		void SetWriteAccess (bool allowed, string userId);

		[Export ("getWriteAccessForUserId:")]
		bool GetWriteAccess (string userId);

		[Export ("setReadAccess:forUser:")]
		void SetReadAccess (bool allowed, ParseUser user);

		[Export ("getReadAccessForUser:")]
		bool GetReadAccess (ParseUser user);

		[Export ("setWriteAccess:forUser:")]
		void SetWriteAccess (bool allowed, ParseUser user);

		[Export ("getWriteAccessForUser:")]
		bool GetWriteAccess (ParseUser user);

		[Export ("getReadAccessForRoleWithName:")]
		bool GetReadAccessForRoleName (string name);

		[Export ("setReadAccess:forRoleWithName:")]
		void SetReadAccessforRoleName (bool allowed, string name);

		[Export ("getWriteAccessForRoleWithName:")]
		bool GetWriteAccessForRoleName (string name);

		[Export ("setWriteAccess:forRoleWithName:")]
		void SetWriteAccessforRoleName (bool allowed, string name);

		[Export ("getReadAccessForRole:")]
		bool GetReadAccess (ParseRole role);

		[Export ("setReadAccess:forRole:")]
		void SetReadAccess (bool allowed, ParseRole role);

		[Export ("getWriteAccessForRole:")]
		bool GetWriteAccess (ParseRole role);

		[Export ("setWriteAccess:forRole:")]
		void SetWriteAccess (bool allowed, ParseRole role);

		[Static]
		[Export ("setDefaultACL:withAccessForCurrentUser:")]
		void SetDefaultACLAccess (ParseACL acl, bool currentUserAccess);

	}

	[BaseType (typeof(NSObject), Name="PFFile")]
	public interface ParseFile
	{
		[Export ("name")]
		string Name { get; }

		[Export ("url")]
		string Url { get; }

		[Export ("isDirty")]
		bool IsDirty { get; }

		[Export ("isDataAvailable")]
		bool IsDataAvailable { get; }

		[Static]
		[Export ("fileWithData:")]
		ParseFile FromData (NSData data);

		[Static]
		[Export ("fileWithName:data:")]
		ParseFile FromData (string name, NSData data);

		[Static]
		[Export ("fileWithName:contentsAtPath:")]
		ParseFile FromPath (string name, string path);

		[Export ("save")]
		bool Save ();

		[Export ("save:")]
		bool Save (out NSError error);

		[Export ("saveInBackground")]
		void SaveAsync ();

		[Export ("saveInBackgroundWithBlock:")]
		void SaveAsync (ParseBooleanResult result);

		[Export ("saveInBackgroundWithBlock:progressBlock:")]
		void SaveAsync (ParseBooleanResult result, ParseProgress progress);

		[Export ("saveInBackgroundWithTarget:selector:"), Internal]
		void SaveAsync (NSObject target, Selector selector);

		[Export ("getData")]
		NSData GetData ();

		[Export ("getDataStream")]
		NSInputStream GetDataStream ();

		[Export ("getData:")]
		NSData GetData (out NSError error);

		[Export ("getDataStream:")]
		NSInputStream GetDataStream (out NSError error);

		[Export ("getDataInBackgroundWithBlock:")]
		void GetDataAsync (ParseDataResult result);

		[Export ("getDataStreamInBackgroundWithBlock:")]
		void GetDataStreamAsync (ParseDataStreamResult block);

		[Export ("getDataInBackgroundWithBlock:progressBlock:")]
		void GetDataAsync (ParseDataResult result, ParseProgress progress);

		[Export ("getDataStreamInBackgroundWithBlock:progressBlock:")]
		void GetDataStreamAsync (ParseDataStreamResult result, ParseProgress progress);

		[Export ("getDataInBackgroundWithTarget:selector:"), Internal]
		void GetDataAsync (NSObject target, Selector selector);

		[Export ("cancel")]
		void Cancel ();

	}

	[BaseType (typeof(ParseObject), Name="PFRole")]
	public interface ParseRole
	{
		[Export ("initWithName:")]
		ParseRole InitWithName (string name);

		[Export ("initWithName:acl:")]
		ParseRole InitWithNameacl (string name, ParseACL acl);

		[Static]
		[Export ("roleWithName:")]
		ParseRole RoleWithName (string name);

		[Static]
		[Export ("roleWithName:acl:")]
		ParseRole RoleWithNameacl (string name, ParseACL acl);

		[Export ("name")]
		string name { get; set; }

		[Export ("users")]
		ParseRelation Users ();

		[Export ("roles")]
		ParseRelation Roles ();

		[Export ("query")]
		ParseQuery Query ();

	}
	
	[BaseType (typeof(NSObject), Name="PFRelation")]
	public interface ParseRelation
	{
		[Export ("targetClass")]
		string TargetClass { get; set; }

		[Export ("key")]
		string Key { get; }

		[Export ("query")]
		ParseQuery Query ();

		[Export ("addObject:")]
		void AddObject (ParseObject obj);

		[Export ("removeObject:")]
		void RemoveObject (ParseObject obj);

	}

	[BaseType (typeof(NSObject), Name="PFObject")]
	public interface ParseObject
	{

		[Static]
		[Export ("objectWithClassName:")]
		ParseObject FromName (string className);

		[Static]
		[Export ("objectWithoutDataWithClassName:objectId:")]
		ParseObject FromName (string className, string objectId);

		[Export ("initWithClassName:")]
		IntPtr Constructor (string newClassName);

		[Export ("objectId")]
		string ObjectId { get; set; }

		[Export ("updatedAt")]
		NSDate UpdatedAt { get; }

		[Export ("createdAt")]
		NSDate CreatedAt { get; }

		[Export ("className")]
		string ClassName { get; }

		[Export ("ACL")]
		ParseACL ACL { get; set; }

		[Export ("addObject:forKey:")]
		void AddObject (NSObject value, string key);

		[Export ("addObjectsFromArray:forKey:")]
		void AddObjects (NSObject[] values, string[] keys);

		[Export ("addUniqueObject:forKey:")]
		void AddUniqueObject (NSObject value, string key);

		[Export ("addUniqueObjectsFromArray:forKey:")]
		void AddUniqueObjects (NSObject[] values, string[] keys);

		[Export ("allKeys")]
		string[] AllKeys { get; }

		[Export ("objectForKey:")]
		NSObject ObjectForKey (string key);

		[Export ("setObject:forKey:")]
		void SetObjectforKey (NSObject value, string key);

		[Export ("removeObject:forKey:")]
		void RemoveObjectForKey (NSObject value, string key);

		[Export ("removeObjectsInArray:forKey:")]
		void RemoveObjectForKey (NSObject[] values, string[] keys);

		[Export ("relationforKey:")]
		ParseRelation RelationforKey (string key);

		[Export ("incrementKey:")]
		void IncrementKey (string key);

		[Export ("incrementKey:byAmount:")]
		void IncrementKeybyAmount (string key, int amount);

		[Export ("save")]
		bool Save ();

		[Export ("save:")]
		bool Save (out NSError error);

		[Export ("saveInBackground")]
		void SaveAsync ();

		[Export ("saveInBackgroundWithBlock:")]
		void SaveAsync (ParseBooleanResult result);

		[Export ("saveInBackgroundWithTarget:selector:")]
		void SaveAsync (NSObject target, Selector selector);

		[Export ("saveEventually")]
		void SaveEventually ();

		[Export ("saveEventually:")]
		void SaveEventually (ParseBooleanResult result);

		[Export ("saveAll:")]
		bool SaveAll (ParseObject[] objects);

		[Static]
		[Export ("saveAll:error:")]
		bool SaveAll (ParseObject[] objects, out NSError error);

		[Static]
		[Export ("saveAllInBackground:")]
		void SaveAllAsync (ParseObject[] objects);

		[Static]
		[Export ("saveAllInBackground:block:")]
		void SaveAllAsync (ParseObject[] objects, ParseBooleanResult result);

		[Static]
		[Export ("saveAllInBackground:target:selector:")]
		void SaveAllAsync (ParseObject[] objects, NSObject target, Selector selector);

		[Export ("isDataAvailable")]
		bool IsDataAvailable ();

		[Export ("refresh")]
		void Refresh ();

		[Export ("refresh:")]
		void Refresh (out NSError error);

		[Export ("refreshInBackgroundWithBlock:")]
		void RefreshAsync (ParseObjectResult result);

		[Export ("refreshInBackgroundWithTarget:selector:")]
		void RefreshAsync (NSObject target, Selector selector);

		[Export ("fetch")]
		void Fetch ();

		[Export ("fetch:")]
		void Fetch (out NSError error);

		[Export ("fetchIfNeeded")]
		ParseObject FetchIfNeeded ();

		[Export ("fetchIfNeeded:")]
		ParseObject FetchIfNeeded (out NSError error);

		[Export ("fetchInBackgroundWithBlock:")]
		void FetchAsync (ParseObjectResult result);

		[Export ("fetchInBackgroundWithTarget:selector:")]
		void FetchAsync (NSObject target, Selector selector);

		[Export ("fetchIfNeededInBackgroundWithBlock:")]
		void FetchIfNeededAsync (ParseObjectResult result);

		[Export ("fetchIfNeededInBackgroundWithTarget:selector:")]
		void FetchIfNeededAsync (NSObject target, Selector selector);

		[Static]
		[Export ("fetchAll:")]
		void FetchAll (ParseObject[] objects);

		[Static]
		[Export ("fetchAll:error:")]
		void FetchAll (ParseObject[] objects, out NSError error);

		[Static]
		[Export ("fetchAllIfNeeded:")]
		void FetchAllIfNeeded (ParseObject[] objects);

		[Static]
		[Export ("fetchAllIfNeeded:error:")]
		void FetchAllIfNeeded (ParseObject[] objects, out NSError error);

		[Static]
		[Export ("fetchAllInBackground:block:")]
		void FetchAllAsync (ParseObject[] objects, ParseArrayResult result);

		[Static]
		[Export ("fetchAllInBackground:target:selector:")]
		void FetchAllAsync (ParseObject[] objects, NSObject target, Selector selector);

		[Static]
		[Export ("fetchAllIfNeededInBackground:block:")]
		void FetchAllIfNeededAsync (ParseObject[] objects, ParseArrayResult result);

		[Static]
		[Export ("fetchAllIfNeededInBackground:target:selector:")]
		void FetchAllIfNeededAsync (ParseObject[] objects, NSObject target, Selector selector);

		[Export ("delete")]
		bool Delete ();

		[Export ("delete:")]
		bool Delete (out NSError error);

		[Export ("deleteInBackground")]
		void DeleteInBackground ();

		[Export ("deleteInBackgroundWithBlock:")]
		void DeleteAsync (ParseBooleanResult result);

		[Export ("deleteInBackgroundWithTarget:selector:")]
		void DeleteAsync (NSObject target, Selector selector);

		[Export ("deleteEventually")]
		void DeleteEventually ();

	}

	[BaseType (typeof(NSObject), Name="PFPush")]
	public interface ParsePush
	{
		[Export ("setChannel:")]
		void SetChannel (string channel);

		[Export ("setChannels:")]
		void SetChannels (string[] channels);

		[Export ("setMessage:")]
		void SetMessage (string message);

		[Export ("setData:")]
		void SetData (NSDictionary data);

		[Export ("setPushToAndroid:")]
		void SetPushToAndroid (bool pushToAndroid);

		[Export ("setPushToIOS:")]
		void SetPushToIOS (bool pushToIOS);

		[Export ("expireAtDate:")]
		void ExpireAtDate (NSDate date);

		[Export ("expireAfterTimeInterval:")]
		void ExpireAfterTimeInterval (double timeInterval);

		[Export ("clearExpiration")]
		void ClearExpiration ();

		[Static]
		[Export ("sendPushMessageToChannel:withMessage:error:")]
		bool SendPushMessage (string channel, string message, out  NSError error);

		[Static]
		[Export ("sendPushMessageToChannelInBackground:withMessage:")]
		void SendPushMessageAsync (string channel, string message);

		[Static]
		[Export ("sendPushMessageToChannelInBackground:withMessage:block:")]
		void SendPushMessageAsync (string channel, string message, ParseBooleanResult result);

		[Static]
		[Export ("sendPushMessageToChannelInBackground:withMessage:target:selector:")]
		void SendPushMessageAsync (string channel, string message, NSObject target, Selector selector);

		[Export ("sendPush:")]
		bool SendPush (out NSError error);

		[Export ("sendPushInBackground")]
		void SendPushAsync ();

		[Export ("sendPushInBackgroundWithBlock:")]
		void SendPushAsync (ParseBooleanResult result);

		[Export ("sendPushInBackgroundWithTarget:selector:")]
		void SendPushAsync (NSObject target, Selector selector);

		[Static]
		[Export ("sendPushDataToChannel:withData:error:")]
		bool SendPushData (string channel, NSDictionary data, out NSError error);

		[Static]
		[Export ("sendPushDataToChannelInBackground:withData:")]
		void SendPushData (string channel, NSDictionary data);

		[Static]
		[Export ("sendPushDataToChannelInBackground:withData:block:")]
		void SendPushData (string channel, NSDictionary data, ParseBooleanResult result);

		[Static]
		[Export ("sendPushDataToChannelInBackground:withData:target:selector:")]
		void SendPushDataAsync (string channel, NSDictionary data, NSObject target, Selector selector);

		[Static]
		[Export ("handlePush:")]
		void HandlePush (NSDictionary userInfo);

		[Static]
		[Export ("storeDeviceToken:")]
		void StoreDeviceToken (NSObject deviceToken);

		[Static]
		[Export ("getSubscribedChannels:")]
		NSSet GetSubscribedChannels (out NSError error);

		[Static]
		[Export ("getSubscribedChannelsInBackgroundWithBlock:")]
		void GetSubscribedChannelsAsync (ParseSetResult result);

		[Static]
		[Export ("getSubscribedChannelsInBackgroundWithTarget:selector:")]
		void GetSubscribedChannelsAsync (NSObject target, Selector selector);

		[Static]
		[Export ("subscribeToChannel:error:")]
		bool SubscribeToChannel (string channel, out NSError error);

		[Static]
		[Export ("subscribeToChannelInBackground:")]
		void SubscribeToChannelAsync (string channel);

		[Static]
		[Export ("subscribeToChannelInBackground:block:")]
		void SubscribeToChannelAsync (string channel, ParseBooleanResult result);

		[Static]
		[Export ("subscribeToChannelInBackground:target:selector:")]
		void SubscribeToChannelAsync (string channel, NSObject target, Selector selector);

		[Static]
		[Export ("unsubscribeFromChannel:error:")]
		bool UnsubscribeFromChannel (string channel, out NSError error);

		[Static]
		[Export ("unsubscribeFromChannelInBackground:")]
		void UnsubscribeFromChannelAsync (string channel);

		[Static]
		[Export ("unsubscribeFromChannelInBackground:block:")]
		void UnsubscribeFromChannelAsync (string channel, ParseBooleanResult result);

		[Static]
		[Export ("unsubscribeFromChannelInBackground:target:selector:")]
		void UnsubscribeFromChannelAsync (string channel, NSObject target, Selector selector);

	}
	
	[BaseType (typeof(NSObject), Name="PFQuery")]
	public interface ParseQuery
	{
		[Export ("className")]
		string ClassName { get; set; }

		[Export ("maxCacheAge")]
		double MaxCacheAge { get; set; }

		[Static]
		[Export ("queryWithClassName:")]
		ParseQuery FromClassName (string className);

		[Export ("initWithClassName:")]
		IntPtr Constructor (string newClassName);

		[Export ("includeKey:")]
		void IncludeKey (string key);

		[Export ("whereKeyExists:")]
		void WhereKeyExists (string key);

		[Export ("whereKeyDoesNotExist:")]
		void WhereKeyDoesNotExist (string key);

		[Export ("whereKey:equalTo:")]
		void WhereKey (string key, NSObject obj);

		[Export ("whereKey:lessThan:")]
		void WhereKeyLessThan (string key, NSObject obj);

		[Export ("whereKey:lessThanOrEqualTo:")]
		void WhereKeyLessThanOrEqualTo (string key, NSObject obj);

		[Export ("whereKey:greaterThan:")]
		void WhereKeyGreaterThan (string key, NSObject obj);

		[Export ("whereKey:greaterThanOrEqualTo:")]
		void WhereKeyGreaterThanOrEqualTo (string key, NSObject obj);

		[Export ("whereKey:notEqualTo:")]
		void WhereKeyNotEqualTo (string key, NSObject obj);

		[Export ("whereKey:containedIn:")]
		void WhereKeyContainedIn (string key, NSArray array);

		[Export ("whereKey:notContainedIn:")]
		void WhereKeyNotContainedIn (string key, NSArray array);

		[Export ("whereKey:nearGeoPoint:")]
		void WhereKeyNear (string key, ParseGeoPoint geopoint);

		[Export ("whereKey:nearGeoPoint:withinMiles:")]
		void WhereKeyWithinMiles (string key, ParseGeoPoint geopoint, double maxDistance);

		[Export ("whereKey:nearGeoPoint:withinKilometers:")]
		void WhereKeyWithinKilometers (string key, ParseGeoPoint geopoint, double maxDistance);

		[Export ("whereKey:nearGeoPoint:withinRadians:")]
		void WhereKeyWithinRadians (string key, ParseGeoPoint geopoint, double maxDistance);

		[Export ("whereKey:withinGeoBoxFromSouthwest:toNortheast:")]
		void WhereKeyWithinBox (string key, ParseGeoPoint southwest, ParseGeoPoint northeast);

		[Export ("whereKey:matchesRegex:")]
		void WhereKeymatchesRegex (string key, string regex);

		[Export ("whereKey:matchesRegex:modifiers:")]
		void WhereKeymatchesRegex (string key, string regex, string modifiers);

		[Export ("whereKey:containsString:")]
		void WhereKeyContains (string key, string substring);

		[Export ("whereKey:hasPrefix:")]
		void WhereKeyHasPrefix (string key, string prefix);

		[Export ("whereKey:hasSuffix:")]
		void WhereKeyHasSuffix (string key, string suffix);

		[Static]
		[Export ("orQueryWithSubqueries:")]
		ParseQuery OrQueryWithSubqueries (NSArray queries);

		[Export ("whereKey:matchesKey:inQuery:")]
		void WhereKeyInQuery (string key, string keyMatch, ParseQuery query);

		[Export ("whereKey:matchesQuery:")]
		void WhereKeymatchesQuery (string key, ParseQuery query);

		[Export ("whereKey:doesNotMatchQuery:")]
		void WhereKeydoesNotMatchQuery (string key, ParseQuery query);

		[Export ("orderByAscending:")]
		void OrderByAscending (string key);

		[Export ("addAscendingOrder:")]
		void AddAscendingOrder (string key);

		[Export ("orderByDescending:")]
		void OrderByDescending (string key);

		[Export ("addDescendingOrder:")]
		void AddDescendingOrder (string key);

		[Export ("getObjectOfClass:objectId:")]
		ParseObject GetObjectOfClass (string objectClass, string objectId);

		[Static]
		[Export ("getObjectOfClass:objectId:error:")]
		ParseObject GetObjectOfClass (string objectClass, string objectId, out NSError error);

		[Export ("getObjectWithId:")]
		ParseObject GetObject (string objectId);

		[Export ("getObjectWithId:error:")]
		ParseObject GetObject (string objectId, out NSError error);

		[Export ("getObjectInBackgroundWithId:block:")]
		void GetObjectAsync (string objectId, ParseObjectResult result);

		[Export ("getObjectInBackgroundWithId:target:selector:")]
		void GetObjectAsync (string objectId, NSObject target, Selector selector);

		[Export ("getUserObjectWithId:")]
		ParseUser GetUserObject (string objectId);

		[Static]
		[Export ("getUserObjectWithId:error:")]
		ParseUser GetUserObject (string objectId, out NSError error);

		[Export ("findObjects")]
		ParseObject[] FindObjects ();

		[Export ("findObjects:")]
		ParseObject[] FindObjects (out NSError error);

		[Export ("findObjectsInBackgroundWithBlock:")]
		void FindObjectsAsync (ParseArrayResult result);

		[Export ("findObjectsInBackgroundWithTarget:selector:")]
		void FindObjectsAsync (NSObject target, Selector selector);

		[Export ("getFirstObject")]
		ParseObject GetFirstObject ();

		[Export ("getFirstObject:")]
		ParseObject GetFirstObject (out NSError error);

		[Export ("getFirstObjectInBackgroundWithBlock:")]
		void GetFirstObjectAsync (ParseObjectResult result);

		[Export ("getFirstObjectInBackgroundWithTarget:selector:")]
		void GetFirstObjectAsync (NSObject target, Selector selector);

		[Export ("countObjects")]
		int CountObjects ();

		[Export ("countObjects:")]
		int CountObjects (out NSError error);

		[Export ("countObjectsInBackgroundWithBlock:")]
		void CountObjectsAsync (ParseIntegerResult result);

		[Export ("countObjectsInBackgroundWithTarget:selector:")]
		void CountObjectsAsync (NSObject target, Selector selector);

		[Export ("cancel")]
		void Cancel ();

		[Export ("limit")]
		int Limit { get; set; }

		[Export ("skip")]
		int Skip { get; set; }

		[Export ("cachePolicy")]
		ParseCachePolicy CachePolicy { get; set; }

		[Export ("hasCachedResult")]
		bool HasCachedResult ();

		[Export ("clearCachedResult")]
		void ClearCachedResult ();

		[Static]
		[Export ("clearAllCachedResults")]
		void ClearAllCachedResults ();

		[Export ("trace")]
		bool Trace { get; set; }

	}
	
	[BaseType (typeof(NSObject), Name="PFGeoPoint")]
	public interface ParseGeoPoint
	{
		[Export ("latitude")]
		double Latitude { get; set; }

		[Export ("longitude")]
		double Longitude { get; set; }

		[Static]
		[Export ("geoPoint")]
		ParseGeoPoint GeoPoint ();

		[Static]
		[Export ("geoPointWithLatitude:longitude:")]
		ParseGeoPoint FromLatLong (double latitude, double longitude);

		[Export ("distanceInRadiansTo:")]
		double DistanceInRadiansTo (ParseGeoPoint point);

		[Export ("distanceInMilesTo:")]
		double DistanceInMilesTo (ParseGeoPoint point);

		[Export ("distanceInKilometersTo:")]
		double DistanceInKilometersTo (ParseGeoPoint point);

	}

	[BaseType (typeof(ParseObject), Name="PFInstallation")]
	public interface ParseInstallation
	{
		[Static]
		[Export ("currentInstallation")]
		ParseInstallation CurrentInstallation { get; }

		[Static]
		[Export ("query")]
		ParseQuery CreateQuery ();

		[Export ("deviceType")]
		string DeviceType { get; }

		[Export ("installationId")]
		string InstallationId { get; }

		[Export ("deviceToken")]
		string DeviceToken { get; }
		
		[Export ("setDeviceTokenFromData")]
		string SetDeviceToken (NSData deviceToken);

		[Export ("badge")]
		int Badge { get; set; }

		[Export ("timeZone")]
		string TimeZone { get; }

		[Export ("channels")]
		string[] Channels { get; set; }	

	}
	
	[BaseType (typeof(ParseObject), Name="PFUser")]
	public interface ParseUser
	{
		[Export ("sessionToken")]
		string SessionToken { get; set; }

		[Export ("isNew")]
		bool IsNew { get; }

		[Export ("username")]
		string Username { get; set; }

		[Export ("password")]
		string Password { get; set; }

		[Export ("email")]
		string Email { get; set; }

		[Static]
		[Export ("currentUser")]
		ParseUser CurrentUser ();

		[Export ("isAuthenticated")]
		bool IsAuthenticated ();

		[Static]
		[Export ("user")]
		ParseUser User ();

		[Static]
		[Export ("enableAutomaticUser")]
		void EnableAutomaticUser ();

		[Export ("signUp")]
		bool SignUp ();

		[Export ("signUp:")]
		bool SignUp (out NSError error);

		[Export ("signUpInBackground")]
		void SignUpAsync ();

		[Export ("signUpInBackgroundWithBlock:")]
		void SignUpAsync (ParseBooleanResult result);

		[Export ("signUpInBackgroundWithTarget:selector:")]
		void SignUpAsync (NSObject target, Selector selector);

		[Static]
		[Export ("logInWithUsername:password:")]
		ParseUser LogIn (string username, string password);

		[Static]
		[Export ("logInWithUsername:password:error:")]
		ParseUser LogIn (string username, string password, out NSError error);

		[Static]
		[Export ("logInWithUsernameInBackground:password:")]
		void LogInAsync (string username, string password);

		[Static]
		[Export ("logInWithUsernameInBackground:password:target:selector:")]
		void LogInWithAsync (string username, string password, NSObject target, Selector selector);

		[Static]
		[Export ("logInWithUsernameInBackground:password:block:")]
		void LogInAsync (string username, string password, ParseUserResult result);

		[Static]
		[Export ("logOut")]
		void LogOut ();

		[Static]
		[Export ("requestPasswordResetForEmail:")]
		bool RequestPasswordReset (string email);

		[Static]
		[Export ("requestPasswordResetForEmail:error:")]
		bool RequestPasswordReset (string email, out NSError error);

		[Static]
		[Export ("requestPasswordResetForEmailInBackground:")]
		void RequestPasswordResetAsync (string email);

		[Static]
		[Export ("requestPasswordResetForEmailInBackground:target:selector:")]
		void RequestPasswordResetAsync (string email, NSObject target, Selector selector);

		[Static]
		[Export ("requestPasswordResetForEmailInBackground:block:")]
		void RequestPasswordResetAsync (string email, ParseBooleanResult result);

		[Static]
		[Export ("query")]
		ParseQuery Query ();

	}
	
	[BaseType (typeof(NSObject), Name="PFAnonymousUtils")]
	interface ParseAnonymousUtils
	{
		[Static]
		[Export ("logInWithBlock:")]
		void LogInWithBlock (ParseUserResult result);

		[Static]
		[Export ("logInWithTarget:selector:")]
		void LogInWithTargetselector (NSObject target, Selector selector);

		[Static]
		[Export ("isLinkedWithUser:")]
		bool IsLinkedWithUser (ParseUser user);

	}


	#region UI

	[BaseType (typeof(UIScrollView), Name="PFSignUpView")]
	interface ParseSignUpView
	{
		[Export ("logo")]
		UIView Logo { get; set; }

		[Export ("fields")]
		ParseSignUpFields Fields { get; }

		[Export ("usernameField")]
		UITextField UsernameField { get; }

		[Export ("passwordField")]
		UITextField PasswordField { get; }

		[Export ("emailField")]
		UITextField EmailField { get; }

		[Export ("additionalField")]
		UITextField AdditionalField { get; }

		[Export ("signUpButton")]
		UIButton SignUpButton { get; }

		[Export ("dismissButton")]
		UIButton DismissButton { get; }

		[Export ("initWithFields:fields")]
		IntPtr Constructor (ParseSignUpFields fields);

	}
	
	[BaseType (typeof(UIViewController), Name="PFSignUpViewController", Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof(ParseSignUpViewControllerDelegate)})]
	interface ParseSignUpViewController
	{
		[Export ("fields")]
		ParseSignUpFields Fields { get; set; }

		[Export ("signUpView")]
		ParseSignUpView SignUpView { get; }

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		ParseSignUpViewControllerDelegate Delegate { get; set; }

	}

	[BaseType (typeof(NSObject), Name="PFSignUpViewControllerDelegate")]
	[Model]
	interface ParseSignUpViewControllerDelegate
	{
		[Export ("signUpViewController:shouldBeginSignUp:"), DefaultValue (true), DelegateName ("PF_VCDict")]
		bool BeginSignUp (ParseSignUpViewController signUpController, NSDictionary info);

		[Export ("signUpViewController:didSignUpUser:"), EventArgs ("PF_VCUser")]
		void SuccededLogin (ParseSignUpViewController signUpController, ParseUser user);

		[Export ("signUpViewController:didFailToSignUpWithError:"), EventArgs ("PF_VCError")]
		void FailedLogin (ParseSignUpViewController signUpController, NSError error);

		[Export ("signUpViewControllerDidCancelSignUp:"), DelegateName ("PF_VC")]
		void CanceledLogin (ParseSignUpViewController signUpController);

	}
	
	[BaseType (typeof(UIView))]
	//, Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof (PF_EGORefreshTableHeaderDelegate)})]
	interface ParseRefreshTableHeaderView
	{

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		Parse_EGORefreshTableHeaderDelegate Delegate { get; set; }

		[Export ("refreshLastUpdatedDate")]
		void RefreshLastUpdatedDate ();

		[Export ("egoRefreshScrollViewDidScroll:")]
		void DidScroll (UIScrollView scrollView);

		[Export ("egoRefreshScrollViewDidEndDragging:")]
		void DidEndDragging (UIScrollView scrollView);

		[Export ("egoRefreshScrollViewDataSourceDidFinishedLoading:")]
		void DataSourceDidFinishedLoading (UIScrollView scrollView);

	}

	[BaseType (typeof(NSObject), Name="PF_EGORefreshTableHeaderView")]
	[Model]
	interface Parse_EGORefreshTableHeaderDelegate
	{
		[Abstract]
		[Export ("egoRefreshTableHeaderDataSourceIsLoading:")]
		//,DefaultValue(true), DelegateName ("PFView")]
		bool IsLoading (ParseRefreshTableHeaderView view);

		[Abstract]
		[Export ("egoRefreshTableHeaderDataSourceLastUpdated:")]
		//, DefaultValue(null), DelegateName ("PFView")]
		DateTime DataSourceLastUpdated (ParseRefreshTableHeaderView view);

	}
	
	[BaseType (typeof(UIView), Name="PFLogInView")]
	interface ParseLogInView
	{
		[Export ("logo"), NullAllowed]
		UIView Logo { get; set; }

		[Export ("fields")]
		ParseLogInFields Fields { get; }

		[Export ("usernameField")]
		UITextField UsernameField { get; }

		[Export ("passwordField")]
		UITextField PasswordField { get; }

		[Export ("passwordForgottenButton")]
		UIButton PasswordForgottenButton { get; }

		[Export ("logInButton")]
		UIButton LogInButton { get; }

		[Export ("facebookButton")]
		UIButton FacebookButton { get; }

		[Export ("twitterButton")]
		UIButton TwitterButton { get; }

		[Export ("signUpButton")]
		UIButton SignUpButton { get; }

		[Export ("dismissButton")]
		UIButton DismissButton { get; }

		[Export ("initWithFields:fields")]
		IntPtr Constructor (ParseLogInFields fields);

	}
	
	[BaseType (typeof(UIViewController), Name="PFLogInViewController", Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof(ParseLogInViewControllerDelegate)})]
	interface ParseLogInViewController
	{
		[Export ("fields")]
		ParseLogInFields Fields { get; set; }

		[Export ("logInView")]
		ParseLogInView LogInView { get; }

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		ParseLogInViewControllerDelegate Delegate { get; set; }

		[Export ("facebookPermissions")]
		NSArray FacebookPermissions { get; set; }

		[Export ("signUpController")]
		ParseSignUpViewController SignUpController { get; set; }

	}

	[BaseType (typeof(NSObject), Name="PFLogInViewControllerDelegate")]
	[Model]
	interface ParseLogInViewControllerDelegate
	{
		[Export ("logInViewController:shouldBeginLogInWithUsername:password:"),DefaultValue(true), DelegateName ("PFShouldLogin")]
		bool ShouldBeginLogIn (ParseLogInViewController logInController, string username, string password);

		[Export ("logInViewController:didLogInUser:"), EventArgs ("PFDidLogin")]
		void SuccededLogin (ParseLogInViewController logInController, ParseUser user);

		[Export ("logInViewController:didFailToLogInWithError:"), EventArgs ("PFFailedLogin")]
		void FailedLogin (ParseLogInViewController logInController, NSError error);

		[Export ("logInViewControllerDidCancelLogIn:"), DelegateName ("PFCanceledLogin")]
		void CanceledLogin (ParseLogInViewController logInController);

	}
	
	[BaseType (typeof(UITableViewController), Name="PFQueryTableViewController")]
	interface ParseQueryTableViewController
	{
		[Export ("className")]
		string ClassName { get; set; }
		
		[Export ("textKey")]
		string TextKey { get; set;  }
		
		[Export ("imageKey")]
		string ImageKey { get; set;  }
		
		[Export ("placeholderImage")]
		UIImage PlaceholderImage { get; set;  }
		
		[Export ("loadingViewEnabled")]
		bool LoadingViewEnabled { get; set;  }

		[Export ("pullToRefreshEnabled")]
		bool PullToRefreshEnabled { get; set; }

		[Export ("paginationEnabled")]
		bool PaginationEnabled { get; set; }

		[Export ("objectsPerPage")]
		int ObjectsPerPage { get; set; }

		[Export ("isLoading")]
		bool IsLoading { get; set; }

		[Export ("objects")]
		ParseObject[] Objects { get; set; }

		[Export ("initWithStyle:className:")]
		IntPtr Constructor (UITableViewStyle style, string aClassName);

		[Export ("initWithClassName:")]
		IntPtr Constructor (string aClassName);

		[Export ("objectsDidLoad:")]
		void ObjectsDidLoad ([NullAllowed] NSError error);

		[Export ("objectsWillLoad")]
		void ObjectsWillLoad ();

		[Export ("objectAtIndex:")]
		ParseObject ObjectAtIndex (NSIndexPath indexPath);

		[Export ("queryForTable")]
		ParseQuery QueryForTable ();

		[Export ("clear")]
		void Clear ();

		[Export ("loadObjects")]
		void LoadObjects ();

		[Export ("loadObjects:clear:")]
		void LoadObjects (int page, bool clear);

		[Export ("loadNextPage")]
		void LoadNextPage ();

		[Export ("loadObjects:clear:")]
		void LoadObjectsclear (int page, bool clear);

		[Export ("tableView:cellForRowAtIndexPath:object:")]
		UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath, ParseObject obj);

		[Export ("tableView:cellForNextPageAtIndexPath:")]
		UITableViewCell TableViewCellForNextPageAtIndexPath (UITableView tableView, NSIndexPath indexPath);
	}
	
	[BaseType (typeof(UIView), Name="PF_MBProgressHUD", Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof(ParseMBProgressHUDDelegate)})]
	interface ParseMBProgressHUD
	{
		[Export ("customView")]
		UIView CustomView { get; set; }

		[Export ("mode")]
		ParseMBProgressHUDMode Mode { get; set; }

		[Export ("animationType")]
		ParseMBProgressHUDAnimation AnimationType { get; set; }

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		ParseMBProgressHUDDelegate Delegate { get; set; }

		[Export ("labelText")]
		string LabelText { get; set; }

		[Export ("detailsLabelText")]
		string DetailsLabelText { get; set; }

		[Export ("opacity")]
		float Opacity { get; set; }

		[Export ("xOffset")]
		float XOffset { get; set; }

		[Export ("yOffset")]
		float YOffset { get; set; }

		[Export ("margin")]
		float Margin { get; set; }

		[Export ("dimBackground")]
		bool DimBackground { get; set; }

		[Export ("graceTime")]
		float GraceTime { get; set; }

		[Export ("minShowTime")]
		float MinShowTime { get; set; }

		[Export ("taskInProgress")]
		bool TaskInProgress { get; set; }

		[Export ("removeFromSuperViewOnHide")]
		bool RemoveFromSuperViewOnHide { get; set; }

		[Export ("labelFont")]
		UIFont LabelFont { get; set; }

		[Export ("detailsLabelFont")]
		UIFont DetailsLabelFont { get; set; }

		[Export ("progress")]
		float Progress { get; set; }

		[Static]
		[Export ("showHUDAddedTo:animated:")]
		ParseMBProgressHUD ShowHUDAdded (UIView view, bool animated);

		[Static]
		[Export ("hideHUDForView:animated:")]
		bool HideHUDForView (UIView view, bool animated);

		[Export ("initWithWindow:")]
		IntPtr Constructor (UIWindow window);

		[Export ("initWithView:")]
		IntPtr Constructor (UIView view);

		[Export ("show:")]
		void Show (bool animated);

		[Export ("hide:")]
		void Hide (bool animated);

		[Export ("hide:afterDelay:")]
		void Hide (bool animated, double delay);

		[Export ("showWhileExecuting:onTarget:withObject:animated:")]
		void ShowWhileExecuting (Selector method, NSObject target, NSObject obj, bool animated);

	}

	[BaseType (typeof(NSObject), Name="PF_MBProgressHUDDelegate")]
	[Model]
	interface ParseMBProgressHUDDelegate
	{
		[Abstract]
		[Export ("hudWasHidden:"), DelegateName ("PF_MBHidden")]
		void HudWasHidden (ParseMBProgressHUD hud);

	}

	[BaseType (typeof(UIView), Name="PF_MBRoundProgressView")]
	interface ParseMBRoundProgressView
	{
		[Export ("progress")]
		float Progress { get; set; }

	}

	[BaseType (typeof(UIImageView), Name="PFImageView")]
	interface ParseImageView
	{
		[Export ("file")]
		ParseFile File { get; set; }

		[Export ("initWithFrame:")]
		IntPtr Constructor (System.Drawing.RectangleF frame);

		[Export ("initWithImage:")]
		IntPtr Constructor (UIImage image);

		[Export ("initWithImage:highlightedImage")]
		IntPtr Constructor (UIImage image, UIImage highlightedImage);

		[Export ("loadInBackground")]
		void LoadInBackground();

		[Export ("loadInBackground:")]
		void LoadInBackground(ParseImageResult result);
	}

	[BaseType (typeof(UITableViewCell), Name="PFTableViewCell")]
	interface ParseTableViewCell
	{
		[Export ("imageView")]
		ParseImageView ImageView { get; set; }

		[Export ("initWithStyle:reuseIdentifier:")]
		IntPtr Constructor (UITableViewCellStyle style, string reuseIdentifier);
	}


	#endregion //UI

	#region Facebook
	
	[BaseType (typeof(NSObject), Name="PFFacebookUtils")]
	interface ParseFacebookUtils
	{
		[Static]
		[Export ("facebook")]
		ParseFacebook Facebook ();

		[Static]
		[Export ("facebookWithDelegate:")]
		ParseFacebook Facebook (ParseFBSessionDelegate del);

		[Static]
		[Export ("initializeWithApplicationId:")]
		void InitializeWithApplicationId (string appId);

		[Static]
		[Export ("isLinkedWithUser:")]
		bool IsLinkedWithUser (ParseUser user);

		[Static]
		[Export ("logInWithPermissions:block:")]
		void LogInAsync (NSArray permissions, ParseUserResult result);

		[Static]
		[Export ("logInWithPermissions:target:selector:")]
		void LogInAsync (NSArray permissions, NSObject target, Selector selector);

		[Static]
		[Export ("logInWithFacebookId:accessToken:expirationDate:block:")]
		void LogInAsync (string facebookId, string accessToken, NSDate expirationDate, ParseUserResult result);

		[Static]
		[Export ("logInWithFacebookId:accessToken:expirationDate:target:selector:")]
		void LogInAsync (string facebookId, string accessToken, NSDate expirationDate, NSObject target, Selector selector);

		[Static]
		[Export ("linkUser:permissions:")]
		void LinkUser (ParseUser user, NSArray permissions);

		[Static]
		[Export ("linkUser:permissions:block:")]
		void LinkUserAsync (ParseUser user, NSArray permissions, ParseBooleanResult result);

		[Static]
		[Export ("linkUser:permissions:target:selector:")]
		void LinkUserAsync (ParseUser user, NSArray permissions, NSObject target, Selector selector);

		[Static]
		[Export ("linkUser:facebookId:accessToken:expirationDate:block:")]
		void LinkUserAsync (ParseUser user, string facebookId, string accessToken, NSDate expirationDate, ParseBooleanResult result);

		[Static]
		[Export ("linkUser:facebookId:accessToken:expirationDate:target:selector:")]
		void LinkUserAsync (ParseUser user, string facebookId, string accessToken, NSDate expirationDate, NSObject target, Selector selector);

		[Static]
		[Export ("unlinkUser:")]
		bool UnlinkUser (ParseUser user);

		[Static]
		[Export ("unlinkUser:error:")]
		bool UnlinkUser (ParseUser user, out NSError error);

		[Static]
		[Export ("unlinkUserInBackground:")]
		void UnlinkUserAsync (ParseUser user);

		[Static]
		[Export ("unlinkUserInBackground:block:")]
		void UnlinkUserAsync (ParseUser user, ParseBooleanResult result);

		[Static]
		[Export ("unlinkUserInBackground:target:selector:")]
		void UnlinkUserAsync (ParseUser user, NSObject target, Selector selector);

		[Static]
		[Export ("shouldExtendAccessTokenForUser:")]
		bool ShouldExtendAccessTokenForUser (ParseUser user);

		[Static]
		[Export ("extendAccessTokenForUser:target:selector:")]
		void ExtendAccessTokenForUser (ParseUser user, NSObject target, Selector selector);

		[Static]
		[Export ("extendAccessTokenForUser:block:")]
		void ExtendAccessTokenForUserAsync (ParseUser user, ParseBooleanResult result);

		[Static]
		[Export ("extendAccessTokenIfNeededForUser:target:selector:")]
		bool ExtendAccessTokenIfNeeded (ParseUser user, NSObject target, Selector selector);

		[Static]
		[Export ("extendAccessTokenIfNeededForUser:block:")]
		bool ExtendAccessTokenIfNeededAsync (ParseUser user, ParseBooleanResult result);

		[Static]
		[Export ("handleOpenURL:")]
		bool HandleOpenURL (NSUrl url);

	}
	
	[BaseType (typeof(UIView), Name="PF_FBDialog", Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof(ParseFBDialogDelegate)})]
	interface ParseFBDialog
	{
		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		ParseFBDialogDelegate Delegate { get; set; }

		[Export ("params")]
		NSMutableDictionary Params { get; set; }

		[Export ("getStringFromUrl:needle:")]
		string GetStringFromUrl (string url, string needle);

		[Export ("initWithURL:loadingURLparams:paramsisViewInvisible:isViewInvisiblefrictionlessSettings:frictionlessSettingsdelegate:delegate")]
		IntPtr Constructor (string loadingURL, NSMutableDictionary parameters, bool isViewInvisible, ParseFBFrictionlessRequestSettings frictionlessSettings, ParseFBDialogDelegate del);

		[Export ("show")]
		void Show ();

		[Export ("load")]
		void Load ();

		[Export ("loadURL:get:")]
		void LoadURLget (string url, NSDictionary getParams);

		[Export ("dismissWithSuccess:animated:")]
		void DismissWithSuccess (bool success, bool animated);

		[Export ("dismissWithError:animated:")]
		void DismissWithError (NSError error, bool animated);

		[Export ("dialogWillAppear")]
		void DialogWillAppear ();

		[Export ("dialogWillDisappear")]
		void DialogWillDisappear ();

		[Export ("dialogDidSucceed:")]
		void DialogDidSucceed (NSUrl url);

		[Export ("dialogDidCancel:")]
		void DialogDidCancel (NSUrl url);

	}

	[BaseType (typeof(NSObject), Name="PFFBDialogDelegate")]
	[Model]
	interface ParseFBDialogDelegate
	{
		[Abstract]
		[Export ("dialogDidComplete:"), DelegateName ("ParseFBDialogArg")]
		void DidComplete (ParseFBDialog dialog);

		[Abstract]
		[Export ("dialogCompleteWithUrl:"), DelegateName ("PFUrl")]
		void CompleteWithUrl (NSUrl url);

		[Abstract]
		[Export ("dialogDidNotCompleteWithUrl:"), DelegateName ("PFUrl")]
		void DidNotCompleteWithUrl (NSUrl url);

		[Abstract]
		[Export ("dialogDidNotComplete:"), DelegateName ("ParseFBDialogArg")]
		void DidNotComplete (ParseFBDialog dialog);

		[Abstract]
		[Export ("dialog:didFailWithError:"), EventArgs ("ParseFBDialogError")]
		void DidFail (ParseFBDialog dialog, NSError error);

		[Abstract]
		[Export ("dialog:shouldOpenURLInExternalBrowser:"), DefaultValue(true), DelegateName ("ParseFBDialogUrl")]
		bool ShouldOpenUrlInExternalBrowser (ParseFBDialog dialog, NSUrl url);

	}
	
	[BaseType (typeof(NSObject), Name="PF_FBFrictionlessRequestSettings")]
	interface ParseFBFrictionlessRequestSettings
	{
		[Export ("enabled")]
		bool Enabled { get; }

		[Export ("enableWithFacebook:")]
		void EnableWithFacebook (ParseFacebook facebook);

		[Export ("reloadRecipientCacheWithFacebook:")]
		void ReloadRecipientCacheWithFacebook (ParseFacebook facebook);

		[Export ("updateRecipientCacheWithRecipients:")]
		void UpdateRecipientCacheWithRecipients (string[] ids);

		[Export ("isFrictionlessEnabledForRecipient:")]
		bool IsFrictionlessEnabledForRecipient (string fbid);

		[Export ("isFrictionlessEnabledForRecipients:")]
		bool IsFrictionlessEnabledForRecipients (string[] fbids);

	}
	
	[BaseType (typeof(NSObject), Name="PF_FBRequest", Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof(ParseFBRequestDelegate)})]
	interface ParseFBRequest
	{
		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		ParseFBRequestDelegate Delegate { get; set; }

		[Export ("url")]
		string Url { get; set; }

		[Export ("httpMethod")]
		string HttpMethod { get; set; }

		[Export ("params")]
		NSMutableDictionary Params { get; set; }

		[Export ("connection")]
		NSUrlConnection Connection { get; set; }

		[Export ("responseText")]
		NSMutableData ResponseText { get; set; }

		[Export ("state")]
		ParseFBRequestState State { get; }

		[Export ("sessionDidExpire")]
		bool SessionDidExpire { get; }

		[Export ("error")]
		NSError Error { get; set; }

		[Static]
		[Export ("serializeURL:params:")]
		string SerializeURL (string baseUrl, NSDictionary parameters);

		[Static]
		[Export ("serializeURL:params:httpMethod:")]
		string SerializeURL (string baseUrl, NSDictionary parameters, string httpMethod);

		[Static]
		[Export ("getRequestWithParams:paramshttpMethod:httpMethoddelegate:requestURL:url")]
		ParseFBRequest GetRequest (NSMutableDictionary parameters, string httpMethod, ParseFBRequestDelegate del, string requestURL);

		[Export ("loading")]
		bool Loading ();

		[Export ("connect")]
		void Connect ();

	}

	[BaseType (typeof(NSObject), Name="PF_FBRequestDelegate")]
	[Model]
	interface ParseFBRequestDelegate
	{
		[Abstract]
		[Export ("requestLoading:"), DelegateName ("ParseFBRequest")]
		void RequestLoading (ParseFBRequest request);

		[Abstract]
		[Export ("request:didReceiveResponse:"), EventArgs ("ParseFBRequestResp")]
		void DidReceiveResponse (ParseFBRequest request, NSUrlResponse response);

		[Abstract]
		[Export ("request:didFailWithError:"), EventArgs ("ParseFBRequestError")]
		void DidFail (ParseFBRequest request, NSError error);

		[Abstract]
		[Export ("request:didLoad:"), EventArgs ("ParseFBRequestObj")]
		void DidLoad (ParseFBRequest request, NSObject result);

		[Abstract]
		[Export ("request:didLoadRawResponse:"), EventArgs ("ParseFBRequestData")]
		void DidLoadRawResponse (ParseFBRequest request, NSData data);

	}
	
	[BaseType (typeof(NSObject), Name="PF_Facebook")]
	//, Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof (ParseFBSessionDelegate)})]
	interface ParseFacebook
	{
		[Export ("accessToken")]
		string AccessToken { get; set; }

		[Export ("expirationDate")]
		NSDate ExpirationDate { get; set; }

		[Export ("sessionDelegate"), NullAllowed]
		ParseFBSessionDelegate SessionDelegate { get; set; }

		//[Export ("sessionDelegate"), NullAllowed]
		//NSObject WeakDelegate { get; set; }

		//[Wrap ("WeakDelegate")]
		//ParseFBSessionDelegate SessionDelegate { get; set; }

		[Export ("urlSchemeSuffix")]
		string UrlSchemeSuffix { get; set; }

		[Export ("isFrictionlessRequestsEnabled")]
		bool IsFrictionlessRequestsEnabled { [Bind ("isFrictionlessRequestsEnabled")] get; }

		[Export ("initWithAppId:andDelegate:")]
		IntPtr Constructor (string appId, ParseFBSessionDelegate del);

		[Export ("initWithAppId:urlSchemeSuffix:andDelegate:")]
		IntPtr Constructor (string appId, string urlSchemeSuffix, ParseFBSessionDelegate del);

		[Export ("authorize:")]
		void Authorize (NSArray permissions);

		[Export ("extendAccessToken")]
		void ExtendAccessToken ();

		[Export ("extendAccessTokenIfNeeded")]
		void ExtendAccessTokenIfNeeded ();

		[Export ("shouldExtendAccessToken")]
		bool ShouldExtendAccessToken ();

		[Export ("handleOpenURL:")]
		bool HandleOpenURL (NSUrl url);

		[Export ("logout")]
		void Logout ();

		[Export ("logout:")]
		void Logout (ParseFBSessionDelegate del);

		[Export ("requestWithParams:andDelegate:")]
		ParseFBRequest Request (NSMutableDictionary parameters, ParseFBRequestDelegate del);

		[Export ("requestWithMethodName:andParams:andHttpMethod:andDelegate:")]
		ParseFBRequest Request (string methodName, NSMutableDictionary parameters, string httpMethod, ParseFBRequestDelegate del);

		[Export ("requestWithGraphPath:andDelegate:")]
		ParseFBRequest RequestWithGraph (string graphPath, ParseFBRequestDelegate del);

		[Export ("requestWithGraphPath:andParams:andDelegate:")]
		ParseFBRequest RequestWithGraph (string graphPath, NSMutableDictionary parameters, ParseFBRequestDelegate del);

		[Export ("requestWithGraphPath:andParams:andHttpMethod:andDelegate:")]
		ParseFBRequest RequestWithGraph (string graphPath, NSMutableDictionary parameters, string httpMethod, ParseFBRequestDelegate del);

		[Export ("dialog:andDelegate:")]
		void Dialog (string action, ParseFBDialogDelegate del);

		[Export ("dialog:andParams:andDelegate:")]
		void Dialog (string action, NSMutableDictionary parameters, ParseFBDialogDelegate del);

		[Export ("isSessionValid")]
		bool IsSessionValid ();

		[Export ("enableFrictionlessRequests")]
		void EnableFrictionlessRequests ();

		[Export ("reloadFrictionlessRecipientCache")]
		void ReloadFrictionlessRecipientCache ();

		[Export ("isFrictionlessEnabledForRecipient:")]
		bool IsFrictionlessEnabledForRecipient (NSObject fbid);

		[Export ("isFrictionlessEnabledForRecipients:")]
		bool IsFrictionlessEnabledForRecipients (NSArray fbids);

	}

	[BaseType (typeof(NSObject), Name="PF_FBSessionDelegate")]
	[Model]
	interface ParseFBSessionDelegate
	{
		[Abstract]
		[Export ("fbDidLogin")]
		void DidLogin ();

		[Abstract]
		[Export ("fbDidNotLogin:"), DelegateName ("PFBool")]
		void DidNotLogin (bool cancelled);

		[Abstract]
		[Export ("fbDidExtendToken:expiresAt:"), DelegateName ("PFStringDate")]
		void DidExtendToken (string accessToken, NSDate expiresAt);

		[Abstract]
		[Export ("fbDidLogout")]
		void DidLogout ();

		[Abstract]
		[Export ("fbSessionInvalidated")]
		void SessionInvalidated ();

	}
	
	[BaseType (typeof(ParseFBDialog), Name="PF_FBLoginDialog")]
	interface ParseFBLoginDialog
	{
		[Export ("initWithURL:loginURLloginParams:delegate:")]
		IntPtr Constructor (string url, NSMutableDictionary parameters, ParseFBLoginDialogDelegate del);

	}

	[BaseType (typeof(NSObject), Name="PF_FBLoginDialogDelegate")]
	[Model]
	interface ParseFBLoginDialogDelegate
	{
		[Abstract]
		[Export ("fbDialogLogin:expirationDate:")]
		void Login (string token, NSDate expirationDate);

		[Abstract]
		[Export ("fbDialogNotLogin:")]
		void NotLogin (bool cancelled);

	}


	#endregion //Facebook

	#region Twitter
	
	[BaseType (typeof(NSObject), Name="PFTwitterUtils")]
	interface ParseTwitterUtils
	{
		[Static]
		[Export ("twitter")]
		ParseTwitter Twitter ();

		[Static]
		[Export ("initializeWithConsumerKey:consumerSecret:")]
		void Initialize (string consumerKey, string consumerSecret);

		[Static]
		[Export ("isLinkedWithUser:")]
		bool IsLinkedWithUser (ParseUser user);

		[Static]
		[Export ("logInWithBlock:")]
		void LogInAsync (ParseUserResult result);

		[Static]
		[Export ("logInWithTarget:selector:")]
		void LogIn (NSObject target, Selector selector);

		[Static]
		[Export ("logInWithTwitterId:screenName:authToken:authTokenSecret:block:")]
		void LogInWithTwitterIdAsync (string twitterId, string screenName, string authToken, string authTokenSecret, ParseUserResult result);

		[Static]
		[Export ("logInWithTwitterId:screenName:authToken:authTokenSecret:target:selector:")]
		void LogInWithTwitterId (string twitterId, string screenName, string authToken, string authTokenSecret, NSObject target, Selector selector);

		[Static]
		[Export ("linkUser:")]
		void LinkUser (ParseUser user);

		[Static]
		[Export ("linkUser:block:")]
		void LinkUserAsync (ParseUser user, ParseBooleanResult result);

		[Static]
		[Export ("linkUser:target:selector:")]
		void LinkUserAsync (ParseUser user, NSObject target, Selector selector);

		[Static]
		[Export ("linkUser:twitterId:screenName:authToken:authTokenSecret:block:")]
		void LinkUserAsync (ParseUser user, string twitterId, string screenName, string authToken, string authTokenSecret, ParseBooleanResult result);

		[Static]
		[Export ("linkUser:twitterId:screenName:authToken:authTokenSecret:target:selector:")]
		void LinkUserAsync (ParseUser user, string twitterId, string screenName, string authToken, string authTokenSecret, NSObject target, Selector selector);

		[Static]
		[Export ("unlinkUser:")]
		bool UnlinkUser (ParseUser user);

		[Static]
		[Export ("unlinkUser:error:")]
		bool UnlinkUser (ParseUser user, out NSError error);

		[Static]
		[Export ("unlinkUserInBackground:")]
		void UnlinkUserAsync (ParseUser user);

		[Static]
		[Export ("unlinkUserInBackground:block:")]
		void UnlinkUserAsync (ParseUser user, ParseBooleanResult result);

		[Static]
		[Export ("unlinkUserInBackground:target:selector:")]
		void UnlinkUserAsync (ParseUser user, NSObject target, Selector selector);

	}
	
	[BaseType (typeof(NSObject), Name="PF_Twitter")]
	interface ParseTwitter
	{
		[Export ("consumerKey")]
		string ConsumerKey { get; set; }

		[Export ("consumerSecret")]
		string ConsumerSecret { get; set; }

		[Export ("authToken")]
		string AuthToken { get; set; }

		[Export ("authTokenSecret")]
		string AuthTokenSecret { get; set; }

		[Export ("userId")]
		string UserId { get; set; }

		[Export ("screenName")]
		string ScreenName { get; set; }

		[Export ("authorizeWithSuccess:failure:error:cancel:")]
		void AuthorizeAsync (Action success, ParseErrorResult error, Action failed);

		[Export ("signRequest:")]
		void SignRequest (NSMutableUrlRequest request);

	}

	#endregion //Twitter
}
