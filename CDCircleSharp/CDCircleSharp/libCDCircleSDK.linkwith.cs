using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libCDCircleSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]
