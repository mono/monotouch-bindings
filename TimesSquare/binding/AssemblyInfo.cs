using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libTimesSquare.a", LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true, Frameworks = "CoreGraphics")]
