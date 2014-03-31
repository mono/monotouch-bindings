using System;

namespace HockeyApp
{
	public enum BITCrashManagerStatus : uint {
		Disabled = 0,
		AlwaysAsk = 1,
		AutoSend = 2
	}

	public enum BITAuthenticatorIdentificationType : uint {
		Anonymous = 0,
		HockeyAppEmail = 1,
		HockeyAppUser = 2,
		TypeDevice = 3,
		TypeWebAuth = 4,
	}

	public enum BITAuthenticatorAppRestrictionEnforcementFrequency : uint {
		OnFirstLaunch = 0,
		OnAppActive = 1
	}

	public enum BITUpdateSetting : uint { 
		CheckStartup = 0,
		CheckDaily = 1,
		CheckManually = 2,
	}

	public enum BITFeedbackUserDataElement : uint {
		DontShow = 0,
		Optional = 1,
		Required = 2,
	}

	public enum BITStoreUpdateSetting : uint { 
		CheckStartup = 0,
		CheckDaily = 1,
		CheckManually = 2,
	}

	public enum BITFeedbackComposeResult {
		Cancelled,
		Submitted,
	};
}
