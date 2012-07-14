using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libTouchDB.a", LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true)]
