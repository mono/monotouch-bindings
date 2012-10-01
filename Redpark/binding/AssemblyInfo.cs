using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libRscMgrUniv.a", LinkTarget.ArmV7 | LinkTarget.Simulator, Frameworks = "ExternalAccessory", ForceLoad = true)]
