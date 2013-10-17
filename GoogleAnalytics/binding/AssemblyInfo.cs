using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libGoogleAnalyticsServices.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, Frameworks = "SystemConfiguration CFNetwork CoreData", ForceLoad = true)]
