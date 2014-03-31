using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace HockeyApp
{
	[BaseType (typeof (NSObject))]
	public partial interface BITHockeyBaseManager 
	{
		[Export("serverURL")]
		string ServerUrl { get;set; }
	}

	[BaseType (typeof(NSObject))]
	public partial interface BITHockeyManager
	{
		[Static]
		[Export("sharedHockeyManager")]
		BITHockeyManager SharedHockeyManager { get;set; }

		[Wrap ("WeakDelegate")]
		BITHockeyManagerDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export("configureWithIdentifier:")]
		void Configure(string appIdentifier);

		[Export("configureWithIdentifier:delegate:")]
		void Configure(string appIdentifier, NSObject managerDelegate);

		[Export("configureWithBetaIdentifier:liveIdentifier:delegate:")]
		void ConfigureWithIdentifier(string betaIdentifier, string liveIdentifier, NSObject managerDelegate);

		[Export("startManager")]
		void StartManager();

		[Export ("serverURL", ArgumentSemantic.Retain)]
		string ServerURL { get; set; }

		[Export ("crashManager", ArgumentSemantic.Retain)]
		BITCrashManager CrashManager { get; }

		[Export ("disableCrashManager")]
		bool DisableCrashManager { [Bind ("isCrashManagerDisabled")] get; set; }

		[Export ("updateManager", ArgumentSemantic.Retain)]
		BITUpdateManager UpdateManager { get; }

		[Export ("disableUpdateManager")]
		bool DisableUpdateManager { [Bind ("isUpdateManagerDisabled")] get; set; }

		[Export ("storeUpdateManager", ArgumentSemantic.Retain)]
		BITStoreUpdateManager StoreUpdateManager { get; }

		[Export ("enableStoreUpdateManager")]
		bool EnableStoreUpdateManager { [Bind ("isStoreUpdateManagerEnabled")] get; set; }

		[Export ("feedbackManager", ArgumentSemantic.Retain)]
		BITFeedbackManager FeedbackManager { get; }

		[Export ("disableFeedbackManager")]
		bool DisableFeedbackManager { [Bind ("isFeedbackManagerDisabled")] get; set; }

		[Export ("authenticator", ArgumentSemantic.Retain)]
		BITAuthenticator Authenticator { get; }

		[Export ("appStoreEnvironment")]
		bool AppStoreEnvironment { [Bind ("isAppStoreEnvironment")] get; }

		[Export ("installString")]
		string InstallString { get; }

		[Export ("debugLogEnabled")]
		bool DebugLogEnabled { [Bind ("isDebugLogEnabled")] get; set; }



		[Export("userID", ArgumentSemantic.Retain)]
		string UserId { get;set; }

		[Export("userName", ArgumentSemantic.Retain)]
		string UserName { get;set; }

		[Export("userEmail", ArgumentSemantic.Retain)]
		string UserEmail { get;set; }

		[Export("testIdentifier")]
		void TestIdentifier();

		[Export("version")]
		string Version();

		[Export("build")]
		string Build();
	}

	public delegate void BITAuthenticatorIdentifyCallback (bool identified, NSError error);
	public delegate void BITAuthenticatorValidateCallback (bool validated, NSError error);

	[BaseType(typeof(BITHockeyBaseManager),
		Delegates=new string [] {"WeakDelegate"}, 
		Events=new Type [] { typeof (BITAuthenticatorDelegate) })]
	public partial interface BITAuthenticator 
	{
		[Wrap ("WeakDelegate")]
		BITAuthenticatorDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }


		[Export("identificationType")]
		BITAuthenticatorIdentificationType IdentificationType { get;set; }

		[Export("restrictApplicationUsage")]
		bool RestrictApplicationUsage { get;set; }

		[Export("restrictionEnforcementFrequency")]
		BITAuthenticatorAppRestrictionEnforcementFrequency RestrictionEnforcementFrequency { get; set; }

		[Export("authenticationSecret")]
		string AuthenticationSecret { get;set; }

		[Export("webpageURL")]
		NSUrl WebpageUrl { get;set; }

		[Export("deviceAuthenticationURL")]
		NSUrl DeviceAuthenticationUrl();

		[Export("urlScheme")]
		string UrlScheme { get;set; }

		[Export("handleOpenURL:sourceApplication:annotation:")]
		bool HandleOpenUrl(NSUrl url, string sourceApplication, IntPtr annotation);

		[Export("authenticateInstallation")]
		void AuthenticateInstallation();

		[Export("identifyWithCompletion:")]
		void IdentifyWithCompletion (BITAuthenticatorIdentifyCallback completion);

		[Export ("identified")]
		bool Identified { [Bind ("isIdentified")] get; }

		[Export("validateWithCompletion:")]
		bool ValidateWithCompletion (BITAuthenticatorValidateCallback completion);

		[Export ("validated")]
		bool Validated { [Bind ("isValidated")] get; }

		[Export("cleanupInternalStorage")]
		void CleanupInternalStorage();

		[Export("publicInstallationIdentifier")]
		string PublicInstallationIdentifier();
	}

	[BaseType(typeof(NSObject))]
	public partial interface BITFeedbackManager
	{
		[Wrap ("WeakDelegate")]
		BITFeedbackManagerDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export("requireUserName")]
		BITFeedbackUserDataElement RequireUserName { get;set; }

		[Export("requireUserEmail")]
		BITFeedbackUserDataElement RequireUserEmail { get;set; }

		[Export("showAlertOnIncomingMessages")]
		bool ShowAlertOnIncomingMessages { get;set; }

		[Export("showFirstRequiredPresentationModal")]
		bool ShowFirstRequiredPresentationModel { get;set; }

		[Export("showFeedbackListView")]
		void ShowFeedbackListView();

		[Export("feedbackListViewController:")]
		UITableViewController FeedbackListViewController(bool modal);

		[Export("showFeedbackComposeView")]
		void ShowFeedbackComposeView();

		[Export("feedbackComposeViewController")]
		BITFeedbackComposeViewController FeedbackComposeViewController();
	}

	[BaseType(typeof(NSObject))]
	public partial interface BITUpdateManager
	{
		[Wrap ("WeakDelegate")]
		BITUpdateManagerDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export("updateSetting", ArgumentSemantic.Assign)]
		BITUpdateSetting UpdateSetting { get;set; }

		[Export("checkForUpdateOnLaunch")]
		bool CheckForUpdateOnLaunch { [Bind("isCheckForUpdateOnLaunch")]get;set; }

		[Export("checkForUpdate")]
		void CheckForUpdate();

		[Export("alwaysShowUpdateReminder")]
		bool AlwaysShowUpdateReminder { get;set; }

		[Export("showDirectInstallOption")]
		bool ShowDirectInstallOption { [Bind("isShowingDirectInstallOption")]get; set; }

		[Export("expiryDate")]
		NSDate ExpiryDate { get;set; }

		[Export("disableUpdateCheckOptionWhenExpired")]
		bool DisableUpdateCheckOptionWhenExpired { get;set; }

		[Export("hockeyViewController:")]
		UIViewController HockeyViewController(bool modal);

		[Export("showUpdateView")]
		void ShowUpdateView();
	}

	[BaseType(typeof(NSObject))]
	public partial interface BITCrashManager 
	{
		[Wrap ("WeakDelegate")]
		BITCrashManagerDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export("crashManagerStatus")]
		BITCrashManagerStatus CrashManagerStatus { get;set; }

		[Export("enableMachExceptionHandler")]
		bool EnableMachExceptionHandler { [Bind("isMachExceptionHandlerEnabled")]get; set; } 

		[Export("enableOnDeviceSymbolication")]
		bool EnableOnDeviceSymbolication { [Bind("isOnDeviceSymbolicationEnabled")]get; set; }

		//TODO: Not enabled yet
		//[Export("setCrashCallbacks:")]

		[Export("showAlwaysButton")]
		bool ShowAlwaysButton { [Bind("shouldShowAlwaysButton")]get; set; }

		[Export("didCrashInLastSession")]
		bool DidCrashInLastSession { get; }

		[Export("timeintervalCrashInLastSessionOccured")]
		double TimeIntervalCrashInLastSessionOccured { get; }

		[Export("isDebuggerAttached")]
		bool IsDebuggerAttached();

		[Export("generateTestCrash")]
		void GenerateTestCrash();
	}

	[BaseType(typeof(BITHockeyBaseManager))]
	public partial interface BITStoreUpdateManager
	{
		[Wrap ("WeakDelegate")]
		BITStoreUpdateManagerDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export("updateSetting", ArgumentSemantic.Assign)]
		BITUpdateSetting UpdateSetting { get;set; }

		[Export("countryCode")]
		string CountryCode { get;set; }

		[Export("checkForUpdateOnLaunch")]
		bool CheckForUpdateOnLaunch { [Bind("isCheckingForUpdateOnLaunch")]get;set; }

		[Export("updateUIEnabled")]
		bool UpdateUIEnabled { [Bind("isUpdateUIEnabled")]get;set; }

		[Export("checkForUpdate")]
		void CheckForUpdate();
	}

	[BaseType(typeof(UIViewController))]
	public partial interface BITFeedbackComposeViewController
	{
		[Wrap ("WeakDelegate")]
		BITFeedbackComposeViewControllerDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export("prepareWithItems:")]
		void PrepareWithItems(NSArray items);
	}

	[BaseType(typeof(NSObject))]
    [Model][Protocol]
	public partial interface BITAuthenticatorDelegate
	{
		[Export("authenticator:willShowAuthenticationController:")]
		[EventArgs("WillShowAuthenticationController")]
		void WillShowAuthenticationController(BITAuthenticator authenticator, UIViewController viewController);
	}

	[BaseType(typeof(NSObject))]
	[Model][Protocol]
	public partial interface BITCrashManagerDelegate
	{
		[Export ("applicationLogForCrashManager:")]
		string ApplicationLogForCrashManager (BITCrashManager crashManager);

		[Export ("userNameForCrashManager:")]
		//[Deprecated]
		string UserNameForCrashManager (BITCrashManager crashManager);

		[Export ("userEmailForCrashManager:")]
		//[Deprecated]
		string UserEmailForCrashManager (BITCrashManager crashManager);

		[Export ("crashManagerWillShowSubmitCrashReportAlert:")]
		void WillShowSubmitCrashReportAlert (BITCrashManager crashManager);

		[Export ("crashManagerWillCancelSendingCrashReport:")]
		void WillCancelSendingCrashReport (BITCrashManager crashManager);

		[Export ("crashManagerWillSendCrashReportsAlways:")]
		void WillSendCrashReportsAlways (BITCrashManager crashManager);

		[Export ("crashManagerWillSendCrashReport:")]
		void WillSendCrashReport (BITCrashManager crashManager);

		[Export ("crashManager:didFailWithError:")]
		void DidFailWithError (BITCrashManager crashManager, NSError error);

		[Export ("crashManagerDidFinishSendingCrashReport:")]
		void DidFinishSendingCrashReport (BITCrashManager crashManager);
	}

	[BaseType (typeof (NSObject))]
	[Model][Protocol]
	public partial interface BITUpdateManagerDelegate 
	{
		[Export ("shouldDisplayExpiryAlertForUpdateManager:")]
		bool ShouldDisplayExpiryAlertForUpdateManager (BITUpdateManager updateManager);

		[Export ("didDisplayExpiryAlertForUpdateManager:")]
		void DidDisplayExpiryAlertForUpdateManager (BITUpdateManager updateManager);

		[Export ("updateManagerShouldSendUsageData:")]
		bool UpdateManagerShouldSendUsageData (BITUpdateManager updateManager);

		[Export ("viewController:forUpdateManager:")]
		UIViewController ViewControllerForUpdateManager (BITUpdateManager updateManager);
	}

	[BaseType (typeof (BITFeedbackComposeViewControllerDelegate))]
	[Model][Protocol]
	public partial interface BITFeedbackManagerDelegate //: BITFeedbackComposeViewControllerDelegate 
	{
		[Export ("feedbackManagerDidReceiveNewFeedback:")]
		void DidReceiveNewFeedback (BITFeedbackManager feedbackManager);
	}

	[BaseType(typeof(NSObject))]
	[Model][Protocol]
	public partial interface BITHockeyManagerDelegate
	{
		[Export("shouldUseLiveIdentifierForHockeyManager:")]
		bool ShouldUseLiveIdentifierForHockeyManager(BITHockeyManager manager);

		[Export("viewControllerForHockeyManager:componentManager:")]
		UIViewController ViewControllerForHockeyManager(BITHockeyManager hockeyManager, BITHockeyBaseManager componentManager);

		[Export("userIDForHockeyManager:componentManager:")]
		string UserIdForHockeyManager(BITHockeyManager hockeyManager, BITHockeyBaseManager componentManager);

		[Export("userNameForHockeyManager:componentManager:")]
		string UserNameForHockeyManager(BITHockeyManager hockeyManager, BITHockeyBaseManager componentManager);

		[Export("userEmailForHockeyManager:componentManager:")]
		string UserEmailForHockeyManager(BITHockeyManager hockeyManager, BITHockeyBaseManager componentManager);

	}

	[BaseType(typeof(NSObject))]
	[Model][Protocol]
	public partial interface BITFeedbackComposeViewControllerDelegate
	{
		[Export("feedbackComposeViewController:didFinishWithResult:")]
		void DidFinishWithResult(BITFeedbackComposeViewController viewController, BITFeedbackComposeResult result);

		[Export("feedbackComposeViewControllerDidFinish:")]
		void DidFinish(BITFeedbackComposeViewController viewController);
	}

	[BaseType(typeof(NSObject))]
	[Model][Protocol]
	public partial interface BITStoreUpdateManagerDelegate
	{
		[Export("detectedUpdateFromStoreUpdateManager:newVersion:storeURL:")]
		void DetectedUpdateFromStoreUpdateManager(BITStoreUpdateManager storeUpdateManager, string newVersion, NSUrl storeUrl);
	}
}

