using System;

namespace OpenTok
{
	public enum OTSessionErrorCode  {
		AuthorizationFailure,
		InvalidSessionId,
		ConnectionFailed,
		NoMessagingServer,
		DKUpdateRequired,
		ConnectionRefused,
		StateFailed,
		P2PSessionUnsupported,
		UnknownServerError,
		P2PSessionRequired,
		P2PSessionMaxParticipants,
		ConnectionTimeout,
		CompatibilityMismatch,
		SignalConnection
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
		elfSubscribeFailure
	}

	public enum OTSessionConnectionStatus {
		Connected,
		Connecting,
		Disconnected,
		Failed
	}
}

