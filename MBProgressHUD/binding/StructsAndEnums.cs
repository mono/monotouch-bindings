using System;

namespace MBProgressHUD
{
	public enum MBProgressHUDMode
	{
		Indeterminate,
		Determinate,
		AnnularDeterminate,
		CustomView,
		Text
	}

	public enum MBProgressHUDAnimation
	{
		MBProgressHUDAnimationFade,
		MBProgressHUDAnimationZoom,
		MBProgressHUDAnimationZoomOut = MBProgressHUDAnimationZoom,
		MBProgressHUDAnimationZoomIn
	}
}

