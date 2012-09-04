using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libcocos2d.a",LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true, Frameworks = "OpenGLES CoreGraphics QuartzCore")]
