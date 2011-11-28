namespace GoogleAnalytics {

	public enum GanError : uint {
		None = 0,
		InvalidInput = 0xbade7a9,
		EventsPerSessionLimit = 0xbad5704e,
		NotStarted = 0xbada55,
		DatabaseError = 0xbadbaddb
	}

	public enum GanCVScope {
		Visitor = 1, Session, Page
	}
}