using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libTouchDB.a", LinkTarget.ArmV7 | LinkTarget.Simulator, LinkerFlags = "-lz -lsqlite3", Frameworks = "SystemConfiguration CFNetwork", ForceLoad=true)]
