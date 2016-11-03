using Foundation;

namespace DreamTeam.Xamarin.FirebaseInstanceID
{
	[Static]
	partial interface Constants
	{
		// extern NSString *const _Nonnull kFIRInstanceIDScopeFirebaseMessaging;
		[Field ("kFIRInstanceIDScopeFirebaseMessaging", "__Internal")]
		NSString kFIRInstanceIDScopeFirebaseMessaging { get; }

		// extern NSString *const _Nonnull kFIRInstanceIDTokenRefreshNotification;
		[Field ("kFIRInstanceIDTokenRefreshNotification", "__Internal")]
		NSString kFIRInstanceIDTokenRefreshNotification { get; }
	}

	// typedef void (^FIRInstanceIDTokenHandler)(NSString * _Nullable, NSError * _Nullable);
	delegate void FIRInstanceIDTokenHandler ([NullAllowed] string arg0, [NullAllowed] NSError arg1);

	// typedef void (^FIRInstanceIDDeleteTokenHandler)(NSError * _Nullable);
	delegate void FIRInstanceIDDeleteTokenHandler ([NullAllowed] NSError arg0);

	// typedef void (^FIRInstanceIDHandler)(NSString * _Nullable, NSError * _Nullable);
	delegate void FIRInstanceIDHandler ([NullAllowed] string arg0, [NullAllowed] NSError arg1);

	// typedef void (^FIRInstanceIDDeleteHandler)(NSError * _Nullable);
	delegate void FIRInstanceIDDeleteHandler ([NullAllowed] NSError arg0);

	// @interface FIRInstanceID : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface FIRInstanceID
	{
		// +(instancetype _Nonnull)instanceID;
		[Static]
		[Export ("instanceID")]
		FIRInstanceID InstanceID ();

		// -(void)setAPNSToken:(NSData * _Nonnull)token type:(FIRInstanceIDAPNSTokenType)type;
		[Export ("setAPNSToken:type:")]
		void SetAPNSToken (NSData token, FIRInstanceIDAPNSTokenType type);

		// -(NSString * _Nullable)token;
		[NullAllowed, Export ("token")]
		string Token { get; }

		// -(void)tokenWithAuthorizedEntity:(NSString * _Nonnull)authorizedEntity scope:(NSString * _Nonnull)scope options:(NSDictionary * _Nullable)options handler:(FIRInstanceIDTokenHandler _Nonnull)handler;
		[Export ("tokenWithAuthorizedEntity:scope:options:handler:")]
		void TokenWithAuthorizedEntity (string authorizedEntity, string scope, [NullAllowed] NSDictionary options, FIRInstanceIDTokenHandler handler);

		// -(void)deleteTokenWithAuthorizedEntity:(NSString * _Nonnull)authorizedEntity scope:(NSString * _Nonnull)scope handler:(FIRInstanceIDDeleteTokenHandler _Nonnull)handler;
		[Export ("deleteTokenWithAuthorizedEntity:scope:handler:")]
		void DeleteTokenWithAuthorizedEntity (string authorizedEntity, string scope, FIRInstanceIDDeleteTokenHandler handler);

		// -(void)getIDWithHandler:(FIRInstanceIDHandler _Nonnull)handler;
		[Export ("getIDWithHandler:")]
		void GetIDWithHandler (FIRInstanceIDHandler handler);

		// -(void)deleteIDWithHandler:(FIRInstanceIDDeleteHandler _Nonnull)handler;
		[Export ("deleteIDWithHandler:")]
		void DeleteIDWithHandler (FIRInstanceIDDeleteHandler handler);
	}
}
