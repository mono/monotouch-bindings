using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimesSquare.iOS
{
	[BaseType (typeof (UITableViewCell))]
	interface TSQCalendarCell {

		[Export ("firstOfMonth", ArgumentSemantic.Retain)]
		NSDate FirstOfMonth { get; set; }

		[Export ("daysInWeek")]
		uint DaysInWeek { get; }

		[Export ("calendar", ArgumentSemantic.Retain)]
		NSCalendar Calendar { get; set; }

		[Export ("calendarView", ArgumentSemantic.Assign)]
		TSQCalendarView CalendarView { get; set; }

		[Static]
		[Export ("cellHeight")]
		float CellHeight { get; }

		[Export ("textColor", ArgumentSemantic.Retain)]
		UIColor TextColor { get; set; }

		[Export ("shadowOffset")]
		SizeF ShadowOffset { get; set; }

		[Export ("columnSpacing")]
		float ColumnSpacing { get; set; }

		[Export ("initWithCalendar:reuseIdentifier:")]
		IntPtr Constructor (NSCalendar calendar, string reuseIdentifier);

		[Export ("layoutViewsForColumnAtIndex:inRect:")]
		void LayoutViews (uint index, RectangleF rect);
	}

	[BaseType (typeof (TSQCalendarCell))]
	interface TSQCalendarMonthHeaderCell {

		[Export ("initWithCalendar:reuseIdentifier:")]
		IntPtr Constructor (NSCalendar calendar, string reuseIdentifier);

		[Export ("headerLabels")]
		UILabel [] HeaderLabels { get; set; }

		[Export ("createHeaderLabels")]
		void CreateHeaderLabels ();
	}

	[BaseType (typeof (TSQCalendarCell))]
	interface TSQCalendarRowCell {

		[Export ("initWithCalendar:reuseIdentifier:")]
		IntPtr Constructor (NSCalendar calendar, string reuseIdentifier);

		[Export ("backgroundImage", ArgumentSemantic.Assign)]
		UIImage BackgroundImage { get; }

		[Export ("selectedBackgroundImage", ArgumentSemantic.Assign)]
		UIImage SelectedBackgroundImage { get; }

		[Export ("todayBackgroundImage", ArgumentSemantic.Assign)]
		UIImage TodayBackgroundImage { get; }

		[Export ("notThisMonthBackgroundImage", ArgumentSemantic.Assign)]
		UIImage NotThisMonthBackgroundImage { get; }

		[Export ("beginningDate", ArgumentSemantic.Retain)]
		NSDate BeginningDate { get; set; }

		[Export ("bottomRow")]
		bool BottomRow { [Bind ("isBottomRow")] get; set; }

		[Export ("selectColumnForDate:")]
		void SelectColumnForDate ([NullAllowed] NSDate date);
	}

	[BaseType (typeof (UIView),
	Delegates=new string [] {"Delegate"},
	Events=new Type [] { typeof (TSQCalendarViewDelegate) })]
	interface TSQCalendarView {

		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);

		[Export ("firstDate", ArgumentSemantic.Retain)]
		NSDate FirstDate { get; set; }

		[Export ("lastDate", ArgumentSemantic.Retain)]
		NSDate LastDate { get; set; }

		[Export ("selectedDate", ArgumentSemantic.Retain)]
		NSDate SelectedDate { get; set; }

		[Export ("calendar", ArgumentSemantic.Retain)]
		NSCalendar Calendar { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		ITSQCalendarViewDelegate Delegate { get; set; }

		[Export ("pinsHeaderToTop")]
		bool PinsHeaderToTop { get; set; }

		[Export ("pagingEnabled")]
		bool PagingEnabled { get; set; }

		[Export ("contentInset")]
		UIEdgeInsets ContentInset { get; set; }

		[Export ("contentOffset")]
		PointF ContentOffset { get; set; }

		[Export ("headerCellClass")]
		Class HeaderCellClass { get; set; }

		[Export ("rowCellClass")]
		Class RowCellClass { get; set; }

		[Export ("scrollToDate:animated:")]
		void ScrollToDate (NSDate date, bool animated);
	}

	interface ITSQCalendarViewDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface TSQCalendarViewDelegate {

		[Export ("calendarView:shouldSelectDate:"), DelegateName ("TSQCalendarViewDelegateS"), NoDefaultValue]
		bool ShouldSelectDate (TSQCalendarView calendarView, NSDate date);

		[Export ("calendarView:didSelectDate:"), EventArgs("TSQCalendarViewDelegateA")]
		void DidSelectDate (TSQCalendarView calendarView, NSDate date);
	}

}

