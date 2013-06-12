//
// Binding to the GANTracker.h Google Analytics iPhone SDK from Google
//
// MIT X11 licensed
//
// Copyright 2009 Novell, Inc.
// Copyright 2011 Xamarin Inc
//
using System;
using MonoTouch.Foundation;

namespace GoogleAnalytics {

	[BaseType (typeof (NSObject))]
	interface GAI {
		[Internal]
		[Export ("defaultTracker")]
		IntPtr InternalDefaultTracker { get; set;  }
		
		[Export ("debug")]
		bool Debug { get; set;  }
		
		[Export ("optOut")]
		bool OptOut { get; set;  }
		
		[Export ("dispatchInterval")]
		double DispatchInterval { get; set;  }
		
		[Export ("trackUncaughtExceptions")]
		bool TrackUncaughtExceptions { get; set;  }
		
		[Static]
		[Export ("sharedInstance")]
		GAI SharedInstance { get; }
		
		[Internal]
		[Export ("trackerWithTrackingId:")]
		IntPtr InternalGetTracker (string trackingId);
		
		[Export ("dispatch")]
		void Dispatch ();
		
	}

	[BaseType (typeof (NSObject))]
	interface GAITracker {
		[Export ("trackingId")]
		string TrackingId { get;  }

		[Export ("appName")]
		string AppName { get; set;  }
		
		[Export ("appId")]
		string AppId { get; set;  }
		
		[Export ("appVersion")]
		string AppVersion { get; set;  }
		
		[Export ("anonymize")]
		bool Anonymize { get; set;  }

		[Export ("useHttps")]
		bool UseHttps { get; set;  }
		
		[Export ("sampleRate")]
		double SampleRate { get; set;  }
		
		[Export ("clientId")]
		string ClientId { get;  }
		
		[Export ("appScreen")]
		string AppScreen { get; set;  }
		
		[Export ("referrerUrl")]
		string ReferrerUrl { get; set;  }
		
		[Export ("campaignUrl")]
		string CampaignUrl { get; set;  }
		
		[Export ("sessionStart")]
		bool SessionStart { get; set;  }
		
		[Export ("sessionTimeout")]
		double SessionTimeout { get; set;  }
		
		[Export ("trackView")]
		bool TrackView ();
		
		[Export ("trackView:")]
		bool TrackView (string screen);
		
		[Export ("trackEventWithCategory:withAction:withLabel:withValue:")]
		bool TrackEvent(string category, string action, string label, NSNumber value);
		
		[Export ("trackTransaction:")]
		bool TrackTransaction (GAITransaction transaction);
		
		[Export ("trackException:withDescription:")]
		bool TrackException (bool isFatal, string format );
		
		[Export ("trackException:withNSException:")]
		bool TrackException (bool isFatal, NSException exception);
		
		[Export ("trackException:withNSError:")]
		bool TrackException (bool isFatal, NSError error);
		
		[Export ("trackTimingWithCategory:withValue:withName:withLabel:")]
		bool TrackTiming (string category, double time, string name, string label);
		
		[Export ("trackSocial:withAction:withTarget:")]
		bool TrackSocial (string network, string action, string target);
		
		[Export ("set:value:")]
		bool Setvalue (string parameterName, string value);
		
		[Export ("get:")]
		string Get (string parameterName);
		
		[Export ("send:params:")]
		bool Sendparams (string trackType, NSDictionary parameters);
		
		[Export ("setCustom:dimension:")]
		bool SetCustom (int index, string dimension);
		
		[Export ("setCustom:metric:")]
		bool SetCustom (int index, NSNumber metric);
		
		[Export ("close")]
		void Close ();
		
	}
	[BaseType (typeof (NSObject))]
	interface GAITransaction {
		[Export ("transactionId")]
		string TransactionId { get;  }
		
		[Export ("affiliation")]
		string Affiliation { get;  }
		
		[Export ("revenueMicros")]
		long RevenueMicros { get; set;  }
		
		[Export ("taxMicros")]
		long TaxMicros { get; set;  }
		
		[Export ("shippingMicros")]
		long ShippingMicros { get; set;  }
		
		[Export ("items")]
		GAITransactionItem[] Items { get;  }
		
		[Static]
		[Export ("transactionWithId:withAffiliation:")]
		GAITransaction TransactionFrom (string transactionId, string affiliation);
		
		[Export ("addItem:")]
		void AddItem (GAITransactionItem item);
		
		[Export ("addItemWithCode:name:category:priceMicros:quantity:")]
		void AddItem (string productCode, string productName, string productCategory, long priceMicros, int quantity);
		
	}
	[BaseType (typeof (NSObject))]
	interface GAITransactionItem {
		[Export ("productCode")]
		string ProductCode { get;  }
		
		[Export ("productName")]
		string ProductName { get; set;  }
		
		[Export ("productCategory")]
		string ProductCategory { get; set;  }
		
		[Export ("priceMicros")]
		long PriceMicros { get; set;  }
		
		[Export ("quantity")]
		int Quantity { get; set;  }
		
		[Static]
		[Export ("itemWithCode:name:category:priceMicros:quantity:")]
		GAITransactionItem ItemFrom (string productCode, string productName, string productCategory, long priceMicros, int quantity);
		
	}
	
}
