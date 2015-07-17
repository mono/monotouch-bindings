using System;
using MonoTouch.Dialog;

namespace FacebookiOSSample
{
	public class CustomCheckboxElement : CheckboxElement
	{
		UIKit.UITableViewCell cell;

		bool enabled = true;

		public bool Enabled {
			get { return enabled; }
			set { 
				if (cell != null) {
					cell.UserInteractionEnabled = value;
					cell.TextLabel.Enabled = value;
				}
				enabled = value;
			}
		}

		public CustomCheckboxElement (string caption, bool value, string group) : this (caption, value)
		{
			Group = group;
		}

		public CustomCheckboxElement (string caption, bool value) : base (caption)
		{
			Value = value;
		}

		public CustomCheckboxElement (string caption) : base (caption)
		{
		}

		public CustomCheckboxElement (string caption, bool value, string group, Action tappedAction) : this (caption, value, group)
		{
			Tapped += tappedAction;
		}

		public CustomCheckboxElement (string caption, bool value, Action tappedAction) : this (caption, value)
		{
			Tapped += tappedAction;
		}

		public CustomCheckboxElement (string caption, Action tappedAction) : base (caption)
		{
			Tapped += tappedAction;
		}

		public override UIKit.UITableViewCell GetCell (UIKit.UITableView tv)
		{
			cell = base.GetCell (tv);
			cell.UserInteractionEnabled = enabled;
			cell.TextLabel.Enabled = enabled;
			return cell;
		}

		protected override Foundation.NSString CellKey {
			get {
				return new Foundation.NSString ("CustomCheckboxElementId");
			}
		}
	}
}

