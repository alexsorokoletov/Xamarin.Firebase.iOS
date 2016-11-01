using ObjCRuntime;
[assembly: LinkWith ("FirebaseDatabase.a", 
Frameworks = "CFNetwork Security SystemConfiguration",
LinkerFlags = "-lc++ -licucore",
IsCxx = true,
SmartLink = true,
ForceLoad = true)]
