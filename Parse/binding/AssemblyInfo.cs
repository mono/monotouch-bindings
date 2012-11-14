using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("Parse", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true, Frameworks = "MobileCoreServices CoreGraphics SystemConfiguration AudioToolbox Security StoreKit")]
