//
// AssemblyInfo.cs
//
// Author:
//   Stephane Delcroix <stephane@delcroix.org>
//
// Copyright © 2013 Stephane Delcroix. All Rights Reserved.


using System;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

[assembly: LinkerSafe]
[assembly: LinkWith ("libCocosDenshion.a",LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true, Frameworks = "OpenAL, AudioToolbox, AVFoundation")]
