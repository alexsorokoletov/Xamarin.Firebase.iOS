using System;
using ObjCRuntime;

namespace Firebase.iOS
{
    [Native]
    public enum FIRLogLevel : ulong
    {
        Error = 0,
        Warning,
        Info,
        Debug,
        Assert,
        Max = Assert
    }

}