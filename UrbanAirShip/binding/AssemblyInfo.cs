using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libUAirship-1.2.0.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7,
                     Frameworks = "MobileCoreServices", LinkerFlags = "-lsqlite3", ForceLoad = true)]
