using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("GooglePlus", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, LinkerFlags = "-ObjC -fobjc-arc", Frameworks = "SystemConfiguration Security", ForceLoad = true)]
