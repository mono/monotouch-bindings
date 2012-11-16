using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libFacebookSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, "-ObjC -lsqlite3", ForceLoad = true, Frameworks = "Accounts CoreGraphics CoreLocation QuartzCore Social", WeakFrameworks = "AdSupport")]
