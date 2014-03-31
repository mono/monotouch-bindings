using System;
using MonoTouch.ObjCRuntime;

/*
Required Linking Frameworks:

CoreGraphics.framework
CoreText.framework
Foundation.framework
QuartzCore.framework
Security.framework
SystemConfiguration.framework
UIKit.framework
*/

//CoreGraphics CoreText Foundation QuartzCore Security SystemConfiguration UIKit
[assembly: LinkWith ("HockeySDK.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, Frameworks = "CoreGraphics CoreText Foundation QuartzCore Security SystemConfiguration UIKit")]
