using System;

namespace opentok
{

	public enum OTSessionErrorCode {
		AuthorizationFailure,
		InvalidSessionId,
		ConnectionFailed,
		NoMessagingServer,
		SDKUpdateRequired,
		ConnectionRefused,
		SessionStateFailed,
		P2SessionUnsupported,
		UnknownServerError,
		P2SessionRequired,
		P2SessionMaxParticipants,
		SessionConnectionTimeout,
		SessionCompatibilityMismatch,
		SessionSignalConnection
	}
	
	public enum OTPublisherErrorCode {
	    NoMediaPublished,
	    UserDeniedCameraAccess,
	    SessionDisconnected
	} 
	
	public enum OTSubscriberErrorCode {
	    FailedToConnect,
	    ConnectionTimedOut,
	    NoStreamMedia,
	    InitializationFailure,
	    InvalidStreamType,
	    SelfSubcribeFailure
	} 

	public enum OTSessionEnvironment {
		Production, Staging, 
	}
	
	public enum OTSessionConnectionStatus {
		Connected, Connecting, Disconnected, Failed
	}
}

