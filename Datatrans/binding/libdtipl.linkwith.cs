using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libdtipl.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, SmartLink = true, ForceLoad = true, LinkerFlags = "-lxml2")]
