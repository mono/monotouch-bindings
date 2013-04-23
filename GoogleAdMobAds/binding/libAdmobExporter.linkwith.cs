using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libAdmobExporter.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]
