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
		[Export ("defaultTracker")]
		GAITracker DefaultTracker { get; set;  }
		
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
		
		[Export ("trackerWithTrackingId:")]
		GAITracker GetTracker (string trackingId);
		
		[Export ("dispatch")]
		void Dispatch ();
		
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface GAITracker {
		[Abstract]
		[Export ("trackingId")]
		string TrackingId { get;  }
		
		[Abstract]
		[Export ("appName")]
		string AppName { get; set;  }
		
		[Abstract]
		[Export ("appId")]
		string AppId { get; set;  }
		
		[Abstract]
		[Export ("appVersion")]
		string AppVersion { get; set;  }
		
		[Abstract]
		[Export ("anonymize")]
		bool Anonymize { get; set;  }
		
		[Abstract]
		[Export ("useHttps")]
		bool UseHttps { get; set;  }
		
		[Abstract]
		[Export ("sampleRate")]
		double SampleRate { get; set;  }
		
		[Abstract]
		[Export ("clientId")]
		string ClientId { get;  }
		
		[Abstract]
		[Export ("appScreen")]
		string AppScreen { get; set;  }
		
		[Abstract]
		[Export ("referrerUrl")]
		string ReferrerUrl { get; set;  }
		
		[Abstract]
		[Export ("campaignUrl")]
		string CampaignUrl { get; set;  }
		
		[Abstract]
		[Export ("sessionStart")]
		bool SessionStart { get; set;  }
		
		[Abstract]
		[Export ("sessionTimeout")]
		double SessionTimeout { get; set;  }
		
		[Abstract]
		[Export ("trackView")]
		bool TrackView ();
		
		[Abstract]
		[Export ("trackView:")]
		bool TrackView (string screen);
		
		[Abstract]
		[Export ("trackEventWithCategory:withAction:withLabel:withValue:")]
		bool TrackEvent(string category, string action, string label, NSNumber value);
		
		[Abstract]
		[Export ("trackTransaction:")]
		bool TrackTransaction (GAITransaction transaction);
		
		[Abstract]
		[Export ("trackException:withDescription:")]
		bool TrackException (bool isFatal, string format );
		
		[Abstract]
		[Export ("trackException:withNSException:")]
		bool TrackException (bool isFatal, NSException exception);
		
		[Abstract]
		[Export ("trackException:withNSError:")]
		bool TrackException (bool isFatal, NSError error);
		
		[Abstract]
		[Export ("trackTimingWithCategory:withValue:withName:withLabel:")]
		bool TrackTiming (string category, double time, string name, string label);
		
		[Abstract]
		[Export ("trackSocial:withAction:withTarget:")]
		bool TrackSocial (string network, string action, string target);
		
		[Abstract]
		[Export ("set:value:")]
		bool Setvalue (string parameterName, string value);
		
		[Abstract]
		[Export ("get:")]
		string Get (string parameterName);
		
		[Abstract]
		[Export ("send:params:")]
		bool Sendparams (string trackType, NSDictionary parameters);
		
		[Abstract]
		[Export ("setCustom:dimension:")]
		bool SetCustom (int index, string dimension);
		
		[Abstract]
		[Export ("setCustom:metric:")]
		bool SetCustom (int index, NSNumber metric);
		
		[Abstract]
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
		int RevenueMicros { get; set;  }
		
		[Export ("taxMicros")]
		int TaxMicros { get; set;  }
		
		[Export ("shippingMicros")]
		int ShippingMicros { get; set;  }
		
		[Export ("items")]
		GAITransactionItem[] Items { get;  }
		
		[Static]
		[Export ("transactionWithId:withAffiliation:")]
		GAITransaction TransactionFrom (string transactionId, string affiliation);
		
		[Export ("addItem:")]
		void AddItem (GAITransactionItem item);
		
		[Export ("addItemWithCode:name:category:priceMicros:quantity:")]
		void AddItem (string productCode, string productName, string productCategory, int priceMicros, int quantity);
		
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
		int PriceMicros { get; set;  }
		
		[Export ("quantity")]
		int Quantity { get; set;  }
		
		[Static]
		[Export ("itemWithCode:name:category:priceMicros:quantity:")]
		GAITransactionItem ItemFrom (string productCode, string productName, string productCategory, int priceMicros, int quantity);
		
	}
	
}
