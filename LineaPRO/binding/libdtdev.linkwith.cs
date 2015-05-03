using System;
using ObjCRuntime;

[assembly: LinkWith ("libdtdev.a", LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64, Frameworks = "ExternalAccessory CoreBluetooth AVFoundation MediaPlayer", IsCxx = true, SmartLink = true, ForceLoad = true)]
