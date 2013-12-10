using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libGoogleAnalyticsExporter.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, SmartLink = true, ForceLoad = true)]
