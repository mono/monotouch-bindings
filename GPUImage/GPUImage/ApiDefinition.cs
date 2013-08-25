using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using MonoTouch.CoreMedia;
using MonoTouch.AVFoundation;

namespace GPUImage
{
	[BaseType(typeof(NSObject))]
	[Model]
	public interface GPUImageTextureDelegate
	{
		[Export("textureNoLongerNeededForTarget:")]
		void TextureNoLongerNeededForTarget(GPUImageInput textureTarget);
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface GPUImageVideoCameraDelegate {

		[Export ("willOutputSampleBuffer:")]
		void WillOutputSampleBuffer(CMSampleBuffer sampleBuffer);
	}

	[BaseType (typeof (GPUImageOutput))]
	public partial interface GPUImageVideoCamera : AVCaptureVideoDataOutputSampleBufferDelegate, AVCaptureAudioDataOutputSampleBufferDelegate {

		[Export ("captureSession", ArgumentSemantic.Retain)]
		AVCaptureSession CaptureSession { get; }

		[Export ("captureSessionPreset", ArgumentSemantic.Copy)]
		string CaptureSessionPreset { get; set; }

		[Export ("frameRate")]
		int FrameRate { get; set; }

		[Export ("frontFacingCameraPresent")]
		bool FrontFacingCameraPresent { [Bind ("isFrontFacingCameraPresent")] get; }

		[Export ("backFacingCameraPresent")]
		bool BackFacingCameraPresent { [Bind ("isBackFacingCameraPresent")] get; }

		[Export ("runBenchmark")]
		bool RunBenchmark { get; set; }

		[Export ("inputCamera")]
		AVCaptureDevice InputCamera { get; }

		[Export ("outputImageOrientation")]
		UIInterfaceOrientation OutputImageOrientation { get; set; }

		[Export ("horizontallyMirrorFrontFacingCamera")]
		bool HorizontallyMirrorFrontFacingCamera { get; set; }

		[Export ("horizontallyMirrorRearFacingCamera")]
		bool HorizontallyMirrorRearFacingCamera { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		GPUImageVideoCameraDelegate Delegate { get; set; }

		[Export ("initWithSessionPreset:cameraPosition:")]
		IntPtr Constructor (string sessionPreset, AVCaptureDevicePosition cameraPosition);

		[Export ("removeInputsAndOutputs")]
		void RemoveInputsAndOutputs ();

		[Export ("startCameraCapture")]
		void StartCameraCapture ();

		[Export ("stopCameraCapture")]
		void StopCameraCapture ();

		[Export ("pauseCameraCapture")]
		void PauseCameraCapture ();

		[Export ("resumeCameraCapture")]
		void ResumeCameraCapture ();

		[Export ("processVideoSampleBuffer:")]
		void ProcessVideoSampleBuffer (CMSampleBuffer sampleBuffer);

		[Export ("processAudioSampleBuffer:")]
		void ProcessAudioSampleBuffer (CMSampleBuffer sampleBuffer);

//		Export ("cameraPosition"), Verify ("ObjC method massaged into getter property", "/Users/micha/Desktop/gpucamera/GPUImageVideoCamera.h", Line = 116)]
		[Export ("cameraPosition")]
		AVCaptureDevicePosition CameraPosition { get; }

//		[Export ("videoCaptureConnection"), Verify ("ObjC method massaged into getter property", "/Users/micha/Desktop/gpucamera/GPUImageVideoCamera.h", Line = 120)]
		[Export ("videoCaptureConnection")]
AVCaptureConnection VideoCaptureConnection { get; }

		[Export ("rotateCamera")]
		void RotateCamera ();

//		[Export ("averageFrameDurationDuringCapture"), Verify ("ObjC method massaged into getter property", "/Users/micha/Desktop/gpucamera/GPUImageVideoCamera.h", Line = 130)]
		[Export ("averageFrameDurationDuringCapture")]
		float AverageFrameDurationDuringCapture { get; }
	}

	[BaseType (typeof (GPUImageVideoCamera))]
	public partial interface GPUImageStillCamera {

		[Export ("jpegCompressionQuality")]
		float JpegCompressionQuality { get; set; }

		[Export ("currentCaptureMetadata")]
		NSDictionary CurrentCaptureMetadata { get; }

		[Export ("capturePhotoAsSampleBufferWithCompletionHandler:")]
		void CapturePhotoAsSampleBufferWithCompletionHandler (Delegate block);

		[Export ("capturePhotoAsImageProcessedUpToFilter:withCompletionHandler:")]
		void CapturePhotoAsImageProcessedUpToFilter (GPUImageOutput finalFilterInChain, Delegate block);

		[Export ("capturePhotoAsJPEGProcessedUpToFilter:withCompletionHandler:")]
		void CapturePhotoAsJPEGProcessedUpToFilter (GPUImageOutput finalFilterInChain, Delegate block);

		[Export ("capturePhotoAsPNGProcessedUpToFilter:withCompletionHandler:")]
		void CapturePhotoAsPNGProcessedUpToFilter (GPUImageOutput finalFilterInChain, Delegate block);
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface GPUImageVideoCameraDelegate {

		[Export ("willOutputSampleBuffer:")]
		void  (CMSampleBuffer sampleBuffer);
	}

	[BaseType (typeof (GPUImageOutput))]
	public partial interface GPUImageVideoCamera : AVCaptureVideoDataOutputSampleBufferDelegate, AVCaptureAudioDataOutputSampleBufferDelegate {

		[Export ("captureSession", ArgumentSemantic.Retain)]
		AVCaptureSession CaptureSession { get; }

		[Export ("captureSessionPreset", ArgumentSemantic.Copy)]
		string CaptureSessionPreset { get; set; }

		[Export ("frameRate")]
		int FrameRate { get; set; }

		[Export ("frontFacingCameraPresent")]
		bool FrontFacingCameraPresent { [Bind ("isFrontFacingCameraPresent")] get; }

		[Export ("backFacingCameraPresent")]
		bool BackFacingCameraPresent { [Bind ("isBackFacingCameraPresent")] get; }

		[Export ("runBenchmark")]
		bool RunBenchmark { get; set; }

		[Export ("inputCamera")]
		AVCaptureDevice InputCamera { get; }

		[Export ("outputImageOrientation")]
		UIInterfaceOrientation OutputImageOrientation { get; set; }

		[Export ("horizontallyMirrorFrontFacingCamera")]
		bool HorizontallyMirrorFrontFacingCamera { get; set; }

		[Export ("horizontallyMirrorRearFacingCamera")]
		bool HorizontallyMirrorRearFacingCamera { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		GPUImageVideoCameraDelegate Delegate { get; set; }

		[Export ("initWithSessionPreset:cameraPosition:")]
		IntPtr Constructor (string sessionPreset, AVCaptureDevicePosition cameraPosition);

		[Export ("removeInputsAndOutputs")]
		void RemoveInputsAndOutputs ();

		[Export ("startCameraCapture")]
		void StartCameraCapture ();

		[Export ("stopCameraCapture")]
		void StopCameraCapture ();

		[Export ("pauseCameraCapture")]
		void PauseCameraCapture ();

		[Export ("resumeCameraCapture")]
		void ResumeCameraCapture ();

		[Export ("processVideoSampleBuffer:")]
		void ProcessVideoSampleBuffer (CMSampleBuffer sampleBuffer);

		[Export ("processAudioSampleBuffer:")]
		void ProcessAudioSampleBuffer (CMSampleBuffer sampleBuffer);

//		[Export ("cameraPosition"), Verify ("ObjC method massaged into getter property", "/Users/micha/Desktop/gpucamera/GPUImageVideoCamera.h", Line = 116)]
		[Export ("cameraPosition")]
		AVCaptureDevicePosition CameraPosition { get; }

//		[Export ("videoCaptureConnection"), Verify ("ObjC method massaged into getter property", "/Users/micha/Desktop/gpucamera/GPUImageVideoCamera.h", Line = 120)]
		[Export ("videoCaptureConnection")]
		AVCaptureConnection VideoCaptureConnection { get; }

		[Export ("rotateCamera")]
		void RotateCamera ();

//		[Export ("averageFrameDurationDuringCapture"), Verify ("ObjC method massaged into getter property", "/Users/micha/Desktop/gpucamera/GPUImageVideoCamera.h", Line = 130)]
		[Export ("averageFrameDurationDuringCapture")]
		float AverageFrameDurationDuringCapture { get; }
	}
	
	[BaseType(typeof(NSObject))]
	[Model]
	public interface GPUImageInput
	{
		[Export("newFrameReadyAtTime:atIndex:")]
		void NewFrameReadyAtTime(CMTime frameTime, int textureIndex);

		[Export("setInputTexture:atIndex:")]
		void SetInputTexture(uint newInputTexture, int textureIndex);

		[Export("setTextureDelegate:atIndex:")]
		void SetTextureDelegate(GPUImageTextureDelegate newTextureDelegate, int textureIndex);

		[Export("nextAvailableTextureIndex")]
		int NextAvailableTextureIndex { get; }

		[Export("setInputSize:atIndex:")]
		void SetInputSize(SizeF newSize, int textureIndex);

		[Export("setInputRotation:atIndex:")]
		void SetInputRotation(GPUImageRotationMode newInputRotation, int textureIndex);

		[Export("maximumOutputSize")]
		SizeF MaximumOutputSize { get; }

		[Export("endProcessing")]
		void EndProcessing();

		[Export("shouldIgnoreUpdatesToThisTarget")]
		bool ShouldIgnoreUpdatesToThisTarget();

		//[Export("enabled")]
		//bool Enabled();

		[Export("conserveMemoryForNextFrame")]
		void ConserveMemoryForNextFrame();

		[Export("wantsMonochromeInput")]
		bool WantsMonochromeInput { get; }

		[Export("setCurrentlyReceivingMonochromeInput:")]
		void SetCurrentlyReceivingMonochromeInput(bool newValue);
	}
	
	[BaseType(typeof(UIView))]
	public interface GPUImageView : GPUImageInput
	{
		[Export("initWithFrame:")]
		IntPtr Constructor(RectangleF frame);

		[Export("fillMode")]
		GPUImageFillModeType FillMode { get; set; }

		[Export("sizeInPixels")]
		SizeF SizeInPixels { get; }

		[Export("enabled")]
		bool Enabled { get; set; }

		[Export("setBackgroundColorRed:green:blue:alpha:")]
		void SetBackgroundColor(float redComponent, float green, float blue, float alpha);
	}

	[BaseType(typeof(NSObject))]
	public interface GPUImageOpenGLESContext 
	{
		[Export("currentShaderProgram")]
		IntPtr CurrentShaderProgram  { get; set; }

		[Static, Export("contextKey")]
		void ContextKey();

		[Static, Export("sharedImageProcessingOpenGLESContext")]
		GPUImageOpenGLESContext SharedImageProcessingOpenGLESContext();

		[Static, Export("sharedOpenGLESQueue")]
		IntPtr SharedOpenGLESQueue();

		[Static, Export("useImageProcessingContext")]
		void UseImageProcessingContext();

		[Static, Export("setActiveShaderProgram:")]
		void SetActiveShaderProgram(IntPtr shaderProgram);

		[Static, Export("maximumTextureSizeForThisDevice")]
		int MaximumTextureSizeForThisDevice { get; }

		[Static, Export("maximumTextureUnitsForThisDevice")]
		int MaximumTextureUnitsForThisDevice { get; }

		[Static, Export("deviceSupportsOpenGLESExtension:")]
		bool DeviceSupportsOpenGLESExtension(string extension);

		[Static, Export("deviceSupportsRedTextures")]
		bool DeviceSupportsRedTextures { get; }
	
		[Static, Export("sizeThatFitsWithinATextureForSize:")]
		SizeF SizeThatFitsWithinATextureForSize(SizeF inputSize);

		[Export("presentBufferForDisplay")]
		void PresentBufferForDisplay();

		[Export("programForVertexShaderString:fragmentShaderString:")]
		IntPtr ProgramForVertexShaderString(string vertexShaderString, string fragmentShaderString);
		
		[Export("useSharegroup:")]
		void UseSharegroup(IntPtr sharegroup);
		
		// Manage fast texture upload
		[Static, Export("supportsFastTextureUpload")]
		bool SupportsFastTextureUpload { get; }
	}

	public delegate void FrameProcessingCompletionCB(GPUImageOutput source, CMTime time);

	[BaseType(typeof(NSObject))]
	public interface GPUImageOutput 
	{
		[Export("shouldSmoothlyScaleOutput")]
		bool ShouldSmoothlyScaleOutput { get; set; }

		[Export("shouldIgnoreUpdatesToThisTarget")]
		bool ShouldIgnoreUpdatesToThisTarget { get; set; }

		//[Export("audioEncodingTarget")]
		//@property(readwrite, nonatomic, retain) GPUImageMovieWriter *audioEncodingTarget { get; set; }

		//[Export("targetToIgnoreForUpdates")]
		//@property(readwrite, nonatomic, unsafe_unretained) id<GPUImageInput> targetToIgnoreForUpdates { get; set; }

		[Export("frameProcessingCompletionBlock", ArgumentSemantic.Copy)]
		FrameProcessingCompletionCB OnFrameProcessingComplete { get; set; }

		[Export("enabled")]
		bool Enabled { get; }

		[Export("setInputTextureForTarget:atIndex:")]
		void SetInputTextureForTarget(GPUImageInput target, int inputTextureIndex);

		[Export("textureForOutput")]
		int TextureForOutput { get; }

		[Export("notifyTargetsAboutNewOutputTexture")]
		void NotifyTargetsAboutNewOutputTexture();

		[Export("targets")]
		NSArray Targets { get; }

		[Export("addTarget:")]
		void AddTarget(NSObject newTarget);	// Todo should be GPUImageInput actually

		[Export("addTarget:atTextureLocation:")]
		void AddTarget(NSObject newTarget, int textureLocation);

		[Export("removeTarget:")]
		void RemoveTarget(NSObject targetToRemove);

		[Export("removeAllTargets")]
		void RemoveAllTargets();

		[Export("initializeOutputTextureIfNeeded")]
		void InitializeOutputTextureIfNeeded();

		[Export("deleteOutputTexture")]
		void DeleteOutputTexture();

		[Export("forceProcessingAtSize:")]
		void ForceProcessingAtSize(SizeF frameSize);

		[Export("forceProcessingAtSizeRespectingAspectRatio:")]
		void ForceProcessingAtSizeRespectingAspectRatio(SizeF frameSize);

		[Export("cleanupOutputImage")]
		void CleanupOutputImage();

		[Export("imageFromCurrentlyProcessedOutput")]
		UIImage ImageFromCurrentlyProcessedOutput();

		[Export("newCGImageFromCurrentlyProcessedOutput")]
		CGImage NewCGImageFromCurrentlyProcessedOutput();

		[Export("imageFromCurrentlyProcessedOutputWithOrientation:")]
		UIImage ImageFromCurrentlyProcessedOutputWithOrientation(UIImageOrientation imageOrientation);

		[Export("newCGImageFromCurrentlyProcessedOutputWithOrientation:")]
		CGImage NewCGImageFromCurrentlyProcessedOutputWithOrientation(UIImageOrientation imageOrientation);

		[Export("imageByFilteringImage:")]
		UIImage ImageByFilteringImage(UIImage imageToFilter);

		[Export("newCGImageByFilteringImage:")]
		CGImage NewCGImageByFilteringImage(UIImage imageToFilter);

		[Export("newCGImageByFilteringCGImage:")]
		CGImage NewCGImageByFilteringCGImage(CGImage imageToFilter);

		[Export("newCGImageByFilteringCGImage:orientation:")]
		CGImage NewCGImageByFilteringCGImage(CGImage imageToFilter, UIImageOrientation orientation);

		[Export("providesMonochromeOutput")]
		CGImage ProvidesMonochromeOutput { get; }

		[Export("prepareForImageCapture")]
		void PrepareForImageCapture();

		[Export("conserveMemoryForNextFrame")]
		void ConserveMemoryForNextFrame();
	}


	[BaseType(typeof(GPUImageOutput))]
	public interface GPUImagePicture
	{
		[Export("initWithURL:")]
		IntPtr Constructor(NSUrl url);

		[Export("initWithImage:")]
		IntPtr Constructor(UIImage image);

		[Export("initWithCGImage:")]
		IntPtr Constructor(CGImage frame);

		[Export("initWithImage:smoothlyScaleOutput:")]
		IntPtr Constructor(UIImage image, bool smoothlyScaleOutput);

		[Export("initWithCGImage:smoothlyScaleOutput:")]
		IntPtr Constructor(CGImage image, bool smoothlyScaleOutput);

		[Export("processImage")]
		void ProcessImage();
	
		[Export("outputImageSize")]
		SizeF OutputImageSize { get; set; }
	}

	[BaseType(typeof(GPUImageOutput))]
	public interface GPUImageRawDataInput
	{
		[Export("initWithBytes:size:")]
		IntPtr Constructor(IntPtr bytesToUpload, SizeF imageSize);

		[Export("initWithBytes:size:pixelFormat:")]
		IntPtr Constructor(IntPtr bytesToUpload, SizeF imageSize, GPUPixelFormat pixelFormat);
		
		[Export("initWithBytes:size:pixelFormat:type:")]
		IntPtr Constructor(IntPtr bytesToUpload, SizeF imageSize, GPUPixelFormat pixelFormat, GPUPixelType pixelType);

		[Export("pixelFormat")]
		GPUPixelFormat PixelFormat { get; set; }

		[Export("pixelType")]
		GPUPixelType PixelType { get; set; }

		// Image rendering
		[Export("updateDataFromBytes:size:")]
		void UpdateDataFromBytes(IntPtr bytesToUpload, SizeF imageSize);

		[Export("processData")]
		void ProcessData();

		[Export("outputImageSize")]
		SizeF OutputImageSize { get; set; }
	}

	namespace Filters
	{
		[BaseType(typeof(GPUImageOutput))]
		public interface GPUImageFilter : GPUImageInput
		{
			[Export("initWithVertexShaderFromString:fragmentShaderFromString:")]
			IntPtr Constructor(string vertexShaderString, string fragmentShaderString);
			
			[Export("initWithFragmentShaderFromString:")]
			IntPtr Constructor(string fragmentShaderString);
			
			//[Export("initWithFragmentShaderFromFile:")]
			//IntPtr Constructor(string fragmentShaderFilename);
			
			[Export("renderTarget")]
			IntPtr RenderTarget { get; }
			
			[Export("preventRendering")]
			bool PreventRendering { get; set; }
			
			[Export("currentlyReceivingMonochromeInput")]
			bool CurrentlyReceivingMonochromeInput { get; set; }
			
			[Export("initializeAttributes")]
			void InitializeAttributes();
			
			[Export("setupFilterForSize:")]
			void SetupFilterForSize(SizeF filterFrameSize);
			
			[Export("rotatedSize:forIndex:")]
			SizeF RotatedSize(SizeF sizeToRotate, int textureIndex);
			
			[Export("rotatedPoint:forRotation:")]
			PointF RotatedPoint(PointF pointToRotate, GPUImageRotationMode rotation);
			
			[Export("recreateFilterFBO")]
			void RecreateFilterFBO();
			
			[Export("sizeOfFBO")]
			SizeF SizeOfFBO { get; }
			
			[Export("createFilterFBOofSize:")]
			void CreateFilterFBOofSize(SizeF currentFBOSize);
			
			[Export("destroyFilterFBO")]
			void DestroyFilterFBO();
			
			[Export("setFilterFBO")]
			void SetFilterFBO();
			
			[Export("setOutputFBO")]
			void SetOutputFBO();
			
			[Export("releaseInputTexturesIfNeeded")]
			void ReleaseInputTexturesIfNeeded();
			
			//[Static, Export("textureCoordinatesForRotation:")]
			//float *TextureCoordinatesForRotation(GPUImageRotationMode rotationMode);
			
			[Export("InformTargetsAboutNewFrameAtTime:")]
			void InformTargetsAboutNewFrameAtTime(CMTime frameTime);
			
			//[Export("")]
			//SizeF outputFrameSize;
			
			[Export("setBackgroundColorRed:green:blue:alpha:")]
			void SetBackgroundColor(float redComponent, float green, float blue, float alpha);
			
			[Export("setInteger:forUniformName:")]
			void SetInteger(int val, string uniformName);
			
			[Export("setFloat:forUniformName:")]
			void SetFloat(float val, string uniformName);
			
			[Export("setSize:forUniformName:")]
			void SetSize(int val, string uniformName);
			
			[Export("setPoint:forUniformName:")]
			void SetPoint(int val, string uniformName);
			
/*
			[Export("")]
			void setFloatVec3(GPUVector3)newVec3 forUniformName(NSString *)uniformName;

			[Export("")]
			void setFloatVec4(GPUVector4)newVec4 forUniform(NSString *)uniformName;

			[Export("")]
			void setFloatArray(float *)array length(GLsizei)count forUniform(NSString*)uniformName;

			[Export("")]
			void setMatrix3f(GPUMatrix3x3)matrix forUniform(int)uniform program(GLProgram *)shaderProgram;

			[Export("")]
			void setMatrix4f(GPUMatrix4x4)matrix forUniform(int)uniform program(GLProgram *)shaderProgram;

			[Export("")]
			void setFloat(float)floatValue forUniform(int)uniform program(GLProgram *)shaderProgram;

			[Export("")]
			void setPoint(PointF)pointValue forUniform(int)uniform program(GLProgram *)shaderProgram;

			[Export("")]
			void setSize(SizeF)sizeValue forUniform(int)uniform program(GLProgram *)shaderProgram;

			[Export("")]
			void setVec3(GPUVector3)vectorValue forUniform(int)uniform program(GLProgram *)shaderProgram;

			[Export("")]
			void setVec4(GPUVector4)vectorValue forUniform(int)uniform program(GLProgram *)shaderProgram;

			[Export("")]
			void setFloatArray(float *)arrayValue length(GLsizei)arrayLength forUniform(int)uniform program(GLProgram *)shaderProgram;

			[Export("")]
			void setInteger(int)intValue forUniform(int)uniform program(GLProgram *)shaderProgram;

			[Export("")]
			void setAndExecuteUniformStateCallbackAtIndex(int)uniform forProgram(GLProgram *)shaderProgram toBlock(dispatch_block_t)uniformStateBlock;

			[Export("")]
			void setUniformsForProgramAtIndex(NSUInteger)programIndex;
*/		
		}
		

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImage3x3TextureSamplingFilter
		{
			/// <summary>
			/// The texel width determines how far out to sample from this texel. By default, this is the normalized width of a pixel, but this can be overridden for different effects.
			/// </summary>
			[Export("texelWidth")]
			float TexelWidth { get; set; }

			/// <summary>
			/// The texel height determines how far out to sample from this texel. By default, this is the normalized width of a pixel, but this can be overridden for different effects.
			/// </summary>
			[Export("texelHeight")]
			float TexelHeight { get; set; }
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImageBuffer
		{
			[Export("bufferSize")]
			uint BufferSize { get; set; }
		}
		
		[BaseType(typeof(GPUImageOutput))]
		public interface GPUImageFilterGroup : GPUImageInput, GPUImageTextureDelegate
		{
			[Export("terminalFilter")]
			GPUImageFilter TerminalFilter { get; set; }
			
			[Export("initialFilters")]
			GPUImageFilter[] InitialFilters { get; set; }
			
			[Export("inputFilterToIgnoreForUpdates")]
			GPUImageFilter InputFilterToIgnoreForUpdates { get; set; }
			
			[Export("addFilter")]
			void AddFilter(GPUImageFilter newFilter);
			
			[Export("filterAtIndex:")]
			GPUImageFilter FilterAtIndex(uint filterIndex);
			
			[Export("filterCount")]
			int FilterCount { get; }
		}

		[BaseType(typeof(GPUImage3x3TextureSamplingFilter))]
		public interface GPUImageToonFilter
		{
			[Export("threshold")]
			float Threshold { get; set; }

			[Export("quantizationLevels")]
			float QuantizationLevels { get; set; }
		}

		[BaseType(typeof(GPUImageFilterGroup))]
		public interface GPUImageSmoothToonFilter
		{
			[Export("texelWidth")]
			float TexelWidth { get; set; }
			
			[Export("texelHeight")]
			float TexelHeight { get; set; }

			/// <summary>
			/// The threshold at which to apply the edges, default of 0.2
			/// </summary>
			[Export("threshold")]
			float threshold { get; set; }
			
			/// <summary>
			/// The levels of quantization for the posterization of colors within the scene, with a default of 10.0
			/// </summary>
			[Export("quantizationLevels")]
			float quantizationLevels { get; set; }
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImageSwirlFilter
		{
			[Export("center")]
			PointF Center { get; set; }
			
			[Export("radius")]
			float Radius { get; set; }
			
			[Export("angle")]
			float Angle { get; set; }
		}

		
		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImageBulgeDistortionFilter
		{
			[Export("center")]
			PointF Center { get; set; }
			
			[Export("radius")]
			float Radius { get; set; }
			
			[Export("angle")]
			float Angle { get; set; }
		}

		
		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImagePinchDistortionFilter
		{
			[Export("center")]
			PointF Center { get; set; }
			
			[Export("radius")]
			float Radius { get; set; }
			
			[Export("angle")]
			float Angle { get; set; }
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImageSphereRefractionFilter
		{
			[Export("center")]
			PointF Center { get; set; }
			
			[Export("radius")]
			float Radius { get; set; }
			
			[Export("refractiveIndex")]
			float RefractiveIndex { get; set; }
		}

		[BaseType(typeof(GPUImageSphereRefractionFilter))]
		public interface GPUImageGlassSphereFilter
		{
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImageStretchDistortionFilter
		{
			[Export("center")]
			PointF Center { get; set; }
		}

		
		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImageKuwaharaFilter
		{
			[Export("radius")]
			int Radius { get; set; }
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImagePolkaDotFilter
		{
			[Export("dotScaling")]
			float DotScaling { get; set; }
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImagePixellateFilter
		{
			[Export("fractionalWidthOfAPixel")]
			float FractionalWidthOfAPixel { get; set; }
		}

		[BaseType(typeof(GPUImagePixellateFilter))]
		public interface GPUImageHalftoneFilter
		{
			[Export("dotScaling")]
			float DotScaling { get; set; }
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImageKuwaharaRadius3Filter
		{
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImagePolarPixellateFilter
		{
			[Export("center")]
			PointF Center { get; set; }

			[Export("pixelSize")]
			SizeF PixelSize { get; set; }
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImageCrosshatchFilter
		{
			[Export("crossHatchSpacing")]
			float CrossHatchSpacing { get; set; }
			
			[Export("lineWidth")]
			float LineWidth { get; set; }
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImageCropFilter
		{
			[Export("cropRegion")]
			RectangleF CropRegion { get; set; }
			
			[Export("initWithCropRegion")]
			IntPtr InitWithCropRegion(RectangleF newCropRegion);
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImageSharpenFilter
		{
			[Export("sharpness")]
			float Sharpness { get; set; }
		}

		
		[BaseType(typeof(GPUImageFilterGroup))]
		public interface GPUImageUnsharpMaskFilter
		{
			[Export("blurSize")]
			float BlurSize { get; set; }

			[Export("intensity")]
			float Intensity { get; set; }
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImageTwoPassFilter
		{
			[Export("initWithFirstStageVertexShaderFromString:firstStageFragmentShaderFromString:secondStageVertexShaderFromString:secondStageFragmentShaderFromString:")]
			IntPtr Constructor(string firstStageVertexShaderString, string firstStageFragmentShaderString, string secondStageVertexShaderString, string secondStageFragmentShaderString);
			
			[Export("initWithFirstStageFragmentShaderFromString:secondStageFragmentShaderFromString:")]
			IntPtr Constructor(string firstStageFragmentShaderString, string secondStageFragmentShaderString);
			
			[Export("initializeSecondaryAttributes")]
			void InitializeSecondaryAttributes();
			
			[Export("initializeSecondOutputTextureIfNeeded")]
			void InitializeSecondOutputTextureIfNeeded();
		}
		

		[BaseType(typeof(GPUImageTwoPassFilter))]
		public interface GPUImageTwoPassTextureSamplingFilter
		{
			[Export("verticalTexelSpacing")]
			float VerticalTexelSpacing { get; set; }

			[Export("horizontalTexelSpacing")]
			float HorizontalTexelSpacing { get; set; }
		}

		[BaseType(typeof(GPUImageTwoPassTextureSamplingFilter))]
		public interface GPUImageLanczosResamplingFilter
		{
			[Export("originalImageSize")]
			SizeF OriginalImageSize { get; set; }
		}


		[BaseType(typeof(GPUImageTwoPassFilter))]
		public interface GPUImageSobelEdgeDetectionFilter
		{
			[Export("texelWidth")]
			float TexelWidth { get; set; }
			
			[Export("texelHeight")]
			float TexelHeight { get; set; }
		}
		
		[BaseType(typeof(GPUImageSobelEdgeDetectionFilter))]
		public interface GPUImageSketchFilter
		{
		}

		/// <summary>
		/// Performs a vignetting effect, fading out the image at the edges
		/// </summary>
		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImageVignetteFilter
		{
			[Export("vignetteCenter")]
			PointF vignetteCenter { get; set; }
			
			[Export("vignetteColor")]
			GPUVector3 vignetteColor { get; set; }
			
			[Export("vignetteStart")]
			float VignetteStart { get; set; }

			[Export("vignetteEnd")]
			float VignetteEnd { get; set; }
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImageJFAVoronoiFilter
		{
			[Export("sizeInPixels")]
			SizeF SizeInPixels { get; set; }
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImagePerlinNoiseFilter
		{
			[Export("colorStart")]
			GPUVector4 colorStart { get; set; }

			[Export("colorFinish")]
			GPUVector4 ColorFinish { get; set; }
		
			[Export("scale")]
			float Scale { get; set; }
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImageSepiaFilter
		{
			[Export("intensity")]
			float Intensity {get;set;}
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImageGrayscaleFilter
		{
		}

		[BaseType(typeof(GPUImageFilter))]
		public interface GPUImageMonochromeFilter
		{
			[Export("intensity")]
			float Intensity {get;set;}

			[Export("color")]
			GPUVector3 color {get;set;}
		}

	}
}