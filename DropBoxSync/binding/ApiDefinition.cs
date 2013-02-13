using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace DropBoxSync.iOS
{
	delegate void DBObserverHandler ();
	delegate void DBAccountManagerObserverHandler (DBAccount account);

	[BaseType (typeof (NSObject))]
	interface DBAccount {

		[Export ("unlink")]
		void Unlink ();

		[Export ("userId")]
		string UserId { get; }

		[Export ("linked")]
		bool Linked { [Bind ("isLinked")] get; }

		[Export ("info")]
		DBAccountInfo Info { get; }

		[Export ("addObserver:block:")]
		void AddObserver (NSObject observer, DBObserverHandler handler);

		[Export ("removeObserver:")]
		void RemoveObserver (NSObject observer);
	}

	[BaseType (typeof (NSObject))]
	interface DBAccountInfo {

		[Export ("displayName")]
		string DisplayName { get; }

		[Export ("email")]
		string Email { get; }
	}

	[BaseType (typeof (NSObject))]
	interface DBAccountManager {

		[Export ("initWithAppKey:secret:")]
		IntPtr Constructor (string key, string secret);

		[Static, Export ("setSharedManager:")]
		void SetSharedManager (DBAccountManager sharedManager);

		[Static, Export ("sharedManager")]
		DBAccountManager SharedManager { get; }

		[Export ("linkFromController:")]
		void LinkFromController (UIViewController rootController);

		[Export ("handleOpenURL:")]
		DBAccount HandleOpenURL (NSUrl url);

		[Export ("linkedAccount")]
		DBAccount LinkedAccount { get; }

		[Export ("addObserver:block:")]
		void AddObserver (NSObject observer, DBAccountManagerObserverHandler handler);

		[Export ("removeObserver:")]
		void RemoveObserver (NSObject observer);
	}

	[BaseType (typeof (NSError))]
	interface DBError {

		[Export ("code")] [New]
		DBErrorCode Code { get; }
	}

	[BaseType (typeof (NSError))]
	interface DBFile {

		// TODO: Missing for now
//		[Export ("readHandle:")]
//		NSFileHandle ReadHandle (out DBError error);

		[Export ("readData:")]
		NSData ReadData (out DBError error);

		[Export ("readString:")]
		string ReadString (out DBError error);

		[Export ("writeContentsOfFile:shouldSteal:error:")]
		bool WriteContentsOfFile (string localPath, bool shouldSteal, out DBError error);

		[Export ("writeData:error:")]
		bool WriteData (NSData data, out DBError error);

		[Export ("writeString:error:")]
		bool WriteString (string aString, out DBError error);

		[Export ("update:")]
		bool Update (out DBError error);

		[Export ("close")]
		bool Close ();

		[Export ("info")]
		DBFileInfo Info { get; }

		[Export ("open")]
		bool Open { [Bind ("isOpen")] get; }

		[Export ("status")]
		DBFileStatus Status { get; }

		[Export ("newerStatus")]
		DBFileStatus NewerStatus { get; }

		[Export ("addObserver:block:")]
		void AddObserver (NSObject observer, DBObserverHandler handler);

		[Export ("removeObserver:")]
		void RemoveObserver (NSObject observer);
	}

	[BaseType (typeof (NSError))]
	interface DBFileInfo {

		[Export ("path")]
		DBPath Path { get; }

		[Export ("isFolder")]
		bool IsFolder { get; }

		[Export ("modifiedTime")]
		NSDate ModifiedTime { get; }

		[Export ("size")]
		long Size { get; }
	}

	[BaseType (typeof (NSError))]
	interface DBFileStatus {

		[Export ("cached")]
		bool Cached { get; }

		[Export ("state")]
		DBFileState State { get; }

		[Export ("progress")]
		float Progress { get; }

		[Export ("error")]
		DBError Error { get; }
	}

	[BaseType (typeof (NSError))]
	interface DBFilesystem {

		[Export ("initWithAccount:")]
		IntPtr Constructor (DBAccount account);

		[Static, Export ("setSharedFilesystem:")]
		void SetSharedFilesystem (DBFilesystem filesystem);

		[Static, Export ("sharedFilesystem")]
		DBFilesystem SharedFilesystem { get; }

		[Export ("listFolder:error:")]
		DBFileInfo [] ListFolder (DBPath path, out DBError error);

		[Export ("fileInfoForPath:error:")]
		DBFileInfo FileInfoForPath (DBPath path, out DBError error);

		[Export ("openFile:error:")]
		DBFile OpenFile (DBPath path, out DBError error);

		[Export ("createFile:error:")]
		DBFile CreateFile (DBPath path, out DBError error);

		[Export ("createFolder:error:")]
		bool CreateFolder (DBPath path, out DBError error);

		[Export ("deletePath:error:")]
		bool DeletePath (DBPath path, out DBError error);

		[Export ("movePath:toPath:error:")]
		bool MovePath (DBPath fromPath, DBPath toPath, out DBError error);

		[Export ("account")]
		DBAccount Account { get; }

		[Export ("completedFirstSync")]
		bool CompletedFirstSync { get; }

		[Export ("shutDown")]
		bool ShutDown { [Bind ("isShutDown")] get; }

		[Export ("status")]
		DBSyncStatus Status { get; }

		[Export ("addObserver:forPath:block:")]
		bool AddObserver (NSObject observer, DBPath path, DBObserverHandler handler);

		[Export ("addObserver:forPathAndChildren:block:")]
		bool AddObserverForPathAndChildren (NSObject observer, DBPath path, DBObserverHandler handler);

		[Export ("addObserver:forPathAndDescendants:block:")]
		bool AddObserverForPathAndDescendants (NSObject observer, DBPath path, DBObserverHandler handler);

		[Export ("removeObserver:")]
		void RemoveObserver (NSObject observer);
	}

	[BaseType (typeof (NSError))]
	interface DBPath {

		[Static, Export ("root")]
		DBPath Root { get; }

		[Export ("initWithString:")]
		IntPtr Constructor (string path);

		[Export ("name")]
		string Name { get; }

		[Export ("childPath:")]
		DBPath ChildPath (string childName);

		[Export ("parent")]
		DBPath Parent { get; }

		[Export ("stringValue")]
		string StringValue { get; }
	}
}

