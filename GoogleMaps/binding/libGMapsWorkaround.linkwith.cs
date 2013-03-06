using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libGMapsWorkaround.a", LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true)]
