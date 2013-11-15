using System;

namespace InMobiSdk
{
	public enum IMAdSize {
		Banner320x48 = 9,
		Banner300x250 = 10,
		Banner728x90 = 11,
		Banner468x60 = 12,
		Banner120x600 = 13,
		Banner320x50 = 15,
	}

	public enum IMErrorCode {
		InvalidRequest = 0,
		NoFill,
		Internal,
		AdFormatNotSupported,
		Timeout,
		RequestCancelled,
		DoMonetization,
		DoNothing
	}

	public enum IMLogLevel {
		None = 0,
		Debug = 1,
		Verbose = 2
	}

	[Flags]
	public enum IMDeviceIdMask {
		IncludeDefaultIds = 0,
		ExcludeODIN1 = 1 << 0,
		ExcludeAdvertisingId = 1 << 1,
		ExcludeVendorId = 1 << 2,
		ExcludeUDID = 1 << 3,
		ExcludeFacebookAttributionId = 1 << 4
	}

	public enum IMUserId {
		Login,
		Session
	}

	public enum IMGender {
		Male = 1,
		Female,
		Unknown
	}

	public enum IMEthnicity {
		Hispanic = 1,
		Caucasian,
		Asian,
		AfricanAmerican,
		Other,
		Unknown
	}

	public enum IMEducation {
		HighSchoolOrLess = 1,
		CollegeOrGraduate,
		PostGraduateOrAbove,
		Unknown
	}

	public enum IMInterstitialState {
		Unknown = 0,
		Init,
		Loading,
		Ready,
		Active
	}

	public enum IMAdMode {
		Network,
		AppGallery
	}

	public enum IMHasChildren {
		True = 1,
		False,
		Unknown
	}

	public enum IMMaritalStatus {
		Single = 1,
		Divorced,
		Engaged,
		Relationship,
		Unknown
	}

	public enum IMSexualOrientation {
		Straight = 1,
		Bisexual,
		Gay,
		Unknown
	}
}

