using ObjCRuntime;
[assembly: LinkWith ("FirebaseAuth.a", 
Frameworks = "Security",
IsCxx = true,
SmartLink = true,
ForceLoad = true)]
