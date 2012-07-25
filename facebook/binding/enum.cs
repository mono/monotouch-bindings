namespace MonoTouch.FacebookConnect  {
	public enum FBRequestState {
		Ready, Loading, Complete, Error
	}

	public enum FBSessionState {
		Created,
		CreatedTokenLoaded,
		CreatedOpening,

		Open = 1 | OPENBIT,
		OpenTokenExtended = 2 | OPENBIT,

		ClosedLoginFailed = 1 | TERMINALBIT,
		Closed = 2 | TERMINALBIT,

		TERMINALBIT = 1 << 8,
		OPENBIT = 1 << 9,
	}

	public enum FBSessionLoginBehavior {
		WithFallbackToWebView,
		WithNoFallbackToWebView,
		ForcingWebView,
	}
}