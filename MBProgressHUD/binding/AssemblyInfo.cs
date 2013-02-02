using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libMBProgressHUD.a", LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, Frameworks = "CoreGraphics")]