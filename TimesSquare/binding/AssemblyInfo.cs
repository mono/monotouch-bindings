using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libTimesSquare.a", LinkTarget.ArmV7 | LinkTarget.Simulator, LinkerFlags = "-ObjC -fobjc-arc", ForceLoad = true, Frameworks = "CoreGraphics")]
