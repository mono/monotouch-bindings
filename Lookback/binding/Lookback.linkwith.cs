using System;
using MonoTouch.ObjCRuntime;
[assembly: LinkWith ("Lookback", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, Frameworks="AVFoundation AudioToolbox CoreVideo CoreMedia SystemConfiguration MediaPlayer QuartzCore")]