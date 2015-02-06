using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libUIImageViewAlignedSharp.a", LinkTarget.Simulator | LinkTarget.ArmV7, SmartLink = true, ForceLoad = true)]
