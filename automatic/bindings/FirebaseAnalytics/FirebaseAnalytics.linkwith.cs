using ObjCRuntime;
[assembly: LinkWith ("FirebaseAnalytics.a", 
Frameworks = "StoreKit",
LinkerFlags = "-lc++ -lsqlite3 -lz",
IsCxx = true,
SmartLink = true,
ForceLoad = true)]
