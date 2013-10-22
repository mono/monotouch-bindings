using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MTiRate
{
	[BaseType (typeof (NSObject),
	Delegates=new string [] {"Delegate"},
	Events=new Type [] { typeof (iRateDelegate) })]   
	interface iRate 
	{
 		[Static]
		[Export ("sharedInstance")]
		iRate SharedInstance { get; }
	
		[Export ("appStoreID", ArgumentSemantic.Assign)]
		uint AppStoreID { get; set; }

		[Export ("appStoreGenreID", ArgumentSemantic.Assign)]
		uint AppStoreGenreID { get; set; }		

		[Export ("appStoreCountry", ArgumentSemantic.Copy)]
		string AppStoreCountry { get; set; }

		[Export ("applicationName", ArgumentSemantic.Copy)]
		string ApplicationName { get; set; }

		[Export ("applicationVersion", ArgumentSemantic.Copy)]
		string ApplicationVersion { get; set; }

		[Export ("applicationBundleID", ArgumentSemantic.Copy)]
		string ApplicationBundleID { get; set; }

		[Export ("usesUntilPrompt", ArgumentSemantic.Assign)]
		uint UsesUntilPrompt { get; set; }
		
		[Export ("eventsUntilPrompt", ArgumentSemantic.Assign)]
		uint EventsUntilPrompt { get; set; }
		
		[Export ("daysUntilPrompt", ArgumentSemantic.Assign)]
		float DaysUntilPrompt { get; set; }

		[Export ("usesPerWeekForPrompt", ArgumentSemantic.Assign)]
		float UsesPerWeekForPrompt { get; set; }
		
		[Export ("remindPeriod", ArgumentSemantic.Assign)]
		float RemindPeriod { get; set; }

		[Export ("messageTitle", ArgumentSemantic.Copy)]
		string MessageTitle { get; set; }
		
		[Export ("message", ArgumentSemantic.Copy)]
		string Message { get; set; }
		
		[Export ("cancelButtonLabel", ArgumentSemantic.Copy)]
		string CancelButtonLabel { get; set; }
		
		[Export ("remindButtonLabel", ArgumentSemantic.Copy)]
		string RemindButtonLabel { get; set; }
		
		[Export ("rateButtonLabel", ArgumentSemantic.Copy)]
		string RateButtonLabel { get; set; }

		[Export ("useAllAvailableLanguages", ArgumentSemantic.Assign)]
		bool UseAllAvailableLanguages { get; set; }

		[Export ("promptAgainForEachNewVersion", ArgumentSemantic.Assign)]
		bool PromptAgainForEachNewVersion { get; set; }

		[Export ("onlyPromptIfLatestVersion", ArgumentSemantic.Assign)]
		bool OnlyPromptIfLatestVersion { get; set; }

		[Export ("onlyPromptIfMainWindowIsAvailable", ArgumentSemantic.Assign)]
		bool OnlyPromptIfMainWindowIsAvailable { get; set; }

		[Export ("promptAtLaunch", ArgumentSemantic.Assign)]
		bool PromptAtLaunch { get; set; }
		
		[Export ("verboseLogging", ArgumentSemantic.Assign)]
		bool VerboseLogging { get; set; }

		[Export ("previewMode", ArgumentSemantic.Assign)]
		bool PreviewMode { get; set; }
	
		[Export ("ratingsURL")]
		NSUrl RatingsURL { get; set; }
		
		[Export ("firstUsed")]
		NSDate FirstUsed { get; set; }
		
		[Export ("lastReminded")]
		NSDate LastReminded { get; set; }
		
		[Export ("usesCount", ArgumentSemantic.Assign)]
		uint UsesCount { get; set; }
		
		[Export ("eventCount", ArgumentSemantic.Assign)]
		uint EventCount { get; set; }

		[Export ("usesPerWeek")]
		float UsesPerWeek { get; }
		
		[Export ("declinedThisVersion", ArgumentSemantic.Assign)]
		bool DeclinedThisVersion { get; set; }
	
		[Export ("declinedAnyVersion")]
		bool DeclinedAnyVersion { get; }

		[Export ("ratedThisVersion", ArgumentSemantic.Assign)]
		bool RatedThisVersion { get; set; }

		[Export ("ratedAnyVersion")]
		bool RatedAnyVersion { get; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		IiRateDelegate Delegate { get; set; }

		[Export ("shouldPromptForRating")]
		bool ShouldPromptForRatingM ();

		[Export ("promptForRating")]
		void PromptForRating ();

		[Export ("promptIfNetworkAvailable")]
		void PromptIfNetworkAvailable ();

		[Export ("openRatingsPageInAppStore")]
		bool OpenRatingsPageInAppStore ();

		[Export ("logEvent:")]
		void LogEvent (bool deferPrompt);

	}

	interface IiRateDelegate {}
	
	[BaseType (typeof (NSObject))]
	[Model][Protocol]
	interface iRateDelegate 
	{
		[Export ("iRateCouldNotConnectToAppStore:withError:"), EventArgs("iRateDelegateError")]
		void CouldNotConnectToAppStore (iRate sender, NSError error);

		[Export ("iRateDidDetectAppUpdate:"), EventArgs("iRateDelegateArgs")]
		void DidDetectAppUpdate (iRate sender);

		[Export ("iRateShouldPromptForRating:"), DelegateName("iRateDelegateShouldPromptForRating"), DefaultValue(true)]
		bool ShouldPromptForRating (iRate sender);

		[Export ("iRateDidPromptForRating:"), DelegateName("iRateDelegateShouldPromptForRating"), DefaultValue(true)]
		void DidPromptForRating (iRate sender);

		[Export ("iRateUserDidAttemptToRateApp:"), EventArgs("iRateDelegateArgs")]
		void UserDidAttemptToRateApp (iRate sender);

		[Export ("iRateUserDidDeclineToRateApp:"), EventArgs("iRateDelegateArgs")]
		void UserDidDeclineToRateApp (iRate sender);
		
		[Export ("iRateUserDidRequestReminderToRateApp:"), EventArgs("iRateDelegateArgs")]
		void UserDidRequestReminderToRateApp(iRate sender);

		[Export ("iRateShouldOpenAppStore:"), DelegateName("iRateDelegateShouldOpenAppStore"), DefaultValue(true)]
		bool ShouldOpenAppStore (iRate sender);

		[Export ("iRateDidPresentStoreKitModal:"), EventArgs("iRateDelegateArgs")]
		void DidPresentStoreKitModal(iRate sender);

		[Export ("iRateDidDismissStoreKitModal:"), EventArgs("iRateDelegateArgs")]
		void DidDismissStoreKitModal(iRate sender);
	}
}

