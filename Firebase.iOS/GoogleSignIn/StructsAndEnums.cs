using System;
using ObjCRuntime;
namespace Firebase.iOS
{

    [Native]
    public enum GIDSignInErrorCode : long
    {
        Unknown = -1,
        Keychain = -2,
        NoSignInHandlersInstalled = -3,
        HasNoAuthInKeychain = -4,
        Canceled = -5
    }

    [Native]
    public enum GIDSignInButtonStyle : long
    {
        Standard = 0,
        Wide = 1,
        IconOnly = 2
    }

    [Native]
    public enum GIDSignInButtonColorScheme : long
    {
        Dark = 0,
        Light = 1
    }
}