using System;
using MonoTouch.Foundation;
using System.Drawing;

	partial class GADBannerView
	{
		// iPhone and iPod Touch ad size.
		public static readonly SizeF GAD_SIZE_320x50 = new SizeF(320, 50);

		// Medium Rectangle size for the iPad (especially in a UISplitView's left pane).
		public static readonly SizeF GAD_SIZE_300x250 = new SizeF(300, 250);

		// Full Banner size for the iPad (especially in a UIPopoverController or in
		// UIModalPresentationFormSheet).
		public static readonly SizeF GAD_SIZE_468x60 = new SizeF(468, 60);

		// Leaderboard size for the iPad.
		public static readonly SizeF GAD_SIZE_728x90 = new SizeF(728, 90);	
	}
	
	partial class GADRequest
	{
		public static readonly string GAD_SIMULATOR_ID = "Simulator";
	}


