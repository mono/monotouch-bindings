using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libThree20SDK.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true)]
[assembly: LinkWith ("libThree20CoreSDK.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true)]
[assembly: LinkWith ("libThree20NetworkSDK.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true)]
[assembly: LinkWith ("libThree20StyleSDK.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true)]
[assembly: LinkWith ("libThree20UISDK.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, Frameworks = "QuartzCore", ForceLoad = true)]
[assembly: LinkWith ("libThree20UICommonSDK.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true)]
[assembly: LinkWith ("libThree20UINavigatorSDK.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true)]
