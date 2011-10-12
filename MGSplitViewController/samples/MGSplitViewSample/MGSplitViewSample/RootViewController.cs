// 
// RootViewController.cs
//  
// Author: Jeffrey Stedfast <jeff@xamarin.com>
// 
// Copyright (c) 2011 Xamarin Inc.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 

using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MGSplitViewSample
{
	public class RootViewController : UITableViewController
	{
		class RootTableViewSource : UITableViewSource {
			static NSString key = new NSString ("RootCell");
			
			public RootTableViewSource ()
			{
			}
			
			public override int NumberOfSections (UITableView tableView)
			{
				return 1;
			}
			
			public override int RowsInSection (UITableView tableview, int section)
			{
				return 10;
			}
			
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (key);
				
				if (cell == null)
					cell = new UITableViewCell (UITableViewCellStyle.Default, key);
				
				cell.TextLabel.Text = string.Format ("Row {0}", indexPath.Row);
				
				return cell;
			}
		}
		
		public RootViewController ()
		{
			TableView.Source = new RootTableViewSource ();
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			ContentSizeForViewInPopover = new SizeF (320.0f, 600.0f);
			ClearsSelectionOnViewWillAppear = false;
		}
	}
}

