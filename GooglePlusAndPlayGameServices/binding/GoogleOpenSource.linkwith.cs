using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("GoogleOpenSource", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, IsCxx = true)]
