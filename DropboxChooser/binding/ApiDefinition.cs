using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Dropins.Chooser.iOS
{
	delegate void DBChooserCompletionHandler (DBChooserResult [] results);

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	interface DBChooser {

		[Static]
		[Export ("defaultChooser")]
		DBChooser DefaultChooser { get; }

		[Export ("initWithAppKey:")]
		IntPtr Constructor (string appKey);

		[Export ("openChooserForLinkType:fromViewController:completion:")]
		void OpenChooser (DBChooserLinkType linkType, UIViewController topViewController, DBChooserCompletionHandler handler);

		[Export ("handleOpenURL:")]
		bool HandleOpenUrl (NSUrl url);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	interface DBChooserResult {

		[Export ("link")]
		NSUrl Link { get; }

		[Export ("name")]
		string Name { get; }

		[Export ("size")]
		long Size { get; }

		[Export ("iconURL")]
		NSUrl IconUrl { get; }

		[Export ("thumbnails")]
		NSDictionary Thumbnails { get; }
	}
}