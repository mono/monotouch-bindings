using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libdtdev.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, Frameworks = "ExternalAccessory", IsCxx = true, ForceLoad = true)]
