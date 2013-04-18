//
// Obsolete.cs
//
// Author:
//   Stephane Delcroix <stephane@delcroix.org>
//
// Copyright © 2013 Stephane Delcroix. All Rights Reserved.


using System;
using System.Drawing;
using System.Runtime.InteropServices;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
#if MONOMAC
using UITextAlignment = MonoMac.AppKit.NSTextAlignment;
using UILineBreakMode = MonoMac.AppKit.NSLineBreakMode;
#endif


namespace MonoTouch.Cocos2D {
    //Obsolete in 2.1
    public partial class CCTexture2D {
	[Obsolete ("2.1 - Use CCTexture2D (string text, string fontName, float fontSize, UITextAlignment alignmenr, CCVerticalTextAlignment vertAlignmenr) instead.")]
	public CCTexture2D (string text, SizeF dimensions, UITextAlignment alignment, CCVerticalTextAlignment vertAlignment, string fontName, float fontSize) : this (text, fontName, fontSize, dimensions, alignment, vertAlignment)
	{
	}
    }

    public partial class CCLabelTTF {
	[Obsolete ("2.1 - Use CCLabelTTF (string label, string fontName, float fontSize, SizeF dimensions, UITextAlignment alignment, UILineBreakMode lineBreakMode) instead.")]
	public CCLabelTTF (string label, SizeF dimensions, UITextAlignment alignment, UILineBreakMode lineBreakMode, string fontName, float fontSize) : this (label, fontName, fontSize, dimensions, alignment, lineBreakMode)
	{
	}

	[Obsolete ("2.1 - Use CCLabelTTF (string label, string fontName, float fontSize, SizeF dimensions, UITextAlignment alignment) instead.")]
	public CCLabelTTF (string label, SizeF dimensions, UITextAlignment alignment, string fontName, float fontSize) : this (label, fontName, fontSize, dimensions, alignment)
	{
	}
    }

    public partial class CCMenuItem {
	[Obsolete ("2.1 - Use ActiveArea instead")]
	RectangleF Rect { 
	    get { return ActiveArea; } 
	    set { ActiveArea = value; }
	}
    }

    public partial class CCDirector {
	[Obsolete ("2.1 - Poorly named, use PushScene instead")]
	public void Push (CCScene scene)
	{
	    PushScene (scene);
	}
    }

    public partial class CCGLProgram {
	[Obsolete ("2.1 - Use SetUniformsForBuiltins () instead.")]
	void SetUniformForModelViewProjectionMatrix ()
	{
	    SetUniformsForBuiltins ();
	}
    }
}	
