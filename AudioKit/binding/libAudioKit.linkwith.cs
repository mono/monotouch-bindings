using System;
using ObjCRuntime;
using Foundation;

[assembly: LinkWith ("libAudioKit.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64, SmartLink = true, ForceLoad = true)]