using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Tapku;
using System.Drawing;

namespace TapkuSample
{
	public partial class ImageCenterViewController : UITableViewController
	{
		public string[] UrlData { get; private set; }
		public TKImageCache ImageCache { get; private set; }
		
		
		//loads the ImageCenterViewController.xib file and connects it to this object
		public ImageCenterViewController ()
			: base()
		{
			
			TableView.Source = new MyTableViewSource(this);
			
			UrlData = new string[] {"http://farm3.static.flickr.com/2797/4196552800_a5de0f3627_t.jpg",
				"http://farm3.static.flickr.com/2380/2417672368_a41257399f_t.jpg",
				"http://farm3.static.flickr.com/2063/2181373837_b32a7e36fd_t.jpg",
				"http://farm4.static.flickr.com/3018/2458286264_8e5bae7ec3_t.jpg",
				"http://farm4.static.flickr.com/3629/3459136258_885598f06a_t.jpg",
				"http://farm4.static.flickr.com/3619/3308615215_63752b7b27_t.jpg",
				"http://farm1.static.flickr.com/3/2451788_febcdb12f6_t.jpg",
				"http://farm4.static.flickr.com/3559/3681486285_2d92961aec_t.jpg",
				"http://farm4.static.flickr.com/3630/3681486481_8f864b67a5_t.jpg",
				"http://farm3.static.flickr.com/2626/3682301814_1fe5081448_t.jpg",
				"http://farm3.static.flickr.com/2655/3951923344_d2bb111a50_t.jpg",
				"http://farm4.static.flickr.com/3229/2723469734_8eeec4e2e4_t.jpg",
				"http://farm4.static.flickr.com/3664/3660136156_dbf8852267_t.jpg",
				"http://farm4.static.flickr.com/3369/3659337053_180878a026_t.jpg",
			};
			
			ImageCache = new TKImageCache("images");
			ImageCache.NotificationName = "newImageCache";
			
			
			NSNotificationCenter.DefaultCenter.AddObserver(new NSString("newImageCache"), (obj) => {
				foreach (var cell in TableView.VisibleCells)
				{
					if(cell.ImageView.Image == null)
					{
						int i = TableView.IndexPathForCell(cell).Row % UrlData.Length;
						var url = new NSUrl(UrlData[i]);
						var image = ImageCache.GetImage(i.ToString(), url, false);
						
						if(image != null)
						{
							cell.ImageView.Image = image;
							cell.SetNeedsLayout();
						}
					}
				}
			});
			
		}
		
		public override void LoadView ()
		{
			base.LoadView ();
			
			this.TableView.RowHeight = 120;
			this.TableView.AllowsSelection = false;
			
			var v = new UIView(new RectangleF(0f, 0f, 320.0f, 100.0f));
			var lab = new UILabel(new RectangleF(40, 20, 260, 80));

			lab.Text = @"The image cache handles large amounts of network image requests. Good for things like twitter avatars.";
			lab.Lines = 3;
			lab.Font = UIFont.BoldSystemFontOfSize(13);
			lab.TextColor = UIColor.Gray;
			v.AddSubview(lab);
			
			TableView.TableHeaderView = v;
		}
		
		public class MyTableViewSource : UITableViewSource
		{
			ImageCenterViewController _parentViewController;
			
			public MyTableViewSource(ImageCenterViewController parent)
			{
				_parentViewController = parent;
			}
			
			public override int NumberOfSections (UITableView tableView)
			{
				return 1;
			}
			
			public override int RowsInSection (UITableView tableview, int section)
			{
				return _parentViewController.UrlData.Length * 3;
			}
			
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cellIdentifier = "Cell";
				var cell = tableView.DequeueReusableCell(cellIdentifier);
				if(cell == null)
					cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
				
				cell.TextLabel.Text = String.Format("Cell {0}", indexPath.Row);
				var i = indexPath.Row;
				
				var index = i % _parentViewController.UrlData.Length;
				var url = new NSUrl(_parentViewController.UrlData[index]);
				var image = _parentViewController.ImageCache.GetImage(index.ToString(), url, true);
				cell.ImageView.Image = image;
    
    			return cell;
			}
		}
		
	}
}
