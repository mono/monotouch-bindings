using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libFacebookSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, "-ObjC -lsqlite3", ForceLoad = true, Frameworks = "CoreGraphics CoreLocation QuartzCore", WeakFrameworks = "Accounts AdSupport Social")]
