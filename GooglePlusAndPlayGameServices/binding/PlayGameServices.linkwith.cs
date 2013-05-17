using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("PlayGameServices", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, Frameworks = "CoreData Security SystemConfiguration", ForceLoad = true)]
