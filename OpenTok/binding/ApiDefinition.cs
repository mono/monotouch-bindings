using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.AVFoundation;

namespace opentok
{
	[BaseType (typeof (NSError))]
	interface OTError {
	}
	
	[BaseType (typeof (NSObject))]
	interface OTConnection {
		[Export ("connectionId")]
		string ConnectionId { get; }
		
		[Export ("creationTime")]
		NSDate CreationTime { get; }
	}
	
	[BaseType (typeof (NSObject))]
	interface OTPublisher {
		[Export ("initWithDelegate:")]
		IntPtr Constructor (OTPublisherDelegate pubDelegate);
		
		[Export ("initWithDelegate:name:")]
		IntPtr Constructor (OTPublisherDelegate pubDelegate, string name);
		
		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		[Wrap ("WeakDelegate")]
		OTPublisherDelegate Delegate { get; set; }
		
		[Export ("session")]
		OTSession Session { get; }
		
		[Export ("view")]
		UIView View { get; }
		
		[Export("name")]
		string Name { get; set; }
		
		[Export ("publishAudio")]
		bool PublishAudio { get; set; }
		
		[Export ("publishVideo")]
		bool PublishVideo { get; set; }
		
		[Export ("cameraPosition")]
		AVCaptureDevicePosition CameraPosition { get; set; }
	}
	
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject))]
	interface OTPublisherDelegate {
		[Export ("publisher:didFailWithError:")]
		[Abstract]
		void DidFail (OTPublisher publisher, OTError error);
		
		[Export ("publisherDidStartStreaming:")]
		void DidStartStreaming (OTPublisher publisher);
		
		[Export ("publisherDidStopStreaming:")]
		void DidStopStreaming (OTPublisher publisher);

		[Export ("publisher:didChangeCameraPosition:")]
		void DidChangeCameraPosition (OTPublisher publisher, AVCaptureDevicePosition cameraPosition);
	}
	
	[BaseType (typeof (NSObject))]
	interface OTSession {
		[Export ("sessionConnectionStatus")]
		OTSessionConnectionStatus SessionConnectionStatus { get;  }

		[Export ("sessionId")]
		string SessionId { get;  }

		[Export ("connectionCount")]
		int ConnectionCount { get;  }

		[Export ("streams")]
		NSDictionary Streams { get;  }

		[Export ("connection")]
		OTConnection Connection { get;  }

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set;  }
		
		[Wrap ("WeakDelegate")]
		OTSessionDelegate Delegate { get; set;  }

		[Export ("environment")]
		OTSessionEnvironment Environment { get; set;  }

		[Export ("initWithSessionId:delegate:")]
		IntPtr Constructor (string sessionId, OTSessionDelegate sessionDelegate);

		[Export ("connectWithApiKey:token:")]
		void Connect (string apiKey, string token);

		[Export ("disconnect")]
		void Disconnect ();

		[Export ("publish:")]
		void Publish (OTPublisher publisher);

		[Export ("unpublish:")]
		void Unpublish (OTPublisher publisher);

		[Export ("signalWithType:data:completionHandler:")]
		void SendSignal (string signalType, NSObject dataToSend, Action<NSError> completionHandler);

		[Export ("signalWithType:data:connections:completionHandler:")]
		void SendSignal (string signalType, NSObject dataToSend, OTConnection [] connections, Action<NSError> completionHandler);

		[Export ("receiveSignalType:withHandler:")]
		void SetReceiveHandler (string signalType, Action<NSString,NSObject,OTConnection> handler);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface OTSessionDelegate {
		[Export ("sessionDidConnect:")]
		void DidConnect (OTSession session);

		[Export ("sessionDidDisconnect:")]
		void DidDisconnect (OTSession session);

		[Export ("session:didFailWithError:")]
		void DidFailWithError (OTSession session, OTError error);

		[Export ("session:didReceiveStream:")]
		void DidReceiveStream (OTSession session, OTStream stream);

		[Export ("session:didDropStream:")]
		void DidDropStream (OTSession session, OTStream stream);

		[Export ("session:didCreateConnection:")]
		void DidCreateConnection (OTSession session, OTConnection connection);

		[Export ("session:didDropConnection:")]
		void DidDropConnection (OTSession session, OTConnection connection);

		
	}
	
	[BaseType (typeof (NSObject))]
	interface OTStream {
		[Export ("connection")]
		OTConnection Connection { get;  }

		[Export ("session")]
		OTSession Session { get;  }

		[Export ("streamId")]
		string StreamId { get;  }

		[Export ("type")]
		string Type { get;  }

		[Export ("creationTime")]
		NSDate CreationTime { get;  }

		[Export ("name")]
		string Name { get;  }

		[Export ("hasAudio")]
		bool HasAudio { get;  }

		[Export ("hasVideo")]
		bool HasVideo { get;  }

		[Export ("videoDimensions")]
		SizeF VideoDimensions { get; }
	}

	[BaseType (typeof (NSObject))]
	interface OTSubscriber {
		[Export ("session")]
		OTSession Session { get;  }

		[Export ("stream")]
		OTStream Stream { get;  }

		[Export ("view")]
		OTVideoView View { get;  }

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		[Wrap ("WeakDelegate")]
		OTSubscriberDelegate Delegate { get; set;  }

		[Export ("subscribeToAudio")]
		bool SubscribeToAudio { get; set;  }

		[Export ("subscribeToVideo")]
		bool SubscribeToVideo { get; set;  }

		[Export ("initWithStream:delegate:")]
		IntPtr Constructor (OTStream stream, OTSubscriberDelegate del);

		[Export ("close")]
		void Close ();

	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface OTSubscriberDelegate {
		[Abstract]
		[Export ("subscriberDidConnectToStream:")]
		void DidConnectToStream (OTSubscriber subscriber);

		[Export ("subscriber:didFailWithError:")]
		void DidFailWithError (OTSubscriber subscriber, OTError error);

		[Export ("subscriberVideoDataReceived:")]
		void VideoDataReceived (OTSubscriber subscriber);

		[Export ("stream:didChangeVideoDimensions:")]
		void DidChangeVideoDimensions (OTStream stream, SizeF dimensions);

		[Export ("subscriberVideoDisabled:")]
		void SubscriberVideoDisabled (OTSubscriber subscriber);
	}

	[BaseType (typeof (UIView))]
	interface OTVideoView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);

		[Export ("toolbarView")]
		UIView ToolbarView { get; }

		[Export ("videoView")]
		UIView VideoView { get; }

		[Export ("getImageWithBlock:")]
		void GetSnapshot (Action<UIImage> snapshotHanlder);
	}
}

