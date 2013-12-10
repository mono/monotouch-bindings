using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libGoogleAnalyticsServices.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, Frameworks = "CoreData SystemConfiguration AdSupport", SmartLink = true, ForceLoad = true, LinkerFlags = "-lz -lsqlite3.0")]
