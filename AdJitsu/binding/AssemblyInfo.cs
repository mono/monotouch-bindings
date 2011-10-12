using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libAdJitsuSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7, "-lxml2 -lsqlite3", ForceLoad = true, IsCxx = true)]
