using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libSDSegmentedControl.a", LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.ArmV7s, LinkerFlags = "-ObjC -fobjc-arc", Frameworks = "QuartzCore CoreGraphics", ForceLoad = true)]
