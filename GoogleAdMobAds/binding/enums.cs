using System;
using MonoTouch.Foundation;

namespace GoogleAdMobAds
{
	//GADRequest file	
	public enum GADGender 
	{	
		kGADGenderUnknown,
	  	kGADGenderMale,
	  	kGADGenderFemale
	}
	
	//GADRequestError file
	public enum GADErrorCode 
	{	
		kGADErrorInvalidRequest,
		kGADErrorNoFill,
	  	kGADErrorNetworkError,
		kGADErrorServerError,
		kGADErrorOSVersionTooLow,
		kGADErrorTimeout
	}
}
