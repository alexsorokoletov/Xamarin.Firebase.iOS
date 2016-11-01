using ObjCRuntime;
[assembly: LinkWith ("FirebaseCore.a", 
Frameworks = "SystemConfiguration",
LinkerFlags = "-lc++",
IsCxx = true,
SmartLink = true,
ForceLoad = true)]
