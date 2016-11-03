using System;
using ObjCRuntime;

namespace DreamTeam.Xamarin.GoogleToolboxForMac_NSData_zlib
{
	[Native]
	public enum GTMNSDataZlibError : long
	{
		GreaterThan32BitsToCompress = 1024,
		Internal,
		DataRemaining
	}
}
