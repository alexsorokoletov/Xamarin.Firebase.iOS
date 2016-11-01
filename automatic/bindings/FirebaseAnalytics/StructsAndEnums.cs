using System;
using ObjCRuntime;

namespace DreamTeam.Xamarin.Firebase
{
	[Native]
	public enum FIRLogLevel : nint
	{
		Error = 0,
		Warning,
		Info,
		Debug,
		Assert,
		Max = Assert
	}
}
