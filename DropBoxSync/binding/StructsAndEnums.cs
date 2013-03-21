using System;

namespace DropBoxSync.iOS
{
	public enum DBErrorCode
	{
		Unknown = 0,
		
		CoreSystem = 1, // System error, out of memory, etc
		
		Params = 2000, // An error due to data passed into the SDK
		ParamsInvalid, // A parameter is invalid, such as a nil object
		ParamsNotFound, // A file corresponding to a provided path was not found
		ParamsExists, // File already exists and was opened exclusively
		ParamsAlreadyOpen, // File was already open
		ParamsParent, // Parent does not exist or is not a folder
		ParamsNotEmpty, // Directory is not empty
		ParamsNotCached, // File was not yet in cache
		
		System = 3000, // An error in the library occurred
		SystemDiskSpace, // An error happened due to insufficient disk space
		
		Network = 4000, // An error occurred making a network request
		NetworkTimeout, // A connection timed out
		NetworkNoConnection, // No network connection available
		NetworkSSL, // Unable to verify the server's SSL certificate. Often caused by an out-of-date clock
		NetworkServer, // Unexpected server error
		
		Auth = 5000, // An authentication related problem occurred
		AuthUnlinked, // The user is no longer linked
		AuthInvalidApp, // An invalid app key or secret was provided
	}

	public enum DBFileState
	{
		Downloading,
		Idle,
		Uploading,
	}

	[Flags]
	public enum DBSyncStatus : uint
	{
		Downloading = 1,
		Uploading = 2,
		Syncing = 4,
		Online = 8
	}
}

