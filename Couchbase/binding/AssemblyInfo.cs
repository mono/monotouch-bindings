using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("Couchbase", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true,IsCxx = true)]
