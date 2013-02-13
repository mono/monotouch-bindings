//
// ApiDefinition.cs: API definition for CocosDenshion binding to Mono
//
// Author:
//   Stephane Delcroix <stephane@delcroix.org>
//
// Copyright © 2013 Stephane Delcroix. All Rights Reserved.

using System;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;


namespace MonoTouch.CocosDenshion {
    [BaseType (typeof (NSObject))]
    [DisableDefaultCtor]
    interface CDSoundSource {
	[Export ("pitch")]
	float Pitch { get; set; }

	[Export ("gain")]
	float Gain { get; set; }

	[Export ("pan")]
	float Pan { get; set; }

	[Export ("looping")]
	bool Looping { get; set; }

	[Export ("isPlaying")]
	bool IsPlaying { get; }

	[Export ("soundId")]
	int SoundId { get; set; }

	[Export ("durationInSeconds")]
	float Duration { get; }

	[Export ("lastError")]
	int LastError { get; }
    }
    

    [BaseType (typeof (NSObject))]
    [DisableDefaultCtor]
    interface SimpleAudioEngine {
	[Export ("backgroundMusicVolume")]
	float BackgroundMusicVolume { get; set; }

	[Export ("effectsVolume")]
	float EffectsVolume { get; set; }
	
	[Export ("willPlayBackgroundMusic")]
	bool WillPlayBackgroundMusic { get; }

	[Export ("sharedEngine")]
	[Static]
	SimpleAudioEngine SharedEngine { get; }

	[Export ("playBackgroundMusic:")]
	void PlayBackgroundMusic (string filepath);

	[Export ("playBackgroundMusic:loop:")]
	void PlayBackgroundMusic (string filepath, bool loop);
	
	[Export ("stopBackgroundMusic")]
	void StopBackgroundMusic ();

	[Export ("pauseBackgroundMusic")]
	void PauseBackgroundMusic ();

	[Export ("resumeBackgroundMusic")]
	void ResumeBackgroundMusic ();

	[Export ("rewindBackgroundMusic")]
	void RewindBackgroundMusic ();

	[Export ("isBackgroundMusicPlaying")]
	bool IsBackgroundMusicPlaying { get; }

	[Export ("playEffect:")]
	uint PlayEffect (string filepath);

	[Export ("stopEffect:")]
	void StopEffect (uint soundid);

	[Export ("playEffect:pitch:pan:gain:")]
	uint PlayEffect (string filepath, float pitch, float pan, float gain);

	[Export ("preloadEffect:")]
	void PreloadEffect (string filepath);

	[Export ("unloadEffect:")]
	void UnloadEffect (string filepath);

	[Export ("soundSourceForFile:")]
	CDSoundSource SoundSourceFor (string filepath);
	
	[Export ("end")]
	[Static]
	void End ();
    }
}
