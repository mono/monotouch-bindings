using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GoogleCast
{
	[BaseType (typeof (NSObject))]
	interface GCKApplicationMetadata {

		[Export ("applicationID", ArgumentSemantic.Copy)]
		string ApplicationId { get; }

		[Export ("applicationName", ArgumentSemantic.Copy)]
		string ApplicationName { get; }

		[Export ("images", ArgumentSemantic.Copy)]
		GCKImage [] Images { get; }

		[Export ("namespaces", ArgumentSemantic.Copy)]
		string [] Namespaces { get; }

		[Export ("senderAppIdentifier")]
		string SenderAppIdentifier ();

		[Export ("senderAppLaunchURL")]
		NSUrl SenderAppLaunchUrl ();

		[Export ("senderApplicationInfo")]
		GCKSenderApplicationInfo SenderApplicationInfo ();
	}

	[BaseType (typeof (NSObject))]
	interface GCKCastChannel {

		[Field ("kGCKInvalidRequestID", "__Internal")]
		int InvalidRequestId { get; }

		[Export ("protocolNamespace", ArgumentSemantic.Copy)]
		string ProtocolNamespace { get; }

		[Export ("isConnected", ArgumentSemantic.Assign)]
		bool IsConnected { get; }

		[Export ("initWithNamespace:")]
		IntPtr Constructor (string protocolNamespace);

		[Export ("didReceiveTextMessage:")]
		void DidReceiveTextMessage (string message);

		[Export ("sendTextMessage:")]
		bool SendTextMessage (string message);

		[Export ("generateRequestID")]
		int GenerateRequestId ();

		[Export ("generateRequestNumber")]
		NSNumber GenerateRequestNumber ();

		[Export ("didConnect")]
		void DidConnect ();

		[Export ("didDisconnect")]
		void DidDisconnect ();
	}

	[BaseType (typeof (NSObject))]
	interface GCKDevice : INSCoding, INSCopying {

		[Export ("ipAddress", ArgumentSemantic.Copy)]
		string IpAddress { get; }

		[Export ("servicePort", ArgumentSemantic.Assign)]
		uint ServicePort { get; }

		[Export ("deviceID", ArgumentSemantic.Copy)]
		string DeviceId { get; set; }

		[Export ("friendlyName", ArgumentSemantic.Copy)]
		string FriendlyName { get; set; }

		[Export ("manufacturer", ArgumentSemantic.Copy)]
		string Manufacturer { get; set; }

		[Export ("modelName", ArgumentSemantic.Copy)]
		string ModelName { get; set; }

		[Export ("icons", ArgumentSemantic.Copy)]
		GCKImage [] Icons { get; set; }

		[Export ("initWithIPAddress:servicePort:")]
		IntPtr Constructor (string ipAddress, uint servicePort);
	}

	[BaseType (typeof (NSObject))]
	interface GCKDeviceFilter {

		[Export ("devices", ArgumentSemantic.Copy)]
		GCKDevice [] Devices { get; }

		[Export ("initWithDeviceScanner:criteria:")]
		IntPtr Constructor (GCKDeviceScanner scanner, GCKFilterCriteria criteria);

		[Export ("addDeviceFilterListener:")]
		void AddDeviceFilterListener (IGCKDeviceFilterListener listener);

		[Export ("removeDeviceFilterListener:")]
		void RemoveDeviceFilterListener (IGCKDeviceFilterListener listener);
	}

	interface IGCKDeviceFilterListener { }

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject))]
	interface GCKDeviceFilterListener {

		[Abstract]
		[Export ("deviceDidComeOnline:forDeviceFilter:")]
		void DeviceDidComeOnline (GCKDevice device, GCKDeviceFilter deviceFilter);

		[Abstract]
		[Export ("deviceDidGoOffline:forDeviceFilter:")]
		void DeviceDidGoOffline (GCKDevice device, GCKDeviceFilter deviceFilter);
	}

	[BaseType (typeof (NSObject))]
	interface GCKDeviceManager {

		[Export ("isConnected", ArgumentSemantic.Assign)]
		bool IsConnected { get; }

		[Export ("isConnectedToApp", ArgumentSemantic.Assign)]
		bool IsConnectedToApp { get; }

		[Export ("isReconnecting", ArgumentSemantic.Assign)]
		bool IsReconnecting { get; }

		[Export ("reconnectTimeout", ArgumentSemantic.Assign)]
		double ReconnectTimeout { get; set; }

		[Export ("device")]
		GCKDevice Device { get; }

		[Export ("delegate", ArgumentSemantic.Assign)] [NullAllowed]
		IGCKDeviceManagerDelegate Delegate { get; set; }

		[Export ("initWithDevice:clientPackageName:")]
		IntPtr Constructor (GCKDevice device, string clientPackageName);

		[Export ("connect")]
		void Connect ();

		[Export ("disconnect")]
		void Disconnect ();

		[Export ("addChannel:")]
		bool AddChannel (GCKCastChannel channel);

		[Export ("removeChannel:")]
		bool RemoveChannel (GCKCastChannel channel);

		[Export ("launchApplication:")]
		bool LaunchApplication (string applicationId);

		[Export ("launchApplication:relaunchIfRunning:")]
		bool LaunchApplication (string applicationId, bool relaunchIfRunning);

		[Export ("joinApplication:")]
		bool JoinApplication (string applicationId);

		[Export ("joinApplication:sessionID:")]
		bool JoinApplication (string applicationId, string sessionId);

		[Export ("leaveApplication")]
		bool LeaveApplication ();

		[Export ("stopApplication")]
		bool StopApplication ();

		[Export ("stopApplicationWithSessionID:")]
		bool StopApplication (string sessionId);

		[Export ("setVolume:")]
		bool SetVolume (float volume);

		[Export ("setMuted:")]
		bool SetMuted (bool muted);

		[Export ("requestDeviceStatus")]
		bool RequestDeviceStatus ();
	}

	interface IGCKDeviceManagerDelegate { }

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject))]
	interface GCKDeviceManagerDelegate {

		[Export ("deviceManagerDidConnect:")]
		void DidConnect (GCKDeviceManager deviceManager);

		[Export ("deviceManagerDidConnect:didFailToConnectWithError:")]
		void DidFailToConnect (GCKDeviceManager deviceManager, NSError error);

		[Export ("deviceManagerDidConnect:didDisconnectWithError:")]
		void DidDisconnect (GCKDeviceManager deviceManager, NSError error);

		[Export ("deviceManagerDidConnect:didConnectToCastApplication:sessionID:launchedApplication:")]
		void DidConnectToCastApplication (GCKDeviceManager deviceManager, GCKApplicationMetadata applicationMetadata, string sessionId, bool launchedApplication);

		[Export ("deviceManagerDidConnect:didFailToConnectToApplicationWithError:")]
		void DidFailToConnectToApplication (GCKDeviceManager deviceManager, NSError error);

		[Export ("deviceManagerDidConnect:didDisconnectFromApplicationWithError:")]
		void DidDisconnectFromApplication (GCKDeviceManager deviceManager, NSError error);

		[Export ("deviceManagerDidConnect:didFailToStopApplicationWithError:")]
		void DidFailToStopApplication (GCKDeviceManager deviceManager, NSError error);

		[Export ("deviceManagerDidConnect:didReceiveStatusForApplication:")]
		void DidReceiveStatus (GCKDeviceManager deviceManager, GCKApplicationMetadata applicationMetadata);

		[Export ("deviceManagerDidConnect:volumeDidChangeToLevel:isMuted:")]
		void VolumeDidChange (GCKDeviceManager deviceManager, float volumeLevel, bool isMuted);
	}

	[BaseType (typeof (NSObject))]
	interface GCKDeviceScanner {

		[Export ("devices", ArgumentSemantic.Copy)]
		GCKDevice [] Devices { get; }

		[Export ("hasDiscoveredDevices", ArgumentSemantic.Assign)]
		bool HasDiscoveredDevices { get; }

		[Export ("scanning", ArgumentSemantic.Assign)]
		bool Scanning { get; }

		[Export ("startScan")]
		void StartScan ();

		[Export ("stopScan")]
		void StopScan ();

		[Export ("addListener:")]
		void AddListener (IGCKDeviceScannerListener listener);

		[Export ("removeListener:")]
		void RemoveListener (IGCKDeviceScannerListener listener);
	}

	interface IGCKDeviceScannerListener { }

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject))]
	interface GCKDeviceScannerListener {

		[Export ("deviceDidComeOnline:")]
		void DeviceDidComeOnline (GCKDevice device);

		[Export ("deviceDidGoOffline:")]
		void DeviceDidGoOffline (GCKDevice device);
	}

	[BaseType (typeof (NSError))]
	interface GCKError {

		[Field ("kGCKErrorCustomDataKey", "__Internal")]
		NSString CustomDataKey { get; }

		[Static]
		[Export ("enumDescriptionForCode:")]
		string EnumDescriptionForCode (GCKErrorCode code);

		[Export ("initWithCode:additionalUserInfo:")]
		IntPtr Constructor (GCKErrorCode code, NSDictionary additionalUserInfo);

		[Export ("initWithCode:")]
		IntPtr Constructor (GCKErrorCode code);
	}


	[BaseType (typeof (NSObject))]
	interface GCKFilterCriteria {

		[Static]
		[Export ("criteriaForAvailableApplicationWithID:")]
		GCKFilterCriteria FromAvailableApplicationWithId (string applicationId);

		[Static]
		[Export ("criteriaForRunningApplicationWithID:supportedNamespaces:")]
		GCKFilterCriteria FromRunningApplicationWithId ([NullAllowed] string applicationId, string [] supportedNamespaces);

		[Static]
		[Export ("criteriaForRunningApplicationWithSupportedNamespaces:")]
		GCKFilterCriteria FromRunningApplicationWithSupportedNamespaces (string [] supportedNamespaces);
	}

	[BaseType (typeof (NSObject))]
	interface GCKImage {

		[Export ("URL", ArgumentSemantic.Retain)]
		NSUrl Url { get; }

		[Export ("width", ArgumentSemantic.Assign)]
		int Width { get; }

		[Export ("height", ArgumentSemantic.Assign)]
		int Height { get; }

		[Export ("initWithURL:width:height:")]
		IntPtr Constructor (NSUrl url, int width, int height);

		[Export ("initWithJSONObject:")]
		IntPtr Constructor (NSObject jsonObj);

		[Export ("JSONObject")]
		NSObject JsonObject ();
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GCKJSONUtils")]
	interface GCKJsonUtils {

		[Static]
		[Export ("parseJSON:")]
		NSObject ParseJson (string json);

		[Static]
		[Export ("writeJSON:")]
		string WriteJson (NSObject obj);

		[Static]
		[Export ("isJSONString:equivalentTo:")]
		bool JsonEquals (string actualJson, string expectedJson);
	}

	[BaseType (typeof (GCKCastChannel))]
	interface GCKMediaControlChannel {

		[Export ("mediaStatus", ArgumentSemantic.Retain)]
		GCKMediaStatus MediaStatus { get; }

		[Export ("delegate", ArgumentSemantic.Assign)] [NullAllowed]
		IGCKMediaControlChannelDelegate Delegate { get; set; }

		[Export ("loadMedia:")]
		int LoadMedia (GCKMediaInformation mediaInfo);

		[Export ("loadMedia:autoplay:")]
		int LoadMedia (GCKMediaInformation mediaInfo, bool autoplay);

		[Export ("loadMedia:autoplay:playPosition:")]
		int LoadMedia (GCKMediaInformation mediaInfo, bool autoplay, double playPosition);

		[Export ("loadMedia:autoplay:playPosition:customData:")]
		int LoadMedia (GCKMediaInformation mediaInfo, bool autoplay, double playPosition, NSObject customData);

		[Export ("pause")]
		int Pause ();

		[Export ("pauseWithCustomData:")]
		int Pause (NSObject customData);

		[Export ("stop")]
		int Stop ();

		[Export ("stopWithCustomData:")]
		int Stop (NSObject customData);

		[Export ("play")]
		int Play ();

		[Export ("playWithCustomData:")]
		int Play (NSObject customData);

		[Export ("seekToTimeInterval:")]
		int Seek (double position);

		[Export ("seekToTimeInterval:resumeState:")]
		int Seek (double position, GCKMediaControlChannelResumeState resumeState);

		[Export ("seekToTimeInterval:resumeState:customData:")]
		int Seek (double position, GCKMediaControlChannelResumeState resumeState, NSObject customData);

		[Export ("setStreamVolume:")]
		int SetStreamVolume (float volume);

		[Export ("setStreamVolume:customData:")]
		int SetStreamVolume (float volume, NSObject customData);

		[Export ("setStreamMuted:")]
		int SetStreamMuted (bool muted);

		[Export ("setStreamMuted:customData:")]
		int SetStreamMuted (bool muted, NSObject customData);

		[Export ("requestStatus")]
		int RequestStatus ();

		[Export ("approximateStreamPosition")]
		double ApproximateStreamPosition ();
	}

	interface IGCKMediaControlChannelDelegate { }

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject))]
	interface GCKMediaControlChannelDelegate {

		[Export ("mediaControlChannel:didCompleteLoadWithSessionID:")]
		void DidCompleteLoad (GCKMediaControlChannel mediaControlChannel, int sessionId);

		[Export ("mediaControlChannel:didFailToLoadMediaWithError:")]
		void DidFailToLoadMedia (GCKMediaControlChannel mediaControlChannel, NSError error);

		[Export ("mediaControlChannelDidUpdateStatus:")]
		void DidUpdateStatus (GCKMediaControlChannel mediaControlChannel);

		[Export ("mediaControlChannelDidUpdateMetadata:")]
		void DidUpdateMetadata (GCKMediaControlChannel mediaControlChannel);

		[Export ("mediaControlChannel:requestDidFailWithID:error:")]
		void RequestDidFail (GCKMediaControlChannel mediaControlChannel, int requestId, NSError error);
	}

	[BaseType (typeof (NSObject))]
	interface GCKMediaInformation {

		[Export ("streamType", ArgumentSemantic.Assign)]
		GCKMediaStreamType StreamType { get; }

		[Export ("contentType", ArgumentSemantic.Copy)]
		string ContentType { get; }

		[Export ("metadata", ArgumentSemantic.Retain)]
		GCKMediaMetadata Metadata { get; }

		[Export ("streamDuration", ArgumentSemantic.Assign)]
		double StreamDuration { get; }

		[Export ("customData", ArgumentSemantic.Retain)]
		NSObject CustomData { get; }

		[Export ("initWithContentID:streamType:contentType:metadata:streamDuration:customData:")]
		IntPtr Constructor (string contentID, GCKMediaStreamType streamType, string contentType, GCKMediaMetadata metadata, double streamDuration, [NullAllowed] NSObject customData);

		[Export ("initWithJSONObject:")]
		IntPtr Constructor (NSObject jsonObj);

		[Export ("JSONObject")]
		NSObject JsonObject ();
	}

	[Static]
	interface GCKMetadataKey {

		[Field ("kGCKMetadataKeyCreationDate", "__Internal")]
		NSString CreationDate { get; }

		[Field ("kGCKMetadataKeyReleaseDate", "__Internal")]
		NSString ReleaseDate { get; }

		[Field ("kGCKMetadataKeyBroadcastDate", "__Internal")]
		NSString BroadcastDate { get; }

		[Field ("kGCKMetadataKeyTitle", "__Internal")]
		NSString Title { get; }

		[Field ("kGCKMetadataKeySubtitle", "__Internal")]
		NSString Subtitle { get; }

		[Field ("kGCKMetadataKeyArtist", "__Internal")]
		NSString Artist { get; }

		[Field ("kGCKMetadataKeyAlbumArtist", "__Internal")]
		NSString AlbumArtist { get; }

		[Field ("kGCKMetadataKeyAlbumTitle", "__Internal")]
		NSString AlbumTitle { get; }

		[Field ("kGCKMetadataKeyComposer", "__Internal")]
		NSString Composer { get; }

		[Field ("kGCKMetadataKeyDiscNumber", "__Internal")]
		NSString DiscNumber { get; }

		[Field ("kGCKMetadataKeyTrackNumber", "__Internal")]
		NSString TrackNumber { get; }

		[Field ("kGCKMetadataKeySeasonNumber", "__Internal")]
		NSString SeasonNumber { get; }

		[Field ("kGCKMetadataKeyEpisodeNumber", "__Internal")]
		NSString EpisodeNumber { get; }

		[Field ("kGCKMetadataKeySeriesTitle", "__Internal")]
		NSString SeriesTitle { get; }

		[Field ("kGCKMetadataKeyStudio", "__Internal")]
		NSString Studio { get; }

		[Field ("kGCKMetadataKeyWidth", "__Internal")]
		NSString Width { get; }

		[Field ("kGCKMetadataKeyHeight", "__Internal")]
		NSString Height { get; }

		[Field ("kGCKMetadataKeyLocationName", "__Internal")]
		NSString LocationName { get; }

		[Field ("kGCKMetadataKeyLocationLatitude", "__Internal")]
		NSString LocationLatitude { get; }

		[Field ("kGCKMetadataKeyLocationLongitude", "__Internal")]
		NSString LocationLongitude { get; }
	}

	[BaseType (typeof (NSObject))]
	interface GCKMediaMetadata {

		[Export ("metadataType", ArgumentSemantic.Assign)]
		GCKMediaMetadataType MetadataType { get; }

		[Export ("initWithMetadataType:")]
		IntPtr Constructor (GCKMediaMetadataType metadataType);

		[Export ("images")]
		GCKImage [] Images ();

		[Export ("removeAllMediaImages")]
		void RemoveAllMediaImages ();

		[Export ("addImage:")]
		void AddImage (GCKImage image);

		[Export ("containsKey:")]
		bool ContainsKey (string key);

		[Export ("allKeys")]
		string [] AllKeys ();

		[Export ("setString:forKey:")]
		void SetString (string value, string Key);

		[Export ("stringForKey:")]
		string StringForKey (string key);

		[Export ("setInteger:forKey:")]
		void SetInteger (int value, string Key);

		[Export ("integerForKey:")]
		int IntegerForKey (string key);

		[Export ("integerForKey:defaultValue:")]
		int IntegerForKey (string key, int defaultValue);

		[Export ("setDouble:forKey:")]
		void SetDouble (double value, string Key);

		[Export ("doubleForKey:")]
		double DoubleForKey (string key);

		[Export ("doubleForKey:defaultValue:")]
		double DoubleForKey (string key, double defaultValue);

		[Export ("setDate:forKey:")]
		void SetDate (NSDate value, string Key);

		[Export ("dateForKey:")]
		NSDate DateForKey (string key);

		[Export ("dateAsStringForKey:")]
		string DateAsStringForKey (string key);
	}

	[Static]
	interface GCKMediaCommand {

		[Field ("kGCKMediaCommandPause", "__Internal")]
		int Pause { get; }

		[Field ("kGCKMediaCommandSeek", "__Internal")]
		int Seek { get; }

		[Field ("kGCKMediaCommandSetVolume", "__Internal")]
		int SetVolume { get; }

		[Field ("kGCKMediaCommandToggleMute", "__Internal")]
		int ToggleMute { get; }

		[Field ("kGCKMediaCommandSkipForward", "__Internal")]
		int SkipForward { get; }

		[Field ("kGCKMediaCommandSkipBackward", "__Internal")]
		int SkipBackward { get; }
	}

	[BaseType (typeof (NSObject))]
	interface GCKMediaStatus {

		[Export ("mediaSessionID", ArgumentSemantic.Assign)]
		int MediaSessionId { get; }

		[Export ("playerState", ArgumentSemantic.Assign)]
		GCKMediaPlayerState PlayerState { get; }

		[Export ("idleReason", ArgumentSemantic.Assign)]
		GCKMediaPlayerIdleReason IdleReason { get; }

		[Export ("playbackRate", ArgumentSemantic.Assign)]
		float PlaybackRate { get; }

		[Export ("mediaInformation", ArgumentSemantic.Retain)]
		GCKMediaInformation MediaInformation { get; }

		[Export ("streamPosition", ArgumentSemantic.Assign)]
		double StreamPosition { get; }

		[Export ("volume", ArgumentSemantic.Assign)]
		float Volume { get; }

		[Export ("isMuted", ArgumentSemantic.Assign)]
		bool IsMuted { get; }

		[Export ("customData", ArgumentSemantic.Retain)]
		NSObject CustomData { get; }

		[Export ("initWithSessionID:mediaInformation:")]
		IntPtr Constructor (int mediaSessionID, GCKMediaInformation mediaInformation);

		[Export ("isMediaCommandSupported:")]
		bool IsMediaCommandSupported (int command);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (GCKCastChannel))]
	interface GCKReceiverControlChannel {

		[Export ("delegate", ArgumentSemantic.Assign)] [NullAllowed]
		IGCKReceiverControlChannelDelegate Delegate { get; set; }

		[Export ("initWithReceiverDestinationID:")]
		IntPtr Constructor (string receiverDestinationId);

		[Export ("isLaunchingApplication")]
		bool IsLaunchingApplication ();

		[Export ("launchApplication:")]
		int LaunchApplication (string applicationId);

		[Export ("stopApplication")]
		int StopApplication ();

		[Export ("stopApplicationWithSessionID:")]
		int StopApplication (string sessionId);

		[Export ("requestDeviceStatus")]
		int RequestDeviceStatus ();

		[Export ("requestAvailabilityForAppIDs:")]
		int RequestAvailability (string [] appIds);

		[Export ("setVolume:")]
		int SetVolume (float volume);

		[Export ("setMuted:")]
		int SetMuted (bool muted);
	}

	interface IGCKReceiverControlChannelDelegate { }

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject))]
	interface GCKReceiverControlChannelDelegate {

		[Export ("receiverControlChannel:didLaunchCastApplication:")]
		void DidLaunchCastApplication (GCKReceiverControlChannel receiverControlChannel, GCKApplicationMetadata applicationMetadata);

		[Export ("receiverControlChannel:didFailToLaunchCastApplicationWithError:")]
		void DidFailToLaunchCastApplication (GCKReceiverControlChannel receiverControlChannel, NSError error);

		[Export ("receiverControlChannel:requestDidFailWithID:error:")]
		void RequestDidFail (GCKReceiverControlChannel receiverControlChannel, int requestId, NSError error);

		[Export ("receiverControlChannel:didReceiveStatusForApplication:")]
		void DidReceiveStatusForApplication (GCKReceiverControlChannel receiverControlChannel, GCKApplicationMetadata applicationMetadata);

		[Export ("receiverControlChannel:volumeDidChangeToLevel:isMuted:")]
		void VolumeDidChange (GCKReceiverControlChannel receiverControlChannel, float volumeLevel, bool isMuted);

		[Export ("receiverControlChannel:didReceiveAppAvailability:")]
		void DidReceiveAppAvailability (GCKReceiverControlChannel receiverControlChannel, NSDictionary appAvailability);
	}

	[BaseType (typeof (NSObject))]
	interface GCKSenderApplicationInfo : INSCopying {

		[Export ("platform", ArgumentSemantic.Assign)]
		GCKSenderApplicationInfoPlatform Platform { get; }

		[Export ("appIdentifier", ArgumentSemantic.Copy)]
		string AppIdentifier { get; }

		[Export ("launchURL", ArgumentSemantic.Retain)]
		NSUrl LaunchUrl { get; }

		[Export ("initWithPlatform:appIdentifier:launchURL:")]
		IntPtr Constructor (GCKSenderApplicationInfoPlatform platform, string appIdentifier, NSUrl launchUrl);

		[Export ("initWithJSONObject:")]
		IntPtr Constructor (NSObject JsonObj);
	}
}