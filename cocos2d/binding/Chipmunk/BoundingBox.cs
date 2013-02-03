//
// BoundingBox.cs
//
// Authors:
//  Stephane Delcroix <stephane@delcroix.org>
//
// Copyright 2012, 2013 S. Delcroix
//

using System;
using System.Drawing;
using System.Runtime.InteropServices;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Chipmunk
{
	[StructLayout(LayoutKind.Sequential)]
	public struct BoundingBox {
		public float Left;
		public float Bottom;
		public float Right;
		public float Top; 
	}
}
