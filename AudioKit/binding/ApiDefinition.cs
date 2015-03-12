using System;
using System.Drawing;

#if __UNIFIED__
using ObjCRuntime;
using Foundation;
using UIKit;
#else
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using CGRect = global::System.Drawing.RectangleF;
using CGSize = global::System.Drawing.SizeF;
using CGPoint = global::System.Drawing.PointF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

namespace AudioKit
{
	#region Core Classes

	delegate void AKEventDelegate ();

	[BaseType (typeof (NSObject))]
	interface AKEvent {

		[Export ("initWithBlock:")]
		IntPtr Constructor ([NullAllowed] AKEventDelegate handler);

		[Export ("runBlock")]
		void RunBlock ();

		[Export ("trigger")]
		void Trigger ();
	}

	[BaseType (typeof (NSObject))]
	interface AKInstrument {

		[Export ("instrumentNumber")]
		int InstrumentNumber { get; }

		[Export ("uniqueName")]
		string UniqueName { get; }

		[Static]
		[Export ("resetID")]
		void ResetID ();

		[Export ("properties")]
		AKInstrumentProperty [] Properties { get; set; }

		[Export ("noteProperties")]
		AKNoteProperty [] NoteProperties { get; set; }

		[Export ("addProperty:")]
		void AddProperty (AKInstrumentProperty property);

		[Export ("addProperty:withName:")]
		void AddProperty (AKInstrumentProperty property, string name);

		// -(void)addNoteProperty:(AKNoteProperty *)newNoteProperty;
		[Export ("addNoteProperty:")]
		void AddNoteProperty (AKNoteProperty property);

		[Export ("functionTables")]
		NSMutableSet FunctionTables { get; set; }

		[Export ("addFunctionTable:")]
		void AddFunctionTable (AKFunctionTable functionTable);

		[Export ("addDynamicFunctionTable:")]
		void AddDynamicFunctionTable (AKFunctionTable functionTable);

		[Export ("userDefinedOperations")]
		NSMutableSet UserDefinedOperations { get; set; }

		[Export ("globalParameters")]
		NSMutableSet GlobalParameters { get; set; }

		[Export ("connect:")]
		void Connect (AKParameter newOperation);

		[Export ("addString:")]
		void AddString (string aString);

		[Export ("assignOutput:to:")]
		void AssignOutput (AKParameter output, AKParameter input);

		[Export ("resetParameter:")]
		void ResetParameter (AKParameter parameter);

		[Export ("enableParameterLog:parameter:timeInterval:")]
		void EnableParameterLog (string message, AKParameter parameter, float timeInterval);

		[Export ("joinOrchestra:")]
		void JoinOrchestra (AKOrchestra orchestra);

		[Export ("stringForCSD")]
		string CSD { get; }

		[Export ("stopStringForCSD")]
		string StopCSD { get; }

		[Export ("playForDuration:")]
		void PlayForDuration (float duration);

		[Export ("play")]
		void Play ();

		[Export ("playNote:")]
		void PlayNote (AKNote note);

		[Export ("playNote:afterDelay:")]
		void PlayNote (AKNote note, float delay);

		[Export ("stopNote:")]
		void StopNote (AKNote note);

		[Export ("stopNote:afterDelay:")]
		void StopNote (AKNote note, float delay);

		[Export ("playPhrase:")]
		void PlayPhrase (AKPhrase phrase);

		[Export ("repeatPhrase:")]
		void RepeatPhrase (AKPhrase phrase);

		[Export ("repeatPhrase:duration:")]
		void RepeatPhrase (AKPhrase phrase, float duration);

		[Export ("stop")]
		void Stop ();
	}

	[BaseType (typeof (NSObject))]
	interface AKManager {

		[Export ("isRunning")]
		bool IsRunning { get; }

		[Export ("isLogging")]
		bool IsLogging { get; set; }

		[Export ("orchestra")]
		AKOrchestra Orchestra { get; set; }

		[Export ("midi")]
		AKMidi Midi { get; }

		[Static]
		[Export ("sharedManager")]
		AKManager GetSharedManager { get; }

		[Export ("runOrchestra")]
		void RunOrchestra ();

		[Export ("runOrchestraForDuration:")]
		void RunOrchestraForDuration (int duration);

		[Export ("resetOrchestra")]
		void ResetOrchestra ();

		[Export ("stop")]
		void Stop ();

		[Export ("triggerEvent:")]
		void TriggerEvent (AKEvent aEvent);

		[Export ("startBatch")]
		void StartBatch ();

		[Export ("endBatch")]
		void EndBatch ();

		[Export ("stopInstrument:")]
		void StopInstrument (AKInstrument instrument);

		[Export ("stopNote:")]
		void StopNote (AKNote note);

		[Export ("updateNote:")]
		void UpdateNote (AKNote note);

		[Static]
		[Export ("stringFromFile:")]
		string StringFromFile (string filename);

		[Export ("enableAudioInput")]
		void EnableAudioInput ();

		[Export ("disableAudioInput")]
		void DisableAudioInput ();

		[Export ("stopRecording")]
		void StopRecording ();

		[Export ("startRecordingToURL:")]
		void StartRecordingToURL (NSUrl url);

		[Export ("enableMidi")]
		void EnableMidi ();

		[Export ("disableMidi")]
		void DisableMidi ();

		[Export ("standardSineWave")]
		AKWeightedSumOfSinusoids StandardSineWave { get; set; }

		[Static]
		[Export ("standardSineWave")]
		AKWeightedSumOfSinusoids GetStandardSineWave { get; }

		[Export ("numberOfSineWaveReferences")]
		int NumberOfSineWaveReferences { get; set; }

		[Export ("standardTriangleWave")]
		AKLineSegments StandardTriangleWave { get; set; }

		[Static]
		[Export ("standardTriangleWave")]
		AKLineSegments GetStandardTriangleWave { get; }

		[Export ("numberOfTriangleWaveReferences")]
		int NumberOfTriangleWaveReferences { get; set; }

		[Export ("standardSquareWave")]
		AKLineSegments StandardSquareWave { get; set; }

		[Static]
		[Export ("standardSquareWave")]
		AKLineSegments GetStandardSquareWave { get; }

		[Export ("numberOfSquareWaveReferences")]
		int NumberOfSquareWaveReferences { get; set; }

		[Export ("standardSawtoothWave")]
		AKLineSegments StandardSawtoothWave { get; set; }

		[Static]
		[Export ("standardSawtoothWave")]
		AKLineSegments GetStandardSawtoothWave { get; }

		[Export ("numberOfSawtoothWaveReferences")]
		int NumberOfSawtoothWaveReferences { get; set; }

		[Export ("standardReverseSawtoothWave")]
		AKLineSegments StandardReverseSawtoothWave { get; set; }

		[Static]
		[Export ("standardReverseSawtoothWave")]
		AKLineSegments GetStandardReverseSawtoothWave { get; }

		[Export ("numberOfReverseSawtoothWaveReferences")]
		int NumberOfReverseSawtoothWaveReferences { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface AKMidi {

		[Export ("listeners")]
		NSMutableSet Listeners { get; set; }

		[Export ("addListener:")]
		void AddListener ([NullAllowed] IAKMidiListener listener);

		[Export ("openMidiIn")]
		void OpenMidiIn ();

		[Export ("closeMidiIn")]
		void CloseMidiIn ();
	}

	interface IAKMidiListener { }

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject))]
	interface AKMidiListener {

		[Export ("midiNoteOn:velocity:channel:")]
		void MidiNoteOn (int note, int velocity, int channel);

		[Export ("midiNoteOff:velocity:channel:")]
		void MidiNoteOff (int note, int velocity, int channel);

		[Export ("midiAftertouchOnNote:pressure:channel:")]
		void MidiAftertouchOnNote (int note, int pressure, int channel);

		[Export ("midiController:changedToValue:channel:")]
		void MidiController (int controller, int value, int channel);

		[Export ("midiAftertouch:channel:")]
		void MidiAftertouch (int pressure, int channel);

		[Export ("midiPitchWheel:channel:")]
		void MidiPitchWheel (int pitchWheelValue, int channel);

		[Export ("midiModulation:channel:")]
		void MidiModulation (int modulation, int channel);

		[Export ("midiPortamento:channel:")]
		void MidiPortamento (int portamento, int channel);

		[Export ("midiVolume:channel:")]
		void MidiVolume (int volume, int channel);

		[Export ("midiBalance:channel:")]
		void MidiBalance (int balance, int channel);

		[Export ("midiPan:channel:")]
		void MidiPan (int pan, int channel);

		[Export ("midiExpression:channel:")]
		void MidiExpression (int expression, int channel);
	}

	// @interface AKNote : NSObject
	[BaseType (typeof (NSObject))]
	interface AKNote {

		[Static]
		[Export ("resetID")]
		void ResetID ();

		[Export ("initWithInstrument:forDuration:")]
		IntPtr Constructor (AKInstrument instrument, float duration);

		[Export ("initWithInstrument:")]
		IntPtr Constructor (AKInstrument instrument);

		[Export ("instrument")]
		AKInstrument Instrument { get; set; }

		[Export ("duration")]
		AKNoteProperty Duration { get; set; }

		[Export ("properties")]
		NSMutableDictionary Properties { get; set; }

		[Export ("addProperty:withName:")]
		void AddProperty (AKNoteProperty property, string name);

		[Export ("addProperty:")]
		void AddProperty (AKNoteProperty property);

		[Export ("updateProperties")]
		void UpdateProperties ();

		[Export ("updatePropertiesAfterDelay:")]
		void UpdatePropertiesAfterDelay (float time);

		[Export ("play")]
		void Play ();

		[Export ("playAfterDelay:")]
		void PlayAfterDelay (float delay);

		[Export ("stop")]
		void Stop ();

		[Export ("stopAfterDelay:")]
		void StopAfterDelay (float delay);

		[Export ("stringForCSD")]
		string CSD { get; }

		[Export ("stopStringForCSD")]
		string StopCSD { get; }
	}

	[BaseType (typeof (NSObject))]
	interface AKOrchestra {

		[Export ("zeroDBFullScaleValue", ArgumentSemantic.Assign)]
		float ZeroDBFullScaleValue { get; set; }

		[Export ("numberOfChannels")]
		int NumberOfChannels { get; }

		[Export ("instruments")]
		NSMutableArray Instruments { get; set; }

		[Export ("functionTables")]
		NSMutableSet FunctionTables { get; set; }

		[Static]
		[Export ("start")]
		void Start ();

		[Static]
		[Export ("reset")]
		void Reset ();

		[Static]
		[Export ("testForDuration:")]
		void TestForDuration (float duration);

		// TODO: 
		[Static]
		[Export ("addInstrument:")]
		void AddInstrumentToOrchestra (AKInstrument instrument);

		[Export ("addInstrument:")]
		void AddInstrument (AKInstrument instrument);

		[Export ("stringForCSD")]
		string CSD { get; }
	}

	[BaseType (typeof (NSObject))]
	interface AKPhrase {

		[Export ("count")]
		int Count { get; }

		[Export ("duration")]
		float Duration { get; }

		[Export ("reset")]
		void Reset ();

		[Export ("addNote:")]
		void AddNote (AKNote note);

		[Export ("addNote:atTime:")]
		void AddNote (AKNote note, float atTime);

		[Export ("startNote:atTime:")]
		void StartNote (AKNote note, float atTime);

		[Export ("stopNote:atTime:")]
		void StopNote (AKNote note, float atTime);

		[Export ("updateNoteProperty:withValue:atTime:")]
		void UpdateNoteProperty (AKNoteProperty noteProperty, float value, float atTime);

		[Export ("playUsingInstrument:")]
		void PlayUsingInstrument (AKInstrument instrument);
	}

	[BaseType (typeof (NSObject))]
	interface AKSampler {

		[Export ("trackNames")]
		string [] TrackNames { get; }

		[Export ("startRecordingToTrack:")]
		void StartRecording (string trackName);

		[Export ("stopRecordingToTrack:")]
		void StopRecording (string trackName);

		[Export ("startPlayingTrack:")]
		void StartPlaying (string trackName);

		[Export ("stopPlayingTrack:")]
		void StopPlaying (string trackName);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	interface AKSequence {

		// TODO: Check NSMutableArray
		[Export ("events")]
		NSMutableArray Events { get; set; }

		[Export ("times")]
		NSMutableArray Times { get; set; }

		[Static]
		[Export ("sequence")]
		AKSequence GetSequence { get; }

		[Export ("play")]
		void Play ();

		[Export ("pause")]
		void Pause ();

		[Export ("stop")]
		void Stop ();

		[Export ("addEvent:")]
		void AddEvent (AKEvent aEvent);

		[Export ("addEvent:atTime:")]
		void AddEventAtTime (AKEvent aEvent, float timeSinceStart);

		[Export ("addEvent:afterDuration:")]
		void AddEventAfterDuration (AKEvent aEvent, float duration);
	}

	#endregion


	#region Libraries/iOS

	[BaseType (typeof (NSObject))]
	interface AKTools {

		[Static]
		[Export ("randomFloatFrom:to:")]
		float RandomFloat (float minimum, float maximum);

		[Static]
		[Export ("scaleValue:fromMinimum:fromMaximum:toMinimum:toMaximum:")]
		float ScaleValue (float value, float fromMinimum, float fromMaximum, float toMinimum, float toMaximum);

		[Static]
		[Export ("scaleLogValue:fromMinimum:fromMaximum:toMinimum:toMaximum:")]
		float ScaleLogValue (float logValue, float fromMinimum, float fromMaximum, float toMinimum, float toMaximum);

		[Internal]
		[Static]
		[Export ("scaleProperty:withScalingFactor:")]
		void _ScaleProperty (NSObject property, float scalingFactor);

		[Internal]
		[Static]
		[Export ("scaleProperty:withInverseScalingFactor:")]
		void _InverseScaleProperty (NSObject property, float scalingFactor);

		[Static]
		[Export ("setSlider:withValue:minimum:maximum:")]
		void SetSlider (UISlider slider, float value, float minimum, float maximum);

		[Static]
		[Export ("scaleValueFromSlider:minimum:maximum:")]
		float ScaleValue (UISlider slider, float minimum, float maximum);

		[Static]
		[Export ("scaleLogValueFromSlider:minimum:maximum:")]
		float ScaleLogValue (UISlider slider, float minimum, float maximum);

		[Internal]
		[Static]
		[Export ("setSlider:withProperty:")]
		void _SetSlider (UISlider slider, NSObject property);

		[Internal]
		[Static]
		[Export ("setProgressView:withProperty:")]
		void _SetProgressView (UIProgressView progressView, NSObject property);

		[Internal]
		[Static]
		[Export ("setProperty:withSlider:")]
		void _SetProperty (NSObject property, UISlider slider);

		[Internal]
		[Static]
		[Export ("setTextField:withProperty:")]
		void _SetTextField (UITextField textfield, NSObject property);

		[Internal]
		[Static]
		[Export ("setLabel:withProperty:")]
		void _SetLabel (UILabel label, NSObject property);

		[Static]
		[Export ("midiNoteToFrequency:")]
		float MidiNoteToFrequency (int note);

		[Static]
		[Export ("scaleControllerValue:fromMinimum:toMaximum:")]
		float ScaleControllerValue (float value, float minimum, float maximum);
	}

	#endregion


	#region Operations

	[Category]
	[BaseType (typeof (AKParameter))]
	interface AKParameterOperationExtension {

		[Export ("operationName")]
		string OperationName ();

		[Export ("stringForCSD")]
		string CSD ();

		[Export ("udoString")]
		string UdoString ();
	}


	#region Operations/Analysis

	[DisableDefaultCtor]
	[BaseType (typeof (AKControl))]
	interface AKTrackedAmplitude {

		[Export ("initWithAudioSource:halfPowerPoint:")]
		IntPtr Constructor (AKParameter audioSource, AKConstant halfPowerPoint);

		[Export ("initWithAudioSource:")]
		IntPtr Constructor (AKParameter audioSource);

		[Static]
		[Export ("amplitudeWithAudioSource:")]
		AKTrackedAmplitude FromAudioSource (AKParameter audioSource);

		[Export ("halfPowerPoint")]
		AKConstant HalfPowerPoint { get; set; }

		[Export ("setOptionalHalfPowerPoint:")]
		void SetOptionalHalfPowerPoint (AKConstant halfPowerPoint);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKControl))]
	interface AKTrackedAmplitudeFromFSignal {

		[Export ("initWithFSignalSource:amplitudeThreshold:")]
		IntPtr Constructor (AKFSignal fSignalSource, AKControl amplitudeThreshold);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKControl))]
	interface AKTrackedFrequency {

		[Export ("initWithAudioSource:sampleSize:")]
		IntPtr Constructor (AKAudio audioSource, AKConstant hopSize);

		[Export ("setOptionalSpectralPeaks:")]
		void SetOptionalSpectralPeaks (AKConstant numberOfSpectralPeaks);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKControl))]
	interface AKTrackedFrequencyFromFSignal {

		[Export ("initWithFSignalSource:amplitudeThreshold:")]
		IntPtr Constructor (AKFSignal fSignalSource, AKControl amplitudeThreshold);
	}

	#endregion


	#region Operations/FFT

	[DisableDefaultCtor]
	[BaseType (typeof (AKFSignal))]
	interface AKCrossSynthesizedFFT {

		[Export ("initWithSignal1:signal2:amplitude1:amplitude2:")]
		IntPtr Constructor (AKFSignal signal1, AKFSignal signal2, AKControl amplitude1, AKControl amplitude2);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKFSignal))]
	interface AKFFT {

		[Export ("initWithInput:fftSize:overlap:windowType:windowFilterSize:")]
		IntPtr Constructor (AKParameter audioSource, AKConstant fftSize, AKConstant overlap, AKFFTWindowType windowType, AKConstant windowSize);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKFSignal))]
	interface AKFFTProcessor {

		[Export ("initWithFunctionTable:frequencyRatio:timeRatio:amplitude:functionTableOffset:sizeOfFFT:hopSize:dbthresh:")]
		IntPtr Constructor (AKParameter functionTable, AKParameter frequencyRatio, AKParameter timeRatio, AKParameter amplitude, AKConstant functionTableOffset, AKConstant sizeOfFFT, AKConstant hopSize, AKConstant dbthresh);

		[Export ("initWithFunctionTable:")]
		IntPtr Constructor (AKParameter functionTable);

		[Static]
		[Export ("WithFunctionTable:")]
		AKFFTProcessor FromFunctionTable (AKParameter functionTable);

		[Export ("frequencyRatio")]
		AKParameter FrequencyRatio { get; [Bind ("setOptionalFrequencyRatio:")] set; }

		[Export ("timeRatio")]
		AKParameter TimeRatio { get; [Bind ("setOptionalTimeRatio:")] set; }

		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }

		[Export ("functionTableOffset")]
		AKConstant FunctionTableOffset { get; [Bind ("setOptionalFunctionTableOffset")] set; }

		[Export ("sizeOfFFT")]
		AKConstant SizeOfFFT { get; [Bind ("setOptionalSizeOfFFT:")] set; }

		[Export ("hopSize")]
		AKConstant HopSize { get; [Bind ("setOptionalHopSize:")] set; }

		[Export ("dbthresh")]
		AKConstant Dbthresh { get; [Bind ("setOptionalDbthresh:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKFSignal))]
	interface AKMixedFFT {

		[Export ("initWithSignal1:signal2:")]
		IntPtr Constructor (AKFSignal signal1, AKFSignal signal2);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKPhaseLockedVocoder {

		[Export ("initWithFunctionTable:time:scaledPitch:amplitude:")]
		IntPtr Constructor (AKControl functionTable, AKAudio time, AKControl scaledPitch, AKControl amplitude);

		[Export ("setOptionalSizeOfFFT:")]
		void SetOptionalSizeOfFFT (AKConstant sizeOfFFT);

		[Export ("setOptionalDecimation:")]
		void SetOptionalDecimation (AKConstant decimation);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKResynthesizedAudio {

		[Export ("initWithSignal:")]
		IntPtr Constructor (AKFSignal source);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKFSignal))]
	interface AKScaledFFT {

		[Export ("initWithSignal:frequencyRatio:")]
		IntPtr Constructor (AKFSignal input, AKControl frequencyRatio);

		[Export ("initWithSignal:frequencyRatio:formantRetainMethod:amplitudeRatio:cepstrumCoefficients:")]
		IntPtr Constructor (AKFSignal input, AKControl frequencyRatio, AKScaledFFTFormantRetainMethod formantRetainMethod, AKControl amplitudeRatio, AKControl numberOfCepstrumCoefficients);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKFSignal))]
	interface AKSpectralVocoder {

		[Export ("initWithAmplitude:excitationFrequencies:depth:gain:")]
		IntPtr Constructor (AKFSignal amplitude, AKFSignal excitationFrequencies, AKControl depth, AKControl gain);

		[Export ("setOptionalCoefficents:")]
		void SetOptionalCoefficents (AKControl coefs);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKFSignal))]
	interface AKWarpedFFT {

		[Export ("initWithInput:scalingRatio:shift:")]
		IntPtr Constructor (AKFSignal sourceSignal, AKControl scalingRatio, AKControl shift);

		[Export ("setOptionalLowFrequency:")]
		void SetOptionalLowFrequency (AKControl lowFrequency);

		[Export ("setOptionalExtractionMethod:")]
		void SetOptionalExtractionMethod (AKControl extractionMethod);

		[Export ("setOptionalGain:")]
		void SetOptionalGain (AKControl gain);

		[Export ("setOptionalNumberOfCoefficients:")]
		void SetOptionalNumberOfCoefficients (AKControl numberOfCoefficients);
	}

	#endregion


	#region Operations/Function Tables

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKTableValue {

		[Export ("initWithFunctionTable:atIndex:")]
		IntPtr Constructor (AKConstant functionTable, AKAudio index);

		[Export ("normalize")]
		void Normalize ();

		[Export ("wrap")]
		void Wrap ();

		[Export ("offsetBy:")]
		void OffsetBy (AKConstant offsetAmount);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKConstant))]
	interface AKTableValueConstant {

		[Export ("initWithFunctionTable:atIndex:")]
		IntPtr Constructor (AKConstant functionTable, AKConstant index);

		[Export ("normalize")]
		void Normalize ();

		[Export ("wrap")]
		void Wrap ();

		[Export ("offsetBy:")]
		void OffsetBy (AKConstant offsetAmount);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKControl))]
	interface AKTableValueControl {

		[Export ("initWithFunctionTable:atIndex:")]
		IntPtr Constructor (AKConstant functionTable, AKControl index);

		[Export ("normalize")]
		void Normalize ();

		[Export ("wrap")]
		void Wrap ();

		[Export ("offsetBy:")]
		void OffsetBy (AKConstant offsetAmount);
	}


	#region Operations/Function Tables/Generators

	[BaseType (typeof (AKFunctionTable))]
	interface AKAdditiveCosineTable {

		[Export ("initWithSize:numberOfHarmonics:lowestHarmonic:partialMultiplier:")]
		IntPtr Constructor (int size, int numberOfHarmonics, int lowestHarmonic, float partialMultiplier);

		[Export ("setOptionalSize:")]
		void SetOptionalSize (int size);

		// @property int numberOfHarmonics;
		[Export ("numberOfHarmonics")]
		int NumberOfHarmonics { get; [Bind ("setOptionalNumberOfHarmonics:")] set; }

		// @property int lowestHarmonic;
		[Export ("lowestHarmonic")]
		int LowestHarmonic { get; [Bind ("setOptionalLowestHarmonic:")] set; }

		// @property float partialMultiplier;
		[Export ("partialMultiplier")]
		float PartialMultiplier { get; [Bind ("setOptionalPartialMultiplier:")] set; }
	}

	[BaseType (typeof (AKFunctionTable))]
	interface AKArrayTable {

		[Export ("initWithArray:")]
		IntPtr Constructor (AKArray parameterArray);

		[Export ("initWithArray:size:")]
		IntPtr Constructor (AKArray parameterArray, int tableSize);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKFunctionTable))]
	interface AKExponentialCurves {

		[New]
		[Export ("size")]
		int Size { get; set; }

		[Export ("initWithValue:")]
		IntPtr Constructor (float value);

		[Export ("addValue:atIndex:")]
		void AddValue (float value, int index);

		[Export ("appendValue:afterNumberOfElements:")]
		void AppendValue (float value, int after);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKConstant))]
	interface AKFunctionTable {

		[Export ("isNormalized", ArgumentSemantic.Assign)]
		bool IsNormalized { get; set; }

		[Export ("parameters")]
		AKArray Parameters { get; set; }

		[Export ("size")]
		int Size { get; set; }

		[Export ("functionName")]
		string FunctionName { get; }

		[Export ("initWithType:size:parameters:")]
		IntPtr Constructor (AKFunctionTableType functionTableType, int tableSize, AKArray parameters);

		[Export ("initWithType:parameters:")]
		IntPtr Constructor (AKFunctionTableType functionTableType, AKArray parameters);

		[Export ("initWithType:")]
		IntPtr Constructor (AKFunctionTableType functionTableType);

		[Export ("stringForCSD")]
		string CSD ();

		[Export ("length")]
		AKConstant Length { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKFunctionTable))]
	interface AKLineSegments {

		[New]
		[Export ("size")]
		int Size { get; set; }

		[Static]
		[Export ("squareWave")]
		AKLineSegments SquareWave { get; }

		[Static]
		[Export ("triangleWave")]
		AKLineSegments TriangleWave { get; }

		[Static]
		[Export ("sawtoothWave")]
		AKLineSegments SawtoothWave { get; }

		[Static]
		[Export ("reverseSawtoothWave")]
		AKLineSegments ReverseSawtoothWave { get; }

		[Export ("initWithValue:")]
		IntPtr Constructor (float value);

		[Export ("addValue:atIndex:")]
		void AddValue (float value, int index);

		[Export ("appendValue:afterNumberOfElements:")]
		void AppendValue (float value, int after);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKFunctionTable))]
	interface AKRandomDistributionTable {

		[Export ("initType:size:")]
		IntPtr Constructor (AKRandomDistributionType distributionType, int size);

		[Export ("initType:size:level:")]
		IntPtr Constructor (AKRandomDistributionType distributionType, int size, float level);

		[Export ("initWeibullTypeWithSize:level:sigma:")]
		IntPtr Constructor (int size, float level, float sigma);

		[Export ("initBetaTypeWithSize:level:alpha:beta:")]
		IntPtr Constructor (int size, float level, float alpha, float beta);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKFunctionTable))]
	interface AKSoundFile {

		[Internal]
		[Export ("initWithFilename:")]
		IntPtr Constructor (string filename);

		[Internal]
		[Export ("initAsMonoFromLeftChannelOfStereoFile:")]
		IntPtr MonoLeftChannelConstructor (string filename);

		[Internal]
		[Export ("initAsMonoFromRightChannelOfStereoFile:")]
		IntPtr MonoRightChannelConstructor (string filename);

		[Export ("channels")]
		AKConstant Channels { get; }
	}

	[BaseType (typeof (AKFunctionTable))]
	interface AKWeightedSumOfSinusoids {

		[Static]
		[Export ("pureSineWave")]
		AKWeightedSumOfSinusoids PureSineWave { get; }

		[Export ("addSinusoidWithPartialNumber:strength:")]
		void AddSinusoid (float partialNumber, float partialStrength);

		[Export ("addSinusoidWithPartialNumber:strength:phase:dcOffset:")]
		void AddSinusoid (int partialNumber, float strength, float phase, float dcOffset);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKFunctionTable))]
	interface AKWindow {

		[Export ("initWithType:")]
		IntPtr Constructor (AKWindowTableType windowType);

		[New]
		[Export ("maximum")]
		float Maximum { get; [Bind ("setOptionalMaximum:")] set; }

		// @property (nonatomic) float kaiserOpenness;
		[Export ("kaiserOpenness")]
		float KaiserOpenness { get; [Bind ("setOptionalKaiserWindowOpenness:")] set; }

		// @property (nonatomic) float standardDeviation;
		[Export ("standardDeviation")]
		float StandardDeviation { get; [Bind ("setOptionalGaussianWindowStandardDeviation:")] set; }
	}

	#endregion


	#region Operations/Function Tables/Loopers

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKFunctionTableLooper {

		[Static]
		[Export ("loopRepeats")]
		AKConstant LoopRepeats { get; }

		[Static]
		[Export ("loopPlaysBackwards")]
		AKConstant LoopPlaysBackwards { get; }

		[Static]
		[Export ("loopPlaysForwardAndThenBackwards")]
		AKConstant LoopPlaysForwardAndThenBackwards { get; }

		[Export ("initWithFunctionTable:startTime:endTime:transpositionRatio:amplitude:crossfadeDuration:loopMode:")]
		IntPtr Constructor (AKFunctionTable functionTable, AKParameter startTime, AKParameter endTime, AKParameter transpositionRatio, AKParameter amplitude, AKParameter crossfadeDuration, AKConstant loopMode);

		[Export ("initWithFunctionTable:")]
		IntPtr Constructor (AKFunctionTable functionTable);

		[Static]
		[Export ("looperWithFunctionTable:")]
		AKFunctionTableLooper FromFunctionTable (AKFunctionTable functionTable);

		[Export ("startTime")]
		AKParameter StartTime { get; [Bind ("setOptionalStartTime:")] set; }

		[Export ("endTime")]
		AKParameter EndTime { get; [Bind ("setOptionalEndTime:")] set; }

		[Export ("transpositionRatio")]
		AKParameter TranspositionRatio { get; [Bind ("setOptionalTranspositionRatio:")] set; }

		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }

		[Export ("crossfadeDuration")]
		AKParameter CrossfadeDuration { get; [Bind ("setOptionalCrossfadeDuration:")] set; }

		[Export ("loopMode")]
		AKConstant LoopMode { get; [Bind ("setOptionalLoopMode:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKMonoSoundFileLooper {

		[Static]
		[Export ("loopPlaysOnce")]
		AKConstant LoopPlaysOnce { get; }

		[Static]
		[Export ("loopRepeats")]
		AKConstant LoopRepeats { get; }

		[Static]
		[Export ("loopPlaysForwardAndThenBackwards")]
		AKConstant LoopPlaysForwardAndThenBackwards { get; }

		[Export ("initWithSoundFile:frequencyRatio:amplitude:loopMode:")]
		IntPtr Constructor (AKFunctionTable soundFile, AKParameter frequencyRatio, AKParameter amplitude, AKConstant loopMode);

		[Export ("initWithSoundFile:")]
		IntPtr Constructor (AKFunctionTable soundFile);

		[Static]
		[Export ("looperWithSoundFile:")]
		AKMonoSoundFileLooper FromSoundFile (AKFunctionTable soundFile);

		[Export ("frequencyRatio")]
		AKParameter FrequencyRatio { get; [Bind ("setOptionalFrequencyRatio:")] set; }

		// @property AKParameter * amplitude;
		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }

		// @property AKConstant * loopMode;
		[Export ("loopMode")]
		AKConstant LoopMode { get; [Bind ("setOptionalLoopMode:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKStereoAudio))]
	interface AKStereoSoundFileLooper {

		[Static]
		[Export ("loopPlaysOnce")]
		AKConstant LoopPlaysOnce { get; }

		[Static]
		[Export ("loopRepeats")]
		AKConstant LoopRepeats { get; }

		[Static]
		[Export ("loopPlaysForwardAndThenBackwards")]
		AKConstant LoopPlaysForwardAndThenBackwards { get; }

		[Export ("initWithSoundFile:frequencyRatio:amplitude:loopMode:")]
		IntPtr Constructor (AKFunctionTable soundFile, AKParameter frequencyRatio, AKParameter amplitude, AKConstant loopMode);

		[Export ("initWithSoundFile:")]
		IntPtr Constructor (AKFunctionTable soundFile);

		[Static]
		[Export ("looperWithSoundFile:")]
		AKStereoSoundFileLooper FromSoundFile (AKFunctionTable soundFile);

		[Export ("frequencyRatio")]
		AKParameter FrequencyRatio { get; [Bind ("setOptionalFrequencyRatio:")] set; }

		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }

		[Export ("loopMode")]
		AKConstant LoopMode { get; [Bind ("setOptionalLoopMode:")] set; }
	}

	#endregion


	#endregion


	#region Operations/Mathematical Operations

	[DisableDefaultCtor]
	[BaseType (typeof (AKParameter))]
	interface AKAssignment {

		[Export ("initWithOutput:input:")]
		IntPtr Constructor (AKParameter output, AKParameter input);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);
	}

	[BaseType (typeof (AKMultipleInputMathOperation))]
	interface AKMaximum {

		[Internal]
		[Export ("initWithInputs:", IsVariadic = true)]
		IntPtr Constructor (AKParameter firstInput, IntPtr nextInputs);

		[Internal]
		[Export ("initWithFirstInput:secondInput:")]
		IntPtr Constructor (AKParameter firstInput, AKParameter secondInput);
	}

	[BaseType (typeof (AKMultipleInputMathOperation))]
	interface AKMinimum {

		[Internal]
		[Export ("initWithInputs:", IsVariadic = true)]
		IntPtr Constructor (AKParameter firstInput, IntPtr nextInputs);

		[Internal]
		[Export ("initWithFirstInput:secondInput:")]
		IntPtr Constructor (AKParameter firstInput, AKParameter secondInput);
	}

	[BaseType (typeof (AKParameter))]
	interface AKMultipleInputMathOperation {

		[Export ("inputs")]
		AKParameter [] Inputs { get; set; }

		[Internal]
		[Export ("initWithInputs:", IsVariadic = true)]
		IntPtr Constructor (AKParameter firstInput, IntPtr nextInputs);

		[Internal]
		[Export ("initWithFirstInput:secondInput:")]
		IntPtr Constructor (AKParameter firstInput, AKParameter secondInput);
	}

	[BaseType (typeof (AKMultipleInputMathOperation))]
	interface AKProduct {

		[Internal]
		[Export ("initWithInputs:", IsVariadic = true)]
		IntPtr Constructor (AKParameter firstInput, IntPtr nextInputs);

		[Internal]
		[Export ("initWithFirstInput:secondInput:")]
		IntPtr Constructor (AKParameter firstInput, AKParameter secondInput);
	}

	[BaseType (typeof (AKControl))]
	interface AKScaledControl {

		[Export ("initWithControl:minimumOutput:maximumOutput:")]
		IntPtr Constructor (AKControl inputControl, AKControl minimumOutput, AKControl maximumOutput);
	}

	[BaseType (typeof (AKMultipleInputMathOperation))]
	interface AKSum {

		[Internal]
		[Export ("initWithInputs:", IsVariadic = true)]
		IntPtr Constructor (AKParameter firstInput, IntPtr nextInputs);

		[Internal]
		[Export ("initWithFirstInput:secondInput:")]
		IntPtr Constructor (AKParameter firstInput, AKParameter secondInput);
	}

	#endregion


	#region Operations/Signal Generators


	#region Operations/Signal Generators/Envelopes

	[BaseType (typeof (AKControl))]
	interface AKAdsrEnvelope {

		[Export ("initWithAttackDuration:decayDuration:sustainLevel:releaseDuration:delay:")]
		IntPtr Constructor (AKConstant attackDuration, AKConstant decayDuration, AKConstant sustainLevel, AKConstant releaseDuration, AKConstant delay);

		[Static]
		[Export ("envelope")]
		AKAdsrEnvelope GetInstance { get; }

		[Export ("attackDuration")]
		AKConstant AttackDuration { get; [Bind ("setOptionalAttackDuration:")] set; }

		[Export ("decayDuration")]
		AKConstant DecayDuration { get; [Bind ("setOptionalDecayDuration:")] set; }

		[Export ("sustainLevel")]
		AKConstant SustainLevel { get; [Bind ("setOptionalSustainLevel:")] set; }

		[Export ("releaseDuration")]
		AKConstant ReleaseDuration { get; [Bind ("setOptionalReleaseDuration:")] set; }

		[Export ("delay")]
		AKConstant Delay { get; [Bind ("setOptionalDelay:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKLine {

		[Export ("initWithFirstPoint:secondPoint:durationBetweenPoints:")]
		IntPtr Constructor (AKConstant firstPoint, AKConstant secondPoint, AKConstant durationBetweenPoints);

		[Static]
		[Export ("line")]
		AKLine GetInstance { get; }

		[Export ("firstPoint")]
		AKConstant FirstPoint { get; [Bind ("setOptionalFirstPoint:")] set; }

		[Export ("secondPoint")]
		AKConstant SecondPoint { get; [Bind ("setOptionalSecondPoint:")] set; }

		[Export ("durationBetweenPoints")]
		AKConstant DurationBetweenPoints { get; [Bind ("setOptionalDurationBetweenPoints:")] set; }
	}

	[BaseType (typeof (AKControl))]
	interface AKLinearAdsrEnvelope {

		[Export ("initWithAttackDuration:decayDuration:sustainLevel:releaseDuration:delay:")]
		IntPtr Constructor (AKConstant attackDuration, AKConstant decayDuration, AKConstant sustainLevel, AKConstant releaseDuration, AKConstant delay);

		[Static]
		[Export ("envelope")]
		AKLinearAdsrEnvelope GetInstance { get; }

		[Export ("attackDuration")]
		AKConstant AttackDuration { get; [Bind ("setOptionalAttackDuration:")] set; }

		[Export ("decayDuration")]
		AKConstant DecayDuration { get; [Bind ("setOptionalDecayDuration:")] set; }

		[Export ("sustainLevel")]
		AKConstant SustainLevel { get; [Bind ("setOptionalSustainLevel:")] set; }

		[Export ("releaseDuration")]
		AKConstant ReleaseDuration { get; [Bind ("setOptionalReleaseDuration:")] set; }

		[Export ("delay")]
		AKConstant Delay { get; [Bind ("setOptionalDelay:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKLinearEnvelope {

		[Export ("initWithRiseTime:decayTime:totalDuration:amplitude:")]
		IntPtr Constructor (AKConstant riseTime, AKConstant decayTime, AKConstant totalDuration, AKParameter amplitude);

		[Static]
		[Export ("envelope")]
		AKLinearEnvelope GetInstance { get; }

		// @property AKConstant * riseTime;
		[Export ("riseTime")]
		AKConstant RiseTime { get; [Bind ("setOptionalRiseTime:")] set; }

		// @property AKConstant * decayTime;
		[Export ("decayTime")]
		AKConstant DecayTime { get; [Bind ("setOptionalDecayTime:")] set; }

		// @property AKConstant * totalDuration;
		[Export ("totalDuration")]
		AKConstant TotalDuration { get; [Bind ("setOptionalTotalDuration:")] set; }

		// @property AKParameter * amplitude;
		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }

		[Export ("decayOnlyOnRelease:")]
		void DecayOnlyOnRelease (bool decayOnRelease);
	}

	#endregion


	#region Operations/Signal Generators/Granular Synthesis

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKGranularSynthesisTexture {

		[Export ("initWithGrainFunctionTable:windowFunctionTable:maximumGrainDuration:averageGrainDuration:maximumFrequencyDeviation:grainFrequency:maximumAmplitudeDeviation:grainAmplitude:grainDensity:useRandomGrainOffset:")]
		IntPtr Constructor (AKConstant grainFunctionTable, AKConstant windowFunctionTable, AKConstant maximumGrainDuration, AKParameter averageGrainDuration, AKParameter maximumFrequencyDeviation, AKParameter grainFrequency, AKParameter maximumAmplitudeDeviation, AKParameter grainAmplitude, AKParameter grainDensity, bool useRandomGrainOffset);

		[Export ("initWithGrainFunctionTable:windowFunctionTable:")]
		IntPtr Constructor (AKConstant grainFunctionTable, AKConstant windowFunctionTable);

		[Static]
		[Export ("textureWithGrainFunctionTable:windowFunctionTable:")]
		AKGranularSynthesisTexture FromGrainFunctionTable (AKConstant grainFunctionTable, AKConstant windowFunctionTable);

		[Export ("maximumGrainDuration")]
		AKConstant MaximumGrainDuration { get; [Bind ("setOptionalMaximumGrainDuration:")] set; }

		[Export ("averageGrainDuration")]
		AKParameter AverageGrainDuration { get; [Bind ("setOptionalAverageGrainDuration:")] set; }

		[Export ("maximumFrequencyDeviation")]
		AKParameter MaximumFrequencyDeviation { get; [Bind ("SetOptionalMaximumFrequencyDeviation:")] set; }

		[Export ("grainFrequency")]
		AKParameter GrainFrequency { get; [Bind ("setOptionalGrainFrequency:")] set; }

		[Export ("maximumAmplitudeDeviation")]
		AKParameter MaximumAmplitudeDeviation { get; [Bind ("setOptionalMaximumAmplitudeDeviation:")] set; }

		[Export ("grainAmplitude")]
		AKParameter GrainAmplitude { get; [Bind ("setOptionalGrainAmplitude:")]set; }

		[Export ("grainDensity")]
		AKParameter GrainDensity { get; [Bind ("setOptionalGrainDensity:")] set; }

		[Export ("useRandomGrainOffset")]
		bool UseRandomGrainOffset { get; [Bind ("setOptionalUseRandomGrainOffset:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKGranularSynthesizer {

		[Export ("initWithGrainWaveform:frequency:windowWaveform:duration:density:maximumOverlappingGrains:frequencyVariation:frequencyVariationDistribution:phase:startPhaseVariation:prpow:")]
		IntPtr Constructor (AKParameter grainWaveform, AKParameter frequency, AKWindow windowWaveform, AKParameter duration, AKParameter density, AKConstant maximumOverlappingGrains, AKParameter frequencyVariation, AKParameter frequencyVariationDistribution, AKParameter phase, AKParameter startPhaseVariation, AKParameter prpow);

		[Export ("initWithGrainWaveform:frequency:")]
		IntPtr Constructor (AKParameter grainWaveform, AKParameter frequency);

		[Static]
		[Export ("WithGrainWaveform:frequency:")]
		AKGranularSynthesizer FromGrainWaveform (AKParameter grainWaveform, AKParameter frequency);

		[Export ("windowWaveform")]
		AKWindow WindowWaveform { get; [Bind ("setOptionalWindowWaveform:")] set; }

		[Export ("duration")]
		AKParameter Duration { get; [Bind ("setOptionalDuration:")] set; }

		[Export ("density")]
		AKParameter Density { get; [Bind ("setOptionalDensity:")] set; }

		[Export ("maximumOverlappingGrains")]
		AKConstant MaximumOverlappingGrains { get; [Bind ("setOptionalMaximumOverlappingGrains:")] set; }

		[Export ("frequencyVariation")]
		AKParameter FrequencyVariation { get; [Bind ("setOptionalFrequencyVariation:")] set; }

		[Export ("frequencyVariationDistribution")]
		AKParameter FrequencyVariationDistribution { get; [Bind ("setOptionalFrequencyVariationDistribution:")] set; }

		[Export ("phase")]
		AKParameter Phase { get; [Bind ("setOptionalPhase:")] set; }

		[Export ("startPhaseVariation")]
		AKParameter StartPhaseVariation { get; [Bind ("setOptionalStartPhaseVariation:")] set; }

		[Export ("prpow")]
		AKParameter Prpow { get; [Bind ("setOptionalPrpow:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKSinusoidBursts {

		[Export ("initWithSineTable:riseShapeTable:overlaps:totalTime:octavationIndex:formantBandwidth:burstRiseTime:burstDuration:burstDecayTime:peakAmplitude:fundamentalFrequency:formantFrequency:")]
		IntPtr Constructor (AKWeightedSumOfSinusoids sineburstSynthesisTable, AKFunctionTable riseShapeTable, AKConstant numberOfOverlaps, AKConstant totalTime, AKControl octavationIndex, AKControl formantBandwidth, AKControl burstRiseTime, AKControl burstDuration, AKControl burstDecayTime, AKParameter peakAmplitude, AKParameter fundamentalFrequency, AKParameter formantFrequency);
	}

	#endregion


	#region Operations/Signal Generators/Musical Controls

	[DisableDefaultCtor]
	[BaseType (typeof (AKControl))]
	interface AKPortamento {

		[Export ("initWithInput:halfTime:")]
		IntPtr Constructor (AKParameter input, AKParameter halfTime);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("portamentoWithInput:")]
		AKPortamento FromInput (AKParameter input);

		[Export ("halfTime")]
		AKParameter HalfTime { get; [Bind ("setOptionalHalfTime:")] set; }
	}

	[BaseType (typeof (AKControl))]
	interface AKVibrato {

		[Export ("initWithVibratoShapeTable:averageFrequency:frequencyRandomness:minimumFrequencyRandomness:maximumFrequencyRandomness:averageAmplitude:amplitudeDeviation:minimumAmplitudeRandomness:maximumAmplitudeRandomness:phase:")]
		IntPtr Constructor (AKFunctionTable vibratoShapeTable, AKParameter averageFrequency, AKParameter frequencyRandomness, AKParameter minimumFrequencyRandomness, AKParameter maximumFrequencyRandomness, AKParameter averageAmplitude, AKParameter amplitudeDeviation, AKParameter minimumAmplitudeRandomness, AKParameter maximumAmplitudeRandomness, AKConstant phase);

		[Static]
		[Export ("vibrato")]
		AKVibrato GetInstance { get; }

		[Export ("vibratoShapeTable")]
		AKFunctionTable VibratoShapeTable { get; [Bind ("setOptionalVibratoShapeTable:")] set; }

		[Export ("averageFrequency")]
		AKParameter AverageFrequency { get; [Bind ("setOptionalAverageFrequency:")] set; }

		[Export ("frequencyRandomness")]
		AKParameter FrequencyRandomness { get; [Bind ("setOptionalFrequencyRandomness:")] set; }

		[Export ("minimumFrequencyRandomness")]
		AKParameter MinimumFrequencyRandomness { get; [Bind ("SetOptionalMinimumFrequencyRandomness:")] set; }

		[Export ("maximumFrequencyRandomness")]
		AKParameter MaximumFrequencyRandomness { get; [Bind ("setOptionalMaximumFrequencyRandomness:")] set; }

		[Export ("averageAmplitude")]
		AKParameter AverageAmplitude { get; [Bind ("setOptionalAverageAmplitude:")] set; }

		[Export ("amplitudeDeviation")]
		AKParameter AmplitudeDeviation { get; [Bind ("setOptionalAmplitudeDeviation:")] set; }

		[Export ("minimumAmplitudeRandomness")]
		AKParameter MinimumAmplitudeRandomness { get; [Bind ("setOptionalMinimumAmplitudeRandomness:")] set; }

		[Export ("maximumAmplitudeRandomness")]
		AKParameter MaximumAmplitudeRandomness { get; [Bind ("setOptionalMaximumAmplitudeRandomness:")] set; }

		[Export ("phase")]
		AKConstant Phase { get; [Bind ("setOptionalPhase:")] set; }
	}

	#endregion


	#region Operations/Signal Generators/Oscillators

	[BaseType (typeof (AKAudio))]
	interface AKFMOscillator {

		[Export ("initWithFunctionTable:baseFrequency:carrierMultiplier:modulatingMultiplier:modulationIndex:amplitude:")]
		IntPtr Constructor (AKFunctionTable functionTable, AKParameter baseFrequency, AKParameter carrierMultiplier, AKParameter modulatingMultiplier, AKParameter modulationIndex, AKParameter amplitude);

		[Static]
		[Export ("oscillator")]
		AKFMOscillator GetInstance { get; }

		[Export ("functionTable")]
		AKFunctionTable FunctionTable { get; [Bind ("setOptionalFunctionTable:")] set; }

		[Export ("baseFrequency")]
		AKParameter BaseFrequency { get; [Bind ("setOptionalBaseFrequency:")] set; }

		[Export ("carrierMultiplier")]
		AKParameter CarrierMultiplier { get; [Bind ("setOptionalCarrierMultiplier:")] set; }

		[Export ("modulatingMultiplier")]
		AKParameter ModulatingMultiplier { get; [Bind ("setOptionalModulatingMultiplier:")] set; }

		[Export ("modulationIndex")]
		AKParameter ModulationIndex { get; [Bind ("setOptionalModulationIndex:")] set; }

		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKLowFrequencyOscillator {

		[Static]
		[Export ("waveformTypeForSine")]
		AKConstant SineWaveform { get; }

		[Static]
		[Export ("waveformTypeForTriangle")]
		AKConstant TriangleWaveform { get; }

		[Static]
		[Export ("waveformTypeForBipolarSquare")]
		AKConstant BipolarSquareWaveform { get; }

		[Static]
		[Export ("waveformTypeForUnipolarSquare")]
		AKConstant UnipolarSquareWaveform { get; }

		[Static]
		[Export ("waveformTypeForSawtooth")]
		AKConstant SawtoothWaveform { get; }

		[Static]
		[Export ("waveformTypeForDownSawtooth")]
		AKConstant DownSawtoothWaveform { get; }

		[Export ("initWithWaveformType:frequency:amplitude:")]
		IntPtr Constructor (AKConstant waveformType, AKParameter frequency, AKParameter amplitude);

		[Static]
		[Export ("oscillator")]
		AKLowFrequencyOscillator GetInstance { get; }

		[Export ("waveformType")]
		AKConstant WaveformType { get; [Bind ("setOptionalWaveformType:")] set; }

		[Export ("frequency")]
		AKParameter Frequency { get; [Bind ("setOptionalFrequency:")] set; }

		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKOscillator {

		[Export ("initWithFunctionTable:frequency:amplitude:")]
		IntPtr Constructor (AKFunctionTable functionTable, AKParameter frequency, AKParameter amplitude);

		[Static]
		[Export ("oscillator")]
		AKOscillator GetInstance { get; }

		[Export ("functionTable")]
		AKFunctionTable FunctionTable { get; [Bind ("setOptionalFunctionTable:")] set; }

		// @property AKParameter * frequency;
		[Export ("frequency")]
		AKParameter Frequency { get; [Bind ("setOptionalFrequency:")] set; }

		// @property AKParameter * amplitude;
		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKPhasor {

		[Export ("initWithFrequency:phase:")]
		IntPtr Constructor (AKParameter frequency, AKConstant phase);

		[Static]
		[Export ("phasor")]
		AKPhasor Phasor ();

		[Export ("frequency")]
		AKParameter Frequency { get; [Bind ("setOptionalFrequency:")] set; }

		[Export ("phase")]
		AKConstant Phase { get; [Bind ("setOptionalPhase:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKVCOscillator {

		[Static]
		[Export ("waveformTypeForSawtooth")]
		AKConstant SawtoothWaveform { get; }

		[Static]
		[Export ("waveformTypeForSquareWithPWM")]
		AKConstant SquareWithPWMWaveform { get; }

		[Static]
		[Export ("waveformTypeForTriangleWithRamp")]
		AKConstant TriangleWithRampWaveform { get; }

		[Static]
		[Export ("waveformTypeForUnnormalizedPulse")]
		AKConstant UnnormalizedPulseWaveform { get; }

		[Static]
		[Export ("waveformTypeForIntegratedSawtooth")]
		AKConstant IntegratedSawtoothWaveform { get; }

		[Static]
		[Export ("waveformTypeForSquare")]
		AKConstant SquareWaveform { get; }

		[Static]
		[Export ("waveformTypeForTriangle")]
		AKConstant TriangleWaveform { get; }

		[Export ("initWithWaveformType:bandwidth:pulseWidth:frequency:amplitude:")]
		IntPtr Constructor (AKConstant waveformType, AKConstant bandwidth, AKParameter pulseWidth, AKParameter frequency, AKParameter amplitude);

		[Static]
		[Export ("oscillator")]
		AKVCOscillator GetInstance { get; }

		[Export ("waveformType")]
		AKConstant WaveformType { get; [Bind ("setOptionalWaveformType:")] set; }

		[Export ("bandwidth")]
		AKConstant Bandwidth { get; [Bind ("setOptionalBandwidth:")] set; }

		[Export ("pulseWidth")]
		AKParameter PulseWidth { get; [Bind ("setOptionalPulseWidth:")] set; }

		[Export ("frequency")]
		AKParameter Frequency { get; [Bind ("setOptionalFrequency:")] set; }

		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }
	}

	#endregion


	#region Operations/Signal Generators/Physical Models

	[BaseType (typeof (AKAudio))]
	interface AKMandolin {

		[Export ("initWithBodySize:frequency:amplitude:pairedStringDetuning:pluckPosition:loopGain:")]
		IntPtr Constructor (AKParameter bodySize, AKParameter frequency, AKParameter amplitude, AKParameter pairedStringDetuning, AKConstant pluckPosition, AKParameter loopGain);

		[Static]
		[Export ("mandolin")]
		AKMandolin GetInstance { get; }

		[Export ("bodySize")]
		AKParameter BodySize { get; [Bind ("setOptionalBodySize:")] set; }

		[Export ("frequency")]
		AKParameter Frequency { get; [Bind ("setOptionalFrequency:")] set; }

		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }

		[Export ("pairedStringDetuning")]
		AKParameter PairedStringDetuning { get; [Bind ("setOptionalPairedStringDetuning:")] set; }

		[Export ("pluckPosition")]
		AKConstant PluckPosition { get; [Bind ("setOptionalPluckPosition:")] set; }

		[Export ("loopGain")]
		AKParameter LoopGain { get; [Bind ("setOptionalLoopGain:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKMarimba {

		[Export ("initWithFrequency:amplitude:stickHardness:strikePosition:vibratoShapeTable:vibratoFrequency:vibratoAmplitude:doubleStrikePercentage:tripleStrikePercentage:")]
		IntPtr Constructor (AKParameter frequency, AKConstant amplitude, AKConstant stickHardness, AKConstant strikePosition, AKFunctionTable vibratoShapeTable, AKParameter vibratoFrequency, AKParameter vibratoAmplitude, AKConstant doubleStrikePercentage, AKConstant tripleStrikePercentage);

		[Static]
		[Export ("marimba")]
		AKMarimba GetInstance { get; }

		[Export ("frequency")]
		AKParameter Frequency { get; [Bind ("setOptionalFrequency:")] set; }

		[Export ("amplitude")]
		AKConstant Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }

		[Export ("stickHardness")]
		AKConstant StickHardness { get; [Bind ("setOptionalStickHardness:")] set; }

		[Export ("strikePosition")]
		AKConstant StrikePosition { get; [Bind ("setOptionalStrikePosition:")] set; }

		[Export ("vibratoShapeTable")]
		AKFunctionTable VibratoShapeTable { get; [Bind ("setOptionalVibratoShapeTable:")] set; }

		[Export ("vibratoFrequency")]
		AKParameter VibratoFrequency { get; [Bind ("setOptionalVibratoFrequency:")] set; }

		[Export ("vibratoAmplitude")]
		AKParameter VibratoAmplitude { get; [Bind ("setOptionalVibratoAmplitude:")] set; }

		[Export ("doubleStrikePercentage")]
		AKConstant DoubleStrikePercentage { get; [Bind ("setOptionalDoubleStrikePercentage:")] set; }

		[Export ("tripleStrikePercentage")]
		AKConstant TripleStrikePercentage { get; [Bind ("setOptionalTripleStrikePercentage:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKPluckedString {

		[Export ("initWithExcitationSignal:frequency:pluckPosition:samplePosition:reflectionCoefficient:amplitude:")]
		IntPtr Constructor (AKParameter excitationSignal, AKConstant frequency, AKConstant pluckPosition, AKParameter samplePosition, AKParameter reflectionCoefficient, AKParameter amplitude);

		[Export ("initWithExcitationSignal:")]
		IntPtr Constructor (AKParameter excitationSignal);

		[Static]
		[Export ("pluckWithExcitationSignal:")]
		AKPluckedString FromExcitationSignal (AKParameter excitationSignal);

		[Export ("frequency")]
		AKConstant Frequency { get; [Bind ("setOptionalFrequency:")] set; }

		[Export ("pluckPosition")]
		AKConstant PluckPosition { get; [Bind ("setOptionalPluckPosition:")] set; }

		[Export ("samplePosition")]
		AKParameter SamplePosition { get; [Bind ("setOptionalSamplePosition:")] set; }

		[Export ("reflectionCoefficient")]
		AKParameter ReflectionCoefficient { get; [Bind ("setOptionalReflectionCoefficient:")] set; }

		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKStruckMetalBar {

		[Static]
		[Export ("boundaryConditionClamped")]
		AKConstant BoundaryConditionClamped ();

		[Static]
		[Export ("boundaryConditionPivoting")]
		AKConstant BoundaryConditionPivoting ();

		[Static]
		[Export ("boundaryConditionFree")]
		AKConstant BoundaryConditionFree ();

		[Export ("initWithDecayTime:dimensionlessStiffness:highFrequencyLoss:strikePosition:strikeVelocity:strikeWidth:leftBoundaryCondition:rightBoundaryCondition:scanSpeed:")]
		IntPtr Constructor (AKConstant decayTime, AKConstant dimensionlessStiffness, AKConstant highFrequencyLoss, AKConstant strikePosition, AKConstant strikeVelocity, AKConstant strikeWidth, AKConstant leftBoundaryCondition, AKConstant rightBoundaryCondition, AKParameter scanSpeed);

		[Static]
		[Export ("strike")]
		AKStruckMetalBar GetInstance { get; }

		[Export ("decayTime")]
		AKConstant DecayTime { get; [Bind ("setOptionalDecayTime:")] set; }

		[Export ("dimensionlessStiffness")]
		AKConstant DimensionlessStiffness { get; [Bind ("setOptionalDimensionlessStiffness:")] set; }

		[Export ("highFrequencyLoss")]
		AKConstant HighFrequencyLoss { get; [Bind ("setOptionalHighFrequencyLoss:")] set; }

		[Export ("strikePosition")]
		AKConstant StrikePosition { get; [Bind ("setOptionalStrikePosition:")] set; }

		[Export ("strikeVelocity")]
		AKConstant StrikeVelocity { get; [Bind ("setOptionalStrikeVelocity:")] set; }

		[Export ("strikeWidth")]
		AKConstant StrikeWidth { get; [Bind ("setOptionalStrikeWidth:")] set; }

		[Export ("leftBoundaryCondition")]
		AKConstant LeftBoundaryCondition { get; [Bind ("setOptionalLeftBoundaryCondition:")] set; }

		[Export ("rightBoundaryCondition")]
		AKConstant RightBoundaryCondition { get; [Bind ("setOptionalRightBoundaryCondition:")] set; }

		[Export ("scanSpeed")]
		AKParameter ScanSpeed { get; [Bind ("setOptionalScanSpeed:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKVibes {

		[Export ("initWithFrequency:amplitude:stickHardness:strikePosition:tremoloShapeTable:tremoloFrequency:tremoloAmplitude:")]
		IntPtr Constructor (AKParameter frequency, AKParameter amplitude, AKConstant stickHardness, AKConstant strikePosition, AKFunctionTable tremoloShapeTable, AKParameter tremoloFrequency, AKParameter tremoloAmplitude);

		[Static]
		[Export ("vibes")]
		AKVibes GetInstance { get; }

		[Export ("frequency")]
		AKParameter Frequency { get; [Bind ("setOptionalFrequency:")] set; }

		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }

		[Export ("stickHardness")]
		AKConstant StickHardness { get; [Bind ("setOptionalStickHardness:")] set; }

		[Export ("strikePosition")]
		AKConstant StrikePosition { get; [Bind ("setOptionalStrikePosition:")] set; }

		[Export ("tremoloShapeTable")]
		AKFunctionTable TremoloShapeTable { get; [Bind ("setOptionalTremoloShapeTable:")] set; }

		[Export ("tremoloFrequency")]
		AKParameter TremoloFrequency { get; [Bind ("setOptionalTremoloFrequency:")] set; }

		[Export ("tremoloAmplitude")]
		AKParameter TremoloAmplitude { get; [Bind ("setOptionalTremoloAmplitude:")] set; }
	}


	#region Operations/Signal Generators/Physical Models/PhiSEM

	[BaseType (typeof (AKAudio))]
	interface AKBambooSticks {

		[Export ("initWithCount:mainResonantFrequency:firstResonantFrequency:secondResonantFrequency:amplitude:")]
		IntPtr Constructor (AKConstant count, AKConstant mainResonantFrequency, AKConstant firstResonantFrequency, AKConstant secondResonantFrequency, AKConstant amplitude);

		[Static]
		[Export ("sticks")]
		AKBambooSticks GetInstance { get; }

		[Export ("count")]
		AKConstant Count { get; [Bind ("setOptionalCount:")] set; }

		[Export ("mainResonantFrequency")]
		AKConstant MainResonantFrequency { get; [Bind ("setOptionalMainResonantFrequency:")] set; }

		[Export ("firstResonantFrequency")]
		AKConstant FirstResonantFrequency { get; [Bind ("setOptionalFirstResonantFrequency:")] set; }

		[Export ("secondResonantFrequency")]
		AKConstant SecondResonantFrequency { get; [Bind ("setOptionalSecondResonantFrequency:")] set; }

		[Export ("amplitude")]
		AKConstant Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKCabasa {

		[Export ("initWithCount:dampingFactor:amplitude:")]
		IntPtr Constructor (AKConstant count, AKConstant dampingFactor, AKConstant amplitude);

		[Static]
		[Export ("cabasa")]
		AKCabasa GetInstance { get; }

		[Export ("count")]
		AKConstant Count { get; [Bind ("setOptionalCount:")] set; }

		[Export ("dampingFactor")]
		AKConstant DampingFactor { get; [Bind ("setOptionalDampingFactor:")] set; }

		[Export ("amplitude")]
		AKConstant Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKCrunch {

		[Export ("initWithIntensity:dampingFactor:amplitude:")]
		IntPtr Constructor (AKConstant intensity, AKConstant dampingFactor, AKConstant amplitude);

		[Static]
		[Export ("crunch")]
		AKCrunch GetInstance { get; }

		[Export ("intensity")]
		AKConstant Intensity { get; [Bind ("setOptionalIntensity:")] set; }

		[Export ("dampingFactor")]
		AKConstant DampingFactor { get; [Bind ("setOptionalDampingFactor:")] set; }

		[Export ("amplitude")]
		AKConstant Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKDroplet {

		[Export ("initWithIntensity:dampingFactor:energyReturn:mainResonantFrequency:firstResonantFrequency:secondResonantFrequency:amplitude:")]
		IntPtr Constructor (AKConstant intensity, AKConstant dampingFactor, AKConstant energyReturn, AKConstant mainResonantFrequency, AKConstant firstResonantFrequency, AKConstant secondResonantFrequency, AKParameter amplitude);

		[Static]
		[Export ("droplet")]
		AKDroplet GetInstance { get; }

		[Export ("intensity")]
		AKConstant Intensity { get; [Bind ("setOptionalIntensity:")] set; }

		[Export ("dampingFactor")]
		AKConstant DampingFactor { get; [Bind ("setOptionalDampingFactor:")] set; }

		[Export ("energyReturn")]
		AKConstant EnergyReturn { get; [Bind ("setOptionalEnergyReturn:")] set; }

		[Export ("mainResonantFrequency")]
		AKConstant MainResonantFrequency { get; [Bind ("setOptionalMainResonantFrequency:")] set; }

		[Export ("firstResonantFrequency")]
		AKConstant FirstResonantFrequency { get; [Bind ("setOptionalFirstResonantFrequency:")] set; }

		[Export ("secondResonantFrequency")]
		AKConstant SecondResonantFrequency { get; [Bind ("setOptionalSecondResonantFrequency:")] set; }

		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKGuiro {

		[Export ("initWithCount:mainResonantFrequency:firstResonantFrequency:amplitude:")]
		IntPtr Constructor (AKConstant count, AKConstant mainResonantFrequency, AKConstant firstResonantFrequency, AKParameter amplitude);

		[Static]
		[Export ("guiro")]
		AKGuiro GetInstance { get; }

		[Export ("count")]
		AKConstant Count { get; [Bind ("setOptionalCount:")] set; }

		[Export ("mainResonantFrequency")]
		AKConstant MainResonantFrequency { get; [Bind ("setOptionalMainResonantFrequency:")] set; }

		[Export ("firstResonantFrequency")]
		AKConstant FirstResonantFrequency { get; [Bind ("setOptionalFirstResonantFrequency:")] set; }

		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKSandPaper {

		[Export ("initWithIntensity:dampingFactor:")]
		IntPtr Constructor (AKConstant intensity, AKConstant dampingFactor);

		[Static]
		[Export ("sandPaper")]
		AKSandPaper GetInstance { get; }

		[Export ("intensity")]
		AKConstant Intensity { get; [Bind ("setOptionalIntensity:")] set; }

		[Export ("dampingFactor")]
		AKConstant DampingFactor { get; [Bind ("setOptionalDampingFactor:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKSekere {

		[Export ("initWithCount:dampingFactor:amplitude:")]
		IntPtr Constructor (AKConstant count, AKConstant dampingFactor, AKConstant amplitude);

		[Static]
		[Export ("sekere")]
		AKSekere GetInstance { get; }

		[Export ("count")]
		AKConstant Count { get; [Bind ("setOptionalCount:")] set; }

		[Export ("dampingFactor")]
		AKConstant DampingFactor { get; [Bind ("setOptionalDampingFactor:")] set; }

		[Export ("amplitude")]
		AKConstant Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKSleighbells {

		[Export ("initWithIntensity:dampingFactor:mainResonantFrequency:firstResonantFrequency:secondResonantFrequency:amplitude:")]
		IntPtr Constructor (AKConstant intensity, AKConstant dampingFactor, AKConstant mainResonantFrequency, AKConstant firstResonantFrequency, AKConstant secondResonantFrequency, AKConstant amplitude);

		[Static]
		[Export ("sleighbells")]
		AKSleighbells GetInstance { get; }

		[Export ("intensity")]
		AKConstant Intensity { get; [Bind ("setOptionalIntensity:")] set; }

		[Export ("dampingFactor")]
		AKConstant DampingFactor { get; [Bind ("setOptionalDampingFactor:")] set; }

		[Export ("mainResonantFrequency")]
		AKConstant MainResonantFrequency { get; [Bind ("setOptionalMainResonantFrequency:")] set; }

		[Export ("firstResonantFrequency")]
		AKConstant FirstResonantFrequency { get; [Bind ("setOptionalFirstResonantFrequency:")] set; }

		[Export ("secondResonantFrequency")]
		AKConstant SecondResonantFrequency { get; [Bind ("setOptionalSecondResonantFrequency:")] set; }

		[Export ("amplitude")]
		AKConstant Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKStick {

		[Export ("initWithIntensity:dampingFactor:amplitude:")]
		IntPtr Constructor (AKConstant intensity, AKConstant dampingFactor, AKConstant amplitude);

		[Static]
		[Export ("stick")]
		AKStick GetInstance { get; }

		[Export ("intensity")]
		AKConstant Intensity { get; [Bind ("setOptionalIntensity:")] set; }

		[Export ("dampingFactor")]
		AKConstant DampingFactor { get; [Bind ("setOptionalDampingFactor:")] set; }

		[Export ("amplitude")]
		AKConstant Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKTambourine {

		[Export ("initWithIntensity:dampingFactor:mainResonantFrequency:firstResonantFrequency:secondResonantFrequency:amplitude:")]
		IntPtr Constructor (AKConstant intensity, AKConstant dampingFactor, AKConstant mainResonantFrequency, AKConstant firstResonantFrequency, AKConstant secondResonantFrequency, AKConstant amplitude);

		[Static]
		[Export ("tambourine")]
		AKTambourine GetInstance { get; }

		[Export ("intensity")]
		AKConstant Intensity { get; [Bind ("setOptionalIntensity:")] set; }

		[Export ("dampingFactor")]
		AKConstant DampingFactor { get; [Bind ("setOptionalDampingFactor:")] set; }

		[Export ("mainResonantFrequency")]
		AKConstant MainResonantFrequency { get; [Bind ("setOptionalMainResonantFrequency:")] set; }

		[Export ("firstResonantFrequency")]
		AKConstant FirstResonantFrequency { get; [Bind ("setOptionalFirstResonantFrequency:")] set; }

		[Export ("secondResonantFrequency")]
		AKConstant SecondResonantFrequency { get; [Bind ("setOptionalSecondResonantFrequency:")] set; }

		[Export ("amplitude")]
		AKConstant Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }
	}

	#endregion


	#region Operations/Signal Generators/Physical Models/Waveguide

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKBeatenPlate {

		[Export ("initWithInput:frequency1:frequency2:cutoffFrequency1:cutoffFrequency2:feedback1:feedback2:")]
		IntPtr Constructor (AKParameter input, AKParameter frequency1, AKParameter frequency2, AKParameter cutoffFrequency1, AKParameter cutoffFrequency2, AKParameter feedback1, AKParameter feedback2);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("beatenPlateWithInput:")]
		AKBeatenPlate FromInput (AKParameter input);

		[Export ("frequency1")]
		AKParameter Frequency1 { get; [Bind ("setOptionalFrequency1:")] set; }

		[Export ("frequency2")]
		AKParameter Frequency2 { get; [Bind ("setOptionalFrequency2:")] set; }

		[Export ("cutoffFrequency1")]
		AKParameter CutoffFrequency1 { get; [Bind ("setOptionalCutoffFrequency1:")] set; }

		[Export ("cutoffFrequency2")]
		AKParameter CutoffFrequency2 { get; [Bind ("setOptionalCutoffFrequency2:")]set; }

		[Export ("feedback1")]
		AKParameter Feedback1 { get; [Bind ("setOptionalFeedback1:")] set; }

		[Export ("feedback2")]
		AKParameter Feedback2 { get; [Bind ("setOptionalFeedback2:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKBowedString {

		[Export ("initWithFrequency:amplitude:pressure:position:vibratoShapeTable:vibratoFrequency:vibratoAmplitude:minimumFrequency:")]
		IntPtr Constructor (AKParameter frequency, AKParameter amplitude, AKParameter pressure, AKParameter position, AKFunctionTable vibratoShapeTable, AKParameter vibratoFrequency, AKParameter vibratoAmplitude, AKConstant minimumFrequency);

		[Static]
		[Export ("bowedString")]
		AKBowedString GetInstance { get; }

		[Export ("frequency")]
		AKParameter Frequency { get; [Bind ("setOptionalFrequency:")] set; }

		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }

		[Export ("pressure")]
		AKParameter Pressure { get; [Bind ("setOptionalPressure:")] set; }

		[Export ("position")]
		AKParameter Position { get; [Bind ("setOptionalPosition:")] set; }

		[Export ("vibratoShapeTable")]
		AKFunctionTable VibratoShapeTable { get; [Bind ("setOptionalVibratoShapeTable:")] set; }

		[Export ("vibratoFrequency")]
		AKParameter VibratoFrequency { get; [Bind ("setOptionalVibratoFrequency:")] set; }

		[Export ("vibratoAmplitude")]
		AKParameter VibratoAmplitude { get; [Bind ("setOptionalVibratoAmplitude:")]set; }

		[Export ("minimumFrequency")]
		AKConstant MinimumFrequency { get; [Bind ("setOptionalMinimumFrequency:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKFlute {

		[Export ("initWithFrequency:attackTime:releaseTime:airJetPressure:jetrf:endrf:noiseAmplitude:amplitude:vibratoShape:vibratoAmplitude:vibratoFrequency:")]
		IntPtr Constructor (AKParameter frequency, AKConstant attackTime, AKConstant releaseTime, AKParameter airJetPressure, AKConstant jetrf, AKConstant endrf, AKParameter noiseAmplitude, AKParameter amplitude, AKFunctionTable vibratoShape, AKParameter vibratoAmplitude, AKParameter vibratoFrequency);

		[Static]
		[Export ("flute")]
		AKFlute GetInstance { get; }

		[Export ("frequency")]
		AKParameter Frequency { get; [Bind ("setOptionalFrequency:")] set; }

		[Export ("attackTime")]
		AKConstant AttackTime { get; [Bind ("setOptionalAttackTime:")] set; }

		[Export ("releaseTime")]
		AKConstant ReleaseTime { get; [Bind ("setOptionalReleaseTime:")] set; }

		[Export ("airJetPressure")]
		AKParameter AirJetPressure { get; [Bind ("setOptionalAirJetPressure:")] set; }

		[Export ("jetrf")]
		AKConstant Jetrf { get; [Bind ("setOptionalJetrf:")] set; }

		[Export ("endrf")]
		AKConstant Endrf { get; [Bind ("setOptionalEndrf:")] set; }

		[Export ("noiseAmplitude")]
		AKParameter NoiseAmplitude { get; [Bind ("setOptionalNoiseAmplitude:")] set; }

		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }

		[Export ("vibratoShape")]
		AKFunctionTable VibratoShape { get; [Bind ("setOptionalVibratoShape:")] set; }

		[Export ("vibratoAmplitude")]
		AKParameter VibratoAmplitude { get; [Bind ("setOptionalVibratoAmplitude:")] set; }

		[Export ("vibratoFrequency")]
		AKParameter VibratoFrequency { get; [Bind ("setOptionalVibratoFrequency:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKSimpleWaveGuideModel {

		[Export ("initWithInput:frequency:cutoff:feedback:")]
		IntPtr Constructor (AKParameter input, AKParameter frequency, AKParameter cutoff, AKParameter feedback);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("modelWithInput:")]
		AKSimpleWaveGuideModel FromInput (AKParameter input);

		[Export ("frequency")]
		AKParameter Frequency { get; [Bind ("setOptionalFrequency:")] set; }

		[Export ("cutoff")]
		AKParameter Cutoff { get; [Bind ("setOptionalCutoff:")] set; }

		[Export ("feedback")]
		AKParameter Feedback { get; [Bind ("setOptionalFeedback:")]set; }
	}

	#endregion


	#endregion


	#region Operations/Signal Generators/Random Generators

	[BaseType (typeof (AKControl))]
	interface AKInterpolatedRandomNumberPulse {

		[Export ("initWithUpperBound:frequency:")]
		IntPtr Constructor (AKParameter upperBound, AKParameter frequency);

		[Static]
		[Export ("pulse")]
		AKInterpolatedRandomNumberPulse GetInstance { get; }

		[Export ("upperBound")]
		AKParameter UpperBound { get; [Bind ("setOptionalUpperBound:")] set; }

		[Export ("frequency")]
		AKParameter Frequency { get; [Bind ("setOptionalFrequency:")] set; }
	}

	[BaseType (typeof (AKControl))]
	interface AKJitter {

		[Export ("initWithAmplitude:minimumFrequency:maximumFrequency:")]
		IntPtr Constructor (AKParameter amplitude, AKParameter minimumFrequency, AKParameter maximumFrequency);

		[Static]
		[Export ("jitter")]
		AKJitter GetInstance { get; }

		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }

		[Export ("minimumFrequency")]
		AKParameter MinimumFrequency { get; [Bind ("setOptionalMinimumFrequency:")] set; }

		[Export ("maximumFrequency")]
		AKParameter MaximumFrequency { get; [Bind ("setOptionalMaximumFrequency:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKNoise {

		[Export ("initWithAmplitude:pinkBalance:beta:")]
		IntPtr Constructor (AKParameter amplitude, AKParameter pinkBalance, AKParameter beta);

		[Static]
		[Export ("noise")]
		AKNoise GetInstance { get; }

		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }

		[Export ("pinkBalance")]
		AKParameter PinkBalance { get; [Bind ("setOptionalPinkBalance:")] set; }

		[Export ("beta")]
		AKParameter Beta { get; [Bind ("setOptionalBeta:")] set; }
	}

	[BaseType (typeof (AKAudio))]
	interface AKRandomNumbers {

		[Export ("initWithLowerBound:upperBound:")]
		IntPtr Constructor (AKParameter lowerBound, AKParameter upperBound);

		[Static]
		[Export ("numbers")]
		AKRandomNumbers GetInstance { get; }

		[Export ("lowerBound")]
		AKParameter LowerBound { get; [Bind ("setOptionalLowerBound:")] set; }

		[Export ("upperBound")]
		AKParameter UpperBound { get; [Bind ("setOptionalUpperBound:")] set; }
	}

	#endregion


	#region Operations/Signal Generators/Segment Arrays

	[DisableDefaultCtor]
	[BaseType (typeof (AKParameter))]
	interface AKSegmentArray {

		[Export ("initWithInitialValue:targetValue:afterDuration:concavity:")]
		IntPtr Constructor (AKConstant initialValue, AKConstant targetValue, AKConstant duration, AKConstant concavity);

		[Export ("addValue:afterDuration:concavity:")]
		void Add (AKConstant value, AKConstant duration, AKConstant concavity);

		[Export ("initWithInitialValue:targetValue:afterDuration:")]
		IntPtr Constructor (AKConstant initialValue, AKConstant targetValue, AKConstant duration);

		[Export ("addValue:afterDuration:")]
		void Add (AKConstant value, AKConstant duration);

		[Export ("releaseToValue:afterDuration:concavity:")]
		void Release (AKConstant value, AKConstant duration, AKConstant concavity);
	}

	[BaseType (typeof (AKControl))]
	interface AKSegmentArrayLoop {

		[Export ("initWithFrequency:initialValue:")]
		IntPtr Constructor (AKParameter frequency, AKParameter initialValue);

		[Export ("addValue:afterDuration:concavity:")]
		void Add (AKParameter value, AKParameter duration, AKParameter concavity);
	}

	#endregion


	#region Operations/Signal Generators/Subtractive Synthesis

	[BaseType (typeof (AKAudio))]
	interface AKAdditiveCosines {

		[Export ("initWithCosineTable:harmonicsCount:firstHarmonicIndex:partialMultiplier:fundamentalFrequency:amplitude:phase:")]
		IntPtr Constructor (AKFunctionTable cosineTable, AKParameter harmonicsCount, AKParameter firstHarmonicIndex, AKParameter partialMultiplier, AKParameter fundamentalFrequency, AKParameter amplitude, AKConstant phase);

		[Export ("initWithCosineTable:")]
		IntPtr Constructor (AKFunctionTable cosineTable);

		[Static]
		[Export ("cosinesWithCosineTable:")]
		AKAdditiveCosines FromCosineTable (AKFunctionTable cosineTable);

		[Export ("harmonicsCount")]
		AKParameter HarmonicsCount { get; [Bind ("setOptionalHarmonicsCount:")] set; }

		[Export ("firstHarmonicIndex")]
		AKParameter FirstHarmonicIndex { get; [Bind ("setOptionalFirstHarmonicIndex:")] set; }

		[Export ("partialMultiplier")]
		AKParameter PartialMultiplier { get; [Bind ("setOptionalPartialMultiplier:")] set; }

		[Export ("fundamentalFrequency")]
		AKParameter FundamentalFrequency { get; [Bind ("setOptionalFundamentalFrequency:")] set; }

		[Export ("amplitude")]
		AKParameter Amplitude { get; [Bind ("setOptionalAmplitude:")] set; }

		[Export ("phase")]
		AKConstant Phase { get; [Bind ("setOptionalPhase:")] set; }
	}

	#endregion


	#endregion


	#region Operations/Signal Input and Output

	[BaseType (typeof (AKAudio))]
	interface AKAudioInput {

	}

	[BaseType (typeof (AKParameter))]
	interface AKAudioOutput {

		[Internal]
		[Export ("initWithInput:")]
		IntPtr FromInputConstructor (AKParameter source);

		[Internal]
		[Export ("initWithAudioSource:")]
		IntPtr FromAudioSourceConstructor (AKParameter audioSource);

		[Internal]
		[Export ("initWithStereoAudioSource:")]
		IntPtr FromStereoAudioSourceConstructor (AKStereoAudio stereoAudio);

		[Internal]
		[Export ("initWithLeftAudio:rightAudio:")]
		IntPtr FromChannelsConstructor (AKParameter leftAudio, AKParameter rightAudio);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKStereoAudio))]
	interface AKFileInput {

		[Export ("initWithFilename:")]
		IntPtr Constructor (string fileName);

		[Export ("initWithFilename:speed:startTime:")]
		IntPtr Constructor (string fileName, AKParameter speed, AKConstant startTime);

		[Export ("speed")]
		AKParameter Speed { get; [Bind ("setOptionalSpeed:")] set; }

		[Export ("startTime")]
		AKConstant StartTime { get; [Bind ("setOptionalStartTime:")] set; }

		[Export ("normalizeTo:")]
		void NormalizeTo (float maximumAmplitude);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKMonoFileInput {

		[Export ("initWithFilename:")]
		IntPtr Constructor (string fileName);

		[Export ("initWithFilename:speed:startTime:")]
		IntPtr Constructor (string fileName, AKParameter speed, AKConstant startTime);

		[Export ("speed")]
		AKParameter Speed { get; [Bind ("setOptionalSpeed:")] set; }

		[Export ("startTime")]
		AKConstant StartTime { get; [Bind ("setOptionalStartTime:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKStereoAudio))]
	interface AKMp3FileInput {

		[Export ("initWithFilename:")]
		IntPtr Constructor (string filename);

		[Static]
		[Export ("mp3WithFilename:")]
		AKMp3FileInput FromFilename (string filename);
	}

	#endregion


	#region Operations/Signal Modifiers


	#region Operations/Signal Modifiers/Convolutions

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKConvolution {

		[Export ("initWithInput:impulseResponseFilename:")]
		IntPtr Constructor (AKParameter input, string impulseResponseFilename);

		[Static]
		[Export ("convolutionWithInput:impulseResponseFilename:")]
		AKConvolution FromInput (AKParameter input, string impulseResponseFilename);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKStereoAudio))]
	interface AKStereoConvolution {

		[Export ("initWithInput:impulseResponseFilename:")]
		IntPtr Constructor (AKParameter input, string impulseResponseFilename);

		[Static]
		[Export ("convolutionWithInput:impulseResponseFilename:")]
		AKStereoConvolution ConvolutionWithInput (AKParameter input, string impulseResponseFilename);
	}

	#endregion


	#region Operations/Signal Modifiers/Delays

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKDelay {

		[Export ("initWithInput:delayTime:feedback:")]
		IntPtr Constructor (AKParameter input, AKConstant delayTime, AKParameter feedback);

		[Export ("initWithInput:delayTime:")]
		IntPtr Constructor (AKParameter input, AKConstant delayTime);

		[Static]
		[Export ("delayWithInput:delayTime:")]
		AKDelay FromInput (AKParameter input, AKConstant delayTime);

		[Export ("feedback")]
		AKParameter Feedback { get; [Bind ("setOptionalFeedback:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKMultitapDelay {

		[Export ("initWithInput:firstEchoTime:firstEchoGain:")]
		IntPtr Constructor (AKParameter input, AKConstant firstEchoTime, AKConstant firstEchoGain);

		[Static]
		[Export ("delayWithInput:firstEchoTime:firstEchoGain:")]
		AKMultitapDelay FromInput (AKParameter input, AKConstant firstEchoTime, AKConstant firstEchoGain);

		[Export ("addEchoAtTime:gain:")]
		void AddEchoAtTime (AKConstant time, AKConstant gain);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKVariableDelay {

		[Export ("initWithInput:delayTime:maximumDelayTime:")]
		IntPtr Constructor (AKParameter input, AKParameter delayTime, AKConstant maximumDelayTime);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("delayWithInput:")]
		AKVariableDelay FromInput (AKParameter input);

		[Export ("delayTime")]
		AKParameter DelayTime { get; [Bind ("setOptionalDelayTime:")] set; }

		[Export ("maximumDelayTime")]
		AKConstant MaximumDelayTime { get; [Bind ("setOptionalMaximumDelayTime:")] set; }
	}

	#endregion


	#region Operations/Signal Modifiers/Effects

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKCompressor {

		[Export ("initWithInput:controllingInput:threshold:lowKnee:highKnee:compressionRatio:attackTime:releaseTime:lookAheadTime:")]
		IntPtr Constructor (AKParameter input, AKParameter controllingInput, AKParameter threshold, AKParameter lowKnee, AKParameter highKnee, AKParameter compressionRatio, AKParameter attackTime, AKParameter releaseTime, AKConstant lookAheadTime);

		[Export ("initWithInput:controllingInput:")]
		IntPtr Constructor (AKParameter input, AKParameter controllingInput);

		[Static]
		[Export ("compressorWithInput:controllingInput:")]
		AKCompressor FromInput (AKParameter input, AKParameter controllingInput);

		[Export ("threshold")]
		AKParameter Threshold { get; [Bind ("setOptionalThreshold:")] set; }

		[Export ("lowKnee")]
		AKParameter LowKnee { get; [Bind ("setOptionalLowKnee:")] set; }

		[Export ("highKnee")]
		AKParameter HighKnee { get; [Bind ("setOptionalHighKnee:")] set; }

		[Export ("compressionRatio")]
		AKParameter CompressionRatio { get; [Bind ("setOptionalCompressionRatio:")] set; }

		[Export ("attackTime")]
		AKParameter AttackTime { get; [Bind ("setOptionalAttackTime:")] set; }

		[Export ("releaseTime")]
		AKParameter ReleaseTime { get; [Bind ("setOptionalReleaseTime:")] set; }

		[Export ("lookAheadTime")]
		AKConstant LookAheadTime { get; [Bind ("setOptionalLookAheadTime:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKDopplerEffect {

		[Export ("initWithInput:sourcePosition:micPosition:smoothingFilterUpdateRate:")]
		IntPtr Constructor (AKParameter input, AKParameter sourcePosition, AKParameter micPosition, AKConstant smoothingFilterUpdateRate);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("effectWithInput:")]
		AKDopplerEffect EffectWithInput (AKParameter input);

		[Export ("sourcePosition")]
		AKParameter SourcePosition { get; [Bind ("setOptionalSourcePosition:")] set; }

		[Export ("micPosition")]
		AKParameter MicPosition { get; [Bind ("setOptionalMicPosition:")] set; }

		[Export ("smoothingFilterUpdateRate")]
		AKConstant SmoothingFilterUpdateRate { get; [Bind ("setOptionalSmoothingFilterUpdateRate:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKFlanger {

		[Export ("initWithInput:delayTime:feedback:")]
		IntPtr Constructor (AKParameter input, AKParameter delayTime, AKParameter feedback);

		[Export ("initWithInput:delayTime:")]
		IntPtr Constructor (AKParameter input, AKParameter delayTime);

		[Static]
		[Export ("effectWithInput:delayTime:")]
		AKFlanger FromInput (AKParameter input, AKParameter delayTime);

		[Export ("feedback")]
		AKParameter Feedback { get; [Bind ("setOptionalFeedback:")] set; }
	}

	#endregion


	#region Operations/Signal Modifiers/Filters

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKCombFilter {

		[Export ("initWithInput:reverbDuration:loopDuration:")]
		IntPtr Constructor (AKParameter input, AKParameter reverbDuration, AKConstant loopDuration);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("filterWithInput:")]
		AKCombFilter FromInput (AKParameter input);

		[Export ("reverbDuration")]
		AKParameter ReverbDuration { get; [Bind("setOptionalReverbDuration:")] set; }

		[Export ("loopDuration")]
		AKConstant LoopDuration { get; [Bind("setOptionalLoopDuration:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKDCBlock {

		[Export ("initWithInput:gain:")]
		IntPtr Constructor (AKParameter input, AKConstant gain);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("filterWithInput:")]
		AKDCBlock FromInput (AKParameter input);

		[Export ("gain")]
		AKConstant Gain { get; [Bind ("setOptionalGain:")] set; }

		[Export ("setOptionalGain:")]
		void SetOptionalGain (AKConstant gain);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKDecimator {

		[Export ("initWithInput:bitDepth:sampleRate:")]
		IntPtr Constructor (AKParameter input, AKParameter bitDepth, AKParameter sampleRate);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("WithInput:")]
		AKDecimator FromInput (AKParameter input);

		[Export ("bitDepth")]
		AKParameter BitDepth { get; [Bind ("setOptionalBitDepth:")] set; }

		[Export ("sampleRate")]
		AKParameter SampleRate { get; [Bind ("setOptionalSampleRate:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKDeclick {

		[Export ("initWithInput:")]
		IntPtr Constructor (AKAudio audioSource);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKEqualizerFilter {

		[Export ("initWithInput:centerFrequency:bandwidth:gain:")]
		IntPtr Constructor (AKParameter input, AKParameter centerFrequency, AKParameter bandwidth, AKParameter gain);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("filterWithInput:")]
		AKEqualizerFilter FromInput (AKParameter input);

		[Export ("centerFrequency")]
		AKParameter CenterFrequency { get; [Bind ("setOptionalCenterFrequency:")] set; }

		[Export ("bandwidth")]
		AKParameter Bandwidth { get; [Bind ("setOptionalBandwidth:")] set; }

		[Export ("gain")]
		AKParameter Gain { get; [Bind ("setOptionalGain:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKHighPassFilter {

		[Export ("initWithInput:cutoffFrequency:")]
		IntPtr Constructor (AKParameter input, AKParameter cutoffFrequency);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("filterWithInput:")]
		AKHighPassFilter FromInput (AKParameter input);

		[Export ("cutoffFrequency")]
		AKParameter CutoffFrequency { get; [Bind ("setOptionalCutoffFrequency:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKStereoAudio))]
	interface AKHilbertTransformer {

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("filterWithInput:")]
		AKHilbertTransformer FromInput (AKParameter input);

		[Export ("realPart")]
		AKParameter RealPart { get; }

		[Export ("imaginaryPart")]
		AKParameter ImaginaryPart { get; }

		[Export ("sineOutput")]
		AKParameter SineOutput { get; }

		[Export ("cosineOutput")]
		AKParameter CosineOutput { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKLowPassFilter {

		[Export ("initWithAudioSource:halfPowerPoint:")]
		IntPtr Constructor (AKParameter audioSource, AKParameter halfPowerPoint);

		[Export ("initWithAudioSource:")]
		IntPtr Constructor (AKParameter audioSource);

		[Static]
		[Export ("filterWithAudioSource:")]
		AKLowPassFilter FromAudioSource (AKParameter audioSource);

		[Export ("halfPowerPoint")]
		AKParameter HalfPowerPoint { get; [Bind ("setOptionalHalfPowerPoint:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKMoogLadder {

		[Export ("initWithInput:cutoffFrequency:resonance:")]
		IntPtr Constructor (AKParameter input, AKParameter cutoffFrequency, AKParameter resonance);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("filterWithInput:")]
		AKMoogLadder FromInput (AKParameter input);

		[Export ("cutoffFrequency")]
		AKParameter CutoffFrequency { get; [Bind ("setOptionalCutoffFrequency:")] set; }

		[Export ("resonance")]
		AKParameter Resonance { get; [Bind ("setOptionalResonance:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKMoogVCF {

		[Export ("initWithInput:cutoffFrequency:resonance:")]
		IntPtr Constructor (AKParameter input, AKParameter cutoffFrequency, AKParameter resonance);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("filterWithInput:")]
		AKMoogVCF FromInput (AKParameter input);

		[Export ("cutoffFrequency")]
		AKParameter CutoffFrequency { get; [Bind ("setOptionalCutoffFrequency:")]set; }

		[Export ("resonance")]
		AKParameter Resonance { get; [Bind ("setOptionalResonance:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKResonantFilter {

		[Export ("initWithAudioSource:centerFrequency:bandwidth:")]
		IntPtr Constructor (AKParameter audioSource, AKParameter centerFrequency, AKParameter bandwidth);

		[Export ("initWithAudioSource:")]
		IntPtr Constructor (AKParameter audioSource);

		[Static]
		[Export ("filterWithAudioSource:")]
		AKResonantFilter FromAudioSource (AKParameter audioSource);

		[Export ("centerFrequency")]
		AKParameter CenterFrequency { get; [Bind ("setOptionalCenterFrequency:")] set; }

		[Export ("bandwidth")]
		AKParameter Bandwidth { get; [Bind ("setOptionalBandwidth:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKThreePoleLowpassFilter {

		[Export ("initWithInput:distortion:cutoffFrequency:resonance:")]
		IntPtr Constructor (AKParameter input, AKParameter distortion, AKParameter cutoffFrequency, AKParameter resonance);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("filterWithInput:")]
		AKThreePoleLowpassFilter FromInput (AKParameter input);

		[Export ("distortion")]
		AKParameter Distortion { get; [Bind ("setOptionalDistortion:")] set; }

		[Export ("cutoffFrequency")]
		AKParameter CutoffFrequency { get; [Bind ("setOptionalCutoffFrequency:")] set; }

		[Export ("resonance")]
		AKParameter Resonance { get; [Bind ("setOptionalResonance:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKVariableFrequencyResponseBandPassFilter {

		[Static]
		[Export ("scalingFactorNone")]
		AKConstant ScalingFactorNone { get; }

		[Static]
		[Export ("scalingFactorPeak")]
		AKConstant ScalingFactorPeak { get; }

		[Static]
		[Export ("scalingFactorRMS")]
		AKConstant ScalingFactorRMS { get; }

		[Export ("initWithAudioSource:cutoffFrequency:bandwidth:scalingFactor:")]
		IntPtr Constructor (AKParameter audioSource, AKParameter cutoffFrequency, AKParameter bandwidth, AKConstant scalingFactor);

		[Export ("initWithAudioSource:")]
		IntPtr Constructor (AKParameter audioSource);

		[Static]
		[Export ("filterWithAudioSource:")]
		AKVariableFrequencyResponseBandPassFilter FromAudioSource (AKParameter audioSource);

		[Export ("cutoffFrequency")]
		AKParameter CutoffFrequency { get; [Bind ("setOptionalCutoffFrequency:")] set; }

		[Export ("bandwidth")]
		AKParameter Bandwidth { get; [Bind ("setOptionalBandwidth:")] set; }

		[Export ("scalingFactor")]
		AKConstant ScalingFactor { get; [Bind ("setOptionalScalingFactor:")] set; }
	}


	#region Operations/Signal Modifiers/Filters/Butterworth Filters

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKBandPassButterworthFilter {

		[Export ("initWithInput:centerFrequency:bandwidth:")]
		IntPtr Constructor (AKParameter input, AKParameter centerFrequency, AKParameter bandwidth);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("filterWithInput:")]
		AKBandPassButterworthFilter FromInput (AKParameter input);

		[Export ("centerFrequency")]
		AKParameter CenterFrequency { get; [Bind ("setOptionalCenterFrequency:")] set; }

		[Export ("bandwidth")]
		AKParameter Bandwidth { get; [Bind ("setOptionalBandwidth:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKBandRejectButterworthFilter {

		[Export ("initWithInput:centerFrequency:bandwidth:")]
		IntPtr Constructor (AKParameter input, AKParameter centerFrequency, AKParameter bandwidth);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("filterWithInput:")]
		AKBandRejectButterworthFilter FromInput (AKParameter input);

		[Export ("centerFrequency")]
		AKParameter CenterFrequency { get; [Bind ("setOptionalCenterFrequency:")] set; }

		[Export ("bandwidth")]
		AKParameter Bandwidth { get; [Bind ("setOptionalBandwidth:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKHighPassButterworthFilter {

		[Export ("initWithInput:cutoffFrequency:")]
		IntPtr Constructor (AKParameter input, AKParameter cutoffFrequency);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("filterWithInput:")]
		AKHighPassButterworthFilter FromInput (AKParameter input);

		[Export ("cutoffFrequency")]
		AKParameter CutoffFrequency { get; [Bind ("setOptionalCutoffFrequency:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKLowPassButterworthFilter {

		[Export ("initWithInput:cutoffFrequency:")]
		IntPtr Constructor (AKParameter input, AKParameter cutoffFrequency);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("filterWithInput:")]
		AKLowPassButterworthFilter FromInput (AKParameter input);

		[Export ("cutoffFrequency")]
		AKParameter CutoffFrequency { get; [Bind ("setOptionalCutoffFrequency:")] set; }

		[Export ("setOptionalCutoffFrequency:")]
		void SetOptionalCutoffFrequency (AKParameter cutoffFrequency);
	}

	#endregion


	#endregion


	#region Operations/Signal Modifiers/Reverbs

	[DisableDefaultCtor]
	[BaseType (typeof (AKStereoAudio))]
	interface AKBallWithinTheBoxReverb {

		[Export ("initWithInput:lengthOfXAxisEdge:lengthOfYAxisEdge:lengthOfZAxisEdge:xLocation:yLocation:zLocation:diffusion:")]
		IntPtr Constructor (AKParameter input, AKConstant lengthOfXAxisEdge, AKConstant lengthOfYAxisEdge, AKConstant lengthOfZAxisEdge, AKParameter xLocation, AKParameter yLocation, AKParameter zLocation, AKConstant diffusion);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("reverbWithInput:")]
		AKBallWithinTheBoxReverb FromInput (AKParameter input);

		[Export ("lengthOfXAxisEdge")]
		AKConstant LengthOfXAxisEdge { get; [Bind ("setOptionalLengthOfXAxisEdge:")] set; }

		[Export ("lengthOfYAxisEdge")]
		AKConstant LengthOfYAxisEdge { get; [Bind ("setOptionalLengthOfYAxisEdge:")] set; }

		[Export ("lengthOfZAxisEdge")]
		AKConstant LengthOfZAxisEdge { get; [Bind ("setOptionalLengthOfZAxisEdge:")] set; }

		[Export ("xLocation")]
		AKParameter XLocation { get; [Bind ("setOptionalXLocation:")] set; }

		[Export ("yLocation")]
		AKParameter YLocation { get; [Bind ("setOptionalYLocation:")] set; }

		[Export ("zLocation")]
		AKParameter ZLocation { get; [Bind ("setOptionalZLocation:")] set; }

		[Export ("diffusion")]
		AKConstant Diffusion { get; [Bind ("setOptionalDiffusion:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKFlatFrequencyResponseReverb {

		[Export ("initWithInput:reverbDuration:loopDuration:")]
		IntPtr Constructor (AKParameter input, AKParameter reverbDuration, AKConstant loopDuration);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("reverbWithInput:")]
		AKFlatFrequencyResponseReverb FromInput (AKParameter input);

		// @property AKParameter * reverbDuration;
		[Export ("reverbDuration")]
		AKParameter ReverbDuration { get; [Bind ("setOptionalReverbDuration:")] set; }

		// @property AKConstant * loopDuration;
		[Export ("loopDuration")]
		AKConstant LoopDuration { get; [Bind ("setOptionalLoopDuration:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKParallelCombLowPassFilterReverb {

		[Export ("initWithInput:duration:highFrequencyDiffusivity:")]
		IntPtr Constructor (AKParameter input, AKParameter duration, AKParameter highFrequencyDiffusivity);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("reverbWithInput:")]
		AKParallelCombLowPassFilterReverb FromInput (AKParameter input);

		// @property AKParameter * duration;
		[Export ("duration")]
		AKParameter Duration { get; [Bind ("setOptionalDuration:")] set; }

		// @property AKParameter * highFrequencyDiffusivity;
		[Export ("highFrequencyDiffusivity")]
		AKParameter HighFrequencyDiffusivity { get; [Bind ("setOptionalHighFrequencyDiffusivity:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKStereoAudio))]
	interface AKReverb {

		[Export ("initWithInput:feedback:cutoffFrequency:")]
		IntPtr Constructor (AKParameter input, AKParameter feedback, AKParameter cutoffFrequency);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("reverbWithInput:")]
		AKReverb FromInput (AKParameter input);

		[Export ("initWithStereoInput:feedback:cutoffFrequency:")]
		IntPtr Constructor (AKStereoAudio input, AKParameter feedback, AKParameter cutoffFrequency);

		[Export ("initWithStereoInput:")]
		IntPtr Constructor (AKStereoAudio input);

		[Static]
		[Export ("reverbWithStereoInput:")]
		AKReverb FromStereoInput (AKStereoAudio input);

		[Export ("feedback")]
		AKParameter Feedback { get; [Bind ("setOptionalFeedback:")] set; }

		[Export ("cutoffFrequency")]
		AKParameter CutoffFrequency { get; [Bind ("setOptionalCutoffFrequency:")] set; }
	}

	#endregion


	#region Operations/Signal Modifiers/Volume and Spatialization

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKBalance {

		[Export ("initWithInput:comparatorAudioSource:halfPowerPoint:")]
		IntPtr Constructor (AKParameter input, AKParameter comparatorAudioSource, AKConstant halfPowerPoint);

		[Export ("initWithInput:comparatorAudioSource:")]
		IntPtr Constructor (AKParameter input, AKParameter comparatorAudioSource);

		[Static]
		[Export ("balanceWithInput:comparatorAudioSource:")]
		AKBalance BalanceWithInput (AKParameter input, AKParameter comparatorAudioSource);

		[Export ("halfPowerPoint")]
		AKConstant HalfPowerPoint { get; [Bind ("setOptionalHalfPowerPoint:")] set; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKAudio))]
	interface AKMix {

		[Export ("initWithInput1:input2:balance:")]
		IntPtr Constructor (AKParameter input1, AKParameter input2, AKParameter balancePoint);

		[Export ("setMinimumBalancePoint:")]
		void SetMinimumBalancePoint (AKConstant minimumBalancePoint);

		[Export ("setMaximumBalancePoint:")]
		void SetMaximumBalancePoint (AKConstant maximumBalancePoint);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (AKStereoAudio))]
	interface AKPanner {

		[Static]
		[Export ("panMethodForEqualPower")]
		AKConstant PanMethodForEqualPower { get; }

		[Static]
		[Export ("panMethodForSquareRoot")]
		AKConstant PanMethodForSquareRoot { get; }

		[Static]
		[Export ("panMethodForLinear")]
		AKConstant PanMethodForLinear { get; }

		[Static]
		[Export ("panMethodForEqualPowerAlternate")]
		AKConstant PanMethodForEqualPowerAlternate { get; }

		[Export ("initWithInput:pan:panMethod:")]
		IntPtr Constructor (AKParameter input, AKParameter pan, AKConstant panMethod);

		[Export ("initWithInput:")]
		IntPtr Constructor (AKParameter input);

		[Static]
		[Export ("pannerWithInput:")]
		AKPanner FromInput (AKParameter input);

		[Export ("pan")]
		AKParameter Pan { get; [Bind ("setOptionalPan:")] set; }

		[Export ("panMethod")]
		AKConstant PanMethod { get; [Bind ("setOptionalPanMethod:")] set; }
	}

	#endregion


	#endregion


	#endregion


	#region Parameters

	[BaseType (typeof (NSObject))]
	interface AKArray {

		[Export ("parameterString")]
		string ParameterString { get; }

		// TODO: Check NSMutableArray
		[Export ("constants")]
		NSMutableArray Constants { get; set; }

		[Export ("addConstant:")]
		void AddConstant (AKConstant constant);

		[Internal]
		[Static]
		[Export ("arrayFromConstants:", IsVariadic = true)]
		AKArray _ArrayFromConstants (AKConstant firstConstant, IntPtr nextConstants);

		[Internal]
		[Static]
		[Export ("arrayFromNumbers:", IsVariadic = true)]
		AKArray _ArrayFromNumbers (NSNumber firstValue, IntPtr nextValues);

		[Export ("count")]
		int Count ();

		[Export ("pairWith:")]
		AKArray PairWith (AKArray pairingArray);
	}

	[BaseType (typeof (AKParameter))]
	interface AKAudio {

		[Export ("initWithString:")]
		IntPtr Constructor (string name);

		[Internal]
		[New]
		[Export ("initWithExpression:")]
		IntPtr ExpressionConstructor (string expression);

		[Export ("initWithValue:")]
		IntPtr Constructor (float initialValue);

		[Export ("initWithMinimum:maximum:")]
		IntPtr Constructor (float minimum, float maximum);

		[Export ("initWithValue:minimum:maximum:")]
		IntPtr Constructor (float initialValue, float minimum, float maximum);
	}

	[BaseType (typeof (AKControl))]
	interface AKConstant {

		[Export ("initWithString:")]
		IntPtr Constructor (string name);

		[Internal]
		[New]
		[Export ("initWithExpression:")]
		IntPtr ExpressionConstructor (string expression);

		[Export ("initWithMinimum:maximum:")]
		IntPtr Constructor (float minimum, float maximum);

		[Export ("initWithValue:minimum:maximum:")]
		IntPtr Constructor (float initialValue, float minimum, float maximum);

		[Static]
		[Export ("constantWithFloat:")]
		AKConstant FromFloat (float value);

		[Static]
		[Export ("constantWithNumber:")]
		AKConstant FromNumber (NSNumber number);

		[Static]
		[Export ("constantWithInt:")]
		AKConstant FromInt (int value);

		[Static]
		[Export ("constantWithFilename:")]
		AKConstant FromFilename (string filename);

		[Static]
		[Export ("constantWithControl:")]
		AKConstant FromControl (AKControl control);

		[Export ("initWithValue:")]
		IntPtr Constructor (NSNumber value);
	}

	[BaseType (typeof (AKAudio))]
	interface AKControl {

		[Export ("toCPS")]
		AKControl ToCPS ();

		[Export ("initWithString:")]
		IntPtr Constructor (string name);

		[Internal]
		[New]
		[Export ("initWithExpression:")]
		IntPtr ExpressionConstructor (string expression);

		[Export ("initWithValue:")]
		IntPtr Constructor (float initialValue);

		[Export ("initWithMinimum:maximum:")]
		IntPtr Constructor (float minimum, float maximum);

		[Export ("initWithValue:minimum:maximum:")]
		IntPtr Constructor (float initialValue, float minimum, float maximum);
	}

	[BaseType (typeof (AKParameter))]
	interface AKFSignal {

		[Export ("initWithString:")]
		IntPtr Constructor (string aString);

		[Internal]
		[New]
		[Export ("initWithExpression:")]
		IntPtr ExpressionConstructor (string expression);

		[Export ("initWithValue:")]
		IntPtr Constructor (float initialValue);

		[Export ("initWithMinimum:maximum:")]
		IntPtr Constructor (float minimum, float maximum);

		[Export ("initWithValue:minimum:maximum:")]
		IntPtr Constructor (float initialValue, float minimum, float maximum);
	}

	[BaseType (typeof (NSObject))]
	interface AKParameter {

		[Export ("parameterString")]
		string ParameterString { get; set; }

		[Static]
		[Export ("parameterWithString:")]
		AKParameter WithString (string name);

		[Static]
		[Export ("globalParameter")]
		AKParameter GlobalParameter ();

		[Static]
		[Export ("globalParameterWithString:")]
		AKParameter GlobalParameter (string name);

		// TODO: Test method
		[Internal]
		[Static]
		[Export ("parameterWithFormat:", IsVariadic = true)]
		AKParameter _WithFormat (string firstFormat, IntPtr nextFormats);

		[Export ("initWithString:")]
		IntPtr Constructor (string name);

		[Internal]
		[Export ("initWithExpression:")]
		IntPtr ExpressionConstructor (string expression);

		[Static]
		[Export ("resetID")]
		void ResetID ();

		[Export ("value", ArgumentSemantic.Assign)]
		float Value { get; set; }

		[Export ("initialValue", ArgumentSemantic.Assign)]
		float InitialValue { get; set; }

		[Export ("minimum", ArgumentSemantic.Assign)]
		float Minimum { get; set; }

		[Export ("maximum", ArgumentSemantic.Assign)]
		float Maximum { get; set; }

		[Export ("initWithValue:")]
		IntPtr Constructor (float initialValue);

		[Export ("initWithMinimum:maximum:")]
		IntPtr Constructor (float minimum, float maximum);

		[Export ("initWithValue:minimum:maximum:")]
		IntPtr Constructor (float initialValue, float minimum, float maximum);

		[Export ("scaleWithValue:minimum:maximum:")]
		void ScaleWithValue (float value, float minimum, float maximum);

		[Export ("reset")]
		void Reset ();

		[Export ("randomize")]
		void Randomize ();

		[Export ("plus:")]
		AKParameter Plus (AKParameter additionalParameter);

		[Export ("minus:")]
		AKParameter Minus (AKParameter subtractedParameter);

		[Export ("scaledBy:")]
		AKParameter ScaledBy (AKParameter scalingFactor);

		[Export ("dividedBy:")]
		AKParameter DividedBy (AKParameter divisor);

		[Export ("inverse")]
		AKParameter Inverse { get; }

		[Export ("floor")]
		AKParameter Floor { get; }

		[Export ("round")]
		AKParameter Round { get; }

		[Export ("fractionalPart")]
		AKParameter FractionalPart { get; }

		[Export ("absoluteValue")]
		AKParameter AbsoluteValue { get; }

		[Export ("log")]
		AKParameter Log { get; }

		[Export ("log10")]
		AKParameter Log10 { get; }

		[Export ("squareRoot")]
		AKParameter SquareRoot { get; }

		[Export ("amplitudeFromFullScaleDecibel")]
		AKParameter AmplitudeFromFullScaleDecibel { get; }
	}

	[BaseType (typeof (AKParameter))]
	interface AKStereoAudio {

		[Internal]
		[New]
		[Export ("initWithExpression:")]
		IntPtr ExpressionConstructor (string expression);

		[Export ("initWithValue:")]
		IntPtr Constructor (float initialValue);

		[Export ("initWithMinimum:maximum:")]
		IntPtr Constructor (float minimum, float maximum);

		[Export ("initWithValue:minimum:maximum:")]
		IntPtr Constructor (float initialValue, float minimum, float maximum);

		[Export ("leftOutput")]
		AKParameter LeftOutput { get; set; }

		[Export ("rightOutput")]
		AKParameter RightOutput { get; set; }

		[Export ("initWithLeftAudio:rightAudio:")]
		IntPtr Constructor (AKParameter leftAudio, AKParameter rightAudio);

		[Static]
		[New]
		[Export ("resetID")]
		void ResetID ();

		[Static]
		[Export ("stereoFromMono:")]
		AKStereoAudio StereoFromMono (AKParameter mono);

		[Static]
		[New]
		[Export ("globalParameter")]
		AKStereoAudio GlobalParameter ();

		[Static]
		[New]
		[Export ("globalParameterWithString:")]
		AKStereoAudio GlobalParameter (string name);

		[New]
		[Export ("scaledBy:")]
		AKStereoAudio ScaledBy (AKParameter scalingFactor);
	}


	#region Parameters/Properties

	[BaseType (typeof (AKControl))]
	interface AKInstrumentProperty {

		[Export ("initWithString:")]
		IntPtr Constructor (string name);

		[Internal]
		[New]
		[Export ("initWithExpression:")]
		IntPtr ExpressionConstructor (string expression);

		[Export ("initWithValue:")]
		IntPtr Constructor (float initialValue);

		[Export ("initWithMinimum:maximum:")]
		IntPtr Constructor (float minimum, float maximum);

		[Export ("initWithValue:minimum:maximum:")]
		IntPtr Constructor (float initialValue, float minimum, float maximum);

		[Export ("name")]
		string Name { get; set; }

		[Export ("stringForCSDGetValue")]
		string CSDGetValue { get; }

		[Export ("stringForCSDSetValue")]
		string CSDSetValue { get; }
	}

	[BaseType (typeof (AKConstant))]
	interface AKNoteProperty {

		[Export ("initWithString:")]
		IntPtr Constructor (string name);

		[Internal]
		[New]
		[Export ("initWithExpression:")]
		IntPtr ExpressionConstructor (string expression);

		[Export ("initWithValue:")]
		IntPtr Constructor (float initialValue);

		[Export ("initWithMinimum:maximum:")]
		IntPtr Constructor (float minimum, float maximum);

		[Export ("initWithValue:minimum:maximum:")]
		IntPtr Constructor (float initialValue, float minimum, float maximum);

		[Export ("name")]
		string Name { get; set; }

		[Export ("note")]
		AKNote Note { get; set; }

		[Export ("pValue", ArgumentSemantic.Assign)]
		int PValue { get; set; }

		[Export ("setValue:afterDelay:")]
		void SetValue (float floatValue, float delay);

		[Static]
		[Export ("duration")]
		AKNoteProperty Duration { get; }
	}

	#endregion

	#endregion


	#region Utilities

	[BaseType (typeof (AKInstrument))]
	interface AKAudioAnalyzer {

		[Export ("trackedFrequency")]
		AKInstrumentProperty TrackedFrequency { get; set; }

		[Export ("trackedAmplitude")]
		AKInstrumentProperty TrackedAmplitude { get; set; }

		[Export ("initWithAudioSource:")]
		IntPtr Constructor (AKParameter audioSource);
	}

	[BaseType (typeof (UIView))]
	interface LevelMeter {

		[Export ("level")]
		nfloat Level { get; set; }

		[Export ("peakLevel")]
		nfloat PeakLevel { get; set; }

		[Export ("numLights")]
		nuint NumLights { get; set; }

		[Export ("vertical")]
		bool Vertical { [Bind ("isVertical")] get; set; }

		[Export ("variableLightIntensity")]
		bool VariableLightIntensity { get; set; }

		[Export ("bgColor", ArgumentSemantic.Retain)]
		UIColor LightsBackgroundColor { get; set; }

		[Export ("borderColor", ArgumentSemantic.Retain)]
		UIColor LightsBorderColor { get; set; }
	}

	#endregion
}