using System;
using ObjCRuntime;

[assembly: LinkWith ("libWEPopover.a",
	LinkTarget.Simulator | LinkTarget.Simulator64 |LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64,
	Frameworks = "Foundation UIKit CoreGraphics QuartzCore",
	SmartLink = true, 
	ForceLoad = true)]
