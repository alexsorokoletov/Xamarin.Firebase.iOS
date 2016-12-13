using ObjCRuntime;
[assembly: LinkWith ("FirebaseDatabase.framework", 
Frameworks = "CFNetwork Security SystemConfiguration",
LinkerFlags = "-lc++ -licucore",
IsCxx = true,
SmartLink = true,
ForceLoad = true)]
