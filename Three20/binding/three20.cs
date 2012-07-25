using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;
using MonoTouch.CoreGraphics;

namespace Three20
{
	[BaseType (typeof (TTPopupViewController))]
	interface TTActionSheetController
	{
		[Wrap ("WeakDelegate")] 
		TTActionSheetControllerDelegate  Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("actionSheet")]
		UIActionSheet ActionSheet { get; }

		[Export ("userInfo", ArgumentSemantic.Retain)]
		IntPtr UserInfo { get; set; }

		[Export ("initWithTitle:")]
		IntPtr Constructor (string title);

		[Export ("initWithTitle:delegate:")]
		IntPtr Constructor (string title, IntPtr Delegate);

		[Export ("addButtonWithTitle:URL:")]
		int AddButtonWithTitle (string title, string URL);

		[Export ("addCancelButtonWithTitle:URL:")]
		int AddCancelButtonWithTitle (string title, string URL);

		[Export ("addDestructiveButtonWithTitle:URL:")]
		int AddDestructiveButtonWithTitle (string title, string URL);

		[Export ("buttonURLAtIndex:")]
		string ButtonURLAtIndex (int index);
	}

	[BaseType (typeof (UIActionSheetDelegate))]
	[Model]
	interface TTActionSheetControllerDelegate
	{
		[Export ("actionSheetController:didDismissWithButtonIndex:URL:")]
		bool ActionSheetController (TTActionSheetController controller, int buttonIndex, string URL);
	}
	
	[BaseType (typeof (UIView))]
	interface TTActivityLabel
	{
		[Export ("style")]
		int Style { get; }

		[Export ("text", ArgumentSemantic.Assign)]
		string Text { get; set; }

		[Export ("font", ArgumentSemantic.Assign)]
		UIFont Font { get; set; }

		[Export ("progress")]
		float Progress { get; set; }

		[Export ("isAnimating")]
		bool IsAnimating { get; set; }

		[Export ("smoothesProgress")]
		bool SmoothesProgress { get; set; }

		[Export ("initWithFrame:style:")]
		IntPtr Constructor (RectangleF frame, int style);

		[Export ("initWithFrame:style:text:")]
		IntPtr Constructor (RectangleF frame, int style, string text);

		[Export ("initWithStyle:")]
		IntPtr Constructor (int style);
	}
	
	[BaseType (typeof (TTPopupViewController))]
	interface TTAlertViewController
	{
		[Wrap ("WeakDelegate")] 
		TTAlertViewControllerDelegate  Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("alertView")]
		UIAlertView AlertView { get; }

		[Export ("userInfo", ArgumentSemantic.Retain)]
		IntPtr UserInfo { get; set; }

		[Export ("initWithTitle:message:")]
		IntPtr Constructor (string title, string message);

		[Export ("initWithTitle:message:delegate:")]
		IntPtr Constructor (string title, string message, IntPtr Delegate);

		[Export ("addButtonWithTitle:URL:")]
		int AddButtonWithTitle (string title, string URL);

		[Export ("addCancelButtonWithTitle:URL:")]
		int AddCancelButtonWithTitle (string title, string URL);

		[Export ("buttonURLAtIndex:")]
		string ButtonURLAtIndex (int index);
	}

	[BaseType (typeof (UIAlertViewDelegate))]
	[Model]
	interface TTAlertViewControllerDelegate
	{
		[Export ("alertViewController:didDismissWithButtonIndex:URL:")]
		bool AlertViewController (TTAlertViewController controller, int buttonIndex, string URL);
	}

	[BaseType (typeof (UIControl))]
	interface TTButton
	{
		[Export ("font", ArgumentSemantic.Retain)]
		UIFont Font { get; set; }

		[Export ("isVertical")]
		bool IsVertical { get; set; }

		[Export ("titleForState:")]
		string TitleForState (UIControlState state);

		[Export ("setTitle:forState:")]
		void SetTitle (string title, UIControlState state);

		[Export ("imageForState:")]
		string ImageForState (UIControlState state);

		[Export ("setImage:forState:")]
		void SetImage (string title, UIControlState state);

		[Export ("styleForState:")]
		TTStyle StyleForState (UIControlState state);

		[Export ("setStyle:forState:")]
		void SetStyle (TTStyle style, UIControlState state);

		[Export ("setStylesWithSelector:")]
		void SetStylesWithSelector (string selector);

		[Export ("suspendLoadingImages:")]
		void SuspendLoadingImages (bool suspended);
	}

	[BaseType (typeof (TTView))]
	interface TTButtonBar
	{
		[Export ("buttons")]
		NSArray Buttons { get; set; }

		[Export ("buttonStyle", ArgumentSemantic.Copy)]
		string ButtonStyle { get; set; }

		[Export ("addButton:target:action:")]
		void AddButton (string title, IntPtr target, NSObject selector);
	}

	[BaseType (typeof (TTStyleSheet))]
	interface TTDefaultStyleSheet
	{
		[Export ("textColor")]
		UIColor TextColor { get; }

		[Export ("highlightedTextColor")]
		UIColor HighlightedTextColor { get; }

		[Export ("placeholderTextColor")]
		UIColor PlaceholderTextColor { get; }

		[Export ("timestampTextColor")]
		UIColor TimestampTextColor { get; }

		[Export ("linkTextColor")]
		UIColor LinkTextColor { get; }

		[Export ("moreLinkTextColor")]
		UIColor MoreLinkTextColor { get; }

		[Export ("selectedTextColor")]
		UIColor SelectedTextColor { get; }

		[Export ("photoCaptionTextColor")]
		UIColor PhotoCaptionTextColor { get; }

		[Export ("navigationBarTintColor")]
		UIColor NavigationBarTintColor { get; }

		[Export ("toolbarTintColor")]
		UIColor ToolbarTintColor { get; }

		[Export ("searchBarTintColor")]
		UIColor SearchBarTintColor { get; }

		[Export ("screenBackgroundColor")]
		UIColor ScreenBackgroundColor { get; }

		[Export ("backgroundColor")]
		UIColor BackgroundColor { get; }

		[Export ("tableActivityTextColor")]
		UIColor TableActivityTextColor { get; }

		[Export ("tableErrorTextColor")]
		UIColor TableErrorTextColor { get; }

		[Export ("tableSubTextColor")]
		UIColor TableSubTextColor { get; }

		[Export ("tableTitleTextColor")]
		UIColor TableTitleTextColor { get; }

		[Export ("tableHeaderTextColor")]
		UIColor TableHeaderTextColor { get; }

		[Export ("tableHeaderShadowColor")]
		UIColor TableHeaderShadowColor { get; }

		[Export ("tableHeaderTintColor")]
		UIColor TableHeaderTintColor { get; }

		[Export ("tableSeparatorColor")]
		UIColor TableSeparatorColor { get; }

		[Export ("tablePlainBackgroundColor")]
		UIColor TablePlainBackgroundColor { get; }

		[Export ("tableGroupedBackgroundColor")]
		UIColor TableGroupedBackgroundColor { get; }

		[Export ("searchTableBackgroundColor")]
		UIColor SearchTableBackgroundColor { get; }

		[Export ("searchTableSeparatorColor")]
		UIColor SearchTableSeparatorColor { get; }

		[Export ("tabTintColor")]
		UIColor TabTintColor { get; }

		[Export ("tabBarTintColor")]
		UIColor TabBarTintColor { get; }

		[Export ("messageFieldTextColor")]
		UIColor MessageFieldTextColor { get; }

		[Export ("messageFieldSeparatorColor")]
		UIColor MessageFieldSeparatorColor { get; }

		[Export ("thumbnailBackgroundColor")]
		UIColor ThumbnailBackgroundColor { get; }

		[Export ("postButtonColor")]
		UIColor PostButtonColor { get; }

		[Export ("font")]
		UIFont Font { get; }

		[Export ("buttonFont")]
		UIFont ButtonFont { get; }

		[Export ("tableFont")]
		UIFont TableFont { get; }

		[Export ("tableSmallFont")]
		UIFont TableSmallFont { get; }

		[Export ("tableTitleFont")]
		UIFont TableTitleFont { get; }

		[Export ("tableTimestampFont")]
		UIFont TableTimestampFont { get; }

		[Export ("tableButtonFont")]
		UIFont TableButtonFont { get; }

		[Export ("tableSummaryFont")]
		UIFont TableSummaryFont { get; }

		[Export ("tableHeaderPlainFont")]
		UIFont TableHeaderPlainFont { get; }

		[Export ("tableHeaderGroupedFont")]
		UIFont TableHeaderGroupedFont { get; }

		[Export ("photoCaptionFont")]
		UIFont PhotoCaptionFont { get; }

		[Export ("messageFont")]
		UIFont MessageFont { get; }

		[Export ("errorTitleFont")]
		UIFont ErrorTitleFont { get; }

		[Export ("errorSubtitleFont")]
		UIFont ErrorSubtitleFont { get; }

		[Export ("activityLabelFont")]
		UIFont ActivityLabelFont { get; }

		[Export ("activityBannerFont")]
		UIFont ActivityBannerFont { get; }

		[Export ("tableSelectionStyle")]
		UITableViewCellSelectionStyle TableSelectionStyle { get; }

		[Export ("selectionFillStyle:")]
		TTStyle SelectionFillStyle (TTStyle next);

		[Export ("pageDotWithColor:")]
		TTStyle PageDotWithColor (UIColor color);
	}

	[BaseType (typeof (UIView))]
	interface TTErrorView
	{
		[Export ("image", ArgumentSemantic.Retain)]
		UIImage Image { get; set; }

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		[Export ("subtitle", ArgumentSemantic.Copy)]
		string Subtitle { get; set; }

		[Export ("initWithTitle:subtitle:image:")]
		IntPtr Constructor (string title, string subtitle, UIImage image);
	}

	[BaseType (typeof (TTView))]
	interface TTImageView
	{
		[Wrap ("WeakDelegate")] 
		TTImageViewDelegate  Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("URL", ArgumentSemantic.Copy)]
		string URL { get; set; }

		[Export ("image", ArgumentSemantic.Retain)]
		UIImage Image { get; set; }

		[Export ("defaultImage", ArgumentSemantic.Retain)]
		UIImage DefaultImage { get; set; }

		[Export ("autoresizesToImage")]
		bool AutoresizesToImage { get; set; }

		[Export ("isLoading")]
		bool IsLoading { get; }

		[Export ("isLoaded")]
		bool IsLoaded { get; }

		[Export ("imageViewDidLoadImage:")]
		void ImageViewDidLoadImage (UIImage image);

		[Export ("imageViewDidFailLoadWithError:")]
		void ImageViewDidFailLoadWithError (NSError error);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTImageViewDelegate
	{
		[Export ("imageView:didLoadImage:")]
		void ImageView (TTImageView imageView, UIImage image);

		[Export ("imageViewDidStartLoad:")]
		void ImageViewDidStartLoad (TTImageView imageView);

		[Export ("imageView:didFailLoadWithError:")]
		void ImageView (TTImageView imageView, NSError error);
	}

	[BaseType (typeof (TTView))]
	interface TTLabel
	{
		[Export ("text", ArgumentSemantic.Copy)]
		string Text { get; set; }

		[Export ("font", ArgumentSemantic.Retain)]
		UIFont Font { get; set; }

		[Export ("initWithText:")]
		IntPtr Constructor (string text);
	}

	[BaseType (typeof (TTButton))]
	interface TTLauncherButton
	{
		[Export ("item")]
		TTLauncherItem Item { get; }

		[Export ("closeButton")]
		TTButton CloseButton { get; }

		[Export ("dragging")]
		bool Dragging { get; set; }

		[Export ("editing")]
		bool Editing { get; set; }

		[Export ("initWithItem:")]
		IntPtr Constructor (TTLauncherItem item);
	}

	[BaseType (typeof (NSObject))]
	interface TTLauncherItem
	{
		[Export ("launcher", ArgumentSemantic.Assign)]
		TTLauncherView Launcher { get; set; }

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		[Export ("image", ArgumentSemantic.Copy)]
		string Image { get; set; }

		[Export ("URL", ArgumentSemantic.Copy)]
		string URL { get; set; }

		[Export ("style", ArgumentSemantic.Copy)]
		string Style { get; set; }

		[Export ("badgeNumber")]
		int BadgeNumber { get; set; }

		[Export ("canDelete")]
		bool CanDelete { get; set; }

		[Export ("initWithTitle:image:URL:")]
		IntPtr Constructor (string title, string image, string URL);
	}

	[BaseType (typeof (UIView))]
	interface TTLauncherView
	{
		[Wrap ("WeakDelegate")] 
		TTLauncherViewDelegate  Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("pages", ArgumentSemantic.Copy)]
		NSArray Pages { get; set; }

		[Export ("columnCount")]
		int ColumnCount { get; set; }

		[Export ("rowCount")]
		int RowCount { get; }

		[Export ("currentPageIndex")]
		int CurrentPageIndex { get; set; }

		[Export ("prompt", ArgumentSemantic.Copy)]
		string Prompt { get; set; }

		[Export ("editing")]
		bool Editing { get; }

		[Export ("addItem:animated:")]
		void AddItem (TTLauncherItem item, bool animated);

		[Export ("removeItem:animated:")]
		void RemoveItem (TTLauncherItem item, bool animated);

		[Export ("itemWithURL:")]
		TTLauncherItem ItemWithURL (string URL);

		[Export ("indexPathOfItem:")]
		NSIndexPath IndexPathOfItem (TTLauncherItem item);

		[Export ("scrollToItem:animated:")]
		void ScrollToItem (TTLauncherItem item, bool animated);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTLauncherViewDelegate
	{
		[Export ("launcherView:didAddItem:")]
		void LauncherViewDidAddItem (TTLauncherView launcher, TTLauncherItem item);

		[Export ("launcherView:didRemoveItem:")]
		void LauncherViewDidRemoveItem (TTLauncherView launcher, TTLauncherItem item);

		[Export ("launcherView:didMoveItem:")]
		void LauncherViewDidMoveItem (TTLauncherView launcher, TTLauncherItem item);

		[Export ("launcherView:didSelectItem:")]
		void LauncherViewDidSelectItem (TTLauncherView launcher, TTLauncherItem item);

		[Export ("launcherViewDidBeginEditing:")]
		void LauncherViewDidBeginEditing (TTLauncherView launcher);

		[Export ("launcherViewDidEndEditing:")]
		void LauncherViewDidEndEditing (TTLauncherView launcher);
	}

	[BaseType (typeof (NSObject))]
	interface TTLayout
	{
		[Export ("layoutSubviews:forView:")]
		SizeF LayoutSubviews (NSArray subviews, UIView view);
	}

	[BaseType (typeof (TTLayout))]
	interface TTFlowLayout
	{
		[Export ("padding")]
		float Padding { get; set; }

		[Export ("spacing")]
		float Spacing { get; set; }
	}

	[BaseType (typeof (TTLayout))]
	interface TTGridLayout
	{
		[Export ("columnCount")]
		int ColumnCount { get; set; }

		[Export ("padding")]
		float Padding { get; set; }

		[Export ("spacing")]
		float Spacing { get; set; }
	}

	[BaseType (typeof (UIControl))]
	interface TTLink
	{
		[Export ("URL", ArgumentSemantic.Retain)]
		IntPtr URL { get; set; }
	}

	[BaseType (typeof (TTTableViewDataSource))]
	interface TTListDataSource
	{
		[Export ("items", ArgumentSemantic.Retain)]
		NSArray Items { get; set; }

		[Export ("initWithItems:")]
		IntPtr Constructor (NSArray items);

		[Export ("indexPathOfItemWithUserInfo:")]
		NSIndexPath IndexPathOfItemWithUserInfo (IntPtr userInfo);
	}

	[BaseType (typeof (TTTableViewDataSource))]
	interface TTSectionedDataSource
	{
		[Export ("items", ArgumentSemantic.Retain)]
		NSArray Items { get; set; }

		[Export ("sections", ArgumentSemantic.Retain)]
		NSArray Sections { get; set; }

		[Export ("initWithItems:sections:")]
		IntPtr Constructor (NSArray items, NSArray sections);

		[Export ("indexPathOfItemWithUserInfo:")]
		NSIndexPath IndexPathOfItemWithUserInfo (IntPtr userInfo);

		[Export ("removeItemAtIndexPath:")]
		void RemoveItemAtIndexPath (NSIndexPath indexPath);

		[Export ("removeItemAtIndexPath:andSectionIfEmpty:")]
		bool RemoveItemAtIndexPath (NSIndexPath indexPath, bool andSection);
	}

	[BaseType (typeof (NSObject))]
	interface TTMessageField
	{
		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		[Export ("required")]
		bool Required { get; set; }

		[Export ("initWithTitle:required:")]
		IntPtr Constructor (string title, bool required);
	}

	[BaseType (typeof (TTMessageField))]
	interface TTMessageRecipientField
	{
		[Export ("recipients", ArgumentSemantic.Retain)]
		NSArray Recipients { get; set; }
	}

	[BaseType (typeof (TTMessageField))]
	interface TTMessageTextField
	{
		[Export ("text", ArgumentSemantic.Copy)]
		string Text { get; set; }
	}

	[BaseType (typeof (TTMessageTextField))]
	interface TTMessageSubjectField
	{
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTModelDelegate
	{
	}

	[BaseType (typeof (NSObject))]
	interface TTModel
	{
		[Export ("didFailLoadWithError:")]
		void DidFailLoadWithError (NSError error);

		[Export ("didUpdateObject:atIndexPath:")]
		void DidUpdateObject (IntPtr Object, NSIndexPath indexPath);

		[Export ("didInsertObject:atIndexPath:")]
		void DidInsertObject (IntPtr Object, NSIndexPath indexPath);

		[Export ("didDeleteObject:atIndexPath:")]
		void DidDeleteObject (IntPtr Object, NSIndexPath indexPath);
	}

	[BaseType (typeof (TTModel))]
	interface TTURLRequestModel
	{
		[Export ("loadedTime", ArgumentSemantic.Retain)]
		NSDate LoadedTime { get; set; }

		[Export ("cacheKey", ArgumentSemantic.Copy)]
		string CacheKey { get; set; }

		[Export ("hasNoMore")]
		bool HasNoMore { get; set; }
	}

	[BaseType (typeof (TTViewController))]
	interface TTModelViewController
	{
		[Export ("model", ArgumentSemantic.Retain)]
		TTModel Model { get; set; }

		[Export ("modelError")]
		NSError ModelError { get; set; }

		[Export ("didLoadModel:")]
		void DidLoadModel (bool firstTime);

		[Export ("didShowModel:")]
		void DidShowModel (bool firstTime);

		[Export ("showModel:")]
		void ShowModel (bool show);

		[Export ("showLoading:")]
		void ShowLoading (bool show);

		[Export ("showEmpty:")]
		void ShowEmpty (bool show);

		[Export ("showError:")]
		void ShowError (bool show);
	}

	[BaseType (typeof (NSObject))]
	interface TTNavigator
	{
		[Wrap ("WeakDelegate")] 
		TTNavigatorDelegate  Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("URLMap")]
		TTURLMap URLMap { get; }

		[Export ("window", ArgumentSemantic.Retain)]
		UIWindow Window { get; set; }

		[Export ("rootViewController")]
		UIViewController RootViewController { get; }

		[Export ("visibleViewController")]
		UIViewController VisibleViewController { get; }

		[Export ("topViewController")]
		UIViewController TopViewController { get; }

		[Export ("URL", ArgumentSemantic.Copy)]
		string URL { get; set; }

		[Export ("persistenceMode")]
		int PersistenceMode { get; set; }

		[Export ("persistenceExpirationAge")]
		double PersistenceExpirationAge { get; set; }

		[Export ("supportsShakeToReload")]
		bool SupportsShakeToReload { get; set; }

		[Export ("opensExternalURLs")]
		bool OpensExternalURLs { get; set; }

		[Export ("isDelayed")]
		bool IsDelayed { get; }

		[Export ("openURL:animated:")]
		UIViewController OpenURL (string URL, bool animated);

		[Export ("openURL:parent:animated:")]
		UIViewController OpenURL (string URL, string parentURL, bool animated);

		[Export ("openURL:query:animated:")]
		UIViewController OpenURL (string URL, NSDictionary query, bool animated);

		[Export ("openURLs:")]
		UIViewController OpenURLs (string URL);

		[Export ("viewControllerForURL:")]
		UIViewController ViewControllerForURL (string URL);

		[Export ("viewControllerForURL:query:")]
		UIViewController ViewControllerForURL (string URL, NSDictionary query);

		[Export ("persistController:path:")]
		void PersistController (UIViewController controller, NSArray path);

		[Export ("pathForObject:")]
		string PathForObject (IntPtr Object);

		[Export ("objectForPath:")]
		IntPtr ObjectForPath (string path);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTNavigatorDelegate
	{
		[Export ("navigator:shouldOpenURL:")]
		bool Navigator (TTNavigator navigator, NSUrl URL);
	}

	[BaseType (typeof (UIControl))]
	interface TTPageControl
	{
		[Export ("numberOfPages")]
		int NumberOfPages { get; set; }

		[Export ("currentPage")]
		int CurrentPage { get; set; }

		[Export ("dotStyle", ArgumentSemantic.Copy)]
		string DotStyle { get; set; }

		[Export ("hidesForSinglePage")]
		bool HidesForSinglePage { get; set; }
	}

	[BaseType (typeof (TTModel))]
	[Model]
	interface TTPhotoSource
	{
		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		[Export ("numberOfPhotos")]
		int NumberOfPhotos { get; }

		[Export ("maxPhotoIndex")]
		int MaxPhotoIndex { get; }
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTPhoto
	{
		[Export ("photoSource", ArgumentSemantic.Assign)]
		TTPhotoSource PhotoSource { get; set; }

		[Export ("size")]
		SizeF Size { get; set; }

		[Export ("index")]
		int Index { get; set; }

		[Export ("caption", ArgumentSemantic.Copy)]
		string Caption { get; set; }

		[Export ("URLForVersion:")]
		string URLForVersion (int version);
	}

	[BaseType (typeof (TTImageView))]
	interface TTPhotoView
	{
		[Export ("photo", ArgumentSemantic.Retain)]
		TTPhoto Photo { get; set; }

		[Export ("captionStyle", ArgumentSemantic.Retain)]
		TTStyle CaptionStyle { get; set; }

		[Export ("hidesExtras")]
		bool HidesExtras { get; set; }

		[Export ("hidesCaption")]
		bool HidesCaption { get; set; }

		[Export ("loadPreview:")]
		bool LoadPreview (bool fromNetwork);

		[Export ("showProgress:")]
		void ShowProgress (float progress);

		[Export ("showStatus:")]
		void ShowStatus (string text);
	}

	[BaseType (typeof (TTModelViewController))]
	interface TTPhotoViewController
	{
		[Export ("photoSource", ArgumentSemantic.Retain)]
		TTPhotoSource PhotoSource { get; set; }

		[Export ("centerPhoto", ArgumentSemantic.Retain)]
		TTPhoto CenterPhoto { get; set; }

		[Export ("centerPhotoIndex")]
		int CenterPhotoIndex { get; }

		[Export ("defaultImage", ArgumentSemantic.Retain)]
		UIImage DefaultImage { get; set; }

		[Export ("captionStyle", ArgumentSemantic.Retain)]
		TTStyle CaptionStyle { get; set; }

		[Export ("showActivity:")]
		void ShowActivity (string title);
	}

	[BaseType (typeof (TTSearchTextField))]
	interface TTPickerTextField
	{
		[Export ("cellViews")]
		NSArray CellViews { get; }

		[Export ("cells")]
		NSArray Cells { get; }

		[Export ("selectedCell", ArgumentSemantic.Assign)]
		TTPickerViewCell SelectedCell { get; set; }

		[Export ("lineCount")]
		int LineCount { get; }

		[Export ("addCellWithObject:")]
		void AddCellWithObject (IntPtr Object);

		[Export ("removeCellWithObject:")]
		void RemoveCellWithObject (IntPtr Object);

		[Export ("scrollToVisibleLine:")]
		void ScrollToVisibleLine (bool animated);

		[Export ("scrollToEditingLine:")]
		void ScrollToEditingLine (bool animated);
	}

	[BaseType (typeof (TTSearchTextFieldDelegate))]
	[Model]
	interface TTPickerTextFieldDelegate
	{
		[Export ("textField:didAddCellAtIndex:")]
		void TextFieldDidAddCell (TTPickerTextField textField, int index);

		[Export ("textField:didRemoveCellAtIndex:")]
		void TextFieldDidRemoveCell (TTPickerTextField textField, int index);

		[Export ("textFieldDidResize:")]
		void TextFieldDidResize (TTPickerTextField textField);
	}

	[BaseType (typeof (TTView))]
	interface TTPickerViewCell
	{
		[Export ("object", ArgumentSemantic.Retain)]
		IntPtr Object { get; set; }

		[Export ("label", ArgumentSemantic.Copy)]
		string Label { get; set; }

		[Export ("font", ArgumentSemantic.Retain)]
		UIFont Font { get; set; }

		[Export ("selected")]
		bool Selected { get; set; }
	}

	[BaseType (typeof (TTModelViewController))]
	interface TTPopupViewController
	{
		[Export ("showInView:animated:")]
		void ShowInView (UIView view, bool animated);

		[Export ("dismissPopupViewControllerAnimated:")]
		void DismissPopupViewControllerAnimated (bool animated);
	}

	[BaseType (typeof (TTPopupViewController))]
	interface TTPostController
	{
		[Wrap ("WeakDelegate")] 
		TTPostControllerDelegate  Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("result", ArgumentSemantic.Retain)]
		IntPtr Result { get; set; }

		[Export ("textView")]
		UITextView TextView { get; }

		[Export ("navigatorBar")]
		UINavigationBar NavigatorBar { get; }

		[Export ("originView", ArgumentSemantic.Retain)]
		UIView OriginView { get; set; }

		[Export ("dismissWithResult:animated:")]
		void DismissWithResult (IntPtr result, bool animated);

		[Export ("failWithError:")]
		void FailWithError (NSError error);

		[Export ("willPostText:")]
		bool WillPostText (string text);

		[Export ("titleForError:")]
		string TitleForError (NSError error);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTPostControllerDelegate
	{
		[Export ("postController:willPostText:")]
		bool PostController (TTPostController postController, string text);

		[Export ("postController:willAnimateTowards:")]
		RectangleF PostController (TTPostController postController, RectangleF rect);

		[Export ("postControllerDidCancel:")]
		void PostControllerDidCancel (TTPostController postController);
	}

	[BaseType (typeof (UIView))]
	interface TTScrollView
	{
		[Wrap ("WeakDelegate")] 
		TTScrollViewDelegate  Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("dataSource", ArgumentSemantic.Assign)]
		TTScrollViewDataSource DataSource { get; set; }

		[Export ("centerPageIndex")]
		int CenterPageIndex { get; set; }

		[Export ("zoomed")]
		bool Zoomed { get; }

		[Export ("holding")]
		bool Holding { get; }

		[Export ("scrollEnabled")]
		bool ScrollEnabled { get; set; }

		[Export ("zoomEnabled")]
		bool ZoomEnabled { get; set; }

		[Export ("rotateEnabled")]
		bool RotateEnabled { get; set; }

		[Export ("pageSpacing")]
		float PageSpacing { get; set; }

		[Export ("orientation")]
		UIInterfaceOrientation Orientation { get; set; }

		[Export ("holdsAfterTouchingForInterval")]
		double HoldsAfterTouchingForInterval { get; set; }

		[Export ("numberOfPages")]
		int NumberOfPages { get; }

		[Export ("centerPage")]
		UIView CenterPage { get; }

		[Export ("visiblePages")]
		NSDictionary VisiblePages { get; }

		[Export ("setOrientation:animated:")]
		void SetOrientation (UIInterfaceOrientation orientation, bool animated);

		[Export ("pageAtIndex:")]
		UIView PageAtIndex (int pageIndex);

		[Export ("zoomToDistance:")]
		void ZoomToDistance (float distance);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTScrollViewDelegate
	{
		[Export ("scrollView:didMoveToPageAtIndex:")]
		void ScrollView (TTScrollView scrollView, int pageIndex);

		[Export ("scrollViewWillRotate:toOrientation:")]
		void ScrollViewWillRotate (TTScrollView scrollView, UIInterfaceOrientation orientation);

		[Export ("scrollViewDidRotate:")]
		void ScrollViewDidRotate (TTScrollView scrollView);

		[Export ("scrollViewWillBeginDragging:")]
		void ScrollViewWillBeginDragging (TTScrollView scrollView);

		[Export ("scrollViewDidEndDragging:willDecelerate:")]
		void ScrollViewDidEndDragging (TTScrollView scrollView, bool willDecelerate);

		[Export ("scrollViewDidEndDecelerating:")]
		void ScrollViewDidEndDecelerating (TTScrollView scrollView);

		[Export ("scrollViewShouldZoom:")]
		bool ScrollViewShouldZoom (TTScrollView scrollView);

		[Export ("scrollViewDidBeginZooming:")]
		void ScrollViewDidBeginZooming (TTScrollView scrollView);

		[Export ("scrollViewDidEndZooming:")]
		void ScrollViewDidEndZooming (TTScrollView scrollView);

		[Export ("scrollView:touchedDown:")]
		void ScrollViewTouchedDown (TTScrollView scrollView, UITouch touch);

		[Export ("scrollView:touchedUpInside:")]
		void ScrollViewTouchedUpInside (TTScrollView scrollView, UITouch touch);

		[Export ("scrollView:tapped:")]
		void ScrollViewTapped (TTScrollView scrollView, UITouch touch);

		[Export ("scrollViewDidBeginHolding:")]
		void ScrollViewDidBeginHolding (TTScrollView scrollView);

		[Export ("scrollViewDidEndHolding:")]
		void ScrollViewDidEndHolding (TTScrollView scrollView);

		[Export ("scrollView:shouldAutorotateToInterfaceOrientation:")]
		bool ScrollView (TTScrollView scrollView, UIInterfaceOrientation orientation);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTScrollViewDataSource
	{
		[Export ("numberOfPagesInScrollView:")]
		int NumberOfPagesInScrollView (TTScrollView scrollView);

		[Export ("scrollView:pageAtIndex:")]
		UIView ScrollViewPageAtIndex (TTScrollView scrollView, int pageIndex);

		[Export ("scrollView:sizeOfPageAtIndex:")]
		SizeF ScrollViewSizeOfPageAtIndex (TTScrollView scrollView, int pageIndex);
	}

	[BaseType (typeof (TTView))]
	interface TTSearchBar
	{
		[Wrap ("WeakDelegate")] 
		UITextFieldDelegate  Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("dataSource", ArgumentSemantic.Retain)]
		TTTableViewDataSource DataSource { get; set; }

		[Export ("text", ArgumentSemantic.Copy)]
		string Text { get; set; }

		[Export ("placeholder", ArgumentSemantic.Copy)]
		string Placeholder { get; set; }

		[Export ("tableView")]
		UITableView TableView { get; }

		[Export ("boxView")]
		TTView BoxView { get; }

		[Export ("tintColor", ArgumentSemantic.Retain)]
		UIColor TintColor { get; set; }

		[Export ("textColor", ArgumentSemantic.Retain)]
		UIColor TextColor { get; set; }

		[Export ("font", ArgumentSemantic.Retain)]
		UIFont Font { get; set; }

		[Export ("textFieldStyle", ArgumentSemantic.Retain)]
		TTStyle TextFieldStyle { get; set; }

		[Export ("returnKeyType")]
		UIReturnKeyType ReturnKeyType { get; set; }

		[Export ("rowHeight")]
		float RowHeight { get; set; }

		[Export ("editing")]
		bool Editing { get; }

		[Export ("searchesAutomatically")]
		bool SearchesAutomatically { get; set; }

		[Export ("showsCancelButton")]
		bool ShowsCancelButton { get; set; }

		[Export ("showsDoneButton")]
		bool ShowsDoneButton { get; set; }

		[Export ("showsDarkScreen")]
		bool ShowsDarkScreen { get; set; }

		[Export ("showsSearchIcon")]
		bool ShowsSearchIcon { get; set; }

		[Export ("showSearchResults:")]
		void ShowSearchResults (bool show);
	}

	[BaseType (typeof (UISearchDisplayController))]
	interface TTSearchDisplayController
	{
		[Export ("searchResultsViewController", ArgumentSemantic.Retain)]
		TTTableViewController SearchResultsViewController { get; set; }

		[Export ("pausesBeforeSearching")]
		bool PausesBeforeSearching { get; set; }
	}

	[BaseType (typeof (UIView))]
	interface TTSearchlightLabel
	{
		[Export ("text", ArgumentSemantic.Copy)]
		string Text { get; set; }

		[Export ("font", ArgumentSemantic.Retain)]
		UIFont Font { get; set; }

		[Export ("textColor", ArgumentSemantic.Retain)]
		UIColor TextColor { get; set; }

		[Export ("spotlightColor", ArgumentSemantic.Retain)]
		UIColor SpotlightColor { get; set; }

		[Export ("textAlignment")]
		UITextAlignment TextAlignment { get; set; }
	}

	[BaseType (typeof (UITextField))]
	interface TTSearchTextField
	{
		[Export ("dataSource", ArgumentSemantic.Retain)]
		TTTableViewDataSource DataSource { get; set; }

		[Export ("tableView")]
		UITableView TableView { get; }

		[Export ("rowHeight")]
		float RowHeight { get; set; }

		[Export ("hasText")]
		bool HasText { get; }

		[Export ("searchesAutomatically")]
		bool SearchesAutomatically { get; set; }

		[Export ("showsDoneButton")]
		bool ShowsDoneButton { get; set; }

		[Export ("showsDarkScreen")]
		bool ShowsDarkScreen { get; set; }

		[Export ("showSearchResults:")]
		void ShowSearchResults (bool show);

		[Export ("rectForSearchResults:")]
		RectangleF RectForSearchResults (bool withKeyboard);

		[Export ("shouldUpdate:")]
		bool ShouldUpdate (bool emptyText);
	}

	[BaseType (typeof (UITextFieldDelegate))]
	[Model]
	interface TTSearchTextFieldDelegate
	{
		[Export ("textField:didSelectObject:")]
		void TextField (TTSearchTextField textField, IntPtr Object);
	}

	[BaseType (typeof (NSObject))]
	interface TTShape
	{
		[Export ("openPath:")]
		void OpenPath (RectangleF rect);

		[Export ("closePath:")]
		void ClosePath (RectangleF rect);

		[Export ("addTopEdgeToPath:lightSource:")]
		void AddTopEdgeToPath (RectangleF rect, int lightSource);

		[Export ("addRightEdgeToPath:lightSource:")]
		void AddRightEdgeToPath (RectangleF rect, int lightSource);

		[Export ("addBottomEdgeToPath:lightSource:")]
		void AddBottomEdgeToPath (RectangleF rect, int lightSource);

		[Export ("addLeftEdgeToPath:lightSource:")]
		void AddLeftEdgeToPath (RectangleF rect, int lightSource);

		[Export ("addToPath:")]
		void AddToPath (RectangleF rect);

		[Export ("addInverseToPath:")]
		void AddInverseToPath (RectangleF rect);

		[Export ("insetsForSize:")]
		UIEdgeInsets InsetsForSize (SizeF size);
	}

	[BaseType (typeof (TTShape))]
	interface TTRectangleShape
	{
	}

	[BaseType (typeof (TTShape))]
	interface TTRoundedRectangleShape
	{
		[Export ("topLeftRadius")]
		float TopLeftRadius { get; set; }

		[Export ("topRightRadius")]
		float TopRightRadius { get; set; }

		[Export ("bottomRightRadius")]
		float BottomRightRadius { get; set; }

		[Export ("bottomLeftRadius")]
		float BottomLeftRadius { get; set; }
	}

	[BaseType (typeof (TTShape))]
	interface TTRoundedRightArrowShape
	{
		[Export ("radius")]
		float Radius { get; set; }
	}

	[BaseType (typeof (TTShape))]
	interface TTRoundedLeftArrowShape
	{
		[Export ("radius")]
		float Radius { get; set; }
	}

	[BaseType (typeof (TTShape))]
	interface TTSpeechBubbleShape
	{
		[Export ("radius")]
		float Radius { get; set; }

		[Export ("pointLocation")]
		float PointLocation { get; set; }

		[Export ("pointAngle")]
		float PointAngle { get; set; }

		[Export ("pointSize")]
		SizeF PointSize { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface TTStyleContext
	{
		[Wrap ("WeakDelegate")] 
		TTStyleDelegate  Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("frame")]
		RectangleF Frame { get; set; }

		[Export ("contentFrame")]
		RectangleF ContentFrame { get; set; }

		[Export ("shape", ArgumentSemantic.Retain)]
		TTShape Shape { get; set; }

		[Export ("font", ArgumentSemantic.Retain)]
		UIFont Font { get; set; }

		[Export ("didDrawContent")]
		bool DidDrawContent { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface TTStyle
	{
		[Export ("initWithNext:")]
		IntPtr Constructor (TTStyle next);

		[Export ("next:")]
		TTStyle Next (TTStyle next);

		[Export ("draw:")]
		void Draw (TTStyleContext context);

		[Export ("addToInsets:forSize:")]
		UIEdgeInsets AddToInsets (UIEdgeInsets insets, SizeF size);

		[Export ("addToSize:context:")]
		SizeF AddToSize (SizeF size, TTStyleContext context);

		[Export ("addStyle:")]
		void AddStyle (TTStyle style);

		[Export ("firstStyleOfClass:")]
		IntPtr FirstStyleOfClass (NSObject cls);

		[Export ("styleForPart:")]
		IntPtr StyleForPart (string name);
	}

	[BaseType (typeof (TTStyle))]
	interface TTContentStyle
	{
	}

	[BaseType (typeof (TTStyle))]
	interface TTPartStyle
	{
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; set; }

		[Export ("style", ArgumentSemantic.Retain)]
		TTStyle Style { get; set; }

		[Export ("drawPart:")]
		void DrawPart (TTStyleContext context);
	}

	[BaseType (typeof (TTStyle))]
	interface TTShapeStyle
	{
		[Export ("shape", ArgumentSemantic.Retain)]
		TTShape Shape { get; set; }
	}

	[BaseType (typeof (TTStyle))]
	interface TTInsetStyle
	{
		[Export ("inset")]
		UIEdgeInsets Inset { get; set; }
	}

	[BaseType (typeof (TTStyle))]
	interface TTBoxStyle
	{
		[Export ("margin")]
		UIEdgeInsets Margin { get; set; }

		[Export ("padding")]
		UIEdgeInsets Padding { get; set; }

		[Export ("minSize")]
		SizeF MinSize { get; set; }

		[Export ("position")]
		int Position { get; set; }
	}

	[BaseType (typeof (TTStyle))]
	interface TTTextStyle
	{
		[Export ("font", ArgumentSemantic.Retain)]
		UIFont Font { get; set; }

		[Export ("color", ArgumentSemantic.Retain)]
		UIColor Color { get; set; }

		[Export ("shadowColor", ArgumentSemantic.Retain)]
		UIColor ShadowColor { get; set; }

		[Export ("minimumFontSize")]
		float MinimumFontSize { get; set; }

		[Export ("shadowOffset")]
		SizeF ShadowOffset { get; set; }

		[Export ("numberOfLines")]
		int NumberOfLines { get; set; }

		[Export ("textAlignment")]
		UITextAlignment TextAlignment { get; set; }

		[Export ("verticalAlignment")]
		UIControlContentVerticalAlignment VerticalAlignment { get; set; }

		[Export ("lineBreakMode")]
		UILineBreakMode LineBreakMode { get; set; }
	}

	[BaseType (typeof (TTStyle))]
	interface TTImageStyle
	{
		[Export ("imageURL", ArgumentSemantic.Copy)]
		string ImageURL { get; set; }

		[Export ("image", ArgumentSemantic.Retain)]
		UIImage Image { get; set; }

		[Export ("defaultImage", ArgumentSemantic.Retain)]
		UIImage DefaultImage { get; set; }

		[Export ("size")]
		SizeF Size { get; set; }

		[Export ("contentMode")]
		UIViewContentMode ContentMode { get; set; }
	}

	[BaseType (typeof (TTStyle))]
	interface TTMaskStyle
	{
		[Export ("mask", ArgumentSemantic.Retain)]
		UIImage Mask { get; set; }
	}

	[BaseType (typeof (TTStyle))]
	interface TTBlendStyle
	{
		[Export ("blendMode")]
		CGBlendMode BlendMode { get; set; }
	}

	[BaseType (typeof (TTStyle))]
	interface TTSolidFillStyle
	{
		[Export ("color", ArgumentSemantic.Retain)]
		UIColor Color { get; set; }
	}

	[BaseType (typeof (TTStyle))]
	interface TTLinearGradientFillStyle
	{
		[Export ("color1", ArgumentSemantic.Retain)]
		UIColor Color1 { get; set; }

		[Export ("color2", ArgumentSemantic.Retain)]
		UIColor Color2 { get; set; }
	}

	[BaseType (typeof (TTStyle))]
	interface TTReflectiveFillStyle
	{
		[Export ("color", ArgumentSemantic.Retain)]
		UIColor Color { get; set; }
	}

	[BaseType (typeof (TTStyle))]
	interface TTShadowStyle
	{
		[Export ("color", ArgumentSemantic.Retain)]
		UIColor Color { get; set; }

		[Export ("blur")]
		float Blur { get; set; }

		[Export ("offset")]
		SizeF Offset { get; set; }
	}

	[BaseType (typeof (TTShadowStyle))]
	interface TTInnerShadowStyle
	{
		[Export ("color", ArgumentSemantic.Retain)]
		UIColor Color { get; set; }

		[Export ("width")]
		float Width { get; set; }
	}

	[BaseType (typeof (TTStyle))]
	interface TTFourBorderStyle
	{
		[Export ("top", ArgumentSemantic.Retain)]
		UIColor Top { get; set; }

		[Export ("right", ArgumentSemantic.Retain)]
		UIColor Right { get; set; }

		[Export ("bottom", ArgumentSemantic.Retain)]
		UIColor Bottom { get; set; }

		[Export ("left", ArgumentSemantic.Retain)]
		UIColor Left { get; set; }

		[Export ("width")]
		float Width { get; set; }
	}

	[BaseType (typeof (TTStyle))]
	interface TTBevelBorderStyle
	{
		[Export ("highlight", ArgumentSemantic.Retain)]
		UIColor Highlight { get; set; }

		[Export ("shadow", ArgumentSemantic.Retain)]
		UIColor Shadow { get; set; }

		[Export ("width")]
		float Width { get; set; }

		[Export ("lightSource")]
		int LightSource { get; set; }
	}

	[BaseType (typeof (TTStyle))]
	interface TTLinearGradientBorderStyle
	{
		[Export ("color1", ArgumentSemantic.Retain)]
		UIColor Color1 { get; set; }

		[Export ("color2", ArgumentSemantic.Retain)]
		UIColor Color2 { get; set; }

		[Export ("location1")]
		float Location1 { get; set; }

		[Export ("location2")]
		float Location2 { get; set; }

		[Export ("width")]
		float Width { get; set; }
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTStyleDelegate
	{
		[Export ("textForLayerWithStyle:")]
		string TextForLayerWithStyle (TTStyle style);

		[Export ("imageForLayerWithStyle:")]
		UIImage ImageForLayerWithStyle (TTStyle style);

		[Export ("drawLayer:withStyle:")]
		void DrawLayer (TTStyleContext context, TTStyle style);
	}

	[BaseType (typeof (NSObject))]
	interface TTStyledFrame
	{
		[Export ("element")]
		TTStyledElement Element { get; }

		[Export ("nextFrame", ArgumentSemantic.Retain)]
		TTStyledFrame NextFrame { get; set; }

		[Export ("bounds")]
		RectangleF Bounds { get; set; }

		[Export ("x")]
		float X { get; set; }

		[Export ("y")]
		float Y { get; set; }

		[Export ("width")]
		float Width { get; set; }

		[Export ("height")]
		float Height { get; set; }

		[Export ("initWithElement:")]
		IntPtr Constructor (TTStyledElement element);

		[Export ("drawInRect:")]
		void DrawInRect (RectangleF rect);

		[Export ("hitTest:")]
		TTStyledBoxFrame HitTest (PointF point);
	}

	[BaseType (typeof (TTStyledFrame))]
	interface TTStyledBoxFrame
	{
		[Export ("parentFrame", ArgumentSemantic.Assign)]
		TTStyledBoxFrame ParentFrame { get; set; }

		[Export ("firstChildFrame", ArgumentSemantic.Retain)]
		TTStyledFrame FirstChildFrame { get; set; }

		[Export ("style", ArgumentSemantic.Retain)]
		TTStyle Style { get; set; }
	}

	[BaseType (typeof (TTStyledBoxFrame))]
	interface TTStyledInlineFrame
	{
		[Export ("inlineParentFrame")]
		TTStyledInlineFrame InlineParentFrame { get; }

		[Export ("inlinePreviousFrame", ArgumentSemantic.Assign)]
		TTStyledInlineFrame InlinePreviousFrame { get; set; }

		[Export ("inlineNextFrame", ArgumentSemantic.Assign)]
		TTStyledInlineFrame InlineNextFrame { get; set; }
	}

	[BaseType (typeof (TTStyledFrame))]
	interface TTStyledTextFrame
	{
		[Export ("node")]
		TTStyledTextNode Node { get; }

		[Export ("text")]
		string Text { get; }

		[Export ("font", ArgumentSemantic.Retain)]
		UIFont Font { get; set; }

		[Export ("initWithText:element:node:")]
		IntPtr Constructor (string text, TTStyledElement element, TTStyledTextNode node);
	}

	[BaseType (typeof (TTStyledFrame))]
	interface TTStyledImageFrame
	{
		[Export ("imageNode")]
		TTStyledImageNode ImageNode { get; }

		[Export ("style", ArgumentSemantic.Retain)]
		TTStyle Style { get; set; }

		[Export ("initWithElement:node:")]
		IntPtr Constructor (TTStyledElement element, TTStyledImageNode node);
	}

	[BaseType (typeof (NSObject))]
	interface TTStyledLayout
	{
		[Export ("width")]
		float Width { get; set; }

		[Export ("height")]
		float Height { get; set; }

		[Export ("font", ArgumentSemantic.Retain)]
		UIFont Font { get; set; }

		[Export ("rootFrame")]
		TTStyledFrame RootFrame { get; }

		[Export ("invalidImages", ArgumentSemantic.Retain)]
		NSArray InvalidImages { get; set; }

		[Export ("initWithRootNode:")]
		IntPtr Constructor (TTStyledNode rootNode);

		[Export ("initWithX:width:height:")]
		IntPtr Constructor (float x, float width, float height);

		[Export ("layout:")]
		void Layout (TTStyledNode node);

		[Export ("layout:container:")]
		void Layout (TTStyledNode node, TTStyledElement element);
	}

	[BaseType (typeof (NSObject))]
	interface TTStyledNode
	{
		[Export ("nextSibling")]
		TTStyledNode NextSibling { get; set; }

		[Export ("parentNode")]
		TTStyledNode ParentNode { get; set; }

		[Export ("outerText")]
		string OuterText { get; set; }

		[Export ("outerHTML")]
		string OuterHTML { get; set; }

		[Export ("initWithNextSibling:")]
		IntPtr Constructor (TTStyledNode nextSibling);

		[Export ("ancestorOrSelfWithClass:")]
		IntPtr AncestorOrSelfWithClass (NSObject cls);
	}

	[BaseType (typeof (TTStyledNode))]
	interface TTStyledTextNode
	{
		[Export ("text")]
		string Text { get; set; }

		[Export ("initWithText:")]
		IntPtr Constructor (string text);

		[Export ("initWithText:next:")]
		IntPtr Constructor (string text, TTStyledNode nextSibling);
	}

	[BaseType (typeof (TTStyledNode))]
	interface TTStyledElement
	{
		[Export ("firstChild")]
		TTStyledNode FirstChild { get; set; }

		[Export ("lastChild")]
		TTStyledNode LastChild { get; set; }

		[Export ("className")]
		string ClassName { get; set; }

		[Export ("initWithText:")]
		IntPtr Constructor (string text);

		[Export ("initWithText:next:")]
		IntPtr Constructor (string text, TTStyledNode nextSibling);

		[Export ("addChild:")]
		void AddChild (TTStyledNode child);

		[Export ("addText:")]
		void AddText (string text);

		[Export ("replaceChild:withChild:")]
		void ReplaceChild (TTStyledNode oldChild, TTStyledNode newChild);

		[Export ("getElementByClassName:")]
		TTStyledNode GetElementByClassName (string className);
	}

	[BaseType (typeof (TTStyledElement))]
	interface TTStyledBlock
	{
	}

	[BaseType (typeof (TTStyledElement))]
	interface TTStyledInlineBlock
	{
	}
	
	//[BaseType (typeof (TTStyledInline))]
	[BaseType (typeof (TTStyledInlineBlock))]
	interface TTStyledItalicNode
	{
		
	}
	[BaseType (typeof (TTStyledInlineBlock))]
	interface TTStyledLinkNode
	{
		[Export ("highlighted")]
		bool Highlighted { get; set; }

		[Export ("URL", ArgumentSemantic.Retain)]
		string URL { get; set; }

		[Export ("initWithURL:")]
		IntPtr Constructor (string URL);

		[Export ("initWithURL:next:")]
		IntPtr Constructor (string URL, TTStyledNode nextSibling);

		[Export ("initWithText:URL:next:")]
		IntPtr Constructor (string text, string URL, TTStyledNode nextSibling);
	}

	[BaseType (typeof (TTStyledInlineBlock))]
	interface TTStyledButtonNode
	{
		[Export ("highlighted")]
		bool Highlighted { get; set; }

		[Export ("URL", ArgumentSemantic.Retain)]
		string URL { get; set; }

		[Export ("initWithURL:")]
		IntPtr Constructor (string URL);

		[Export ("initWithURL:next:")]
		IntPtr Constructor (string URL, TTStyledNode nextSibling);

		[Export ("initWithText:URL:next:")]
		IntPtr Constructor (string text, string URL, TTStyledNode nextSibling);
	}

	[BaseType (typeof (TTStyledElement))]
	interface TTStyledImageNode
	{
		[Export ("URL", ArgumentSemantic.Retain)]
		string URL { get; set; }

		[Export ("image", ArgumentSemantic.Retain)]
		UIImage Image { get; set; }

		[Export ("defaultImage", ArgumentSemantic.Retain)]
		UIImage DefaultImage { get; set; }

		[Export ("width")]
		float Width { get; set; }

		[Export ("height")]
		float Height { get; set; }

		[Export ("initWithURL:")]
		IntPtr Constructor (string URL);
	}

	[BaseType (typeof (NSObject))]
	interface TTStyledText
	{
		[Wrap ("WeakDelegate")] 
		TTStyledTextDelegate  Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("rootNode")]
		TTStyledNode RootNode { get; set; }

		[Export ("rootFrame")]
		TTStyledFrame RootFrame { get; set; }

		[Export ("font")]
		UIFont Font { get; set; }

		[Export ("width")]
		float Width { get; set; }

		[Export ("height")]
		float Height { get; set; }

		[Export ("needsLayout")]
		bool NeedsLayout { get; set; }

		[Export ("invalidImages")]
		NSArray InvalidImages { get; set; }

		[Export ("initWithNode:")]
		IntPtr Constructor (TTStyledNode rootNode);

		[Export ("drawAtPoint:")]
		void DrawAtPoint (PointF point);

		[Export ("drawAtPoint:highlighted:")]
		void DrawAtPoint (PointF point, bool highlighted);

		[Export ("hitTest:")]
		TTStyledBoxFrame HitTest (PointF point);

		[Export ("getFrameForNode:")]
		TTStyledFrame GetFrameForNode (TTStyledNode node);

		[Export ("addChild:")]
		void AddChild (TTStyledNode child);

		[Export ("addText:")]
		void AddText (string text);

		[Export ("insertChild:atIndex:")]
		void InsertChild (TTStyledNode child, int index);

		[Export ("getElementByClassName:")]
		TTStyledNode GetElementByClassName (string className);
		
		[Static, Export ("textFromXHTML:")]
		TTStyledText TextFromXHTML (string source);
		
		[Static, Export ("textFromXHTML:lineBreaks:URLs:")]
		TTStyledText TextFromXHTML (string source, bool lineBreaks, bool URLs);
		
		[Static, Export ("textWithURLs:")]
		TTStyledText TextWithURLs (string source);
		
		[Static, Export ("textWithURLs:lineBreaks:")]
		TTStyledText TextWithURLs (string source, bool lineBreaks);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTStyledTextDelegate
	{
		[Export ("styledTextNeedsDisplay:")]
		void StyledTextNeedsDisplay (TTStyledText text);
	}

	[BaseType (typeof (UIView))]
	interface TTStyledTextLabel
	{
		[Export ("text")]
		TTStyledText Text { get; set; }

		[Export ("html")]
		string Html { get; set; }

		[Export ("font")]
		UIFont Font { get; set; }

		[Export ("textColor")]
		UIColor TextColor { get; set; }

		[Export ("highlightedTextColor")]
		UIColor HighlightedTextColor { get; set; }

		[Export ("textAlignment")]
		UITextAlignment TextAlignment { get; set; }

		[Export ("contentInset")]
		UIEdgeInsets ContentInset { get; set; }

		[Export ("highlighted")]
		bool Highlighted { get; set; }

		[Export ("highlightedNode", ArgumentSemantic.Retain)]
		TTStyledElement HighlightedNode { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface TTStyledTextParser
	{
		[Export ("rootNode")]
		TTStyledNode RootNode { get; set; }

		[Export ("parseLineBreaks")]
		bool ParseLineBreaks { get; set; }

		[Export ("parseURLs")]
		bool ParseURLs { get; set; }

		[Export ("parseXHTML:")]
		void ParseXHTML (string html);

		[Export ("parseText:")]
		void ParseText (string String);
	}

	[BaseType (typeof (NSObject))]
	interface TTStyleSheet
	{
		[Static, Export ("globalStyleSheet")]
		TTStyleSheet GlobalStyleSheet { get; set; }
		
		[Export ("styleWithSelector:")]
		TTStyle StyleWithSelector (string selector);

		[Export ("styleWithSelector:forState:")]
		TTStyle StyleWithSelector (string selector, UIControlState state);
	}

	[BaseType (typeof (TTView))]
	interface TTTabBar
	{
		[Wrap ("WeakDelegate")] 
		TTTabDelegate  Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("tabItems", ArgumentSemantic.Retain)]
		NSArray TabItems { get; set; }

		[Export ("tabViews")]
		NSArray TabViews { get; }

		[Export ("tabStyle", ArgumentSemantic.Copy)]
		string TabStyle { get; set; }

		[Export ("selectedTabItem", ArgumentSemantic.Assign)]
		TTTabItem SelectedTabItem { get; set; }

		[Export ("selectedTabView", ArgumentSemantic.Assign)]
		TTTab SelectedTabView { get; set; }

		[Export ("selectedTabIndex")]
		int SelectedTabIndex { get; set; }

		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);

		[Export ("showTabAtIndex:")]
		void ShowTabAtIndex (int tabIndex);

		[Export ("hideTabAtIndex:")]
		void HideTabAtIndex (int tabIndex);
	}

	[BaseType (typeof (TTTabBar))]
	interface TTTabStrip
	{
	}

	[BaseType (typeof (TTTabBar))]
	interface TTTabGrid
	{
		[Export ("columnCount")]
		int ColumnCount { get; set; }
	}

	[BaseType (typeof (TTButton))]
	interface TTTab
	{
		[Export ("tabItem", ArgumentSemantic.Retain)]
		TTTabItem TabItem { get; set; }

		[Export ("initWithItem:tabBar:")]
		IntPtr Constructor (TTTabItem item, TTTabBar tabBar);
	}

	[BaseType (typeof (NSObject))]
	interface TTTabItem
	{
		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		[Export ("icon", ArgumentSemantic.Copy)]
		string Icon { get; set; }

		[Export ("object", ArgumentSemantic.Retain)]
		IntPtr Object { get; set; }

		[Export ("badgeNumber")]
		int BadgeNumber { get; set; }

		[Export ("initWithTitle:")]
		IntPtr Constructor (string title);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTTabDelegate
	{
		[Export ("tabBar:tabSelected:")]
		void TabBar (TTTabBar tabBar, int selectedIndex);
	}

	[BaseType (typeof (TTView))]
	interface TTTableHeaderView
	{
		[Export ("initWithTitle:")]
		IntPtr Constructor (string title);
	}

	[BaseType (typeof (NSObject))]
	interface TTTableItem
	{
		[Export ("userInfo", ArgumentSemantic.Retain)]
		IntPtr UserInfo { get; set; }
	}

	[BaseType (typeof (TTTableItem))]
	interface TTTableLinkedItem
	{
		[Export ("URL", ArgumentSemantic.Copy)]
		string URL { get; set; }

		[Export ("accessoryURL", ArgumentSemantic.Copy)]
		string AccessoryURL { get; set; }
	}

	[BaseType (typeof (TTTableLinkedItem))]
	interface TTTableTextItem
	{
		[Export ("text", ArgumentSemantic.Copy)]
		string Text { get; set; }
	}

	[BaseType (typeof (TTTableTextItem))]
	interface TTTableCaptionItem
	{
		[Export ("caption", ArgumentSemantic.Copy)]
		string Caption { get; set; }
	}

	[BaseType (typeof (TTTableCaptionItem))]
	interface TTTableRightCaptionItem
	{
	}

	[BaseType (typeof (TTTableTextItem))]
	interface TTTableSubtitleItem
	{
		[Export ("subtitle", ArgumentSemantic.Copy)]
		string Subtitle { get; set; }

		[Export ("imageURL", ArgumentSemantic.Copy)]
		string ImageURL { get; set; }

		[Export ("defaultImage", ArgumentSemantic.Retain)]
		UIImage DefaultImage { get; set; }
	}

	[BaseType (typeof (TTTableTextItem))]
	interface TTTableMessageItem
	{
		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		[Export ("caption", ArgumentSemantic.Copy)]
		string Caption { get; set; }

		[Export ("timestamp", ArgumentSemantic.Retain)]
		NSDate Timestamp { get; set; }

		[Export ("imageURL", ArgumentSemantic.Copy)]
		string ImageURL { get; set; }
	}

	[BaseType (typeof (TTTableTextItem))]
	interface TTTableLongTextItem
	{
	}

	[BaseType (typeof (TTTableTextItem))]
	interface TTTableSummaryItem
	{
	}

	[BaseType (typeof (TTTableTextItem))]
	interface TTTableButton
	{
		[Export ("isLoading")]
		bool IsLoading { get; set; }
	}

	[BaseType (typeof (TTTableTextItem))]
	interface TTTableImageItem
	{
		[Export ("imageURL", ArgumentSemantic.Copy)]
		string ImageURL { get; set; }

		[Export ("defaultImage", ArgumentSemantic.Retain)]
		UIImage DefaultImage { get; set; }

		[Export ("imageStyle", ArgumentSemantic.Retain)]
		TTStyle ImageStyle { get; set; }
	}

	[BaseType (typeof (TTTableImageItem))]
	interface TTTableRightImageItem
	{
		[Export ("text", ArgumentSemantic.Copy)]
		string Text { get; set; }
	}

	[BaseType (typeof (TTTableLinkedItem))]
	interface TTTableStyledTextItem
	{
		[Export ("text", ArgumentSemantic.Retain)]
		TTStyledText Text { get; set; }

		[Export ("margin")]
		UIEdgeInsets Margin { get; set; }

		[Export ("padding")]
		UIEdgeInsets Padding { get; set; }
	}

	[BaseType (typeof (TTTableItem))]
	interface TTTableControlItem
	{
		[Export ("caption", ArgumentSemantic.Copy)]
		string Caption { get; set; }

		[Export ("control", ArgumentSemantic.Retain)]
		UIControl Control { get; set; }
	}

	[BaseType (typeof (TTTableItem))]
	interface TTTableViewItem
	{
		[Export ("caption", ArgumentSemantic.Copy)]
		string Caption { get; set; }

		[Export ("view", ArgumentSemantic.Retain)]
		UIView View { get; set; }
	}

	[BaseType (typeof (TTTableViewCell))]
	interface TTTableLinkedItemCell
	{
	}

	[BaseType (typeof (TTTableLinkedItemCell))]
	interface TTTableTextItemCell
	{
		[Export ("captionLabel")]
		UILabel CaptionLabel { get; }
	}

	[BaseType (typeof (TTTableLinkedItemCell))]
	interface TTTableSubtextItemCell
	{
		[Export ("captionLabel")]
		UILabel CaptionLabel { get; }
	}

	[BaseType (typeof (TTTableLinkedItemCell))]
	interface TTTableRightCaptionItemCell
	{
		[Export ("captionLabel")]
		UILabel CaptionLabel { get; }
	}

	[BaseType (typeof (TTTableLinkedItemCell))]
	interface TTTableSubtitleItemCell
	{
		[Export ("subtitleLabel")]
		UILabel SubtitleLabel { get; set; }

		[Export ("imageView2")]
		TTImageView ImageView2 { get; set; }
	}

	[BaseType (typeof (TTTableLinkedItemCell))]
	interface TTTableMessageItemCell
	{
		[Export ("titleLabel")]
		UILabel TitleLabel { get; set; }

		[Export ("captionLabel")]
		UILabel CaptionLabel { get; }

		[Export ("timestampLabel")]
		UILabel TimestampLabel { get; set; }

		[Export ("imageView2")]
		TTImageView ImageView2 { get; set; }
	}

	[BaseType (typeof (TTTableSubtitleItemCell))]
	interface TTTableMoreButtonCell
	{
		[Export ("activityIndicatorView")]
		UIActivityIndicatorView ActivityIndicatorView { get; set; }

		[Export ("animating")]
		bool Animating { get; set; }
	}

	[BaseType (typeof (TTTableTextItemCell))]
	interface TTTableImageItemCell
	{
		[Export ("imageView2")]
		TTImageView ImageView2 { get; set; }
	}

	[BaseType (typeof (TTTableLinkedItemCell))]
	interface TTStyledTextTableItemCell
	{
		[Export ("label")]
		TTStyledTextLabel Label { get; }
	}

	[BaseType (typeof (TTTableViewCell))]
	interface TTStyledTextTableCell
	{
		[Export ("label")]
		TTStyledTextLabel Label { get; }
	}

	[BaseType (typeof (TTTableViewCell))]
	interface TTTableActivityItemCell
	{
		[Export ("activityLabel")]
		TTActivityLabel ActivityLabel { get; set; }
	}

	[BaseType (typeof (TTTableViewCell))]
	interface TTTableControlCell
	{
		[Export ("item")]
		TTTableControlItem Item { get; set; }

		[Export ("control")]
		UIControl Control { get; set; }
	}

	[BaseType (typeof (TTTableViewCell))]
	interface TTTableFlushViewCell
	{
		[Export ("item")]
		TTTableViewItem Item { get; set; }

		[Export ("view")]
		UIView View { get; set; }
	}

	[BaseType (typeof (UITableView))]
	interface TTTableView
	{
		[Export ("highlightedLabel", ArgumentSemantic.Retain)]
		TTStyledTextLabel HighlightedLabel { get; set; }

		[Export ("contentOrigin")]
		float ContentOrigin { get; set; }
	}

	[BaseType (typeof (UITableViewDelegate))]
	[Model]
	interface TTTableViewDelegate
	{
		[Export ("tableView:touchesBegan:withEvent:")]
		void TableViewTouchesBegan (UITableView tableView, NSSet touches, UIEvent Event);

		[Export ("tableView:touchesEnded:withEvent:")]
		void TableViewTouchesEnded (UITableView tableView, NSSet touches, UIEvent Event);
	}

	[BaseType (typeof (UITableViewCell))]
	interface TTTableViewCell
	{
		[Export ("object", ArgumentSemantic.Retain)]
		IntPtr Object { get; set; }
	}

	[BaseType (typeof (TTModelViewController))]
	interface TTTableViewController
	{
		[Export ("tableView", ArgumentSemantic.Retain)]
		UITableView TableView { get; set; }

		[Export ("tableBannerView", ArgumentSemantic.Retain)]
		UIView TableBannerView { get; set; }

		[Export ("tableOverlayView", ArgumentSemantic.Retain)]
		UIView TableOverlayView { get; set; }

		[Export ("loadingView", ArgumentSemantic.Retain)]
		UIView LoadingView { get; set; }

		[Export ("errorView", ArgumentSemantic.Retain)]
		UIView ErrorView { get; set; }

		[Export ("emptyView", ArgumentSemantic.Retain)]
		UIView EmptyView { get; set; }

		[Export ("menuView")]
		UIView MenuView { get; }

		[Export ("dataSource", ArgumentSemantic.Retain)]
		TTTableViewDataSource DataSource { get; set; }

		[Export ("tableViewStyle")]
		UITableViewStyle TableViewStyle { get; set; }

		[Export ("variableHeightRows")]
		bool VariableHeightRows { get; set; }

		[Export ("initWithStyle:")]
		IntPtr Constructor (UITableViewStyle style);

		[Export ("setTableBannerView:animated:")]
		void SetTableBannerView (UIView tableBannerView, bool animated);

		[Export ("showMenu:forCell:animated:")]
		void ShowMenu (UIView view, UITableViewCell cell, bool animated);

		[Export ("hideMenu:")]
		void HideMenu (bool animated);

		[Export ("didSelectObject:atIndexPath:")]
		void DidSelectObject (IntPtr Object, NSIndexPath indexPath);

		[Export ("shouldOpenURL:")]
		bool ShouldOpenURL (string URL);
	}

	[BaseType (typeof (NSObject))]
	interface TTTableViewDataSource
	{
	}

	[BaseType (typeof (TTPopupViewController))]
	interface TTTextBarController
	{
		[Export ("textEditor")]
		TTTextEditor TextEditor { get; }

		[Export ("postButton")]
		TTButton PostButton { get; }

		[Export ("footerBar", ArgumentSemantic.Retain)]
		UIView FooterBar { get; set; }

		[Export ("dismissWithResult:animated:")]
		void DismissWithResult (IntPtr result, bool animated);

		[Export ("failWithError:")]
		void FailWithError (NSError error);

		[Export ("willPostText:")]
		bool WillPostText (string text);

		[Export ("titleForError:")]
		string TitleForError (NSError error);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTTextBarDelegate
	{
		[Export ("textBarDidBeginEditing:")]
		void TextBarDidBeginEditing (TTTextBarController textBar);

		[Export ("textBarDidEndEditing:")]
		void TextBarDidEndEditing (TTTextBarController textBar);

		[Export ("textBar:willPostText:")]
		bool TextBar (TTTextBarController textBar, string text);

		[Export ("textBarDidCancel:")]
		void TextBarDidCancel (TTTextBarController textBar);
	}

	[BaseType (typeof (TTView))]
	interface TTTextEditor
	{
		[Wrap ("WeakDelegate")] 
		TTTextEditorDelegate  Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("text", ArgumentSemantic.Copy)]
		string Text { get; set; }

		[Export ("placeholder", ArgumentSemantic.Copy)]
		string Placeholder { get; set; }

		[Export ("font", ArgumentSemantic.Retain)]
		UIFont Font { get; set; }

		[Export ("textColor", ArgumentSemantic.Retain)]
		UIColor TextColor { get; set; }

		[Export ("minNumberOfLines")]
		int MinNumberOfLines { get; set; }

		[Export ("maxNumberOfLines")]
		int MaxNumberOfLines { get; set; }

		[Export ("editing")]
		bool Editing { get; }

		[Export ("autoresizesToText")]
		bool AutoresizesToText { get; set; }

		[Export ("showsExtraLine")]
		bool ShowsExtraLine { get; set; }

		[Export ("scrollContainerToCursor:")]
		void ScrollContainerToCursor (UIScrollView scrollView);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTTextEditorDelegate
	{
		[Export ("textEditorShouldBeginEditing:")]
		bool TextEditorShouldBeginEditing (TTTextEditor textEditor);

		[Export ("textEditorShouldEndEditing:")]
		bool TextEditorShouldEndEditing (TTTextEditor textEditor);

		[Export ("textEditorDidBeginEditing:")]
		void TextEditorDidBeginEditing (TTTextEditor textEditor);

		[Export ("textEditorDidEndEditing:")]
		void TextEditorDidEndEditing (TTTextEditor textEditor);

		[Export ("textEditorDidChange:")]
		void TextEditorDidChange (TTTextEditor textEditor);

		[Export ("textEditor:shouldResizeBy:")]
		bool TextEditor (TTTextEditor textEditor, float height);

		[Export ("textEditorShouldReturn:")]
		bool TextEditorShouldReturn (TTTextEditor textEditor);
	}

	[BaseType (typeof (TTTableViewCell))]
	interface TTThumbsTableViewCell
	{
		[Export ("photo", ArgumentSemantic.Retain)]
		TTPhoto Photo { get; set; }

		//[Wrap ("WeakDelegate")] 
		//TTThumbsTableViewCellDelegate  Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("thumbSize")]
		float ThumbSize { get; set; }

		[Export ("thumbOrigin")]
		PointF ThumbOrigin { get; set; }

		[Export ("columnCount")]
		int ColumnCount { get; set; }

		[Export ("suspendLoading:")]
		void SuspendLoading (bool suspended);
	}

	[BaseType (typeof (TTTableViewController))]
	interface TTThumbsViewController
	{
		[Wrap ("WeakDelegate")] 
		TTThumbsViewControllerDelegate  Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("photoSource", ArgumentSemantic.Retain)]
		TTPhotoSource PhotoSource { get; set; }

		[Export ("initWithQuery:")]
		IntPtr Constructor (NSDictionary query);
	}

	[BaseType (typeof (TTTableViewDataSource))]
	interface TTThumbsDataSource
	{
		//[Wrap ("WeakDelegate")] 
		//TTThumbsTableViewCellDelegate  Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("photoSource", ArgumentSemantic.Retain)]
		TTPhotoSource PhotoSource { get; set; }
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTThumbsViewControllerDelegate
	{
	}

	[BaseType (typeof (TTButton))]
	interface TTThumbView
	{
		[Export ("thumbURL", ArgumentSemantic.Copy)]
		string ThumbURL { get; set; }
	}

	[BaseType (typeof (NSObject))]
	interface TTURLCache
	{
		[Export ("disableDiskCache")]
		bool DisableDiskCache { get; set; }

		[Export ("disableImageCache")]
		bool DisableImageCache { get; set; }

		[Export ("cachePath", ArgumentSemantic.Copy)]
		string CachePath { get; set; }

		[Export ("maxPixelCount")]
		int MaxPixelCount { get; set; }

		[Export ("invalidationAge")]
		double InvalidationAge { get; set; }

		[Export ("initWithName:")]
		IntPtr Constructor (string name);

		[Export ("cachePathForURL:")]
		string CachePathForURL (string URL);

		[Export ("cachePathForKey:")]
		string CachePathForKey (string key);

		[Export ("hasDataForURL:")]
		bool HasDataForURL (string URL);

		[Export ("dataForURL:")]
		NSData DataForURL (string URL);

		[Export ("imageForURL:")]
		IntPtr ImageForURL (string URL);

		[Export ("imageForURL:fromDisk:")]
		IntPtr ImageForURL (string URL, bool fromDisk);

		[Export ("storeData:forURL:")]
		void StoreDataForURL (NSData data, string URL);

		[Export ("storeData:forKey:")]
		void StoreDataForKey (NSData data, string key);

		[Export ("storeImage:forURL:")]
		void StoreImage (UIImage image, string URL);

		[Export ("storeTemporaryImage:toDisk:")]
		string StoreTemporaryImage (UIImage image, bool toDisk);

		[Export ("storeTemporaryData:")]
		string StoreTemporaryData (NSData data);

		[Export ("storeTemporaryFile:")]
		string StoreTemporaryFile (NSUrl fileURL);

		[Export ("moveDataForURL:toURL:")]
		void MoveDataForURL (string oldURL, string newURL);

		[Export ("moveDataFromPath:toURL:")]
		void MoveDataFromPath (string path, string newURL);

		[Export ("moveDataFromPathToTemporaryURL:")]
		string MoveDataFromPathToTemporaryURL (string path);

		[Export ("removeURL:fromDisk:")]
		void RemoveURL (string URL, bool fromDisk);

		[Export ("removeKey:")]
		void RemoveKey (string key);

		[Export ("removeAll:")]
		void RemoveAll (bool fromDisk);

		[Export ("invalidateURL:")]
		void InvalidateURL (string URL);

		[Export ("invalidateKey:")]
		void InvalidateKey (string key);
	}

	[BaseType (typeof (NSObject))]
	interface TTURLMap
	{
		[Export ("from:toObject:")]
		void FromToObject (string URL, IntPtr Object);

		[Export ("from:toObject:selector:")]
		void FromToObject (string URL, IntPtr Object, NSObject selector);

		[Export ("from:toViewController:")]
		void FromToViewController (string URL, IntPtr target);

		[Export ("from:toViewController:selector:")]
		void FromToViewController (string URL, IntPtr target, NSObject selector);

		[Export ("from:toViewController:transition:")]
		void FromToSharedViewController (string URL, IntPtr target, int transition);

		[Export ("from:toSharedViewController:")]
		void FromToSharedViewController (string URL, IntPtr target);

		[Export ("from:toSharedViewController:selector:")]
		void FromToSharedViewController (string URL, IntPtr target, NSObject selector);

		[Export ("from:toModalViewController:")]
		void FromToModalViewController (string URL, IntPtr target);

		[Export ("from:toModalViewController:selector:")]
		void FromToModalViewController (string URL, IntPtr target, NSObject selector);

		[Export ("from:toModalViewController:transition:")]
		void FromToModalViewController (string URL, IntPtr target, int transition);

		[Export ("from:toURL:")]
		void FromToUrl (NSObject cls, string URL);

		[Export ("from:name:toURL:")]
		void FromNameToUrl (NSObject cls, string name, string URL);

		[Export ("setObject:forURL:")]
		void SetObject (IntPtr Object, string URL);

		[Export ("removeURL:")]
		void RemoveURL (string URL);

		[Export ("removeObject:")]
		void RemoveObject (IntPtr Object);

		[Export ("removeObjectForURL:")]
		void RemoveObjectForURL (string URL);

		[Export ("objectForURL:")]
		IntPtr ObjectForURL (string URL);

		[Export ("objectForURL:query:")]
		IntPtr ObjectForURL (string URL, NSDictionary query);

		[Export ("dispatchURL:toTarget:query:")]
		IntPtr DispatchURL (string URL, IntPtr target, NSDictionary query);

		[Export ("navigationModeForURL:")]
		int NavigationModeForURL (string URL);

		[Export ("transitionForURL:")]
		int TransitionForURL (string URL);

		[Export ("isSchemeSupported:")]
		bool IsSchemeSupported (string scheme);

		[Export ("isAppURL:")]
		bool IsAppURL (NSUrl URL);

		[Export ("URLForObject:")]
		string URLForObject (IntPtr Object);

		[Export ("URLForObject:withName:")]
		string URLForObject (IntPtr Object, string name);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTURLObject
	{
		[Export ("URLValue")]
		string URLValue { get; }

		[Export ("URLValueWithName:")]
		string URLValueWithName (string name);
	}

	[BaseType (typeof (NSObject))]
	interface TTURLPattern
	{
		[Export ("URL", ArgumentSemantic.Copy)]
		string URL { get; set; }

		[Export ("scheme")]
		string Scheme { get; }

		[Export ("specificity")]
		int Specificity { get; }

		[Export ("classForInvocation")]
		NSObject ClassForInvocation { get; }

		//[Export ("selector")]
		//NSObject Selector { get; set; }

		[Export ("setSelectorIfPossible:")]
		void SetSelectorIfPossible (NSObject selector);
	}

	[BaseType (typeof (TTURLPattern))]
	interface TTURLNavigatorPattern
	{
		[Export ("targetClass")]
		NSObject TargetClass { get; set; }

		[Export ("targetObject", ArgumentSemantic.Assign)]
		IntPtr TargetObject { get; set; }

		[Export ("navigationMode")]
		int NavigationMode { get; }

		[Export ("parentURL", ArgumentSemantic.Copy)]
		string ParentURL { get; set; }

		[Export ("transition")]
		int Transition { get; set; }

		[Export ("argumentCount")]
		int ArgumentCount { get; set; }

		[Export ("isUniversal")]
		bool IsUniversal { get; }

		[Export ("isFragment")]
		bool IsFragment { get; }

		//[Export ("initWithTarget:")]
		//IntPtr Constructor (IntPtr target);

		[Export ("initWithTarget:mode:")]
		IntPtr Constructor (IntPtr target, int navigationMode);

		[Export ("matchURL:")]
		bool MatchURL (NSUrl URL);

		[Export ("invoke:withURL:query:")]
		IntPtr Invoke (IntPtr target, NSUrl URL, NSDictionary query);

		[Export ("createObjectFromURL:query:")]
		IntPtr CreateObjectFromURL (NSUrl URL, NSDictionary query);
	}

	[BaseType (typeof (TTURLPattern))]
	interface TTURLGeneratorPattern
	{
		[Export ("targetClass")]
		NSObject TargetClass { get; set; }

		[Export ("initWithTargetClass:")]
		IntPtr Constructor (Class targetClass);

		[Export ("generateURLFromObject:")]
		string GenerateURLFromObject (IntPtr Object);
	}

	[BaseType (typeof (NSObject))]
	interface TTURLRequest
	{
		[Export ("delegates")]
		NSArray Delegates { get; }

		[Export ("response", ArgumentSemantic.Retain)]
		TTURLResponse Response { get; set; }

		[Export ("URL", ArgumentSemantic.Copy)]
		string URL { get; set; }

		[Export ("httpMethod", ArgumentSemantic.Copy)]
		string HttpMethod { get; set; }

		[Export ("httpBody", ArgumentSemantic.Retain)]
		NSData HttpBody { get; set; }

		[Export ("contentType", ArgumentSemantic.Copy)]
		string ContentType { get; set; }

		[Export ("parameters")]
		NSDictionary Parameters { get; }

		[Export ("headers")]
		NSDictionary Headers { get; }

		[Export ("cachePolicy")]
		int CachePolicy { get; set; }

		[Export ("cacheExpirationAge")]
		double CacheExpirationAge { get; set; }

		[Export ("cacheKey", ArgumentSemantic.Retain)]
		string CacheKey { get; set; }

		[Export ("userInfo", ArgumentSemantic.Retain)]
		IntPtr UserInfo { get; set; }

		[Export ("timestamp", ArgumentSemantic.Retain)]
		NSDate Timestamp { get; set; }

		[Export ("isLoading")]
		bool IsLoading { get; set; }

		[Export ("shouldHandleCookies")]
		bool ShouldHandleCookies { get; set; }

		[Export ("totalBytesLoaded")]
		int TotalBytesLoaded { get; set; }

		[Export ("totalBytesExpected")]
		int TotalBytesExpected { get; set; }

		[Export ("respondedFromCache")]
		bool RespondedFromCache { get; set; }

		[Export ("addFile:mimeType:fileName:")]
		void AddFile (NSData data, string mimeType, string fileName);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTURLRequestDelegate
	{
		[Export ("requestDidStartLoad:")]
		void RequestDidStartLoad (TTURLRequest request);

		[Export ("requestDidUploadData:")]
		void RequestDidUploadData (TTURLRequest request);

		[Export ("requestDidFinishLoad:")]
		void RequestDidFinishLoad (TTURLRequest request);

		[Export ("request:didFailLoadWithError:")]
		void Request (TTURLRequest request, NSError error);

		[Export ("requestDidCancelLoad:")]
		void RequestDidCancelLoad (TTURLRequest request);
	}

	[BaseType (typeof (NSObject))]
	interface TTUserInfo
	{
		[Export ("topic", ArgumentSemantic.Retain)]
		string Topic { get; set; }

		[Export ("strong", ArgumentSemantic.Retain)]
		IntPtr Strong { get; set; }

		[Export ("weak", ArgumentSemantic.Assign)]
		IntPtr Weak { get; set; }

		[Export ("initWithTopic:strong:weak:")]
		IntPtr Constructor (string topic, IntPtr strong, IntPtr weak);
	}

	[BaseType (typeof (NSObject))]
	interface TTURLRequestQueue
	{
		[Export ("suspended")]
		bool Suspended { get; set; }

		[Export ("maxContentLength")]
		int MaxContentLength { get; set; }

		[Export ("userAgent", ArgumentSemantic.Copy)]
		string UserAgent { get; set; }

		[Export ("imageCompressionQuality")]
		float ImageCompressionQuality { get; set; }

		[Export ("sendRequest:")]
		bool SendRequest (TTURLRequest request);

		[Export ("cancelRequest:")]
		void CancelRequest (TTURLRequest request);

		[Export ("cancelRequestsWithDelegate:")]
		void CancelRequestsWithDelegate (IntPtr Delegate);

		[Export ("createNSURLRequest:URL:")]
		NSUrlRequest CreateNSURLRequest (TTURLRequest request, NSUrl URL);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTURLResponse
	{
	}

	[BaseType (typeof (NSObject))]
	interface TTURLDataResponse
	{
		[Export ("data")]
		NSData Data { get; }
	}

	[BaseType (typeof (NSObject))]
	interface TTURLImageResponse
	{
		[Export ("image")]
		UIImage Image { get; }
	}

	[BaseType (typeof (UIView))]
	interface TTView
	{
		[Export ("style", ArgumentSemantic.Retain)]
		TTStyle Style { get; set; }

		[Export ("layout", ArgumentSemantic.Retain)]
		TTLayout Layout { get; set; }

		[Export ("drawContent:")]
		void DrawContent (RectangleF rect);
	}

	[BaseType (typeof (UIViewController))]
	interface TTViewController
	{
		[Export ("navigationBarStyle")]
		UIBarStyle NavigationBarStyle { get; set; }

		[Export ("navigationBarTintColor", ArgumentSemantic.Retain)]
		UIColor NavigationBarTintColor { get; set; }

		[Export ("statusBarStyle")]
		UIStatusBarStyle StatusBarStyle { get; set; }

		[Export ("searchViewController", ArgumentSemantic.Retain)]
		TTTableViewController SearchViewController { get; set; }

		[Export ("hasViewAppeared")]
		bool HasViewAppeared { get; }

		[Export ("isViewAppearing")]
		bool IsViewAppearing { get; }

		[Export ("autoresizesForKeyboard")]
		bool AutoresizesForKeyboard { get; set; }

		[Export ("keyboardWillAppear:withBounds:")]
		void KeyboardWillAppear (bool animated, RectangleF bounds);

		[Export ("keyboardWillDisappear:withBounds:")]
		void KeyboardWillDisappear (bool animated, RectangleF bounds);

		[Export ("keyboardDidAppear:withBounds:")]
		void KeyboardDidAppear (bool animated, RectangleF bounds);

		[Export ("keyboardDidDisappear:withBounds:")]
		void KeyboardDidDisappear (bool animated, RectangleF bounds);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTWebControllerDelegate
	{
	}

	[BaseType (typeof (UIWebView))]
	interface TTYouTubeView
	{
		[Export ("URL", ArgumentSemantic.Copy)]
		string URL { get; set; }

		[Export ("initWithURL:")]
		IntPtr Constructor (string URL);
	}
}
