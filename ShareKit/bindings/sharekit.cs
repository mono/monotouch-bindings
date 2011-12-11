//
// sharekit.cs: definition for the ShareKit API
//
// Authors:
//   Miguel de Icaza
//
// Copyright 2011 Xamarin, Inc.
//
// Licensed under the terms of the Apache 2 License
//
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;
using System;

namespace MonoTouch.ShareKit {
	
	[BaseType (typeof (NSObject))]
	interface ShkItem {
		[Export ("URL")]
		NSUrl Url { get; set;  }

		[Export ("image")]
		UIImage Image { get; set;  }

		[Export ("title")]
		string Title { get; set;  }

		//[Export ("text")]
		//string Text { get; set;  }

		[Export ("tags")]
		string Tags { get; set;  }

		[Export ("data")]
		NSData Data { get; set;  }

		[Export ("mimeType")]
		string MimeType { get; set;  }

		[Export ("filename")]
		string Filename { get; set;  }

		[Export ("shareType")]
		ShkShareType ShareType { get; set; }

		[Static]
		[Export ("URL:title:")]
		ShkItem CreateUrlItem (NSUrl url, string title);

		[Static]
		[Export ("image:title:")]
		ShkItem CreateImageItem (UIImage image, string title);

		[Static]
		[Export ("text:")]
		ShkItem CreateTextItem (string text);

		[Static]
		[Export ("file:filename:mimeType:title:")]
		ShkItem CreateFileItem (NSData data, string filename, string mimeType, string title);

		[Export ("setCustomValue:forKey:")]
		void SetCustomValue (string value, string key);

		[Export ("customValueForKey:")]
		string GetCustomValueForKey (string key);

		[Export ("customBoolForSwitchKey:")]
		bool GetCustomBoolForSwitchKey (string key);

		[Export ("dictionaryRepresentation")]
		NSDictionary AsDictionary { get; }

		[Static]
		[Export ("itemFromDictionary:")]
		ShkItem FromDictionary (NSDictionary dictionary);
	}

	[BaseType (typeof (UIActionSheet))]
	interface ShkActionSheet {
		[Export ("item")]
		ShkItem Item { get; set;  }

		[Static]
		[Export ("actionSheetForType:")]
		ShkActionSheet FromType (ShkShareType type);

		[Static]
		[Export ("actionSheetForItem:")]
		ShkActionSheet FromItem (ShkItem iitem);
	}


	[BaseType (typeof (NSObject))]
	interface ShkRequest {
		[Export ("params")]
		string Params { get; set;  }

		[Export ("method")]
		string Method { get; set;  }

		[Export ("headerFields")]
		NSDictionary HeaderFields { get; set;  }

		[Export ("delegate")]
		NSObject Delegate { get; set;  }

		[Export ("isFinishedSelector")]
		Selector IsFinishedSelector { get; set;  }

		[Export ("connection")]
		NSUrlConnection Connection { get; set;  }

		[Export ("response")]
		NSHttpUrlResponse Response { get; set;  }

		[Export ("headers")]
		NSDictionary Headers { get; set;  }

		[Export ("data")]
		NSMutableData Data { get; set;  }

		[Export ("result")]
		string Result { [Bind ("getResult")] get; set;  }

		[Export ("success")]
		bool Success { get; set;  }

		[Export ("url")]
		NSUrl Url { get; set; }

		[Export ("initWithURL:params:delegate:isFinishedSelector:method:autostart:")]
		IntPtr Construct (NSUrl url, string parameters, NSObject delegateObject, Selector selector, string method, bool autostart);

		[Export ("start")]
		void Start ();

		[Export ("finish")]
		void Finish ();
	}
	
	[BaseType (typeof (UIView))]
	interface ShkActivityIndicator {
		[Export ("subMessageLabel")]
		UILabel SubMessageLabel { get; set;  }

		[Export ("spinner")]
		UIActivityIndicatorView Spinner { get; set;  }

		[Export ("centerMessageLabel")]
		UILabel CenterMessageLabel { get; set; }

		[Static]
		[Export ("currentIndicator")]
		ShkActivityIndicator CurrentIndicator { get; }

		[Export ("show")]
		void Show ();

		[Export ("hideAfterDelay")]
		void HideAfterDelay ();

		[Export ("hide")]
		void Hide ();

		[Export ("hidden")]
		void Hidden ();

		[Export ("displayActivity:")]
		void DisplayActivity (string message);

		[Export ("displayCompleted:")]
		void DisplayCompleted (string message);

		[Export ("setCenterMessage:")]
		void SetCenterMessage (string message);

		[Export ("setSubMessage:")]
		void SetSubMessage (string message);

		[Export ("showSpinner")]
		void ShowSpinner ();

		[Export ("setProperRotation:")]
		void SetProperRotation (bool animated);
	}

	[BaseType (typeof (NSObject))]
	interface ShkFormFieldSettings {
		[Export ("key")]
		string Key { get; set;  }

		[Export ("type")]
		ShkFormFieldType Type { get; set;  }

		[Export ("start")]
		string Start { get; set;  }

		[Export ("label")]
		string Label { get; set; }

		[Static]
		[Export ("label:key:type:start:")]
		ShkFormFieldSettings CreateForm (string label, string key, ShkFormFieldType type, string start);

	}

	[BaseType (typeof (NSOperation))]
	interface ShkOfflineSharer {
		[Export ("sharerId")]
		string SharerId { get; set;  }

		[Export ("uid")]
		string Uid { get; set;  }

		[Export ("readyToFinish")]
		bool ReadyToFinish { get; set;  }

		[Export ("runLoopThread")]
		NSThread RunLoopThread { get; set;  }

		[Export ("sharer")]
		ShkSharer Sharer { get; set;  }

		[Export ("item")]
		ShkItem Item { get; set; }

		[Export ("initWithItem:forSharer:uid:")]
		NSObject Constructor (ShkItem iitem, string sharerId, string uid);

		[Export ("share")]
		void Share ();

		[Export ("shouldRun")]
		bool ShouldRun { get; }

		[Export ("finish")]
		void Finish ();

		[Export ("lastSpin")]
		void LastSpin ();
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface ShkSharerDelegate {
		[Abstract]
		[Export ("sharerStartedSending:")]
		void StartedSending (ShkSharer sharer);

		[Abstract]
		[Export ("sharerFinishedSending:")]
		void FinishedSending (ShkSharer sharer);

		[Abstract]
		[Export ("sharer:failedWithError:shouldRelogin:")]
		void FailedWithError (ShkSharer sharer, NSError error, bool shouldRelogin);

		[Abstract]
		[Export ("sharerCancelledSending:")]
		void CancelledSending (ShkSharer sharer);

	}

	[BaseType (typeof (UINavigationController))]
	interface ShkSharer {
		[Export ("item")]
		ShkItem Item { get; set;  }

		[Export ("pendingForm")]
		ShkFormController PendingForm { get; set;  }

		[Export ("request")]
		ShkRequest Request { get; set;  }

		[Export ("lastError")]
		NSError LastError { get; set;  }

		[Export ("quiet")]
		bool Quiet { get; set;  }

		[Export ("pendingAction")]
		ShkSharerPendingAction PendingAction { get; set;  }

		[Export ("shareDelegate")]
		ShkSharerDelegate Delegate { get; set; }

		[Export ("sharerTitle")]
		string SharerTitle { get; }

		[Export ("sharerId")]
		string SharerId { get; }

		[Export ("shouldAutoShare")]
		bool ShouldAutoShare ();

		[Export ("shareItem:")]
		NSObject ShareItem (ShkItem i);

		[Static]
		[Export ("shareURL:")]
		NSObject FromUrl (NSUrl url);

		[Static]
		[Export ("shareURL:title:")]
		NSObject FromUrl (NSUrl url, string title);

		[Static]
		[Export ("shareImage:title:")]
		NSObject FromImage (UIImage image, string title);

		[Static]
		[Export ("shareText:")]
		NSObject FromText (string text);

		[Static]
		[Export ("shareFile:filename:mimeType:title:")]
		NSObject FromFile (NSData file, string filename, string mimeType, string title);

		[Export ("share")]
		void Share ();

		[Export ("isAuthorized")]
		bool IsAuthorized { get; }

		[Export ("authorize")]
		bool Authorize ();

		[Export ("promptAuthorization")]
		void PromptAuthorization ();

		[Export ("getAuthValueForKey:")]
		string GetAuthValueForKey (string key);

		[Export ("authorizationFormShow")]
		void AuthorizationFormShow ();

		[Export ("authorizationFormValidate:")]
		void AuthorizationFormValidate (ShkFormController form);

		[Export ("authorizationFormSave:")]
		void AuthorizationFormSave (ShkFormController form);

		[Export ("authorizationFormFields")]
		NSObject [] AuthorizationFormFields ();

		[Export ("validateItem")]
		bool ValidateItem ();

		[Export ("tryToSend")]
		bool TryToSend ();

		[Export ("send")]
		bool Send ();

		[Export ("show")]
		void Show ();

		[Export ("shareFormFieldsForType:")]
		NSObject [] ShareFormFieldsForType (ShkShareType type);

		[Export ("shareFormValidate:")]
		void ShareFormValidate (ShkFormController form);

		[Export ("shareFormSave:")]
		void ShareFormSave (ShkFormController form);

		[Export ("tryPendingAction")]
		void TryPendingAction ();

		[Export ("sendDidStart")]
		void SendDidStart ();

		[Export ("sendDidFinish")]
		void SendDidFinish ();

		[Export ("sendDidFailShouldRelogin")]
		void SendDidFailShouldRelogin ();

		[Export ("sendDidFailWithError:")]
		void SendDidFailWithError (NSError error);

		[Export ("sendDidFailWithError:shouldRelogin:")]
		void SendDidFailWithErrorshouldRelogin (NSError error, bool shouldRelogin);

		[Export ("sendDidCancel")]
		void SendDidCancel ();
	}

	[BaseType (typeof (UITableViewController))]
	interface ShkFormController {
		[Export ("validateSelector")]
		Selector ValidateSelector  { get; set;  }

		[Export ("saveSelector")]
		Selector SaveSelector { get; set;  }

		[Export ("labelWidth")]
		float LabelWidth { get; set;  }

		[Export ("activeField")]
		UITextField ActiveField { get; set;  }

		[Export ("autoSelect")]
		bool AutoSelect { get; set;  }

		[Export ("delegate")]
		NSObject Delegate { get; set; }

		[Export ("initWithStyle:title:rightButtonTitle:")]
		IntPtr Constructor (UITableViewStyle style, string barTitle, string rightButtonTitle);

		[Export ("addSection:header:footer:")]
		void AddSection (NSObject [] fields, string header, string footer);

		[Export ("rowSettingsForIndexPath:")]
		ShkFormFieldSettings GetRowSettings (NSIndexPath indexPath);

		[Export ("close")]
		void Close ();

		[Export ("cancel")]
		void Cancel ();

		[Export ("validateForm")]
		void ValidateForm ();

		[Export ("saveForm")]
		void SaveForm ();

		// NSMutableDictionary
		[Export ("formValues")]
		NSDictionary FormValues ();

		// NSMutableDictionary
		[Export ("formValuesForSection:")]
		NSDictionary FormValues (int section);

	}

}
