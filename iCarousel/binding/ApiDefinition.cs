using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;

namespace iCarouselSDK
{

	[BaseType (typeof (UIView))]
	interface iCarousel {

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
		float Perspective { get; set; }

		[Export ("decelerationRate", ArgumentSemantic.Assign)]
		float DecelerationRate { get; set; }

		[Export ("scrollSpeed", ArgumentSemantic.Assign)]
		float ScrollSpeed { get; set; }

		[Export ("bounceDistance", ArgumentSemantic.Assign)]
		float BounceDistance { get; set; }

		[Export ("scrollEnabled", ArgumentSemantic.Assign)]
		bool ScrollEnabled { [Bind ("isScrollEnabled")] get; set; }

		[Export ("vertical", ArgumentSemantic.Assign)]
		bool vertical { [Bind ("isVertical")] get; set; }

		[Export ("wrapEnabled", ArgumentSemantic.Assign)]
		bool WrapEnabled { [Bind ("isWrapEnabled")] get; }

		[Export ("bounces", ArgumentSemantic.Assign)]
		bool Bounces { get; set; }

		[Export ("scrollOffset", ArgumentSemantic.Assign)]
		float ScrollOffset { get; set; }

		[Export ("offsetMultiplier")]
		float OffsetMultiplier { get; }

		[Export ("contentOffset", ArgumentSemantic.Assign)]
		SizeF ContentOffset { get; set; }

		[Export ("viewpointOffset", ArgumentSemantic.Assign)]
		SizeF ViewpointOffset { get; set; }

		[Export ("numberOfItems")]
		int NumberOfItems { get; }

		[Export ("numberOfPlaceholders")]
		int NumberOfPlaceholders { get; }

		[Export ("currentItemIndex", ArgumentSemantic.Assign)]
		int CurrentItemIndex { get; set; }

		[Export ("currentItemView")]
		UIView CurrentItemView { get; }

		[Export ("indexesForVisibleItems")]
		NSNumber [] IndexesForVisibleItems { get; }

		[Export ("numberOfVisibleItems")]
		int NumberOfVisibleItems { get; }

		[Export ("itemWidth")]
		float ItemWidth { get; }

		[Export ("contentView")]
		UIView ContentView { get; }

		[Export ("toggle")]
		float Toggle { get; }

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
		void ScrollByOffset (float offset, double duration);

		[Export ("scrollToOffset:duration:")]
		void ScrollToOffset (float offset, double duration);

		[Export ("scrollByNumberOfItems:duration:")]
		void ScrollByNumberOfItems (int itemCount, double duration);

		[Export ("scrollToItemAtIndex:duration:")]
		void ScrollToItem (int index, double duration);

		[Export ("scrollToItemAtIndex:animated:")]
		void ScrollToItem (int index, bool animated);

		[Export ("itemViewAtIndex:")]
		UIView GetItemView (int index);

		[Export ("indexOfItemView:")]
		int IndexOfItemView (UIView view);

		[Export ("indexOfItemViewOrSubview:")]
		int IndexOfItemViewOrSubview (UIView view);

		[Export ("offsetForItemAtIndex:")]
		float OffsetForItem (int index);

		[Export ("removeItemAtIndex:animated:")]
		void RemoveItem (int index, bool animated);

		[Export ("insertItemAtIndex:animated:")]
		void InsertItem (int index, bool animated);

		[Export ("reloadItemAtIndex:animated:")]
		void ReloadItem (int index, bool animated);

		[Export ("reloadData")]
		void ReloadData ();

		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface iCarouselDataSource {

		[Export ("numberOfItemsInCarousel:")] [Abstract]
		uint NumberOfItems (iCarousel carousel);

		[Export ("carousel:viewForItemAtIndex:reusingView:")] [Abstract]
		UIView ViewForItem (iCarousel carousel, uint index, UIView reusingView);

		[Export ("numberOfPlaceholdersInCarousel:")]
		uint NumberOfPlaceholders (iCarousel carousel);

		[Export ("carousel:placeholderViewAtIndex:reusingView:")]
		UIView PlaceholderViewAtIndex (iCarousel carousel, uint index, UIView reusingView);
	}

	[BaseType (typeof (NSObject))]
	[Model]
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
		bool ShouldSelectItem (iCarousel carousel, int index);

		[Export ("carousel:didSelectItemAtIndex:")]
		void DidSelectItem (iCarousel carousel, int index);

		[Export ("carouselItemWidth:")]
		float ItemWidth (iCarousel carousel);

		[Export ("carousel:itemTransformForOffset:baseTransform:")]
		CATransform3D ItemTransform (iCarousel carousel, float offset, CATransform3D baseTransform);

		[Export ("carousel:valueForOption:withDefault:")]
		float ValueForOption (iCarousel carousel, iCarouselOption option, float aValue);
	}
}

