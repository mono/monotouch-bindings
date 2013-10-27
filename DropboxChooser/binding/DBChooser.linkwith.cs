using System;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;

[assembly: LinkerSafe]
[assembly: LinkWith ("DBChooser.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, LinkerFlags = "-fobjc-arc", Frameworks = "CoreGraphics", SmartLink = true, ForceLoad = true)]