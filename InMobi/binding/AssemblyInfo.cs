using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libInMobi_iOS.a", LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.Simulator, Frameworks = "SystemConfiguration AVFoundation MediaPlayer Security MessageUI Foundation CoreGraphics UIKit", ForceLoad = true)]
