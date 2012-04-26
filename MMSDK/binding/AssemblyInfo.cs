using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libMMSDK_4.5.5.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, Frameworks = "CoreGraphics QuartzCore MediaPlayer CoreLocation MobileCoreServices AudioToolbox AVFoundation SystemConfiguration UIKit", ForceLoad = true)]
