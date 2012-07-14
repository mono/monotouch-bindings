using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

using Couchbase;

namespace CouchSample
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		DialogViewController dvc;
		UIWindow window;
		CouchTouchDBServer server;
		CouchDatabase database;
		CouchDesignDocument design;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			NSError error;

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.MakeKeyAndVisible ();
			dvc = new DialogViewController (new RootElement ("CouchDemo") {
				new Section ("Welcome")
			});
			window.RootViewController = new UINavigationController (dvc);		

			server = new CouchTouchDBServer ();
			if (server.Error != null){
				Console.WriteLine ("Error with the code: {0}", server.Error);
			}
			database = server.GetDatabase ("grocery-sync");
			database.EnsureCreated (out error);
			database.TracksChanges = true;

			//
			// Create a view with documents sorted by date
			//
			design = database.DesignDocumentWithName ("grocery");
			design.DefineView ("byDate", (doc,emit) => {
				var date = doc ["created_at"];
				if (date != null)
					emit (date, doc);
			}, "1.0");

			// Validation function requiring parseable dates
			design.SetValidationBlock ((newRevision,context)=>{
				if (newRevision.Deleted)
					return true;
				var date = newRevision.Properties ["created_at"];
				if (date != null && RestBody.DateWithJSONObject (date) == null){
					context.ErrorMessage = "Invalid date";
					return false;
				}
				return true;
			});
			return true;
		}

		static void Main (string[] args)
		{
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}

