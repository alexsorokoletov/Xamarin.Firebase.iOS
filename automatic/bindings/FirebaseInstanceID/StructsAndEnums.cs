using System;
using ObjCRuntime;

namespace DreamTeam.Xamarin.Firebase
{
	[Native]
	public enum FIRInstanceIDError : nuint
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
	public enum FIRInstanceIDAPNSTokenType : nint
	{
		Unknown,
		Sandbox,
		Prod
	}
}
