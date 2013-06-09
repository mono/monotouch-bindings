using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Google.Plus
{
	[BaseType (typeof (NSObject), Name = "GPPDeepLinkDelegate")]
	[Protocol]
	[Model]
	interface DeepLinkDelegate {
		[Export ("didReceiveDeepLink:")]
		void DidReceiveDeepLink (DeepLink deepLink);
	}

	[BaseType (typeof (NSObject), Name = "GPPDeepLink")]
	interface DeepLink {

		[Static]
		[Export ("setDelegate:")]
		void SetDelegate (DeepLinkDelegate aDelegate);

		[Static]
		[Export ("readDeepLinkAfterInstall")]
		DeepLink ReadDeepLinkAfterInstall { get; }

		[Static]
		[Export ("handleURL:sourceApplication:annotation:")]
		DeepLink HandleUrl (NSUrl url, string sourceApplication, NSObject annotation);

		[Static]
		[Export ("deepLinkID")]
		string DeepLinkID { get; }

		[Static]
		[Export ("source")]
		string Source { get; }
	}

	[BaseType (typeof (NSObject), Name = "GPPShareDelegate")]
	[Protocol]
	[Model]
	interface ShareDelegate {
		[Export ("finishedSharing:")]
		void FinishedSharing (bool shared);
	}

	[BaseType (typeof (NSObject), Name = "GPPShareBuilder")]
	[Protocol]
	interface ShareBuilder {

		[Bind ("setURLToShare:")]
		ShareBuilder SetURLToShare (NSUrl urlToShare);

		[Bind ("setPrefillText:")]
		ShareBuilder SetPrefillText (string prefillText);

		[Bind ("setTitle:description:thumbnailURL:")]
		ShareBuilder SetTitle (string title, string description, NSUrl thumbnailUrl);

		[Bind ("setContentDeepLinkID:")]
		ShareBuilder SetContentDeepLinkId (string contentDeepLinkID);

		[Bind ("setCallToActionButtonWithLabel:URL:deepLinkID:")]
		ShareBuilder SetCallToActionButton (string label, NSUrl url, string deepLinkID);

		[Bind ("open")]
		bool Open ();
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GPPShare")]
	interface Share {

		[Wrap ("WeakDelegate")][NullAllowed]
		ShareDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Static]
		[Export ("sharedInstance")]
		Share SharedInstance { get; }

		[Export ("shareDialog")] [Internal]
		IntPtr ShareDialog_ { get; }

		//		[Export ("shareDialog")]
		//		ShareBuilder ShareDialog { get; }

		[Export ("handleURL:sourceApplication:annotation:")]
		bool HandleUrl (NSUrl url, string sourceApplication, NSObject annotation);
	}

	[BaseType (typeof (NSObject), Name = "GPPSignInDelegate")]
	[Protocol]
	[Model]
	interface SignInDelegate {

		[Abstract]
		[Export ("finishedWithAuth:error:"), EventArgs ("SignInDelegateFinished")]
		void Finished (Google.OpenSource.OAuth2Authentication auth, NSError error);

		[Export ("didDisconnectWithError:"), EventArgs ("SignInDelegateDidDisconnect")]
		void DidDisconnect (NSError error);
	}

	[BaseType (typeof (NSObject), Name = "GPPSignIn",
	           Delegates= new string [] {"WeakDelegate"},
	Events=new Type [] { typeof (SignInDelegate) })]
	interface SignIn {

		[Export ("authentication")]
		Google.OpenSource.OAuth2Authentication Authentication { get; }

		[Export ("userID")]
		string UserId { get; }

		[Export ("userEmail")]
		string UserEmail { get; }

		[Wrap ("WeakDelegate")][NullAllowed]
		SignInDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("clientID", ArgumentSemantic.Copy)]
		string ClientId { get; set; }

		[Export ("scopes", ArgumentSemantic.Copy)]
		string [] Scopes { get; set; }

		[Export ("attemptSSO", ArgumentSemantic.Assign)]
		bool AttemptSSO { get; set; }

		[Export ("language", ArgumentSemantic.Copy)]
		string Language { get; set; }

		[Export ("keychainName", ArgumentSemantic.Copy)]
		string KeychainName { get; set; }

		[Export ("actions", ArgumentSemantic.Copy)]
		string [] Actions { get; set; }

		[Export ("shouldFetchGoogleUserEmail", ArgumentSemantic.Assign)]
		bool ShouldFetchGoogleUserEmail { get; set; }

		[Export ("shouldFetchGoogleUserID", ArgumentSemantic.Assign)]
		bool ShouldFetchGoogleUserId { get; set; }

		[Static]
		[Export ("sharedInstance")]
		SignIn SharedInstance { get; }

		[Export ("hasAuthInKeychain")]
		bool HasAuthInKeychain { get; }

		[Export ("trySilentAuthentication")]
		bool TrySilentAuthentication { get; }

		[Export ("authenticate")]
		bool Authenticate ();

		[Export ("handleURL:sourceApplication:annotation:")]
		bool HandleUrl (NSUrl url, string sourceApplication, NSObject annotation);

		[Export ("signOut")]
		bool SignOut ();

		[Export ("disconnect")]
		bool Disconnect ();

		// TODO: Bind GTLServicePlus found in GoogleOpenSource.Framework
		//		[Export ("plusService")]
		//		GTLServicePlus PlusService { get; }
	}

	[BaseType (typeof (UIButton), Name = "GPPSignInButton")]
	interface SignInButton {

		[Export ("setStyle:")]
		void SetStyle (SignInButtonStyle style);

		[Export ("setColorScheme:")]
		void SetColorScheme (SignInButtonColorScheme colorScheme);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (UIButton), Name = "GPPURLHandler")]
	interface UrlHandler {
		[Static]
		[Export ("handleURL:sourceApplication:annotation:")]
		bool HandleUrl ([NullAllowed] NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);
	}
}

#region "GoogleOpenSource"

namespace Google.OpenSource
{
	[BaseType (typeof (NSObject), Name = "GTMOAuth2Authentication")]
	interface OAuth2Authentication {
		// TODO: Fully Bind it, IF NEEDED

		[Export ("clientID", ArgumentSemantic.Copy)]
		string ClientId { get; set; }

		[Export ("clientSecret", ArgumentSemantic.Copy)]
		string ClientSecret { get; set; }

		[Export ("redirectURI", ArgumentSemantic.Copy)]
		string RedirectUri { get; set; }

		[Export ("scope", ArgumentSemantic.Copy)]
		string Scope { get; set; }

		[Export ("tokenType", ArgumentSemantic.Copy)]
		string TokenType { get; set; }

		[Export ("assertion", ArgumentSemantic.Copy)]
		string Assertion { get; set; }

		[Export ("refreshScope", ArgumentSemantic.Copy)]
		string RefreshScope { get; set; }

		[Export ("additionalTokenRequestParameters", ArgumentSemantic.Retain)]
		NSDictionary AdditionalTokenRequestParameters { get; set; }

		[Export ("additionalGrantTypeRequestParameters", ArgumentSemantic.Retain)]
		NSDictionary AdditionalGrantTypeRequestParameters { get; set; }

		[Export ("parameters", ArgumentSemantic.Retain)]
		NSDictionary Parameters { get; set; }

		[Export ("accessToken", ArgumentSemantic.Retain)]
		string AccessToken { get; set; }

		[Export ("refreshToken", ArgumentSemantic.Retain)]
		string RefreshToken { get; set; }

		[Export ("expiresIn", ArgumentSemantic.Retain)]
		NSNumber ExpiresIn { get; set; }

		[Export ("code", ArgumentSemantic.Retain)]
		string Code { get; set; }

		[Export ("errorString", ArgumentSemantic.Retain)]
		string ErrorString { get; set; }

		[Export ("tokenURL", ArgumentSemantic.Copy)]
		NSUrl TokenURL { get; set; }

		[Export ("expirationDate", ArgumentSemantic.Copy)]
		NSDate ExpirationDate { get; set; }

		[Export ("serviceProvider", ArgumentSemantic.Copy)]
		string ServiceProvider { get; set; }

		[Export ("userID", ArgumentSemantic.Retain)]
		string UserID { get; set; }

		[Export ("userEmail", ArgumentSemantic.Retain)]
		string UserEmail { get; set; }

		[Export ("userEmailIsVerified", ArgumentSemantic.Retain)]
		string UserEmailIsVerified { get; set; }

		[Export ("canAuthorize")]
		bool CanAuthorize { get; }

		[Export ("shouldAuthorizeAllRequests", ArgumentSemantic.Assign)]
		string ShouldAuthorizeAllRequests { get; set; }

		[Export ("userData", ArgumentSemantic.Retain)]
		NSObject UserData { get; set; }

		[Export ("properties", ArgumentSemantic.Retain)]
		NSDictionary Properties { get; set; }

		[Export ("authorizationTokenKey", ArgumentSemantic.Copy)]
		string AuthorizationTokenKey { get; set; }
	}

	[BaseType (typeof (NSObject), Name = "GTLDateTime")]
	interface PlusDateTime {
		[Static, Export ("dateTimeWithRFC3339String:")]
		PlusDateTime DateTimeWithRfc3339String (string str);

		[Static, Export ("dateTimeWithDate:timeZone:")]
		PlusDateTime DateTimeWithDate (NSDate date, NSTimeZone tz);

		[Static, Export ("dateTimeForAllDayWithDate:")]
		PlusDateTime DateTimeForAllDayWithDate (NSDate date);

		[Static, Export ("dateTimeWithDateComponents:")]
		PlusDateTime DateTimeWithDateComponents (NSDateComponents date);

		[Export ("date")]
		NSDate Date { get; }

		[Export ("calendar")]
		NSCalendar Calendar { get; }

		[Export ("RFC3339String")]
		string Rfc3339String { get; }

		[Export ("stringValue")]
		string StringValue { get; }

		[Export ("timeZone")]
		NSTimeZone TimeZone { get; }

		[Export ("dateComponents")]
		NSDateComponents DateComponents { get; }

		[Export ("milliseconds")]
		int Milliseconds { get; }

		[Export ("hasTime")]
		bool HasTime { get; }

		[Export ("offsetSeconds")]
		int OffsetSeconds { get; }

		[Export ("universalTime")]
		bool UniversalTime { [Bind ("isUniversalTime")] get; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLCollectionObject")]
	interface PlusCollectionObject {
		[Export ("itemAtIndex:")]
		NSObject ItemAtIndex (uint idx);

		[Export ("objectAtIndexedSubscript:")]
		NSObject ObjectAtIndexedSubscript (int idx);

		[Export ("itemForIdentifier:")]
		NSObject ItemForIdentifier (string key);

		[Export ("resetIdentifierMap")]
		void ResetIdentifierMap ();

		[Export ("items")]
		NSObject [] Items { get; }
	}

	[BaseType (typeof (PlusCollectionObject), Name = "GTLResultArray")]
	interface PlusResultArray {
		[Export ("itemsWithItemClass:")]
		NSObject [] ItemsWithItemClass (Class itemClass);
	}

	[BaseType (typeof (NSObject), Name = "GTLObject")]
	interface PlusObject {
		[Export ("JSON")]
		NSMutableDictionary Json { get; set; }

		[Export ("surrogates")]
		NSDictionary Surrogates { get; set; }

		[Export ("userProperties")]
		NSMutableDictionary UserProperties { get; set; }

		[Static]
		[Export ("object")]
		PlusObject GetPlusObject { get; }

		[Static]
		[Export ("objectWithJSON:")]
		PlusObject GetGobjectFromJson (NSMutableDictionary dict);

		[Export ("JSONString")]
		string JsonString { get; }

		[Export ("setJSONValue:forKey:")]
		void SetJsonValue (NSObject val, string key);

		[Export ("JSONValueForKey:")]
		NSObject JsonValueForKey (string key);

		[Export ("additionalJSONKeys")]
		string [] AdditionalJsonKeys { get; }

		[Export ("additionalPropertyForName:")]
		NSObject AdditionalProperty (string name);

		[Export ("setAdditionalProperty:forName:")]
		void SetAdditionalProperty (NSObject obj, string name);

		[Export ("additionalProperties")]
		NSDictionary AdditionalProperties { get; }

		[Export ("setProperty:forKey:")]
		void SetProperty (NSObject obj, string key);

		[Export ("propertyForKey:")]
		NSObject PropertyForKey (string key);

		[Export ("setUserData:")]
		void SetUserData (NSObject obj);

		[Export ("userData")]
		NSObject UserData { get; }

		[Export ("fieldsDescription")]
		string FieldsDescription { get; }

		[Export ("patchObjectFromOriginal:")]
		void PatchObjectFromOriginal (PlusObject obj);

		[Static]
		[Export ("nullValue")]
		NSObject NullValue { get; }
	}

	[BaseType (typeof (PlusCollectionObject), Name = "GTLPlusAcl")]
	interface PlusAcl {
		[Export ("descriptionProperty")]
		string DescriptionProperty { get; set; }

		[Export ("items")] [New]
		PlusAclentryResource [] Items { get; set; }

		[Export ("kind")]
		string Kind { get; set; }
	}

	[BaseType (typeof (PlusCollectionObject), Name = "GTLPlusAclentryResource")]
	interface PlusAclentryResource {
		[Export ("displayName")]
		string DisplayName { get; set; }

		[Export ("identifier")]
		string Identifier { get; set; }

		[Export ("type")]
		string Type { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivity")]
	interface PlusActivity {

		[Export ("access")]
		PlusAcl Access { get; set; }

		[Export ("actor")]
		PlusActivityActor Actor { get; set; }

		[Export ("address")]
		string Address { get; set; }

		[Export ("annotation")]
		string Annotation { get; set; }

		[Export ("crosspostSource")]
		string CrosspostSource { get; set; }

		[Export ("ETag")]
		string ETAg { get; set; }

		[Export ("geocode")]
		string Geocode { get; set; }

		[Export ("identifier")]
		string Identifier { get; set; }

		[Export ("kind")]
		string Kind { get; set; }

		[Export ("object")]
		PlusActivityObject ActivityObject { get; set; }

		[Export ("placeId")]
		string PlaceId { get; set; }

		[Export ("placeName")]
		string PlaceName { get; set; }

		[Export ("provider")]
		PlusActivityProvider Provider { get; set; }

		[Export ("published")]
		PlusDateTime Published { get; set; }

		[Export ("radius")]
		string Radius { get; set; }

		[Export ("title")]
		string Title { get; set; }

		[Export ("updated")]
		PlusDateTime Updated { get; set; }

		[Export ("url")]
		string Url { get; set; }

		[Export ("verb")]
		string Verb { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivityActor")]
	interface PlusActivityActor {

		[Export ("displayName")]
		string DisplayName { get; set; }

		[Export ("identifier")]
		string Identifier { get; set; }

		[Export ("image")]
		PlusActivityActorImage Image { get; set; }

		[Export ("name")]
		PlusActivityActorName Name { get; set; }

		[Export ("url")]
		string Url { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivityObject")]
	interface PlusActivityObject {

		[Export ("actor")]
		PlusActivityObjectActor Actor { get; set; }

		[Export ("attachments")]
		PlusActivityObjectAttachmentsItem [] Attachments { get; set; }

		[Export ("content")]
		string Content { get; set; }

		[Export ("identifier")]
		string Identifier { get; set; }

		[Export ("objectType")]
		string ObjectType { get; set; }

		[Export ("originalContent")]
		string OriginalContent { get; set; }

		[Export ("plusoners")]
		PlusActivityObjectPlusoners Plusoners { get; set; }

		[Export ("replies")]
		PlusActivityObjectReplies Replies { get; set; }

		[Export ("resharers")]
		PlusActivityObjectResharers Resharers { get; set; }

		[Export ("url")]
		string Url { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivityProvider")]
	interface PlusActivityProvider {

		[Export ("title")]
		string Title { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivityActorImage")]
	interface PlusActivityActorImage {

		[Export ("url")]
		string Url { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivityActorName")]
	interface PlusActivityActorName {

		[Export ("familyName")]
		string FamilyName { get; set; }

		[Export ("givenName")]
		string GivenName { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivityObjectActor")]
	interface PlusActivityObjectActor {

		[Export ("displayName")]
		string DisplayName { get; set; }

		[Export ("identifier")]
		string Identifier { get; set; }

		[Export ("image")]
		PlusActivityObjectActorImage Image { get; set; }

		[Export ("url")]
		string Url { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivityObjectAttachmentsItem")]
	interface PlusActivityObjectAttachmentsItem {

		[Export ("content")]
		string Content { get; set; }

		[Export ("displayName")]
		string DisplayName { get; set; }

		[Export ("embed")]
		PlusActivityObjectAttachmentsItemEmbed Embed { get; set; }

		[Export ("fullImage")]
		PlusActivityObjectAttachmentsItemFullImage FullImage { get; set; }

		[Export ("identifier")]
		string Identifier { get; set; }

		[Export ("image")]
		PlusActivityObjectAttachmentsItemImage Image { get; set; }

		[Export ("objectType")]
		string ObjectType { get; set; }

		[Export ("thumbnails")]
		PlusActivityObjectAttachmentsItemThumbnailsItem [] Thumbnails { get; set; }

		[Export ("url")]
		string Url { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivityObjectPlusoners")]
	interface PlusActivityObjectPlusoners {

		[Export ("selfLink")]
		string SelfLink { get; set; }

		[Export ("totalItems")]
		NSNumber TotalItems { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivityObjectReplies")]
	interface PlusActivityObjectReplies {

		[Export ("selfLink")]
		string SelfLink { get; set; }

		[Export ("totalItems")]
		NSNumber TotalItems { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivityObjectResharers")]
	interface PlusActivityObjectResharers {

		[Export ("selfLink")]
		string SelfLink { get; set; }

		[Export ("totalItems")]
		NSNumber TotalItems { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivityObjectActorImage")]
	interface PlusActivityObjectActorImage {

		[Export ("url")]
		string Url { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivityObjectAttachmentsItemEmbed")]
	interface PlusActivityObjectAttachmentsItemEmbed {

		[Export ("type")]
		string Type { get; set; }

		[Export ("url")]
		string Url { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivityObjectAttachmentsItemFullImage")]
	interface PlusActivityObjectAttachmentsItemFullImage {

		[Export ("height")]
		NSNumber Height { get; set; }

		[Export ("type")]
		string Type { get; set; }

		[Export ("url")]
		string Url { get; set; }

		[Export ("width")]
		NSNumber Width { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivityObjectAttachmentsItemImage")]
	interface PlusActivityObjectAttachmentsItemImage {

		[Export ("height")]
		NSNumber Height { get; set; }

		[Export ("type")]
		string Type { get; set; }

		[Export ("url")]
		string Url { get; set; }

		[Export ("width")]
		NSNumber Width { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivityObjectAttachmentsItemThumbnailsItem")]
	interface PlusActivityObjectAttachmentsItemThumbnailsItem {

		[Export ("descriptionProperty")]
		string DescriptionProperty { get; set; }

		[Export ("image")]
		PlusActivityObjectAttachmentsItemThumbnailsItemImage Image { get; set; }

		[Export ("url")]
		string Url { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusActivityObjectAttachmentsItemThumbnailsItemImage")]
	interface PlusActivityObjectAttachmentsItemThumbnailsItemImage {

		[Export ("height")]
		NSNumber Height { get; set; }

		[Export ("type")]
		string Type { get; set; }

		[Export ("url")]
		string Url { get; set; }

		[Export ("width")]
		NSNumber Width { get; set; }
	}

	[BaseType (typeof (PlusCollectionObject), Name = "GTLPlusActivityFeed")]
	interface PlusActivityFeed {

		[Export ("ETag")]
		string ETAg { get; set; }

		[Export ("identifier")]
		string Identifier { get; set; }

		[Export ("items")] [New]
		PlusActivity [] Items { get; set; }

		[Export ("kind")]
		string Kind { get; set; }

		[Export ("nextLink")]
		string NextLink { get; set; }

		[Export ("nextPageToken")]
		string NextPageToken { get; set; }

		[Export ("selfLink")]
		string SelfLink { get; set; }

		[Export ("title")]
		string Title { get; set; }

		[Export ("updated")]
		PlusDateTime Updated { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusComment")]
	interface PlusComment {

		[Export ("actor")]
		PlusCommentActor Actor { get; set; }

		[Export ("ETag")]
		string ETAg { get; set; }

		[Export ("identifier")]
		string Identifier { get; set; }

		[Export ("inReplyTo")]
		PlusCommentInReplyToItem [] InReplyTo { get; set; }

		[Export ("kind")]
		string Kind { get; set; }

		[Export ("object")]
		PlusCommentObject Object { get; set; }

		[Export ("plusoners")]
		PlusCommentPlusoners Plusoners { get; set; }

		[Export ("published")]
		PlusDateTime Published { get; set; }

		[Export ("selfLink")]
		string SelfLink { get; set; }

		[Export ("updated")]
		PlusDateTime Updated { get; set; }

		[Export ("verb")]
		string Verb { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusCommentActor")]
	interface PlusCommentActor {

		[Export ("displayName")]
		string DisplayName { get; set; }

		[Export ("identifier")]
		string Identifier { get; set; }

		[Export ("image")]
		PlusCommentActorImage Image { get; set; }

		[Export ("url")]
		string Url { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusCommentInReplyToItem")]
	interface PlusCommentInReplyToItem {

		[Export ("identifier")]
		string Identifier { get; set; }

		[Export ("url")]
		string Url { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusCommentObject")]
	interface PlusCommentObject {

		[Export ("content")]
		string Content { get; set; }

		[Export ("objectType")]
		string ObjectType { get; set; }

		[Export ("originalContent")]
		string OriginalContent { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusCommentPlusoners")]
	interface PlusCommentPlusoners {

		[Export ("totalItems")]
		NSNumber TotalItems { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusCommentActorImage")]
	interface PlusCommentActorImage {

		[Export ("url")]
		string Url { get; set; }
	}

	[BaseType (typeof (PlusCollectionObject), Name = "GTLPlusCommentFeed")]
	interface PlusCommentFeed {

		[Export ("ETag")]
		string ETAg { get; set; }

		[Export ("identifier")]
		string Identifier { get; set; }

		[Export ("items")] [New]
		PlusComment [] Items { get; set; }

		[Export ("kind")]
		string Kind { get; set; }

		[Export ("nextLink")]
		string NextLink { get; set; }

		[Export ("nextPageToken")]
		string NextPageToken { get; set; }

		[Export ("title")]
		string Title { get; set; }

		[Export ("updated")]
		PlusDateTime Updated { get; set; }
	}

	[BaseType (typeof (PlusObject))]
	interface PlusItemScope {

		[Export ("about")]
		PlusItemScope About { get; set; }

		[Export ("additionalName")]
		string [] AdditionalName { get; set; }

		[Export ("address")]
		PlusItemScope Address { get; set; }

		[Export ("addressCountry")]
		string AddressCountry { get; set; }

		[Export ("addressLocality")]
		string AddressLocality { get; set; }

		[Export ("addressRegion")]
		string AddressRegion { get; set; }

		[Export ("associatedMedia")]
		PlusItemScope [] AssociatedMedia { get; set; }

		[Export ("attendeeCount")]
		NSNumber AttendeeCount { get; set; }

		[Export ("attendees")]
		PlusItemScope [] Attendees { get; set; }

		[Export ("audio")]
		PlusItemScope Audio { get; set; }

		[Export ("author")]
		PlusItemScope [] Author { get; set; }

		[Export ("bestRating")]
		string BestRating { get; set; }

		[Export ("birthDate")]
		string BirthDate { get; set; }

		[Export ("byArtist")]
		PlusItemScope ByArtist { get; set; }

		[Export ("caption")]
		string Caption { get; set; }

		[Export ("contentSize")]
		string ContentSize { get; set; }

		[Export ("contentUrl")]
		string ContentUrl { get; set; }

		[Export ("contributor")]
		PlusItemScope [] Contributor { get; set; }

		[Export ("dateCreated")]
		string DateCreated { get; set; }

		[Export ("dateModified")]
		string DateModified { get; set; }

		[Export ("datePublished")]
		string DatePublished { get; set; }

		[Export ("descriptionProperty")]
		string DescriptionProperty { get; set; }

		[Export ("duration")]
		string Duration { get; set; }

		[Export ("embedUrl")]
		string EmbedUrl { get; set; }

		[Export ("endDate")]
		string EndDate { get; set; }

		[Export ("familyName")]
		string FamilyName { get; set; }

		[Export ("gender")]
		string Gender { get; set; }

		[Export ("geo")]
		PlusItemScope Geo { get; set; }

		[Export ("givenName")]
		string GivenName { get; set; }

		[Export ("height")]
		string Height { get; set; }

		[Export ("identifier")]
		string Identifier { get; set; }

		[Export ("image")]
		string Image { get; set; }

		[Export ("inAlbum")]
		PlusItemScope InAlbum { get; set; }

		[Export ("kind")]
		string Kind { get; set; }

		[Export ("latitude")]
		NSNumber Latitude { get; set; }

		[Export ("location")]
		PlusItemScope Location { get; set; }

		[Export ("longitude")]
		NSNumber Longitude { get; set; }

		[Export ("name")]
		string Name { get; set; }

		[Export ("partOfTVSeries")]
		PlusItemScope PartOfTvsEries { get; set; }

		[Export ("performers")]
		PlusItemScope [] Performers { get; set; }

		[Export ("playerType")]
		string PlayerType { get; set; }

		[Export ("postalCode")]
		string PostalCode { get; set; }

		[Export ("postOfficeBoxNumber")]
		string PostOfficeBoxNumber { get; set; }

		[Export ("ratingValue")]
		string RatingValue { get; set; }

		[Export ("reviewRating")]
		PlusItemScope ReviewRating { get; set; }

		[Export ("startDate")]
		string StartDate { get; set; }

		[Export ("streetAddress")]
		string StreetAddress { get; set; }

		[Export ("text")]
		string Text { get; set; }

		[Export ("thumbnail")]
		PlusItemScope Thumbnail { get; set; }

		[Export ("thumbnailUrl")]
		string ThumbnailUrl { get; set; }

		[Export ("tickerSymbol")]
		string TickerSymbol { get; set; }

		[Export ("type")]
		string Type { get; set; }

		[Export ("url")]
		string Url { get; set; }

		[Export ("width")]
		string Width { get; set; }

		[Export ("worstRating")]
		string WorstRating { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusMoment")]
	interface PlusMoment {

		[Export ("identifier")]
		string Identifier { get; set; }

		[Export ("kind")]
		string Kind { get; set; }

		[Export ("result")]
		PlusItemScope Result { get; set; }

		[Export ("startDate")]
		PlusDateTime StartDate { get; set; }

		[Export ("target")]
		PlusItemScope Target { get; set; }

		[Export ("type")]
		string Type { get; set; }
	}

	[BaseType (typeof (PlusCollectionObject), Name = "GTLPlusMomentsFeed")]
	interface PlusMomentsFeed {

		[Export ("ETag")]
		string ETAg { get; set; }

		[Export ("items")] [New]
		PlusMoment [] Items { get; set; }

		[Export ("kind")]
		string Kind { get; set; }

		[Export ("nextLink")]
		string NextLink { get; set; }

		[Export ("nextPageToken")]
		string NextPageToken { get; set; }

		[Export ("selfLink")]
		string SelfLink { get; set; }

		[Export ("title")]
		string Title { get; set; }

		[Export ("updated")]
		PlusDateTime Updated { get; set; }
	}

	[BaseType (typeof (PlusCollectionObject), Name = "GTLPlusPeopleFeed")]
	interface PlusPeopleFeed {

		[Export ("ETag")]
		string ETAg { get; set; }

		[Export ("items")] [New]
		PlusPerson [] Items { get; set; }

		[Export ("kind")]
		string Kind { get; set; }

		[Export ("nextPageToken")]
		string NextPageToken { get; set; }

		[Export ("selfLink")]
		string SelfLink { get; set; }

		[Export ("title")]
		string Title { get; set; }

		[Export ("totalItems")]
		NSNumber TotalItems { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusPerson")]
	interface PlusPerson {
		[Export ("aboutMe")]
		string AboutMe { get; set; }

		[Export ("ageRange")]
		PlusPersonAgeRange AgeRange { get; set; }

		[Export ("birthday")]
		string Birthday { get; set; }

		[Export ("braggingRights")]
		string BraggingRights { get; set; }

		[Export ("circledByCount")]
		NSNumber CircledByCount { get; set; }

		[Export ("cover")]
		PlusPersonCover Cover { get; set; }

		[Export ("currentLocation")]
		string CurrentLocation { get; set; }

		[Export ("displayName")]
		string DisplayName { get; set; }

		[Export ("emails")]
		NSObject [] Emails { get; set; }

		[Export ("ETag")]
		string ETAg { get; set; }

		[Export ("gender")]
		string Gender { get; set; }

		[Export ("hasApp")]
		NSNumber HasApp { get; set; }

		[Export ("identifier")]
		string Identifier { get; set; }

		[Export ("image")]
		PlusPersonImage Image { get; set; }

		[Export ("isPlusUser")]
		NSNumber IsPlusUser { get; set; }

		[Export ("kind")]
		string Kind { get; set; }

		[Export ("language")]
		string Language { get; set; }

		[Export ("name")]
		PlusPersonName Name { get; set; }

		[Export ("nickname")]
		string Nickname { get; set; }

		[Export ("objectType")]
		string ObjectType { get; set; }

		[Export ("organizations")]
		PlusPersonOrganizationsItem [] Organizations { get; set; }

		[Export ("placesLived")]
		PlusPersonPlacesLivedItem [] PlacesLived { get; set; }

		[Export ("plusOneCount")]
		NSNumber PlusOneCount { get; set; }

		[Export ("relationshipStatus")]
		string RelationshipStatus { get; set; }

		[Export ("tagline")]
		string Tagline { get; set; }

		[Export ("url")]
		string Url { get; set; }

		[Export ("urls")]
		PlusPersonUrlsItem [] Urls { get; set; }

		[Export ("verified")]
		NSNumber Verified { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusPersonAgeRange")]
	interface PlusPersonAgeRange {

		[Export ("max")]
		NSNumber Max { get; set; }

		[Export ("min")]
		NSNumber Min { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusPersonCover")]
	interface PlusPersonCover {

		[Export ("coverInfo")]
		PlusPersonCoverInfo CoverInfo { get; set; }

		[Export ("coverPhoto")]
		PlusPersonCoverPhoto CoverPhoto { get; set; }

		[Export ("layout")]
		string Layout { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusPersonEmailsItem")]
	interface PlusPersonEmailsItem {

		[Export ("primary")]
		NSNumber Primary { get; set; }

		[Export ("type")]
		string Type { get; set; }

		[Export ("value")]
		string Value { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusPersonImage")]
	interface PlusPersonImage {

		[Export ("url")]
		string Url { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusPersonName")]
	interface PlusPersonName {

		[Export ("familyName")]
		string FamilyName { get; set; }

		[Export ("formatted")]
		string Formatted { get; set; }

		[Export ("givenName")]
		string GivenName { get; set; }

		[Export ("honorificPrefix")]
		string HonorificPrefix { get; set; }

		[Export ("honorificSuffix")]
		string HonorificSuffix { get; set; }

		[Export ("middleName")]
		string MiddleName { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusPersonOrganizationsItem")]
	interface PlusPersonOrganizationsItem {

		[Export ("department")]
		string Department { get; set; }

		[Export ("descriptionProperty")]
		string DescriptionProperty { get; set; }

		[Export ("endDate")]
		string EndDate { get; set; }

		[Export ("location")]
		string Location { get; set; }

		[Export ("name")]
		string Name { get; set; }

		[Export ("primary")]
		NSNumber Primary { get; set; }

		[Export ("startDate")]
		string StartDate { get; set; }

		[Export ("title")]
		string Title { get; set; }

		[Export ("type")]
		string Type { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusPersonPlacesLivedItem")]
	interface PlusPersonPlacesLivedItem {
		[Export ("primary")]
		NSNumber Primary { get; set; }

		[Export ("value")]
		string Value { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusPersonUrlsItem")]
	interface PlusPersonUrlsItem {
		[Export ("primary")]
		NSNumber Primary { get; set; }

		[Export ("type")]
		string Type { get; set; }

		[Export ("value")]
		string Value { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusPersonCoverCoverInfo")]
	interface PlusPersonCoverInfo {

		[Export ("leftImageOffset")]
		NSNumber LeftImageOffset { get; set; }

		[Export ("topImageOffset")]
		NSNumber TopImageOffset { get; set; }
	}

	[BaseType (typeof (PlusObject), Name = "GTLPlusPersonCoverCoverPhoto")]
	interface PlusPersonCoverPhoto {

		[Export ("height")]
		NSNumber Height { get; set; }

		[Export ("url")]
		string Url { get; set; }

		[Export ("width")]
		NSNumber Width { get; set; }
	}

	[BaseType (typeof (NSObject), Name = "GTLQueryProtocol")]
	[Model]
	[Protocol]
	interface QueryProtocol {

		[Export ("isBatchQuery")]
		bool IsBatchQuery ();

		[Export ("shouldSkipAuthorization")]
		bool ShouldSkipAuthorization ();

		[Export ("executionDidStop")]
		void ExecutionDidStop ();

		[Export ("additionalHTTPHeaders")]
		NSDictionary AdditionalHTTPHeaders ();

		[Export ("urlQueryParameters")]
		NSDictionary UrlQueryParameters ();

		[Export ("uploadParameters")]
		UploadParameters UploadParams ();
	}

	delegate void CompletionHandler (ServiceTicket ticket, NSObject obj, NSError error);

	[BaseType (typeof (NSObject), Name = "GTLQuery")]
	interface Query {

		[Export ("methodName")]
		string MethodName { get; }

		[Export ("JSON")]
		NSMutableDictionary Json { get; set; }

		[Export ("bodyObject")]
		PlusObject BodyObject { get; set; }

		[Export ("requestID")]
		string RequestId { get; set; }

		[Export ("uploadParameters")]
		UploadParameters UploadParametrs { get; set; }

		[Export ("urlQueryParameters")]
		NSDictionary UrlQueryParameters { get; set; }

		[Export ("additionalHTTPHeaders")]
		NSDictionary AdditionalHTTPHeaders { get; set; }

		[Export ("expectedObjectClass")]
		Class ExpectedObjectClass { get; set; }

		[Export ("shouldSkipAuthorization")]
		bool ShouldSkipAuthorization { get; set; }

		[Export ("setCompletionBlock:")]
		void SetCompletionHandler (CompletionHandler handler);

		[Static]
		[Export ("queryWithMethodName:")]
		Query FromMethodName (string methodName);

		[Export ("initWithMethodName:")]
		IntPtr Constructor (string methodName);

		[Export ("setCustomParameter:forKey:")]
		void SetCustomParameter (NSObject obj, string key);

		[Static]
		[Export ("nextRequestID")]
		string NextRequestID { get; }

		[Static]
		[Export ("parameterNameMap")]
		NSDictionary ParameterNameMap { get; }

		[Static]
		[Export ("arrayPropertyToClassMap")]
		NSDictionary ArrayPropertyToClassMap { get; }

		[Export ("isBatchQuery")]
		bool IsBatchQuery ();

		[Export ("uploadParameters")]
		UploadParameters UploadParams ();

		[Export ("executionDidStop")]
		void ExecutionDidStop ();
	}

	[BaseType (typeof (Query), Name = "GTLQueryPlus")]
	interface QueryPlus {

		[Export ("fields")]
		string Fields { get; set; }

		[Export ("activityId")]
		string ActivityId { get; set; }

		[Export ("collection")]
		string Collection { get; set; }

		[Export ("commentId")]
		string CommentId { get; set; }

		[Export ("debug")]
		bool Debug { get; set; }

		[Export ("identifier")]
		string Identifier { get; set; }

		[Export ("language")]
		string Language { get; set; }

		[Export ("maxResults")]
		uint MaxResults { get; set; }

		[Export ("orderBy")]
		string OrderBy { get; set; }

		[Export ("pageToken")]
		string PageToken { get; set; }

		[Export ("query")]
		string Query { get; set; }

		[Export ("sortOrder")]
		string SortOrder { get; set; }

		[Export ("targetUrl")]
		string TargetUrl { get; set; }

		[Export ("type")]
		string Type { get; set; }

		[Export ("userId")]
		string UserId { get; set; }

		[Static, Export ("queryForActivitiesGetWithActivityId:")]
		QueryPlus QueryForActivitiesGetWithActivityId (string activityId);

		[Static, Export ("queryForActivitiesListWithUserId:collection:")]
		QueryPlus QueryForActivitiesListWithUserId (string userId, string collection);

		[Static, Export ("queryForActivitiesSearchWithQuery:")]
		QueryPlus QueryForActivitiesSearchWithQuery (string query);

		[Static, Export ("queryForCommentsGetWithCommentId:")]
		QueryPlus QueryForCommentsGetWithCommentId (string commentId);

		[Static, Export ("queryForCommentsListWithActivityId:")]
		QueryPlus QueryForCommentsListWithActivityId (string activityId);

		[Static, Export ("queryForMomentsInsertWithObject:userId:collection:")]
		QueryPlus QueryForMomentsInsertWithObject (PlusMoment obj, string userId, string collection);

		[Static, Export ("queryForMomentsListWithUserId:collection:")]
		QueryPlus QueryForMomentsListWithUserId (string userId, string collection);

		[Static, Export ("queryForMomentsRemoveWithIdentifier:")]
		QueryPlus QueryForMomentsRemoveWithIdentifier (string identifier);

		[Static, Export ("queryForPeopleGetWithUserId:")]
		QueryPlus QueryForPeopleGetWithUserId (string userId);

		[Static, Export ("queryForPeopleListWithUserId:collection:")]
		QueryPlus QueryForPeopleListWithUserId (string userId, string collection);

		[Static, Export ("queryForPeopleListByActivityWithActivityId:collection:")]
		QueryPlus QueryForPeopleListByActivityWithActivityId (string activityId, string collection);

		[Static, Export ("queryForPeopleSearchWithQuery:")]
		QueryPlus QueryForPeopleSearchWithQuery (string query);
	}

	delegate void ServiceCompletionHandler (ServiceTicket ticket, NSObject obj, NSError error);
	delegate void ServiceUploadProgressHandler (ServiceTicket ticket, ulong numberOfBytesRead, ulong dataLength);
	delegate void ServiceRetryHandler (ServiceTicket ticket, bool suggestedWillRetry, NSError error);
	
	[BaseType (typeof (NSObject), Name = "GTLService")]
	interface Service {

		[Export ("executeQuery:delegate:didFinishSelector:")]
		ServiceTicket ExecuteQuery (QueryProtocol query, NSObject aDelegate, Selector finishedSelector);

		[Export ("executeQuery:delegate:didFinishSelector:")]
		ServiceTicket ExecuteQuery (QueryProtocol query, ServiceCompletionHandler handler);

		[Export ("shouldFetchNextPages")]
		bool ShouldFetchNextPages { get; set; }

		[Export ("retryEnabled")]
		bool RetryEnabled { [Bind ("isRetryEnabled")] get; set; }

		[Export ("APIKey")]
		string APIKey { get; set; }

		[Export ("retrySelector")]
		Selector RetrySelector { get; set; }

		[Export ("setRetryBlock:")]
		void SetRetryHandler (ServiceRetryHandler handler);

		[Export ("maxRetryInterval")]
		double MaxRetryInterval { get; set; }

		[Export ("fetchObjectWithMethodNamed:parameters:objectClass:delegate:didFinishSelector:")]
		ServiceTicket FetchObject (string methodName, NSDictionary parameters, Class objectClass, NSObject aDelegate, Selector finishedSelector);

		[Export ("fetchObjectWithMethodNamed:insertingObject:objectClass:delegate:didFinishSelector:")]
		ServiceTicket FetchObject (string methodName, PlusObject bodyObject, Class objectClass, NSObject aDelegate, Selector finishedSelector);

		[Export ("fetchObjectWithMethodNamed:parameters:insertingObject:objectClass:delegate:didFinishSelector:")]
		ServiceTicket FetchObject (string methodName, NSDictionary parameters, PlusObject bodyObject, Class objectClass, NSObject aDelegate, Selector finishedSelector);

		[Export ("fetchObjectWithMethodNamed:parameters:objectClass:completionHandler:")]
		ServiceTicket FetchObject (string methodName, NSDictionary parameters, Class objectClass, ServiceCompletionHandler handler);

		[Export ("fetchObjectWithMethodNamed:insertingObject:objectClass:completionHandler:")]
		ServiceTicket FetchObject (string methodName, PlusObject bodyObject, Class objectClass, ServiceCompletionHandler handler);

		[Export ("fetchObjectWithMethodNamed:parameters:insertingObject:objectClass:completionHandler:")]
		ServiceTicket FetchObject (string methodName, NSDictionary parameters, PlusObject bodyObject, Class objectClass, ServiceCompletionHandler handler);

		[Export ("fetchObjectWithURL:delegate:didFinishSelector:")]
		ServiceTicket FetchObject (NSUrl objectURL, NSObject aDelegate, Selector finishedSelector);

		[Export ("fetchObjectWithURL:objectClass:delegate:didFinishSelector:")]
		ServiceTicket FetchObject (NSUrl objectURL, Class objectClass, NSObject aDelegate, Selector finishedSelector);

		[Export ("fetchPublicObjectWithURL:objectClass:delegate:didFinishSelector:")]
		ServiceTicket FetchPublicObject (NSUrl objectURL, Class objectClass, NSObject aDelegate, Selector finishedSelector);

		[Export ("fetchObjectByInsertingObject:forURL:delegate:didFinishSelector:")]
		ServiceTicket FetchObject (PlusObject bodyToPut, NSUrl destinationURL, NSObject aDelegate, Selector finishedSelector);

		[Export ("fetchObjectByUpdatingObject:forURL:delegate:didFinishSelector:")]
		ServiceTicket FetchObjectByUpdating (PlusObject bodyToPut, NSUrl destinationURL, NSObject aDelegate, Selector finishedSelector);

		[Export ("deleteResourceURL:ETag:delegate:didFinishSelector:")]
		ServiceTicket DeleteResource (NSUrl destinationURL, [NullAllowed] string etagOrNull, NSObject aDelegate, Selector finishedSelector);

		[Export ("fetchObjectWithURL:completionHandler:")]
		ServiceTicket FetchObject (NSUrl objectURL, ServiceCompletionHandler handler);

		[Export ("fetchObjectByInsertingObject:forURL:completionHandler:")]
		ServiceTicket FetchObject (PlusObject bodyToPut, NSUrl destinationURL, ServiceCompletionHandler handler);

		[Export ("fetchObjectByUpdatingObject:forURL:completionHandler:")]
		ServiceTicket FetchObjectByUpdating (PlusObject bodyToPut, NSUrl destinationURL, ServiceCompletionHandler handler);

		[Export ("deleteResourceURL:ETag:completionHandler:")]
		ServiceTicket DeleteResource (NSUrl destinationURL, [NullAllowed] string etagOrNull, ServiceCompletionHandler handler);

		[Export ("setServiceProperty:forKey:")]
		void SetServiceProperty ([NullAllowed] NSObject obj, string key);

		[Export ("servicePropertyForKey:")]
		NSObject SetServiceProperty (string key);

		[Export ("serviceProperties")]
		NSDictionary ServiceProperties { get; set; }

		[Export ("serviceUserData")]
		NSObject ServiceUserData { get; set; }

		[Export ("surrogates")]
		NSDictionary Surrogates { get; set; }

		[Export ("shouldFetchInBackground")]
		bool ShouldFetchInBackground { get; set; }

		[Export ("delegateQueue")]
		NSOperationQueue DelegateQueue { get; set; }

		[Export ("runLoopModes")]
		NSObject [] RunLoopModes { get; set; }

		[Export ("userAgentAddition")]
		string UserAgentAddition { get; set; }

		[Export ("userAgent")]
		string UserAgent { get; set; }

		[Export ("requestUserAgent")]
		string RequestUserAgent { get; }

		[Export ("requestForURL:ETag:httpMethod:")]
		NSMutableUrlRequest RequestForUrl (NSUrl url, [NullAllowed] string etagOrNull, [NullAllowed] string httpMethodOrNull);

		[Export ("objectRequestForURL:object:ETag:httpMethod:isREST:additionalHeaders:ticket:")]
		NSMutableUrlRequest ObjectRequestForUrl (NSUrl url, [NullAllowed] PlusObject obj, [NullAllowed] string etagOrNull, [NullAllowed] string httpMethodOrNull, bool isRest, NSDictionary additionalHeaders, ServiceTicket ticket);

		[Export ("parseQueue")]
		NSOperationQueue ParseQueue { get; set; }

		[Export ("cookieStorageMethod")]
		int CookieStorageMethod { get; set; }

		[Export ("isRESTDataWrapperRequired")]
		bool IsRESTDataWrapperRequired { get; set; }

		[Export ("urlQueryParameters")]
		NSDictionary UrlQueryParameters { get; set; }

		[Export ("additionalHTTPHeaders")]
		NSDictionary AdditionalHTTPHeaders { get; set; }

		[Export ("apiVersion")]
		string ApiVersion { get; set; }

		[Export ("rpcURL")]
		NSUrl RpcUrl { get; set; }

		[Export ("rpcUploadURL")]
		NSUrl RpcUploadUrl { get; set; }

		[Export ("serviceUploadChunkSize")]
		uint ServiceUploadChunkSize { get; set; }

		[Static]
		[Export ("defaultServiceUploadChunkSize")]
		uint DefaultServiceUploadChunkSize { get; }

		[Export ("uploadProgressSelector")]
		Selector UploadProgressSelector { get; set; }

		[Export ("setUploadProgressBlock:")]
		void SetUploadProgressHandler (ServiceUploadProgressHandler handler);

		[Export ("waitForTicket:timeout:fetchedObject:error:")]
		bool WaitForTicket (ServiceTicket ticket, double timeoutInSeconds, [NullAllowed] PlusObject outObjectOrNull, [NullAllowed] NSError outErrorOrNull);
	}

	[BaseType (typeof (NSObject), Name = "GTLServiceTicket")]
	interface ServiceTicket {

		[Static, Export ("ticketForService:")]
		ServiceTicket TicketForService (Service service);

		[Export ("initWithService:")]
		IntPtr Constructor (Service service);

		[Export ("service")]
		Service Service { get; }

		[Export ("cancelTicket")]
		void CancelTicket ();

		[Export ("pauseUpload")]
		void PauseUpload ();

		[Export ("resumeUpload")]
		void ResumeUpload ();

		[Export ("isUploadPaused")]
		bool IsUploadPaused { get; }

		[Export ("objectFetcher")]
		int ObjectFetcher { get; set; }

		[Export ("uploadProgressSelector")]
		Selector UploadProgressSelector { get; set; }

		[Export ("APIKey")]
		string ApikEy { get; set; }

		[Export ("setProperty:forKey:")]
		void SetProperty ([NullAllowed] NSObject obj, string key);

		[Export ("propertyForKey:")]
		NSObject PropertyForKey (string key);

		[Export ("properties")]
		NSDictionary Properties { get; set; }

		[Export ("userData")]
		NSObject UserData { get; set; }

		[Export ("postedObject")]
		int PostedObject { get; set; }

		[Export ("fetchedObject")]
		int FetchedObject { get; set; }

		[Export ("executingQuery")]
		NSObject ExecutingQuery { get; set; }

		[Export ("originalQuery")]
		NSObject OriginalQuery { get; set; }

		[Export ("queryForRequestID:")]
		Query QueryForRequestId (string requestID);

		[Export ("surrogates")]
		NSDictionary Surrogates { get; set; }

		[Export ("retryEnabled")]
		bool RetryEnabled { [Bind ("isRetryEnabled")] get; set; }

		[Export ("retrySelector")]
		Selector RetrySelector { get; set; }

		[Export ("setRetryBlock:")]
		void SetRetryHandler (ServiceRetryHandler handler);

		[Export ("maxRetryInterval")]
		double MaxRetryInterval { get; set; }

		[Export ("statusCode")]
		int StatusCode { get; }

		[Export ("fetchError")]
		NSError FetchError { get; set; }

		[Export ("hasCalledCallback")]
		bool HasCalledCallback { get; set; }

		[Export ("shouldFetchNextPages")]
		bool ShouldFetchNextPages { get; set; }

		[Export ("pagesFetchedCounter")]
		uint PagesFetchedCounter { get; set; }

		[Export ("setUploadProgressBlock:")]
		void SetUploadProgressHandler (ServiceUploadProgressHandler handler);
	}

	[BaseType (typeof (Service), Name = "GTLServicePlus")]
	interface ServicePlus {

	}

	[BaseType (typeof (NSObject), Name = "GTLUploadParameters")]
	interface UploadParameters {

		[Export ("MIMEType")]
		string MIMEType { get; set; }

		[Export ("data")]
		NSData Data { get; set; }

		[Export ("fileHandle")]
		NSFileHandle FileHandle { get; set; }

		[Export ("uploadLocationURL")]
		NSUrl UploadLocationUrl { get; set; }

		[Export ("slug")]
		string Slug { get; set; }

		[Export ("shouldSendUploadOnly")]
		bool ShouldSendUploadOnly { get; set; }

		[Static, Export ("uploadParametersWithData:MIMEType:")]
		UploadParameters UploadParametersWithData (NSData data, string mimeType);

		[Static, Export ("uploadParametersWithFileHandle:MIMEType:")]
		UploadParameters UploadParametersWithFileHandle (NSFileHandle fileHandle, string mimeType);
	}
}

#endregion

#region "PlayGameServices"
namespace Google.Play.GameServices
{
	delegate void AchievementDidUnlockHandler (bool newlyUnlocked, NSError error);
	delegate void AchievementDidIncrementHandler (bool newlyUnlocked, int currentSteps, NSError error);
	delegate void AchievementDidRevealHandler (AchievementState state, NSError error);

	[BaseType (typeof (NSObject), Name = "GPGAchievement")]
	interface Achievement {

		[Export ("initWithAchievementId:")]
		IntPtr Constructor (string achievementId);

		[Static]
		[Export ("achievementWithId:")]
		Achievement FromAchievementId (string achievementId);

		[Export ("achievementId", ArgumentSemantic.Copy)]
		string AchievementId { get; }

		[Export ("showsCompletionNotification", ArgumentSemantic.Assign)]
		bool ShowsCompletionNotification { get; }

		[Export ("unlockAchievementWithCompletionHandler:")]
		void UnlockAchievement (AchievementDidUnlockHandler completionHandler);

		[Export ("revealAchievementWithCompletionHandler:")]
		void RevealAchievement (AchievementDidRevealHandler completionHandler);

		[Export ("incrementAchievementNumSteps:completionHandler:")]
		void IncrementAchievement (int steps, AchievementDidIncrementHandler completionHandler);
	}

	[BaseType (typeof (UINavigationController), Name = "GPGAchievementController",
	           Delegates= new string [] {"AchievementWeakDelegate"},
	Events=new Type [] { typeof (AchievementControllerDelegate) })]
	interface AchievementController {

		[Wrap ("AchievementWeakDelegate")][NullAllowed]
		AchievementControllerDelegate AchievementDelegate { get; set; }

		[Export ("achievementDelegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject AchievementWeakDelegate { get; set; }
	}

	[BaseType (typeof (NSObject), Name = "GPGAchievementControllerDelegate")]
	[Protocol]
	[Model]
	interface AchievementControllerDelegate {
		[Abstract]
		[Export ("achievementViewControllerDidFinish:"), EventArgs ("AchievementController"), EventName ("Finished")]
		void DidFinish (AchievementController viewController);
	}

	[BaseType (typeof (NSObject), Name = "GPGAchievementMetadata")]
	interface AchievementMetadata {

		[Export ("achievementId", ArgumentSemantic.Copy)]
		string AchievementId { get; }

		[Export ("state", ArgumentSemantic.Assign)]
		AchievementState State { get; }

		[Export ("type", ArgumentSemantic.Assign)]
		AchievementType AchType { get; }

		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		[Export ("achievementDescription", ArgumentSemantic.Copy)]
		string AchievementDescription { get; }

		[Export ("revealedIconUrl", ArgumentSemantic.Copy)]
		NSUrl RevealedIconUrl { get; }

		[Export ("unlockedIconUrl", ArgumentSemantic.Copy)]
		NSUrl UnlockedIconUrl { get; }

		[Export ("completedSteps", ArgumentSemantic.Assign)]
		int CompletedSteps { get; }

		[Export ("numberOfSteps", ArgumentSemantic.Assign)]
		int NumberOfSteps { get; }

		[Export ("formattedCompletedSteps", ArgumentSemantic.Copy)]
		string FormattedCompletedSteps { get; }

		[Export ("formattedNumberOfSteps", ArgumentSemantic.Copy)]
		string FormattedNumberOfSteps { get; }

		[Export ("lastUpdatedTimestamp", ArgumentSemantic.Assign)]
		long LastUpdatedTimestamp { get; }

		[Export ("progress", ArgumentSemantic.Assign)]
		float Progress { get; }
	}

	[BaseType (typeof (NSObject), Name = "GPGAchievementModel")]
	interface AchievementModel {

		[Export ("allMetadata")]
		AchievementMetadata [] AllMetadata { get; }

		[Export ("metadataForAchievementId:")]
		AchievementMetadata GetMetadata (string achievementId);
	}

	[BaseType (typeof (KeyedModel), Name = "GPGApplicationModel")]
	interface ApplicationModel {

		[Export ("initWithApplicationId:")]
		IntPtr Constructor (string applicationId);

		[Export ("achievement")]
		AchievementModel Achievement { get; }

		//		TODO: Find GPGGameMetadataModel
		//		[Export ("application")]
		//		GameMetadataModel Application { get; }

		[Export ("leaderboard")]
		LeaderboardModel Leaderboard { get; }

		[Export ("player")]
		PlayerModel Player { get; }

		[Export ("appState")]
		AppStateModel AppState { get; }
	}

	[BaseType (typeof (NSObject), Name = "GPGAppStateListInfo")]
	interface AppStateListInfo {

		[Export ("dataIsStale", ArgumentSemantic.Assign)]
		bool DataIsStale { get; set; }

		[Export ("key", ArgumentSemantic.Copy)]
		NSNumber Key { get; }
	}

	delegate void AppStateListHandler (NSNumber key, NSData state, NSError error);
	delegate void AppStateListKeysHandler (NSObject [] states, NSNumber maxKeyCount, NSError error);
	delegate void AppStateLoadResultHandler (AppStateLoadStatus status, NSError error);
	delegate void AppStateWriteResultHandler (AppStateWriteStatus status, NSError error);
	delegate NSData AppStateConflictHandler (NSNumber key, NSData localState, NSData remoteState);

	[BaseType (typeof (NSObject), Name = "GPGAppStateModel")]
	interface AppStateModel {

		[Export ("setStateData:forKey:")]
		void SetStateData (NSData state, NSNumber key);

		[Export ("stateDataForKey:")]
		NSData StateData (NSNumber key);

		[Export ("listStatesWithCompletionHandler:conflictHandler:")]
		void ListStates (AppStateListHandler completionHandler, AppStateConflictHandler conflictHandler);

		[Export ("listStateKeysWithCompletionHandler:")]
		void ListStateKeys (AppStateListKeysHandler completionHandler);

		[Export ("loadForKey:completionHandler:conflictHandler:")]
		void Load (NSNumber key, AppStateLoadResultHandler completionHandler, AppStateConflictHandler conflictHandler);

		[Export ("updateForKey:completionHandler:conflictHandler:")]
		void Update (NSNumber key, AppStateWriteResultHandler completionHandler, AppStateConflictHandler conflictHandler);

		[Export ("clearForKey:completionHandler:conflictHandler:")]
		void Clear (NSNumber key, AppStateWriteResultHandler completionHandler, AppStateConflictHandler conflictHandler);

		[Export ("deleteForKey:completionHandler:")]
		void Delete (NSNumber key, AppStateWriteResultHandler completionHandler);
	}

	delegate void ModelDidLoadHandler (NSError error);

	[BaseType (typeof (NSObject), Name = "GPGKeyedModel")]
	interface KeyedModel {

		[Export ("loadDataForKey:")]
		void LoadData (string key);

		[Export ("loadDataForKey:completionHandler:")]
		void LoadData (string key, ModelDidLoadHandler completionHandler);

		[Export ("reloadDataForKey:")]
		void ReloadData (string key);

		[Export ("reloadDataForKey:completionHandler:")]
		void ReloadData (string key, ModelDidLoadHandler completionHandler);

		[Export ("isLoadingDataForKey:")]
		bool IsLoadingData (string key);

		[Export ("isDataLoadedForKey:")]
		bool IsDataLoaded (string key);

		[Export ("errorFromLoadingDataForKey:")]
		NSError ErrorFromLoadingData (string key);
	}

	delegate void LeaderboardLoadScoresHandler (Score [] scores, NSError error);
	delegate void LeaderboardResetScoresHandler (NSError error);

	[BaseType (typeof (NSObject), Name = "GPGLeaderboard")]
	interface Leaderboard {

		[Export ("initWithLeaderboardId:")]
		IntPtr Constructor (string leaderboardId);

		[Static]
		[Export ("leaderboardWithId:")]
		Leaderboard FromLeaderboardId (string leaderboardId);

		[Export ("leaderboardId")]
		string LeaderboardId { get; }

		[Export ("personalWindow", ArgumentSemantic.Assign)]
		bool PersonalWindow { [Bind ("isPersonalWindow")] get; set; }

		[Export ("timeScope", ArgumentSemantic.Assign)]
		LeaderboardTimeScope TimeScope { get; set; }

		[Export ("social", ArgumentSemantic.Assign)]
		bool Social { [Bind ("isSocial")] get; set; }

		[Export ("loadScoresWithCompletionHandler:")]
		void LoadScores (LeaderboardLoadScoresHandler completionHandler);

		[Export ("loadNextPageOfScoresWithCompletionHandler:")]
		void LoadNextPageOfScores (LeaderboardLoadScoresHandler completionHandler);

		[Export ("loadPreviousPageOfScoresWithCompletionHandler:")]
		void LoadPreviousPageOfScores (LeaderboardLoadScoresHandler completionHandler);

		[Export ("isLoading")]
		bool IsLoading { get; }

		[Export ("isLoadingPreviousPage")]
		bool IsLoadingPreviousPage { get; }

		[Export ("isLoadingNextPage")]
		bool IsLoadingNextPage { get; }

		[Export ("scores", ArgumentSemantic.Copy)]
		Score [] Scores { get; }

		[Export ("localPlayerScore", ArgumentSemantic.Retain)]
		LocalPlayerScore aLocalPlayerScore { get; }

		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		[Export ("hasPreviousPage", ArgumentSemantic.Assign)]
		bool HasPreviousPage { get; }

		[Export ("hasNextPage", ArgumentSemantic.Assign)]
		bool HasNextPage { get; }
	}

	[BaseType (typeof (UINavigationController), Name = "GPGLeaderboardController",
	           Delegates= new string [] {"LeaderboardWeakDelegate"},
	Events=new Type [] { typeof (LeaderboardControllerDelegate) })]
	interface LeaderboardController {

		[Export ("initWithLeaderboardId:")]
		IntPtr Constructor (string leaderboardId);

		[Export ("timeScope", ArgumentSemantic.Assign)]
		LeaderboardTimeScope TimeScope { get; set; }

		[Wrap ("LeaderboardWeakDelegate")][NullAllowed]
		LeaderboardControllerDelegate LeaderboardDelegate { get; set; }

		[Export ("leaderboardDelegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject LeaderboardWeakDelegate { get; set; }
	}

	[BaseType (typeof (NSObject), Name = "GPGLeaderboardControllerDelegate")]
	[Protocol]
	[Model]
	interface LeaderboardControllerDelegate {
		[Abstract]
		[Export ("leaderboardViewControllerDidFinish:"), EventArgs ("AchievementController"), EventName ("Finished")]
		void DidFinish (LeaderboardController viewController);
	}

	[BaseType (typeof (NSObject), Name = "GPGLeaderboardMetadata")]
	interface LeaderboardMetadata {

		[Export ("iconUrl", ArgumentSemantic.Copy)]
		NSUrl IconUrl { get; }

		[Export ("leaderboardId", ArgumentSemantic.Copy)]
		string LeaderboardId { get; }

		[Export ("order", ArgumentSemantic.Assign)]
		LeaderboardOrder Order { get; }

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; }
	}

	[BaseType (typeof (NSObject), Name = "GPGLeaderboardModel")]
	interface LeaderboardModel {

		[Export ("allMetadata")]
		LeaderboardMetadata [] AllMetadata { get; }

		[Export ("metadataForLeaderboardId")]
		LeaderboardMetadata GetMetadata (string leaderboardId);
	}

	[BaseType (typeof (UINavigationController), Name = "GPGLeaderboardsController",
	           Delegates= new string [] {"LeaderboardsdWeakDelegate"},
	Events=new Type [] { typeof (LeaderboardsControllerDelegate) })]
	interface LeaderboardsController {

		[Wrap ("LeaderboardsdWeakDelegate")][NullAllowed]
		LeaderboardsControllerDelegate LeaderboardsDelegate { get; set; }

		[Export ("leaderboardsDelegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject LeaderboardsdWeakDelegate { get; set; }
	}

	[BaseType (typeof (NSObject), Name = "GPGLeaderboardsControllerDelegate")]
	[Protocol]
	[Model]
	interface LeaderboardsControllerDelegate {
		[Abstract]
		[Export ("leaderboardViewControllerDidFinish:"), EventArgs ("AchievementController"), EventName ("Finished")]
		void DidFinish (LeaderboardsController viewController);
	}

	[BaseType (typeof (NSObject), Name = "GPGLocalPlayerRank")]
	interface LocalPlayerRank {

		[Export ("formattedRank", ArgumentSemantic.Copy)]
		string FormattedRank { get; }

		[Export ("formattedNumScores", ArgumentSemantic.Copy)]
		string FormattedNumScores { get; }

		[Export ("numScores", ArgumentSemantic.Assign)]
		long NumScores { get; }

		[Export ("rank", ArgumentSemantic.Assign)]
		long Rank { get; }
	}

	[BaseType (typeof (NSObject), Name = "GPGLocalPlayerScore")]
	interface LocalPlayerScore {

		[Export ("publicRank", ArgumentSemantic.Retain)]
		LocalPlayerRank PublicRank { get; }

		[Export ("leaderboardId", ArgumentSemantic.Copy)]
		string LeaderboardId { get; }

		[Export ("scoreString", ArgumentSemantic.Copy)]
		string ScoreString { get; }

		[Export ("scoreValue", ArgumentSemantic.Assign)]
		ulong ScoreValue { get; }

		[Export ("socialRank", ArgumentSemantic.Retain)]
		LocalPlayerRank SocialRank { get; }

		[Export ("writeTimestamp", ArgumentSemantic.Assign)]
		long WriteTimestamp { get; }
	}

	delegate void ReAuthenticationHandler (bool requiresKeychainWipe, NSError error);
	delegate void RevisionCheckHandler (RevisionStatus revisionStatus, NSError error);

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GPGManager")]
	interface Manager {

		[Notification]
		[Field ("GPGUserDidSignOutNotification", "__Internal")]
		NSString DidSignOutNotification { get; }

		[Static]
		[Export ("sharedInstance")]
		Manager SharedManager { get; }

		[Export ("applicationModel")]
		ApplicationModel ApplicationModel { get; }

		[Export ("applicationId")]
		string ApplicationId { get; }

		[Export ("hasAuthorizer")]
		bool HasAuthorizer { get; }

		[Export ("signout")]
		void Signout ();

		[Export ("signIn:reauthorizeHandler:")]
		void SignIn (Google.Plus.SignIn signIn, ReAuthenticationHandler reauthenticationHandler);

		[Export ("validOrientationFlags", ArgumentSemantic.Assign)]
		uint ValidOrientationFlags { get; set; }

		[Export ("welcomeBackOffset", ArgumentSemantic.Assign)]
		uint WelcomeBackOffset { get; set; }

		[Export ("welcomeBackToastPlacement", ArgumentSemantic.Assign)]
		ToastPlacement WelcomeBackToastPlacement { get; set; }

		[Export ("achievementUnlockedOffset", ArgumentSemantic.Assign)]
		uint AchievementUnlockedOffset { get; set; }

		[Export ("achievementUnlockedToastPlacement", ArgumentSemantic.Assign)]
		ToastPlacement AchievementUnlockedToastPlacement { get; set; }

		[Export ("refreshRevisionStatus:")]
		void RefreshRevisionStatus (RevisionCheckHandler revisionCheckHandler);

		[Export ("revisionStatus")]
		RevisionStatus RevisionStatus { get; }

		[Export ("isRevisionValid")]
		bool IsRevisionValid { get; }
	}

	[BaseType (typeof (NSObject), Name = "GPGPlayer")]
	interface Player {

		[Export ("avatarUrl", ArgumentSemantic.Copy)]
		NSUrl AvatarUrl { get; }

		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		[Export ("playerId", ArgumentSemantic.Copy)]
		string PlayerId { get; }
	}

	[BaseType (typeof (NSObject), Name = "GPGPlayerModel")]
	interface PlayerModel {
		[Export ("localPlayer")]
		Player LocalPlayer { get; }
	}

	delegate void ScoreReportScoreHandler (ScoreReport report, NSError error);
	delegate void ScoreBatchReportHandler (NSError error);

	[BaseType (typeof (NSObject), Name = "GPGScore")]
	interface Score {

		[Export ("initWithLeaderboardId:")]
		IntPtr Constructor (string leaderboardId);

		[Static]
		[Export ("scoreWithLeaderboardId:")]
		Score FromLeaderboardId (string leaderboardId);

		[Export ("leaderboardId", ArgumentSemantic.Copy)]
		string LeaderboardId { get; }

		[Export ("value", ArgumentSemantic.Assign)]
		ulong Value { get; set; }

		[Export ("submitScoreWithCompletionHandler:")]
		void SubmitScore (ScoreReportScoreHandler completionHandler);

		[Static]
		[Export ("submitScores:withCompletionHandler:withCompletionHandler:")]
		void SubmitScores (Score [] scores, ScoreBatchReportHandler completionHandler);

		[Export ("formattedRank", ArgumentSemantic.Copy)]
		string FormattedRank { get; }

		[Export ("formattedScore", ArgumentSemantic.Copy)]
		string FormattedScore { get; }

		[Export ("rank", ArgumentSemantic.Assign)]
		ulong Rank { get; }

		[Export ("playerId", ArgumentSemantic.Copy)]
		string PlayerId { get; }

		[Export ("displayName", ArgumentSemantic.Copy)]
		string DisplayName { get; }

		[Export ("avatarUrl", ArgumentSemantic.Copy)]
		NSUrl AvatarUrl { get; }

		[Export ("writeTimestamp", ArgumentSemantic.Assign)]
		long WriteTimestamp { get; }
	}

	[BaseType (typeof (NSObject), Name = "GPGScoreReport")]
	interface ScoreReport {

		[Export ("isHighScoreForLocalPlayerToday", ArgumentSemantic.Assign)]
		bool IsHighScoreForLocalPlayerToday { get; }

		[Export ("isHighScoreForLocalPlayerThisWeek", ArgumentSemantic.Assign)]
		bool IsHighScoreForLocalPlayerThisWeek { get; }

		[Export ("isHighScoreForLocalPlayerAllTime", ArgumentSemantic.Assign)]
		bool IsHighScoreForLocalPlayerAllTime { get; }

		[Export ("reportedScoreValue", ArgumentSemantic.Assign)]
		ulong ReportedScoreValue { get; }

		[Export ("highScoreForLocalPlayerToday", ArgumentSemantic.Retain)]
		Score HighScoreForLocalPlayerToday { get; }

		[Export ("highScoreForLocalPlayerThisWeek", ArgumentSemantic.Retain)]
		Score HighScoreForLocalPlayerThisWeek { get; }

		[Export ("highScoreForLocalPlayerAllTime", ArgumentSemantic.Retain)]
		Score HighScoreForLocalPlayerAllTime { get; }
	}
}
#endregion
