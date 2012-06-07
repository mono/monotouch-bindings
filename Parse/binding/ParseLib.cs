using System;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace ParseLib
{

	public delegate void PFBooleanResult (bool succeeded, NSError error);
	public delegate void PFIntegerResult (int number, NSError error);
	public delegate void PFArrayResult (NSArray objects, NSError error);
	public delegate void PFObjectResult (PFObject theObject, NSError error);
	public delegate void PFSetResult(NSSet channels, NSError error);
	public delegate void PFUserResult (PFUser user, NSError error);
	public delegate void PFDataResult (NSData data, NSError error);
	public delegate void PFDataStreamResult (NSInputStream data, NSError error);
	public delegate void PFErrorResult(NSError error);
	public delegate void PFProgress (int percentDone);


	[BaseType (typeof (NSObject))]
	public interface Parse {

		[Static]
		[Export ("setApplicationId:clientKey:")]
		void SetApplicationIdclientKey (string applicationId, string clientKey);

		[Static]
		[Export ("offlineMessagesEnabled:")]
		void OfflineMessagesEnabled (bool enabled);

		[Static]
		[Export ("errorMessagesEnabled:")]
		void ErrorMessagesEnabled (bool enabled);

		[Static]
		[Export ("getApplicationId")]
		string ApplicationId{get;}

		[Static]
		[Export ("getClientKey")]
		string ClientKey{get;}


	}
	
	
	[BaseType (typeof (NSObject))]
	public interface PFACL {
		[Static]
		[Export ("ACL")]
		PFACL ACL ();

		[Static]
		[Export ("ACLWithUser:")]
		PFACL ACL (PFUser user);

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
		void SetReadAccess (bool allowed, PFUser user);

		[Export ("getReadAccessForUser:")]
		bool GetReadAccess (PFUser user);

		[Export ("setWriteAccess:forUser:")]
		void SetWriteAccess (bool allowed, PFUser user);

		[Export ("getWriteAccessForUser:")]
		bool GetWriteAccess (PFUser user);

		[Export ("getReadAccessForRoleWithName:")]
		bool GetReadAccessForRoleName (string name);

		[Export ("setReadAccess:forRoleWithName:")]
		void SetReadAccessforRoleName (bool allowed, string name);

		[Export ("getWriteAccessForRoleWithName:")]
		bool GetWriteAccessForRoleName (string name);

		[Export ("setWriteAccess:forRoleWithName:")]
		void SetWriteAccessforRoleName (bool allowed, string name);

		[Export ("getReadAccessForRole:")]
		bool GetReadAccess (PFRole role);

		[Export ("setReadAccess:forRole:")]
		void SetReadAccess (bool allowed, PFRole role);

		[Export ("getWriteAccessForRole:")]
		bool GetWriteAccess (PFRole role);

		[Export ("setWriteAccess:forRole:")]
		void SetWriteAccess (bool allowed, PFRole role);

		[Static]
		[Export ("setDefaultACL:withAccessForCurrentUser:")]
		void SetDefaultACLAccess (PFACL acl, bool currentUserAccess);

	}


	[BaseType (typeof (NSObject))]
	public interface PFFile {
		[Export ("name")]
		string Name { get;  }

		[Export ("url")]
		string Url { get;  }

		[Export ("isDirty")]
		bool IsDirty { get;  }

		[Export ("isDataAvailable")]
		bool IsDataAvailable { get;  }

		[Static]
		[Export ("fileWithData:")]
		PFFile FromData (NSData data);

		[Static]
		[Export ("fileWithName:data:")]
		PFFile FromData (string name, NSData data);

		[Static]
		[Export ("fileWithName:contentsAtPath:")]
		PFFile FromPath (string name, string path);

		[Export ("save")]
		bool Save ();

		[Export ("save:")]
		bool Save (out NSError error);

		[Export ("saveInBackground")]
		void SaveAsync ();

		[Export ("saveInBackgroundWithBlock:")]
		void SaveAsync (PFBooleanResult result);

		[Export ("saveInBackgroundWithBlock:progressBlock:")]
		void SaveInBackgroundWithBlockprogressBlock (PFBooleanResult result, PFProgress progress);

		[Export ("saveInBackgroundWithTarget:selector:")]
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
		void GetDataAsync (PFDataResult result);

		[Export ("getDataStreamInBackgroundWithBlock:")]
		void GetDataStreamAsync (PFDataStreamResult block);

		[Export ("getDataInBackgroundWithBlock:progressBlock:")]
		void GetDataAsync (PFDataResult result, PFProgress progress);

		[Export ("getDataStreamInBackgroundWithBlock:progressBlock:")]
		void GetDataStreamAsync (PFDataStreamResult result, PFProgress progress);

		[Export ("getDataInBackgroundWithTarget:selector:")]
		void GetDataAsync (NSObject target, Selector selector);

		[Export ("cancel")]
		void Cancel ();

	}

	[BaseType (typeof (PFObject))]
	public interface PFRole {
		[Export ("initWithName:")]
		PFRole InitWithName (string name);

		[Export ("initWithName:acl:")]
		PFRole InitWithNameacl (string name, PFACL acl);

		[Static]
		[Export ("roleWithName:")]
		PFRole RoleWithName (string name);

		[Static]
		[Export ("roleWithName:acl:")]
		PFRole RoleWithNameacl (string name, PFACL acl);

		[Export ("name")]
		string name {get;set;}

		[Export ("users")]
		PFRelation Users ();

		[Export ("roles")]
		PFRelation Roles ();

		[Export ("query")]
		PFQuery Query ();

	}

	
	[BaseType (typeof (NSObject))]
	public interface PFRelation {
		[Export ("targetClass")]
		string TargetClass { get; set;  }

		[Export ("key")]
		string Key { get;  }

		[Export ("query")]
		PFQuery Query ();

		[Export ("addObject:")]
		void AddObject (PFObject obj);

		[Export ("removeObject:")]
		void RemoveObject (PFObject obj);

	}


	[BaseType (typeof (NSObject))]
	public interface PFObject {

		[Static]
		[Export ("objectWithClassName:")]
		PFObject FromName (string className);

		[Static]
		[Export ("objectWithoutDataWithClassName:objectId:")]
		PFObject FromName (string className, string objectId);

		[Export ("initWithClassName:")]
		IntPtr Constructor (string newClassName);


		[Export ("objectId")]
		string ObjectId {get;set;}

		[Export ("updatedAt")]
		NSDate UpdatedAt { get;  }

		[Export ("createdAt")]
		NSDate CreatedAt { get;  }

		[Export ("className")]
		string ClassName { get;  }

		[Export ("ACL")]
		PFACL ACL { get; set;  }

		[Export ("allKeys")]
		string[] AllKeys {get;}

		[Export ("objectForKey:")]
		NSObject ObjectForKey (string key);

		[Export ("setObject:forKey:")]
		void SetObjectforKey (NSObject value, string key);

		[Export ("removeObjectForKey:")]
		void RemoveObjectForKey (string key);

		[Export ("relationforKey:")]
		PFRelation RelationforKey (string key);

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
		void SaveAsync (PFBooleanResult result);

		[Export ("saveInBackgroundWithTarget:selector:")]
		void SaveAsync (NSObject target, Selector selector);

		[Export ("saveEventually")]
		void SaveEventually ();

		[Export ("saveAll:")]
		bool SaveAll (PFObject[] objects);

		[Static]
		[Export ("saveAll:error:")]
		bool SaveAll (PFObject[] objects,out NSError error);

		[Static]
		[Export ("saveAllInBackground:")]
		void SaveAllAsync (PFObject[] objects);

		[Static]
		[Export ("saveAllInBackground:block:")]
		void SaveAllAsync (PFObject[] objects, PFBooleanResult result);

		[Static]
		[Export ("saveAllInBackground:target:selector:")]
		void SaveAllAsync (PFObject[] objects, NSObject target, Selector selector);

		[Export ("isDataAvailable")]
		bool IsDataAvailable ();

		[Export ("refresh")]
		void Refresh ();

		[Export ("refresh:")]
		void Refresh (out NSError error);

		[Export ("refreshInBackgroundWithBlock:")]
		void RefreshAsync (PFObjectResult result);

		[Export ("refreshInBackgroundWithTarget:selector:")]
		void RefreshAsync (NSObject target, Selector selector);

		[Export ("fetch")]
		void Fetch ();

		[Export ("fetch:")]
		void Fetch (out NSError error);

		[Export ("fetchIfNeeded")]
		PFObject FetchIfNeeded ();

		[Export ("fetchIfNeeded:")]
		PFObject FetchIfNeeded (out NSError error);

		[Export ("fetchInBackgroundWithBlock:")]
		void FetchAsync (PFObjectResult result);

		[Export ("fetchInBackgroundWithTarget:selector:")]
		void FetchAsync (NSObject target, Selector selector);

		[Export ("fetchIfNeededInBackgroundWithBlock:")]
		void FetchIfNeededAsync (PFObjectResult result);

		[Export ("fetchIfNeededInBackgroundWithTarget:selector:")]
		void FetchIfNeededAsync (NSObject target, Selector selector);

		[Static]
		[Export ("fetchAll:")]
		void FetchAll (PFObject[] objects);

		[Static]
		[Export ("fetchAll:error:")]
		void FetchAll (PFObject[] objects,out NSError error);

		[Static]
		[Export ("fetchAllIfNeeded:")]
		void FetchAllIfNeeded (PFObject[] objects);

		[Static]
		[Export ("fetchAllIfNeeded:error:")]
		void FetchAllIfNeeded (PFObject[] objects,out NSError error);

		[Static]
		[Export ("fetchAllInBackground:block:")]
		void FetchAllAsync (PFObject[] objects, PFArrayResult result);

		[Static]
		[Export ("fetchAllInBackground:target:selector:")]
		void FetchAllAsync (PFObject[] objects, NSObject target, Selector selector);

		[Static]
		[Export ("fetchAllIfNeededInBackground:block:")]
		void FetchAllIfNeededAsync (PFObject[] objects, PFArrayResult result);

		[Static]
		[Export ("fetchAllIfNeededInBackground:target:selector:")]
		void FetchAllIfNeededAsync (PFObject[] objects, NSObject target, Selector selector);

		[Export ("delete")]
		bool Delete ();

		[Export ("delete:")]
		bool Delete (out NSError error);

		[Export ("deleteInBackground")]
		void DeleteInBackground ();

		[Export ("deleteInBackgroundWithBlock:")]
		void DeleteAsync (PFBooleanResult result);

		[Export ("deleteInBackgroundWithTarget:selector:")]
		void DeleteAsync (NSObject target, Selector selector);

		[Export ("deleteEventually")]
		void DeleteEventually ();

	}


	[BaseType (typeof (NSObject))]
	public interface PFPush {
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
		bool SendPushMessage (string channel, string message,out  NSError error);

		[Static]
		[Export ("sendPushMessageToChannelInBackground:withMessage:")]
		void SendPushMessageAsync (string channel, string message);

		[Static]
		[Export ("sendPushMessageToChannelInBackground:withMessage:block:")]
		void SendPushMessageAsync (string channel, string message, PFBooleanResult result);

		[Static]
		[Export ("sendPushMessageToChannelInBackground:withMessage:target:selector:")]
		void SendPushMessageAsync (string channel, string message, NSObject target, Selector selector);

		[Export ("sendPush:")]
		bool SendPush (out NSError error);

		[Export ("sendPushInBackground")]
		void SendPushAsync ();

		[Export ("sendPushInBackgroundWithBlock:")]
		void SendPushAsync (PFBooleanResult result);

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
		void SendPushData (string channel, NSDictionary data, PFBooleanResult result);

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
		void GetSubscribedChannelsAsync (PFSetResult result);

		[Static]
		[Export ("getSubscribedChannelsInBackgroundWithTarget:selector:")]
		void GetSubscribedChannelsAsync (NSObject target, Selector selector);

		[Static]
		[Export ("subscribeToChannel:error:")]
		bool SubscribeToChannel (string channel,out NSError error);

		[Static]
		[Export ("subscribeToChannelInBackground:")]
		void SubscribeToChannelAsync (string channel);

		[Static]
		[Export ("subscribeToChannelInBackground:block:")]
		void SubscribeToChannelAsync (string channel, PFBooleanResult result);

		[Static]
		[Export ("subscribeToChannelInBackground:target:selector:")]
		void SubscribeToChannelAsync (string channel, NSObject target, Selector selector);

		[Static]
		[Export ("unsubscribeFromChannel:error:")]
		bool UnsubscribeFromChannel (string channel,out NSError error);

		[Static]
		[Export ("unsubscribeFromChannelInBackground:")]
		void UnsubscribeFromChannelAsync (string channel);

		[Static]
		[Export ("unsubscribeFromChannelInBackground:block:")]
		void UnsubscribeFromChannelAsync (string channel, PFBooleanResult result);

		[Static]
		[Export ("unsubscribeFromChannelInBackground:target:selector:")]
		void UnsubscribeFromChannelAsync (string channel, NSObject target, Selector selector);

	}

	
	[BaseType (typeof (NSObject))]
	public interface PFQuery {
		[Export ("className")]
		string ClassName { get; set;  }

		[Export ("maxCacheAge")]
		double MaxCacheAge { get; set;  }

		[Static]
		[Export ("queryWithClassName:")]
		PFQuery FromClassNAme (string className);

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
		void WhereKeyNear (string key, PFGeoPoint geopoint);

		[Export ("whereKey:nearGeoPoint:withinMiles:")]
		void WhereKeyWithinMiles (string key, PFGeoPoint geopoint, double maxDistance);

		[Export ("whereKey:nearGeoPoint:withinKilometers:")]
		void WhereKeyWithinKilometers (string key, PFGeoPoint geopoint, double maxDistance);

		[Export ("whereKey:nearGeoPoint:withinRadians:")]
		void WhereKeyWithinRadians (string key, PFGeoPoint geopoint, double maxDistance);

		[Export ("whereKey:withinGeoBoxFromSouthwest:toNortheast:")]
		void WhereKeyWithinBox (string key, PFGeoPoint southwest, PFGeoPoint northeast);

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
		PFQuery OrQueryWithSubqueries (NSArray queries);

		[Export ("whereKey:matchesQuery:")]
		void WhereKeymatchesQuery (string key, PFQuery query);

		[Export ("whereKey:doesNotMatchQuery:")]
		void WhereKeydoesNotMatchQuery (string key, PFQuery query);

		[Export ("orderByAscending:")]
		void OrderByAscending (string key);

		[Export ("addAscendingOrder:")]
		void AddAscendingOrder (string key);

		[Export ("orderByDescending:")]
		void OrderByDescending (string key);

		[Export ("addDescendingOrder:")]
		void AddDescendingOrder (string key);

		[Export ("getObjectOfClass:objectId:")]
		PFObject GetObjectOfClass (string objectClass, string objectId);

		[Static]
		[Export ("getObjectOfClass:objectId:error:")]
		PFObject GetObjectOfClass (string objectClass, string objectId,out NSError error);

		[Export ("getObjectWithId:")]
		PFObject GetObject (string objectId);

		[Export ("getObjectWithId:error:")]
		PFObject GetObject (string objectId, out NSError error);

		[Export ("getObjectInBackgroundWithId:block:")]
		void GetObjectAsync (string objectId, PFObjectResult result);

		[Export ("getObjectInBackgroundWithId:target:selector:")]
		void GetObjectAsync (string objectId, NSObject target, Selector selector);

		[Export ("getUserObjectWithId:")]
		PFUser GetUserObject (string objectId);

		[Static]
		[Export ("getUserObjectWithId:error:")]
		PFUser GetUserObject (string objectId,out NSError error);

		[Export ("findObjects")]
		PFObject[] FindObjects ();

		[Export ("findObjects:")]
		PFObject[] FindObjects (out NSError error);

		[Export ("findObjectsInBackgroundWithBlock:")]
		void FindObjectsAsync (PFArrayResult result);

		[Export ("findObjectsInBackgroundWithTarget:selector:")]
		void FindObjectsAsync (NSObject target, Selector selector);

		[Export ("getFirstObject")]
		PFObject GetFirstObject ();

		[Export ("getFirstObject:")]
		PFObject GetFirstObject (out NSError error);

		[Export ("getFirstObjectInBackgroundWithBlock:")]
		void GetFirstObjectAsync (PFObjectResult result);

		[Export ("getFirstObjectInBackgroundWithTarget:selector:")]
		void GetFirstObjectAsync (NSObject target, Selector selector);

		[Export ("countObjects")]
		int CountObjects ();

		[Export ("countObjects:")]
		int CountObjects (out NSError error);

		[Export ("countObjectsInBackgroundWithBlock:")]
		void CountObjectsAsync(PFIntegerResult result);

		[Export ("countObjectsInBackgroundWithTarget:selector:")]
		void CountObjectsAsync (NSObject target, Selector selector);

		[Export ("cancel")]
		void Cancel ();

		[Export ("limit")]
		int Limit {get;set;}

		[Export ("skip")]
		int Skip {get;set;}


		[Export ("cachePolicy")]
		PFCachePolicy CachePolicy {get;set;}

		[Export ("hasCachedResult")]
		bool HasCachedResult ();

		[Export ("clearCachedResult")]
		void ClearCachedResult ();

		[Static]
		[Export ("clearAllCachedResults")]
		void ClearAllCachedResults ();

		[Export ("trace")]
		bool Trace {get;set;}

	}

	
	[BaseType (typeof (NSObject))]
	public interface PFGeoPoint {
		[Export ("latitude")]
		double Latitude { get; set;  }

		[Export ("longitude")]
		double Longitude { get; set;  }

		[Static]
		[Export ("geoPoint")]
		PFGeoPoint GeoPoint ();

		[Static]
		[Export ("geoPointWithLatitude:longitude:")]
		PFGeoPoint FromLatLong (double latitude, double longitude);

		[Export ("distanceInRadiansTo:")]
		double DistanceInRadiansTo (PFGeoPoint point);

		[Export ("distanceInMilesTo:")]
		double DistanceInMilesTo (PFGeoPoint point);

		[Export ("distanceInKilometersTo:")]
		double DistanceInKilometersTo (PFGeoPoint point);

	}

	
	[BaseType (typeof (PFObject))]
	public interface PFUser {
		[Export ("sessionToken")]
		string SessionToken { get; set;  }

		[Export ("isNew")]
		bool IsNew { get;  }

		[Export ("username")]
		string Username { get; set;  }

		[Export ("password")]
		string Password { get; set;  }

		[Export ("email")]
		string Email { get; set;  }

		[Static]
		[Export ("currentUser")]
		PFUser CurrentUser ();

		[Export ("isAuthenticated")]
		bool IsAuthenticated ();

		[Static]
		[Export ("user")]
		PFUser User ();

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
		void SignUpAsync (PFBooleanResult result);

		[Export ("signUpInBackgroundWithTarget:selector:")]
		void SignUpAsync (NSObject target, Selector selector);

		[Static]
		[Export ("logInWithUsername:password:")]
		PFUser LogIn (string username, string password);

		[Static]
		[Export ("logInWithUsername:password:error:")]
		PFUser LogIn (string username, string password, out NSError error);

		[Static]
		[Export ("logInWithUsernameInBackground:password:")]
		void LogInAsync (string username, string password);

		[Static]
		[Export ("logInWithUsernameInBackground:password:target:selector:")]
		void LogInWithAsync (string username, string password, NSObject target, Selector selector);

		[Static]
		[Export ("logInWithUsernameInBackground:password:block:")]
		void LogInAsync (string username, string password, PFUserResult result);

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
		void RequestPasswordResetAsync (string email, PFBooleanResult result);

		[Static]
		[Export ("query")]
		PFQuery Query ();

	}

	
	[BaseType (typeof (NSObject))]
	interface PFAnonymousUtils {
		[Static]
		[Export ("logInWithBlock:")]
		void LogInWithBlock (PFUserResult result);

		[Static]
		[Export ("logInWithTarget:selector:")]
		void LogInWithTargetselector (NSObject target, Selector selector);

		[Static]
		[Export ("isLinkedWithUser:")]
		bool IsLinkedWithUser (PFUser user);

	}


	#region UI

	[BaseType (typeof (UIScrollView))]
	interface PFSignUpView {
		[Export ("logo")]
		UIView Logo { get; set;  }

		[Export ("fields")]
		PFSignUpFields Fields { get;  }

		[Export ("usernameField")]
		UITextField UsernameField { get;  }

		[Export ("passwordField")]
		UITextField PasswordField { get;  }

		[Export ("emailField")]
		UITextField EmailField { get;  }

		[Export ("additionalField")]
		UITextField AdditionalField { get;  }

		[Export ("signUpButton")]
		UIButton SignUpButton { get;  }

		[Export ("dismissButton")]
		UIButton DismissButton { get;  }

		[Export ("initWithFields:fields")]
		IntPtr Constructor (PFSignUpFields fields );

	}

	
	[BaseType (typeof (UIViewController), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof (PFSignUpViewControllerDelegate)})]
	interface PFSignUpViewController {
		[Export ("fields")]
		PFSignUpFields Fields { get; set;  }

		[Export ("signUpView")]
		PFSignUpView SignUpView { get;  }

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		PFSignUpViewControllerDelegate Delegate { get; set; }

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface PFSignUpViewControllerDelegate {
		[Export ("signUpViewController:shouldBeginSignUp:"), DefaultValue (true), DelegateName ("PF_VCDict")]
		bool BeginSignUp (PFSignUpViewController signUpController, NSDictionary info);

		[Export ("signUpViewController:didSignUpUser:"), EventArgs ("PF_VCUser")]
		void SuccededLogin (PFSignUpViewController signUpController, PFUser user);

		[Export ("signUpViewController:didFailToSignUpWithError:"), EventArgs ("PF_VCError")]
		void FailedLogin (PFSignUpViewController signUpController, NSError error);

		[Export ("signUpViewControllerDidCancelSignUp:"), DelegateName ("PF_VC")]
		void CanceledLogin (PFSignUpViewController signUpController);

	}

	
	[BaseType (typeof (UIView))]//, Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof (PF_EGORefreshTableHeaderDelegate)})]
	interface PF_EGORefreshTableHeaderView {

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		PF_EGORefreshTableHeaderDelegate Delegate { get; set; }

		[Export ("refreshLastUpdatedDate")]
		void RefreshLastUpdatedDate ();

		[Export ("egoRefreshScrollViewDidScroll:")]
		void DidScroll (UIScrollView scrollView);

		[Export ("egoRefreshScrollViewDidEndDragging:")]
		void DidEndDragging (UIScrollView scrollView);

		[Export ("egoRefreshScrollViewDataSourceDidFinishedLoading:")]
		void DataSourceDidFinishedLoading (UIScrollView scrollView);

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface PF_EGORefreshTableHeaderDelegate {
		[Abstract]
		[Export ("egoRefreshTableHeaderDataSourceIsLoading:")]//,DefaultValue(true), DelegateName ("PFView")]
		bool IsLoading (PF_EGORefreshTableHeaderView view);

		[Abstract]
		[Export ("egoRefreshTableHeaderDataSourceLastUpdated:")]//, DefaultValue(null), DelegateName ("PFView")]
		NSDate DataSourceLastUpdated (PF_EGORefreshTableHeaderView view);

	}

	
	[BaseType (typeof (UIView))]
	interface PFLogInView {
		[Export ("logo")]
		UIView Logo { get; set;  }

		[Export ("fields")]
		PFLogInFields Fields { get;  }

		[Export ("usernameField")]
		UITextField UsernameField { get;  }

		[Export ("passwordField")]
		UITextField PasswordField { get;  }

		[Export ("passwordForgottenButton")]
		UIButton PasswordForgottenButton { get;  }

		[Export ("logInButton")]
		UIButton LogInButton { get;  }

		[Export ("facebookButton")]
		UIButton FacebookButton { get;  }

		[Export ("twitterButton")]
		UIButton TwitterButton { get;  }

		[Export ("signUpButton")]
		UIButton SignUpButton { get;  }

		[Export ("dismissButton")]
		UIButton DismissButton { get;  }

		[Export ("initWithFields:fields")]
		IntPtr Constructor (PFLogInFields fields );

	}

	
	[BaseType (typeof (UIViewController), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof (PFLogInViewControllerDelegate)})]
	interface PFLogInViewController {
		[Export ("fields")]
		PFLogInFields Fields { get; set;  }

		[Export ("logInView")]
		PFLogInView LogInView { get;  }

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		PFLogInViewControllerDelegate Delegate { get; set; }

		[Export ("facebookPermissions")]
		NSArray FacebookPermissions { get; set;  }

		[Export ("signUpController")]
		PFSignUpViewController SignUpController { get; set;  }

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface PFLogInViewControllerDelegate {
		[Export ("logInViewController:shouldBeginLogInWithUsername:password:"),DefaultValue(true), DelegateName ("PFShouldLogin")]
		bool ShouldBeginLogIn (PFLogInViewController logInController, string username, string password);

		[Export ("logInViewController:didLogInUser:"), EventArgs ("PFDidLogin")]
		void SuccededLogin (PFLogInViewController logInController, PFUser user);

		[Export ("logInViewController:didFailToLogInWithError:"), EventArgs ("PFFailedLogin")]
		void FailedLogin (PFLogInViewController logInController, NSError error);

		[Export ("logInViewControllerDidCancelLogIn:"), DelegateName ("PFCanceledLogin")]
		void CanceledLogin (PFLogInViewController logInController);

	}

	
	[BaseType (typeof (UITableViewController))]
	interface PFQueryTableViewController {
		[Export ("className")]
		string ClassName { get; set;  }

		[Export ("keyToDisplay")]
		string KeyToDisplay { get; set;  }

		[Export ("pullToRefreshEnabled")]
		bool PullToRefreshEnabled { get; set;  }

		[Export ("paginationEnabled")]
		bool PaginationEnabled { get; set;  }

		[Export ("objectsPerPage")]
		uint ObjectsPerPage { get; set;  }

		[Export ("isLoading")]
		bool IsLoading { get; set;  }

		[Export ("objects")]
		PFObject[] Objects { get; set;  }

		[Export ("pageThatIsLoading")]
		int PageThatIsLoading { get; set;  }

		[Export ("initWithStyle:className:")]
		IntPtr Constructor (UITableViewStyle style, string aClassName);

		[Export ("initWithClassName:")]
		IntPtr Constructor (string aClassName);

		[Export ("objectsDidLoad:")]
		void ObjectsDidLoad (NSError error);

		[Export ("objectsWillLoad")]
		void ObjectsWillLoad ();

		[Export ("objectAtIndex:")]
		PFObject ObjectAtIndex (NSIndexPath indexPath);

		[Export ("queryForTable")]
		PFQuery QueryForTable ();

		[Export ("clear")]
		void Clear ();

		[Export ("loadObjects")]
		void LoadObjects ();

		[Export ("loadObjects:clear:")]
		void LoadObjects (int page, bool clear);

		[Export ("loadNextPage")]
		void LoadNextPage ();

		[Export ("tableView:cellForRowAtIndexPath:object:")]
		UITableViewCell TableViewcellForRowAtIndexPathobject (UITableView tableView, NSIndexPath indexPath, PFObject obj);

		[Export ("tableView:cellForNextPageAtIndexPath:")]
		UITableViewCell TableViewcellForNextPageAtIndexPath (UITableView tableView, NSIndexPath indexPath);

	}

	
	[BaseType (typeof (UIView), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof (PF_MBProgressHUDDelegate)})]
	interface PF_MBProgressHUD {
		[Export ("customView")]
		UIView CustomView { get; set;  }

		[Export ("mode")]
		PF_MBProgressHUDMode Mode { get; set;  }

		[Export ("animationType")]
		PF_MBProgressHUDAnimation AnimationType { get; set;  }

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		PF_MBProgressHUDDelegate Delegate { get; set; }

		[Export ("labelText")]
		string LabelText { get; set;  }

		[Export ("detailsLabelText")]
		string DetailsLabelText { get; set;  }

		[Export ("opacity")]
		float Opacity { get; set;  }

		[Export ("xOffset")]
		float XOffset { get; set;  }

		[Export ("yOffset")]
		float YOffset { get; set;  }

		[Export ("margin")]
		float Margin { get; set;  }

		[Export ("dimBackground")]
		bool DimBackground { get; set;  }

		[Export ("graceTime")]
		float GraceTime { get; set;  }

		[Export ("minShowTime")]
		float MinShowTime { get; set;  }

		[Export ("taskInProgress")]
		bool TaskInProgress { get; set;  }

		[Export ("removeFromSuperViewOnHide")]
		bool RemoveFromSuperViewOnHide { get; set;  }

		[Export ("labelFont")]
		UIFont LabelFont { get; set;  }

		[Export ("detailsLabelFont")]
		UIFont DetailsLabelFont { get; set;  }

		[Export ("progress")]
		float Progress { get; set;  }

		[Static]
		[Export ("showHUDAddedTo:animated:")]
		PF_MBProgressHUD ShowHUDAdded (UIView view, bool animated);

		[Static]
		[Export ("hideHUDForView:animated:")]
		bool HideHUDForView(UIView view, bool animated);

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

	[BaseType (typeof (NSObject))]
	[Model]
	interface PF_MBProgressHUDDelegate {
		[Abstract]
		[Export ("hudWasHidden:"), DelegateName ("PF_MBHidden")]
		void HudWasHidden (PF_MBProgressHUD hud);

	}

	[BaseType (typeof (UIView))]
	interface PF_MBRoundProgressView {
		[Export ("progress")]
		float Progress { get; set;  }

	}


	#endregion //UI

	#region Facebook
	
	[BaseType (typeof (NSObject))]
	interface PFFacebookUtils {
		[Static]
		[Export ("facebook")]
		PF_Facebook Facebook ();

		[Static]
		[Export ("facebookWithDelegate:")]
		PF_Facebook Facebook (PF_FBSessionDelegate del);

		[Static]
		[Export ("initializeWithApplicationId:")]
		void InitializeWithApplicationId (string appId);

		[Static]
		[Export ("isLinkedWithUser:")]
		bool IsLinkedWithUser (PFUser user);

		[Static]
		[Export ("logInWithPermissions:block:")]
		void LogInAsync (NSArray permissions, PFUserResult result);

		[Static]
		[Export ("logInWithPermissions:target:selector:")]
		void LogInAsync (NSArray permissions, NSObject target, Selector selector);

		[Static]
		[Export ("logInWithFacebookId:accessToken:expirationDate:block:")]
		void LogInAsync (string facebookId, string accessToken, NSDate expirationDate, PFUserResult result);

		[Static]
		[Export ("logInWithFacebookId:accessToken:expirationDate:target:selector:")]
		void LogInAsync (string facebookId, string accessToken, NSDate expirationDate, NSObject target, Selector selector);

		[Static]
		[Export ("linkUser:permissions:")]
		void LinkUser (PFUser user, NSArray permissions);

		[Static]
		[Export ("linkUser:permissions:block:")]
		void LinkUserAsync (PFUser user, NSArray permissions, PFBooleanResult result);

		[Static]
		[Export ("linkUser:permissions:target:selector:")]
		void LinkUserAsync (PFUser user, NSArray permissions, NSObject target, Selector selector);

		[Static]
		[Export ("linkUser:facebookId:accessToken:expirationDate:block:")]
		void LinkUserAsync (PFUser user, string facebookId, string accessToken, NSDate expirationDate, PFBooleanResult result);

		[Static]
		[Export ("linkUser:facebookId:accessToken:expirationDate:target:selector:")]
		void LinkUserAsync (PFUser user, string facebookId, string accessToken, NSDate expirationDate, NSObject target, Selector selector);

		[Static]
		[Export ("unlinkUser:")]
		bool UnlinkUser (PFUser user);

		[Static]
		[Export ("unlinkUser:error:")]
		bool UnlinkUser (PFUser user, out NSError error);

		[Static]
		[Export ("unlinkUserInBackground:")]
		void UnlinkUserAsync (PFUser user);

		[Static]
		[Export ("unlinkUserInBackground:block:")]
		void UnlinkUserAsync (PFUser user, PFBooleanResult result);

		[Static]
		[Export ("unlinkUserInBackground:target:selector:")]
		void UnlinkUserAsync (PFUser user, NSObject target, Selector selector);

		[Static]
		[Export ("shouldExtendAccessTokenForUser:")]
		bool ShouldExtendAccessTokenForUser (PFUser user);

		[Static]
		[Export ("extendAccessTokenForUser:target:selector:")]
		void ExtendAccessTokenForUser(PFUser user, NSObject target, Selector selector);

		[Static]
		[Export ("extendAccessTokenForUser:block:")]
		void ExtendAccessTokenForUserAsync (PFUser user, PFBooleanResult result);

		[Static]
		[Export ("extendAccessTokenIfNeededForUser:target:selector:")]
		bool ExtendAccessTokenIfNeeded (PFUser user, NSObject target, Selector selector);

		[Static]
		[Export ("extendAccessTokenIfNeededForUser:block:")]
		bool ExtendAccessTokenIfNeededAsync (PFUser user, PFBooleanResult result);

		[Static]
		[Export ("handleOpenURL:")]
		bool HandleOpenURL (NSUrl url);

	}

	
	[BaseType (typeof (UIView), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof (PF_FBDialogDelegate)})]
	interface PF_FBDialog {
		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		PF_FBDialogDelegate Delegate { get; set; }

		[Export ("params")]
		NSMutableDictionary Params { get; set;  }

		[Export ("getStringFromUrl:needle:")]
		string GetStringFromUrl (string url, string needle);

		[Export ("initWithURL:loadingURLparams:paramsisViewInvisible:isViewInvisiblefrictionlessSettings:frictionlessSettingsdelegate:delegate")]
		IntPtr Constructor (string loadingURL, NSMutableDictionary parameters, bool isViewInvisible, PF_FBFrictionlessRequestSettings frictionlessSettings, PF_FBDialogDelegate del );

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

	[BaseType (typeof (NSObject))]
	[Model]
	interface PF_FBDialogDelegate {
		[Abstract]
		[Export ("dialogDidComplete:"), DelegateName ("PF_FBDialogArg")]
		void DidComplete (PF_FBDialog dialog);

		[Abstract]
		[Export ("dialogCompleteWithUrl:"), DelegateName ("PFUrl")]
		void CompleteWithUrl (NSUrl url);

		[Abstract]
		[Export ("dialogDidNotCompleteWithUrl:"), DelegateName ("PFUrl")]
		void DidNotCompleteWithUrl (NSUrl url);

		[Abstract]
		[Export ("dialogDidNotComplete:"), DelegateName ("PF_FBDialogArg")]
		void DidNotComplete (PF_FBDialog dialog);

		[Abstract]
		[Export ("dialog:didFailWithError:"), EventArgs ("PF_FBDialogError")]
		void DidFail (PF_FBDialog dialog, NSError error);

		[Abstract]
		[Export ("dialog:shouldOpenURLInExternalBrowser:"), DefaultValue(true), DelegateName ("PF_FBDialogUrl")]
		bool ShouldOpenURLInExternalBrowser (PF_FBDialog dialog, NSUrl url);

	}

	
	[BaseType (typeof (NSObject))]
	interface PF_FBFrictionlessRequestSettings {
		[Export ("enabled")]
		bool Enabled { get;  }

		[Export ("enableWithFacebook:")]
		void EnableWithFacebook (PF_Facebook facebook);

		[Export ("reloadRecipientCacheWithFacebook:")]
		void ReloadRecipientCacheWithFacebook (PF_Facebook facebook);

		[Export ("updateRecipientCacheWithRecipients:")]
		void UpdateRecipientCacheWithRecipients (string[] ids);

		[Export ("isFrictionlessEnabledForRecipient:")]
		bool IsFrictionlessEnabledForRecipient (string fbid);

		[Export ("isFrictionlessEnabledForRecipients:")]
		bool IsFrictionlessEnabledForRecipients (string[] fbids);

	}

	
	[BaseType (typeof (NSObject), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof (PF_FBRequestDelegate)})]
	interface PF_FBRequest {
		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		PF_FBRequestDelegate Delegate { get; set; }

		[Export ("url")]
		string Url { get; set;  }

		[Export ("httpMethod")]
		string HttpMethod { get; set;  }

		[Export ("params")]
		NSMutableDictionary Params { get; set;  }

		[Export ("connection")]
		NSUrlConnection Connection { get; set;  }

		[Export ("responseText")]
		NSMutableData ResponseText { get; set;  }

		[Export ("state")]
		PF_FBRequestState State { get;  }

		[Export ("sessionDidExpire")]
		bool SessionDidExpire { get;  }

		[Export ("error")]
		NSError Error { get; set;  }

		[Static]
		[Export ("serializeURL:params:")]
		string SerializeURL (string baseUrl, NSDictionary parameters);

		[Static]
		[Export ("serializeURL:params:httpMethod:")]
		string SerializeURL (string baseUrl, NSDictionary parameters, string httpMethod);

		[Static]
		[Export ("getRequestWithParams:paramshttpMethod:httpMethoddelegate:requestURL:url")]
		PF_FBRequest GetRequest (NSMutableDictionary parameters, string httpMethod, PF_FBRequestDelegate del, string requestURL );

		[Export ("loading")]
		bool Loading ();

		[Export ("connect")]
		void Connect ();

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface PF_FBRequestDelegate {
		[Abstract]
		[Export ("requestLoading:"), DelegateName ("PF_FBRequest")]
		void RequestLoading (PF_FBRequest request);

		[Abstract]
		[Export ("request:didReceiveResponse:"), EventArgs ("PF_FBRequestResp")]
		void DidReceiveResponse (PF_FBRequest request, NSUrlResponse response);

		[Abstract]
		[Export ("request:didFailWithError:"), EventArgs ("PF_FBRequestError")]
		void DidFail (PF_FBRequest request, NSError error);

		[Abstract]
		[Export ("request:didLoad:"), EventArgs ("PF_FBRequestObj")]
		void DidLoad (PF_FBRequest request, NSObject result);

		[Abstract]
		[Export ("request:didLoadRawResponse:"), EventArgs ("PF_FBRequestData")]
		void DidLoadRawResponse (PF_FBRequest request, NSData data);

	}

	
	[BaseType (typeof (NSObject))]//, Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof (PF_FBSessionDelegate)})]
	interface PF_Facebook {
		[Export ("accessToken")]
		string AccessToken { get; set;  }

		[Export ("expirationDate")]
		NSDate ExpirationDate { get; set;  }

		[Export ("sessionDelegate"), NullAllowed]
		PF_FBSessionDelegate SessionDelegate { get; set; }

		//[Export ("sessionDelegate"), NullAllowed]
		//NSObject WeakDelegate { get; set; }

		//[Wrap ("WeakDelegate")]
		//PF_FBSessionDelegate SessionDelegate { get; set; }

		[Export ("urlSchemeSuffix")]
		string UrlSchemeSuffix { get; set;  }

		[Export ("isFrictionlessRequestsEnabled")]
		bool IsFrictionlessRequestsEnabled { [Bind ("isFrictionlessRequestsEnabled")] get;  }

		[Export ("initWithAppId:andDelegate:")]
		IntPtr Constructor (string appId, PF_FBSessionDelegate del);

		[Export ("initWithAppId:urlSchemeSuffix:andDelegate:")]
		IntPtr Constructor (string appId, string urlSchemeSuffix, PF_FBSessionDelegate del);

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
		void Logout (PF_FBSessionDelegate del);

		[Export ("requestWithParams:andDelegate:")]
		PF_FBRequest Request (NSMutableDictionary parameters, PF_FBRequestDelegate del);

		[Export ("requestWithMethodName:andParams:andHttpMethod:andDelegate:")]
		PF_FBRequest Request (string methodName, NSMutableDictionary parameters, string httpMethod, PF_FBRequestDelegate del);

		[Export ("requestWithGraphPath:andDelegate:")]
		PF_FBRequest RequestWithGraph (string graphPath, PF_FBRequestDelegate del);

		[Export ("requestWithGraphPath:andParams:andDelegate:")]
		PF_FBRequest RequestWithGraph (string graphPath, NSMutableDictionary parameters, PF_FBRequestDelegate del);

		[Export ("requestWithGraphPath:andParams:andHttpMethod:andDelegate:")]
		PF_FBRequest RequestWithGraph (string graphPath, NSMutableDictionary parameters, string httpMethod, PF_FBRequestDelegate del);

		[Export ("dialog:andDelegate:")]
		void Dialog (string action, PF_FBDialogDelegate del);

		[Export ("dialog:andParams:andDelegate:")]
		void Dialog (string action, NSMutableDictionary parameters, PF_FBDialogDelegate del);

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

	[BaseType (typeof (NSObject))]
	[Model]
	interface PF_FBSessionDelegate {
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

	
	[BaseType (typeof (PF_FBDialog))]
	interface PF_FBLoginDialog {
		[Export ("initWithURL:loginURLloginParams:delegate:")]
		IntPtr Constructor (string url, NSMutableDictionary parameters, PF_FBLoginDialogDelegate del );

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface PF_FBLoginDialogDelegate {
		[Abstract]
		[Export ("fbDialogLogin:expirationDate:")]
		void Login (string token, NSDate expirationDate);

		[Abstract]
		[Export ("fbDialogNotLogin:")]
		void NotLogin (bool cancelled);

	}


	#endregion //Facebook

	#region Twitter
	
	[BaseType (typeof (NSObject))]
	interface PFTwitterUtils {
		[Static]
		[Export ("twitter")]
		PF_Twitter Twitter ();

		[Static]
		[Export ("initializeWithConsumerKey:consumerSecret:")]
		void Initialize (string consumerKey, string consumerSecret);

		[Static]
		[Export ("isLinkedWithUser:")]
		bool IsLinkedWithUser (PFUser user);

		[Static]
		[Export ("logInWithBlock:")]
		void LogInAsync (PFUserResult result);

		[Static]
		[Export ("logInWithTarget:selector:")]
		void LogIn (NSObject target, Selector selector);

		[Static]
		[Export ("logInWithTwitterId:screenName:authToken:authTokenSecret:block:")]
		void LogInWithTwitterIdAsync (string twitterId, string screenName, string authToken, string authTokenSecret, PFUserResult result);

		[Static]
		[Export ("logInWithTwitterId:screenName:authToken:authTokenSecret:target:selector:")]
		void LogInWithTwitterId (string twitterId, string screenName, string authToken, string authTokenSecret, NSObject target, Selector selector);

		[Static]
		[Export ("linkUser:")]
		void LinkUser (PFUser user);

		[Static]
		[Export ("linkUser:block:")]
		void LinkUserAsync (PFUser user, PFBooleanResult result);

		[Static]
		[Export ("linkUser:target:selector:")]
		void LinkUserAsync (PFUser user, NSObject target, Selector selector);

		[Static]
		[Export ("linkUser:twitterId:screenName:authToken:authTokenSecret:block:")]
		void LinkUserAsync (PFUser user, string twitterId, string screenName, string authToken, string authTokenSecret, PFBooleanResult result);

		[Static]
		[Export ("linkUser:twitterId:screenName:authToken:authTokenSecret:target:selector:")]
		void LinkUserAsync (PFUser user, string twitterId, string screenName, string authToken, string authTokenSecret, NSObject target, Selector selector);

		[Static]
		[Export ("unlinkUser:")]
		bool UnlinkUser (PFUser user);

		[Static]
		[Export ("unlinkUser:error:")]
		bool UnlinkUser (PFUser user, out NSError error);

		[Static]
		[Export ("unlinkUserInBackground:")]
		void UnlinkUserAsync (PFUser user);

		[Static]
		[Export ("unlinkUserInBackground:block:")]
		void UnlinkUserAsync (PFUser user, PFBooleanResult result);

		[Static]
		[Export ("unlinkUserInBackground:target:selector:")]
		void UnlinkUserAsync (PFUser user, NSObject target, Selector selector);

	}

	
	[BaseType (typeof (NSObject))]
	interface PF_Twitter {
		[Export ("consumerKey")]
		string ConsumerKey { get; set;  }

		[Export ("consumerSecret")]
		string ConsumerSecret { get; set;  }

		[Export ("authToken")]
		string AuthToken { get; set;  }

		[Export ("authTokenSecret")]
		string AuthTokenSecret { get; set;  }

		[Export ("userId")]
		string UserId { get; set;  }

		[Export ("screenName")]
		string ScreenName { get; set;  }

		[Export ("authorizeWithSuccess:failure:error:cancel:")]
		void AuthorizeAsync (Action success, PFErrorResult error, Action failed);

		[Export ("signRequest:")]
		void SignRequest (NSMutableUrlRequest request);

	}

	#endregion //Twitter
}
