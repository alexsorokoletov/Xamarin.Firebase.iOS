using System;
using CoreFoundation;
using DreamTeam.Xamarin.GTMSessionFetcher;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace DreamTeam.Xamarin.GTMOAuth2
{
	// @interface GTMGatherInputStream : NSInputStream <NSStreamDelegate>
	[BaseType (typeof(NSInputStream))]
	interface GTMGatherInputStream : INSStreamDelegate
	{
		// +(NSInputStream *)streamWithArray:(NSArray *)dataArray __attribute__((nonnull(0)));
		[Static]
		[Export ("streamWithArray:")]
		//[Verify (StronglyTypedNSArray)]
		NSInputStream StreamWithArray (NSObject[] dataArray);
	}

	// @interface GTMMIMEDocumentPart : NSObject
	[BaseType (typeof(NSObject))]
	interface GTMMIMEDocumentPart
	{
		// @property (readonly, nonatomic) NSDictionary<NSString *,NSString *> * headers;
		[Export ("headers")]
		NSDictionary<NSString, NSString> Headers { get; }

		// @property (readonly, nonatomic) NSData * headerData;
		[Export ("headerData")]
		NSData HeaderData { get; }

		// @property (readonly, nonatomic) NSData * body;
		[Export ("body")]
		NSData Body { get; }

		// @property (readonly, nonatomic) NSUInteger length;
		[Export ("length")]
		nuint Length { get; }

		// +(instancetype)partWithHeaders:(NSDictionary *)headers body:(NSData *)body;
		[Static]
		[Export ("partWithHeaders:body:")]
		GTMMIMEDocumentPart PartWithHeaders (NSDictionary headers, NSData body);
	}

	// @interface GTMMIMEDocument : NSObject
	[BaseType (typeof(NSObject))]
	interface GTMMIMEDocument
	{
		// @property (copy, nonatomic) NSString * boundary;
		[Export ("boundary")]
		string Boundary { get; set; }

		// +(instancetype)MIMEDocument;
		[Static]
		[Export ("MIMEDocument")]
		GTMMIMEDocument MIMEDocument ();

		// -(void)addPartWithHeaders:(NSDictionary<NSString *,NSString *> *)headers body:(NSData *)body __attribute__((nonnull(0, 1)));
		[Export ("addPartWithHeaders:body:")]
		void AddPartWithHeaders (NSDictionary<NSString, NSString> headers, NSData body);

		//// -(void)generateInputStream:(NSInputStream **)outStream length:(unsigned long long *)outLength boundary:(NSString **)outBoundary;
		//[Export ("generateInputStream:length:boundary:")]
		//unsafe void GenerateInputStream (out NSInputStream outStream, ulong* outLength, out string outBoundary);

		//// -(void)generateDispatchData:(dispatch_data_t *)outDispatchData length:(unsigned long long *)outLength boundary:(NSString **)outBoundary;
		//[Export ("generateDispatchData:length:boundary:")]
		//unsafe void GenerateDispatchData (out OS_dispatch_data outDispatchData, ulong* outLength, out string outBoundary);

		// +(NSData *)dataWithHeaders:(NSDictionary<NSString *,NSString *> *)headers;
		[Static]
		[Export ("dataWithHeaders:")]
		NSData DataWithHeaders (NSDictionary<NSString, NSString> headers);

		// +(NSArray<GTMMIMEDocumentPart *> *)MIMEPartsWithBoundary:(NSString *)boundary data:(NSData *)fullDocumentData;
		[Static]
		[Export ("MIMEPartsWithBoundary:data:")]
		GTMMIMEDocumentPart[] MIMEPartsWithBoundary (string boundary, NSData fullDocumentData);

		// +(void)searchData:(NSData *)data targetBytes:(const void *)targetBytes targetLength:(NSUInteger)targetLength foundOffsets:(NSArray<NSNumber *> **)outFoundOffsets;
		//[Static]
		//[Export ("searchData:targetBytes:targetLength:foundOffsets:")]
		//unsafe void SearchData (NSData data, void* targetBytes, nuint targetLength, out NSNumber[] outFoundOffsets);

		// +(NSDictionary<NSString *,NSString *> *)headersWithData:(NSData *)data;
		[Static]
		[Export ("headersWithData:")]
		NSDictionary<NSString, NSString> HeadersWithData (NSData data);

		// -(void)seedRandomWith:(u_int32_t)seed;
		[Export ("seedRandomWith:")]
		void SeedRandomWith (uint seed);

		// +(NSUInteger)findBytesWithNeedle:(const unsigned char *)needle needleLength:(NSUInteger)needleLength haystack:(const unsigned char *)haystack haystackLength:(NSUInteger)haystackLength foundOffset:(NSUInteger *)foundOffset;
		//[Static]
		//[Export ("findBytesWithNeedle:needleLength:haystack:haystackLength:foundOffset:")]
		//unsafe nuint FindBytesWithNeedle (byte* needle, nuint needleLength, byte* haystack, nuint haystackLength, nuint* foundOffset);

		// +(void)searchData:(NSData *)data targetBytes:(const void *)targetBytes targetLength:(NSUInteger)targetLength foundOffsets:(NSArray<NSNumber *> **)outFoundOffsets foundBlockNumbers:(NSArray<NSNumber *> **)outFoundBlockNumbers;
		//[Static]
		//[Export ("searchData:targetBytes:targetLength:foundOffsets:foundBlockNumbers:")]
		//unsafe void SearchData (NSData data, void* targetBytes, nuint targetLength, out NSNumber[] outFoundOffsets, out NSNumber[] outFoundBlockNumbers);
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const kGTMOAuth2ServiceProviderGoogle;
		[Field ("kGTMOAuth2ServiceProviderGoogle", "__Internal")]
		NSString kGTMOAuth2ServiceProviderGoogle { get; }

		// extern NSString *const kGTMOAuth2ErrorDomain;
		[Field ("kGTMOAuth2ErrorDomain", "__Internal")]
		NSString kGTMOAuth2ErrorDomain { get; }

		// extern NSString *const kGTMOAuth2ErrorMessageKey;
		[Field ("kGTMOAuth2ErrorMessageKey", "__Internal")]
		NSString kGTMOAuth2ErrorMessageKey { get; }

		// extern NSString *const kGTMOAuth2ErrorRequestKey;
		[Field ("kGTMOAuth2ErrorRequestKey", "__Internal")]
		NSString kGTMOAuth2ErrorRequestKey { get; }

		// extern NSString *const kGTMOAuth2ErrorJSONKey;
		[Field ("kGTMOAuth2ErrorJSONKey", "__Internal")]
		NSString kGTMOAuth2ErrorJSONKey { get; }
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const kGTMOAuth2FetchStarted;
		[Field ("kGTMOAuth2FetchStarted", "__Internal")]
		NSString kGTMOAuth2FetchStarted { get; }

		// extern NSString *const kGTMOAuth2FetchStopped;
		[Field ("kGTMOAuth2FetchStopped", "__Internal")]
		NSString kGTMOAuth2FetchStopped { get; }

		// extern NSString *const kGTMOAuth2FetcherKey;
		[Field ("kGTMOAuth2FetcherKey", "__Internal")]
		NSString kGTMOAuth2FetcherKey { get; }

		// extern NSString *const kGTMOAuth2FetchTypeKey;
		[Field ("kGTMOAuth2FetchTypeKey", "__Internal")]
		NSString kGTMOAuth2FetchTypeKey { get; }

		// extern NSString *const kGTMOAuth2FetchTypeToken;
		[Field ("kGTMOAuth2FetchTypeToken", "__Internal")]
		NSString kGTMOAuth2FetchTypeToken { get; }

		// extern NSString *const kGTMOAuth2FetchTypeRefresh;
		[Field ("kGTMOAuth2FetchTypeRefresh", "__Internal")]
		NSString kGTMOAuth2FetchTypeRefresh { get; }

		// extern NSString *const kGTMOAuth2FetchTypeAssertion;
		[Field ("kGTMOAuth2FetchTypeAssertion", "__Internal")]
		NSString kGTMOAuth2FetchTypeAssertion { get; }

		// extern NSString *const kGTMOAuth2FetchTypeUserInfo;
		[Field ("kGTMOAuth2FetchTypeUserInfo", "__Internal")]
		NSString kGTMOAuth2FetchTypeUserInfo { get; }

		// extern NSString *const kGTMOAuth2ErrorKey;
		[Field ("kGTMOAuth2ErrorKey", "__Internal")]
		NSString kGTMOAuth2ErrorKey { get; }

		// extern NSString *const kGTMOAuth2ErrorObjectKey;
		[Field ("kGTMOAuth2ErrorObjectKey", "__Internal")]
		NSString kGTMOAuth2ErrorObjectKey { get; }

		// extern NSString *const kGTMOAuth2ErrorInvalidRequest;
		[Field ("kGTMOAuth2ErrorInvalidRequest", "__Internal")]
		NSString kGTMOAuth2ErrorInvalidRequest { get; }

		// extern NSString *const kGTMOAuth2ErrorInvalidClient;
		[Field ("kGTMOAuth2ErrorInvalidClient", "__Internal")]
		NSString kGTMOAuth2ErrorInvalidClient { get; }

		// extern NSString *const kGTMOAuth2ErrorInvalidGrant;
		[Field ("kGTMOAuth2ErrorInvalidGrant", "__Internal")]
		NSString kGTMOAuth2ErrorInvalidGrant { get; }

		// extern NSString *const kGTMOAuth2ErrorUnauthorizedClient;
		[Field ("kGTMOAuth2ErrorUnauthorizedClient", "__Internal")]
		NSString kGTMOAuth2ErrorUnauthorizedClient { get; }

		// extern NSString *const kGTMOAuth2ErrorUnsupportedGrantType;
		[Field ("kGTMOAuth2ErrorUnsupportedGrantType", "__Internal")]
		NSString kGTMOAuth2ErrorUnsupportedGrantType { get; }

		// extern NSString *const kGTMOAuth2ErrorInvalidScope;
		[Field ("kGTMOAuth2ErrorInvalidScope", "__Internal")]
		NSString kGTMOAuth2ErrorInvalidScope { get; }

		// extern NSString *const kGTMOAuth2UserSignedIn;
		[Field ("kGTMOAuth2UserSignedIn", "__Internal")]
		NSString kGTMOAuth2UserSignedIn { get; }

		// extern NSString *const kGTMOAuth2AccessTokenRefreshed;
		[Field ("kGTMOAuth2AccessTokenRefreshed", "__Internal")]
		NSString kGTMOAuth2AccessTokenRefreshed { get; }

		// extern NSString *const kGTMOAuth2RefreshTokenChanged;
		[Field ("kGTMOAuth2RefreshTokenChanged", "__Internal")]
		NSString kGTMOAuth2RefreshTokenChanged { get; }

		// extern NSString *const kGTMOAuth2AccessTokenRefreshFailed;
		[Field ("kGTMOAuth2AccessTokenRefreshFailed", "__Internal")]
		NSString kGTMOAuth2AccessTokenRefreshFailed { get; }

		// extern NSString *const kGTMOAuth2WebViewStartedLoading;
		[Field ("kGTMOAuth2WebViewStartedLoading", "__Internal")]
		NSString kGTMOAuth2WebViewStartedLoading { get; }

		// extern NSString *const kGTMOAuth2WebViewStoppedLoading;
		[Field ("kGTMOAuth2WebViewStoppedLoading", "__Internal")]
		NSString kGTMOAuth2WebViewStoppedLoading { get; }

		// extern NSString *const kGTMOAuth2WebViewKey;
		[Field ("kGTMOAuth2WebViewKey", "__Internal")]
		NSString kGTMOAuth2WebViewKey { get; }

		// extern NSString *const kGTMOAuth2WebViewStopKindKey;
		[Field ("kGTMOAuth2WebViewStopKindKey", "__Internal")]
		NSString kGTMOAuth2WebViewStopKindKey { get; }

		// extern NSString *const kGTMOAuth2WebViewFinished;
		[Field ("kGTMOAuth2WebViewFinished", "__Internal")]
		NSString kGTMOAuth2WebViewFinished { get; }

		// extern NSString *const kGTMOAuth2WebViewFailed;
		[Field ("kGTMOAuth2WebViewFailed", "__Internal")]
		NSString kGTMOAuth2WebViewFailed { get; }

		// extern NSString *const kGTMOAuth2WebViewCancelled;
		[Field ("kGTMOAuth2WebViewCancelled", "__Internal")]
		NSString kGTMOAuth2WebViewCancelled { get; }

		// extern NSString *const kGTMOAuth2NetworkLost;
		[Field ("kGTMOAuth2NetworkLost", "__Internal")]
		NSString kGTMOAuth2NetworkLost { get; }

		// extern NSString *const kGTMOAuth2NetworkFound;
		[Field ("kGTMOAuth2NetworkFound", "__Internal")]
		NSString kGTMOAuth2NetworkFound { get; }
	}

	// @interface GTMOAuth2Authentication : NSObject <GTMFetcherAuthorizationProtocol>
	[BaseType (typeof(NSObject))]
	interface GTMOAuth2Authentication : IGTMFetcherAuthorizationProtocol
	{
		// @property (copy, atomic) NSString * clientID;
		[Export ("clientID")]
		string ClientID { get; set; }

		// @property (copy, atomic) NSString * clientSecret;
		[Export ("clientSecret")]
		string ClientSecret { get; set; }

		// @property (copy, atomic) NSString * redirectURI;
		[Export ("redirectURI")]
		string RedirectURI { get; set; }

		// @property (retain, atomic) NSString * scope;
		[Export ("scope", ArgumentSemantic.Retain)]
		string Scope { get; set; }

		// @property (retain, atomic) NSString * tokenType;
		[Export ("tokenType", ArgumentSemantic.Retain)]
		string TokenType { get; set; }

		// @property (retain, atomic) NSString * assertion;
		[Export ("assertion", ArgumentSemantic.Retain)]
		string Assertion { get; set; }

		// @property (retain, atomic) NSString * refreshScope;
		[Export ("refreshScope", ArgumentSemantic.Retain)]
		string RefreshScope { get; set; }

		// @property (retain, atomic) NSDictionary * additionalTokenRequestParameters;
		[Export ("additionalTokenRequestParameters", ArgumentSemantic.Retain)]
		NSDictionary AdditionalTokenRequestParameters { get; set; }

		// @property (retain, atomic) NSDictionary * additionalGrantTypeRequestParameters;
		[Export ("additionalGrantTypeRequestParameters", ArgumentSemantic.Retain)]
		NSDictionary AdditionalGrantTypeRequestParameters { get; set; }

		// @property (readonly, atomic) NSDictionary * parameters;
		[Export ("parameters")]
		NSDictionary Parameters { get; }

		// @property (retain, atomic) NSString * accessToken;
		[Export ("accessToken", ArgumentSemantic.Retain)]
		string AccessToken { get; set; }

		// @property (retain, atomic) NSString * refreshToken;
		[Export ("refreshToken", ArgumentSemantic.Retain)]
		string RefreshToken { get; set; }

		// @property (retain, atomic) NSNumber * expiresIn;
		[Export ("expiresIn", ArgumentSemantic.Retain)]
		NSNumber ExpiresIn { get; set; }

		// @property (retain, atomic) NSString * code;
		[Export ("code", ArgumentSemantic.Retain)]
		string Code { get; set; }

		// @property (retain, atomic) NSString * errorString;
		[Export ("errorString", ArgumentSemantic.Retain)]
		string ErrorString { get; set; }

		// @property (copy, atomic) NSURL * tokenURL;
		[Export ("tokenURL", ArgumentSemantic.Copy)]
		NSUrl TokenURL { get; set; }

		// @property (copy, atomic) NSDate * expirationDate;
		[Export ("expirationDate", ArgumentSemantic.Copy)]
		NSDate ExpirationDate { get; set; }

		// @property (copy, atomic) NSString * serviceProvider;
		[Export ("serviceProvider")]
		string ServiceProvider { get; set; }

		// @property (retain) NSString * userID;
		[Export ("userID", ArgumentSemantic.Retain)]
		string UserID { get; set; }

		// @property (retain, atomic) NSString * userEmail;
		[Export ("userEmail", ArgumentSemantic.Retain)]
		string UserEmail { get; set; }

		// @property (retain, atomic) NSString * userEmailIsVerified;
		[Export ("userEmailIsVerified", ArgumentSemantic.Retain)]
		string UserEmailIsVerified { get; set; }

		// @property (readonly, atomic) BOOL canAuthorize;
		[Export ("canAuthorize")]
		bool CanAuthorize { get; }

		// @property (assign, atomic) BOOL shouldAuthorizeAllRequests;
		[Export ("shouldAuthorizeAllRequests")]
		bool ShouldAuthorizeAllRequests { get; set; }

		// @property (retain, atomic) id userData;
		[Export ("userData", ArgumentSemantic.Retain)]
		NSObject UserData { get; set; }

		// @property (retain, atomic) NSDictionary * properties;
		[Export ("properties", ArgumentSemantic.Retain)]
		NSDictionary Properties { get; set; }

		// @property (assign, atomic) id<GTMSessionFetcherServiceProtocol> fetcherService;
		[Export ("fetcherService", ArgumentSemantic.Assign)]
		GTMSessionFetcherServiceProtocol FetcherService { get; set; }

		// @property (copy, atomic) NSString * authorizationTokenKey;
		[Export ("authorizationTokenKey")]
		string AuthorizationTokenKey { get; set; }

		// +(id)authenticationWithServiceProvider:(NSString *)serviceProvider tokenURL:(NSURL *)tokenURL redirectURI:(NSString *)redirectURI clientID:(NSString *)clientID clientSecret:(NSString *)clientSecret;
		[Static]
		[Export ("authenticationWithServiceProvider:tokenURL:redirectURI:clientID:clientSecret:")]
		NSObject AuthenticationWithServiceProvider (string serviceProvider, NSUrl tokenURL, string redirectURI, string clientID, string clientSecret);

		// -(void)reset;
		[Export ("reset")]
		void Reset ();

		// -(void)authorizeRequest:(NSMutableURLRequest *)request delegate:(id)delegate didFinishSelector:(SEL)sel;
		[Export ("authorizeRequest:delegate:didFinishSelector:")]
		void AuthorizeRequest (NSMutableUrlRequest request, NSObject @delegate, Selector sel);

		// -(void)authorizeRequest:(NSMutableURLRequest *)request completionHandler:(void (^)(NSError *))handler;
		[Export ("authorizeRequest:completionHandler:")]
		void AuthorizeRequest (NSMutableUrlRequest request, Action<NSError> handler);

		// -(BOOL)authorizeRequest:(NSMutableURLRequest *)request;
		[Export ("authorizeRequest:")]
		bool AuthorizeRequest (NSMutableUrlRequest request);

		// -(void)waitForCompletionWithTimeout:(NSTimeInterval)timeoutInSeconds;
		[Export ("waitForCompletionWithTimeout:")]
		void WaitForCompletionWithTimeout (double timeoutInSeconds);

		// @property (retain, atomic) GTMSessionFetcher * refreshFetcher;
		[Export ("refreshFetcher", ArgumentSemantic.Retain)]
        GTMSessionFetcher.GTMSessionFetcher RefreshFetcher { get; set; }

		// -(BOOL)isAuthorizingRequest:(NSURLRequest *)request;
		[Export ("isAuthorizingRequest:")]
		bool IsAuthorizingRequest (NSUrlRequest request);

		// -(BOOL)isAuthorizedRequest:(NSURLRequest *)request;
		[Export ("isAuthorizedRequest:")]
		bool IsAuthorizedRequest (NSUrlRequest request);

		// -(void)stopAuthorization;
		[Export ("stopAuthorization")]
		void StopAuthorization ();

		// -(void)stopAuthorizationForRequest:(NSURLRequest *)request;
		[Export ("stopAuthorizationForRequest:")]
		void StopAuthorizationForRequest (NSUrlRequest request);

		// -(NSString *)userAgent;
		[Export ("userAgent")]
		//[Verify (MethodToProperty)]
		string UserAgent { get; }

		// -(void)setKeysForResponseString:(NSString *)str;
		[Export ("setKeysForResponseString:")]
		void SetKeysForResponseString (string str);

		// -(void)setKeysForResponseDictionary:(NSDictionary *)dict;
		[Export ("setKeysForResponseDictionary:")]
		void SetKeysForResponseDictionary (NSDictionary dict);

		// -(NSString *)persistenceResponseString;
		[Export ("persistenceResponseString")]
		//[Verify (MethodToProperty)]
		string PersistenceResponseString { get; }

		// -(void)setKeysForPersistenceResponseString:(NSString *)str;
		[Export ("setKeysForPersistenceResponseString:")]
		void SetKeysForPersistenceResponseString (string str);

		// -(GTMSessionFetcher *)beginTokenFetchWithDelegate:(id)delegate didFinishSelector:(SEL)finishedSel;
		[Export ("beginTokenFetchWithDelegate:didFinishSelector:")]
		GTMSessionFetcher.GTMSessionFetcher BeginTokenFetchWithDelegate (NSObject @delegate, Selector finishedSel);

		// -(void)notifyFetchIsRunning:(BOOL)isStarting fetcher:(GTMSessionFetcher *)fetcher type:(NSString *)fetchType;
		[Export ("notifyFetchIsRunning:fetcher:type:")]
		void NotifyFetchIsRunning (bool isStarting, GTMSessionFetcher.GTMSessionFetcher fetcher, string fetchType);

		// -(void)setProperty:(id)obj forKey:(NSString *)key;
		[Export ("setProperty:forKey:")]
		void SetProperty (NSObject obj, string key);

		// -(id)propertyForKey:(NSString *)key;
		[Export ("propertyForKey:")]
		NSObject PropertyForKey (string key);

		// +(NSString *)encodedOAuthValueForString:(NSString *)str;
		[Static]
		[Export ("encodedOAuthValueForString:")]
		string EncodedOAuthValueForString (string str);

		// +(NSString *)encodedQueryParametersForDictionary:(NSDictionary *)dict;
		[Static]
		[Export ("encodedQueryParametersForDictionary:")]
		string EncodedQueryParametersForDictionary (NSDictionary dict);

		// +(NSDictionary *)dictionaryWithResponseString:(NSString *)responseStr;
		[Static]
		[Export ("dictionaryWithResponseString:")]
		NSDictionary DictionaryWithResponseString (string responseStr);

		// +(NSDictionary *)dictionaryWithJSONData:(NSData *)data;
		[Static]
		[Export ("dictionaryWithJSONData:")]
		NSDictionary DictionaryWithJSONData (NSData data);

		// +(NSString *)scopeWithStrings:(NSString *)firstStr, ... __attribute__((sentinel(0, 1)));
		[Static, Internal]
		[Export ("scopeWithStrings:", IsVariadic = true)]
		string ScopeWithStrings (string firstStr, IntPtr varArgs);
	}

	// @interface GTMOAuth2SignIn : NSObject
	[BaseType (typeof(NSObject))]
	interface GTMOAuth2SignIn
	{
		// @property (retain, nonatomic) GTMOAuth2Authentication * authentication;
		[Export ("authentication", ArgumentSemantic.Retain)]
		GTMOAuth2Authentication Authentication { get; set; }

		// @property (retain, nonatomic) NSURL * authorizationURL;
		[Export ("authorizationURL", ArgumentSemantic.Retain)]
		NSUrl AuthorizationURL { get; set; }

		// @property (retain, nonatomic) NSDictionary * additionalAuthorizationParameters;
		[Export ("additionalAuthorizationParameters", ArgumentSemantic.Retain)]
		NSDictionary AdditionalAuthorizationParameters { get; set; }

		[Wrap ("WeakDelegate")]
		NSObject Delegate { get; set; }

		// @property (retain, nonatomic) id delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Retain)]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) SEL webRequestSelector;
		[Export ("webRequestSelector", ArgumentSemantic.Assign)]
		Selector WebRequestSelector { get; set; }

		// @property (assign, nonatomic) SEL finishedSelector;
		[Export ("finishedSelector", ArgumentSemantic.Assign)]
		Selector FinishedSelector { get; set; }

		// @property (retain, nonatomic) id userData;
		[Export ("userData", ArgumentSemantic.Retain)]
		NSObject UserData { get; set; }

		// @property (assign, nonatomic) BOOL shouldFetchGoogleUserEmail;
		[Export ("shouldFetchGoogleUserEmail")]
		bool ShouldFetchGoogleUserEmail { get; set; }

		// @property (assign, nonatomic) BOOL shouldFetchGoogleUserProfile;
		[Export ("shouldFetchGoogleUserProfile")]
		bool ShouldFetchGoogleUserProfile { get; set; }

		// @property (readonly, retain, nonatomic) NSDictionary * userProfile;
		[Export ("userProfile", ArgumentSemantic.Retain)]
		NSDictionary UserProfile { get; }

		// @property (assign, nonatomic) NSTimeInterval networkLossTimeoutInterval;
		[Export ("networkLossTimeoutInterval")]
		double NetworkLossTimeoutInterval { get; set; }

		// -(id)initWithAuthentication:(GTMOAuth2Authentication *)auth authorizationURL:(NSURL *)authorizationURL delegate:(id)delegate webRequestSelector:(SEL)webRequestSelector finishedSelector:(SEL)finishedSelector;
		[Export ("initWithAuthentication:authorizationURL:delegate:webRequestSelector:finishedSelector:")]
		IntPtr Constructor (GTMOAuth2Authentication auth, NSUrl authorizationURL, NSObject @delegate, Selector webRequestSelector, Selector finishedSelector);

		// +(GTMOAuth2Authentication *)standardGoogleAuthenticationForScope:(NSString *)scope clientID:(NSString *)clientID clientSecret:(NSString *)clientSecret;
		[Static]
		[Export ("standardGoogleAuthenticationForScope:clientID:clientSecret:")]
		GTMOAuth2Authentication StandardGoogleAuthenticationForScope (string scope, string clientID, string clientSecret);

        // -(BOOL)startSigningIn;
        [Export("startSigningIn")]
        //[Verify (MethodToProperty)]
        bool StartSigningIn();

		// -(void)cancelSigningIn;
		[Export ("cancelSigningIn")]
		void CancelSigningIn ();

		// -(BOOL)requestRedirectedToRequest:(NSURLRequest *)redirectedRequest;
		[Export ("requestRedirectedToRequest:")]
		bool RequestRedirectedToRequest (NSUrlRequest redirectedRequest);

		// -(BOOL)titleChanged:(NSString *)title;
		[Export ("titleChanged:")]
		bool TitleChanged (string title);

		// -(BOOL)cookiesChanged:(NSHTTPCookieStorage *)cookieStorage;
		[Export ("cookiesChanged:")]
		bool CookiesChanged (NSHttpCookieStorage cookieStorage);

		// -(BOOL)loadFailedWithError:(NSError *)error;
		[Export ("loadFailedWithError:")]
		bool LoadFailedWithError (NSError error);

		// -(void)windowWasClosed;
		[Export ("windowWasClosed")]
		void WindowWasClosed ();

		// -(void)authCodeObtained;
		[Export ("authCodeObtained")]
		void AuthCodeObtained ();

		// +(void)revokeTokenForGoogleAuthentication:(GTMOAuth2Authentication *)auth;
		[Static]
		[Export ("revokeTokenForGoogleAuthentication:")]
		void RevokeTokenForGoogleAuthentication (GTMOAuth2Authentication auth);

		// +(GTMSessionFetcher *)userInfoFetcherWithAuth:(GTMOAuth2Authentication *)auth;
		[Static]
		[Export ("userInfoFetcherWithAuth:")]
		GTMSessionFetcher.GTMSessionFetcher UserInfoFetcherWithAuth (GTMOAuth2Authentication auth);

		// +(NSData *)decodeWebSafeBase64:(NSString *)base64Str;
		[Static]
		[Export ("decodeWebSafeBase64:")]
		NSData DecodeWebSafeBase64 (string base64Str);

		// +(NSString *)nativeClientRedirectURI;
		[Static]
		[Export ("nativeClientRedirectURI")]
		//[Verify (MethodToProperty)]
		string NativeClientRedirectURI { get; }

		// +(NSURL *)googleAuthorizationURL;
		[Static]
		[Export ("googleAuthorizationURL")]
		//[Verify (MethodToProperty)]
		NSUrl GoogleAuthorizationURL { get; }

		// +(NSURL *)googleTokenURL;
		[Static]
		[Export ("googleTokenURL")]
		//[Verify (MethodToProperty)]
		NSUrl GoogleTokenURL { get; }

		// +(NSURL *)googleUserInfoURL;
		[Static]
		[Export ("googleUserInfoURL")]
		//[Verify (MethodToProperty)]
		NSUrl GoogleUserInfoURL { get; }
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const kGTMOAuth2KeychainErrorDomain;
		[Field ("kGTMOAuth2KeychainErrorDomain", "__Internal")]
		NSString kGTMOAuth2KeychainErrorDomain { get; }

		// extern NSString *const kGTMOAuth2CookiesWillSwapOut;
		[Field ("kGTMOAuth2CookiesWillSwapOut", "__Internal")]
		NSString kGTMOAuth2CookiesWillSwapOut { get; }

		// extern NSString *const kGTMOAuth2CookiesDidSwapIn;
		[Field ("kGTMOAuth2CookiesDidSwapIn", "__Internal")]
		NSString kGTMOAuth2CookiesDidSwapIn { get; }
	}

	// typedef void (^GTMOAuth2ViewControllerCompletionHandler)(GTMOAuth2ViewControllerTouch *, GTMOAuth2Authentication *, NSError *);
	delegate void GTMOAuth2ViewControllerCompletionHandler (GTMOAuth2ViewControllerTouch arg0, GTMOAuth2Authentication arg1, NSError arg2);

	// @interface GTMOAuth2ViewControllerTouch : UIViewController <UINavigationControllerDelegate, UIWebViewDelegate>
	[BaseType (typeof(UIViewController))]
	interface GTMOAuth2ViewControllerTouch : IUINavigationControllerDelegate, IUIWebViewDelegate
	{
		// @property (copy, nonatomic) NSString * keychainItemName;
		[Export ("keychainItemName")]
		string KeychainItemName { get; set; }

		//// @property (assign, nonatomic) CFTypeRef keychainItemAccessibility;
		//[Export ("keychainItemAccessibility", ArgumentSemantic.Assign)]
		//unsafe void* KeychainItemAccessibility { get; set; }

		// @property (copy, nonatomic) NSString * initialHTMLString;
		[Export ("initialHTMLString")]
		string InitialHTMLString { get; set; }

		// @property (assign, nonatomic) BOOL showsInitialActivityIndicator;
		[Export ("showsInitialActivityIndicator")]
		bool ShowsInitialActivityIndicator { get; set; }

		// @property (readonly, retain, nonatomic) GTMOAuth2Authentication * authentication;
		[Export ("authentication", ArgumentSemantic.Retain)]
		GTMOAuth2Authentication Authentication { get; }

		// @property (readonly, retain, nonatomic) GTMOAuth2SignIn * signIn;
		[Export ("signIn", ArgumentSemantic.Retain)]
		GTMOAuth2SignIn SignIn { get; }

		// @property (retain, nonatomic) UIButton * backButton __attribute__((iboutlet));
		[Export ("backButton", ArgumentSemantic.Retain)]
		UIButton BackButton { get; set; }

		// @property (retain, nonatomic) UIButton * forwardButton __attribute__((iboutlet));
		[Export ("forwardButton", ArgumentSemantic.Retain)]
		UIButton ForwardButton { get; set; }

		// @property (retain, nonatomic) UIActivityIndicatorView * initialActivityIndicator __attribute__((iboutlet));
		[Export ("initialActivityIndicator", ArgumentSemantic.Retain)]
		UIActivityIndicatorView InitialActivityIndicator { get; set; }

		// @property (retain, nonatomic) UIView * navButtonsView __attribute__((iboutlet));
		[Export ("navButtonsView", ArgumentSemantic.Retain)]
		UIView NavButtonsView { get; set; }

		// @property (retain, nonatomic) UIBarButtonItem * rightBarButtonItem __attribute__((iboutlet));
		[Export ("rightBarButtonItem", ArgumentSemantic.Retain)]
		UIBarButtonItem RightBarButtonItem { get; set; }

		// @property (retain, nonatomic) UIWebView * webView __attribute__((iboutlet));
		[Export ("webView", ArgumentSemantic.Retain)]
		UIWebView WebView { get; set; }

		// @property (copy, nonatomic) void (^popViewBlock)();
		[Export ("popViewBlock", ArgumentSemantic.Copy)]
		Action PopViewBlock { get; set; }

		// @property (assign, nonatomic) NSTimeInterval networkLossTimeoutInterval;
		[Export ("networkLossTimeoutInterval")]
		double NetworkLossTimeoutInterval { get; set; }

		// @property (retain, nonatomic) NSURL * browserCookiesURL;
		[Export ("browserCookiesURL", ArgumentSemantic.Retain)]
		NSUrl BrowserCookiesURL { get; set; }

		// @property (retain, nonatomic) id userData;
		[Export ("userData", ArgumentSemantic.Retain)]
		NSObject UserData { get; set; }

		// -(void)setProperty:(id)obj forKey:(NSString *)key;
		[Export ("setProperty:forKey:")]
		void SetProperty (NSObject obj, string key);

		// -(id)propertyForKey:(NSString *)key;
		[Export ("propertyForKey:")]
		NSObject PropertyForKey (string key);

		// @property (retain, nonatomic) NSDictionary * properties;
		[Export ("properties", ArgumentSemantic.Retain)]
		NSDictionary Properties { get; set; }

		// +(id)controllerWithScope:(NSString *)scope clientID:(NSString *)clientID clientSecret:(NSString *)clientSecret keychainItemName:(NSString *)keychainItemName delegate:(id)delegate finishedSelector:(SEL)finishedSelector;
		[Static]
		[Export ("controllerWithScope:clientID:clientSecret:keychainItemName:delegate:finishedSelector:")]
		NSObject ControllerWithScope (string scope, string clientID, string clientSecret, string keychainItemName, NSObject @delegate, Selector finishedSelector);

		// -(id)initWithScope:(NSString *)scope clientID:(NSString *)clientID clientSecret:(NSString *)clientSecret keychainItemName:(NSString *)keychainItemName delegate:(id)delegate finishedSelector:(SEL)finishedSelector;
		[Export ("initWithScope:clientID:clientSecret:keychainItemName:delegate:finishedSelector:")]
		IntPtr Constructor (string scope, string clientID, string clientSecret, string keychainItemName, NSObject @delegate, Selector finishedSelector);

		// +(id)controllerWithScope:(NSString *)scope clientID:(NSString *)clientID clientSecret:(NSString *)clientSecret keychainItemName:(NSString *)keychainItemName completionHandler:(GTMOAuth2ViewControllerCompletionHandler)handler;
		[Static]
		[Export ("controllerWithScope:clientID:clientSecret:keychainItemName:completionHandler:")]
		NSObject ControllerWithScope (string scope, string clientID, string clientSecret, string keychainItemName, GTMOAuth2ViewControllerCompletionHandler handler);

		// -(id)initWithScope:(NSString *)scope clientID:(NSString *)clientID clientSecret:(NSString *)clientSecret keychainItemName:(NSString *)keychainItemName completionHandler:(GTMOAuth2ViewControllerCompletionHandler)handler;
		[Export ("initWithScope:clientID:clientSecret:keychainItemName:completionHandler:")]
		IntPtr Constructor (string scope, string clientID, string clientSecret, string keychainItemName, GTMOAuth2ViewControllerCompletionHandler handler);

		// +(id)controllerWithAuthentication:(GTMOAuth2Authentication *)auth authorizationURL:(NSURL *)authorizationURL keychainItemName:(NSString *)keychainItemName delegate:(id)delegate finishedSelector:(SEL)finishedSelector;
		[Static]
		[Export ("controllerWithAuthentication:authorizationURL:keychainItemName:delegate:finishedSelector:")]
		NSObject ControllerWithAuthentication (GTMOAuth2Authentication auth, NSUrl authorizationURL, string keychainItemName, NSObject @delegate, Selector finishedSelector);

		// -(id)initWithAuthentication:(GTMOAuth2Authentication *)auth authorizationURL:(NSURL *)authorizationURL keychainItemName:(NSString *)keychainItemName delegate:(id)delegate finishedSelector:(SEL)finishedSelector;
		[Export ("initWithAuthentication:authorizationURL:keychainItemName:delegate:finishedSelector:")]
		IntPtr Constructor (GTMOAuth2Authentication auth, NSUrl authorizationURL, string keychainItemName, NSObject @delegate, Selector finishedSelector);

		// +(id)controllerWithAuthentication:(GTMOAuth2Authentication *)auth authorizationURL:(NSURL *)authorizationURL keychainItemName:(NSString *)keychainItemName completionHandler:(GTMOAuth2ViewControllerCompletionHandler)handler;
		[Static]
		[Export ("controllerWithAuthentication:authorizationURL:keychainItemName:completionHandler:")]
		NSObject ControllerWithAuthentication (GTMOAuth2Authentication auth, NSUrl authorizationURL, string keychainItemName, GTMOAuth2ViewControllerCompletionHandler handler);

		// -(id)initWithAuthentication:(GTMOAuth2Authentication *)auth authorizationURL:(NSURL *)authorizationURL keychainItemName:(NSString *)keychainItemName completionHandler:(GTMOAuth2ViewControllerCompletionHandler)handler;
		[Export ("initWithAuthentication:authorizationURL:keychainItemName:completionHandler:")]
		IntPtr Constructor (GTMOAuth2Authentication auth, NSUrl authorizationURL, string keychainItemName, GTMOAuth2ViewControllerCompletionHandler handler);

		// +(NSString *)authNibName;
		[Static]
		[Export ("authNibName")]
		//[Verify (MethodToProperty)]
		string AuthNibName { get; }

		// +(NSBundle *)authNibBundle;
		[Static]
		[Export ("authNibBundle")]
		//[Verify (MethodToProperty)]
		NSBundle AuthNibBundle { get; }

		// -(void)setUpNavigation;
		[Export ("setUpNavigation")]
		void SetUpNavigation ();

		// -(void)swapOutCookies;
		[Export ("swapOutCookies")]
		void SwapOutCookies ();

		// -(void)swapInCookies;
		[Export ("swapInCookies")]
		void SwapInCookies ();

		// -(NSHTTPCookieStorage *)systemCookieStorage;
		[Export ("systemCookieStorage")]
		//[Verify (MethodToProperty)]
		NSHttpCookieStorage SystemCookieStorage { get; }

		// +(Class)signInClass;
		// +(void)setSignInClass:(Class)theClass;
		[Static]
		[Export ("signInClass")]
		//[Verify (MethodToProperty)]
		Class SignInClass { get; set; }

		// -(void)cancelSigningIn;
		[Export ("cancelSigningIn")]
		void CancelSigningIn ();

		// +(void)revokeTokenForGoogleAuthentication:(GTMOAuth2Authentication *)auth;
		[Static]
		[Export ("revokeTokenForGoogleAuthentication:")]
		void RevokeTokenForGoogleAuthentication (GTMOAuth2Authentication auth);

		// +(GTMOAuth2Authentication *)authForGoogleFromKeychainForName:(NSString *)keychainItemName clientID:(NSString *)clientID clientSecret:(NSString *)clientSecret error:(NSError **)error;
		[Static]
		[Export ("authForGoogleFromKeychainForName:clientID:clientSecret:error:")]
		GTMOAuth2Authentication AuthForGoogleFromKeychainForName (string keychainItemName, string clientID, string clientSecret, out NSError error);

		// +(GTMOAuth2Authentication *)authForGoogleFromKeychainForName:(NSString *)keychainItemName clientID:(NSString *)clientID clientSecret:(NSString *)clientSecret;
		[Static]
		[Export ("authForGoogleFromKeychainForName:clientID:clientSecret:")]
		GTMOAuth2Authentication AuthForGoogleFromKeychainForName (string keychainItemName, string clientID, string clientSecret);

		// +(BOOL)authorizeFromKeychainForName:(NSString *)keychainItemName authentication:(GTMOAuth2Authentication *)auth error:(NSError **)error;
		[Static]
		[Export ("authorizeFromKeychainForName:authentication:error:")]
		bool AuthorizeFromKeychainForName (string keychainItemName, GTMOAuth2Authentication auth, out NSError error);

		// +(BOOL)removeAuthFromKeychainForName:(NSString *)keychainItemName;
		[Static]
		[Export ("removeAuthFromKeychainForName:")]
		bool RemoveAuthFromKeychainForName (string keychainItemName);

		// +(BOOL)saveParamsToKeychainForName:(NSString *)keychainItemName accessibility:(CFTypeRef)accessibility authentication:(GTMOAuth2Authentication *)auth error:(NSError **)error;
		//[Static]
		//[Export ("saveParamsToKeychainForName:accessibility:authentication:error:")]
		//unsafe bool SaveParamsToKeychainForName (string keychainItemName, void* accessibility, GTMOAuth2Authentication auth, out NSError error);

		// +(BOOL)saveParamsToKeychainForName:(NSString *)keychainItemName authentication:(GTMOAuth2Authentication *)auth;
		[Static]
		[Export ("saveParamsToKeychainForName:authentication:")]
		bool SaveParamsToKeychainForName (string keychainItemName, GTMOAuth2Authentication auth);
	}

	// @interface GTMOAuth2Keychain : NSObject
	[BaseType (typeof(NSObject))]
	interface GTMOAuth2Keychain
	{
		// +(GTMOAuth2Keychain *)defaultKeychain;
		// +(void)setDefaultKeychain:(GTMOAuth2Keychain *)keychain;
		[Static]
		[Export ("defaultKeychain")]
		//[Verify (MethodToProperty)]
		GTMOAuth2Keychain DefaultKeychain { get; set; }

		// -(NSString *)passwordForService:(NSString *)service account:(NSString *)account error:(NSError **)error;
		[Export ("passwordForService:account:error:")]
		string PasswordForService (string service, string account, out NSError error);

		// -(BOOL)removePasswordForService:(NSString *)service account:(NSString *)account error:(NSError **)error;
		[Export ("removePasswordForService:account:error:")]
		bool RemovePasswordForService (string service, string account, out NSError error);

		// -(BOOL)setPassword:(NSString *)password forService:(NSString *)service accessibility:(CFTypeRef)accessibility account:(NSString *)account error:(NSError **)error;
		//[Export ("setPassword:forService:accessibility:account:error:")]
		//unsafe bool SetPassword (string password, string service, void* accessibility, string account, out NSError error);
	}

	// @interface GTMReadMonitorInputStream : NSInputStream <NSStreamDelegate>
	[BaseType (typeof(NSInputStream))]
	interface GTMReadMonitorInputStream : INSStreamDelegate
	{
		// +(instancetype)inputStreamWithStream:(NSInputStream *)input __attribute__((nonnull(0)));
		[Static]
		[Export ("inputStreamWithStream:")]
		GTMReadMonitorInputStream InputStreamWithStream (NSInputStream input);

		// -(instancetype)initWithStream:(NSInputStream *)input __attribute__((nonnull(0)));
		[Export ("initWithStream:")]
		IntPtr Constructor (NSInputStream input);

		[Wrap ("WeakReadDelegate")]
		NSObject ReadDelegate { get; set; }

		// @property (atomic, weak) id readDelegate;
		[NullAllowed, Export ("readDelegate", ArgumentSemantic.Weak)]
		NSObject WeakReadDelegate { get; set; }

		// @property (assign, atomic) SEL readSelector;
		[Export ("readSelector", ArgumentSemantic.Assign)]
		Selector ReadSelector { get; set; }

		// @property (atomic, strong) NSArray * runLoopModes;
		[Export ("runLoopModes", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] RunLoopModes { get; set; }
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull kGTMSessionFetcherServiceSessionBecameInvalidNotification;
		[Field ("kGTMSessionFetcherServiceSessionBecameInvalidNotification", "__Internal")]
		NSString kGTMSessionFetcherServiceSessionBecameInvalidNotification { get; }

		// extern NSString *const _Nonnull kGTMSessionFetcherServiceSessionKey;
		[Field ("kGTMSessionFetcherServiceSessionKey", "__Internal")]
		NSString kGTMSessionFetcherServiceSessionKey { get; }
	}

	// @interface GTMSessionFetcherService : NSObject <GTMSessionFetcherServiceProtocol>
	[BaseType (typeof(NSObject))]
	interface GTMSessionFetcherService : IGTMSessionFetcherServiceProtocol
	{
		// @property (readonly, atomic, strong) NSDictionary<NSString *,NSArray *> * _Nullable delayedFetchersByHost;
		[NullAllowed, Export ("delayedFetchersByHost", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSArray> DelayedFetchersByHost { get; }

		// @property (readonly, atomic, strong) NSDictionary<NSString *,NSArray *> * _Nullable runningFetchersByHost;
		[NullAllowed, Export ("runningFetchersByHost", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSArray> RunningFetchersByHost { get; }

		// @property (assign, atomic) NSUInteger maxRunningFetchersPerHost;
		[Export ("maxRunningFetchersPerHost")]
		nuint MaxRunningFetchersPerHost { get; set; }

		// @property (atomic, strong) NSURLSessionConfiguration * _Nullable configuration;
		[NullAllowed, Export ("configuration", ArgumentSemantic.Strong)]
		NSUrlSessionConfiguration Configuration { get; set; }

		// @property (copy, atomic) GTMSessionFetcherConfigurationBlock _Nullable configurationBlock;
		[NullAllowed, Export ("configurationBlock", ArgumentSemantic.Copy)]
		GTMSessionFetcherConfigurationBlock ConfigurationBlock { get; set; }

		// @property (atomic, strong) NSHTTPCookieStorage * _Nullable cookieStorage;
		[NullAllowed, Export ("cookieStorage", ArgumentSemantic.Strong)]
		NSHttpCookieStorage CookieStorage { get; set; }

		// @property (atomic, strong) dispatch_queue_t _Null_unspecified callbackQueue;
		[Export ("callbackQueue", ArgumentSemantic.Strong)]
		DispatchQueue CallbackQueue { get; set; }

		// @property (copy, atomic) GTMSessionFetcherChallengeBlock _Nullable challengeBlock;
		//[NullAllowed, Export ("challengeBlock", ArgumentSemantic.Copy)]
		//GTMSessionFetcherChallengeBlock ChallengeBlock { get; set; }

		// @property (atomic, strong) NSURLCredential * _Nullable credential;
		[NullAllowed, Export ("credential", ArgumentSemantic.Strong)]
		NSUrlCredential Credential { get; set; }

		// @property (atomic, strong) NSURLCredential * _Nonnull proxyCredential;
		[Export ("proxyCredential", ArgumentSemantic.Strong)]
		NSUrlCredential ProxyCredential { get; set; }

		// @property (copy, atomic) NSArray<NSString *> * _Nullable allowedInsecureSchemes;
		[NullAllowed, Export ("allowedInsecureSchemes", ArgumentSemantic.Copy)]
		string[] AllowedInsecureSchemes { get; set; }

		// @property (assign, atomic) BOOL allowLocalhostRequest;
		[Export ("allowLocalhostRequest")]
		bool AllowLocalhostRequest { get; set; }

		// @property (assign, atomic) BOOL allowInvalidServerCertificates;
		[Export ("allowInvalidServerCertificates")]
		bool AllowInvalidServerCertificates { get; set; }

		// @property (getter = isRetryEnabled, assign, atomic) BOOL retryEnabled;
		[Export ("retryEnabled")]
		bool RetryEnabled { [Bind ("isRetryEnabled")] get; set; }

		// @property (copy, atomic) GTMSessionFetcherRetryBlock _Nullable retryBlock;
		//[NullAllowed, Export ("retryBlock", ArgumentSemantic.Copy)]
		//GTMSessionFetcherRetryBlock RetryBlock { get; set; }

		// @property (assign, atomic) NSTimeInterval maxRetryInterval;
		[Export ("maxRetryInterval")]
		double MaxRetryInterval { get; set; }

		// @property (assign, atomic) NSTimeInterval minRetryInterval;
		[Export ("minRetryInterval")]
		double MinRetryInterval { get; set; }

		// @property (copy, atomic) NSDictionary<NSString *,id> * _Nullable properties;
		[NullAllowed, Export ("properties", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Properties { get; set; }

		// @property (assign, atomic) BOOL skipBackgroundTask;
		[Export ("skipBackgroundTask")]
		bool SkipBackgroundTask { get; set; }

		// @property (copy, atomic) NSString * _Nullable userAgent;
		[NullAllowed, Export ("userAgent")]
		string UserAgent { get; set; }

		// @property (atomic, strong) id<GTMFetcherAuthorizationProtocol> _Nullable authorizer;
		[NullAllowed, Export ("authorizer", ArgumentSemantic.Strong)]
		GTMFetcherAuthorizationProtocol Authorizer { get; set; }

		// @property (atomic, strong) NSOperationQueue * _Null_unspecified sessionDelegateQueue;
		[Export ("sessionDelegateQueue", ArgumentSemantic.Strong)]
		NSOperationQueue SessionDelegateQueue { get; set; }

		// @property (assign, atomic) BOOL reuseSession;
		[Export ("reuseSession")]
		bool ReuseSession { get; set; }

		// @property (assign, atomic) NSTimeInterval unusedSessionTimeout;
		[Export ("unusedSessionTimeout")]
		double UnusedSessionTimeout { get; set; }

		// -(void)resetSession;
		[Export ("resetSession")]
		void ResetSession ();

		// -(GTMSessionFetcher * _Nonnull)fetcherWithRequest:(NSURLRequest * _Nonnull)request;
		[Export ("fetcherWithRequest:")]
		GTMSessionFetcher.GTMSessionFetcher FetcherWithRequest (NSUrlRequest request);

		// -(GTMSessionFetcher * _Nonnull)fetcherWithURL:(NSURL * _Nonnull)requestURL;
		[Export ("fetcherWithURL:")]
		GTMSessionFetcher.GTMSessionFetcher FetcherWithURL (NSUrl requestURL);

		// -(GTMSessionFetcher * _Nonnull)fetcherWithURLString:(NSString * _Nonnull)requestURLString;
		[Export ("fetcherWithURLString:")]
		GTMSessionFetcher.GTMSessionFetcher FetcherWithURLString (string requestURLString);

		// -(id _Nonnull)fetcherWithRequest:(NSURLRequest * _Nonnull)request fetcherClass:(Class _Nonnull)fetcherClass;
		[Export ("fetcherWithRequest:fetcherClass:")]
		NSObject FetcherWithRequest (NSUrlRequest request, Class fetcherClass);

		// -(BOOL)isDelayingFetcher:(GTMSessionFetcher * _Nonnull)fetcher;
		[Export ("isDelayingFetcher:")]
		bool IsDelayingFetcher (GTMSessionFetcher.GTMSessionFetcher fetcher);

		// -(NSUInteger)numberOfFetchers;
		[Export ("numberOfFetchers")]
		//[Verify (MethodToProperty)]
		nuint NumberOfFetchers { get; }

		// -(NSUInteger)numberOfRunningFetchers;
		[Export ("numberOfRunningFetchers")]
		//[Verify (MethodToProperty)]
		nuint NumberOfRunningFetchers { get; }

		// -(NSUInteger)numberOfDelayedFetchers;
		[Export ("numberOfDelayedFetchers")]
		//[Verify (MethodToProperty)]
		nuint NumberOfDelayedFetchers { get; }

		// -(NSArray<GTMSessionFetcher *> * _Nullable)issuedFetchers;
		[NullAllowed, Export ("issuedFetchers")]
		//[Verify (MethodToProperty)]
		GTMSessionFetcher.GTMSessionFetcher[] IssuedFetchers { get; }

		// -(NSArray<GTMSessionFetcher *> * _Nullable)issuedFetchersWithRequestURL:(NSURL * _Nonnull)requestURL;
		[Export ("issuedFetchersWithRequestURL:")]
		[return: NullAllowed]
		GTMSessionFetcher.GTMSessionFetcher[] IssuedFetchersWithRequestURL (NSUrl requestURL);

		// -(void)stopAllFetchers;
		[Export ("stopAllFetchers")]
		void StopAllFetchers ();

		// -(NSURLSession * _Nullable)session;
		[NullAllowed, Export ("session")]
		//[Verify (MethodToProperty)]
		NSUrlSession Session { get; }

		// -(NSURLSession * _Nullable)sessionForFetcherCreation;
		[NullAllowed, Export ("sessionForFetcherCreation")]
		//[Verify (MethodToProperty)]
		NSUrlSession SessionForFetcherCreation { get; }

		// -(id<NSURLSessionDelegate> _Nullable)sessionDelegate;
		[NullAllowed, Export ("sessionDelegate")]
		//[Verify (MethodToProperty)]
		NSUrlSessionDelegate SessionDelegate { get; }

		// -(NSDate * _Nullable)stoppedAllFetchersDate;
		[NullAllowed, Export ("stoppedAllFetchersDate")]
		//[Verify (MethodToProperty)]
		NSDate StoppedAllFetchersDate { get; }

		// @property (copy, atomic) GTMSessionFetcherTestBlock _Nullable testBlock;
		//[NullAllowed, Export ("testBlock", ArgumentSemantic.Copy)]
		//GTMSessionFetcherTestBlock TestBlock { get; set; }
	}

	// @interface TestingSupport (GTMSessionFetcherService)
	[Category]
	[BaseType (typeof(GTMSessionFetcherService))]
	interface GTMSessionFetcherService_TestingSupport
	{
		// +(instancetype _Nonnull)mockFetcherServiceWithFakedData:(NSData * _Nullable)fakedDataOrNil fakedError:(NSError * _Nullable)fakedErrorOrNil;
		[Static]
		[Export ("mockFetcherServiceWithFakedData:fakedError:")]
		GTMSessionFetcherService MockFetcherServiceWithFakedData ([NullAllowed] NSData fakedDataOrNil, [NullAllowed] NSError fakedErrorOrNil);

		// -(BOOL)waitForCompletionOfAllFetchersWithTimeout:(NSTimeInterval)timeoutInSeconds;
		[Export ("waitForCompletionOfAllFetchersWithTimeout:")]
		bool WaitForCompletionOfAllFetchersWithTimeout (double timeoutInSeconds);
	}

	// @interface BackwardsCompatibilityOnly (GTMSessionFetcherService)
	[Category]
	[BaseType (typeof(GTMSessionFetcherService))]
	interface GTMSessionFetcherService_BackwardsCompatibilityOnly
	{
        // @property (assign, atomic) NSInteger cookieStorageMethod;
        [Export("cookieStorageMethod")]
        nint CookieStorageMethod();
	}

	[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const int64_t kGTMSessionUploadFetcherStandardChunkSize;
		[Field ("kGTMSessionUploadFetcherStandardChunkSize", "__Internal")]
		long kGTMSessionUploadFetcherStandardChunkSize { get; }

		// extern const int64_t kGTMSessionUploadFetcherMaximumDemandBufferSize;
		[Field ("kGTMSessionUploadFetcherMaximumDemandBufferSize", "__Internal")]
		long kGTMSessionUploadFetcherMaximumDemandBufferSize { get; }

		// extern NSString *const _Nonnull kGTMSessionFetcherUploadLocationObtainedNotification;
		[Field ("kGTMSessionFetcherUploadLocationObtainedNotification", "__Internal")]
		NSString kGTMSessionFetcherUploadLocationObtainedNotification { get; }
	}


    //GTMSessionFetcherChallengeDispositionBlock b;
	// typedef void (^GTMSessionUploadFetcherDataProviderResponse)(NSData * _Nullable, NSError * _Nullable);
	delegate void GTMSessionUploadFetcherDataProviderResponse ([NullAllowed] NSData arg0, [NullAllowed] NSError arg1);

	// typedef void (^GTMSessionUploadFetcherDataProvider)(int64_t, int64_t, GTMSessionUploadFetcherDataProviderResponse _Nonnull);
	delegate void GTMSessionUploadFetcherDataProvider (long arg0, long arg1, GTMSessionUploadFetcherDataProviderResponse arg2);

	// @interface GTMSessionUploadFetcher : GTMSessionFetcher
	[BaseType (typeof(GTMSessionFetcher.GTMSessionFetcher))]
	interface GTMSessionUploadFetcher
	{
		// +(instancetype _Nonnull)uploadFetcherWithRequest:(NSURLRequest * _Nonnull)request uploadMIMEType:(NSString * _Nonnull)uploadMIMEType chunkSize:(int64_t)chunkSize fetcherService:(GTMSessionFetcherService * _Nullable)fetcherServiceOrNil;
		[Static]
		[Export ("uploadFetcherWithRequest:uploadMIMEType:chunkSize:fetcherService:")]
		GTMSessionUploadFetcher UploadFetcherWithRequest (NSUrlRequest request, string uploadMIMEType, long chunkSize, [NullAllowed] GTMSessionFetcherService fetcherServiceOrNil);

		// +(instancetype _Nonnull)uploadFetcherWithLocation:(NSURL * _Nullable)uploadLocationURL uploadMIMEType:(NSString * _Nonnull)uploadMIMEType chunkSize:(int64_t)chunkSize fetcherService:(GTMSessionFetcherService * _Nullable)fetcherServiceOrNil;
		[Static]
		[Export ("uploadFetcherWithLocation:uploadMIMEType:chunkSize:fetcherService:")]
		GTMSessionUploadFetcher UploadFetcherWithLocation ([NullAllowed] NSUrl uploadLocationURL, string uploadMIMEType, long chunkSize, [NullAllowed] GTMSessionFetcherService fetcherServiceOrNil);

		// -(void)setUploadDataLength:(int64_t)fullLength provider:(GTMSessionUploadFetcherDataProvider _Nullable)block;
		[Export ("setUploadDataLength:provider:")]
		void SetUploadDataLength (long fullLength, [NullAllowed] GTMSessionUploadFetcherDataProvider block);

		// +(NSArray * _Nonnull)uploadFetchersForBackgroundSessions;
		[Static]
		[Export ("uploadFetchersForBackgroundSessions")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] UploadFetchersForBackgroundSessions { get; }

		// +(instancetype _Nullable)uploadFetcherForSessionIdentifier:(NSString * _Nonnull)sessionIdentifier;
		[Static]
		[Export ("uploadFetcherForSessionIdentifier:")]
		[return: NullAllowed]
		GTMSessionUploadFetcher UploadFetcherForSessionIdentifier (string sessionIdentifier);

		// -(void)pauseFetching;
		[Export ("pauseFetching")]
		void PauseFetching ();

		// -(void)resumeFetching;
		[Export ("resumeFetching")]
		void ResumeFetching ();

		// -(BOOL)isPaused;
		[Export ("isPaused")]
		//[Verify (MethodToProperty)]
		bool IsPaused { get; }

		// @property (atomic, strong) NSURL * _Nullable uploadLocationURL;
		[NullAllowed, Export ("uploadLocationURL", ArgumentSemantic.Strong)]
		NSUrl UploadLocationURL { get; set; }

		// @property (atomic, strong) NSData * _Nullable uploadData;
		[NullAllowed, Export ("uploadData", ArgumentSemantic.Strong)]
		NSData UploadData { get; set; }

		// @property (atomic, strong) NSURL * _Nullable uploadFileURL;
		[NullAllowed, Export ("uploadFileURL", ArgumentSemantic.Strong)]
		NSUrl UploadFileURL { get; set; }

		// @property (atomic, strong) NSFileHandle * _Nullable uploadFileHandle;
		[NullAllowed, Export ("uploadFileHandle", ArgumentSemantic.Strong)]
		NSFileHandle UploadFileHandle { get; set; }

		// @property (readonly, copy, atomic) GTMSessionUploadFetcherDataProvider _Nullable uploadDataProvider;
		[NullAllowed, Export ("uploadDataProvider", ArgumentSemantic.Copy)]
		GTMSessionUploadFetcherDataProvider UploadDataProvider { get; }

		// @property (copy, atomic) NSString * _Nonnull uploadMIMEType;
		[Export ("uploadMIMEType")]
		string UploadMIMEType { get; set; }

		// @property (assign, atomic) int64_t chunkSize;
		[Export ("chunkSize")]
		long ChunkSize { get; set; }

		// @property (readonly, assign, atomic) int64_t currentOffset;
		[Export ("currentOffset")]
		long CurrentOffset { get; }

		// @property (atomic, strong) GTMSessionFetcher * _Nullable chunkFetcher;
		[NullAllowed, Export ("chunkFetcher", ArgumentSemantic.Strong)]
		GTMSessionFetcher.GTMSessionFetcher ChunkFetcher { get; set; }

		// @property (readonly, atomic) GTMSessionFetcher * _Nonnull activeFetcher;
		[Export ("activeFetcher")]
		GTMSessionFetcher.GTMSessionFetcher ActiveFetcher { get; }

		// @property (readonly, atomic) NSURLRequest * _Nullable lastChunkRequest;
		[NullAllowed, Export ("lastChunkRequest")]
		NSUrlRequest LastChunkRequest { get; }

		// @property (assign, atomic) NSInteger statusCode;
		[Export ("statusCode")]
		nint StatusCode { get; set; }

		// @property (readonly, atomic) dispatch_queue_t _Nullable delegateCallbackQueue;
		[NullAllowed, Export ("delegateCallbackQueue")]
		DispatchQueue DelegateCallbackQueue { get; }

		// @property (readonly, atomic) GTMSessionFetcherCompletionHandler _Nullable delegateCompletionHandler;
		[NullAllowed, Export ("delegateCompletionHandler")]
		GTMSessionFetcherCompletionHandler DelegateCompletionHandler { get; }
	}

	// @interface GTMSessionUploadFetcherMethods (GTMSessionFetcher)
	[Category]
	[BaseType (typeof(GTMSessionFetcher.GTMSessionFetcher))]
	interface GTMSessionFetcher_GTMSessionUploadFetcherMethods
	{
        // @property (readonly) GTMSessionUploadFetcher * _Nullable parentUploadFetcher;
        [NullAllowed, Export("parentUploadFetcher")]
        GTMSessionUploadFetcher ParentUploadFetcher();
	}
}
