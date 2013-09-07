using System;

namespace Couchbase
{
	public enum CBLStaleness {
		Never,
		OK,
		UpdateAfter
	}

	public enum CBLReplicationMode {
		Stopped,
		Offline,
		Idle,
		Active
	}

	public struct CBLManagerOptions {
		public bool ReadOnly;
		public bool NoReplicator;
	}
}