using System;

namespace AlexTouch.GoogleAdMobAds
{
	//GADRequest file	
	public enum GADGender 
	{	
		Unknown,
	  	Male,
	  	Female
	}
	
	//GADRequestError file
	public enum GADErrorCode 
	{	
		InvalidRequest,
		NoFill,
	  	NetworkError,
		ServerError,
		OSVersionTooLow,
		Timeout,
		InterstitialAlreadyUsed,
		kGADMediationError
	}
}

