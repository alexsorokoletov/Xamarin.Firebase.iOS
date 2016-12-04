using ObjCRuntime;
[assembly: LinkWith ("GTMOAuth2.a", 
Frameworks = "Security SystemConfiguration",
IsCxx = true,
SmartLink = true,
ForceLoad = true)]
