using System;

#if __UNIFIED__
using ObjCRuntime;
#endif

namespace AudioKit
{
	#if __UNIFIED__
	[Native]
	public enum AKFFTWindowType : ulong {
	#else
	public enum AKFFTWindowType : uint {
	#endif
		Hamming = 0,
		VonHann = 1
	}

	#if __UNIFIED__
	[Native]
	public enum AKScaledFFTFormantRetainMethod : ulong {
	#else
	public enum AKScaledFFTFormantRetainMethod : uint {
	#endif
		None 		 = 0,
		LifteredCepstrum = 1,
		TrueEnvelope 	 = 2
	}

	#if __UNIFIED__
	[Native]
	public enum AKRandomDistributionType : ulong {
	#else
	public enum AKRandomDistributionType : uint {
	#endif
		Uniform        = 1,
		Linear 	       = 2,
		Triangular     = 3,
		Exponential    = 4,
		Biexponential  = 5,
		Gaussian       = 6,
		Cauchy         = 7,
		PositiveCauchy = 8,
		Poisson        = 11
	}

	#if __UNIFIED__
	[Native]
	public enum AKWindowTableType : ulong {
	#else
	public enum AKWindowTableType : uint {
	#endif
		Hamming 	       = 1,
		Hanning 	       = 2,
		BartlettTriangle       = 3,
		BlackmanThreeTerm      = 4,
		BlackmanHarrisFourTerm = 5,
		Gaussian 	       = 6,
		Kaiser 		       = 7,
		Rectangle 	       = 8,
		Sync 		       = 9
	}

	#if __UNIFIED__
	[Native]
	public enum AKMidiConstant : ulong {
	#else
	public enum AKMidiConstant : uint {
	#endif
		NoteOff 	     = 8,
		NoteOn 		     = 9,
		PolyphonicAftertouch = 10,
		ControllerChange     = 11,
		ProgramChange	     = 12,
		Aftertouch 	     = 13,
		PitchWheel 	     = 14,
		Sysex 		     = 240
	}

	#if __UNIFIED__
	[Native]
	public enum AKFunctionTableType : ulong {
	#else
	public enum AKFunctionTableType : uint {
	#endif
		SoundFile 	       = 1,
		Array 		       = 2,
		AdditiveCosines        = 11,
		WeightedSumOfSinusoids = 19,
		Window 		       = 20,
		RandomDistributions    = 21,
		ExponentialCurves      = 25,
		StraightLines 	       = 27
	}
}

