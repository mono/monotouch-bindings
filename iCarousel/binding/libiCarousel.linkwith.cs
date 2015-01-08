using System;
using ObjCRuntime;

[assembly: LinkWith ("libiCarousel.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64 | LinkTarget.Simulator, Frameworks = "QuartzCore CoreGraphics", ForceLoad = true)]
