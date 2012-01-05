using System;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace Parse
{
	[BaseType (typeof (NSObject))]
	interface Parse {
		
		[Static]
		[Export ("setApplicationId:clientKey:")]
		void SetApplicationId (string applicationId,string clientKey);
		
		[Static]
		[Export ("setFacebookApplicationId:")]
		void SetFacebookApplicationId (string applicationId);

		[Static]
		[Export ("hasFacebookApplicationId")]
		bool HasFacebookApplicationId ();

		[Static]
		[Export ("getApplicationId")]
		string GetApplicationId ();

		[Static]
		[Export ("getClientKey")]
		string GetClientKey ();

		[Static]
		[Export ("getFacebookApplicationId")]
		string GetFacebookApplicationId ();

	}
	
	
	[BaseType (typeof (NSObject))]
	interface PFACL {
		[Static]
		[Export ("ACL")]
		PFACL ACL ();

		[Static]
		[Export ("ACLWithUser:")]
		PFACL ACLWithUser (PFUser user);

		[Export ("setPublicReadAccess:")]
		void SetPublicReadAccess (bool allowed);

		[Export ("setPublicWriteAccess:")]
		void SetPublicWriteAccess (bool allowed);

		[Export ("setReadAccess:forUserId:")]
		void SetReadAccessforUserId (bool allowed, string userId);

		[Export ("setWriteAccess:forUserId:")]
		void SetWriteAccessforUserId (bool allowed, string userId);

		[Export ("setReadAccess:forUser:")]
		void SetReadAccessforUser (bool allowed, PFUser user);

		[Export ("setWriteAccess:forUser:")]
		void SetWriteAccessforUser (bool allowed, PFUser user);

	}


	[BaseType (typeof (NSObject))]
	interface PFFile {
		[Export ("name")]
		string Name { get;  }

		[Export ("url")]
		string Url { get;  }

		[Export ("isDataAvailable")]
		bool IsDataAvailable { get;  }

		[Export ("isDirty")]
		bool IsDirty { get;  }

		[Export ("save")]
		bool Save ();

		//[Export ("save:")]
		//bool Save (NSError error);

		[Export ("saveInBackground")]
		void SaveInBackground ();

		[Export ("saveInBackgroundWithTarget:selector:")]
		void SaveInBackgroundWithTargetselector (NSObject target, Selector selector);

		[Export ("getData")]
		NSData GetData ();

		//[Export ("getData:")]
		//NSData GetData (NSError error);

		[Export ("getDataInBackgroundWithTarget:selector:")]
		void GetDataInBackgroundWithTargetselector (NSObject target, Selector selector);

		//[Export ("saveInBackgroundWithBlock:")]
		//void Save (PFBooleanResult result);

		//[Export ("getDataInBackgroundWithBlock:")]
		//void GetDataInBackgroundWithBlock (PFDataResult result);

		[Export ("fileWithData:")]
		PFFile FileWithData (NSData data);

		[Static]
		[Export ("fileWithName:data:")]
		PFFile FileWithNamedata (string name, NSData data);

	}
	
	[BaseType (typeof (NSObject))]
	interface PFObject {
		
		[Export ("objectId")]
		string ObjectId { get; set;  }

		[Export ("updatedAt")]
		NSDate UpdatedAt { get;  }

		[Export ("createdAt")]
		NSDate CreatedAt { get;  }

		[Export ("initWithClassName:")]
		IntPtr Constructor (string newClassName);

		[Static]
		[Export ("objectWithClassName:")]
		PFObject FromName (string className);

		[Export ("address")]
		PFPointer Address ();

		//[Export ("save")]
		//bool Save ();

		[Export ("save:")]
		bool Save (out NSError error);

		[Export ("saveInBackground")]
		void SaveInBackground ();

		[Export ("saveInBackgroundWithTarget:selector:")]
		void SaveInBackgroundWithTargetselector (NSObject target, Selector selector);

		//[Export ("refresh")]
		//void Refresh ();

		[Export ("refresh:")]
		void Refresh (NSError error);

		[Export ("refreshInBackgroundWithTarget:selector:")]
		void RefreshInBackgroundWithTargetselector (NSObject target, Selector selector);

		//[Export ("delete")]
		//bool Delete ();

		[Export ("delete:")]
		bool Delete (NSError error);

		[Export ("deleteInBackground")]
		void DeleteInBackground ();

		[Export ("deleteInBackgroundWithTarget:selector:")]
		void DeleteInBackgroundWithTargetselector (NSObject target, Selector selector);

		//[Export ("deleteInBackgroundWithBlock:")]
		//void DeleteInBackgroundWithBlock (PFBooleanResultBlock block);

		//[Export ("saveInBackgroundWithBlock:")]
		//void SaveInBackgroundWithBlock (PFBooleanResultBlock block);

		//[Export ("refreshInBackgroundWithBlock:")]
		//void RefreshInBackgroundWithBlock (PFObjectResultBlock block);

		[Export ("objectForKey:")]
		NSObject ObjectForKey (string key);

		[Export ("setObject:forKey:")]
		void SetObjectforKey (NSObject inObject, string key);

		[Export ("removeObjectForKey:")]
		void RemoveObjectForKey (string key);

		[Static]
		[Export ("saveAll:")]
		bool SaveAll (NSArray objects);

		[Static]
		[Export ("saveAll:error:")]
		bool SaveAllerror (NSArray objects, NSError error);

		[Static]
		[Export ("saveAllInBackground:")]
		void SaveAllInBackground (NSArray objects);

		[Static]
		[Export ("saveAllInBackground:withTarget:selector:")]
		void SaveAllInBackgroundwithTargetselector (NSArray objects, NSObject target, Selector selector);

		[Export ("isDirty")]
		bool IsDirty ();
		
		[Export ("initWithClassName:result:")]
		IntPtr Constructor  (string newClassName, NSDictionary result);

	}
	
	
	[BaseType (typeof (NSObject))]
	interface PFPointer {
		[Export ("objectId")]
		string ObjectId { get; set;  }

		[Export ("className")]
		string ClassName { get; set;  }

		[Export ("proxyForJson")]
		NSObject ProxyForJson ();
		
		[Export ("initWithClassName:objectId:")]
		IntPtr Constructor (string newClassName, string newObjectId);

		[Static]
		[Export ("pointerWithClassName:objectId:")]
		PFPointer PointerWithClassNameobjectId (string newClassName, string newObjectId);

		//[Export ("copyWithZone:")]
		//NSObject CopyWithZone (NSZone zone);

	}

	
	[BaseType (typeof (NSObject))]
	interface PFPush {
		[Static]
		[Export ("subscribeToChannel:withError:")]
		bool Subscribe (string channel,out NSError error);
	}

	
	[BaseType (typeof (NSObject))]
	interface PFQuery {
		[Export ("className")]
		string ClassName { get; set;  }

		[Export ("limit")]
		NSNumber Limit { get; set;  }

		[Export ("skip")]
		NSNumber Skip { get; set;  }

		//[Export ("cachePolicy")]
		//PFCachePolicy CachePolicy { get; set;  }

		[Export ("order")]
		string Order { get; set;  }
		
		[Export ("initWithClassName:")]
		IntPtr Constructor (string newClassName);

		[Export ("orderByAscending:")]
		void OrderByAscending (string key);

		[Export ("orderByDescending:")]
		void OrderByDescending (string key);

		[Export ("whereKey:equalTo:")]
		void WhereKeyequalTo (string key, NSObject inObject);

		[Export ("whereKey:lessThan:")]
		void WhereKeylessThan (string key, NSObject inObject);

		[Export ("whereKey:lessThanOrEqualTo:")]
		void WhereKeylessThanOrEqualTo (string key, NSObject inObject);

		[Export ("whereKey:greaterThan:")]
		void WhereKeygreaterThan (string key, NSObject inObject);

		[Export ("whereKey:greaterThanOrEqualTo:")]
		void WhereKeygreaterThanOrEqualTo (string key, NSObject inObject);

		[Export ("whereKey:notEqualTo:")]
		void WhereKeynotEqualTo (string key, NSObject inObject);

		[Export ("whereKey:containedIn:")]
		void WhereKeycontainedIn (string key, NSArray array);

		//[Export ("findObjects")]
		//NSArray FindObjects ();

		[Export ("findObjects:")]
		NSArray FindObjects (NSError error);

		[Export ("findObjectsInBackgroundWithTarget:selector:")]
		void FindObjectsAsync (NSObject target, Selector selector);

		//[Export ("countObjects")]
		//int CountObjects ();

		[Export ("countObjects:")]
		int CountObjects (NSError error);

		[Export ("countObjectsInBackgroundWithTarget:selector:")]
		void CountObjectsAsync (NSObject target, Selector selector);

		[Export ("getObjectWithId:")]
		PFObject GetObject (string objectId);

		[Export ("getObjectWithId:error:")]
		PFObject GetObject (string objectId, NSError error);

		[Export ("getObjectInBackgroundWithId:target:selector:")]
		void GetObjectAsync (string objectId, NSObject target, Selector selector);

		[Static]
		[Export ("getObjectOfClass:objectId:")]
		PFObject GetObject(string objectClass, string objectId);

		[Static]
		[Export ("getObjectOfClass:objectId:error:")]
		PFObject GetObject (string objectClass, string objectId, NSError error);

		[Static]
		[Export ("queryWithClassName:")]
		PFQuery Query (string className);

		[Static]
		[Export ("getUserObjectWithId:")]
		PFUser GetUserObject (string objectId);

		[Static]
		[Export ("getUserObjectWithId:error:")]
		PFUser GetUserObject (string objectId, NSError error);

		[Static]
		[Export ("queryForUser")]
		PFQuery QueryForUser ();

		//[Export ("findObjectsInBackgroundWithBlock:")]
		//void FindObjectsInBackgroundWithBlock (PFArrayResultBlock block);

		//[Export ("countObjectsInBackgroundWithBlock:")]
		//void CountObjectsInBackgroundWithBlock (PFIntegerResultBlock block);

		//[Export ("getObjectInBackgroundWithId:block:")]
		//void GetObjectInBackgroundWithIdblock (string objectId, PFObjectResultBlock block);

	}
	
	
	[BaseType (typeof (PFObject))]
	interface PFUser {
		[Export ("password")]
		string Password { get; set;  }

		[Export ("sessionToken")]
		string SessionToken { get; set;  }

		[Export ("facebookAccessToken")]
		string FacebookAccessToken { get;  }

		[Export ("facebookExpirationDate")]
		NSDate FacebookExpirationDate { get;  }

		[Export ("facebookId")]
		string FacebookId { get;  }

		[Export ("isNew")]
		bool IsNew { get;  }

		[Export ("username")]
		string Username { get; set;  }

		[Export ("email")]
		string Email { get; set;  }

		[Static]
		[Export ("user")]
		PFUser User ();

		[Static]
		[Export ("currentUser")]
		NSObject CurrentUser ();

		[Static]
		[Export ("logInWithUsername:password:")]
		PFUser LogIn (string username, string password);

		[Static]
		[Export ("logInWithUsername:password:error:")]
		PFUser LogIn (string username, string password, NSError error);

		[Static]
		[Export ("logInWithUsernameInBackground:password:")]
		void LogInAsycnc (string username, string password);

		[Static]
		[Export ("logInWithUsernameInBackground:password:target:selector:")]
		void LogInAsync (string username, string password, NSObject target, Selector selector);

		[Static]
		[Export ("facebook")]
		PF_Facebook Facebook ();

		[Static]
		[Export ("facebookWithDelegate:")]
		PF_Facebook Facebook (PF_FBSessionDelegate fbDelegate);

		[Static]
		[Export ("logInWithFacebook:target:selector:")]
		void LogInWithFacebook (NSArray permissions, NSObject target, Selector selector);

		[Export ("linkToFacebook:target:selector:")]
		void LinkToFacebook (NSArray permissions, NSObject target, Selector selector);

		[Export ("unlinkFromFacebook")]
		bool UnlinkFromFacebook ();

		[Export ("unlinkFromFacebookWithError:")]
		bool UnlinkFromFacebook (NSError error);

		[Export ("unlinkFromFacebookInBackgroundWithTarget:selector:")]
		void UnlinkFromFacebookAsync (NSObject target, Selector selector);

		[Static]
		[Export ("requestPasswordResetForEmail:")]
		bool RequestPasswordReset (string email);

		[Static]
		[Export ("requestPasswordResetForEmail:error:")]
		bool RequestPasswordReset (string email, NSError error);

		[Static]
		[Export ("requestPasswordResetForEmailInBackground:")]
		void RequestPasswordResetAsync (string email);

		[Static]
		[Export ("requestPasswordResetForEmailInBackground:withTarget:selector:")]
		void RequestPasswordResetAsync (string email, NSObject target, Selector selector);

		[Static]
		[Export ("logOut")]
		void LogOut ();

		[Export ("isAuthenticated")]
		bool IsAuthenticated ();

		[Export ("hasFacebook")]
		bool HasFacebook ();

		//[Export ("signUp")]
		//bool SignUp ();

		[Export ("signUp:")]
		bool SignUp (NSError error);

		[Export ("signUpInBackground")]
		void SignUpAsync ();

		[Export ("signUpInBackgroundWithTarget:selector:")]
		void SignUpAsync (NSObject target, Selector selector);

		//[Export ("logInWithUsernameInBackground:password:block:")]
		//void LogIn (string username, string password, PFUserResultBlock block);

		//[Static]
		//[Export ("requestPasswordResetForEmailInBackground:block:")]
		//void RequestPassword (string email, PFBooleanResultBlock block);

		//[Export ("signUpInBackgroundWithBlock:")]
		//void SignUp (PFBooleanResultBlock block);

		//[Static]
		//[Export ("logInWithFacebook:block:")]
		//void LogInWithFacebook (NSArray permissions, PFUserResultBlock block);

		//[Export ("linkToFacebook:block:")]
		//void LinkToFacebook (NSArray permissions, PFBooleanResultBlock block);
		
		//[Export ("unlinkFromFacebookWithBlock:")]
		//void UnlinkFromFacebook (PFBooleanResultBlock block);

	}

	#region Facebook
	
	[BaseType (typeof (NSObject))]
	interface PF_Facebook {
		[Export ("accessToken")]
		string AccessToken { get; set;  }

		[Export ("expirationDate")]
		NSDate ExpirationDate { get; set;  }

		[Export ("sessionDelegate")]
		PF_FBSessionDelegate SessionDelegate { get; set;  }

		[Export ("localAppId")]
		string LocalAppId { get; set;  }
	
	
		[Export ("initWithAppId:andDelegate:")]
		IntPtr Constructor (string appId, PF_FBSessionDelegate fbDelegate);

		[Export ("authorize:")]
		void Authorize (NSArray permissions);

		[Export ("authorize:localAppId:")]
		void AuthorizeLocalApp (NSArray permissions, string localAppId);

		[Export ("handleOpenURL:")]
		bool OpenURL (NSUrl url);

		[Export ("logout:")]
		void Logout (PF_FBSessionDelegate fbDelegate);

		[Export ("requestWithParams:andDelegate:")]
		PF_FBRequest GetRequest (NSMutableDictionary parameters, PF_FBRequestDelegate fbDelegate);

		[Export ("requestWithMethodName:andParams:andHttpMethod:andDelegate:")]
		PF_FBRequest GetRequest (string methodName, NSMutableDictionary parameters, string httpMethod, PF_FBRequestDelegate fbDelegate);

		[Export ("requestWithGraphPath:andDelegate:")]
		PF_FBRequest GetGraphRequest (string graphPath, PF_FBRequestDelegate fbDelegate);

		[Export ("requestWithGraphPath:andParams:andDelegate:")]
		PF_FBRequest GetGraphRequest (string graphPath, NSMutableDictionary parameters, PF_FBRequestDelegate fbDelegate);

		[Export ("requestWithGraphPath:andParams:andHttpMethod:andDelegate:")]
		PF_FBRequest GetGraphRequest (string graphPath, NSMutableDictionary parameters, string httpMethod, PF_FBRequestDelegate fbDelegate);

		[Export ("dialog:andDelegate:")]
		void Dialog (string action, PF_FBDialogDelegate fbDelegate);

		[Export ("dialog:andParams:andDelegate:")]
		void Dialog (string action, NSMutableDictionary parameters, PF_FBDialogDelegate fbDelegate);

		[Export ("isSessionValid")]
		bool IsSessionValid ();

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface PF_FBSessionDelegate {
		[Abstract]
		[Export ("fbDidLogin")]
		void DidLogin ();

		[Abstract]
		[Export ("fbDidNotLogin:")]
		void DidNotLogin (bool cancelled);

		[Abstract]
		[Export ("fbDidLogout")]
		void DidLogout ();
	}
	
	
	[BaseType (typeof (UIView))]
	interface PF_FBDialog {
		[Export ("delegate")]
		PF_FBDialogDelegate Delegate { get; set;  }

		[Export ("params")]
		NSMutableDictionary Params { get; set;  }

		[Export ("title")]
		string Title { get; set;  }

		[Export ("getStringFromUrl:urlneedle:needle")]
		string GetString (string url, string urlNeedle , string needle );

		[Export ("initWithURL:loadingURLparams:paramsdelegate:delegate")]
		IntPtr Constructor (string url, NSMutableDictionary parameters , PF_FBDialogDelegate theDelegate );

		[Export ("show")]
		void Show ();

		[Export ("load")]
		void Load ();

		[Export ("loadURL:get:")]
		void LoadURLget (string url, NSDictionary getParams);

		[Export ("dismissWithSuccess:animated:")]
		void Dismiss (bool success, bool animated);

		[Export ("dismissWithError:animated:")]
		void Dismiss (NSError error, bool animated);

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
		[Export ("dialogDidComplete:")]
		void DialogComplete (PF_FBDialog dialog);

		[Abstract]
		[Export ("dialogCompleteWithUrl:")]
		void DialogComplete (NSUrl url);

		[Abstract]
		[Export ("dialogDidNotCompleteWithUrl:")]
		void DialogDidNotComplete (NSUrl url);

		[Abstract]
		[Export ("dialogDidNotComplete:")]
		void DialogDidNotComplete (PF_FBDialog dialog);

		[Abstract]
		[Export ("dialog:didFailWithError:")]
		void DialogDidFail (PF_FBDialog dialog, NSError error);

		[Abstract]
		[Export ("dialog:shouldOpenURLInExternalBrowser:")]
		bool DialogShouldOpenURLInExternalBrowser (PF_FBDialog dialog, NSUrl url);

	}
	
	
	[BaseType (typeof (NSObject))]
	interface PF_FBRequest {
		[Export ("delegate")]
		PF_FBRequestDelegate Delegate { get; set;  }

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

		[Static]
		[Export ("serializeURL:params:")]
		string SerializeURL (string baseUrl, NSDictionary parameters);

		[Static]
		[Export ("serializeURL:params:httpMethod:")]
		string SerializeURL (string baseUrl, NSDictionary parameters, string httpMethod);

		[Static]
		[Export ("getRequestWithParams:paramshttpMethod:httpMethoddelegate:requestURL:url")]
		PF_FBRequest GetRequest (NSMutableDictionary parameters, string  httpMethod, PF_FBRequestDelegate requestDelegate, string url );

		[Export ("loading")]
		bool Loading ();

		[Export ("connect")]
		void Connect ();

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface PF_FBRequestDelegate {
		[Abstract]
		[Export ("requestLoading:")]
		void Loading (PF_FBRequest request);

		[Abstract]
		[Export ("request:didReceiveResponse:")]
		void ReceiveResponse (PF_FBRequest request, NSUrlResponse response);

		[Abstract]
		[Export ("request:didFailWithError:")]
		void DidFailWithError (PF_FBRequest request, NSError error);

		[Abstract]
		[Export ("request:didLoad:")]
		void DidLoad (PF_FBRequest request, NSObject result);

		[Abstract]
		[Export ("request:didLoadRawResponse:")]
		void DidLoadRawResponse (PF_FBRequest request, NSData data);

	}

	
	#endregion
}
