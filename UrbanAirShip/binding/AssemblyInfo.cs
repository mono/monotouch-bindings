using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libUAirship-1.2.0.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7,
                     Frameworks = "CFNetwork CoreGraphics Foundation MobileCoreServices Security SystemConfiguration UIKit CoreTelephony StoreKit CoreLocation", LinkerFlags = "-lsqlite3", ForceLoad = true)]
