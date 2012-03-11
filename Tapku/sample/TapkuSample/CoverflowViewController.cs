// 
//  Copyright 2012  Xamarin Inc  (http://www.xamarin.com)
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
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Drawing;
using Tapku;
using System.IO;
using MonoTouch.Foundation;

namespace TapkuSample
{
	public class CoverflowViewController : UIViewController
	{
		public UIImage[] Covers { get; private set; }
		
		TKCoverflowView coverflow;
		TKCoverflowViewDelegate _coverFlowDelegate;
		TKCoverflowViewDataSource _coverFlowDataSource;
		
		
		public CoverflowViewController ()
		{
		}
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			bool isPhone = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone;
			if(isPhone) {
				return (toInterfaceOrientation == UIInterfaceOrientation.LandscapeRight);
			}
			
			return true;
		}
		
		public override void LoadView ()
		{
			var rect = UIScreen.MainScreen.Bounds;
			
			rect = CGAffineTransform.CGRectApplyAffineTransform (rect, CGAffineTransform.MakeRotation ((float)(90.0f * Math.PI / 180.0f)));
			rect.Location = PointF.Empty;
			this.View = new UIView (rect);
			
			this.View.BackgroundColor = UIColor.White;
			this.View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			
			rect = this.View.Bounds;
			rect.Height = 1000;
			
			_coverFlowDelegate = new CoverDelegate();
			_coverFlowDataSource = new CoverDataSource(this);
			
			coverflow = new TKCoverflowView(this.View.Bounds);
			coverflow.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			coverflow.CoverflowDelegate = _coverFlowDelegate;
			coverflow.DataSource = _coverFlowDataSource;
			
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				coverflow.CoverSpacing = 100;
				coverflow.CoverSize = new SizeF (300, 300);
			}
			
			this.View.AddSubview (coverflow);
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad();
			
			if(UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {
				Covers = new UIImage[]{
					UIImage.FromBundle("Images/coverflow_iphone/cover_1.jpg"),
					UIImage.FromBundle("Images/coverflow_iphone/cover_2.jpg"),
					UIImage.FromBundle("Images/coverflow_iphone/cover_3.jpg"),
					UIImage.FromBundle("Images/coverflow_iphone/cover_4.jpg"),
					UIImage.FromBundle("Images/coverflow_iphone/cover_5.jpg"),
					UIImage.FromBundle("Images/coverflow_iphone/cover_6.jpg"),
					UIImage.FromBundle("Images/coverflow_iphone/cover_7.jpg"),
					UIImage.FromBundle("Images/coverflow_iphone/cover_8.jpg"),
					UIImage.FromBundle("Images/coverflow_iphone/cover_9.jpg"),
				};
			}
			else {
				Covers = new UIImage[]{
					UIImage.FromBundle("Images/coverflow_ipad/ipadcover_1.jpg"),
					UIImage.FromBundle("Images/coverflow_ipad/ipadcover_2.jpg"),
					UIImage.FromBundle("Images/coverflow_ipad/ipadcover_3.jpg"),
					UIImage.FromBundle("Images/coverflow_ipad/ipadcover_4.jpg"),
					UIImage.FromBundle("Images/coverflow_ipad/ipadcover_5.jpg"),
					UIImage.FromBundle("Images/coverflow_ipad/ipadcover_6.jpg"),
					UIImage.FromBundle("Images/coverflow_ipad/ipadcover_7.jpg"),
					UIImage.FromBundle("Images/coverflow_ipad/ipadcover_8.jpg"),
					UIImage.FromBundle("Images/coverflow_ipad/ipadcover_9.jpg"),
				};
			}
			
			coverflow.SetNumberOfCovers(580);
		}
		
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			coverflow.BringCoverAtIndexToFront(Covers.Length * 2, false);
		}
		
		public class CoverDelegate : TKCoverflowViewDelegate
		{
			public CoverDelegate()
			{
			}
			
			public override void CoverAtIndexWasBroughtToFront (TKCoverflowView coverflowView, int index)
			{
				Console.WriteLine("Front " + index);
			}

			#region implemented abstract members of Tapku.TKCoverflowViewDelegate
			public override void CoverAtIndexWasDoubleTapped (TKCoverflowView coverflowView, int index)
			{
				Console.WriteLine("Cover At Index {0} was Double Tapped", index);
				
				var cover = coverflowView.CoverAtIndex(index);
				
				if(cover == null)
					return;
				
				UIView.BeginAnimations("coverFlowViewTapAnimation");
				UIView.SetAnimationDuration(1);
				UIView.SetAnimationTransition(UIViewAnimationTransition.FlipFromLeft, cover, true);
				UIView.CommitAnimations();
			}
			#endregion
		}
		

		public class CoverDataSource : TKCoverflowViewDataSource
		{
			
			CoverflowViewController _viewController;
			
			public CoverDataSource (CoverflowViewController vc)
				: base()
			{
				_viewController = vc;
			}
			
			public override TKCoverflowCoverView CoverflowViewcoverAtIndex (TKCoverflowView coverflowView, int index)
			{
				var cover = coverflowView.DequeueReusableCoverView();
				
				if(cover == null) {
					bool isPhone = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone;
					var frame = isPhone ? new RectangleF(0, 0, 224, 300) : new RectangleF(0, 0, 300, 600);
					
					cover = new TKCoverflowCoverView(frame);
					cover.Baseline = 224;
				}
				
				var coverIndex = index % _viewController.Covers.Length;
				cover.Image = _viewController.Covers[coverIndex];
				return cover;
			}
		}
		
		
	}
	
}

