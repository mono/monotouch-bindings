//
// StructsAndEnums.cs: Definitions used by Cocos2D
//
// Author:
//   Miguel de Icaza
//   Stephane Delcroix
//
// Copyright 2011, 2012, 2013 Xamarin, Inc.
// Copyright 2012, 2013 S. Delcroix
//
using System;
using System.Runtime.InteropServices;
using System.Drawing;
using OpenTK;

namespace MonoTouch.Cocos2D {

	[StructLayout (LayoutKind.Sequential)]
	public struct CCBezierConfig {
		public PointF EndPosition;
		public PointF ControlPoint1;
		public PointF ControlPoint2;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CCColor3B {
		public byte R;
		public byte G;
		public byte B;

		public CCColor3B (byte r, byte g, byte b) {
			R = r;
			G = g;
			B = b;
		}

		public static CCColor3B White { get {return new CCColor3B(0xff,0xff,0xff);}}
		public static CCColor3B Yellow { get {return new CCColor3B(0xff,0xff,0);}}
		public static CCColor3B Blue { get {return new CCColor3B(0,0,0xff);}}
		public static CCColor3B Green { get {return new CCColor3B(0,0xff,0);}}
		public static CCColor3B Red { get {return new CCColor3B(0xff,0,0);}}
		public static CCColor3B Magenta { get {return new CCColor3B(0xff, 0, 0xff);}}
		public static CCColor3B Black { get {return new CCColor3B(0,0,0);}}
		public static CCColor3B Orange { get {return new CCColor3B(0xff,0x7f,0);}}
		public static CCColor3B Gray { get {return new CCColor3B(0xa6,0xa6,0xa6);}}
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CCColor4B {
		public byte R;
		public byte G;
		public byte B;
		public byte A;

		public CCColor4B (byte r, byte g, byte b, byte a) {
			R = r;
			G = g;
			B = b;
			A = a;
		}

		public CCColor4B (CCColor3B color, byte a) {
			R = color.R;
			G = color.G;
			B = color.B;
			A = a;
		}
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CCColor4F {
		public float R;
		public float G;
		public float B;
		public float A;

		public CCColor4F (float r, float g, float b, float a) {
			R = r;
			G = g;
			B = b;
			A = a;
		}
	}


	public enum CCDirectorProjection {
		TwoD,
		ThreeD,
		Custom,
		Default = TwoD,
	}

	public enum CCImageFormat {
		JPEG, PNG
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

	public enum CCOrientation {
		LeftOver = 0,
		RightOver = 1,
		UpOver = 0,
		DownOver = 1,
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CCBlendFunc {
		public uint Src;
		public uint Dst;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CCTex2F {
		public float U;
		public float V;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CCV2F_C4B_T2F {
		public Vector2 Vertices;
		public CCColor4B Colors;
		public CCTex2F  TexCoords;
	}
		
	[StructLayout (LayoutKind.Sequential)]
	public struct CCV3F_C4B_T2F {
		public Vector3 Vertices;
		public CCColor4B Colors;
		public CCTex2F TexCoords;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CCV3F_C4B_T2F_Quad {
		public CCV3F_C4B_T2F TopLeft;
		public CCV3F_C4B_T2F BottomLeft;
		public CCV3F_C4B_T2F TopRight;
		public CCV3F_C4B_T2F BottomRight;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CCQuad2 {
		public Vector2 TopLeft, TopRight, BottomLeft, BottomRight;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CCQuad3 {
		public Vector3 BottomLeft, BottomRight, TopLeft, TopRight;
	}

	public enum CCVerticalTextAlignment {
		Top, Center, Bottom
	}
	
	public enum CCOSVersion {
		iOSVersion_4_0   = 0x04000000,
		iOSVersion_4_0_1 = 0x04000100,
		iOSVersion_4_1   = 0x04010000,
		iOSVersion_4_2   = 0x04020000,
		iOSVersion_4_2_1 = 0x04020100,
		iOSVersion_4_3   = 0x04030000,
		iOSVersion_4_3_1 = 0x04030100,
		iOSVersion_4_3_2 = 0x04030200,
		iOSVersion_4_3_3 = 0x04030300,
		iOSVersion_4_3_4 = 0x04030400,
		iOSVersion_4_3_5 = 0x04030500,
		iOSVersion_5_0   = 0x05000000,
		iOSVersion_5_0_1 = 0x05000100,
		iOSVersion_5_1_0 = 0x05010000,
		iOSVersion_6_0_0 = 0x06000000,
		
		MacVersion_10_6  = 0x0a060000,
		MacVersion_10_7  = 0x0a070000,
		MacVersion_10_8  = 0x0a080000,
	}

	public enum CCParticleEmitterMode {
		Gravity,
		Radius
	}

	public enum CCPositionType {
		Free, Relative, Grouped
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CCParticleModeA {
		public PointF Direction;
		public float RadialAcceleration;
		public float TangentialAcceleration;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CCParticleModeB {
		public float Angle;
		public float DegreesPerSecond;
		public float Radius;
		public float DeltaRadius;
	}
	
	[StructLayout (LayoutKind.Explicit)]
	public struct CCParticleUnion {
		[FieldOffset (0)]
		public CCParticleModeA A;

		[FieldOffset (0)]
		public CCParticleModeB B;
	}
	
	[StructLayout (LayoutKind.Sequential)]
	public struct CCParticle {
		public PointF Position;
		public PointF StartPosition;

		public CCColor4F Color;
		public CCColor4F DeltaColor;

		public float Size;
		public float DeltaSize;

		public float Rotation;
		public float DeltaRotation;

		public float TimeToLive;

		public uint AtlasIndex;

		public CCParticleUnion Mode;
	}

	public enum CCProgressTimerType {
		Radial, Bar
	}

	public enum CCResolutionType {
		Unknown,
#if MONOMAC
		Mac, MacRetina
#else
		iPhone, iPhoneRetinaDisplay, iPad, iPadRetinaDisplay
#endif
	}

	[Flags]
	public enum CCTMXTileFlags : uint {
		Horizontal = 0x80000000,
		Vertical = 0x40000000,
		Diagonal = 0x20000000,
		FlippedAll = Horizontal | Vertical | Diagonal,
		FlippedMask = ~FlippedAll
	}

#if !MONOMAC
	public enum CCTouchesMode {
		AllAtOnce,
		OneByOne,
	}
#endif
}
