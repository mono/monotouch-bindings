using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Couchbase;
using System.Diagnostics;
using System.Linq;

namespace CouchbaseSample
{

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

		public override void WillUseCell (CBLUITableSource source, UITableViewCell cell, QueryRow row)
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
