using System;

using System.Runtime.InteropServices;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Couchbase {

	public delegate void CBLMapEmitBlock(NSObject key, NSObject value);
	public delegate bool CBLFilterBlock(CBLRevision revision, NSDictionary options);
	public delegate bool CBLValidationBlock(CBLRevision newRevision, CBLValidationContext context);
	public delegate void CBLMapBlock(NSDictionary doc, CBLView view);
	public delegate NSObject CBLReduceBlock(NSArray keys, NSArray values, bool rereduce);
	public delegate bool CBLChangeEnumeratorBlock(String key, NSObject oldValue, NSObject newValue);

	[BaseType (typeof (NSObject))]
	public partial interface CBLAttachment {

		[Export ("initWithContentType:body:")]
		IntPtr Constructor (string contentType, NSObject body);

		[Export ("revision", ArgumentSemantic.Retain)]
		CBLRevisionBase Revision { get; }

		[Export ("document")]
		CBLDocument Document { get; }

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
		CBLRevision UpdateBody (NSData body, string contentType, out NSError outError);
	}

	[BaseType (typeof (NSObject))]
	public partial interface CBLViewCompiler {

		[Export ("compileMapFunction:language:")]
		CBLMapBlock CompileMapFunction (string mapSource, string language);

		[Export ("compileReduceFunction:language:")]
		CBLReduceBlock CompileReduceFunction (string reduceSource, string language);
	}

	[BaseType (typeof (NSObject))]
	public partial interface CBLView {

		[Export("emit:value:")]
		void Emit (NSObject key, NSObject value);

		[Export("foo")]
		void Foo (CBLMapEmitBlock emit);

		[Export ("database")]
		CBLDatabase Database { get; }

		[Export ("name")]
		string Name { get; }

		[Export ("mapBlock")]
		CBLMapBlock MapBlock { get; }

		[Export ("reduceBlock")]
		CBLReduceBlock ReduceBlock { get; }

		[Export ("setMapBlock:reduceBlock:version:")]
		bool SetMapBlock (CBLMapBlock mapBlock, [NullAllowed] CBLReduceBlock reduceBlock, string version);

		[Export ("setMapBlock:version:")]
		bool SetMapBlock (CBLMapBlock mapBlock, string version);

		[Export ("stale")]
		bool Stale { get; }

		[Export ("lastSequenceIndexed")]
		Int64 LastSequenceIndexed { get; }

		[Export ("removeIndex")]
		void RemoveIndex ();

		[Export ("deleteView")]
		void DeleteView ();

		[Export ("query")]
		CBLQuery Query { get; }

		[Static, Export ("totalValues:")]
		NSNumber TotalValues (NSObject [] values);

		[Static, Export ("compiler")]
		CBLViewCompiler Compiler { get; set; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface CBLFilterCompiler {

		[Export ("compileFilterFunction:language:")]
		CBLFilterBlock CompileFilterFunction (string filterSource, string language);
	}

	[BaseType (typeof (NSObject))]
	public partial interface CBLDatabase {

		[Export ("name")]
		string Name { get; }

		[Export ("manager")]
		CBLManager Manager { get; }

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
		CBLDocument DocumentWithID (string docID);

		[Export ("objectForKeyedSubscript:")]
		CBLDocument ObjectForKeyedSubscript (string key);

		[Export ("untitledDocument")]
		CBLDocument UntitledDocument { get; }

		[Export ("cachedDocumentWithID:")]
		CBLDocument CachedDocumentWithID (string docID);

		[Export ("clearDocumentCache")]
		void ClearDocumentCache ();

		[Export ("getLocalDocumentWithID:")]
		NSDictionary GetLocalDocumentWithID (string localDocID);

		[Export ("putLocalDocument:withID:error:")]
		bool PutLocalDocument (NSDictionary properties, string localDocID, out NSError outError);

		[Export ("deleteLocalDocumentWithID:error:")]
		bool DeleteLocalDocumentWithID (string localDocID, out NSError outError);

		[Export ("queryAllDocuments")]
		CBLQuery QueryAllDocuments { get; }

		[Export ("slowQueryWithMap:")]
		CBLQuery SlowQueryWithMap (CBLMapBlock mapBlock);

		[Export ("viewNamed:")]
		CBLView ViewNamed (string name);

		[Export ("existingViewNamed:")]
		CBLView ExistingViewNamed (string name);

		[Export ("defineValidation:asBlock:")]
		void DefineValidation (string validationName, CBLValidationBlock validationBlock);

		[Export ("validationNamed:")]
		CBLValidationBlock ValidationNamed (string validationName);

		[Export ("defineFilter:asBlock:")]
		void DefineFilter (string filterName, CBLFilterBlock filterBlock);

		[Export ("filterNamed:")]
		CBLFilterBlock FilterNamed (string filterName);

		[Static, Export ("filterCompiler")]
		CBLFilterCompiler FilterCompiler { get; set; }

		[Export ("inTransaction:")]
		bool InTransaction (Action<bool> bloc);

		[Export ("allReplications")]
		NSObject [] AllReplications { get; }

		[Export ("pushToURL:")]
		CBLReplication PushToURL (NSUrl url);

		[Export ("pullFromURL:")]
		CBLReplication PullFromURL (NSUrl url);

		[Export ("replicateWithURL:exclusively:")]
		NSObject [] ReplicateWithURL (NSUrl otherDbURL, bool exclusively);

		[Notification, Field ("kCBLDatabaseChangeNotification", "__Internal")]
		NSString CBLDatabaseChangeNotification { get; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface CBLValidationContext {

		[Export ("currentRevision")]
		CBLRevision CurrentRevision { get; }

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

	[BaseType (typeof (NSObject))]
	public partial interface CBLDocument {

		[Export ("database")]
		CBLDatabase Database { get; }

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
		CBLRevision CurrentRevision { get; }

		[Export ("revisionWithID:")]
		CBLRevision RevisionWithID (string revisionID);

		[Export ("getRevisionHistory:")]
		NSObject [] GetRevisionHistory (out NSError outError);

		[Export ("getConflictingRevisions:")]
		NSObject [] GetConflictingRevisions (out NSError outError);

		[Export ("getLeafRevisions:")]
		NSObject [] GetLeafRevisions (out NSError outError);

		[Export ("newRevision")]
		CBLNewRevision NewRevision { get; }

		[Export ("properties", ArgumentSemantic.Copy)]
		NSDictionary Properties { get; }

		[Export ("userProperties", ArgumentSemantic.Copy)]
		NSDictionary UserProperties { get; }

		[Export ("propertyForKey:")]
		NSObject PropertyForKey (string key);

		[Export ("objectForKeyedSubscript:")]
		NSObject ObjectForKeyedSubscript (string key);

		[Export ("putProperties:error:")]
		CBLRevision PutProperties (NSDictionary properties, out NSError outError);

		[Export ("modelObject", ArgumentSemantic.Assign)]
		NSObject ModelObject { get; set; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface CBLDocumentModel {

		[Export ("tdDocumentChanged:")]
		void TdDocumentChanged (CBLDocument doc);

		[Notification, Field ("kCBLDocumentChangeNotification", "__Internal")]
		NSString CBLDocumentChangeNotification { get; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface CBLManager {

		[Static, Export ("sharedInstance")]
		CBLManager SharedInstance { get; }

		[Static, Export ("isValidDatabaseName:")]
		bool IsValidDatabaseName (string name);

		[Static, Export ("defaultDirectory")]
		string DefaultDirectory { get; }

		[Export ("initWithDirectory:options:error:")]
		IntPtr Constructor (string directory, CBLManagerOptions options, out NSError outError);

		[Export ("close")]
		void Close ();

		[Export ("directory")]
		string Directory { get; }

		[Export ("databaseNamed:error:")]
		CBLDatabase DatabaseNamed (string name, out NSError outError);

		[Export ("objectForKeyedSubscript:")]
		CBLDatabase ObjectForKeyedSubscript (string key);

		[Export ("createDatabaseNamed:error:")]
		CBLDatabase CreateDatabaseNamed (string name, out NSError outError);

		[Export ("allDatabaseNames")]
		NSObject [] AllDatabaseNames { get; }

		[Export ("replaceDatabaseNamed:withDatabaseFile:withAttachments:error:")]
		bool ReplaceDatabaseNamed (string databaseName, string databasePath, string attachmentsPath, out NSError outError);

		[Export ("asyncTellDatabaseNamed:to:")]
		void AsyncTellDatabaseNamed (string dbName, Action<CBLDatabase> block);

		[Export ("internalURL")]
		NSUrl InternalURL { get; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface MYDynamicObject {

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
//
//		[Static, Export ("impForGetterOfProperty:ofType:")]
//		unsafe IntPtr ImpForGetterOfProperty (string property, char* propertyType);
//
//		[Static, Export ("impForSetterOfProperty:ofType:")]
//		unsafe IntPtr ImpForSetterOfProperty (string property, char* propertyType);
	}


	[BaseType (typeof (MYDynamicObject))]
	public partial interface CBLModel : CBLDocumentModel {

		[Static, Export ("modelForDocument:")]
		CBLModel ModelForDocument (CBLDocument document);

		[Export ("initWithNewDocumentInDatabase:")]
		IntPtr Constructor (CBLDatabase database);

		[Export ("document", ArgumentSemantic.Retain)]
		CBLDocument Document { get; }

		[Export ("database", ArgumentSemantic.Retain)]
		CBLDatabase Database { get; set; }

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

		[Export ("getValueOfProperty:")]
		NSObject GetValueOfProperty (string property);

		[Export ("setValue:ofProperty:")]
		bool SetValue (NSObject value, string property);

		[Export ("attachmentNames")]
		NSObject [] AttachmentNames { get; }

		[Export ("attachmentNamed:")]
		CBLAttachment AttachmentNamed (string name);

		[Export ("addAttachment:named:")]
		void AddAttachment (CBLAttachment attachment, string name);

		[Export ("removeAttachmentNamed:")]
		void RemoveAttachmentNamed (string name);

		[Export ("initWithDocument:")]
		IntPtr Constructor (CBLDocument document);

		[Export ("idForNewDocumentInDatabase:")]
		string IdForNewDocumentInDatabase (CBLDatabase db);

		[Export ("didLoadFromDocument")]
		void DidLoadFromDocument ();

		[Export ("databaseForModelProperty:")]
		CBLDatabase DatabaseForModelProperty (string propertyName);

		[Export ("markNeedsSave")]
		void MarkNeedsSave ();

		[Static, Export ("itemClassForArrayProperty:")]
		Class ItemClassForArrayProperty (string property);
	}

//	[Category, BaseType (typeof (CBLDatabase))]
//	public partial interface CBLModel_CBLDatabase {
//
//		[Export ("unsavedModels")]
//		NSObject [] UnsavedModels { get; }
//
//		[Export ("saveAllModels:")]
//		bool SaveAllModels (out NSError outError);
//
//		[Export ("autosaveAllModels:")]
//		bool AutosaveAllModels (out NSError outError);
//	}

	[BaseType (typeof (NSArray))]
	public partial interface CBLModelArray {

		[Export ("initWithOwner:property:itemClass:docIDs:")]
		IntPtr Constructor (CBLModel owner, string property, Class itemClass, String [] docIDs);

		[Export ("initWithOwner:property:itemClass:models:")]
		IntPtr Constructor (CBLModel owner, string property, Class itemClass, NSObject [] models);

		[Export ("docIDs")]
		NSObject [] DocIDs { get; }
	}
	
	[BaseType (typeof (NSObject))]
	public partial interface CBLModelFactory {

		[Static, Export ("sharedInstance")]
		CBLModelFactory SharedInstance { get; }

		[Export ("modelForDocument:")]
		NSObject ModelForDocument (CBLDocument document);

		[Export ("registerClass:forDocumentType:")]
		void RegisterClass (NSObject classOrName, string type);

		[Export ("classForDocument:")]
		Class ClassForDocument (CBLDocument document);

		[Export ("classForDocumentType:")]
		Class ClassForDocumentType (string type);
	}

	[BaseType (typeof (NSObject))]
	public partial interface CBLQuery {

		[Export ("database")]
		CBLDatabase Database { get; }

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
		CBLStaleness Stale { get; set; }

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
		CBLQueryEnumerator Rows { get; }

		[Export ("rowsIfChanged")]
		CBLQueryEnumerator RowsIfChanged { get; }

		[Export ("runAsync:")]
		void RunAsync (Action<CBLQueryEnumerator> onComplete);

		[Export ("asLiveQuery")]
		CBLLiveQuery AsLiveQuery { get; }
	}

	[BaseType (typeof (CBLQuery))]
	public partial interface CBLLiveQuery {

		[Export ("start")]
		void Start ();

		[Export ("stop")]
		void Stop ();

		[Export ("rows", ArgumentSemantic.Retain)]
		CBLQueryEnumerator Rows { get; }
	}

	[BaseType (typeof (NSEnumerator))]
	public partial interface CBLQueryEnumerator {

		[Export ("count")]
		uint Count { get; }

		[Export ("sequenceNumber")]
		UInt64 SequenceNumber { get; }

		[Export ("nextRow")]
		CBLQueryRow NextRow { get; }

		[Export ("rowAtIndex:")]
		CBLQueryRow RowAtIndex (uint index);

		[Export ("error")]
		NSError Error { get; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface CBLQueryRow {

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
		CBLDocument Document { get; }

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
	
	[BaseType (typeof (CBLModel))]
	public partial interface CBLReplication {

		[Export ("initPullFromSourceURL:toDatabase:")]
		IntPtr Constructor (NSUrl source, CBLDatabase database);

		[Export ("initPushFromDatabase:toTargetURL:")]
		IntPtr Constructor (CBLDatabase database, NSUrl target);

		[Export ("localDatabase")]
		CBLDatabase LocalDatabase { get; }

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
		NSObject [] Doc_ids { get; set; }

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
		CBLReplicationMode Mode { get; }

		[Export ("running")]
		bool Running { get; }

		[Export ("error", ArgumentSemantic.Retain)]
		NSError Error { get; }

		[Export ("completed")]
		uint Completed { get; }

		[Export ("total")]
		uint Total { get; }

		[Notification, Field ("kCBLReplicationChangeNotification", "__Internal")]
		NSString CBLReplicationChangeNotification { get; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface CBLRevisionBase {

		[Export ("document")]
		CBLDocument Document { get; }

		[Export ("database")]
		CBLDatabase Database { get; }

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
		NSObject [] AttachmentNames { get; }

		[Export ("attachmentNamed:")]
		CBLAttachment AttachmentNamed (string name);

		[Export ("attachments")]
		NSObject [] Attachments { get; }
	}

	[BaseType (typeof (CBLRevisionBase))]
	public partial interface CBLRevision {

		[Export ("propertiesAreLoaded")]
		bool PropertiesAreLoaded { get; }

		[Export ("newRevision")]
		CBLNewRevision NewRevision { get; }

		[Export ("putProperties:error:")]
		CBLRevision PutProperties (NSDictionary properties, out NSError outError);

		[Export ("deleteDocument:")]
		CBLRevision DeleteDocument (out NSError outError);

		[Export ("getRevisionHistory:")]
		NSObject [] GetRevisionHistory (out NSError outError);
	}

	[BaseType (typeof (CBLRevisionBase))]
	public partial interface CBLNewRevision {

		[Export ("isDeleted")]
		bool IsDeleted { get; set; }

		[Export ("properties", ArgumentSemantic.Copy)]
		NSMutableDictionary Properties { get; set; }

		[Export ("userProperties", ArgumentSemantic.Copy)]
		NSDictionary UserProperties { get; }

		[Export ("setObject:forKeyedSubscript:")]
		void SetObject (NSObject value, string key);

		[Export ("parentRevision")]
		CBLRevision ParentRevision { get; }

		[Export ("parentRevisionID")]
		string ParentRevisionID { get; }

		[Export ("save:")]
		CBLRevision Save (out NSError outError);

		[Export ("addAttachment:named:")]
		void AddAttachment (CBLAttachment attachment, string name);

		[Export ("removeAttachmentNamed:")]
		void RemoveAttachmentNamed (string name);
	}

	[Protocol, BaseType (typeof (NSObject))]
	public partial interface UIDataSourceModelAssociation
	{
		[Export("modelIdentifierForElementAtIndexPath:inView:")]
		NSIndexPath ModelIdForElementInView(string id, UIView view);

		[Export("indexPathForElementWithModelIdentifier:inView:")]
		string ModelIdForElementInView(NSIndexPath id, UIView view);
	}

	[BaseType (typeof (NSObject))]
	public partial interface CBLUICollectionSource : UIDataSourceModelAssociation {

		[Export ("collectionView", ArgumentSemantic.Retain)]
		UICollectionView CollectionView { get; set; }

		[Export ("query", ArgumentSemantic.Retain)]
		CBLLiveQuery Query { get; set; }

		[Export ("reloadFromQuery")]
		void ReloadFromQuery ();

		[Export ("rows")]
		NSMutableArray Rows { get; }

		[Export ("rowAtIndex:")]
		CBLQueryRow RowAtIndex (uint index);

		[Export ("indexPathForDocument:")]
		NSIndexPath IndexPathForDocument (CBLDocument document);

		[Export ("rowAtIndexPath:")]
		CBLQueryRow RowAtIndexPath (NSIndexPath path);

		[Export ("documentAtIndexPath:")]
		CBLDocument DocumentAtIndexPath (NSIndexPath path);

		[Export ("deleteDocumentsAtIndexes:error:")]
		bool DeleteDocumentsAtIndexes (NSObject [] indexPaths, out NSError outError);

		[Export ("deleteDocuments:error:")]
		bool DeleteDocuments (NSObject [] documents, out NSError outError);
	}

	[BaseType(typeof(UICollectionViewDelegate))]
	public partial interface CBLUICollectionDelegate {

		[Export ("couchCollectionSource:cellForRowAtIndexPath:")]
		UICollectionViewCell CellForRowAtIndexPath (CBLUICollectionSource source, NSIndexPath indexPath);

		[Export ("couchCollectionSource:willUpdateFromQuery:")]
		void WillUpdateFromQuery (CBLUICollectionSource source, CBLLiveQuery query);

		[Export ("couchCollectionSource:updateFromQuery:previousRows:")]
		void UpdateFromQuery (CBLUICollectionSource source, CBLLiveQuery query, NSObject [] previousRows);

		[Export ("couchCollectionSource:willUseCell:forRow:")]
		void WillUseCell (CBLUICollectionSource source, UICollectionViewCell cell, CBLQueryRow row);
	}

	[BaseType (typeof (NSObject))]
	public partial interface CBLUITableSource : UIDataSourceModelAssociation {

		[Outlet, Export ("tableView", ArgumentSemantic.Assign)]
		UITableView TableView { get; set; }

		[Export ("query", ArgumentSemantic.Retain)]
		CBLLiveQuery Query { get; set; }

		[Export ("reloadFromQuery")]
		void ReloadFromQuery ();

		[Export ("rows")]
		NSObject [] Rows { get; }

		[Export ("rowAtIndex:")]
		CBLQueryRow RowAtIndex (uint index);

		[Export ("indexPathForDocument:")]
		NSIndexPath IndexPathForDocument (CBLDocument document);

		[Export ("rowAtIndexPath:")]
		CBLQueryRow RowAtIndexPath (NSIndexPath path);

		[Export ("documentAtIndexPath:")]
		CBLDocument DocumentAtIndexPath (NSIndexPath path);

		[Export ("labelProperty", ArgumentSemantic.Copy)]
		string LabelProperty { get; set; }

		[Export ("deletionAllowed")]
		bool DeletionAllowed { get; set; }

		[Export ("deleteDocumentsAtIndexes:error:")]
		bool DeleteDocumentsAtIndexes (NSObject [] indexPaths, out NSError outError);

		[Export ("deleteDocuments:error:")]
		bool DeleteDocuments (NSObject [] documents, out NSError outError);
	}

	[BaseType(typeof (UITableViewDelegate))]
	public partial interface CBLUITableDelegate {

		[Export ("couchTableSource:cellForRowAtIndexPath:")]
		UITableViewCell CellForRowAtIndexPath (CBLUITableSource source, NSIndexPath indexPath);

		[Export ("couchTableSource:willUpdateFromQuery:")]
		void WillUpdateFromQuery (CBLUITableSource source, CBLLiveQuery query);

		[Export ("couchTableSource:updateFromQuery:previousRows:")]
		void UpdateFromQuery (CBLUITableSource source, CBLLiveQuery query, NSObject [] previousRows);

		[Export ("couchTableSource:willUseCell:forRow:")]
		void WillUseCell (CBLUITableSource source, UITableViewCell cell, CBLQueryRow row);

		[Export ("couchTableSource:deleteRow:")]
		bool DeleteRow (CBLUITableSource source, CBLQueryRow row);

		[Export ("couchTableSource:deleteFailed:")]
		void DeleteFailed (CBLUITableSource source, NSError error);
	}
}
