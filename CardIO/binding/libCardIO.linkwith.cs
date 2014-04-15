using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libCardIO.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, IsCxx = true, WeakFrameworks="AudioToolbox AVFoundation CoreGraphics CoreMedia Foundation MobileCoreServices OpenGLES QuartzCore Security UIKit")]
