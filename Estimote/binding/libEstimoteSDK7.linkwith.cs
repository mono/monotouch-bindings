using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libEstimoteSDK7.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true)]
