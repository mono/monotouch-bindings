//
// ChipmunkObject.cs
//
// Authors:
//  Stephane Delcroix <stephane@delcroix.org>
//
// Copyright 2012 S. Delcroix
//

using System;
using System.Drawing;
using System.Runtime.InteropServices;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Chipmunk
{
	public class ChipmunkObject : IDisposable
	{
		public HandleRef Handle { get; private set;}

		public void Dispose ()
		{
			Cleanup ();

			System.GC.SuppressFinalize (this);
		}

		protected ChipmunkObject (IntPtr ptr)
		{
			Handle = new HandleRef (this, ptr);
		}
	
		~ChipmunkObject ()
		{
			Cleanup ();
		}

		protected virtual void Cleanup ()
		{
			Handle = new HandleRef (this, IntPtr.Zero);
		}
	}
}
