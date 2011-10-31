using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libRedLaserSDK.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, Frameworks = "AVFoundation CFNetwork CoreMedia CoreVideo OpenGLES Security SystemConfiguration", ForceLoad = true, IsCxx = true, NeedsGccExceptionHandling = true)]
