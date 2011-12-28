using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libATMHudSDK.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true, Frameworks="AudioToolbox")]
