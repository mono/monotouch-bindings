using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libCouchCocoa.a", LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true)]
[assembly: LinkWith ("libTouchDB.a", LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true)]
