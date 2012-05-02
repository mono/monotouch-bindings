using System;

namespace opentok
{

	public enum OTSessionErrorCode {
	    AuthorizationFailure,       /* An invalid API key or token was provided */
	    InvalidSessionId,           /* An invalid session ID was provided */
	    ConnectionFailed,           /* There was an error connecting to OpenTok services */
	    NoMessagingServer,          /* No messaging server is available for this session */
	    SDKUpdateRequired           /* A new version of the OpenTok SDK is available and required to connect to this session */
	}
	
	public enum OTPublisherErrorCode {
	    NoMediaPublished,           /* Attempting to publish a stream with no audio or video */
	    UserDeniedCameraAccess,     /* The user denied access to the camera during publishing */
	    AlreadyPublishing,          /* Already publishing */
	    SessionDisconnected         /* Attempting to publish to a disconnected session */
	} 
	
	public enum OTSubscriberErrorCode {
	    FailedToConnect,            /* Subscriber failed to connect to stream. Can reattempt connection */
	    ConnectionTimedOut,         /* Subscriber timed out while attempting to connect to stream. Can reattempt connection */
	    NoStreamMedia,              /* The stream has no audio or video to subscribe to  */
	    InitializationFailure       /* Subscriber failed to initialize */
	} 

	public enum OTSessionEnvironment {
		Production, Staging, 
	}
	
	public enum OTSessionConnectionStatus {
		Connected, Connecting, Disconnected, Failed
	}
}

