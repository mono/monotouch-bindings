using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace PinterestSDK.Pinit
{
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	interface Pinterest {
	
		[Internal]
		[Export ("initWithClientId:")]
		IntPtr Constructor (NSString clientId);

		[Internal]
		[Export ("initWithClientId:urlSchemeSuffix:")]
		IntPtr Constructor (NSString clientId, NSString suffix);

		[Export ("canPinWithSDK")]
		bool CanPin { get; }

		[Export ("createPinWithImageURL:sourceURL:description:")]
		void CreatePin (NSUrl imageUrl, NSUrl sourceUrl, string descriptionText);

		[Static]
		[Export ("pinItButton")]
		UIButton GetPinItButton ();

		[Export ("openUserWithUsername:")]
		void OpenUser (string username);

		[Export ("openPinWithIdentifier:")]
		void OpenPin (string identifier);

		[Export ("openBoardWithSlug:fromUser:")]
		void OpenPin (string slug, string username);

	}
}

