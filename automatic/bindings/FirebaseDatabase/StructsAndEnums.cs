using System;
using ObjCRuntime;

namespace DreamTeam.Xamarin.Firebase
{
	[Native]
	public enum FIRDataEventType : nint
	{
		ChildAdded,
		ChildRemoved,
		ChildChanged,
		ChildMoved,
		Value
	}
}
