using System;

namespace UIImageViewAlignedSharp
{
	public enum UIImageViewAlignmentMask : uint {
		UIImageViewAlignmentMaskCenter = 0,
		UIImageViewAlignmentMaskLeft = 1,
		UIImageViewAlignmentMaskRight = 2,
		UIImageViewAlignmentMaskTop = 4,
		UIImageViewAlignmentMaskBottom = 8
//			,
//		UIImageViewAlignmentMaskBottomLeft = UIImageViewAlignmentMaskBottom | UIImageViewAlignmentMaskLeft,
//		UIImageViewAlignmentMaskBottomRight = UIImageViewAlignmentMaskBottom | UIImageViewAlignmentMaskRight,
//		UIImageViewAlignmentMaskTopLeft = UIImageViewAlignmentMaskTop | UIImageViewAlignmentMaskLeft,
//		UIImageViewAlignmentMaskTopRight = UIImageViewAlignmentMaskTop | UIImageViewAlignmentMaskRight
	}
}