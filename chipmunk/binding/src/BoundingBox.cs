//
// BoundingBox.cs
//
// Author:
//   Stephane Delcroix <stephane@delcroix.org>
//
// Copyright © 2012, 2013 Stephane Delcroix. All Rights Reserved.

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Chipmunk
{
    [StructLayout (LayoutKind.Sequential)]
    internal struct BoundingBox {
	float l;
	float b;
	float r;
	float t;

	public static implicit operator BoundingBox (RectangleF rect)
	{
	    return new BoundingBox {
		l = rect.Left,
		b = rect.Bottom,
		r = rect.Right,
		t = rect.Top,
	    };
	}

	public static implicit operator RectangleF (BoundingBox box)
	{
	    return RectangleF.FromLTRB (box.l, box.t, box.r, box.b);
	}
    }
}

