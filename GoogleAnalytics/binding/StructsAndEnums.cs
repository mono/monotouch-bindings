using System;

namespace GoogleAnalytics.iOS
{
	public enum GAIErrorCode
	{
		NoError = 0,
		DatabaseError,
		NetworkError
	}

	public enum GAILogLevel : uint
	{
		None = 0,
		Error = 1,
		Warning = 2,
		Info = 3,
		Verbose = 4
	}

	public enum TAGContainerCallbackRefreshType
	{
		Saved,
		Network
	}

	public enum TAGContainerCallbackRefreshFailure
	{
		NoSavedContainer,
		IoError,
		NoNetwork,
		NetworkError,
		ServerError,
		UnknownError
	}

	public enum TAGOpenType
	{
		PreferNonDefault,
		PreferFresh
	}

	public enum TAGLoggerLogLevelType
	{
		Verbose,
		Debug,
		Info,
		Warning,
		Error,
		None
	}

	public enum TAGRefreshMode
	{
		Standard,
		DefaultContainer
	}
}

