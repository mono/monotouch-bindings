using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("Opentok", LinkTarget.ArmV7 | LinkTarget.ArmV7s, Frameworks = "CoreTelephony MobileCoreServices CFNetwork SystemConfiguration CoreMedia Security AudioToolbox CoreAudio CoreVideo OpenGLES QuartzCore AVFoundation CoreGraphics", LinkerFlags = "-lstdc++ -lz -ObjC", IsCxx = true, SmartLink = true, ForceLoad = true)]
