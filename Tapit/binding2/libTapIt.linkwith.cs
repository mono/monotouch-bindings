using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libTapIt.a", LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true, Frameworks = "SystemConfiguration CoreGraphics QuartzCore CoreTelephony")]
