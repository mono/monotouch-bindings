// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace CouchbaseSample
{
	[Register ("RootViewController")]
	partial class RootViewController
	{
		[Outlet]
		Couchbase.CBLUITableSource Datasource { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField EntryField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView TableView { get; set; }

		[Action ("AddNewEntry:")]
		partial void AddNewEntry (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Datasource != null) {
				Datasource.Dispose ();
				Datasource = null;
			}

			if (EntryField != null) {
				EntryField.Dispose ();
				EntryField = null;
			}

			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}
		}
	}
}
