using System;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

[assembly: LinkerSafe]
[assembly: LinkWith ("libChipmunk-iPhone.a",LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]
