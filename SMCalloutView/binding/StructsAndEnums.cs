using System;

namespace SMCalloutView
{
	public enum CalloutArrowDirection : ulong
	{
		Up = 1UL << 0,
		Down = 1UL << 1,
		Any = Up | Down
	}

	public enum CalloutAnimation
	{
		Bounce, // the "bounce" animation we all know and love from UIAlertView
		Fade, // a simple fade in or out
		Stretch // grow or shrink linearly, like in the iPad Calendar app
	}
}