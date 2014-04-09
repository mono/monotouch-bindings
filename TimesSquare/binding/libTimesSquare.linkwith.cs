using System;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;

[assembly: LinkerSafe]
[assembly: LinkWith ("libTimesSquare.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, Frameworks = "CoreGraphics", LinkerFlags = "-ObjC -fobjc-arc", SmartLink = true, ForceLoad = true)]
