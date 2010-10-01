using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using System;

namespace Facebook
{
    [BaseType(typeof(NSObject))]
    interface FBRequest
    {
        //+ (FBRequest*)request;
        [Static]
        [Export("request")]
        FBRequest Request();

        //+ (FBRequest*)requestWithDelegate:(id<FBRequestDelegate>)delegate;
        [Static]
        [Export("requestWithDelegate:")]
        FBRequest RequestWithDelegate(FBRequestDelegate callback);

        //+ (FBRequest*)requestWithSession:(FBSession*)session;
        [Static]
        [Export("requestWithSession:")]
        FBRequest RequestWithSession(FBSession session);

        //+ (FBRequest*)requestWithSession:(FBSession*)session delegate:(id<FBRequestDelegate>)delegate;
        [Static]
        [Export("requestWithSession:delegate:")]
        FBRequest RequestWithSession(FBSession session, FBRequestDelegate callback);

        //@property(nonatomic,assign) id<FBRequestDelegate> delegate;
        [Export("delegates")]
        FBRequestDelegate Delegate { get; set; }

        //@property(nonatomic,readonly) NSString* url;
        [Export("url")]
        NSString Url { get; }

        //@property(nonatomic,readonly) NSString* method;
        [Export("method")]
        NSString Method { get; }

        //@property(nonatomic,retain) id userInfo;
        [Export("userInfo")]
        IntPtr UserInfo { get; }

        //@property(nonatomic,readonly) NSDictionary* params;
        [Export("params")]
        NSDictionary Params { get; }

        //@property(nonatomic,readonly) NSObject* dataParam;
        [Export("dataParam")]
        NSObject DataParam { get; }

        //@property(nonatomic,readonly) NSDate* timestamp;
        [Export("timestamp")]
        NSDate Timestamp { get; }

        //@property(nonatomic,readonly) NSDictionary* loading;
        [Export("loading")]
        bool Loading { get; }

        //- (id)initWithSession:(FBSession*)session;
        [Export("initWithSession:")]
        IntPtr InitWithSession(FBSession session);

        //- (void)call:(NSString*)method params:(NSDictionary*)params;
        [Export("call:params:")]
        void Call(NSString method, NSDictionary parameters);

        //- (void)call:(NSString*)method params:(NSDictionary*)params dataParam:(NSData*)dataParam;
        [Export("call:params:dataParam:")]
        void Call(NSString method, NSDictionary parameters, NSData dataParam);

        //- (void)post:(NSString*)url params:(NSDictionary*)params;
        [Export("post:params:")]
        void Post(NSString url, NSDictionary parameters);
       
        //- (void)cancel;
        [Export("Cancel")]
        void Cancel();
    }

    [BaseType(typeof(NSObject))]
    [Model]
    interface FBRequestDelegate 
    {
        [Abstract]
        //- (void)requestLoading:(FBRequest*)request;
        [Export("requestLoading:")]
        void RequestLoading(FBRequest request);

        [Abstract]
        //- (void)request:(FBRequest*)request didReceiveResponse:(NSURLResponse*)response;
        [Export("request:didReceiveResponse:")]
        void Request(FBRequest request, NSUrlResponse response);

        [Abstract]
        //- (void)request:(FBRequest*)request didFailWithError:(NSError*)error;
        [Export("Request:didFailWithError:")]
        void Request(FBRequest request, NSError error);

        [Abstract]
        //- (void)request:(FBRequest*)request didLoad:(id)result;
        [Export("request:didLoad:")]
        void Request(FBRequest request, FBRequestDelegate result);

        [Abstract]
        //- (void)requestWasCancelled:(FBRequest*)request;
        [Export("requestWasCancelled:")]
        void RequestWasCancelled(FBRequest request);
    }

    [BaseType(typeof(NSObject))]
    interface FBSession
    {
        //@property (nonatomic, readonly) NSMutableArray* delegates;
        [Export("delegates")]
        NSObject[] Delegates { get; }

        //@property (nonatomic, readonly) NSString* apiURL;
        [Export("apiURL")]
        NSString ApiURL { get; }

        //@property (nonatomic, readonly) NSString* apiSecureURL;
        [Export("apiSecureURL")]
        NSString ApiSecureURL { get; }

        //@property (nonatomic, readonly) NSString* apiSecret;
        [Export("apiSecret")]
        NSString ApiSecret { get; }

        //@property (nonatomic, readonly) NSString* getSessionProxy;
        [Export("getSessionProxy")]
        NSString GetSessionProxy { get; }

        //@property (nonatomic, readonly) FBUID uid;
        [Export("uid")]
        ulong Uid { get; }

        //@property (nonatomic, readonly) NSString* sessionKey;
        [Export("sessionKey")]
        NSString SessionKey { get; }

        //@property (nonatomic, readonly) NSString* sessionSecret;
        [Export("sessionSecret")]
        NSString SessionSecret { get; }

        //@property (nonatomic, readonly) NSDate* expirationDate;
        [Export("expirationDate")]
        NSDate ExpirationDate { get; }
		
		//@property (nonatomic, readonly) BOOL isConnected;
        [Export("isConnected")]
        bool IsConnected { get; }

        //+ (FBSession*)session;
        [Static]
        [Export("session")]
        FBSession Session();

        //+ (FBSession*)session;
        [Static]
        [Export("setSession:")]
        void SetSession(FBSession session);

        //+ (FBSession*)sessionForApplication:(NSString*)key secret:(NSString*)secret
        //delegate:(id<FBSessionDelegate>)delegate;
        [Static]
        [Export("sessionForApplication:secret:delegate:")]
        FBSession SessionForApplication(NSString key, NSString secret, FBSessionDelegate callback);

        //+ (FBSession*)sessionForApplication:(NSString*)key getSessionProxy:(NSString*)getSessionProxy
        //delegate:(id<FBSessionDelegate>)delegate;
        [Static]
        [Export("sessionForApplication:getSessionProxy:delegate:")]
        FBSession SessionForApplicationProxy(NSString key, NSString proxy, FBSessionDelegate callback);

        //- (FBSession*)initWithKey:(NSString*)key secret:(NSString*)secret
        //getSessionProxy:(NSString*)getSessionProxy;
        [Export("initWithKey:secret:getSessionProxy:")]
        FBSession InitWithKey(NSString key, NSString secret, NSString getSessionProxy);

        //- (void)begin:(FBUID)uid sessionKey:(NSString*)sessionKey sessionSecret:(NSString*)sessionSecret
        //expires:(NSDate*)expires;
        [Export("begin:sessionKey:sessionSecret:expires:")]
        void Begin(ulong uid, NSString sessionKey, NSString sessionSecret, NSDate expires);

        //- (BOOL)resume;
        [Export("resume")]
        bool Resume();

        //- (void)cancelLogin;
        [Export("cancelLogin")]
        void CancelLogin();

        //- (void)logout;
        [Export("logout")]
        void Logout();

        //- (void)send:(FBRequest*)request;
        [Export("send:")]
        void Send(FBRequest request);

        //- (void)deleteFacebookCookies;
        [Export("deleteFacebookCookies")]
        void DeleteFacebookCookies();
    }


    [BaseType(typeof(NSObject))]
    [Model]
    interface FBSessionDelegate
    {
        [Abstract]
        //- (void)session:(FBSession*)session didLogin:(FBUID)uid;
        [Export("session:didLogin:")]
        void DidLogin(FBSession session, ulong uid);

        [Abstract]
        //- (void)sessionDidNotLogin:(FBSession*)session;
        [Export("sessionDidNotLogin:")]
        void SessionDidNotLogin(FBSession session);

        [Abstract]
        //- (void)session:(FBSession*)session willLogout:(FBUID)uid;
        [Export("session:willLogout:")]
        void WillLogout(FBSession session, ulong uid);

        [Abstract]
        //- (void)sessionDidLogout:(FBSession*)session;
        [Export("sessionDidLogout:")]
        void SessionDidLogout(FBSession session);
    }

    [BaseType(typeof(UIView))]
    interface FBDialog
    {
        //- (id)initWithSession:(FBSession*)session;
        [Export("initWithSession:")]
        void InitWithSession(NSObject session);

        //- (void)show;
        [Export("show")]
        void Show();
    }


    [BaseType(typeof(FBDialog))]
    interface FBLoginDialog
    {

    }


}

	