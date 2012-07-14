using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Couchbase
{

	[BaseType (typeof (NSObject))]
	interface RestBody {
		[Export ("content")]
		NSData Content { get;  }

		[Export ("headers")]
		NSDictionary Headers { get;  }

		[Export ("resource")]
		RestResource Resource { get;  }

		[Export ("contentType")]
		string ContentType { get;  }

		[Export ("eTag")]
		string ETag { get;  }

		[Export ("lastModified")]
		string LastModified { get;  }

		[Export ("asString")]
		string AsString { get;  }

		[Export ("fromJSON")]
		NSObject FromJSON { get;  }

		[Export ("entityHeadersFrom:")]
		NSDictionary EntityHeadersFrom (NSDictionary headers);

		[Export ("initWithContent:headers:resource:")]
		IntPtr Constructor (NSData content, NSDictionary headers, RestResource resource);

		[Export ("initWithData:contentType:")]
		IntPtr Constructor (NSData content, string contentType);

		[Static]
		[Export ("stringWithJSONObject:")]
		string StringFromJsonObject (NSObject obj);

		[Static]
		[Export ("prettyStringWithJSONObject:")]
		string PrettyStringWithJsonObject (NSObject obj);

		[Static]
		[Export ("JSONObjectWithData:")]
		NSObject JsonObjectFromData (NSData data);

		[Static]
		[Export ("JSONObjectWithString:")]
		NSObject JsonObjectWithString (string str);

		[Static]
		[Export ("JSONObjectWithDate:")]
		string JsonObjectWithDate (NSDate date);

		[Static]
		[Export ("dateWithJSONObject:")]
		NSDate DateWithJSONObject (NSObject jsonObject);

		[Static]
		[Export ("base64WithData:")]
		string EncodeBase64 (NSData data);

		[Static]
		[Export ("dataWithBase64:")]
		NSData DecodeBase64 (string base64);
	}

	[BaseType (typeof (RestBody))]
	interface RestMutableBody {
		[Export ("headers"), New]
		NSDictionary Headers { get; set;  }

		[Export ("mutableHeaders")]
		NSMutableDictionary MutableHeaders { get; set;  }

		[Export ("contentType"), New]
		string ContentType { get; set;  }

		[Export ("resource"), New]
		RestResource Resource { get; set;  }

	}

	[BaseType (typeof (NSObject))]
	interface RestOperation {
		[Export ("resource")]
		RestResource Resource { get;  }

		[Export ("URL")]
		NSUrl Url { get;  }

		[Export ("name")]
		string Name { get;  }

		[Export ("method")]
		string Method { get;  }

		[Export ("request")]
		NSUrlRequest Request { get;  }

		[Export ("isReadOnly")]
		bool IsReadOnly { get;  }

		[Export ("isGET")]
		bool IsGet { get;  }

		[Export ("isPUT")]
		bool IsPut { get;  }

		[Export ("isPOST")]
		bool IsPost { get;  }

		[Export ("isDELETE")]
		bool IsDelte { get;  }

		[Export ("requestBody")]
		NSData RequestBody { get; set;  }

		[Export ("error")]
		NSError Error { get;  }

		[Export ("isSuccessful")]
		bool IsSuccessful { get;  }

		[Export ("httpStatus")]
		int HttpStatus { get;  }

		[Export ("responseHeaders")]
		NSDictionary ResponseHeaders { get;  }

		[Export ("responseBody")]
		RestBody ResponseBody { get;  }

		[Export ("response")]
		NSHttpUrlResponse Response { get;  }

		[Export ("resultObject")]
		NSObject ResultObject { get; set;  }

		[Export ("initWithResource:request:")]
		IntPtr Constructor (RestResource resource, NSUrlRequest request);

		[Export ("setValue:forHeader:")]
		void SetHeaderValue (string value, string headerName);

		[Export ("start")]
		RestOperation Start ();

		[Export ("onCompletion:")]
		bool OnCompletion (NSAction onComplete);

		[Export ("wait")]
		bool Wait ();

		[Export ("wait:")]
		bool Wait (out NSError outError);

		[Static]
		[Export ("wait:")]
		bool Wait (NSSet operations);

		[Export ("cancel")]
		void Cancel ();

		[Export ("isComplete")]
		bool IsComplete { get; }

		[Export ("dump")]
		string Dump ();
	}

	[BaseType (typeof (NSObject), Name="RestResource")]
	interface RestResource {
		[Export ("URL")]
		NSUrl Url { get;  }

		[Export ("parent")]
		RestResource Parent { get;  }

		[Export ("relativePath")]
		string RelativePath { get;  }

		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set;  }

		[Wrap ("WeakDelegate")]
		RestResourceDelegate Delegate { get; set; }

		[Export ("eTag")]
		string ETag { get; set;  }

		[Export ("lastModified")]
		string LastModified { get; set;  }

		[Export ("cachedURL")]
		NSUrl CachedUrl { get; set;  }

		[Export ("activeOperations")]
		NSSet ActiveOperations { get;  }

		[Export ("initWithURL:")]
		IntPtr Constructor (NSUrl url);

		[Export ("initWithParent:relativePath:")]
		IntPtr Constructor (RestResource parent, string path);

		[Export ("initUntitledWithParent:")]
		IntPtr Constructor (RestResource parent);

		[Export ("setCredential:")]
		void SetCredential (NSUrlCredential credential);

		[Export ("setProtectionSpace:")]
		void SetProtectionSpace (NSUrlProtectionSpace protectionSpace);

		[Export ("GET")]
		RestOperation Get ();

		[Export ("POST:parameters:")]
		RestOperation Post (NSData body, NSDictionary parameters);

		[Export ("PUT:parameters:")]
		RestOperation Put (NSData body, NSDictionary parameters);

		[Export ("PUTJSON:parameters:")]
		RestOperation PutJson (NSObject body, NSDictionary parameters);

		[Export ("POSTJSON:parameters:")]
		RestOperation PostJson (NSObject body, NSDictionary parameters);

		[Export ("DELETE")]
		RestOperation Delete ();

		[Export ("sendHTTP:parameters:")]
		RestOperation SendHttp (string method, NSDictionary parameters);

		[Export ("requestWithMethod:parameters:")]
		NSMutableUrlRequest RequestWithMethod (string method, NSDictionary parameters);

		[Export ("sendRequest:")]
		RestOperation SendRequest (NSUrlRequest request);

		[Export ("cacheResponse:")]
		bool CacheResponse (RestOperation operation);

		[Export ("operationDidStart:")]
		void OperationDidStart (RestOperation op);

		[Export ("operationDidComplete:")]
		void OperationDidComplete (RestOperation op);

		[Export ("operation:willCompleteWithError:")]
		NSError OperationWillComplete (RestOperation op, NSError error);

		[Export ("createdByPOST:")]
		void CreatedByPost (RestOperation op);

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface RestResourceDelegate {
		[Abstract]
		[Export ("resource:willSendRequest:")]
		void WillSendRequest (RestResource resource, NSMutableUrlRequest request);

		[Abstract]
		[Export ("resource:didReceiveResponse:")]
		void DidReceiveResponse (RestResource resource, NSHttpUrlResponse response);
	}

	[BaseType (typeof (RestResource))]
	interface CouchResource {
		[Export ("database")]
		CouchDatabase Database { get;  }
	}

	delegate string CouchDocumentPathMap (string documentId);

	[BaseType (typeof (CouchResource))]
	interface CouchDatabase {
		[Export ("server")]
		CouchServer Server { get;  }

		[Export ("documentPathMap")]
		CouchDocumentPathMap DocumentPathMap { get; set;  }

		[Export ("lastSequenceNumber")]
		uint LastSequenceNumber { get; set;  }

		[Export ("replications")]
		NSArray Replications { get;  }

		[Static]
		[Export ("databaseWithURL:")]
		CouchDatabase FromUrl (NSUrl databaseURL);

		[Static]
		[Export ("databaseNamed:onServerWithURL:")]
		CouchDatabase FromUrl (string databaseName, NSUrl serverURL);

		[Export ("create")]
		RestOperation Create ();

		[Export ("ensureCreated:")]
		bool EnsureCreated (out NSError outError);

		[Export ("compact")]
		RestOperation Compact ();

		[Export ("getDocumentCount")]
		int DocumentCount { get; }

		[Export ("documentWithID:")]
		CouchDocument CreateDocumentWithID (string docID);

		[Export ("untitledDocument")]
		CouchDocument CreateUntitledDocument ();

		[Export ("getAllDocuments")]
		CouchQuery GetAllDocuments ();

		[Export ("getDocumentsWithIDs:")]
		CouchQuery GetDocumentsWithIDs (string [] docIDs);

		[Export ("putChanges:toRevisions:")]
		RestOperation PutChanges (NSObject [] properties, NSObject [] revisions);

		[Export ("putChanges:")]
		RestOperation PutChanges (NSObject [] properties);

		[Export ("deleteRevisions:")]
		RestOperation DeleteRevisions (NSObject [] revisions);

		[Export ("deleteDocuments:")]
		RestOperation DeleteDocuments (NSObject []documents);

		[Export ("clearDocumentCache")]
		void ClearDocumentCache ();

		[Export ("slowQueryWithMap:reduce:language:")]
		CouchQuery CreateSlowQuery (string map, string reduce, string language);

		[Export ("slowQueryWithMap:")]
		CouchQuery CreateSlowQuery (string map);

		[Export ("designDocumentWithName:")]
		CouchDesignDocument DesignDocumentWithName (string name);

		[Export ("pullFromDatabaseAtURL:")]
		CouchReplication PullFromDatabase (NSUrl sourceURL);

		[Export ("pushToDatabaseAtURL:")]
		CouchReplication PushToDatabase (NSUrl targetURL);

		[Export ("replicateWithURL:exclusively:")]
		CouchPersistentReplication [] Replicate (NSUrl otherURL, bool exclusively);

		[Export ("replicationFromDatabaseAtURL:")]
		CouchPersistentReplication ReplicationFromDatabase (NSUrl sourceURL);

		[Export ("replicationToDatabaseAtURL:")]
		CouchPersistentReplication ReplicationToDatabase (NSUrl targetURL);

		[Field ("kCouchDatabaseChangeNotification", "__Internal")]
		NSString ChangeNotification { get; }
	}


	[BaseType (typeof (CouchResource))]
	interface CouchServer {
		[Export ("activityPollInterval")]
		double ActivityPollInterval { get; set;  }

		[Export ("initWithURL:")]
		IntPtr Constructor (NSUrl url);

		[Export ("close")]
		void Close ();

		[Export ("getVersion:")]
		string GetVersion (out NSError outError);

		[Export ("generateUUIDs:")]
		string [] GenerateUUIDs (int count);

		[Export ("getDatabases")]
		CouchDatabase [] GetDatabases ();

		[Export ("databaseNamed:")]
		CouchDatabase GetDatabase (string name);

		[Export ("activeTasks")]
		NSObject [] GetActiveTasks ();

		[Export ("checkActiveTasks")]
		void CheckActiveTasks ();

		[Export ("replications")]
		CouchPersistentReplication [] Replications { get; }

	}


	[BaseType (typeof (CouchResource))]
	interface CouchDocument {
		[Export ("abbreviatedID")]
		string AbbreviatedID { get;  }

		[Export ("isDeleted")]
		bool IsDeleted { get;  }

		[Export ("modelObject")]
		NSObject ModelObject { get; set;  }

		[Export ("userProperties")]
		NSDictionary UserProperties { get;  }

		[Export ("documentID")]
		string DocumentID { get; }

		[Export ("currentRevisionID")]
		string CurrentRevisionID { get; }

		[Export ("currentRevision")]
		CouchRevision GetCurrentRevision ();

		[Export ("revisionWithID:")]
		CouchRevision GetRevisionID (string revisionID);

		[Export ("getRevisionHistory")]
		CouchRevision [] GetRevisionHistory ();

		[Export ("properties")]
		NSDictionary Properties { get; }

		[Export ("propertyForKey:")]
		NSObject GetPropertyForKey (string key);

		[Export ("putProperties:")]
		RestOperation PutProperties (NSDictionary properties);

		[Export ("getConflictingRevisions")]
		CouchRevision [] GetConflictingRevisions ();

		[Export ("resolveConflictingRevisions:withRevision:")]
		RestOperation ResolveConflictingRevisions (CouchRevision [] conflicts, CouchRevision winningRevision);

		[Export ("resolveConflictingRevisions:withProperties:")]
		RestOperation ResolveConflictingRevisions (CouchRevision [] conflicts, NSDictionary properties);

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface CouchDocumentModel {
		[Export ("couchDocumentChanged:")]
		void CouchDocumentChanged (CouchDocument doc);
	}


	[BaseType (typeof (CouchResource))]
	interface CouchQuery {
		[Export ("limit")]
		uint Limit { get; set;  }

		[Export ("skip")]
		uint Skip { get; set;  }

		[Export ("descending")]
		bool Descending { get; set;  }

		[Export ("startKey")]
		NSObject StartKey { get; set;  }

		[Export ("endKey")]
		NSObject EndKey { get; set;  }

		[Export ("startKeyDocID")]
		string StartKeyDocID { get; set;  }

		[Export ("endKeyDocID")]
		string EndKeyDocID { get; set;  }

		[Export ("stale")]
		CouchStaleness Stale { get; set;  }

		[Export ("keys"), NullAllowed]
		NSObject [] Keys { get; set;  }

		[Export ("groupLevel")]
		uint GroupLevel { get; set;  }

		[Export ("prefetch")]
		bool Prefetch { get; set;  }

		[Export ("sequences")]
		bool Sequences { get; set;  }

		[Export ("error")]
		NSError Error { get;  }

		[Export ("designDocument")]
		CouchDesignDocument GetDesignDocument ();

		[Export ("start")]
		RestOperation Start ();

		[Export ("rows")]
		CouchQueryEnumerator RowsEnumerator ();

		[Export ("rowsIfChanged")]
		CouchQueryEnumerator RowsEnumeratorIfChanged ();

		[Export ("asLiveQuery")]
		CouchLiveQuery AsLiveQuery ();
	}

	[BaseType (typeof (CouchQuery))]
	interface CouchLiveQuery {
		[Export ("rows")]
		CouchQueryEnumerator LiveRowsEnumerator ();

		[Export ("wait")]
		bool Wait ();
	}

	[BaseType (typeof (NSEnumerator))]
	interface CouchQueryEnumerator {
		[Export ("totalCount")]
		uint TotalCount { get;  }

		[Export ("sequenceNumber")]
		uint SequenceNumber { get;  }

		[Export ("count")]
		uint Count ();

		[Export ("nextRow")]
		CouchQueryRow GetNextRow ();

		[Export ("rowAtIndex:")]
		CouchQueryRow GetRow (uint index);

	}

	[BaseType (typeof (NSObject))]
	interface CouchQueryRow {
		[Export ("value")]
		NSObject Value { get;  }

		[Export ("key")]
		NSObject Key { get;  }

		[Export ("documentID")]
		string DocumentID { get;  }

		[Export ("sourceDocumentID")]
		string SourceDocumentID { get;  }

		[Export ("documentRevision")]
		string DocumentRevision { get;  }

		[Export ("document")]
		CouchDocument Document { get;  }

		[Export ("documentProperties")]
		NSDictionary DocumentProperties { get;  }

		[Export ("key0")]
		NSObject Key0 { get;  }

		[Export ("key1")]
		NSObject Key1 { get;  }

		[Export ("key2")]
		NSObject Key2 { get;  }

		[Export ("key3")]
		NSObject Key3 { get;  }

		[Export ("localSequence")]
		long LocalSequence { get;  }

		[Export ("keyAtIndex:")]
		NSObject GetKeyAtIndex (uint index);

	}

	delegate void Emit (NSObject key, NSObject value);
	delegate void TDMap (NSDictionary doc, Emit emit);
	delegate NSObject TDReduce (NSObject [] keys, NSObject [] values, bool rereduce);
	delegate bool TDValidation (TDRevision revision, NSObject context);
	delegate bool TDFilter (TDRevision revision);

	[BaseType (typeof (CouchDocument))]
	interface CouchDesignDocument {
		[Export ("language")]
		string Language { get; set;  }

		[Export ("viewNames")]
		string [] ViewNames { get;  }

		[Export ("filters")]
		NSDictionary Filters { get;  }

		[Export ("validation")]
		string ValidationScript { get; set;  }

		[Export ("includeLocalSequence")]
		bool IncludeLocalSequence { get; set;  }

		[Export ("changed")]
		bool Changed { get;  }

		[Export ("queryViewNamed:")]
		CouchQuery CereateQuery (string viewName);

		[Export ("isLanguageAvailable:")]
		bool IsLanguageAvailable (string language);

		[Export ("mapFunctionOfViewNamed:")]
		string GetMapFunction (string viewName);

		[Export ("reduceFunctionOfViewNamed:")]
		string GetReduceFunction (string viewName);

		[Export ("defineViewNamed:map:reduce:")]
		void DefineView (string viewName, string mapFunction, string reduceFunction);

		[Export ("defineViewNamed:map:")]
		void DefineView (string viewName, string mapFunction);

		[Export ("defineFilterNamed:asFunction:")]
		void DefineFilter (string filterName, string filterFunction);

		[Export ("saveChanges")]
		RestOperation SaveChanges ();

#if !MONOMAC
		[Export ("defineViewNamed:mapBlock:version:")]
		void DefineView (string viewName, TDMap mapBlock, string version);

		[Export ("defineViewNamed:mapBlock:reduceBlock:version:")]
		void DefineView (string viewName, TDMap mapBlock, TDReduce reduceBlock, string version);

		[Export ("defineFilterNamed:block:")]
		void DefineFilter (string filterName, TDFilter filterBlock);

		[Export ("setValidationBlock:")]
		void SetValidationBlock (TDValidation validationBlock);
#endif
	}

	[Static]
	interface CouchLanguage {
		[Field ("kCouchLanguageJavaScript", "__Internal")]
		NSString Javascript { get; }

		[Field ("kCouchLanguageErlang", "__Internal")]
		NSString Erlang { get; }
	}


	[BaseType (typeof (NSObject))]
	interface CouchReplication {
		[Export ("remoteURL")]
		NSUrl RemoteURL { get;  }

		[Export ("pull")]
		bool Pull { get;  }

		[Export ("createTarget")]
		bool CreateTarget { get; set;  }

		[Export ("continuous")]
		bool Continuous { get; set;  }

		[Export ("filter")]
		string Filter { get; set;  }

		[Export ("filterParams")]
		NSDictionary FilterParams { get; set;  }

		[Export ("headers")]
		NSDictionary Headers { get; set;  }

		[Export ("OAuth")]
		NSDictionary OAuth { get; set;  }

		[Export ("options")]
		NSDictionary Options { get; set;  }

		[Export ("running")]
		bool Running { get;  }

		[Export ("status")]
		string Status { get;  }

		[Export ("completed")]
		uint Completed { get;  }

		[Export ("total")]
		uint Total { get;  }

		[Export ("error")]
		NSError Error { get;  }

		[Export ("mode")]
		CouchReplicationMode Mode { get;  }

		[Export ("localDatabase")]
		CouchDatabase LocalDatabase ();

		[Export ("start")]
		RestOperation Start ();

		[Export ("stop")]
		void Stop ();
	}

	[BaseType (typeof (CouchModel))]
	interface CouchPersistentReplication {
		[Export ("remoteURL")]
		NSUrl RemoteUrl { get;  }

		[Export ("pull")]
		bool Pull { get;  }

		[Export ("create_target")]
		bool CreateTarget { get; set;  }

		[Export ("continuous")]
		bool Continuous { get; set;  }

		[Export ("filter")]
		string Filter { get; set;  }

		[Export ("query_params")]
		NSDictionary QueryParams { get; set;  }

		[Export ("doc_ids")]
		NSObject DocIds { get; set;  }

		[Export ("headers")]
		NSDictionary Headers { get; set;  }

		[Export ("OAuth")]
		NSDictionary OAuth { get; set;  }

		[Export ("state")]
		CouchReplicationState State { get;  }

		[Export ("completed")]
		uint Completed { get;  }

		[Export ("total")]
		uint  Total { get;  }

		[Export ("error")]
		NSError Error { get;  }

		[Export ("mode")]
		CouchReplicationMode Mode { get;  }

		[Export ("localDatabase")]
		CouchDatabase LocalDatabase ();

		[Export ("actAsUser:withRoles:")]
		void ActAsUser (string username, string [] roles);

		[Export ("actAsAdmin")]
		void ActAsAdmin ();

		[Export ("restart")]
		void Restart ();
	}


	[BaseType (typeof (CouchResource))]
	interface CouchRevision {
		[Export ("documentID")]
		string DocumentID { get;  }

		[Export ("revisionID")]
		string RevisionID { get;  }

		[Export ("isCurrent")]
		bool IsCurrent { get;  }

		[Export ("isDeleted")]
		bool IsDeleted { get;  }

		[Export ("userProperties")]
		NSDictionary UserProperties { get;  }

		[Export ("propertiesAreLoaded")]
		bool PropertiesAreLoaded { get;  }

		[Export ("document")]
		CouchDocument GetDocument ();

		[Export ("properties")]
		NSDictionary Properties ();

		[Export ("propertyForKey:")]
		NSObject GetPropertyForKey (string key);

		[Export ("putProperties:")]
		RestOperation PutProperties (NSDictionary properties);

		[Export ("attachmentNames")]
		string [] AttachmentNames ();

		[Export ("attachmentNamed:")]
		CouchAttachment GetAttachment (string name);

		[Export ("createAttachmentWithName:type:")]
		CouchAttachment CreateAttachment (string name, string contentType);

	}


	[BaseType (typeof (CouchResource))]
	interface CouchAttachment {
		[Export ("document")]
		CouchDocument Document { get;  }

		[Export ("name")]
		string Name { get;  }

		[Export ("contentType")]
		string ContentType { get;  }

		[Export ("length")]
		long Length { get;  }

		[Export ("metadata")]
		NSDictionary Metadata { get;  }

		[Export ("body")]
		NSData Body { get; set;  }

		[Export ("unversionedURL")]
		NSUrl UnversionedUrl { get;  }

		[Export ("revision")]
		CouchRevision GetRevision ();

		[Export ("PUT:contentType:")]
		RestOperation Put (NSData body, string contentType);

		[Export ("PUT:")]
		RestOperation Put (NSData body);

	}

	[BaseType (typeof (NSObject))]
	interface TDRevision {
		[Export ("docID")]
		string DocID { get;  }

		[Export ("revID")]
		string RevID { get;  }

		[Export ("deleted")]
		bool Deleted { get;  }

		[Export ("body")]
		TDBody Body { get; set;  }

		[Export ("properties")]
		NSDictionary Properties { get; set;  }

		[Export ("asJSON")]
		NSData AsJson { get; set;  }

		[Export ("sequence")]
		long Sequence { get; set;  }

		[Export ("generation")]
		uint Generation { get;  }

		[Export ("initWithDocID:revID:deleted:")]
		IntPtr Constructor (string docID, string revID, bool deleted);

		[Export ("initWithBody:")]
		IntPtr Constructor (TDBody body);

		[Export ("initWithProperties:")]
		IntPtr Constructor (NSDictionary properties);

		[Static]
		[Export ("revisionWithProperties:")]
		TDRevision FromProperties (NSDictionary properties);

		[Export ("compareSequences:")]
		NSComparisonResult CompareSequences (TDRevision rev);

		[Static]
		[Export ("generationFromRevID:")]
		uint GenerationFromRevID (string revID);

		[Export ("copyWithDocID:revID:")]
		TDRevision CopyWithDocIDrevID (string docID, string revID);

	}

	[BaseType (typeof (NSObject))]
	interface TDRevisionList {
		[Export ("count")]
		uint Count { get;  }

		[Export ("allRevisions")]
		NSArray AllRevisions { get;  }

		[Export ("allDocIDs")]
		NSArray AllDocIDs { get;  }

		[Export ("allRevIDs")]
		NSArray AllRevIDs { get;  }

		[Export ("initWithArray:")]
		NSObject InitWithArray (NSArray revs);

		[Export ("revWithDocID:revID:")]
		TDRevision RevWithDocIDrevID (string docID, string revID);

		[Export ("objectEnumerator")]
		NSEnumerator ObjectEnumerator ();

		[Export ("addRev:")]
		void AddRev (TDRevision rev);

		[Export ("removeRev:")]
		void RemoveRev (TDRevision rev);

		[Export ("limit:")]
		void Limit (uint limit);

		[Export ("sortBySequence")]
		void SortBySequence ();

	}


	[BaseType (typeof (NSObject))]
	interface TDBody {
		[Export ("isValidJSON")]
		bool IsValidJson { get;  }

		[Export ("asJSON")]
		NSData AsJson { get;  }

		[Export ("asPrettyJSON")]
		NSData AsPrettyJson { get;  }

		[Export ("asJSONString")]
		string AsJsonString { get;  }

		[Export ("asObject")]
		NSObject AsObject { get;  }

		[Export ("error")]
		bool Error { get;  }

		[Export ("properties")]
		NSDictionary Properties { get;  }

		[Export ("initWithProperties:")]
		IntPtr Constructor (NSDictionary properties);

		[Export ("initWithArray:")]
		IntPtr Constructor (NSArray array);

		[Export ("initWithJSON:")]
		IntPtr Constructor (NSData json);

		[Static]
		[Export ("bodyWithProperties:")]
		TDBody FromProperties (NSObject properties);

		[Static]
		[Export ("bodyWithJSON:")]
		TDBody FromJson (NSData json);

		[Export ("propertyForKey:")]
		NSObject GetPropertyForKey (string key);
	}


	[BaseType (typeof (CouchDynamicObject))]
	interface CouchModel {
		[Export ("document")]
		CouchDocument Document { get;  }

		[Export ("database")]
		CouchDatabase Database { get; set;  }

		[Export ("isNew")]
		bool IsNew { get;  }

		[Export ("autosaves")]
		bool Autosaves { get; set;  }

		[Export ("needsSave")]
		bool NeedsSave { get;  }

		[Export ("timeSinceExternallyChanged")]
		double TimeSinceExternallyChanged { get;  }

		[Export ("attachmentNames")]
		string [] AttachmentNames { get;  }

		[Export ("modelForDocument:")]
		CouchModel FromDocument (CouchDocument document);

		[Export ("initWithNewDocumentInDatabase:")]
		IntPtr Constructor (CouchDatabase database);

		[Export ("save")]
		RestOperation Save ();

		[Export ("propertiesToSave")]
		NSDictionary PropertiesToSave ();

		[Export ("deleteDocument")]
		RestOperation DeleteDocument ();

		[Static]
		[Export ("saveModels:")]
		RestOperation SaveModels (NSArray models);

		[Export ("markExternallyChanged")]
		void MarkExternallyChanged ();

		[Export ("getValueOfProperty:")]
		NSObject GetValueOfProperty (string property);

		[Export ("setValue:ofProperty:")]
		bool SetValueofProperty (NSObject value, string property);

		[Export ("attachmentNamed:")]
		CouchAttachment GetAttachment (string name);

		[Export ("createAttachmentWithName:type:body:")]
		CouchAttachment CreateAttachment (string name, string contentType, NSData body);

		[Export ("removeAttachmentNamed:")]
		void RemoveAttachment (string name);

		[Export ("idForNewDocumentInDatabase:")]
		string IdForNewDocumentInDatabase (CouchDatabase db);

		[Export ("didLoadFromDocument")]
		void DidLoadFromDocument ();

		[Export ("databaseForModelProperty:")]
		CouchDatabase DatabaseForModelProperty (string propertyName);
	}


	[BaseType (typeof (NSObject))]
	interface CouchDynamicObject {
		[Static]
		[Export ("propertyNames")]
		NSSet GetPropertyNames ();

		[Export ("getValueOfProperty:")]
		NSObject GetValue (string property);

		[Export ("setValue:ofProperty:")]
		bool SetValue (NSObject value, string property);

		[Static]
		[Export ("classOfProperty:")]
		Class ClassOfProperty (string propertyName);

		[Static]
		[Export ("getterKey:")]
		string GetterKey (Selector sel);

		[Static]
		[Export ("setterKey:")]
		string SetterKey (Selector sel);

	}

}

