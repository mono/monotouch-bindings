//
// Constraint.cs
//
// Author:
//   Stephane Delcroix <stephane@delcroix.org>
//
// Copyright © 2013 Stephane Delcroix. All Rights Reserved.

using System;

namespace Chipmunk
{
    public abstract partial class Constraint : ChipmunkObject
    {
	protected Constraint (IntPtr ptr) : base (ptr)
	{
	}
    }
}

