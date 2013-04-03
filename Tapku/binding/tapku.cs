using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;
using MonoTouch.CoreGraphics;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;
using MonoTouch.CoreAnimation;

namespace Tapku
{
    
    [BaseType (typeof (UIView))]
    interface TKLoadingView {
        [Export ("message")]
        string Message { get; set;  }

        [Export ("radius")]
        float Radius { get; set;  }

        [Export ("initWithTitle:message:")]
        IntPtr Constructor (string title, string message);

        [Export ("initWithTitle:")]
        IntPtr Constructor (string title);

        [Export ("startAnimating")]
        void StartAnimating ();

        [Export ("stopAnimating")]
        void StopAnimating ();

    }

    [BaseType (typeof (UIAlertView))]
    interface TKProgressAlertView {
        [Export ("progressBar")]
        TKProgressBarView ProgressBar { get;  }

        [Export ("label")]
        UILabel Label { get;  }

        [Export ("initWithProgressTitle:")]
        IntPtr Constructor (string title);

        [Export ("show")]
        void Show ();

        [Export ("hide")]
        void Hide ();

    }

    [BaseType (typeof (UIView))]
    interface TKProgressBarView {
        [Export ("progress")]
        float Progress { get; set;  }

        [Export ("initWithStyle:")]
        IntPtr Constructor (TKProgressBarViewStyle style);

    }

    [BaseType (typeof (UIView))]
    interface TKProgressCircleView {
        [Export ("progress")]
        float Progress { get; set;  }

        [Export ("twirlMode")]
        bool TwirlMode { [Bind ("isTwirling")] get; set;  }

        [Export ("setProgress:animated:")]
        void SetProgress (float progress, bool animated);

    }

    [BaseType (typeof (UIView))]
    interface TapDetectingView {
        //[Export ("<TapDetectingViewDelegate>")]
        //NSObject <TapDetectingViewDelegate> { get; set;  }

    }

    /*[BaseType (typeof ())]
    [Model]
    interface TapDetectingViewDelegate {
        [Abstract]
        [Export ("tapDetectingView:gotSingleTapAtPoint:")]
        void TapDetectingViewgotSingleTapAtPoint (TapDetectingView view, PointF tapPoint);

        [Abstract]
        [Export ("tapDetectingView:gotDoubleTapAtPoint:")]
        void TapDetectingViewgotDoubleTapAtPoint (TapDetectingView view, PointF tapPoint);

        [Abstract]
        [Export ("tapDetectingView:gotTwoFingerTapAtPoint:")]
        void TapDetectingViewgotTwoFingerTapAtPoint (TapDetectingView view, PointF tapPoint);

    }*/

    [BaseType (typeof (NSObject))]
    interface TKAlertCenter {
        [Static]
        [Export ("defaultCenter")]
        TKAlertCenter DefaultCenter { get; }

        [Export ("postAlertWithMessage:image:")]
        void PostAlert (string message, UIImage image);

        [Export ("postAlertWithMessage:")]
        void PostAlert (string message);

    }

    [BaseType (typeof (UIApplicationDelegate))]
    interface TKAppDelegate {
        [Export ("window")]
        TKWindow Window { get; set;  }

        [Export ("applicationDidStartup:")]
        void ApplicationDidStartup (UIApplication application);

    }

    [BaseType (typeof (UITableViewCell))]
    interface TKButtonCell {
    }

    [BaseType (typeof (TapDetectingView))]
    interface TKCalendarDayEventView {
        [Export ("id")]
        NSNumber Id { get; set;  }

        [Export ("startDate")]
        NSDate StartDate { get; set;  }

        [Export ("endDate")]
        NSDate EndDate { get; set;  }

        [Export ("title")]
        string Title { get; set;  }

        [Export ("location")]
        string Location { get; set;  }

        [Export ("balloonColorTop")]
        UIColor BalloonColorTop { get; set;  }

        [Export ("balloonColorBottom")]
        UIColor BalloonColorBottom { get; set;  }

        [Export ("textColor")]
        UIColor TextColor { get; set;  }

        [Export ("setupCustomInitialisation")]
        void SetupCustomInitialisation ();

        [Static]
        [Export ("eventViewWithFrame:id:startDate:endDate:title:location:")]
        NSObject EventView (RectangleF frame, NSNumber id, NSDate startDate, NSDate endDate, string title, string location);

    }

    [BaseType (typeof (UIView))]
    interface TKCalendarDayTimelineView {
        [Export ("scrollView")]
        UIScrollView scrollView { get;  }

        [Export ("timelineView")]
        TKTimelineView timelineView { get;  }

        [Export ("events")]
        NSArray events { get; set;  }

        [Export ("currentDay")]
        NSDate currentDay { get; set;  }

        //[Export ("<TKCalendarDayTimelineViewDelegate>")]
        //NSObject <TKCalendarDayTimelineViewDelegate> { get; set;  }

        [Export ("timelineColor")]
        UIColor TimelineColor { get; set;  }

        [Export ("hourColor")]
        UIColor HourColor { get; set;  }

        [Export ("is24hClock")]
        bool Is24hClock { get; set;  }

        [Export ("setupCustomInitialisation")]
        void SetupCustomInitialisation ();

        [Export ("reloadDay")]
        void ReloadDay ();

    }

    [BaseType (typeof (NSObject))]
    [Model]
    interface TKCalendarDayTimelineViewDelegate {
        [Abstract]
        [Export ("calendarDayTimelineView:eventsForDate:")]
        NSArray CalendarDayTimelineVieweventsForDate (TKCalendarDayTimelineView calendarDayTimeline, NSDate eventDate);

        [Abstract]
        [Export ("calendarDayTimelineView:eventViewWasSelected:")]
        void CalendarDayTimelineVieweventViewWasSelected (TKCalendarDayTimelineView calendarDayTimeline, TKCalendarDayEventView eventView);

        [Abstract]
        [Export ("calendarDayTimelineView:eventDateWasSelected:")]
        void CalendarDayTimelineVieweventDateWasSelected (TKCalendarDayTimelineView calendarDayTimeline, NSDate eventDate);

    }

    [BaseType (typeof (TapDetectingView))]
    interface TKTimelineView {
        [Export ("times")]
        NSArray Times { get;  }

        [Export ("periods")]
        NSArray Periods { get;  }

        [Export ("hourColor")]
        UIColor HourColor { get; set;  }

        [Export ("is24hClock")]
        bool Is24hClock { get; set;  }

        [Export ("setupCustomInitialisation")]
        void SetupCustomInitialisation ();

    }

    [BaseType (typeof (UIViewController))]
    interface TKCalendarDayViewController {
        [Export ("calendarDayTimelineView")]
        TKCalendarDayTimelineView CalendarDayTimelineView { get; set;  }

    }

    [BaseType (typeof (TKCalendarMonthViewController))]
    interface TKCalendarMonthTableViewController {
        [Export ("updateTableOffset:")]
        void UpdateTableOffset (bool animated);

    }

    [BaseType (typeof (UIView))]
    interface TKCalendarMonthView {
        //[Export ("<TKCalendarMonthViewDelegate>")]
        //NSObject <TKCalendarMonthViewDelegate> { get; set;  }

        //[Export ("<TKCalendarMonthViewDataSource>")]
        //NSObject <TKCalendarMonthViewDataSource> { get; set;  }

        [Export ("dateSelected")]
        NSDate DateSelected ();

        [Export ("monthDate")]
        NSDate MonthDate ();

        [Export ("selectDate:")]
        void SelectDate (NSDate date);

        [Export ("reload")]
        void Reload ();

    }

    /*[BaseType (typeof ())]
    [Model]
    interface TKCalendarMonthViewDelegate {
        [Export ("calendarMonthView:didSelectDate:")]
        void CalendarMonthViewdidSelectDate (TKCalendarMonthView monthView, NSDate date);

        [Export ("calendarMonthView:monthShouldChange:animated:")]
        bool CalendarMonthViewmonthShouldChangeanimated (TKCalendarMonthView monthView, NSDate month, bool animated);

        [Export ("calendarMonthView:monthWillChange:animated:")]
        void CalendarMonthViewmonthWillChangeanimated (TKCalendarMonthView monthView, NSDate month, bool animated);

        [Export ("calendarMonthView:monthDidChange:animated:")]
        void CalendarMonthViewmonthDidChangeanimated (TKCalendarMonthView monthView, NSDate month, bool animated);

    }*/

    /*[BaseType (typeof ())]
    [Model]
    interface TKCalendarMonthViewDataSource {
    }*/

    [BaseType (typeof (UIViewController))]
    interface TKCalendarMonthViewController {
        [Export ("monthView")]
        TKCalendarMonthView MonthView { get; set;  }

        [Export ("initWithSunday:")]
        IntPtr Constructor (bool sundayFirst);

    }

    [BaseType (typeof (UIView))]
    interface TKCoverflowCoverView {
        [Export ("image")]
        UIImage Image { get; set;  }

        [Export ("gradientLayer")]
        CAGradientLayer GradientLayer { get; set;  }

        [Export ("baseline")]
        float Baseline { get; set;  }

        [Export("initWithFrame:")]
        IntPtr Constructor(RectangleF frame);

    }

    [BaseType(typeof(UIScrollView))]
    interface TKCoverflowView {

        [Export ("coverSize")]
        SizeF CoverSize { get; set;  }

        [Export ("numberOfCovers")]
        int NumberOfCovers { get; set;  }

        [Export ("coverSpacing")]
        float CoverSpacing { get; set;  }

        [Export ("coverAngle")]
        float CoverAngle { get; set;  }

        [Export ("currentIndex")]
        int CurrentIndex { get; set;  }

        [Export ("dequeueReusableCoverView")]
        TKCoverflowCoverView DequeueReusableCoverView ();

        [Export ("coverAtIndex:")]
        TKCoverflowCoverView CoverAtIndex (int index);

        [Export ("indexOfFrontCoverView")]
        int IndexOfFrontCoverView ();

        [Export ("bringCoverAtIndexToFront:animated:")]
        void BringCoverAtIndexToFront(int index, bool animated);
		
		[Export ("coverflowDelegate"), NullAllowed]
		NSObject WeakCoverflowDelegate { get; set; }

		[Wrap ("WeakCoverflowDelegate")]
		TKCoverflowViewDelegate CoverflowDelegate { get; set; }
				
		[Export ("dataSource"), NullAllowed]
		TKCoverflowViewDataSource DataSource { get; set;  }

        [Export("initWithFrame:")]
        IntPtr Constructor(RectangleF frame);
    }

    [BaseType (typeof (UIScrollViewDelegate))]
    [Model]
    interface TKCoverflowViewDelegate {
        [Abstract]
		[EventArgs("CoverWasBroughtToFront")]
        [Export ("coverflowView:coverAtIndexWasBroughtToFront:")]
        void CoverAtIndexWasBroughtToFront (TKCoverflowView coverflowView, int index);

        [Abstract]
		[EventArgs("CoverWasDoubleTapped")]
        [Export ("coverflowView:coverAtIndexWasDoubleTapped:")]
        void CoverAtIndexWasDoubleTapped (TKCoverflowView coverflowView, int index);

    }

    [BaseType (typeof (NSObject))]
    [Model]
    interface TKCoverflowViewSource {
        [Abstract]
        [Export ("coverflowView:coverAtIndex:"), DelegateName ("TKCoverflowCoverFlowAtIndex"), DefaultValue (null)]
        TKCoverflowCoverView CoverflowViewcoverAtIndex (TKCoverflowView coverflowView, int index);

    }

    [BaseType (typeof (NSObject))]
    [Model]
    interface TKCoverflowViewDataSource {
        [Abstract]
        [Export ("coverflowView:coverAtIndex:")]
        TKCoverflowCoverView CoverflowViewcoverAtIndex (TKCoverflowView coverflowView, int index);
    }

    [BaseType (typeof (UIView))]
    interface TKEmptyView {
        [Export ("imageView")]
        UIImageView ImageView { get; set;  }

        [Export ("titleLabel")]
        UILabel TitleLabel { get; set;  }

        [Export ("subtitleLabel")]
        UILabel SubtitleLabel { get; set;  }

        [Export ("initWithFrame:mask:title:subtitle:")]
        IntPtr Constructor (RectangleF frame, UIImage image, string titleString, string subtitleString);

        [Export ("initWithFrame:emptyViewImage:title:subtitle:")]
        IntPtr Constructor (RectangleF frame, TKEmptyViewImage image, string titleString, string subtitleString);

        [Export ("setImage:")]
        void SetImage (UIImage image);

        [Export ("setEmptyImage:")]
        void SetEmptyImage (TKEmptyViewImage image);

    }

    [BaseType (typeof (UIViewController))]
    interface TKGraphController {

    }

    [BaseType(typeof(NSCache))]
    interface TKImageCache {

        [Export("cacheDirectoryName", ArgumentSemantic.Copy)]
        string CacheDirectory { get; set; }

        [Export("notificationName", ArgumentSemantic.Copy)]
        string NotificationName { get; set; }

        [Export("timeTillRefreshCache", ArgumentSemantic.Assign)]
        double TimeTillRefreshCache { get; set; }

        [Export("imageForKey:url:queueIfNeeded:")]
        UIImage GetImage(string key, NSUrl url, bool queueIfNeeded);

        [Export("imageForKey:url:queueIfNeeded:tag:")]
        UIImage GetImage(string key, NSUrl url, bool queueIfNeeded, int tag);

        [Export("cachedImageForKey:")]
        UIImage FindCachedImage(string key);

        [Export("imageExistsWithKey:")]
        bool DoesImageExist(string key);

        [Export("cancelOperations")]
        void CancelOperations();

        [Export("clearCachedImages")]
        void ClearCachedImages();

        [Export("removeCachedImagesFromDiskOlderThanTime:")]
        void ClearCachedImages(double interval);

        [Export("initWithCacheDirectoryName:")]
        IntPtr Constructor(string directoryName);

    }



    [BaseType (typeof (TKTableViewCell))]
    interface TKIndicatorCell {
        [Export ("text")]
        string Text { get; set;  }

        [Export ("count")]
        int Count { get; set;  }

    }

    [BaseType (typeof (UITableViewCell))]
    interface TKLabelCell {
    }

    [BaseType (typeof (TKLabelCell))]
    interface TKLabelFieldCell {
    }

    [BaseType (typeof (TKLabelCell))]
    interface TKLabelSwitchCell {
    }

    [BaseType (typeof (TKLabelCell))]
    interface TKLabelTextFieldCell {
    }

    [BaseType (typeof (TKLabelCell))]
    interface TKLabelTextViewCell {
    }

    [BaseType (typeof (NSObject))]
    interface TKMapPlace {

        [Export ("title", ArgumentSemantic.Copy)]
        string Title { get; set;  }

        [Export ("coordinate")]
        CLLocationCoordinate2D Coordinate { get; set;  }

        [Export ("color")]
        MKPinAnnotationColor Color { get; set; }
    }

    [BaseType (typeof (UIView))]
    interface TKMapView {

        [Export ("pinMode", ArgumentSemantic.Assign)]
        bool PinMode { get; set;  }

        [Export ("mapView")]
        MKMapView MapView { get; set;  }

        [Export ("initWithFrame:")]
        IntPtr Constructor (RectangleF frame);

        [Export ("delegate"), NullAllowed]
        NSObject WeakDelegate { get; set;  }

        [Wrap ("WeakDelegate")]
        TKMapViewDelegate Delegate { get; set; }
    }

    [BaseType (typeof (NSObject))]
    [Model]
    interface TKMapViewDelegate {

        [Export ("didPlacePinAtCoordinate:")]
        void DidPlacePin(CLLocationCoordinate2D location);
    }

    [BaseType (typeof (UINavigationController))]
    interface TKNavigationController {
        [Export ("initWithRootViewController:")]
        IntPtr Constructor (UIViewController rootViewController);
    }

    [BaseType (typeof (UINavigationItem))]
    interface TKNavigationItem {
    }

    [BaseType (typeof (UINavigationBar))]
    interface TKNavigationBar {
    }

    [BaseType (typeof (UITableViewCell))]
    interface TKSwitchCell {
        [Export ("slider")]
        UISwitch Slider { get; set;  }

    }

    [BaseType (typeof (UITableViewCell))]
    interface TKTableViewCell {
    }

    [BaseType (typeof (TKViewController))]
    interface TKTableViewController {
        [Export ("tableView")]
        UITableView TableView { get; set;  }

        [Export ("loadingView")]
        UIView LoadingView { get; set;  }

        [Export ("emptyView")]
        TKEmptyView EmptyView { get; set;  }

        [Export ("searchBar")]
        UISearchBar SearchBar { get; set;  }

        [Export ("searchBarDisplayController")]
        UISearchDisplayController SearchBarDisplayController { get; set;  }

        [Export ("initWithStyle:")]
        IntPtr Constructor (UITableViewStyle style);
    }

    [BaseType (typeof (UITableViewCell))]
    interface TKTextViewCell {
        [Export("textView")]
        UITextView TextView { get; set; }
    }

    [BaseType (typeof (UIViewController))]
    interface TKViewController {
        [Export("addActiveRequest:")]
        void AddActiveRequest(TKHTTPRequest request);

        [Export("activeRequestCount")]
        int ActiveRequestCount();

        [Export("removeActiveRequest:")]
        void RemoveActiveRequest(TKHTTPRequest request);

        [Export("cancelActiveRequests")]
        void CancelActiveRequests();
    }

    [BaseType (typeof (UIWindow))]
    interface TKWindow {
    }


    [BaseType(typeof(NSOperation))]
    interface TKHTTPRequest {
        [Export("initWithURL:")]
        IntPtr Constructor(NSUrl url);

        [Export("requestWithURLRequest:")]
        IntPtr Constructor(NSUrlRequest request);

        [Static, Export("requestWithURL")]
        TKHTTPRequest RequestWithURL(NSUrl url);

        [Static, Export("requestWithURLRequest:")]
        TKHTTPRequest RequestWithUrlRequest(NSUrlRequest request);

        [Export("URL")]
        NSUrl Url { get; set; }

        [Export("URLRequest")]
        NSUrlRequest Request { get; set; }
        
        [Export("tag", ArgumentSemantic.Assign)]
        int Tag { get; set; }

        [Export("showNetworkActivity", ArgumentSemantic.Assign)]
        bool ShowNetworkActivity { get; set; }

        [Export("didStartSelector", ArgumentSemantic.Assign)]
        Selector DidStartSelector { get; set; }

        [Export("didFinishSelector", ArgumentSemantic.Assign)]
        Selector DidFinishSelector { get; set; }

        [Export("didFailSelector", ArgumentSemantic.Assign)]
        Selector DidFailSelector { get; set; }

        [Export("downloadDestinationPath", ArgumentSemantic.Copy)]
        string DownloadDestinationPath { get; set; }

        [Export("temporaryFileDownloadPath", ArgumentSemantic.Copy)]
        string TemporaryFileDownloadPath { get; set; }

        [Export("error", ArgumentSemantic.Copy)]
        NSError Error { get; set; }

        [Export("statusCode", ArgumentSemantic.Assign)]
        int StatusCode { get; set; }

        [Export("responseHeaders")]
        NSDictionary ResponseHeaders { get; set; }

        [Export("responseData")]
        NSData ResponseData { get; }

        [Export("startAsynchronous")]
        void StartAsync();

        [Static, Export("isNetworkInUse")]
        bool IsNetworkInUse();

        [Static, Export("setShouldUpdateNetworkActivityIndicator:")]
        void SetShouldUpdateNetworkActivityIndicator(bool shouldUpdate);

        [Export ("progressDelegate", ArgumentSemantic.None)][NullAllowed]
        NSObject WeakDelegate { get; set; }

        [Wrap ("WeakDelegate")]
        TKHTTPRequestProgressDelegate Delegate { get; set; }
    }


    [BaseType(typeof(NSObject))]
    [Model]
    interface TKHTTPRequestProgressDelegate {
        [Export("request:didReceiveTotalBytes:ofExpectedBytes:")]
        void ReceivedBytes(TKHTTPRequest request, int received, int totalExpected);
        
    }


}
