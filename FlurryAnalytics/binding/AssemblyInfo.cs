using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libFlurry.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s,Frameworks = "SystemConfiguration Security", ForceLoad = true)]
