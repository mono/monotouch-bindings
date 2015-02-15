using System;
using ObjCRuntime;

[assembly: LinkWith ("libdtdev.a", LinkTarget.ArmV7 | LinkTarget.Simulator, SmartLink = true, ForceLoad = true, Frameworks = "ExternalAccessory", WeakFrameworks = "CoreBluetooth", IsCxx = true)]