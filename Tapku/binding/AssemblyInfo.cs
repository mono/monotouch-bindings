using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libTapkuSDK.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true)]
