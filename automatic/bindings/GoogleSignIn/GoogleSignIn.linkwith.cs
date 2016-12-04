using ObjCRuntime;
[assembly: LinkWith ("GoogleSignIn.a", 
Frameworks = "CoreText SafariServices Security",
IsCxx = true,
SmartLink = true,
ForceLoad = true)]
