using DreamTeam.Xamarin.FirebaseAnalytics;
using DreamTeam.Xamarin.FirebaseCore;
using System;
using CoreFoundation;
using Foundation;
using ObjCRuntime;

namespace DreamTeam.Xamarin.FirebaseDatabase
{
	// @interface FIRDataSnapshot : NSObject
	[BaseType (typeof(NSObject))]
	interface FIRDataSnapshot
	{
		// -(FIRDataSnapshot * _Nonnull)childSnapshotForPath:(NSString * _Nonnull)childPathString;
		[Export ("childSnapshotForPath:")]
		FIRDataSnapshot ChildSnapshotForPath (string childPathString);

		// -(BOOL)hasChild:(NSString * _Nonnull)childPathString;
		[Export ("hasChild:")]
		bool HasChild (string childPathString);

		// -(BOOL)hasChildren;
		[Export ("hasChildren")]
		// [Verify (MethodToProperty)]
		bool HasChildren { get; }

		// -(BOOL)exists;
		[Export ("exists")]
		// [Verify (MethodToProperty)]
		bool Exists { get; }

		// -(id _Nullable)valueInExportFormat;
		[NullAllowed, Export ("valueInExportFormat")]
		// [Verify (MethodToProperty)]
		NSObject ValueInExportFormat { get; }

		// @property (readonly, nonatomic, strong) id _Nullable value;
		[NullAllowed, Export ("value", ArgumentSemantic.Strong)]
		NSObject Value { get; }

		// @property (readonly, nonatomic) NSUInteger childrenCount;
		[Export ("childrenCount")]
		nuint ChildrenCount { get; }

		// @property (readonly, nonatomic, strong) FIRDatabaseReference * _Nonnull ref;
		[Export ("ref", ArgumentSemantic.Strong)]
		FIRDatabaseReference Ref { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull key;
		[Export ("key", ArgumentSemantic.Strong)]
		string Key { get; }

		// @property (readonly, nonatomic, strong) NSEnumerator * _Nonnull children;
		[Export ("children", ArgumentSemantic.Strong)]
		NSEnumerator Children { get; }

		// @property (readonly, nonatomic, strong) id _Nullable priority;
		[NullAllowed, Export ("priority", ArgumentSemantic.Strong)]
		NSObject Priority { get; }
	}

	// @interface FIRDatabaseQuery : NSObject
	[BaseType (typeof(NSObject))]
	interface FIRDatabaseQuery
	{
		// -(FIRDatabaseHandle)observeEventType:(FIRDataEventType)eventType withBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull))block;
		[Export ("observeEventType:withBlock:")]
		nuint ObserveEventType (FIRDataEventType eventType, Action<FIRDataSnapshot> block);

		// -(FIRDatabaseHandle)observeEventType:(FIRDataEventType)eventType andPreviousSiblingKeyWithBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull, NSString * _Nullable))block;
		[Export ("observeEventType:andPreviousSiblingKeyWithBlock:")]
		nuint ObserveEventType (FIRDataEventType eventType, Action<FIRDataSnapshot, NSString> block);

		// -(FIRDatabaseHandle)observeEventType:(FIRDataEventType)eventType withBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull))block withCancelBlock:(void (^ _Nullable)(NSError * _Nonnull))cancelBlock;
		[Export ("observeEventType:withBlock:withCancelBlock:")]
		nuint ObserveEventType (FIRDataEventType eventType, Action<FIRDataSnapshot> block, [NullAllowed] Action<NSError> cancelBlock);

		// -(FIRDatabaseHandle)observeEventType:(FIRDataEventType)eventType andPreviousSiblingKeyWithBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull, NSString * _Nullable))block withCancelBlock:(void (^ _Nullable)(NSError * _Nonnull))cancelBlock;
		[Export ("observeEventType:andPreviousSiblingKeyWithBlock:withCancelBlock:")]
		nuint ObserveEventType (FIRDataEventType eventType, Action<FIRDataSnapshot, NSString> block, [NullAllowed] Action<NSError> cancelBlock);

		// -(void)observeSingleEventOfType:(FIRDataEventType)eventType withBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull))block;
		[Export ("observeSingleEventOfType:withBlock:")]
		void ObserveSingleEventOfType (FIRDataEventType eventType, Action<FIRDataSnapshot> block);

		// -(void)observeSingleEventOfType:(FIRDataEventType)eventType andPreviousSiblingKeyWithBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull, NSString * _Nullable))block;
		[Export ("observeSingleEventOfType:andPreviousSiblingKeyWithBlock:")]
		void ObserveSingleEventOfType (FIRDataEventType eventType, Action<FIRDataSnapshot, NSString> block);

		// -(void)observeSingleEventOfType:(FIRDataEventType)eventType withBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull))block withCancelBlock:(void (^ _Nullable)(NSError * _Nonnull))cancelBlock;
		[Export ("observeSingleEventOfType:withBlock:withCancelBlock:")]
		void ObserveSingleEventOfType (FIRDataEventType eventType, Action<FIRDataSnapshot> block, [NullAllowed] Action<NSError> cancelBlock);

		// -(void)observeSingleEventOfType:(FIRDataEventType)eventType andPreviousSiblingKeyWithBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull, NSString * _Nullable))block withCancelBlock:(void (^ _Nullable)(NSError * _Nonnull))cancelBlock;
		[Export ("observeSingleEventOfType:andPreviousSiblingKeyWithBlock:withCancelBlock:")]
		void ObserveSingleEventOfType (FIRDataEventType eventType, Action<FIRDataSnapshot, NSString> block, [NullAllowed] Action<NSError> cancelBlock);

		// -(void)removeObserverWithHandle:(FIRDatabaseHandle)handle;
		[Export ("removeObserverWithHandle:")]
		void RemoveObserverWithHandle (nuint handle);

		// -(void)removeAllObservers;
		[Export ("removeAllObservers")]
		void RemoveAllObservers ();

		// -(void)keepSynced:(BOOL)keepSynced;
		[Export ("keepSynced:")]
		void KeepSynced (bool keepSynced);

		// -(FIRDatabaseQuery * _Nonnull)queryLimitedToFirst:(NSUInteger)limit;
		[Export ("queryLimitedToFirst:")]
		FIRDatabaseQuery QueryLimitedToFirst (nuint limit);

		// -(FIRDatabaseQuery * _Nonnull)queryLimitedToLast:(NSUInteger)limit;
		[Export ("queryLimitedToLast:")]
		FIRDatabaseQuery QueryLimitedToLast (nuint limit);

		// -(FIRDatabaseQuery * _Nonnull)queryOrderedByChild:(NSString * _Nonnull)key;
		[Export ("queryOrderedByChild:")]
		FIRDatabaseQuery QueryOrderedByChild (string key);

		// -(FIRDatabaseQuery * _Nonnull)queryOrderedByKey;
		[Export ("queryOrderedByKey")]
		// [Verify (MethodToProperty)]
		FIRDatabaseQuery QueryOrderedByKey { get; }

		// -(FIRDatabaseQuery * _Nonnull)queryOrderedByValue;
		[Export ("queryOrderedByValue")]
		// [Verify (MethodToProperty)]
		FIRDatabaseQuery QueryOrderedByValue { get; }

		// -(FIRDatabaseQuery * _Nonnull)queryOrderedByPriority;
		[Export ("queryOrderedByPriority")]
		// [Verify (MethodToProperty)]
		FIRDatabaseQuery QueryOrderedByPriority { get; }

		// -(FIRDatabaseQuery * _Nonnull)queryStartingAtValue:(id _Nullable)startValue;
		[Export ("queryStartingAtValue:")]
		FIRDatabaseQuery QueryStartingAtValue ([NullAllowed] NSObject startValue);

		// -(FIRDatabaseQuery * _Nonnull)queryStartingAtValue:(id _Nullable)startValue childKey:(NSString * _Nullable)childKey;
		[Export ("queryStartingAtValue:childKey:")]
		FIRDatabaseQuery QueryStartingAtValue ([NullAllowed] NSObject startValue, [NullAllowed] string childKey);

		// -(FIRDatabaseQuery * _Nonnull)queryEndingAtValue:(id _Nullable)endValue;
		[Export ("queryEndingAtValue:")]
		FIRDatabaseQuery QueryEndingAtValue ([NullAllowed] NSObject endValue);

		// -(FIRDatabaseQuery * _Nonnull)queryEndingAtValue:(id _Nullable)endValue childKey:(NSString * _Nullable)childKey;
		[Export ("queryEndingAtValue:childKey:")]
		FIRDatabaseQuery QueryEndingAtValue ([NullAllowed] NSObject endValue, [NullAllowed] string childKey);

		// -(FIRDatabaseQuery * _Nonnull)queryEqualToValue:(id _Nullable)value;
		[Export ("queryEqualToValue:")]
		FIRDatabaseQuery QueryEqualToValue ([NullAllowed] NSObject value);

		// -(FIRDatabaseQuery * _Nonnull)queryEqualToValue:(id _Nullable)value childKey:(NSString * _Nullable)childKey;
		[Export ("queryEqualToValue:childKey:")]
		FIRDatabaseQuery QueryEqualToValue ([NullAllowed] NSObject value, [NullAllowed] string childKey);

		// @property (readonly, nonatomic, strong) FIRDatabaseReference * _Nonnull ref;
		[Export ("ref", ArgumentSemantic.Strong)]
		FIRDatabaseReference Ref { get; }
	}

	// @interface FIRMutableData : NSObject
	[BaseType (typeof(NSObject))]
	interface FIRMutableData
	{
		// -(BOOL)hasChildren;
		[Export ("hasChildren")]
		// [Verify (MethodToProperty)]
		bool HasChildren { get; }

		// -(BOOL)hasChildAtPath:(NSString * _Nonnull)path;
		[Export ("hasChildAtPath:")]
		bool HasChildAtPath (string path);

		// -(FIRMutableData * _Nonnull)childDataByAppendingPath:(NSString * _Nonnull)path;
		[Export ("childDataByAppendingPath:")]
		FIRMutableData ChildDataByAppendingPath (string path);

		// @property (nonatomic, strong) id _Nullable value;
		[NullAllowed, Export ("value", ArgumentSemantic.Strong)]
		NSObject Value { get; set; }

		// @property (nonatomic, strong) id _Nullable priority;
		[NullAllowed, Export ("priority", ArgumentSemantic.Strong)]
		NSObject Priority { get; set; }

		// @property (readonly, nonatomic) NSUInteger childrenCount;
		[Export ("childrenCount")]
		nuint ChildrenCount { get; }

		// @property (readonly, nonatomic, strong) NSEnumerator * _Nonnull children;
		[Export ("children", ArgumentSemantic.Strong)]
		NSEnumerator Children { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable key;
		[NullAllowed, Export ("key", ArgumentSemantic.Strong)]
		string Key { get; }
	}

	// @interface FIRTransactionResult : NSObject
	[BaseType (typeof(NSObject))]
	interface FIRTransactionResult
	{
		// +(FIRTransactionResult * _Nonnull)successWithValue:(FIRMutableData * _Nonnull)value;
		[Static]
		[Export ("successWithValue:")]
		FIRTransactionResult SuccessWithValue (FIRMutableData value);

		// +(FIRTransactionResult * _Nonnull)abort;
		[Static]
		[Export ("abort")]
		// [Verify (MethodToProperty)]
		FIRTransactionResult Abort();
	}

	// @interface FIRServerValue : NSObject
	[BaseType (typeof(NSObject))]
	interface FIRServerValue
	{
		// +(NSDictionary * _Nonnull)timestamp;
		[Static]
		[Export ("timestamp")]
		// [Verify (MethodToProperty)]
		NSDictionary Timestamp { get; }
	}

	// @interface FIRDatabaseReference : FIRDatabaseQuery
	[BaseType (typeof(FIRDatabaseQuery))]
	interface FIRDatabaseReference
	{
		// -(FIRDatabaseReference * _Nonnull)child:(NSString * _Nonnull)pathString;
		[Export ("child:")]
		FIRDatabaseReference Child (string pathString);

		// -(FIRDatabaseReference * _Nonnull)childByAppendingPath:(NSString * _Nonnull)pathString __attribute__((deprecated("use child: instead")));
		[Export ("childByAppendingPath:")]
		FIRDatabaseReference ChildByAppendingPath (string pathString);

		// -(FIRDatabaseReference * _Nonnull)childByAutoId;
		[Export ("childByAutoId")]
		// [Verify (MethodToProperty)]
		FIRDatabaseReference ChildByAutoId { get; }

		// -(void)setValue:(id _Nullable)value;
		[Export ("setValue:")]
		void SetValue ([NullAllowed] NSObject value);

		// -(void)setValue:(id _Nullable)value withCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Export ("setValue:withCompletionBlock:")]
		void SetValue ([NullAllowed] NSObject value, Action<NSError, FIRDatabaseReference> block);

		// -(void)setValue:(id _Nullable)value andPriority:(id _Nullable)priority;
		[Export ("setValue:andPriority:")]
		void SetValue ([NullAllowed] NSObject value, [NullAllowed] NSObject priority);

		// -(void)setValue:(id _Nullable)value andPriority:(id _Nullable)priority withCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Export ("setValue:andPriority:withCompletionBlock:")]
		void SetValue ([NullAllowed] NSObject value, [NullAllowed] NSObject priority, Action<NSError, FIRDatabaseReference> block);

		// -(void)removeValue;
		[Export ("removeValue")]
		void RemoveValue ();

		// -(void)removeValueWithCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Export ("removeValueWithCompletionBlock:")]
		void RemoveValueWithCompletionBlock (Action<NSError, FIRDatabaseReference> block);

		// -(void)setPriority:(id _Nullable)priority;
		[Export ("setPriority:")]
		void SetPriority ([NullAllowed] NSObject priority);

		// -(void)setPriority:(id _Nullable)priority withCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Export ("setPriority:withCompletionBlock:")]
		void SetPriority ([NullAllowed] NSObject priority, Action<NSError, FIRDatabaseReference> block);

		// -(void)updateChildValues:(NSDictionary * _Nonnull)values;
		[Export ("updateChildValues:")]
		void UpdateChildValues (NSDictionary values);

		// -(void)updateChildValues:(NSDictionary * _Nonnull)values withCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Export ("updateChildValues:withCompletionBlock:")]
		void UpdateChildValues (NSDictionary values, Action<NSError, FIRDatabaseReference> block);

		// -(FIRDatabaseHandle)observeEventType:(FIRDataEventType)eventType withBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull))block;
		[Export ("observeEventType:withBlock:")]
		nuint ObserveEventType (FIRDataEventType eventType, Action<FIRDataSnapshot> block);

		// -(FIRDatabaseHandle)observeEventType:(FIRDataEventType)eventType andPreviousSiblingKeyWithBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull, NSString * _Nullable))block;
		[Export ("observeEventType:andPreviousSiblingKeyWithBlock:")]
		nuint ObserveEventType (FIRDataEventType eventType, Action<FIRDataSnapshot, NSString> block);

		// -(FIRDatabaseHandle)observeEventType:(FIRDataEventType)eventType withBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull))block withCancelBlock:(void (^ _Nullable)(NSError * _Nonnull))cancelBlock;
		[Export ("observeEventType:withBlock:withCancelBlock:")]
		nuint ObserveEventType (FIRDataEventType eventType, Action<FIRDataSnapshot> block, [NullAllowed] Action<NSError> cancelBlock);

		// -(FIRDatabaseHandle)observeEventType:(FIRDataEventType)eventType andPreviousSiblingKeyWithBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull, NSString * _Nullable))block withCancelBlock:(void (^ _Nullable)(NSError * _Nonnull))cancelBlock;
		[Export ("observeEventType:andPreviousSiblingKeyWithBlock:withCancelBlock:")]
		nuint ObserveEventType (FIRDataEventType eventType, Action<FIRDataSnapshot, NSString> block, [NullAllowed] Action<NSError> cancelBlock);

		// -(void)observeSingleEventOfType:(FIRDataEventType)eventType withBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull))block;
		[Export ("observeSingleEventOfType:withBlock:")]
		void ObserveSingleEventOfType (FIRDataEventType eventType, Action<FIRDataSnapshot> block);

		// -(void)observeSingleEventOfType:(FIRDataEventType)eventType andPreviousSiblingKeyWithBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull, NSString * _Nullable))block;
		[Export ("observeSingleEventOfType:andPreviousSiblingKeyWithBlock:")]
		void ObserveSingleEventOfType (FIRDataEventType eventType, Action<FIRDataSnapshot, NSString> block);

		// -(void)observeSingleEventOfType:(FIRDataEventType)eventType withBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull))block withCancelBlock:(void (^ _Nullable)(NSError * _Nonnull))cancelBlock;
		[Export ("observeSingleEventOfType:withBlock:withCancelBlock:")]
		void ObserveSingleEventOfType (FIRDataEventType eventType, Action<FIRDataSnapshot> block, [NullAllowed] Action<NSError> cancelBlock);

		// -(void)observeSingleEventOfType:(FIRDataEventType)eventType andPreviousSiblingKeyWithBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull, NSString * _Nullable))block withCancelBlock:(void (^ _Nullable)(NSError * _Nonnull))cancelBlock;
		[Export ("observeSingleEventOfType:andPreviousSiblingKeyWithBlock:withCancelBlock:")]
		void ObserveSingleEventOfType (FIRDataEventType eventType, Action<FIRDataSnapshot, NSString> block, [NullAllowed] Action<NSError> cancelBlock);

		// -(void)removeObserverWithHandle:(FIRDatabaseHandle)handle;
		[Export ("removeObserverWithHandle:")]
		void RemoveObserverWithHandle (nuint handle);

		// -(void)keepSynced:(BOOL)keepSynced;
		[Export ("keepSynced:")]
		void KeepSynced (bool keepSynced);

		// -(void)removeAllObservers;
		[Export ("removeAllObservers")]
		void RemoveAllObservers ();

		// -(FIRDatabaseQuery * _Nonnull)queryLimitedToFirst:(NSUInteger)limit;
		[Export ("queryLimitedToFirst:")]
		FIRDatabaseQuery QueryLimitedToFirst (nuint limit);

		// -(FIRDatabaseQuery * _Nonnull)queryLimitedToLast:(NSUInteger)limit;
		[Export ("queryLimitedToLast:")]
		FIRDatabaseQuery QueryLimitedToLast (nuint limit);

		// -(FIRDatabaseQuery * _Nonnull)queryOrderedByChild:(NSString * _Nonnull)key;
		[Export ("queryOrderedByChild:")]
		FIRDatabaseQuery QueryOrderedByChild (string key);

		// -(FIRDatabaseQuery * _Nonnull)queryOrderedByKey;
		[Export ("queryOrderedByKey")]
		// [Verify (MethodToProperty)]
		FIRDatabaseQuery QueryOrderedByKey { get; }

		// -(FIRDatabaseQuery * _Nonnull)queryOrderedByPriority;
		[Export ("queryOrderedByPriority")]
		// [Verify (MethodToProperty)]
		FIRDatabaseQuery QueryOrderedByPriority { get; }

		// -(FIRDatabaseQuery * _Nonnull)queryStartingAtValue:(id _Nullable)startValue;
		[Export ("queryStartingAtValue:")]
		FIRDatabaseQuery QueryStartingAtValue ([NullAllowed] NSObject startValue);

		// -(FIRDatabaseQuery * _Nonnull)queryStartingAtValue:(id _Nullable)startValue childKey:(NSString * _Nullable)childKey;
		[Export ("queryStartingAtValue:childKey:")]
		FIRDatabaseQuery QueryStartingAtValue ([NullAllowed] NSObject startValue, [NullAllowed] string childKey);

		// -(FIRDatabaseQuery * _Nonnull)queryEndingAtValue:(id _Nullable)endValue;
		[Export ("queryEndingAtValue:")]
		FIRDatabaseQuery QueryEndingAtValue ([NullAllowed] NSObject endValue);

		// -(FIRDatabaseQuery * _Nonnull)queryEndingAtValue:(id _Nullable)endValue childKey:(NSString * _Nullable)childKey;
		[Export ("queryEndingAtValue:childKey:")]
		FIRDatabaseQuery QueryEndingAtValue ([NullAllowed] NSObject endValue, [NullAllowed] string childKey);

		// -(FIRDatabaseQuery * _Nonnull)queryEqualToValue:(id _Nullable)value;
		[Export ("queryEqualToValue:")]
		FIRDatabaseQuery QueryEqualToValue ([NullAllowed] NSObject value);

		// -(FIRDatabaseQuery * _Nonnull)queryEqualToValue:(id _Nullable)value childKey:(NSString * _Nullable)childKey;
		[Export ("queryEqualToValue:childKey:")]
		FIRDatabaseQuery QueryEqualToValue ([NullAllowed] NSObject value, [NullAllowed] string childKey);

		// -(void)onDisconnectSetValue:(id _Nullable)value;
		[Export ("onDisconnectSetValue:")]
		void OnDisconnectSetValue ([NullAllowed] NSObject value);

		// -(void)onDisconnectSetValue:(id _Nullable)value withCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Export ("onDisconnectSetValue:withCompletionBlock:")]
		void OnDisconnectSetValue ([NullAllowed] NSObject value, Action<NSError, FIRDatabaseReference> block);

		// -(void)onDisconnectSetValue:(id _Nullable)value andPriority:(id _Nonnull)priority;
		[Export ("onDisconnectSetValue:andPriority:")]
		void OnDisconnectSetValue ([NullAllowed] NSObject value, NSObject priority);

		// -(void)onDisconnectSetValue:(id _Nullable)value andPriority:(id _Nullable)priority withCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Export ("onDisconnectSetValue:andPriority:withCompletionBlock:")]
		void OnDisconnectSetValue ([NullAllowed] NSObject value, [NullAllowed] NSObject priority, Action<NSError, FIRDatabaseReference> block);

		// -(void)onDisconnectRemoveValue;
		[Export ("onDisconnectRemoveValue")]
		void OnDisconnectRemoveValue ();

		// -(void)onDisconnectRemoveValueWithCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Export ("onDisconnectRemoveValueWithCompletionBlock:")]
		void OnDisconnectRemoveValueWithCompletionBlock (Action<NSError, FIRDatabaseReference> block);

		// -(void)onDisconnectUpdateChildValues:(NSDictionary * _Nonnull)values;
		[Export ("onDisconnectUpdateChildValues:")]
		void OnDisconnectUpdateChildValues (NSDictionary values);

		// -(void)onDisconnectUpdateChildValues:(NSDictionary * _Nonnull)values withCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Export ("onDisconnectUpdateChildValues:withCompletionBlock:")]
		void OnDisconnectUpdateChildValues (NSDictionary values, Action<NSError, FIRDatabaseReference> block);

		// -(void)cancelDisconnectOperations;
		[Export ("cancelDisconnectOperations")]
		void CancelDisconnectOperations ();

		// -(void)cancelDisconnectOperationsWithCompletionBlock:(void (^ _Nullable)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Export ("cancelDisconnectOperationsWithCompletionBlock:")]
		void CancelDisconnectOperationsWithCompletionBlock ([NullAllowed] Action<NSError, FIRDatabaseReference> block);

		// +(void)goOffline;
		[Static]
		[Export ("goOffline")]
		void GoOffline ();

		// +(void)goOnline;
		[Static]
		[Export ("goOnline")]
		void GoOnline ();

		// -(void)runTransactionBlock:(FIRTransactionResult * _Nonnull (^ _Nonnull)(FIRMutableData * _Nonnull))block;
		[Export ("runTransactionBlock:")]
		void RunTransactionBlock (Func<FIRMutableData, FIRTransactionResult> block);

		// -(void)runTransactionBlock:(FIRTransactionResult * _Nonnull (^ _Nonnull)(FIRMutableData * _Nonnull))block andCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, BOOL, FIRDataSnapshot * _Nullable))completionBlock;
		[Export ("runTransactionBlock:andCompletionBlock:")]
		void RunTransactionBlock (Func<FIRMutableData, FIRTransactionResult> block, Action<NSError, bool, FIRDataSnapshot> completionBlock);

		// -(void)runTransactionBlock:(FIRTransactionResult * _Nonnull (^ _Nonnull)(FIRMutableData * _Nonnull))block andCompletionBlock:(void (^ _Nullable)(NSError * _Nullable, BOOL, FIRDataSnapshot * _Nullable))completionBlock withLocalEvents:(BOOL)localEvents;
		[Export ("runTransactionBlock:andCompletionBlock:withLocalEvents:")]
		void RunTransactionBlock (Func<FIRMutableData, FIRTransactionResult> block, [NullAllowed] Action<NSError, bool, FIRDataSnapshot> completionBlock, bool localEvents);

		// -(NSString * _Nonnull)description;
		[Export ("description")]
		// [Verify (MethodToProperty)]
		string Description { get; }

		// @property (readonly, nonatomic, strong) FIRDatabaseReference * _Nullable parent;
		[NullAllowed, Export ("parent", ArgumentSemantic.Strong)]
		FIRDatabaseReference Parent { get; }

		// @property (readonly, nonatomic, strong) FIRDatabaseReference * _Nonnull root;
		[Export ("root", ArgumentSemantic.Strong)]
		FIRDatabaseReference Root { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull key;
		[Export ("key", ArgumentSemantic.Strong)]
		string Key { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull URL;
		[Export ("URL", ArgumentSemantic.Strong)]
		string URL { get; }

		// @property (readonly, nonatomic, strong) FIRDatabase * _Nonnull database;
		[Export ("database", ArgumentSemantic.Strong)]
		FIRDatabase Database { get; }
	}

	// @interface FIRDatabase : NSObject
	[BaseType (typeof(NSObject))]
	interface FIRDatabase
	{
		// +(FIRDatabase * _Nonnull)database;
		[Static]
		[Export ("database")]
		// [Verify (MethodToProperty)]
		FIRDatabase Database { get; }

		// +(FIRDatabase * _Nonnull)databaseForApp:(FIRApp * _Nonnull)app;
		[Static]
		[Export ("databaseForApp:")]
		FIRDatabase DatabaseForApp (FIRApp app);

		// @property (readonly, nonatomic, weak) FIRApp * _Nullable app;
		[NullAllowed, Export ("app", ArgumentSemantic.Weak)]
		FIRApp App { get; }

		// -(FIRDatabaseReference * _Nonnull)reference;
		[Export ("reference")]
		// [Verify (MethodToProperty)]
		FIRDatabaseReference Reference { get; }

		// -(FIRDatabaseReference * _Nonnull)referenceWithPath:(NSString * _Nonnull)path;
		[Export ("referenceWithPath:")]
		FIRDatabaseReference ReferenceWithPath (string path);

		// -(FIRDatabaseReference * _Nonnull)referenceFromURL:(NSString * _Nonnull)databaseUrl;
		[Export ("referenceFromURL:")]
		FIRDatabaseReference ReferenceFromURL (string databaseUrl);

		// -(void)purgeOutstandingWrites;
		[Export ("purgeOutstandingWrites")]
		void PurgeOutstandingWrites ();

		// -(void)goOffline;
		[Export ("goOffline")]
		void GoOffline ();

		// -(void)goOnline;
		[Export ("goOnline")]
		void GoOnline ();

		// @property (nonatomic) BOOL persistenceEnabled;
		[Export ("persistenceEnabled")]
		bool PersistenceEnabled { get; set; }

		// @property (nonatomic) NSUInteger persistenceCacheSizeBytes;
		[Export ("persistenceCacheSizeBytes")]
		nuint PersistenceCacheSizeBytes { get; set; }

		// @property (nonatomic, strong) dispatch_queue_t _Nonnull callbackQueue;
		[Export ("callbackQueue", ArgumentSemantic.Strong)]
		DispatchQueue CallbackQueue { get; set; }

		// +(void)setLoggingEnabled:(BOOL)enabled;
		[Static]
		[Export ("setLoggingEnabled:")]
		void SetLoggingEnabled (bool enabled);

		// +(NSString * _Nonnull)sdkVersion;
		[Static]
		[Export ("sdkVersion")]
		// [Verify (MethodToProperty)]
		string SdkVersion { get; }
	}
}
