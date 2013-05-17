using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("GoogleOpenSource.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, IsCxx = true)]
