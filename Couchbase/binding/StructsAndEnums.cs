using System;

namespace Couchbase
{
	public enum RestLogLevel {
		Nothing = 0, RequestUrls, RequestHeaders
	}

	public enum CouchReplicationMode {
		Stopped, Offline, Idle, Active
	}

	public enum CouchStaleness {
		Never, Ok, UpdateAfter
	}

	public enum CouchReplicationState {
		Idle, Triggered, Completed, Error, 
	}

}

