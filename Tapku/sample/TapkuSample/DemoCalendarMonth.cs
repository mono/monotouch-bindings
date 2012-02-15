using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Tapku;

namespace TapkuSample
{
	public partial class DemoCalendarMonth : TKCalendarMonthViewController
	{
		//loads the DemoCalendarMonth.xib file and connects it to this object
		public DemoCalendarMonth ()
		{
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			
			
			
			//MonthView.SelectDate(NSDate.Now);
		}
		
	}
}
