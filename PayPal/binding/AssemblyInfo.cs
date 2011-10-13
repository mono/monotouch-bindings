using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libPayPalMPL.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, "-lxml2 -lz", ForceLoad = true)]
