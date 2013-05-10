
using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace iCarouselSample
{
	public partial class DVCMenu : DialogViewController
	{
		public DVCMenu () : base (UITableViewStyle.Grouped, null)
		{

			Root = new RootElement ("iCarousel") {
				new Section ("Samples"){
					new StringElement ("Simple Demo", () => {
						var vc = new SimpleSampleViewController ();
						NavigationController.PushViewController (vc, true);
					}),
					new StringElement ("Controls Demo", () => {
						var vc = new ControlsViewController ();
						NavigationController.PushViewController (vc, true);
					}),
					new StringElement ("Buttons Demo", () => {
						var vc = new ButtonsViewController ();
						NavigationController.PushViewController (vc, true);
					}),
					new StringElement ("Auto Scroll Demo", () => {
						var vc = new AutoScrollViewController ();
						NavigationController.PushViewController (vc, true);
					}),
					new StringElement ("Async Image Demo", () => {
						var vc = new AsyncImageViewController ();
						NavigationController.PushViewController (vc, true);
					})
				}
			};
		}
	}
}
