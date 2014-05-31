using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Reflection;
using System.Linq;

namespace CouchbaseSample
{
  public partial class ConfigViewController : UIViewController
  {
    internal const string SyncUrlKey = "syncpoint";
    static readonly NSString[] learnMoreUrls = new NSString[] {
      (NSString)@"http://www.couchbase.com/products-and-services/couchbase-single-server",
      (NSString)@"http://www.iriscouch.com/",
      (NSString)@"http://www.couchbasecloud.com/"
    };

    public ConfigViewController ()
			: base ("ConfigViewController", null)
    {
    }

    partial void LearnMore (NSObject sender)
    {
      var tag = ((UIView)sender).Tag;
      var url = new NSUrl (learnMoreUrls [tag]);
      UIApplication.SharedApplication.OpenUrl (url);
    }

    public override void ViewDidLoad ()
    {
      base.ViewDidLoad ();

      NavigationItem.Title = "Configure Sync";

      var purgeButton = new UIBarButtonItem (
        "Done",
        UIBarButtonItemStyle.Plain,
        Done
      );

      NavigationItem.LeftBarButtonItem = purgeButton;
    }

    public override void ViewWillAppear (bool animated)
    {
      base.ViewWillAppear (animated);

      var syncPoint = NSUserDefaults.StandardUserDefaults.StringForKey (SyncUrlKey);
      UrlField.Text = syncPoint;

      VersionField.Text = Assembly.GetAssembly (typeof(Couchbase.Database)).GetName ().Version.ToString ();
    }

    void Done (object sender, EventArgs args)
    {
      var syncPoint = UrlField.Text;
      if (String.IsNullOrWhiteSpace (syncPoint)) {
        Pop ();
        return;
      }

      var remoteUrl = new NSUrl (syncPoint);

      // If user just enters the server URL, fill in a default database name:
      if (String.IsNullOrWhiteSpace (remoteUrl.Path) || remoteUrl.Path == "/") {
        remoteUrl = remoteUrl.Append ("grocery-sync", false);
        syncPoint = remoteUrl.AbsoluteString;
      }

      NSUserDefaults.StandardUserDefaults.SetString (syncPoint, SyncUrlKey);

      Pop ();
    }

    void Pop ()
    {
      var navController = (UINavigationController)ParentViewController;
      navController.PopViewControllerAnimated (true);
    }
  }
}

