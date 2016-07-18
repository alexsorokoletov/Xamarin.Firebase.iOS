using Foundation;
using ObjCRuntime;
namespace Firebase.iOS
{
    //[Static]
    partial interface Constants
    {
        // extern NSString *const _Nonnull FIREmailPasswordAuthProviderID;
        [Field("FIREmailPasswordAuthProviderID", "__Internal")]
        NSString FIREmailPasswordAuthProviderID { get; }

        // extern NSString *const _Nonnull FIRFacebookAuthProviderID;
        [Field("FIRFacebookAuthProviderID", "__Internal")]
        NSString FIRFacebookAuthProviderID { get; }

        // extern NSString *const _Nonnull FIRGitHubAuthProviderID;
        [Field("FIRGitHubAuthProviderID", "__Internal")]
        NSString FIRGitHubAuthProviderID { get; }

        // extern NSString *const _Nonnull FIRGoogleAuthProviderID;
        [Field("FIRGoogleAuthProviderID", "__Internal")]
        NSString FIRGoogleAuthProviderID { get; }

        // extern NSString *const _Nonnull FIRTwitterAuthProviderID;
        [Field("FIRTwitterAuthProviderID", "__Internal")]
        NSString FIRTwitterAuthProviderID { get; }

        // extern NSString *const FIRAuthErrorDomain;
        [Field("FIRAuthErrorDomain", "__Internal")]
        NSString FIRAuthErrorDomain { get; }

        // extern NSString *const FIRAuthErrorNameKey;
        [Field("FIRAuthErrorNameKey", "__Internal")]
        NSString FIRAuthErrorNameKey { get; }

        // extern NSString *const _Nonnull FIRAuthStateDidChangeNotification;
        [Field("FIRAuthStateDidChangeNotification", "__Internal")]
        NSString FIRAuthStateDidChangeNotification { get; }

        // extern const double FirebaseAuthVersionNumber;
        [Field("FirebaseAuthVersionNumber", "__Internal")]
        double FirebaseAuthVersionNumber { get; }

        // extern const unsigned char *const FirebaseAuthVersionString;
        [Field("FirebaseAuthVersionString", "__Internal")]
        NSString FirebaseAuthVersionString { get; }
    }

    // @interface FIREmailPasswordAuthProvider : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface FIREmailPasswordAuthProvider
    {
        // +(FIRAuthCredential * _Nonnull)credentialWithEmail:(NSString * _Nonnull)email password:(NSString * _Nonnull)password;
        [Static]
        [Export("credentialWithEmail:password:")]
        FIRAuthCredential CredentialWithEmail(string email, string password);
    }

    // @interface FIRFacebookAuthProvider : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface FIRFacebookAuthProvider
    {
        // +(FIRAuthCredential * _Nonnull)credentialWithAccessToken:(NSString * _Nonnull)accessToken;
        [Static]
        [Export("credentialWithAccessToken:")]
        FIRAuthCredential CredentialWithAccessToken(string accessToken);
    }

    // @interface FIRGitHubAuthProvider : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface FIRGitHubAuthProvider
    {
        // +(FIRAuthCredential * _Nonnull)credentialWithToken:(NSString * _Nonnull)token;
        [Static]
        [Export("credentialWithToken:")]
        FIRAuthCredential CredentialWithToken(string token);
    }

    // @interface FIRGoogleAuthProvider : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface FIRGoogleAuthProvider
    {
        // +(FIRAuthCredential * _Nonnull)credentialWithIDToken:(NSString * _Nonnull)IDToken accessToken:(NSString * _Nonnull)accessToken;
        [Static]
        [Export("credentialWithIDToken:accessToken:")]
        FIRAuthCredential CredentialWithIDToken(string IDToken, string accessToken);
    }

    // @interface FIRTwitterAuthProvider : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface FIRTwitterAuthProvider
    {
        // +(FIRAuthCredential * _Nonnull)credentialWithToken:(NSString * _Nonnull)token secret:(NSString * _Nonnull)secret;
        [Static]
        [Export("credentialWithToken:secret:")]
        FIRAuthCredential CredentialWithToken(string token, string secret);
    }

    // @interface FIRAuthErrors
    interface FIRAuthErrors
    {
    }

    // typedef void (^FIRAuthStateDidChangeListenerBlock)(FIRAuth * _Nonnull, FIRUser * _Nullable);
    delegate void FIRAuthStateDidChangeListenerBlock(FIRAuth arg0, [NullAllowed] FIRUser arg1);

    // typedef void (^FIRAuthResultCallback)(FIRUser * _Nullable, NSError * _Nullable);
    delegate void FIRAuthResultCallback([NullAllowed] FIRUser arg0, [NullAllowed] NSError arg1);

    // typedef void (^FIRProviderQueryCallback)(NSArray<NSString *> * _Nullable, NSError * _Nullable);
    delegate void FIRProviderQueryCallback([NullAllowed] string[] arg0, [NullAllowed] NSError arg1);

    // typedef void (^FIRSendPasswordResetCallback)(NSError * _Nullable);
    delegate void FIRSendPasswordResetCallback([NullAllowed] NSError arg0);

    // @interface FIRAuth : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface FIRAuth
    {
        // +(FIRAuth * _Nullable)auth;
        [Static]
        [NullAllowed, Export("auth")]
        FIRAuth Auth { get; }

        // +(FIRAuth * _Nullable)authWithApp:(FIRApp * _Nonnull)app;
        [Static]
        [Export("authWithApp:")]
        [return: NullAllowed]
        FIRAuth AuthWithApp(FIRApp app);

        // @property (readonly, nonatomic, weak) FIRApp * _Nullable app;
        [NullAllowed, Export("app", ArgumentSemantic.Weak)]
        FIRApp App { get; }

        // @property (readonly, nonatomic, strong) FIRUser * _Nullable currentUser;
        [NullAllowed, Export("currentUser", ArgumentSemantic.Strong)]
        FIRUser CurrentUser { get; }

        // -(void)fetchProvidersForEmail:(NSString * _Nonnull)email completion:(FIRProviderQueryCallback _Nullable)completion;
        [Export("fetchProvidersForEmail:completion:")]
        void FetchProvidersForEmail(string email, [NullAllowed] FIRProviderQueryCallback completion);

        // -(void)signInWithEmail:(NSString * _Nonnull)email password:(NSString * _Nonnull)password completion:(FIRAuthResultCallback _Nullable)completion;
        [Export("signInWithEmail:password:completion:")]
        void SignInWithEmail(string email, string password, [NullAllowed] FIRAuthResultCallback completion);

        // -(void)signInWithCredential:(FIRAuthCredential * _Nonnull)credential completion:(FIRAuthResultCallback _Nullable)completion;
        [Export("signInWithCredential:completion:")]
        void SignInWithCredential(FIRAuthCredential credential, [NullAllowed] FIRAuthResultCallback completion);

        // -(void)signInAnonymouslyWithCompletion:(FIRAuthResultCallback _Nullable)completion;
        [Export("signInAnonymouslyWithCompletion:")]
        void SignInAnonymouslyWithCompletion([NullAllowed] FIRAuthResultCallback completion);

        // -(void)signInWithCustomToken:(NSString * _Nonnull)token completion:(FIRAuthResultCallback _Nullable)completion;
        [Export("signInWithCustomToken:completion:")]
        void SignInWithCustomToken(string token, [NullAllowed] FIRAuthResultCallback completion);

        // -(void)createUserWithEmail:(NSString * _Nonnull)email password:(NSString * _Nonnull)password completion:(FIRAuthResultCallback _Nullable)completion;
        [Export("createUserWithEmail:password:completion:")]
        void CreateUserWithEmail(string email, string password, [NullAllowed] FIRAuthResultCallback completion);

        // -(void)sendPasswordResetWithEmail:(NSString * _Nonnull)email completion:(FIRSendPasswordResetCallback _Nullable)completion;
        [Export("sendPasswordResetWithEmail:completion:")]
        void SendPasswordResetWithEmail(string email, [NullAllowed] FIRSendPasswordResetCallback completion);

        // -(BOOL)signOut:(NSError * _Nullable * _Nullable)error;
        [Export("signOut:")]
        bool SignOut([NullAllowed] out NSError error);

        // -(FIRAuthStateDidChangeListenerHandle _Nonnull)addAuthStateDidChangeListener:(FIRAuthStateDidChangeListenerBlock _Nonnull)listener;
        [Export("addAuthStateDidChangeListener:")]
        NSObject AddAuthStateDidChangeListener(FIRAuthStateDidChangeListenerBlock listener);

        // -(void)removeAuthStateDidChangeListener:(FIRAuthStateDidChangeListenerHandle _Nonnull)listenerHandle;
        [Export("removeAuthStateDidChangeListener:")]
        void RemoveAuthStateDidChangeListener(NSObject listenerHandle);
    }

    // @interface FIRAuthCredential : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface FIRAuthCredential
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull provider;
        [Export("provider")]
        string Provider { get; }
    }

    // @protocol FIRUserInfo <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface FIRUserInfo
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull providerID;
        [Abstract]
        [Export("providerID")]
        string ProviderID { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull uid;
        [Abstract]
        [Export("uid")]
        string Uid { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable displayName;
        [Abstract]
        [NullAllowed, Export("displayName")]
        string DisplayName { get; }

        // @required @property (readonly, copy, nonatomic) NSURL * _Nullable photoURL;
        [Abstract]
        [NullAllowed, Export("photoURL", ArgumentSemantic.Copy)]
        NSUrl PhotoURL { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable email;
        [Abstract]
        [NullAllowed, Export("email")]
        string Email { get; }
    }

    // typedef void (^FIRAuthTokenCallback)(NSString * _Nullable, NSError * _Nullable);
    delegate void FIRAuthTokenCallback([NullAllowed] string arg0, [NullAllowed] NSError arg1);

    // typedef void (^FIRUserProfileChangeCallback)(NSError * _Nullable);
    delegate void FIRUserProfileChangeCallback([NullAllowed] NSError arg0);

    // typedef void (^FIRSendEmailVerificationCallback)(NSError * _Nullable);
    delegate void FIRSendEmailVerificationCallback([NullAllowed] NSError arg0);

    // @interface FIRUser : NSObject <FIRUserInfo>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface FIRUser : FIRUserInfo
    {
        // @property (readonly, getter = isAnonymous, nonatomic) BOOL anonymous;
        [Export("anonymous")]
        bool Anonymous { [Bind("isAnonymous")] get; }

        // @property (readonly, getter = isEmailVerified, nonatomic) BOOL emailVerified;
        [Export("emailVerified")]
        bool EmailVerified { [Bind("isEmailVerified")] get; }

        // @property (readonly, nonatomic) NSString * _Nullable refreshToken;
        [NullAllowed, Export("refreshToken")]
        string RefreshToken { get; }

        // @property (readonly, nonatomic) NSArray<id<FIRUserInfo>> * _Nonnull providerData;
        [Export("providerData")]
        FIRUserInfo[] ProviderData { get; }

        // -(void)updateEmail:(NSString * _Nonnull)email completion:(FIRUserProfileChangeCallback _Nullable)completion;
        [Export("updateEmail:completion:")]
        void UpdateEmail(string email, [NullAllowed] FIRUserProfileChangeCallback completion);

        // -(void)updatePassword:(NSString * _Nonnull)password completion:(FIRUserProfileChangeCallback _Nullable)completion;
        [Export("updatePassword:completion:")]
        void UpdatePassword(string password, [NullAllowed] FIRUserProfileChangeCallback completion);

        // -(FIRUserProfileChangeRequest * _Nonnull)profileChangeRequest;
        [Export("profileChangeRequest")]
        FIRUserProfileChangeRequest ProfileChangeRequest { get; }

        // -(void)reloadWithCompletion:(FIRUserProfileChangeCallback _Nullable)completion;
        [Export("reloadWithCompletion:")]
        void ReloadWithCompletion([NullAllowed] FIRUserProfileChangeCallback completion);

        // -(void)reauthenticateWithCredential:(FIRAuthCredential * _Nonnull)credential completion:(FIRUserProfileChangeCallback _Nullable)completion;
        [Export("reauthenticateWithCredential:completion:")]
        void ReauthenticateWithCredential(FIRAuthCredential credential, [NullAllowed] FIRUserProfileChangeCallback completion);

        // -(void)getTokenWithCompletion:(FIRAuthTokenCallback _Nullable)completion;
        [Export("getTokenWithCompletion:")]
        void GetTokenWithCompletion([NullAllowed] FIRAuthTokenCallback completion);

        // -(void)getTokenForcingRefresh:(BOOL)forceRefresh completion:(FIRAuthTokenCallback _Nullable)completion;
        [Export("getTokenForcingRefresh:completion:")]
        void GetTokenForcingRefresh(bool forceRefresh, [NullAllowed] FIRAuthTokenCallback completion);

        // -(void)linkWithCredential:(FIRAuthCredential * _Nonnull)credential completion:(FIRAuthResultCallback _Nullable)completion;
        [Export("linkWithCredential:completion:")]
        void LinkWithCredential(FIRAuthCredential credential, [NullAllowed] FIRAuthResultCallback completion);

        // -(void)unlinkFromProvider:(NSString * _Nonnull)provider completion:(FIRAuthResultCallback _Nullable)completion;
        [Export("unlinkFromProvider:completion:")]
        void UnlinkFromProvider(string provider, [NullAllowed] FIRAuthResultCallback completion);

        // -(void)sendEmailVerificationWithCompletion:(FIRSendEmailVerificationCallback _Nullable)completion;
        [Export("sendEmailVerificationWithCompletion:")]
        void SendEmailVerificationWithCompletion([NullAllowed] FIRSendEmailVerificationCallback completion);

        // -(void)deleteWithCompletion:(FIRUserProfileChangeCallback _Nullable)completion;
        [Export("deleteWithCompletion:")]
        void DeleteWithCompletion([NullAllowed] FIRUserProfileChangeCallback completion);
    }

    // @interface FIRUserProfileChangeRequest : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface FIRUserProfileChangeRequest
    {
        // @property (copy, nonatomic) NSString * _Nullable displayName;
        [NullAllowed, Export("displayName")]
        string DisplayName { get; set; }

        // @property (copy, nonatomic) NSURL * _Nullable photoURL;
        [NullAllowed, Export("photoURL", ArgumentSemantic.Copy)]
        NSUrl PhotoURL { get; set; }

        // -(void)commitChangesWithCompletion:(FIRUserProfileChangeCallback _Nullable)completion;
        [Export("commitChangesWithCompletion:")]
        void CommitChangesWithCompletion([NullAllowed] FIRUserProfileChangeCallback completion);
    }
}