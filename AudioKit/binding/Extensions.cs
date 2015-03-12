using System;
using System.Runtime.InteropServices;

#if __UNIFIED__
using ObjCRuntime;
using Foundation;
using UIKit;
#else
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif

namespace AudioKit
{

	#region Libraries/iOS

	public partial class AKTools
	{
		public static void ScaleProperty (AKInstrumentProperty property, float scalingFactor)
		{
			_ScaleProperty (property, scalingFactor); 
		}

		public static void ScaleProperty (AKNoteProperty property, float scalingFactor)
		{
			_ScaleProperty (property, scalingFactor); 
		}

		public static void InverseScaleProperty (AKInstrumentProperty property, float scalingFactor)
		{
			_InverseScaleProperty (property, scalingFactor); 
		}

		public static void InverseScaleProperty (AKNoteProperty property, float scalingFactor)
		{
			_InverseScaleProperty (property, scalingFactor); 
		}

		public static void SetSlider (UISlider slider, AKInstrumentProperty property)
		{
			_SetSlider (slider, property);
		}

		public static void SetSlider (UISlider slider, AKNoteProperty property)
		{
			_SetSlider (slider, property);
		}

		public static void SetProgressView (UIProgressView progressView, AKInstrumentProperty property)
		{
			_SetProgressView (progressView, property);
		}

		public static void SetProgressView (UIProgressView progressView, AKNoteProperty property)
		{
			_SetProgressView (progressView, property);
		}

		public static void SetProperty (AKInstrumentProperty property, UISlider slider)
		{
			_SetProperty (property, slider);
		}

		public static void SetProperty (AKNoteProperty property, UISlider slider)
		{
			_SetProperty (property, slider);
		}

		public static void SetTextField (UITextField textfield, AKInstrumentProperty property)
		{
			_SetTextField (textfield, property);
		}

		public static void SetTextField (UITextField textfield, AKNoteProperty property)
		{
			_SetTextField (textfield, property);
		}

		public static void SetLabel (UILabel label, AKInstrumentProperty property)
		{
			_SetLabel (label, property);
		}

		public static void SetLabel (UILabel label, AKNoteProperty property)
		{
			_SetLabel (label, property);
		}
	}

	#endregion


	#region Operations


	#region Operations/Function Tables


	#region Operations/Function Tables/Generators

	public partial class AKSoundFile
	{
		public static AKSoundFile FromFilename (string filename)
		{
			if (filename == null)
				filename = string.Empty;

			return new AKSoundFile (filename);
		}

		public static AKSoundFile FromMonoLeftChannel (string filename)
		{
			if (filename == null)
				filename = string.Empty;

			IntPtr pConstructor = new AKSoundFile (filename).MonoLeftChannelConstructor (filename);
			return pConstructor == IntPtr.Zero ? null : Runtime.GetNSObject<AKSoundFile> (pConstructor);
		}

		public static AKSoundFile FromMonoRightChannel (string filename)
		{
			if (filename == null)
				filename = string.Empty;

			IntPtr pConstructor = new AKSoundFile (filename).MonoRightChannelConstructor (filename);
			return pConstructor == IntPtr.Zero ? null : Runtime.GetNSObject<AKSoundFile> (pConstructor);
		}
	}

	#endregion


	#endregion


	#region Operations/Mathematical Operations

//	public partial class AKMaximum
//	{
//		public static AKMaximum FromInputs (params AKParameter[] inputs)
//		{
//			if (inputs == null)
//				throw new ArgumentNullException ("inputs");
//
//			var pInputsArray = Marshal.AllocHGlobal (inputs.Length * IntPtr.Size);
//			for (int i = 1; i < inputs.Length; i++) {
//				IntPtr inputPtr = Marshal.AllocHGlobal (Marshal.SizeOf<AKParameter> (inputs [i]));
//				Marshal.StructureToPtr<AKParameter> (inputs [i], inputPtr, false);
//				Marshal.WriteIntPtr (pInputsArray, (i - 1) * IntPtr.Size, inputPtr);
//
//				Marshal.FreeHGlobal (inputPtr);
//			}
//
//			Marshal.WriteIntPtr (pInputsArray, (inputs.Length - 1) * IntPtr.Size, IntPtr.Zero);
//			var result = new AKMaximum (inputs[0], pInputsArray);
//			Marshal.FreeHGlobal (pInputsArray);
//
//			return result;
//		}
//
//		public static AKMaximum FromInputs (AKParameter firstInput, AKParameter secondInput)
//		{
//			return new AKMaximum (firstInput, secondInput);
//		}
//	}

//	public partial class AKMinimum
//	{
//		public static AKMinimum FromInputs (params AKParameter[] inputs)
//		{
//			if (inputs == null)
//				throw new ArgumentNullException ("inputs");
//
//			var pInputsArray = Marshal.AllocHGlobal (inputs.Length * IntPtr.Size);
//			for (int i = 1; i < inputs.Length; i++) {
//				IntPtr inputPtr = Marshal.AllocHGlobal (Marshal.SizeOf<AKParameter> (inputs [i]));
//				Marshal.StructureToPtr<AKParameter> (inputs [i], inputPtr, false);
//				Marshal.WriteIntPtr (pInputsArray, (i - 1) * IntPtr.Size, inputPtr);
//
//				Marshal.FreeHGlobal (inputPtr);
//			}
//
//			Marshal.WriteIntPtr (pInputsArray, (inputs.Length - 1) * IntPtr.Size, IntPtr.Zero);
//			var result = new AKMinimum (inputs[0], pInputsArray);
//			Marshal.FreeHGlobal (pInputsArray);
//
//			return result;
//		}
//
//		public static AKMinimum FromInputs (AKParameter firstInput, AKParameter secondInput)
//		{
//			return new AKMinimum (firstInput, secondInput);
//		}
//	}

	public partial class AKMultipleInputMathOperation
	{
		public static AKMultipleInputMathOperation GetInstance ()
		{
			return new AKMultipleInputMathOperation ();
		}

		public static AKMultipleInputMathOperation FromInputs (params AKParameter[] inputs)
		{
			if (inputs == null)
				throw new ArgumentNullException ("inputs");

			var pInputsArray = Marshal.AllocHGlobal (inputs.Length * IntPtr.Size);
			for (int i = 1; i < inputs.Length; i++) {
				IntPtr inputPtr = Marshal.AllocHGlobal (Marshal.SizeOf<AKParameter> (inputs [i]));
				Marshal.StructureToPtr<AKParameter> (inputs [i], inputPtr, false);
				Marshal.WriteIntPtr (pInputsArray, (i - 1) * IntPtr.Size, inputPtr);

				Marshal.FreeHGlobal (inputPtr);
			}

			Marshal.WriteIntPtr (pInputsArray, (inputs.Length - 1) * IntPtr.Size, IntPtr.Zero);
			var result = new AKMultipleInputMathOperation (inputs[0], pInputsArray);
			Marshal.FreeHGlobal (pInputsArray);

			return result;
		}

		public static AKMultipleInputMathOperation FromInputs (AKParameter firstInput, AKParameter secondInput)
		{
			return new AKMultipleInputMathOperation (firstInput, secondInput);
		}
	}

//	public partial class AKProduct
//	{
//		public static AKProduct FromInputs (params AKParameter[] inputs)
//		{
//			if (inputs == null)
//				throw new ArgumentNullException ("inputs");
//
//			var pInputsArray = Marshal.AllocHGlobal (inputs.Length * IntPtr.Size);
//			for (int i = 1; i < inputs.Length; i++) {
//				IntPtr inputPtr = Marshal.AllocHGlobal (Marshal.SizeOf<AKParameter> (inputs [i]));
//				Marshal.StructureToPtr<AKParameter> (inputs [i], inputPtr, false);
//				Marshal.WriteIntPtr (pInputsArray, (i - 1) * IntPtr.Size, inputPtr);
//
//				Marshal.FreeHGlobal (inputPtr);
//			}
//
//			Marshal.WriteIntPtr (pInputsArray, (inputs.Length - 1) * IntPtr.Size, IntPtr.Zero);
//			var result = new AKProduct (inputs[0], pInputsArray);
//			Marshal.FreeHGlobal (pInputsArray);
//
//			return result;
//		}
//
//		public static AKProduct FromInputs (AKParameter firstInput, AKParameter secondInput)
//		{
//			return new AKProduct (firstInput, secondInput);
//		}
//	}

//	public partial class AKSum
//	{
//		public static AKSum FromInputs (params AKParameter[] inputs)
//		{
//			if (inputs == null)
//				throw new ArgumentNullException ("inputs");
//
//			var pInputsArray = Marshal.AllocHGlobal (inputs.Length * IntPtr.Size);
//			for (int i = 1; i < inputs.Length; i++) {
//				IntPtr inputPtr = Marshal.AllocHGlobal (Marshal.SizeOf<AKParameter> (inputs [i]));
//				Marshal.StructureToPtr<AKParameter> (inputs [i], inputPtr, false);
//				Marshal.WriteIntPtr (pInputsArray, (i - 1) * IntPtr.Size, inputPtr);
//
//				Marshal.FreeHGlobal (inputPtr);
//			}
//
//			Marshal.WriteIntPtr (pInputsArray, (inputs.Length - 1) * IntPtr.Size, IntPtr.Zero);
//			var result = new AKSum (inputs[0], pInputsArray);
//			Marshal.FreeHGlobal (pInputsArray);
//
//			return result;
//		}
//
//		public static AKSum FromInputs (AKParameter firstInput, AKParameter secondInput)
//		{
//			return new AKSum (firstInput, secondInput);
//		}
//	}

	#endregion


	#region Operations/Signal Input and Output

	public partial class AKAudioOutput
	{
		public static AKAudioOutput FromInput (AKParameter source)
		{
			if (source == null)
				throw new ArgumentNullException ("source");

			IntPtr pConstructor = new AKAudioOutput ().FromInputConstructor (source);
			return pConstructor == IntPtr.Zero ? null : Runtime.GetNSObject<AKAudioOutput> (pConstructor);
		}

		public static AKAudioOutput FromAudioSource (AKParameter audioSource)
		{
			if (audioSource == null)
				throw new ArgumentNullException ("source");

			IntPtr pConstructor = new AKAudioOutput ().FromAudioSourceConstructor (audioSource);
			return pConstructor == IntPtr.Zero ? null : Runtime.GetNSObject<AKAudioOutput> (pConstructor);
		}

		public static AKAudioOutput FromStereoAudioSource (AKStereoAudio stereoAudio)
		{
			if (stereoAudio == null)
				throw new ArgumentNullException ("source");

			IntPtr pConstructor = new AKAudioOutput ().FromStereoAudioSourceConstructor (stereoAudio);
			return pConstructor == IntPtr.Zero ? null : Runtime.GetNSObject<AKAudioOutput> (pConstructor);
		}

		public static AKAudioOutput FromChannels (AKParameter leftAudio, AKParameter rightAudio)
		{
			if (leftAudio == null)
				throw new ArgumentNullException ("leftAudio");

			if (rightAudio == null)
				throw new ArgumentNullException ("rightAudio");

			IntPtr pConstructor = new AKAudioOutput ().FromChannelsConstructor (leftAudio, rightAudio);
			return pConstructor == IntPtr.Zero ? null : Runtime.GetNSObject<AKAudioOutput> (pConstructor);
		}
	}

	#endregion


	#endregion


	#region Parameters

	public partial class AKArray
	{
		public static AKArray ArrayFromConstants (params AKConstant [] constants)
		{
			if (constants == null)
				throw new ArgumentNullException ("constants");

			var pConstantsArray = Marshal.AllocHGlobal (constants.Length * IntPtr.Size);
			for (int i = 1; i < constants.Length; i++) {
				IntPtr constantPtr = Marshal.AllocHGlobal (Marshal.SizeOf<AKConstant> (constants [i]));
				Marshal.StructureToPtr<AKConstant> (constants [i], constantPtr, false);
				Marshal.WriteIntPtr (pConstantsArray, (i - 1) * IntPtr.Size, constantPtr);

				Marshal.FreeHGlobal (constantPtr);
			}

			Marshal.WriteIntPtr (pConstantsArray, (constants.Length - 1) * IntPtr.Size, IntPtr.Zero);
			var result = _ArrayFromConstants (constants[0], pConstantsArray);
			Marshal.FreeHGlobal (pConstantsArray);

			return result;
		}

		public static AKArray ArrayFromNumbers (params NSNumber [] numbers)
		{
			if (numbers == null)
				throw new ArgumentNullException ("numbers");

			var pConstantsArray = Marshal.AllocHGlobal (numbers.Length * IntPtr.Size);
			for (int i = 1; i < numbers.Length; i++) {
				IntPtr constantPtr = Marshal.AllocHGlobal (Marshal.SizeOf<NSNumber> (numbers [i]));
				Marshal.StructureToPtr<NSNumber> (numbers [i], constantPtr, false);
				Marshal.WriteIntPtr (pConstantsArray, (i - 1) * IntPtr.Size, constantPtr);

				Marshal.FreeHGlobal (constantPtr);
			}

			Marshal.WriteIntPtr (pConstantsArray, (numbers.Length - 1) * IntPtr.Size, IntPtr.Zero);
			var result = _ArrayFromNumbers (numbers[0], pConstantsArray);
			Marshal.FreeHGlobal (pConstantsArray);

			return result;
		}
	}

//	public partial class AKAudio
//	{
//		public static AKAudio FromExpression (string expression)
//		{
//			if (expression == null)
//				expression = string.Empty;
//
//			IntPtr pConstructor = new AKAudio ().ExpressionConstructor (expression);
//			return pConstructor == IntPtr.Zero ? null : Runtime.GetNSObject<AKAudio> (pConstructor);
//		}
//	}
//
//	public partial class AKConstant
//	{
//		public static AKConstant FromExpression (string expression)
//		{
//			if (expression == null)
//				expression = string.Empty;
//
//			IntPtr pConstructor = new AKConstant ().ExpressionConstructor (expression);
//			return pConstructor == IntPtr.Zero ? null : Runtime.GetNSObject<AKConstant> (pConstructor);
//		}
//	}
//
//	public partial class AKControl
//	{
//		public static AKControl FromExpression (string expression)
//		{
//			if (expression == null)
//				expression = string.Empty;
//
//			IntPtr pConstructor = new AKControl ().ExpressionConstructor (expression);
//			return pConstructor == IntPtr.Zero ? null : Runtime.GetNSObject<AKControl> (pConstructor);
//		}
//	}
//
//	public partial class AKFSignal
//	{
//		public static AKFSignal FromExpression (string expression)
//		{
//			if (expression == null)
//				expression = string.Empty;
//
//			IntPtr pConstructor = new AKFSignal ().ExpressionConstructor (expression);
//			return pConstructor == IntPtr.Zero ? null : Runtime.GetNSObject<AKFSignal> (pConstructor);
//		}
//	}

	public partial class AKParameter
	{
		public static AKParameter WithFormat (params string [] formats)
		{
			if (formats == null)
				throw new ArgumentNullException ("formats");

			var pFormatsArray = Marshal.AllocHGlobal (formats.Length * IntPtr.Size);
			for (int i = 1; i < formats.Length; i++) {
				IntPtr formatPtr = Marshal.AllocHGlobal (Marshal.SizeOf<string> (formats [i]));
				Marshal.StructureToPtr<string> (formats [i], formatPtr, false);
				Marshal.WriteIntPtr (pFormatsArray, (i - 1) * IntPtr.Size, formatPtr);

				Marshal.FreeHGlobal (formatPtr);
			}

			Marshal.WriteIntPtr (pFormatsArray, (formats.Length - 1) * IntPtr.Size, IntPtr.Zero);
			var result = _WithFormat (formats[0], pFormatsArray);
			Marshal.FreeHGlobal (pFormatsArray);

			return result;
		}

		public static AKParameter FromExpression (string expression)
		{
			if (expression == null)
				expression = string.Empty;

			IntPtr pConstructor = new AKParameter ().ExpressionConstructor (expression);
			return pConstructor == IntPtr.Zero ? null : Runtime.GetNSObject<AKParameter> (pConstructor);
		}
	}

//	public partial class AKStereoAudio
//	{
//		public static AKStereoAudio FromExpression (string expression)
//		{
//			if (expression == null)
//				expression = string.Empty;
//
//			IntPtr pConstructor = new AKStereoAudio ().ExpressionConstructor (expression);
//			return pConstructor == IntPtr.Zero ? null : Runtime.GetNSObject<AKStereoAudio> (pConstructor);
//		}
//	}


	#region Parameters/Properties

//	public partial class AKInstrumentProperty
//	{
//		public static AKInstrumentProperty FromExpression (string expression)
//		{
//			if (expression == null)
//				expression = string.Empty;
//
//			IntPtr pConstructor = new AKInstrumentProperty ().ExpressionConstructor (expression);
//			return pConstructor == IntPtr.Zero ? null : Runtime.GetNSObject<AKInstrumentProperty> (pConstructor);
//		}
//	}
//
//	public partial class AKNoteProperty
//	{
//		public static AKNoteProperty FromExpression (string expression)
//		{
//			if (expression == null)
//				expression = string.Empty;
//
//			IntPtr pConstructor = new AKNoteProperty ().ExpressionConstructor (expression);
//			return pConstructor == IntPtr.Zero ? null : Runtime.GetNSObject<AKNoteProperty> (pConstructor);
//		}
//	}

	#endregion

	#endregion
}

