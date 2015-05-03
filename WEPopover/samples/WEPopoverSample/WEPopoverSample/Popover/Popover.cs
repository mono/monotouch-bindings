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
using UIKit;
using CoreGraphics;

namespace WEPopoverSample
{
	public static class Popover
	{
		public static bool ShouldDismiss { get; set; }
		public static bool IsInitialized { get; private set; }
		
		static PopoverController _PopoverController;
		
		public static UIViewController ContentViewController {
			get { return _PopoverController.ContentViewController; }
			set { _PopoverController.ContentViewController = value; }
		}
		
		public static CGSize ContentSize {
			get { return _PopoverController.ContentSize; }
			set { _PopoverController.ContentSize = value; }
		}
		
		public static Action<PopoverController> PopoverClosed { get; set; }
		
		public static PopoverContainerViewProperties Properties { 
			get { return _PopoverController.Properties; }
			set { _PopoverController.Properties = value; }
		}
		
		
		public static void Initialize()
		{
			if(IsInitialized == false) {
				_PopoverController = new PopoverController();
				
				if (_PopoverController.ContentViewController != null) {
					_PopoverController.ContentViewController = ContentViewController;
				}
				
				if(Properties == null) {
					Properties = DefaultPopoverProperties();
				}
				
				_PopoverController.Delegate = new PopoverDelegate();
			}
		}
		
		public static void PresentFromRect(CGRect rect, UIView view, UIPopoverArrowDirection arrowDirection, bool animated)
		{
			_PopoverController.PresentPopover (rect, view, arrowDirection, animated);
		}
		
		class PopoverDelegate : PopoverControllerDelegate
		{
			public override bool ShouldDismissPopover(PopoverController popover)
			{
				return ShouldDismiss;
			}
			
			public override void DidDismissPopover(PopoverController popover)
			{
				PopoverClosed(popover);
			}
		}
		
		private static PopoverContainerViewProperties DefaultPopoverProperties()
		{
			var imageSize = new CGSize (30.0f, 30.0f);
			var bgMargin = 6.0f;
			var contentMargin = 2.0f;
			var popoverImagePath = @"Images/popover/";
			
			return new PopoverContainerViewProperties	
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

