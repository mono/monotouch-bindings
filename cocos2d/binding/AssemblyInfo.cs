using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libcocos2d.a",LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true, Frameworks = "OpenGLES CoreGraphics QuartzCore")]
#if ENABLE_CHIPMUNK_INTEGRATION
[assembly: LinkWith ("libChipmunk.a",LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]
#endif
