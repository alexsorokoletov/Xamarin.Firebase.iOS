using System;
using Foundation;

namespace DreamTeam.Xamarin.GoogleToolboxForMac.NSData_zlib
{
	// @interface GTMZLibAdditions (NSData)
	[Category]
	[BaseType (typeof(NSData))]
	interface NSData_GTMZLibAdditions
	{
		// +(NSData *)gtm_dataByGzippingBytes:(const void *)bytes length:(NSUInteger)length;
		// [Static]
		// [Export ("gtm_dataByGzippingBytes:length:")]
		// unsafe NSData Gtm_dataByGzippingBytes (void* bytes, nuint length);

		// +(NSData *)gtm_dataByGzippingBytes:(const void *)bytes length:(NSUInteger)length error:(NSError **)error;
		// [Static]
		// [Export ("gtm_dataByGzippingBytes:length:error:")]
		// unsafe NSData Gtm_dataByGzippingBytes (void* bytes, nuint length, out NSError error);

		// +(NSData *)gtm_dataByGzippingData:(NSData *)data __attribute__((deprecated("Use error variant")));
		[Static]
		[Export ("gtm_dataByGzippingData:")]
		NSData Gtm_dataByGzippingData (NSData data);

		// +(NSData *)gtm_dataByGzippingData:(NSData *)data error:(NSError **)error;
		[Static]
		[Export ("gtm_dataByGzippingData:error:")]
		NSData Gtm_dataByGzippingData (NSData data, out NSError error);

		// +(NSData *)gtm_dataByGzippingBytes:(const void *)bytes length:(NSUInteger)length compressionLevel:(int)level __attribute__((deprecated("Use error variant")));
		// [Static]
		// [Export ("gtm_dataByGzippingBytes:length:compressionLevel:")]
		// unsafe NSData Gtm_dataByGzippingBytes (void* bytes, nuint length, int level);

		// +(NSData *)gtm_dataByGzippingBytes:(const void *)bytes length:(NSUInteger)length compressionLevel:(int)level error:(NSError **)error;
		// [Static]
		// [Export ("gtm_dataByGzippingBytes:length:compressionLevel:error:")]
		// unsafe NSData Gtm_dataByGzippingBytes (void* bytes, nuint length, int level, out NSError error);

		// +(NSData *)gtm_dataByGzippingData:(NSData *)data compressionLevel:(int)level __attribute__((deprecated("Use error variant")));
		[Static]
		[Export ("gtm_dataByGzippingData:compressionLevel:")]
		NSData Gtm_dataByGzippingData (NSData data, int level);

		// +(NSData *)gtm_dataByGzippingData:(NSData *)data compressionLevel:(int)level error:(NSError **)error;
		[Static]
		[Export ("gtm_dataByGzippingData:compressionLevel:error:")]
		NSData Gtm_dataByGzippingData (NSData data, int level, out NSError error);

		// +(NSData *)gtm_dataByDeflatingBytes:(const void *)bytes length:(NSUInteger)length __attribute__((deprecated("Use error variant")));
		// [Static]
		// [Export ("gtm_dataByDeflatingBytes:length:")]
		// unsafe NSData Gtm_dataByDeflatingBytes (void* bytes, nuint length);

		// +(NSData *)gtm_dataByDeflatingBytes:(const void *)bytes length:(NSUInteger)length error:(NSError **)error;
		// [Static]
		// [Export ("gtm_dataByDeflatingBytes:length:error:")]
		// unsafe NSData Gtm_dataByDeflatingBytes (void* bytes, nuint length, out NSError error);

		// +(NSData *)gtm_dataByDeflatingData:(NSData *)data __attribute__((deprecated("Use error variant")));
		[Static]
		[Export ("gtm_dataByDeflatingData:")]
		NSData Gtm_dataByDeflatingData (NSData data);

		// +(NSData *)gtm_dataByDeflatingData:(NSData *)data error:(NSError **)error;
		[Static]
		[Export ("gtm_dataByDeflatingData:error:")]
		NSData Gtm_dataByDeflatingData (NSData data, out NSError error);

		// +(NSData *)gtm_dataByDeflatingBytes:(const void *)bytes length:(NSUInteger)length compressionLevel:(int)level __attribute__((deprecated("Use error variant")));
		// [Static]
		// [Export ("gtm_dataByDeflatingBytes:length:compressionLevel:")]
		// unsafe NSData Gtm_dataByDeflatingBytes (void* bytes, nuint length, int level);

		// +(NSData *)gtm_dataByDeflatingBytes:(const void *)bytes length:(NSUInteger)length compressionLevel:(int)level error:(NSError **)error;
		// [Static]
		// [Export ("gtm_dataByDeflatingBytes:length:compressionLevel:error:")]
		// unsafe NSData Gtm_dataByDeflatingBytes (void* bytes, nuint length, int level, out NSError error);

		// +(NSData *)gtm_dataByDeflatingData:(NSData *)data compressionLevel:(int)level __attribute__((deprecated("Use error variant")));
		[Static]
		[Export ("gtm_dataByDeflatingData:compressionLevel:")]
		NSData Gtm_dataByDeflatingData (NSData data, int level);

		// +(NSData *)gtm_dataByDeflatingData:(NSData *)data compressionLevel:(int)level error:(NSError **)error;
		[Static]
		[Export ("gtm_dataByDeflatingData:compressionLevel:error:")]
		NSData Gtm_dataByDeflatingData (NSData data, int level, out NSError error);

		// +(NSData *)gtm_dataByInflatingBytes:(const void *)bytes length:(NSUInteger)length __attribute__((deprecated("Use error variant")));
		// [Static]
		// [Export ("gtm_dataByInflatingBytes:length:")]
		// unsafe NSData Gtm_dataByInflatingBytes (void* bytes, nuint length);

		// +(NSData *)gtm_dataByInflatingBytes:(const void *)bytes length:(NSUInteger)length error:(NSError **)error;
		// [Static]
		// [Export ("gtm_dataByInflatingBytes:length:error:")]
		// unsafe NSData Gtm_dataByInflatingBytes (void* bytes, nuint length, out NSError error);

		// +(NSData *)gtm_dataByInflatingData:(NSData *)data __attribute__((deprecated("Use error variant")));
		[Static]
		[Export ("gtm_dataByInflatingData:")]
		NSData Gtm_dataByInflatingData (NSData data);

		// +(NSData *)gtm_dataByInflatingData:(NSData *)data error:(NSError **)error;
		[Static]
		[Export ("gtm_dataByInflatingData:error:")]
		NSData Gtm_dataByInflatingData (NSData data, out NSError error);

		// +(NSData *)gtm_dataByRawDeflatingBytes:(const void *)bytes length:(NSUInteger)length __attribute__((deprecated("Use error variant")));
		// [Static]
		// [Export ("gtm_dataByRawDeflatingBytes:length:")]
		// unsafe NSData Gtm_dataByRawDeflatingBytes (void* bytes, nuint length);

		// +(NSData *)gtm_dataByRawDeflatingBytes:(const void *)bytes length:(NSUInteger)length error:(NSError **)error;
		// [Static]
		// [Export ("gtm_dataByRawDeflatingBytes:length:error:")]
		// unsafe NSData Gtm_dataByRawDeflatingBytes (void* bytes, nuint length, out NSError error);

		// +(NSData *)gtm_dataByRawDeflatingData:(NSData *)data __attribute__((deprecated("Use error variant")));
		[Static]
		[Export ("gtm_dataByRawDeflatingData:")]
		NSData Gtm_dataByRawDeflatingData (NSData data);

		// +(NSData *)gtm_dataByRawDeflatingData:(NSData *)data error:(NSError **)error;
		[Static]
		[Export ("gtm_dataByRawDeflatingData:error:")]
		NSData Gtm_dataByRawDeflatingData (NSData data, out NSError error);

		// +(NSData *)gtm_dataByRawDeflatingBytes:(const void *)bytes length:(NSUInteger)length compressionLevel:(int)level __attribute__((deprecated("Use error variant")));
		// [Static]
		// [Export ("gtm_dataByRawDeflatingBytes:length:compressionLevel:")]
		// unsafe NSData Gtm_dataByRawDeflatingBytes (void* bytes, nuint length, int level);

		// +(NSData *)gtm_dataByRawDeflatingBytes:(const void *)bytes length:(NSUInteger)length compressionLevel:(int)level error:(NSError **)error;
		// [Static]
		// [Export ("gtm_dataByRawDeflatingBytes:length:compressionLevel:error:")]
		// unsafe NSData Gtm_dataByRawDeflatingBytes (void* bytes, nuint length, int level, out NSError error);

		// +(NSData *)gtm_dataByRawDeflatingData:(NSData *)data compressionLevel:(int)level __attribute__((deprecated("Use error variant")));
		[Static]
		[Export ("gtm_dataByRawDeflatingData:compressionLevel:")]
		NSData Gtm_dataByRawDeflatingData (NSData data, int level);

		// +(NSData *)gtm_dataByRawDeflatingData:(NSData *)data compressionLevel:(int)level error:(NSError **)error;
		[Static]
		[Export ("gtm_dataByRawDeflatingData:compressionLevel:error:")]
		NSData Gtm_dataByRawDeflatingData (NSData data, int level, out NSError error);

		// +(NSData *)gtm_dataByRawInflatingBytes:(const void *)bytes length:(NSUInteger)length __attribute__((deprecated("Use error variant")));
		// [Static]
		// [Export ("gtm_dataByRawInflatingBytes:length:")]
		// unsafe NSData Gtm_dataByRawInflatingBytes (void* bytes, nuint length);

		// +(NSData *)gtm_dataByRawInflatingBytes:(const void *)bytes length:(NSUInteger)length error:(NSError **)error;
		// [Static]
		// [Export ("gtm_dataByRawInflatingBytes:length:error:")]
		// unsafe NSData Gtm_dataByRawInflatingBytes (void* bytes, nuint length, out NSError error);

		// +(NSData *)gtm_dataByRawInflatingData:(NSData *)data __attribute__((deprecated("Use error variant")));
		[Static]
		[Export ("gtm_dataByRawInflatingData:")]
		NSData Gtm_dataByRawInflatingData (NSData data);

		// +(NSData *)gtm_dataByRawInflatingData:(NSData *)data error:(NSError **)error;
		[Static]
		[Export ("gtm_dataByRawInflatingData:error:")]
		NSData Gtm_dataByRawInflatingData (NSData data, out NSError error);
	}

	[Static]
	// [Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const GTMNSDataZlibErrorDomain;
		[Field ("GTMNSDataZlibErrorDomain", "__Internal")]
		NSString GTMNSDataZlibErrorDomain { get; }

		// extern NSString *const GTMNSDataZlibErrorKey;
		[Field ("GTMNSDataZlibErrorKey", "__Internal")]
		NSString GTMNSDataZlibErrorKey { get; }

		// extern NSString *const GTMNSDataZlibRemainingBytesKey;
		[Field ("GTMNSDataZlibRemainingBytesKey", "__Internal")]
		NSString GTMNSDataZlibRemainingBytesKey { get; }
	}
}
