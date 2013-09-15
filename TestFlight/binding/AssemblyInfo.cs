using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libTestFlight.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true)]
[assembly: LinkWith ("libarclite.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true)]