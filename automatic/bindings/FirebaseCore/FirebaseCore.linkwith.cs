using ObjCRuntime;
[assembly: LinkWith ("FirebaseCore.framework", 
Frameworks = "SystemConfiguration",
LinkerFlags = "-lc++",
IsCxx = true,
SmartLink = true,
ForceLoad = true)]
