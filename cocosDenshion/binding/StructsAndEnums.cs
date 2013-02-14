//
// StructsAndEnums.cs
//
// Author:
//   Stephane Delcroix <stephane@delcroix.org>
//
// Copyright © 2013 Stephane Delcroix. All Rights Reserved.

namespace MonoTouch.CocosDenshion {
    public enum AudioManagerMode {
	FxOnly,
	FxPlusMusic,
	FxPlusMusicIfNoOtherAudio,
	MediaPlayback,
	PlayAndRecord,
    }

    public enum AudioManagerState {
	Uninitialised,
	Initialising,
	Initialised,
    }

    public enum AudioManagerResignBehavior {
	DoNothing,
	StopPlay,
	Stop,
    }

    public enum AudioSourceChannel {
	Left = 0,
	Right = 1,
    }

    public enum LongAudioSourceState {
	Init,
	Loaded,
	Playing,
	Paused,
	Stopped,
    }
}

