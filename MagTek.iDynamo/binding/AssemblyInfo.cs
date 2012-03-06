using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libMTSCRA.a", LinkTarget.ArmV6 | LinkTarget.ArmV7, "-ObjC -lc++", Frameworks = "ExternalAccessory", ForceLoad = true, IsCxx = true)]
