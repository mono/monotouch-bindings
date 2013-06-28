using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;

namespace SDWebImage
{
	delegate void SDImageCacheDoneHandler (UIImage image, SDImageCacheType cacheType);
	delegate void SDImageCacheCalculateHandler (uint fileCount, ulong totalSize);


	[BaseType (typeof (NSObject))]
	interface SDImageCache
	{
		[Export ("maxCacheAge", ArgumentSemantic.Assign)]
		int MaxCacheAge { get; set; }

		[Export ("maxCacheSize", ArgumentSemantic.Assign)]
		ulong MaxCacheSize { get; set; }

		[Static, Export ("sharedImageCache")]
		SDImageCache SharedImageCache { get; }

		[Export ("initWithNamespace:")]
		IntPtr Constructor (string aNamespace);

		[Export ("addReadOnlyCachePath:")]
		void AddReadOnlyCachePath (string path);

		[Export ("storeImage:forKey:")]
		void StoreImage (UIImage image, string key);

		[Export ("storeImage:forKey:toDisk:")]
		void StoreImage (UIImage image, string key, bool toDisk);

		[Export ("storeImage:imageData:forKey:toDisk:")]
		void StoreImage (UIImage image, NSData imageData, string key, bool toDisk);

		[Export ("queryDiskCacheForKey:done:")]
		void QueryDiskCache (string key, SDImageCacheDoneHandler doneHandler);

		[Export ("imageFromMemoryCacheForKey:")]
		UIImage ImageFromMemoryCache (string key);

		[Export ("imageFromDiskCacheForKey:")]
		UIImage ImageFromDiskCache (string key);

		[Export ("removeImageForKey:")]
		void RemoveImage (string key);

		[Export ("removeImageForKey:fromDisk:")]
		void RemoveImage (string key, bool fromDisk);

		[Export ("clearMemory")]
		void ClearMemory ();

		[Export ("clearDisk")]
		void ClearDisk ();

		[Export ("cleanDisk")]
		void CleanDisk ();

		[Export ("getSize")]
		ulong GetSize { get; }

		[Export ("getDiskCount")]
		int GetDiskCount { get; }

		[Export ("calculateSizeWithCompletionBlock:")]
		void CalculateSize (SDImageCacheCalculateHandler completionHandler);
	}

	delegate void SDWebImageDownloaderProgressHandler (uint receivedSize, long expectedSize);
	delegate void SDWebImageDownloaderCompleteHandler (UIImage image, NSData data, NSError error, bool finished);

	[BaseType (typeof (NSObject))]
	interface SDWebImageDownloader
	{
		[Notification]
		[Field ("SDWebImageDownloadStartNotification", "__Internal")]
		NSString DownloadStartNotification { get; }

		[Notification]
		[Field ("SDWebImageDownloadStopNotification", "__Internal")]
		NSString DownloadStopNotification { get; }

		[Export ("maxConcurrentDownloads", ArgumentSemantic.Assign)]
		int MaxConcurrentDownloads { get; set; }

		[Export ("executionOrder", ArgumentSemantic.Assign)]
		SDWebImageDownloaderExecutionOrder ExecutionOrder { get; set; }

		[Static, Export ("sharedDownloader")]
		SDWebImageDownloader SharedDownloader { get; }

		[Export ("setValue:forHTTPHeaderField:")]
		void SetValueforHTTPHeaderField ([NullAllowed] string value, string field);

		[Export ("valueForHTTPHeaderField:")]
		string ValueForHTTPHeaderField (string field);

		[Export ("downloadImageWithURL:options:progress:completed:")]
		SDWebImageOperation DownloadImage (NSUrl url, SDWebImageDownloaderOptions options, SDWebImageDownloaderProgressHandler progressHandler, SDWebImageDownloaderCompleteHandler completedHandler);
	}

	delegate void dispatch_queue_t ();
	delegate void SDWebImageDownloaderOperationCancelHandler ();

	[BaseType (typeof (NSOperation))]
	interface SDWebImageDownloaderOperation
	{
		[Export ("request")]
		NSUrlRequest request { get; }

		[Export ("options", ArgumentSemantic.Assign)]
		SDWebImageDownloaderOptions Options { get; }

		[Export ("initWithRequest:options:progress:completed:cancelled:")]
		IntPtr Constructor (NSUrlRequest request, SDWebImageDownloaderOptions options, [NullAllowed] SDWebImageDownloaderProgressHandler progressHandler, [NullAllowed] SDWebImageDownloaderCompleteHandler completedHandler, [NullAllowed] SDWebImageDownloaderOperationCancelHandler CancelHandler);
	}

	delegate void SDWebImageCompletedHandler (UIImage image, NSError error, SDImageCacheType cacheType);
	delegate void SDWebImageCompletedWithFinishedHandler (UIImage image, NSError error, SDImageCacheType cacheType, bool finished);
	delegate NSString SDWebImageManagerCacheKeyFilterHandler (NSUrl url);

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface SDWebImageManagerDelegate
	{
		[Export ("imageManager:shouldDownloadImageForURL:"), DelegateName ("SDWebImageManagerDelegateCondition"), DefaultValue (true)]
		bool ShouldDownloadImageForURL (SDWebImageManager imageManager, NSUrl imageUrl);

		[Export ("imageManager:transformDownloadedImage:withURL:"), DelegateName ("SDWebImageManagerDelegateImage"), DefaultValueFromArgument ("image")]
		UIImage TransformDownloadedImage (SDWebImageManager imageManager, UIImage image, NSUrl imageUrl);
	}

	[BaseType (typeof (NSObject),
	Delegates=new string [] {"WeakDelegate"}, 
	Events=new Type [] { typeof (SDWebImageManagerDelegate) })]
	interface SDWebImageManager
	{
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		[Wrap ("WeakDelegate")][NullAllowed]
		SDWebImageManagerDelegate Delegate { get; set; }

		[Export ("imageCache")]
		SDImageCache ImageCache { get; }

		[Export ("imageDownloader")]
		SDWebImageDownloader ImageDownloader { get; }

		[Export ("setCacheKeyFilter:")]
		void SetCacheKeyFilter (SDWebImageManagerCacheKeyFilterHandler handler);

		[Static, Export ("sharedManager")]
		SDWebImageManager SharedManager { get; }

		[Export ("downloadWithURL:options:progress:completed:")]
		SDWebImageOperation DownloadWithURL (NSUrl url, SDWebImageOptions options,[NullAllowed] SDWebImageDownloaderProgressHandler progressHandler,[NullAllowed] SDWebImageCompletedWithFinishedHandler completedHandler);

		[Export ("cancelAll")]
		void CancelAll ();

		[Export ("isRunning")]
		bool IsRunning { get; }
	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface SDWebImageOperation
	{
		[Export ("cancel")] [Abstract]
		void Cancel ();
	}

	delegate void SDWebImagePrefetcherCompletedHandler (uint finishedCount, uint skippedCount);

	[BaseType (typeof (NSObject))]
	interface SDWebImagePrefetcher
	{
		[Export ("maxConcurrentDownloads", ArgumentSemantic.Assign)]
		uint MaxConcurrentDownloads { get; set; }

		[Export ("options", ArgumentSemantic.Assign)]
		SDWebImageOptions Options { get; set; }

		[Static, Export ("sharedImagePrefetcher")]
		SDWebImagePrefetcher SharedImagePrefetcher { get; }

		[Export ("prefetchURLs:")]
		void prefetchURLs (NSUrl [] urls);

		[Export ("prefetchURLs:completed:")]
		void prefetchURLs (NSUrl [] urls, [NullAllowed] SDWebImagePrefetcherCompletedHandler completionHandler);

		[Export ("cancelPrefetching")]
		void CancelPrefetching ();
	}

	[BaseType (typeof (UIImage))]
	[Category]
	interface ForceDecodeUIImageExtension {
		[Static, Export ("decodedImageWithImage:")]
		UIImage DecodedImage (UIImage image);
	}

	[BaseType (typeof (UIButton))]
	[Category]
	interface WebCacheUIButtonExtension {

		[Export ("setImageWithURL:forState:")]
		void SetImage (NSUrl url, UIControlState state);

		[Export ("setImageWithURL:forState:placeholderImage:")]
		void SetImage (NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder);

		[Export ("setImageWithURL:forState:placeholderImage:options:")]
		void SetImage (NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, SDWebImageOptions options);

		[Export ("setImageWithURL:forState:completed:")]
		void SetImage (NSUrl url, UIControlState state, [NullAllowed] SDWebImageCompletedHandler completedHandler);

		[Export ("setImageWithURL:forState:placeholderImage:completed:")]
		void SetImage (NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, [NullAllowed] SDWebImageCompletedHandler completedHandler);

		[Export ("setImageWithURL:forState:placeholderImage:options:completed:")]
		void SetImage (NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDWebImageCompletedHandler completedHandler);

		[Export ("setBackgroundImageWithURL:forState:")]
		void SetBackgroundImage (NSUrl url, UIControlState state);

		[Export ("setBackgroundImageWithURL:forState:placeholderImage:")]
		void SetBackgroundImage (NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder);

		[Export ("setBackgroundImageWithURL:forState:placeholderImage:options:")]
		void SetBackgroundImage (NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, SDWebImageOptions options);

		[Export ("setBackgroundImageWithURL:forState:completed:")]
		void SetBackgroundImage (NSUrl url, UIControlState state, [NullAllowed] SDWebImageCompletedHandler completedHandler);

		[Export ("setBackgroundImageWithURL:forState:placeholderImage:completed:")]
		void SetBackgroundImage (NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, [NullAllowed] SDWebImageCompletedHandler completedHandler);
		
		[Export ("setBackgroundImageWithURL:forState:placeholderImage:options:completed:")]
		void SetBackgroundImage (NSUrl url, UIControlState state, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDWebImageCompletedHandler completedHandler);

		[Export ("cancelCurrentImageLoad")]
		void CancelCurrentImageLoad ();
	}

	[BaseType (typeof (UIImageView))]
	[Category]
	interface WebCacheUIImageViewExtension {
		
		[Export ("setImageWithURL:")]
		void SetImage (NSUrl url);
		
		[Export ("setImageWithURL:placeholderImage:")]
		void SetImage (NSUrl url, [NullAllowed] UIImage placeholder);
		
		[Export ("setImageWithURL:placeholderImage:options:")]
		void SetImage (NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options);
		
		[Export ("setImageWithURL:completed:")]
		void SetImage (NSUrl url, [NullAllowed] SDWebImageCompletedHandler completedHandler);
		
		[Export ("setImageWithURL:placeholderImage:completed:")]
		void SetImage (NSUrl url, [NullAllowed] UIImage placeholder, [NullAllowed] SDWebImageCompletedHandler completedHandler);
		
		[Export ("setImageWithURL:placeholderImage:options:completed:")]
		void SetImage (NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDWebImageCompletedHandler completedHandler);
		
		[Export ("setImageWithURL:placeholderImage:options:progress:completed:")]
		void SetImage (NSUrl url, [NullAllowed] UIImage placeholder, SDWebImageOptions options, [NullAllowed] SDWebImageDownloaderProgressHandler progress, [NullAllowed] SDWebImageCompletedHandler completedHandler);

		[Export ("cancelCurrentImageLoad")]
		void CancelCurrentImageLoad ();
	}
}

