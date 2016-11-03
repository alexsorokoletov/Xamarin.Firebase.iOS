using System;
using ObjCRuntime;

namespace DreamTeam.Xamarin.FirebaseAnalytics
{
	[Native]
	public enum FIRLogLevel : long
	{
		Error = 0,
		Warning,
		Info,
		Debug,
		Assert,
		Max = Assert
	}
}
