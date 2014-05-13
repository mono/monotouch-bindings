﻿using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace LookbackSDK
{
	[BaseType (typeof(NSObject), Name="Lookback")]
	public interface Lookback
	{
		[Static]
		[Export ("setApplicationId:clientKey:")]
		void SetAppId (string applicationId, string clientKey);

		[Static]
		[Export ("offlineMessagesEnabled:")]
		void OfflineMessagesEnabled (bool enabled);

		[Static]
		[Export ("errorMessagesEnabled:")]
		void ErrorMessagesEnabled (bool enabled);

		[Static]
		[Export ("getApplicationId")]
		string ApplicationId{ get; }

		[Static]
		[Export ("getClientKey")]
		string ClientKey{ get; }


		/// <summary>
		/// In your ApplicationDidFinishLaunching or similar, call this method to prepare Lookback for use, using the App Token from your integration guide at lookback.io.
		/// </summary>
		/// <param name="appToken">A string identifying your app, received from your app settings at http://lookback.io</param>
		[Static]
		[Export ("setupWithAppToken:")]
		void SetupWithAppToken (string appToken);

		/// <summary>
		/// Shared instance of Lookback to use from your code. You must call SetupWithAppToken before calling this method.
		/// </summary>
		/// <value>Shared instance of Lookback</value>
		[Static] 
		[Export ("lookback")]
		Lookback lookback { get; set; }

		/// <summary>
		/// Whether Lookback is set to recording. You can either set this programmatically, or use LookbackSettingsViewController to let the user activate it.
		/// </summary>
		/// <value>Whether or not lookback is enabled.</value>
		[Export ("enabled")]
		bool Enabled { get; set; }

		/// <summary>
		/// If enabled, displays UI to start recording when you shake the device. Default NO. This is just a convenience method. It's roughly equivalent to implementing
		/// -[motionEnded:withEvent:] in your first responder, and modally displaying a
		/// LookbackSettingsViewController on the window's root view controller.
		/// </summary>
		/// <value>Whether or not shake to record is enabled.</value>
		[Export ("shakeToRecord")]
		bool ShakeToRecord { get; set; }

		/// <summary>
		/// Is Lookback paused? Lookback will pause automatically when app is inactive. The value of this property is undefined if recording is not enabled (as there is nothing to pause).
		/// </summary>
		/// <value>Whether or not lookback is paused.</value>
		[Export ("isPaused")]
		bool Paused { get; }

		/// <summary>
		/// Identifier for the user who's currently using the app. You can filter on this property at lookback.io later. If your service has log in user names, you can use that here. Optional. http://lookback.io/docs/log-username
		/// </summary>
		/// <value>The lookback user identifier.</value>
		[Export ("userIdentifier", ArgumentSemantic.Copy)]
		string UserIdentifier { get; set; }

		/// <summary>
		/// Track user navigation manually, if automatic tracking has been disabled. @see LookbackAutomaticallyLogViewAppearance
		/// </summary>
		/// <param name="viewIdentifier">Unique human readable identifier for a specific view</param>
		[Export ("enteredView:")]
		void EnteredView (string viewIdentifier);

		/// <summary>
		/// Track user navigation manually, if automatic tracking has been disabled. @see LookbackAutomaticallyLogViewAppearance
		/// </summary>
		/// <param name="viewIdentifier">Unique human readable identifier for a specific view</param>
		[Export ("exitedView:")]
		void ExitedView (string viewIdentifier);

		/// <summary>
		/// For debugging
		/// </summary>
		/// <value>The lookback application token.</value>
		[Export ("appToken")]
		string AppToken { get; }
	}

	[BaseType (typeof (UIView))]
	[Category]
	interface LookbackConcealing {
		[Static]
		[Export ("lookback_shouldBeConcealedInRecordings")]
		bool  LookbackShouldBeConcealedInRecordings { get; set; }
	}


//	[BaseType (typeof(UITableViewController), Name="LookbackSettingsViewController", Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof(LookbackSettingsViewController)})]
//	interface LookbackSettingsViewController
//	{
//		[Export ("delegate"), NullAllowed]
//		NSObject WeakDelegate { get; set; }
//
//		[Wrap ("WeakDelegate")]
//		LookbackSettingsViewController Delegate { get; set; }
//
//		[Export ("showsRecordButton")]
//		bool ShowsRecordButton { get; set; }
//	}

}

