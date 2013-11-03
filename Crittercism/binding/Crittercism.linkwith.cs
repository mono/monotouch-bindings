using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libCrittercism.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true, Frameworks="SystemConfiguration Foundation")]
