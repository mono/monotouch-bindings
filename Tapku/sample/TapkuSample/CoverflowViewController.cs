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
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Drawing;
using Tapku;

namespace TapkuSample
{
	public class CoverflowViewController : UIViewController
	{
		TKCoverflowView coverflow;
		public UIImage[] covers;
		public CoverflowViewController ()
		{
		}
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return toInterfaceOrientation == UIInterfaceOrientation.LandscapeLeft || toInterfaceOrientation == UIInterfaceOrientation.LandscapeRight;
		}
		
		public override void LoadView ()
		{
			var rect = UIScreen.MainScreen.Bounds;
			rect = CGAffineTransform.CGRectApplyAffineTransform (rect, CGAffineTransform.MakeRotation ((float)(90f * Math.PI / 180f)));
			rect.Location = PointF.Empty;
			this.View = new UIView (rect);
			this.View.BackgroundColor = UIColor.White;
			this.View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			rect = this.View.Bounds;
			rect.Height = 1000;
			
			coverflow = new TKCoverflowView ();
			coverflow.Frame = this.View.Bounds;
			coverflow.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			
			coverflow.CoverAtIndexWasBroughtToFront += delegate(object sender, CoverWasBroughtToFrontEventArgs e) {
				
			};
			coverflow.CoverAtIndexWasDoubleTapped += delegate(object sender, CoverWasDoubleTappedEventArgs e) {
				
			};
			
			coverflow.DataSource = new CoverDataSource(this);
			//coverflow.CoverflowViewcoverAtIndex = CoverflowViewcoverAtIndex;
			//coverflow.
			
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				coverflow.CoverSpacing = 100;
				coverflow.CoverSize = new SizeF (300, 300);
			}
			this.View.AddSubview (coverflow);
			/*
	if([UIDevice currentDevice].userInterfaceIdiom == UIUserInterfaceIdiomPhone){
		
		UIButton *btn = [UIButton buttonWithType:UIButtonTypeRoundedRect];
		btn.frame = CGRectMake(0,0,100,20);
		[btn setTitle:@"# Covers" forState:UIControlStateNormal];
		[btn addTarget:self action:@selector(changeNumberOfCovers) forControlEvents:UIControlEventTouchUpInside];
		[self.view addSubview:btn];
	}else{
		
		UIBarButtonItem *nocoversitem = [[UIBarButtonItem alloc] initWithTitle:@"# Covers" 
																  style:UIBarButtonItemStyleBordered 
																 target:self action:@selector(changeNumberOfCovers)];
		
		UIBarButtonItem *flex = [[UIBarButtonItem alloc] initWithBarButtonSystemItem:UIBarButtonSystemItemFlexibleSpace target:nil action:nil];
								  
		self.toolbarItems = [NSArray arrayWithObjects:flex,nocoversitem,nil];
		[nocoversitem release];
		[flex release];
	}
		

	CGSize s = self.view.bounds.size;
	
	UIButton *infoButton = [UIButton buttonWithType:UIButtonTypeInfoLight];
	[infoButton addTarget:self action:@selector(info) forControlEvents:UIControlEventTouchUpInside];
	infoButton.frame = CGRectMake(s.width-50, 5, 50, 30);
	[self.view addSubview:infoButton];
	*/
		}
		TKCoverflowCoverView CoverflowViewcoverAtIndex (TKCoverflowView coverflowView, int index)
			{
				var cover = coverflowView.DequeueReusableCoverView();
				if(cover == null)
				{
					cover = new TKCoverflowCoverView();
					cover.Frame = new RectangleF(0,0,224,300);
					cover.Baseline = 224;
				}
				cover.Image = covers[index];
				return cover;
			}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad();
			covers = new UIImage[]{
				new UIImage("Images/coverflow_ipad/cover_1.jpg"),
				new UIImage("Images/coverflow_ipad/cover_2.jpg"),
				new UIImage("Images/coverflow_ipad/cover_3.jpg"),
				new UIImage("Images/coverflow_ipad/cover_4.jpg"),
				new UIImage("Images/coverflow_ipad/cover_5.jpg"),
				new UIImage("Images/coverflow_ipad/cover_6.jpg"),
				new UIImage("Images/coverflow_ipad/cover_7.jpg"),
				new UIImage("Images/coverflow_ipad/cover_8.jpg"),
				new UIImage("Images/coverflow_ipad/cover_9.jpg"),
			};
			coverflow.NumberOfCovers = 580;
		}
		
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			coverflow.BringCoverAtIndexToFront(covers.Length * 2,false);
		}
		
		public class CoverDelegate : TKCoverflowViewDelegate
		{
			public override void CoverAtIndexWasBroughtToFront (TKCoverflowView coverflowView, int index)
			{
				Console.WriteLine("Front " + index);
			}

			#region implemented abstract members of Tapku.TKCoverflowViewDelegate
			public override void CoverAtIndexWasDoubleTapped (TKCoverflowView coverflowView, int index)
			{
				// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			}
			#endregion
		}
		public class CoverDataSource : TKCoverflowViewDataSource
		{
			CoverflowViewController Vc;
			public CoverDataSource (CoverflowViewController vc)
			{
				Vc = vc;
			}
			public override TKCoverflowCoverView CoverflowViewcoverAtIndex (TKCoverflowView coverflowView, int index)
			{
				var cover = coverflowView.DequeueReusableCoverView();
				if(cover == null)
				{
					cover = new TKCoverflowCoverView();
					cover.Frame = new RectangleF(0,0,224,300);
					cover.Baseline = 224;
				}
				cover.Image = Vc.covers[index];
				return cover;
			}
		}
		
	}
	
}

