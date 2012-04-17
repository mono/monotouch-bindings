using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libMTSCRA.a", LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.Thumb, "-lc++", Frameworks = "AudioToolbox CoreGraphics ExternalAccessory", ForceLoad = true, IsCxx = true)]
