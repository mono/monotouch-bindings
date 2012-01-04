using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.CoreAnimation;
using MonoTouch.UIKit;

namespace MonoTouch.Datatrans {
    
    //@interface DTVisualStyle : NSObject <NSCopying> {
    [BaseType(typeof(NSObject), Name = "DTVisualStyle")]
    interface DtVisualStyle {

        #region Properties

        //@property (nonatomic, assign) BOOL isDark;
        [Export("isDark", ArgumentSemantic.Assign)]
        bool IsDark {
            get;
            set;
        }

        //@property (nonatomic, copy) DTShadowTextStyle* navigationBarTitleStyle;
        [Export("navigationBarTitleStyle", ArgumentSemantic.Copy)]
        DtShadowTextStyle NavigationBarTitleStyle {
            get;
            set;
        }

        //@property (nonatomic, retain) UIColor *navigationBarButtonItemDoneTintColor;
        [Export("navigationBarButtonItemDoneTintColor", ArgumentSemantic.Retain)]
        UIColor NavigationBarButtonItemDoneTintColor {
            get;
            set;
        }

        //@property (nonatomic, retain) DTShadowTextStyle *toolbarTextStyle;
        [Export("toolbarTextStyle", ArgumentSemantic.Retain)]
        DtShadowTextStyle ToolbarTextStyle {
            get;
            set;
        }

        //@property (nonatomic, retain) UIColor *backgroundColor;
        [Export("backgroundColor", ArgumentSemantic.Retain)]
        UIColor BackgroundColor {
            get;
            set;
        }

        //// New style

        //@property (nonatomic, copy) DTSimpleTextStyle* inputFieldStyle;
        [Export("inputFieldStyle", ArgumentSemantic.Copy)]
        DtSimpleTextStyle InputFieldStyle {
            get;
            set;
        }

        //@property (nonatomic, copy) DTShadowTextStyle* inputLabelStyle;
        [Export("inputLabelStyle", ArgumentSemantic.Copy)]
        DtShadowTextStyle InputLabelStyle {
            get;
            set;
        }

        //@property (nonatomic, copy) DTShadowTextStyle* titleStyle;
        [Export("titleStyle", ArgumentSemantic.Copy)]
        DtShadowTextStyle TitleStyle {
            get;
            set;
        }

        //@property (nonatomic, copy) DTShadowTextStyle* textStyle;
        [Export("textStyle", ArgumentSemantic.Copy)]
        DtShadowTextStyle TextStyle {
            get;
            set;
        }
        
        //@property (nonatomic, copy) DTShadowTextStyle* emphasizedTextStyle;
        [Export("emphasizedTextStyle", ArgumentSemantic.Copy)]
        DtShadowTextStyle EmphasizedTextStyle {
            get;
            set;
        }

        //#if USE_DEPRECATED_STYLE

        //@property (nonatomic, copy) DTShadowTextStyle* infoTextStyle;
        [Export("infoTextStyle", ArgumentSemantic.Copy)]
        DtShadowTextStyle InfoTextStyle {
            get;
            set;
        }

        //@property (nonatomic, copy) DTShadowTextStyle* emphasizedInfoTextStyle;
        [Export("emphasizedInfoTextStyle", ArgumentSemantic.Copy)]
        DtShadowTextStyle EmphasizedInfoTextStyle {
            get;
            set;
        }
        
        //#endif

        //@property (nonatomic, copy) DTShadowTextStyle* tableViewTitleStyle;
        [Export("tableViewTitleStyle", ArgumentSemantic.Copy)]
        DtShadowTextStyle TableViewTitleStyle {
            get;
            set;
        }
        
        //@property (nonatomic, copy) DTShadowTextStyle* tableViewCellTextStyle;
        [Export("tableViewCellTextStyle", ArgumentSemantic.Copy)]
        DtShadowTextStyle TableViewCellTextStyle {
            get;
            set;
        }

        //@property (nonatomic, retain) UIColor *tableViewCellBackgroundColor;
        [Export("tableViewCellBackgroundColor", ArgumentSemantic.Retain)]
        UIColor TableViewCellBackgroundColor {
            get;
            set;
        }

        //@property (nonatomic, retain) UIColor *tableViewCellSelectedBackgroundColor;
        [Export("tableViewCellSelectedBackgroundColor", ArgumentSemantic.Retain)]
        UIColor TableViewCellSelectedBackgroundColor {
            get;
            set;
        }

        //@end
        #endregion

        //+ (DTVisualStyle *)defaultStyle;
        [Static, Export("defaultStyle")]
        DtVisualStyle DefaultStyle();

    }


    
    //@interface DTShadowTextStyle : DTSimpleTextStyle <NSCopying> {
    [BaseType(typeof(DtSimpleTextStyle), Name = "DTShadowTextStyle")]
    interface DtShadowTextStyle {

        #region Properties

        //@property (nonatomic, retain) UIColor* shadowColor;
        [Export("shadowColor", ArgumentSemantic.Retain)]
        UIColor ShadowColor {
            get;
            set;
        }

        //@property (nonatomic, assign) CGSize shadowOffset;
        [Export("shadowOffset", ArgumentSemantic.Assign)]
        SizeF ShadowOffset {
            get;
            set;
        }

        #endregion

        //+ (id)textStyleWithFont:(UIFont *)font color:(UIColor *)color;
        [Static, Export("textStyleWithFont:color:")]
        DtShadowTextStyle DtShadowTextStyleFromFont(UIFont font, UIColor color);

        //- (id)withShadowColor:(UIColor *)color andOffset:(CGSize)shadowOffset;
        [Export("withShadowColor:andOffset:")]
        IntPtr Constructor(UIColor color, SizeF shadowOffset);

        #region methodes

        //- (void)applyToLabel:(UILabel *)label;
        [Export("applyToLabel:")]
        void ApplyTo(UILabel label);

        //- (NSString *)CSSStyle;
        [Export("CSSStyle")]
        string CSSStyle();

        #endregion
    }
        
    //@interface DTSimpleTextStyle : NSObject <NSCopying> {
    [BaseType(typeof(NSObject), Name = "DTSimpleTextStyle")]
    interface DtSimpleTextStyle {

        #region Properties

        //@property (nonatomic, retain) UIColor* color;
        [Export("color", ArgumentSemantic.Retain)]
        UIColor Color {
            get;
            set;
        }

        //@property (nonatomic, retain) UIFont* font;
        [Export("font", ArgumentSemantic.Retain)]
        UIFont Font {
            get;
            set;
        }

        #endregion

        //+ (id)textStyleWithFont:(UIFont *)font color:(UIColor *)color;
        [Static, Export("textStyleWithFont:color:")]
        DtSimpleTextStyle DtSimpleTextStyleFromFont(UIFont font, UIColor color);

        #region methodes

        //- (void)applyToTextField:(UITextField *)textField;
        [Export("applyToTextField:")]
        void ApplyTo(UITextField textField);

        //- (void)applyToTextView:(UITextView *)textView;
        [Export("applyToTextView:")]
        void ApplyTo(UITextView textView);

        #endregion
        //@end
    }
    
    //@interface DTPaymentRequest : NSObject <NSCopying> {
    [BaseType(typeof(NSObject), Name = "DTPaymentRequest")]
    interface DtPaymentRequest {

        #region Properties

        //@property (nonatomic, copy) NSString* merchantId;
        [Export("merchantId", ArgumentSemantic.Copy)]
        string MerchantId {
            get;
            set;
        }

        //@property (nonatomic, copy) NSString* refno;
        [Export("refno", ArgumentSemantic.Copy)]
        string Refno {
            get;
            set;
        }

        //@property (nonatomic, copy) NSString* currencyCode;
        [Export("currencyCode", ArgumentSemantic.Copy)]
        string CurrencyCode {
            get;
            set;
        }

        //@property (nonatomic, assign) NSUInteger amountInSmallestCurrencyUnit;
        [Export("amountInSmallestCurrencyUnit", ArgumentSemantic.Assign)]
        int AmountInSmallestCurrencyUnit {
            get;
            set;
        }

        //@property (nonatomic, copy) NSString* signature;
        [Export("signature", ArgumentSemantic.Copy)]
        string Signature {
            get;
            set;
        }

        //@property (nonatomic, copy) NSString* localizedMerchantName;
        [Export("localizedMerchantName", ArgumentSemantic.Copy)]
        string LocalizedMerchantName {
            get;
            set;
        }
        
        //@property (nonatomic, copy) NSString* localizedPriceDescription;
        [Export("localizedPriceDescription", ArgumentSemantic.Copy)]
        string LocalizedPriceDescription {
            get;
            set;
        }
        #endregion

    }

    
    //@interface DTPaymentOptions : NSObject <NSCopying> {
    [BaseType(typeof(NSObject), Name = "DTPaymentOptions")]
    interface DtPaymentOptions {

        #region Properties

        //@property (nonatomic, assign) BOOL testing;
        [Export("testing", ArgumentSemantic.Assign)]
        bool Testing {
            get;
            set;
        }

        //@property (nonatomic, assign) BOOL hideToolbarSecurityInfo;
        [Export("hideToolbarSecurityInfo", ArgumentSemantic.Assign)]
        bool HideToolbarSecurityInfo {
            get;
            set;
        }

        //@property (nonatomic, assign) BOOL showBackButtonOnFirstScreen;
        [Export("showBackButtonOnFirstScreen", ArgumentSemantic.Assign)]
        bool ShowBackButtonOnFirstScreen {
            get;
            set;
        }

        //@property (nonatomic, assign) BOOL showAuthorizationConfirmationScreen;
        [Export("showAuthorizationConfirmationScreen", ArgumentSemantic.Assign)]
        bool ShowAuthorizationConfirmationScreen {
            get;
            set;
        }


        //@property (nonatomic, assign) DTPaymentReturnsCreditCard returnsCreditCard;
        [Export("returnsCreditCard", ArgumentSemantic.Assign)]
        DtPaymentReturnsCreditCard ReturnsCreditCard {
            get;
            set;
        }


        //@property (nonatomic, copy) NSDictionary* merchantProperties;
        [Export("merchantProperties", ArgumentSemantic.Copy)]
        NSDictionary MerchantProperties {
            get;
            set;
        }

        #endregion

    }


    
    //@interface DTAliasController : NSObject {
    [BaseType(typeof(NSObject), Name = "DTAliasController")]
    interface DtAliasController {

        //// Archiving / unarchiving helpers
        //+ (void)createAliasWithAliasRequest:(DTAliasRequest *)aliasRequest delegate:(id<DTAliasControllerDelegate>)delegate testing:(BOOL)testing;
        [Static, Export("createAliasWithAliasRequest:delegate:testing:")]
        void CreateAlias(DtAliasRequest aliasRequest, DtAliasControllerDelegate dtDelegate, bool testing);

    }

    //@protocol DTAliasControllerDelegate <NSObject>
    [BaseType(typeof(NSObject), Name = "DTAliasControllerDelegate")]
    [Model]
    interface DtAliasControllerDelegate {

        //- (void)aliasRequest:(DTAliasRequest *)aliasRequest didFinishWithAlias:(DTCreditCard *)creditCardAlias;
        [Abstract]
        [Export("aliasRequest:didFinishWithAlias:"), EventArgs("DtAliasRequest")]
        void DidFinish(DtAliasRequest aliasRequest, DtCreditCard creditCardAlias);

        //- (void)aliasRequest:(DTAliasRequest *)aliasRequest didFailWithError:(NSError *)error;
        [Abstract]
        [Export("aliasRequest:didFailWithError:"), EventArgs("DtAliasRequest")]
        void DidFail(DtAliasRequest aliasRequest, NSError error);

    }


    //@interface DTPaymentController : NSObject {
    [BaseType(typeof(NSObject), Name = "DTPaymentController", Delegates = new string[] { "WeakDelegate" }, Events = new Type[] { typeof(DtPaymentControllerDelegate) })]
    interface DtPaymentController {

        #region Properties

        //@property (nonatomic, copy) DTVisualStyle *visualStyle;
        [Export("visualStyle", ArgumentSemantic.Copy)]
        DtVisualStyle VisualStyle {
            get;
            set;
        }

        //@property (nonatomic, copy) DTPaymentOptions *paymentOptions;
        [Export("paymentOptions", ArgumentSemantic.Copy)]
        DtPaymentOptions PaymentOptions {
            get;
            set;
        }

        //@property (nonatomic, copy) DTCreditCard *creditCard;
        [Export("creditCard", ArgumentSemantic.Copy)]
        DtCreditCard CreditCard {
            get;
            set;
        }

        #endregion

        #region Delegates

        //@property (nonatomic, readonly) id<DTPaymentControllerDelegate> delegate;
        [Export("delegate")]
        NSObject WeakDelegate {
            get;
            set;
        }

        //@property (nonatomic, readonly) id<DTPaymentControllerDelegate> delegate;
        [Wrap("WeakDelegate")]
        DtPaymentControllerDelegate Delegate {
            get;
            set;
        }

        #endregion

        //+ (NSArray *)allAvailablePaymentMethods;
        [Static, Export("allAvailablePaymentMethods")]
        NSArray AllAvailablePaymentMethods();

        //+ (id)paymentControllerWithDelegate:(id<DTPaymentControllerDelegate>)delegate
        //                     paymentRequest:(DTPaymentRequest *)request
        //                     paymentMethods:(NSArray *)identifiers;
        [Static, Export("paymentControllerWithDelegate:paymentRequest:paymentMethods:")]
        DtPaymentController FromDelegate(DtPaymentControllerDelegate dtDelegate, DtPaymentRequest request, NSArray identifiers);

        //+ (id)paymentControllerWithDelegate:(id<DTPaymentControllerDelegate>)delegate
        //                     paymentRequest:(DTPaymentRequest *)request
        //                         creditCard:(DTCreditCard *)creditCard;
        [Static, Export("paymentControllerWithDelegate:paymentRequest:creditCard:")]
        DtPaymentController FromDelegate(DtPaymentControllerDelegate dtDelegate, DtPaymentRequest request, DtCreditCard creditCard);

        #region Methodes

        //// present in navigation controller and retain
        //- (void)presentInNavigationController:(UINavigationController *)controller animated:(BOOL)animated;
        [Export("presentInNavigationController:animated:")]
        void PresentIn(UINavigationController controller, bool animated);

        //- (void)dismissAnimated:(BOOL)animated;
        [Export("dismissAnimated:")]
        void Dismiss(bool animated);

        //- (void)restoreToolbarState:(BOOL)animated;
        [Export("restoreToolbarState:")]
        void RestoreToolbarState(bool animated);

        #endregion
    }

    //@protocol DTPaymentControllerDelegate <NSObject>
    [Model]
    [BaseType(typeof(NSObject), Name = "DTPaymentControllerDelegate")]
    interface DtPaymentControllerDelegate {

        //- (void)paymentController:(DTPaymentController *)controller paymentRequestDidSucceed:(DTPaymentRequest *)request;
        [Abstract]
        [Export("paymentController:paymentRequestDidSucceed:"), EventArgs("DtPaymentSucceed")]
        void DidSucceed(DtPaymentController controller, DtPaymentRequest request);

        //- (void)paymentController:(DTPaymentController *)controller didFailWithError:(NSError *)error;
        [Abstract]
        [Export("paymentController:didFailWithError:"), EventArgs("DtPaymentFail")]
        void DidFail(DtPaymentController controller, NSError error);

        //- (void)paymentController:(DTPaymentController *)controller didCancelWithType:(DTPaymentCancellationType)cancellationType;
        [Abstract]
        [Export("paymentController:didCancelWithType:"), EventArgs("DtPaymentCancel")]
        void DidCancel(DtPaymentController controller, DtPaymentCancellationType cancellationType);

        //- (BOOL)paymentController:(DTPaymentController *)controller shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)toInterfaceOrientation;
        //// Implement this method if the payment controller should support user interface orientations other than UIInterfaceOrientationPortrait.
        [Abstract]
        [Export("paymentController:shouldAutorotateToInterfaceOrientation:"), DelegateName("DTInterfaceOrientation"), DefaultValue(false)]
        bool ShouldAutorotate(DtPaymentController controller, UIInterfaceOrientation toInterfaceOrientation);

    }

    //@interface DTAliasRequest : NSObject <NSCopying> {
    [BaseType(typeof(NSObject), Name = "DTAliasRequest")]
    interface DtAliasRequest {

        #region Properties

        //@property (nonatomic, copy) NSString* merchantId;
        [Export("merchantId", ArgumentSemantic.Copy)]
        string MerchantId {
            get;
            set;
        }

        //@property (nonatomic, copy) NSString* paymentMethod;
        [Export("paymentMethod", ArgumentSemantic.Copy)]
        string PaymentMethod {
            get;
            set;
        }

        //@property (nonatomic, copy) NSString* number;
        [Export("number", ArgumentSemantic.Copy)]
        string Number {
            get;
            set;
        }

        //@property (nonatomic, assign) NSUInteger expMonth;
        [Export("expMonth", ArgumentSemantic.Assign)]
        int ExpirationMonth {
            get;
            set;
        }

        //@property (nonatomic, assign) NSUInteger expYear;
        [Export("expYear", ArgumentSemantic.Assign)]
        int ExpirationYear {
            get;
            set;
        }

        //@property (nonatomic, copy) NSString* cvv;
        [Export("cvv", ArgumentSemantic.Copy)]
        string Cvv {
            get;
            set;
        }

        //@property (nonatomic, copy) NSString* holder;
        [Export("holder", ArgumentSemantic.Copy)]
        string Holder {
            get;
            set;
        }

        #endregion

        //- (id)initWithMerchantId:(NSString *)merchantId paymentMethod:(NSString *)method number:(NSString *)number 
        //			expMonth:(NSUInteger)expMonth expYear:(NSUInteger)expYear cvv:(NSString *)cvv holder:(NSString *)holder;
        [Export("initWithMerchantId:paymentMethod:number:expMonth:expYear:cvv:holder:")]
        IntPtr Constructor(string merchantId, string paymentMethod, string number, int expMonth, int expYear, string cvv, string holder);

    }

    //@interface DTCreditCard : NSObject <NSCopying, NSCoding> {
    [BaseType(typeof(NSObject), Name = "DTCreditCard")]
    interface DtCreditCard {


        //@property (nonatomic, assign) NSUInteger expMonth;
        [Export("expMonth", ArgumentSemantic.Assign)]
        int ExpirationMonth {
            get;
            set;
        }

        //@property (nonatomic, assign) NSUInteger expYear;
        [Export("expYear", ArgumentSemantic.Assign)]
        int ExpirationYear {
            get;
            set;
        }

        //@property (nonatomic, copy) NSString* maskedCC;
        [Export("maskedCC", ArgumentSemantic.Copy)]
        string MaskedCC {
            get;
            set;
        }

        //@property (nonatomic, copy) NSString* alias;
        [Export("alias", ArgumentSemantic.Copy)]
        string Alias {
            get;
            set;
        }

        //@property (nonatomic, copy) NSString* cardHolder;
        [Export("cardHolder", ArgumentSemantic.Copy)]
        string CardHolder {
            get;
            set;
        }

        //@property (nonatomic, copy) NSString* paymentMethod;
        [Export("paymentMethod", ArgumentSemantic.Copy)]
        string PaymentMethod {
            get;
            set;
        }

        //- (id)initWithPaymentMethod:(NSString *)method;
        [Export("initWithPaymentMethod:")]
        IntPtr Constructor(string method);


        //// Archiving / unarchiving helpers
        //+ (id)creditCardWithData:(NSData *)data;
        [Static, Export("creditCardWithData:")]
        DtCreditCard FromData(NSData data);

        //// Archiving / unarchiving helpers
        //- (NSData *)data;
        [Export("data")]
        NSData Data();

    }
}

