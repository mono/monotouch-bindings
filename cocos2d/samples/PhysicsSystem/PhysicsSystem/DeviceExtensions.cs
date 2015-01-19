using System;

using UIKit;

namespace PhysicsSystem
{
	public static class DeviceExtensions
	{
		public static bool IsIPad (this UIDevice device)
		{
			return device.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad;
		}

		public static bool IsIPhone (this UIDevice device)
		{
			return device.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone;
		}
	}
}