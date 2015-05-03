using System;
using MonoTouch.Foundation;

namespace PinterestSDK.Pinit
{
	public partial class Pinterest
	{
		static NSString nsclientId;
		static NSString nssuffix;

		public Pinterest (string clientId) : 
			this ((nsclientId = new NSString (clientId)))
		{	
		}

		public Pinterest (string clientId, string suffix) : 
			this ((nsclientId = new NSString (clientId)), (nssuffix = new NSString (suffix)))
		{
		}
	}
}

