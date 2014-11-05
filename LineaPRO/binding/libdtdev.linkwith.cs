using System;
using MonoTouch.ObjCRuntime;
[assembly: LinkWith ("libdtdev.a", LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true, Frameworks = "ExternalAccessory", WeakFrameworks = "CoreBluetooth", IsCxx = true)]