using System;

namespace GPUImage
{
	public enum GPUImageFillModeType
	{
		kGPUImageFillModeStretch,                       // Stretch to fill the full view, which may distort the image outside of its normal aspect ratio
		kGPUImageFillModePreserveAspectRatio,           // Maintains the aspect ratio of the source image, adding bars of the specified background color
		kGPUImageFillModePreserveAspectRatioAndFill     // Maintains the aspect ratio of the source image, zooming in on its center to fill the view
	} 

	public enum GPUImageRotationMode { kGPUImageNoRotation, kGPUImageRotateLeft, kGPUImageRotateRight, kGPUImageFlipVertical, kGPUImageFlipHorizonal, kGPUImageRotateRightFlipVertical, kGPUImageRotate180 };


	public struct GPUVector4 {
		public float one;
		public float two;
		public float three;
		public float four;
	};

	public struct GPUVector3 {
		public float one;
		public float two;
		public float three;
	};

	public struct GPUMatrix4x4 {
		public GPUVector4 one;
		public GPUVector4 two;
		public GPUVector4 three;
		public GPUVector4 four;
	};

	public struct GPUMatrix3x3 {
		public GPUVector3 one;
		public GPUVector3 two;
		public GPUVector3 three;
	};

	public enum GPUPixelFormat {
		GPUPixelFormatBGRA = 0x80E1,
		GPUPixelFormatRGBA = 0x1908,
		GPUPixelFormatRGB = 0x1907
	}
	
	public enum GPUPixelType {
		GPUPixelTypeUByte = 0x1401,
		GPUPixelTypeFloat = 0x1406
	}
}

