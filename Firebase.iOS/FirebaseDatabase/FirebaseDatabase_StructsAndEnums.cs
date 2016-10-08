using System;
using ObjCRuntime;

namespace Firebase.iOS
{
    [Native]
    public enum FIRDataEventType : ulong
    {
        ChildAdded,
        ChildRemoved,
        ChildChanged,
        ChildMoved,
        Value
    }
}