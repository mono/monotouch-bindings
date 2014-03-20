using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("GoogleOpenSource", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, LinkerFlags = "-ObjC -fobjc-arc", ForceLoad = true, IsCxx = true)]
