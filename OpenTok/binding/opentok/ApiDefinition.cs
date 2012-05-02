using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.AVFoundation;

namespace opentok
{
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//

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
	[BaseType (typeof (NSObject))]
	interface OTPublisherDelegate {
		[Export ("publisher:didFailWithError:")]
		[Abstract]
		void DidFail (OTPublisher publisher, OTError error);
		
		[Export ("publisherDidStartStreaming:")]
		void DidStartStreaming (OTPublisher publisher);
		
		[Export ("publisherDidStopStreaming:")]
		void DidStopStreaming (OTPublisher publisher);
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

		[Export ("initWithSessionId:delegate:environment:")]
		IntPtr Constructor (string sessionId, OTSessionDelegate sessionDelegate, OTSessionEnvironment environment);

		[Export ("connectWithApiKey:token:")]
		void Connect (string apiKey, string token);

		[Export ("disconnect")]
		void Disconnect ();

		[Export ("publish:")]
		void Publish (OTPublisher publisher);

		[Export ("unpublish:")]
		void Unpublish (OTPublisher publisher);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface OTSessionDelegate {
		[Abstract]
		[Export ("sessionDidConnect:")]
		void DidConnect (OTSession session);

		[Abstract]
		[Export ("sessionDidDisconnect:")]
		void DidDisconnect (OTSession session);

		[Abstract]
		[Export ("session:didFailWithError:")]
		void DidFailWithError (OTSession session, OTError error);

		[Abstract]
		[Export ("session:didReceiveStream:")]
		void DidReceiveStream (OTSession session, OTStream stream);

		[Abstract]
		[Export ("session:didDropStream:")]
		void DidDropStream (OTSession session, OTStream stream);
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
	}

	[BaseType (typeof (NSObject))]
	interface OTSubscriber {
		[Export ("session")]
		OTSession Session { get;  }

		[Export ("stream")]
		OTStream Stream { get;  }

		[Export ("view")]
		UIView View { get;  }

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
	interface OTSubscriberDelegate {
		[Abstract]
		[Export ("subscriberDidConnectToStream:")]
		void DidConnectToStream (OTSubscriber subscriber);

		[Abstract]
		[Export ("subscriber:didFailWithError:")]
		void DidFailWithError (OTSubscriber subscriber, OTError error);

		[Abstract]
		[Export ("subscriberVideoDataReceived:")]
		void VideoDataReceived (OTSubscriber subscriber);
	}
}

