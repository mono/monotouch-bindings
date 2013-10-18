using System;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MTiRate
{
	public delegate bool iRateDelegateShouldOpenAppStore ();

	public delegate bool iRateDelegateShouldPromptForRating ();

	partial class iRate
	{
		private iRate._iRateDelegate EnsureiRateDelegate ()
		{
			NSObject nSObject = this.WeakDelegate;
			if (nSObject == null || !(nSObject is iRate._iRateDelegate))
			{
				nSObject = new iRate._iRateDelegate ();
				this.WeakDelegate = nSObject;
			}
			return (iRate._iRateDelegate)nSObject;
		}

		public event EventHandler CouldNotConnectToAppStore
		{
			add
			{
				iRate._iRateDelegate expr_07 = this.EnsureiRateDelegate ();
//				expr_07.couldNotConnectToAppStore = (EventHandler)Delegate.Combine (expr_07.couldNotConnectToAppStore, value);
				expr_07.couldNotConnectToAppStore += value;
			}
			remove
			{
				iRate._iRateDelegate expr_07 = this.EnsureiRateDelegate ();
//				expr_07.couldNotConnectToAppStore = (EventHandler)Delegate.Remove (expr_07.couldNotConnectToAppStore, value);
				expr_07.couldNotConnectToAppStore -= value;
			}
		}

		public event EventHandler DidDetectAppUpdate
		{
			add
			{
				iRate._iRateDelegate expr_07 = this.EnsureiRateDelegate ();
//				expr_07.didDetectAppUpdate = (EventHandler)Delegate.Combine (expr_07.didDetectAppUpdate, value);
				expr_07.didDetectAppUpdate += value;
			}
			remove
			{
				iRate._iRateDelegate expr_07 = this.EnsureiRateDelegate ();
//				expr_07.didDetectAppUpdate = (EventHandler)Delegate.Remove (expr_07.didDetectAppUpdate, value);
				expr_07.didDetectAppUpdate -= value;
			}
		}

		public event EventHandler DidDismissStoreKitModal
		{
			add
			{
				iRate._iRateDelegate expr_07 = this.EnsureiRateDelegate ();
//				expr_07.didDismissStoreKitModal = (EventHandler)Delegate.Combine (expr_07.didDismissStoreKitModal, value);
				expr_07.didDismissStoreKitModal += value;
			}
			remove
			{
				iRate._iRateDelegate expr_07 = this.EnsureiRateDelegate ();
//				expr_07.didDismissStoreKitModal = (EventHandler)Delegate.Remove (expr_07.didDismissStoreKitModal, value);
				expr_07.didDismissStoreKitModal -= value;
			}
		}

		public event EventHandler DidPresentStoreKitModal
		{
			add
			{
				iRate._iRateDelegate expr_07 = this.EnsureiRateDelegate ();
//				expr_07.didPresentStoreKitModal = (EventHandler)Delegate.Combine (expr_07.didPresentStoreKitModal, value);
				expr_07.didPresentStoreKitModal += value;
			}
			remove
			{
				iRate._iRateDelegate expr_07 = this.EnsureiRateDelegate ();
//				expr_07.didPresentStoreKitModal = (EventHandler)Delegate.Remove (expr_07.didPresentStoreKitModal, value);
				expr_07.didPresentStoreKitModal -= expr_07.didPresentStoreKitModal;
			}
		}

		public event EventHandler DidPromptForRating
		{
			add
			{
				iRate._iRateDelegate expr_07 = this.EnsureiRateDelegate ();
//				expr_07.didPromptForRating = (EventHandler)Delegate.Combine (expr_07.didPromptForRating, value);
				expr_07.didPromptForRating += value;
			}
			remove
			{
				iRate._iRateDelegate expr_07 = this.EnsureiRateDelegate ();
//				expr_07.didPromptForRating = (EventHandler)Delegate.Remove (expr_07.didPromptForRating, value);
				expr_07.didPromptForRating -= expr_07.didPresentStoreKitModal;
			}
		}

		public event EventHandler UserDidAttemptToRateApp
		{
			add
			{
				iRate._iRateDelegate expr_07 = this.EnsureiRateDelegate ();
//				expr_07.userDidAttemptToRateApp = (EventHandler)Delegate.Combine (expr_07.userDidAttemptToRateApp, value);
				expr_07.userDidAttemptToRateApp += value;
			}
			remove
			{
				iRate._iRateDelegate expr_07 = this.EnsureiRateDelegate ();
//				expr_07.userDidAttemptToRateApp = (EventHandler)Delegate.Remove (expr_07.userDidAttemptToRateApp, value);
				expr_07.userDidAttemptToRateApp -= value;
			}
		}

		public event EventHandler UserDidDeclineToRateApp
		{
			add
			{
				iRate._iRateDelegate expr_07 = this.EnsureiRateDelegate ();
//				expr_07.userDidDeclineToRateApp = (EventHandler)Delegate.Combine (expr_07.userDidDeclineToRateApp, value);
				expr_07.userDidDeclineToRateApp += value;
			}
			remove
			{
				iRate._iRateDelegate expr_07 = this.EnsureiRateDelegate ();
//				expr_07.userDidDeclineToRateApp = (EventHandler)Delegate.Remove (expr_07.userDidDeclineToRateApp, value);
				expr_07.userDidDeclineToRateApp -= value;
			}
		}

		public event EventHandler UserDidRequestReminderToRateApp
		{
			add
			{
				iRate._iRateDelegate expr_07 = this.EnsureiRateDelegate ();
//				expr_07.userDidRequestReminderToRateApp = (EventHandler)Delegate.Combine (expr_07.userDidRequestReminderToRateApp, value);
				expr_07.userDidRequestReminderToRateApp += value;
			}
			remove
			{
				iRate._iRateDelegate expr_07 = this.EnsureiRateDelegate ();
//				expr_07.userDidRequestReminderToRateApp = (EventHandler)Delegate.Remove (expr_07.userDidRequestReminderToRateApp, value);
				expr_07.userDidRequestReminderToRateApp -= value;
			}
		}

		[Register]
		private sealed class _iRateDelegate : iRateDelegate
		{
			//
			// Fields
			//
			internal EventHandler couldNotConnectToAppStore;

			internal EventHandler didDismissStoreKitModal;

			internal EventHandler didPresentStoreKitModal;

			internal iRateDelegateShouldOpenAppStore shouldOpenAppStore;

			internal EventHandler userDidRequestReminderToRateApp;

			internal EventHandler userDidDeclineToRateApp;

			internal EventHandler userDidAttemptToRateApp;

			internal EventHandler didPromptForRating;

			internal iRateDelegateShouldPromptForRating shouldPromptForRating;

			internal EventHandler didDetectAppUpdate;

			//
			// Constructors
			//
			public _iRateDelegate ()
			{
				this.IsDirectBinding = false;
			}

			//
			// Methods
			//
			[Preserve (Conditional = true)]
			public override void CouldNotConnectToAppStore (NSError error)
			{
				EventHandler eventHandler = this.couldNotConnectToAppStore;
				if (eventHandler != null)
				{
					eventHandler.Invoke (error, EventArgs.Empty);
				}
			}

			[Preserve (Conditional = true)]
			public override void DidDetectAppUpdate ()
			{
				EventHandler eventHandler = this.didDetectAppUpdate;
				if (eventHandler != null)
				{
					eventHandler.Invoke (null, EventArgs.Empty);
				}
			}

			[Preserve (Conditional = true)]
			public override void DidDismissStoreKitModal ()
			{
				EventHandler eventHandler = this.didDismissStoreKitModal;
				if (eventHandler != null)
				{
					eventHandler.Invoke (null, EventArgs.Empty);
				}
			}

			[Preserve (Conditional = true)]
			public override void DidPresentStoreKitModal ()
			{
				EventHandler eventHandler = this.didPresentStoreKitModal;
				if (eventHandler != null)
				{
					eventHandler.Invoke (null, EventArgs.Empty);
				}
			}

			[Preserve (Conditional = true)]
			public override void DidPromptForRating ()
			{
				EventHandler eventHandler = this.didPromptForRating;
				if (eventHandler != null)
				{
					eventHandler.Invoke (null, EventArgs.Empty);
				}
			}

			[Preserve (Conditional = true)]
			public override bool ShouldOpenAppStore ()
			{
				iRateDelegateShouldOpenAppStore iRateDelegateShouldOpenAppStore = this.shouldOpenAppStore;
				return iRateDelegateShouldOpenAppStore == null || iRateDelegateShouldOpenAppStore ();
			}

			[Preserve (Conditional = true)]
			public override bool ShouldPromptForRating ()
			{
				iRateDelegateShouldPromptForRating iRateDelegateShouldPromptForRating = this.shouldPromptForRating;
				return iRateDelegateShouldPromptForRating == null || iRateDelegateShouldPromptForRating ();
			}

			[Preserve (Conditional = true)]
			public override void UserDidAttemptToRateApp ()
			{
				EventHandler eventHandler = this.userDidAttemptToRateApp;
				if (eventHandler != null)
				{
					eventHandler.Invoke (null, EventArgs.Empty);
				}
			}

			[Preserve (Conditional = true)]
			public override void UserDidDeclineToRateApp ()
			{
				EventHandler eventHandler = this.userDidDeclineToRateApp;
				if (eventHandler != null)
				{
					eventHandler.Invoke (null, EventArgs.Empty);
				}
			}

			[Preserve (Conditional = true)]
			public override void UserDidRequestReminderToRateApp ()
			{
				EventHandler eventHandler = this.userDidRequestReminderToRateApp;
				if (eventHandler != null)
				{
					eventHandler.Invoke (null, EventArgs.Empty);
				}
			}
		}

	}
}