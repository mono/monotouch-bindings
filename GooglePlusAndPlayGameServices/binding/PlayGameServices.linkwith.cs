using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("PlayGameServices", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, LinkerFlags = "-ObjC -fobjc-arc", Frameworks = "CoreData Security SystemConfiguration", ForceLoad = true)]
