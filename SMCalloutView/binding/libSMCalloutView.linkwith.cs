using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libSMCalloutView.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, Frameworks = "QuartzCore", ForceLoad = true)]
