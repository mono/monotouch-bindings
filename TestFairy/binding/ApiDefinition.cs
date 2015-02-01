using System;
using System.Drawing;
using ObjCRuntime;
using Foundation;
using UIKit;

namespace TestFairyLib
{
	[BaseType (typeof(NSObject))]
	interface TestFairy {

		/// <summary>
		/// Initialize a TestFairy session.
		/// </summary>
		/// <param name="APIKey"></param>
		[Static, Export("begin:")]
		void Begin(string APIKey);

		/// <summary>
		/// Hide a specific view from appearing in the video generated.
		/// </summary>
		/// <param name="view"></param>
		[Static, Export("hideView:")]
		void HideView(UIView view);

		/// <summary>
		/// Push the feedback view controller. Hook a button to this method
		/// to allow users to provide feedback about the current session. All
		/// feedback will appear in your build report page, and in the
		/// recorded session page.
		/// </summary>
		[Static, Export("pushFeedbackController")]
		void PushFeedbackController();

		/// <summary>
		/// Proxy didUpdateLocations delegate values and these locations will
		/// appear over a map in the recorded session. Useful for debugging actual
		/// long/lat values against what the user sees on screen.
		/// </summary>
		/// <param name="locations">Array of CLLocation as passed by didUpdateLocations</param>
		[Static, Export("updateLocation:")]
		void UpdateLocation(NSObject[] locations);

		/// <summary>
		/// Mark a checkpoint in session. Use this text to tag a session
		/// with a checkpoint name. Later you can filter sessions where your
		/// user passed through this checkpoint, for bettering understanding
		/// user experience and behavior.
		/// </summary>
		/// <param name="name">Name of checkpoint, make it short.</param>
		[Static, Export("checkpoint:")]
		void Checkpoint(string name);

		/// <summary>
		/// Sets a correlation identifier for this session. This value can
		/// be looked up via web dashboard. For example, setting correlation
		/// to the value of the user-id after they logged in. Can be called
		/// only once per session (subsequent calls will be ignored.)
		/// </summary>
		/// <param name="correlationId">Correlation value</param>
		[Static, Export("setCorrelationId:")]
		void SetCorrelationId(string correlationId);

		/// <summary>
		/// Pauses the current session. This method stops recoding of 
		/// the current session until Resume() has been called.
		/// </summary>
		[Static, Export("pause")]
		void Pause();

		/// <summary>
		/// Resumes the recording of the current session. This method
		/// resumes a session after it was paused.
		/// </summary>
		[Static, Export("resume")]
		void Resume();

		/// <summary>
		/// Returns the url of the current session while its being recorded.
		/// Will return null if session hasn't started yet.
		/// </summary>
		/// <returns>The session URL.</returns>
		[Static, Export("sessionUrl")]
		string GetSessionUrl();
	}
}

