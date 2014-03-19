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
		LowPriority = 1 << 0,
		ProgressiveDownload = 1 << 1,
		UseNSUrlCache = 1 << 2,
		IgnoreCachedResponse = 1 << 3,
		ContinueInBackground = 1 << 4,
		HandleCookies = 1 << 5,
		AllowInvalidSSLCertificates = 1 << 6
	}
	
	public enum SDWebImageDownloaderExecutionOrder
	{
		FirstInFirstOut,
		LastInFirstOut
	}
	
	[Flags]
	public enum SDWebImageOptions
	{
		RetryFailed = 1 << 0,
		LowPriority = 1 << 1,
		CacheMemoryOnly = 1 << 2,
		ProgressiveDownload = 1 << 3,
		RefreshCached = 1 << 4,
		ContinueInBackground = 1 << 5,
		HandleCookies = 1 << 6,
		AllowInvalidSSLCertificates = 1 << 7
	}
}