using System;

namespace SDWebImage
{
	public enum SDImageCacheType
	{
		None = 0,
		Disk,
		Memory
	}

	[Flags]
	public enum SDWebImageDownloaderOptions
	{
		LowPriority = 1,
		ProgressiveDownload = 2,
		UseNSUrlCache = 4,
		IgnoreCachedResponse = 8
	}

	public enum SDWebImageDownloaderQueueMode
	{
		FILO,
		LIFO
	}

	[Flags]
	public enum SDWebImageOptions
	{
		RetryFailed = 1,
		LowPriority = 2,
		CacheMemoryOnly = 4,
		ProgressiveDownload = 8,
		RefreshCached = 16
	}
}

