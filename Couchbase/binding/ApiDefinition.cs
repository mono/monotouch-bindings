using System;

using System.Runtime.InteropServices;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Couchbase {

  public delegate void MapEmitBlock(NSObject key, [NullAllowed] NSObject value);
	public delegate bool FilterBlock(Revision revision, NSDictionary options);
	public delegate bool ValidationBlock(Revision newRevision, ValidationContext context);
	public delegate void MapBlock(NSDictionary doc, [BlockCallback] MapEmitBlock emit);
	public delegate NSObject ReduceBlock(NSArray keys, NSArray values, bool rereduce);
	public delegate bool ChangeEnumeratorBlock(String key, NSObject oldValue, NSObject newValue);

	[BaseType (typeof (NSObject), Name = "CBLAttachment")]
	public partial interface Attachment {

		[Export ("initWithContentType:body:")]
		IntPtr Constructor (string contentType, NSObject body);

		[Export ("revision", ArgumentSemantic.Retain)]
		RevisionBase Revision { get; }

		[Export ("document")]
		Document Document { get; }

		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		[Export ("contentType")]
		string ContentType { get; }

		[Export ("length")]
		UInt64 Length { get; }

		[Export ("metadata")]
		NSDictionary Metadata { get; }

		[Export ("body")]
		NSData Body { get; }

		[Export ("bodyURL")]
		NSUrl BodyURL { get; }

		[Export ("updateBody:contentType:error:")]
		Revision UpdateBody (NSData body, string contentType, out NSError outError);
	}
  public interface IViewCompiler { }

	[Protocol, BaseType (typeof (NSObject), Name = "CBLViewCompiler")]
	public partial interface ViewCompiler {

		[Export ("compileMapFunction:language:")]
		MapBlock CompileMapFunction (string mapSource, string language);

		[Export ("compileReduceFunction:language:")]
		ReduceBlock CompileReduceFunction (string reduceSource, string language);
	}

	[BaseType (typeof (NSObject), Name = "CBLView")]
	public partial interface View {

		[Export ("database")]
		Database Database { get; }

		[Export ("name")]
		string Name { get; }

		[Export ("mapBlock")]
		MapBlock MapBlock { get; }

		[Export ("reduceBlock")]
		ReduceBlock ReduceBlock { get; }

		[Export ("setMapBlock:reduceBlock:version:")]
		bool SetMapBlock (MapBlock mapBlock, [NullAllowed] ReduceBlock reduceBlock, string version);

		[Export ("setMapBlock:version:")]
		bool SetMapBlock (MapBlock mapBlock, string version);

		[Export ("stale")]
		bool Stale { get; }

		[Export ("lastSequenceIndexed")]
		Int64 LastSequenceIndexed { get; }

		[Export ("removeIndex")]
		void RemoveIndex ();

		[Export ("deleteView")]
		void DeleteView ();

		[Export ("query")]
		Query Query { get; }

		[Static, Export ("totalValues:")]
		NSNumber TotalValues (NSNumber [] values);

		[Static, Export ("compiler")]
		IViewCompiler Compiler { get; set; }
	}
  public interface IFilterCompiler { }

	[Protocol, BaseType (typeof (NSObject), Name = "CBLFilterCompiler")]
	public partial interface FilterCompiler {

		[Export ("compileFilterFunction:language:")]
		FilterBlock CompileFilterFunction (string filterSource, string language);
	}

	[BaseType (typeof (NSObject), Name = "CBLDatabase")]
	public partial interface Database {

		[Export ("name")]
		string Name { get; }

		[Export ("manager")]
		Manager Manager { get; }

		[Export ("documentCount")]
		uint DocumentCount { get; }

		[Export ("lastSequenceNumber")]
		Int64 LastSequenceNumber { get; }

		[Export ("internalURL")]
		NSUrl InternalURL { get; }

		[Export ("compact:")]
		bool Compact (out NSError outError);

		[Export ("deleteDatabase:")]
		bool DeleteDatabase (out NSError outError);

		[Export ("documentWithID:")]
		Document DocumentWithID (string docID);

		[Export ("objectForKeyedSubscript:")]
		Document ObjectForKeyedSubscript (string key);

		[Export ("untitledDocument")]
		Document UntitledDocument { get; }

		[Export ("cachedDocumentWithID:")]
		Document CachedDocumentWithID (string docID);

		[Export ("clearDocumentCache")]
		void ClearDocumentCache ();

		[Export ("getLocalDocumentWithID:")]
		NSDictionary GetLocalDocumentWithID (string localDocID);

		[Export ("putLocalDocument:withID:error:")]
		bool PutLocalDocument (NSDictionary properties, string localDocID, out NSError outError);

		[Export ("deleteLocalDocumentWithID:error:")]
		bool DeleteLocalDocumentWithID (string localDocID, out NSError outError);

		[Export ("queryAllDocuments")]
		Query QueryAllDocuments { get; }

		[Export ("slowQueryWithMap:")]
		Query SlowQueryWithMap (MapBlock mapBlock);

		[Export ("viewNamed:")]
		View ViewNamed (string name);

		[Export ("existingViewNamed:")]
		View ExistingViewNamed (string name);

		[Export ("defineValidation:asBlock:")]
		void DefineValidation (string validationName, ValidationBlock validationBlock);

		[Export ("validationNamed:")]
		ValidationBlock ValidationNamed (string validationName);

		[Export ("defineFilter:asBlock:")]
		void DefineFilter (string filterName, FilterBlock filterBlock);

		[Export ("filterNamed:")]
		FilterBlock FilterNamed (string filterName);

		[Static, Export ("filterCompiler")]
		IFilterCompiler FilterCompiler { get; set; }

		[Export ("inTransaction:")]
		bool InTransaction (Action<bool> bloc);

		[Export ("allReplications")]
		Replication [] AllReplications { get; }

		[Export ("pushToURL:")]
		Replication PushToURL (NSUrl url);

		[Export ("pullFromURL:")]
		Replication PullFromURL (NSUrl url);

		[Export ("replicateWithURL:exclusively:")]
		Replication [] ReplicateWithURL ([NullAllowed] NSUrl otherDbURL, bool exclusively);

		[Notification, Field ("kCBLDatabaseChangeNotification", "__Internal")]
		NSString DatabaseChangeNotification { get; }
	}

	[BaseType (typeof (NSObject), Name = "CBLValidationContext")]
	public partial interface ValidationContext {

		[Export ("currentRevision")]
		Revision CurrentRevision { get; }

		[Export ("errorType")]
		int ErrorType { get; set; }

		[Export ("errorMessage", ArgumentSemantic.Copy)]
		string ErrorMessage { get; set; }

		[Export ("changedKeys")]
		NSObject [] ChangedKeys { get; }

		[Export ("allowChangesOnlyTo:")]
		bool AllowChangesOnlyTo (NSObject [] allowedKeys);

		[Export ("disallowChangesTo:")]
		bool DisallowChangesTo (NSObject [] disallowedKeys);

		[Export ("enumerateChanges:")]
		bool EnumerateChanges (Func<NSString, NSObject, NSObject, bool> enumerator);
	}

	[BaseType (typeof (NSObject), Name = "CBLDocument")]
	public partial interface Document {

		[Export ("database")]
		Database Database { get; }

		[Export ("documentID")]
		string DocumentID { get; }

		[Export ("abbreviatedID")]
		string AbbreviatedID { get; }

		[Export ("isDeleted")]
		bool IsDeleted { get; }

		[Export ("deleteDocument:")]
		bool DeleteDocument (out NSError outError);

		[Export ("purgeDocument:")]
		bool PurgeDocument (out NSError outError);

		[Export ("currentRevisionID", ArgumentSemantic.Copy)]
		string CurrentRevisionID { get; }

		[Export ("currentRevision")]
		Revision CurrentRevision { get; }

		[Export ("revisionWithID:")]
		Revision RevisionWithID (string revisionID);

		[Export ("getRevisionHistory:")]
    Revision [] GetRevisionHistory (out NSError outError);

		[Export ("getConflictingRevisions:")]
    Revision [] GetConflictingRevisions (out NSError outError);

		[Export ("getLeafRevisions:")]
    Revision [] GetLeafRevisions (out NSError outError);

		[Export ("newRevision")]
		NewRevision NewRevision { get; }

		[Export ("properties", ArgumentSemantic.Copy)]
		NSDictionary Properties { get; }

		[Export ("userProperties", ArgumentSemantic.Copy)]
		NSDictionary UserProperties { get; }

		[Export ("propertyForKey:")]
		NSObject PropertyForKey (string key);

		[Export ("objectForKeyedSubscript:")]
		NSObject ObjectForKeyedSubscript (string key);

		[Export ("putProperties:error:")]
		Revision PutProperties (NSDictionary properties, out NSError outError);

		[Export ("modelObject", ArgumentSemantic.Assign)]
		NSObject ModelObject { get; set; }
	}
  public interface IDocumentModel {}

	[Protocol, BaseType (typeof (NSObject), Name = "CBLDocumentModel")]
	public partial interface DocumentModel {

		[Export ("tdDocumentChanged:")]
		void DocumentChanged (Document doc);

		[Notification, Field ("kCBLDocumentChangeNotification", "__Internal")]
		NSString DocumentChangeNotification { get; }
	}

	[BaseType (typeof (NSObject), Name = "CBLManager")]
	public partial interface Manager {

		[Static, Export ("sharedInstance")]
		Manager SharedInstance { get; }

		[Static, Export ("isValidDatabaseName:")]
		bool IsValidDatabaseName (string name);

		[Static, Export ("defaultDirectory")]
		string DefaultDirectory { get; }

		[Export ("initWithDirectory:options:error:")]
		IntPtr Constructor (string directory, ManagerOptions options, out NSError outError);

		[Export ("close")]
		void Close ();

		[Export ("directory")]
		string Directory { get; }

		[Export ("databaseNamed:error:")]
		Database DatabaseNamed (string name, out NSError outError);

		[Export ("objectForKeyedSubscript:")]
		Database ObjectForKeyedSubscript (string key);

		[Export ("createDatabaseNamed:error:")]
		Database CreateDatabaseNamed (string name, out NSError outError);

		[Export ("allDatabaseNames")]
		NSString [] AllDatabaseNames { get; }

		[Export ("replaceDatabaseNamed:withDatabaseFile:withAttachments:error:")]
		bool ReplaceDatabaseNamed (string databaseName, string databasePath, string attachmentsPath, out NSError outError);

		[Export ("asyncTellDatabaseNamed:to:")]
		void AsyncTellDatabaseNamed (string dbName, Action<Database> block);

		[Export ("internalURL")]
		NSUrl InternalURL { get; }
	}

	[BaseType (typeof (NSObject), Name = "MYDynamicObject")]
	public partial interface CouchDynamicObject {

		[Static, Export ("propertyNames")]
		NSSet PropertyNames { get; }

		[Export ("getValueOfProperty:")]
		NSObject GetValueOfProperty (string property);

		[Export ("setValue:ofProperty:")]
		bool SetValue (NSObject value, string property);

		[Static, Export ("classOfProperty:")]
		Class ClassOfProperty (string propertyName);

		[Static, Export ("getterKey:")]
		string GetterKey (Selector sel);

		[Static, Export ("setterKey:")]
		string SetterKey (Selector sel);

		[Static, Export ("impForGetterOfProperty:ofClass:")]
		IntPtr ImpForGetterOfProperty (string property, Class propertyClass);

		[Static, Export ("impForSetterOfProperty:ofClass:")]
		IntPtr ImpForSetterOfProperty (string property, Class propertyClass);

		[Static, Export ("impForGetterOfProperty:ofType:")]
		IntPtr ImpForGetterOfProperty (string property, string propertyType);

		[Static, Export ("impForSetterOfProperty:ofType:")]
		IntPtr ImpForSetterOfProperty (string property, string propertyType);
	}


	[BaseType (typeof (CouchDynamicObject), Name = "CBLModel")]
	public partial interface Model : IDocumentModel {

		[Static, Export ("modelForDocument:")]
		Model ModelForDocument (Document document);

		[Export ("initWithNewDocumentInDatabase:")]
		IntPtr Constructor (Database database);

		[Export ("document", ArgumentSemantic.Retain)]
		Document Document { get; }

		[Export ("database", ArgumentSemantic.Retain)]
		Database Database { get; set; }

		[Export ("isNew")]
		bool IsNew { get; }

		[Export ("save:")]
		bool Save (out NSError outError);

		[Export ("autosaves")]
		bool Autosaves { get; set; }

		[Export ("autosaveDelay")]
		double AutosaveDelay { get; }

		[Export ("needsSave")]
		bool NeedsSave { get; }

		[Export ("propertiesToSave")]
		NSDictionary PropertiesToSave { get; }

		[Export ("deleteDocument:")]
		bool DeleteDocument (out NSError outError);

		[Export ("timeSinceExternallyChanged")]
		double TimeSinceExternallyChanged { get; }

		[Static, Export ("saveModels:error:")]
		bool SaveModels (NSObject [] models, out NSError outError);

		[Export ("markExternallyChanged")]
		void MarkExternallyChanged ();

		[Export ("attachmentNames")]
		NSString [] AttachmentNames { get; }

		[Export ("attachmentNamed:")]
		Attachment AttachmentNamed (string name);

		[Export ("addAttachment:named:")]
		void AddAttachment (Attachment attachment, string name);

		[Export ("removeAttachmentNamed:")]
		void RemoveAttachmentNamed (string name);

		[Export ("initWithDocument:")]
		IntPtr Constructor (Document document);

		[Export ("idForNewDocumentInDatabase:")]
		string IdForNewDocumentInDatabase (Database db);

		[Export ("didLoadFromDocument")]
		void DidLoadFromDocument ();

		[Export ("databaseForModelProperty:")]
		Database DatabaseForModelProperty (string propertyName);

		[Export ("markNeedsSave")]
		void MarkNeedsSave ();

		[Static, Export ("itemClassForArrayProperty:")]
		Class ItemClassForArrayProperty (string property);
	}

	[Category, BaseType (typeof (Database))]
	public partial interface Model_Database {

		[Static, Export ("unsavedModels")]
		NSObject [] UnsavedModels { get; }

		[Static, Export ("saveAllModels:")]
		bool SaveAllModels (out NSError outError);

		[Static, Export ("autosaveAllModels:")]
		bool AutosaveAllModels (out NSError outError);
	}

	[BaseType (typeof (NSArray), Name = "CBLModelArray")]
	public partial interface ModelArray {

		[Export ("initWithOwner:property:itemClass:docIDs:")]
		IntPtr Constructor (Model owner, string property, Class itemClass, String [] docIDs);

		[Export ("initWithOwner:property:itemClass:models:")]
		IntPtr Constructor (Model owner, string property, Class itemClass, NSObject [] models);

		[Export ("docIDs")]
		NSObject [] DocIDs { get; }
	}
	
	[BaseType (typeof (NSObject), Name = "CBLModelFactory")]
	public partial interface ModelFactory {

		[Static, Export ("sharedInstance")]
		ModelFactory SharedInstance { get; }

		[Export ("modelForDocument:")]
		NSObject ModelForDocument (Document document);

		[Export ("registerClass:forDocumentType:")]
		void RegisterClass (NSObject classOrName, string type);

		[Export ("classForDocument:")]
		Class ClassForDocument (Document document);

		[Export ("classForDocumentType:")]
		Class ClassForDocumentType (string type);
	}

	[BaseType (typeof (NSObject), Name = "CBLQuery")]
	public partial interface Query {

		[Export ("database")]
		Database Database { get; }

		[Export ("limit")]
		uint Limit { get; set; }

		[Export ("skip")]
		uint Skip { get; set; }

		[Export ("descending")]
		bool Descending { get; set; }

		[Export ("startKey", ArgumentSemantic.Copy)]
		NSObject StartKey { get; set; }

		[Export ("endKey", ArgumentSemantic.Copy)]
		NSObject EndKey { get; set; }

		[Export ("startKeyDocID", ArgumentSemantic.Copy)]
		string StartKeyDocID { get; set; }

		[Export ("endKeyDocID", ArgumentSemantic.Copy)]
		string EndKeyDocID { get; set; }

		[Export ("stale")]
		Staleness Stale { get; set; }

		[Export ("keys", ArgumentSemantic.Copy)]
		NSObject [] Keys { get; set; }

		[Export ("mapOnly")]
		bool MapOnly { get; set; }

		[Export ("groupLevel")]
		uint GroupLevel { get; set; }

		[Export ("prefetch")]
		bool Prefetch { get; set; }

		[Export ("sequences")]
		bool Sequences { get; set; }

		[Export ("includeDeleted")]
		bool IncludeDeleted { get; set; }

		[Export ("error")]
		NSError Error { get; }

		[Export ("rows")]
		QueryEnumerator Rows { get; }

		[Export ("rowsIfChanged")]
		QueryEnumerator RowsIfChanged { get; }

		[Export ("runAsync:")]
		void RunAsync (Action<QueryEnumerator> onComplete);

		[Export ("asLiveQuery")]
		LiveQuery AsLiveQuery { get; }
	}

	[BaseType (typeof (Query), Name = "CBLLiveQuery")]
	public partial interface LiveQuery {

		[Export ("start")]
		void Start ();

		[Export ("stop")]
		void Stop ();
	}

	[BaseType (typeof (NSEnumerator), Name = "CBLQueryEnumerator")]
	public partial interface QueryEnumerator {

		[Export ("count")]
		uint Count { get; }

		[Export ("sequenceNumber")]
		UInt64 SequenceNumber { get; }

		[Export ("nextRow")]
		QueryRow NextRow { get; }

		[Export ("rowAtIndex:")]
		QueryRow RowAtIndex (uint index);

		[Export ("error")]
		NSError Error { get; }
	}

	[BaseType (typeof (NSObject), Name = "CBLQueryRow")]
	public partial interface QueryRow {

		[Export ("key")]
		NSObject Key { get; }

		[Export ("value")]
		NSObject Value { get; }

		[Export ("documentID")]
		string DocumentID { get; }

		[Export ("sourceDocumentID")]
		string SourceDocumentID { get; }

		[Export ("documentRevision")]
		string DocumentRevision { get; }

		[Export ("document")]
		Document Document { get; }

		[Export ("documentProperties")]
		NSDictionary DocumentProperties { get; }

		[Export ("keyAtIndex:")]
		NSObject KeyAtIndex (uint index);

		[Export ("key0")]
		NSObject Key0 { get; }

		[Export ("key1")]
		NSObject Key1 { get; }

		[Export ("key2")]
		NSObject Key2 { get; }

		[Export ("key3")]
		NSObject Key3 { get; }

		[Export ("localSequence")]
		UInt64 LocalSequence { get; }
	}
	
	[BaseType (typeof (Model), Name = "CBLReplication")]
	public partial interface Replication {

		[Export ("initPullFromSourceURL:toDatabase:")]
		IntPtr Constructor (NSUrl source, Database database);

		[Export ("initPushFromDatabase:toTargetURL:")]
		IntPtr Constructor (Database database, NSUrl target);

		[Export ("localDatabase")]
		Database LocalDatabase { get; }

		[Export ("remoteURL")]
		NSUrl RemoteURL { get; }

		[Export ("pull")]
		bool Pull { get; }

		[Export ("persistent")]
		bool Persistent { get; set; }

		[Export ("create_target")]
		bool CreateTarget { get; set; }

		[Export ("continuous")]
		bool Continuous { get; set; }

		[Export ("filter", ArgumentSemantic.Copy)]
		string Filter { get; set; }

		[Export ("query_params", ArgumentSemantic.Copy)]
		NSDictionary Query_params { get; set; }

		[Export ("doc_ids", ArgumentSemantic.Copy)]
		NSObject [] DocIds { get; set; }

		[Export ("headers", ArgumentSemantic.Copy)]
		NSDictionary Headers { get; set; }

		[Export ("credential", ArgumentSemantic.Retain)]
		NSUrlCredential Credential { get; set; }

		[Export ("OAuth", ArgumentSemantic.Copy)]
		NSDictionary OAuth { get; set; }

		[Export ("facebookEmailAddress", ArgumentSemantic.Copy)]
		string FacebookEmailAddress { get; set; }

		[Export ("registerFacebookToken:forEmailAddress:")]
		bool RegisterFacebookToken (string token, string email);

		[Export ("personaOrigin")]
		NSUrl PersonaOrigin { get; }

		[Export ("personaEmailAddress", ArgumentSemantic.Copy)]
		string PersonaEmailAddress { get; set; }

		[Export ("registerPersonaAssertion:")]
		bool RegisterPersonaAssertion (string assertion);

		[Static, Export ("setAnchorCerts:onlyThese:")]
		void SetAnchorCerts (NSObject [] certs, bool onlyThese);

		[Export ("start")]
		void Start ();

		[Export ("stop")]
		void Stop ();

		[Export ("restart")]
		void Restart ();

		[Export ("mode")]
		ReplicationMode Mode { get; }

		[Export ("running")]
		bool Running { get; }

		[Export ("error", ArgumentSemantic.Retain)]
		NSError Error { get; }

		[Export ("completed")]
		uint Completed { get; }

		[Export ("total")]
		uint Total { get; }

    [Notification, Field ("kCBLReplicationChangeNotification", "__Internal")]
		NSString ReplicationChangeNotification { get; }
	}

	[BaseType (typeof (NSObject), Name = "CBLRevisionBase")]
	public partial interface RevisionBase {

		[Export ("document")]
		Document Document { get; }

		[Export ("database")]
		Database Database { get; }

		[Export ("isDeleted")]
		bool IsDeleted { get; }

		[Export ("revisionID")]
		string RevisionID { get; }

		[Export ("properties", ArgumentSemantic.Copy)]
		NSDictionary Properties { get; }

		[Export ("userProperties", ArgumentSemantic.Copy)]
		NSDictionary UserProperties { get; }

		[Export ("propertyForKey:")]
		NSObject PropertyForKey (string key);

		[Export ("objectForKeyedSubscript:")]
		NSObject ObjectForKeyedSubscript (string key);

		[Export ("attachmentNames")]
		String [] AttachmentNames { get; }

		[Export ("attachmentNamed:")]
		Attachment AttachmentNamed (string name);

		[Export ("attachments")]
		Attachment [] Attachments { get; }
	}

	[BaseType (typeof (RevisionBase), Name = "CBLRevision")]
	public partial interface Revision {

		[Export ("propertiesAreLoaded")]
		bool PropertiesAreLoaded { get; }

		[Export ("newRevision")]
		NewRevision NewRevision { get; }

		[Export ("putProperties:error:")]
		Revision PutProperties (NSDictionary properties, out NSError outError);

		[Export ("deleteDocument:")]
		Revision DeleteDocument (out NSError outError);

		[Export ("getRevisionHistory:")]
		Revision [] GetRevisionHistory (out NSError outError);
	}

	[BaseType (typeof (RevisionBase), Name = "CBLNewRevision")]
	public partial interface NewRevision {

		[Export ("setObject:forKeyedSubscript:")]
		void SetObject (NSObject value, string key);

		[Export ("parentRevision")]
		Revision ParentRevision { get; }

		[Export ("parentRevisionID")]
		string ParentRevisionID { get; }

		[Export ("save:")]
		Revision Save (out NSError outError);

		[Export ("addAttachment:named:")]
		void AddAttachment (Attachment attachment, string name);

		[Export ("removeAttachmentNamed:")]
		void RemoveAttachmentNamed (string name);
	}

  public interface IUIDataSourceModelAssociation { }

	[Protocol, BaseType (typeof (NSObject))]
	public partial interface UIDataSourceModelAssociation
	{
		[Export("modelIdentifierForElementAtIndexPath:inView:")]
		NSIndexPath ModelIdForElementInView(string id, UIView view);

		[Export("indexPathForElementWithModelIdentifier:inView:")]
		string ModelIdForElementInView(NSIndexPath id, UIView view);
	}

  public interface ICBLUICollectionSource : IUIDataSourceModelAssociation {}

	[Protocol, BaseType (typeof (NSObject))]
	public partial interface CBLUICollectionSource : UIDataSourceModelAssociation {

		[Export ("collectionView", ArgumentSemantic.Retain)]
		UICollectionView CollectionView { get; set; }

		[Export ("query", ArgumentSemantic.Retain)]
		LiveQuery Query { get; set; }

		[Export ("reloadFromQuery")]
		void ReloadFromQuery ();

		[Export ("rows")]
		NSMutableArray Rows { get; }

		[Export ("rowAtIndex:")]
		QueryRow RowAtIndex (uint index);

		[Export ("indexPathForDocument:")]
		NSIndexPath IndexPathForDocument (Document document);

		[Export ("rowAtIndexPath:")]
		QueryRow RowAtIndexPath (NSIndexPath path);

		[Export ("documentAtIndexPath:")]
		Document DocumentAtIndexPath (NSIndexPath path);

		[Export ("deleteDocumentsAtIndexes:error:")]
    bool DeleteDocumentsAtIndexes (NSIndexPath [] indexPaths, out NSError outError);

		[Export ("deleteDocuments:error:")]
		bool DeleteDocuments (Document [] documents, out NSError outError);
	}

	[Model, BaseType(typeof(UICollectionViewDelegate))]
	public partial interface CBLCollectionDelegate {

		[Export ("couchCollectionSource:cellForRowAtIndexPath:")]
		UICollectionViewCell CellForRowAtIndexPath (ICBLUICollectionSource source, NSIndexPath indexPath);

		[Export ("couchCollectionSource:willUpdateFromQuery:")]
		void WillUpdateFromQuery (ICBLUICollectionSource source, LiveQuery query);

		[Export ("couchCollectionSource:updateFromQuery:previousRows:")]
		void UpdateFromQuery (ICBLUICollectionSource source, LiveQuery query, QueryRow [] previousRows);

		[Export ("couchCollectionSource:willUseCell:forRow:")]
		void WillUseCell (ICBLUICollectionSource source, UICollectionViewCell cell, QueryRow row);
	}

	[BaseType (typeof (NSObject))]
	public partial interface CBLUITableSource : UIDataSourceModelAssociation {

		[Outlet, Export ("tableView", ArgumentSemantic.Assign)]
		UITableView TableView { get; set; }

		[Export ("query", ArgumentSemantic.Retain)]
		LiveQuery Query { get; set; }

		[Export ("reloadFromQuery")]
		void ReloadFromQuery ();

		[Export ("rows")]
		QueryRow [] Rows { get; }

		[Export ("rowAtIndex:")]
		QueryRow RowAtIndex (uint index);

		[Export ("indexPathForDocument:")]
		NSIndexPath IndexPathForDocument (Document document);

		[Export ("rowAtIndexPath:")]
		QueryRow RowAtIndexPath (NSIndexPath path);

		[Export ("documentAtIndexPath:")]
		Document DocumentAtIndexPath (NSIndexPath path);

		[Export ("labelProperty", ArgumentSemantic.Copy)]
		string LabelProperty { get; set; }

		[Export ("deletionAllowed")]
		bool DeletionAllowed { get; set; }

		[Export ("deleteDocumentsAtIndexes:error:")]
    bool DeleteDocumentsAtIndexes (NSIndexPath [] indexPaths, out NSError outError);

		[Export ("deleteDocuments:error:")]
		bool DeleteDocuments (Document [] documents, out NSError outError);
	}

  public interface ICBLUITableDelegate : IUITableViewDelegate {}

	[Protocol, Model, BaseType(typeof (UITableViewDelegate))]
	public partial interface CBLUITableDelegate {

		[Export ("couchTableSource:cellForRowAtIndexPath:")]
		UITableViewCell CellForRowAtIndexPath (CBLUITableSource source, NSIndexPath indexPath);

		[Export ("couchTableSource:willUpdateFromQuery:")]
		void WillUpdateFromQuery (CBLUITableSource source, LiveQuery query);

		[Export ("couchTableSource:updateFromQuery:previousRows:")]
		void UpdateFromQuery (CBLUITableSource source, LiveQuery query, QueryRow [] previousRows);

		[Export ("couchTableSource:willUseCell:forRow:")]
		void WillUseCell (CBLUITableSource source, UITableViewCell cell, QueryRow row);

		[Export ("couchTableSource:deleteRow:")]
		bool DeleteRow (CBLUITableSource source, QueryRow row);

		[Export ("couchTableSource:deleteFailed:")]
		void DeleteFailed (CBLUITableSource source, NSError error);
	}
}
