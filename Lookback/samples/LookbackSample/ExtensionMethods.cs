using System;
using MonoTouch.Foundation;

namespace LookbackSample
{
	public static class ExtensionMethods
	{
		public static NSString ToNSString(this String str)
		{
			return new NSString(str);
		}
	}
}

