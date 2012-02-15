using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libTapkuLibraryUniversal.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true)]
