using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Datatrans
{
	[BaseType (typeof (NSObject))]
	public partial interface DTAliasController {

		[Static, Export ("createAliasWithAliasRequest:delegate:testing:")]
		void CreateAliasWithAliasRequest (DTAliasRequest aliasRequest, DTAliasControllerDelegate controllerDelegate, bool testing);
	}

	[Protocol, Model, BaseType (typeof (NSObject))]
	public partial interface DTAliasControllerDelegate {

		[Export ("aliasRequest:didFinishWithAlias:")]
		void DidFinishWithAlias (DTAliasRequest aliasRequest, DTCreditCard creditCardAlias);

		[Export ("aliasRequest:didFailWithError:")]
		void DidFailWithError (DTAliasRequest aliasRequest, NSError error);
	}

	[BaseType (typeof (NSObject))]
	public partial interface DTAliasRequest {

		[Export ("merchantId", ArgumentSemantic.Copy)]
		string MerchantId { get; set; }

		[Export ("paymentMethod", ArgumentSemantic.Copy)]
		string PaymentMethod { get; set; }

		[Export ("number", ArgumentSemantic.Copy)]
		string Number { get; set; }

		[Export ("expMonth")]
		uint ExpMonth { get; set; }

		[Export ("expYear")]
		uint ExpYear { get; set; }

		[Export ("cvv", ArgumentSemantic.Copy)]
		string Cvv { get; set; }

		[Export ("holder", ArgumentSemantic.Copy)]
		string Holder { get; set; }

		[Export ("initWithMerchantId:paymentMethod:number:expMonth:expYear:cvv:holder:")]
		IntPtr Constructor (string merchantId, string method, string number, uint expMonth, uint expYear, string cvv, string holder);
	}

	[BaseType (typeof (DTRecurringPaymentMethod))]
	public partial interface DTCreditCard {

		[Export ("expMonth")]
		uint ExpMonth { get; set; }

		[Export ("expYear")]
		uint ExpYear { get; set; }

		[Export ("maskedCC", ArgumentSemantic.Copy)]
		string MaskedCC { get; set; }

		[Export ("cardHolder", ArgumentSemantic.Copy)]
		string CardHolder { get; set; }

		[Export ("initWithPaymentMethod:")]
		IntPtr Constructor (string method);

		[Static, Export ("creditCardWithData:")]
		NSObject CreditCardWithData (NSData data);

		[Export ("data")]
		NSData Data { get; }
	}

	[BaseType (typeof (DTRecurringPaymentMethod))]
	public partial interface DTPayPal {

		[Export ("email", ArgumentSemantic.Copy)]
		string Email { get; set; }

		[Static, Export ("ppWithData:")]
		NSObject PpWithData (NSData data);

		[Export ("data")]
		NSData Data { get; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface DTPaymentController {

		[Export ("visualStyle", ArgumentSemantic.Copy)]
		DTVisualStyle VisualStyle { get; set; }

		[Export ("paymentOptions", ArgumentSemantic.Copy)]
		DTPaymentOptions PaymentOptions { get; set; }

		[Export ("recurringPaymentMethod")]
		DTRecurringPaymentMethod RecurringPaymentMethod { get; }

		[Export ("delegate")]
		DTPaymentControllerDelegate Delegate { get; }

		[Static, Export ("allAvailablePaymentMethods")]
		string [] AllAvailablePaymentMethods { get; }

		[Static, Export ("paymentControllerWithDelegate:paymentRequest:paymentMethods:")]
		DTPaymentController PaymentControllerWithDelegate (DTPaymentControllerDelegate aDelegate, DTPaymentRequest request, string [] identifiers);

		[Static, Export ("paymentControllerWithDelegate:paymentRequest:recurringPaymentMethod:")]
		DTPaymentController PaymentControllerWithDelegate (DTPaymentControllerDelegate aDelegate, DTPaymentRequest request, DTRecurringPaymentMethod recurringPaymentMethod);

		[Export ("presentInNavigationController:animated:")]
		void PresentInNavigationController (UINavigationController controller, bool animated);

		[Export ("dismissAnimated:")]
		void DismissAnimated (bool animated);

		[Export ("restoreToolbarState:")]
		void RestoreToolbarState (bool animated);
	}

	[Protocol, Model, BaseType (typeof (NSObject))]
	public partial interface DTPaymentControllerDelegate {

		[Export ("paymentController:paymentRequestDidSucceed:")]
		void PaymentRequestDidSucceed (DTPaymentController controller, DTPaymentRequest request);

		[Export ("paymentController:didFailWithError:")]
		void DidFailWithError (DTPaymentController controller, NSError error);

		[Export ("paymentController:didCancelWithType:")]
		void DidCancelWithType (DTPaymentController controller, DTPaymentCancellationType cancellationType);

		[Export ("paymentController:shouldAutorotateToInterfaceOrientation:")]
		bool ShouldAutorotateToInterfaceOrientation (DTPaymentController controller, UIInterfaceOrientation toInterfaceOrientation);
	}

	[BaseType (typeof (NSObject))]
	public partial interface DTPaymentOptions {

		[Field ("DTPaymentMethodVisa", "__Internal")]
		NSString Visa { get; }

		[Field ("DTPaymentMethodMasterCard", "__Internal")]
		NSString MasterCard { get; }

		[Field ("DTPaymentMethodDinersClub", "__Internal")]
		NSString DinersClub { get; }

		[Field ("DTPaymentMethodAmericanExpress", "__Internal")]
		NSString AmericanExpress { get; }

		[Field ("DTPaymentMethodPostFinanceCard", "__Internal")]
		NSString PostFinanceCard { get; }

		[Field ("DTPaymentMethodPostFinanceEFinance", "__Internal")]
		NSString PostFinanceEFinance { get; }

		[Field ("DTPaymentMethodPayPal", "__Internal")]
		NSString PayPal { get; }

		[Export ("testing")]
		bool Testing { get; set; }

		[Export ("hideToolbarSecurityInfo")]
		bool HideToolbarSecurityInfo { get; set; }

		[Export ("showBackButtonOnFirstScreen")]
		bool ShowBackButtonOnFirstScreen { get; set; }

		[Export ("showAuthorizationConfirmationScreen")]
		bool ShowAuthorizationConfirmationScreen { get; set; }

		[Export ("returnsCreditCard")]
		DTPaymentReturnsCreditCard ReturnsCreditCard { get; set; }

		[Export ("returnsPostFinanceAlias")]
		bool ReturnsPostFinanceAlias { get; set; }

		[Export ("returnsPayPalAlias")]
		bool ReturnsPayPalAlias { get; set; }

		[Export ("cardHolder")]
		DTPaymentCardHolder CardHolder { get; set; }

		[Export ("merchantProperties", ArgumentSemantic.Copy)]
		NSDictionary MerchantProperties { get; set; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface DTPaymentRequest {

		[Export ("merchantId", ArgumentSemantic.Copy)]
		string MerchantId { get; set; }

		[Export ("refno", ArgumentSemantic.Copy)]
		string Refno { get; set; }

		[Export ("currencyCode", ArgumentSemantic.Copy)]
		string CurrencyCode { get; set; }

		[Export ("amountInSmallestCurrencyUnit")]
		uint AmountInSmallestCurrencyUnit { get; set; }

		[Export ("signature", ArgumentSemantic.Copy)]
		string Signature { get; set; }

		[Export ("localizedMerchantName", ArgumentSemantic.Copy)]
		string LocalizedMerchantName { get; set; }

		[Export ("localizedPriceDescription", ArgumentSemantic.Copy)]
		string LocalizedPriceDescription { get; set; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface DTRecurringPaymentMethod {

		[Export ("paymentMethod", ArgumentSemantic.Copy)]
		string PaymentMethod { get; set; }

		[Export ("alias", ArgumentSemantic.Copy)]
		string Alias { get; set; }

		[Export ("initWithPaymentMethod:")]
		IntPtr Constructor (string method);

		[Static, Export ("recurringPaymentMethodWithData:")]
		NSObject RecurringPaymentMethodWithData (NSData data);

		[Export ("data")]
		NSData Data { get; }
	}

	[BaseType (typeof (DTRecurringPaymentMethod))]
	public partial interface DTPostFinanceCard {

		[Export ("maskedCC", ArgumentSemantic.Copy)]
		string MaskedCC { get; set; }

		[Static, Export ("pfCardWithData:")]
		NSObject PfCardWithData (NSData data);

		[Export ("data")]
		NSData Data { get; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface DTSimpleTextStyle {

		[Static, Export ("textStyleWithFont:color:")]
		NSObject TextStyleWithFont (UIFont font, UIColor color);

		[Export ("applyToTextField:")]
		void ApplyToTextField (UITextField textField);

		[Export ("applyToTextView:")]
		void ApplyToTextView (UITextView textView);

		[Export ("color", ArgumentSemantic.Retain)]
		UIColor Color { get; set; }

		[Export ("font", ArgumentSemantic.Retain)]
		UIFont Font { get; set; }
	}

	[BaseType (typeof (DTSimpleTextStyle))]
	public partial interface DTShadowTextStyle {

		[Static, Export ("textStyleWithFont:color:")]
		NSObject TextStyleWithFont (UIFont font, UIColor color);

		[Export ("withShadowColor:andOffset:")]
		NSObject WithShadowColor (UIColor color, SizeF shadowOffset);

		[Export ("applyToLabel:")]
		void ApplyToLabel (UILabel label);

		[Export ("CSSStyle")]
		string CSSStyle { get; }

		[Export ("shadowColor", ArgumentSemantic.Retain)]
		UIColor ShadowColor { get; set; }

		[Export ("shadowOffset", ArgumentSemantic.Assign)]
		SizeF ShadowOffset { get; set; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface DTVisualStyle {

		[Export ("isDark")]
		bool IsDark { get; set; }

		[Export ("navigationBarTitleStyle", ArgumentSemantic.Copy)]
		DTShadowTextStyle NavigationBarTitleStyle { get; set; }

		[Export ("navigationBarButtonItemDoneTintColor", ArgumentSemantic.Retain)]
		UIColor NavigationBarButtonItemDoneTintColor { get; set; }

		[Export ("toolbarTextStyle", ArgumentSemantic.Retain)]
		DTShadowTextStyle ToolbarTextStyle { get; set; }

		[Export ("backgroundColor", ArgumentSemantic.Retain)]
		UIColor BackgroundColor { get; set; }

		[Export ("inputFieldStyle", ArgumentSemantic.Copy)]
		DTSimpleTextStyle InputFieldStyle { get; set; }

		[Export ("inputLabelStyle", ArgumentSemantic.Copy)]
		DTShadowTextStyle InputLabelStyle { get; set; }

		[Export ("titleStyle", ArgumentSemantic.Copy)]
		DTShadowTextStyle TitleStyle { get; set; }

		[Export ("textStyle", ArgumentSemantic.Copy)]
		DTShadowTextStyle TextStyle { get; set; }

		[Export ("emphasizedTextStyle", ArgumentSemantic.Copy)]
		DTShadowTextStyle EmphasizedTextStyle { get; set; }

		[Export ("infoTextStyle", ArgumentSemantic.Copy)]
		DTShadowTextStyle InfoTextStyle { get; set; }

		[Export ("emphasizedInfoTextStyle", ArgumentSemantic.Copy)]
		DTShadowTextStyle EmphasizedInfoTextStyle { get; set; }

		[Export ("tableViewTitleStyle", ArgumentSemantic.Copy)]
		DTShadowTextStyle TableViewTitleStyle { get; set; }

		[Export ("tableViewCellTextStyle", ArgumentSemantic.Copy)]
		DTShadowTextStyle TableViewCellTextStyle { get; set; }

		[Export ("tableViewCellBackgroundColor", ArgumentSemantic.Retain)]
		UIColor TableViewCellBackgroundColor { get; set; }

		[Export ("tableViewCellSelectedBackgroundColor", ArgumentSemantic.Retain)]
		UIColor TableViewCellSelectedBackgroundColor { get; set; }

		[Static, Export ("defaultStyle")]
		DTVisualStyle DefaultStyle { get; }
	}
}

