using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libRedLaserSDK.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, Frameworks = "AudioToolbox AVFoundation CFNetwork CoreMedia CoreVideo OpenGLES Security SystemConfiguration CoreLocation", ForceLoad = true, IsCxx = true, NeedsGccExceptionHandling = true)]
