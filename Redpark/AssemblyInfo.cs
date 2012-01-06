using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("Parse.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7,Frameworks = "MobileCoreServices CoreGraphics SystemConfiguration AudioToolbox Security", ForceLoad = true)]
