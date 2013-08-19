using System;
using MonoTouch.UIKit;

namespace LineaTest
{
	public static class FlavorusColors
	{
		/// <summary>
		/// The trademark red Flavorus brand color, for branding, errors, etc.
		/// </summary>
		public static UIColor FlavorusRed { get { return _flavorusRed.Value; } }
		static Lazy<UIColor> _flavorusRed = new Lazy<UIColor>(() => UIColor.FromRGB(226,61,69));

		/// <summary>
		/// A darker shade of the FlavorusRed color.
		/// </summary>
		public static UIColor FlavorusRedDark { get { return _flavorusRedDark.Value; } }
		static Lazy<UIColor> _flavorusRedDark = new Lazy<UIColor>(() => UIColor.FromRGB(142,27,32));

		/// <summary>
		/// A green color used to indicate success.
		/// </summary>
		public static UIColor FlavorusGreen { get { return _flavorusGreen.Value; } }
		static Lazy<UIColor> _flavorusGreen = new Lazy<UIColor>(() => UIColor.FromRGB(43,174,52));

		/// <summary>
		/// A darker shade of the FlavorusGreen color.
		/// </summary>
		public static UIColor FlavorusGreenDark { get { return _flavorusGreenDark.Value; } }
		static Lazy<UIColor> _flavorusGreenDark = new Lazy<UIColor>(() => UIColor.FromRGB(35,108,59));

		/// <summary>
		/// A blue color used for the tab bar and section headings.
		/// </summary>
		public static UIColor FlavorusBlue { get { return _flavorusBlue.Value; } }
		static Lazy<UIColor> _flavorusBlue = new Lazy<UIColor>(() => UIColor.FromRGB(16,118,151));

		/// <summary>
		/// A darker shade of the FlavorusBlue color.
		/// </summary>
		public static UIColor FlavorusBlueDark { get { return _flavorusBlueDark.Value; } }
		static Lazy<UIColor> _flavorusBlueDark = new Lazy<UIColor>(() => UIColor.FromRGB(0,68,85));

		/// <summary>
		/// A yellow color used to indicate warnings.
		/// </summary>
		public static UIColor FlavorusYellow { get { return _flavorusYellow.Value; } }
		static Lazy<UIColor> _flavorusYellow = new Lazy<UIColor>(() => UIColor.FromRGB(255,206,3));

		/// <summary>
		/// The trademark Facebook blue color.
		/// </summary>
		public static UIColor FacebookBlue { get { return _facebookBlue.Value; } }
		static Lazy<UIColor> _facebookBlue = new Lazy<UIColor>(() => UIColor.FromRGB(105,128,169));

		/// <summary>
		/// A darker shade of the FacebookBlue color.
		/// </summary>
		public static UIColor FacebookBlueDark { get { return _facebookBlueDark.Value; } }
		static Lazy<UIColor> _facebookBlueDark = new Lazy<UIColor>(() => UIColor.FromRGB(53,79,126));

		/// <summary>
		/// The standard gray color used for labels.
		/// </summary>
		public static UIColor LabelGray { get { return _labelGray.Value; } }
		static Lazy<UIColor> _labelGray = new Lazy<UIColor>(() => UIColor.FromRGB(152,152,152));

		/// <summary>
		/// A lighter shade of the LabelGray color.
		/// </summary>
		public static UIColor LabelGrayLight { get { return _labelGrayLight.Value; } }
		static Lazy<UIColor> _labelGrayLight = new Lazy<UIColor>(() => UIColor.FromRGB(180,180,180));

		/// <summary>
		/// A darker shade of the LabelGray color.
		/// </summary>
		public static UIColor LabelGrayDark { get { return _labelGrayDark.Value; } }
		static Lazy<UIColor> _labelGrayDark = new Lazy<UIColor>(() => UIColor.FromRGB(51,51,51));

		/// <summary>
		/// A very light gray color used for section dividing-lines.
		/// </summary>
		public static UIColor LineLightGray { get { return _lineLightGray.Value; } }
		static Lazy<UIColor> _lineLightGray = new Lazy<UIColor>(() => UIColor.FromRGB(218,218,218));

		/// <summary>
		/// A gray color used for gray buttons.
		/// </summary>
		public static UIColor ButtonGray { get { return _buttonGray.Value; } }
		static Lazy<UIColor> _buttonGray = new Lazy<UIColor>(() => UIColor.FromRGB(152,152,152));

		/// <summary>
		/// A darker shade of the ButtonGray color.
		/// </summary>
		public static UIColor ButtonGrayDark { get { return _buttonGrayDark.Value; } }
		static Lazy<UIColor> _buttonGrayDark = new Lazy<UIColor>(() => UIColor.FromRGB(122,122,122));

		/// <summary>
		/// A light blue color used for date headings.
		/// </summary>
		public static UIColor DateLightBlue { get { return _dateLightBlue.Value; } }
		static Lazy<UIColor> _dateLightBlue = new Lazy<UIColor>(() => UIColor.FromRGB(162,223,232));

		/// <summary>
		/// A dark blue color used for date headings.
		/// </summary>
		public static UIColor DateDarkBlue { get { return _dateDarkBlue.Value; } }
		static Lazy<UIColor> _dateDarkBlue = new Lazy<UIColor>(() => UIColor.FromRGB(0,68,85));

		/// <summary>
		/// A light gray color used for accented section backgrounds.
		/// </summary>
		public static UIColor SectionLightGray { get { return _sectionLightGray.Value; } }
		static Lazy<UIColor> _sectionLightGray = new Lazy<UIColor>(() => UIColor.FromRGB(240,240,240));
	}
}

