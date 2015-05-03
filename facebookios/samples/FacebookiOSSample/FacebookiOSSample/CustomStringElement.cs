using System;
using MonoTouch.Dialog;
using UIKit;

namespace FacebookiOSSample
{
	public class CustomStringElement : StringElement
	{
		bool eventAssigned = false;
		nfloat fontSize;

		public CustomStringElement (string caption, Action tapped) : this (caption, tapped, 15)
		{
		}

		public CustomStringElement (string caption, Action tapped, nfloat fontSize) : base (caption)
		{
			Tapped += tapped;
			eventAssigned = true;
			this.fontSize = fontSize;
		}

		public CustomStringElement (string caption, string value) : this (caption, value, 15)
		{
		}

		public CustomStringElement (string caption, string value, nfloat fontSize) : base (caption)
		{
			this.Value = value;
			this.fontSize = fontSize;
		}

		public CustomStringElement (string caption) : this (caption, 15)
		{
		}

		public CustomStringElement (string caption, nfloat fontSize) : base (caption)
		{
		}

		public override UITableViewCell GetCell (UITableView tv)
		{
			UITableViewCell cell = tv.DequeueReusableCell ((Value != null) ? Value : "CustomStringElementId");
			if (cell == null) {
				cell = new UITableViewCell (Value != null ? UITableViewCellStyle.Value1 : UITableViewCellStyle.Default, "CustomStringElementId");
				cell.SelectionStyle = eventAssigned ? UITableViewCellSelectionStyle.Blue : UITableViewCellSelectionStyle.None;
			}
			cell.Accessory = UITableViewCellAccessory.None;
			cell.TextLabel.Text = Caption;
			cell.TextLabel.TextAlignment = Alignment;
			cell.TextLabel.Font = UIFont.SystemFontOfSize (fontSize);
			if (cell.DetailTextLabel != null) {
				cell.DetailTextLabel.Text = ((this.Value != null) ? this.Value : string.Empty);
				cell.DetailTextLabel.Font = UIFont.SystemFontOfSize (12);
			}
			return cell;
		}
	}
}

