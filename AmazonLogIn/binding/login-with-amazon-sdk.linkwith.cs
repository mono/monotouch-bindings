using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("login-with-amazon-sdk.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, Frameworks = "Security", ForceLoad = true)]
