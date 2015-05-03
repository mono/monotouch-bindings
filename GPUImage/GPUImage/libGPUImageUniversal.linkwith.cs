using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libGPUImageUniversal.a", LinkTarget.ArmV7 | LinkTarget.Simulator, Frameworks = "AVFoundation OpenGLES CoreVideo QuartzCore", ForceLoad = true)]
