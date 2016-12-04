using Foundation;

namespace DreamTeam.Xamarin.GoogleToolboxForMac.NSString_URLArguments
{
    // @interface GTMNSStringURLArgumentsAdditions (NSString)
    [Category]
    [BaseType(typeof(NSString))]
    interface NSString_GTMNSStringURLArgumentsAdditions
    {
        // -(NSString *)gtm_stringByEscapingForURLArgument;
        [Export("gtm_stringByEscapingForURLArgument")]
        //[Verify (MethodToProperty)]
        string Gtm_stringByEscapingForURLArgument();

        // -(NSString *)gtm_stringByUnescapingFromURLArgument;
        [Export("gtm_stringByUnescapingFromURLArgument")]
        //[Verify (MethodToProperty)]
        string Gtm_stringByUnescapingFromURLArgument();
    }
}
