using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;
using MonoTouch.CoreGraphics;
using MonoTouch.UIKit;

namespace UrbanAirship
{
	[BaseType (typeof (NSObject))]
	interface UAirship {
		[Export ("deviceToken")]
		string DeviceToken { get; set;  }

		[Export ("analytics")]
		UAAnalytics Analytics { get; set;  }

		[Export ("server")]
		string Server { get; set;  }

		[Export ("appId")]
		string AppId { get; set;  }

		[Export ("appSecret")]
		string AppSecret { get; set;  }

		[Export ("deviceTokenHasChanged")]
		bool DeviceTokenHasChanged { get; set;  }

		[Export ("ready")]
		bool Ready { get; set;  }

		[Static]
		[Export ("setLogging:")]
		void SetLogging (bool enabled);

		[Static]
		[Export ("takeOff:")]
		void TakeOff (NSDictionary options);

		[Static]
		[Export ("land")]
		void Land ();

		[Static]
		[Export ("shared")]
		UAirship Shared { get; }

		[Export ("registerDeviceToken:")]
		void RegisterDeviceToken (NSData token);

//		[Export ("registerDeviceTokenWithExtraInfo:")]
//		void RegisterDeviceToken (NSDictionary info);

		[Export ("registerDeviceToken:withAlias:")]
		void RegisterDeviceToken (NSData token, string alias);

		[Export ("registerDeviceToken:withExtraInfo:")]
		void RegisterDeviceToken (NSData token, NSDictionary info);

		[Export ("unRegisterDeviceToken")]
		void UnRegisterDeviceToken ();

	}

	[Static]
	interface UAirshipTakeOffOptions
	{
		[Static, Field ("UAirshipTakeOffOptionsAirshipConfigKey", "__Internal")]
		NSString AirshipConfigKey { get; }
		
		[Static, Field ("UAirshipTakeOffOptionsLaunchOptionsKey", "__Internal")]
		NSString LaunchOptionsKey { get; }
		
		[Static, Field ("UAirshipTakeOffOptionsAnalyticsKey", "__Internal")]
		NSString AnalyticsKey { get; }
		
		[Static, Field ("UAirshipTakeOffOptionsDefaultUsernameKey", "__Internal")]
		NSString DefaultUsernameKey { get; }
		
		[Static, Field ("UAirshipTakeOffOptionsDefaultPasswordKey", "__Internal")]
		NSString DefaultPasswordKey { get; }
	}
	
	[BaseType (typeof (NSObject), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof(UAPushNotificationDelegate)})]
	interface UAPush {
		[Export ("useCustomUI")]
		NSObject UseCustomUI { get; set;  }

		[Export ("openApnsSettings:animated:")]
		void OpenApnsSettings(UIViewController viewController, bool animated);
		
		[Export ("closeApnsSettingsAnimated:")]
		void CloseApnsSettings(bool animated);
		
		[Export ("land")]
		void Land();

		[Static]
		[Export ("shared")]
		UAPush Shared { get; }
		
		[Export ("registerForRemoteNotificationTypes:")]
		void RegisterForRemoteNotificationTypes (UIRemoteNotificationType types);

		[Export ("registerDeviceToken:")]
		void RegisterDeviceToken (NSData token);
		
		[Export ("updateRegistration")]
		void UpdateRegistration();
		
		[Export ("addTagToCurrentDevice:")]
		void AddTagToCurrentDevice(string tag);
		
		[Export ("removeTagFromCurrentDevice:")]
		void RemoveTagFromCurrentDevice(string tag);
		
		[Export ("updateAlias:")]
		void UpdateAlias (string value);
		
		[Export ("updateTags:")]
		void UpdateTags(string[] value);
		
		[Export ("setQuietTimeFrom:to:withTimeZone:")]
		void SetQuietTime(NSDate from, NSDate to, NSTimeZone tz);
		
		[Export ("disableQuietTime")]
		void DisableQuietTime();
		
		[Export ("enableAutobadge:")]
		void EnableAutobadge (bool enabled);
		
		[Export ("setBadgeNumber:")]
		void SetBadgeNumber (int badgeNumber);
		
		[Export ("resetBadge")]
		void ResetBadge();
		
		[Export("handleNotification:applicationState:")]
		void HandleNotification(NSDictionary notification, UIApplicationState state);
		
		[Export("pushTypeString:")]
		string PushTypeString (UIRemoteNotificationType types);

		[Wrap ("WeakDelegate")]
		UAPushNotificationDelegate WeakDelegate { get; set; }

	}

	[BaseType (typeof(NSObject))]
	[Model]
	interface UAPushNotificationDelegate
	{
		[Export ("displayNotificationAlert:")]
		void DisplayNotificationAlert (string alertMessage);

		[Export ("displayLocalizedNotificationAlert:")]
		void DisplayLocalizedNotificationAlert (NSDictionary alertDict);

		[Export ("playNotificationSound:")]
		void PlayNotificationSound (string sound);

		[Export ("handleNotification:withCustomPayload:"), EventArgs ("NotificationWithCustomPayload")]
		void HandleNotificationWithCustomPayload (NSDictionary notification, NSDictionary customPayload);

		[Export ("handleBadgeUpdate:")]
		void HandleBadgeUpdate (int badgeNumber);

		[Export ("handleBackgroundNotification:")]
		void HandleBackgroundNotification (NSDictionary notification);

	}

	[BaseType (typeof(NSObject), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof(UAHTTPConnectionDelegate)})]
	interface UAAnalytics
	{
		[Export ("server")]
		string Server { get; set; }

		[Export ("session")]
		NSMutableDictionary Session { get; }

		[Export ("databaseSize")]
		int DatabaseSize { get; }

		[Export ("x_ua_max_total")]
		int X_ua_max_total { get; }

		[Export ("x_ua_max_batch")]
		int X_ua_max_batch { get; }

		[Export ("x_ua_max_wait")]
		int X_ua_max_wait { get; }

		[Export ("x_ua_min_batch_interval")]
		int X_ua_min_batch_interval { get; }

		[Export ("sendInterval")]
		int SendInterval { get; set; }

		[Export ("oldestEventTime")]
		double OldestEventTime { get; }

		[Export ("lastSendTime")]
		DateTime LastSendTime { get; }

		[Export ("initWithOptions:")]
		IntPtr Constructor (NSDictionary options);

		[Export ("restoreFromDefault")]
		void RestoreFromDefault ();

		[Export ("saveDefault")]
		void SaveDefault ();

		[Export ("addEvent:")]
		void AddEvent (UAEvent theEvent);

		[Export ("handleNotification:")]
		void HandleNotification (NSDictionary userInfo);

		[Export ("resetEventsDatabaseStatus")]
		void ResetEventsDatabaseStatus ();

		[Export ("sendIfNeeded")]
		void SendIfNeeded ();
			
		[Wrap ("WeakDelegate")]
		UAHTTPConnectionDelegate WeakDelegate { get; set; }
	}
	
	[BaseType (typeof(UIImageView))]
	interface UAAsyncImageView
	{
		[Export ("onReady")]
		Selector OnReady { get; set; }

		[Export ("target")]
		NSObject Target { get; set; }

		[Export ("loadImageFromURL:")]
		void LoadImageL (NSUrl url);
	}
	
	[BaseType (typeof(UISegmentedControl))]
	interface UABarButtonSegmentedControl
	{
	}
	
	[BaseType (typeof(NSObject))]
	interface UAContentURLCache
	{
		[Export ("contentDictionary")]
		NSMutableDictionary ContentDictionary { get; set; }

		[Export ("timestampDictionary")]
		NSMutableDictionary TimestampDictionary { get; set; }

		[Export ("path")]
		string Path { get; set; }

		[Export ("expirationInterval")]
		double ExpirationInterval { get; set; }

		[Static]
		[Export ("cacheWithExpirationInterval:withPath:")]
		UAContentURLCache CacheWithExpiration (double interval, string pathString);

		[Export ("initWithExpirationInterval:withPath:")]
		IntPtr Constructor (double interval, string pathString);

		[Export ("setContent:forProductURL:")]
		void SetContentforProductURL (NSUrl contentURL, NSUrl productURL);

		[Export ("contentForProductURL:")]
		NSUrl ContentForProductURL (NSUrl productURL);

	}
	
	[BaseType (typeof(NSObject))]
	interface UADateUtils
	{
		[Static]
		[Export ("formattedDateRelativeToNow:")]
		string FormattedDateRelativeToNow (NSDate date);

	}
	
	[BaseType (typeof(NSObject), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof(UAZipDownloadContentProtocol)})]
	interface UADownloadContent
	{
		[Export ("userInfo")]
		NSObject UserInfo { get; set; }

		[Export ("clearBeforeDownload")]
		bool ClearBeforeDownload { get; set; }

		[Export ("username")]
		string Username { get; set; }

		[Export ("password")]
		string Password { get; set; }

		[Export ("downloadRequestURL")]
		NSUrl DownloadRequestURL { get; set; }

		[Export ("downloadFileName")]
		string DownloadFileName { get; set; }

		[Export ("requestMethod")]
		string RequestMethod { get; set; }

		[Export ("responseString")]
		string ResponseString { get; set; }

		[Export ("downloadPath")]
		string DownloadPath { get; set; }

		[Export ("downloadTmpPath")]
		string DownloadTmpPath { get; set; }

		[Export ("postData")]
		NSDictionary PostData { get; set; }
		
		[Wrap ("WeakDelegate")]
		UAZipDownloadContentProtocol WeakDelegate { get; set; }

	}

	[BaseType (typeof(NSObject))]
	[Model]
	interface UAZipDownloadContentProtocol
	{
		[Export ("decompressDidSucceed:")]
		void DecompressDidSucceed (UAZipDownloadContent zipDownloadContent);

		[Export ("decompressDidFail:")]
		void DecompressDidFail (UAZipDownloadContent zipDownloadContent);

	}

	[BaseType (typeof(UADownloadContent))]
	interface UAZipDownloadContent
	{
		[Export ("decompressedContentPath")]
		string DecompressedContentPath { get; set; }

		[Export ("decompress")]
		void Decompress ();

	}
	
	[BaseType (typeof(NSObject))]
	[Model]
	interface UADownloadManagerDelegate
	{
		[Export ("requestDidSucceed:")]
		void Success (UADownloadContent downloadContent);

		[Export ("requestDidFail:")]
		void Failed (UADownloadContent downloadContent);

		[Export ("downloadQueueProgress:count:"), EventArgs ("UADownloadManagerProgress")]
		void DownloadProgress (float progress, int count);

	}

	[BaseType (typeof(NSObject), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof(UADownloadManagerDelegate)})]
	interface UADownloadManager
	{
		[Export ("delegate")]
		UADownloadManagerDelegate Delegate { get; set; }

		[Export ("download:")]
		void Download (UADownloadContent content);

		[Export ("downloadingContentCount")]
		int DownloadingContentCount ();

		[Export ("allDownloadingContents")]
		UADownloadContent[] AllDownloadingContents ();

		[Export ("cancel:")]
		void Cancel (UADownloadContent downloadContent);

		[Export ("updateProgressDelegate:")]
		void UpdateProgressDelegate (UADownloadContent downloadContent);

		[Export ("isDownloading:")]
		bool IsDownloading (UADownloadContent downloadContent);

		[Export ("endBackground")]
		void EndBackground ();
	
		[Wrap ("WeakDelegate")]
		UADownloadManagerDelegate WeakDelegate { get; set; }
	}
	
	[BaseType (typeof(NSObject))]
	interface UAEvent
	{
		[Export ("time")]
		string Time { get; }

		[Export ("event_id")]
		string Event_id { get; }

		[Export ("data")]
		NSMutableDictionary Data { get; }

		[Static]
		[Export ("event")]
		UAEvent Event ();

		[Export ("initWithContext:")]
		IntPtr Constructor (NSDictionary context);

		[Static]
		[Export ("eventWithContext:")]
		NSObject FromContext (NSDictionary context);

		[Export ("getType")]
		string EventType { get; }

		[Export ("gatherData:")]
		void GatherData (NSDictionary context);

		[Export ("getEstimatedSize")]
		int GetEstimatedSize ();

	}

	[BaseType (typeof(UAEvent))]
	interface UAEventCustom
	{
		[Static]
		[Export ("eventWithType:")]
		UAEventCustom FromType (string aType);

		[Export ("initWithType:andContext:")]
		IntPtr Constructor (string aType, NSDictionary context);

		[Static]
		[Export ("eventWithType:andContext:")]
		UAEventCustom FromType (string aType, NSDictionary context);

	}

	[BaseType (typeof(UAEvent))]
	interface UAEventAppInit
	{
	}

	[BaseType (typeof(UAEventAppInit))]
	interface UAEventAppForeground
	{
	}

	[BaseType (typeof(UAEvent))]
	interface UAEventAppExit
	{
	}

	[BaseType (typeof(UAEventAppExit))]
	interface UAEventAppBackground
	{
	}

	[BaseType (typeof(UAEvent))]
	interface UAEventDeviceRegistration
	{
	}

	[BaseType (typeof(UAEvent))]
	interface UAEventPushReceived
	{
	}

	[BaseType (typeof(UAEvent))]
	interface UAEventAppActive
	{
	}

	[BaseType (typeof(UAEvent))]
	interface UAEventAppInactive
	{
	}
	
	[BaseType (typeof(NSObject))]
	interface UAHTTPRequest
	{
		[Export ("HTTPMethod")]
		string HTTPMethod { get; set; }

		[Export ("headers")]
		NSDictionary Headers { get; }

		[Export ("username")]
		string Username { get; set; }

		[Export ("password")]
		string Password { get; set; }

		[Export ("body")]
		NSData Body { get; set; }

		[Export ("compressBody")]
		bool CompressBody { get; set; }

		[Export ("userInfo")]
		NSObject UserInfo { get; set; }

		[Static]
		[Export ("requestWithURLString:")]
		UAHTTPRequest RequestWithURLString (string urlString);

		[Export ("initWithURLString:")]
		IntPtr Constructor (string urlString);

		[Export ("addRequestHeader:value:")]
		void AddRequestHeadervalue (string header, string value);

		[Export ("appendBodyData:")]
		void AppendBodyData (NSData data);

	}

	[BaseType (typeof(NSObject))]
	[Model]
	interface UAHTTPConnectionDelegate
	{
		[Abstract]
		[Export ("requestDidSucceed:response:responseData:"), EventArgs ("UAHTTPConnectionSucceeded")]
		void Success (UAHTTPRequest request, NSHttpUrlResponse response, NSData responseData);

		[Abstract]
		[Export ("requestDidFail:")]
		void Failed (UAHTTPRequest request);

	}

	[BaseType (typeof(NSObject))]
	interface UAHTTPConnection
	{
		[Static]
		[Export ("connectionWithRequest:")]
		UAHTTPConnection ConnectionWithRequest (UAHTTPRequest httpRequest);

		[Export ("initWithRequest:")]
		IntPtr Constructor (UAHTTPRequest httpRequest);

		[Export ("start")]
		bool Start ();

		[Export ("connection:didReceiveResponse:")]
		void ReceivedResponse (NSUrlConnection connection, NSHttpUrlResponse response);

		[Export ("connection:didReceiveData:")]
		void ConnectionReceivedData (NSUrlConnection connection, NSData data);

		[Export ("connection:didFailWithError:")]
		void ConnectionFailed (NSUrlConnection connection, NSError error);

		[Export ("connectionDidFinishLoading:")]
		void FinishedLoading (NSUrlConnection connection);
	
	}
	
	[BaseType (typeof(NSObject))]
	interface UAKeychainUtils
	{
		[Static]
		[Export ("createKeychainValueForUsername:withPassword:forIdentifier:")]
		bool CreateKeychainValue (string username, string password, string identifier);

		[Static]
		[Export ("deleteKeychainValue:")]
		void DeleteKeychainValue (string identifier);

		[Static]
		[Export ("updateKeychainValueForUsername:withPassword:withEmailAddress:forIdentifier:")]
		bool UpdateKeychainValue (string username, string password, string email, string identifier);

		[Static]
		[Export ("getPassword:")]
		string GetPassword (string identifier);

		[Static]
		[Export ("getUsername:")]
		string GetUsername (string identifier);

		[Static]
		[Export ("getEmailAddress:")]
		string GetEmailAddress (string identifier);
	}
	
	[BaseType (typeof(NSObject))]
	interface UALocalStorageDirectory
	{
		[Export ("storageType")]
		UALocalStorageType StorageType { get; set; }

		[Export ("subpath")]
		string Subpath { get; set; }

		[Export ("oldPaths")]
		NSSet OldPaths { get; set; }

		[Export ("path")]
		string Path { get; }

		[Static]
		[Export ("uaDirectory")]
		UALocalStorageDirectory UaDirectory ();

		[Static]
		[Export ("localStorageDirectoryWithType:withSubpath:withOldPaths:")]
		UALocalStorageDirectory LocalStorageDirectory (UALocalStorageType storageType, string nameString, NSSet oldPathsSet);

		[Export ("subDirectoryWithPathComponent:")]
		string SubDirectoryWithPathComponent (string component);

	}
	
	
	[BaseType (typeof (NSObject))]
	interface UAObservable {
		[Export ("notifyObservers:")]
		void NotifyObservers (Selector selector);

		[Export ("notifyObservers:withObject:")]
		void NotifyObservers (Selector selector, NSObject arg1);

		[Export ("notifyObservers:withObject:withObject:")]
		void NotifyObservers (Selector selector, NSObject arg1, NSObject arg2);

		[Export ("addObserver:")]
		void AddObserver (NSObject observer);

		[Export ("removeObserver:")]
		void RemoveObserver (NSObject observer);

		[Export ("removeObservers")]
		void RemoveObservers ();

		[Export ("countObservers")]
		int CountObservers ();

	}
	
	[BaseType (typeof (NSObject))]
	interface UASQLite {
		[Export ("busyRetryTimeout")]
		int BusyRetryTimeout { get; set;  }

		[Export ("dbPath")]
		string DbPath { get;  }

		[Export ("initWithDBPath:")]
		IntPtr Constructor (string aDBPath);

		[Export ("open:")]
		bool Open (string aDBPath);

		[Export ("close")]
		void Close ();

		[Export ("lastErrorMessage")]
		string LastErrorMessage ();

		[Export ("lastErrorCode")]
		int LastErrorCode ();

		[Export ("executeQuery:")]
		NSArray ExecuteQuery (string sql);

		[Export ("executeQuery:arguments:")]
		NSArray ExecuteQuery (string sql, string[] args);

		[Export ("executeUpdate:")]
		bool ExecuteUpdate (string sql );

		[Export ("executeUpdate:arguments:")]
		bool ExecuteUpdate (string sql, string[] args);

		[Export ("commit")]
		bool Commit ();

		[Export ("rollback")]
		bool Rollback ();

		[Export ("beginTransaction")]
		bool BeginTransaction ();

		[Export ("beginDeferredTransaction")]
		bool BeginDeferredTransaction ();

		[Export ("tableExists:")]
		bool TableExists (string tableName);

		[Export ("indexExists:")]
		bool IndexExists (string indexName);

	}
	
	
	[BaseType (typeof (NSObject))]
	interface UATagUtils {
		[Static]
		[Export ("createTags:tags")]
		NSArray CreateTagstags (UATagType tags );

	}



}
