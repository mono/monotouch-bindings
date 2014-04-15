using System.Drawing;
using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace Card.IO 
{
	[BaseType (typeof (NSObject))]
	[Protocol]
	public partial interface CreditCardInfo 
	{
		[Export ("cardNumber", ArgumentSemantic.Copy)]
		string CardNumber { get; set; }

		[Export ("redactedCardNumber", ArgumentSemantic.Copy)]
		string RedactedCardNumber { get; }

		[Export ("expiryMonth")]
		uint ExpiryMonth { get; set; }

		[Export ("expiryYear")]
		uint ExpiryYear { get; set; }

		[Export ("cvv", ArgumentSemantic.Copy)]
		string Cvv { get; set; }

		[Export ("postalCode", ArgumentSemantic.Copy)]
		string PostalCode { get; set; }

//		[Export ("zip", ArgumentSemantic.Copy)]
//		string Zip { [Bind ("postalCode")] get; [Bind ("setPostalCode:")] set; }

		[Export ("scanned")]
		bool Scanned { get; set; }

		[Export ("cardType")]
		CreditCardType CardType { get; }

		[Static, Export ("displayStringForCardType:usingLanguageOrLocale:")]
		string DisplayStringForCardType (CreditCardType cardType, string languageOrLocale);

		[Static, Export ("logoForCardType:")]
		UIImage LogoForCardType (CreditCardType cardType);
	}

	[Model, Protocol, BaseType (typeof (NSObject))]
	public partial interface CardIOViewDelegate {

		[Export ("cardIOView:didScanCard:")]
		void DidScanCard (CardIOView cardIOView, CreditCardInfo cardInfo);
	}

	[BaseType (typeof (UIView))]
	public partial interface CardIOView {

		[Static, Export ("canReadCardWithCamera")]
		bool CanReadCardWithCamera { get; }

		[Export ("appToken", ArgumentSemantic.Copy)]
		string AppToken { get; set; }

		[Export ("delegate", ArgumentSemantic.Retain)]
		CardIOViewDelegate Delegate { get; set; }

		[Export ("languageOrLocale", ArgumentSemantic.Copy)]
		string LanguageOrLocale { get; set; }

		[Export ("guideColor", ArgumentSemantic.Retain)]
		UIColor GuideColor { get; set; }

		[Export ("useCardIOLogo")]
		bool UseCardIOLogo { get; set; }

		[Export ("allowFreelyRotatingCardGuide")]
		bool AllowFreelyRotatingCardGuide { get; set; }

		[Export ("scannedImageDuration")]
		float ScannedImageDuration { get; set; }

		[Export ("cameraPreviewFrame", ArgumentSemantic.Assign)]
		RectangleF CameraPreviewFrame { get; }
	}

	[Model, Protocol, BaseType (typeof (NSObject), Name="CardIOPaymentViewControllerDelegate")]
	public partial interface BasePaymentViewControllerDelegate {

		[Export ("userDidCancelPaymentViewController:")]
		//[EventArgs ("UserDidCancel")]
		void UserDidCancel (PaymentViewController paymentViewController);

		[Export ("userDidProvideCreditCardInfo:inPaymentViewController:")]
		//[EventArgs ("UserDidProvideCreditCardInfo")]
		void UserDidProvideCreditCardInfo (CreditCardInfo cardInfo, PaymentViewController paymentViewController);
	}

	public partial class PaymentViewControllerDelegate { 
	}

	[BaseType (typeof (UINavigationController),
		Name="CardIOPaymentViewController")]
	public partial interface PaymentViewController {

		//[Export("init")]
		//IntPtr Constructor ();

		[Export ("initWithPaymentDelegate:")]
		IntPtr Constructor (BasePaymentViewControllerDelegate paymentDelegate);

		[Export ("initWithPaymentDelegate:scanningEnabled:")]
		IntPtr Constructor (BasePaymentViewControllerDelegate paymentDelegate, bool scanningEnabled);

		[Export ("appToken", ArgumentSemantic.Copy)]
		string AppToken { get; set; }

		[Export ("languageOrLocale", ArgumentSemantic.Copy)]
		string LanguageOrLocale { get; set; }

		[Export ("keepStatusBarStyle")]
		bool KeepStatusBarStyle { get; set; }

		[Export ("navigationBarStyle")]
		UIBarStyle NavigationBarStyle { get; set; }

		[Export ("navigationBarTintColor", ArgumentSemantic.Retain)]
		UIColor NavigationBarTintColor { get; set; }

		[Export ("disableBlurWhenBackgrounding")]
		bool DisableBlurWhenBackgrounding { get; set; }

		[Export ("guideColor", ArgumentSemantic.Retain)]
		UIColor GuideColor { get; set; }

		[Export ("suppressScanConfirmation")]
		bool SuppressScanConfirmation { get; set; }

		[Export ("suppressScannedCardImage")]
		bool SuppressScannedCardImage { get; set; }

		[Export ("collectExpiry")]
		bool CollectExpiry { get; set; }

		[Export ("collectCVV")]
		bool CollectCVV { get; set; }

		[Export ("collectPostalCode")]
		bool CollectPostalCode { get; set; }

//		[Export ("collectZip")]
//		bool CollectZip { [Bind ("collectPostalCode")] get; [Bind ("setCollectPostalCode:")] set; }

		[Export ("useCardIOLogo")]
		bool UseCardIOLogo { get; set; }

		[Export ("allowFreelyRotatingCardGuide")]
		bool AllowFreelyRotatingCardGuide { get; set; }

		[Export ("disableManualEntryButtons")]
		bool DisableManualEntryButtons { get; set; }

		[Export("paymentDelegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get;set; }

		[NullAllowed]
		[Wrap("WeakDelegate")] //Export ("paymentDelegate", ArgumentSemantic.Assign)]
		BasePaymentViewControllerDelegate Delegate { get; set; }

		[Static, Export ("canReadCardWithCamera")]
		bool CanReadCardWithCamera { get; }

		[Static, Export ("libraryVersion")]
		string LibraryVersion { get; }

		[Export ("showsFirstUseAlert")]
		bool ShowsFirstUseAlert { get; set; }
	}
}
