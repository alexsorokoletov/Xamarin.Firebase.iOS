// using DreamTeam.Xamarin.GoogleInterchangeUtilities;
using DreamTeam.Xamarin.GoogleToolboxForMac_NSData_zlib;
using System;
using Foundation;
using ObjCRuntime;

namespace DreamTeam.Xamarin.FirebaseCore
{
	// @interface FIRAnalyticsConfiguration : NSObject
	[BaseType (typeof(NSObject))]
	interface FIRAnalyticsConfiguration
	{
		// +(FIRAnalyticsConfiguration *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		// [Verify (MethodToProperty)]
		FIRAnalyticsConfiguration SharedInstance { get; }

		// -(void)setMinimumSessionInterval:(NSTimeInterval)minimumSessionInterval;
		[Export ("setMinimumSessionInterval:")]
		void SetMinimumSessionInterval (double minimumSessionInterval);

		// -(void)setSessionTimeoutInterval:(NSTimeInterval)sessionTimeoutInterval;
		[Export ("setSessionTimeoutInterval:")]
		void SetSessionTimeoutInterval (double sessionTimeoutInterval);

		// -(void)setAnalyticsCollectionEnabled:(BOOL)analyticsCollectionEnabled;
		[Export ("setAnalyticsCollectionEnabled:")]
		void SetAnalyticsCollectionEnabled (bool analyticsCollectionEnabled);

		// -(void)setIsEnabled:(BOOL)isEnabled __attribute__((deprecated("Use setAnalyticsCollectionEnabled: instead.")));
		[Export ("setIsEnabled:")]
		void SetIsEnabled (bool isEnabled);
	}

	// typedef void (^FIRAppVoidBoolCallback)(BOOL);
	delegate void FIRAppVoidBoolCallback (bool arg0);

	// @interface FIRApp : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface FIRApp
	{
		// +(void)configure;
		[Static]
		[Export ("configure")]
		void Configure ();

		// +(void)configureWithOptions:(FIROptions * _Nonnull)options;
		[Static]
		[Export ("configureWithOptions:")]
		void ConfigureWithOptions (FIROptions options);

		// +(void)configureWithName:(NSString * _Nonnull)name options:(FIROptions * _Nonnull)options;
		[Static]
		[Export ("configureWithName:options:")]
		void ConfigureWithName (string name, FIROptions options);

		// +(FIRApp * _Nullable)defaultApp;
		[Static]
		[NullAllowed, Export ("defaultApp")]
		// [Verify (MethodToProperty)]
		FIRApp DefaultApp { get; }

		// +(FIRApp * _Nullable)appNamed:(NSString * _Nonnull)name;
		[Static]
		[Export ("appNamed:")]
		[return: NullAllowed]
		FIRApp AppNamed (string name);

		// +(NSDictionary * _Nullable)allApps;
		[Static]
		[NullAllowed, Export ("allApps")]
		// [Verify (MethodToProperty)]
		NSDictionary AllApps { get; }

		// -(void)deleteApp:(FIRAppVoidBoolCallback _Nonnull)completion;
		[Export ("deleteApp:")]
		void DeleteApp (FIRAppVoidBoolCallback completion);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) FIROptions * _Nonnull options;
		[Export ("options")]
		FIROptions Options { get; }
	}

	// @interface FIRConfiguration : NSObject
	[BaseType (typeof(NSObject))]
	interface FIRConfiguration
	{
		// +(FIRConfiguration *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		// [Verify (MethodToProperty)]
		FIRConfiguration SharedInstance { get; }

		// @property (readwrite, nonatomic) FIRAnalyticsConfiguration * analyticsConfiguration;
		[Export ("analyticsConfiguration", ArgumentSemantic.Assign)]
		FIRAnalyticsConfiguration AnalyticsConfiguration { get; set; }

		// @property (assign, readwrite, nonatomic) FIRLogLevel logLevel __attribute__((deprecated("Use -FIRDebugEnabled and -FIRDebugDisabled. See FIRApp.h for more details.")));
		[Export ("logLevel", ArgumentSemantic.Assign)]
		FIRLogLevel LogLevel { get; set; }
	}

	// @interface FIROptions : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface FIROptions : INSCopying
	{
		// +(FIROptions *)defaultOptions;
		[Static]
		[Export ("defaultOptions")]
		// [Verify (MethodToProperty)]
		FIROptions DefaultOptions { get; }

		// @property (readonly, copy, nonatomic) NSString * APIKey;
		[Export ("APIKey")]
		string APIKey { get; }

		// @property (readonly, copy, nonatomic) NSString * clientID;
		[Export ("clientID")]
		string ClientID { get; }

		// @property (readonly, copy, nonatomic) NSString * trackingID;
		[Export ("trackingID")]
		string TrackingID { get; }

		// @property (readonly, copy, nonatomic) NSString * GCMSenderID;
		[Export ("GCMSenderID")]
		string GCMSenderID { get; }

		// @property (readonly, copy, nonatomic) NSString * androidClientID;
		[Export ("androidClientID")]
		string AndroidClientID { get; }

		// @property (readonly, copy, nonatomic) NSString * googleAppID;
		[Export ("googleAppID")]
		string GoogleAppID { get; }

		// @property (readonly, copy, nonatomic) NSString * databaseURL;
		[Export ("databaseURL")]
		string DatabaseURL { get; }

		// @property (readwrite, copy, nonatomic) NSString * deepLinkURLScheme;
		[Export ("deepLinkURLScheme")]
		string DeepLinkURLScheme { get; set; }

		// @property (readonly, copy, nonatomic) NSString * storageBucket;
		[Export ("storageBucket")]
		string StorageBucket { get; }

		// -(instancetype)initWithGoogleAppID:(NSString *)googleAppID bundleID:(NSString *)bundleID GCMSenderID:(NSString *)GCMSenderID APIKey:(NSString *)APIKey clientID:(NSString *)clientID trackingID:(NSString *)trackingID androidClientID:(NSString *)androidClientID databaseURL:(NSString *)databaseURL storageBucket:(NSString *)storageBucket deepLinkURLScheme:(NSString *)deepLinkURLScheme;
		[Export ("initWithGoogleAppID:bundleID:GCMSenderID:APIKey:clientID:trackingID:androidClientID:databaseURL:storageBucket:deepLinkURLScheme:")]
		IntPtr Constructor (string googleAppID, string bundleID, string GCMSenderID, string APIKey, string clientID, string trackingID, string androidClientID, string databaseURL, string storageBucket, string deepLinkURLScheme);

		// -(instancetype)initWithContentsOfFile:(NSString *)plistPath;
		[Export ("initWithContentsOfFile:")]
		IntPtr Constructor (string plistPath);
	}
}
