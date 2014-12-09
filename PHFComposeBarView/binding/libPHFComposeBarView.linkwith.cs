using System;
#if __UNIFIED__
using ObjCRuntime;
#else
using MonoTouch.ObjCRuntime;
#endif

[assembly: LinkWith ("libPHFComposeBarView.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, Frameworks = "CoreGraphics", ForceLoad = true)]
