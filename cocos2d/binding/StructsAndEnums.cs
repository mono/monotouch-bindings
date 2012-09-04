//
// enums.cs: Definitions used by Cocos2D
//
// Author:
//   Miguel de Icaza
//
// Copyright 2011 Xamarin, Inc.
//
using System.Runtime.InteropServices;
using System.Drawing;

namespace MonoTouch.Cocos2D {

	[StructLayout (LayoutKind.Sequential)]
	public struct CCBezierConfig {
		public PointF EndPosition;
		public PointF ControlPoint1;
		public PointF ControlPoint2;
	}

	public enum CCDirectorProjection {
		TwoD,
		ThreeD,
		Custom,
		Default = TwoD,
	}

	public enum CCTexture2DPixelFormat {
		Rgba8888,
		Rgb888,
		Rgb565,
		A8,
		I8,
		AI88,
		Rgba4444,
		Rgb5a1,
		Pvrtc4,
		Pvrtc2,
		Default = Rgba8888
	}
}
