using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libAdJitsuSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7, "-lxml2 -lsqlite3", Frameworks = "AVFoundation CoreGraphics CoreMedia CoreMotion CoreText MediaPlayer OpenGLES QuartzCore", ForceLoad = true, IsCxx = true)]
