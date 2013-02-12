using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

namespace ParseTouch {

	// Use this for synchronous operations
	[Register ("__My_NSActionDispatcher")]
	internal class NSActionDispatcher : NSObject {

		public static Selector Selector = new Selector ("apply");

		NSAction action;

		public NSActionDispatcher (NSAction action)
		{
			this.action = action;
		}

		[Export ("apply")]
		[Preserve (Conditional = true)]
		public void Apply ()
		{
			action ();
		}
	}

	public partial class ParseFile {
		public void SaveAsync (NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			SaveAsync (d, NSActionDispatcher.Selector);
		}


		public void GetDataAsync (NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			GetDataAsync (d, NSActionDispatcher.Selector);
		}
	}

	public partial class ParseObject {

		public NSObject this [string key]
		{
			get{ return this.ObjectForKey (key);}
			set{ this.SetObjectforKey (value,key);}
		}

		public void SaveAsync (NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			SaveAsync (d, NSActionDispatcher.Selector);
		}

		public void RefreshAsync (NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			RefreshAsync (d, NSActionDispatcher.Selector);
		}

		public void SaveAllAsync (ParseObject [] objects, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			SaveAllAsync (objects, d, NSActionDispatcher.Selector);
		}

		public void FetchAsync (NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			FetchAsync (d, NSActionDispatcher.Selector);
		}
		
		public void FetchIfNeededAsync (NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			FetchIfNeededAsync (d, NSActionDispatcher.Selector);
		}

		public void DeleteAsync (NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			DeleteAsync (d, NSActionDispatcher.Selector);
		}

		public static void FetchAllAsync (ParseObject [] objects, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			FetchAllAsync (objects, d, NSActionDispatcher.Selector);
		}

		public static void FetchAllIfNeededAsync (ParseObject [] objects, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			FetchAllIfNeededAsync (objects, d, NSActionDispatcher.Selector);
		}
	}
	public partial class ParsePush {
		public void SendPushMessageAsync (string channel, string message, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			SendPushMessageAsync (channel, message, d, NSActionDispatcher.Selector);
		}
		
		public void SendPushAsync (NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			SendPushAsync (d, NSActionDispatcher.Selector);			
		}
		
		public void SendPushDataAsync (string channel, NSDictionary data, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			SendPushDataAsync (channel, data, d, NSActionDispatcher.Selector);			
		}
		
		public void GetSubscribedChannelsAsync (NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			GetSubscribedChannelsAsync (d, NSActionDispatcher.Selector);			
		}
		
		public void SubscribeToChannelAsync (string channel, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			SubscribeToChannelAsync (channel, d, NSActionDispatcher.Selector);
		}
		
		public void UnsubscribeFromChannelAsync (string channel, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			UnsubscribeFromChannelAsync (channel, d, NSActionDispatcher.Selector);			
		}
	}
	
	public partial class ParseQuery {
		public void GetObjectAsync (string objectId, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			GetObjectAsync (objectId, d, NSActionDispatcher.Selector);				
		}
		
		public void FindObjectsAsync (NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			FindObjectsAsync (d, NSActionDispatcher.Selector);				
		}
			
		public void GetFirstObjectAsync (NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			GetFirstObjectAsync (d, NSActionDispatcher.Selector);				
		}
			
		public void CountObjectsAsync (NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			CountObjectsAsync (d, NSActionDispatcher.Selector);				
		}
	}
	
	public partial class ParseUser {
		public void SignUpAsync (NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			SignUpAsync (d, NSActionDispatcher.Selector);				
		}
		
		public void LogInWithAsync (string username, string password, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			LogInWithAsync (username, password, d, NSActionDispatcher.Selector);				
		}
		
		public void RequestPasswordResetAsync (string email, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			RequestPasswordResetAsync (email, d, NSActionDispatcher.Selector);				
		}
	}
		
	partial class ParseAnonymousUtils {
		public void LogInWithTargetselector (NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			LogInWithTargetselector (d, NSActionDispatcher.Selector);			
		}
	}
	
	partial class ParseMBProgressHUD {
		public void ShowWhileExecuting (NSAction method, NSAction callback, bool animated)
		{
			// Read the docs.
		}
	}

	partial class ParseFacebookUtils {
		public static void LogInAsync (NSArray permissions, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			LogInAsync (permissions, d, NSActionDispatcher.Selector);
		}
		
		public static void LogInAsync (string facebookId, string accessToken, NSDate expirationDate, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			LogInAsync (facebookId, accessToken, expirationDate, d, NSActionDispatcher.Selector);			
		}
		
		public static void LinkUserAsync (ParseUser user, NSArray permissions, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			LinkUserAsync (user, permissions, d, NSActionDispatcher.Selector);			
		}
		
		public static void LinkUserAsync (ParseUser user, string facebookId, string accessToken, NSDate expirationDate, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			LinkUserAsync (user, facebookId, accessToken, expirationDate, d, NSActionDispatcher.Selector);			
		}
		
		public static void UnlinkUserAsync (ParseUser user, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			UnlinkUserAsync (user, d, NSActionDispatcher.Selector);			
		}
		
		public static void ExtendAccessTokenForUser (ParseUser user, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			ExtendAccessTokenForUser (user, d, NSActionDispatcher.Selector);			
		}
		
		public static bool ExtendAccessTokenIfNeeded (ParseUser user, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			return ExtendAccessTokenIfNeeded (user, d, NSActionDispatcher.Selector);			
		}
	}
	
	partial class ParseTwitterUtils {
		public void LogIn (NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			LogIn (d, NSActionDispatcher.Selector);			
		}
		
		public void LogInWithTwitterId (string twitterId, string screenName, string authToken, string authTokenSecret, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			LogInWithTwitterId (twitterId, screenName, authToken, authTokenSecret, d, NSActionDispatcher.Selector);			
		}
		
		public void LinkUserAsync (ParseUser user, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			LinkUserAsync (user, d, NSActionDispatcher.Selector);			
		}
		
		public void LinkUserAsync (ParseUser user, string twitterId, string screenName, string authToken, string authTokenSecret, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			LinkUserAsync (user, twitterId, screenName, authToken, authTokenSecret, d, NSActionDispatcher.Selector);			
		}
		
		public void UnlinkUserAsync (ParseUser user, NSAction callback)
		{
			var d = new NSActionDispatcher (callback);
			UnlinkUserAsync (user, d, NSActionDispatcher.Selector);			
		}
	}
	
}
