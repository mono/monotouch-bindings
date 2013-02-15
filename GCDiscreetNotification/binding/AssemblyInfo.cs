using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libGCDiscreetNotificationView.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, Frameworks = "CoreGraphics")]
