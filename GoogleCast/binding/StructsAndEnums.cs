using System;

namespace GoogleCast
{
	public enum GCKErrorCode
	{
		NetworkError = 1,
		Timeout = 2,
		DeviceAuthenticationFailure = 3,
		InvalidRequest = 4,
		Cancelled = 5,
		NotAllowed = 6,
		ApplicationNotFound = 7,
		ApplicationNotRunning = 8,
		AppDidEnterBackground = 91,
		Disconnected = 92,
		DuplicateRequest = 93,
		MediaLoadFailed = 94,
		InvalidMediaPlayerState = 95,
		Unknown = 99
	}

	public enum GCKMediaControlChannelResumeState
	{
		Unchanged = 0,
		Play = 1,
		Pause = 2
	}

	public enum GCKMediaStreamType
	{
		None = 0,
		Buffered = 1,
		Live = 2,
		Unknown = 99
	}

	public enum GCKMediaMetadataType
	{
		Generic = 0,
		Movie = 1,
		TvShow = 2,
		MusicTrack = 3,
		Photo = 4,
		User = 100
	}

	public enum GCKMediaPlayerState
	{
		Unknown = 0,
		Idle = 1,
		Playing = 2,
		Paused = 3,
		Buffering = 4
	}

	public enum GCKMediaPlayerIdleReason
	{
		None = 0,
		Finished = 1,
		Cancelled = 2,
		Interrupted = 3,
		Error = 4
	}

	public enum GCKAppAvailability
	{
		Unavailable,
		Available
	}

	public enum GCKSenderApplicationInfoPlatform
	{
		Android = 1,
		iOS = 2,
		Chrome = 3
	}
}

