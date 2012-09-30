//
// StructsAndEnums.cs: Definitions used by Cocos2D
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

	[StructLayout (LayoutKind.Sequential)]
	public struct Color3B {
		public byte R;
		public byte G;
		public byte B;

		public Color3B (byte r, byte g, byte b) {
			R = r;
			G = g;
			B = b;
		}

		public static Color3B White { get {return new Color3B(0xff,0xff,0xff);}}
		public static Color3B Yellow { get {return new Color3B(0xff,0xff,0);}}
		public static Color3B Blue { get {return new Color3B(0,0,0xff);}}
		public static Color3B Green { get {return new Color3B(0,0xff,0);}}
		public static Color3B Red { get {return new Color3B(0xff,0,0);}}
		public static Color3B Magenta { get {return new Color3B(0xff, 0, 0xff);}}
		public static Color3B Black { get {return new Color3B(0,0,0);}}
		public static Color3B Orange { get {return new Color3B(0xff,0x7f,0);}}
		public static Color3B Gray { get {return new Color3B(0xa6,0xa6,0xa6);}}
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct Color4B {
		public byte R;
		public byte G;
		public byte B;
		public byte A;

		public Color4B (byte r, byte g, byte b, byte a) {
			R = r;
			G = g;
			B = b;
			A = a;
		}

		public Color4B (Color3B color, byte a) {
			R = color.R;
			G = color.G;
			B = color.B;
			A = a;
		}
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

	public enum Orientation {
		LeftOver = 0,
		RightOver = 1,
		UpOver = 0,
		DownOver = 1,
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct BlendFunc {
		public uint Src;
		public uint Dst;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct Vertex3F {
		public float X;
		public float Y;
		public float Z;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct Tex2F {
		public float U;
		public float V;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct V3F_C4B_T2F {
		public Vertex3F Vertices;
		public Color4B Colors;
		public Tex2F TexCoords;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct V3F_C4B_T2F_Quad {
		public V3F_C4B_T2F TopLeft;
		public V3F_C4B_T2F BottomLeft;
		public V3F_C4B_T2F TopRight;
		public V3F_C4B_T2F BottomRight;
	} 

	public enum TextAlignment {
		Left,
		Center,
		Right,
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct Vertex2F {
		public float X;
		public float Y;
	}
	
}
