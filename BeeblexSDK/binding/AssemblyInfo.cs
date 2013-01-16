using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libBeeblex-SDK.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, Frameworks="SystemConfiguration Security StoreKit")]
