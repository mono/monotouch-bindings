using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libCorePlot-CocoaTouch.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, Frameworks = "CoreGraphics QuartzCore", ForceLoad = true, IsCxx = true)]
