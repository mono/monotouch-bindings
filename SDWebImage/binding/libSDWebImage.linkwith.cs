using System;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;

[assembly: LinkerSafe]
[assembly: LinkWith ("libSDWebImage.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, SmartLink = true, ForceLoad = true, LinkerFlags = "-ObjC -fobjc-arc", Frameworks = "CoreGraphics ImageIO")]
