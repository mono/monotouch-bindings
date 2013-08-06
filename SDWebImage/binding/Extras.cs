using System;
using MonoTouch.Foundation;

namespace SDWebImage
{
	public partial class SDWebImageDownloader
	{
		public SDWebImageOperation DownloadImageWithURL (NSUrl url, SDWebImageDownloaderOptions options, SDWebImageDownloaderProgressHandler progressHandler, SDWebImageDownloaderCompleteHandler completedHandler)
		{
			return new SDWebImageOperation (DownloadImageWithURL_ (url, options, progressHandler, completedHandler));
		}
	}

	public partial class SDWebImageManager
	{
		public SDWebImageOperation DownloadImageWithURL (NSUrl url, SDWebImageOptions options, SDWebImageDownloaderProgressHandler progressHandler, SDWebImageCompletedWithFinishedHandler completedHandler)
		{
			return new SDWebImageOperation (DownloadWithURL_ (url, options, progressHandler, completedHandler));
		}
	}
}