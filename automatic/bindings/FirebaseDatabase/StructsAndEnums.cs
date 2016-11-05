using System;
using ObjCRuntime;

namespace DreamTeam.Xamarin.FirebaseDatabase
{
	[Native]
	public enum FIRDataEventType : long
	{
		ChildAdded,
		ChildRemoved,
		ChildChanged,
		ChildMoved,
		Value
	}
}
