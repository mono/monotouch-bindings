using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("Dropbox.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, Frameworks = "CFNetwork Security SystemConfiguration QuartzCore")]
