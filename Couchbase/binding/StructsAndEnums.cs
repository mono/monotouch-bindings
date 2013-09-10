using System;

namespace Couchbase
{
	public enum Staleness {
		Never,
		OK,
		UpdateAfter
	}

	public enum ReplicationMode {
		Stopped,
		Offline,
		Idle,
		Active
	}

	public struct ManagerOptions {
		public bool ReadOnly;
		public bool NoReplicator;
	}
}