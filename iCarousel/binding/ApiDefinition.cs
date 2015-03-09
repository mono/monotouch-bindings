using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace iCarouselSDK
{
	[BaseType (typeof (UIView))]
	interface iCarousel 
	{
		[Export ("dataSource", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDataSource { get; set; }
		
		[Wrap ("WeakDataSource")] 
		iCarouselDataSource DataSource { get; set; }
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		[Wrap ("WeakDelegate")]
		iCarouselDelegate Delegate { get; set; }

		[Export ("type", ArgumentSemantic.Assign)]
		iCarouselType CarouselType { get; set; }

		[Export ("perspective", ArgumentSemantic.Assign)]
		nfloat Perspective { get; set; }

		[Export ("decelerationRate", ArgumentSemantic.Assign)]
		nfloat DecelerationRate { get; set; }

		[Export ("scrollSpeed", ArgumentSemantic.Assign)]
		nfloat ScrollSpeed { get; set; }

		[Export ("bounceDistance", ArgumentSemantic.Assign)]
		nfloat BounceDistance { get; set; }

		[Export ("scrollEnabled", ArgumentSemantic.Assign)]
		bool ScrollEnabled { [Bind ("isScrollEnabled")] get; set; }

		[Export ("vertical", ArgumentSemantic.Assign)]
		bool vertical { [Bind ("isVertical")] get; set; }

		[Export ("wrapEnabled", ArgumentSemantic.Assign)]
		bool WrapEnabled { [Bind ("isWrapEnabled")] get; }

		[Export ("bounces", ArgumentSemantic.Assign)]
		bool Bounces { get; set; }

		[Export ("scrollOffset", ArgumentSemantic.Assign)]
		nfloat ScrollOffset { get; set; }

		[Export ("offsetMultiplier")]
		nfloat OffsetMultiplier { get; }

		[Export ("contentOffset", ArgumentSemantic.Assign)]
		CGSize ContentOffset { get; set; }

		[Export ("viewpointOffset", ArgumentSemantic.Assign)]
		CGSize ViewpointOffset { get; set; }

		[Export ("numberOfItems")]
		nint NumberOfItems { get; }

		[Export ("numberOfPlaceholders")]
		nint NumberOfPlaceholders { get; }

		[Export ("currentItemIndex", ArgumentSemantic.Assign)]
		nint CurrentItemIndex { get; set; }

		[Export ("currentItemView")]
		UIView CurrentItemView { get; }

		[Export ("indexesForVisibleItems")]
		NSNumber [] IndexesForVisibleItems { get; }

		[Export ("numberOfVisibleItems")]
		nint NumberOfVisibleItems { get; }

		[Export ("itemWidth")]
		nfloat ItemWidth { get; }

		[Export ("contentView")]
		UIView ContentView { get; }

		[Export ("toggle")]
		nfloat Toggle { get; }

		[Export ("stopAtItemBoundary", ArgumentSemantic.Assign)]
		bool StopAtItemBoundary { get; set; }

		[Export ("scrollToItemBoundary", ArgumentSemantic.Assign)]
		bool ScrollToItemBoundary { get; set; }

		[Export ("ignorePerpendicularSwipes", ArgumentSemantic.Assign)]
		bool IgnorePerpendicularSwipes { get; set; }

		[Export ("centerItemWhenSelected", ArgumentSemantic.Assign)]
		bool CenterItemWhenSelected { get; set; }

		[Export ("dragging")]
		bool Dragging { [Bind ("isDragging")] get; set; }

		[Export ("decelerating")]
		bool Decelerating { [Bind ("isDecelerating")] get; set; }

		[Export ("scrolling")]
		bool Scrolling { [Bind ("isScrolling")] get; set; }

		[Export ("scrollByOffset:duration:")]
		void ScrollByOffset (nfloat offset, double duration);

		[Export ("scrollToOffset:duration:")]
		void ScrollToOffset (nfloat offset, double duration);

		[Export ("scrollByNumberOfItems:duration:")]
		void ScrollByNumberOfItems (nint itemCount, double duration);

		[Export ("scrollToItemAtIndex:duration:")]
		void ScrollToItem (nint index, double duration);

		[Export ("scrollToItemAtIndex:animated:")]
		void ScrollToItem (nint index, bool animated);

		[Export ("itemViewAtIndex:")]
		UIView GetItemView (nint index);

		[Export ("indexOfItemView:")]
		nint IndexOfItemView (UIView view);

		[Export ("indexOfItemViewOrSubview:")]
		nint IndexOfItemViewOrSubview (UIView view);

		[Export ("offsetForItemAtIndex:")]
		nfloat OffsetForItem (nint index);
	
		[Export ("removeItemAtIndex:animated:")]
		void RemoveItem (nint index, bool animated);

		[Export ("insertItemAtIndex:animated:")]
		void InsertItem (nint index, bool animated);

		[Export ("reloadItemAtIndex:animated:")]
		void ReloadItem (nint index, bool animated);

		[Export ("reloadData")]
		void ReloadData ();

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface iCarouselDataSource {

		[Export ("numberOfItemsInCarousel:")] [Abstract]
		nuint NumberOfItems (iCarousel carousel);

		[Export ("carousel:viewForItemAtIndex:reusingView:")] [Abstract]
		UIView ViewForItem (iCarousel carousel, nuint index, UIView reusingView);

		[Export ("numberOfPlaceholdersInCarousel:")]
		nuint NumberOfPlaceholders (iCarousel carousel);

		[Export ("carousel:placeholderViewAtIndex:reusingView:")]
		UIView PlaceholderViewAtIndex (iCarousel carousel, nuint index, UIView reusingView);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface iCarouselDelegate {

		[Export ("carouselWillBeginScrollingAnimation:")]
		void WillBeginScrollingAnimation (iCarousel carousel);

		[Export ("carouselDidEndScrollingAnimation:")]
		void DidEndScrollingAnimation (iCarousel carousel);

		[Export ("carouselDidScroll:")]
		void DidScroll (iCarousel carousel);

		[Export ("carouselCurrentItemIndexDidChange:")]
		void CurrentItemIndexDidChange (iCarousel carousel);

		[Export ("carouselWillBeginDragging:")]
		void WillBeginDragging (iCarousel carousel);

		[Export ("carouselDidEndDragging:willDecelerate:")]
		void DidEndDragging (iCarousel carousel, bool willDecelerate);

		[Export ("carouselWillBeginDecelerating:")]
		void WillBeginDecelerating (iCarousel carousel);

		[Export ("carouselDidEndDecelerating:")]
		void DidEndDecelerating (iCarousel carousel);

		[Export ("carousel:shouldSelectItemAtIndex:")]
		bool ShouldSelectItem (iCarousel carousel, nint index);

		[Export ("carousel:didSelectItemAtIndex:")]
		void DidSelectItem (iCarousel carousel, nint index);

		[Export ("carouselItemWidth:")]
		nfloat ItemWidth (iCarousel carousel);

		[Export ("carousel:itemTransformForOffset:baseTransform:")]
		CATransform3D ItemTransform (iCarousel carousel, nfloat offset, CATransform3D baseTransform);

		[Export ("carousel:valueForOption:withDefault:")]
		nfloat ValueForOption (iCarousel carousel, iCarouselOption option, nfloat aValue);
	}
}