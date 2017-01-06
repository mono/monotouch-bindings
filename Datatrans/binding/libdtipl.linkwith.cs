using System;
using ObjCRuntime;

[assembly: LinkWith ("libdtipl.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64 , SmartLink = true, ForceLoad = true, LinkerFlags = "-lxml2 -all_load -ObjC", Frameworks = "Security")]

