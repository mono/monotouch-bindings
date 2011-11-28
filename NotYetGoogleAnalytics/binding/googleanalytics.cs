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
	interface GANTracker {
		[Static][Export ("sharedTracker")]
		GANTracker SharedTracker { get; }

		[Export ("startTrackerWithAccountID:dispatchPeriod:delegate:")]
		void StartTracker (string accountiD, int dispatchPeriod, [NullAllowed] GANTrackerDelegate ganDelegate);

		[Export ("stopTracker")]
		void StopTracker ();

		[Export ("trackPageview:withError:")]
		bool TrackPageView (string pageUrl, out NSError nsError);

		[Export ("trackEvent:action:label:value:withError:")]
		bool TrackEvent (string category, string action, string label, int value, out NSError nsError);

		[Export ("setCustomVariableAtIndex:name:value:scope:withError")]
		bool SetCustomVariable (int index, string name, string value, GanCVScope scope, out NSError nsError);
		
		[Export ("setCustomVariableAtIndex:name:value:withError")]
		bool SetCustomVariable (int index, string name, string value, out NSError nsError);

		[Export ("addTransaction:totalPrice:storeName:totalTax:shippingCost:withError:")]
		bool AddTransaction (string orderId, double price, string storeName, double totalTax, double shippingCost, out NSError error);

		[Export ("addItem:itemSKU:itemPrice:itemCount:itemName:itemCategory:withError:")]
		void AddItem (string orderId, string itemSKU, double itemPrice, double itemCount, string itemName, string itemCategory, out NSError error);

		[Export ("trackTransactions:")]
		bool TrackTransactions (out NSError error);

		[Export ("clearTransactions:")]
		bool ClearTransactions (out NSError error);

		[Export ("setReferrer:withError:")]
		bool SetReferrer (string referrer, out NSError error);
	       
		[Export ("debug")]
		bool Debug { get; set; }

		[Export ("dryRun")]
		bool DryRun { get; set; }

		[Export ("anonymizeIp")]
		bool AnonymizeIp { get; set; }

		[Export ("sampleRate")]
		uint SampleRate { get; set; }
		
		[Export ("dispatch")]
		bool Dispatch ();

		[Export ("dispatchSynchronous")]
		bool dispatchSynchronous (double timeout);
	}

	[BaseType (typeof (NSObject))]
	interface GANTrackerDelegate {
		[Export ("trackerDispatchDidComplete:eventsDispatched:eventsFailedDispatch:")]
		void DispatchCompleted (GANTracker tracker, int eventsDispatched, int eventsFailedDispatch);
	}
}
