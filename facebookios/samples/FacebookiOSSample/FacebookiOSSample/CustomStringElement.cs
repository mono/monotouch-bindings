using System;
using UIKit;
using Foundation;
using MonoTouch.Dialog;

namespace FBExam
{
	public class CustomStringElement : StringElement
	{
		UITableViewCell cell;

		public new string Value {
			get { return base.Value; }
			set { 
				base.Value = value;
				if (cell != null) {
					cell.TextLabel.Text = value;
					cell.SetNeedsLayout ();
				}
			}
		}

		public CustomStringElement (string caption, Action tapped) : base (caption, tapped)
		{
		}

		public override UITableViewCell GetCell (UIKit.UITableView tv)
		{
			cell = base.GetCell (tv);
			return cell;
		}

		protected override NSString CellKey {
			get { return new NSString ("CustomStringElementId"); }
		}
	}
}

