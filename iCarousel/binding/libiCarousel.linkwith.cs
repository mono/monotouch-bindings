using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libiCarousel.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, Frameworks = "QuartzCore CoreGraphics", ForceLoad = true)]
