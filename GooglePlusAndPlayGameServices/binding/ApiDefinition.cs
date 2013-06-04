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
	[Model]
	interface ShareBuilder {

		[Export ("setURLToShare:")]
		ShareBuilder SetURLToShare (NSUrl urlToShare);

		[Export ("setPrefillText:")]
		ShareBuilder SetPrefillText (string prefillText);

		[Export ("setTitle:description:thumbnailURL:")]
		ShareBuilder SetTitle (string title, string description, NSUrl thumbnailUrl);

		[Export ("setContentDeepLinkID:")]
		ShareBuilder SetContentDeepLinkID (string contentDeepLinkID);

		[Export ("setCallToActionButtonWithLabel:URL:deepLinkID:")]
		ShareBuilder SetCallToActionButton (string label, NSUrl url, string deepLinkID);

		[Export ("open")]
		bool Open ();
	}

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

		[Export ("handleURL:sourceApplication:annotation:")]
		bool HandleUrl (NSUrl url, string sourceApplication, NSObject annotation);
	}

	[BaseType (typeof (NSObject), Name = "GPPSignInDelegate")]
	[Protocol]
	[Model]
	interface SignInDelegate {

		[Abstract]
		[Export ("finishedWithAuth:error:")]
		void Finished (Google.OpenSource.OAuth2Authentication auth, NSError error);

		[Export ("didDisconnectWithError:")]
		void DidDisconnect (NSError error);
	}

	[BaseType (typeof (NSObject), Name = "GPPSignIn")]
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
		bool AhouldFetchGoogleUserId { get; set; }

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
		bool HandleUrl (NSUrl url, string sourceApplication, NSObject annotation);
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
