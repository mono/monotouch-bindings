using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libMTSCRA.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Thumb, "-lc++", Frameworks = "AudioToolbox CoreGraphics ExternalAccessory", ForceLoad = true, IsCxx = true)]
