using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

using Amazon.LogIn;

namespace AmazonLogInSample
{
	// This uses MonoTouch.Dialog to create the User Details View
	// http://docs.xamarin.com/guides/ios/user_interface/monotouch.dialog
	public partial class DVCDetails : DialogViewController
	{
		public DVCDetails (string name, string email, string userId, string postalCode) : base (UITableViewStyle.Grouped, null)
		{
			Root = new RootElement ("User Details") { 
				new Section () {
					new StyledStringElement ("Name", name, UITableViewCellStyle.Subtitle),
					new StyledStringElement ("Email", email, UITableViewCellStyle.Subtitle),
					new StyledMultilineElement ("User Id", userId, UITableViewCellStyle.Subtitle),
					new StyledStringElement ("Postal Code", string.IsNullOrEmpty (postalCode) ? "N/A" : postalCode, UITableViewCellStyle.Subtitle)
				},
				new Section () {
					new StringElement ("Log Out", ()=> {
						// Here we handle user's Log Out Action, AMZNLogoutDelegate will handle
						// success or failure
						AIMobileLib.ClearAuthorizationState (new AMZNLogoutDelegate (this));
					}) {
						Alignment = UITextAlignment.Center
					}
				}
			};
		}
	}
}
