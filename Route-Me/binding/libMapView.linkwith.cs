using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libMapView.a", LinkTarget.ArmV7 | LinkTarget.Simulator, 
                     Frameworks = "CoreLocation QuartzCore UIKit Foundation CoreGraphics", 
                     LinkerFlags = "-lz -lsqlite3", ForceLoad = true, IsCxx = true)]
