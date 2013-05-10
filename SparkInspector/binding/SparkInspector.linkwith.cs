using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("SparkInspector.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, Frameworks = "QuartzCore")]
