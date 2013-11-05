using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libRedLaserSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, Frameworks = "AudioToolbox AVFoundation CFNetwork CoreMedia CoreVideo OpenGLES Security SystemConfiguration CoreLocation", ForceLoad = true, IsCxx = true, LinkerFlags = "-lstdc++")]
