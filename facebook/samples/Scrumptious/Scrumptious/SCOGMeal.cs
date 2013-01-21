using System;
using MonoTouch.FacebookConnect;


namespace Scrumptious
{
	public class SCOGMeal : FBGraphObject
	{
		public SCOGMeal ()
		{
			
		}

		public SCOGMeal (IntPtr ptr) : base (ptr)
		{

		}

		public string Id { get; set; }
		public string Url { get; set; }
	}

	public class SCOGEatMealAction : FBOpenGraphAction
	{
		public SCOGEatMealAction ()
		{
			
		}

		public SCOGEatMealAction (IntPtr ptr) : base (ptr)
		{
			
		}
		public SCOGMeal Meal { get; set; }
	}
}

