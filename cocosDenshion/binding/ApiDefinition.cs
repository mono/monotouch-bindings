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
using MonoTouch.AVFoundation;

namespace MonoTouch.CocosDenshion {
    [BaseType (typeof (NSObject))]
    interface CDLongAudioSource {
	[Export ("audioSourcePlayer")]
	AVAudioPlayer AudioSourcePlayer { get; }

	[Export ("audioSourceFilePath")]
	string AudioSourceFilePath { get; }

	[Export ("numberOfLoops")]
	int NumberOfLoops { get; set; }

	[Export ("volume")]
	float Volume { get; set; }

	[Export ("backgroundMusic")]
	bool BackgroundMusic { get; set; }

	[Export ("load:")]
	void Load (string filepath);

	[Export ("play")]
	void Play ();

	[Export ("stop")]
	void Stop ();

	[Export ("pause")]
	void Pause ();

	[Export ("rewind")]
	void Rewind ();

	[Export ("resume")]
	void Resume ();

	[Export ("isPlaying")]
	bool IsPlaying { get; }
    }
    
    [BaseType (typeof (NSObject))]
    [DisableDefaultCtor]
    interface CDAudioManager {
	[Export ("soundEngine")]
	CDSoundEngine SoundEngine { get; }

	[Export ("backgroundMusic")]
	CDLongAudioSource BackgroundMusic { get; }

	[Export ("willPlayBackgroundMusic")]
	bool WillPlayBackgroundMusic { get; }

	[Export ("sharedManager")]
	[Static]
	CDAudioManager SharedManager { get; }
	
	[Export ("sharedManagerState")]
	[Static]
	AudioManagerState SharedManagerState { get; }	
	
	[Export ("configure:")]
	[Static]
	void Configure (AudioManagerMode mode);

	[Export ("initAsynchronously:")]
	[Static]
	void InitAsync (AudioManagerMode mode);

	[Export ("init:")]
	IntPtr Constructor (AudioManagerMode mode);

	[Export ("audioSessionInterrupted")]
	void AudioSessionInterrupted ();

	[Export ("audioSessionResumed")]
	void AudioSessionResumed ();

	[Export ("setResignBehavior:autoHandle:")]
	void SetResignBehavior (AudioManagerResignBehavior resignBehavior, bool autoHandle);

	[Export ("isDeviceMuted")]
	bool IsDeviceMuted { get; }

	[Export ("isOtherAudioPlaying")]
	bool IsOtherAudioPlaying { get; }

	[Export ("setMode:")]
	AudioManagerMode Mode { set; }

	[Export ("end")]
	[Static]
	void End ();

	[Export ("applicationWillResignActive")]
	void ApplicationWillResignActive ();

	[Export ("applicationDidBecomeActive")]
	void ApplicationDidBecomeActive ();

	[Export ("audioSourceLoad:channel:")]
	CDLongAudioSource Load (string filepath, AudioSourceChannel channel);

	[Export ("audioSourceForChannel:")]
	CDLongAudioSource SourceFor (AudioSourceChannel channel);

	[Export ("playBackgroundMusic:loop:")]
	void PlayBackgroundMusic (string filepath, bool loop);
	
	[Export ("preloadBackgroundMusic:")]
	void PreloadBackgroundMusic (string filepath);

	[Export ("stopBackgroundMusic")]
	void StopBackgroundMusic ();

	[Export ("pauseBackgroundMusic")]
	void PauseBackgroundMusic ();

	[Export ("rewindBackgroundMusic")]
	void RewindBackgroundMusic ();
	
	[Export ("resumeBackgroundMusic")]
	void ResumeBackgroundMusic ();

	[Export ("isBackgroundMusicPlaying")]
	bool IsBackgroundMusicPlaying { get; }

	[Export ("setBackgroundMusicCompletionListener:selector:")]	
	[Internal]
	void SetBackgroundMusicCompletionListener (NSObject target, Selector sel);
    }
    
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
    interface CDSoundEngine {
	[Export ("masterGain")]
	float MasterGain { get; set; }

	[Export ("lastErrorCode")]
	int LastErrorCode { get; }

	[Export ("functioning")]
	bool IsFunctioning { get; }

	[Export ("asynchLoadProgress")]
	float AsyncLoadProgress { get; set; }

	[Export ("getGainworks")]
	bool GainWorks { get; }

	[Export ("sourceTotal")]
	int SourceTotal { get; }

	[Export ("sourceGroupTotal")]
	uint SourceGroupTotal { get; }

	[Export ("mixerSampleRate")]
	[Static]
	float SampleRate { set; }

	[Export ("playSound:sourceGroupId:pitch:pan:gain:loop:")]
	uint PlaySound (int soundId, int sourceGroupId, float pitch, float pan, float gain, bool loop);

	[Export ("soundSourceForSound:sourceGroupId:")]
	CDSoundSource SoundSourceFor (int soundId, int sourceGroupId);

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

	[Export ("mute")]
	bool Mute { get; set; }

	[Export ("enabled")]
	bool Enabled { get; set; }
    }
}
