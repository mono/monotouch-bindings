using System;

namespace Parse
{
	public enum ParseCachePolicy
	{
		IgnoreCache = 0,
		CacheOnly,
		NetworkOnly,
		CacheElseNetwork,
		NetworkElseCache,
		CacheThenNetwork
	}

	public enum ParseSignUpFields
	{
		UsernameAndPassword = 0,
		Email = 1 << 0,
		Additional = 1 << 1, // this field can be used for something else
		SignUpButton = 1 << 2,
		DismissButton = 1 << 3,
		Default = UsernameAndPassword | Email | SignUpButton | DismissButton
	}

	public enum ParseLogInFields
	{
		None = 0,
		UsernameAndPassword = 1 << 0,
		PasswordForgotten = 1 << 1,
		LogInButton = 1 << 2,
		Facebook = 1 << 3,
		Twitter = 1 << 4,
		SignUpButton = 1 << 5,
		DismissButton = 1 << 6,
	    
		Default = UsernameAndPassword | LogInButton | SignUpButton | PasswordForgotten | DismissButton
	}
	
	public enum ParseMBProgressHUDMode
	{
		/** Progress is shown using an UIActivityIndicatorView. This is the default. */
		Indeterminate,
		/** Progress is shown using a MBRoundProgressView. */
		Determinate,
		/** Shows a custom view */
		CustomView
	}

	public enum ParseMBProgressHUDAnimation
	{
		/** Opacity animation */
		Fade,
		/** Opacity + scale animation */
		Zoom
	}

	public enum ParseFBRequestState
	{
		Ready,
		Loading,
		Complete,
		Error
	}
	;

}
