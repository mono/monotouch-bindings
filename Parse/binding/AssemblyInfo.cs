using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("Parse", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, LinkerFlags = "-lsqlite3 -lz",Frameworks = "MobileCoreServices CoreGraphics SystemConfiguration AudioToolbox Security StoreKit AssetsLibrary Accounts AdSupport Social CFNetwork CoreLocation QuartzCore", ForceLoad = true)]