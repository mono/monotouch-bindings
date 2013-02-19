using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TimesSquare.iOS;

namespace TimesSquareiOSSample
{
	[Register ("TSQTACalendarRowCell")]
	public class TSQTACalendarRowCell : TSQCalendarRowCell
	{

		public TSQTACalendarRowCell () : base ()
		{			
		}

		public TSQTACalendarRowCell (IntPtr handler) : base (handler)
		{
		}

		public override void LayoutViews (uint index, System.Drawing.RectangleF rect)
		{
			rect.Y += ColumnSpacing;
			rect.Height -= BottomRow ? 2.0f : 1.0f * ColumnSpacing;
			base.LayoutViews (index, rect);
		}

		public override UIImage TodayBackgroundImage {
			get {
				return UIImage.FromBundle ("images/CalendarTodaysDate.png").StretchableImage (4, 4);
			}
		}

		public override UIImage SelectedBackgroundImage {
			get {
				return UIImage.FromBundle ("images/CalendarSelectedDate.png").StretchableImage (4, 4);
			}
		}

		public override UIImage NotThisMonthBackgroundImage {
			get {
				return UIImage.FromBundle ("images/CalendarPreviousMonth.png").StretchableImage (0, 0);
			}
		}

		public override UIImage BackgroundImage {
			get {
				return UIImage.FromBundle ( BottomRow ? "images/CalendarRowBottom.png" : "images/CalendarRow.png");
			}
		}
	}
}

