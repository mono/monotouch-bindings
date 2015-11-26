using System;
using ObjCRuntime;

[assembly: LinkWith ("FBSDKCoreKit.a", LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64, LinkerFlags = "-ObjC", SmartLink = true, ForceLoad = true)]