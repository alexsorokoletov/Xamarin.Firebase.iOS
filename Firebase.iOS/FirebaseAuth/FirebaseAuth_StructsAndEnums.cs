using System;
using ObjCRuntime;
namespace Firebase.iOS
{
    [Native]
    public enum FIRAuthErrorCode : long
    {
        orCodeInvalidCustomToken = 17000,
        orCodeCustomTokenMismatch = 17002,
        orCodeInvalidCredential = 17004,
        orCodeUserDisabled = 17005,
        orCodeOperationNotAllowed = 17006,
        orCodeEmailAlreadyInUse = 17007,
        orCodeInvalidEmail = 17008,
        orCodeWrongPassword = 17009,
        orCodeTooManyRequests = 17010,
        orCodeUserNotFound = 17011,
        orCodeAccountExistsWithDifferentCredential = 17012,
        rorCodeAccountExistsWithDifferentCredential = 17012,
        orCodeRequiresRecentLogin = 17014,
        orCodeProviderAlreadyLinked = 17015,
        orCodeNoSuchProvider = 17016,
        orCodeInvalidUserToken = 17017,
        orCodeNetworkError = 17020,
        orCodeUserTokenExpired = 17021,
        orCodeInvalidAPIKey = 17023,
        orCodeUserMismatch = 17024,
        orCodeCredentialAlreadyInUse = 17025,
        orCodeWeakPassword = 17026,
        orCodeAppNotAuthorized = 17028,
        orCodeKeychainError = 17995,
        orCodeInternalError = 17999
    }
}