using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libiRate.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true, Frameworks = "StoreKit")]
