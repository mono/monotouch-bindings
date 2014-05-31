// 
//  Copyright 2012  abhatia
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using WEPopover;
using MonoTouch.UIKit;
using System.Drawing;

namespace WEPopoverSample
{
	public static class Popover
	{
		public static bool ShouldDismiss { get; set; }
		public static bool IsInitialized { get; private set; }
		
		static WEPopoverController _PopoverController;
		
		public static UIViewController ContentViewController {
			get { return _PopoverController.ContentViewController; }
			set { _PopoverController.ContentViewController = value; }
		}
		
		public static SizeF ContentSize {
			get { return _PopoverController.ContentSize; }
			set { _PopoverController.ContentSize = value; }
		}
		
		public static Action<WEPopoverController> PopoverClosed { get; set; }
		
		public static WEPopoverContainerViewProperties Properties { 
			get { return _PopoverController.Properties; }
			set { _PopoverController.Properties = value; }
		}
		
		
		public static void Initialize()
		{
			if(IsInitialized == false) {
				_PopoverController = new WEPopoverController();
				
				if (_PopoverController.ContentViewController != null) {
					_PopoverController.ContentViewController = ContentViewController;
				}
				
				if(Properties == null) {
					Properties = DefaultPopoverProperties();
				}
				
				_PopoverController.Delegate = new PopoverDelegate();
			}
		}
		
		public static void PresentFromRect(RectangleF rect, UIView view, UIPopoverArrowDirection arrowDirection, bool animated)
		{
			_PopoverController.PresentFromRect(rect, view, arrowDirection, animated);
		}
		
		class PopoverDelegate : WEPopoverControllerDelegate
		{
			public override bool ShouldDismissPopover(WEPopoverController popover)
			{
				return ShouldDismiss;
			}
			
			public override void DidDismissPopover(WEPopoverController popover)
			{
				PopoverClosed(popover);
			}
		}
		
		private static WEPopoverContainerViewProperties DefaultPopoverProperties()
		{
			var imageSize = new SizeF(30.0f, 30.0f);
			var bgMargin = 6.0f;
			var contentMargin = 2.0f;
			var popoverImagePath = @"Images/popover/";
			
			return new WEPopoverContainerViewProperties	
			{
				LeftBackgroundMargin = bgMargin,
				RightBackgroundMargin = bgMargin,
				TopBackgroundMargin = bgMargin,
				BottomBackgroundMargin = bgMargin,
				
				LeftBackgroundCapSize = (int)(imageSize.Width/2),
				TopBackgroundCapSize = (int)(imageSize.Width/2),
				
				LeftContentMargin = contentMargin,
				RightContentMargin = contentMargin,
				TopContentMargin = contentMargin,
				BottomContentMargin = contentMargin,
				ArrowMargin = 1.0f,
				
				BackgroundImageName = popoverImagePath + @"popoverBgSimple.png",
				UpArrowImageName = popoverImagePath + @"popoverArrowUpSimple.png",
				DownArrowImageName = popoverImagePath + @"popoverArrowDownSimple.png",
				LeftArrowImageName = popoverImagePath + @"popoverArrowLeftSimple.png",
				RightArrowImageName = popoverImagePath + @"popoverArrowRightSimple.png",
			};	
		}
		
	}
}

