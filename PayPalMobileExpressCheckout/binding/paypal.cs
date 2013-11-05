/*
 * paypal.cs: API definitions
 *
 * Author:
 *   Miguel de Icaza (miguel@xamarin.com)
 *
 * Copyright 2011 Xamarin, Inc.
 */

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace MonoTouch.PayPal {


	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface DeviceReferenceTokenDelegate {
		[Abstract]
		[Export ("receivedDeviceReferenceToken:")]
		void ReceivedDeviceReferenceToken (string token);

		[Abstract]
		[Export ("couldNotFetchDeviceReferenceToken")]
		void CouldNotFetchDeviceReferenceToken ();

	}

	[BaseType (typeof (NSObject))]
	interface PayPal {
		[Export ("lang")]
		string Language { get; set;  }

		[Export ("errorMessage")]
		string ErrorMessage { get; set;  }

		[Export ("payButtons")]
		UIButton[] PayButtons { get; set;  }

		[Export ("appID")]
		string AppID { get;  }

		[Export ("initialized")]
		bool Initialized { get;  }

		[Export ("paymentsEnabled")]
		bool PaymentsEnabled { get;  }

		[Export ("environment")]
		PayPalEnvironment Environment { get;  }

		[Static]
		[Export ("getPayPalInst")]
		PayPal GetPayPalInst ();

		[Export ("fetchDeviceReferenceTokenWithAppID:forEnvironment:withDelegate:")]
		void FetchDeviceReferenceToken (string inAppID, PayPalEnvironment env, DeviceReferenceTokenDelegate del);

		[Export ("fetchDeviceReferenceTokenWithAppID:withDelegate:")]
		void FetchDeviceReferenceToken (string inAppID, DeviceReferenceTokenDelegate del);

		[Export ("getPayButtonWithTarget:andAction:andButtonType:")]
		UIButton GetPayButton (DeviceReferenceTokenDelegate target, Selector action, PayPalButtonType inButtonType);

	}
}
