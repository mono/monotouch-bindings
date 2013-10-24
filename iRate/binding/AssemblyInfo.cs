using System;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;

[assembly:LinkerSafe]
[assembly: LinkWith ("libiRate.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true, Frameworks = "StoreKit", SmartLink=true)]
