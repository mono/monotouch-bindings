
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface UARegistrationObserver {
		[Export ("registerDeviceTokenSucceeded")]
		void RegisterDeviceTokenSucceeded ();

		[Export ("registerDeviceTokenFailed:")]
		void RegisterDeviceTokenFailed (UA_ASIHTTPRequest request);

		[Export ("unRegisterDeviceTokenSucceeded")]
		void UnRegisterDeviceTokenSucceeded ();

		[Export ("unRegisterDeviceTokenFailed:")]
		void UnRegisterDeviceTokenFailed (UA_ASIHTTPRequest request);

		[Export ("addTagToDeviceSucceeded")]
		void AddTagToDeviceSucceeded ();

		[Export ("addTagToDeviceFailed:")]
		void AddTagToDeviceFailed (UA_ASIHTTPRequest request);

		[Export ("removeTagFromDeviceSucceeded")]
		void RemoveTagFromDeviceSucceeded ();

		[Export ("removeTagFromDeviceFailed:")]
		void RemoveTagFromDeviceFailed (UA_ASIHTTPRequest request);

	}

	[BaseType (typeof (UAObservable))]
	interface UAirship {
		[Export ("deviceToken")]
		string DeviceToken { get; set;  }

		[Export ("analytics")]
		UAAnalytics Analytics { get; set;  }

		[Export ("server")]
		string Server { get; set;  }

		[Export ("appId")]
		string AppId { get; set;  }

		[Export ("appSecret")]
		string AppSecret { get; set;  }

		[Export ("deviceTokenHasChanged")]
		bool DeviceTokenHasChanged { get; set;  }

		[Export ("ready")]
		bool Ready { get; set;  }

		[Static]
		[Export ("setLogging:")]
		void SetLogging (bool enabled);

		[Static]
		[Export ("takeOff:")]
		void TakeOff (NSDictionary options);

		[Static]
		[Export ("land")]
		void Land ();

		[Static]
		[Export ("shared")]
		UAirship Shared ();

		[Export ("registerDeviceToken:")]
		void RegisterDeviceToken (NSData token);

		[Export ("registerDeviceTokenWithExtraInfo:")]
		void RegisterDeviceToken (NSDictionary info);

		[Export ("registerDeviceToken:withAlias:")]
		void RegisterDeviceToken (NSData token, string alias);

		[Export ("registerDeviceToken:withExtraInfo:")]
		void RegisterDeviceToken (NSData token, NSDictionary info);

		[Export ("unRegisterDeviceToken")]
		void UnRegisterDeviceToken ();

	}
