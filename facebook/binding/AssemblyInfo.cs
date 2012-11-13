using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libFacebookSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, "sqlite3", ForceLoad = true, Frameworks = "CoreGraphics")]
