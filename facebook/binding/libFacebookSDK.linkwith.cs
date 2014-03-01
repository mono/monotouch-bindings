using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libFacebookSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, "-ObjC -fobjc-arc -lsqlite3", SmartLink = true, ForceLoad = true, Frameworks = "CoreGraphics CoreLocation QuartzCore Security", WeakFrameworks = "Accounts Social")]