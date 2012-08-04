using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

namespace ParseLib {

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
	
}