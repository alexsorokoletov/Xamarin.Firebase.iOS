using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace DreamTeam.Xamarin.GTMOAuth2
{
	[Native]
	public enum GTMSessionFetcherError : long
	{
		DownloadFailed = -1,
		UploadChunkUnavailable = -2,
		BackgroundExpiration = -3,
		BackgroundFetchFailed = -4,
		InsecureRequest = -5,
		TaskCreationFailed = -6
	}

	[Native]
	public enum GTMSessionFetcherStatus : long
	{
		NotModified = 304,
		BadRequest = 400,
		Unauthorized = 401,
		Forbidden = 403,
		PreconditionFailed = 412
	}

	//static class CFunctions
	//{
	//	// extern void GTMSessionFetcherAssertValidSelector (id _Nullable obj, SEL _Nullable sel, ...);
	//	[DllImport ("__Internal")]
	//	[Verify (PlatformInvoke)]
	//	static extern void GTMSessionFetcherAssertValidSelector ([NullAllowed] NSObject obj, [NullAllowed] Selector sel, IntPtr varArgs);

	//	// extern NSString * _Nonnull GTMFetcherStandardUserAgentString (NSBundle * _Nullable bundle);
	//	[DllImport ("__Internal")]
	//	[Verify (PlatformInvoke)]
	//	static extern NSString GTMFetcherStandardUserAgentString ([NullAllowed] NSBundle bundle);

	//	// extern NSString * _Nonnull GTMFetcherApplicationIdentifier (NSBundle * _Nullable bundle);
	//	[DllImport ("__Internal")]
	//	[Verify (PlatformInvoke)]
	//	static extern NSString GTMFetcherApplicationIdentifier ([NullAllowed] NSBundle bundle);

	//	// extern NSString * _Nonnull GTMFetcherSystemVersionString ();
	//	[DllImport ("__Internal")]
	//	[Verify (PlatformInvoke)]
	//	static extern NSString GTMFetcherSystemVersionString ();

	//	// extern NSString * _Nonnull GTMFetcherCleanedUserAgentString (NSString * _Nonnull str);
	//	[DllImport ("__Internal")]
	//	[Verify (PlatformInvoke)]
	//	static extern NSString GTMFetcherCleanedUserAgentString (NSString str);

	//	// extern NSData * _Nullable GTMDataFromInputStream (NSInputStream * _Nonnull inputStream, NSError * _Nullable * _Nullable outError);
	//	[DllImport ("__Internal")]
	//	[Verify (PlatformInvoke)]
	//	[return: NullAllowed]
	//	static extern NSData GTMDataFromInputStream (NSInputStream inputStream, [NullAllowed] out NSError outError);
	//}

	[Native]
	public enum GTMOAuth2Error : long
	{
		WindowClosed = -1000,
		AuthorizationFailed = -1001,
		TokenExpired = -1002,
		TokenUnavailable = -1003,
		UnauthorizableRequest = -1004
	}

	[Native]
	public enum GTMOAuth2KeychainError : long
	{
		BadArguments = -1301,
		NoPassword = -1302
	}
}
