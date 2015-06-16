using System;
using ObjCRuntime;

namespace Facebook.CoreKit
{
	[Native]
	public enum AppEventsFlushBehavior : ulong
	{
		Auto = 0,
		ExplicitOnly
	}

	[Native]
	public enum ErrorCode : long
	{
		Reserved = 0,
		Encryption,
		InvalidArgument,
		Unknown,
		Network,
		AppEventsFlush,
		GraphRequestNonTextMimeTypeReturned,
		GraphRequestProtocolMismatch,
		GraphRequestGraphAPI,
		DialogUnavailable
	}

	[Native]
	public enum GraphRequestErrorCategory : ulong
	{
		Other = 0,
		Transient = 1,
		Recoverable = 2
	}

	[Native]
	public enum ProfilePictureMode : ulong
	{
		Square,
		Normal
	}
}

namespace Facebook.LoginKit
{
	[Native]
	public enum LoginButtonTooltipBehavior : ulong
	{
		Automatic = 0,
		ForceDisplay = 1,
		Disable = 2
	}

	[Native]
	public enum LoginErrorCode : long
	{
		Reserved = 300,
		Unknown,
		PasswordChanged,
		UserCheckpointed,
		UserMismatch,
		UnconfirmedUser,
		SystemAccountAppDisabled,
		SystemAccountUnavailable,
		BadChallengeString
	}

	[Native]
	public enum DefaultAudience : ulong
	{
		Friends = 0,
		OnlyMe,
		Everyone
	}

	[Native]
	public enum LoginBehavior : ulong
	{
		Native = 0,
		Browser,
		SystemAccount,
		Web
	}

	[Native]
	public enum TooltipViewArrowDirection : ulong
	{
		Down = 0,
		Up = 1
	}

	[Native]
	public enum TooltipColorStyle : ulong
	{
		FriendlyBlue = 0,
		NeutralGray = 1
	}
}

namespace Facebook.MessengerShareKit
{
	[Native]
	public enum MessengerShareButtonStyle : ulong
	{
		Blue = 0,
		White = 1,
		WhiteBordered = 2
	}

	[Flags]
	[Native]
	public enum MessengerPlatformCapability : ulong
	{
		None = 0,
		Open = 1 << 0,
		Image = 1 << 1,
		AnimatedGIF = 1 << 2,
		AnimatedWebP = 1 << 3,
		Video = 1 << 4,
		Audio = 1 << 5
	}
}

namespace Facebook.ShareKit
{
	[Native]
	public enum AppGroupPrivacy : ulong
	{
		Open = 0,
		Closed
	}

	[Native]
	public enum GameRequestActionType : ulong
	{
		None = 0,
		Send,
		AskFor,
		Turn
	}

	[Native]
	public enum GameRequestFilter : ulong
	{
		None = 0,
		AppUsers,
		AppNonUsers
	}

	[Native]
	public enum LikeControlAuxiliaryPosition : ulong
	{
		Inline,
		Top,
		Bottom
	}

	[Native]
	public enum LikeControlHorizontalAlignment : ulong
	{
		Left,
		Center,
		Right
	}

	[Native]
	public enum LikeControlStyle : ulong
	{
		Standard = 0,
		BoxCount
	}

	[Native]
	public enum LikeObjectType : ulong
	{
		Unknown = 0,
		OpenGraph,
		Page
	}

	[Native]
	public enum ShareErrorCode : long
	{
		Reserved = 200,
		OpenGraph,
		DialogNotAvailable
	}

	[Native]
	public enum ShareDialogMode : ulong
	{
		Automatic = 0,
		Native,
		ShareSheet,
		Browser,
		Web,
		FeedBrowser,
		FeedWeb
	}
}