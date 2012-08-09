using System;

namespace InMobi
{
	public enum AdErrorCode
	{
		/// <summary>
		/// The ad request is invalid. Typically, this is because the ad did not have the ad unit ID or rootViewController set.
		/// </summary>
		InvalidRequestError,
     
		/// <summary>
		/// An ad request is already in progress.
		/// </summary>
		RequestInProgressError,
    
		/// <summary>
		/// An ad click is in progress.
		/// </summary>
		ClickInProgressError,
    
		/// <summary>
		/// The ad request was successful, but no ad was returned.
		/// </summary>
		NoFillError,
    
		/// <summary>
		/// Network error!
		/// </summary>
		NetworkError,
    
		/// <summary>
		/// The ad server experienced a failure while processing the request.
		/// </summary>
		InternalError,
	}
	
	public enum InterstitialState
	{
		/// <summary>
		/// The default state of an interstitial. If an interstitial ad request fails, or if the user dismisses the interstitial, the state will be changed back to init.
		/// </summary>
		InterstitialAdStateInit,
		
		/// <summary>
		/// Indicates an interstitial ad request is in progress.
		/// </summary>
		AdStateLoading,
		
		/// <summary>
		/// Indicates an interstitial is ready to be displayed. An interstitial can be displayed only if the state is ready. You can call presentFromRootViewController: to display this ad.
		/// </summary>
		AdStateReady,
		
		/// <summary>
		/// Indicates an interstitial is displayed on the user's screen.
		/// </summary>
		AdStateActive
	};
	
	public enum Gender
	{
		None,
		Male,
		Female,
	}

	public enum Ethnicity
	{
		None,
		Mixed,
		Asian,
		Black,
		Hispanic,
		NativeAmerican,
		White,
		Other,
	}

	public enum Education
	{
		None, 
		HighSchool,
		SomeCollege,
		InCollege,
		BachelorsDegree,
		MastersDegree,
		DoctoralDegree,
		Other,
	}
	
	public enum Animation
	{	
		/// <summary>
		/// No animation in between of an ad refresh.
		/// </summary>
		Off,
		
		/// <summary>
		/// Ad refresh will perform a UIViewAnimationTransitionCurlUp.
		/// </summary>
		CurlUp ,
		
		/// <summary>
		/// Ad refresh will perform a UIViewAnimationTransitionCurlDown.
		/// </summary>
		CurlDown,
		
		/// <summary>
		/// Ad refresh will perform a UIViewAnimationTransitionFlipFromLeft.
		/// </summary>
		FlipFromLeft,
		
		/// <summary>
		/// Ad refresh will perform a UIViewAnimationTransitionFlipFromRight.
		/// </summary>
		FlipFromRight,
	}
	
	public enum LogLevel
	{
		/// <summary>
		/// The default minimal log level.
		/// </summary>
		Minimal = 1,
		
		/// <summary>
		/// The log level used for debugging purpose.
		/// </summary>
		Debug = 2,
		
		/// <summary>
		/// The log level used for critical debugging.
		/// </summary>
		Critical = 3,
	}
}