using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libGoogleAdMobAds.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true, Frameworks = "AudioToolbox MessageUI SystemConfiguration CoreGraphics")]
