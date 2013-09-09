using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Couchbase;
using System.Diagnostics;
using System.Linq;

namespace CouchbaseSample.iOS
{
	public partial class RootViewController : UIViewController
	{
		const string DefaultViewName = "byDate";
		const string DocumentDisplayPropertyName = "text";
		internal const string CheckboxPropertyName = "check";

 		public CBLDatabase Database { get; set; }

		public RootViewController () : base ("RootViewController", null)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Grocery Sync", "Grocery Sync");
		}

		public DetailViewController DetailViewController { get;	set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var deleteButton = new UIBarButtonItem ("Clean", UIBarButtonItemStyle.Plain, DeleteCheckedItems);
			NavigationItem.RightBarButtonItem = deleteButton;

			EntryField.ShouldEndEditing += (sender) => { 
				EntryField.ResignFirstResponder (); 
				return true; 
			};

			EntryField.EditingDidEndOnExit += AddNewItem;

			// Custom initialization
			InitializeDatabase ();
			InitializeCouchbaseView ();
			InitializeDatasource ();

			Datasource.TableView = TableView;
			Datasource.TableView.Delegate = new CouchtableDelegate(this, Datasource);

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

		void InitializeCouchbaseView ()
		{
			var view = Database.ViewNamed (DefaultViewName);

			NSObject key = new NSString("created_at");
			var mapBlock = new CBLMapBlock ((doc, aview) => {
				NSObject date  = doc.ObjectForKey (key);
				if (date  != null) {
					aview.Emit (date, doc);
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
			CBLLiveQuery query = view.Query.AsLiveQuery;
			query.Descending = true;

			Datasource.Query = query;
			Datasource.LabelProperty = DocumentDisplayPropertyName; // Document property to display in the cell label
		}

		IEnumerable<NSObject> CheckedDocuments
		{
			get
			{
				var docs = new List<NSObject> ();
				foreach (CBLQueryRow row in Datasource.Rows)
				{
					var doc = row.Document;
					NSObject val;

					if (doc.Properties.TryGetValue ((NSString)CheckboxPropertyName, out val) && ((NSNumber)val).BoolValue)
					{
						docs.Add (doc);
					}
				}
				return docs;
			}
		}

		void AddNewItem (object sender, EventArgs args)
		{
			var value = EntryField.Text;
			if (String.IsNullOrWhiteSpace (value))
				return;

			var rows = Datasource.Rows;
			var rowCount = rows == null ? "null" : rows.Length.ToString();

			var jsonDate = DateTime.UtcNow.ToString("o");
			var vals = NSDictionary.FromObjectsAndKeys (
				new NSObject[] { new NSString(value), NSNumber.FromBoolean(false), new NSString(jsonDate) }, 
			new NSObject[] { new NSString(DocumentDisplayPropertyName), new NSString(CheckboxPropertyName), new NSString("created_at") }
			);

			var doc = Database.UntitledDocument;
			NSError error;
			var result = doc.PutProperties (vals, out error);
			if (result == null)
				throw new ApplicationException ("failed to save a new document");

			EntryField.Text = null;
		}

		void DeleteCheckedItems (object sender, EventArgs args)
		{
			var numChecked = CheckedDocuments.Count();
			if (numChecked == 0)
				return;

			var prompt = String.Format("Are you sure you want to remove the {0} checked-off item{1}?",
			                           numChecked,
			                           numChecked == 1 ? String.Empty : "s");

			var alert = new UIAlertView ("Remove Completed Items?",
			                            prompt,
			                            null,
			                            "Cancel",
			                            "Remove");

			alert.Dismissed += (alertView, e) => {
				if (e.ButtonIndex == 0) return;

				NSError error;
				Datasource.DeleteDocuments(CheckedDocuments.ToArray(), out error);
			};
			alert.Show ();
		}

		public void ShowErrorAlert (string errorMessage, NSError error, Boolean fatal = false)
		{
			if (error != null)
				errorMessage = String.Format ("{0}\r\n{1}", errorMessage, error.LocalizedDescription);

			var alert = new UIAlertView (fatal ? @"Fatal Error" : @"Error",
			                             errorMessage,
			                             null,
			                             fatal ? null : "Dismiss"
			                             );
			alert.Show ();
		}
	}

	public class CouchtableDelegate : CBLUITableDelegate
	{
		static UIColor backgroundColor;

		RootViewController parent;
		CBLUITableSource dataSource;

		public CouchtableDelegate(RootViewController controller, CBLUITableSource source)
		{
			parent = controller;
			dataSource = source;
		}

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 50f;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var row = dataSource.RowAtIndexPath (indexPath);
			var doc = row.Document;

			// Toggle the document's 'checked' property
			var docContent = doc.Properties.MutableCopy() as NSMutableDictionary;
			var checkedVal = (NSNumber)docContent.ValueForKey ((NSString)RootViewController.CheckboxPropertyName);
			var wasChecked = checkedVal.BoolValue;
			docContent.SetValueForKey (new NSNumber(!wasChecked), (NSString)RootViewController.CheckboxPropertyName);

			NSError error;
			var newRevision = doc.CurrentRevision.PutProperties (docContent, out error);
			if (newRevision == null)
				parent.ShowErrorAlert ("Failed to update item", error, false);
		}

		public override void WillUseCell (CBLUITableSource source, UITableViewCell cell, CBLQueryRow row)
		{
			if (backgroundColor == null)
			{
				var image = UIImage.FromBundle("item_background");
				backgroundColor = UIColor.FromPatternImage (image);
			}

			cell.BackgroundColor = backgroundColor;
			cell.SelectionStyle = UITableViewCellSelectionStyle.Gray;

			cell.TextLabel.Font = UIFont.FromName ("Helvetica", 18f);
			cell.TextLabel.BackgroundColor = UIColor.Clear;

			var props = row.Value as NSDictionary;
			var isChecked = ((NSNumber)props.ValueForKey ((NSString)RootViewController.CheckboxPropertyName)).BoolValue;
			cell.TextLabel.TextColor = isChecked ? UIColor.Gray : UIColor.Black;
			cell.ImageView.Image = UIImage.FromBundle (isChecked 
			                                          ? "list_area___checkbox___checked" 
			                                          : "list_area___checkbox___unchecked");
		}
	}
}
