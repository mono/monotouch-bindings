using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libInMobi.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, LinkerFlags = "-lsqlite3.0 -lz -ObjC", Frameworks = "AdSupport AudioToolbox AVFoundation CoreTelephony MediaPlayer MessageUI Security Social StoreKit SystemConfiguration", SmartLink = true, ForceLoad = true)]
