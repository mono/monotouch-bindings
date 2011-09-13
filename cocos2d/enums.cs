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
}