using System;
using System.Drawing;

namespace GoogleAdMobAds
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
		MediationDataError,
		MediationAdapterError,
		MediationNoFill,
		MediationInvalidAdSize
	}
	
	public enum GADSearchBorderType 
	{	
		None,
		Dashed,
		Dotted,
		Solid
	}
	
	public struct GADAdSize
	{
		public SizeF size;
		public uint flags;
	}
}