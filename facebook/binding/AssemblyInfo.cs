using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libFacebookSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, "-lsqlite3", ForceLoad = true, Frameworks = "CoreGraphics")]
