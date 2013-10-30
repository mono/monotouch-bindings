using System;

namespace GoogleAnalytics {

	public partial class GAI 
	{
		public GAITracker DefaultTracker { 
			get { 
				return new GAITracker (InternalDefaultTracker); 
			}
		}

		public GAITracker GetTracker(string trackingId) { 
			return new GAITracker (InternalGetTracker(trackingId));
		}
	}

}