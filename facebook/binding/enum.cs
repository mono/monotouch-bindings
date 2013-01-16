namespace MonoTouch.FacebookConnect  {
	public enum FBRequestState {
		Ready, Loading, Complete, Error
	}

	public enum FBSessionState {
		Created = 0,
		CreatedTokenLoaded = 1,
		CreatedOpening = 2,
		Open = 1 | (1 << 9),
		OpenTokenExtended = 2 | (1 << 9),
		ClosedLoginFailed = 1 | (1 << 8),
		Closed = 2 | (1 << 8)
	}

	public enum FBSessionDefaultAudience {
		None = 0,
		OnlyMe = 10,
		Friends = 20,
		Everyone = 30
	}

	public enum FBSessionLoginBehavior {
		WithFallbackToWebView, WithNoFallbackToWebView, ForcingWebView, UseSystemAccountIfPresent
	}
}