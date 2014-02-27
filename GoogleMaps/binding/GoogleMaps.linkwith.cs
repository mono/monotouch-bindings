using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("GoogleMaps", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s,"-ObjC -lz -licucore -lc++", Frameworks = "AVFoundation CoreData CoreLocation CoreText GLKit ImageIO OpenGLES QuartzCore SystemConfiguration", SmartLink = true, ForceLoad = true, IsCxx = true)]
