using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libGoogleAdMobAds.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true, Frameworks = "AudioToolbox MessageUI SystemConfiguration CoreGraphics MediaPlayer", WeakFrameworks = "AdSupport", IsCxx = true, LinkerFlags = "-lz -lsqlite3")]
[assembly: LinkWith ("libAdmobExporter.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]