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

		[Export ("deviceManager:didFailToConnectWithError:")]
		void DidFailToConnect (GCKDeviceManager deviceManager, NSError error);

		[Export ("deviceManager:didDisconnectWithError:")]
		void DidDisconnect (GCKDeviceManager deviceManager, NSError error);

		[Export ("deviceManager:didConnectToCastApplication:sessionID:launchedApplication:")]
		void DidConnectToCastApplication (GCKDeviceManager deviceManager, GCKApplicationMetadata applicationMetadata, string sessionId, bool launchedApplication);

		[Export ("deviceManager:didFailToConnectToApplicationWithError:")]
		void DidFailToConnectToApplication (GCKDeviceManager deviceManager, NSError error);

		[Export ("deviceManager:didDisconnectFromApplicationWithError:")]
		void DidDisconnectFromApplication (GCKDeviceManager deviceManager, NSError error);

		[Export ("deviceManager:didFailToStopApplicationWithError:")]
		void DidFailToStopApplication (GCKDeviceManager deviceManager, NSError error);

		[Export ("deviceManager:didReceiveStatusForApplication:")]
		void DidReceiveStatus (GCKDeviceManager deviceManager, GCKApplicationMetadata applicationMetadata);

		[Export ("deviceManager:volumeDidChangeToLevel:isMuted:")]
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
	interface GCKImage : INSCopying, INSCoding {

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

		[Export ("mediaControlChannel:requestDidCompleteWithID:")]
		void RequestDidComplete (GCKMediaControlChannel mediaControlChannel, int requestId);

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

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name="GoogleCastExporter")]
	interface GCKMetadataKey {

		[Static]
		[Export ("kGCKMetadataKeyCreationDateGlobal")]
		NSString KMetadataKeyCreationDate { get; }

		[Static]
		[Export ("kGCKMetadataKeyReleaseDateGlobal")]
		NSString KMetadataKeyReleaseDate { get; }

		[Static]
		[Export ("kGCKMetadataKeyBroadcastDateGlobal")]
		NSString KMetadataKeyBroadcastDate { get; }

		[Static]
		[Export ("kGCKMetadataKeyTitleGlobal")]
		NSString KMetadataKeyTitle { get; }

		[Static]
		[Export ("kGCKMetadataKeySubtitleGlobal")]
		NSString KMetadataKeySubtitle { get; }

		[Static]
		[Export ("kGCKMetadataKeyArtistGlobal")]
		NSString KMetadataKeyArtist { get; }

		[Static]
		[Export ("kGCKMetadataKeyAlbumArtistGlobal")]
		NSString KMetadataKeyAlbumArtist { get; }

		[Static]
		[Export ("kGCKMetadataKeyAlbumTitleGlobal")]
		NSString KMetadataKeyAlbumTitle { get; }

		[Static]
		[Export ("kGCKMetadataKeyComposerGlobal")]
		NSString KMetadataKeyComposer { get; }

		[Static]
		[Export ("kGCKMetadataKeyDiscNumberGlobal")]
		NSString KMetadataKeyDiscNumber { get; }

		[Static]
		[Export ("kGCKMetadataKeyTrackNumberGlobal")]
		NSString KMetadataKeyTrackNumber { get; }

		[Static]
		[Export ("kGCKMetadataKeySeasonNumberGlobal")]
		NSString KMetadataKeySeasonNumber { get; }

		[Static]
		[Export ("kGCKMetadataKeyEpisodeNumberGlobal")]
		NSString KMetadataKeyEpisodeNumber { get; }

		[Static]
		[Export ("kGCKMetadataKeySeriesTitleGlobal")]
		NSString KMetadataKeySeriesTitle { get; }

		[Static]
		[Export ("kGCKMetadataKeyStudioGlobal")]
		NSString KMetadataKeyStudio { get; }

		[Static]
		[Export ("kGCKMetadataKeyWidthGlobal")]
		NSString KMetadataKeyWidth { get; }

		[Static]
		[Export ("kGCKMetadataKeyHeightGlobal")]
		NSString KMetadataKeyHeight { get; }

		[Static]
		[Export ("kGCKMetadataKeyLocationNameGlobal")]
		NSString KMetadataKeyLocationName { get; }

		[Static]
		[Export ("kGCKMetadataKeyLocationLatitudeGlobal")]
		NSString KMetadataKeyLocationLatitude { get; }

		[Static]
		[Export ("kGCKMetadataKeyLocationLongitudeGlobal")]
		NSString KMetadataKeyLocationLongitude { get; }
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

		[Export ("objectForKey:")]
		NSObject ObjectForKey (string key);

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

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name="GoogleCastMediaCommandExporter")]
	interface GCKMediaCommand {

		[Static]
		[Export ("kGCKMediaCommandPauseGlobal")]
		int Pause { get; }

		[Static]
		[Export ("kGCKMediaCommandSeekGlobal")]
		int Seek { get; }

		[Static]
		[Export ("kGCKMediaCommandSetVolumeGlobal")]
		int SetVolume { get; }

		[Static]
		[Export ("kGCKMediaCommandToggleMuteGlobal")]
		int ToggleMute { get; }

		[Static]
		[Export ("kGCKMediaCommandSkipForwardGlobal")]
		int SkipForward { get; }

		[Static]
		[Export ("kGCKMediaCommandSkipBackwardGlobal")]
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