using System;

namespace Google.Plus
{
	public enum SignInButtonStyle
	{
		Standard = 0,
		Wide = 1,
		IconOnly = 2
	}

	public enum SignInButtonColorScheme
	{
		Dark = 0,
		Light = 1
	}

}

namespace Google.Play.GameServices
{
	public enum AchievementType
	{
		Unknown = -1,
		Standard,
		Incremental
	}

	public enum AchievementState
	{
		Unknown = -1,
		Hidden,
		Revealed,
		Unlocked
	}

	public enum LeaderboardTimeScope
	{
		Unknown = -1,
		Today = 1,
		ThisWeek = 2,
		AllTime = 3
	}

	public enum LeaderboardOrder
	{
		Unknown = -1,
		LargerIsBetter,
		SmallerIsBetter,
	}

	public enum AppStateLoadStatus
	{
		UnknownError = -1,
		Success,
		NotFound
	}

	public enum AppStateWriteStatus
	{
		UnknownError = -1,
		Success,
		BadKeyDataOrVersion,
		KeysQuotaExceeded,
		NotFound,
		Conflict,
		SizeExceeded
	}

	public enum ToastPlacement
	{
		Top,
		Bottom,
		Center
	}

	public enum RevisionStatus
	{
		Unknown = -1,
		OK,
		Deprecated,
		Invalid
	}
}