using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libKiip.a",  LinkTarget.ArmV7 | LinkTarget.Simulator,Frameworks = "MobileCoreServices CoreGraphics CFNetwork SystemConfiguration", ForceLoad = true)]
