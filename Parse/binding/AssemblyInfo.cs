using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("Parse", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7,Frameworks = "MobileCoreServices CoreGraphics SystemConfiguration AudioToolbox Security StoreKit", ForceLoad = true)]
