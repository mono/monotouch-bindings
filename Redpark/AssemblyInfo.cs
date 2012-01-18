using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libRscMgrUniv.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7,Frameworks = "ExternalAccessory", ForceLoad = true)]
