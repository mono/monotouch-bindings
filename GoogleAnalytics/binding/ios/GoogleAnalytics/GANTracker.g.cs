//
// Auto-generated from generator.cs, do not edit
//
// We keep references to objects, so warning 414 is expected

#pragma warning disable 414

using System;

using System.Drawing;

using System.Runtime.InteropServices;

using MonoTouch;

using MonoTouch.CoreFoundation;

using MonoTouch.CoreMedia;

using MonoTouch.CoreMotion;

using MonoTouch.Foundation;

using MonoTouch.ObjCRuntime;

using MonoTouch.CoreAnimation;

using MonoTouch.CoreLocation;

using MonoTouch.MapKit;

using MonoTouch.UIKit;

using MonoTouch.CoreGraphics;

using MonoTouch.NewsstandKit;

using MonoTouch.GLKit;

using OpenTK;

namespace GoogleAnalytics {
	[Register("GANTracker", true)]
	public partial class GANTracker : NSObject {
		static IntPtr selSharedTracker = Selector.GetHandle ("sharedTracker");
		static IntPtr selDebug = Selector.GetHandle ("debug");
		static IntPtr selSetDebug = Selector.GetHandle ("setDebug:");
		static IntPtr selDryRun = Selector.GetHandle ("dryRun");
		static IntPtr selSetDryRun = Selector.GetHandle ("setDryRun:");
		static IntPtr selAnonymizeIp = Selector.GetHandle ("anonymizeIp");
		static IntPtr selSetAnonymizeIp = Selector.GetHandle ("setAnonymizeIp:");
		static IntPtr selSampleRate = Selector.GetHandle ("sampleRate");
		static IntPtr selSetSampleRate = Selector.GetHandle ("setSampleRate:");
		static IntPtr selStartTrackerWithAccountIDDispatchPeriodDelegate = Selector.GetHandle ("startTrackerWithAccountID:dispatchPeriod:delegate:");
		static IntPtr selStopTracker = Selector.GetHandle ("stopTracker");
		static IntPtr selTrackPageviewWithError = Selector.GetHandle ("trackPageview:withError:");
		static IntPtr selTrackEventActionLabelValueWithError = Selector.GetHandle ("trackEvent:action:label:value:withError:");
		static IntPtr selSetCustomVariableAtIndexNameValueScopeWithError = Selector.GetHandle ("setCustomVariableAtIndex:name:value:scope:withError");
		static IntPtr selSetCustomVariableAtIndexNameValueWithError = Selector.GetHandle ("setCustomVariableAtIndex:name:value:withError");
		static IntPtr selAddTransactionTotalPriceStoreNameTotalTaxShippingCostWithError = Selector.GetHandle ("addTransaction:totalPrice:storeName:totalTax:shippingCost:withError:");
		static IntPtr selAddItemItemSKUItemPriceItemCountItemNameItemCategoryWithError = Selector.GetHandle ("addItem:itemSKU:itemPrice:itemCount:itemName:itemCategory:withError:");
		static IntPtr selTrackTransactions = Selector.GetHandle ("trackTransactions:");
		static IntPtr selClearTransactions = Selector.GetHandle ("clearTransactions:");
		static IntPtr selSetReferrerWithError = Selector.GetHandle ("setReferrer:withError:");
		static IntPtr selDispatch = Selector.GetHandle ("dispatch");
		static IntPtr selDispatchSynchronous = Selector.GetHandle ("dispatchSynchronous");
		
		static IntPtr class_ptr = Class.GetHandle ("GANTracker");
		
		[Export ("init")]
		public  GANTracker () : base (NSObjectFlag.Empty)
		{
			Handle = MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.Init);
			
		}

		public GANTracker (NSObjectFlag t) : base (t) {}

		public GANTracker (IntPtr handle) : base (handle) {}

		[Export ("startTrackerWithAccountID:dispatchPeriod:delegate:")]
		public virtual void StartTracker (string accountiD, int dispatchPeriod, GANTrackerDelegate ganDelegate)
		{
			if (accountiD == null)
				throw new ArgumentNullException ("accountiD");
			var nsaccountiD = new NSString (accountiD);
			
			MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_IntPtr_int_IntPtr (this.Handle, selStartTrackerWithAccountIDDispatchPeriodDelegate, nsaccountiD.Handle, dispatchPeriod, ganDelegate == null ? IntPtr.Zero : ganDelegate.Handle);
			nsaccountiD.Dispose ();
			
		}
		
		[Export ("stopTracker")]
		public virtual void StopTracker ()
		{
			MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend (this.Handle, selStopTracker);
		}
		
		[Export ("trackPageview:withError:")]
		public virtual bool TrackPageView (string pageUrl, out NSError nsError)
		{
			if (pageUrl == null)
				throw new ArgumentNullException ("pageUrl");
			IntPtr nsErrorPtr = Marshal.AllocHGlobal(4);
			Marshal.WriteInt32(nsErrorPtr, 0);
			
			var nspageUrl = new NSString (pageUrl);
			
			bool ret;
			ret = MonoTouch.ObjCRuntime.Messaging.bool_objc_msgSend_IntPtr_IntPtr (this.Handle, selTrackPageviewWithError, nspageUrl.Handle, nsErrorPtr);
			nspageUrl.Dispose ();
			
			
			IntPtr nsErrorValue = Marshal.ReadIntPtr(nsErrorPtr);
			nsError = nsErrorValue != IntPtr.Zero ? (NSError)Runtime.GetNSObject(nsErrorValue) : null;
			Marshal.FreeHGlobal(nsErrorPtr);
			
			return ret;
		}
		
		[Export ("trackEvent:action:label:value:withError:")]
		public virtual bool TrackEvent (string category, string action, string label, int value, out NSError nsError)
		{
			if (category == null)
				throw new ArgumentNullException ("category");
			if (action == null)
				throw new ArgumentNullException ("action");
			if (label == null)
				throw new ArgumentNullException ("label");
			IntPtr nsErrorPtr = Marshal.AllocHGlobal(4);
			Marshal.WriteInt32(nsErrorPtr, 0);
			
			var nscategory = new NSString (category);
			var nsaction = new NSString (action);
			var nslabel = new NSString (label);
			
			bool ret;
			ret = MonoTouch.ObjCRuntime.Messaging.bool_objc_msgSend_IntPtr_IntPtr_IntPtr_int_IntPtr (this.Handle, selTrackEventActionLabelValueWithError, nscategory.Handle, nsaction.Handle, nslabel.Handle, value, nsErrorPtr);
			nscategory.Dispose ();
			nsaction.Dispose ();
			nslabel.Dispose ();
			
			
			IntPtr nsErrorValue = Marshal.ReadIntPtr(nsErrorPtr);
			nsError = nsErrorValue != IntPtr.Zero ? (NSError)Runtime.GetNSObject(nsErrorValue) : null;
			Marshal.FreeHGlobal(nsErrorPtr);
			
			return ret;
		}
		
		[Export ("setCustomVariableAtIndex:name:value:scope:withError")]
		public virtual bool SetCustomVariable (int index, string name, string value, GanCVScope scope, out NSError nsError)
		{
			if (name == null)
				throw new ArgumentNullException ("name");
			if (value == null)
				throw new ArgumentNullException ("value");
			IntPtr nsErrorPtr = Marshal.AllocHGlobal(4);
			Marshal.WriteInt32(nsErrorPtr, 0);
			
			var nsname = new NSString (name);
			var nsvalue = new NSString (value);
			
			bool ret;
			ret = googleanalytics.Messaging.bool_objc_msgSend_int_IntPtr_IntPtr_int_IntPtr (this.Handle, selSetCustomVariableAtIndexNameValueScopeWithError, index, nsname.Handle, nsvalue.Handle, (int)scope, nsErrorPtr);
			nsname.Dispose ();
			nsvalue.Dispose ();
			
			
			IntPtr nsErrorValue = Marshal.ReadIntPtr(nsErrorPtr);
			nsError = nsErrorValue != IntPtr.Zero ? (NSError)Runtime.GetNSObject(nsErrorValue) : null;
			Marshal.FreeHGlobal(nsErrorPtr);
			
			return ret;
		}
		
		[Export ("setCustomVariableAtIndex:name:value:withError")]
		public virtual bool SetCustomVariable (int index, string name, string value, out NSError nsError)
		{
			if (name == null)
				throw new ArgumentNullException ("name");
			if (value == null)
				throw new ArgumentNullException ("value");
			IntPtr nsErrorPtr = Marshal.AllocHGlobal(4);
			Marshal.WriteInt32(nsErrorPtr, 0);
			
			var nsname = new NSString (name);
			var nsvalue = new NSString (value);
			
			bool ret;
			ret = googleanalytics.Messaging.bool_objc_msgSend_int_IntPtr_IntPtr_IntPtr (this.Handle, selSetCustomVariableAtIndexNameValueWithError, index, nsname.Handle, nsvalue.Handle, nsErrorPtr);
			nsname.Dispose ();
			nsvalue.Dispose ();
			
			
			IntPtr nsErrorValue = Marshal.ReadIntPtr(nsErrorPtr);
			nsError = nsErrorValue != IntPtr.Zero ? (NSError)Runtime.GetNSObject(nsErrorValue) : null;
			Marshal.FreeHGlobal(nsErrorPtr);
			
			return ret;
		}
		
		[Export ("addTransaction:totalPrice:storeName:totalTax:shippingCost:withError:")]
		public virtual bool AddTransaction (string orderId, System.Double price, string storeName, System.Double totalTax, System.Double shippingCost, out NSError error)
		{
			if (orderId == null)
				throw new ArgumentNullException ("orderId");
			if (storeName == null)
				throw new ArgumentNullException ("storeName");
			IntPtr errorPtr = Marshal.AllocHGlobal(4);
			Marshal.WriteInt32(errorPtr, 0);
			
			var nsorderId = new NSString (orderId);
			var nsstoreName = new NSString (storeName);
			
			bool ret;
			ret = googleanalytics.Messaging.bool_objc_msgSend_IntPtr_Double_IntPtr_Double_Double_IntPtr (this.Handle, selAddTransactionTotalPriceStoreNameTotalTaxShippingCostWithError, nsorderId.Handle, price, nsstoreName.Handle, totalTax, shippingCost, errorPtr);
			nsorderId.Dispose ();
			nsstoreName.Dispose ();
			
			
			IntPtr errorValue = Marshal.ReadIntPtr(errorPtr);
			error = errorValue != IntPtr.Zero ? (NSError)Runtime.GetNSObject(errorValue) : null;
			Marshal.FreeHGlobal(errorPtr);
			
			return ret;
		}
		
		[Export ("addItem:itemSKU:itemPrice:itemCount:itemName:itemCategory:withError:")]
		public virtual void AddItem (string orderId, string itemSKU, System.Double itemPrice, System.Double itemCount, string itemName, string itemCategory, out NSError error)
		{
			if (orderId == null)
				throw new ArgumentNullException ("orderId");
			if (itemSKU == null)
				throw new ArgumentNullException ("itemSKU");
			if (itemName == null)
				throw new ArgumentNullException ("itemName");
			if (itemCategory == null)
				throw new ArgumentNullException ("itemCategory");
			IntPtr errorPtr = Marshal.AllocHGlobal(4);
			Marshal.WriteInt32(errorPtr, 0);
			
			var nsorderId = new NSString (orderId);
			var nsitemSKU = new NSString (itemSKU);
			var nsitemName = new NSString (itemName);
			var nsitemCategory = new NSString (itemCategory);
			
			googleanalytics.Messaging.void_objc_msgSend_IntPtr_IntPtr_Double_Double_IntPtr_IntPtr_IntPtr (this.Handle, selAddItemItemSKUItemPriceItemCountItemNameItemCategoryWithError, nsorderId.Handle, nsitemSKU.Handle, itemPrice, itemCount, nsitemName.Handle, nsitemCategory.Handle, errorPtr);
			nsorderId.Dispose ();
			nsitemSKU.Dispose ();
			nsitemName.Dispose ();
			nsitemCategory.Dispose ();
			
			
			IntPtr errorValue = Marshal.ReadIntPtr(errorPtr);
			error = errorValue != IntPtr.Zero ? (NSError)Runtime.GetNSObject(errorValue) : null;
			Marshal.FreeHGlobal(errorPtr);
			
		}
		
		[Export ("trackTransactions:")]
		public virtual bool TrackTransactions (out NSError error)
		{
			IntPtr errorPtr = Marshal.AllocHGlobal(4);
			Marshal.WriteInt32(errorPtr, 0);
			
			bool ret;
			ret = MonoTouch.ObjCRuntime.Messaging.bool_objc_msgSend_IntPtr (this.Handle, selTrackTransactions, errorPtr);
			
			IntPtr errorValue = Marshal.ReadIntPtr(errorPtr);
			error = errorValue != IntPtr.Zero ? (NSError)Runtime.GetNSObject(errorValue) : null;
			Marshal.FreeHGlobal(errorPtr);
			
			return ret;
		}
		
		[Export ("clearTransactions:")]
		public virtual bool ClearTransactions (out NSError error)
		{
			IntPtr errorPtr = Marshal.AllocHGlobal(4);
			Marshal.WriteInt32(errorPtr, 0);
			
			bool ret;
			ret = MonoTouch.ObjCRuntime.Messaging.bool_objc_msgSend_IntPtr (this.Handle, selClearTransactions, errorPtr);
			
			IntPtr errorValue = Marshal.ReadIntPtr(errorPtr);
			error = errorValue != IntPtr.Zero ? (NSError)Runtime.GetNSObject(errorValue) : null;
			Marshal.FreeHGlobal(errorPtr);
			
			return ret;
		}
		
		[Export ("setReferrer:withError:")]
		public virtual bool SetReferrer (string referrer, out NSError error)
		{
			if (referrer == null)
				throw new ArgumentNullException ("referrer");
			IntPtr errorPtr = Marshal.AllocHGlobal(4);
			Marshal.WriteInt32(errorPtr, 0);
			
			var nsreferrer = new NSString (referrer);
			
			bool ret;
			ret = MonoTouch.ObjCRuntime.Messaging.bool_objc_msgSend_IntPtr_IntPtr (this.Handle, selSetReferrerWithError, nsreferrer.Handle, errorPtr);
			nsreferrer.Dispose ();
			
			
			IntPtr errorValue = Marshal.ReadIntPtr(errorPtr);
			error = errorValue != IntPtr.Zero ? (NSError)Runtime.GetNSObject(errorValue) : null;
			Marshal.FreeHGlobal(errorPtr);
			
			return ret;
		}
		
		[Export ("dispatch")]
		public virtual bool Dispatch ()
		{
			return MonoTouch.ObjCRuntime.Messaging.bool_objc_msgSend (this.Handle, selDispatch);
		}
		
		[Export ("dispatchSynchronous")]
		public virtual bool dispatchSynchronous (System.Double timeout)
		{
			return MonoTouch.ObjCRuntime.Messaging.bool_objc_msgSend_Double (this.Handle, selDispatchSynchronous, timeout);
		}
		
		static object __mt_SharedTracker_var_static;
		public static GANTracker SharedTracker {
			[Export ("sharedTracker")]
			get {
				GANTracker ret;
				ret = (GANTracker) Runtime.GetNSObject (MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend (class_ptr, selSharedTracker));
				__mt_SharedTracker_var_static = ret;
				return ret;
			}
			
		}
		
		public virtual bool Debug {
			[Export ("debug")]
			get {
				return MonoTouch.ObjCRuntime.Messaging.bool_objc_msgSend (this.Handle, selDebug);
			}
			
			[Export ("setDebug:")]
			set {
				MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_bool (this.Handle, selSetDebug, value);
			}
		}
		
		public virtual bool DryRun {
			[Export ("dryRun")]
			get {
				return MonoTouch.ObjCRuntime.Messaging.bool_objc_msgSend (this.Handle, selDryRun);
			}
			
			[Export ("setDryRun:")]
			set {
				MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_bool (this.Handle, selSetDryRun, value);
			}
		}
		
		public virtual bool AnonymizeIp {
			[Export ("anonymizeIp")]
			get {
				return MonoTouch.ObjCRuntime.Messaging.bool_objc_msgSend (this.Handle, selAnonymizeIp);
			}
			
			[Export ("setAnonymizeIp:")]
			set {
				MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_bool (this.Handle, selSetAnonymizeIp, value);
			}
		}
		
		public virtual System.UInt32 SampleRate {
			[Export ("sampleRate")]
			get {
				return MonoTouch.ObjCRuntime.Messaging.UInt32_objc_msgSend (this.Handle, selSampleRate);
			}
			
			[Export ("setSampleRate:")]
			set {
				MonoTouch.ObjCRuntime.Messaging.void_objc_msgSend_UInt32 (this.Handle, selSetSampleRate, value);
			}
		}
		
	} /* class GANTracker */
}
