using System;
using System.Runtime.InteropServices;

namespace Mobclix
{
	public enum Education 
	{
		EducationUnknown = 0,
		EducationHighSchool,
		EducationSomeCollege,
		EducationInCollege,
		EducationBachelorsDegree,
		EducationMastersDegree,
		EducationDoctoralDegree
	}

    public enum Ethnicity 
	{
		Unknown = 0,
		Mixed,
		Asian,
		Black,
		Hispanic,
		NativeAmerican,
		White
	}

    public enum Religion
	{
		Unknown = 0,
		Buddhism,
		Christianity,
		Hinduism,
		Islam,
		Judaism,
		Unaffiliated,
		Other
	}

    public enum Gender 
	{
		Unknown = 0,
		Male,
		Female,
		Both,
	}

    public enum MaritalStatus 
	{
		Unknown = 0,
		SingleAvailable,
		SingleUnavailable,
		Married,
	}

	public enum BrowserStyle 
	{
		/// <summary>
		/// Toolbar with back/forward/reload buttons, no navigation bar
		/// </summary>
		ToolbarStyle,
		/// <summary>
		/// No toolbar, Navigation bar with "Done" button + self.title (Default: Advertisement)
		/// </summary>
		NavigationStyle, 
		/// <summary>
		/// No toolbar, No Navigation bar, Single "X" in top left corner
		/// </summary>
		WidgetStyle,
		/// <summary>
		/// Contains toolbar and navigation bar. 
		/// </summary>
		FullStyle, 
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MCDemographics
	{
		public Education Education;
		public Ethnicity Ethnicity;
		public Religion Religion;
		public Gender Gender; // MCDemographicsGenderBoth is not valid for this field.
		public Gender DatingGender; // MCDemographicsGenderBoth is valid for this field.
		public MaritalStatus MaritalStatus;
		public uint Income;
		public uint AreaCode;
		public int DmaCode;
		public int MetroCode;
		public string City;
		public string Country;
		public string PostalCode;
		public string RegionCode;
		public double Latitude;
		public double Longitude;
	}

	public enum AdsError 
	{
		UnknownError = 0,
		ServerError	= -500,
		Unavailable	= -503,
		NotStarted	= -8888888,
		Disabled = -9999999
	}

	public enum SuballocationType 
	{
		Open	 	= -1006,
		IAd			= -275,
		AdMob		= -750,
		Google		= -10100,
		Millennial	= -1375
	}

	public enum FeedbackRating
	{
		Unknown = 0,
		Poor,
		Fair,
		Good,
		VeryGood,
		Excellent	
	}

	public struct FeedbackRatings
	{
		public FeedbackRating CategoryA;
		public FeedbackRating CategoryB;
		public FeedbackRating CategoryC;
		public FeedbackRating CategoryD;
		public FeedbackRating CategoryE;	
	}
}