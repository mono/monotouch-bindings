
using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

using DropBoxSync.iOS;

namespace DropBoxSyncSampleMTD
{
	public partial class DVCLogin : DialogViewController
	{
		DVCFiles filesController;

		public DVCLogin () : base (UITableViewStyle.Grouped, null, true)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			ButtonSwitcher ();
		}

		void ButtonSwitcher ()
		{
			if (DBAccountManager.SharedManager.LinkedAccount == null) {
				Root = new RootElement ("DropBox Sync") {
					new Section (){
						new StringElement ("Link Account", () => DBAccountManager.SharedManager.LinkFromController (NavigationController)) { 
							Alignment = UITextAlignment.Center 
						}
					}
				};
			} else {
				Root = new RootElement ("DropBox Sync") {
					new Section () {
						new StringElement ("Unlink Account", () => {
							DBAccountManager.SharedManager.LinkedAccount.Unlink ();
							ButtonSwitcher ();
						}) { Alignment = UITextAlignment.Center },
						new StringElement ("Show DropBox Files", () => {
							filesController = new DVCFiles (DBPath.Root);
							NavigationController.PushViewController (filesController, true);
						}) { Alignment = UITextAlignment.Center } 
					}
				};
			}
		}
	}
}
