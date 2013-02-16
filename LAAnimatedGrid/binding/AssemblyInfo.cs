using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libLAAnimatedGrid.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, Frameworks = "MobileCoreServices QuartzCore SystemConfiguration CoreGraphics")]
