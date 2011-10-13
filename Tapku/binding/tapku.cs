using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;
using MonoTouch.CoreGraphics;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace Tapku
{
    [BaseType(typeof(UITableViewCell))]
    interface ABTableViewCell
    {
        [Export("drawContentView:")]
        void DrawContentView(RectangleF r);

    }


    [BaseType(typeof(ABTableViewCell))]
    interface FSIndicatorCell
    {
        [Export("text", ArgumentSemantic.Copy)]
        string Text { get; set; }

        [Export("count", ArgumentSemantic.Assign)]
        int Count { get; set; }

    }


    [BaseType(typeof(ABTableViewCell))]
    interface FSSubtitleCell
    {
        [Export("title", ArgumentSemantic.Copy)]
        string Title { get; set; }

        [Export("subtitle", ArgumentSemantic.Copy)]
        string Subtitle { get; set; }

    }


    [BaseType(typeof(UIView))]
    interface LoadingHUDView
    {
        [Export("title", ArgumentSemantic.Copy)]
        string Title { get; set; }

        [Export("message", ArgumentSemantic.Copy)]
        string Message { get; set; }

        [Export("initWithTitle:message:")]
        IntPtr Constructor(string ttl, string msg);

        [Export("initWithTitle:")]
        IntPtr Constructor(string ttl);

    }


    [BaseType(typeof(UITableViewCell))]
    interface TKButtonCell
    {
        [Export("text", ArgumentSemantic.Copy)]
        string Text { get; set; }

    }


    [BaseType(typeof(UIView))]
    interface TKCalendarMonthView
    {
        [Export("lines")]
        int Lines { get; }

        [Export("weekdayOfFirst")]
        int WeekdayOfFirst { get; }

        [Export("dateOfFirst")]
        NSDate DateOfFirst { get; }

        [Export("initWithFrame:startDate:today:marked:")]
        IntPtr Constructor(RectangleF frame, NSDate theDate, int todayDay, NSArray marksArray);

        [Export("setDate:today:marked:")]
        void SetDate(NSDate firstOfMonth, int dayOfDate, NSArray marksArray);

        [Export("selectDay:")]
        void SelectDay(int theDayNumber);

    }


    [BaseType(typeof(NSObject))]
    [Model]
    interface TKCalendarMonthViewDelegate
    {
        [Export("calendarMonth:dateWasSelected:")]
        void CalendarMonthDateWasSelected(TKCalendarMonthView calendarMonth, int integer);

        [Export("calendarMonth:previousMonthDayWasSelected:")]
        void CalendarMonthPreviousMonthDayWasSelected(TKCalendarMonthView calendarMonth, int day);

        [Export("calendarMonth:nextMonthDayWasSelected:")]
        void CalendarMonthNextMonthDayWasSelected(TKCalendarMonthView calendarMonth, int day);

    }


    [BaseType(typeof(UIView))]
    interface TKCalendarDayView
    {
        [Export("str", ArgumentSemantic.Copy)]
        string Str { get; set; }

        [Export("selected", ArgumentSemantic.Assign)]
        bool Selected { get; set; }

        [Export("active", ArgumentSemantic.Assign)]
        bool Active { get; set; }

        [Export("today", ArgumentSemantic.Assign)]
        bool Today { get; set; }

        [Export("marked", ArgumentSemantic.Assign)]
        bool Marked { get; set; }

    }


    [BaseType(typeof(UIView))]
    interface TKCalendarView
    {
        [Export("monthString", ArgumentSemantic.Copy)]
        string MonthString { get; set; }

        [Export("initWithFrame:delegate:")]
        IntPtr Constructor(RectangleF frame, IntPtr Delegate);

    }


    [BaseType(typeof(NSObject))]
    [Model]
    interface TKCalendarViewDelegate
    {
        [Export("calendarView:dateWasSelected:ofMonth:")]
        void CalendarView(TKCalendarView calendar, int integer, NSDate monthDate);

        [Export("calendarView:itemsForDaysInMonth:")]
        NSArray CalendarView(TKCalendarView calendar, NSDate monthDate);

        [Export("calendarView:willShowMonth:")]
        void CalendarViewWillShowMonth(TKCalendarView calendar, NSDate monthDate);

    }


    [BaseType(typeof(UIViewController))]
    interface TKCalendarViewController
    {
        [Export("calendarView", ArgumentSemantic.Retain)]
        TKCalendarView CalendarView { get; set; }

    }


    [BaseType(typeof(UIView))]
    interface TKEmptyView
    {
        [Export("title", ArgumentSemantic.Retain)]
        UILabel Title { get; set; }

        [Export("subtitle", ArgumentSemantic.Retain)]
        UILabel Subtitle { get; set; }

        [Export("mask", ArgumentSemantic.Retain)]
        UIImage Mask { get; set; }

    }


    [BaseType(typeof(UIView))]
    interface TKDropShadowImage
    {
        [Export("mask", ArgumentSemantic.Retain)]
        UIImage Mask { get; set; }

    }


    [BaseType(typeof(UIView))]
    interface TKGradientImage
    {
        [Export("mask", ArgumentSemantic.Retain)]
        UIImage Mask { get; set; }

    }


    [BaseType(typeof(NSObject))]
    interface TKGlobal
    {
    }


    [BaseType(typeof(UITableViewCell))]
    interface TKLabelCell
    {
        [Export("label", ArgumentSemantic.Retain)]
        UILabel Label { get; set; }

    }


    [BaseType(typeof(TKLabelCell))]
    interface TKLabelFieldCell
    {
        [Export("field", ArgumentSemantic.Retain)]
        UILabel Field { get; set; }

    }


    [BaseType(typeof(TKLabelCell))]
    interface TKLabelSwitchCell
    {
        [Export("switcher", ArgumentSemantic.Retain)]
        UISwitch Switcher { get; set; }

    }


    [BaseType(typeof(TKLabelCell))]
    interface TKLabelTextViewCell
    {
        [Export("textView", ArgumentSemantic.Retain)]
        UITextView TextView { get; set; }

    }


    [BaseType(typeof(NSObject))]
    [Model]
    interface TKOverlayViewDelegate
    {
        [Export("didTouchAtPoint:")]
        void DidTouchAtPoint(PointF point);

    }


    [BaseType(typeof(UIView))]
    interface TKMapView
    {
        [Export("pinMode")]
        bool PinMode { get; }

        [Export("mapView", ArgumentSemantic.Retain)]
        MKMapView MapView { get; set; }

        [Export("setPinMode:")]
        void SetPinMode(bool pinMode);

    }


    [BaseType(typeof(UIView))]
    interface TKOverlayView
    {
    }


    [BaseType(typeof(UIView))]
    interface TKOverviewHeaderView
    {
        [Export("title", ArgumentSemantic.Retain)]
        UILabel Title { get; set; }

        [Export("subtitle", ArgumentSemantic.Retain)]
        UILabel Subtitle { get; set; }

        [Export("indicator", ArgumentSemantic.Retain)]
        TKOverviewIndicatorView Indicator { get; set; }

    }


    [BaseType(typeof(UIView))]
    interface TKOverviewIndicatorView
    {
        //[Export("color", ArgumentSemantic.Assign)]
        //TKOverviewIndicatorViewColor Color { get; set; }

        [Export("text", ArgumentSemantic.Copy)]
        string Text { get; set; }
		
        //[Export("initWithColor:")]
        //IntPtr Constructor(TKOverviewIndicatorViewColor colour);

    }


    [BaseType(typeof(NSObject))]
    interface TKPlace
    {
        [Export("coordinate", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Coordinate { get; set; }

        [Export("color", ArgumentSemantic.Assign)]
        MKPinAnnotationColor Color { get; set; }

    }


    [BaseType(typeof(UITableViewCell))]
    interface TKSwitchCell
    {
        [Export("text", ArgumentSemantic.Copy)]
        string Text { get; set; }

        [Export("slider", ArgumentSemantic.Assign)]
        UISwitch Slider { get; set; }

    }


    [BaseType(typeof(UITableViewCell))]
    interface TKTextViewCell
    {
        [Export("textView", ArgumentSemantic.Retain)]
        UITextView TextView { get; set; }

    }


    [BaseType(typeof(NSObject))]
    [Model]
    interface TKTimeGraphDelegate
    {
        [Export("titleForTimeGraph:")]
        string TitleForTimeGraph(TKTimeGraph graph);

        [Export("goalValueForTimeGraph:")]
        NSNumber GoalValueForTimeGraph(TKTimeGraph graph);

        [Export("numberofPointsOnTimeGraph:")]
        int NumberofPointsOnTimeGraph(TKTimeGraph graph);

        [Export("timeGraph:yValueForPoint:")]
        NSNumber TimeGraphYValueForPoint(TKTimeGraph graph, int x);

        [Export("timeGraph:xLabelForPoint:")]
        string TimeGraphXLabelForPoint(TKTimeGraph graph, int x);

        [Export("timeGraph:yLabelForValue:")]
        string TimeGraphYLabelForValue(TKTimeGraph graph, float value);

    }


    [BaseType(typeof(UIView))]
    interface TKTimeGraph
    {
        [Export("data", ArgumentSemantic.Retain)]
        NSArray Data { get; set; }

        [Export("setTitle:")]
        void SetTitle(string str);

    }


    [BaseType(typeof(UIView))]
    interface TKTimeGraphPointsView
    {
        [Export("data", ArgumentSemantic.Retain)]
        NSArray Data { get; set; }

    }


    [BaseType(typeof(UIView))]
    interface TKTimeGraphIndicator
    {
        [Export("initWithFrame:title:sideUp:")]
        IntPtr Constructor(RectangleF frame, string str, bool up);

    }


}
