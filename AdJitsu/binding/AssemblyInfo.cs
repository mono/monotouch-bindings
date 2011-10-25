using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libAdJitsuSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7, "-lxml2 -lsqlite3", Frameworks = "AVFoundation CoreGraphics CoreLocation CoreMedia CoreMotion CoreText MediaPlayer MobileCoreServices OpenGLES QuartzCore", ForceLoad = true, IsCxx = true)]
