using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libUAirship-1.4.0.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7,
                     Frameworks = "MobileCoreServices CFNetwork CoreGraphics Security SystemConfiguration CoreTelephony StoreKit CoreLocation MessageUI AudioToolbox MapKit", LinkerFlags = "-lsqlite3", ForceLoad = true)]
