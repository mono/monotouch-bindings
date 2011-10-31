// 
// DetailViewController.cs
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
using System.Collections;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using MG;

namespace MGSplitViewSample
{
	public partial class DetailViewController : UIViewController
	{
		MGSplitViewController splitViewController;
		
		//loads the DetailViewController.xib file and connects it to this object
		public DetailViewController (MGSplitViewController splitViewController) : base ("DetailViewController", null)
		{
			this.splitViewController = splitViewController;
		}
		
		void ConfigureView ()
		{
			master.Title = splitViewController.IsShowingMaster ? "Hide Master" : "Show Master";
			vertical.Title = splitViewController.Vertical ? "Horizontal Split" : "Vertical Split";
			divider.Title = (splitViewController.DividerStyle == MGSplitViewDividerStyle.Thin) ? "Enable Dragging" : "Disable Dragging";
			order.Title = (splitViewController.MasterBeforeDetail) ? "Detail First" : "Master First";
		}
		
		public void AddButton (UIBarButtonItem button)
		{
			List<UIBarButtonItem> items = new List<UIBarButtonItem> (toolbar.Items);
			
			items.Insert (0, button);
			
			toolbar.SetItems (items.ToArray (), true);
		}
		
		public void RemoveButton (UIBarButtonItem button)
		{
			List<UIBarButtonItem> items = new List<UIBarButtonItem> (toolbar.Items);
			if (items.Remove (button))
				toolbar.SetItems (items.ToArray (), true);
		}
		
		partial void ShowMasterToggled (NSObject sender)
		{
			splitViewController.ToggleMasterView (sender);
			ConfigureView ();
		}
		
		partial void VerticalToggled (NSObject sender)
		{
			splitViewController.ToggleSplitOrientation (sender);
			ConfigureView ();
		}
		
		partial void DividerToggled (NSObject sender)
		{
			MGSplitViewDividerStyle style = (splitViewController.DividerStyle == MGSplitViewDividerStyle.Thin) ? MGSplitViewDividerStyle.PaneSplitter : MGSplitViewDividerStyle.Thin;
			
			splitViewController.SetDividerStyle (style, true);
			ConfigureView ();
		}
		
		partial void OrderToggled (NSObject sender)
		{
			splitViewController.ToggleMasterBeforeDetail (sender);
			ConfigureView ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
		
		public override void DidRotate (UIInterfaceOrientation fromInterfaceOrientation)
		{
			base.DidRotate (fromInterfaceOrientation);
			
			ConfigureView ();
		}
	}
}
