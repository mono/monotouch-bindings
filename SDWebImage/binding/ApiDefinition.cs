using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;

namespace SDWebImage
{
	delegate void SDImageCacheDoneHandler (UIImage image, SDImageCacheType cacheType);
	delegate void SDImageCompletionHandler (uint fileCount, ulong totalSize);
	
	[BaseType (typeof (NSObject))]
	interface SDImageCache
	{	
		[Export ("maxMemoryCost", ArgumentSemantic.Assign)]
		int MaxMemoryCost { get; set; }

		[Export ("maxCacheAge", ArgumentSemantic.Assign)]
		int MaxCacheAge { get; set; }

		[Export ("maxCacheSize", ArgumentSemantic.Assign)]
		uint MaxCacheSize { get; set; }
		
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

		[Export ("storeImage:recalculateFromImage:imageData:forKey:toDisk:")]
		void StoreImage (UIImage image, bool recalculate, NSData imageData, string key, bool toDisk);
		
		[Export ("queryDiskCacheForKey:done:")]
		NSOperation QueryDiskCache (string key, SDImageCacheDoneHandler doneHandler);
		
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

		[Export ("clearDiskOnCompletion:")]
		void ClearDisk (NSAction completionHandler);
		
		[Export ("cleanDisk")]
		void CleanDisk ();
		
		[Export ("getSize")]
		uint Size { get; }
		
		[Export ("getDiskCount")]
		int DiskCount { get; }

		[Export ("calculateSizeWithCompletionBlock:")]
		void CalculateSize (SDImageCompletionHandler completionHandler);

		[Export ("diskImageExistsWithKey:")]
		bool DiskImageExists (string key);
	}
	
	delegate void SDWebImageDownloaderProgressHandler (int receivedSize, int expectedSize);
	delegate void SDWebImageDownloaderCompleteHandler (UIImage image, NSData data, NSError error, bool finished);
	delegate NSDictionary HeadersFilterHandler (NSUrl url, NSDictionary headers);

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

		[Export ("currentDownloadCount", ArgumentSemantic.Assign)]
		int CurrentDownloadCount { get; }

		[Export ("downloadTimeout", ArgumentSemantic.Assign)]
		double DownloadTimeout { get; set; }
		
		[Export ("executionOrder", ArgumentSemantic.Assign)]
		SDWebImageDownloaderExecutionOrder ExecutionOrder { get; set; }
		
		[Static, Export ("sharedDownloader")]
		SDWebImageDownloader SharedDownloader { get; }

		[Export ("setHeadersFilter:")]
		void setHeadersFilter (HeadersFilterHandler handler);
		
		[Export ("setValue:forHTTPHeaderField:")]
		void SetValueforHTTPHeaderField ([NullAllowed] string value, string field);
		
		[Export ("valueForHTTPHeaderField:")]
		string ValueForHTTPHeaderField (string field);

		[Export ("downloadImageWithURL:options:progress:completed:")]
		ISDWebImageOperation DownloadImage (NSUrl url, SDWebImageDownloaderOptions options, SDWebImageDownloaderProgressHandler progressHandler, SDWebImageDownloaderCompleteHandler completedHandler);
	}

	delegate void SDWebImageDownloaderOperationCancelHandler ();
	
	[BaseType (typeof (NSOperation))]
	interface SDWebImageDownloaderOperation : ISDWebImageOperation
	{
		[Export ("request")]
		NSUrlRequest request { get; }
		
		[Export ("options", ArgumentSemantic.Assign)]
		SDWebImageDownloaderOptions Options { get; }
		
		[Export ("initWithRequest:options:progress:completed:cancelled:")]
		IntPtr Constructor (NSUrlRequest request, SDWebImageDownloaderOptions options, SDWebImageDownloaderProgressHandler progressHandler, SDWebImageDownloaderCompleteHandler completedHandler, SDWebImageDownloaderOperationCancelHandler CancelHandler);
	}
	
	delegate void SDWebImageCompletedHandler (UIImage image, NSError error, SDImageCacheType cacheType);
	delegate void SDWebImageCompletedWithFinishedHandler (UIImage image, NSError error, SDImageCacheType cacheType, bool finished);
	delegate NSString SDWebImageManagerCacheKeyFilterHandler (NSUrl url);

	interface ISDWebImageManagerDelegate { }

	[BaseType (typeof (NSObject))]
	[Protocol]
	[Model]
	interface SDWebImageManagerDelegate
	{
		[Export ("imageManager:shouldDownloadImageForURL:"), DelegateName ("SDWebImageManagerDelegateCondition"), DefaultValue (true)]
		bool ShouldDownloadImageForURL (SDWebImageManager imageManager, NSUrl imageUrl);
		
		[Export ("imageManager:transformDownloadedImage:withURL:"), DelegateName ("SDWebImageManagerDelegateImage"), DefaultValueFromArgument ("image")]
		UIImage TransformDownloadedImage (SDWebImageManager imageManager, UIImage image, NSUrl imageUrl);
	}
	
	[BaseType (typeof (NSObject),
		Delegates=new string [] {"Delegate"}, 
		Events=new Type [] { typeof (SDWebImageManagerDelegate) })]
	interface SDWebImageManager
	{
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		ISDWebImageManagerDelegate Delegate { get; set; }
		
		[Export ("imageCache")]
		SDImageCache ImageCache { get; }
		
		[Export ("imageDownloader")]
		SDWebImageDownloader ImageDownloader { get; }
		
		[Export ("setCacheKeyFilter:")]
		void SetCacheKeyFilter (SDWebImageManagerCacheKeyFilterHandler handler);
		
		[Static, Export ("sharedManager")]
		SDWebImageManager SharedManager { get; }

		[Export ("downloadWithURL:options:progress:completed:")]
		ISDWebImageOperation Download (NSUrl url, SDWebImageOptions options, SDWebImageDownloaderProgressHandler progressHandler, SDWebImageCompletedWithFinishedHandler completedHandler);

		[Export ("cancelAll")]
		void CancelAll ();
		
		[Export ("isRunning")]
		bool IsRunning { get; }

		[Export ("diskImageExistsForURL:")]
		bool DiskImageExists (NSUrl url);
	}

	interface ISDWebImageOperation { }

	[BaseType (typeof (NSObject))]
	[Protocol]
	interface SDWebImageOperation
	{
		[Bind ("cancel")]
		void Cancel ();
	}

	interface ISDWebImagePrefetcherDelegate { }

	[BaseType (typeof (NSObject))]
	[Protocol]
	[Model]
	interface SDWebImagePrefetcherDelegate
	{
		[Export ("imagePrefetcher:didPrefetchURL:finishedCount:totalCount:"), EventArgs ("SDWebImagePrefetcherDelegatePrefech")]
		void DidPrefetchUrl (SDWebImagePrefetcher imagePrefetcher, NSUrl imageUrl, uint finishedCount, uint totalCount);

		[Export ("imagePrefetcher:didFinishWithTotalCount:skippedCount:"), EventArgs ("SDWebImagePrefetcherDelegateFinish")]
		void DidFinish (SDWebImageManager imageManager, UIImage image, NSUrl imageUrl);
	}
	
	delegate void SDWebImagePrefetcherCompletedHandler (uint finishedCount, uint skippedCount);
	
	[BaseType (typeof (NSObject),
		Delegates=new string [] {"Delegate"}, 
		Events=new Type [] { typeof (SDWebImagePrefetcherDelegate) })]
	interface SDWebImagePrefetcher
	{
		[Export ("maxConcurrentDownloads", ArgumentSemantic.Assign)]
		uint MaxConcurrentDownloads { get; set; }
		
		[Export ("options", ArgumentSemantic.Assign)]
		SDWebImageOptions Options { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		ISDWebImagePrefetcherDelegate Delegate { get; set; }
		
		[Static, Export ("sharedImagePrefetcher")]
		SDWebImagePrefetcher SharedImagePrefetcher { get; }
		
		[Export ("prefetchURLs:")]
		void prefetchUrls (NSUrl [] urls);
		
		[Export ("prefetchURLs:completed:")]
		void prefetchURLs (NSUrl [] urls, SDWebImagePrefetcherCompletedHandler completionHandler);
		
		[Export ("cancelPrefetching")]
		void CancelPrefetching ();
	}
	
	[BaseType (typeof (UIImage))]
	[Category]
	interface ForceDecodeUIImageExtension {
		[Static, Export ("decodedImageWithImage:")]
		UIImage DecodedImageWithImage (UIImage image);
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

		[Export ("setAnimationImagesWithURLs:")]
		void SetAnimationImages (NSUrl [] urls);

		[Export ("cancelCurrentImageLoad")]
		void CancelCurrentImageLoad ();

		[Export ("cancelCurrentArrayLoad")]
		void CancelCurrentArrayLoad ();
	}
}