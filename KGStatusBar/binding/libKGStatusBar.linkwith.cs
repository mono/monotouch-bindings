using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libKGStatusBar.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, Frameworks = "CoreGraphics", ForceLoad = true)]
