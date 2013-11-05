namespace GoogleAnalytics {

	public enum GAIErrorCode {
		// This error code indicates that there was no error. Never used.
		NoError = 0,

		// This error code indicates that there was a database-related error.
		DatabaseError,

		// This error code indicates that there was a network-related error.
		NetworkError,
	}

}