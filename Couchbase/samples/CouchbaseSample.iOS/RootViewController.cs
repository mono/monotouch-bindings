using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Couchbase;
using System.Diagnostics;

namespace CouchbaseSample.iOS
{
	public partial class RootViewController : UIViewController
	{
		const string DefaultViewName = "byDate";
		const string DocumentDisplayPropertyName = "text";

		public CBLDatabase Database { get; set; }

		public RootViewController () : base ("RootViewController", null)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Grocery Sync", "Grocery Sync");
		}

		public DetailViewController DetailViewController { get;	set; }


		void AddNewItem (object sender, EventArgs args)
		{
			var value = EntryField.Text;
			if (String.IsNullOrWhiteSpace (value))
				return;

			var rows = Datasource.Rows;
			var rowCount = rows == null ? "null" : rows.Length.ToString();
			Debug.WriteLine ("{0}, {1}", value, rowCount);
			foreach (var r in rows)
				Debug.WriteLine (r);

			var jsonDate = DateTime.UtcNow.ToString("o");
			var vals = NSDictionary.FromObjectsAndKeys (
				new NSObject[] { new NSString(value), NSNumber.FromBoolean(false), new NSString(jsonDate) }, 
				new NSObject[] { new NSString(DocumentDisplayPropertyName), new NSString("check"), new NSString("created_at") }
			);

			var doc = Database.UntitledDocument;
			NSError error;
			var result = doc.PutProperties (vals, out error);
			if (result == null)
				throw new ApplicationException ("failed to save a new document");

			EntryField.Text = null;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			EntryField.ShouldEndEditing += (sender) => { 
				EntryField.ResignFirstResponder (); 
				return true; 
			};

			EntryField.EditingDidEndOnExit += AddNewItem;

			// Custom initialization
			InitializeDatabase ();
			InitializeView ();
			InitializeDatasource ();

			Datasource.TableView = this.TableView;
			NavigationController.NavigationBar.TintColor = new UIColor (0.564f, 0.0f, 0.015f, 0f);
		}

		void InitializeDatabase ()
		{
			NSError error;
			var db = CBLManager.SharedInstance.CreateDatabaseNamed ("grocery-sync", out error);
			if (error != null)
				throw new ApplicationException (error.Description);
			else if (db == null)
				throw new ApplicationException("Could not create database");

			Database = db;
		}

		void InitializeView ()
		{
			var view = Database.ViewNamed (DefaultViewName);

			NSObject key = new NSString("created_at");
			var mapBlock = new CBLMapBlock ((doc, emit) => {
				NSObject date  = doc.ObjectForKey (key);
				if (date  != null) {
					emit (date, doc);
				}
			});

			view.SetMapBlock (mapBlock, null, "1.1");

			var validationBlock = new CBLValidationBlock ((revision, context)=>{
				if (revision.IsDeleted) return true;

				NSObject date = revision.Properties.ObjectForKey(key);
				return (date != null);
			});

			Database.DefineValidation ((NSString)key, validationBlock);

		}

		void InitializeDatasource ()
		{
			var view = Database.ViewNamed (DefaultViewName);
			CBLLiveQuery query = view.Query.AsLiveQuery; //[[[database viewNamed: @"byDate"] query] asLiveQuery];
			query.Descending = true;

			Datasource.Query = query;
			Datasource.LabelProperty = DocumentDisplayPropertyName; // Document property to display in the cell label
		}
	}
}
