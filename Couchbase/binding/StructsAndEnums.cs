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

	public enum TDStatus {
		OK             = 200,
		Created        = 201,
		Accepted       = 206,
		
		NotModified    = 304,
		
		BadRequest     = 400,
		Forbidden      = 403,
		NotFound       = 404,
		NotAcceptable  = 406,
		Conflict       = 409,
		Duplicate      = 412,      // Formally known as "Precondition Failed"
		UnsupportedType= 415,
		
		ServerError    = 500,
		UpstreamError  = 502,      // aka Bad Gateway -- upstream server error
		
		BadEncoding    = 490,
		BadAttachment  = 491,
		AttachmentNotFound = 492,
		BadJSON        = 493,
		BadID          = 494,
		BadParam       = 495,
		
		DBError        = 590,      // SQLite error
		CorruptError   = 591,      // bad data in database
		AttachmentError= 592,      // problem with attachment store
		CallbackError  = 593,      // app callback (emit fn, etc.) failed
		Exception      = 594,      // Exception raised/caught
	}
}

