using System;

namespace Amazon.Login
{
	public enum ApiChooser
	{
		AuthorizeUser = 1,
		GetAccessToken = 2,
		ClearAuthorizationState = 3,
		GetProfile = 4
	}

	public enum AIErrorCode : uint
	{
		NoError,
		ApplicationNotAuthorized,
		ServerError,
		ErrorUserInterrupted,
		AccessDenied,
		DeviceError,
		InvalidInput,
		NetworkError,
		UnauthorizedClient,
		InternalError,
		UnknownError = uint.MaxValue
	}
}

