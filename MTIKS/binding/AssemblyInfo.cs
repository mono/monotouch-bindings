using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libmTiks.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true)]
