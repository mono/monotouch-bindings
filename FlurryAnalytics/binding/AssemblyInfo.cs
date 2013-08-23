using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libFlurry.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true)]
