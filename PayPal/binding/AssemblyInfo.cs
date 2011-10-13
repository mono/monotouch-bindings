using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libPayPalEC.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true)]
