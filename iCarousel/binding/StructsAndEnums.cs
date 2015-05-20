using System;

namespace iCarouselSDK
{
	public enum iCarouselType
	{
		Linear = 0,
		Rotary,
		InvertedRotary,
		Cylinder,
		InvertedCylinder,
		Wheel,
		InvertedWheel,
		CoverFlow,
		CoverFlow2,
		TimeMachine,
		InvertedTimeMachine,
		Custom
	}

	public enum iCarouselOption
	{
		Wrap = 0,
		ShowBackfaces,
		OffsetMultiplier,
		VisibleItems,
		Count,
		Arc,
		Angle,
		Radius,
		Tilt,
		Spacing,
		FadeMin,
		FadeMax,
		FadeRange
	}
}