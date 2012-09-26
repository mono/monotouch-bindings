using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libMobclix.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, Frameworks = "AddressBook AddressBookUI AudioToolbox AVFoundation MediaPlayer MessageUI QuartzCore SystemConfiguration", WeakFrameworks = "EventKit CoreMotion iAd", ForceLoad = true)]
