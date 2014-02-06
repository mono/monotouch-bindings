using System;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;

[assembly: LinkerSafe]
[assembly: LinkWith ("GoogleCast", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, Frameworks = "AVFoundation CoreGraphics", LinkerFlags = "-ObjC", SmartLink = true, ForceLoad = true)]
