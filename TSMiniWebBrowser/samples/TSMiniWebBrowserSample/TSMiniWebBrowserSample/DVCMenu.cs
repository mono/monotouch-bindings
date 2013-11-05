using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

using TSMiniWebBrowser;

namespace TSMiniWebBrowserSample
{
	public partial class DVCMenu : DialogViewController
	{
		public DVCMenu () : base (UITableViewStyle.Grouped, null)
		{
			Root = new RootElement ("MiniWebBrowser Sample") {
				new Section (){
					new StringElement ("Start Browsing", () => {
						var browser = new MiniWebBrowser (new NSUrl ("http://xamarin.com")) {
							Mode = MiniWebBrowserMode.Navigation,
							BarStyle = UIBarStyle.Black
						};

						NavigationController.PushViewController (browser, true);
					}) { Alignment = UITextAlignment.Center },

					new StringElement ("Start Browsing Modal", () => {
						var browser = new MiniWebBrowser (new NSUrl ("http://xamarin.com")) {
							Mode = MiniWebBrowserMode.Modal,
							BarStyle = UIBarStyle.Default,
							Delegate = new MyWebDelegate ()
						};

						PresentViewController (browser, true, null);
					}) { Alignment = UITextAlignment.Center }
				}
			};
		}

		class MyWebDelegate : MiniWebBrowserDelegate
		{
			public override void DidDismiss ()
			{
				Console.WriteLine ("Mini Web Browser Did Dismiss");
			}
		}
	}
}
