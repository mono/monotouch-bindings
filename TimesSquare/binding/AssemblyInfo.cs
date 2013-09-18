using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libTimesSquare.a", LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true, Frameworks = "CoreGraphics")]
[assembly: LinkWith ("libarclite.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true)]
