using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libGoogleAdMobAds.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, SmartLink = true, ForceLoad = true, Frameworks = "AudioToolbox MessageUI SystemConfiguration CoreGraphics MediaPlayer StoreKit AVFoundation AdSupport CoreTelephony", LinkerFlags = "-lz -lsqlite3 -ObjC")]
