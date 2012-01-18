using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libUAirship-1.1.3.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true)]
