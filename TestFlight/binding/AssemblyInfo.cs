using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libTestFlight.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64, ForceLoad = true)]
[assembly: LinkWith ("libarclite.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.Arm64, ForceLoad = true)]