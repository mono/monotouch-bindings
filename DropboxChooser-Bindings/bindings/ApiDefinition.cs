using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace DropboxChooser
{
	
	[BaseType (typeof (NSObject))]
	public partial interface DBChooserResult {

		[Export ("link")]
		NSUrl Link { get; }

		[Export ("name")]
		string Name { get; }

		[Export ("size")]
		long Size { get; }

		[Export ("iconURL")]
		NSUrl IconURL { get; }

		[Export ("thumbnails")]
		NSDictionary Thumbnails { get; }
	}



	[BaseType (typeof (NSObject))]
	public partial interface DBChooser {

		[Static, Export ("defaultChooser")]
		DBChooser DefaultChooser { get; }

		[Export ("initWithAppKey:")]
		IntPtr Constructor (string appKey);

		[Export ("openChooserForLinkType:fromViewController:completion:")]
		void OpenChooserForLinkType (DBChooserLinkType linkType, UIViewController topViewController, DBChooserCompletionBlock blk);

		[Export ("handleOpenURL:")]
		bool HandleOpenURL (NSUrl url);
	}

	[Preserve]
	public delegate void DBChooserCompletionBlock(DBChooserResult[] results);

}

