using DreamTeam.Xamarin.FirebaseAnalytics;
using FirebaseDynamicLinks;
using Foundation;
using ObjCRuntime;

namespace DreamTeam.Xamarin.FirebaseDynamicLinks
{
	// @interface FIRDynamicLink : NSObject
	[BaseType (typeof(NSObject))]
	interface FIRDynamicLink
	{
		// @property (readonly, copy, nonatomic) NSURL * _Nullable url;
		[NullAllowed, Export ("url", ArgumentSemantic.Copy)]
		NSUrl Url { get; }

		// @property (readonly, assign, nonatomic) FIRDynamicLinkMatchConfidence matchConfidence;
		[Export ("matchConfidence", ArgumentSemantic.Assign)]
		FIRDynamicLinkMatchConfidence MatchConfidence { get; }
	}

	// typedef void (^FIRDynamicLinkResolverHandler)(NSURL * _Nullable, NSError * _Nullable);
	delegate void FIRDynamicLinkResolverHandler ([NullAllowed] NSUrl arg0, [NullAllowed] NSError arg1);

	// typedef void (^FIRDynamicLinkUniversalLinkHandler)(FIRDynamicLink * _Nullable, NSError * _Nullable);
	delegate void FIRDynamicLinkUniversalLinkHandler ([NullAllowed] FIRDynamicLink arg0, [NullAllowed] NSError arg1);

	// @interface FIRDynamicLinks : NSObject
	[BaseType (typeof(NSObject))]
	interface FIRDynamicLinks
	{
		// +(instancetype _Nullable)dynamicLinks;
		[Static]
		[Export ("dynamicLinks")]
		[return: NullAllowed]
		FIRDynamicLinks DynamicLinks ();

		// -(BOOL)shouldHandleDynamicLinkFromCustomSchemeURL:(NSURL * _Nonnull)url;
		[Export ("shouldHandleDynamicLinkFromCustomSchemeURL:")]
		bool ShouldHandleDynamicLinkFromCustomSchemeURL (NSUrl url);

		// -(FIRDynamicLink * _Nullable)dynamicLinkFromCustomSchemeURL:(NSURL * _Nonnull)url;
		[Export ("dynamicLinkFromCustomSchemeURL:")]
		[return: NullAllowed]
		FIRDynamicLink DynamicLinkFromCustomSchemeURL (NSUrl url);

		// -(FIRDynamicLink * _Nullable)dynamicLinkFromUniversalLinkURL:(NSURL * _Nonnull)url;
		[Export ("dynamicLinkFromUniversalLinkURL:")]
		[return: NullAllowed]
		FIRDynamicLink DynamicLinkFromUniversalLinkURL (NSUrl url);

		// -(BOOL)handleUniversalLink:(NSURL * _Nonnull)url completion:(FIRDynamicLinkUniversalLinkHandler _Nonnull)completion;
		[Export ("handleUniversalLink:completion:")]
		bool HandleUniversalLink (NSUrl url, FIRDynamicLinkUniversalLinkHandler completion);

		// -(void)resolveShortLink:(NSURL * _Nonnull)url completion:(FIRDynamicLinkResolverHandler _Nonnull)completion;
		[Export ("resolveShortLink:completion:")]
		void ResolveShortLink (NSUrl url, FIRDynamicLinkResolverHandler completion);

		// -(BOOL)matchesShortLinkFormat:(NSURL * _Nonnull)url;
		[Export ("matchesShortLinkFormat:")]
		bool MatchesShortLinkFormat (NSUrl url);
	}
}
