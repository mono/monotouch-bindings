using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libFlurry.a", LinkTarget.Simulator | LinkTarget.ArmV7,Frameworks = "SystemConfiguration", ForceLoad = true)]
