using System;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

[assembly: LinkerSafe]
[assembly: LinkWith ("libcocos2d.a",LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true, Frameworks = "OpenGLES CoreGraphics QuartzCore CoreText")]
#if ENABLE_CHIPMUNK_INTEGRATION
[assembly: LinkWith ("libChipmunk.a",LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true)]
#endif
