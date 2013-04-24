using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libGoogleMapsExporter.a", LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.ArmV7s, ForceLoad = true)]
