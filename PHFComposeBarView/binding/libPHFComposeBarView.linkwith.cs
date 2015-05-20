using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libPHFComposeBarView.a", LinkTarget.ArmV7 | LinkTarget.Simulator, Frameworks = "CoreGraphics", ForceLoad = true)]
