using Foundation;

namespace DreamTeam.Xamarin.GoogleToolboxForMac.NSDictionary_URLArguments
{
	// @interface GTMNSDictionaryURLArgumentsAdditions (NSDictionary)
	[Category]
	[BaseType (typeof(NSDictionary))]
	interface NSDictionary_GTMNSDictionaryURLArgumentsAdditions
	{
		// +(NSDictionary *)gtm_dictionaryWithHttpArgumentsString:(NSString *)argString;
		[Static]
		[Export ("gtm_dictionaryWithHttpArgumentsString:")]
		NSDictionary Gtm_dictionaryWithHttpArgumentsString (string argString);

		// -(NSString *)gtm_httpArgumentsString;
		[Export ("gtm_httpArgumentsString")]
		// [Verify (MethodToProperty)]
		string Gtm_httpArgumentsString ();
	}

	// @interface GTMNSStringURLArgumentsAdditions (NSString)
	[Category]
	[BaseType (typeof(NSString))]
	interface NSString_GTMNSStringURLArgumentsAdditions
	{
		// -(NSString *)gtm_stringByEscapingForURLArgument;
		[Export ("gtm_stringByEscapingForURLArgument")]
		// [Verify (MethodToProperty)]
		string Gtm_stringByEscapingForURLArgument ();

		// -(NSString *)gtm_stringByUnescapingFromURLArgument;
		[Export ("gtm_stringByUnescapingFromURLArgument")]
		// [Verify (MethodToProperty)]
		string Gtm_stringByUnescapingFromURLArgument ();
	}
}
