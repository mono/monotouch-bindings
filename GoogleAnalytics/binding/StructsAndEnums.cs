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
}

