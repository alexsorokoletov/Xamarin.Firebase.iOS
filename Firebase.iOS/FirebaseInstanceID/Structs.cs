using System;
using ObjCRuntime;

namespace Firebase.iOS
{
    [Native]
    public enum FIRInstanceIDError : ulong
    {
        Unknown = 0,
        Authentication = 1,
        NoAccess = 2,
        Timeout = 3,
        Network = 4,
        OperationInProgress = 5,
        InvalidRequest = 7
    }

    [Native]
    public enum FIRInstanceIDAPNSTokenType : long
    {
        Unknown,
        Sandbox,
        Prod
    }
}

