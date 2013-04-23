using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libGoogleAdMobAds.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true, Frameworks = "AudioToolbox MessageUI SystemConfiguration CoreGraphics MediaPlayer StoreKit", WeakFrameworks = "AdSupport", IsCxx = true, LinkerFlags = "-lz -lsqlite3")]